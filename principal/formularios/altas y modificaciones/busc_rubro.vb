Public Class busc_rubro

    Dim rub As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        rub.adapter = "select id_rubro,nombre from rub_01 where nombre like '" & Me.txt_rubro.Text & "%'"
        rub.tabla = "rub_01"
        rub.cabecera_nombre = "RUBRO"
        rub.formulario = Me
        rub.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            rub.instruccion = "select id_rubro,nombre from rub_01 where id_rubro like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            rub.codigo = "id_rubro"
            rub.nombre = "nombre"
            rub.cargar()

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.cmb_rubro.Text = rub.text
                Form_cliente.cmb_rubro.Text = rub.text2
                Form_cliente.txt_observacion.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 1 Then
                Form_articulos.txt_rubro.Text = rub.text
                Form_articulos.lbl_rubro.Text = rub.text2
                Form_articulos.txt_proveedor.Focus()
            End If

            If Form_reporte_precios.txt_estado_form.Text = 1 Or Form_reporte_precios.txt_estado_form.Text = 2 Then
                If Form_reporte_precios.chk_inluye_rubro.Checked = False Then
                    Form_reporte_precios.txt_cod_rub.Text = rub.text
                    Form_reporte_precios.lbl_rubro.Text = rub.text2
                    Form_reporte_precios.dt_fec_desde.Focus()
                Else
                    Form_reporte_precios.DataGridView1.Rows.Add()
                    Form_reporte_precios.DataGridView1.Rows(Form_reporte_precios.DataGridView1.Rows.Count - 1).Cells(0).Value = rub.text
                    Form_reporte_precios.DataGridView1.Rows(Form_reporte_precios.DataGridView1.Rows.Count - 1).Cells(1).Value = rub.text2

                    Form_reporte_precios.txt_cod_rub.Text = ""
                    Form_reporte_precios.txt_cod_rub.Focus()
                    Form_reporte_precios.txt_cod_rub.SelectAll()
                End If
            End If

            If Form_stock.txt_estado_form.Text = 1 Then
                Form_stock.txt_rubro.Text = rub.text
                Form_stock.lbl_rubro.Text = rub.text2
                Form_stock.cmb_ordena.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 4 Then
                Form_articulos.txt_rub.Text = rub.text
                Form_articulos.lbl_rub.Text = rub.text2
                Form_articulos.cmd_buscar.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 2 Then
                If Form_articulos.compara1 = True Then
                    Form_articulos.txt_rango_desde.Text = rub.text
                    Form_articulos.lbl_rango_desde.Text = rub.text2
                    Form_articulos.txt_rango_hasta.Focus()
                Else
                    Form_articulos.txt_rango_hasta.Text = rub.text
                    Form_articulos.lbl_rango_hasta.Text = rub.text2
                    Form_articulos.txt_porcentaje.Focus()
                End If
            End If

            Me.Dispose()

        End If
    End Sub

    Private Sub txt_provincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rubro.KeyDown
        If e.KeyCode = Keys.Return Then
            rub.instruccion = "select id_rubro,nombre from rub_01 where nombre like '" & Me.txt_rubro.Text & "%'"
            rub.tabla = "rub_01"
            rub.cabecera_nombre = "RUBRO"
            rub.formulario = Me
            rub.buscar()
            Me.DataGridView1.Focus()
        End If
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click
        Me.Close()
    End Sub

End Class