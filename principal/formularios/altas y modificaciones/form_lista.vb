Imports System.Data
Imports System.Data.SqlClient

Public Class form_lista

    Dim suc As New pymsoft.prov_vend_list_bco
    Dim par As New pymsoft.parametro
    Dim tabla As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As SqlConnection
    Public sale As Boolean = True

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        suc.adapter = "select *from lista_01"
        suc.tabla = "lista_01"
        suc.formulario = Me
        suc.cabecera_nombre = "LISTA"
        suc.mostrar()

        Me.cmd_modificar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        suc.codigo = "id_lis"
        suc.nombre = "nombre"
        suc.instruccion = "select * from lista_01 where id_lis like '" & Me.txt_codigo.Text & "'"
        suc.verifica_codigo()
        suc.instruccion = "INSERT INTO lista_01(id_lis,nombre) VALUES('" + Me.txt_codigo.Text + "' , '" + Me.txt_nombre.Text + "')"
        suc.agregar()
        Me.txt_codigo.Focus()
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Try

            Dim num As Integer

            tabla.Clear()

            conex = conecta()
            comando = New SqlDataAdapter("select *from parametro_01 where estado = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and descripcion = '" & RTrim(Form_login.cmb_usuario.Text) & "' and cod_interno='18'", conex)
            comando.Fill(tabla)

            If tabla.Rows.Count > 0 Then
                MessageBox.Show("No se puede eliminar la lista Predeterminada", "PyMsoft", MessageBoxButtons.OK)
                Exit Sub
            End If

            num = Me.DataGridView1.SelectedCells(0).Value

            suc.instruccion1 = "SELECT * FROM FACT_CAB WHERE id_lista = '" & num & "'"
            suc.tabla1 = "fact_cab"

            suc.instruccion = "DELETE lista_01 WHERE id_lis = '" & num & "'"
            suc.borrar()

            sale = False

            suc.instruccion = "DELETE art_precio WHERE id_lista1 = '" & num & "'"
            suc.borrar()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        tabla.Clear()

        conex = conecta()
        comando = New SqlDataAdapter("select *from parametro_01 where estado = '" & Me.cod_interno.Text & "' and descripcion = '" & RTrim(Form_login.cmb_usuario.Text) & "' and cod_interno='18'", conex)
        comando.Fill(tabla)

        If tabla.Rows.Count > 0 Then
            par.instruccion = "update parametro_01 set estado= '" & Me.txt_codigo.Text & "' where cod_interno ='18' and descripcion = '" & RTrim(Form_login.cmb_usuario.Text) & "'"
            par.abm()
        End If

        par.instruccion = "update cli_01 set cod_list = '" & Me.txt_codigo.Text & "', nom_lista= '" & Me.txt_nombre.Text & "' where cod_list ='" & Me.cod_interno.Text & "'"
        par.abm()

        par.instruccion = "update art_01 set id_lista = '" & Me.txt_codigo.Text & "', lista= '" & Me.txt_nombre.Text & "' where id_lista ='" & Me.cod_interno.Text & "'"
        par.abm()

        suc.instruccion = "update lista_01 set id_lis = '" & Me.txt_codigo.Text & "', nombre= '" & Me.txt_nombre.Text & "' where id_lis ='" & Me.cod_interno.Text & "'"
        suc.actualizar()

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

                Me.txt_codigo.Focus()
                Me.txt_codigo.SelectAll()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\Lista.html")
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