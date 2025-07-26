Imports System.Data
Imports System.Data.SqlClient

Public Class Form_rentabilidad

    Dim tbl As New DataTable
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter

    Dim reporte As New pymsoft.reporte

    Private Sub Form_rentabilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Form_rentabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_agrupacion.Text = Me.cmb_agrupacion.Items(0)
        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        Me.dt_fec_desde.Value = Date.Now
        Me.dt_fec_hasta.Value = Date.Now
    End Sub

    Private Sub cmb_agrupacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agrupacion.SelectedIndexChanged

        If Me.cmb_agrupacion.Text = "Vendedor" Then

            Me.cmb_nombre.Visible = True
            Me.lbl_nom.Visible = True

            tbl.Clear()

            conex = conecta()
            comando = New SqlDataAdapter("select id_vendedor,nombre from vend_01", conex)
            comando.Fill(tbl)

            Me.cmb_nombre.DataSource = tbl
            Me.cmb_nombre.ValueMember = "nombre"
            Me.txt_cod_vendedor.Text = tbl.Rows(0).Item(0)

        Else

            Me.cmb_nombre.Visible = False
            Me.lbl_nom.Visible = False

        End If

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Try

            Dim rep As Object = Nothing
            Dim x As String

            x = reporte.carga_datos("rentabilidad")

            If x = "rentabilidad" Then
                rep = New rentabilidad
            End If

            x = reporte.carga_datos("rentabilidad_c")

            If x = "rentabilidad_c" Then
                rep = New rentabilidad_c
            End If

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")

            Dim tb As New DataTable
            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject

            txt = rep.Section2.ReportObjects.Item("fec_desde")
            txt.Text = Me.dt_fec_desde.Text

            txt1 = rep.Section2.ReportObjects.Item("fec_hasta")
            txt1.Text = Me.dt_fec_hasta.Text

            txt2 = rep.Section2.ReportObjects.Item("agru")
            txt2.Text = Me.cmb_agrupacion.Text

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            If Me.Check_talonario.Checked = True Then

                If RTrim(Me.cmb_agrupacion.Text) = "Total" Then rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and ({fact_det.tipo_fact2} = 'FC' or {fact_det.tipo_fact2} = 'NC') and {fact_det.talon1} = 1"

                If RTrim(Me.cmb_agrupacion.Text) = "Vendedor" Then rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and {fact_det.vend1} = " & RTrim(Me.txt_cod_vendedor.Text) & " and ({fact_det.tipo_fact2} <> 'PD' and {fact_det.tipo_fact2} <> 'RE' and {fact_det.tipo_fact2} <> 'RS') and and {fact_det.talon1} = 1"

            Else

                If RTrim(Me.cmb_agrupacion.Text) = "Total" Then rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and ({fact_det.tipo_fact2} = 'FC' or {fact_det.tipo_fact2} = 'NC') and {fact_det.talon1} = 2"

                If RTrim(Me.cmb_agrupacion.Text) = "Vendedor" Then rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and {fact_det.vend1} = " & RTrim(Me.txt_cod_vendedor.Text) & " and ({fact_det.tipo_fact2} <> 'PD' and {fact_det.tipo_fact2} <> 'RE' and {fact_det.tipo_fact2} <> 'RS') and and {fact_det.talon1} = 2"

            End If


            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        Catch ex As Exception

        Finally

            barra_carga.Timer1.Enabled = True

        End Try

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

    Private Sub cmb_nombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_nombre.SelectedIndexChanged

        Dim tbl1 As New DataTable

        Try

            tbl1.Clear()

            conex = conecta()
            comando = New SqlDataAdapter("select id_vendedor from vend_01 where nombre = '" & RTrim(Me.cmb_nombre.Text) & "'", conex)
            comando.Fill(tbl1)

            Me.txt_cod_vendedor.Text = tbl1.Rows(0).Item(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
        Else
            Me.Check_talonario.BackColor = Color.Black
        End If
    End Sub

End Class