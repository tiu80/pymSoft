Imports System.Data.SqlClient
Imports System.Data

Public Class Form_consulta_art_sinstock

    Dim art As New pymsoft.articulo
    Dim fact As New pymsoft.factura
    Dim reporte As New pymsoft.reporte
    Dim tbl As New DataTable, tbl1 As New DataTable, tbl2 As New DataTable
    Dim comando1 As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim coman As SqlCommand

    Private Sub Form_consulta_art_sinstock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        conex = conecta()
        tbl2.Clear()

        comando1 = New SqlDataAdapter("select detalle,sum(cantidad1),codi_producto as cantidad1 from fact_det where fact_det.tipo_fact2 = 'PD' and fact_det.cantidad_sin_stock = 'SI' group by detalle,codi_producto", conex)
        comando1.Fill(tbl2)

        Me.DataGridView1.DataSource = tbl2

        Me.DataGridView1.Columns(0).Width = 450
        Me.DataGridView1.Columns(1).Width = 130
        Me.DataGridView1.Columns(2).Visible = False

        Me.DataGridView1.Columns(0).HeaderText = "NOMBRE"
        Me.DataGridView1.Columns(1).HeaderText = "CANTIDAD"
        Me.DataGridView1.Columns(0).DefaultCellStyle.BackColor = Color.LightGreen
        Me.DataGridView1.Columns(1).DefaultCellStyle.BackColor = Color.LightSalmon

        Me.Text = Me.Text & "    -    " & "Fecha Desde:" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "   " & "Hasta:" & "  " & Form_consulta_comprobante.dt_fec_fin.Text

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                Me.lbl_articulo.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.lbl_id_art.Text = Me.DataGridView1.SelectedCells(2).Value
                Call busca_en_pedido()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub busca_en_pedido()

        conex = conecta()
        tbl1.Clear()

        comando1 = New SqlDataAdapter("select fec_emision,tipo_fact,letra_fact,prefijo_fact,num_fact1,nombre,cantidad1,talon1 from fact_cab inner join fact_det on fact_cab.num_fact1 = fact_det.num_fact and fact_cab.letra_fact = fact_det.letra_fact1 and fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.prefijo_fact = fact_det.prefijo_fact2 and fact_det.nom_producto = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and fact_det.tipo_fact2 = 'PD' and fact_det.cantidad_sin_stock = 'SI'", conex)
        comando1.Fill(tbl1)

        Me.DataGridView2.DataSource = tbl1

        Me.DataGridView2.Columns(0).Width = 80
        Me.DataGridView2.Columns(1).Width = 60
        Me.DataGridView2.Columns(2).Width = 60
        Me.DataGridView2.Columns(3).Width = 60
        Me.DataGridView2.Columns(4).Width = 80
        Me.DataGridView2.Columns(5).Width = 300
        Me.DataGridView2.Columns(6).Width = 100

        Me.DataGridView2.Columns(7).Visible = False

        Me.DataGridView2.Columns(0).HeaderText = "FECHA"
        Me.DataGridView2.Columns(1).HeaderText = "TC"
        Me.DataGridView2.Columns(2).HeaderText = "LT"
        Me.DataGridView2.Columns(3).HeaderText = "PRE"
        Me.DataGridView2.Columns(4).HeaderText = "NUMERO"
        Me.DataGridView2.Columns(5).HeaderText = "NOMBRE"
        Me.DataGridView2.Columns(6).HeaderText = "CANTIDAD"

        Me.DataGridView2.Columns(6).DefaultCellStyle.BackColor = Color.LightSalmon

    End Sub

    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown

        Try

            If e.KeyCode = Keys.Delete Then

                Dim x As Integer = MessageBox.Show("Esta seguro que quiere borrar el Articulo!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

                If x = 6 Then

                    conex = conecta()
                    If conex.State = ConnectionState.Closed Then conex.Open()

                    coman = New SqlCommand("delete from fact_det where codi_producto= '" & RTrim(Me.lbl_id_art.Text) & "' and num_fact = '" & RTrim(Me.DataGridView2.SelectedCells(4).Value) & "' and tipo_fact2 = '" & RTrim(Me.DataGridView2.SelectedCells(1).Value) & "' and prefijo_fact2 = '" & RTrim(Me.DataGridView2.SelectedCells(3).Value) & "' and letra_fact1 = '" & RTrim(Me.DataGridView2.SelectedCells(2).Value) & "' and talon1 = '" & RTrim(Me.DataGridView2.SelectedCells(6).Value) & "'", conex)
                    coman.ExecuteNonQuery()

                    Me.DataGridView2.Rows.Remove(Me.DataGridView2.SelectedRows(0))

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tool_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_imprime.Click

        Dim rep As Object = Nothing
        Dim x As String
        Dim PrinterSettings As New System.Drawing.Printing.PrinterSettings()
        Dim PageSettings As New System.Drawing.Printing.PageSettings(PrinterSettings)
        Dim pd As New PrintDialog

        x = reporte.carga_datos("art_sin_stock")

        If x = "art_sin_stock" Then
            rep = New art_sin_stock
        End If

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper

        rep.PrintOptions.CopyTo(PrinterSettings, PageSettings)
        pd.PrinterSettings = PrinterSettings
        pd.AllowSomePages = True
        pd.AllowSelection = True

        If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

            rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

        End If

    End Sub

    Private Sub tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_exporta.Click
        Form_exporta.Show()
    End Sub

End Class