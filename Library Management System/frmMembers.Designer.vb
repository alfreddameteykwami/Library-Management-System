<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembers
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
        lblSearchName = New Label()
        lblStatus = New Label()
        lblEmail = New Label()
        lblPhone = New Label()
        lblFullName = New Label()
        lblMemberID = New Label()
        txtFullName = New TextBox()
        txtMemberID = New TextBox()
        txtSearch = New TextBox()
        txtEmail = New TextBox()
        txtPhone = New TextBox()
        cmbStatus = New ComboBox()
        dgvMembers = New DataGridView()
        Panel1 = New Panel()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        btnAdd = New Button()
        btnClose = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        CType(dgvMembers, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        pnlHeader.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblSearchName
        ' 
        lblSearchName.AutoSize = True
        lblSearchName.Font = New Font("Segoe UI", 9.75F)
        lblSearchName.Location = New Point(482, 102)
        lblSearchName.Name = "lblSearchName"
        lblSearchName.Size = New Size(131, 28)
        lblSearchName.TabIndex = 15
        lblSearchName.Text = "Search Name:"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 9.75F)
        lblStatus.Location = New Point(482, 60)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(69, 28)
        lblStatus.TabIndex = 8
        lblStatus.Text = "Status:"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 9.75F)
        lblEmail.Location = New Point(482, 23)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(63, 28)
        lblEmail.TabIndex = 6
        lblEmail.Text = "Email:"
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Font = New Font("Segoe UI", 9.75F)
        lblPhone.Location = New Point(32, 102)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(71, 28)
        lblPhone.TabIndex = 4
        lblPhone.Text = "Phone:"
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Font = New Font("Segoe UI", 9.75F)
        lblFullName.Location = New Point(32, 63)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(104, 28)
        lblFullName.TabIndex = 2
        lblFullName.Text = "Full Name:"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Font = New Font("Segoe UI", 9.75F)
        lblMemberID.Location = New Point(32, 23)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(114, 28)
        lblMemberID.TabIndex = 0
        lblMemberID.Text = "Member ID:"
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(152, 60)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(237, 33)
        txtFullName.TabIndex = 3
        ' 
        ' txtMemberID
        ' 
        txtMemberID.Location = New Point(152, 20)
        txtMemberID.Name = "txtMemberID"
        txtMemberID.Size = New Size(237, 33)
        txtMemberID.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(619, 99)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(235, 33)
        txtSearch.TabIndex = 16
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(618, 20)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(237, 33)
        txtEmail.TabIndex = 7
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(152, 99)
        txtPhone.MaxLength = 10
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(237, 33)
        txtPhone.TabIndex = 5
        ' 
        ' cmbStatus
        ' 
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.FormattingEnabled = True
        cmbStatus.Items.AddRange(New Object() {"Active", "Suspended"})
        cmbStatus.Location = New Point(618, 57)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(237, 36)
        cmbStatus.TabIndex = 9
        ' 
        ' dgvMembers
        ' 
        dgvMembers.AllowUserToDeleteRows = False
        dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMembers.BackgroundColor = Color.White
        dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembers.Dock = DockStyle.Fill
        dgvMembers.Location = New Point(0, 236)
        dgvMembers.Name = "dgvMembers"
        dgvMembers.RowHeadersWidth = 62
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMembers.Size = New Size(1289, 498)
        dgvMembers.TabIndex = 18
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblMemberID)
        Panel1.Controls.Add(lblSearchName)
        Panel1.Controls.Add(cmbStatus)
        Panel1.Controls.Add(lblStatus)
        Panel1.Controls.Add(lblEmail)
        Panel1.Controls.Add(lblPhone)
        Panel1.Controls.Add(lblFullName)
        Panel1.Controls.Add(txtFullName)
        Panel1.Controls.Add(txtMemberID)
        Panel1.Controls.Add(txtPhone)
        Panel1.Controls.Add(txtSearch)
        Panel1.Controls.Add(txtEmail)
        Panel1.Dock = DockStyle.Top
        Panel1.Font = New Font("Segoe UI", 9.75F)
        Panel1.Location = New Point(0, 83)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1289, 153)
        Panel1.TabIndex = 19
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label2)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1289, 83)
        pnlHeader.TabIndex = 27
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(31, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(214, 25)
        Label3.TabIndex = 0
        Label3.Text = "Manage Library Members"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(31, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(450, 36)
        Label2.TabIndex = 0
        Label2.Text = "MEMBER REGISTRY MANAGEMENT"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnAdd)
        Panel2.Controls.Add(btnClose)
        Panel2.Controls.Add(btnUpdate)
        Panel2.Controls.Add(btnDelete)
        Panel2.Controls.Add(btnClear)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 734)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1289, 86)
        Panel2.TabIndex = 28
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnAdd.BackColor = Color.FromArgb(CByte(15), CByte(118), CByte(110))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(43, 18)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(88, 43)
        btnAdd.TabIndex = 29
        btnAdd.Text = "&ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(190), CByte(18), CByte(60))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1141, 18)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 43)
        btnClose.TabIndex = 33
        btnClose.Text = "C&LOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnUpdate.BackColor = Color.Navy
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(149, 18)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(92, 43)
        btnUpdate.TabIndex = 30
        btnUpdate.Text = "&UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnDelete.BackColor = Color.FromArgb(CByte(190), CByte(18), CByte(60))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(258, 18)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(88, 43)
        btnDelete.TabIndex = 31
        btnDelete.Text = "&DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnClear.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(364, 18)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(92, 43)
        btnClear.TabIndex = 32
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' frmMembers
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1289, 820)
        Controls.Add(dgvMembers)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MinimumSize = New Size(900, 650)
        Name = "frmMembers"
        Text = "Member Registry Mangement"
        CType(dgvMembers, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents lblSearchName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblMemberID As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtMemberID As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents dgvMembers As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
End Class
