Public Class barra_carga

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Me.Timer1.Interval = 150 Then
            Me.Dispose()
        End If

        Timer1.Enabled = False

    End Sub

End Class