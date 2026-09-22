<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooks
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
        btnDelete = New Button()
        btnClear = New Button()
        btnUpdate = New Button()
        btnAdd = New Button()
        lblQuantity = New Label()
        lblAuthor = New Label()
        txtAuthor = New TextBox()
        txtTitle = New TextBox()
        lblTitle = New Label()
        txtBookID = New TextBox()
        lblBookID = New Label()
        cmbCategory = New ComboBox()
        lblGenre = New Label()
        Label1 = New Label()
        txtISBN = New TextBox()
        numTotalCopies = New NumericUpDown()
        dgvBooks = New DataGridView()
        btnClose = New Button()
        txtSearchInventory = New TextBox()
        lblSearchName = New Label()
        pnlHeader = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        GroupBox1 = New GroupBox()
        CType(numTotalCopies, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvBooks, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        Panel2.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnDelete
        ' 
        btnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnDelete.BackColor = Color.FromArgb(CByte(190), CByte(18), CByte(60))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(269, 34)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(88, 43)
        btnDelete.TabIndex = 12
        btnDelete.Text = "&DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnClear.BackColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(375, 34)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(92, 43)
        btnClear.TabIndex = 13
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnUpdate.BackColor = Color.Navy
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(160, 34)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(92, 43)
        btnUpdate.TabIndex = 11
        btnUpdate.Text = "&UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnAdd.BackColor = Color.FromArgb(CByte(15), CByte(118), CByte(110))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(54, 34)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(88, 43)
        btnAdd.TabIndex = 10
        btnAdd.Text = "&ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.ForeColor = SystemColors.ControlText
        lblQuantity.Location = New Point(597, 68)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(122, 28)
        lblQuantity.TabIndex = 8
        lblQuantity.Text = "Total Copies:"
        ' 
        ' lblAuthor
        ' 
        lblAuthor.AutoSize = True
        lblAuthor.ForeColor = SystemColors.ControlText
        lblAuthor.Location = New Point(28, 154)
        lblAuthor.Name = "lblAuthor"
        lblAuthor.Size = New Size(134, 28)
        lblAuthor.TabIndex = 4
        lblAuthor.Text = "Author Name:"
        ' 
        ' txtAuthor
        ' 
        txtAuthor.Location = New Point(165, 151)
        txtAuthor.Name = "txtAuthor"
        txtAuthor.Size = New Size(274, 33)
        txtAuthor.TabIndex = 5
        ' 
        ' txtTitle
        ' 
        txtTitle.Location = New Point(165, 105)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(274, 33)
        txtTitle.TabIndex = 3
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.ForeColor = SystemColors.ControlText
        lblTitle.Location = New Point(28, 108)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(103, 28)
        lblTitle.TabIndex = 2
        lblTitle.Text = "Book Title:"
        ' 
        ' txtBookID
        ' 
        txtBookID.BackColor = Color.LightGray
        txtBookID.Location = New Point(165, 14)
        txtBookID.Name = "txtBookID"
        txtBookID.ReadOnly = True
        txtBookID.Size = New Size(274, 33)
        txtBookID.TabIndex = 1
        ' 
        ' lblBookID
        ' 
        lblBookID.AutoSize = True
        lblBookID.ForeColor = SystemColors.ControlText
        lblBookID.Location = New Point(28, 17)
        lblBookID.Name = "lblBookID"
        lblBookID.Size = New Size(85, 28)
        lblBookID.TabIndex = 0
        lblBookID.Text = "Book ID:"
        ' 
        ' cmbCategory
        ' 
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategory.FormattingEnabled = True
        cmbCategory.Items.AddRange(New Object() {"Fiction", "Science", "History", "Biography", "Technology", "Art", "Mathematics", "Physics", "Chemistry", "Biology "})
        cmbCategory.Location = New Point(734, 16)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(274, 36)
        cmbCategory.TabIndex = 7
        ' 
        ' lblGenre
        ' 
        lblGenre.AutoSize = True
        lblGenre.ForeColor = SystemColors.ControlText
        lblGenre.Location = New Point(597, 19)
        lblGenre.Name = "lblGenre"
        lblGenre.Size = New Size(96, 28)
        lblGenre.TabIndex = 6
        lblGenre.Text = "Category:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(28, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(135, 28)
        Label1.TabIndex = 19
        Label1.Text = "ISBN Number:"
        ' 
        ' txtISBN
        ' 
        txtISBN.Location = New Point(165, 62)
        txtISBN.Name = "txtISBN"
        txtISBN.Size = New Size(274, 33)
        txtISBN.TabIndex = 20
        ' 
        ' numTotalCopies
        ' 
        numTotalCopies.Location = New Point(734, 66)
        numTotalCopies.Name = "numTotalCopies"
        numTotalCopies.Size = New Size(274, 33)
        numTotalCopies.TabIndex = 21
        ' 
        ' dgvBooks
        ' 
        dgvBooks.AllowUserToAddRows = False
        dgvBooks.AllowUserToDeleteRows = False
        dgvBooks.AllowUserToResizeRows = False
        dgvBooks.BackgroundColor = Color.White
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBooks.Dock = DockStyle.Fill
        dgvBooks.Location = New Point(0, 283)
        dgvBooks.Name = "dgvBooks"
        dgvBooks.RowHeadersWidth = 62
        dgvBooks.Size = New Size(1271, 426)
        dgvBooks.TabIndex = 22
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(190), CByte(18), CByte(60))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1140, 34)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 43)
        btnClose.TabIndex = 23
        btnClose.Text = "C&LOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' txtSearchInventory
        ' 
        txtSearchInventory.Location = New Point(894, 153)
        txtSearchInventory.Name = "txtSearchInventory"
        txtSearchInventory.Size = New Size(274, 33)
        txtSearchInventory.TabIndex = 25
        ' 
        ' lblSearchName
        ' 
        lblSearchName.AutoSize = True
        lblSearchName.ForeColor = SystemColors.ControlText
        lblSearchName.Location = New Point(597, 156)
        lblSearchName.Name = "lblSearchName"
        lblSearchName.Size = New Size(291, 28)
        lblSearchName.TabIndex = 24
        lblSearchName.Text = "Search by Book Title / Category:"
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.Navy
        pnlHeader.Controls.Add(Label3)
        pnlHeader.Controls.Add(Label2)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1271, 83)
        pnlHeader.TabIndex = 26
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Gainsboro
        Label3.Location = New Point(31, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(188, 25)
        Label3.TabIndex = 0
        Label3.Text = "Manage Library Books"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(31, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(440, 36)
        Label2.TabIndex = 0
        Label2.Text = "BOOK INVENTORY MANAGEMENT"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnAdd)
        Panel2.Controls.Add(btnUpdate)
        Panel2.Controls.Add(btnClose)
        Panel2.Controls.Add(btnClear)
        Panel2.Controls.Add(btnDelete)
        Panel2.Dock = DockStyle.Bottom
        Panel2.ForeColor = Color.White
        Panel2.Location = New Point(0, 709)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1271, 107)
        Panel2.TabIndex = 27
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblBookID)
        GroupBox1.Controls.Add(lblGenre)
        GroupBox1.Controls.Add(txtSearchInventory)
        GroupBox1.Controls.Add(cmbCategory)
        GroupBox1.Controls.Add(txtBookID)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(lblSearchName)
        GroupBox1.Controls.Add(lblQuantity)
        GroupBox1.Controls.Add(lblTitle)
        GroupBox1.Controls.Add(txtISBN)
        GroupBox1.Controls.Add(txtTitle)
        GroupBox1.Controls.Add(lblAuthor)
        GroupBox1.Controls.Add(txtAuthor)
        GroupBox1.Controls.Add(numTotalCopies)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Font = New Font("Segoe UI", 9.75F)
        GroupBox1.Location = New Point(0, 83)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1271, 200)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        ' 
        ' frmBooks
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1271, 816)
        Controls.Add(dgvBooks)
        Controls.Add(GroupBox1)
        Controls.Add(Panel2)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MinimumSize = New Size(950, 600)
        Name = "frmBooks"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Book Inventory Management"
        CType(numTotalCopies, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvBooks, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        Panel2.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtBookID As TextBox
    Friend WithEvents lblBookID As Label
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents lblGenre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents numTotalCopies As NumericUpDown
    Friend WithEvents dgvBooks As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents txtSearchInventory As TextBox
    Friend WithEvents lblSearchName As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
