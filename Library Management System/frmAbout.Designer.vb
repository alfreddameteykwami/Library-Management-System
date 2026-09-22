<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        btnOK = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(47, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(237, 25)
        Label1.TabIndex = 0
        Label1.Text = "Library Management System"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(47, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(259, 25)
        Label2.TabIndex = 1
        Label2.Text = "Version 1.0.0 (Production Build)"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(47, 131)
        Label3.Name = "Label3"
        Label3.Size = New Size(291, 25)
        Label3.TabIndex = 2
        Label3.Text = "System Guidelines && Specifications:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(47, 170)
        Label4.Name = "Label4"
        Label4.Size = New Size(341, 25)
        Label4.TabIndex = 3
        Label4.Text = "- Built-in In-Memory Module State Engine"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(47, 206)
        Label5.Name = "Label5"
        Label5.Size = New Size(595, 25)
        Label5.TabIndex = 4
        Label5.Text = "- Real-time Input Regular Expression Verification (Email && Contact lengths)"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(47, 244)
        Label6.Name = "Label6"
        Label6.Size = New Size(614, 25)
        Label6.TabIndex = 5
        Label6.Text = "- Automated Transaction Integrity && Multi-Form Synchronization Framework"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(47, 305)
        Label7.Name = "Label7"
        Label7.Size = New Size(336, 25)
        Label7.TabIndex = 6
        Label7.Text = "Developed by: Project Group 9 (Group 4)"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(47, 355)
        Label8.Name = "Label8"
        Label8.Size = New Size(212, 25)
        Label8.TabIndex = 7
        Label8.Text = "2026 All Rights Reserved."
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(314, 391)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(112, 34)
        btnOK.TabIndex = 8
        btnOK.Text = "&OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' frmAbout
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnOK)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAbout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "About System"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnOK As Button
End Class
