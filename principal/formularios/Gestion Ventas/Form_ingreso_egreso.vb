Imports System.Data
Imports System.Data.SqlClient

Public Class Form_ingreso_egreso

    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim tb As DataTable
    Dim conex As SqlConnection

    Private Sub Form_ingreso_egreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_tipo_movimiento.Text = Me.cmb_tipo_movimiento.Items(0)

        llena_grilla()
        llena_talonario()

        If Form_login.cmb_usuario.Text <> "Administrador" Then

            Me.cmd_eliminar.Enabled = False
            Me.cmd_eliminar.BackColor = Color.LightGray
            Me.dt_fecha.Enabled = False

        End If

    End Sub

    Private Sub llena_talonario()

        conex = conecta()

        tb = New DataTable
        tb.Clear()

        Me.cmb_talonario.Items.Clear()

        Dim i As Integer

        Try

            comando = New SqlDataAdapter("select talon from numerador order by talon", conex)
            comando.Fill(tb)
            comando.Dispose()

            For i = 0 To tb.Rows.Count - 1
                Me.cmb_talonario.Items.Add(tb.Rows(i).Item(0))
            Next

            Me.cmb_talonario.Text = Me.cmb_talonario.Items(0)

            llena_pto_vta(Me.cmb_talonario.Text)

        Catch ex As Exception

        Finally

            tb.Dispose()

        End Try

    End Sub

    Private Sub llena_pto_vta(ByVal talonario As Integer)

        conex = conecta()

        tb = New DataTable
        tb.Clear()

        Try

            comando = New SqlDataAdapter("select punto_venta from numerador where talon = '" & talonario & "'", conex)
            comando.Fill(tb)
            comando.Dispose()

            Me.txt_pto_vta.Text = tb.Rows(0).Item(0)

        Catch ex As Exception

        Finally

            tb.Dispose()

        End Try

    End Sub

    Private Sub llena_grilla()

        conex = New SqlConnection
        conex = conecta()

        tb = New DataTable
        tb.Clear()

        Try

            comando = New SqlDataAdapter("select top 100 * from IngresoEgreso order by fecha,id", conex)
            comando.Fill(tb)
            comando.Dispose()

            Me.DataGridView1.DataSource = tb

            Me.DataGridView1.Columns(0).Width = 60
            Me.DataGridView1.Columns(1).Width = 120
            Me.DataGridView1.Columns(2).Width = 120
            Me.DataGridView1.Columns(3).Width = 120
            Me.DataGridView1.Columns(4).Width = 460
            Me.DataGridView1.Columns(5).Width = 40
            Me.DataGridView1.Columns(6).Width = 40

        Catch ex As Exception

        Finally

            tb.Dispose()

        End Try

    End Sub

    Private Sub cmd_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_agregar.Click

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        Try

            If Me.txt_importe.Text <= "0" Then
                MessageBox.Show("Debe completar el campo importe!!", "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.txt_importe.Focus()
                Me.txt_importe.SelectAll()
                Exit Sub
            End If

            coman = New SqlCommand("Insert Into IngresoEgreso(tipo,fecha,importe,comentario,talonario,ptovta) values ('" & Trim(Me.cmb_tipo_movimiento.Text) & "','" & Me.dt_fecha.Text & "','" & Me.txt_importe.Text & "','" & Trim(Me.txt_comentario.Text) & "','" & Trim(Me.cmb_talonario.Text) & "','" & Trim(Me.txt_pto_vta.Text) & "')", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally

            If conex.State = ConnectionState.Open Then conex.Close()
            llena_grilla()

        End Try

    End Sub

    Private Sub txt_importe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_importe.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_talonario.Focus()
        End If
    End Sub

    Private Sub txt_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        Try

            Dim x As String = MessageBox.Show("Esta Seguro que desea eliminar este registo?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If x = 6 Then

                coman = New SqlCommand("delete from IngresoEgreso where id = '" & Trim(Me.DataGridView1.SelectedCells.Item(0).Value) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally

            If conex.State = ConnectionState.Open Then conex.Close()
            llena_grilla()

        End Try

    End Sub

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click

        conex = New SqlConnection
        conex = conecta()

        tb = New DataTable
        tb.Clear()

        Try

            comando = New SqlDataAdapter("select * from IngresoEgreso where fecha >= '" & Me.dt_desde.Text & "' and fecha <= '" & Me.dt_hasta.Text & "'", conex)
            comando.Fill(tb)
            comando.Dispose()

            Me.DataGridView1.DataSource = tb

            Me.DataGridView1.Columns(0).Width = 90
            Me.DataGridView1.Columns(1).Width = 120
            Me.DataGridView1.Columns(2).Width = 120
            Me.DataGridView1.Columns(3).Width = 120
            Me.DataGridView1.Columns(4).Width = 510

        Catch ex As Exception

        Finally

            tb.Dispose()

        End Try

    End Sub

    Private Sub cmb_tipo_movimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_tipo_movimiento.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_importe.Focus()
            Me.txt_importe.SelectAll()
        End If
    End Sub

    Private Sub txt_comentario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_comentario.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_agregar.Focus()
        End If
    End Sub

    Private Sub cmb_talonario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_talonario.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_comentario.Focus()
            Me.txt_comentario.SelectAll()
        End If
    End Sub

    Private Sub cmb_talonario_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_talonario.SelectionChangeCommitted
        llena_pto_vta(Me.cmb_talonario.Text)
    End Sub

    Private Sub dt_fecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fecha.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_tipo_movimiento.Focus()
        End If
    End Sub

End Class