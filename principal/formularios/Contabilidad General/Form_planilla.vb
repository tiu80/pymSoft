Imports System.Data
Imports System.Data.SqlClient

Public Class Form_planilla

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl As New DataTable, tb1 As New DataTable
    Dim i As Integer
    Public existe_movimiento As Boolean = False

    Private Sub txt_numero_int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_int.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Form_planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        tbl.Clear()

        comando = New SqlDataAdapter("select descripcion,numero_planilla,num_movimiento,id_planilla from planilla01", conex)
        comando.Fill(tbl)

        Me.cmb_planilla.DataSource = tbl
        Me.cmb_planilla.ValueMember = "descripcion"

        Me.txt_num_palnilla.Text = tbl.Rows(0).Item(1)
        Me.txt_numero_int.Text = tbl.Rows(0).Item(2)

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        form_factura.verifica_fecha(Me.DateTimePicker1.Value.Month, Me.DateTimePicker1.Value.Year)

        If form_factura.fecha_mala = False Then
            Me.DateTimePicker1.Focus()
            Exit Sub
        End If

        Form_muestra_planilla.txt_estado_form.Text = 1
        Form_muestra_planilla.txt_codigo_planilla.Text = tbl.Rows(0).Item(3)
        Form_muestra_planilla.txt_numero_planilla.Text = tbl.Rows(0).Item(1)

        Call carga_movimiento_en_planilla()

        Form_muestra_planilla.Show()

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

    Private Sub carga_movimiento_en_planilla()

        conex = conecta()
        tb1.Clear()

        comando = New SqlDataAdapter("select num_interno,cuenta,det_cuenta,entrada,salida,np,tp,operacion,num_comprobante,bco,movimiento from planilla_caja where num_interno = '" & RTrim(Me.txt_numero_int.Text) & "' and mes = '" & RTrim(Me.DateTimePicker1.Value.Month) & "' and año = '" & RTrim(Me.DateTimePicker1.Value.Year) & "'", conex)
        comando.Fill(tb1)
        comando.Dispose()

        Form_muestra_planilla.cmb_movimiento.Focus()

        If tb1.Rows.Count = Nothing Then Exit Sub

        Form_muestra_planilla.Tool_eminima_mov.Enabled = True
        Form_muestra_planilla.Tool_eminina_item.Enabled = True
        Form_muestra_planilla.Tool_exporta.Enabled = True
        Form_muestra_planilla.Tool_imprime.Enabled = True

        Form_muestra_planilla.cmd_cancelar.Enabled = False
        Form_muestra_planilla.cmd_aceptar.Enabled = False
        Form_muestra_planilla.cmd_guarda_mov.Enabled = False

        existe_movimiento = True

        For i = 0 To tb1.Rows.Count - 1

            Form_muestra_planilla.DataGridView1.Rows.Add()

            Form_muestra_planilla.DataGridView1.Rows(i).Cells(0).Value = tb1.Rows(i).Item(0)
            Form_muestra_planilla.DataGridView1.Rows(i).Cells(1).Value = tb1.Rows(i).Item(1)
            Form_muestra_planilla.DataGridView1.Rows(i).Cells(2).Value = tb1.Rows(i).Item(2)

            If tb1.Rows(i).Item(3) <> Nothing Then Form_muestra_planilla.DataGridView1.Rows(i).Cells(3).Value = tb1.Rows(i).Item(3)
            If tb1.Rows(i).Item(4) <> Nothing Then Form_muestra_planilla.DataGridView1.Rows(i).Cells(4).Value = tb1.Rows(i).Item(4)

            Form_muestra_planilla.DataGridView1.Rows(i).Cells(5).Value = tb1.Rows(i).Item(8)
            Form_muestra_planilla.DataGridView1.Rows(i).Cells(6).Value = tb1.Rows(i).Item(9)
            Form_muestra_planilla.DataGridView1.Rows(i).Cells(7).Value = tb1.Rows(i).Item(10)

        Next

        Form_muestra_planilla.DataGridView1.Focus()

        tb1.Dispose()

    End Sub

End Class