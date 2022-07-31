Public Class Form_tipo_comprobante

    Public x As Integer

    Private Sub cmd_tickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tickets.Click

        x = 1 ' ticket
        Me.Close()

    End Sub

    Private Sub cmd_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_factura.Click

        If RTrim(form_factura.txt_letra.Text) = "A" Then

            x = 2 ' factura A
            Me.Close()

        End If

        If RTrim(form_factura.txt_letra.Text) = "B" Then

            x = 3 'factura B
            Me.Close()

        End If

    End Sub

End Class