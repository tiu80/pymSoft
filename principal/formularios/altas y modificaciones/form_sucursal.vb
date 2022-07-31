Public Class form_sucursal

    Dim suc As New pymsoft.prov_vend_list_bco

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        suc.adapter = "select *from sucursal_01"
        suc.tabla = "sucursal_01"
        suc.formulario = Me
        suc.cabecera_nombre = "SUCURSAL"
        suc.mostrar()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        suc.codigo = "id_suc"
        suc.nombre = "nombre"
        suc.instruccion = "select * from sucursal_01 where id_suc like '" & Me.txt_codigo.Text & "'"
        suc.verifica_codigo()
        suc.instruccion = "INSERT INTO sucursal_01(id_suc,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        suc.agregar()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            suc.instruccion = "select *from sucursal_01"
            suc.instruccion = "DELETE sucursal_01 WHERE id_suc= '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            suc.borrar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click
        suc.instruccion = "update sucursal_01 set id_suc= '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_suc ='" & Me.cod_interno.Text & "'"
        suc.actualizar()
        Me.cmd_aceptar.Enabled = True
        Me.cmd_eliminar.Enabled = True
        Me.cmd_modificar.Enabled = False
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then
            Try

                Me.txt_codigo.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.txt_nombre.Text = Me.DataGridView1.SelectedCells(1).Value
                Me.cod_interno.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.cmd_modificar.Enabled = True
                Me.cmd_aceptar.Enabled = False
                Me.cmd_eliminar.Enabled = False

            Catch ex As Exception

            End Try

        End If
    End Sub
End Class