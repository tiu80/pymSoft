Public Class busc_lista

    Dim suc As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        suc.instruccion = "select *from lista_01 where nombre like '" & Me.txt_sucursal.Text & "%'"
        suc.tabla = "lista_01"
        suc.cabecera_nombre = "LISTA"
        suc.formulario = Me
        suc.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            suc.instruccion = "select *from lista_01 where id_lis like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            suc.codigo = "id_lis"
            suc.nombre = "nombre"
            suc.cargar()

            If Form_lista_oferta.txt_estado_form.Text = 1 Then
                Form_lista_oferta.txt_lista.Text = suc.text
                Form_lista_oferta.lbl_lista.Text = suc.text2
                Form_lista_oferta.txt_art.Focus()
            End If

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.txt_sucursal.Text = suc.text
                Form_cliente.lbl_sucursal.Text = suc.text2
                Form_cliente.cmb_rubro.Focus()
            End If

            If Form_trans_pda.txt_estado_form.Text = 1 Then
                Form_trans_pda.txt_lista.Text = suc.text
                Form_trans_pda.lbl_lista.Text = suc.text2
                Form_trans_pda.txt_vendedor.Focus()
            End If

            If form_factura.txt_estado_form.Text = 1 Then
                form_factura.txt_cod_lista.Text = suc.text
                form_factura.txt_lista.Text = suc.text2
                form_factura.txt_codigo_producto.Enabled = True
                form_factura.txt_codigo_producto.Focus()
                form_factura.txt_cod_lista.Enabled = False
            End If

            If Form_articulos.txt_estado_form.Text = 1 Then
                Form_articulos.txt_lista.Text = suc.text
                Form_articulos.lbl_lista.Text = suc.text2
                Form_articulos.txt_codigo.Focus()
            End If

            If Form_stock.txt_estado_form.Text = 1 Then
                Form_stock.txt_codigo.Text = suc.text
                Form_stock.lbl_lista.Text = suc.text2
                Form_stock.txt_proveedor.Focus()
            End If

            If Form_reporte_precios.txt_estado_form.Text = 1 Then
                Form_reporte_precios.txt_cod_list.Text = suc.text
                Form_reporte_precios.lbl_lista.Text = suc.text2
                Form_reporte_precios.txt_cod_prov.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 4 Then
                Form_articulos.txt_list.Text = suc.text
                Form_articulos.lbl_list.Text = suc.text2
                Form_articulos.txt_prov.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 3 Then
                If Form_articulos.control = "D" Then
                    Form_articulos.txt_lis_destino.Text = suc.text
                    Form_articulos.lbl_lis_destino.Text = suc.text2
                    Form_articulos.txt_codigo_iva_expotador.Focus()
                Else
                    Form_articulos.txt_lis_origen.Text = suc.text
                    Form_articulos.lbl_lis_origen.Text = suc.text2
                    Form_articulos.txt_lis_destino.Focus()
                    Form_articulos.txt_lis_destino.SelectAll()
                End If
            End If

            If Form_articulos.txt_estado_form.Text = 2 Then
                If Form_articulos.compara = True Then
                    Form_articulos.txt_origen.Text = suc.text
                    Form_articulos.lbl_origen.Text = suc.text2
                    Form_articulos.txt_destino.Focus()
                Else
                    Form_articulos.txt_destino.Text = suc.text
                    Form_articulos.lbl_destino.Text = suc.text2

                    If Form_articulos.txt_rango_desde.Visible = True Then
                        Form_articulos.txt_rango_desde.Focus()
                    Else
                        Form_articulos.txt_porcentaje.Focus()
                    End If
                End If

            End If

            Me.Dispose()

        End If

    End Sub

    Private Sub busc_localidad_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub

    Private Sub txt_sucursal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_sucursal.KeyDown
        If e.KeyCode = Keys.Return Then

            suc.instruccion = "select *from lista_01 where nombre like '" & Me.txt_sucursal.Text & "%'"
            suc.tabla = "lista_01"
            suc.cabecera_nombre = "LISTA"
            suc.formulario = Me
            suc.buscar()
            Me.DataGridView1.Focus()

        End If
    End Sub

End Class
