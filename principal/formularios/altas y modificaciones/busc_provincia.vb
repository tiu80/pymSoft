Public Class busc_provincia

    Dim pro As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        pro.adapter = "select *from prov_01 where nombre like '" & Me.txt_provincia.Text & "%'"
        pro.tabla = "prov_01"
        pro.cabecera_nombre = "PROVINCIA"
        pro.formulario = Me
        pro.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then
            pro.instruccion = "select *from prov_01 where id_prov like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            pro.codigo = "id_prov"
            pro.nombre = "nombre"
            pro.cargar()
            Form_cliente.txt_provincia.Text = pro.text
            Form_cliente.lbl_provincia.Text = pro.text2
            Form_cliente.txt_zona.Focus()
            Me.Dispose()
        End If
    End Sub

    Private Sub busc_provincia_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub

    Private Sub txt_provincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_provincia.KeyDown
        If e.KeyCode = Keys.Return Then
            pro.instruccion = "select *from prov_01 where nombre like '" & Me.txt_provincia.Text & "%'"
            pro.tabla = "prov_01"
            pro.cabecera_nombre = "PROVINCIA"
            pro.formulario = Me
            pro.buscar()
            Me.DataGridView1.Focus()
        End If
    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click
        Me.Close()
    End Sub
End Class