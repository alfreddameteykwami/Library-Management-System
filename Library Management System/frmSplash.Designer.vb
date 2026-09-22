<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
        components = New ComponentModel.Container()
        tmrSplash = New Timer(components)
        prgLoading = New ProgressBar()
        lblLoadingStatus = New Label()
        lblSystemTitle = New Label()
        SuspendLayout()
        ' 
        ' tmrSplash
        ' 
        tmrSplash.Interval = 10000
        ' 
        ' prgLoading
        ' 
        prgLoading.Location = New Point(43, 215)
        prgLoading.Name = "prgLoading"
        prgLoading.Size = New Size(500, 12)
        prgLoading.TabIndex = 1
        ' 
        ' lblLoadingStatus
        ' 
        lblLoadingStatus.AutoSize = True
        lblLoadingStatus.BackColor = Color.Transparent
        lblLoadingStatus.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblLoadingStatus.ForeColor = Color.White
        lblLoadingStatus.Location = New Point(147, 175)
        lblLoadingStatus.Name = "lblLoadingStatus"
        lblLoadingStatus.Size = New Size(292, 25)
        lblLoadingStatus.TabIndex = 0
        lblLoadingStatus.Text = "Initializing system components..."
        lblLoadingStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSystemTitle
        ' 
        lblSystemTitle.AutoSize = True
        lblSystemTitle.BackColor = Color.Transparent
        lblSystemTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSystemTitle.ForeColor = Color.White
        lblSystemTitle.Location = New Point(6, 109)
        lblSystemTitle.Name = "lblSystemTitle"
        lblSystemTitle.Size = New Size(582, 48)
        lblSystemTitle.TabIndex = 2
        lblSystemTitle.Text = "LIBRARY MANAGEMENT SYSTEM"
        ' 
        ' frmSplash
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        BackgroundImage = My.Resources.Resources.photo_2026_08_13_02_21_59
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(600, 350)
        Controls.Add(lblSystemTitle)
        Controls.Add(lblLoadingStatus)
        Controls.Add(prgLoading)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSplash"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmSplash"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tmrSplash As Timer
    Friend WithEvents prgLoading As ProgressBar
    Friend WithEvents lblLoadingStatus As Label
    Friend WithEvents lblSystemTitle As Label
End Class
