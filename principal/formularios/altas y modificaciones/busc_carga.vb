Public Class busc_carga

    Dim lis As New pymsoft.prov_vend_list_bco

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click
        lis.instruccion = "select id,carga from carga_01 where carga like '" & Me.txt_busqueda.Text & "%'"
        lis.tabla = "carga_01"
        lis.cabecera_nombre = "CARGA"
        lis.formulario = Me
        lis.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyDown

        If e.KeyCode = Keys.Return Then
            lis.instruccion = "select id,carga from carga_01 where carga like '" & Me.txt_busqueda.Text & "%'"
            lis.tabla = "carga_01"
            lis.cabecera_nombre = "CARGA"
            lis.formulario = Me
            lis.buscar()
            Me.DataGridView1.Focus()
        End If

    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            lis.instruccion = "select id,carga from carga_01 where id like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            lis.codigo = "id"
            lis.nombre = "carga"
            lis.cargar()

            If form_factura.txt_estado_form.Text = 1 Then
                form_factura.txt_n_carga.Text = (lis.text)
                form_factura.lbl_nombre_carga.Text = Trim(lis.text2)
                form_factura.txt_codigo_producto.Focus()
                form_factura.txt_n_carga.Enabled = False
            End If

            If Form_trans_pda.txt_estado_form.Text = 1 Then
                Form_trans_pda.txt_carga.Text = (lis.text)
                Form_trans_pda.lbl_nombre_carga.Text = Trim(lis.text2)
                Form_trans_pda.Check_cliente.Focus()
            End If

            If Form_parte_carga.txt_estado_form.Text = 1 Then
                Form_parte_carga.txt_n_carga.Text = (lis.text)
                Form_parte_carga.lbl_nombre_carga.Text = Trim(lis.text2)
                Form_parte_carga.cmd_aceptar.Focus()
            End If

            Me.Dispose()

        End If

    End Sub

End Class