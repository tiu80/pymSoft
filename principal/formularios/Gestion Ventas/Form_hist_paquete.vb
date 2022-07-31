Imports System.Data
Imports System.Data.SqlClient

Public Class Form_hist_paquete

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl As New DataTable

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Dim rep As New hist_paquetes

        If RTrim(Me.cmb_modalidad.Text) = "Todos" Then

            'If Me.Check_paquetes.Checked = False Then rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            'If Me.Check_paquetes.Checked = True Then rep.GroupHeaderSection2.SectionFormat.EnableSuppress = False

            rep.RecordSelectionFormula = "{hist_pre_ven.fecha_venta} >= date('" & Me.txtFechaDesde.Text & "') and {hist_pre_ven.fecha_venta} <= date('" & Me.txtFechaHasta.Text & "')"

        Else

            'If Me.Check_paquetes.Checked = False Then rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            'If Me.Check_paquetes.Checked = True Then rep.GroupHeaderSection2.SectionFormat.EnableSuppress = False

            rep.RecordSelectionFormula = "{hist_pre_ven.fecha_venta} >= date('" & Me.txtFechaDesde.Text & "') and {hist_pre_ven.fecha_venta} <= date('" & Me.txtFechaHasta.Text & "') and {hist_pre_ven.nombre} = '" & RTrim(cmb_nombre.Text) & "'"

        End If

        frmComprobanteEnVisualizaMovimientos.CrystalReportViewer1.ReportSource = rep
        frmComprobanteEnVisualizaMovimientos.CrystalReportViewer1.RefreshReport()
        frmComprobanteEnVisualizaMovimientos.Show()

    End Sub


    Private Sub cmb_modalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_modalidad.SelectedIndexChanged

        If RTrim(Me.cmb_modalidad.Text) = "Todos" Then
            Me.lbl_nombre.Visible = False
            Me.cmb_nombre.Visible = False
        Else
            Me.lbl_nombre.Visible = True
            Me.cmb_nombre.Visible = True

            tbl.Clear()

            conex = oConexion
            comando = New SqlDataAdapter("select nombre from PAQUETES", conex)
            comando.Fill(tbl)

            Me.cmb_nombre.DataSource = tbl
            Me.cmb_nombre.DisplayMember = "nombre"

        End If

    End Sub

    Private Sub Form_hist_paquete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class