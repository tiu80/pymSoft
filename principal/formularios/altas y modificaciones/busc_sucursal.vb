Public Class busc_sucursal

    Dim suc As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        suc.instruccion = "select *from sucursal_01 where nombre like '" & Me.txt_sucursal.Text & "%'"
        suc.tabla = "sucursal_01"
        suc.cabecera_nombre = "SUCURSAL"
        suc.formulario = Me
        suc.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            suc.instruccion = "select *from sucursal_01 where id_suc like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            suc.codigo = "id_suc"
            suc.nombre = "nombre"
            suc.cargar()

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.txt_sucursal.Text = suc.text
                Form_cliente.lbl_sucursal.Text = suc.text2
                Form_cliente.cmb_rubro.Focus()
            End If

            If Form_articulos.txt_estado_form.Text = 1 Then
                Form_articulos.txt_lista.Text = suc.text
                Form_articulos.lbl_lista.Text = suc.text2
                Form_articulos.txt_utilidad.Focus()
            End If

            Me.Dispose()

        End If

    End Sub

    Private Sub busc_localidad_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub

    Private Sub txt_sucursal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_sucursal.KeyDown
        If e.KeyCode = Keys.Return Then

            suc.instruccion = "select *from sucursal_01 where nombre like '" & Me.txt_sucursal.Text & "%'"
            suc.tabla = "sucursal_01"
            suc.cabecera_nombre = "SUCURSAL"
            suc.formulario = Me
            suc.buscar()
            Me.DataGridView1.Focus()

        End If
    End Sub
End Class
