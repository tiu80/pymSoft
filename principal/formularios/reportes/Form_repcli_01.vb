Public Class Form_repcli_01

    Private Sub Form_repcli_01_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub
End Class