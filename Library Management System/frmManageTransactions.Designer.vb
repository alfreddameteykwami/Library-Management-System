<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageTransactions
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
        lblTransactionID = New Label()
        txtTxID = New TextBox()
        txtMemberID = New TextBox()
        lblMemberID = New Label()
        lblBookID = New Label()
        txtBookID = New TextBox()
        lblIssueDate = New Label()
        dtpIssue = New DateTimePicker()
        lblReturnDate = New Label()
        dtpReturn = New DateTimePicker()
        lblFine = New Label()
        txtFine = New TextBox()
        dgvTransactions = New DataGridView()
        lblTitleBlock = New Label()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        btnIssue = New Button()
        btnReturn = New Button()
        btnClear = New Button()
        btnClose = New Button()
        CType(dgvTransactions, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTransactionID
        ' 
        lblTransactionID.AutoSize = True
        lblTransactionID.Font = New Font("Segoe UI", 9.75F)
        lblTransactionID.Location = New Point(70, 17)
        lblTransactionID.Name = "lblTransactionID"
        lblTransactionID.Size = New Size(138, 28)
        lblTransactionID.TabIndex = 0
        lblTransactionID.Text = "Transaction ID:"
        ' 
        ' txtTxID
        ' 
        txtTxID.Location = New Point(203, 14)
        txtTxID.Name = "txtTxID"
        txtTxID.Size = New Size(241, 31)
        txtTxID.TabIndex = 1
        ' 
        ' txtMemberID
        ' 
        txtMemberID.Location = New Point(203, 54)
        txtMemberID.Name = "txtMemberID"
        txtMemberID.Size = New Size(241, 31)
        txtMemberID.TabIndex = 3
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Font = New Font("Segoe UI", 9.75F)
        lblMemberID.Location = New Point(70, 57)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(114, 28)
        lblMemberID.TabIndex = 2
        lblMemberID.Text = "Member ID:"
        ' 
        ' lblBookID
        ' 
        lblBookID.AutoSize = True
        lblBookID.Font = New Font("Segoe UI", 9.75F)
        lblBookID.Location = New Point(70, 97)
        lblBookID.Name = "lblBookID"
        lblBookID.Size = New Size(85, 28)
        lblBookID.TabIndex = 4
        lblBookID.Text = "Book ID:"
        ' 
        ' txtBookID
        ' 
        txtBookID.Location = New Point(203, 94)
        txtBookID.Name = "txtBookID"
        txtBookID.Size = New Size(241, 31)
        txtBookID.TabIndex = 5
        ' 
        ' lblIssueDate
        ' 
        lblIssueDate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblIssueDate.AutoSize = True
        lblIssueDate.Font = New Font("Segoe UI", 9.75F)
        lblIssueDate.Location = New Point(520, 19)
        lblIssueDate.Name = "lblIssueDate"
        lblIssueDate.Size = New Size(104, 28)
        lblIssueDate.TabIndex = 6
        lblIssueDate.Text = "Issue Date:"
        ' 
        ' dtpIssue
        ' 
        dtpIssue.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        dtpIssue.Format = DateTimePickerFormat.Short
        dtpIssue.Location = New Point(649, 14)
        dtpIssue.Name = "dtpIssue"
        dtpIssue.Size = New Size(241, 31)
        dtpIssue.TabIndex = 7
        ' 
        ' lblReturnDate
        ' 
        lblReturnDate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblReturnDate.AutoSize = True
        lblReturnDate.Font = New Font("Segoe UI", 9.75F)
        lblReturnDate.Location = New Point(520, 57)
        lblReturnDate.Name = "lblReturnDate"
        lblReturnDate.Size = New Size(119, 28)
        lblReturnDate.TabIndex = 8
        lblReturnDate.Text = "Return Date:"
        ' 
        ' dtpReturn
        ' 
        dtpReturn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        dtpReturn.Format = DateTimePickerFormat.Short
        dtpReturn.Location = New Point(647, 52)
        dtpReturn.Name = "dtpReturn"
        dtpReturn.Size = New Size(243, 31)
        dtpReturn.TabIndex = 9
        ' 
        ' lblFine
        ' 
        lblFine.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblFine.AutoSize = True
        lblFine.Font = New Font("Segoe UI", 9.75F)
        lblFine.Location = New Point(520, 93)
        lblFine.Name = "lblFine"
        lblFine.Size = New Size(109, 28)
        lblFine.TabIndex = 10
        lblFine.Text = "Fine (GHC):"
        ' 
        ' txtFine
        ' 
        txtFine.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtFine.Location = New Point(647, 90)
        txtFine.Name = "txtFine"
        txtFine.Size = New Size(243, 31)
        txtFine.TabIndex = 11
        txtFine.Text = "0.00"
        ' 
        ' dgvTransactions
        ' 
        dgvTransactions.AllowUserToAddRows = False
        dgvTransactions.AllowUserToDeleteRows = False
        dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTransactions.BackgroundColor = Color.White
        dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransactions.Dock = DockStyle.Fill
        dgvTransactions.Location = New Point(0, 221)
        dgvTransactions.Name = "dgvTransactions"
        dgvTransactions.RowHeadersWidth = 62
        dgvTransactions.Size = New Size(1299, 470)
        dgvTransactions.TabIndex = 16
        ' 
        ' lblTitleBlock
        ' 
        lblTitleBlock.AutoSize = True
        lblTitleBlock.Location = New Point(606, 22)
        lblTitleBlock.Name = "lblTitleBlock"
        lblTitleBlock.Size = New Size(0, 25)
        lblTitleBlock.TabIndex = 17
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label2)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1299, 83)
        pnlHeader.TabIndex = 27
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(31, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(412, 25)
        Label3.TabIndex = 0
        Label3.Text = "Manage Book Trannsactions - Issue / Return Books"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(31, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(302, 36)
        Label2.TabIndex = 0
        Label2.Text = "CIRCULATION MODULE"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblTransactionID)
        Panel1.Controls.Add(txtTxID)
        Panel1.Controls.Add(txtMemberID)
        Panel1.Controls.Add(lblMemberID)
        Panel1.Controls.Add(lblBookID)
        Panel1.Controls.Add(txtBookID)
        Panel1.Controls.Add(lblIssueDate)
        Panel1.Controls.Add(dtpIssue)
        Panel1.Controls.Add(txtFine)
        Panel1.Controls.Add(lblReturnDate)
        Panel1.Controls.Add(lblFine)
        Panel1.Controls.Add(dtpReturn)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 83)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1299, 138)
        Panel1.TabIndex = 28
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnIssue)
        Panel2.Controls.Add(btnReturn)
        Panel2.Controls.Add(btnClear)
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.ForeColor = Color.White
        Panel2.Location = New Point(0, 691)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1299, 107)
        Panel2.TabIndex = 29
        ' 
        ' btnIssue
        ' 
        btnIssue.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnIssue.BackColor = Color.FromArgb(CByte(15), CByte(118), CByte(110))
        btnIssue.FlatStyle = FlatStyle.Flat
        btnIssue.ForeColor = Color.White
        btnIssue.Location = New Point(54, 41)
        btnIssue.Name = "btnIssue"
        btnIssue.Size = New Size(88, 43)
        btnIssue.TabIndex = 10
        btnIssue.Text = "&ISSUE"
        btnIssue.UseVisualStyleBackColor = False
        ' 
        ' btnReturn
        ' 
        btnReturn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnReturn.BackColor = Color.Navy
        btnReturn.FlatStyle = FlatStyle.Flat
        btnReturn.ForeColor = Color.White
        btnReturn.Location = New Point(160, 41)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(92, 43)
        btnReturn.TabIndex = 11
        btnReturn.Text = "&RETURN"
        btnReturn.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnClear.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(269, 41)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(92, 43)
        btnClear.TabIndex = 13
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(190), CByte(18), CByte(60))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1151, 41)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(88, 43)
        btnClose.TabIndex = 12
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' frmManageTransactions
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1299, 798)
        Controls.Add(dgvTransactions)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(pnlHeader)
        Controls.Add(lblTitleBlock)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmManageTransactions"
        Text = "Manage Book Transactions"
        CType(dgvTransactions, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTransactionID As Label
    Friend WithEvents txtTxID As TextBox
    Friend WithEvents txtMemberID As TextBox
    Friend WithEvents lblMemberID As Label
    Friend WithEvents lblBookID As Label
    Friend WithEvents txtBookID As TextBox
    Friend WithEvents lblIssueDate As Label
    Friend WithEvents dtpIssue As DateTimePicker
    Friend WithEvents lblReturnDate As Label
    Friend WithEvents dtpReturn As DateTimePicker
    Friend WithEvents lblFine As Label
    Friend WithEvents txtFine As TextBox
    Friend WithEvents dgvTransactions As DataGridView
    Friend WithEvents lblTitleBlock As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnIssue As Button
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
End Class
