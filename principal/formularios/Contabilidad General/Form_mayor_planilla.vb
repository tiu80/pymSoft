Imports System.Data
Imports System.Data.SqlClient

Public Class Form_mayor_planilla

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tb As New DataTable
    Dim i As Integer
    Dim suma As Double

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub txt_cuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cuenta.KeyDown

        If e.KeyCode = Keys.F1 Then
            busc_cuenta.Show()
        End If

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        tb.Clear()
        conex = conecta()
        suma = 0

        Form_muestra_mayor.DataGridView1.Rows.Clear()
        Form_muestra_mayor.DataGridView1.Columns.Clear()

        Form_muestra_mayor.DataGridView1.Columns.Add(1, 1)
        Form_muestra_mayor.DataGridView1.Columns.Add(2, 2)
        Form_muestra_mayor.DataGridView1.Columns.Add(3, 3)
        Form_muestra_mayor.DataGridView1.Columns.Add(4, 4)
        Form_muestra_mayor.DataGridView1.Columns.Add(5, 5)

        Form_muestra_mayor.DataGridView1.Columns(0).HeaderText = "FECHA"
        Form_muestra_mayor.DataGridView1.Columns(1).HeaderText = "DETALLE"
        Form_muestra_mayor.DataGridView1.Columns(2).HeaderText = "ENTRADA"
        Form_muestra_mayor.DataGridView1.Columns(3).HeaderText = "SALIDA"
        Form_muestra_mayor.DataGridView1.Columns(4).HeaderText = "SALDO"

        Form_muestra_mayor.DataGridView1.Columns(0).Width = 80
        Form_muestra_mayor.DataGridView1.Columns(1).Width = 360

        comando = New SqlDataAdapter("select fec_emi,det_cuenta,entrada,salida from planilla_caja where fec_emi >= '" & Me.dt_fec_desde.Text & "' and fec_emi <= '" & Me.dt_fec_hasta.Text & "' and det_cuenta = '" & RTrim(Me.lbl_cuenta.Text) & "' ORDER BY fec_emi", conex)
        comando.Fill(tb)

        If tb.Rows.Count = Nothing Then
            MessageBox.Show("No hay movimientos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i = 0 To tb.Rows.Count - 1

            Form_muestra_mayor.DataGridView1.Rows.Add()

            Form_muestra_mayor.DataGridView1.Rows(i).Cells(0).Value = tb.Rows(i).Item(0)
            Form_muestra_mayor.DataGridView1.Rows(i).Cells(1).Value = tb.Rows(i).Item(1)
            Form_muestra_mayor.DataGridView1.Rows(i).Cells(2).Value = tb.Rows(i).Item(2)
            Form_muestra_mayor.DataGridView1.Rows(i).Cells(3).Value = tb.Rows(i).Item(3)

            If tb.Rows(i).Item(2) = 0 Then Form_muestra_mayor.DataGridView1.Rows(i).Cells(2).Value = ""
            If tb.Rows(i).Item(3) = 0 Then Form_muestra_mayor.DataGridView1.Rows(i).Cells(3).Value = ""

            If tb.Rows(i).Item(2) <> Nothing Or tb.Rows(i).Item(2) <> 0 Then

                suma = Format(suma + tb.Rows(i).Item(2), "0.00")
                Form_muestra_mayor.DataGridView1.Rows(i).Cells(4).Value = suma

            End If

            If tb.Rows(i).Item(3) <> Nothing Or tb.Rows(i).Item(3) <> 0 Then

                suma = Format(suma - tb.Rows(i).Item(3), "0.00")
                Form_muestra_mayor.DataGridView1.Rows(i).Cells(4).Value = suma

            End If

        Next

        Form_muestra_mayor.DataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.LightSalmon
        Form_muestra_mayor.DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.LightGreen
        Form_muestra_mayor.DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.LightBlue

        i = Form_muestra_mayor.DataGridView1.Rows.Count - 1
        Form_muestra_mayor.DataGridView1.Rows(i).Cells(4).Style.BackColor = Color.LightYellow

        Form_muestra_mayor.txt_comentario1.Text = "Fecha:" & "   " & Me.dt_fec_desde.Text & "     " & " Hasta:" & "   " & Me.dt_fec_hasta.Text & vbCrLf & vbCrLf & "Cuenta:" & "  " & Me.lbl_cuenta.Text & vbCrLf & vbCrLf & "Saldo Actual:" & "  " & Form_muestra_mayor.DataGridView1.Rows(i).Cells(4).Value

        Form_muestra_mayor.txt_estado_form.Text = 1
        Form_muestra_mayor.Show()

    End Sub

End Class