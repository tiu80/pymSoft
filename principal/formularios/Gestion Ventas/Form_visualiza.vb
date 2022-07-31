Imports System.Data
Imports System.Data.SqlClient

Public Class Form_visualiza

    Private Sub Form_visualiza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.txt_estado_form.Text = 1 Then

            Me.cmb_tipo.Items.Add("FC")
            Me.cmb_tipo.Items.Add("NC")
            Me.cmb_tipo.Items.Add("PD")
            Me.cmb_tipo.Items.Add("RC")
            Me.cmb_tipo.Items.Add("ND")
            Me.cmb_tipo.Items.Add("PR")
            Me.cmb_talonario.Text = Me.cmb_talonario.Items(0)

            Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)

        End If

        If Me.txt_estado_form.Text = 2 Then

            Me.cmb_tipo.Items.Add("RE")
            Me.cmb_tipo.Items.Add("RS")
            Me.cmb_talonario.Text = Me.cmb_talonario.Items(0)

            Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)

        End If

        If Me.txt_estado_form.Text = 3 Then

            Me.cmb_tipo.Items.Add("FC")
            Me.cmb_tipo.Items.Add("NC")
            Me.cmb_talonario.Text = Me.cmb_talonario.Items(0)

            Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)

        End If

    End Sub

    Private Sub txt_prefijo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_prefijo.GotFocus
        Me.txt_prefijo.SelectAll()
    End Sub

    Private Sub txt_prefijo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_prefijo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_numero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.GotFocus
        Me.txt_numero.SelectAll()
    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmd_acepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta.Click

        Dim midataset As New DataSet
        Dim comando As SqlDataAdapter
        Dim comando1 As SqlCommand
        Dim valor As Single
        Dim conex As New SqlConnection

        conex = conecta()

        Form_muestra_factura.txt_verifica_anular_borrar.Text = 1

        Try

            If Me.txt_estado_form.Text = 3 Then

                comando = New SqlDataAdapter("select cuenta,detalle,neto,iva_ins,imp_interno,exento,per_iva,per_ib from compra_det inner join compra_tot on compra_det.lt = '" & RTrim(Me.txt_letra.Text) & "' and compra_det.num = '" & RTrim(Me.txt_numero.Text) & "' and compra_det.tipo1 = '" & RTrim(Me.cmb_tipo.Text) & "' and compra_det.pre = '" & RTrim(Me.txt_prefijo.Text) & "' where compra_det.num = compra_tot.num1 and compra_det.lt = compra_tot.lt1 and compra_det.pre = compra_tot.pre1 and compra_det.tipo1 = compra_tot.tipo2", conex)
                comando.Fill(midataset, "compra_det")

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables(0)

                comando1 = New SqlCommand("select neto,imp_interno,exento,iva_ins,fec_emi2 from compra_tot where num1 = '" & RTrim(Me.txt_numero.Text) & "' and tipo2 = '" & RTrim(Me.cmb_tipo.Text) & "' and lt1 = '" & RTrim(Me.txt_letra.Text) & "' and pre1 = '" & RTrim(Me.txt_prefijo.Text) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader1 As SqlDataReader = comando1.ExecuteReader

                reader1.Read()

                Form_muestra_factura.txt_estado_form.Text = 1
                Form_muestra_factura.txt_comprobante.Text = "compra"
                Form_muestra_factura.txt_inscripto.Text = reader1("iva_ins")
                Form_muestra_factura.txt_exento.Text = reader1("exento")
                Form_muestra_factura.txt_imp_interno_grilla.Text = reader1("imp_interno")
                Form_muestra_factura.txt_total_grilla.Text = reader1("neto")
                Form_muestra_factura.dt_fec.Text = reader1("fec_emi2")
                Form_muestra_factura.txt_gravado.Text = Form_muestra_factura.txt_total_grilla.Text - Form_muestra_factura.txt_inscripto.Text - Form_muestra_factura.txt_imp_interno_grilla.Text - Form_muestra_factura.txt_imp_interno_grilla.Text

                reader1.Close()
                conex.Close()

                comando1 = New SqlCommand("select numero,letra,prefijo,tipo,id_cliente,nombre,direccion,forma_pago,lista,tipo_iva,fec_emi from compra_cab where numero = '" & RTrim(Me.txt_numero.Text) & "' and letra= '" & RTrim(Me.txt_letra.Text) & "' and tipo = '" & RTrim(Me.cmb_tipo.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader1 = comando1.ExecuteReader
                reader1.Read()

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader1("nombre") & vbCrLf & "Direccion:" & "   " & reader1("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader1("tipo_iva") & vbCrLf & "Comprobante:" & "  " & reader1("tipo") & " - " & reader1("letra") & " - " & reader1("prefijo") & " - " & reader1("numero") & vbCrLf & "Fecha Emision:" & "  " & reader1("fec_emi") & "     " & reader1("forma_pago") & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                Form_muestra_factura.txt_tipo.Text = reader1("tipo")
                Form_muestra_factura.txt_letra.Text = reader1("letra")
                Form_muestra_factura.txt_prefijo.Text = reader1("prefijo")
                Form_muestra_factura.txt_numero.Text = reader1("numero")
                Form_muestra_factura.txt_nombre.Text = reader1("nombre")
                Form_muestra_factura.txt_f_pago.Text = reader1("forma_pago")
                Form_muestra_factura.txt_talon.Text = reader1("prefijo")

                reader1.Close()

                Me.txt_prefijo.Text = ""
                Me.txt_letra.Text = ""
                Me.txt_numero.Text = ""
                Me.cmb_tipo.Focus()

                Form_muestra_factura.Show()
                Exit Sub

            End If

            If RTrim(Me.cmb_tipo.Text) = "RC" Then

                comando = New SqlDataAdapter("select fecha,tipo_fact,letra_fact,pre_fact,num_fact,cancelado from recibo_det where recibo_det.letra_01 = '" & RTrim(Me.txt_letra.Text) & "' and recibo_det.id_det = '" & RTrim(Me.txt_numero.Text) & "' and recibo_det.tc1 = 'RC' and pre1='" & RTrim(Me.txt_prefijo.Text) & "' and recibo_det.talon1 = '" & Trim(Me.cmb_talonario.Text) & "'", conex)
                comando.Fill(midataset, "recibo_det")

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("recibo_det")

                comando1 = New SqlCommand("select total from recibo_tot where id_tot = '" & Me.txt_numero.Text & "' and lt = '" & Me.txt_letra.Text & "' and pre2='" & Me.txt_prefijo.Text & "' and recibo_tot.talon2 = '" & Trim(Me.cmb_talonario.Text) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader1 As SqlDataReader = comando1.ExecuteReader

                reader1.Read()

                Form_muestra_factura.txt_total_grilla.Text = reader1("total")

                reader1.Close()
                conex.Close()

                comando1 = New SqlCommand("select id_rec,tc,letra,pre,fec_emi,id_cli,nombre,direccion,saldo_ant,p_venta2 from recibo_cab where recibo_cab.id_rec = '" & RTrim(Me.txt_numero.Text) & "' and recibo_cab.letra = '" & RTrim(Me.txt_letra.Text) & "' and pre='" & Me.txt_prefijo.Text & "' and recibo_cab.talon = '" & Trim(Me.cmb_talonario.Text) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader1 = comando1.ExecuteReader
                reader1.Read()

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader1("nombre") & vbCrLf & "Direccion:" & "   " & reader1("direccion") & vbCrLf & "Comprobante:" & "  " & reader1("tc") & " - " & reader1("letra") & " - " & reader1("id_rec") & vbCrLf & "Fecha Emision:" & "  " & reader1("fec_emi") & vbCrLf & "Saldo Anterior:" & "  " & reader1("saldo_ant") & vbCrLf & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                Form_muestra_factura.txt_tipo.Text = reader1("tc")
                Form_muestra_factura.txt_letra.Text = reader1("letra")
                Form_muestra_factura.txt_prefijo.Text = reader1("pre")
                Form_muestra_factura.txt_numero.Text = reader1("id_rec")
                Form_muestra_factura.txt_nombre.Text = reader1("nombre")
                Form_muestra_factura.txt_codigo_cli.Text = reader1("id_cli")
                Form_muestra_factura.dt_fec.Value = reader1("fec_emi")
                Form_muestra_factura.txt_talon.Text = Me.cmb_talonario.Text
                Form_muestra_factura.txt_comprobante.Text = "cobro"

                reader1.Close()

                Form_muestra_cons_comp.es_recibo = False

                Me.txt_prefijo.Text = ""
                Me.txt_letra.Text = ""
                Me.txt_numero.Text = ""
                Me.cmb_tipo.Focus()

                Form_muestra_factura.Show()
                Exit Sub

            End If

            If RTrim(Me.cmb_tipo.Text) = "PR" Then

                comando = New SqlDataAdapter("select Distinct cli_01.id_cli,cli_01.nombre,cli_01.direccion,cli_01.tipo_cliente,cli_01.localidad,presupuesto.num,presupuesto.fecha_emision1 from cli_01 inner join presupuesto on cli_01.id_cli = presupuesto.id_cli and presupuesto.num= '" & RTrim(Me.txt_numero.Text) & "'", conex)
                comando.Fill(midataset, "cli_01")

                Form_muestra_factura.DataGridView1.DataSource = midataset.Tables("presupuesto")

                comando1 = New SqlCommand("select tot from presupuesto where num = '" & Me.txt_numero.Text & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim reader1 As SqlDataReader = comando1.ExecuteReader

                reader1.Read()

                Form_muestra_factura.txt_total_grilla.Text = reader1("tot")

                reader1.Close()
                conex.Close()

                comando1 = New SqlCommand("select fecha_emision1,descrip,cant,precio,descuento,total1,num,0,0 from presupuesto where num = '" & RTrim(Me.txt_numero.Text) & "'", conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                reader1 = comando1.ExecuteReader

                reader1.Read()

                Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & midataset.Tables("cli_01").Rows(0).Item(1).ToString() & vbCrLf & "Direccion:" & "   " & midataset.Tables("cli_01").Rows(0).Item(2).ToString() & vbCrLf & "Comprobante:" & "  " & "PR" & " - " & midataset.Tables("cli_01").Rows(0).Item(5).ToString() & vbCrLf & "Fecha Emision:" & "  " & midataset.Tables("cli_01").Rows(0).Item(6).ToString() & vbCrLf & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

                Form_muestra_factura.txt_tipo.Text = "PR"
                Form_muestra_factura.txt_numero.Text = reader1("num")
                'Form_muestra_factura.txt_nombre.Text = reader1("nombre")
                'Form_muestra_factura.txt_codigo_cli.Text = reader1("id_cli")
                Form_muestra_factura.dt_fec.Value = reader1("fecha_emision1")
                Form_muestra_factura.txt_comprobante.Text = "venta"

                reader1.Close()

                Me.txt_prefijo.Text = ""
                Me.txt_letra.Text = ""
                Me.txt_numero.Text = ""
                Me.cmb_tipo.Focus()

                Form_muestra_factura.Show()
                Exit Sub

            End If

            comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,total1,descuento,iva_inscripto,imp_interno,exento1,mes,año,cantidad_sin_stock from fact_det where fact_det.letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and fact_det.num_fact = '" & RTrim(Me.txt_numero.Text) & "' and fact_det.tipo_fact2 = '" & RTrim(Me.cmb_tipo.Text) & "' and fact_det.prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and fact_det.talon1 = '" & RTrim(Me.cmb_talonario.Text) & "'", conex)
            comando.Fill(midataset, "fact_det")

            Form_muestra_factura.txt_mes.Text = midataset.Tables("fact_det").Rows(0).Item(9)
            Form_muestra_factura.txt_año.Text = midataset.Tables("fact_det").Rows(0).Item(10)

            Form_muestra_factura.DataGridView1.DataSource = midataset.Tables(0)

            Form_muestra_factura.DataGridView1.Columns(9).Visible = False
            Form_muestra_factura.DataGridView1.Columns(10).Visible = False
            Form_muestra_factura.DataGridView1.Columns(11).Visible = False

            comando1 = New SqlCommand("select sub_total,exento,iva_ins,iva_10,imp_interno1,total,descuento,fecha_emision1,comentario from fact_tot inner join fact_cab on fact_tot.num_factura = '" & RTrim(Me.txt_numero.Text) & "' and fact_tot.tipo_factura = '" & RTrim(Me.cmb_tipo.Text) & "' and fact_tot.letra = '" & RTrim(Me.txt_letra.Text) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and fact_tot.talon2 = '" & RTrim(Me.cmb_talonario.Text) & "' where fact_cab.prefijo_fact = fact_tot.pref and fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.letra_fact=fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.talon = fact_tot.talon2", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando1.ExecuteReader

            reader.Read()

            Form_muestra_factura.txt_comprobante.Text = "venta"
            Form_muestra_factura.txt_gravado.Text = reader("Sub_total")
            Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
            Form_muestra_factura.txt_exento.Text = reader("exento")
            Form_muestra_factura.txt_no_inscripto.Text = reader("iva_10")
            Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno1")
            Form_muestra_factura.txt_total_grilla.Text = reader("total")
            Form_muestra_factura.dt_fec.Text = reader("fecha_emision1")
            Form_muestra_factura.valor = reader("comentario")
            valor = reader("descuento")

            reader.Close()
            conex.Close()

            comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact,talon,cae,venc_cae from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and fact_cab.letra_fact= '" & RTrim(Me.txt_letra.Text) & "' and fact_cab.tipo_fact = '" & RTrim(Me.cmb_tipo.Text) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and fact_cab.talon = '" & RTrim(Me.cmb_talonario.Text) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            reader = comando1.ExecuteReader
            reader.Read()

            Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & vbCrLf & "Descuento Total Factura:" & "   " & valor & "%" & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

            Form_muestra_factura.txt_tipo.Text = reader("tipo_fact")
            Form_muestra_factura.txt_letra.Text = reader("letra_fact")
            Form_muestra_factura.txt_prefijo.Text = reader("prefijo_fact")
            Form_muestra_factura.txt_numero.Text = reader("num_fact1")
            Form_muestra_factura.txt_nombre.Text = reader("nombre")
            Form_muestra_factura.txt_f_pago.Text = reader("forma_pago")
            Form_muestra_factura.txt_talon.Text = reader("talon")
            Form_muestra_factura.txt_estado_fact.Text = reader("estado_fact")
            Form_muestra_factura.txt_cae.Text = reader("cae")
            Form_muestra_factura.txt_venc_cae.Text = reader("venc_cae")

            reader.Close()

            Me.txt_prefijo.Text = ""
            Me.txt_letra.Text = ""
            Me.txt_numero.Text = ""
            Me.cmb_tipo.Focus()

            If RTrim(Me.cmb_tipo.Text) = "PD" Then
                Form_muestra_factura.tol_anula.Enabled = False
                Form_muestra_factura.tol_forma_cobro.Enabled = False
            End If

        Catch ex As Exception

            MsgBox(Err.Description, MsgBoxStyle.Critical, "PyMsoft")
            Me.txt_letra.Text = ""
            Me.txt_numero.Text = ""
            Me.txt_prefijo.Text = ""
            Me.cmb_tipo.Focus()
            Exit Sub

        Finally

            conex.Close()
            midataset.Dispose()

        End Try

        Form_muestra_factura.Show()

    End Sub

    Private Sub txt_letra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_letra.GotFocus
        Me.txt_letra.SelectAll()
    End Sub

    Private Sub txt_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_letra.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub cmd_cancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancela.Click
        Me.Dispose()
    End Sub
End Class