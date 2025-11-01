Imports System.Data
Imports System.Data.SqlClient

Public Class Form_concilia_saldos_ctacte_historico

    Dim comando As SqlDataAdapter
    Dim tb, tb_ctacte, tb_resumen As New DataTable
    Dim conex As New SqlConnection
    Dim i, j, x, talon As Integer
    Dim ant, total, total_fila_ctacte, total_fila_resumen As Double

    Private Sub Form_concilia_saldos_ctacte_historico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form_repcta_cte.Check_talonario.Checked = True Then
            talon = 1
        Else
            talon = 2
        End If

        tb.Clear()
        tb_ctacte.Clear()
        tb_resumen.Clear()

        conex = conecta()
        comando = New SqlDataAdapter("select distinct id_cli,cli from cta_cte01", conex)
        comando.Fill(tb)
        comando.Dispose()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        For i = 0 To tb.Rows.Count - 1

            selecciona_saldo_cta_cte(tb.Rows(i).Item(0))
            selecciona_saldo_resumencta(tb.Rows(i).Item(0))

            If total_fila_ctacte <> total_fila_resumen Then

                Me.DataGridView1.Rows.Add()
                Me.DataGridView1.Rows(x).Cells(0).Value = tb.Rows(i).Item(0)
                Me.DataGridView1.Rows(x).Cells(1).Value = tb.Rows(i).Item(1)
                Me.DataGridView1.Rows(x).Cells(2).Value = total_fila_ctacte
                Me.DataGridView1.Rows(x).Cells(3).Value = total_fila_resumen
                Me.DataGridView1.Rows(x).Cells(4).Value = Format(Me.DataGridView1.Rows(x).Cells(2).Value - Me.DataGridView1.Rows(x).Cells(3).Value, "0.00")

                x = x + 1

            End If

            total_fila_ctacte = 0
            total_fila_resumen = 0

            barra_carga.Refresh()

        Next

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub selecciona_saldo_resumencta(ByVal idcli As String)

        tb_resumen.Clear()

        comando = New SqlDataAdapter("SELECT     dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, CASE dbo.Recibo_cab.talon WHEN 1 THEN 1 WHEN 2 THEN 2 ELSE 2 END AS talon " & _
                                   "FROM         dbo.cta_cte_hist LEFT OUTER JOIN " & _
                                   "dbo.fact_cab ON dbo.cta_cte_hist.fec = dbo.fact_cab.fec_emision AND dbo.cta_cte_hist.id_cli = dbo.fact_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.fact_cab.tipo_fact AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.fact_cab.letra_fact AND dbo.cta_cte_hist.pre = dbo.fact_cab.prefijo_fact AND dbo.cta_cte_hist.num = dbo.fact_cab.num_fact1 LEFT OUTER JOIN " & _
                                   "dbo.recibo_cab ON dbo.cta_cte_hist.fec = dbo.recibo_cab.fec_emi AND dbo.cta_cte_hist.id_cli = dbo.recibo_cab.id_cli AND dbo.cta_cte_hist.tc = dbo.recibo_cab.tc AND " & _
                                   "dbo.cta_cte_hist.lt = dbo.recibo_cab.letra And dbo.cta_cte_hist.pre = dbo.recibo_cab.pre And dbo.cta_cte_hist.num = dbo.recibo_cab.id_rec " & _
                                   "WHERE     dbo.cta_cte_hist.tc = 'RC' and dbo.cta_cte_hist.id_cli = '" & Trim(idcli) & "' and dbo.Recibo_cab.talon = '" & Trim(talon) & "'" & _
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
                                   "dbo.cta_cte_hist.tc = 'ND') and dbo.cta_cte_hist.id_cli = '" & Trim(idcli) & "' and dbo.fact_cab.talon = '" & Trim(talon) & "'" & _
                                   "GROUP BY dbo.cta_cte_hist.fec, dbo.cta_cte_hist.tc, dbo.cta_cte_hist.lt, dbo.cta_cte_hist.pre, dbo.cta_cte_hist.num, dbo.cta_cte_hist.debito, dbo.cta_cte_hist.credito, dbo.cta_cte_hist.estado, " & _
                                   "dbo.cta_cte_hist.id_cli, dbo.cta_cte_hist.cli, dbo.recibo_cab.talon, dbo.fact_cab.talon", conex)

        comando.Fill(tb_resumen)
        comando.Dispose()

        total = 0

        For j = 0 To tb_resumen.Rows.Count - 1

            If RTrim(tb_resumen.Rows(j).Item(1)) = "FC" Or RTrim(tb_resumen.Rows(j).Item(1)) = "ND" Then

                total = Format(total + tb_resumen.Rows(j).Item(5), "0.00")

            Else

                total = Format(total - tb_resumen.Rows(j).Item(6), "0.00")

            End If

        Next

        total_fila_resumen = total

    End Sub

    Private Sub selecciona_saldo_cta_cte(ByVal idcli As String)

        tb_ctacte.Clear()

        comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0 from cta_cte01 as C where C.id_cli = '" & RTrim(idcli) & "' and C.fecha_emi >= '01-01-2000' and C.fecha_emi <= '31-12-2050' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num_fact = F.num_fact1 and C.id_cli = F.id_cli)= '" & talon & "' or (select R.talon from Recibo_cab as R where C.tc = R.tc and C.lt = R.letra and C.pre = R.pre and C.num_fact = R.id_rec and C.id_cli = R.id_cli)= '" & talon & "' or (C.tc='RA' and C.pre = '" & Trim(talon) & "' and C.id_cli = '" & RTrim(idcli) & "') order by C.fecha_emi,C.tc", conex)
        comando.Fill(tb_ctacte)
        comando.Dispose()

        total = 0

        For j = 0 To tb_ctacte.Rows.Count - 1

            If RTrim(tb_ctacte.Rows(j).Item(1)) = "FC" Or RTrim(tb_ctacte.Rows(j).Item(1)) = "ND" Then

                total = Format(total + tb_ctacte.Rows(j).Item(6), "0.00")

            Else

                total = Format(total - tb_ctacte.Rows(j).Item(7), "0.00")

            End If

        Next

        total_fila_ctacte = total

    End Sub

End Class