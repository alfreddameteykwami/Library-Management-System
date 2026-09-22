Imports MySql.Data.MySqlClient

Public Class frmMembers
    ' 🔌 BOTH DATABASE STRINGS ACCESSIBLE FROM MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    ' Local storage DataTable configured to hold the alphanumeric formatting for dgvMembers binding
    Private viewTable As New DataTable()

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximumSize = New Size(0, 0)
        Me.Width = 900

        dgvMembers.Width = Me.ClientSize.Width - dgvMembers.Left - 40

        ' Keep Member ID control locked as an automatic tracker
        txtMemberID.ReadOnly = True
        txtMemberID.BackColor = SystemColors.Control
        txtFullName.Focus()
        txtMemberID.Text = GetNextMemberID()

        Try
            SetupDataGridView()
            LoadMembersFromDatabase()
        Catch ex As Exception
            MessageBox.Show("Initialization failure: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupDataGridView()
        dgvMembers.AllowUserToAddRows = False
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMembers.MultiSelect = False
        dgvMembers.AllowUserToDeleteRows = False
        dgvMembers.AllowUserToResizeRows = False
        dgvMembers.ReadOnly = True

        ' Construct display table schema mapping
        viewTable.Columns.Clear()
        viewTable.Columns.Add("member_id", GetType(String))
        viewTable.Columns.Add("full_name", GetType(String))
        viewTable.Columns.Add("phone", GetType(String))
        viewTable.Columns.Add("email", GetType(String))
        viewTable.Columns.Add("status", GetType(String))
        dgvMembers.DataSource = viewTable

        ' Set clean column header titles
        dgvMembers.Columns("member_id").HeaderText = "Member ID"
        dgvMembers.Columns("full_name").HeaderText = "Full Name"
        dgvMembers.Columns("phone").HeaderText = "Phone"
        dgvMembers.Columns("email").HeaderText = "Email"
        dgvMembers.Columns("status").HeaderText = "Status"
    End Sub

    Private Function GetNextMemberID() As String
        Dim nextID As String = "MB001"
        Try
            Using conn As New MySqlConnection(localConnString)
                Dim query As String = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " &
                                      "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'members'"
                Using cmd As New MySqlCommand(query, conn)
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Dim rawID As Long = Convert.ToInt64(result)
                        nextID = "MB" & rawID.ToString("D3")
                    End If
                End Using
            End Using
        Catch ex As Exception
            nextID = "AUTO-GEN"
        End Try
        Return nextID
    End Function

    ' --- FETCH ENGINE WITH APP-LEVEL ALPHANUMERIC FORMATTING ---
    Public Sub LoadMembersFromDatabase()
        Try
            Dim query As String = "SELECT member_id, full_name, phone, email, status FROM members"
            Using conn As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(query, conn)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        viewTable.Rows.Clear()
                        While reader.Read()
                            Dim rawID As Integer = Convert.ToInt32(reader("member_id"))
                            Dim formattedID As String = "MB" & rawID.ToString("D3")
                            viewTable.Rows.Add(formattedID, reader("full_name").ToString(), reader("phone").ToString(), reader("email").ToString(), reader("status").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed loading rows: " & ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            If Not System.Text.RegularExpressions.Regex.IsMatch(email, pattern) Then Return False

            Dim parts() As String = email.Trim().Split("@"c)
            If parts.Length <> 2 Then Return False
            Dim domain As String = parts(1).ToLower()

            Dim allowedDomains As New List(Of String) From {
                "gmail.com", "icloud.com", "yahoo.com", "outlook.com",
                "hotmail.com", "aol.com", "zoho.com", "proton.me", "mail.com"
            }

            If allowedDomains.Contains(domain) Then Return True

            If domain.EndsWith(".edu.gh") OrElse
               domain.EndsWith(".gov.gh") OrElse
               domain.EndsWith(".org.gh") OrElse
               domain.EndsWith(".com.gh") Then
                Return True
            End If

            Return False
        Catch
            Return False
        End Try
    End Function

    Private Function ValidateForm() As Boolean
        If txtFullName.Text.Trim() = "" Then
            MessageBox.Show("Full Name is strictly required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please choose a registry Status profile.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim phoneText As String = txtPhone.Text.Trim()
        If phoneText.Length <> 10 OrElse Not IsNumeric(phoneText) Then
            MessageBox.Show("Phone field must contain exactly 10 numeric digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return False
        End If

        If txtEmail.Text.Trim() <> "" AndAlso Not IsValidEmail(txtEmail.Text.Trim()) Then
            MessageBox.Show("Please provide a structurally valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        Return True
    End Function

    ' ====================================================================================
    ' DATABASE MODIFIERS (SAVE, UPDATE, DELETE WITH DUAL SYNC)
    ' ====================================================================================

    ' --- SAVE RECORD ---
    '
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateForm() Then Exit Sub

        Dim localSaved = False
        Dim remoteSaved = False
        Dim query = "INSERT INTO members (full_name, phone, email, status) VALUES (@name, @phone, @email, @status)"

        ' 1. LOCAL LOGIC WRITE
        Try
            Using connLocal As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(query, connLocal)
                    connLocal.Open()
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim)
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
                    cmd.ExecuteNonQuery()
                    localSaved = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Local insertion failed: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' 2. REMOTE SYNC WRITE (PC 2)
        Try
            Using connRemote As New MySqlConnection(remoteConnString)
                Using cmd As New MySqlCommand(query, connRemote)
                    connRemote.Open()
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim)
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
                    cmd.ExecuteNonQuery()
                    remoteSaved = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Remote (PC 2) Sync Dropped: " & ex.Message & vbCrLf & "Local database profile has been saved successfully.", "Sync Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' 3. VERDICT NOTIFIER
        If localSaved Then
            Dim newlyCreatedMemberID = txtMemberID.Text.Trim

            If localSaved And remoteSaved Then
                MessageBox.Show("New library profile saved successfully across both database instances!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("New library profile saved locally, but failed to synchronize out to the remote node.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim askUser = MessageBox.Show("Would you like to create a system login account for this new member right now?",
                                              "Create User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If askUser = DialogResult.Yes Then
                frmRegister.MdiParent = MdiParent
                frmRegister.Show()
                frmRegister.PrepareFormForDirectLink(newlyCreatedMemberID)
            End If

            Dim openViewForm = My.Application.OpenForms.OfType(Of frmViewMembers).FirstOrDefault
            If openViewForm IsNot Nothing Then openViewForm.LoadMembersFromDatabase()
        End If

        LoadMembersFromDatabase()
        ClearInputs()
        txtMemberID.Text = GetNextMemberID()
    End Sub

    ' --- UPDATE RECORD ---
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvMembers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please highlight a member entry line from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Not ValidateForm() Then Exit Sub

        Dim localUpdated = False
        Dim remoteUpdated = False

        Dim rawIDText = txtMemberID.Text.Replace("MB", "").Trim
        Dim dbIntegerID = Convert.ToInt32(rawIDText)
        Dim query = "UPDATE members SET full_name=@name, phone=@phone, email=@email, status=@status WHERE member_id=@id"

        ' 1. LOCAL LOGIC UPDATE
        Try
            Using connLocal As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(query, connLocal)
                    connLocal.Open()
                    cmd.Parameters.AddWithValue("@id", dbIntegerID)
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim)
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text)

                    If cmd.ExecuteNonQuery > 0 Then localUpdated = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Local update failed: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' 2. REMOTE SYNC UPDATE (PC 2)
        If localUpdated Then
            Try
                Using connRemote As New MySqlConnection(remoteConnString)
                    Using cmd As New MySqlCommand(query, connRemote)
                        connRemote.Open()
                        cmd.Parameters.AddWithValue("@id", dbIntegerID)
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim)
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim)
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text)

                        If cmd.ExecuteNonQuery > 0 Then remoteUpdated = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Remote (PC 2) Update Sync Interrupted: " & ex.Message, "Sync Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        ' 3. COMPLETION MESSAGE DISPATCH
        If localUpdated And remoteUpdated Then
            MessageBox.Show("Member account files refreshed live globally!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf localUpdated Then
            MessageBox.Show("Member account files refreshed locally; network sync failed.", "Partial Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Dim openViewForm = My.Application.OpenForms.OfType(Of frmViewMembers).FirstOrDefault
        If openViewForm IsNot Nothing Then openViewForm.LoadMembersFromDatabase()

        LoadMembersFromDatabase()
        ClearInputs()
        txtMemberID.Text = GetNextMemberID()
    End Sub

    ' --- DELETE RECORD ---
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvMembers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a member row from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to remove this member record across both platforms?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Exit Sub

        Dim formattedID = dgvMembers.SelectedRows(0).Cells("member_id").Value.ToString
        Dim dbIntegerID = Convert.ToInt32(formattedID.Replace("MB", ""))
        Dim deleteQuery = "DELETE FROM members WHERE member_id=@id"

        Dim localDeleted = False
        Dim remoteDeleted = False

        ' 1. LOCAL PURGE BLOCK
        Try
            Using connLocal As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(deleteQuery, connLocal)
                    connLocal.Open()

                    cmd.Parameters.AddWithValue("@id", dbIntegerID)
                    cmd.ExecuteNonQuery()
                    localDeleted = True
                End Using

                ' Auto-Increment Counter Reset Management if completely emptied
                Dim countQuery = "SELECT COUNT(*) FROM members"
                Dim totalMembers = 0
                Using countCmd As New MySqlCommand(countQuery, connLocal)
                    totalMembers = Convert.ToInt32(countCmd.ExecuteScalar)
                End Using

                If totalMembers = 0 Then
                    Dim resetQuery = "ALTER TABLE members AUTO_INCREMENT = 1"
                    Using resetCmd As New MySqlCommand(resetQuery, connLocal)
                        resetCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Local deletion failed: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' 2. REMOTE PURGE BLOCK (PC 2)
        Try
            Using connRemote As New MySqlConnection(remoteConnString)
                Using cmd As New MySqlCommand(deleteQuery, connRemote)
                    connRemote.Open()
                    cmd.Parameters.AddWithValue("@id", dbIntegerID)
                    cmd.ExecuteNonQuery()
                    remoteDeleted = True
                End Using

                ' Mirror Auto-Increment check for remote alignment
                Dim rCountQuery = "SELECT COUNT(*) FROM members"
                Dim rTotalMembers = 0
                Using rCountCmd As New MySqlCommand(rCountQuery, connRemote)
                    rTotalMembers = Convert.ToInt32(rCountCmd.ExecuteScalar)
                End Using

                If rTotalMembers = 0 Then
                    Dim rResetQuery = "ALTER TABLE members AUTO_INCREMENT = 1"
                    Using rResetCmd As New MySqlCommand(rResetQuery, connRemote)
                        rResetCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Remote Purge Dropped: The record was deleted locally, but connection dropped to the remote server.", "Sync Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' 3. GRAPHIC UI FEEDBACK
        If localDeleted And remoteDeleted Then
            MessageBox.Show("Profile purged cleanly from registry rows across both instances.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Profile removed locally only.", "Partial Purge", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Dim openViewForm = My.Application.OpenForms.OfType(Of frmViewMembers).FirstOrDefault
        If openViewForm IsNot Nothing Then openViewForm.LoadMembersFromDatabase()

        LoadMembersFromDatabase()
        ClearInputs()
        txtMemberID.Text = GetNextMemberID()
    End Sub

    ' --- GRID CELL POPULATION ROUTINE ---
    Private Sub dgvMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMembers.Rows(e.RowIndex)
            txtMemberID.Text = row.Cells("member_id").Value.ToString()
            txtFullName.Text = row.Cells("full_name").Value.ToString()
            txtPhone.Text = row.Cells("phone").Value.ToString()
            txtEmail.Text = row.Cells("email").Value.ToString()
            cmbStatus.Text = row.Cells("status").Value.ToString()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInputs()
        txtMemberID.Text = GetNextMemberID()
    End Sub

    Private Sub ClearInputs()
        txtFullName.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        cmbStatus.SelectedIndex = -1
        txtFullName.Focus()
    End Sub

    ' --- LIVE CACHED SEARCH ENGINE FILTERS ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim searchText As String = txtSearch.Text.Trim().Replace("'", "''")
            If dgvMembers.DataSource IsNot Nothing Then
                If searchText = "" Then
                    viewTable.DefaultView.RowFilter = ""
                Else
                    viewTable.DefaultView.RowFilter = String.Format("full_name LIKE '%{0}%' OR phone LIKE '%{0}%'", searchText)
                End If
            End If
        Catch ex As Exception
            ' Quiet tracking block
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim dialog = MessageBox.Show("Are you sure you want to close this Window?",
                                                         "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class