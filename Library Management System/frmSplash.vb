Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmSplash
    Private progressValue As Integer = 0

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply blur directly to the form's background image
        If Me.BackgroundImage IsNot Nothing Then
            Me.BackgroundImage = ApplyBlurAndOverlay(Me.BackgroundImage, 10, 110)
        End If

        ' Set label to transparent background relative to form
        lblLoadingStatus.BackColor = Color.Transparent

        ' Initial centering
        CenterStatusLabel()

        ' Initialize Timer and Progress Controls
        tmrSplash.Interval = 40
        prgLoading.Value = 0
        prgLoading.Maximum = 100
        tmrSplash.Start()
    End Sub

    ' ====================================================================================
    ' 1. DYNAMIC CENTERING LOGIC
    ' ====================================================================================
    ' Centers the label whenever its text length changes
    Private Sub lblLoadingStatus_TextChanged(sender As Object, e As EventArgs) Handles lblLoadingStatus.TextChanged
        CenterStatusLabel()
    End Sub

    Private Sub CenterStatusLabel()
        lblLoadingStatus.AutoSize = True
        lblLoadingStatus.Left = (Me.ClientSize.Width - lblLoadingStatus.Width) \ 2
        lblLoadingStatus.Refresh()
    End Sub

    ' ====================================================================================
    ' 2. FAST GDI+ BACKGROUND BLUR & DARK TINT HELPER
    ' ====================================================================================
    Private Function ApplyBlurAndOverlay(ByVal sourceImage As Image, ByVal blurFactor As Integer, ByVal overlayOpacity As Integer) As Bitmap
        If sourceImage Is Nothing Then Return Nothing
        If blurFactor < 1 Then blurFactor = 1

        ' Step A: Downscale image
        Dim smallWidth As Integer = Math.Max(1, sourceImage.Width \ blurFactor)
        Dim smallHeight As Integer = Math.Max(1, sourceImage.Height \ blurFactor)
        Dim smallBitmap As New Bitmap(smallWidth, smallHeight)

        Using gSmall As Graphics = Graphics.FromImage(smallBitmap)
            gSmall.InterpolationMode = InterpolationMode.HighQualityBilinear
            gSmall.DrawImage(sourceImage, New Rectangle(0, 0, smallWidth, smallHeight))
        End Using

        ' Step B: Upscale back to original size
        Dim blurredImage As New Bitmap(sourceImage.Width, sourceImage.Height)
        Using gFinal As Graphics = Graphics.FromImage(blurredImage)
            gFinal.InterpolationMode = InterpolationMode.HighQualityBilinear
            gFinal.DrawImage(smallBitmap, New Rectangle(0, 0, sourceImage.Width, sourceImage.Height))

            ' Step C: Apply dark tint overlay
            Using overlayBrush As New SolidBrush(Color.FromArgb(overlayOpacity, 0, 0, 0))
                gFinal.FillRectangle(overlayBrush, 0, 0, sourceImage.Width, sourceImage.Height)
            End Using
        End Using

        smallBitmap.Dispose()
        Return blurredImage
    End Function

    ' ====================================================================================
    ' 3. SPLASH TIMER PROGRESSION
    ' ====================================================================================
    Private Sub tmrSplash_Tick(sender As Object, e As EventArgs) Handles tmrSplash.Tick
        progressValue += 1

        If progressValue <= 100 Then
            prgLoading.Value = progressValue

            Select Case progressValue
                Case 1 To 25
                    lblLoadingStatus.Text = "Loading system libraries..."
                Case 26 To 50
                    lblLoadingStatus.Text = "Connecting to in-memory repositories..."
                Case 51 To 75
                    lblLoadingStatus.Text = "Verifying modules and constants..."
                Case 76 To 99
                    lblLoadingStatus.Text = "Optimising UI assets..."
                Case 100
                    lblLoadingStatus.Text = "Ready!"
            End Select
        Else
            tmrSplash.Stop()
            frmLogin.Show()
            Me.Hide()
        End If
    End Sub
End Class