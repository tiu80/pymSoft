Imports System.Data
Imports System.Data.SqlClient

Public Class Form_rep_cliente

    Dim reporte As New pymsoft.reporte
    Dim comando As SqlDataAdapter
    Dim conex As SqlConnection
    Dim tabla As DataTable
    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

    Private Sub Form_rep_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Form_rep_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_agrupacion.Text = Me.cmb_agrupacion.Items(0)
        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        Me.dt_fec_desde.Focus()
    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("clientes")

        If x = "clientes" Then
            rep = New clientes
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If Me.cmb_ordena.Text = "Codigo" Then   ' Ordena x codigo

            If RTrim(Me.cmb_agrupacion.Text) = "Total" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Localidad" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente' and {cli_01.localidad} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor' and {cli_01.localidad} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

                txt = rep.Section2.ReportObjects.Item("txt_nombre")
                txt.Text = "Localidad:"

                txt = rep.Section2.ReportObjects.Item("txt_zona")
                txt.Text = Me.cmb_detalle_agrupacion.Text

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Zona" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente' and {cli_01.zona} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor' and {cli_01.zona} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = False
                'rep.DetailSection1.SectionFormat.EnableSuppress = True
                'rep.Section3.SectionFormat.EnableSuppress = False

                txt = rep.Section2.ReportObjects.Item("txt_nombre")
                txt.Text = "Zona:"

                txt = rep.Section2.ReportObjects.Item("txt_zona")
                txt.Text = Me.cmb_detalle_agrupacion.Text

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Provincia" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor'"

                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False

            End If

        End If

        If Me.cmb_ordena.Text <> "Codigo" Then   ' Ordena x Nombre

            If RTrim(Me.cmb_agrupacion.Text) = "Total" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Localidad" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Zona" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente' and {cli_01.zona} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor' and {cli_01.zona} = '" & RTrim(Me.cmb_detalle_agrupacion.Text) & "'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = False
                'rep.DetailSection1.SectionFormat.EnableSuppress = False
                'rep.Section3.SectionFormat.EnableSuppress = True

            End If

            If RTrim(Me.cmb_agrupacion.Text) = "Provincia" Then

                If Me.opt_cli.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Cliente'"
                If Me.opt_prov.Checked = True Then rep.RecordSelectionFormula = "{cli_01.estado} = '" & RTrim(Me.cmb_estado.Text) & "' and {cli_01.tipo_cliente} = 'Proveedor'"

                rep.GroupHeaderSection2.SectionFormat.EnableSuppress = False
                rep.GroupHeaderSection3.SectionFormat.EnableSuppress = True
                rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            End If

        End If

        txt = rep.Section1.ReportObjects.Item("nombre")

        If Me.opt_cli.Checked = True Then
            txt.Text = "Reportes Clientes"
        Else
            txt.Text = "Reportes Proveedores"
        End If

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

    Private Sub cmb_agrupacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_agrupacion.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.cmb_detalle_agrupacion.Focus()
        End If
    End Sub

    Private Sub cmb_agrupacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agrupacion.SelectedIndexChanged

        Select Case Me.cmb_agrupacion.Text

            Case "Zona"

                Me.lbl_detalle_agrupacion.Visible = True
                Me.cmb_detalle_agrupacion.Visible = True

                llena_cmb_zona()
            Case "Localidad"

                Me.lbl_detalle_agrupacion.Visible = True
                Me.cmb_detalle_agrupacion.Visible = True

                llena_cmb_localidad()

            Case Else
                Me.lbl_detalle_agrupacion.Visible = False
                Me.cmb_detalle_agrupacion.Visible = False

        End Select
    End Sub

    Private Sub llena_cmb_zona()

        Try

            Dim i As Integer = 0
            Me.cmb_detalle_agrupacion.Items.Clear()

            tabla = New DataTable
            conex = New SqlConnection
            conex = conecta()
            Dim comando As New SqlDataAdapter("select zona from zona_01 order by zona", conex)
            comando.Fill(tabla)

            For i = 0 To tabla.Rows.Count - 1
                Me.cmb_detalle_agrupacion.Items.Add(tabla.Rows(i).Item(0).ToString)
            Next

            Me.cmb_detalle_agrupacion.Text = Me.cmb_detalle_agrupacion.Items(0)

            comando.Dispose()
            tabla.Dispose()
            conex.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub llena_cmb_localidad()

        Try

            Dim i As Integer = 0
            Me.cmb_detalle_agrupacion.Items.Clear()

            tabla = New DataTable
            conex = New SqlConnection
            conex = conecta()
            Dim comando As New SqlDataAdapter("select nom_localidad from localidad order by id_loc", conex)
            comando.Fill(tabla)

            For i = 0 To tabla.Rows.Count - 1
                Me.cmb_detalle_agrupacion.Items.Add(tabla.Rows(i).Item(0).ToString)
            Next

            Me.cmb_detalle_agrupacion.Text = Me.cmb_detalle_agrupacion.Items(0)

            comando.Dispose()
            tabla.Dispose()
            conex.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dt_fec_desde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_desde.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.dt_fec_hasta.Focus()
        End If
    End Sub

    Private Sub dt_fec_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_hasta.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.cmb_agrupacion.Focus()
        End If
    End Sub

    Private Sub cmb_detalle_agrupacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_detalle_agrupacion.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.cmb_estado.Focus()
        End If
    End Sub

    Private Sub cmb_estado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_estado.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.cmd_acepta1.Focus()
        End If
    End Sub
End Class