Public Class busc_cuenta

    Dim cta As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        cta.instruccion = "select cuenta,nombre from plan_cuenta where nombre like '" & Me.txt_cta.Text & "%'"
        cta.tabla = "plan_cuenta"
        cta.cabecera_nombre = "CUENTA"
        cta.formulario = Me
        cta.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            cta.instruccion = "select cuenta,nombre from plan_cuenta where cuenta like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            cta.codigo = "cuenta"
            cta.nombre = "nombre"
            cta.cargar()

            If Form_compras.txt_estado_form.Text = 1 Then

                Form_compras.txt_cod_cta.Text = cta.text
                Form_compras.lbl_cuenta.Text = cta.text2
                Form_compras.txt_cod_iva.Focus()

            End If

            If Form_alta_planilla.txt_estado_form.Text = 1 Then

                Form_alta_planilla.txt_cuenta.Text = cta.text
                Form_alta_planilla.lbl_nom_cta.Text = cta.text2
                Form_alta_planilla.dt_fec_ini.Focus()

            End If

            If Form_alta_movimiento.txt_estado_form.Text = 1 Then

                Form_alta_movimiento.txt_cuenta.Text = cta.text
                Form_alta_movimiento.lbl_nom_cta.Text = cta.text2
                Form_alta_movimiento.dt_fec_ini.Focus()

            End If

            If Form_muestra_planilla.txt_estado_form.Text = 1 Then

                Form_muestra_planilla.txt_inputacion.Text = cta.text
                Form_muestra_planilla.lbl_imputacion.Text = cta.text2
                Form_muestra_planilla.dt_fec_acredit.Focus()

            End If

            If Form_mayor_planilla.txt_estado_form.Text = 1 Then

                Form_mayor_planilla.txt_cuenta.Text = cta.text
                Form_mayor_planilla.lbl_cuenta.Text = cta.text2
                Form_mayor_planilla.cmd_aceptar.Focus()

            End If

            Me.Dispose()

        End If

    End Sub

    Private Sub txt_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cta.KeyDown

        If e.KeyCode = Keys.Return Then

            cta.instruccion = "select cuenta,nombre from plan_cuenta where nombre like '" & Me.txt_cta.Text & "%'"
            cta.tabla = "plan_cuenta"
            cta.cabecera_nombre = "CUENTA"
            cta.formulario = Me
            cta.buscar()
            Me.DataGridView1.Focus()

        End If

    End Sub

End Class