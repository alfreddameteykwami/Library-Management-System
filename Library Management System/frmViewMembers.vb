Imports MySql.Data.MySqlClient

Public Class frmViewMembers
    ' 🔌 BOTH SYSTEM CONNECTION STRINGS INITIALIZED VIA MY.SETTINGS
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString
    Private memberTable As New DataTable()

    Private Sub frmViewMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupDataTable()
            SetupDataGridView()
            LoadMembersFromDatabase() ' Pull directly from the active live database node
        Catch ex As Exception
            modErrorHandler.LogError(ex)
        End Try
    End Sub

    Private Sub SetupDataTable()
        ' Explicitly define our standard internal mapping keys
        memberTable.Columns.Clear()
        memberTable.Columns.Add("member_id", GetType(String))
        memberTable.Columns.Add("full_name", GetType(String))
        memberTable.Columns.Add("phone", GetType(String))
        memberTable.Columns.Add("status", GetType(String))
    End Sub

    Private Sub SetupDataGridView()
        dgvRoster.DataSource = memberTable
        dgvRoster.ReadOnly = True
        dgvRoster.AllowUserToAddRows = False
        dgvRoster.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRoster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Clean header mapping to keep the display readable
        dgvRoster.Columns("member_id").HeaderText = "Member ID"
        dgvRoster.Columns("full_name").HeaderText = "Full Name"
        dgvRoster.Columns("phone").HeaderText = "Phone"
        dgvRoster.Columns("status").HeaderText = "Status"
    End Sub

    ' --- PUBLIC FETCH ENGINE WITH AUTOMATED PC1 / PC2 FAILOVER ---
    Public Sub LoadMembersFromDatabase()
        Dim query As String = "SELECT member_id, full_name, phone, status FROM members"
        Dim activeConnString As String = localConnString
        Dim fallbackAttempted As Boolean = False

        Using conn As New MySqlConnection()
            ' --- CONNECTION ESTABLISHMENT ENGINE ---
            Try
                conn.ConnectionString = activeConnString
                conn.Open()
            Catch localEx As Exception
                ' If Local PC 1 fails, instantly attempt routing to Remote PC 2
                Try
                    activeConnString = remoteConnString
                    conn.ConnectionString = activeConnString
                    conn.Open()
                    fallbackAttempted = True
                Catch remoteEx As Exception
                    ' Both points offline
                    modErrorHandler.LogError(remoteEx)
                    MessageBox.Show("Critical Connection Failure: Could not link to the local registry or the remote mirror." & vbCrLf &
                                    "PC 1 Error: " & localEx.Message & vbCrLf &
                                    "PC 2 Error: " & remoteEx.Message, "Database Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End Try

            ' --- DATA EXTRACTION ENGINE ---
            Try
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        memberTable.Rows.Clear()

                        While reader.Read()
                            ' Extract the clean internal integer ID
                            Dim rawID As Integer = Convert.ToInt32(reader("member_id"))

                            ' Formats the ID string dynamically into your requested MB001 pattern
                            Dim formattedID As String = "MB" & rawID.ToString("D3")

                            ' Inject the formatted string row into the live UI grid dataview
                            memberTable.Rows.Add(formattedID, reader("full_name").ToString(), reader("phone").ToString(), reader("status").ToString())
                        End While
                    End Using
                End Using
                ' Alter form title bar subtly to reflect the active environment status
                If fallbackAttempted Then
                    Me.Text = "Member Roster Viewer (Connected to Remote Server)"
                Else
                    Me.Text = "Member Roster Viewer (Connected to Local Server)"
                End If

            Catch ex As Exception
                modErrorHandler.LogError(ex)
                MessageBox.Show("Error loading member roster from database: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' --- LIVE IN-MEMORY ROSTER FILTER ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim filterText = txtSearch.Text.Trim.Replace("'", "''")
            If filterText = "" Then
                memberTable.DefaultView.RowFilter = ""
            Else
                ' Filters locally against your designated column strings
                memberTable.DefaultView.RowFilter = String.Format("full_name LIKE '%{0}%' OR phone LIKE '%{0}%'", filterText)
            End If
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    ' --- MDI BOUNDARY FORCE LOCK ---
    Private Sub frmMembers_Move(sender As Object, e As EventArgs) Handles Me.Move
        If Me.MdiParent IsNot Nothing Then
            Dim parentContainer As Control = Me.MdiParent

            Dim maxRight As Integer = parentContainer.ClientSize.Width - Me.Width - 4
            Dim maxBottom As Integer = parentContainer.ClientSize.Height - Me.Height - 50

            If Me.Left < 0 Then Me.Left = 0
            If Me.Top < 0 Then Me.Top = 0
            If Me.Left > maxRight Then Me.Left = maxRight
            If Me.Top > maxBottom Then Me.Top = maxBottom
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim dialog = MessageBox.Show("Are you sure you want to close this Window?",
                                                     "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class