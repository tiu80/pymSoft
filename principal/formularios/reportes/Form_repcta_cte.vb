Imports System.Data
Imports System.Data.SqlClient

Public Class Form_repcta_cte

    Dim midataset As New DataSet
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim cod_vend, cod_pro, cod_zona As Integer
    Dim tbs, tbs1 As New DataTable
    Dim i, j, cont, dias As Integer
    Dim d30, d45, d60, saldototal As Double
    Dim talonario As Short = 2

    Dim reporte As New pymsoft.reporte
    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

    Private Sub Form_repcta_cte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Form_repcta_cte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_ordenacion.Text = Me.cmb_ordenacion.Items(0)
        Me.cmb_filtro.Text = Me.cmb_filtro.Items(0)
        Me.cmb_tipo1.Text = Me.cmb_tipo1.Items(0)
        Me.cmb_tipo2.Text = Me.cmb_tipo2.Items(0)
        llena_cmb_zona()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.TabControl1.SelectedTab Is Me.TabPage1 And Me.chk_historico.Checked = False And Me.chk_convinado.Checked = True Then
            carga_reporte_ctacte_convinado()
            Exit Sub
        End If

        If Me.TabControl1.SelectedTab Is Me.TabPage1 And Me.chk_historico.Checked = False Then
            carga_reporte_ctacte()
            Exit Sub
        End If

        If Me.TabControl1.SelectedTab Is Me.TabPage1 And Me.chk_historico.Checked = True Then
            carga_reporte_historico_ctacte()
            Exit Sub
        End If

        If Me.TabControl1.SelectedTab Is Me.TabPage2 Then carga_reporte_saldos_ventas()
        If Me.TabControl1.SelectedTab Is Me.TabPage3 Then carga_reporte_saldos_compras()

    End Sub

    Private Sub carga_reporte_saldos_compras()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("saldos_vencidos_compras")

        If x = "saldos_vencidos_compras" Then
            rep = New saldos_vencidos_compras
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If Me.cmb_tipo2.Text = "Total" Then

            'rep.RecordSelectionFormula = "(date('" & Me.DateTimePicker2.Text & "') >= DateAdd('d',30,{cta_cte_pro.fecha_emi}))"
            'rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            'Form_repcli_01.CrystalReportViewer1.DisplayGroupTree = False

            'borro el contenido de la tabla temporal
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("Delete from TempSaldosVencidos", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then conex.Close()

            seleccion_codigo_proveedor()

            tbs1.Clear()

            conex = conecta()

            ' selecciono los clientes distintos para ver cuantos hay en la cuenta
            comando = New SqlDataAdapter("select distinct cli from cta_cte_pro", conex)
            comando.Fill(tbs1)

            ' busco los clientes distinto para agregar a la tabla
            For i = 0 To tbs1.Rows.Count - 1
                tbs.Clear()

                comando = New SqlDataAdapter("select fecha_emi,cli,debito,credito,id_cli from cta_cte_pro where cli = '" & Trim(tbs1.Rows(i).Item(0)) & "'", conex)
                comando.Fill(tbs)

                For j = 0 To tbs.Rows.Count - 1

                    dias = DateDiff(DateInterval.Day, Me.DateTimePicker2.Value, tbs.Rows(j).Item(0))
                    If dias < 0 Then dias = dias * (-1)

                    If dias > 30 And dias <= 45 Then
                        d30 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 45 And dias <= 60 Then
                        d45 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 60 Then
                        d60 = tbs.Rows(j).Item(2)
                    End If

                    saldototal = Format(saldototal + (tbs.Rows(j).Item(2) - tbs.Rows(j).Item(3)), "0.00")

                    If conex.State = ConnectionState.Closed Then conex.Open()

                    If cont = 0 Then
                        coman = New SqlCommand("Insert into TempSaldosVencidos(id,cliente,saldo30,saldo45,saldo60,saldototal,zona,vendedor,id_zona,id_vend) values('" & i & "','" & Trim(tbs.Rows(j).Item(1)) & "','" & d30 & "','" & d45 & "','" & d60 & "','" & saldototal & "','" & Me.cmb_zona.Text & "','" & Me.cmb_descripcion1.Text & "','" & cod_zona & "','" & cod_pro & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        cont = 1
                    Else
                        coman = New SqlCommand("Update TempSaldosVencidos set saldo30 = '" & d30 & "',saldo45='" & d45 & "',saldo60='" & d60 & "',saldototal = '" & saldototal & "' where cliente ='" & Trim(tbs.Rows(j).Item(1)) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()
                    End If

                    If conex.State = ConnectionState.Open Then conex.Close()

                Next

                cont = 0
                d30 = 0
                d45 = 0
                d60 = 0
                saldototal = 0

            Next

            Form_repcli_01.CrystalReportViewer1.DisplayGroupTree = True

            txt = rep.Section2.ReportObjects.Item("txt_modalidad")
            txt.Text = "Total"

        Else

            'borro el contenido de la tabla temporal
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("Delete from TempSaldosVencidos", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then conex.Close()

            seleccion_codigo_proveedor()

            tbs1.Clear()

            conex = conecta()

            ' selecciono los clientes distintos para ver cuantos hay en la cuenta
            comando = New SqlDataAdapter("select distinct cli from cta_cte_pro where id_cli = '" & Trim(cod_pro) & "'", conex)
            comando.Fill(tbs1)

            ' busco los clientes distinto para agregar a la tabla
            For i = 0 To tbs1.Rows.Count - 1
                tbs.Clear()

                comando = New SqlDataAdapter("select fecha_emi,cli,debito,credito,id_cli from cta_cte_pro where cli = '" & Trim(tbs1.Rows(i).Item(0)) & "'", conex)
                comando.Fill(tbs)

                For j = 0 To tbs.Rows.Count - 1

                    dias = DateDiff(DateInterval.Day, Me.DateTimePicker2.Value, tbs.Rows(j).Item(0))
                    If dias < 0 Then dias = dias * (-1)

                    If dias > 30 And dias <= 45 Then
                        d30 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 45 And dias <= 60 Then
                        d45 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 60 Then
                        d60 = tbs.Rows(j).Item(2)
                    End If

                    saldototal = Format(saldototal + (tbs.Rows(j).Item(2) - tbs.Rows(j).Item(3)), "0.00")

                    If conex.State = ConnectionState.Closed Then conex.Open()

                    If cont = 0 Then
                        coman = New SqlCommand("Insert into TempSaldosVencidos(id,cliente,saldo30,saldo45,saldo60,saldototal,zona,vendedor,id_zona,id_vend) values('" & i & "','" & Trim(tbs.Rows(j).Item(1)) & "','" & d30 & "','" & d45 & "','" & d60 & "','" & saldototal & "','" & Me.cmb_zona.Text & "','" & Me.cmb_descripcion1.Text & "','" & cod_zona & "','" & cod_pro & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        cont = 1
                    Else
                        coman = New SqlCommand("Update TempSaldosVencidos set saldo30 = '" & d30 & "',saldo45='" & d45 & "',saldo60='" & d60 & "',saldototal = '" & saldototal & "' where cliente ='" & Trim(tbs.Rows(j).Item(1)) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()
                    End If

                    If conex.State = ConnectionState.Open Then conex.Close()

                Next

                cont = 0
                d30 = 0
                d45 = 0
                d60 = 0
                saldototal = 0

            Next

            rep.RecordSelectionFormula = "{TempSaldosVencidos.id_vend} = " & cod_pro & ""
            Form_repcli_01.CrystalReportViewer1.DisplayGroupTree = True

            txt = rep.Section2.ReportObjects.Item("txt_modalidad")
            txt.Text = "Proveedores"

        End If


        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True


    End Sub

    Private Sub carga_reporte_saldos_ventas()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("saldos_vencidos")

        If x = "saldos_vencidos" Then
            rep = New Saldos_vencidos
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If Me.cmb_tipo1.Text = "Total" Then

            'rep.RecordSelectionFormula = "(date('" & Me.DateTimePicker1.Text & "') >= DateAdd('d',30,{cta_cte01.fecha_emi})) and {cli_01.zona} = '" & Trim(Me.cmb_zona.Text) & "'"
            'rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            'Form_repcli_01.CrystalReportViewer1.DisplayGroupTree = False

            txt = rep.Section2.ReportObjects.Item("txt_modalidad")
            txt.Text = "Total"

        Else


            'borro el contenido de la tabla temporal
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("Delete from TempSaldosVencidos", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then conex.Close()

            seleccion_codigo_vendedor()
            seleccion_codigo_zona()

            tbs1.Clear()

            conex = conecta()

            ' selecciono los clientes distintos para ver cuantos hay en la cuenta
            comando = New SqlDataAdapter("select distinct CC.cli from cta_cte01 as CC inner join cli_01 as C on CC.id_cli = C.id_cli where CC.cod_vend = '" & Trim(cod_vend) & "' and C.id_zona ='" & Trim(cod_zona) & "'", conex)
            comando.Fill(tbs1)

            ' busco los clientes distinto para agregar a la tabla
            For i = 0 To tbs1.Rows.Count - 1
                tbs.Clear()

                comando = New SqlDataAdapter("select fecha_emi,cli,debito,credito,cod_vend from cta_cte01 where cli = '" & Trim(tbs1.Rows(i).Item(0)) & "'", conex)
                comando.Fill(tbs)

                For j = 0 To tbs.Rows.Count - 1

                    dias = DateDiff(DateInterval.Day, Me.DateTimePicker1.Value, tbs.Rows(j).Item(0))
                    If dias < 0 Then dias = dias * (-1)

                    If dias > 30 And dias <= 45 Then
                        d30 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 45 And dias <= 60 Then
                        d45 = tbs.Rows(j).Item(2)
                    End If

                    If dias > 60 Then
                        d60 = tbs.Rows(j).Item(2)
                    End If

                    saldototal = Format(saldototal + (tbs.Rows(j).Item(2) - tbs.Rows(j).Item(3)), "0.00")

                    If conex.State = ConnectionState.Closed Then conex.Open()

                    If cont = 0 Then
                        coman = New SqlCommand("Insert into TempSaldosVencidos(id,cliente,saldo30,saldo45,saldo60,saldototal,zona,vendedor,id_zona,id_vend) values('" & i & "','" & Trim(tbs.Rows(j).Item(1)) & "','" & d30 & "','" & d45 & "','" & d60 & "','" & saldototal & "','" & Me.cmb_zona.Text & "','" & Me.cmb_descripcion1.Text & "','" & cod_zona & "','" & cod_vend & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        cont = 1
                    Else
                        coman = New SqlCommand("Update TempSaldosVencidos set saldo30 = '" & d30 & "',saldo45='" & d45 & "',saldo60='" & d60 & "',saldototal = '" & saldototal & "' where cliente ='" & Trim(tbs.Rows(j).Item(1)) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()
                    End If

                    If conex.State = ConnectionState.Open Then conex.Close()

                Next

                cont = 0
                d30 = 0
                d45 = 0
                d60 = 0
                saldototal = 0

            Next

            rep.RecordSelectionFormula = "{TempSaldosVencidos.id_vend} = " & cod_vend & " and {TempSaldosVencidos.id_zona} = " & Trim(Me.cod_zona) & ""
            Form_repcli_01.CrystalReportViewer1.DisplayGroupTree = True

            txt = rep.Section2.ReportObjects.Item("txt_modalidad")
            txt.Text = "Vendedores"

            txt = rep.Section2.ReportObjects.Item("txt_vendedor")
            txt.Text = Me.cmb_descripcion1.Text

            txt = rep.Section2.ReportObjects.Item("zona")
            txt.Text = Me.cmb_zona.Text

        End If


        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub carga_reporte_ctacte()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("cta_cte")

        If x = "cta_cte" Then
            rep = New cta_cte
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If RTrim(Me.cmb_filtro.Text) = "Total" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.talon}= " & Me.talonario & ""
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Cliente" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.cli} = '" & Trim(Me.cmb_descripcion.Text) & "' and {rep_cta_cte.talon}= " & Me.talonario & ""
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Vendedor" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.nom_vendedor} = '" & RTrim(Me.cmb_descripcion.Text) & "' and {rep_cta_cte.talon}= " & Me.talonario & ""
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Provincia" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.provincia} = '" & RTrim(Me.cmb_descripcion.Text) & "' and {rep_cta_cte.talon}= " & Me.talonario & ""
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Zona" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.zona} = '" & RTrim(Me.cmb_descripcion.Text) & "' and {rep_cta_cte.talon}= " & Me.talonario & ""
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub carga_reporte_ctacte_convinado()

        Dim rep As Object = Nothing
        Dim x As String

        x = reporte.carga_datos("cta_cte")

        If x = "cta_cte" Then
            rep = New cta_cte
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If RTrim(Me.cmb_filtro.Text) = "Total" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "')"
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Cliente" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.cli} = '" & Trim(Me.cmb_descripcion.Text) & "'"
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Vendedor" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.nom_vendedor} = '" & RTrim(Me.cmb_descripcion.Text) & "'"
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Provincia" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.provincia} = '" & RTrim(Me.cmb_descripcion.Text) & "'"
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Zona" Then

            rep.RecordSelectionFormula = "{rep_cta_cte.fecha_emi} >= date('" & Me.dt_fecha_desde.Text & "') and {rep_cta_cte.fecha_emi} <= date('" & Me.dt_fecha_hasta.Text & "') and {rep_cta_cte.zona} = '" & RTrim(Me.cmb_descripcion.Text) & "'"
            rep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            rep.GroupHeaderSection3.SectionFormat.EnableSuppress = False
            rep.GroupHeaderSection1.SectionFormat.EnableSuppress = True

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        barra_carga.Timer1.Enabled = True

    End Sub


    Private Sub carga_reporte_historico_ctacte()

        'Dim rep As New historico_cta_cte
        Dim rep As New resumen_hist_ctacte

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("DELETE FROM Temp_historico_ctacte", conex)
        coman.CommandType = CommandType.Text

        coman.ExecuteNonQuery()
        coman.Dispose()

        coman = New SqlCommand("INSERT INTO Temp_historico_ctacte (fec,tc,lt,pre,num,debito,credito,estado,id_cli,cli,talon,acum) EXEC historico_general '" & Me.dt_fecha_desde.Text & "','" & talonario & "'", conex)
        coman.CommandType = CommandType.Text

        coman.ExecuteNonQuery()
        coman.Dispose()

        If conex.State = ConnectionState.Open Then conex.Close()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If RTrim(Me.cmb_filtro.Text) = "Total" Then

            rep.RecordSelectionFormula = "{Temp_historico_ctacte.fec} >= date('" & Me.dt_fecha_desde.Text & "') and {Temp_historico_ctacte.fec} <= date('" & Me.dt_fecha_hasta.Text & "') and {Temp_historico_ctacte.talon}= " & Me.talonario & ""

            barra_carga.PictureBox1.Refresh()

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub cmb_filtro_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_filtro.SelectedIndexChanged

        conex = conecta()
        Me.midataset.Clear()

        If RTrim(Me.cmb_filtro.Text) = "Total" Then

            Me.cmb_descripcion.Visible = False
            Me.lbl_tipo_filtro.Visible = False

        End If

        If RTrim(Me.cmb_filtro.Text) = "Cliente" Then

            Me.cmb_descripcion.Visible = True
            Me.lbl_tipo_filtro.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from cli_01 order by nombre ASC", conex)
            comando.Fill(midataset, "cli_01")

            Me.cmb_descripcion.DataSource = midataset.Tables("cli_01")
            Me.cmb_descripcion.ValueMember = "nombre"

            comando.Dispose()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Vendedor" Then

            Me.cmb_descripcion.Visible = True
            Me.lbl_tipo_filtro.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from vend_01 order by nombre ASC", conex)
            comando.Fill(midataset, "vend_01")

            Me.cmb_descripcion.DataSource = midataset.Tables("vend_01")
            Me.cmb_descripcion.ValueMember = "nombre"

            comando.Dispose()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Zona" Then

            Me.cmb_descripcion.Visible = True
            Me.lbl_tipo_filtro.Visible = True

            Dim comando As New SqlDataAdapter("select zona from zona_01 order by zona ASC", conex)
            comando.Fill(midataset, "zona_01")

            Me.cmb_descripcion.DataSource = midataset.Tables("zona_01")
            Me.cmb_descripcion.ValueMember = "zona"

            comando.Dispose()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Localidad" Then

            Me.cmb_descripcion.Visible = True
            Me.lbl_tipo_filtro.Visible = True

            Dim comando As New SqlDataAdapter("select nom_localidad from localidad order by nom_localidad ASC", conex)
            comando.Fill(midataset, "localidad")

            Me.cmb_descripcion.DataSource = midataset.Tables("localidad")
            Me.cmb_descripcion.ValueMember = "nom_localidad"

            comando.Dispose()

        End If

        If RTrim(Me.cmb_filtro.Text) = "Provincia" Then

            Me.cmb_descripcion.Visible = True
            Me.lbl_tipo_filtro.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from prov_01 order by nombre ASC", conex)
            comando.Fill(midataset, "prov_01")

            Me.cmb_descripcion.DataSource = midataset.Tables("prov_01")
            Me.cmb_descripcion.ValueMember = "nombre"

            comando.Dispose()

        End If

    End Sub

    Private Sub cmb_tipo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo1.SelectedIndexChanged

        Dim i As Int16
        conex = conecta()

        If RTrim(Me.cmb_tipo1.Text) = "Total" Then

            Me.cmb_descripcion1.Visible = False
            Me.lbl_descripcion1.Visible = False

        Else

            Me.cmb_descripcion1.Items.Clear()
            midataset.Tables.Clear()

            Me.cmb_descripcion1.Visible = True
            Me.lbl_descripcion1.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from vend_01 order by nombre ASC", conex)
            comando.Fill(midataset, "vend_01")

            For i = 0 To midataset.Tables("vend_01").Rows.Count - 1

                Me.cmb_descripcion1.Items.Add(midataset.Tables("vend_01").Rows(i).Item(0))

            Next

            Me.cmb_descripcion1.Text = Me.cmb_descripcion1.Items(0)
            comando.Dispose()

        End If

    End Sub

    Private Sub seleccion_codigo_zona()

        conex = conecta()

        Dim tb As New DataTable

        Dim comando As New SqlDataAdapter("select id_zona from zona_01 where zona = '" & Trim(Me.cmb_zona.Text) & "'", conex)
        comando.Fill(tb)

        cod_zona = tb.Rows(0).Item(0)

        comando.Dispose()
        tb.Dispose()

    End Sub

    Private Sub seleccion_codigo_vendedor()

        conex = conecta()

        Dim tb As New DataTable

        Dim comando As New SqlDataAdapter("select id_vendedor from vend_01 where nombre = '" & Trim(Me.cmb_descripcion1.Text) & "'", conex)
        comando.Fill(tb)

        cod_vend = tb.Rows(0).Item(0)

        comando.Dispose()
        tb.Dispose()

    End Sub

    Private Sub seleccion_codigo_proveedor()

        conex = conecta()

        Dim tb As New DataTable

        Dim comando As New SqlDataAdapter("select id_cli from cli_01 where nombre = '" & Trim(Me.cmb_descipcion2.Text) & "'", conex)
        comando.Fill(tb)

        cod_pro = tb.Rows(0).Item(0)

        comando.Dispose()
        tb.Dispose()

    End Sub

    Private Sub cmb_tipo2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo2.SelectedIndexChanged

        Dim i As Int16
        conex = conecta()

        If RTrim(Me.cmb_tipo2.Text) = "Total" Then

            Me.cmb_descipcion2.Visible = False
            Me.lbl_descripcion2.Visible = False

        Else

            Me.cmb_descipcion2.Items.Clear()

            Me.cmb_descipcion2.Visible = True
            Me.lbl_descripcion2.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from cli_01 where tipo_cliente ='Proveedor' order by nombre ASC", conex)
            comando.Fill(midataset, "cli_01")

            For i = 0 To midataset.Tables("cli_01").Rows.Count - 1

                Me.cmb_descipcion2.Items.Add(midataset.Tables("cli_01").Rows(i).Item(0))

            Next

            Me.cmb_descipcion2.Text = Me.cmb_descipcion2.Items(0)

            comando.Dispose()

        End If

    End Sub

    Private Sub llena_cmb_zona()

        Try

            Dim i As Integer = 0
            Dim tabla As New DataTable
            Me.cmb_zona.Items.Clear()

            conex = New SqlConnection
            conex = conecta()
            Dim comando As New SqlDataAdapter("select zona from zona_01 order by zona", conex)
            comando.Fill(tabla)

            For i = 0 To tabla.Rows.Count - 1
                Me.cmb_zona.Items.Add(tabla.Rows(i).Item(0).ToString)
            Next

            Me.cmb_zona.Text = Me.cmb_zona.Items(0)

            comando.Dispose()
            tabla.Dispose()
            conex.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
            Me.chk_convinado.Checked = False
            talonario = 1
        Else
            Me.Check_talonario.BackColor = Color.Black
            talonario = 2
        End If
    End Sub

    Private Sub cmd_conciliador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_conciliador.Click

        Form_concilia_saldos_ctacte_historico.Show()

    End Sub

    Private Sub chk_convinado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_convinado.CheckedChanged
        If Me.chk_convinado.Checked = True Then
            Me.Check_talonario.Checked = False
            Me.chk_historico.Checked = False
        End If
    End Sub

    Private Sub chk_historico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_historico.CheckedChanged
        If Me.chk_historico.Checked = True Then
            Me.chk_convinado.Checked = False
        End If
    End Sub
End Class