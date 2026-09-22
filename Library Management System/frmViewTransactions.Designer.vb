<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewTransactions
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
        lblSearchMemberID = New Label()
        txtSearch = New TextBox()
        dgvTransactions = New DataGridView()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label1 = New Label()
        pnlFooter = New Panel()
        btnClose = New Button()
        CType(dgvTransactions, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblSearchMemberID
        ' 
        lblSearchMemberID.AutoSize = True
        lblSearchMemberID.ForeColor = Color.White
        lblSearchMemberID.Location = New Point(659, 58)
        lblSearchMemberID.Name = "lblSearchMemberID"
        lblSearchMemberID.Size = New Size(244, 25)
        lblSearchMemberID.TabIndex = 0
        lblSearchMemberID.Text = "Search Member ID / Book ID:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(909, 55)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(249, 31)
        txtSearch.TabIndex = 1
        ' 
        ' dgvTransactions
        ' 
        dgvTransactions.AllowUserToAddRows = False
        dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTransactions.BackgroundColor = Color.White
        dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransactions.Dock = DockStyle.Fill
        dgvTransactions.Location = New Point(0, 115)
        dgvTransactions.Name = "dgvTransactions"
        dgvTransactions.ReadOnly = True
        dgvTransactions.RowHeadersWidth = 62
        dgvTransactions.Size = New Size(1268, 582)
        dgvTransactions.TabIndex = 2
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Controls.Add(txtSearch)
        pnlHeader.Controls.Add(lblSearchMemberID)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1268, 115)
        pnlHeader.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(29, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(245, 25)
        Label3.TabIndex = 3
        Label3.Text = "View Book Circulation History"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(29, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(481, 38)
        Label1.TabIndex = 2
        Label1.Text = "VIEW TRANSACTION HISTORY LOG"
        ' 
        ' pnlFooter
        ' 
        pnlFooter.Controls.Add(btnClose)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 697)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1268, 70)
        pnlFooter.TabIndex = 6
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1144, 11)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 47)
        btnClose.TabIndex = 3
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' frmViewTransactions
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1268, 767)
        Controls.Add(dgvTransactions)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmViewTransactions"
        Text = "View Transaction History Log"
        CType(dgvTransactions, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblSearchMemberID As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvTransactions As DataGridView
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnClose As Button
End Class
