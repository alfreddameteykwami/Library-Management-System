Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class frmRegister
    ' 🔌 BOTH SYSTEM CONNECTION STRINGS INITIALIZED VIA MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the Role combo box drop-down list options
        cmbRole.Items.Clear()
        cmbRole.Items.Add("Admin")
        cmbRole.Items.Add("User")
        cmbRole.SelectedIndex = -1

        LoadMemberIDs()
    End Sub

    ' --- FETCH ENGINE FOR CROSS-FORM DROPDOWN (WITH RETRY FAILOVER) ---
    Private Sub LoadMemberIDs()
        Dim query As String = "SELECT member_id FROM members"
        Dim activeConnString As String = localConnString
        Dim fallbackAttempted As Boolean = False

        Using conn As New MySqlConnection()
            ' 1. CONNECTION MANAGEMENT LAYER
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
                    MessageBox.Show("Hardware Link Failure: Could not load member profiles from either database node." & vbCrLf &
                                    "PC 1 Error: " & localEx.Message, "Database Offline", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End Try

            ' 2. DATA COMMAND & QUERY LAYER (FIXED: Structured cleanly inside the connection instance scope)
            Try
                Using cmd As New MySqlCommand(query, conn)
                    Using reader = cmd.ExecuteReader()
                        cmbMemberID.Items.Clear()
                        While reader.Read()
                            ' Formats numerical 1 into display "MB001"
                            cmbMemberID.Items.Add("MB" & Convert.ToInt32(reader("member_id")).ToString("D3"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error reading members from active data source: " & ex.Message, "SQL Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Smart UI toggle: Only allow a Member ID link if the account type is a regular user
    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.Text = "User" Then
            cmbMemberID.Enabled = True

            ' SAFEGUARD: Alert admin if they pick "User" but haven't added any members yet
            If cmbMemberID.Items.Count = 0 Then
                MessageBox.Show("There are currently zero members registered in the database. You must add a physical member profile first before creating a 'User' account.", "No Members Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRole.SelectedIndex = -1
                cmbMemberID.Enabled = False
            End If
        Else
            cmbMemberID.SelectedIndex = -1
            cmbMemberID.Enabled = False
        End If
    End Sub

    ' --- SHORTCUT METHOD: Called by frmMembers during initial database onboarding ---
    Public Sub PrepareFormForDirectLink(memberID As String)
        ' 1. Reload list to catch the brand new member item
        LoadMemberIDs()

        ' 2. Enforce 'User' profile rules
        cmbRole.Text = "User"
        cmbRole.Enabled = False

        ' 3. Auto-select and lock the matching target ID
        If cmbMemberID.Items.Contains(memberID) Then
            cmbMemberID.Text = memberID
            cmbMemberID.Enabled = False
        End If

        txtRegUsername.Focus()
    End Sub

    ' ====================================================================================
    ' DUAL SYNCHRONIZED ACCOUNTS CREATION ENGINE
    ' ====================================================================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 1. Check for blank fields
        If txtRegUsername.Text.Trim() = "" OrElse txtRegPassword.Text.Trim() = "" OrElse cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Please fill out all registration fields and select a system role profile.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Ensure users are explicitly linked to a card identity profile
        If cmbRole.Text = "User" AndAlso cmbMemberID.SelectedIndex = -1 Then
            MessageBox.Show("A regular User account must be linked to a physical Member ID profile.", "Link Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Determine clean integer raw ID value
        Dim rawIDValue As Object = DBNull.Value
        If cmbRole.Text <> "Admin" Then
            rawIDValue = Convert.ToInt32(cmbMemberID.Text.Replace("MB", "").Trim())
        End If

        Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE BINARY username = @user"
        Dim insertQuery As String = "INSERT INTO users (username, password, role, member_id) VALUES (@user, @pass, @role, @memID)"

        Dim localSaved As Boolean = False
        Dim remoteSaved As Boolean = False

        ' --- 3. LOCAL PROCESSING STEP ---
        Try
            Using connLocal As New MySqlConnection(localConnString)
                connLocal.Open()

                ' Check unique username locally
                Using chkCmd As New MySqlCommand(checkQuery, connLocal)
                    chkCmd.Parameters.AddWithValue("@user", txtRegUsername.Text.Trim())
                    If Convert.ToInt32(chkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("This username is already taken locally. Please choose another one.", "Registration Halted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtRegUsername.Focus()
                        Exit Sub
                    End If
                End Using

                ' Insert Account
                Using cmd As New MySqlCommand(insertQuery, connLocal)
                    cmd.Parameters.AddWithValue("@user", txtRegUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtRegPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cmbRole.Text)
                    cmd.Parameters.AddWithValue("@memID", rawIDValue)
                    cmd.ExecuteNonQuery()
                    localSaved = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Local registration failed: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' --- 4. REMOTE DUPLICATION STEP (PC 2) ---
        If localSaved Then
            Try
                Using connRemote As New MySqlConnection(remoteConnString)
                    connRemote.Open()

                    ' Skip remote username constraint check unless necessary, overwrite/insert safely
                    Using cmd As New MySqlCommand(insertQuery, connRemote)
                        cmd.Parameters.AddWithValue("@user", txtRegUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@pass", txtRegPassword.Text.Trim())
                        cmd.Parameters.AddWithValue("@role", cmbRole.Text)
                        cmd.Parameters.AddWithValue("@memID", rawIDValue)
                        cmd.ExecuteNonQuery()
                        remoteSaved = True
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Remote (PC 2) Mirror Down: The user account was created locally, but failed to sync across the network connection.", "Network Sync Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        ' --- 5. INTERFACE RESPONSE WRAPPER ---
        If localSaved Then
            If localSaved And remoteSaved Then
                MessageBox.Show("New account system profile generated and mirrored successfully across instances!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Account successfully created locally.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Auto-refresh the user view list panel if it is currently open in the background
            Dim openViewForm = My.Application.OpenForms.OfType(Of frmViewUsers)().FirstOrDefault()
            If openViewForm IsNot Nothing Then openViewForm.LoadUsersFromDatabase()

            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Cancel?", "Confirm Cancel", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub txtRegPassword_TextChanged(sender As Object, e As EventArgs) Handles txtRegPassword.TextChanged
        Dim len As Integer = txtRegPassword.Text.Length

        If len = 0 Then
            lblPasswordStrength.Text = ""
        Else
            If len < 6 Then
                lblPasswordStrength.Text = "Strength: Weak"
                lblPasswordStrength.ForeColor = Color.Red
            ElseIf len >= 6 AndAlso len < 10 Then
                lblPasswordStrength.Text = "Strength: Medium"
                lblPasswordStrength.ForeColor = Color.Orange
            Else
                lblPasswordStrength.Text = "Strength: Strong"
                lblPasswordStrength.ForeColor = Color.Green
            End If
        End If
    End Sub
End Class