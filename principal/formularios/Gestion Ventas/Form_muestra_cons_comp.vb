Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_cons_comp

    Dim i As Integer = 0
    Dim acu As Single = 0
    Dim acu_posnet, acu_vale, acu_debito, acu_credito, acu_cheque As Single
    Dim valida As Boolean = True
    Dim valida1 As Boolean = True
    Public es_recibo As Boolean = True
    Dim conex As New SqlConnection
    Dim midataset1 As New DataSet
    Dim tbl As New DataTable, tbl1 As New DataTable
    Public tbl2 As New DataTable
    Dim comando As SqlDataAdapter
    Public recibo As Boolean = True
    Dim rep As New consulta_comp
    Dim estado_fact As Short = 0, estado_rec As Short = 0
    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim fact As New pymsoft.factura
    Public pos As Short = 0

    Private Sub Form_muestra_cons_comp_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Form_muestra_factura.Dispose()
    End Sub

    Private Sub Form_muestra_cons_comp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        Call carga_seleccion_cosulta()

        Me.txt_n_carga.Text = Form_consulta_comprobante.txt_n_carga.Text
        Form_muestra_factura.txt_verifica_anular_borrar.Text = 0
        conex = conecta()

        Me.txt_estado_form.Text = 1

        If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Presupuestos" Then

            Call carga_cabecera_presupuesto()

            Exit Sub

        End If

        If Me.recibo = True Then

            Call carga_cabecera_factura_pedido()

        Else

            Call carga_cabecera_recibo()

        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick

        Call mostrar()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            Call mostrar()

        End If

        If e.KeyCode = Keys.F3 Then

            Form_comentario.TextBox1.Text = Trim(Me.DataGridView1.SelectedCells.Item(12).Value)
            Form_comentario.Show()

        End If

        If e.KeyCode = Keys.F1 Then

            If Form_consulta_comprobante.cmb_tipo.Text = "Pedidos" Then

                Dim x As Short = MessageBox.Show("Desea cambiar el Cliente ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If x = 6 Then
                    pos = Me.DataGridView1.CurrentCell.RowIndex
                    busc_cliente.Show()
                End If

            End If

        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Public Sub mostrar()

        Dim midataset As New DataSet
        Dim comando As SqlDataAdapter
        Dim comando1 As SqlCommand
        Dim valor As Single

        Try

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Facturas" Or RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Debitos" Then

                comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,total1,descuento,iva_inscripto,imp_interno,exento1,val_uni_sec from fact_det where fact_det.letra_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_det.num_fact = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_det.tipo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_det.prefijo_fact2= '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_det.talon1 = '" & RTrim(Me.DataGridView1.SelectedCells(10).Value) & "'", conex)
                comando.Fill(midataset, "fact_det")
                comando.Dispose()

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("fact_det")

                comando1 = New SqlCommand("select sub_total,exento,iva_ins,iva_10,imp_interno1,total,descuento,comentario from fact_tot where fact_tot.num_factura = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_tot.nombre_cli = '" & RTrim(Me.DataGridView1.SelectedCells(5).Value) & "' and fact_tot.tipo_factura = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_tot.pref = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_tot.letra = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_tot.talon2 = '" & RTrim(Me.DataGridView1.SelectedCells(10).Value) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader As SqlDataReader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_muestra_factura.txt_gravado.Text = reader("Sub_total")
                Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
                Form_muestra_factura.txt_exento.Text = reader("exento")
                Form_muestra_factura.txt_no_inscripto.Text = reader("iva_10")
                Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno1")
                Form_muestra_factura.txt_total_grilla.Text = reader("total")
                valor = reader("descuento")
                Form_muestra_factura.valor = reader("comentario")

                reader.Close()
                conex.Close()

                comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact,pago,talon,cae,venc_cae from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_cab.letra_fact= '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_cab.tipo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_cab.talon = '" & RTrim(Me.DataGridView1.SelectedCells(10).Value) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & "   -   " & "Lista:" & " " & reader("lista") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & "  " & reader("pago") & "                       " & "C.A.E:" & " " & reader("cae") & vbCrLf & "Descuento Total Factura:" & "   " & valor & "%" & "                                                                             " & "Venc C.A.E:" & " " & reader("venc_cae") & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                Form_muestra_factura.txt_tipo.Text = reader("tipo_fact")
                Form_muestra_factura.txt_letra.Text = reader("letra_fact")
                Form_muestra_factura.txt_prefijo.Text = reader("prefijo_fact")
                Form_muestra_factura.txt_numero.Text = reader("num_fact1")
                Form_muestra_factura.txt_estado_fact.Text = reader("estado_fact")
                Form_muestra_factura.dt_fec.Value = reader("fec_emision")
                Form_muestra_factura.txt_nombre.Text = reader("nombre")
                Form_muestra_factura.txt_f_pago.Text = reader("forma_pago")
                Form_muestra_factura.txt_talon.Text = reader("talon")
                Form_muestra_factura.txt_tipo_iva.Text = reader("tipo_iva")
                Form_muestra_factura.txt_comprobante.Text = "venta"

                reader.Close()

                Form_muestra_factura.Show()

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Pedidos" Then

                If form_factura.txt_estado_form.Text = 1 Then
                    MessageBox.Show("Hay comprobantes sin terminar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Call carga_cabecera_factura_pedido()

                comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact,talon,vendedor,id_lista,(select distinct localidad from cli_01 where nombre = '" & RTrim(Me.DataGridView1.SelectedCells(5).Value) & "') as loc from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_cab.letra_fact= '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_cab.tipo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader As SqlDataReader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_factura_preventa.txt_muestra_datos.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & "    -    " & reader("loc")

                Form_factura_preventa.txt_tipo.Text = reader("tipo_fact")
                Form_factura_preventa.txt_letra.Text = reader("letra_fact")
                Form_factura_preventa.txt_prefijo.Text = reader("prefijo_fact")
                Form_factura_preventa.txt_numero.Text = reader("num_fact1")
                Form_factura_preventa.txt_talon.Text = reader("talon")
                Form_factura_preventa.txt_cod_cli.Text = reader("id_cli")
                Form_factura_preventa.txt_nombre.Text = reader("nombre")
                Form_factura_preventa.txt_fecHA_emi.Text = reader("fec_emision")
                Form_factura_preventa.txt_vendedor.Text = reader("vendedor")
                Form_factura_preventa.txt_cod_lis.Text = reader("id_lista")
                Form_factura_preventa.txt_cuit.Text = reader("cuit")
                Form_factura_preventa.txt_iva.Text = reader("tipo_iva")
                Form_factura_preventa.txt_estado_form.Text = 1
                Form_muestra_factura.txt_comprobante.Text = "venta"

                reader.Close()

                midataset.Clear()

                comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,precio_civa1,iva1,imp_interno,exento1,cantidad_sin_stock,iva_inscripto,costo,cod_prov,cod_rub,descuento,total1,fila,(select unidad_secundaria from art_01 where art_01.id_art = fact_det.codi_producto) as uni_sec,val_uni_sec,(select bonif_vta from art_precio where art_precio.id_art1 = fact_det.codi_producto and art_precio.id_lista1 = fact_det.cod_lista) as bonif_vta from fact_det where fact_det.letra_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_det.prefijo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_det.num_fact = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_det.tipo_fact2 = 'PD' order by letra_fact1", conex)
                comando.Fill(midataset, "fact_det")
                comando.Dispose()

                Dim i As Integer

                Form_factura_preventa.DataGridView1.Columns.Add("codigo", "cod")
                Form_factura_preventa.DataGridView1.Columns.Add("detalle", "det")
                Form_factura_preventa.DataGridView1.Columns.Add("cant", "cant")
                Form_factura_preventa.DataGridView1.Columns.Add("p_siva", "p_siva")
                Form_factura_preventa.DataGridView1.Columns.Add("p_civa", "p_civa")
                Form_factura_preventa.DataGridView1.Columns.Add("iva", "iva")
                Form_factura_preventa.DataGridView1.Columns.Add("imp", "imp")
                Form_factura_preventa.DataGridView1.Columns.Add("exento", "exento")
                Form_factura_preventa.DataGridView1.Columns.Add("sin_stk", "sin_stk")
                Form_factura_preventa.DataGridView1.Columns.Add("ins", "ins")
                Form_factura_preventa.DataGridView1.Columns.Add("total_siva", "total_siva")
                Form_factura_preventa.DataGridView1.Columns.Add("total_civa", "total_civa")
                Form_factura_preventa.DataGridView1.Columns.Add("verifica_tecla", "verifica_tecla")
                Form_factura_preventa.DataGridView1.Columns.Add("n_ins", "n_ins")
                Form_factura_preventa.DataGridView1.Columns.Add("costo", "costo")
                Form_factura_preventa.DataGridView1.Columns.Add("total costo", "total_costo")
                Form_factura_preventa.DataGridView1.Columns.Add("cod_proveed", "cod_proveed")
                Form_factura_preventa.DataGridView1.Columns.Add("cod rub", "cod_rub")
                Form_factura_preventa.DataGridView1.Columns.Add("Desc", "descuento")
                Form_factura_preventa.DataGridView1.Columns.Add("p_civa1", "p_civa1")
                Form_factura_preventa.DataGridView1.Columns.Add("entra_busqueda", "entra_busqueda")
                Form_factura_preventa.DataGridView1.Columns.Add("fila_editada", "fila_editada")
                Form_factura_preventa.DataGridView1.Columns.Add("p_siva1", "p_siva1")
                Form_factura_preventa.DataGridView1.Columns.Add("fila", "fila")
                Form_factura_preventa.DataGridView1.Columns.Add("uni_sec", "uni_sec")
                Form_factura_preventa.DataGridView1.Columns.Add("val_uni_sec", "val_uni_sec")
                Form_factura_preventa.DataGridView1.Columns.Add("bonif_vta", "bonif_vta")

                Form_factura_preventa.DataGridView1.Columns(3).Visible = False
                Form_factura_preventa.DataGridView1.Columns(5).Visible = False
                Form_factura_preventa.DataGridView1.Columns(6).Visible = False
                Form_factura_preventa.DataGridView1.Columns(7).Visible = False
                Form_factura_preventa.DataGridView1.Columns(8).Visible = False
                Form_factura_preventa.DataGridView1.Columns(9).Visible = False
                Form_factura_preventa.DataGridView1.Columns(10).Visible = False
                Form_factura_preventa.DataGridView1.Columns(12).Visible = False
                Form_factura_preventa.DataGridView1.Columns(13).Visible = False
                Form_factura_preventa.DataGridView1.Columns(14).Visible = False
                Form_factura_preventa.DataGridView1.Columns(15).Visible = False
                Form_factura_preventa.DataGridView1.Columns(16).Visible = False
                Form_factura_preventa.DataGridView1.Columns(17).Visible = False
                Form_factura_preventa.DataGridView1.Columns(19).Visible = False
                Form_factura_preventa.DataGridView1.Columns(20).Visible = False
                Form_factura_preventa.DataGridView1.Columns(21).Visible = False
                Form_factura_preventa.DataGridView1.Columns(22).Visible = False
                Form_factura_preventa.DataGridView1.Columns(23).Visible = False
                Form_factura_preventa.DataGridView1.Columns(24).Visible = False

                For i = 0 To midataset.Tables("fact_det").Rows.Count - 1

                    Form_factura_preventa.DataGridView1.Rows.Add()

                    Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value = midataset.Tables("fact_det").Rows(i).Item(0)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(1).Value = midataset.Tables("fact_det").Rows(i).Item(1)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value = midataset.Tables("fact_det").Rows(i).Item(2)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value = midataset.Tables("fact_det").Rows(i).Item(3)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(22).Value = midataset.Tables("fact_det").Rows(i).Item(3)

                    Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Format(midataset.Tables("fact_det").Rows(i).Item(14) / midataset.Tables("fact_det").Rows(i).Item(2), "0.00")

                    If midataset.Tables("fact_det").Rows(i).Item(16) = "NO" Then
                        Form_factura_preventa.DataGridView1.Rows(i).Cells(10).Value = Format(midataset.Tables("fact_det").Rows(i).Item(3) * midataset.Tables("fact_det").Rows(i).Item(2), "0.00")
                    Else
                        Form_factura_preventa.DataGridView1.Rows(i).Cells(10).Value = Format(midataset.Tables("fact_det").Rows(i).Item(3) * midataset.Tables("fact_det").Rows(i).Item(17), "0.00")
                    End If

                    Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value = midataset.Tables("fact_det").Rows(i).Item(5)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value = midataset.Tables("fact_det").Rows(i).Item(6)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value = midataset.Tables("fact_det").Rows(i).Item(7)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(8).Value = midataset.Tables("fact_det").Rows(i).Item(8)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = midataset.Tables("fact_det").Rows(i).Item(9)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(14).Value = midataset.Tables("fact_det").Rows(i).Item(10)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(16).Value = midataset.Tables("fact_det").Rows(i).Item(11)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(17).Value = midataset.Tables("fact_det").Rows(i).Item(12)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value = midataset.Tables("fact_det").Rows(i).Item(13)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(19).Value = midataset.Tables("fact_det").Rows(i).Item(4)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value = midataset.Tables("fact_det").Rows(i).Item(14)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(23).Value = midataset.Tables("fact_det").Rows(i).Item(15)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(24).Value = midataset.Tables("fact_det").Rows(i).Item(16)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value = midataset.Tables("fact_det").Rows(i).Item(17)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(26).Value = midataset.Tables("fact_det").Rows(i).Item(18)

                Next

                Form_factura_preventa.Show()

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Recibos" Then

                comando = New SqlDataAdapter("select fecha,tipo_fact,letra_fact,pre_fact,num_fact,cancelado from recibo_det inner join recibo_cab on recibo_det.letra_01 = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and recibo_det.id_det = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and recibo_det.tc1 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and recibo_det.pre1='" & Me.DataGridView1.SelectedCells(4).Value & "' and recibo_det.talon1='" & Me.DataGridView1.SelectedCells(7).Value & "' and recibo_cab.id_rec = recibo_det.id_det and recibo_cab.letra = recibo_det.letra_01 and recibo_cab.tc = recibo_det.tc1 and recibo_cab.pre = recibo_det.pre1 and recibo_cab.talon = recibo_det.talon1", conex)
                comando.Fill(midataset, "recibo_det")
                comando.Dispose()

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("recibo_det")

                comando1 = New SqlCommand("select total_cobro,pago from recibo_tot where id_tot = '" & Me.DataGridView1.SelectedCells(1).Value & "' and lt = '" & Me.DataGridView1.SelectedCells(3).Value & "' and pre2='" & Me.DataGridView1.SelectedCells(4).Value & "' and talon2 = '" & Me.DataGridView1.SelectedCells(7).Value & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader As SqlDataReader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_muestra_factura.txt_total_grilla.Text = reader("total_cobro")
                Dim pago As String = reader("pago")

                reader.Close()
                conex.Close()

                comando1 = New SqlCommand("select id_rec,tc,letra,pre,fec_emi,id_cli,nombre,direccion,saldo_ant,talon,p_venta2 from recibo_cab where recibo_cab.id_rec = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and recibo_cab.fec_emi = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and recibo_cab.letra = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and pre='" & Me.DataGridView1.SelectedCells(4).Value & "' and recibo_cab.talon='" & Me.DataGridView1.SelectedCells(7).Value & "'", conex)
                conex.Open()

                reader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_muestra_factura.txt_tipo.Text = reader("tc")
                Form_muestra_factura.txt_letra.Text = reader("letra")
                Form_muestra_factura.txt_prefijo.Text = reader("pre")
                Form_muestra_factura.txt_numero.Text = reader("id_rec")
                Form_muestra_factura.dt_fec.Value = reader("fec_emi")
                Form_muestra_factura.txt_nombre.Text = reader("nombre")
                Form_muestra_factura.txt_talon.Text = reader("talon")
                Form_muestra_factura.txt_comprobante.Text = "cobro"
                Form_muestra_factura.txt_p_venta.Text = reader("p_venta2")

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Comprobante:" & "  " & reader("tc") & " - " & reader("pre") & " - " & reader("letra") & " - " & reader("id_rec") & "     " & "Estado:" & "  " & pago & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emi") & vbCrLf & "Saldo Anterior:" & "  " & reader("saldo_ant") & vbCrLf & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                reader.Close()

                es_recibo = False
                Form_muestra_factura.Show()

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Presupuestos" Then

                comando = New SqlDataAdapter("select fecha_emision1,descrip,cant,precio,descuento,total1,0,0,0,0 from presupuesto where num = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "'", conex)
                comando.Fill(midataset, "presupuesto")
                comando.Dispose()

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("presupuesto")

                Form_muestra_factura.DataGridView1.Columns(0).Width = 100
                Form_muestra_factura.DataGridView1.Columns(1).Width = 320
                Form_muestra_factura.DataGridView1.Columns(2).Width = 80
                Form_muestra_factura.DataGridView1.Columns(3).Width = 80
                Form_muestra_factura.DataGridView1.Columns(4).Width = 80
                Form_muestra_factura.DataGridView1.Columns(5).Width = 80

                comando1 = New SqlCommand("select tot from presupuesto where num  = '" & Me.DataGridView1.SelectedCells(2).Value & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader As SqlDataReader = comando1.ExecuteReader
                comando1.Dispose()

                reader.Read()

                Form_muestra_factura.txt_total_grilla.Text = reader("tot")

                reader.Close()
                conex.Close()

                comando1 = New SqlCommand("select fecha_emision1,nombre,direccion,localidad,telefono,num,tot from presupuesto inner join cli_01 on presupuesto.id_cli = cli_01.id_cli  and num = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader = comando1.ExecuteReader
                comando.Dispose()

                reader.Read()

                Form_muestra_factura.txt_numero.Text = reader("num")
                Form_muestra_factura.dt_fec.Value = reader("fecha_emision1")
                Form_muestra_factura.txt_nombre.Text = reader("nombre")
                Form_muestra_factura.txt_tipo.Text = "PR"
                Form_muestra_factura.txt_prefijo.Text = 0
                Form_muestra_factura.txt_letra.Text = "P"
                Form_muestra_factura.txt_comprobante.Text = "venta"

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "  -  " & reader("direccion") & "  -  " & reader("localidad") & vbCrLf & "Telefono:" & " " & reader("telefono") & vbCrLf & "Comprobante:" & "  " & "PR" & " - " & reader("num") & "  " & vbCrLf & "Fecha Emision:" & "  " & reader("fecha_emision1") & vbCrLf & "Total:" & "  " & reader("tot")

                reader.Close()

                Form_muestra_factura.Show()

            End If

        Catch ex As Exception

            MessageBox.Show("No hay Datos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        Finally

            conex.Close()
            midataset.Dispose()

        End Try

    End Sub

    Private Sub exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportar.Click
        Me.DataGridView2.DataSource = tbl2

        Form_exporta.Show()

    End Sub

    Private Sub form_factura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Me.txt_cierra_form.Text = 2 Then

            e.Cancel = True
            Form_muestra_factura.TopMost = True

        End If

    End Sub

    Private Sub fact_contado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fact_contado.Click

        Try

            Dim cont As Integer = 0
            acu = 0
            valida1 = False
            tbl2.Clear()
            Dim sale As Boolean = True

            If valida = False Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2
                    Me.DataGridView1.Rows(i).Visible = True
                Next

            End If

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If Me.DataGridView1.Rows(i).Cells(7).Value = "Cta Cte" Then
                    Me.DataGridView1.CurrentCell = Nothing
                    Me.DataGridView1.Rows(i).Visible = False
                Else
                    cont = cont + 1
                End If
            Next

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If Form_consulta_comprobante.cmb_modalidad.Text = "Total" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Contado' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where  fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Contado' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where fact_cab.nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Contado' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where fact_cab.nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

            Next

            Me.lbl_total.Text = acu

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "     " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text & "       " & "Forma de Pago:" & "   " & "Contado"
            Else
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "     " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Nombre:" & "   " & Form_consulta_comprobante.cmb_cliente_total.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text & "       " & "Forma de Pago:" & "   " & "Contado"
            End If

            Form_consulta_comprobante.txt_acu.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fact_cta_cte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fact_cta_cte.Click

        Try

            Dim cont As Integer = 0
            acu = 0
            valida = False
            tbl2.Clear()
            Dim sale As Boolean = True

            If valida1 = False Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2
                    Me.DataGridView1.Rows(i).Visible = True
                Next

            End If

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If Me.DataGridView1.Rows(i).Cells(7).Value = "Contado" Then
                    Me.DataGridView1.CurrentCell = Nothing
                    Me.DataGridView1.Rows(i).Visible = False
                Else
                    cont = cont + 1
                End If
            Next

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If Form_consulta_comprobante.cmb_modalidad.Text = "Total" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Cta Cte' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where  fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Cta Cte' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where fact_cab.nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                    If sale = True Then
                        Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_cab.forma_pago = 'Cta Cte' and  fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where fact_cab.nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                        comando.Fill(tbl2)
                        sale = False
                    End If

                    If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" And Me.DataGridView1.Rows(i).Visible = True And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                        acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(10).Value = Format(acu, "0.00")
                        Form_consulta_comprobante.txt_acu.Text = acu

                    End If

                End If

            Next

            Me.lbl_total.Text = acu

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "     " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text & "       " & "Forma de Pago:" & "   " & "Cta Cte"
            Else
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "     " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Nombre:" & "   " & Form_consulta_comprobante.cmb_cliente_total.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text & "       " & "Forma de Pago:" & "   " & "Cta Cte"
            End If

            Form_consulta_comprobante.txt_acu.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub obtiene_medios_pago(ByVal tipo, ByVal letra, ByVal prefijo, ByVal numero, ByVal talon)

        Dim tbx As New DataTable
        conex = conecta()

        tbx.Clear()
        comando = New SqlDataAdapter("select isnull(total,0) from cheque_01 where numero = '" & Trim(numero) & "' and tc = '" & Trim(tipo) & "' and lt = '" & Trim(letra) & "' and prefijo = '" & Trim(prefijo) & "' and talon = '" & Trim(talon) & "'", conex)
        comando.Fill(tbx)
        comando.Dispose()

        If tbx.Rows.Count > 0 Then acu_cheque = acu_cheque + tbx.Rows(0).Item(0)

        tbx.Clear()
        comando = New SqlDataAdapter("select isnull(total,0) from vale_01 where numero = '" & Trim(numero) & "' and tc = '" & Trim(tipo) & "' and lt = '" & Trim(letra) & "' and prefijo = '" & Trim(prefijo) & "' and talon = '" & Trim(talon) & "'", conex)
        comando.Fill(tbx)
        comando.Dispose()

        If tbx.Rows.Count > 0 Then acu_vale = acu_vale + tbx.Rows(0).Item(0)

        tbx.Clear()
        comando = New SqlDataAdapter("select isnull(total,0) from ticket_01 where id_tiket = '" & Trim(numero) & "' and tc = '" & Trim(tipo) & "' and lt = '" & Trim(letra) & "' and prefijo = '" & Trim(prefijo) & "' and talon = '" & Trim(talon) & "'", conex)
        comando.Fill(tbx)
        comando.Dispose()

        If tbx.Rows.Count > 0 Then acu_posnet = acu_posnet + tbx.Rows(0).Item(0)

        tbx.Clear()
        comando = New SqlDataAdapter("select isnull(importe,0) from t_credito where id_credito = '" & RTrim(numero) & "' and tc = '" & Trim(tipo) & "' and lt = '" & Trim(letra) & "' and prefijo = '" & Trim(prefijo) & "' and talon = '" & Trim(talon) & "'", conex)
        comando.Fill(tbx)
        comando.Dispose()

        If tbx.Rows.Count > 0 Then acu_credito = acu_credito + tbx.Rows(0).Item(0)

        tbx.Clear()
        comando = New SqlDataAdapter("select isnull(importe,0) from t_debito where id_debito = '" & RTrim(numero) & "' and tc = '" & Trim(tipo) & "' and lt = '" & Trim(letra) & "' and prefijo = '" & Trim(prefijo) & "' and talon = '" & Trim(talon) & "'", conex)
        comando.Fill(tbx)
        comando.Dispose()

        If tbx.Rows.Count > 0 Then acu_debito = acu_debito + tbx.Rows(0).Item(0)

    End Sub

    Public Sub fact_total()

        Try

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Pedidos" Then

                If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then
                    Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text
                Else
                    Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Nombre:" & "   " & Form_consulta_comprobante.cmb_cliente_total.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text
                End If

                Exit Sub

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Facturas" Then

                acu = 0
                tbl2.Clear()

                Dim comando As New SqlDataAdapter("select DISTINCT fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' where  fact_cab.talon = fact_tot.talon2 and fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision", conex)
                comando.Fill(tbl2)
                comando.Dispose()

                If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then

                    For i = 0 To Me.DataGridView1.Rows.Count - 2

                        If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "PD" Then

                            acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                            Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                            Form_consulta_comprobante.txt_acu.Text = acu

                        Else

                            Me.DataGridView1.Rows(i).Cells(11).Value = 0

                            If RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                                acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                                Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                                Form_consulta_comprobante.txt_acu.Text = acu

                            End If

                        End If

                    Next

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                    For i = 0 To Me.DataGridView1.Rows.Count - 2

                        If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) = Form_consulta_comprobante.cmb_cliente_total.Text And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                            acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                            Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                            Form_consulta_comprobante.txt_acu.Text = acu

                        Else

                            Me.DataGridView1.Rows(i).Cells(11).Value = 0

                            If RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                                acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                                Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                                Form_consulta_comprobante.txt_acu.Text = acu

                            End If

                        End If

                    Next

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                    acu_cheque = 0
                    acu_posnet = 0
                    acu_debito = 0
                    acu_credito = 0
                    acu_vale = 0

                    For i = 0 To Me.DataGridView1.Rows.Count - 2

                        If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And Form_consulta_comprobante.cmb_cliente_total.Text = RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                            acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                            Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                            Form_consulta_comprobante.txt_acu.Text = acu

                            ' cambio realizado para Joel que quiere desglozar el importe
                            ' que se muestra es decir efectivo,postet por vendedor
                            obtiene_medios_pago(Trim(Me.DataGridView1.Rows(i).Cells(1).Value), Trim(Me.DataGridView1.Rows(i).Cells(3).Value), Trim(Me.DataGridView1.Rows(i).Cells(4).Value), Trim(Me.DataGridView1.Rows(i).Cells(2).Value), Form_consulta_comprobante.talonario)

                        Else

                            Me.DataGridView1.Rows(i).Cells(11).Value = 0

                            If RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                                acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                                Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                                Form_consulta_comprobante.txt_acu.Text = acu

                            End If

                        End If

                    Next

                End If

                If Form_consulta_comprobante.cmb_modalidad.Text = "Zona" Then

                    For i = 0 To Me.DataGridView1.Rows.Count - 2

                        If (RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND") And RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                            acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                            Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                            Form_consulta_comprobante.txt_acu.Text = acu

                        Else

                            Me.DataGridView1.Rows(i).Cells(11).Value = 0

                            If RTrim(Me.DataGridView1.Rows(i).Cells(9).Value) <> "Anulado" Then

                                acu = Format(acu - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                                Me.DataGridView1.Rows(i).Cells(11).Value = Format(acu, "0.00")
                                Form_consulta_comprobante.txt_acu.Text = acu

                            End If

                        End If

                    Next

                End If

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Recibos" Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    acu = Format(acu + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                    Form_consulta_comprobante.txt_acu.Text = acu

                Next

            End If

            If RTrim(Form_consulta_comprobante.cmb_tipo.Text) = "Presupuestos" Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    acu = Format(acu + Me.DataGridView1.Rows(i).Cells(4).Value, "0.00")
                    Me.DataGridView1.Rows(i).Cells(5).Value = acu

                Next

            End If

            Me.lbl_total.Text = "$" & " " & Val(Form_consulta_comprobante.txt_acu.Text)

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text
            Else
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Nombre:" & "   " & Form_consulta_comprobante.cmb_cliente_total.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Efectivo: $" & " " & Format((Me.lbl_total.Text - acu_posnet - acu_debito - acu_credito - acu_vale - acu_cheque), "0.00") & "  " & "PosNet: $" & acu_posnet & " - " & "Cheque: $" & acu_cheque & " - " & "Debito: $" & acu_debito & " - " & "Credito: $" & acu_credito & " - " & "Vale: $" & acu_vale
            End If

            Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

            Form_consulta_comprobante.txt_acu.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub factura_totales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles factura_totales.Click

        acu = 0

        For i = 0 To Me.DataGridView1.Rows.Count - 2
            Me.DataGridView1.Rows(i).Visible = True
        Next

        Call fact_total()

    End Sub

    Private Sub carga_cabecera_factura_pedido()

        If estado_fact = 0 Then

            Me.DataGridView1.Columns(7).Visible = False
            Me.DataGridView1.Columns(8).Visible = False
            Me.DataGridView1.Columns(9).Visible = False
            Me.DataGridView1.Columns(10).Visible = False
            'Me.DataGridView1.Columns.Add("acu", "Acumulado")

            Me.DataGridView1.Columns(0).Width = 120
            Me.DataGridView1.Columns(1).Width = 50
            Me.DataGridView1.Columns(2).Width = 50
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 245
            Me.DataGridView1.Columns(6).Width = 80
            Me.DataGridView1.Columns(7).Width = 80
            Me.DataGridView1.Columns(8).Width = 90
            Me.DataGridView1.Columns(9).Width = 90
            Me.DataGridView1.Columns(10).Width = 90
            Me.DataGridView1.Columns(12).Width = 500

            Me.DataGridView1.Columns(0).HeaderText = "Fecha Inicial"
            Me.DataGridView1.Columns(1).HeaderText = "tipo"
            Me.DataGridView1.Columns(2).HeaderText = "Numero"
            Me.DataGridView1.Columns(3).HeaderText = "Letra"
            Me.DataGridView1.Columns(4).HeaderText = "Suc"
            Me.DataGridView1.Columns(5).HeaderText = "Nombre"
            Me.DataGridView1.Columns(6).HeaderText = "Total"
            Me.DataGridView1.Columns(7).HeaderText = "Forma_pago"
            Me.DataGridView1.Columns(8).HeaderText = "Vendedor"
            Me.DataGridView1.Columns(9).HeaderText = "Estado"
            Me.DataGridView1.Columns(10).HeaderText = "Talon"

            For i = 0 To Me.DataGridView1.Rows.Count - 2
                If Me.DataGridView1.Rows(i).Cells(9).Value = "Anulado" Then
                    Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.LightGray
                End If
            Next

            Call fact_total()

        End If

        estado_fact = 1

    End Sub

    Public Sub carga_cabecera_recibo()

        If estado_rec = 0 Then

            Me.DataGridView1.Columns(0).Width = 100
            Me.DataGridView1.Columns(1).Width = 50
            Me.DataGridView1.Columns(2).Width = 50
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 283
            Me.DataGridView1.Columns(6).Width = 100
            Me.DataGridView1.Columns(7).Visible = False

            Me.DataGridView1.Columns(0).HeaderText = "Fecha Inicial"
            Me.DataGridView1.Columns(1).HeaderText = "Numero"
            Me.DataGridView1.Columns(2).HeaderText = "Tipo"
            Me.DataGridView1.Columns(3).HeaderText = "Letra"
            Me.DataGridView1.Columns(4).HeaderText = "Pre"
            Me.DataGridView1.Columns(5).HeaderText = "Nombre"
            Me.DataGridView1.Columns(6).HeaderText = "Total"

            Dim a As Integer = Me.DataGridView1.Rows.Count - 1

            Call fact_total()

            Me.DataGridView1.Rows(a).DefaultCellStyle.BackColor = Color.LightGreen

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1
            Else
                Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_comprobante.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_comprobante.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_comprobante.cmb_modalidad.Text & vbCrLf & "Nombre:" & "   " & Form_consulta_comprobante.cmb_cliente_total.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1
            End If

        End If

        estado_rec = 1

    End Sub

    Private Sub Tool_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_imprime.Click

        Dim PrinterSettings As New System.Drawing.Printing.PrinterSettings()
        Dim PageSettings As New System.Drawing.Printing.PageSettings(PrinterSettings)
        Dim pd As New PrintDialog

        txt = rep.Section2.ReportObjects.Item("fec_emi")
        txt.Text = Form_consulta_comprobante.dt_fec_ini.Text

        txt = rep.Section2.ReportObjects.Item("fec_hasta")
        txt.Text = Form_consulta_comprobante.dt_fec_fin.Text

        txt = rep.Section2.ReportObjects.Item("usu")
        txt.Text = principal.lbl_usu.Text

        txt = rep.Section2.ReportObjects.Item("moda")
        txt.Text = Form_consulta_comprobante.cmb_modalidad.Text

        txt = rep.Section2.ReportObjects.Item("reg")
        txt.Text = Me.DataGridView1.Rows.Count - 1

        txt = rep.Section2.ReportObjects.Item("imp")
        txt.Text = Me.lbl_total.Text

        txt = rep.Section2.ReportObjects.Item("tipo")
        txt.Text = Form_consulta_comprobante.cmb_tipo.Text

        txt = rep.Section2.ReportObjects.Item("txt_vend")
        txt.Text = Form_consulta_comprobante.cmb_cliente_total.Text

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        If RTrim(Form_consulta_comprobante.cmb_modalidad.Text) = "Total" Then

            rep.SetDataSource(tbl2)
            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()

        End If

        If RTrim(Form_consulta_comprobante.cmb_modalidad.Text) = "Vendedor" Then

            rep.RecordSelectionFormula = "{fact_cab.fec_emision} >= date('" & RTrim(Form_consulta_comprobante.dt_fec_ini.Text) & "') and {fact_cab.fec_emision} <= date('" & RTrim(Form_consulta_comprobante.dt_fec_fin.Text) & "') and {fact_cab.nom_vendedor}= '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and {fact_cab.talon} = " & RTrim(Form_consulta_comprobante.talonario) & " and {fact_cab.tipo_fact} <> 'PD' and {fact_cab.tipo_fact} <> 'RE' and {fact_cab.tipo_fact} <> 'RS'"

        End If

        If RTrim(Form_consulta_comprobante.cmb_modalidad.Text) = "Cliente/Proveedor" Then

            rep.RecordSelectionFormula = "{fact_cab.fec_emision} >= date('" & RTrim(Form_consulta_comprobante.dt_fec_ini.Text) & "') and {fact_cab.fec_emision} <= date('" & RTrim(Form_consulta_comprobante.dt_fec_fin.Text) & "') and {fact_cab.nombre}= '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and {fact_cab.talon} = " & RTrim(Form_consulta_comprobante.talonario) & " and {fact_cab.tipo_fact} <> 'PD' and {fact_cab.tipo_fact} <> 'RE' and {fact_cab.tipo_fact} <> 'RS'"

        End If

        If RTrim(Form_consulta_comprobante.cmb_modalidad.Text) = "Zona" Then

            rep.SetDataSource(tbl)
            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            'rep.RecordSelectionFormula = "{fact_cab.fec_emision} >= date('" & RTrim(Form_consulta_comprobante.dt_fec_ini.Text) & "') and {fact_cab.fec_emision} <= date('" & RTrim(Form_consulta_comprobante.dt_fec_fin.Text) & "') and  {zona_01.zona} = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and {fact_cab.talon} = " & RTrim(Form_consulta_comprobante.talonario) & " and {fact_cab.tipo_fact} <> 'PD' and {fact_cab.tipo_fact} <> 'RE' and {fact_cab.tipo_fact} <> 'RS'"

        End If

        'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper

        rep.PrintOptions.CopyTo(PrinterSettings, PageSettings)
        pd.PrinterSettings = PrinterSettings
        pd.AllowSomePages = True
        pd.AllowSelection = True

        If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

            rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

        End If

    End Sub

    Public Sub carga_seleccion_cosulta()

        conex = conecta()
        tbl.Clear()
        tbl2.Clear()

        recibo = True

        If Form_consulta_comprobante.cmb_tipo.Text = "Pedidos" Then

            If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                Call verifica_numero_vendedor()

                Dim comando1 As New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.vendedor ='" & RTrim(tbl1.Rows(0).Item(0)) & "' and fact_cab.tipo_fact = 'PD' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando1.Fill(tbl)
                comando1.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            Else

                Dim comando As New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.talon = '" & RTrim(Form_consulta_comprobante.talonario) & "' where fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "'and tipo_fact = 'PD' order by fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact ASC", conex)
                comando.Fill(tbl)
                comando.Fill(tbl2)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl

            End If

        End If

        If Form_consulta_comprobante.cmb_tipo.Text = "Facturas" Then

            recibo = True
            tbl.Clear()
            Me.tool_art_sin_stock.Visible = False
            Me.Tool_reemplaza_art.Visible = False

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' and fact_cab.tipo_fact <> 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.tipo_fact,fact_cab.prefijo_fact,fact_cab.num_fact1", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' and fact_cab.tipo_fact <> 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                Call verifica_numero_vendedor()

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.vendedor ='" & RTrim(tbl1.Rows(0).Item(0)) & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' and fact_cab.tipo_fact <> 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

                tbl1.Clear()

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Zona" Then

                Dim comando As New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and (select zona from cli_01 where cli_01.id_cli = fact_cab.id_cli) = '" & Trim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' and fact_cab.tipo_fact <> 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

                tbl1.Clear()

            End If

        End If

        If Form_consulta_comprobante.cmb_tipo.Text = "Debitos" Then

            recibo = True
            tbl.Clear()
            Me.tool_art_sin_stock.Visible = False
            Me.Tool_reemplaza_art.Visible = False

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.tipo_fact = 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.tipo_fact,fact_cab.prefijo_fact,fact_cab.num_fact1", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.tipo_fact = 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                Call verifica_numero_vendedor()

                Dim comando As New SqlDataAdapter("select fec_emision + hora,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and fact_cab.nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.vendedor ='" & RTrim(tbl1.Rows(0).Item(0)) & "' and fact_cab.tipo_fact = 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

                tbl1.Clear()

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Zona" Then

                Dim comando As New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,letra,prefijo_fact,nombre,total,forma_pago,nom_vendedor,estado_fact,talon,'' as Acumulado,comentario from fact_tot inner join fact_cab on fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision= fact_tot.fecha_emision1 and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '" & Form_consulta_comprobante.talonario & "' and (select zona from cli_01 where cli_01.id_cli = fact_cab.id_cli) = '" & Trim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' and fact_cab.tipo_fact = 'ND' where fact_tot.num_factura= fact_cab.num_fact1 and fact_tot.letra=fact_cab.letra_fact and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.fec_emision >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fact_cab.fec_emision <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' order by fact_cab.fec_emision,fact_cab.letra_fact,fact_cab.num_fact1,fact_cab.prefijo_fact", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

                tbl1.Clear()

            End If

        End If

        If Form_consulta_comprobante.cmb_tipo.Text = "Recibos" Then

            recibo = False
            tbl.Clear()
            Me.tool_art_sin_stock.Visible = False
            Me.Tool_reemplaza_art.Visible = False

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then

                If Form_consulta_comprobante.cmb_tipo.Text = "Recibos" Then comando = New SqlDataAdapter("select fec_emi,id_rec,tc,letra,pre,nombre,total_cobro,talon from recibo_cab inner join recibo_tot on recibo_cab.talon = '" & Form_consulta_comprobante.talonario & "' and recibo_cab.talon = recibo_tot.talon2 and recibo_cab.p_venta2 = recibo_tot.p_venta and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.tc = recibo_tot.tip and recibo_cab.pre = recibo_tot.pre2 where fec_emi >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fec_emi <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' and recibo_cab.tc = 'RC' order by recibo_cab.fec_emi,recibo_cab.id_rec,recibo_cab.tc,recibo_cab.letra,recibo_cab.pre", conex)
                comando.Fill(tbl)
                comando.Dispose()
                recibo = False
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Cliente/Proveedor" Then

                comando = New SqlDataAdapter("select fec_emi,id_rec,tc,letra,pre,nombre,total_cobro,talon from recibo_tot inner join recibo_cab on recibo_cab.talon = '" & Form_consulta_comprobante.talonario & "' and recibo_cab.talon = recibo_tot.talon2 and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.tc = recibo_tot.tip and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.talon = recibo_tot.talon2 where fec_emi >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fec_emi <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' and nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' order by recibo_cab.fec_emi,recibo_cab.id_rec,recibo_cab.tc,recibo_cab.letra,recibo_cab.pre", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            End If

            If Form_consulta_comprobante.cmb_modalidad.Text = "Vendedor" Then

                comando = New SqlDataAdapter("select fec_emi,id_rec,tc,letra,pre,nombre,total_cobro,talon from recibo_tot inner join recibo_cab on recibo_cab.talon = '" & Form_consulta_comprobante.talonario & "' and recibo_cab.talon = recibo_tot.talon2 and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.tc = recibo_tot.tip and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.talon = recibo_tot.talon2 where fec_emi >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and fec_emi <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' and nom_vendedor = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "' order by recibo_cab.fec_emi,recibo_cab.id_rec,recibo_cab.tc,recibo_cab.letra,recibo_cab.pre", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

                tbl1.Clear()

            End If

        End If

        If Form_consulta_comprobante.cmb_tipo.Text = "Presupuestos" Then

            If Form_consulta_comprobante.cmb_modalidad.Text = "Total" Then

                comando = New SqlDataAdapter("select fecha_emision1,'PR',num,nombre,tot from presupuesto inner join cli_01 on presupuesto.fecha_emision1 >= '" & Form_consulta_comprobante.dt_fec_ini.Text & "' and presupuesto.fecha_emision1 <= '" & Form_consulta_comprobante.dt_fec_fin.Text & "' and presupuesto.fila =0 and presupuesto.id_cli = cli_01.id_cli", conex)
                comando.Fill(tbl)
                comando.Dispose()
                Me.DataGridView1.DataSource = tbl
                Me.DataGridView2.DataSource = tbl

            End If

        End If

        conex.Close()

    End Sub

    Private Sub verifica_numero_vendedor()

        Dim comando As SqlDataAdapter

        conex = conecta()
        tbl1.Clear()

        comando = New SqlDataAdapter("select id_vendedor from vend_01 where nombre = '" & RTrim(Form_consulta_comprobante.cmb_cliente_total.Text) & "'", conex)
        comando.Fill(tbl1)

    End Sub

    Private Sub tool_art_sin_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_art_sin_stock.Click

        Form_consulta_art_sinstock.txt_estado_form.Text = 1
        Form_consulta_art_sinstock.Show()

    End Sub

    Private Sub Tool_reemplaza_art_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_reemplaza_art.Click

        Form_cambia_articulo.Show()

    End Sub

    Private Sub carga_cabecera_presupuesto()

        Me.DataGridView1.Columns.Add("acu", "Acumulado")

        Me.DataGridView1.Columns(0).Width = 100
        Me.DataGridView1.Columns(1).Width = 50
        Me.DataGridView1.Columns(2).Width = 50
        Me.DataGridView1.Columns(3).Width = 300
        Me.DataGridView1.Columns(4).Width = 100
        Me.DataGridView1.Columns(5).Width = 100

        Me.DataGridView1.Columns(0).HeaderText = "Fecha Inicial"
        Me.DataGridView1.Columns(1).HeaderText = "tipo"
        Me.DataGridView1.Columns(2).HeaderText = "Numero"
        Me.DataGridView1.Columns(3).HeaderText = "Nombre"
        Me.DataGridView1.Columns(4).HeaderText = "Total"

        Call fact_total()

        barra_carga.Timer1.Enabled = True
        Me.tool_art_sin_stock.Visible = False
        Me.Tool_reemplaza_art.Visible = False

    End Sub
End Class