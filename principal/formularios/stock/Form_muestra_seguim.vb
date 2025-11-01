Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_seguim

    Dim conex As New SqlConnection
    Dim tabla As New DataTable, tabla1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim midataset As New DataSet
    Dim comando1 As SqlCommand
    Dim valor As Single
    Dim i As Integer

    Private Sub Form_muestra_seguim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1
        Call carga_cabecera()

    End Sub

    Public Sub mostrar()

        Try

            midataset.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,total1,descuento,iva_inscripto,imp_interno,exento1,val_uni_sec from fact_det where fact_det.prefijo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_det.letra_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_det.num_fact = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_det.tipo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and fact_det.fec_emi = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_det.talon1 = '" & Me.DataGridView1.SelectedCells(8).Value & "' ", conex)
            comando.Fill(midataset, "fact_det")

            Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("fact_det")

            comando1 = New SqlCommand("select sub_total,exento,iva_ins,iva_10,imp_interno1,total,descuento from fact_tot inner join fact_cab on fact_tot.num_factura = '" & Me.DataGridView1.SelectedCells(3).Value & "' and fact_tot.tipo_factura = '" & Me.DataGridView1.SelectedCells(0).Value & "' and fact_tot.letra= '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_tot.pref= '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando1.ExecuteReader

            reader.Read()

            Form_muestra_factura.txt_gravado.Text = reader("Sub_total")
            Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
            Form_muestra_factura.txt_exento.Text = reader("exento")
            Form_muestra_factura.txt_no_inscripto.Text = reader("iva_10")
            Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno1")
            Form_muestra_factura.txt_total_grilla.Text = reader("total")
            valor = reader("descuento")

            reader.Close()
            conex.Close()

            comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_cab.fec_emision= '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_cab.letra_fact= '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_cab.tipo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "'and fact_cab.prefijo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            reader = comando1.ExecuteReader
            reader.Read()

            Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & vbCrLf & "Descuento Total Factura:" & "   " & valor & "%" & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

            Form_muestra_factura.txt_tipo.Text = reader("tipo_fact")
            Form_muestra_factura.txt_letra.Text = reader("letra_fact")
            Form_muestra_factura.txt_prefijo.Text = reader("prefijo_fact")
            Form_muestra_factura.txt_numero.Text = reader("num_fact1")
            Form_muestra_factura.txt_estado_fact.Text = reader("estado_fact")

            reader.Close()

            Form_muestra_factura.Show()

        Catch ex As Exception

            MessageBox.Show("No hay Datos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        Finally

            conex.Close()
            midataset.Dispose()

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            Call mostrar()
        End If

    End Sub

    Public Sub calcula_acumulado()

        Dim i As Integer
        Dim acu As Single = Form_seguimiento_art.corte

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RS" Or RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "PD" Or RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "ND" Then

                If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RS" Then
                    Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If

                acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                Me.DataGridView1.Rows(i).Cells(9).Value = acu

                If RTrim(Me.DataGridView1.Rows(i).Cells(7).Value) = "Anulado" Then

                    acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                    Me.DataGridView1.Rows(i).Cells(9).Value = acu
                    Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.LightGray

                End If

            End If

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RE" Then

                If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RE" Then
                    Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                End If

                acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                Me.DataGridView1.Rows(i).Cells(9).Value = acu

                If RTrim(Me.DataGridView1.Rows(i).Cells(7).Value) = "Anulado" Then

                    acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                    Me.DataGridView1.Rows(i).Cells(9).Value = acu
                    Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.LightGray

                End If

            End If

        Next

    End Sub

    Private Sub carga_cabecera()

        Try

            Me.DataGridView1.Columns.Add("acu", "Acumulado")
            Me.DataGridView1.Columns(0).Width = 35
            Me.DataGridView1.Columns(1).Width = 35
            Me.DataGridView1.Columns(2).Width = 35
            Me.DataGridView1.Columns(3).Width = 80
            Me.DataGridView1.Columns(4).Width = 80
            Me.DataGridView1.Columns(5).Width = 300
            Me.DataGridView1.Columns(6).Width = 80
            Me.DataGridView1.Columns(7).Width = 80
            Me.DataGridView1.Columns(8).Width = 75

            Me.DataGridView1.Columns(0).HeaderText = "Tc"
            Me.DataGridView1.Columns(1).HeaderText = "Lt"
            Me.DataGridView1.Columns(2).HeaderText = "Pre"
            Me.DataGridView1.Columns(3).HeaderText = "numero"
            Me.DataGridView1.Columns(4).HeaderText = "Fecha"
            Me.DataGridView1.Columns(5).HeaderText = "Detalle"
            Me.DataGridView1.Columns(6).HeaderText = "Cantidad"
            Me.DataGridView1.Columns(7).HeaderText = "Estado"

            Me.DataGridView1.Columns(7).Visible = False
            Me.DataGridView1.Columns(8).Visible = False

            Call calcula_acumulado()
            barra_carga.Timer1.Enabled = True

            Dim a As Integer = Me.DataGridView1.Rows.Count - 2
            Me.DataGridView1.Rows(a).Cells(9).Style.BackColor = Color.Salmon

        Catch ex As Exception

        End Try

    End Sub

    Private Sub exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportar.Click
        Form_exporta.Show()
    End Sub

End Class