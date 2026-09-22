Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmManageTransactions

    ' 🔌 SYSTEM DATA HUB PLATFORMS LINK CONFIGURATION via MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    ' --- REAL-WORLD USER SESSION MANAGEMENT HUB ---
    Public CurrentUserRole As String = "Admin" ' Dynamically flips between "Admin" and "User"
    Public CurrentMemberID As String = "MB001" ' Active member account key

    Private Sub frmManageTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupDataGridView()
            ConfigurePermissions()
            DisplayTransactions()
        Catch ex As Exception
            MessageBox.Show("Initialization Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupDataGridView()
        With dgvTransactions
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnCount = 6
            .Columns(0).Name = "Tx ID"
            .Columns(1).Name = "Member ID"
            .Columns(2).Name = "Book ID"
            .Columns(3).Name = "Status"
            .Columns(4).Name = "Request/Issue Date"
            .Columns(5).Name = "Due Date"
        End With
    End Sub

    Private Sub ConfigurePermissions()
        If CurrentUserRole = "User" Then
            txtTxID.Text = "AUTO-GEN"
            txtTxID.Enabled = False

            txtMemberID.Text = CurrentMemberID
            txtMemberID.Enabled = False

            btnIssue.Text = "SUBMIT REQUEST"
            btnReturn.Visible = False
            dtpIssue.Enabled = False

            If lblTitleBlock IsNot Nothing Then lblTitleBlock.Text = "Personal Library Dashboard (User Mode)"
        Else
            txtTxID.Text = ""
            txtTxID.Enabled = False
            txtMemberID.Text = ""
            txtMemberID.Enabled = True

            btnIssue.Text = "ISSUE"
            btnReturn.Visible = True
            btnReturn.Enabled = True
            dtpIssue.Enabled = True

            If lblTitleBlock IsNot Nothing Then lblTitleBlock.Text = "Global Transactions Management Panel (Admin Mode)"
        End If
    End Sub

    ' ====================================================================================
    ' DATABASE READ MANAGEMENT ENGINE
    ' ====================================================================================
    Public Sub DisplayTransactions()
        Dim query As String = "SELECT transaction_id, member_id, book_id, request_date, issue_date, due_date, status FROM library_transactions"

        If CurrentUserRole = "User" Then
            query &= " WHERE member_id = @memId"
        End If
        query &= " ORDER BY transaction_id DESC"

        Dim activeConnString As String = localConnString
        Dim fallbackAttempted As Boolean = False
        Using conn As New MySqlConnection()
            Try
                conn.ConnectionString = activeConnString
                conn.Open()
            Catch localEx As Exception
                Try
                    activeConnString = remoteConnString
                    conn.ConnectionString = activeConnString
                    conn.Open()
                    fallbackAttempted = True
                Catch remoteEx As Exception
                    MessageBox.Show("Hardware Link Failure: Could not load data records from local server or remote backup instance.", "Network Offline", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End Try

            Try
                dgvTransactions.Rows.Clear()
                Using cmd As New MySqlCommand(query, conn)
                    If CurrentUserRole = "User" Then cmd.Parameters.AddWithValue("@memId", CurrentMemberID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Direct string retrieval prevents FormatException on VARCHAR fields
                            Dim displayTxID As String = reader("transaction_id").ToString()
                            Dim displayMemID As String = reader("member_id").ToString()
                            Dim displayBookID As String = reader("book_id").ToString()
                            Dim statusText As String = reader("status").ToString()

                            Dim dateTracker As String = "-"
                            If statusText = "Requested" Then
                                dateTracker = If(IsDBNull(reader("request_date")), "-", Convert.ToDateTime(reader("request_date")).ToString("yyyy-MM-dd"))
                            Else
                                dateTracker = If(IsDBNull(reader("issue_date")), "-", Convert.ToDateTime(reader("issue_date")).ToString("yyyy-MM-dd"))
                            End If

                            Dim dueDateText As String = If(IsDBNull(reader("due_date")), "-", Convert.ToDateTime(reader("due_date")).ToString("yyyy-MM-dd"))

                            dgvTransactions.Rows.Add(displayTxID, displayMemID, displayBookID, statusText, dateTracker, dueDateText)
                        End While
                    End Using
                End Using

                Me.Text = If(fallbackAttempted, "Manage Transactions Ledger (Connected to Remote Mirror)", "Manage Transactions Ledger (Connected to Local Server)")

            Catch ex As Exception
                MessageBox.Show("Error occurred while gathering records: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' ====================================================================================
    ' ACTION MODIFIERS (ISSUE / REQUEST ENGINE)
    ' ====================================================================================
    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        Try
            Dim targetBookID As String = txtBookID.Text.Trim()
            If String.IsNullOrWhiteSpace(targetBookID) Then
                MessageBox.Show("Please enter a Book ID (e.g., BK005).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Normalize string inputs (e.g. if user types "5", convert to "BK005" format)
            If Char.IsDigit(targetBookID(0)) Then
                targetBookID = "BK" & Convert.ToInt32(targetBookID).ToString("D3")
            End If

            Dim targetMemberID As String = CurrentMemberID
            If CurrentUserRole = "Admin" Then
                targetMemberID = txtMemberID.Text.Trim()
                If String.IsNullOrWhiteSpace(targetMemberID) Then
                    MessageBox.Show("Please enter a Member ID (e.g., MB001).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Char.IsDigit(targetMemberID(0)) Then
                    targetMemberID = "MB" & Convert.ToInt32(targetMemberID).ToString("D3")
                End If
            End If

            ' --- STEP 1: VERIFY STOCK AVAILABILITY (QUERIES VARCHAR book_id EXACT MATCH) ---
            Dim bookAvailable As Boolean = False
            Dim currentStockCount As Integer = 0

            Using connCheck As New MySqlConnection(localConnString)
                Try
                    connCheck.Open()
                Catch
                    connCheck.ConnectionString = remoteConnString
                    connCheck.Open()
                End Try

                ' String comparison matching your phpMyAdmin VARCHAR structure
                Dim checkQuery As String = "SELECT available_copies FROM books WHERE UPPER(TRIM(book_id)) = UPPER(@bID) OR isbn = @bID"
                Using chkCmd As New MySqlCommand(checkQuery, connCheck)
                    chkCmd.Parameters.AddWithValue("@bID", targetBookID)
                    Dim result = chkCmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        bookAvailable = True
                        currentStockCount = Convert.ToInt32(result)
                    End If
                End Using
            End Using

            If Not bookAvailable Then
                MessageBox.Show("Validation Terminated: Targeted Book ID '" & targetBookID & "' does not exist in the catalog registers.", "Missing Asset", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If currentStockCount <= 0 Then
                MessageBox.Show("Transaction Aborted: This specific book title is currently out of stock.", "No Copies Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- STEP 2: DEFINE EXECUTION PARAMETERS AND QUERIES ---
            Dim localSuccess As Boolean = False
            Dim query As String = ""

            If CurrentUserRole = "User" Then
                query = "INSERT INTO library_transactions (member_id, book_id, request_date, status) VALUES (@mID, @bID, CURDATE(), 'Requested')"
            Else
                If dgvTransactions.SelectedRows.Count = 0 Then
                    MessageBox.Show("Please select a pending 'Requested' row item from the grid view to approve.", "Selection Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim selectedStatus As String = dgvTransactions.SelectedRows(0).Cells("Status").Value.ToString()
                If selectedStatus <> "Requested" Then
                    MessageBox.Show("Direct issuing requires highlighting a row currently marked as 'Requested'.", "Invalid Target", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim targetTxID As String = dgvTransactions.SelectedRows(0).Cells("Tx ID").Value.ToString()

                query = "UPDATE library_transactions SET issue_date = CURDATE(), due_date = DATE_ADD(CURDATE(), INTERVAL 14 DAY), status = 'Issued' WHERE transaction_id = @tID; " &
                        "UPDATE books SET available_copies = available_copies - 1 WHERE UPPER(TRIM(book_id)) = UPPER(@bID);"
            End If

            ' --- STEP 3: RUN PARALLEL WRITE INSERTS ---
            Try
                Using connL As New MySqlConnection(localConnString)
                    Using cmdL As New MySqlCommand(query, connL)
                        connL.Open()
                        cmdL.Parameters.AddWithValue("@mID", targetMemberID)
                        cmdL.Parameters.AddWithValue("@bID", targetBookID)
                        If CurrentUserRole <> "User" Then
                            cmdL.Parameters.AddWithValue("@tID", dgvTransactions.SelectedRows(0).Cells("Tx ID").Value.ToString())
                        End If
                        cmdL.ExecuteNonQuery()
                        localSuccess = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Local transaction commit operation failed: " & ex.Message, "PC 1 Write Halt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Mirror to Remote instance if online
            Try
                Using connR As New MySqlConnection(remoteConnString)
                    Using cmdR As New MySqlCommand(query, connR)
                        connR.Open()
                        cmdR.Parameters.AddWithValue("@mID", targetMemberID)
                        cmdR.Parameters.AddWithValue("@bID", targetBookID)
                        If CurrentUserRole <> "User" Then
                            cmdR.Parameters.AddWithValue("@tID", dgvTransactions.SelectedRows(0).Cells("Tx ID").Value.ToString())
                        End If
                        cmdR.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                ' Silent remote sync warning
            End Try

            If localSuccess Then
                MessageBox.Show(If(CurrentUserRole = "User", "Book reservation hold request logged successfully!", "Book checkout authorization complete!"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            DisplayTransactions()
            txtBookID.Clear()
            If CurrentUserRole = "Admin" Then txtMemberID.Clear()

        Catch ex As Exception
            MessageBox.Show("Error processing transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ====================================================================================
    ' RETURN MUTATION ENGINE
    ' ====================================================================================
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If CurrentUserRole = "User" Then Exit Sub

        Try
            If dgvTransactions.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select an active transaction row from the grid layout.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim currentStatus = dgvTransactions.SelectedRows(0).Cells("Status").Value.ToString()
            If currentStatus <> "Issued" Then
                MessageBox.Show("Returns can only be processed against lines explicitly marked as 'Issued'.", "Invalid Target", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim targetTxID As String = dgvTransactions.SelectedRows(0).Cells("Tx ID").Value.ToString()
            Dim targetBookID As String = dgvTransactions.SelectedRows(0).Cells("Book ID").Value.ToString()

            Dim updateQuery As String = "UPDATE library_transactions SET return_date = CURDATE(), status = 'Returned' WHERE transaction_id = @tID; " &
                                        "UPDATE books SET available_copies = available_copies + 1 WHERE UPPER(TRIM(book_id)) = UPPER(@bID);"

            Dim localSuccess As Boolean = False

            Using connL As New MySqlConnection(localConnString)
                Using cmdL As New MySqlCommand(updateQuery, connL)
                    connL.Open()
                    cmdL.Parameters.AddWithValue("@tID", targetTxID)
                    cmdL.Parameters.AddWithValue("@bID", targetBookID)
                    cmdL.ExecuteNonQuery()
                    localSuccess = True
                End Using
            End Using

            ' Try remote mirror
            Try
                Using connR As New MySqlConnection(remoteConnString)
                    Using cmdR As New MySqlCommand(updateQuery, connR)
                        connR.Open()
                        cmdR.Parameters.AddWithValue("@tID", targetTxID)
                        cmdR.Parameters.AddWithValue("@bID", targetBookID)
                        cmdR.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                ' Silent remote failover warning
            End Try

            If localSuccess Then
                MessageBox.Show("Asset check-in processed successfully! Stock balances replenished.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            DisplayTransactions()
            txtBookID.Clear()
            txtMemberID.Clear()

        Catch ex As Exception
            MessageBox.Show("Error returning book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvTransactions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactions.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvTransactions.Rows(e.RowIndex)

            txtTxID.Text = selectedRow.Cells("Tx ID").Value?.ToString()
            txtMemberID.Text = selectedRow.Cells("Member ID").Value?.ToString()
            txtBookID.Text = selectedRow.Cells("Book ID").Value?.ToString()

            Dim dateStr As String = selectedRow.Cells("Request/Issue Date").Value?.ToString()
            Dim parsedDate As DateTime
            If DateTime.TryParse(dateStr, parsedDate) Then
                dtpIssue.Value = parsedDate
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtTxID.Clear()
        txtBookID.Clear()
        txtMemberID.Clear()
        If txtFine IsNot Nothing Then txtFine.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class