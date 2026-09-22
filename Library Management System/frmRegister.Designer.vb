<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Label1 = New Label()
        lblUsername = New Label()
        lblRole = New Label()
        btnSave = New Button()
        lblPassword = New Label()
        txtRegPassword = New TextBox()
        txtRegUsername = New TextBox()
        cmbRole = New ComboBox()
        btnCancel = New Button()
        cmbMemberID = New ComboBox()
        lblMemberID = New Label()
        lblPasswordStrength = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(179, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(284, 32)
        Label1.TabIndex = 0
        Label1.Text = "CREATE NEW ACCOUNT"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(30, 91)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(95, 25)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username:"
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(332, 91)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(148, 25)
        lblRole.TabIndex = 2
        lblRole.Text = "Assign User Role:"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(202, 253)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 47)
        btnSave.TabIndex = 3
        btnSave.Text = "&SAVE"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(30, 158)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(91, 25)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password:"
        ' 
        ' txtRegPassword
        ' 
        txtRegPassword.Location = New Point(30, 186)
        txtRegPassword.Name = "txtRegPassword"
        txtRegPassword.Size = New Size(284, 31)
        txtRegPassword.TabIndex = 5
        txtRegPassword.UseSystemPasswordChar = True
        ' 
        ' txtRegUsername
        ' 
        txtRegUsername.Location = New Point(30, 119)
        txtRegUsername.Name = "txtRegUsername"
        txtRegUsername.Size = New Size(284, 31)
        txtRegUsername.TabIndex = 6
        ' 
        ' cmbRole
        ' 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.FormattingEnabled = True
        cmbRole.Items.AddRange(New Object() {"Admin", "User"})
        cmbRole.Location = New Point(332, 119)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(284, 33)
        cmbRole.TabIndex = 7
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(332, 253)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 47)
        btnCancel.TabIndex = 8
        btnCancel.Text = "&CANCEL"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' cmbMemberID
        ' 
        cmbMemberID.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMemberID.FormattingEnabled = True
        cmbMemberID.Location = New Point(332, 186)
        cmbMemberID.Name = "cmbMemberID"
        cmbMemberID.Size = New Size(284, 33)
        cmbMemberID.TabIndex = 9
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Location = New Point(332, 158)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(164, 25)
        lblMemberID.TabIndex = 10
        lblMemberID.Text = "Assign Member ID:"
        ' 
        ' lblPasswordStrength
        ' 
        lblPasswordStrength.AutoSize = True
        lblPasswordStrength.Location = New Point(71, 230)
        lblPasswordStrength.Name = "lblPasswordStrength"
        lblPasswordStrength.Size = New Size(0, 25)
        lblPasswordStrength.TabIndex = 11
        ' 
        ' frmRegister
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(656, 331)
        Controls.Add(lblPasswordStrength)
        Controls.Add(lblMemberID)
        Controls.Add(cmbMemberID)
        Controls.Add(btnCancel)
        Controls.Add(cmbRole)
        Controls.Add(txtRegUsername)
        Controls.Add(txtRegPassword)
        Controls.Add(lblPassword)
        Controls.Add(btnSave)
        Controls.Add(lblRole)
        Controls.Add(lblUsername)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmRegister"
        StartPosition = FormStartPosition.CenterScreen
        Text = "New Account"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtRegPassword As TextBox
    Friend WithEvents txtRegUsername As TextBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents cmbMemberID As ComboBox
    Friend WithEvents lblMemberID As Label
    Friend WithEvents lblPasswordStrength As Label
End Class
