Public Class busc_bancos

    Dim ban As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        ban.instruccion = "select *from bco_01 where nombre like '" & Me.txt_bancos.Text & "%'"
        ban.tabla = "bco_01"
        ban.cabecera_nombre = "BANCO"
        ban.formulario = Me
        ban.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub txt_localidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bancos.KeyDown

        If e.KeyCode = Keys.Return Then

            ban.instruccion = "select *from bco_01 where nombre like '" & Me.txt_bancos.Text & "%'"
            ban.tabla = "bco_01"
            ban.cabecera_nombre = "BANCOS"
            ban.formulario = Me
            ban.buscar()
            Me.DataGridView1.Focus()

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            ban.instruccion = "select *from bco_01 where id_bco like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            ban.codigo = "id_bco"
            ban.nombre = "nombre"
            ban.cargar()

            If Form_tipo_pago.txt_estado_form.Text = 1 Then

                Form_tipo_pago.txt_banco.Text = ban.text
                Form_tipo_pago.lbl_banco.Text = ban.text2
                Form_tipo_pago.dt_fec_acred.Focus()

            End If

            Me.Dispose()

        End If

    End Sub

End Class