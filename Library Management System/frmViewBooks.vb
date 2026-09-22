Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class frmViewBooks

    ' ====================================================================================
    ' 1. CLASS-LEVEL VARIABLES & SESSION ROLES
    ' ====================================================================================
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString
    Private catalogTable As New DataTable()

    ' Wire these dynamically to your application's active session state upon form load
    Public CurrentUserRole As String = "Member" ' Flips between "Admin" and "Member"/"User"
    Public CurrentMemberID As String = "MB001"  ' Active patron ID for requests

    Public Sub New()
        InitializeComponent()
    End Sub

    ' ====================================================================================
    ' 2. FORM INITIALIZATION
    ' ====================================================================================
    Private Sub frmViewBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigurePermissions()
            SetupDataGridView()
        Catch ex As Exception
            MessageBox.Show("UI Setup Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' Dynamically control Request button visibility based on role
    Private Sub ConfigurePermissions()
        If btnRequest IsNot Nothing Then
            If CurrentUserRole.Equals("Member", StringComparison.OrdinalIgnoreCase) OrElse
               CurrentUserRole.Equals("User", StringComparison.OrdinalIgnoreCase) Then
                btnRequest.Visible = True
            Else
                btnRequest.Visible = False ' Hidden for Admin / Staff
            End If
        End If
    End Sub

    Private Async Sub frmViewBooks_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Load database data only AFTER the window is rendered on screen
        Await LoadCatalogFromDatabase()
    End Sub

    Private Sub SetupDataGridView()
        If dgvCatalog IsNot Nothing Then
            With dgvCatalog
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeRows = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End With
        End If
    End Sub

    ' ====================================================================================
    ' 3. ASYNC DATABASE FETCH
    ' ====================================================================================
    Public Async Function LoadCatalogFromDatabase() As Task
        Me.Text = "Book Catalog Viewer - Connecting..."

        Dim localStr As String = EnsureTimeout(localConnString)
        Dim remoteStr As String = EnsureTimeout(remoteConnString)
        Dim query As String = "SELECT book_id, isbn, title, author, category, total_copies, available_copies FROM books"
        Dim connectionTargets() As String = {localStr, remoteStr}
        Dim connected As Boolean = False
        Dim isRemote As Boolean = False
        Dim conn As New MySqlConnection()

        For i As Integer = 0 To connectionTargets.Length - 1
            Dim currentTarget As String = connectionTargets(i)
            If String.IsNullOrWhiteSpace(currentTarget) Then Continue For

            Try
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.ConnectionString = currentTarget

                Await conn.OpenAsync()

                connected = True
                isRemote = (i > 0)
                Exit For
            Catch ex As Exception
                ' Keep loop moving to next server target
            End Try
        Next

        If Not connected Then
            conn.Dispose()
            Me.Text = "Book Catalog Viewer (Offline)"
            MessageBox.Show("Unable to connect to Local or Remote databases." & vbCrLf &
                            "Please ensure MySQL server (XAMPP) is running.",
                            "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If

        Try
            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    catalogTable.Clear()

                    Await Task.Run(Sub() adapter.Fill(catalogTable))

                    If dgvCatalog IsNot Nothing Then
                        dgvCatalog.DataSource = catalogTable
                        FormatGridHeaders()
                    End If
                End Using
            End Using

            Me.Text = If(isRemote, "Book Catalog Viewer (Connected to Remote Server)", "Book Catalog Viewer (Connected to Local Server)")

        Catch ex As Exception
            MessageBox.Show("Error reading book catalog: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            End If
        End Try
    End Function

    Private Sub FormatGridHeaders()
        If dgvCatalog.Columns.Count > 0 Then
            If dgvCatalog.Columns.Contains("book_id") Then dgvCatalog.Columns("book_id").HeaderText = "Book ID"
            If dgvCatalog.Columns.Contains("isbn") Then dgvCatalog.Columns("isbn").HeaderText = "ISBN"
            If dgvCatalog.Columns.Contains("title") Then dgvCatalog.Columns("title").HeaderText = "Title"
            If dgvCatalog.Columns.Contains("author") Then dgvCatalog.Columns("author").HeaderText = "Author"
            If dgvCatalog.Columns.Contains("category") Then dgvCatalog.Columns("category").HeaderText = "Category"
            If dgvCatalog.Columns.Contains("total_copies") Then dgvCatalog.Columns("total_copies").HeaderText = "Total Copies"
            If dgvCatalog.Columns.Contains("available_copies") Then dgvCatalog.Columns("available_copies").HeaderText = "Available"

            If dgvCatalog.Columns.Contains("book_id") Then dgvCatalog.Columns("book_id").FillWeight = 60
            If dgvCatalog.Columns.Contains("isbn") Then dgvCatalog.Columns("isbn").FillWeight = 90
            If dgvCatalog.Columns.Contains("title") Then dgvCatalog.Columns("title").FillWeight = 150
            If dgvCatalog.Columns.Contains("author") Then dgvCatalog.Columns("author").FillWeight = 120
            If dgvCatalog.Columns.Contains("category") Then dgvCatalog.Columns("category").FillWeight = 100
            If dgvCatalog.Columns.Contains("total_copies") Then dgvCatalog.Columns("total_copies").FillWeight = 70
            If dgvCatalog.Columns.Contains("available_copies") Then dgvCatalog.Columns("available_copies").FillWeight = 70
        End If
    End Sub

    Private Function EnsureTimeout(connStr As String) As String
        If String.IsNullOrWhiteSpace(connStr) Then Return ""
        If Not connStr.ToLower().Contains("connect timeout") AndAlso Not connStr.ToLower().Contains("connection timeout") Then
            If Not connStr.Trim().EndsWith(";") Then connStr &= ";"
            connStr &= "Connect Timeout=3;"
        End If
        Return connStr
    End Function

    ' ====================================================================================
    ' 4. LIVE SEARCH FILTER
    ' ====================================================================================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim filterText As String = txtSearch.Text.Trim().Replace("'", "''")

            If filterText = "" Then
                catalogTable.DefaultView.RowFilter = ""
            Else
                catalogTable.DefaultView.RowFilter = String.Format("[title] LIKE '%{0}%' OR [author] LIKE '%{0}%' OR [isbn] LIKE '%{0}%' OR [category] LIKE '%{0}%'", filterText)
            End If
        Catch ex As Exception
            catalogTable.DefaultView.RowFilter = ""
        End Try
    End Sub

    ' ====================================================================================
    ' 5. REQUEST BOOK & FORM ACTIONS
    ' ====================================================================================
    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' 1. Validate grid selection
        If dgvCatalog IsNot Nothing AndAlso dgvCatalog.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a book from the list to request.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = dgvCatalog.SelectedRows(0)
        Dim targetBookID As String = selectedRow.Cells("book_id").Value.ToString()
        Dim bookTitle As String = selectedRow.Cells("title").Value.ToString()
        Dim availableCopies As Integer = Convert.ToInt32(selectedRow.Cells("available_copies").Value)

        ' 2. Check stock availability
        If availableCopies <= 0 Then
            MessageBox.Show("Sorry, '" & bookTitle & "' is currently out of stock.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3. Confirm submission with user
        Dim confirm As DialogResult = MessageBox.Show("Submit a hold request for '" & bookTitle & "'?",
                                                    "Confirm Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Exit Sub

        ' 4. Insert hold request into library_transactions
        Dim insertQuery As String = "INSERT INTO library_transactions (member_id, book_id, request_date, status) " &
                                   "VALUES (@mID, @bID, CURDATE(), 'Requested')"

        Dim targetConn As String = EnsureTimeout(localConnString)

        Try
            Using conn As New MySqlConnection(targetConn)
                conn.Open()
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@mID", CurrentMemberID)
                    cmd.Parameters.AddWithValue("@bID", targetBookID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Book hold request for '" & bookTitle & "' logged successfully! An admin will process your request.",
                            "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Failed to log hold request: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class