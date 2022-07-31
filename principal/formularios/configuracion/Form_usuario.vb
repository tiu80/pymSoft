Public Class Form_usuario

    Dim usu As New pymsoft.usuario

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        usu.adapter = "select *from usuario_01"
        usu.tabla = "usuario_01"
        usu.formulario = Me
        usu.cabecera_nombre = "NOMBRE"
        usu.cabecera_nombre1 = "CONTRASEÑA"
        usu.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        usu.codigo = "id_usu"
        usu.nombre = "nombre"
        usu.nombre1 = "contraseña"
        usu.instruccion = "select *from usuario_01 where id_usu = '" & RTrim(Me.txt_codigo.Text) & "' or nombre = '" & RTrim(Me.txt_nombre.Text) & "'"
        usu.verifica_codigo()
        usu.instruccion = "INSERT INTO usuario_01(id_usu,nombre,contraseña) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "','" + Me.txt_contraseña.Text + "')"
        usu.agregar()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Dim a As Short

        Try
            If Me.DataGridView1.SelectedCells(0).Value <> "1" Then

                usu.instruccion = "select usuario from menu_usu where usuario like '" & Me.DataGridView1.SelectedCells(1).Value & "'"
                usu.verifica_asignacion()

                If usu.validar = True Then
                    MessageBox.Show("El usuario Tiene un Menu Asociado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                a = MsgBox("Esta seguro que desea eliminar", MsgBoxStyle.YesNo, "PymSoft")

                If a = 6 Then

                    Me.txt_borra_usu.Text = Me.DataGridView1.SelectedCells(1).Value

                    usu.instruccion = "DELETE usuario_01 WHERE id_usu = '" & Me.DataGridView1.SelectedCells(0).Value & "'"
                    usu.borrar()
                    usu.instruccion = "DELETE menu_usu WHERE usuario = '" & RTrim(Me.txt_borra_usu.Text) & "'"
                    usu.borrar()

                End If

            Else
                MessageBox.Show("No se puede borrar Administrador", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch es As Exception

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        usu.instruccion = "update usuario_01 set id_usu = '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' , contraseña = '" & Me.txt_contraseña.Text & "' where id_usu ='" & Me.cod_interno.Text & "'"
        usu.actualizar()

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = True
        Me.cmd_eliminar.BackColor = Color.Black
        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray

        Me.txt_codigo.Enabled = True
        Me.txt_nombre.Enabled = True
        Me.txt_codigo.Focus()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then
            Try

                If Me.DataGridView1.SelectedCells(0).Value = "1" Then
                    Me.txt_codigo.Enabled = False
                    Me.txt_nombre.Enabled = False
                Else
                    Me.txt_codigo.Enabled = True
                    Me.txt_nombre.Enabled = True
                End If

                Me.txt_codigo.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.txt_nombre.Text = Me.DataGridView1.SelectedCells(1).Value
                Me.txt_contraseña.Text = Me.DataGridView1.SelectedCells(2).Value
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

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_nombre.Focus()
        End If
    End Sub

End Class