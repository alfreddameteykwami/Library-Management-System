<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        ssStatus = New StatusStrip()
        lblStatusUser = New ToolStripStatusLabel()
        lblStatusDate = New ToolStripStatusLabel()
        pnlSidebar = New Panel()
        PictureBox1 = New PictureBox()
        Button4 = New Button()
        btnViewBooks = New Button()
        btnDashboard = New Button()
        btnManageMembers = New Button()
        flpSidebar = New FlowLayoutPanel()
        btnManageBooks = New Button()
        btnViewMembers = New Button()
        btnManageTransactions = New Button()
        btnViewTransactions = New Button()
        btnAddNewUser = New Button()
        btnViewUsers = New Button()
        btnReports = New Button()
        pnlSidebarBottom = New Panel()
        btnExit = New Button()
        btnAbout = New Button()
        btnLogout = New Button()
        ssStatus.SuspendLayout()
        pnlSidebar.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        flpSidebar.SuspendLayout()
        pnlSidebarBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' ssStatus
        ' 
        ssStatus.ImageScalingSize = New Size(24, 24)
        ssStatus.Items.AddRange(New ToolStripItem() {lblStatusUser, lblStatusDate})
        ssStatus.Location = New Point(0, 1012)
        ssStatus.Name = "ssStatus"
        ssStatus.Size = New Size(1157, 32)
        ssStatus.TabIndex = 2
        ssStatus.Text = "StatusStrip1"
        ' 
        ' lblStatusUser
        ' 
        lblStatusUser.Name = "lblStatusUser"
        lblStatusUser.Size = New Size(109, 25)
        lblStatusUser.Text = "User: Admin"
        ' 
        ' lblStatusDate
        ' 
        lblStatusDate.Name = "lblStatusDate"
        lblStatusDate.Size = New Size(53, 25)
        lblStatusDate.Text = "Date:"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Transparent
        pnlSidebar.Controls.Add(PictureBox1)
        pnlSidebar.Controls.Add(Button4)
        pnlSidebar.Location = New Point(3, 3)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(294, 199)
        pnlSidebar.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.icons8_book_shelf_100
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(76, 37)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(133, 132)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(3, 599)
        Button4.Name = "Button4"
        Button4.Size = New Size(287, 59)
        Button4.TabIndex = 8
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' btnViewBooks
        ' 
        btnViewBooks.FlatStyle = FlatStyle.Flat
        btnViewBooks.Font = New Font("Segoe UI", 10F)
        btnViewBooks.ForeColor = Color.White
        btnViewBooks.Location = New Point(3, 310)
        btnViewBooks.Name = "btnViewBooks"
        btnViewBooks.Padding = New Padding(15, 0, 0, 0)
        btnViewBooks.Size = New Size(284, 45)
        btnViewBooks.TabIndex = 5
        btnViewBooks.Text = "View Book Catalog"
        btnViewBooks.TextAlign = ContentAlignment.MiddleLeft
        btnViewBooks.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI", 10F)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(3, 208)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(15, 0, 0, 0)
        btnDashboard.Size = New Size(284, 45)
        btnDashboard.TabIndex = 6
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' btnManageMembers
        ' 
        btnManageMembers.FlatStyle = FlatStyle.Flat
        btnManageMembers.Font = New Font("Segoe UI", 10F)
        btnManageMembers.ForeColor = Color.White
        btnManageMembers.Location = New Point(3, 361)
        btnManageMembers.Name = "btnManageMembers"
        btnManageMembers.Padding = New Padding(15, 0, 0, 0)
        btnManageMembers.Size = New Size(284, 45)
        btnManageMembers.TabIndex = 7
        btnManageMembers.Text = "Manage Members Statuses"
        btnManageMembers.TextAlign = ContentAlignment.MiddleLeft
        btnManageMembers.UseVisualStyleBackColor = True
        ' 
        ' flpSidebar
        ' 
        flpSidebar.AutoScroll = True
        flpSidebar.BackColor = Color.FromArgb(CByte(24), CByte(30), CByte(54))
        flpSidebar.Controls.Add(pnlSidebar)
        flpSidebar.Controls.Add(btnDashboard)
        flpSidebar.Controls.Add(btnManageBooks)
        flpSidebar.Controls.Add(btnViewBooks)
        flpSidebar.Controls.Add(btnManageMembers)
        flpSidebar.Controls.Add(btnViewMembers)
        flpSidebar.Controls.Add(btnManageTransactions)
        flpSidebar.Controls.Add(btnViewTransactions)
        flpSidebar.Controls.Add(btnAddNewUser)
        flpSidebar.Controls.Add(btnViewUsers)
        flpSidebar.Controls.Add(btnReports)
        flpSidebar.Controls.Add(pnlSidebarBottom)
        flpSidebar.Dock = DockStyle.Left
        flpSidebar.FlowDirection = FlowDirection.TopDown
        flpSidebar.Location = New Point(0, 0)
        flpSidebar.Name = "flpSidebar"
        flpSidebar.Size = New Size(300, 1012)
        flpSidebar.TabIndex = 12
        flpSidebar.WrapContents = False
        ' 
        ' btnManageBooks
        ' 
        btnManageBooks.FlatStyle = FlatStyle.Flat
        btnManageBooks.Font = New Font("Segoe UI", 10F)
        btnManageBooks.ForeColor = Color.White
        btnManageBooks.Location = New Point(3, 259)
        btnManageBooks.Name = "btnManageBooks"
        btnManageBooks.Padding = New Padding(15, 0, 0, 0)
        btnManageBooks.Size = New Size(284, 45)
        btnManageBooks.TabIndex = 6
        btnManageBooks.Text = "Manage Books"
        btnManageBooks.TextAlign = ContentAlignment.MiddleLeft
        btnManageBooks.UseVisualStyleBackColor = True
        ' 
        ' btnViewMembers
        ' 
        btnViewMembers.FlatStyle = FlatStyle.Flat
        btnViewMembers.Font = New Font("Segoe UI", 10F)
        btnViewMembers.ForeColor = Color.White
        btnViewMembers.Location = New Point(3, 412)
        btnViewMembers.Name = "btnViewMembers"
        btnViewMembers.Padding = New Padding(15, 0, 0, 0)
        btnViewMembers.Size = New Size(284, 45)
        btnViewMembers.TabIndex = 7
        btnViewMembers.Text = "View Members Statuses"
        btnViewMembers.TextAlign = ContentAlignment.MiddleLeft
        btnViewMembers.UseVisualStyleBackColor = True
        ' 
        ' btnManageTransactions
        ' 
        btnManageTransactions.FlatStyle = FlatStyle.Flat
        btnManageTransactions.Font = New Font("Segoe UI", 10F)
        btnManageTransactions.ForeColor = Color.White
        btnManageTransactions.Location = New Point(3, 463)
        btnManageTransactions.Name = "btnManageTransactions"
        btnManageTransactions.Padding = New Padding(15, 0, 0, 0)
        btnManageTransactions.Size = New Size(284, 45)
        btnManageTransactions.TabIndex = 7
        btnManageTransactions.Text = "Issue/Return Books"
        btnManageTransactions.TextAlign = ContentAlignment.MiddleLeft
        btnManageTransactions.UseVisualStyleBackColor = True
        ' 
        ' btnViewTransactions
        ' 
        btnViewTransactions.FlatStyle = FlatStyle.Flat
        btnViewTransactions.Font = New Font("Segoe UI", 10F)
        btnViewTransactions.ForeColor = Color.White
        btnViewTransactions.Location = New Point(3, 514)
        btnViewTransactions.Name = "btnViewTransactions"
        btnViewTransactions.Padding = New Padding(15, 0, 0, 0)
        btnViewTransactions.Size = New Size(284, 45)
        btnViewTransactions.TabIndex = 7
        btnViewTransactions.Text = "View Transaction History"
        btnViewTransactions.TextAlign = ContentAlignment.MiddleLeft
        btnViewTransactions.UseVisualStyleBackColor = True
        ' 
        ' btnAddNewUser
        ' 
        btnAddNewUser.FlatStyle = FlatStyle.Flat
        btnAddNewUser.Font = New Font("Segoe UI", 10F)
        btnAddNewUser.ForeColor = Color.White
        btnAddNewUser.Location = New Point(3, 565)
        btnAddNewUser.Name = "btnAddNewUser"
        btnAddNewUser.Padding = New Padding(15, 0, 0, 0)
        btnAddNewUser.Size = New Size(284, 45)
        btnAddNewUser.TabIndex = 7
        btnAddNewUser.Text = "Add New User"
        btnAddNewUser.TextAlign = ContentAlignment.MiddleLeft
        btnAddNewUser.UseVisualStyleBackColor = True
        ' 
        ' btnViewUsers
        ' 
        btnViewUsers.FlatStyle = FlatStyle.Flat
        btnViewUsers.Font = New Font("Segoe UI", 10F)
        btnViewUsers.ForeColor = Color.White
        btnViewUsers.Location = New Point(3, 616)
        btnViewUsers.Name = "btnViewUsers"
        btnViewUsers.Padding = New Padding(15, 0, 0, 0)
        btnViewUsers.Size = New Size(284, 47)
        btnViewUsers.TabIndex = 14
        btnViewUsers.Text = "View Users"
        btnViewUsers.TextAlign = ContentAlignment.MiddleLeft
        btnViewUsers.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Segoe UI", 10F)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(3, 669)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(15, 0, 0, 0)
        btnReports.Size = New Size(284, 51)
        btnReports.TabIndex = 15
        btnReports.Text = "Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' pnlSidebarBottom
        ' 
        pnlSidebarBottom.BackColor = Color.FromArgb(CByte(18), CByte(23), CByte(42))
        pnlSidebarBottom.Controls.Add(btnExit)
        pnlSidebarBottom.Controls.Add(btnAbout)
        pnlSidebarBottom.Controls.Add(btnLogout)
        pnlSidebarBottom.Location = New Point(3, 726)
        pnlSidebarBottom.Name = "pnlSidebarBottom"
        pnlSidebarBottom.Size = New Size(284, 196)
        pnlSidebarBottom.TabIndex = 17
        ' 
        ' btnExit
        ' 
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.ForeColor = Color.White
        btnExit.Location = New Point(0, 130)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(284, 59)
        btnExit.TabIndex = 8
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnAbout
        ' 
        btnAbout.FlatStyle = FlatStyle.Flat
        btnAbout.ForeColor = Color.White
        btnAbout.Location = New Point(0, 0)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(284, 59)
        btnAbout.TabIndex = 8
        btnAbout.Text = "About LMS"
        btnAbout.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(0, 65)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(284, 59)
        btnLogout.TabIndex = 8
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1157, 1044)
        Controls.Add(flpSidebar)
        Controls.Add(ssStatus)
        IsMdiContainer = True
        MaximizeBox = False
        Name = "frmMain"
        Text = "Library Management System - Dashboard"
        WindowState = FormWindowState.Maximized
        ssStatus.ResumeLayout(False)
        ssStatus.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        flpSidebar.ResumeLayout(False)
        pnlSidebarBottom.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ssStatus As StatusStrip
    Friend WithEvents lblStatusUser As ToolStripStatusLabel
    Friend WithEvents lblStatusDate As ToolStripStatusLabel
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnViewBooks As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnManageMembers As Button
    Friend WithEvents flpSidebar As FlowLayoutPanel
    Friend WithEvents Button4 As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnViewUsers As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents pnlSidebarBottom As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnManageBooks As Button
    Friend WithEvents btnViewMembers As Button
    Friend WithEvents btnManageTransactions As Button
    Friend WithEvents btnViewTransactions As Button
    Friend WithEvents btnAddNewUser As Button
End Class
