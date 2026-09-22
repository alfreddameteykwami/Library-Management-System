<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewBooks
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
        lblSearchTitleAuthor = New Label()
        txtSearch = New TextBox()
        dgvCatalog = New DataGridView()
        btnClose = New Button()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label1 = New Label()
        pnlFooter = New Panel()
        btnRequest = New Button()
        CType(dgvCatalog, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblSearchTitleAuthor
        ' 
        lblSearchTitleAuthor.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblSearchTitleAuthor.AutoSize = True
        lblSearchTitleAuthor.ForeColor = Color.White
        lblSearchTitleAuthor.Location = New Point(666, 58)
        lblSearchTitleAuthor.Name = "lblSearchTitleAuthor"
        lblSearchTitleAuthor.Size = New Size(171, 25)
        lblSearchTitleAuthor.TabIndex = 0
        lblSearchTitleAuthor.Text = "Search Tiltle/Author:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        txtSearch.Location = New Point(843, 55)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(277, 31)
        txtSearch.TabIndex = 1
        ' 
        ' dgvCatalog
        ' 
        dgvCatalog.AllowUserToAddRows = False
        dgvCatalog.AllowUserToDeleteRows = False
        dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCatalog.BackgroundColor = Color.White
        dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCatalog.Dock = DockStyle.Fill
        dgvCatalog.Location = New Point(0, 115)
        dgvCatalog.Name = "dgvCatalog"
        dgvCatalog.RowHeadersWidth = 62
        dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCatalog.Size = New Size(1141, 558)
        dgvCatalog.TabIndex = 2
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1005, 11)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 47)
        btnClose.TabIndex = 3
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Controls.Add(txtSearch)
        pnlHeader.Controls.Add(lblSearchTitleAuthor)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1141, 115)
        pnlHeader.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(29, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 25)
        Label3.TabIndex = 3
        Label3.Text = "View Library Books"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(29, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(306, 38)
        Label1.TabIndex = 2
        Label1.Text = "VIEW BOOK CATALOG"
        ' 
        ' pnlFooter
        ' 
        pnlFooter.Controls.Add(btnRequest)
        pnlFooter.Controls.Add(btnClose)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 673)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1141, 70)
        pnlFooter.TabIndex = 5
        ' 
        ' btnRequest
        ' 
        btnRequest.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnRequest.BackColor = Color.FromArgb(CByte(15), CByte(118), CByte(110))
        btnRequest.FlatStyle = FlatStyle.Flat
        btnRequest.ForeColor = Color.White
        btnRequest.Location = New Point(828, 11)
        btnRequest.Name = "btnRequest"
        btnRequest.Size = New Size(153, 47)
        btnRequest.TabIndex = 11
        btnRequest.Text = "&REQUEST BOOK"
        btnRequest.UseVisualStyleBackColor = False
        btnRequest.Visible = False
        ' 
        ' frmViewBooks
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1141, 743)
        Controls.Add(dgvCatalog)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmViewBooks"
        StartPosition = FormStartPosition.CenterScreen
        Text = "View Book Catalog"
        CType(dgvCatalog, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblSearchTitleAuthor As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvCatalog As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnRequest As Button
End Class
