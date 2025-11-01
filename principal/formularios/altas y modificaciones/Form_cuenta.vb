Public Class Form_cuenta
   
    Dim cta As New pymsoft.prov_vend_list_bco

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cta.adapter = "select *from cta_01"
        cta.tabla = "cta_01"
        cta.formulario = Me
        cta.cabecera_nombre = "CUENTA"
        cta.mostrar()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        cta.codigo = "id_cta"
        cta.nombre = "nombre"
        cta.instruccion = "select * from cta_01 where id_cta like '" & Me.txt_codigo.Text & "'"
        cta.verifica_codigo()
        cta.instruccion = "INSERT INTO cta_01(id_cta,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        cta.agregar()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            cta.instruccion = "DELETE cta_01 WHERE id_cta = '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            cta.borrar()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click
        cta.instruccion = "update cta_01 set id_cta = '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_cta ='" & Me.cod_interno.Text & "'"
        cta.actualizar()
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