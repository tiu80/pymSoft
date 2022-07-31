Public Class provincia

    Dim pro As New pymsoft.prov_vend_list_bco
    Dim par As New pymsoft.parametro

    Private Sub provincia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro.adapter = "select *from prov_01"
        pro.tabla = "prov_01"
        pro.formulario = Me
        pro.cabecera_nombre = "PROVINCIA"
        pro.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        pro.codigo = "id_prov"
        pro.nombre = "nombre"
        pro.instruccion = "select * from prov_01 where id_prov like '" & Me.txt_codigo.Text & "'"
        pro.verifica_codigo()
        pro.instruccion = "INSERT INTO prov_01(id_prov,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        pro.agregar()
        Me.txt_codigo.Focus()
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            pro.instruccion = "select *from prov_01"
            pro.instruccion1 = "select * from cli_01 where id_prov = '" & Trim(Me.DataGridView1.SelectedCells(0).Value) & "'"
            pro.tabla1 = "cli_01"
            pro.instruccion = "DELETE prov_01 WHERE id_prov= '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            pro.borrar()
        Catch ex As Exception

        End Try
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

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        par.instruccion = "update cli_01 set provincia= '" & Me.txt_nombre.Text & "',id_prov = '" & Me.txt_codigo.Text & "' where id_prov ='" & Me.cod_interno.Text & "'"
        par.abm()
        pro.instruccion = "update prov_01 set id_prov= '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_prov ='" & Me.cod_interno.Text & "'"
        pro.actualizar()

        Me.txt_codigo.Text = ""
        Me.txt_nombre.Text = ""

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = True
        Me.cmd_eliminar.BackColor = Color.Black
        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\provincia.html")
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