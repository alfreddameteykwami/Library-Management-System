<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewUsers
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
        dgvUsers = New DataGridView()
        lblSearchName = New Label()
        txtSearchName = New TextBox()
        btnDeleteUser = New Button()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label1 = New Label()
        pnlFooter = New Panel()
        btnClose = New Button()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Dock = DockStyle.Fill
        dgvUsers.Location = New Point(0, 115)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.RowHeadersWidth = 62
        dgvUsers.Size = New Size(1372, 469)
        dgvUsers.TabIndex = 0
        ' 
        ' lblSearchName
        ' 
        lblSearchName.AutoSize = True
        lblSearchName.ForeColor = Color.White
        lblSearchName.Location = New Point(752, 58)
        lblSearchName.Name = "lblSearchName"
        lblSearchName.Size = New Size(196, 25)
        lblSearchName.TabIndex = 1
        lblSearchName.Text = "Search by Name / Role:"
        ' 
        ' txtSearchName
        ' 
        txtSearchName.Location = New Point(954, 55)
        txtSearchName.Name = "txtSearchName"
        txtSearchName.Size = New Size(278, 31)
        txtSearchName.TabIndex = 2
        ' 
        ' btnDeleteUser
        ' 
        btnDeleteUser.BackColor = Color.Teal
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location = New Point(1046, 11)
        btnDeleteUser.Name = "btnDeleteUser"
        btnDeleteUser.Size = New Size(141, 47)
        btnDeleteUser.TabIndex = 4
        btnDeleteUser.Text = "&DELETE USER"
        btnDeleteUser.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Controls.Add(lblSearchName)
        pnlHeader.Controls.Add(txtSearchName)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1372, 115)
        pnlHeader.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(29, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(185, 25)
        Label3.TabIndex = 3
        Label3.Text = "View Registered Users"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(29, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(415, 38)
        Label1.TabIndex = 2
        Label1.Text = "VIEW REGISTERED USERS LOG"
        ' 
        ' pnlFooter
        ' 
        pnlFooter.Controls.Add(btnClose)
        pnlFooter.Controls.Add(btnDeleteUser)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 584)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1372, 70)
        pnlFooter.TabIndex = 7
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1216, 11)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 47)
        btnClose.TabIndex = 3
        btnClose.Text = "&CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' frmViewUsers
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1372, 654)
        Controls.Add(dgvUsers)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmViewUsers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registered Users"
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents lblSearchName As Label
    Friend WithEvents txtSearchName As TextBox
    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnClose As Button
End Class
