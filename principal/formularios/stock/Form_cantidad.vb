Public Class Form_cantidad

    Dim num As New pymsoft.numerodecimales

    Private Sub txt_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad.KeyDown

        Try

            If e.KeyCode = Keys.Return Then
                Form_muestra_pedido_prov.DataGridView1.Rows(Form_muestra_pedido_prov.pos).Cells(3).Value = Me.txt_cantidad.Text
                Form_muestra_pedido_prov.DataGridView1.Rows(Form_muestra_pedido_prov.pos).Cells(5).Value = Format(Me.txt_cantidad.Text * Form_muestra_pedido_prov.DataGridView1.Rows(Form_muestra_pedido_prov.pos).Cells(6).Value, "0.000")
                Form_muestra_pedido_prov.DataGridView1.Item(5, Form_muestra_pedido_prov.pos).Style.ForeColor = Color.Red
                Me.Close()
            End If

        Catch ex As Exception

            Me.Close()

        End Try

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        num.positivos_punto(e, Me.txt_cantidad)
    End Sub

End Class