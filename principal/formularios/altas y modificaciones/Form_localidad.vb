Public Class Form_localidad

    Dim loc As New pymsoft.prov_vend_list_bco
    Dim par As New pymsoft.parametro

    Private Sub Form_localidad_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
    End Sub

    Private Sub Form_localidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loc.adapter = "select *from localidad"
        loc.tabla = "localidad"
        loc.formulario = Me
        loc.cabecera_nombre = "LOCALIDAD"
        loc.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        loc.codigo = "id_loc"
        loc.nombre = "nom_localidad"
        loc.instruccion = "select * from localidad where id_loc = '" & Me.txt_codigo.Text & "' or nom_localidad = '" & Me.txt_nombre.Text & "'"
        loc.verifica_codigo()
        loc.instruccion = "INSERT INTO localidad(id_loc,nom_localidad) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        loc.agregar()
        Me.txt_codigo.Focus()
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        par.instruccion = "update cli_01 set num_loc= '" & Me.txt_codigo.Text & "', localidad= '" & Me.txt_nombre.Text & "' where num_loc ='" & Me.cod_interno.Text & "'"
        par.abm()
        loc.instruccion = "update localidad set id_loc= '" & Me.txt_codigo.Text & "', nom_localidad= '" & Me.txt_nombre.Text & "' where id_loc ='" & Me.cod_interno.Text & "'"
        loc.actualizar()

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = True
        Me.cmd_eliminar.BackColor = Color.Black
        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try
            loc.instruccion = "select *from localidad"
            loc.instruccion1 = "select * from cli_01 where num_loc = '" & Trim(Me.DataGridView1.SelectedCells(0).Value) & "'"
            loc.tabla1 = "cli_01"
            loc.instruccion = "DELETE localidad WHERE id_loc= '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            loc.borrar()
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