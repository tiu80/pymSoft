Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System

Public Class Form_resumen_cta

    Dim cli As New pymsoft.cliente1
    Dim conex As New SqlConnection
    Dim coman As SqlDataAdapter
    Dim comando As SqlCommand
    Dim tb As DataTable
    Dim saldo, temp As Double
    Dim i As Integer
    Public activo As Boolean = False
    Private talonario As Short = 2

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Try

            Dim rep As New resumen_cta

            Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

            txt = rep.Section2.ReportObjects.Item("fec_emi")
            txt.Text = Me.dt_fec_emi.Text

            txt1 = rep.Section2.ReportObjects.Item("fec_fin")
            txt1.Text = Me.dt_fec_hasta.Text

            txt2 = rep.Section2.ReportObjects.Item("nombre")
            txt2.Text = Me.lbl_cliente.Text

            saldo = calcula_Acumulado()

            llena_tabla()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

            rep.SetParameterValue("saldo", saldo)

            rep.RecordSelectionFormula = "{Temp_historico_ctacte.fec} >= date('" & Me.dt_fec_emi.Text & "') and {Temp_historico_ctacte.fec} <= date('" & Me.dt_fec_hasta.Text & "') and {Temp_historico_ctacte.id_cli} = " & RTrim(Me.txt_codigo.Text) & " and {Temp_historico_ctacte.talon} = " & RTrim(Me.talonario) & ""

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            'Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

            barra_carga.Timer1.Enabled = True

        Catch ex As Exception

            MessageBox.Show("No hay datos para mostrar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Private Sub llena_tabla()

        tb = New DataTable
        tb.Clear()

        conex = conecta()

        'coman = New SqlDataAdapter("SELECT     dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
        '                          "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, CASE dbo.Recibo_cab.talon WHEN 1 THEN 1 WHEN 2 THEN 2 ELSE 2 END AS talon " & _
        '                          "FROM         dbo.cta_cte_hist LEFT OUTER JOIN " & _
        '                          "dbo.fact_cab ON dbo.cta_cte_hist.fec = dbo.fact_cab.fec_emision AND dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact AND " & _
        '                          "dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 LEFT OUTER JOIN " & _
        '                          "dbo.recibo_cab ON dbo.cta_cte_hist.fec = dbo.recibo_cab.fec_emi AND dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc AND " & _
        '                          "dbo.cta_cte_hist.lt = dbo.recibo_cab.letra And dbo.cta_cte_hist.pre = dbo.recibo_cab.pre And dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
        '                          "WHERE     dbo.cta_cte_hist.tc = 'RC' and dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.Recibo_cab.talon = '" & Trim(talonario) & "'" & _
        '                          "GROUP BY dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
        '                          "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, dbo.recibo_cab.talon, dbo.fact_cab.talon " & _
        '                          "UNION " & _
        '                          "SELECT     dbo.cta_cte01.fecha_emi, dbo.cta_cte01.tc, dbo.cta_cte01.lt, dbo.cta_cte01.pre, dbo.cta_cte01.num_fact, dbo.cta_cte01.debito, dbo.cta_cte01.credito, dbo.cta_cte01.estado, dbo.cta_cte01.id_cli, " & _
        '                          "dbo.cta_cte01.cli, dbo.cta_cte01.pre " & _
        '                          "FROM         dbo.cta_cte01 " & _
        '                          "WHERE     dbo.cta_cte01.tc = 'RA' and dbo.cta_cte01.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.cta_cte01.pre = '" & Trim(talonario) & "' " & _
        '                          "GROUP BY dbo.cta_cte01.fecha_emi, dbo.cta_cte01.tc, dbo.cta_cte01.lt, dbo.cta_cte01.pre, dbo.cta_cte01.num_fact, dbo.cta_cte01.debito, dbo.cta_cte01.credito, dbo.cta_cte01.estado, dbo.cta_cte01.id_cli, " & _
        '                          "dbo.cta_cte01.cli, dbo.cta_cte01.pre " & _
        '                          "UNION " & _
        '                          "SELECT     dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
        '                          "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, CASE dbo.fact_cab.talon WHEN 1 THEN 1 WHEN 2 THEN 2 ELSE 2 END AS talon " & _
        '                          "FROM         dbo.cta_cte_hist LEFT OUTER JOIN " & _
        '                          "dbo.fact_cab ON dbo.cta_cte_hist.fec = dbo.fact_cab.fec_emision AND dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact AND " & _
        '                          "dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 LEFT OUTER JOIN " & _
        '                          "dbo.recibo_cab ON dbo.cta_cte_hist.fec = dbo.recibo_cab.fec_emi AND dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc AND " & _
        '                          "dbo.cta_cte_hist.lt = dbo.recibo_cab.letra AND dbo.cta_cte_hist.pre = dbo.recibo_cab.pre AND dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
        '                          "WHERE     (dbo.cta_cte_hist.tc = 'FC' OR " & _
        '                          "dbo.cta_cte_hist.tc = 'NC' OR " & _
        '                          "dbo.cta_cte_hist.tc = 'ND') and dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.fact_cab.talon = '" & Trim(talonario) & "'" & _
        '                          "GROUP BY dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
        '                          "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, dbo.recibo_cab.talon, dbo.fact_cab.talon", conex)

        coman = New SqlDataAdapter("SELECT     dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, CASE dbo.Recibo_cab.talon WHEN 1 THEN 1 WHEN 2 THEN 2 ELSE 2 END AS talon " & _
                                   "FROM         dbo.cta_cte_hist LEFT OUTER JOIN " & _
                                   "dbo.fact_cab ON dbo.cta_cte_hist.fec = dbo.fact_cab.fec_emision AND dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 LEFT OUTER JOIN " & _
                                   "dbo.recibo_cab ON dbo.cta_cte_hist.fec = dbo.recibo_cab.fec_emi AND dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.recibo_cab.letra And dbo.cta_cte_hist.pre = dbo.recibo_cab.pre And dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
                                   "WHERE     dbo.cta_cte_hist.tc = 'RC' and dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.Recibo_cab.talon = '" & Trim(talonario) & "'" & _
                                   "GROUP BY dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, dbo.recibo_cab.talon, dbo.fact_cab.talon " & _
                                   "UNION " & _
                                   "SELECT     dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, CASE dbo.fact_cab.talon WHEN 1 THEN 1 WHEN 2 THEN 2 ELSE 2 END AS talon " & _
                                   "FROM         dbo.cta_cte_hist LEFT OUTER JOIN " & _
                                   "dbo.fact_cab ON dbo.cta_cte_hist.fec = dbo.fact_cab.fec_emision AND dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 LEFT OUTER JOIN " & _
                                   "dbo.recibo_cab ON dbo.cta_cte_hist.fec = dbo.recibo_cab.fec_emi AND dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.recibo_cab.letra AND dbo.cta_cte_hist.pre = dbo.recibo_cab.pre AND dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
                                   "WHERE     (dbo.cta_cte_hist.tc = 'FC' OR " & _
                                   "dbo.cta_cte_hist.tc = 'NC' OR " & _
                                   "dbo.cta_cte_hist.tc = 'ND') and dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.fact_cab.talon = '" & Trim(talonario) & "'" & _
                                   "GROUP BY dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, dbo.recibo_cab.talon, dbo.fact_cab.talon", conex)

        coman.Fill(tb)
        coman.Dispose()

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        comando = New SqlCommand("DELETE FROM Temp_historico_ctacte", conex)
        comando.ExecuteNonQuery()
        comando.Dispose()

        For i = 0 To tb.Rows.Count - 1

            comando = New SqlCommand("INSERT INTO Temp_historico_ctacte (fec,tc,lt,pre,num,debito,credito,estado,id_cli,cli,talon,acum) values ('" & Trim(tb.Rows(i).Item(0)) & "','" & Trim(tb.Rows(i).Item(1)) & "','" & Trim(tb.Rows(i).Item(2)) & "','" & Trim(tb.Rows(i).Item(3)) & "','" & Trim(tb.Rows(i).Item(4)) & "','" & Trim(tb.Rows(i).Item(5)) & "','" & Trim(tb.Rows(i).Item(6)) & "','" & Trim(tb.Rows(i).Item(7)) & "','" & Trim(tb.Rows(i).Item(8)) & "','" & Trim(tb.Rows(i).Item(9)) & "','" & Trim(tb.Rows(i).Item(10)) & "',0)", conex)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Next

        If conex.State = ConnectionState.Open Then conex.Close()

        tb.Dispose()

    End Sub

    Private Function calcula_Acumulado() As Double

        tb = New DataTable
        tb.Clear()

        conex = conecta()

        coman = New SqlDataAdapter("SELECT ROUND(C1.TOT_FAC + C2.TOT_REC,2,0) FROM" & _
                    " (SELECT ISNULL(sum(dbo.cta_cte_hist.debito - dbo.cta_cte_hist.credito ),0) AS TOT_FAC  " & _
                    " FROM dbo.cta_cte_HIST inner join fact_cab " & _
                    " ON dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli " & _
                 " AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact " & _
                 " AND dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact " & _
                 " AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact " & _
                 " AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 " & _
                    " WHERE " & _
                    " dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' And dbo.fact_cab.talon = '" & talonario & "' and dbo.cta_cte_hist.fec < '" & Me.dt_fec_emi.Text & "' ) AS C1, " & _
                    " (SELECT    ISNULL(sum(dbo.cta_cte_hist.debito - dbo.cta_cte_hist.credito),0)  AS TOT_REC " & _
                    " FROM         dbo.cta_cte_HIST inner join dbo.recibo_cab " & _
                    " ON dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli " & _
                 " AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc " & _
                 " AND dbo.cta_cte_hist.lt = dbo.recibo_cab.letra " & _
                 " AND dbo.cta_cte_hist.pre = dbo.recibo_cab.pre " & _
                 " AND dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
                    " WHERE " & _
                    " dbo.cta_cte_hist.id_cli = '" & Trim(Me.txt_codigo.Text) & "' and dbo.recibo_cab.talon = '" & talonario & "' and dbo.cta_cte_hist.fec < '" & Me.dt_fec_emi.Text & "' ) AS C2 ", conex)

        coman.Fill(tb)
        coman.Dispose()

        If tb.Rows(0).Item(0).ToString <> "" Then
            temp = tb.Rows(0).Item(0)
        Else
            temp = 0
        End If

        tb.Dispose()

        Return temp

    End Function

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then
            activo = False
            busc_cliente.Show()
        End If
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            activo = False
            cli.insruccion = "select id_cli,nombre from cli_01 where id_cli like '" & RTrim(Me.txt_codigo.Text) & "'"
            cli.cargar_registro()
            activo = True
            If cli.verifica = False Then
                Me.lbl_cliente.Text = ""
            End If
        End If

    End Sub

    Private Sub Form_resumen_cta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_estado_form.Text = 1
    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
            talonario = 1
        Else
            Me.Check_talonario.BackColor = Color.Black
            talonario = 2
        End If
    End Sub

    Private Sub dt_fec_emi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_emi.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_hasta.Focus()
        End If
    End Sub

    Private Sub dt_fec_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_hasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_aceptar.Focus()
        End If
    End Sub
End Class