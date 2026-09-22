Imports System.Drawing

Public Class frmMain
    'Stores the member info passed from Login
    Public LoggedInRole As String = ""
    Public LoggedInMemberID As String = ""

    ' Holds user role passed from frmLogin ("Admin" or "User")
    Public UserRole As String = "User"
    Private isLoggingOut As Boolean = False

    ' Set fixed heights for submenus
    Private ReadOnly SUBMENU_HEIGHT_2_ITEMS As Integer = 80
    Private ReadOnly SUBMENU_HEIGHT_1_ITEM As Integer = 40

    ' ====================================================================================
    ' 1. INITIALIZATION & ROLE-BASED ACCESS CONTROL (RBAC)
    ' ====================================================================================
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatusDate.Text = "Date: " & DateTime.Now.ToString("yyyy-MM-dd")

        ' Evaluate User Role from Database
        Dim isAdmin As Boolean = String.Equals(LoggedInRole, "Admin", StringComparison.OrdinalIgnoreCase)
        lblStatusUser.Text = If(isAdmin, "User: Admin", "User: Standard User")

        ' Apply System Access Permissions based on Database Role
        ApplyRolePermissions(isAdmin)

    End Sub

    ''' <summary>
    ''' Configures feature permissions based on account type.
    ''' </summary>
    Private Sub ApplyRolePermissions(ByVal isAdmin As Boolean)
        ' --- ADMIN HAS ACCESS TO EVERYTHING ---
        ' --- USER HAS RESTRICTED ACCESS ---

        ' Books Submenu
        btnManageBooks.Visible = isAdmin     ' Admin Only (CRUD)
        btnViewBooks.Visible = True          ' Everyone can view catalog

        ' Members Submenu
        btnManageMembers.Visible = isAdmin   ' Admin Only (CRUD)
        btnViewMembers.Visible = isAdmin        'Admin Only

        ' Transactions Submenu
        btnManageTransactions.Visible = isAdmin        ' Admin Only
        btnViewTransactions.Visible = True          ' Everyone can view history

        ' Admin-Only Top-Level Modules
        btnAddNewUser.Visible = isAdmin         ' Admin Only
        btnViewUsers.Visible = isAdmin           ' Admin Only
        btnReports.Visible = isAdmin            ' Admin Only
    End Sub


    ' ====================================================================================
    ' 3. MDI WINDOW LAUNCHER ENGINE
    ' ====================================================================================

    Private Sub OpenForm(Of T As {Form, New})()
        ' 1. Un-maximize any open MDI children so the new form doesn't snap to Maximized
        For Each child As Form In Me.MdiChildren
            If child.WindowState = FormWindowState.Maximized Then
                child.WindowState = FormWindowState.Normal
            End If
        Next

        ' 2. Check if form is already open
        Dim targetForm As Form = Me.MdiChildren.OfType(Of T)().FirstOrDefault()

        If targetForm Is Nothing Then
            targetForm = New T()
            targetForm.MdiParent = Me
            'targetForm.WindowState = FormWindowState.Normal
            targetForm.WindowState = FormWindowState.Maximized
            targetForm.StartPosition = FormStartPosition.Manual

            targetForm.Show()
            CenterMdiChild(targetForm)
        Else
            'targetForm.WindowState = FormWindowState.Normal
            targetForm.WindowState = FormWindowState.Maximized
            targetForm.BringToFront()
            targetForm.Activate()
            CenterMdiChild(targetForm)
        End If
    End Sub

    ' Helper routine to center non-maximized floating windows inside frmMain
    Private Sub CenterMdiChild(child As Form)
        ' Calculate available space inside the MDI client panel
        Dim mdiClientArea As Control = Me.Controls.OfType(Of MdiClient)().FirstOrDefault()

        If mdiClientArea IsNot Nothing Then
            Dim x As Integer = (mdiClientArea.Width - child.Width) \ 2
            Dim y As Integer = (mdiClientArea.Height - child.Height) \ 2

            If x < 0 Then x = 0
            If y < 0 Then y = 0

            child.Location = New Point(x, y)
        End If
    End Sub

    ' ====================================================================================
    ' 4. NAVIGATION CLICK EVENTS
    ' ====================================================================================
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        For Each child As Form In Me.MdiChildren.ToArray()
            child.Close()
        Next
    End Sub

    Private Sub btnManageBooks_Click(sender As Object, e As EventArgs) Handles btnManageBooks.Click
        OpenForm(Of frmBooks)()
    End Sub


    Private Sub btnViewBooks_Click(sender As Object, e As EventArgs) Handles btnViewBooks.Click
        Dim bookForm As New frmViewBooks()

        bookForm.CurrentUserRole = Me.LoggedInRole
        bookForm.CurrentMemberID = Me.LoggedInMemberID

        'bookForm.TopLevel = False
        'bookForm.FormBorderStyle
        bookForm.Show()
    End Sub

    Private Sub btnManageMembers_Click(sender As Object, e As EventArgs) Handles btnManageMembers.Click
        OpenForm(Of frmMembers)()
    End Sub

    Private Sub btnViewMembers_Click(sender As Object, e As EventArgs) Handles btnViewMembers.Click
        OpenForm(Of frmViewMembers)()
    End Sub

    Private Sub btnManageTransactions_Click(sender As Object, e As EventArgs) Handles btnManageTransactions.Click
        OpenForm(Of frmManageTransactions)()
    End Sub

    Private Sub btnViewTransactions_Click(sender As Object, e As EventArgs) Handles btnViewTransactions.Click
        OpenForm(Of frmViewTransactions)()
    End Sub

    Private Sub btnAddNewUser_Click(sender As Object, e As EventArgs) Handles btnAddNewUser.Click
        OpenForm(Of frmRegister)()
    End Sub

    Private Sub btnViewUsers_Click(sender As Object, e As EventArgs) Handles btnViewUsers.Click
        OpenForm(Of frmViewUsers)()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        OpenForm(Of frmLMSReports)()
    End Sub

    ' ====================================================================================
    ' 5. SYSTEM DIALOGS & LOGOUT
    ' ====================================================================================
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        OpenForm(Of frmAbout)()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            isLoggingOut = True
            Me.Close()
            frmLogin.Show()
            frmLogin.txtUsername.Clear()
            frmLogin.txtPassword.Clear()
            frmLogin.txtUsername.Focus()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isLoggingOut AndAlso e.CloseReason = CloseReason.UserClosing Then
            If MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
            Else
                Application.ExitThread()
            End If
        End If
    End Sub



End Class