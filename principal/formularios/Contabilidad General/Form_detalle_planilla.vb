Imports System.Data
Imports System.Data.SqlClient

Public Class Form_detalle_planilla

    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim tb As New DataTable, tb1 As New DataTable, tb2 As New DataTable
    Dim i As Integer
    Dim suma As Double, suma1 As Double
    Dim reporte As New pymsoft.reporte

    Private Sub Form_detalle_planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim x As Integer

            Me.DataGridView1.Columns.Add(1, 1)
            Me.DataGridView1.Columns.Add(2, 2)
            Me.DataGridView1.Columns.Add(3, 3)
            Me.DataGridView1.Columns.Add(4, 4)
            Me.DataGridView1.Columns.Add(5, 5)
            Me.DataGridView1.Columns.Add(6, 6)
            Me.DataGridView1.Columns.Add(7, 7)
            Me.DataGridView1.Columns.Add(8, 8)
            Me.DataGridView1.Columns.Add(9, 9)

            Me.DataGridView1.Columns(0).HeaderText = "FECHA"
            Me.DataGridView1.Columns(1).HeaderText = "Nº INT"
            Me.DataGridView1.Columns(2).HeaderText = "CUENTA"
            Me.DataGridView1.Columns(3).HeaderText = "MOVIMIENTO"
            Me.DataGridView1.Columns(4).HeaderText = "ENTRADA"
            Me.DataGridView1.Columns(5).HeaderText = "SALIDA"
            Me.DataGridView1.Columns(6).HeaderText = "SALDO"
            Me.DataGridView1.Columns(7).HeaderText = "NP"
            Me.DataGridView1.Columns(8).HeaderText = "TP"

            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 70
            Me.DataGridView1.Columns(2).Width = 70
            Me.DataGridView1.Columns(3).Width = 283
            Me.DataGridView1.Columns(4).Width = 80
            Me.DataGridView1.Columns(5).Width = 80
            Me.DataGridView1.Columns(6).Width = 80

            ' calculo saldo incial

            conex = conecta()

            tb1.Clear()
            comando = New SqlDataAdapter("select saldo from planilla01 where numero_planilla = '" & RTrim(form_consulta_planilla.txt_cod_planilla.Text) & "' and descripcion = '" & RTrim(form_consulta_planilla.cmb_planilla.Text) & "'", conex)
            comando.Fill(tb1)

            ' calculo saldo anterior

            tb2.Clear()

            comando = New SqlDataAdapter("select fec_emi,entrada,salida,np,tp from planilla_caja where np = '" & RTrim(form_consulta_planilla.txt_cod_planilla.Text) & "' and fec_emi < '" & form_consulta_planilla.dt_fec_desde.Text & "' ORDER BY fec_emi", conex)
            comando.Fill(tb2)

            For i = 0 To tb2.Rows.Count - 1

                If tb2.Rows(i).Item(1) <> Nothing Then
                    suma1 = Format(suma1 + tb2.Rows(i).Item(1), "0.00")
                End If

                If tb2.Rows(i).Item(2) <> Nothing Then
                    suma1 = Format(suma1 - tb2.Rows(i).Item(2), "0.00")
                End If

            Next

            If RTrim(form_consulta_planilla.cmb_movimientos.Text) = "TOTAL" Then

                ' calcula total planilla

                tb.Clear()

                comando = New SqlDataAdapter("select fec_emi,num_interno,cuenta,det_cuenta,entrada,salida,0,np,tp from planilla_caja where np = '" & RTrim(form_consulta_planilla.txt_cod_planilla.Text) & "' and fec_emi >= '" & form_consulta_planilla.dt_fec_desde.Text & "' and fec_emi <= '" & form_consulta_planilla.dt_fec_hasta.Text & "' ORDER BY fec_emi", conex)
                comando.Fill(tb)

                suma = Format(suma1 + tb1.Rows(0).Item(0), "0.00")

                For i = 0 To tb.Rows.Count - 1

                    Me.DataGridView1.Rows.Add()

                    Me.DataGridView1.Rows(i).Cells(0).Value = tb.Rows(i).Item(0)
                    Me.DataGridView1.Rows(i).Cells(1).Value = tb.Rows(i).Item(1)
                    Me.DataGridView1.Rows(i).Cells(2).Value = tb.Rows(i).Item(2)
                    Me.DataGridView1.Rows(i).Cells(3).Value = tb.Rows(i).Item(3)

                    If tb.Rows(i).Item(4) <> Nothing Then

                        Me.DataGridView1.Rows(i).Cells(4).Value = tb.Rows(i).Item(4)
                        suma = Format(suma + Val(Me.DataGridView1.Rows(i).Cells(4).Value), "0.00")
                        Me.DataGridView1.Rows(i).Cells(6).Value = suma

                    End If

                    If tb.Rows(i).Item(5) <> Nothing Then

                        Me.DataGridView1.Rows(i).Cells(5).Value = tb.Rows(i).Item(5)
                        suma = Format(suma - Val(Me.DataGridView1.Rows(i).Cells(5).Value), "0.00")
                        Me.DataGridView1.Rows(i).Cells(6).Value = suma

                    End If

                    Me.DataGridView1.Rows(i).Cells(7).Value = tb.Rows(i).Item(7)
                    Me.DataGridView1.Rows(i).Cells(8).Value = tb.Rows(i).Item(8)

                Next

                x = Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(x).Cells(6).Style.BackColor = Color.Salmon

                Me.txt_comentario.Text = "Planilla:" & "  " & form_consulta_planilla.txt_cod_planilla.Text & " " & " - " & form_consulta_planilla.cmb_planilla.Text & vbCrLf & vbCrLf & "Fecha:" & "   " & form_consulta_planilla.dt_fec_desde.Text & "     " & " Hasta:" & "   " & form_consulta_planilla.dt_fec_hasta.Text & vbCrLf & vbCrLf & "Saldo Incial:" & "  " & tb1.Rows(0).Item(0) & "         " & " Saldo Anterior:" & "  " & suma1 & "         " & "Saldo Actual:" & "  " & Me.DataGridView1.Rows(x).Cells(6).Value

                Exit Sub

            End If

            tb.Clear()

            comando = New SqlDataAdapter("select fec_emi,num_interno,cuenta,det_cuenta,entrada,salida,0,np,tp from planilla_caja where np = '" & RTrim(form_consulta_planilla.txt_cod_planilla.Text) & "' and fec_emi >= '" & form_consulta_planilla.dt_fec_desde.Text & "' and fec_emi <= '" & form_consulta_planilla.dt_fec_hasta.Text & "' and movimiento = '" & RTrim(form_consulta_planilla.cmb_movimientos.Text) & "' ORDER BY fec_emi", conex)
            comando.Fill(tb)

            For i = 0 To tb.Rows.Count - 1

                Me.DataGridView1.Rows.Add()

                Me.DataGridView1.Rows(i).Cells(0).Value = tb.Rows(i).Item(0)
                Me.DataGridView1.Rows(i).Cells(1).Value = tb.Rows(i).Item(1)
                Me.DataGridView1.Rows(i).Cells(2).Value = tb.Rows(i).Item(2)
                Me.DataGridView1.Rows(i).Cells(3).Value = tb.Rows(i).Item(3)

                If tb.Rows(i).Item(4) <> Nothing Then

                    Me.DataGridView1.Rows(i).Cells(4).Value = tb.Rows(i).Item(4)
                    suma = Format(suma + Val(Me.DataGridView1.Rows(i).Cells(4).Value), "0.00")
                    Me.DataGridView1.Rows(i).Cells(6).Value = suma

                End If

                If tb.Rows(i).Item(5) <> Nothing Then

                    Me.DataGridView1.Rows(i).Cells(5).Value = tb.Rows(i).Item(5)
                    suma = Format(suma - Val(Me.DataGridView1.Rows(i).Cells(5).Value), "0.00")
                    Me.DataGridView1.Rows(i).Cells(6).Value = suma

                End If

                Me.DataGridView1.Rows(i).Cells(7).Value = tb.Rows(i).Item(7)
                Me.DataGridView1.Rows(i).Cells(8).Value = tb.Rows(i).Item(8)

            Next

            x = Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(x).Cells(6).Style.BackColor = Color.Salmon

            Me.txt_comentario.Text = "Planilla:" & "  " & form_consulta_planilla.txt_cod_planilla.Text & " " & " - " & form_consulta_planilla.cmb_planilla.Text & vbCrLf & vbCrLf & "Fecha:" & "   " & form_consulta_planilla.dt_fec_desde.Text & "     " & " Hasta:" & "   " & form_consulta_planilla.dt_fec_hasta.Text & vbCrLf & vbCrLf & "Saldo Incial:" & "  " & tb1.Rows(0).Item(0) & "         " & " Saldo Anterior:" & "  " & suma1 & "         " & "Saldo Actual:" & "  " & Me.DataGridView1.Rows(x).Cells(6).Value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub imprimir_reporte()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("planilla01")

        If x = "planilla01" Then
            rep = New planilla01
        End If

        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txT3 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt4 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt5 As CrystalDecisions.CrystalReports.Engine.TextObject

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        txt = rep.Section2.ReportObjects.Item("txt_planilla")
        txt.Text = form_consulta_planilla.cmb_planilla.Text

        txt1 = rep.Section2.ReportObjects.Item("fec_desde")
        txt1.Text = form_consulta_planilla.dt_fec_desde.Text

        txt2 = rep.Section2.ReportObjects.Item("fec_hasta")
        txt2.Text = form_consulta_planilla.dt_fec_hasta.Text

        txT3 = rep.Section2.ReportObjects.Item("txt_saldo_ini")
        txT3.Text = tb1.Rows(0).Item(0)

        txt4 = rep.Section2.ReportObjects.Item("txt_saldo_ant")
        txt4.Text = suma1

        txt5 = rep.Section2.ReportObjects.Item("txt_total")
        txt5.Text = suma

        If RTrim(form_consulta_planilla.cmb_movimientos.Text) = "TOTAL" Then

            rep.RecordSelectionFormula = "{planilla_caja.fec_emi} >= date('" & form_consulta_planilla.dt_fec_desde.Text & "') and {planilla_caja.fec_emi} <= date('" & form_consulta_planilla.dt_fec_hasta.Text & "')"

        Else

            rep.RecordSelectionFormula = "{planilla_caja.fec_emi} >= date('" & form_consulta_planilla.dt_fec_desde.Text & "') and {planilla_caja.fec_emi} <= date('" & form_consulta_planilla.dt_fec_hasta.Text & "') and {planilla_caja.movimiento} = '" & RTrim(form_consulta_planilla.cmb_movimientos.Text) & "'"

        End If

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub tool_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_imprime.Click

        Call imprimir_reporte()

    End Sub

    Private Sub Tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_exporta.Click

        Form_exporta.Show()

    End Sub

End Class