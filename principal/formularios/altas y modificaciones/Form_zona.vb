Public Class Form_zona

    Dim list As New pymsoft.prov_vend_list_bco
    Dim par As New pymsoft.parametro

    Private Sub Form_listas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        list.adapter = "select id_zona,zona from zona_01 order by id_zona ASC"
        list.tabla = "zona_01"
        list.formulario = Me
        list.cabecera_nombre = "ZONA"
        list.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        list.codigo = "id_zona"
        list.nombre = "zona"
        list.instruccion = "select id_zona,zona from zona_01 where id_zona = '" & Me.txt_codigo.Text & "' OR zona = '" & Me.txt_nombre.Text & "'"
        list.verifica_codigo()
        list.instruccion = "INSERT INTO zona_01(id_zona,zona) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        list.agregar()
        Me.txt_codigo.Focus()
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        par.instruccion = "update cli_01 set id_zona = '" & Me.txt_codigo.Text & "', zona = '" & Me.txt_nombre.Text & "' where id_zona ='" & Me.cod_interno.Text & "'"
        par.abm()
        list.instruccion = "update zona_01 set id_zona= '" & Me.txt_codigo.Text & "', zona= '" & Me.txt_nombre.Text & "' where id_zona ='" & Me.cod_interno.Text & "'"
        list.actualizar()

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

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            list.instruccion = "select *from zona_01"
            list.instruccion1 = "select * from cli_01 where id_zona = '" & Trim(Me.DataGridView1.SelectedCells(0).Value) & "'"
            list.tabla1 = "cli_01"
            list.instruccion = "DELETE zona_01 WHERE id_zona = '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            list.borrar()
        Catch ex As Exception

        End Try
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