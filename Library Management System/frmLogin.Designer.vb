<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblUsername = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnCancel = New Button()
        btnLogin = New Button()
        lblPassword = New Label()
        Label3 = New Label()
        tmrShake = New Timer(components)
        ckbShowPassword = New CheckBox()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.ForeColor = Color.White
        lblUsername.Location = New Point(3, 52)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(95, 25)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(104, 49)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(278, 31)
        txtUsername.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(104, 101)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(278, 31)
        txtPassword.TabIndex = 4
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(104, 254)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 49)
        btnCancel.TabIndex = 8
        btnCancel.Text = "&CANCEL"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(270, 254)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(112, 49)
        btnLogin.TabIndex = 7
        btnLogin.Text = "&LOGIN"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.ForeColor = Color.White
        lblPassword.Location = New Point(7, 107)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(91, 25)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(6, 323)
        Label3.Name = "Label3"
        Label3.Size = New Size(408, 32)
        Label3.TabIndex = 0
        Label3.Text = "LIBRARY MANAGEMENT SYSTEM"
        ' 
        ' tmrShake
        ' 
        tmrShake.Interval = 50
        ' 
        ' ckbShowPassword
        ' 
        ckbShowPassword.AutoSize = True
        ckbShowPassword.ForeColor = Color.White
        ckbShowPassword.Location = New Point(104, 152)
        ckbShowPassword.Name = "ckbShowPassword"
        ckbShowPassword.Size = New Size(162, 29)
        ckbShowPassword.TabIndex = 6
        ckbShowPassword.Text = "Show Password"
        ckbShowPassword.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(ckbShowPassword)
        Panel1.Controls.Add(lblUsername)
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(lblPassword)
        Panel1.Controls.Add(btnCancel)
        Panel1.Controls.Add(btnLogin)
        Panel1.Location = New Point(448, 90)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(396, 390)
        Panel1.TabIndex = 9
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.icons8_book_shelf_100
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(150, 173)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(127, 126)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.login_page
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(892, 561)
        Controls.Add(Label3)
        Controls.Add(PictureBox1)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tmrShake As Timer
    Friend WithEvents ckbShowPassword As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox

End Class
