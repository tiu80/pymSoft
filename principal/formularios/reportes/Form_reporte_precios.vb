Imports System.Data
Imports System.Data.SqlClient

Public Class Form_reporte_precios

    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim reporte As New pymsoft.reporte
    Dim fact As New pymsoft.factura
    Dim tabla As DataTable
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim i As Integer
    Dim rubros As String

    Private Sub txt_cod_prov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_prov.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from list_01 where id_lista like '" & Me.txt_cod_prov.Text & "'"
            xxx.codigo = "id_lista"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_prov.Text = xxx.text
            Me.lbl_prov.Text = xxx.text2

            If xxx.validar = False Then
                Me.txt_cod_prov.Text = "0"
                Me.lbl_prov.Text = "Todos los Registros"
            End If

            Me.txt_cod_rub.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_proveedor.Show()
        End If

    End Sub

    Private Sub txt_cod_rub_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_rub.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from rub_01 where id_rubro like '" & Me.txt_cod_rub.Text & "'"
            xxx.codigo = "id_rubro"
            xxx.nombre = "nombre"
            xxx.cargar()

            If Me.chk_inluye_rubro.Checked = False Then

                Me.txt_cod_rub.Text = xxx.text
                Me.lbl_rubro.Text = xxx.text2

                If xxx.validar = False Then
                    Me.txt_cod_rub.Text = "0"
                    Me.lbl_rubro.Text = "Todos los Registros"
                End If

                Me.dt_fec_desde.Focus()

            Else

                If Me.txt_cod_rub.Text <> "" Then

                    Me.DataGridView1.Rows.Add()
                    Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Value = xxx.text
                    Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = xxx.text2

                End If

                Me.txt_cod_rub.Text = ""
                Me.txt_cod_rub.Focus()
                Me.txt_cod_rub.SelectAll()

            End If

        End If

        If e.KeyCode = Keys.F1 Then
            busc_rubro.Show()
        End If

    End Sub

    Private Sub Form_reporte_precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        fact.carga_parametro()
        Call carga_lista_definida()
        Me.txt_cod_list.Focus()

    End Sub

    Private Sub carga_lista_definida()
        Try

            xxx.instruccion = "select *from lista_01 where id_lis like '" & fact.lista_predeterminada & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_list.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            Me.txt_cod_prov.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_acepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        If Me.TabControl1.SelectedTab.Name = "TabPage1" Then

            If Me.chk_inluye_rubro.Checked = True Then llena_string_rubro()
            Call carga_precios()

        Else

            carga_precios_desactualizados()

        End If

    End Sub

    Private Sub carga_precios_desactualizados()

        Dim fecha As Date
        Dim rep As New precios_desactualizados

        fecha = CDate(Date.Now).ToString("dd/MM/yyyy")
        fecha = fecha.AddDays(Me.txt_dias_a_revisar.Text * -1)

        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

        txt = rep.Section2.ReportObjects.Item("txt_fecha")
        txt.Text = fecha

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, "")

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        rep.RecordSelectionFormula = "{art_01.estado} = 'Activo' and {art_01.id_lista} = " & Trim(Me.txt_cod_list.Text) & " and {art_01.fec_modi} <= date('" & fecha & "')"

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub llena_string_rubro()

        rubros = ""

        For i = 0 To Me.DataGridView1.Rows.Count - 1
            If i = 0 Then
                rubros = rubros & Me.DataGridView1.Rows(i).Cells(0).Value
            Else
                rubros = rubros & "," & Me.DataGridView1.Rows(i).Cells(0).Value
            End If
        Next

    End Sub

    Private Sub carga_precios()

        Dim rep As Object = Nothing
        Dim rep1 As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("precios")

        If x = "precios" Then
            rep = New precios
        End If

        x = reporte.carga_datos("precio_x_rubro_codigo")

        If x = "precio_x_rubro_codigo" Then
            rep1 = New precio_x_rubro_codigo
        End If

        x = reporte.carga_datos("precio_x_rubro")

        If x = "precio_x_rubro" Then
            If Me.chk_inluye_rubro.Checked = False Then rep1 = New precio_x_rubro
            If Me.chk_inluye_rubro.Checked = True Then rep1 = New precio_x_rubro_param
        End If

        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject

        If Me.txt_cod_prov.Text = "" Then Me.txt_cod_prov.Text = 0
        If Me.txt_cod_rub.Text = "" Then Me.txt_cod_rub.Text = 0

        conex = conecta()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        tabla = New DataTable
        tabla.Clear()

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text = 0 And Me.txt_cod_rub.Text = 0 And Me.chk_inluye_rubro.Checked = False Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY CAST(id_art1 AS Integer)", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios.id_lista1} = " & Trim(Me.txt_cod_list.Text) & ""
                'rep1.RecordSelectionFormula = "{precios.id_lista1} = " & Trim(Me.txt_cod_list.Text) & " and {precios.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"

            Else

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY nom", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios_n.id_lista1} = " & Trim(Me.txt_cod_list.Text) & ""
                'rep1.RecordSelectionFormula = "{precios_n.id_lista1} = " & Trim(Me.txt_cod_list.Text) & " and {precios_n.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"

            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text <> 0 And Me.txt_cod_rub.Text = 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY CAST(id_art1 AS Integer)", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & ""
                'rep1.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & " and {precios.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""

            Else

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY nom", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & ""
                'rep1.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & " and {precios_n.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""

            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text <> 0 And Me.txt_cod_rub.Text <> 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_proveedor = '" & Trim(Me.txt_cod_prov.Text) & "' and id_rubro = '" & Trim(Me.txt_cod_rub.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY CAST(id_art1 AS Integer)", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & ""
                'rep1.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & " and {precios.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""

            Else

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_proveedor = '" & Trim(Me.txt_cod_prov.Text) & "' and and id_rubro ='" & Trim(Me.txt_cod_rub.Text) & "' estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY nom", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios_n.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & ""
                'rep1.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios_n.id_proveedor} = " & RTrim(Me.txt_cod_prov.Text) & " and {precios_n.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""


            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text = 0 And Me.txt_cod_rub.Text <> 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_rubro = '" & Trim(Me.txt_cod_rub.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY CAST(id_art1 AS Integer)", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & ""
                'rep1.RecordSelectionFormula = "{precios.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""

            Else

                comando = New SqlDataAdapter("select * from precios where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and id_rubro ='" & Trim(Me.txt_cod_rub.Text) & "' estado1 ='" & Trim(Me.cmb_estado.Text) & "' ORDER BY nom", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & ""
                'rep1.RecordSelectionFormula = "{precios_n.id_lista1} = " & RTrim(Me.txt_cod_list.Text) & " and {precios_n.id_rubro} = " & RTrim(Me.txt_cod_rub.Text) & " and {precios_n.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"""


            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text = 0 And Me.txt_cod_rub.Text = 0 And Me.chk_inluye_rubro.Checked = True Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select * from art_01 inner join art_precio on id_lista = id_lista1 and id_art = id_art1 where id_lista = '" & Trim(Me.txt_cod_list.Text) & "' and art_precio.estado1 ='" & Trim(Me.cmb_estado.Text) & "' and art_01.id_rubro in (" & rubros & ") ORDER BY CAST(id_art1 AS Integer)", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios.id_lista1} = " & Trim(Me.txt_cod_list.Text) & ""
                'rep1.RecordSelectionFormula = "{precios.id_lista1} = " & Trim(Me.txt_cod_list.Text) & " and {precios.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"

            Else

                comando = New SqlDataAdapter("select * from art_01 inner join art_precio on id_lista = id_lista1 and id_art = id_art1 where id_lista1 = '" & Trim(Me.txt_cod_list.Text) & "' and estado1 ='" & Trim(Me.cmb_estado.Text) & "'  and id_rubro in (" & rubros & ")ORDER BY nom", conex)
                comando.Fill(tabla)
                comando.Dispose()

                'rep.RecordSelectionFormula = "{precios_n.id_lista1} = " & Trim(Me.txt_cod_list.Text) & ""
                'rep1.RecordSelectionFormula = "{precios_n.id_lista1} = " & Trim(Me.txt_cod_list.Text) & " and {precios_n.estado1} ='" & Trim(Me.cmb_estado.Text) & "'"

            End If

        End If

        If Me.opt_rubro.Checked = False Then

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")

            rep.SetDataSource(tabla)
            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.Refresh()

        End If

        If Me.opt_rubro.Checked = True Then

            rep1.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep1.SetDatabaseLogon(conexion.usuario, "")

            rep1.SetDataSource(tabla)
            Form_repcli_01.CrystalReportViewer1.ReportSource = rep1
            Form_repcli_01.CrystalReportViewer1.Refresh()

        End If


        barra_carga.Timer1.Enabled = True

        tabla.Dispose()

        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Dispose()
    End Sub

    Private Sub dt_fec_desde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_desde.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_hasta.Focus()
        End If
    End Sub

    Private Sub dt_fec_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_hasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_ordena.Focus()
        End If
    End Sub

    Private Sub cmb_ordena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_ordena.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_estado.Focus()
        End If
    End Sub

    Private Sub cmb_estado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_estado.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_acepta1.Focus()
        End If
    End Sub

    Private Sub chk_exluye_rubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.chk_inluye_rubro.Checked = True Then
            Me.DataGridView1.Visible = True
            Me.DataGridView1.Rows.Clear()
        Else
            Me.DataGridView1.Visible = False
            Me.DataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub txt_cod_list_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_list.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_cod_list.Text & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_list.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            If xxx.validar = False Then
                Me.txt_cod_list.Focus()
                Exit Sub
            End If

            Me.txt_cod_prov.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
        End If

    End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.txt_dias_a_revisar.SelectAll()
            Me.txt_dias_a_revisar.Focus()
        End If
    End Sub

    Private Sub chk_inluye_rubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_inluye_rubro.CheckedChanged
        If Me.chk_inluye_rubro.Checked = True Then
            Me.DataGridView1.Visible = True
            Me.DataGridView1.Rows.Clear()
        Else
            Me.DataGridView1.Visible = False
            Me.DataGridView1.Rows.Clear()
        End If
    End Sub
End Class