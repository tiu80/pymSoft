Public Class busc_localidad

    Dim loc As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        loc.instruccion = "select *from localidad where nom_localidad like '" & Me.txt_localidad.Text & "%'"
        loc.tabla = "localidad"
        loc.cabecera_nombre = "LOCALIDAD"
        loc.formulario = Me
        loc.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub txt_localidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_localidad.KeyDown

        If e.KeyCode = Keys.Return Then

            loc.instruccion = "select *from localidad where nom_localidad like '" & Me.txt_localidad.Text & "%'"
            loc.tabla = "localidad"
            loc.cabecera_nombre = "LOCALIDAD"
            loc.formulario = Me
            loc.buscar()
            Me.DataGridView1.Focus()

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            loc.instruccion = "select *from localidad where id_loc like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            loc.codigo = "id_loc"
            loc.nombre = "nom_localidad"
            loc.cargar()

            If Form_cliente.txt_estado_form.Text = 1 Then

                Form_cliente.txt_localidad.Text = loc.text
                Form_cliente.lbl_localidad.Text = loc.text2
                Form_cliente.txt_provincia.Focus()

            End If

            If Form_empresa.txt_estado_form.Text = 1 Then

                Form_empresa.txt_localidad.Text = loc.text
                Form_empresa.lbl_localidad.Text = loc.text2
                Form_empresa.cmb_iva.Focus()

            End If

            Me.Dispose()

        End If

    End Sub

    Private Sub busc_localidad_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub
End Class