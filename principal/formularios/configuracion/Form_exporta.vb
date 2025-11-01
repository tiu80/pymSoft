Public Class Form_exporta

    Private Sub Form_exporta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmd_tipo.Text = Me.cmd_tipo.Items(0)
    End Sub

    Private Sub cmd_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exportar.Click

        If Me.cmd_tipo.Text = "Exel" Then

            Dim cadena As String

            If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_cons_comp.DataGridView2, Form_muestra_cons_comp.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_muestra_factura.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_factura.DataGridView1, Form_muestra_factura.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_cta_cte.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_cta_cte.DataGridView1, Form_cta_cte.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_muestra_saldo.txt_estado_form.Text = 1 Then
                cadena = Form_muestra_saldo.txt_comentario.Text & vbCrLf & Form_muestra_saldo.txt_comentario1.Text
                Call ExportarDatosExcel(Form_muestra_saldo.DataGridView1, cadena)
                Me.Dispose()
            End If

            If Form_muestra_seguim.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_seguim.DataGridView1, Form_muestra_seguim.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_muestra_stock.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_stock.DataGridView1, Form_muestra_stock.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_muestra_pedido_prov.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_pedido_prov.DataGridView1, Form_muestra_pedido_prov.txt_comentario.Text)
                Me.Dispose()
            End If

            If Form_muestra_planilla.txt_estado_form.Text = 1 Then
                Call ExportarDatosExcel(Form_muestra_planilla.DataGridView1, "")
                Me.Dispose()
            End If

        End If
    End Sub

End Class