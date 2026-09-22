Public Class frmAbout
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close() ' Safely dismisses the information window
    End Sub
    Private Sub frmMembers_Move(sender As Object, e As EventArgs) Handles Me.Move
        'Ensure the parent container exists
        If Me.MdiParent IsNot Nothing Then
            Dim parentContainer As Control = Me.MdiParent

            'Set up local boundaries based on MDI client area size
            '(Accounting for standard menu and status bar offsets)
            Dim maxRight As Integer = parentContainer.ClientSize.Width - Me.Width - 4
            Dim maxBottom As Integer = parentContainer.ClientSize.Height - Me.Height - 50

            'Snap to Left border
            If Me.Left < 0 Then Me.Left = 0

            'snap to top border
            If Me.Top < 0 Then Me.Top = 0

            'snap to right border
            If Me.Left > maxRight Then Me.Left = maxRight

            'snap to bottom border
            If Me.Top > maxBottom Then Me.Top = maxBottom

        End If
    End Sub

End Class