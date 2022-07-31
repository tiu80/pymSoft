Public Class Form_muestra_mayor

    Dim reporte As New pymsoft.reporte

    Private Sub Tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_exporta.Click
        Form_exporta.Show()
    End Sub

    Private Sub Tool_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_imprime.Click
        Call imprimir_reporte()
    End Sub

    Private Sub imprimir_reporte()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("mayor")

        If x = "mayor" Then
            rep = New mayor
        End If

        Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txT3 As CrystalDecisions.CrystalReports.Engine.TextObject

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        txt1 = rep.Section2.ReportObjects.Item("fec_desde")
        txt1.Text = Form_mayor_planilla.dt_fec_desde.Text

        txt2 = rep.Section2.ReportObjects.Item("fec_hasta")
        txt2.Text = Form_mayor_planilla.dt_fec_hasta.Text

        txT3 = rep.Section2.ReportObjects.Item("cuenta")
        txT3.Text = Form_mayor_planilla.lbl_cuenta.Text

        rep.RecordSelectionFormula = "{planilla_caja.fec_emi} >= date('" & Form_mayor_planilla.dt_fec_desde.Text & "') and {planilla_caja.fec_emi} <= date('" & Form_mayor_planilla.dt_fec_hasta.Text & "') and {planilla_caja.det_cuenta} = '" & RTrim(Form_mayor_planilla.lbl_cuenta.Text) & "'"

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

        barra_carga.Timer1.Enabled = True

    End Sub

End Class