Public Class Form_rubro

    Dim ru As New pymsoft.prov_vend_list_bco
    Dim par As New pymsoft.parametro

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ru.adapter = "select id_rubro,nombre from rub_01"
        ru.tabla = "rub_01"
        ru.formulario = Me
        ru.cabecera_nombre = "RUBRO"
        ru.mostrar()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        ru.codigo = "id_rubro"
        ru.nombre = "nombre"
        ru.instruccion = "select * from rub_01 where id_rubro like '" & Me.txt_codigo.Text & "'"
        ru.verifica_codigo()
        ru.instruccion = "INSERT INTO rub_01(id_rubro,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        ru.agregar()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            ru.instruccion = "select *from rub_01"
            ru.instruccion = "DELETE rub_01 WHERE id_rubro= '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            ru.borrar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        par.instruccion = "update art_01 set id_rubro= '" & Me.txt_codigo.Text & "', rubro= '" & Me.txt_nombre.Text & "' where id_rubro ='" & Me.cod_interno.Text & "'"
        par.abm()
        ru.instruccion = "update rub_01 set id_rubro= '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_rubro ='" & Me.cod_interno.Text & "'"
        ru.actualizar()

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