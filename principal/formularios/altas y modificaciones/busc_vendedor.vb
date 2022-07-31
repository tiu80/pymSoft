Public Class busc_vendedor

    Dim vend As New pymsoft.vendedor

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        vend.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click
        Me.Dispose()
    End Sub

    Private Sub txt_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_vendedor.KeyDown
        If e.KeyCode = Keys.Return Then
            vend.buscar()
            Me.DataGridView1.Focus()
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then

            vend.instruccion = "select *from vend_01 where id_vendedor like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            vend.codigo_vend = "id_vendedor"
            vend.nombre_vend = "nombre"
            vend.cargar_vendedor()

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.txt_vendedor.Text = vend.text
                Form_cliente.lbl_vendedor.Text = vend.text2
                Form_cliente.txt_sucursal.Focus()
            End If

            If Form_recibos.txt_estado_form.Text = 1 Then
                Form_recibos.txt_vendedor.Text = vend.text
                Form_recibos.txt_nom_vendedor.Text = vend.text2
                Form_recibos.txt_comprobante.Focus()
                Form_recibos.txt_vendedor.Enabled = False
            End If

            If Form_trans_pda.txt_estado_form.Text = 1 Then
                Form_trans_pda.txt_vendedor.Text = vend.text
                Form_trans_pda.lbl_vendedor.Text = vend.text2
                Form_trans_pda.dt_fecha_caja.Focus()
            End If

            If form_factura.txt_estado_form.Text = 1 Then
                form_factura.txt_vendedor.Text = vend.text
                form_factura.txt_nom_vendedor.Text = vend.text2
                If form_factura.txt_cod_lista.Enabled = False Then form_factura.txt_codigo_producto.Enabled = True
                form_factura.txt_codigo_producto.Focus()
                form_factura.txt_vendedor.Enabled = False
            End If

        End If

    End Sub

    Private Sub busc_vendedor_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub

End Class