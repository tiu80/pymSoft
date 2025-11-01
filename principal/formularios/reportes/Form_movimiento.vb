Imports System.Data
Imports System.Data.SqlClient

Public Class Form_movimiento

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tb As New DataTable, tb1 As New DataTable
    Dim i, pos As Integer
    Dim hora, reshora As TimeSpan

    Private Sub txt_cod_empleado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_empleado.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_cod_empleado.Text <> "" Then

                Call carga_codigo_empleado(Me.txt_cod_empleado.Text)

                If tb.Rows.Count <> Nothing Then

                    Call llena_grilla_empleado()
                    Me.DataGridView1.Focus()

                Else

                    tb1.Clear()

                    comando = New SqlDataAdapter("select legajo,nombre from empleado order by nombre ASC", conex)
                    comando.Fill(tb1)

                    Form_busc_empleados.DataGridView1.DataSource = tb1
                    Form_busc_empleados.DataGridView1.Columns(0).Width = 100
                    Form_busc_empleados.DataGridView1.Columns(1).Width = 400
                    Form_busc_empleados.Show()

                End If

            End If

        End If
    End Sub

    Public Sub carga_codigo_empleado(ByVal cod As Integer)

        tb.Clear()

        comando = New SqlDataAdapter("select M.fecha,M.horae,M.horas,M.dia,E.nombre,M.unico from empleado_mov as M inner join empleado as E on E.legajo = M.id where M.id = '" & RTrim(cod) & "' and M.fecha >= '" & RTrim(Me.DateTimePicker1.Text) & "' and M.fecha <= '" & RTrim(Me.DateTimePicker2.Text) & "' order by M.fecha,M.horae ASC", conex)
        comando.Fill(tb)

        Dim fecha As Date = Me.DateTimePicker1.Text
        Dim dias As String
        Dim xx As String = DateDiff(DateInterval.Day, Me.DateTimePicker1.Value, Me.DateTimePicker2.Value)

        'For i = 0 To xx - 1

        'dias = (DateAdd(DateInterval.Day, i, fecha))
        dias = WeekdayName(Weekday(fecha))

        'Next

    End Sub

    Public Sub llena_grilla_empleado()

        Dim inicial As DateTime
        Dim final As DateTime
        Dim dia As String
        Dim suma As TimeSpan

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.lbl_hora.Text = 0

        If tb.Rows.Count <> Nothing Then

            Me.DataGridView1.Columns.Add("fecha", "FECHA")
            Me.DataGridView1.Columns.Add("Hora ingreso", "HORA INGRESO")
            Me.DataGridView1.Columns.Add("hora Egreso", "HORA EGRESO")
            Me.DataGridView1.Columns.Add("Dia", "DIA")
            Me.DataGridView1.Columns.Add("Horas/Mts", "HH/MM/SS")
            Me.DataGridView1.Columns.Add("Unico", "Unico")

            Me.lbl_nombre.Text = tb.Rows(0).Item(4)

            For i = 0 To tb.Rows.Count - 1

                Me.DataGridView1.Rows.Add()

                Me.DataGridView1.Rows(i).Cells(1).Value = tb.Rows(i).Item(1)
                Me.DataGridView1.Rows(i).Cells(2).Value = tb.Rows(i).Item(2)

                inicial = tb.Rows(i).Item(1)
                dia = tb.Rows(i).Item(3)

                Me.DataGridView1.Rows(i).Cells(1).Value = CDate(tb.Rows(i).Item(1)).ToLongTimeString

                If tb.Rows(i).Item(2).ToString = Nothing Then
                    final = inicial
                Else
                    final = tb.Rows(i).Item(2)
                    Me.DataGridView1.Rows(i).Cells(2).Value = CDate(tb.Rows(i).Item(2)).ToLongTimeString
                End If

                Dim fecha1 As DateTime = DateTime.Parse(inicial)
                Dim fecha2 As DateTime = DateTime.Parse(final)
                Dim diferencia As TimeSpan = fecha2.Subtract(fecha1)

                suma = suma + diferencia

                Me.lbl_hora.Text = suma.ToString

                Me.DataGridView1.Rows(i).Cells(4).Value = diferencia
                Me.DataGridView1.Rows(i).Cells(3).Value = tb.Rows(i).Item(3)
                Me.DataGridView1.Rows(i).Cells(0).Value = tb.Rows(i).Item(0)
                Me.DataGridView1.Rows(i).Cells(5).Value = tb.Rows(i).Item(5)

            Next

            Me.DataGridView1.Columns(0).Width = 140
            Me.DataGridView1.Columns(1).Width = 230
            Me.DataGridView1.Columns(2).Width = 220
            Me.DataGridView1.Columns(3).Width = 110
            Me.DataGridView1.Columns(4).Width = 170
            Me.DataGridView1.Columns(5).Visible = False

        End If

        Me.lbl_hora.Text = suma.ToString

    End Sub

    Private Sub Form_movimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If conex.State = ConnectionState.Closed Then
            conex = conecta()
            conex.Open()
        End If

        Me.txt_cod_empleado.Focus()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            Form_edita_horario.lbl_unico.Text = Me.DataGridView1.SelectedCells.Item(5).Value
            Form_edita_horario.lbl_nombre.Text = Me.lbl_nombre.Text
            Form_edita_horario.lbl_fecha.Text = Me.DataGridView1.SelectedCells.Item(0).Value

            If Me.DataGridView1.SelectedCells.Item(1).Value.ToString <> "" Then
                Form_edita_horario.dt_hora_inicio.Text = Me.DataGridView1.SelectedCells.Item(1).Value
            Else
                Form_edita_horario.dt_hora_inicio.Visible = False
            End If

            If Me.DataGridView1.SelectedCells.Item(2).Value.ToString <> "" Then
                Form_edita_horario.dt_hora_fin.Text = Me.DataGridView1.SelectedCells.Item(2).Value
            Else
                Form_edita_horario.dt_hora_fin.Visible = False
            End If

            pos = Me.DataGridView1.CurrentCell.RowIndex
            Form_edita_horario.lbl_pos.Text = pos
            Form_edita_horario.lbl_cod_empleado.Text = Me.txt_cod_empleado.Text
            Form_edita_horario.Show()
        End If

    End Sub
End Class