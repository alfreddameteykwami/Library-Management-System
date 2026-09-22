<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewMembers
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
        txtSearch = New TextBox()
        lblSearchNamePhone = New Label()
        btnClose = New Button()
        pnlFooter = New Panel()
        TextBox1 = New TextBox()
        lblSearchTitleAuthor = New Label()
        dgvRoster = New DataGridView()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label1 = New Label()
        pnlFooter.SuspendLayout()
        CType(dgvRoster, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(863, 55)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(267, 31)
        txtSearch.TabIndex = 1
        ' 
        ' lblSearchNamePhone
        ' 
        lblSearchNamePhone.AutoSize = True
        lblSearchNamePhone.ForeColor = Color.White
        lblSearchNamePhone.Location = New Point(680, 58)
        lblSearchNamePhone.Name = "lblSearchNamePhone"
        lblSearchNamePhone.Size = New Size(177, 25)
        lblSearchNamePhone.TabIndex = 0
        lblSearchNamePhone.Text = "Search Name/Phone:"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1023, 16)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(107, 46)
        btnClose.TabIndex = 3
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlFooter
        ' 
        pnlFooter.Controls.Add(btnClose)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 732)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1161, 74)
        pnlFooter.TabIndex = 8
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TextBox1.Location = New Point(1813, 87)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(277, 31)
        TextBox1.TabIndex = 1
        ' 
        ' lblSearchTitleAuthor
        ' 
        lblSearchTitleAuthor.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblSearchTitleAuthor.AutoSize = True
        lblSearchTitleAuthor.ForeColor = Color.White
        lblSearchTitleAuthor.Location = New Point(1636, 90)
        lblSearchTitleAuthor.Name = "lblSearchTitleAuthor"
        lblSearchTitleAuthor.Size = New Size(171, 25)
        lblSearchTitleAuthor.TabIndex = 0
        lblSearchTitleAuthor.Text = "Search Tiltle/Author:"
        ' 
        ' dgvRoster
        ' 
        dgvRoster.AllowUserToAddRows = False
        dgvRoster.AllowUserToDeleteRows = False
        dgvRoster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRoster.BackgroundColor = Color.White
        dgvRoster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRoster.Dock = DockStyle.Fill
        dgvRoster.Location = New Point(0, 109)
        dgvRoster.Name = "dgvRoster"
        dgvRoster.RowHeadersWidth = 62
        dgvRoster.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRoster.Size = New Size(1161, 623)
        dgvRoster.TabIndex = 6
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(lblSearchTitleAuthor)
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Controls.Add(TextBox1)
        pnlHeader.Controls.Add(lblSearchNamePhone)
        pnlHeader.Controls.Add(txtSearch)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1161, 109)
        pnlHeader.TabIndex = 7
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
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(29, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(306, 38)
        Label1.TabIndex = 2
        Label1.Text = "VIEW BOOK CATALOG"
        ' 
        ' frmViewMembers
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1161, 806)
        Controls.Add(dgvRoster)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmViewMembers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmViewMembers"
        pnlFooter.ResumeLayout(False)
        CType(dgvRoster, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearchNamePhone As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblSearchTitleAuthor As Label
    Friend WithEvents dgvRoster As DataGridView
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
End Class
