Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_rem_cli

    Dim comando As SqlDataAdapter
    Dim comando1 As SqlCommand
    Dim conex As New SqlConnection
    Dim midataset As New DataSet


    Private Sub Form_muestra_rem_cli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim val, val1, re, rs, saldo As Double

        Me.DataGridView1.Columns.Add("Tc", "TC")
        Me.DataGridView1.Columns.Add("Lt", "Lt")
        Me.DataGridView1.Columns.Add("Pre", "Pre")
        Me.DataGridView1.Columns.Add("Numero", "Numero")
        Me.DataGridView1.Columns.Add("Fecha", "Fecha")
        Me.DataGridView1.Columns.Add("RE", "Entrada")
        Me.DataGridView1.Columns.Add("RS", "Salida")
        Me.DataGridView1.Columns.Add("Saldo", "Saldo")

        Me.DataGridView1.Columns(0).Width = 40
        Me.DataGridView1.Columns(1).Width = 40
        Me.DataGridView1.Columns(2).Width = 40
        Me.DataGridView1.Columns(3).Width = 80
        Me.DataGridView1.Columns(4).Width = 80
        Me.DataGridView1.Columns(5).Width = 100
        Me.DataGridView1.Columns(6).Width = 100
        Me.DataGridView1.Columns(7).Width = 100

        Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        For i = 0 To Form_consulta_rem_cli.tbl.Rows.Count - 1

            If RTrim(Form_consulta_rem_cli.tbl.Rows(i).Item(0)) = "RE" Then

                Me.DataGridView1.Rows.Add()

                Me.DataGridView1.Rows(i).Cells(0).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(0)
                Me.DataGridView1.Rows(i).Cells(1).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(1)
                Me.DataGridView1.Rows(i).Cells(2).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(2)
                Me.DataGridView1.Rows(i).Cells(3).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(3)
                Me.DataGridView1.Rows(i).Cells(4).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(4)
                Me.DataGridView1.Rows(i).Cells(5).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(5)

                val1 = Me.DataGridView1.Rows(i).Cells(5).Value

                Me.DataGridView1.Rows(i).Cells(7).Value = val + val1
                val = Me.DataGridView1.Rows(i).Cells(7).Value
                saldo = val

                re = re + Me.DataGridView1.Rows(i).Cells(5).Value

            End If

            If RTrim(Form_consulta_rem_cli.tbl.Rows(i).Item(0)) = "RS" Then

                Me.DataGridView1.Rows.Add()

                Me.DataGridView1.Rows(i).Cells(0).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(0)
                Me.DataGridView1.Rows(i).Cells(1).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(1)
                Me.DataGridView1.Rows(i).Cells(2).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(2)
                Me.DataGridView1.Rows(i).Cells(3).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(3)
                Me.DataGridView1.Rows(i).Cells(4).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(4)
                Me.DataGridView1.Rows(i).Cells(4).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(4)
                Me.DataGridView1.Rows(i).Cells(6).Value = Form_consulta_rem_cli.tbl.Rows(i).Item(5)

                val1 = Me.DataGridView1.Rows(i).Cells(6).Value

                Me.DataGridView1.Rows(i).Cells(7).Value = val - val1
                val = Me.DataGridView1.Rows(i).Cells(7).Value
                saldo = val

                rs = rs + Me.DataGridView1.Rows(i).Cells(6).Value

            End If

        Next

        Me.DataGridView1.Rows.Add()
        Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
        Me.DataGridView1.Rows(i).Cells(7).Value = saldo
        Me.DataGridView1.Rows(i).Cells(5).Value = re
        Me.DataGridView1.Rows(i).Cells(6).Value = rs

        Me.txt_comentario.Text = "Cliente:" & "  " & Form_consulta_rem_cli.txt_codigo.Text & " - " & "   " & Form_consulta_rem_cli.lbl_cliente.Text & vbCrLf & "Fecha Desde:" & "   " & Form_consulta_rem_cli.dt_fec_hasta.Text & "   " & "Fecha Hasta:" & "  " & Form_consulta_rem_cli.dt_fec_hasta.Text & vbCrLf & "Filtro:" & "   " & Form_consulta_rem_cli.cmb_filtro.Text & vbCrLf & "Agrupacion:" & "  " & Form_consulta_rem_cli.cmb_agrupacion.Text & vbCrLf & "Saldo Acumulado:" & "  " & saldo

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                midataset.Clear()
                conex = conecta()

                comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,total1,descuento,iva_inscripto,imp_interno,exento1 from fact_det where fact_det.letra_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_det.num_fact = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_det.tipo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and fact_det.fec_emi = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_det.prefijo_fact2= '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' ", conex)
                comando.Fill(midataset, "fact_det")

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("fact_det")

                comando1 = New SqlCommand("select sub_total,exento,iva_ins,iva_10,imp_interno1,total,descuento from fact_tot inner join fact_cab on fact_tot.num_factura = '" & Me.DataGridView1.SelectedCells(3).Value & "' and fact_tot.tipo_factura = '" & Me.DataGridView1.SelectedCells(0).Value & "' and fact_tot.letra = '" & Me.DataGridView1.SelectedCells(1).Value & "' and fact_tot.pref = '" & Me.DataGridView1.SelectedCells(2).Value & "' and fact_tot.fecha_emision1 = '" & Me.DataGridView1.SelectedCells(4).Value & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader As SqlDataReader = comando1.ExecuteReader

                reader.Read()

                Form_muestra_factura.txt_gravado.Text = reader("Sub_total")
                Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
                Form_muestra_factura.txt_exento.Text = reader("exento")
                Form_muestra_factura.txt_no_inscripto.Text = reader("iva_10")
                Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno1")
                Form_muestra_factura.txt_total_grilla.Text = reader("total")

                reader.Close()
                conex.Close()

                comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_cab.fec_emision= '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_cab.letra_fact= '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_cab.tipo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader = comando1.ExecuteReader
                reader.Read()

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & "   -   " & "Lista:" & " " & reader("lista") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                Form_muestra_factura.txt_tipo.Text = reader("tipo_fact")
                Form_muestra_factura.txt_letra.Text = reader("letra_fact")
                Form_muestra_factura.txt_prefijo.Text = reader("prefijo_fact")
                Form_muestra_factura.txt_numero.Text = reader("num_fact1")
                Form_muestra_factura.txt_estado_fact.Text = reader("estado_fact")

                reader.Close()

                Form_muestra_factura.Show()

            End If

        Catch ex As Exception
            MessageBox.Show("No hay datos para Mostrar", "PyM soft", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
End Class
