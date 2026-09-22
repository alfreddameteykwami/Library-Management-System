Public Module modErrorHandler
    Public Sub LogError(ByVal ex As Exception)
        MessageBox.Show("An unexpected error occured: " & ex.Message, "System Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Module
