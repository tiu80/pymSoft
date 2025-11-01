Public Class busc_zona

    Dim lis As New pymsoft.prov_vend_list_bco

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click
        lis.instruccion = "select id_zona,zona from zona_01 where zona like '" & Me.txt_busqueda.Text & "%'"
        lis.tabla = "zona_01"
        lis.cabecera_nombre = "ZONA"
        lis.formulario = Me
        lis.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()

    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyDown

        If e.KeyCode = Keys.Return Then
            lis.instruccion = "select id_zona,zona from zona_01 where zona like '" & Me.txt_busqueda.Text & "%'"
            lis.tabla = "zona_01"
            lis.cabecera_nombre = "ZONA"
            lis.formulario = Me
            lis.buscar()
            Me.DataGridView1.Focus()
        End If

    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            lis.instruccion = "select id_zona,zona from zona_01 where id_zona like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            lis.codigo = "id_zona"
            lis.nombre = "zona"
            lis.cargar()

            If Form_cliente.txt_estado_form.Text = 1 Then
                Form_cliente.txt_zona.Text = lis.text
                Form_cliente.lbl_zona.Text = lis.text2
                Form_cliente.txt_telefono.Focus()
            End If

            Me.Dispose()

        End If

    End Sub

End Class