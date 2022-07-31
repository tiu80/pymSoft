Imports System.Data
Imports System.Data.SqlClient

Public Class Form_consulta_compras_det

    Dim comando As SqlDataAdapter
    Dim comando1 As SqlCommand
    Dim tb As New DataTable, tb1 As New DataTable
    Dim conex As SqlConnection

    Private Sub Form_consulta_compras_det_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1

        Me.DataGridView1.Columns(0).Width = 80
        Me.DataGridView1.Columns(1).Width = 50
        Me.DataGridView1.Columns(2).Width = 50
        Me.DataGridView1.Columns(3).Width = 50
        Me.DataGridView1.Columns(4).Width = 70
        Me.DataGridView1.Columns(5).Width = 340

        Me.txt_comentario.Text = "Movimiento del :" & "  " & Form_consulta_compras.dt_fec_ini.Text & "    " & "Hasta" & "   " & Form_consulta_compras.dt_fec_fin.Text & "      " & "Usuario:" & "  " & Form_login.cmb_usuario.Text & vbCrLf & "Modalidad: " & "   " & Form_consulta_compras.cmb_modalidad.Text & vbCrLf & "Total Registros:" & "   " & Me.DataGridView1.Rows.Count - 1 & vbCrLf & "Importe:" & "   " & Me.lbl_total.Text

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            If Form_consulta_compras.cmb_tipo.Text = "Nota de Credito" Or Form_consulta_compras.cmb_tipo.Text = "Factura" Then Call carga_factura_compra(Me.DataGridView1.SelectedCells(1).Value, Me.DataGridView1.SelectedCells(3).Value, Me.DataGridView1.SelectedCells(2).Value, Me.DataGridView1.SelectedCells(4).Value, Me.DataGridView1.SelectedCells(7).Value)
            If Form_consulta_compras.cmb_tipo.Text = "Orden Pago" Then Call carga_orden_pago(Me.DataGridView1.SelectedCells(2).Value, Me.DataGridView1.SelectedCells(3).Value, Me.DataGridView1.SelectedCells(4).Value, Me.DataGridView1.SelectedCells(1).Value)

        End If

    End Sub

    Public Sub carga_factura_compra(ByVal tipo, ByVal letra, ByVal prefijo, ByVal numero, ByVal id_cliente)

        tb.Clear()
        conex = New SqlConnection
        conex = conecta()

        comando = New SqlDataAdapter("select cuenta,detalle,debito,total,iva_ins,imp_interno,exento from compra_det inner join compra_tot on compra_det.num = compra_tot.num1 and compra_det.lt = compra_tot.lt1 and compra_det.pre = compra_tot.pre1 and compra_det.tipo1 = compra_tot.tipo2 and compra_det.talon1 = compra_tot.talon2 and compra_det.id_cli = compra_tot.id_cli1 where compra_det.lt = '" & RTrim(letra) & "' and compra_det.num = '" & RTrim(numero) & "' and compra_det.tipo1 = '" & RTrim(tipo) & "' and compra_det.pre= '" & RTrim(prefijo) & "' and compra_det.id_cli= '" & RTrim(id_cliente) & "'", conex)
        comando.Fill(tb)

        Form_muestra_factura.DataGridView1.DataSource = tb

        comando1 = New SqlCommand("select neto,exento,iva_ins,imp_interno,total from compra_tot where compra_tot.num1 = '" & RTrim(numero) & "' and compra_tot.tipo2 = '" & RTrim(tipo) & "' and compra_tot.pre1 = '" & RTrim(prefijo) & "' and compra_tot.lt1 = '" & RTrim(letra) & "' and compra_tot.id_cli1 = '" & RTrim(id_cliente) & "'", conex)
        If conex.State = ConnectionState.Closed Then conex.Open()

        Dim reader As SqlDataReader = comando1.ExecuteReader

        reader.Read()

        Form_muestra_factura.txt_gravado.Text = reader("neto")
        Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
        Form_muestra_factura.txt_exento.Text = reader("exento")
        Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno")
        Form_muestra_factura.txt_total_grilla.Text = reader("total")

        reader.Close()
        conex.Close()

        comando1 = New SqlCommand("select numero,tipo,prefijo,letra,fec_emi,id_cliente,nombre,tipo_iva,cuit,direccion,forma_pago,talon from compra_cab where compra_cab.numero = '" & RTrim(numero) & "' and compra_cab.letra = '" & RTrim(letra) & "' and compra_cab.tipo = '" & RTrim(tipo) & "' and compra_cab.prefijo = '" & RTrim(prefijo) & "'", conex)
        If conex.State = ConnectionState.Closed Then conex.Open()

        reader = comando1.ExecuteReader
        reader.Read()

        Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo") & " - " & reader("letra") & " - " & reader("prefijo") & " - " & reader("numero") & "   -   " & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emi") & "     " & reader("forma_pago") & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva Insc%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

        Form_muestra_factura.txt_tipo.Text = reader("tipo")
        Form_muestra_factura.txt_letra.Text = reader("letra")
        Form_muestra_factura.txt_prefijo.Text = reader("prefijo")
        Form_muestra_factura.txt_numero.Text = reader("numero")
        Form_muestra_factura.dt_fec.Value = reader("fec_emi")
        Form_muestra_factura.txt_nombre.Text = reader("nombre")
        Form_muestra_factura.txt_f_pago.Text = reader("forma_pago")
        Form_muestra_factura.txt_talon.Text = reader("talon")
        Form_muestra_factura.txt_comprobante.Text = "Compra"

        reader.Close()

        Form_muestra_factura.Show()

    End Sub

    Public Sub carga_orden_pago(ByVal tipo, ByVal letra, ByVal prefijo, ByVal numero)

        tb1.Clear()
        conex = New SqlConnection
        conex = conecta()

        comando = New SqlDataAdapter("select fecha,tipo_fact,letra_fact,pre_fact,num_fact,cancelado from recibo_det inner join recibo_cab on recibo_det.letra_01 = '" & RTrim(letra) & "' and recibo_det.id_det = '" & RTrim(numero) & "' and recibo_det.tc1 = '" & RTrim(tipo) & "' and recibo_det.pre1='" & RTrim(prefijo) & "' and recibo_cab.id_rec = recibo_det.id_det and recibo_cab.letra = recibo_det.letra_01 and recibo_cab.tc = recibo_det.tc1 and recibo_cab.pre = recibo_det.pre1", conex)
        comando.Fill(tb1)

        Form_muestra_factura.DataGridView1.DataSource = tb1

        comando1 = New SqlCommand("select total,pago from recibo_tot where id_tot = '" & Trim(numero) & "' and lt = '" & Trim(letra) & "' and pre2='" & prefijo & "' and tip ='" & Trim(tipo) & "'", conex)
        If conex.State = ConnectionState.Closed Then conex.Open()

        Dim reader As SqlDataReader = comando1.ExecuteReader

        reader.Read()

        Form_muestra_factura.txt_total_grilla.Text = reader("total")
        Dim pago As String = reader("pago")

        reader.Close()
        conex.Close()

        comando1 = New SqlCommand("select id_rec,tc,letra,pre,fec_emi,id_cli,nombre,direccion,saldo_ant,talon,p_venta2 from recibo_cab where recibo_cab.id_rec = '" & RTrim(numero) & "' and recibo_cab.letra = '" & RTrim(letra) & "' and pre='" & Trim(prefijo) & "' and tc= '" & Trim(tipo) & "'", conex)
        conex.Open()

        reader = comando1.ExecuteReader
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

        Form_muestra_cons_comp.es_recibo = False
        Form_muestra_factura.Show()

    End Sub
End Class