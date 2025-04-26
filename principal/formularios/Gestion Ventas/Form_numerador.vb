Imports System.Data
Imports System.Data.SqlClient

Public Class Form_numerador

    Dim tal As New pymsoft.talonario
    Dim fact As New pymsoft.factura
    Dim fac_elec As New pymsoft.factura_electronica
    Dim sel As New pymsoft.selecciona

    Dim veri As Boolean

    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim dia, mes, año, cuit_empresa As String
    Dim estado As Boolean = True
    Dim qr As Byte()

    Private Sub txt_factura_a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_factura_b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_factura_c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_n_credito_a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_n_credito_b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_pedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_punto_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_recibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_remito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_talonario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmd_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_guardar.Click

        tal.instruccion = "INSERT INTO numerador(talon,punto_venta,fact_a,fact_b,fact_c,recibo,remito,pedido,n_credito_a,n_credito_b,orden_pago,n_debito_a,n_debito_b,n_credito_c,cae,venc_cae) VALUES('" + Me.txt_talonario.Text + "' , '" + Me.txt_punto_venta.Text + "','" + Me.txt_fact_a.Text + "','" + Me.txt_fact_b.Text + "','" + Me.txt_fact_c.Text + "','" + Me.txt_recibo.Text + "','" + Me.txt_remito.Text + "','" + Me.txt_pedido.Text + "','" + Me.txt_n_credito_a.Text + "','" + Me.txt_n_credito_b.Text + "','" + Me.txt_orden_pago.Text + "','" + Me.txt_debito_a.Text + "','" + Me.txt_debito_b.Text + "','" + Me.txt_n_credito_c.Text + "','','')"
        tal.agregar()
        Call limpiar()

    End Sub

    Public Sub limpiar()

        Me.txt_fact_a.Text = 0
        Me.txt_fact_b.Text = 0
        Me.txt_fact_c.Text = 0
        Me.txt_recibo.Text = 0
        Me.txt_pedido.Text = 0
        Me.txt_remito.Text = 0
        Me.txt_debito_a.Text = 0
        Me.txt_debito_b.Text = 0
        Me.txt_debito_c.Text = 0
        Me.txt_n_credito_a.Text = 0
        Me.txt_n_credito_b.Text = 0
        Me.txt_orden_pago.Text = 0
        Me.txt_punto_venta.Focus()
        Me.txt_punto_venta.SelectAll()

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        tal.verifiva_numerador()

        If Me.txt_venc_cae.Text = "  /  /" Then
            Me.txt_venc_cae.Text = "01/01/1900"
        End If

        If Form_factura_preventa.txt_estado_form.Text <> 1 Then

            If tal.verifica = True And tal.evalua = True Then

                tal.instruccion = "update numerador set talon = '" & Me.txt_talonario.Text & "',punto_venta = '" & Me.txt_punto_venta.Text & "', fact_a = '" & Me.txt_fact_a.Text & "',fact_b ='" & Me.txt_fact_b.Text & "',fact_c='" & Me.txt_fact_c.Text & "',recibo ='" & Me.txt_recibo.Text & "',remito ='" & Me.txt_remito.Text & "',pedido ='" & Me.txt_pedido.Text & "',n_credito_a ='" & Me.txt_n_credito_a.Text & "',n_credito_b ='" & Me.txt_n_credito_b.Text & "',orden_pago = '" + Me.txt_orden_pago.Text + "',n_debito_a = '" + Me.txt_debito_a.Text + "',n_debito_b = '" + Me.txt_debito_b.Text + "',cae = '" + Me.txt_cae.Text + "',venc_cae = '" + Me.txt_venc_cae.Text + "' where punto_venta = '" & RTrim(Me.txt_int_p_vta.Text) & "' and talon = '" & RTrim(Me.txt_talonario.Text) & "'"
                tal.actualizar()
                tal.instruccion = "update numerador set remito ='" & Me.txt_remito.Text & "', pedido = '" & Me.txt_pedido.Text & "', recibo = '" & Me.txt_recibo.Text & "' where talon <> '0'"
                tal.actualizar()

                MessageBox.Show("Numerador actualizado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                tal.instruccion = "select *from numerador"
                tal.mostrar()
                Exit Sub

            End If

            Me.Close()

        End If

        If Form_factura_preventa.txt_estado_form.Text = 1 Then

            If tal.verifica = False Then

                tal.instruccion = "select *from numerador"
                tal.mostrar()
                tal.verifica = True
                Exit Sub

            End If

            Me.Hide()

            ' esto es un parche que se hizo para riopedrecongelados
            ' xq tenia el mimso punto de venta en bco y negro y generaba 
            'diferencias en las cuentas corrientes y demas
            ' con esto se logra poner siempre la letra C a lo negro
            If Me.txt_talonario.Text = 2 Then Form_factura_preventa.txt_letra.Text = "C"

            Call actualiza_numerador_preventa()

            Exit Sub

        End If

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Dim a As Integer

        Call verifica_prefijo()

        If veri = False Then
            Exit Sub
        End If

        a = MessageBox.Show("Esta seguro que desea Borrarlo", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            tal.instruccion = "DELETE numerador WHERE talon = '" & Me.txt_talonario.Text & "' and punto_venta = '" & Me.txt_punto_venta.Text & "'"
            tal.borrar()

        End If

    End Sub

    Private Sub Form_numerador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        estado = True

        If Form_factura_preventa.txt_estado_form.Text = 1 Then

            If Form_factura_preventa.txt_talon.Text = 2 Then tal.instruccion = "select *from numerador where talon = 2"
            If Form_factura_preventa.txt_talon.Text = 1 Then tal.instruccion = "select *from numerador where talon = 1 and punto_venta = '" & fact.punto_venta & "'"
            tal.mostrar()
            Me.txt_talonario.Focus()

            Me.cmd_guardar.Enabled = False
            Me.cmd_guardar.BackColor = Color.LightGray
            Me.cmd_eliminar.Enabled = False
            Me.cmd_eliminar.BackColor = Color.LightGray

            Exit Sub

        End If

        tal.instruccion = "select *from numerador "
        tal.mostrar()
        Me.txt_talonario.Focus()

    End Sub

    Private Sub txt_talonario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_talonario.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            If Me.txt_talonario.Text = "0" Then
                MessageBox.Show("Error Numero Talonario", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Call limpiar()
                Exit Sub
            End If

            Me.txt_punto_venta.Focus()

        End If

    End Sub

    Private Sub verifica_prefijo()

        If Me.txt_talonario.Text = 1 Or Me.txt_talonario.Text = 2 Then
            MessageBox.Show("No se puede borrar este Talonario", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            veri = False
            Exit Sub
        End If

    End Sub

    Private Sub txt_punto_venta_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_punto_venta.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            tal.instruccion = "select *from numerador where talon ='" & Me.txt_talonario.Text & "' and punto_venta = '" & Me.txt_punto_venta.Text & "'"
            tal.mostrar()
            Me.txt_fact_a.Focus()

            If Form_factura_preventa.txt_estado_form.Text = 1 Then
                Me.cmd_guardar.Enabled = False
                Me.cmd_guardar.BackColor = Color.LightGray
                Me.cmd_eliminar.Enabled = False
                Me.cmd_eliminar.BackColor = Color.LightGray
            End If

        End If

    End Sub

    Private Sub actualiza_numerador_preventa()

        Dim numero_factura As Integer = 0
        Dim i As Integer = 0

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' actualiza a factura C
        If RTrim(Form_factura_preventa.txt_letra.Text) = "C" Then

            ' SI ESTA HABILITADO VERIFICO WEB SERVICE 
            If fact.Factura_electronica_AFIP = "SI" And fact.Graba_AFIP = "SI" And Me.txt_talonario.Text = 1 And Trim(Me.txt_punto_venta.Text) = Trim(fact.punto_venta) Then

                sel.instruccion = "select *from empresa_01"
                sel.nombre_tabla = "empresa_01"
                sel.carga_campos()

                fac_elec.Concepto = 1

                fac_elec.Tipo_comprobante = 11
                fac_elec.Tipo_documento = 99
                fac_elec.Numero_documento = 0
                fac_elec.Punto_venta = Me.txt_punto_venta.Text
                fac_elec.Comprobante_desde = CLng(Me.txt_fact_c.Text)
                fac_elec.Comprobante_hasta = CLng(Me.txt_fact_c.Text)
                fac_elec.Importe_total = Form_factura_preventa.txt_total_grilla.Text
                fac_elec.Importe_neto = Form_factura_preventa.txt_total_grilla.Text
                fac_elec.Importe_iva = "0.00"

                fac_elec.Fecha_comprobante = Format(Date.Now, "yyyyMMdd")

                'estado = fac_elec.carga_factura_electronica(0, 0, "C", sel.cuit, sel.CRT, sel.KEY, CLng(Me.txt_fact_c.Text), Trim(Form_factura_preventa.txt_iva.Text))
                estado = fac_elec.AutorizarFactura(Replace(sel.cuit, "-", ""), CLng(Me.txt_fact_c.Text), Trim(Form_factura_preventa.txt_iva.Text), 0, 0, "C")

                If fac_elec.Numeradores_distintos = True Then
                    MessageBox.Show("La numeracion del sistemas no es laisma que AFIP.. Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Exit Sub
                End If

                If estado = False Then
                    MessageBox.Show("La Factura no se grabo en el AFIP....Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Exit Sub
                Else
                    qr = fac_elec.gerena_QR_factura(sel.cuit, Form_factura_preventa.QrCodeImgControl1)
                End If

            Else

                qr = System.Text.Encoding.UTF8.GetBytes(1)

                'MessageBox.Show(" CAE: " & fact_elec.cae_afip & " Venc: " & fact_elec.Fecha_cae, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If estado = True Then

                ' SI ESTA TODO BIEN ACTUALIZO EL PEDIDO A FACTURA
                tal.instruccion = "update fact_cab set qr = @qr where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar_con_qr(qr)

                tal.instruccion = "update fact_cab set fec_emision = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact1 = '" & Me.txt_fact_c.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'C',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE',cae = '" & fac_elec.cae_afip & "',venc_cae = '" & fac_elec.Fecha_cae & "' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                tal.instruccion = "update fact_det set fec_emi = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact = '" & Me.txt_fact_c.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'C',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
                tal.actualizar()

                tal.instruccion = "update fact_tot set fecha_emision1 = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_factura = '" & Me.txt_fact_c.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'C',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                numero_factura = Me.txt_fact_c.Text

            End If

                ' SI ESTA HABILITADO IMPRIMO EN FISCAL
                If fact.Imprime_en_fiscal = "SI" Then

                    If fact.Talonario_predeterminado = 2 Or fact.Imprime_en_fiscal = "NO" Then
                        Exit Sub
                    End If

                    If RTrim(fact.fiscal_epson) = "SI" Then

                        'fact.imprime_ticket_fisca_epson_tm220()

                    End If

                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' actualiza a factura B
        If RTrim(Form_factura_preventa.txt_letra.Text) = "B" Then

            ' SI ESTA HABILITADO VERIFICO WEB SERVICE
            If fact.Factura_electronica_AFIP = "SI" And fact.Graba_AFIP = "SI" And Me.txt_talonario.Text = 1 And Trim(Me.txt_punto_venta.Text) = Trim(fact.punto_venta) Then

                sel.instruccion = "select *from empresa_01"
                sel.nombre_tabla = "empresa_01"
                sel.carga_campos()

                fac_elec.Concepto = 1

                If RTrim(Form_factura_preventa.txt_iva.Text) = "Consumidor Final" Then
                    fac_elec.Tipo_comprobante = 6
                    fac_elec.Tipo_documento = 99
                    fac_elec.Numero_documento = 0
                End If

                If RTrim(Form_factura_preventa.txt_iva.Text) = "Exento" Then
                    fac_elec.Tipo_comprobante = 6
                    fac_elec.Tipo_documento = 80
                    fac_elec.Numero_documento = RTrim(Replace(Form_factura_preventa.txt_cuit.Text, "-", ""))
                End If

                fac_elec.Punto_venta = Me.txt_punto_venta.Text
                fac_elec.Comprobante_desde = CLng(Me.txt_fact_b.Text)
                fac_elec.Comprobante_hasta = CLng(Me.txt_fact_b.Text)
                fac_elec.Importe_total = Form_factura_preventa.txt_total_grilla.Text
                fac_elec.Importe_neto = Form_factura_preventa.txt_gravado.Text
                fac_elec.Importe_iva = Val(Form_factura_preventa.txt_inscripto.Text) + Val(Form_factura_preventa.txt_insc_10.Text)
                fac_elec.Neto_10 = Form_factura_preventa.neto_10
                fac_elec.Neto_21 = Form_factura_preventa.neto_21

                fac_elec.Fecha_comprobante = Format(Date.Now, "yyyyMMdd")

                'estado = fac_elec.carga_factura_electronica(Form_factura_preventa.txt_insc_10.Text, Form_factura_preventa.txt_inscripto.Text, "B", sel.cuit, sel.CRT, sel.KEY, CLng(Me.txt_fact_b.Text), Trim(Form_factura_preventa.txt_iva.Text))
                estado = fac_elec.AutorizarFactura(Replace(sel.cuit, "-", ""), CLng(Me.txt_fact_b.Text), Trim(Form_factura_preventa.txt_iva.Text), Form_factura_preventa.txt_insc_10.Text, Form_factura_preventa.txt_inscripto.Text, "B")

                If estado = False Then
                    MessageBox.Show("La Factura no se grabo en el AFIP....Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Exit Sub
                Else
                    qr = fac_elec.gerena_QR_factura(sel.cuit, Form_factura_preventa.QrCodeImgControl1)
                End If

            Else

                qr = System.Text.Encoding.UTF8.GetBytes(1)

                'MessageBox.Show(" CAE: " & fact_elec.cae_afip & " Venc: " & fact_elec.Fecha_cae, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If estado = True Then

                tal.instruccion = "update fact_cab set qr = @qr where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar_con_qr(qr)

                tal.instruccion = "update fact_cab set fec_emision = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact1 = '" & Me.txt_fact_b.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'B',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE',cae = '" & fac_elec.cae_afip & "',venc_cae = '" & fac_elec.Fecha_cae & "' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                tal.instruccion = "update fact_det set fec_emi = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact = '" & Me.txt_fact_b.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'B',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
                tal.actualizar()

                tal.instruccion = "update fact_tot set id_cliente = '" & Trim(Form_factura_preventa.txt_cod_cli.Text) & "',fecha_emision1 = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_factura = '" & Me.txt_fact_b.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'B',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                numero_factura = Me.txt_fact_b.Text

            End If

        End If

        ' actualiza a factura A
        If RTrim(Form_factura_preventa.txt_letra.Text) = "A" Then


            ' SI ESTA HABILITADO VERIFICO WEB SERVICE
            If fact.Factura_electronica_AFIP = "SI" And fact.Graba_AFIP = "SI" And Me.txt_talonario.Text = 1 And Trim(Me.txt_punto_venta.Text) = Trim(fact.punto_venta) Then

                sel.instruccion = "select *from empresa_01"
                sel.nombre_tabla = "empresa_01"
                sel.carga_campos()

                fac_elec.Concepto = 1

                fac_elec.Tipo_comprobante = 1
                fac_elec.Tipo_documento = 80
                fac_elec.Numero_documento = RTrim(Replace(Form_factura_preventa.txt_cuit.Text, "-", ""))
                fac_elec.Punto_venta = Me.txt_punto_venta.Text
                fac_elec.Comprobante_desde = CLng(Me.txt_fact_a.Text)
                fac_elec.Comprobante_hasta = CLng(Me.txt_fact_a.Text)
                fac_elec.Importe_total = Form_factura_preventa.txt_total_grilla.Text
                fac_elec.Importe_neto = Form_factura_preventa.txt_gravado.Text
                fac_elec.Importe_iva = Val(Form_factura_preventa.txt_inscripto.Text) + Val(Form_factura_preventa.txt_insc_10.Text)
                fac_elec.Neto_10 = Form_factura_preventa.neto_10
                fac_elec.Neto_21 = Form_factura_preventa.neto_21

                fac_elec.Fecha_comprobante = Format(Date.Now, "yyyyMMdd")

                'estado = fac_elec.carga_factura_electronica(Form_factura_preventa.txt_insc_10.Text, Form_factura_preventa.txt_inscripto.Text, "A", sel.cuit, sel.CRT, sel.KEY, CLng(Me.txt_fact_a.Text), Trim(Form_factura_preventa.txt_iva.Text))
                estado = fac_elec.AutorizarFactura(Replace(sel.cuit, "-", ""), CLng(Me.txt_fact_a.Text), Trim(Form_factura_preventa.txt_iva.Text), Form_factura_preventa.txt_insc_10.Text, Form_factura_preventa.txt_inscripto.Text, "A")

                If estado = False Then
                    MessageBox.Show("La Factura no se grabo en el AFIP....Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Exit Sub
                Else
                    qr = fac_elec.gerena_QR_factura(sel.cuit, Form_factura_preventa.QrCodeImgControl1)
                End If

            Else

                qr = System.Text.Encoding.UTF8.GetBytes(1)

                'MessageBox.Show(" CAE: " & fact_elec.cae_afip & " Venc: " & fact_elec.Fecha_cae, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If estado = True Then

                tal.instruccion = "update fact_cab set qr = @qr where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar_con_qr(qr)

                tal.instruccion = "update fact_cab set fec_emision = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact1 = '" & Me.txt_fact_a.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'A',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE',cae = '" & fac_elec.cae_afip & "',venc_cae = '" & fac_elec.Fecha_cae & "' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                tal.instruccion = "update fact_det set fec_emi = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_fact = '" & Me.txt_fact_a.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'A',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
                tal.actualizar()

                tal.instruccion = "update fact_tot set id_cliente = '" & Trim(Form_factura_preventa.txt_cod_cli.Text) & "',fecha_emision1 = '" & Date.Now.ToString("yyyy/dd/MM") & "',num_factura = '" & Me.txt_fact_a.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'A',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
                tal.actualizar()

                numero_factura = Me.txt_fact_a.Text

            End If

        End If

        'imprime factura

        If Form_factura_preventa.az = 6 Then

            fact.form_txt_letra = Form_factura_preventa.txt_letra.Text
            fact.tipo_fact = "FC"
            fact.form_txt = "FACTURA"
            fact.imprimir_factura(numero_factura, Form_factura_preventa.txt_letra.Text, Me.txt_punto_venta.Text, fact.tipo_fact, Me.txt_talonario.Text, fact.form_txt, Form_factura_preventa.txt_iva.Text)

        End If

        form_factura.borra_tabla_art_act(Form_factura_preventa.nom_computadora)

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("INSERT INTO cta_cte01(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,confirma,cod_vend) VALUES('" & numero_factura & "','FC', '" + Form_factura_preventa.txt_letra.Text + "','" + Me.txt_punto_venta.Text + "','" + Form_factura_preventa.txt_cod_cli.Text + "','" + Form_factura_preventa.txt_nombre.Text + "','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Val(Form_factura_preventa.txt_total_grilla.Text) & "', '','" & numero_factura & "', 'DEBE','P','" & Form_factura_preventa.txt_vendedor.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman = New SqlCommand("INSERT INTO cta_cte_hist(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" & numero_factura & "','FC', '" + Form_factura_preventa.txt_letra.Text + "','" + Me.txt_punto_venta.Text + "','" & Val(Form_factura_preventa.txt_total_grilla.Text) & "', '','DEBE','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Form_factura_preventa.txt_cod_cli.Text & "','" & Form_factura_preventa.txt_nombre.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

        form_factura.actualiza_numeradores()

        conex.Close()
        Form_factura_preventa.Dispose()
        Form_muestra_cons_comp.carga_seleccion_cosulta()
        Me.Dispose()

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\manual\numerador.html")
    End Sub

    Private Sub cmd_verifica_ultimo_numero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_verifica_ultimo_numero.Click

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        fac_elec.Tipo_comprobante = Me.txt_tipo_comprobante_afip.Text
        fac_elec.Punto_venta = Me.txt_punto_venta_afip.Text
        sel.instruccion = "select *from empresa_01"
        sel.nombre_tabla = "empresa_01"
        sel.carga_campos()
        'fac_elec.consulta_ultimo_numero(sel.cuit, sel.CRT, sel.KEY)
        'Me.lbl_ultimo_comprobante.Text = fac_elec.ultimo_numero_afip
        fac_elec.verifica_sign_token()
        Me.lbl_ultimo_comprobante.Text = fac_elec.ObtenerUltimoComprobanteAutorizado(fac_elec.sign, fac_elec.token, Replace(sel.cuit, "-", ""), fac_elec.Tipo_comprobante, fac_elec.Punto_venta)

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub txt_tipo_comprobante_afip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tipo_comprobante_afip.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_punto_venta_afip.Focus()
            Me.txt_punto_venta_afip.SelectAll()
        End If
    End Sub

    Private Sub txt_punto_venta_afip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_punto_venta_afip.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.cmd_verifica_ultimo_numero.Focus()
        End If
    End Sub

    Private Sub cmd_consulta_comprobante_autorizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_consulta_comprobante_autorizado.Click

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        Try

            fac_elec.Tipo_comprobante = Me.txt_tipo_aut.Text
            fac_elec.Punto_venta = Me.txt_pto_vta_aut.Text
            fac_elec.ultimo_numero_afip = Me.txt_numero_aut.Text
            sel.instruccion = "select *from empresa_01"
            sel.nombre_tabla = "empresa_01"
            sel.carga_campos()

            'fac_elec.consulta_numero(sel.cuit, sel.CRT, sel.KEY, Me.txt_numero_aut.Text)
            'Me.lbl_cae.Text = fac_elec.cae_afip
            'Me.txt_cae.Text = Me.lbl_cae.Text
            'dia = fac_elec.Fecha_cae.ToString.Substring(6, 2)
            'mes = fac_elec.Fecha_cae.ToString.Substring(4, 2)
            'año = fac_elec.Fecha_cae.ToString.Substring(0, 4)
            'Me.lbl_venc_cae.Text = dia & mes & año
            'Me.txt_venc_cae.Text = Me.lbl_venc_cae.Text
            'Me.lbl_importe_cae.Text = fac_elec.importe_comprobante

            fac_elec.verifica_sign_token()
            fac_elec.ConsultarFacturaAFIP(Replace(sel.cuit, "-", ""), Me.txt_tipo_aut.Text, Me.txt_pto_vta_aut.Text, Me.txt_numero_aut.Text, fac_elec.token, fac_elec.sign)
            Me.lbl_cae.Text = fac_elec.cae_afip
            Me.txt_cae.Text = Me.lbl_cae.Text
            dia = fac_elec.Fecha_cae.ToString.Substring(6, 2)
            mes = fac_elec.Fecha_cae.ToString.Substring(4, 2)
            año = fac_elec.Fecha_cae.ToString.Substring(0, 4)
            Me.lbl_venc_cae.Text = dia & mes & año
            Me.txt_venc_cae.Text = Me.lbl_venc_cae.Text
            Me.lbl_importe_cae.Text = fac_elec.importe_comprobante

        Catch ex As Exception

        Finally

            barra_carga.Timer1.Enabled = True

        End Try

    End Sub

    Private Sub txt_tipo_aut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tipo_aut.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_pto_vta_aut.Focus()
            Me.txt_pto_vta_aut.SelectAll()
        End If
    End Sub

    Private Sub txt_pto_vta_aut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pto_vta_aut.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_numero_aut.Focus()
            Me.txt_numero_aut.SelectAll()
        End If
    End Sub

    Private Sub txt_numero_aut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numero_aut.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.cmd_consulta_comprobante_autorizado.Focus()
        End If
    End Sub

    Private Sub txt_debito_a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_debito_a.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_debito_b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_debito_b.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

End Class
