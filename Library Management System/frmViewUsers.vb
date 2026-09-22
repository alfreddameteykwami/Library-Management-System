Imports MySql.Data.MySqlClient

Public Class frmViewUsers
    ' 🔌 BOTH SYSTEM CONNECTION STRINGS INITIALIZED VIA MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    Private Sub frmViewUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadUsersFromDatabase()
    End Sub

    Private Sub SetupDataGridView()
        ' Lock down the grid design for clean management view
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.ReadOnly = True
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.MultiSelect = False
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.RowHeadersVisible = False

        ' Structure matching custom alphanumeric format layers
        dgvUsers.ColumnCount = 4
        dgvUsers.Columns(0).Name = "System ID"
        dgvUsers.Columns(1).Name = "Username"
        dgvUsers.Columns(2).Name = "Role Profile"
        dgvUsers.Columns(3).Name = "Linked Library Card"
    End Sub

    ' --- DATABASE FULFILLMENT MATRIX (WITH AUTOMATED PC1 / PC2 FAILOVER) ---
    Public Sub LoadUsersFromDatabase(Optional filterText As String = "")
        Dim query As String = "SELECT user_id, username, role, member_id FROM users"
        If Not String.IsNullOrEmpty(filterText) Then
            query &= " WHERE username LIKE @search OR role LIKE @search"
        End If

        Dim activeConnString As String = localConnString
        Dim fallbackAttempted As Boolean = False

        Using conn As New MySqlConnection()
            ' --- CONNECTION FAILOVER ENGINE ---
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
                    MessageBox.Show("Hardware Link Failure: Could not load user profiles from either database node." & vbCrLf &
                                    "PC 1 Error: " & localEx.Message, "Database Offline", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End Try

            ' --- CHANNELS RENDERING ENGINE ---
            Try
                dgvUsers.Rows.Clear()
                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrEmpty(filterText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & filterText & "%")
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim rawUserID As Integer = Convert.ToInt32(reader("user_id"))
                            Dim displayUserID As String = "US" & rawUserID.ToString("D3")

                            Dim username As String = reader("username").ToString()
                            Dim role As String = reader("role").ToString()

                            ' Alphanumeric formatting loop logic matching administrative link status
                            Dim displayMemberID As String = "N/A (Admin)"
                            If Not IsDBNull(reader("member_id")) Then
                                Dim rawMemID As Integer = Convert.ToInt32(reader("member_id"))
                                displayMemberID = "MB" & rawMemID.ToString("D3")
                            End If

                            dgvUsers.Rows.Add(displayUserID, username, role, displayMemberID)
                        End While
                    End Using
                End Using

                ' Reflect environment tracking state cleanly on screen header frame
                If fallbackAttempted Then
                    Me.Text = "System User Profiles Roster (Connected to Remote Server)"
                Else
                    Me.Text = "System User Profiles Roster (Connected to Local Server)"
                End If

                dgvUsers.ClearSelection()
            Catch ex As Exception
                MessageBox.Show("Roster extraction execution failed: " & ex.Message, "SQL Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' --- SEARCH AS YOU TYPE ENGINE ---
    Private Sub txtSearchName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchName.TextChanged
        LoadUsersFromDatabase(txtSearchName.Text.Trim())
    End Sub

    ' --- DELETE USER ACCOUNT MECHANIC (WITH DUAL SYNCHRONIZATION) ---
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please highlight a specific user row account profile from the roster list view below to remove.", "Selection Target Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim displayID As String = selectedRow.Cells("System ID").Value.ToString()
        Dim targetUsername As String = selectedRow.Cells("Username").Value.ToString()
        Dim rawUserID As Integer = Convert.ToInt32(displayID.Replace("US", ""))

        Dim confirmResult As DialogResult = MessageBox.Show($"Are you absolutely sure you want to permanently erase user account '{targetUsername}' ({displayID}) from system storage?",
                                                            "Confirm Account Deletion",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question)
        If confirmResult = DialogResult.No Then Exit Sub

        Dim deleteQuery As String = "DELETE FROM users WHERE user_id = @uID"
        Dim localDeleted As Boolean = False
        Dim remoteDeleted As Boolean = False

        ' --- 1. LOCAL PURGE ACTION ---
        Try
            Using connLocal As New MySqlConnection(localConnString)
                Using cmd As New MySqlCommand(deleteQuery, connLocal)
                    connLocal.Open()
                    cmd.Parameters.AddWithValue("@uID", rawUserID)
                    cmd.ExecuteNonQuery()
                    localDeleted = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Local deletion execution failed: " & ex.Message, "Database Violation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' --- 2. REMOTE PURGE ACTION (PC 2) ---
        If localDeleted Then
            Try
                Using connRemote As New MySqlConnection(remoteConnString)
                    Using cmd As New MySqlCommand(deleteQuery, connRemote)
                        connRemote.Open()
                        cmd.Parameters.AddWithValue("@uID", rawUserID)
                        cmd.ExecuteNonQuery()
                        remoteDeleted = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Remote Purge Sync Dropped: The system access profile was removed from PC 1, but network issues blocked the drop on PC 2.", "Sync Network Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        ' --- 3. RENDERING COMPONENT REFRESH ---
        If localDeleted Then
            If localDeleted And remoteDeleted Then
                MessageBox.Show("The system access profile has been successfully wiped across both server nodes.", "Record Dropped Everywhere", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("The profile has been wiped locally.", "Partial Drop Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            txtSearchName.Clear()
            LoadUsersFromDatabase()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class