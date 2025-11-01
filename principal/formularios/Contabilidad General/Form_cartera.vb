Public Class Form_cartera

    Dim cart As New pymsoft.prov_vend_list_bco

    Private Sub Form_cartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cart.adapter = "select *from cartera"
        cart.tabla = "cartera"
        cart.formulario = Me
        cart.cabecera_nombre = "CARTERA"
        cart.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        cart.codigo = "id_cartera"
        cart.nombre = "cartera"
        cart.instruccion = "select * from cartera where id_cartera like '" & Me.txt_codigo.Text & "'"
        cart.verifica_codigo()
        cart.instruccion = "INSERT INTO cartera(id_cartera,cartera) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        cart.agregar()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Try

            cart.instruccion = "DELETE cartera WHERE id_cartera = '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            cart.borrar()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        cart.instruccion = "update cartera set id_cartera = '" & Me.txt_codigo.Text & "', cartera = '" & Me.txt_nombre.Text & "' where id_cartera ='" & Me.cod_interno.Text & "'"
        cart.actualizar()

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = True
        Me.cmd_eliminar.BackColor = Color.Black
        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            Try

                Me.txt_codigo.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.txt_nombre.Text = Me.DataGridView1.SelectedCells(1).Value
                Me.cod_interno.Text = Me.DataGridView1.SelectedCells(0).Value

                Me.cmd_aceptar.Enabled = False
                Me.cmd_aceptar.BackColor = Color.LightGray
                Me.cmd_eliminar.Enabled = False
                Me.cmd_eliminar.BackColor = Color.LightGray
                Me.cmd_modificar.Enabled = True
                Me.cmd_modificar.BackColor = Color.Black

            Catch ex As Exception

            End Try

        End If

    End Sub
End Class