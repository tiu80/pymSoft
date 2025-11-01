Imports System.Data
Imports System.Data.SqlClient

Public Class Form_asigna

    Dim asigna As New pymsoft.parametro

    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim midataset As New DataSet

    Private Sub Form_asigna_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Dispose()
        Form_muestra_asignacion.Dispose()
        midataset.Dispose()
    End Sub

    Private Sub Form_asigna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            Form_muestra_asignacion.Show()
        End If

    End Sub

    Private Sub Form_asigna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_estado.Text = Me.cmb_estado.Items(0)

        conex = conecta()

        comando = New SqlDataAdapter("select nombre from usuario_01 where nombre <> 'Administrador'", conex)
        comando.Fill(midataset, "usuario_01")

        Me.list_usu.DataSource = midataset.Tables("usuario_01")
        Me.list_usu.DisplayMember = "nombre"

        comando = New SqlDataAdapter("select distinct id_menu from sub_menu_01 where id_menu <> 1 ", conex)
        comando.Fill(midataset, "sub_menu_01")

        Me.list_menu.DataSource = midataset.Tables("sub_menu_01")
        Me.list_menu.DisplayMember = "id_menu"

        comando = New SqlDataAdapter("select distinct id_parametro from parametro_01", conex)
        comando.Fill(midataset, "parametro_01")

        Me.List_parametro.DataSource = midataset.Tables("parametro_01")
        Me.List_parametro.DisplayMember = "id_parametro"

        If Me.list_menu.Items.Count = 0 Or Me.list_usu.Items.Count = 0 Then
            Me.cmd_asinga.Enabled = False
            Me.cmd_actualiza.Enabled = False
        End If

    End Sub

    Private Sub cmd_asinga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_asinga.Click

        asigna.instruccion = "select usuario from menu_usu where usuario like '" & Me.list_usu.Text & "'"
        asigna.verifica_config_duplicado()

        If asigna.verifica = True Then

            asigna.instruccion = "INSERT INTO menu_usu(usuario,menu,parametro,estado,integridad) VALUES('" & Me.list_usu.Text & "' , '" & Me.list_menu.Text & "','" & Me.List_parametro.Text & "','" + Me.cmb_estado.Text + "','1')"
            asigna.abm()
            MessageBox.Show("Configuracion Guardada!!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Dispose()

        End If

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        asigna.instruccion = "update menu_usu set usuario = '" & Me.list_usu.Text & "', menu= '" & Me.list_menu.Text & "' , parametro = '" & Me.List_parametro.Text & "',estado = '" & Me.cmb_estado.Text & "' where usuario ='" & Me.list_usu.Text & "'"
        asigna.abm()

        MessageBox.Show("Registro Actualizado!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Me.Dispose()

    End Sub

    Private Sub list_usu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles list_usu.KeyDown

        If e.KeyCode = Keys.F1 Then
            Form_muestra_asignacion.Show()
        End If

    End Sub

    Private Sub list_menu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles list_menu.KeyDown

        If e.KeyCode = Keys.F1 Then
            Form_muestra_asignacion.Show()
        End If

    End Sub

    Private Sub List_parametro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles List_parametro.KeyDown

        If e.KeyCode = Keys.F1 Then
            Form_muestra_asignacion.Show()
        End If

    End Sub

End Class