Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class frmBooks

    ' 🔌 BOTH DATABASE STRINGS ACCESSIBLE FROM MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    ' ====================================================================================
    ' 1. INITIALIZATION & UX DESIGNER MODES
    ' ====================================================================================
    Private Sub frmBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ConfigureDataGridView()
        RefreshDatabaseGrid()
        ClearAndPrepareFields()
    End Sub

    Private Sub ConfigureDataGridView()
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBooks.MultiSelect = False
        dgvBooks.AllowUserToAddRows = False
        dgvBooks.AllowUserToDeleteRows = False
        dgvBooks.AllowUserToResizeRows = False
        dgvBooks.ReadOnly = True
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ====================================================================================
    ' 2. REAL-TIME INPUT FILTERS & AUTO-FORMATTING ENGINES
    ' ====================================================================================
    Private Sub txtISBN_TextChanged(sender As Object, e As EventArgs) Handles txtISBN.TextChanged
        Dim txtBox As TextBox = DirectCast(sender, TextBox)
        Dim digitsOnly As String = txtBox.Text.Replace("-", "")

        If digitsOnly.Length > 13 Then
            digitsOnly = digitsOnly.Substring(0, 13)
        End If

        Dim formattedISBN As String = digitsOnly

        If digitsOnly.Length > 3 AndAlso digitsOnly.Length <= 4 Then
            formattedISBN = digitsOnly.Insert(3, "-")
        ElseIf digitsOnly.Length > 4 AndAlso digitsOnly.Length <= 6 Then
            formattedISBN = digitsOnly.Insert(3, "-").Insert(5, "-")
        ElseIf digitsOnly.Length > 6 AndAlso digitsOnly.Length <= 12 Then
            formattedISBN = digitsOnly.Insert(3, "-").Insert(5, "-").Insert(8, "-")
        ElseIf digitsOnly.Length = 13 Then
            formattedISBN = digitsOnly.Insert(3, "-").Insert(5, "-").Insert(8, "-").Insert(15, "-")
        End If

        If txtBox.Text <> formattedISBN Then
            Dim cursorPosition As Integer = txtBox.SelectionStart
            Dim oldLength As Integer = txtBox.Text.Length

            txtBox.Text = formattedISBN

            Dim lengthDifference As Integer = txtBox.Text.Length - oldLength
            txtBox.SelectionStart = Math.Max(0, cursorPosition + lengthDifference)
        End If
    End Sub

    Private Sub txtISBN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtISBN.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-"c AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub txtTitle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTitle.KeyPress
    '    If Char.IsDigit(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtAuthor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAuthor.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ====================================================================================
    ' 3. FORM VALIDATION CONTROL ROUTINES
    ' ====================================================================================
    Private Function ValidateFormInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtISBN.Text) OrElse
           String.IsNullOrWhiteSpace(txtTitle.Text) OrElse
           String.IsNullOrWhiteSpace(txtAuthor.Text) Then
            MessageBox.Show("All entry fields are mandatory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbCategory.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbCategory.Text) Then
            MessageBox.Show("Please select a valid library category classification.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim cleanISBN As String = txtISBN.Text.Replace("-", "").Trim()
        If cleanISBN.Length <> 13 OrElse Not Regex.IsMatch(cleanISBN, "^[0-9]+$") Then
            MessageBox.Show("Invalid ISBN. The system strictly requires a modern standard 13-digit code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If numTotalCopies.Value < 1 Then
            MessageBox.Show("Total stock quantities cannot be zero or negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' ====================================================================================
    ' 4. LIVE DATABASE SYNC & PROFESSIONAL ALPHANUMERIC ID SEQUENCING
    ' ====================================================================================
    Private Sub RefreshDatabaseGrid()
        Try
            Dim query As String = "SELECT book_id, isbn, title, author, category, total_copies, available_copies FROM books"
            Using conn As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New System.Data.DataTable()
                        adapter.Fill(dt)
                        dgvBooks.DataSource = dt

                        dgvBooks.Columns("book_id").Width = 80
                        dgvBooks.Columns("isbn").Width = 140
                        dgvBooks.Columns("total_copies").Width = 90
                        dgvBooks.Columns("available_copies").Width = 110

                        dgvBooks.Columns("book_id").HeaderText = "Book ID"
                        dgvBooks.Columns("isbn").HeaderText = "ISBN"
                        dgvBooks.Columns("title").HeaderText = "Title"
                        dgvBooks.Columns("author").HeaderText = "Author"
                        dgvBooks.Columns("category").HeaderText = "Category"
                        dgvBooks.Columns("total_copies").HeaderText = "Total Copies"
                        dgvBooks.Columns("available_copies").HeaderText = "Available Copies"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to pull local view logs: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAndPrepareFields()
        txtISBN.Clear()
        txtTitle.Clear()
        txtAuthor.Clear()
        If cmbCategory.Items.Count > 0 Then cmbCategory.SelectedIndex = -1
        numTotalCopies.Value = 1
        dgvBooks.ClearSelection()

        Try
            Dim query As String = "SELECT book_id FROM books ORDER BY book_id DESC LIMIT 1"
            Using conn As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(query, conn)
                    conn.Open()
                    Dim lastId As Object = cmd.ExecuteScalar()

                    If lastId IsNot Nothing AndAlso lastId.ToString().ToUpper().StartsWith("BK") Then
                        Dim currentNumber As Integer = Integer.Parse(lastId.ToString().Substring(2))
                        txtBookID.Text = "BK" & (currentNumber + 1).ToString("D3")
                    Else
                        txtBookID.Text = "BK001"
                    End If
                End Using
            End Using
        Catch ex As Exception
            txtBookID.Text = "BK001"
        End Try
    End Sub

    Private Sub dgvBooks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBooks.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvBooks.Rows(e.RowIndex)
            txtBookID.Text = selectedRow.Cells("book_id").Value.ToString().ToUpper()
            txtISBN.Text = selectedRow.Cells("isbn").Value.ToString()
            txtTitle.Text = selectedRow.Cells("title").Value.ToString()
            txtAuthor.Text = selectedRow.Cells("author").Value.ToString()
            cmbCategory.SelectedItem = selectedRow.Cells("category").Value.ToString()
            numTotalCopies.Value = Convert.ToDecimal(selectedRow.Cells("total_copies").Value)
        End If
    End Sub

    ' ====================================================================================
    ' 5. DATABASE MODIFIERS (SAVE, UPDATE, DELETE WITH DUAL SYNC)
    ' ====================================================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateFormInputs() Then Exit Sub

        Dim localSaved As Boolean = False
        Dim remoteSaved As Boolean = False

        ' --- 1. LOCAL TRANSACTION ---
        Try
            Using connLocal As New MySqlConnection(localConnString)
                connLocal.Open()
                Dim checkQuery As String = "SELECT COUNT(*) FROM books WHERE isbn = @isbn"
                Using checkCmd As New MySqlCommand(checkQuery, connLocal)
                    checkCmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("A book profile with this exact ISBN is already registered in the Local system.", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using

                Dim query As String = "INSERT INTO books (book_id, isbn, title, author, category, total_copies, available_copies) VALUES (@id, @isbn, @title, @author, @category, @total, @total)"
                Using cmd As New MySqlCommand(query, connLocal)
                    cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim())
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
                    cmd.Parameters.AddWithValue("@total", numTotalCopies.Value)
                    cmd.ExecuteNonQuery()
                End Using
                localSaved = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Local SQL transaction aborted: " & ex.Message, "Local Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub ' Stop if local save fails to prevent data fragmentation
        End Try

        ' --- 2. REMOTE TRANSACTION (PC 2) ---
        Try
            Using connRemote As New MySqlConnection(remoteConnString)
                connRemote.Open()

                ' Check duplicate on remote server in case database was modified independently
                Dim checkQuery As String = "SELECT COUNT(*) FROM books WHERE isbn = @isbn OR book_id = @id"
                Using checkCmd As New MySqlCommand(checkQuery, connRemote)
                    checkCmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        ' If conflicting entry exists, skip writing but don't break local execution flow
                        Throw New Exception("Record conflict or duplicate primary key detected on Remote Engine.")
                    End If
                End Using
                Dim query As String = "INSERT INTO books (book_id, isbn, title, author, category, total_copies, available_copies) VALUES (@id, @isbn, @title, @author, @category, @total, @total)"
                Using cmd As New MySqlCommand(query, connRemote)
                    cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim())
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
                    cmd.Parameters.AddWithValue("@total", numTotalCopies.Value)
                    cmd.ExecuteNonQuery()
                End Using
                remoteSaved = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Remote (PC 2) Sync Interrupted: " & ex.Message & vbCrLf & "Local record was safely committed.", "Sync Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' --- 3. VERDICT ENGINE UI ---
        If localSaved And remoteSaved Then
            MessageBox.Show("Inventory entry logged completely across both instances!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf localSaved Then
            MessageBox.Show("Inventory entry logged locally, but Remote (PC 2) synchronization failed.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        RefreshDatabaseGrid()
        ClearAndPrepareFields()
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not ValidateFormInputs() Then Exit Sub

        Dim localUpdated As Boolean = False
        Dim remoteUpdated As Boolean = False
        Dim oldTotal As Integer = 0
        Dim oldAvailable As Integer = 0

        ' --- 1. LOCAL LOGIC CHECK & UPDATE ---
        Try
            Using connLocal As New MySqlConnection(localConnString)
                connLocal.Open()
                Dim fetchQuery As String = "SELECT total_copies, available_copies FROM books WHERE book_id=@id"
                Using fetchCmd As New MySqlCommand(fetchQuery, connLocal)
                    fetchCmd.Parameters.AddWithValue("@id", txtBookID.Text)
                    Using reader As MySqlDataReader = fetchCmd.ExecuteReader()
                        If reader.Read() Then
                            oldTotal = Convert.ToInt32(reader("total_copies"))
                            oldAvailable = Convert.ToInt32(reader("available_copies"))
                        End If
                    End Using
                End Using

                Dim currentlyBorrowed As Integer = oldTotal - oldAvailable
                Dim newTotal As Integer = Convert.ToInt32(numTotalCopies.Value)
                Dim newAvailable As Integer = newTotal - currentlyBorrowed

                If newAvailable < 0 Then
                    MessageBox.Show("Cannot lower total stock. There are currently " & currentlyBorrowed & " copies of this book actively checked out locally.", "Inventory Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim query As String = "UPDATE books SET isbn=@isbn, title=@title, author=@author, category=@category, total_copies=@total, available_copies=@available WHERE book_id=@id"
                Using cmd As New MySqlCommand(query, connLocal)
                    cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim())
                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
                    cmd.Parameters.AddWithValue("@total", newTotal)
                    cmd.Parameters.AddWithValue("@available", newAvailable)
                    If cmd.ExecuteNonQuery() > 0 Then
                        localUpdated = True
                        Dim openForm As frmViewBooks = My.Application.OpenForms.OfType(Of frmViewBooks)().FirstOrDefault()
                        If openForm IsNot Nothing Then Await openForm.LoadCatalogFromDatabase()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Local update aborted: " & ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Skip Remote database 


        ' --- 2. REMOTE UPDATE (PC 2) ---
        'If localUpdated Then
        '    Try
        '        Using connRemote As New MySqlConnection(remoteConnString)
        '            connRemote.Open()

        '            ' Fetch remote record metrics independently to ensure safety compliance
        '            Dim rOldTotal As Integer = 0
        '            Dim rOldAvailable As Integer = 0
        '            Dim rFetchQuery As String = "SELECT total_copies, available_copies FROM books WHERE book_id=@id"

        '            Using fetchCmd As New MySqlCommand(rFetchQuery, connRemote)
        '                fetchCmd.Parameters.AddWithValue("@id", txtBookID.Text)
        '                Using reader As MySqlDataReader = fetchCmd.ExecuteReader()
        '                    If reader.Read() Then
        '                        rOldTotal = Convert.ToInt32(reader("total_copies"))
        '                        rOldAvailable = Convert.ToInt32(reader("available_copies"))
        '                    End If
        '                End Using
        '            End Using

        '            Dim rCurrentlyBorrowed As Integer = rOldTotal - rOldAvailable
        '            Dim newTotal As Integer = Convert.ToInt32(numTotalCopies.Value)
        '            Dim rNewAvailable As Integer = newTotal - rCurrentlyBorrowed

        '            If rNewAvailable >= 0 Then
        '                Dim query As String = "UPDATE books SET isbn=@isbn, title=@title, author=@author, category=@category, total_copies=@total, available_copies=@available WHERE book_id=@id"
        '                Using cmd As New MySqlCommand(query, connRemote)
        '                    cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
        '                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim())
        '                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
        '                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim())
        '                    cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
        '                    cmd.Parameters.AddWithValue("@total", newTotal)
        '                    cmd.Parameters.AddWithValue("@available", rNewAvailable)

        '                    If cmd.ExecuteNonQuery() > 0 Then remoteUpdated = True
        '                End Using
        '            End If
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show("Remote (PC 2) Update Sync Failed: " & ex.Message, "Sync Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End Try
        'End If

        ' --- 3. FINAL MESSAGING ENGINE ---
        'If localUpdated And remoteUpdated Then
        '    MessageBox.Show("Live inventory updated globally across both nodes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ElseIf localUpdated Then
        If localUpdated Then
            MessageBox.Show("Live inventory updated locally, but remote link dropped out.", "Partial Sync", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("No changes made. Select a valid row target.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        RefreshDatabaseGrid()
        ClearAndPrepareFields()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(txtBookID.Text) Then
            MessageBox.Show("Please pick a record row from the database grid to drop.", "Target Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to drop record " & txtBookID.Text & " permanently across both systems?",
                                                            "Confirm Data Destruction", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then Exit Sub

        Dim localDeleted As Boolean = False
        Dim remoteDeleted As Boolean = False

        ' --- 1. LOCAL ENGINE PURGE ---
        Try
            Using connLocal As New MySqlConnection(localConnString)
                connLocal.Open()
                Dim query As String = "DELETE FROM books WHERE book_id=@id"
                Using cmd As New MySqlCommand(query, connLocal)
                    cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
                    cmd.ExecuteNonQuery()
                End Using
                localDeleted = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Local delete transaction failed: " & ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' --- 2. REMOTE ENGINE PURGE (PC 2) ---
        'Try
        '    Using connRemote As New MySqlConnection(remoteConnString)
        '        connRemote.Open()
        '        Dim query As String = "DELETE FROM books WHERE book_id=@id"
        '        Using cmd As New MySqlCommand(query, connRemote)
        '            cmd.Parameters.AddWithValue("@id", txtBookID.Text.ToUpper())
        '            cmd.ExecuteNonQuery()
        '        End Using
        '        remoteDeleted = True
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("Remote Purge Blocked: Server was unreachable or the record was not found.", "Sync Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End Try

        ' --- 3. NOTIFICATION DISPATCHER ---

        ' Skip Remote database 
        'If localDeleted And remoteDeleted Then
        '    MessageBox.Show("Entry dropped completely from both database platforms.", "Purge Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Else
        MessageBox.Show("Entry dropped locally only. Remote record left unaltered.", "Partial Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        RefreshDatabaseGrid()
        ClearAndPrepareFields()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAndPrepareFields()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim dialog As DialogResult = MessageBox.Show("Are you sure you want to close the Book Management form?",
                                                     "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' --- INSTANT CHARACTER FILTER FOR THE INVENTORY GRID ---
    Private Sub txtSearchInventory_TextChanged(sender As Object, e As EventArgs) Handles txtSearchInventory.TextChanged
        Try
            Dim filterText As String = txtSearchInventory.Text.Trim().Replace("'", "''")

            If dgvBooks.DataSource IsNot Nothing AndAlso TypeOf dgvBooks.DataSource Is DataTable Then
                Dim dt As DataTable = CType(dgvBooks.DataSource, DataTable)

                If filterText = "" Then
                    dt.DefaultView.RowFilter = ""
                Else
                    dt.DefaultView.RowFilter = String.Format("[title] LIKE '%{0}%' OR [category] LIKE '%{0}%'", filterText)
                End If
            End If
        Catch ex As Exception
            If dgvBooks.DataSource IsNot Nothing AndAlso TypeOf dgvBooks.DataSource Is DataTable Then
                CType(dgvBooks.DataSource, DataTable).DefaultView.RowFilter = ""
            End If
        End Try
    End Sub
End Class