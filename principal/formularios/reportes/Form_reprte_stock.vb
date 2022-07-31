Imports System.Data
Imports System.Data.SqlClient

Public Class Form_reprte_stock

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl As New DataTable

    Private Sub Form_reprte_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        Me.cmb_estado.Text = Me.cmb_estado.Items(0)

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Try

            Dim rep As New stock_pedido_positivo
            conex = conecta()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            tbl.Clear()

            comando = New SqlDataAdapter("select nombre,cantidad,proveedor from fact_det inner join art_01 on fact_det.cod_prov = art_01.id_proveedor and fact_det.codi_producto = art_01.id_art and fact_det.detalle = art_01.nombre and fact_det.tipo_fact2 = fact_det.tipo_fact2 and fact_det.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_det.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' group by nombre,cantidad,proveedor", conex)
            comando.Fill(tbl)

            rep.SetDataSource(tbl)

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

            barra_carga.Timer1.Enabled = True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information, "Pym Soft")
            barra_carga.Timer1.Enabled = True
            Me.Close()

        Finally

            Me.Dispose()

        End Try

    End Sub

End Class