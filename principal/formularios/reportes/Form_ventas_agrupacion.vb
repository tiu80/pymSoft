Imports System.Data
Imports System.Data.SqlClient

Public Class Form_ventas_agrupacion

    Dim i As Integer
    Dim fact As New pymsoft.factura
    Dim reporte As New pymsoft.reporte

    Dim comando As SqlDataAdapter
    Dim conex As SqlConnection

    Private Sub Form_ventas_agrupacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dt_fec_desde.Text = Date.Now
        Me.dt_fec_hasta.Text = Date.Now
        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)
    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("ventas_agru_indi")

        If x = "ventas_agru_indi" Then
            rep = New ventas_agru_indi
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

        txt = rep.Section2.ReportObjects.Item("fecha_emi")
        txt.Text = Me.dt_fec_desde.Text

        txt = rep.Section2.ReportObjects.Item("fecha_fin")
        txt.Text = Me.dt_fec_hasta.Text

        txt = rep.Section2.ReportObjects.Item("modalidad")
        txt.Text = Me.cmb_modalidad.Text

        txt = rep.Section2.ReportObjects.Item("articulos")
        txt.Text = Me.lbl_nombre_articulo.Text

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        'modalidad total
        If Trim(Me.cmb_modalidad.Text) = "Total" Then
            rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and {fact_det.tipo_fact2} <> 'PD' and {fact_det.tipo_fact2} <> 'RE' and {fact_det.tipo_fact2} <> 'RS' and {fact_det.codi_producto} = '" & Trim(Me.txt_articulo.Text) & "'"
        End If

        'agrupacion total y modalidad zona
        If Trim(Me.cmb_modalidad.Text) = "Zona" Then
            txt = rep.Section2.ReportObjects.Item("zona")
            txt.Text = Me.cmb_nombre_cat.Text
            rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and {fact_det.tipo_fact2} <> 'PD' and {fact_det.tipo_fact2} <> 'RE' and {fact_det.tipo_fact2} <> 'RS' and {fact_det.codi_producto} = '" & Trim(Me.txt_articulo.Text) & "' and {cli_01.zona} = '" & Trim(Me.cmb_nombre_cat.Text) & "'"
        End If

        'agrupacion vendedor y modalidad total
        If Trim(Me.cmb_modalidad.Text) = "Vendedor" Then
            txt = rep.Section2.ReportObjects.Item("vendedor")
            txt.Text = Me.cmb_nombre_cat.Text
            rep.RecordSelectionFormula = "{fact_det.fec_emi} >= date('" & Me.dt_fec_desde.Text & "') and {fact_det.fec_emi} <= date('" & Me.dt_fec_hasta.Text & "') and {fact_det.tipo_fact2} <> 'PD' and {fact_det.tipo_fact2} <> 'RE' and {fact_det.tipo_fact2} <> 'RS' and {fact_det.codi_producto} = '" & Trim(Me.txt_articulo.Text) & "' and {cli_01.nom_vendedor} = '" & Trim(Me.cmb_nombre_cat.Text) & "'"
        End If

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        'Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.F1 Then

            fact.carga_parametro()

            busc_articulos.txt_lista.Text = fact.lista_predeterminada

            busc_articulos.Show()

        End If

    End Sub

    Private Sub cmb_modalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_modalidad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_nombre_cat.Focus()
        End If
    End Sub

    Private Sub cmb_modalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_modalidad.SelectedIndexChanged

        If Trim(Me.cmb_modalidad.Text) = "Zona" Then

            Dim tb As New DataTable
            Me.cmb_nombre_cat.Items.Clear()

            conex = New SqlConnection
            conex = conecta()

            comando = New SqlDataAdapter("select zona from zona_01 order by zona", conex)
            comando.Fill(tb)

            For i = 0 To tb.Rows.Count - 1
                Me.cmb_nombre_cat.Items.Add(tb.Rows(i).Item(0))
            Next

            Me.cmb_nombre_cat.Text = Me.cmb_nombre_cat.Items(0)
            Me.cmb_nombre_cat.Enabled = True

            tb.Dispose()
            comando.Dispose()

            Me.cmb_nombre_cat.Enabled = True

        ElseIf Trim(Me.cmb_modalidad.Text) = "Vendedor" Then

            Dim tb As New DataTable
            Me.cmb_nombre_cat.Items.Clear()

            conex = New SqlConnection
            conex = conecta()

            comando = New SqlDataAdapter("select nombre from vend_01 order by nombre", conex)
            comando.Fill(tb)

            For i = 0 To tb.Rows.Count - 1
                Me.cmb_nombre_cat.Items.Add(tb.Rows(i).Item(0))
            Next

            Me.cmb_nombre_cat.Text = Me.cmb_nombre_cat.Items(0)
            Me.cmb_nombre_cat.Enabled = True

            tb.Dispose()
            comando.Dispose()

        Else

            Me.cmb_nombre_cat.Enabled = False

        End If
    End Sub

    Private Sub dt_fec_desde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_desde.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_hasta.Focus()
        End If
    End Sub

    Private Sub dt_fec_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_hasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_articulo.Focus()
            Me.txt_articulo.SelectAll()
        End If
    End Sub

    Private Sub cmb_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.cmb_modalidad.Focus()
        End If
    End Sub

    Private Sub txt_articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_articulo.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_articulos.txt_lista.Text = 1
            busc_articulos.Show()
        End If
    End Sub

End Class