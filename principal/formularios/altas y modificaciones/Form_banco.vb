Public Class Form_banco

    Dim bco As New pymsoft.prov_vend_list_bco

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bco.adapter = "select *from bco_01"
        bco.tabla = "bco_01"
        bco.formulario = Me
        bco.cabecera_nombre = "BANCO"
        bco.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        bco.codigo = "id_bco"
        bco.nombre = "nombre"
        bco.instruccion = "select * from bco_01 where id_bco = '" & Me.txt_codigo.Text & "' or nombre = '" & Me.txt_nombre.Text & "'"
        bco.verifica_codigo()
        bco.instruccion = "INSERT INTO bco_01(id_bco,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        bco.agregar()
        Me.txt_codigo.Focus()
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            bco.instruccion1 = "select *from cheque_01 where cod_banco = '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            bco.tabla1 = "cheque_01"
            bco.instruccion = "DELETE bco_01 WHERE id_bco= '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            bco.borrar()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click
        bco.instruccion = "update bco_01 set id_bco= '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_bco ='" & Me.cod_interno.Text & "'"
        bco.actualizar()
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

                Me.txt_codigo.Enabled = False

                Me.txt_nombre.Focus()
                Me.txt_nombre.SelectAll()

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_nombre.Focus()
            Me.txt_nombre.SelectAll()
        End If
    End Sub

    Private Sub txt_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nombre.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmd_aceptar.Enabled = True Then Me.cmd_aceptar.Focus()
            If Me.cmd_aceptar.Enabled = False Then Me.cmd_modificar.Focus()
        End If
    End Sub
End Class