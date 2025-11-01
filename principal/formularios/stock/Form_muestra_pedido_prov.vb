Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_pedido_prov

    Public pos As Integer
    Dim coman As SqlCommand
    Dim conex As New SqlConnection

    Dim rep As New stock_pedido_positivo

    Private Sub Form_muestra_pedido_prov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                Form_cantidad.lbl_nombre.Text = Me.DataGridView1.SelectedCells(0).Value
                pos = Me.DataGridView1.CurrentCell.RowIndex
                Form_cantidad.Show()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_exporta.Show()
    End Sub

    Private Sub Toolgraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolgraba.Click


        Dim a As Integer = MessageBox.Show("Esto sobreescribira cualquier pedido de este proveedor guardado: Desea continuar ??", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim i As Integer
            Dim suma As Double

            coman = New SqlCommand("DELETE pedido_01 where id_prov = '" & RTrim(Form_pedido_proveedor.txt_cod_prov.Text) & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                If Me.DataGridView1.Rows(i).Cells(3).Value <> Nothing Then

                    coman = New SqlCommand("Insert into pedido_01(nombre,cantidad,proveedor,fec_emi,fec_hasta,id_prov,rubro,costo) values ('" & Me.DataGridView1.Rows(i).Cells(0).Value & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Form_pedido_proveedor.cmb_prove.Text & "','" & Form_pedido_proveedor.dt_fec_desde.Text & "','" & Form_pedido_proveedor.dt_fec_hasta.Text & "','" & Form_pedido_proveedor.txt_cod_prov.Text & "','" & Me.DataGridView1.Rows(i).Cells(4).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "')", conex)
                    coman.ExecuteNonQuery()

                    If Me.DataGridView1.Item(5, i).Style.ForeColor = Color.Red Then
                        suma = Format(suma + Me.DataGridView1.Rows(i).Cells(5).Value, "0.000")
                    End If

                    coman.Dispose()

                End If

            Next

            Me.txt_comentario.Text = Me.txt_comentario.Text & "     " & "Costo Total: $" & "  " & suma
            conex.Close()

        End If

    End Sub

    Private Sub toolvista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolvista.Click

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        rep.RecordSelectionFormula = "{pedido_01.fec_emi} >= date('" & Form_pedido_proveedor.dt_fec_desde.Text & "') and {pedido_01.fec_emi} <= date('" & Form_pedido_proveedor.dt_fec_hasta.Text & "') and {pedido_01.proveedor} = '" & RTrim(Form_pedido_proveedor.cmb_prove.Text) & "'"

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

    End Sub

    Private Sub Toolimprime_copia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolimprime_copia.Click

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        If Form_pedido_proveedor.cmb_ordena.Text = "Alfabeticamente" Then

            rep.RecordSelectionFormula = "{pedido_01.fec_emi} >= date('" & Form_pedido_proveedor.dt_fec_desde.Text & "') and {pedido_01.fec_emi} <= date('" & Form_pedido_proveedor.dt_fec_hasta.Text & "') and {pedido_01.proveedor} ='" & RTrim(Form_pedido_proveedor.cmb_prove.Text) & "'"

        End If


        If Form_pedido_proveedor.cmb_ordena.Text = "Codigo" Then

            rep.RecordSelectionFormula = "{pedido_01.fec_emi} >= date('" & Form_pedido_proveedor.dt_fec_desde.Text & "') and {pedido_01.fec_emi} <= date('" & Form_pedido_proveedor.dt_fec_hasta.Text & "') and {pedido_01.proveedor} = '" & RTrim(Form_pedido_proveedor.cmb_prove.Text) & "'"

        End If

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

    End Sub
End Class