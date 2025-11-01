Imports System.Data
Imports System.Data.SqlClient

Public Class Form_variacion_precios

    Dim reporte As New pymsoft.reporte
    Dim rep As New cambio_precios

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim coman As SqlCommand
    Dim tb As New DataTable
    Dim i As Integer
    Dim x As String

    Private Sub Form_variacion_precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim var1 As Double, suma As Double

        Me.txt_estado_form.Text = 1

        tb.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select id_art,detalle,precio,precio_nuevo,variacion from precio_01", conex)
        comando.Fill(tb)
        comando.Dispose()

        Me.DataGridView1.Columns.Add("Codigo", "Codigo")
        Me.DataGridView1.Columns.Add("Descripcion", "Descripcion")
        Me.DataGridView1.Columns.Add("Precio viejo", "Precio viejo")
        Me.DataGridView1.Columns.Add("Precio nuevo", "Precio nuevo")
        Me.DataGridView1.Columns.Add(" $ Var", " $ Var")
        Me.DataGridView1.Columns.Add(" % Var", " % Var")

        Me.DataGridView1.Columns(0).Width = 90
        Me.DataGridView1.Columns(1).Width = 300
        Me.DataGridView1.Columns(2).Width = 90
        Me.DataGridView1.Columns(3).Width = 90
        Me.DataGridView1.Columns(5).Width = 70

        For i = 0 To tb.Rows.Count - 1

            Me.DataGridView1.Rows.Add()

            Me.DataGridView1.Rows(i).Cells(0).Value = tb.Rows(i).Item(0)
            Me.DataGridView1.Rows(i).Cells(1).Value = tb.Rows(i).Item(1)
            Me.DataGridView1.Rows(i).Cells(2).Value = tb.Rows(i).Item(2)
            Me.DataGridView1.Rows(i).Cells(3).Value = tb.Rows(i).Item(3)
            Me.DataGridView1.Rows(i).Cells(4).Value = tb.Rows(i).Item(4)

            var1 = Format((tb.Rows(i).Item(4) / tb.Rows(i).Item(2)) * 100, "0.00")
            suma = suma + var1
            Me.DataGridView1.Rows(i).Cells(5).Value = var1 & "%"

        Next

        Dim x As Integer = Me.DataGridView1.Rows.Count - 1
        Me.lbl_total.Text = Format(suma / x, "0.00") & "%"

        Me.DataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.LightGreen
        Me.DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.LightSalmon
        Me.DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.LightBlue
        Me.DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.LightCyan

    End Sub

    Private Sub Tool_imprime1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_imprime1.Click

        x = reporte.carga_datos("cambio_precios")

        If x = "cambio_precios" Then
            rep = New cambio_precios
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, "")

        If x = "0" Then
            MessageBox.Show("No existe el reporte..Verifique", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            barra_carga.Enabled = True
            Exit Sub
        End If

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub tool_vista1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_vista1.Click

        x = reporte.carga_datos("cambio_precios")

        If x = "cambio_precios" Then
            rep = New cambio_precios
        End If

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, "")

        If x = "0" Then
            MessageBox.Show("No existe el reporte..Verifique", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            barra_carga.Enabled = True
            Exit Sub
        End If

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub Tool_exporta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_exporta1.Click

        Form_exporta.Show()

    End Sub

    Private Sub Tool_borra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_borra.Click

        Dim x As Integer = MessageBox.Show("Esta seguro que desea borrar la variacion de precios ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x <> 7 Then

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("delete precio_01", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then conex.Close()

            Me.Close()

        End If

    End Sub
End Class