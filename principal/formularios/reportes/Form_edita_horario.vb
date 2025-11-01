Imports System.Data
Imports System.Data.SqlClient

Public Class Form_edita_horario

    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim hora3 As DateTime
    Dim hora4 As DateTime

    Private Sub dt_hora_inicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dt_hora_inicio.LostFocus

        If Me.dt_hora_fin.Visible = True Then
            Dim tiempoI As TimeSpan = TimeSpan.Parse(Me.dt_hora_inicio.Text)
            Dim tiempoF As TimeSpan = TimeSpan.Parse(Me.dt_hora_fin.Text)
            Dim resta As TimeSpan = tiempoF - tiempoI
            Me.lbl_difernecia_hora.Text = resta.ToString

            'Dim totaltiempo As TimeSpan
            'Dim hora1 As DateTime = Me.dt_hora_inicio.Text
            'Dim hora2 As DateTime = Me.dt_hora_fin.Text
            'totaltiempo = hora1.Subtract(hora2)
            'Me.lbl_difernecia_hora.Text = totaltiempo.ToString
            'hora3 = hora1
            'hora4 = hora2

        End If

    End Sub

    Private Sub dt_hora_fin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_hora_fin.ValueChanged

        If Me.dt_hora_fin.Visible = True Then

            Dim tiempoI As TimeSpan = TimeSpan.Parse(Me.dt_hora_inicio.Text)
            Dim tiempoF As TimeSpan = TimeSpan.Parse(Me.dt_hora_fin.Text)
            Dim resta As TimeSpan = tiempoF - tiempoI
            Me.lbl_difernecia_hora.Text = resta.ToString

            'Dim totaltiempo As TimeSpan
            'Dim hora1 As DateTime = Me.dt_hora_inicio.Text
            'Dim hora2 As DateTime = Me.dt_hora_fin.Text
            'totaltiempo = hora2.Subtract(hora1)
            'Me.lbl_difernecia_hora.Text = totaltiempo.ToString
            'hora3 = hora1
            'hora4 = hora2

        End If

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        Form_movimiento.DataGridView1.Rows(Me.lbl_pos.Text).Cells(1).Value = Me.dt_hora_inicio.Text
        If Me.dt_hora_fin.Visible = True Then Form_movimiento.DataGridView1.Rows(Me.lbl_pos.Text).Cells(2).Value = Me.dt_hora_fin.Text
        If Me.lbl_difernecia_hora.Text <> "" Then Form_movimiento.DataGridView1.Rows(Me.lbl_pos.Text).Cells(4).Value = Me.lbl_difernecia_hora.Text

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("Update empleado_mov set horae = '" & Me.dt_hora_inicio.Value & "' unico = '" & Trim(Me.lbl_unico.Text) & "' and id = '" & RTrim(Me.lbl_cod_empleado.Text) & "' and fecha ='" & Me.lbl_fecha.Text & "'", conex)
        coman.ExecuteNonQuery()
        coman.Dispose()

        If Me.dt_hora_fin.Visible = True Then

            coman = New SqlCommand("Update empleado_mov set horas = '" & Me.dt_hora_fin.Value & "' unico = '" & Trim(Me.lbl_unico.Text) & "' and id = '" & RTrim(Me.lbl_cod_empleado.Text) & "' and fecha ='" & Me.lbl_fecha.Text & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

        End If

        If conex.State = ConnectionState.Open Then conex.Close()

        Form_movimiento.carga_codigo_empleado(Form_movimiento.txt_cod_empleado.Text)
        Form_movimiento.llena_grilla_empleado()

        Me.Close()

    End Sub
End Class