Public Class busc_proveedor

    Dim lis As New pymsoft.prov_vend_list_bco

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click
        lis.instruccion = "select *from cli_01 where nombre like '" & Me.txt_busqueda.Text & "%' and tipo_cliente = 'Proveedor'"
        lis.tabla = "cli_01"
        lis.cabecera_nombre = "MOMBRE"
        lis.formulario = Me
        lis.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyDown

        If e.KeyCode = Keys.Return Then
            lis.instruccion = "select *from cli_01 where nombre like '" & Me.txt_busqueda.Text & "%' and tipo_cliente ='Proveedor'"
            lis.tabla = "cli_01"
            lis.cabecera_nombre = "NOMBRE"
            lis.formulario = Me
            lis.buscar()
            Me.DataGridView1.Focus()
        End If

    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            lis.instruccion = "select *from cli_01 where id_cli like '" & Me.DataGridView1.SelectedCells(0).Value & "' and tipo_cliente = 'Proveedor'"
            lis.codigo = "id_cli"
            lis.nombre = "nombre"
            lis.cargar()

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.txt_sucursal.Text = lis.text
                Form_cliente.lbl_sucursal.Text = lis.text2
                Form_cliente.cmb_rubro.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 1 Then
                Form_articulos.txt_proveedor.Text = lis.text
                Form_articulos.lbl_proveedor.Text = lis.text2
                Form_articulos.txt_costo.Focus()
            End If

            If Form_stock.txt_estado_form.Text = 1 Then
                Form_stock.txt_proveedor.Text = lis.text
                Form_stock.lbl_proveedor.Text = lis.text2
                Form_stock.txt_rubro.Focus()
            End If

            If Form_reporte_precios.txt_estado_form.Text = 1 Or Form_reporte_precios.txt_estado_form.Text = 2 Then
                Form_reporte_precios.txt_cod_prov.Text = lis.text
                Form_reporte_precios.lbl_prov.Text = lis.text2
                Form_reporte_precios.txt_cod_rub.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 4 Then
                Form_articulos.txt_prov.Text = lis.text
                Form_articulos.lbl_prov.Text = lis.text2
                Form_articulos.txt_rub.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 2 Then
                If Form_articulos.compara1 = True Then
                    Form_articulos.txt_rango_desde.Text = lis.text
                    Form_articulos.lbl_rango_desde.Text = lis.text2
                    Form_articulos.txt_rango_hasta.Focus()
                Else
                    Form_articulos.txt_rango_hasta.Text = lis.text
                    Form_articulos.lbl_rango_hasta.Text = lis.text2
                    Form_articulos.txt_porcentaje.Focus()
                End If
            End If

            Me.Dispose()

        End If

    End Sub
End Class
