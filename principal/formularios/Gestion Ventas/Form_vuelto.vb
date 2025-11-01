Public Class Form_vuelto

    Public valor_vuelto As Single

    Private Sub txt_vuelto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_vuelto.KeyDown
        Try

            If e.KeyCode = Keys.Return Then
                valor_vuelto = Me.txt_vuelto.Text - form_factura.txt_total_grilla.Text
                form_factura.txt_res_vuelto.Text = valor_vuelto
                Me.Close()
                MessageBox.Show("Su Vuelto es:" & " " & valor_vuelto, "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                barra_carga.Show()
                form_factura.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_vuelto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vuelto.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

End Class