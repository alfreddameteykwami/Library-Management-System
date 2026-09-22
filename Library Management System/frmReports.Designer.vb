<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLMSReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblHeaderSubtitle = New Label()
        lblHeaderTitle = New Label()
        grpFilters = New GroupBox()
        btnReset = New Button()
        cboReportType = New ComboBox()
        Label1 = New Label()
        btnGenerate = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        dtpToDate = New DateTimePicker()
        lblToDate = New Label()
        lblFromDate = New Label()
        dtpFromDate = New DateTimePicker()
        pnlGridContainer = New Panel()
        dgvReportResults = New DataGridView()
        Panel1 = New Panel()
        btnClose = New Button()
        lblRecordCount = New Label()
        lblTotalFines = New Label()
        btnExportCSV = New Button()
        pnlHeader.SuspendLayout()
        grpFilters.SuspendLayout()
        pnlGridContainer.SuspendLayout()
        CType(dgvReportResults, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(lblHeaderSubtitle)
        pnlHeader.Controls.Add(lblHeaderTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1164, 97)
        pnlHeader.TabIndex = 0
        ' 
        ' lblHeaderSubtitle
        ' 
        lblHeaderSubtitle.AutoSize = True
        lblHeaderSubtitle.Font = New Font("Segoe UI", 8.5F)
        lblHeaderSubtitle.ForeColor = Color.Gainsboro
        lblHeaderSubtitle.Location = New Point(13, 46)
        lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        lblHeaderSubtitle.Size = New Size(539, 23)
        lblHeaderSubtitle.TabIndex = 1
        lblHeaderSubtitle.Text = "Audit Loans, track overdue items, calculate fines, and export CSV logs"
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.Location = New Point(13, 10)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(665, 36)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "LIBRARY MANAGEMENT SYSTEM - REPORTS ENGINE"
        ' 
        ' grpFilters
        ' 
        grpFilters.Controls.Add(btnReset)
        grpFilters.Controls.Add(cboReportType)
        grpFilters.Controls.Add(Label1)
        grpFilters.Controls.Add(btnGenerate)
        grpFilters.Controls.Add(lblSearch)
        grpFilters.Controls.Add(txtSearch)
        grpFilters.Controls.Add(dtpToDate)
        grpFilters.Controls.Add(lblToDate)
        grpFilters.Controls.Add(lblFromDate)
        grpFilters.Controls.Add(dtpFromDate)
        grpFilters.Dock = DockStyle.Top
        grpFilters.Location = New Point(0, 97)
        grpFilters.Name = "grpFilters"
        grpFilters.Size = New Size(1164, 109)
        grpFilters.TabIndex = 1
        grpFilters.TabStop = False
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(1033, 37)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(112, 49)
        btnReset.TabIndex = 7
        btnReset.Text = "&RESET"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' cboReportType
        ' 
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList
        cboReportType.FormattingEnabled = True
        cboReportType.Items.AddRange(New Object() {"Active Borrowed Books", "Overdue Books & Outstanding Fines", "Complete Book Inventory Catalog", "Historical Circulation Log"})
        cboReportType.Location = New Point(23, 49)
        cboReportType.Name = "cboReportType"
        cboReportType.Size = New Size(214, 36)
        cboReportType.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(178, 28)
        Label1.TabIndex = 0
        Label1.Text = "Select Report Type:"
        ' 
        ' btnGenerate
        ' 
        btnGenerate.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.ForeColor = Color.White
        btnGenerate.Location = New Point(885, 37)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(127, 49)
        btnGenerate.TabIndex = 7
        btnGenerate.Text = "&GENERATE"
        btnGenerate.UseVisualStyleBackColor = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(256, 18)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(164, 28)
        lblSearch.TabIndex = 2
        lblSearch.Text = "Search Keywords:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(256, 49)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(226, 33)
        txtSearch.TabIndex = 3
        ' 
        ' dtpToDate
        ' 
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(716, 48)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(151, 33)
        dtpToDate.TabIndex = 5
        ' 
        ' lblToDate
        ' 
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(716, 18)
        lblToDate.Name = "lblToDate"
        lblToDate.Size = New Size(82, 28)
        lblToDate.TabIndex = 6
        lblToDate.Text = "To Date:"
        ' 
        ' lblFromDate
        ' 
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(505, 18)
        lblFromDate.Name = "lblFromDate"
        lblFromDate.Size = New Size(108, 28)
        lblFromDate.TabIndex = 4
        lblFromDate.Text = "From Date:"
        ' 
        ' dtpFromDate
        ' 
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(505, 48)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(191, 33)
        dtpFromDate.TabIndex = 5
        ' 
        ' pnlGridContainer
        ' 
        pnlGridContainer.Controls.Add(dgvReportResults)
        pnlGridContainer.Dock = DockStyle.Fill
        pnlGridContainer.Location = New Point(0, 206)
        pnlGridContainer.Name = "pnlGridContainer"
        pnlGridContainer.Size = New Size(1164, 515)
        pnlGridContainer.TabIndex = 2
        ' 
        ' dgvReportResults
        ' 
        dgvReportResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReportResults.BackgroundColor = Color.White
        dgvReportResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReportResults.Dock = DockStyle.Fill
        dgvReportResults.Location = New Point(0, 0)
        dgvReportResults.Name = "dgvReportResults"
        dgvReportResults.RowHeadersWidth = 62
        dgvReportResults.Size = New Size(1164, 515)
        dgvReportResults.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightGray
        Panel1.Controls.Add(btnClose)
        Panel1.Controls.Add(lblRecordCount)
        Panel1.Controls.Add(lblTotalFines)
        Panel1.Controls.Add(btnExportCSV)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 641)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1164, 80)
        Panel1.TabIndex = 3
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1033, 13)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 49)
        btnClose.TabIndex = 7
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' lblRecordCount
        ' 
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New Point(23, 41)
        lblRecordCount.Name = "lblRecordCount"
        lblRecordCount.Size = New Size(218, 28)
        lblRecordCount.TabIndex = 1
        lblRecordCount.Text = "Total Records Returns: 0"
        ' 
        ' lblTotalFines
        ' 
        lblTotalFines.AutoSize = True
        lblTotalFines.Location = New Point(23, 13)
        lblTotalFines.Name = "lblTotalFines"
        lblTotalFines.Size = New Size(307, 28)
        lblTotalFines.TabIndex = 0
        lblTotalFines.Text = "Total Outstanding Fines: GH₵ 0.00"
        ' 
        ' btnExportCSV
        ' 
        btnExportCSV.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnExportCSV.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnExportCSV.FlatStyle = FlatStyle.Flat
        btnExportCSV.ForeColor = Color.White
        btnExportCSV.Location = New Point(871, 13)
        btnExportCSV.Name = "btnExportCSV"
        btnExportCSV.Size = New Size(141, 49)
        btnExportCSV.TabIndex = 7
        btnExportCSV.Text = "&EXPORT CSV"
        btnExportCSV.UseVisualStyleBackColor = False
        ' 
        ' frmLMSReports
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1164, 721)
        Controls.Add(Panel1)
        Controls.Add(pnlGridContainer)
        Controls.Add(grpFilters)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.75F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmLMSReports"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LMS - Execute Reports & Analytics"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        grpFilters.ResumeLayout(False)
        grpFilters.PerformLayout()
        pnlGridContainer.ResumeLayout(False)
        CType(dgvReportResults, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblHeaderSubtitle As Label
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblFromDate As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents pnlGridContainer As Panel
    Friend WithEvents dgvReportResults As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotalFines As Label
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExportCSV As Button
End Class
