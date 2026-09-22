Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmLMSReports

    ' 🔌 DUAL DATABASE FAILOVER SETTINGS (PC 1 Local / PC 2 Remote Sync)
    Private localConnString As String = My.Settings.DBcon
    Private remoteConnString As String = My.Settings.RemoteConnectionString

    Private GhanaCulture As New System.Globalization.CultureInfo("en-GH")

    Private Sub frmLMSReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "LMS - Executive Reports & Analytics"

        ' Populate LMS Report Categories
        cboReportType.Items.Clear()
        cboReportType.Items.Add("Active Borrowed Books")
        cboReportType.Items.Add("Overdue Books & Outstanding Fines")
        cboReportType.Items.Add("Complete Book Inventory Catalog")
        cboReportType.Items.Add("Historical Circulation Log")
        cboReportType.SelectedIndex = 0

        ' Default Date Ranges (First day of current month to today)
        dtpFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now

        ' Initial Report Load
        GenerateReport()
    End Sub

    ' ====================================================================================
    ' INPUT VALIDATION ENGINE (Handles Erratic User Interactions)
    ' ====================================================================================
    Private Function ValidateReportInputs() As Boolean
        ' 1. Validate Report Type Selection
        If cboReportType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a valid report category from the dropdown menu.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReportType.Focus()
            Return False
        End If

        ' 2. Validate Date Range Integrity
        If dtpFromDate.Value.Date > dtpToDate.Value.Date Then
            MessageBox.Show("The 'From Date' cannot be set later than the 'To Date'. Please adjust the date range.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpFromDate.Focus()
            Return False
        End If

        ' 3. Validate Date Limits (Future Dates Prevention)
        If dtpFromDate.Value.Date > DateTime.Now.Date Then
            MessageBox.Show("The 'From Date' cannot be set in the future.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpFromDate.Focus()
            Return False
        End If

        ' 4. Sanitize Search Keywords against invalid symbol injection
        Dim searchPattern As New Regex("^[a-zA-Z0-9\s\-_]*$")
        If Not searchPattern.IsMatch(txtSearch.Text.Trim()) Then
            MessageBox.Show("Search keywords contain unsupported special characters. Please use letters, numbers, spaces, or hyphens only.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSearch.SelectAll()
            txtSearch.Focus()
            Return False
        End If

        Return True
    End Function

    ' Prevent erratic key inputs directly on Search field
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        ' Allow Control keys, Letters, Digits, Space, Hyphen, Backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetterOrDigit(e.KeyChar) AndAlso
           Not Char.IsWhiteSpace(e.KeyChar) AndAlso e.KeyChar <> "-"c AndAlso e.KeyChar <> "_"c Then
            e.Handled = True
        End If
    End Sub

    ' ====================================================================================
    ' REPORT GENERATION ENGINE (WITH FAILOVER ROUTING & PARAMETERIZED QUERIES)
    ' ====================================================================================
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If ValidateReportInputs() Then
            GenerateReport()
        End If
    End Sub

    Public Sub GenerateReport()
        Dim query As String = ""
        Dim searchFilter As String = txtSearch.Text.Trim()
        Dim fromDate As String = dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00")
        Dim toDate As String = dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59")

        ' Dynamic Query Assembly based on selected report category
        Select Case cboReportType.SelectedIndex
            Case 0 ' Active Borrowed Books
                query = "SELECT IssueID, StudentID, StudentName, BookTitle, IssueDate, DueDate, FineAmount, Status " &
                        "FROM borrow_records WHERE Status = 'Borrowed' "
                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= "AND (StudentID LIKE @search OR StudentName LIKE @search OR BookTitle LIKE @search) "
                End If

            Case 1 ' Overdue Books & Outstanding Fines
                query = "SELECT IssueID, StudentID, StudentName, BookTitle, IssueDate, DueDate, FineAmount, Status " &
                        "FROM borrow_records WHERE Status = 'Borrowed' AND DueDate < NOW() "
                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= "AND (StudentID LIKE @search OR StudentName LIKE @search OR BookTitle LIKE @search) "
                End If

            Case 2 ' Complete Book Inventory Catalog
                query = "SELECT BookID, ISBN, Title, Author, Category, TotalCopies, AvailableCopies " &
                        "FROM books WHERE 1=1 "
                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= "AND (Title LIKE @search OR Author LIKE @search OR ISBN LIKE @search OR Category LIKE @search) "
                End If

            Case 3 ' Historical Circulation Log
                query = "SELECT IssueID, StudentID, StudentName, BookTitle, IssueDate, DueDate, ReturnDate, FineAmount, Status " &
                        "FROM borrow_records WHERE IssueDate BETWEEN @fromDate AND @toDate "
                If Not String.IsNullOrEmpty(searchFilter) Then
                    query &= "AND (StudentID LIKE @search OR StudentName LIKE @search OR BookTitle LIKE @search) "
                End If
        End Select

        Dim activeConnString As String = localConnString

        Using conn As New MySqlConnection()
            ' Automatic Dual Node Connection Routing (Silent Failover)
            Try
                conn.ConnectionString = activeConnString
                conn.Open()
            Catch localEx As Exception
                Try
                    activeConnString = remoteConnString
                    conn.ConnectionString = activeConnString
                    conn.Open()
                Catch remoteEx As Exception
                    MessageBox.Show("Report Engine Offline: Could not establish a database connection with either the primary or secondary node.",
                                    "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End Try

            ' Secure Parameterized Query Execution Layer
            Try
                Using cmd As New MySqlCommand(query, conn)
                    If query.Contains("@search") Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchFilter & "%")
                    End If
                    If query.Contains("@fromDate") Then
                        cmd.Parameters.AddWithValue("@fromDate", fromDate)
                        cmd.Parameters.AddWithValue("@toDate", toDate)
                    End If

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvReportResults.DataSource = dt

                    ' Metric Calculations and Formatting
                    CalculateSummaryMetrics(dt)
                    FormatGridColumns()

                End Using

            Catch ex As Exception
                MessageBox.Show("Report Generation Error: " & ex.Message, "SQL Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' ====================================================================================
    ' SUMMARY METRICS & GRID FORMATTING
    ' ====================================================================================
    Private Sub CalculateSummaryMetrics(dt As DataTable)
        Dim totalFines As Decimal = 0D

        If dt.Columns.Contains("FineAmount") Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row("FineAmount")) Then
                    totalFines += Convert.ToDecimal(row("FineAmount"))
                End If
            Next
        End If

        lblTotalFines.Text = "Total Outstanding Fines: " & totalFines.ToString("C", GhanaCulture)
        lblRecordCount.Text = "Total Records Returned: " & dt.Rows.Count.ToString()
    End Sub

    Private Sub FormatGridColumns()
        If dgvReportResults.Columns.Count = 0 Then Exit Sub

        ' Format Currency Display (Ghana Cedi GH₵)
        If dgvReportResults.Columns.Contains("FineAmount") Then
            dgvReportResults.Columns("FineAmount").DefaultCellStyle.FormatProvider = GhanaCulture
            dgvReportResults.Columns("FineAmount").DefaultCellStyle.Format = "C"
            dgvReportResults.Columns("FineAmount").HeaderText = "Fine Amount"
        End If

        ' Format Dates
        If dgvReportResults.Columns.Contains("IssueDate") Then dgvReportResults.Columns("IssueDate").DefaultCellStyle.Format = "yyyy-MM-dd"
        If dgvReportResults.Columns.Contains("DueDate") Then dgvReportResults.Columns("DueDate").DefaultCellStyle.Format = "yyyy-MM-dd"
        If dgvReportResults.Columns.Contains("ReturnDate") Then dgvReportResults.Columns("ReturnDate").DefaultCellStyle.Format = "yyyy-MM-dd"

        dgvReportResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ====================================================================================
    ' CUSTOM REPORT EXPORT ENGINE (CSV / EXCEL)
    ' ====================================================================================
    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click
        ' Validation: Ensure data exists before exporting
        If dgvReportResults.Rows.Count = 0 Then
            MessageBox.Show("There are no records in the grid to export. Please generate a report first.",
                            "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "CSV File (*.csv)|*.csv"
        sfd.FileName = "LMS_Report_" & cboReportType.SelectedItem.ToString().Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                Using writer As New StreamWriter(sfd.FileName)
                    ' Write Headers
                    Dim headers As String = ""
                    For i As Integer = 0 To dgvReportResults.Columns.Count - 1
                        If dgvReportResults.Columns(i).Visible Then
                            headers &= """" & dgvReportResults.Columns(i).HeaderText & ""","
                        End If
                    Next
                    writer.WriteLine(headers.TrimEnd(","c))

                    ' Write Data Rows
                    For Each row As DataGridViewRow In dgvReportResults.Rows
                        If Not row.IsNewRow Then
                            Dim line As String = ""
                            For i As Integer = 0 To dgvReportResults.Columns.Count - 1
                                If dgvReportResults.Columns(i).Visible Then
                                    Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                                    line &= """" & cellValue.Replace("""", """""") & ""","
                                End If
                            Next
                            writer.WriteLine(line.TrimEnd(","c))
                        End If
                    Next
                End Using

                MessageBox.Show("Report successfully exported to " & sfd.FileName, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error writing export file: " & ex.Message, "File Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close this window?", "Confirm Close", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Clear()
        cboReportType.SelectedIndex = 0
        dtpFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now
        GenerateReport()
    End Sub
End Class