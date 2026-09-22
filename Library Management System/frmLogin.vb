Imports System.DirectoryServices.ActiveDirectory
Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private originalLocation As Point
    Private shakeCount As Integer = 0

    ' 🔌 BOTH CONFIGURATIONS READY
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        txtPassword.UseSystemPasswordChar = True
    End Sub

    ' --- MAIN LOGIN VERIFICATION ENGINE ---
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' 1. Form Validation
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            originalLocation = Me.Location
            shakeCount = 0
            tmrShake.Start()
            MessageBox.Show("Please fill out both Username and Password fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Establish Secure Connection (Failover Logic)
        Dim connStringToUse As String = ""
        Dim activeConn As MySqlConnection = Nothing

        ' Try Local First
        Try
            activeConn = New MySqlConnection(localConnString)
            activeConn.Open()
            connStringToUse = localConnString
        Catch localEx As Exception
            ' If Local fails, try Remote (PC 2)
            Try
                If activeConn IsNot Nothing Then activeConn.Dispose()
                activeConn = New MySqlConnection(remoteConnString)
                activeConn.Open()
                connStringToUse = remoteConnString
            Catch remoteEx As Exception
                ' Both failed
                If activeConn IsNot Nothing Then activeConn.Dispose()
                MessageBox.Show("Could not connect to Local or Remote databases." & vbCrLf &
                                "Local Error: " & localEx.Message & vbCrLf &
                                "Remote Error: " & remoteEx.Message, "Network Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End Try

        ' 3. Execute Parametric User Matching Query
        Try
            Dim query As String = "SELECT username, role, member_id FROM users WHERE BINARY username = @user AND BINARY password = @pass"

            Using cmd As New MySqlCommand(query, activeConn)
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim accountRole As String = reader("role").ToString()
                        Dim activeMemberID As String = If(IsDBNull(reader("member_id")), "", reader("member_id").ToString())

                        Dim mainMenu As New frmMain()
                        mainMenu.LoggedInRole = accountRole
                        mainMenu.LoggedInMemberID = activeMemberID

                        mainMenu.UserRole = accountRole

                        ' Inform the user where they logged in (Optional, but great for troubleshooting testing!)
                        If connStringToUse = remoteConnString Then
                            MessageBox.Show("Logged into Remote Server (PC 2).", "Remote Connection Active", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        mainMenu.Show()
                        Me.Hide()
                    Else
                        originalLocation = Me.Location
                        shakeCount = 0
                        tmrShake.Start()

                        MessageBox.Show("Incorrect Username or Password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtPassword.Clear()
                        txtPassword.Focus()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database authentication crash: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If activeConn IsNot Nothing Then
                If activeConn.State = ConnectionState.Open Then activeConn.Close()
                activeConn.Dispose()
            End If
        End Try
    End Sub

    Private Sub tmrShake_Tick(sender As Object, e As EventArgs) Handles tmrShake.Tick
        If shakeCount < 10 Then
            If shakeCount Mod 2 = 0 Then
                Me.Location = New Point(originalLocation.X + 10, originalLocation.Y)
            Else
                Me.Location = New Point(originalLocation.X - 10, originalLocation.Y)
            End If
            shakeCount += 1
        Else
            tmrShake.Stop()
            Me.Location = originalLocation
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    Private Sub ckbShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ckbShowPassword.CheckedChanged
        If ckbShowPassword.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class