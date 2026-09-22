Imports Library_Management_System.My
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class frmViewTransactions

    ' ====================================================================================
    ' 1. CLASS-LEVEL VARIABLES & CONSTRUCTOR
    ' ====================================================================================
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString
    Private transactionsTable As New DataTable()

    Public Sub New()
        InitializeComponent()


    End Sub

    ' ====================================================================================
    ' 2. FORM INITIALIZATION
    ' ====================================================================================
    Private Sub frmViewTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupDataGridView()
            ApplyButtonStyles()
        Catch ex As Exception
            MessageBox.Show("UI Setup Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub frmViewTransactions_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Window renders first; database records load asynchronously in the background
        Await LoadTransactionsFromDatabaseAsync()
    End Sub

    Private Sub SetupDataGridView()
        If dgvTransactions IsNot Nothing Then
            With dgvTransactions
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

    Private Sub ApplyButtonStyles()
        ' Matches your primary dark action style
        If btnClose IsNot Nothing Then
            With btnClose
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .BackColor = Color.FromArgb(30, 41, 59)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
                .Cursor = Cursors.Hand
                .FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85)
            End With
        End If
    End Sub

    ' ====================================================================================
    ' 3. ASYNC DATABASE ENGINE (JOINED CIRCULATION HISTORY)
    ' ====================================================================================
    Public Async Function LoadTransactionsFromDatabaseAsync() As Task
        Me.Text = "Transaction History Log - Connecting..."

        Dim localStr As String = EnsureTimeout(localConnString)
        Dim remoteStr As String = EnsureTimeout(remoteConnString)

        ' Relational query bringing together Transactions, Members, and Books

        Dim query As String = "SELECT t.transaction_id, m.full_name, b.title, t.request_date, t.status " &
                      "FROM library_transactions t " &
                      "JOIN members m ON t.member_id = m.member_id " &
                      "JOIN books b ON t.book_id = b.book_id"


        'Dim query As String = "SELECT t.transaction_id, t.member_id, m.full_name AS member_name, " &
        '                     "t.book_id, b.title AS book_title, t.borrow_date, t.due_date, " &
        '                     "t.return_date, t.status, t.fine_amount " &
        '                     "FROM library_transactions t " &
        '                     "LEFT JOIN members m ON t.member_id = m.member_id " &
        '                     "LEFT JOIN books b ON t.book_id = b.book_id " &
        '                     "ORDER BY t.transaction_id DESC"

        Dim connectionTargets() As String = {localStr, remoteStr}
        Dim connected As Boolean = False
        Dim isRemote As Boolean = False
        Dim conn As New MySqlConnection()

        ' Sequential server connection without placing Await inside Catch blocks
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
                ' Proceed to fallback target
            End Try
        Next

        If Not connected Then
            conn.Dispose()
            Me.Text = "Transaction History Log (Offline)"
            MessageBox.Show("Unable to connect to Local or Remote databases." & vbCrLf &
                            "Please ensure MySQL server (XAMPP) is running.",
                            "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If

        ' Fetch history records
        Try
            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    transactionsTable.Clear()

                    Await Task.Run(Sub() adapter.Fill(transactionsTable))

                    If dgvTransactions IsNot Nothing Then
                        dgvTransactions.DataSource = transactionsTable
                        FormatGridHeaders()
                    End If
                End Using
            End Using

            Me.Text = If(isRemote, "Transaction History Log (Remote Server)", "Transaction History Log (Local Server)")

        Catch ex As Exception
            MessageBox.Show("Error pulling circulation records: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            End If
            End Try
    End Function

    Private Sub FormatGridHeaders()
        If dgvTransactions.Columns.Count > 0 Then
            If dgvTransactions.Columns.Contains("transaction_id") Then dgvTransactions.Columns("transaction_id").HeaderText = "TX ID"
            If dgvTransactions.Columns.Contains("member_id") Then dgvTransactions.Columns("member_id").HeaderText = "Member ID"
            If dgvTransactions.Columns.Contains("member_name") Then dgvTransactions.Columns("member_name").HeaderText = "Member Name"
            If dgvTransactions.Columns.Contains("book_id") Then dgvTransactions.Columns("book_id").HeaderText = "Book ID"
            If dgvTransactions.Columns.Contains("book_title") Then dgvTransactions.Columns("book_title").HeaderText = "Book Title"
            If dgvTransactions.Columns.Contains("borrow_date") Then dgvTransactions.Columns("borrow_date").HeaderText = "Borrow Date"
            If dgvTransactions.Columns.Contains("due_date") Then dgvTransactions.Columns("due_date").HeaderText = "Due Date"
            If dgvTransactions.Columns.Contains("return_date") Then dgvTransactions.Columns("return_date").HeaderText = "Return Date"
            If dgvTransactions.Columns.Contains("status") Then dgvTransactions.Columns("status").HeaderText = "Status"
            If dgvTransactions.Columns.Contains("fine_amount") Then dgvTransactions.Columns("fine_amount").HeaderText = "Fine ($)"

            ' Column Proportions
            If dgvTransactions.Columns.Contains("transaction_id") Then dgvTransactions.Columns("transaction_id").FillWeight = 50
            If dgvTransactions.Columns.Contains("member_id") Then dgvTransactions.Columns("member_id").FillWeight = 65
            If dgvTransactions.Columns.Contains("member_name") Then dgvTransactions.Columns("member_name").FillWeight = 120
            If dgvTransactions.Columns.Contains("book_id") Then dgvTransactions.Columns("book_id").FillWeight = 60
            If dgvTransactions.Columns.Contains("book_title") Then dgvTransactions.Columns("book_title").FillWeight = 140
            If dgvTransactions.Columns.Contains("borrow_date") Then dgvTransactions.Columns("borrow_date").FillWeight = 85
            If dgvTransactions.Columns.Contains("due_date") Then dgvTransactions.Columns("due_date").FillWeight = 85
            If dgvTransactions.Columns.Contains("return_date") Then dgvTransactions.Columns("return_date").FillWeight = 85
            If dgvTransactions.Columns.Contains("status") Then dgvTransactions.Columns("status").FillWeight = 75
            If dgvTransactions.Columns.Contains("fine_amount") Then dgvTransactions.Columns("fine_amount").FillWeight = 65
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
    ' 4. LIVE FILTER ENGINE (SEARCH BY MEMBER ID, BOOK ID, NAME, OR TITLE)
    ' ====================================================================================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim filterText As String = txtSearch.Text.Trim().Replace("'", "''")

            If filterText = "" Then
                transactionsTable.DefaultView.RowFilter = ""
            Else
                ' Search across Member ID, Book ID, Member Name, Book Title, and Status
                transactionsTable.DefaultView.RowFilter = String.Format(
                    "Convert([member_id], 'System.String') LIKE '%{0}%' OR " &
                    "Convert([book_id], 'System.String') LIKE '%{0}%' OR " &
                    "[member_name] LIKE '%{0}%' OR " &
                    "[book_title] LIKE '%{0}%' OR " &
                    "[status] LIKE '%{0}%'", filterText)
            End If
        Catch ex As Exception
            transactionsTable.DefaultView.RowFilter = ""
        End Try
    End Sub

    ' ====================================================================================
    ' 5. FORM CLOSING ACTIONS
    ' ====================================================================================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Confirm Close", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class