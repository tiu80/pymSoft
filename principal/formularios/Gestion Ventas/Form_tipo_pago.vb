Imports System.Data
Imports System.Data.SqlClient

Public Class Form_tipo_pago

    Dim ban As New pymsoft.prov_vend_list_bco
    Dim tipo As New pymsoft.parametro
    Dim num As New pymsoft.numerodecimales

    Dim veri, sale, no_efectivo As Boolean, duplicado As Boolean = True, flag As Boolean = True, entro_descuento As Boolean = False
    Dim cont As Int16 = 0
    Dim i, cobro As Integer
    Dim valor As Single = "0.00"
    Dim var As Single, acumula As Single
    Public act_total_cobro As Boolean
    Dim tbl As New DataTable
    Dim comando As SqlDataAdapter
    Dim coma As SqlCommand
    Dim conex As New SqlConnection

    Private Sub txt_tipo_cobro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tipo_cobro.KeyDown

        Try

            If e.KeyCode = Keys.F1 Then
                Form_muestra_opcion_pago.Show()
            End If

            If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

                If Me.txt_tipo_cobro.Text = 1 Then
                    cont = cont + 1
                    Me.lbl_tipo.Text = "Efectivo..."
                    Call desabilita_textos()

                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_total.Text = acumula
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_descripcion.Text = Form_recibos.txt_cliente.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then
                        Me.txt_total.Text = acumula
                    End If

                    'Me.txt_descuento.Enabled = True
                    'Me.txt_descuento.Focus()
                    Me.txt_total.Focus()

                    no_efectivo = True
                    Me.cmd_acepta.Enabled = True
                    Me.cmd_cancela.Enabled = True
                    cobro = Me.txt_tipo_cobro.Text

                End If

                If Me.txt_tipo_cobro.Text = 2 Then
                    Me.lbl_tipo.Text = "Cheque..."
                    Call habilita_textos_cbanco()
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_descripcion.Text = Form_recibos.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_total.Text = acumula
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    Me.txt_numero.Focus()
                    Me.txt_descuento.Enabled = False
                    Me.txt_total.ReadOnly = False
                    cont = cont + 1
                    no_efectivo = False
                    Me.cmd_acepta.Enabled = True
                    Me.cmd_cancela.Enabled = True
                End If

                If Me.txt_tipo_cobro.Text = 3 Then
                    Me.lbl_tipo.Text = "PosNet..."
                    desabilita_textos()
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_descripcion.Text = Form_recibos.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_total.Text = acumula
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    Me.txt_descuento.Enabled = False
                    Me.txt_total.Focus()
                    Me.txt_total.ReadOnly = False
                    cont = cont + 1
                    no_efectivo = False
                    Me.cmd_acepta.Enabled = True
                    Me.cmd_cancela.Enabled = True
                    cobro = Me.txt_tipo_cobro.Text
                End If

                If Me.txt_tipo_cobro.Text = 4 Then
                    Me.lbl_tipo.Text = "Vale..."
                    If Form_recibos.txt_estado_form.Text = 1 Or Form_muestra_factura.txt_tipo.Text = "RC" Then
                        MessageBox.Show("Esta opcion no esta permitida!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txt_tipo_cobro.Focus()
                        Me.cmd_acepta.Enabled = False
                        Exit Sub
                    Else
                        Me.cmd_acepta.Enabled = True
                        Me.cmd_cancela.Enabled = True
                    End If
                    desabilita_textos()
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    Me.txt_descuento.Enabled = False
                    Me.txt_total.Focus()
                    Me.txt_total.ReadOnly = False
                    cont = cont + 1
                    no_efectivo = False
                    cobro = Me.txt_tipo_cobro.Text
                End If

                If Me.txt_tipo_cobro.Text = 5 Then
                    Me.lbl_tipo.Text = "Tarjeta Credito..."
                    Call habilita_textos()
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_descripcion.Text = Form_recibos.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_total.Text = acumula
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    Me.txt_descuento.Enabled = False
                    Me.txt_numero.Focus()
                    Me.txt_total.ReadOnly = False
                    cont = cont + 1
                    no_efectivo = False
                    Me.cmd_acepta.Enabled = True
                    Me.cmd_cancela.Enabled = True
                    Me.dt_fec_acred.Enabled = False
                    cobro = Me.txt_tipo_cobro.Text
                End If

                If Me.txt_tipo_cobro.Text = 6 Then
                    Me.lbl_tipo.Text = "Tarjeta Debito..."
                    Call habilita_textos()
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = form_factura.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_descripcion.Text = Form_recibos.txt_cliente.Text
                    If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Me.txt_total.Text = acumula
                    If form_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
                    If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.txt_total.Text = acumula
                    Me.txt_descuento.Enabled = False
                    Me.txt_numero.Focus()
                    Me.txt_total.ReadOnly = False
                    no_efectivo = False
                    cont = cont + 1
                    Me.cmd_acepta.Enabled = True
                    Me.cmd_cancela.Enabled = True
                    cobro = Me.txt_tipo_cobro.Text
                End If

                If Me.txt_tipo_cobro.Text = 0 Or Me.txt_tipo_cobro.Text > 6 Or Me.txt_tipo_cobro.Text = "" Then
                    Me.txt_tipo_cobro.Focus()
                    Me.txt_tipo_cobro.Text = ""
                    Me.cmd_acepta.Enabled = False
                    Me.cmd_cancela.Enabled = False
                    cont = 0
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_numero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numero.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_descripcion.Focus()
        End If
    End Sub

    Private Sub txt_descripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descripcion.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_banco.Enabled = True Then Me.txt_banco.Focus()
            If Me.txt_banco.Enabled = False Then Me.txt_total.Focus()
        End If
    End Sub

    Private Sub txt_banco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_banco.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            ban.instruccion = "select *from bco_01 where id_bco like '" & Me.txt_banco.Text & "'"
            ban.codigo = "id_bco"
            ban.nombre = "nombre"
            ban.cargar()
            Me.txt_banco.Text = ban.text
            Me.lbl_banco.Text = ban.text2
            Me.dt_fec_acred.Focus()
        End If

        If e.KeyCode = Keys.F1 Then
            busc_bancos.Show()
        End If

    End Sub

    Private Sub dt_fec_emi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_acred.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_descuento.Enabled = True Then Me.txt_descuento.Focus()
            If Me.txt_descuento.Enabled = False Then Me.txt_total.Focus()
        End If
    End Sub

    Private Sub desabilita_textos()
        Me.txt_numero.Enabled = False
        Me.txt_descripcion.Enabled = False
        Me.txt_banco.Enabled = False
        Me.dt_fec_acred.Enabled = False
    End Sub

    Private Sub habilita_textos()
        Me.txt_numero.Enabled = True
        Me.txt_descripcion.Enabled = True
        Me.dt_fec_acred.Enabled = True
    End Sub

    Private Sub habilita_textos_cbanco()
        Me.txt_numero.Enabled = True
        Me.txt_descripcion.Enabled = True
        Me.txt_banco.Enabled = True
        Me.dt_fec_acred.Enabled = True
    End Sub

    Private Sub txt_tipo_cobro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tipo_cobro.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_tipo_cobro_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_tipo_cobro.Validating
        If Me.txt_tipo_cobro.Text = "" Then
            e.Cancel = False
        End If
    End Sub

    Private Sub cmd_acepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta.Click

        If Me.txt_tipo_cobro.Text = 2 Then Call verifica()
        If Me.txt_tipo_cobro.Text = 1 Or Me.txt_tipo_cobro.Text = 3 Or Me.txt_tipo_cobro.Text = 4 Or Me.txt_tipo_cobro.Text = 5 Or Me.txt_tipo_cobro.Text = 6 Then Call verifica1()

        If veri = False Then

            form_factura.txt_total_cobro.Text = 1
            form_factura.txt_importe_cobro.Text = Me.txt_total.Text

            If (form_factura.txt_estado_form.Text = 1 Or Form_muestra_factura.txt_tipo.Text <> "RC" Or Form_muestra_factura.txt_tipo.Text <> "OP") And Form_recibos.txt_estado_form.Text <> 1 And Form_recibos.txt_estado_form.Text <> 2 Then

                If Form_muestra_factura.txt_estado_form.Text = 1 Then
                    tipo.instruccion = "update fact_tot set efectivo = 'SI',total_cobro = '" + Me.txt_total.Text + "', descuento = '" + Me.txt_descuento.Text + "' where num_factura = '" + Form_muestra_factura.txt_numero.Text + "' and letra = '" + Form_muestra_factura.txt_letra.Text + "' and pref = '" + Form_muestra_factura.txt_prefijo.Text + "' and tipo_factura = '" + Form_muestra_factura.txt_tipo.Text + "'"
                    tipo.abm()
                    'tipo.instruccion = "update fact_tot set efectivo = 'SI' where num_factura = '" + Form_muestra_factura.txt_numero.Text + "' and letra = '" + Form_muestra_factura.txt_letra.Text + "' and pref = '" + Form_muestra_factura.txt_prefijo.Text + "' and tipo_factura = '" + Form_muestra_factura.txt_tipo.Text + "'"
                    'tipo.abm()
                End If

                tipo.instruccion = "update fact_tot set total_cobro = '" + Me.txt_total.Text + "', descuento = '" + Me.txt_descuento.Text + "' where num_factura = '" + form_factura.txt_numero.Text + "' and letra = '" + form_factura.txt_letra.Text + "' and pref = '" + form_factura.txt_prefijo.Text + "' and tipo_factura = '" + Form_muestra_factura.txt_tipo.Text + "'"
                tipo.abm()

                acumula = Format(acumula - Me.txt_total.Text, "0.00")

                Call pide_en_factura(Me.txt_num.Text, Me.txt_tipo.Text, Me.txt_letra.Text, Me.txt_pre.Text, Me.txt_num.Text, Me.txt_fec_emi.Text, Me.txt_descripcion.Text, Me.txt_banco.Text, Me.dt_fec_acred.Text, Me.txt_total.Text, Me.txt_pre.Text)

            End If

            If (Form_recibos.txt_estado_form.Text = 1 Or Form_muestra_factura.txt_tipo.Text = "RC") And form_factura.txt_estado_form.Text <> 1 Then

                If entro_descuento = False Then Form_recibos.txt_total_cobro.Text = Form_recibos.txt_total.Text
                Form_recibos.txt_importe_cobro.Text = Me.txt_total.Text

                If Form_muestra_factura.txt_estado_form.Text = 1 Then
                    tipo.instruccion = "update recibo_tot set efectivo = 'SI',total_cobro = '" + Me.txt_total.Text + "' where id_tot = '" + Form_muestra_factura.txt_numero.Text + "' and lt = '" + Form_muestra_factura.txt_letra.Text + "' and pre2 = '" + Form_muestra_factura.txt_prefijo.Text + "' and talon2 = '" + Form_muestra_factura.txt_talon.Text + "'"
                    tipo.abm()
                    'tipo.instruccion = "update recibo_tot set efectivo = 'SI' where id_tot = '" + Form_muestra_factura.txt_numero.Text + "' and lt = '" + Form_muestra_factura.txt_letra.Text + "' and pre2 = '" + Form_muestra_factura.txt_prefijo.Text + "' and talon2 = '" + Form_muestra_factura.txt_talon.Text + "'"
                    'tipo.abm()
                End If

                If Val(Me.txt_descuento.Text) > 0 Or Me.txt_descuento.Text <> "" Then
                    Form_recibos.txt_total_cobro.Text = Me.txt_total.Text
                    entro_descuento = True
                End If

                acumula = Format(acumula - Me.txt_total.Text, "0.00")

                Call pide_en_recibo(Me.txt_num.Text, Me.txt_tipo.Text, Me.txt_letra.Text, Me.txt_pre.Text, Me.txt_num.Text, Me.txt_fec_emi.Text, Me.txt_descripcion.Text, Me.txt_banco.Text, Me.dt_fec_acred.Text, Me.txt_total.Text, Me.txt_pre.Text)

            End If

            If (Form_recibos.txt_estado_form.Text = 2 Or Form_muestra_factura.txt_tipo.Text = "OP") And form_factura.txt_estado_form.Text <> 1 Then

                If entro_descuento = False Then Form_recibos.txt_total_cobro.Text = Form_recibos.txt_total.Text
                Form_recibos.txt_importe_cobro.Text = Me.txt_total.Text

                If Form_muestra_factura.txt_estado_form.Text = 1 Then
                    tipo.instruccion = "update recibo_tot set efectivo = 'SI',total_cobro = '" + Me.txt_total.Text + "' where id_tot = '" + Form_muestra_factura.txt_numero.Text + "' and lt = '" + Form_muestra_factura.txt_letra.Text + "' and pre2 = '" + Form_muestra_factura.txt_prefijo.Text + "' and talon2 = '" + Form_muestra_factura.txt_talon.Text + "'"
                    tipo.abm()
                    'tipo.instruccion = "update recibo_tot set efectivo = 'SI' where id_tot = '" + Form_muestra_factura.txt_numero.Text + "' and lt = '" + Form_muestra_factura.txt_letra.Text + "' and pre2 = '" + Form_muestra_factura.txt_prefijo.Text + "'"
                    'tipo.abm()
                End If

                If Val(Me.txt_descuento.Text) > 0 Or Me.txt_descuento.Text <> "" Then
                    Form_recibos.txt_total_cobro.Text = Me.txt_total.Text
                    entro_descuento = True
                End If

                acumula = Format(acumula - Me.txt_total.Text, "0.00")

                Call pide_en_recibo(Me.txt_num.Text, Me.txt_tipo.Text, Me.txt_letra.Text, Me.txt_pre.Text, Me.txt_num.Text, Me.txt_fec_emi.Text, Me.txt_descripcion.Text, Me.txt_banco.Text, Me.dt_fec_acred.Text, Me.txt_total.Text, Me.txt_pre.Text)

            End If

            Me.txt_descuento.Text = ""

        End If

    End Sub

    Private Sub Form_tipo_pago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1
        Me.txt_tipo_cobro.Focus()

        If form_factura.txt_estado_form.Text = 1 Then acumula = form_factura.txt_total_grilla.Text

        If Form_muestra_factura.txt_estado_form.Text = 1 Then
            acumula = Form_muestra_factura.txt_total_grilla.Text
            Me.txt_descripcion.Text = Form_muestra_factura.txt_nombre.Text
            Me.dt_fec_acred.Value = Form_muestra_factura.dt_fec.Value
        End If

        If Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2 Then
            acumula = Form_recibos.txt_total.Text
        End If

        sale = False

    End Sub

    Private Sub verifica()
        If Me.txt_numero.Text = "" Or Me.txt_descripcion.Text = "" Or Me.txt_banco.Text = "" Or Me.txt_total.Text = "" Then
            MessageBox.Show("Complete los Campos...", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            veri = True
        Else
            veri = False
        End If
    End Sub

    Private Sub verifica1()
        If Me.txt_total.Text = "" Then
            MessageBox.Show("Complete los Campos...", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            veri = True
        Else
            veri = False
        End If
    End Sub

    Private Sub pide_en_factura(ByVal cod, ByVal tc, ByVal lt, ByVal pre, ByVal num, ByVal fec, ByVal detalle, ByVal bco, ByVal fec_acred, ByVal total, ByVal p_venta)

        Try

            Dim modo As Char = "F"

            If Me.txt_tipo_cobro.Text = 2 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    Me.txt_numero.Focus()
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                If flag = True Then
                    tipo.instruccion = "INSERT INTO cheque_01(id_cheque,tc,lt,prefijo,numero,fec_emi,detalle,cod_banco,banco,fec_acred,total,modo,p_venta,talon,estado) VALUES('" & Me.txt_numero.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_pre.Text & "','" & Me.txt_num.Text & "','" & form_factura.dt_fec_emision.Text & "', '" & Me.txt_descripcion.Text & "','" & Me.txt_banco.Text & "','" & Me.lbl_banco.Text & "', '" & Me.dt_fec_acred.Text & "', '" & Me.txt_total.Text & "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                    tipo.abm()
                End If

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 3 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO ticket_01(id_tiket,tc,lt,prefijo,numero,detalle,fec_emi,total,modo,p_venta,talon,estado) VALUES('" & Me.txt_num.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_pre.Text & "','" & Me.txt_num.Text & "','" & Me.txt_descripcion.Text & "','" & Me.txt_fec_emi.Text & "','" & Me.txt_total.Text & "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 4 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO vale_01(id_vale,tc,lt,prefijo,numero,fec_emi,detalle,total,p_venta,talon,estado) VALUES('" & Me.txt_num.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_pre.Text & "','" & Me.txt_num.Text & "','" & Me.txt_fec_emi.Text & "', '" & Me.txt_descripcion.Text & "','" & Me.txt_total.Text & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 5 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO t_credito(id_credito,tc,lt,prefijo,numero,f_emi,cli_1,importe,modo,p_venta,talon,estado) VALUES('" & Me.txt_num.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_pre.Text & "','" & Me.txt_num.Text & "','" & Me.txt_fec_emi.Text & "', '" & Me.txt_descripcion.Text & "','" & Me.txt_total.Text & "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 6 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO t_debito(id_debito,tc,lt,prefijo,numero,fecha,cliente,importe,modo,p_venta,talon,estado) VALUES('" & Me.txt_num.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_pre.Text & "','" & Me.txt_num.Text & "','" & Me.txt_fec_emi.Text & "', '" & Me.txt_descripcion.Text & "','" & Me.txt_total.Text & "','" & modo & "', '" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If form_factura.txt_estado_form.Text = 1 And veri = False Or Form_muestra_factura.txt_estado_form.Text = 1 Then

                If acumula = 0 Then

                    If RTrim(Me.txt_tipo_cobro.Text) <> 1 And acumula = 0 Then
                        form_factura.txt_modifica_efectivo.Text = 1
                    End If

                    If form_factura.tipo = "FC" Or form_factura.tipo = "NC" Then form_factura.imprime_fiscal()
                    form_factura.sale = True
                    sale = True
                    form_factura.Close()

                    If Me.txt_abre.Text = 1 Then
                        form_factura.abre = 0
                        Form_login.txt_tipoo.Text = 1
                        Form_login.Timer3.Enabled = True
                    End If

                    Me.Close()

                    Form_muestra_factura.Dispose()
                    barra_carga.Timer1.Enabled = True

                Else
                    Call limpia()
                    Me.txt_tipo_cobro.Focus()
                End If

            End If

        Catch ex As Exception


        End Try

    End Sub

    Private Sub pide_en_recibo(ByVal cod, ByVal tc, ByVal lt, ByVal pre, ByVal num, ByVal fec, ByVal detalle, ByVal bco, ByVal fec_acred, ByVal total, ByVal p_venta)

        Try

            Dim modo As Char = "R"

            If Me.txt_tipo_cobro.Text = 2 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    Me.txt_numero.Focus()
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                If flag = True Then
                    tipo.instruccion = "INSERT INTO cheque_01(id_cheque,tc,lt,prefijo,numero,fec_emi,detalle,cod_banco,banco,fec_acred,total,modo,p_venta,talon,estado) VALUES('" + Me.txt_numero.Text + "','" + Me.txt_tipo.Text + "','" + Me.txt_letra.Text + "','" + Me.txt_pre.Text + "','" + Me.txt_num.Text + "','" + Me.txt_fec_emi.Text + "', '" + Me.txt_descripcion.Text + "', '" & Me.txt_banco.Text & "','" + Me.lbl_banco.Text + "', '" + Me.dt_fec_acred.Text + "', '" + Me.txt_total.Text + "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                    tipo.abm()
                End If

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 3 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO ticket_01(id_tiket,tc,lt,prefijo,numero,detalle,fec_emi,total,modo,p_venta,talon,estado) VALUES('" + Me.txt_num.Text + "','" + Me.txt_tipo.Text + "','" + Me.txt_letra.Text + "','" + Me.txt_pre.Text + "','" + Me.txt_num.Text + "','" + Me.txt_descripcion.Text + "','" + Me.txt_fec_emi.Text + "','" + Me.txt_total.Text + "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 5 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO t_credito(id_credito,tc,lt,prefijo,numero,cli_1,f_emi,importe,modo,p_venta,talon,estado) VALUES('" + Me.txt_num.Text + "','" + Me.txt_tipo.Text + "','" + Me.txt_letra.Text + "','" + Me.txt_pre.Text + "','" + Me.txt_num.Text + "','" + Me.txt_descripcion.Text + "','" + Me.txt_fec_emi.Text + "','" + Me.txt_total.Text + "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If Me.txt_tipo_cobro.Text = 6 Then

                Call verifica_forma_cobro()

                If tbl.Rows.Count >= 1 Then
                    duplicado = False
                    MessageBox.Show("El valor ya esta ingresado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    duplicado = True
                End If

                tipo.instruccion = "INSERT INTO t_debito(id_debito,tc,lt,prefijo,numero,cliente,fecha,importe,modo,p_venta,talon,estado) VALUES('" + Me.txt_num.Text + "','" + Me.txt_tipo.Text + "','" + Me.txt_letra.Text + "','" + Me.txt_pre.Text + "','" + Me.txt_num.Text + "','" + Me.txt_descripcion.Text + "','" + Me.txt_fec_emi.Text + "','" + Me.txt_total.Text + "','" & modo & "','" & Me.txt_p_venta.Text & "','" & Me.txt_talon.Text & "','I')"
                tipo.abm()

                Call carga_grilla()

            End If

            If acumula = 0 And duplicado = True Then

                barra_carga.Show()
                barra_carga.PictureBox1.Refresh()

                Form_recibos.txt_dif_cobro.Text = Me.txt_total.Text
                barra_carga.Timer1.Enabled = True
                sale = True
                Form_recibos.txt_controla_numerador.Text = 1
                Me.Close()
                Form_recibos.comprobante = True
                If Form_muestra_factura.txt_estado_form.Text = 1 Then Form_muestra_factura.Close()
                If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) Then Form_recibos.Close()
            Else
                Call limpia()
                Me.txt_tipo_cobro.Focus()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_cancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancela.Click
        Me.Close()
    End Sub

    Private Sub form_tipo_pago_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If sale = False Then

            For i = 0 To Me.data_forma_cheque.Rows.Count - 2

                tipo.instruccion = "delete cheque_01 where id_cheque = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(3).Value) & "' and banco = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(4).Value) & "'"
                tipo.abm()

            Next

            For i = 0 To Me.data_forma_cheque.Rows.Count - 2

                tipo.instruccion = "delete vale_01 where id_vale = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(3).Value) & "'"
                tipo.abm()

            Next

            For i = 0 To Me.data_forma_cheque.Rows.Count - 2

                tipo.instruccion = "delete ticket_01 where numero = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(3).Value) & "'"
                tipo.abm()

            Next

            For i = 0 To Me.data_forma_cheque.Rows.Count - 2

                tipo.instruccion = "delete t_credito where id_credito = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(3).Value) & "'"
                tipo.abm()

            Next

            For i = 0 To Me.data_forma_cheque.Rows.Count - 2

                tipo.instruccion = "delete t_debito where id_debito = '" & RTrim(Me.data_forma_cheque.Rows(i).Cells(3).Value) & "'"
                tipo.abm()

            Next

        End If

        Form_recibos.comprobante = False

    End Sub

    Private Sub txt_descuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descuento.KeyDown
        If e.KeyCode = Keys.Return Then
            Call calcula_des()
            Me.txt_total.Focus()
        End If
    End Sub

    Private Sub txt_descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento.KeyPress
        num.negativos_punto(e, Me.txt_descuento)
    End Sub

    Private Sub txt_total_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_total.KeyDown
        If e.KeyCode = Keys.Return Then

            Me.cmd_acepta.Focus()

        End If
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress
        num.positivos_punto(e, Me.txt_total)
    End Sub

    Private Sub calcula_des()
        Try

            Dim sub1 As Single

            If Form_recibos.txt_estado_form.Text = 1 Then
                sub1 = (Form_recibos.txt_total.Text * Me.txt_descuento.Text / 100)
                Me.txt_total.Text = Format(Form_recibos.txt_total.Text + sub1, "0.00")
            End If

            If form_factura.txt_estado_form.Text = 1 Then
                sub1 = (form_factura.txt_total_grilla.Text * Me.txt_descuento.Text / 100)
                Me.txt_total.Text = Format(form_factura.txt_total_grilla.Text + sub1, "0.00")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub limpia()

        Me.txt_tipo_cobro.Text = ""
        Me.lbl_tipo.Text = ""
        Me.txt_numero.Text = ""
        Me.txt_banco.Text = ""
        Me.lbl_banco.Text = ""

    End Sub

    Private Sub carga_grilla()

        Try

            Me.data_forma_cheque.Rows.Add()

            If Me.txt_tipo_cobro.Text = 2 Then

                Me.data_forma_cheque.Rows(i).Cells(0).Value = Me.txt_tipo_cobro.Text
                Me.data_forma_cheque.Rows(i).Cells(1).Value = Me.lbl_tipo.Text
                Me.data_forma_cheque.Rows(i).Cells(2).Value = Me.txt_total.Text
                Me.data_forma_cheque.Rows(i).Cells(3).Value = Me.txt_numero.Text
                Me.data_forma_cheque.Rows(i).Cells(4).Value = Me.lbl_banco.Text

            End If

            If Me.txt_tipo_cobro.Text = 3 Then

                Me.data_forma_cheque.Rows(i).Cells(0).Value = Me.txt_tipo_cobro.Text
                Me.data_forma_cheque.Rows(i).Cells(1).Value = Me.lbl_tipo.Text
                Me.data_forma_cheque.Rows(i).Cells(2).Value = Me.txt_total.Text
                If form_factura.txt_estado_form.Text = 1 Then Me.data_forma_cheque.Rows(i).Cells(3).Value = form_factura.txt_numero.Text
                If Form_recibos.txt_estado_form.Text = 1 Then Me.data_forma_cheque.Rows(i).Cells(3).Value = Form_recibos.txt_numero.Text

            End If

            If Me.txt_tipo_cobro.Text = 4 Then

                Me.data_forma_cheque.Rows(i).Cells(0).Value = Me.txt_tipo_cobro.Text
                Me.data_forma_cheque.Rows(i).Cells(1).Value = Me.lbl_tipo.Text
                Me.data_forma_cheque.Rows(i).Cells(2).Value = Me.txt_total.Text

            End If

            If Me.txt_tipo_cobro.Text = 5 Or Me.txt_tipo_cobro.Text = 6 Then

                Me.data_forma_cheque.Rows(i).Cells(0).Value = Me.txt_tipo_cobro.Text
                Me.data_forma_cheque.Rows(i).Cells(1).Value = Me.lbl_tipo.Text
                Me.data_forma_cheque.Rows(i).Cells(2).Value = Me.txt_total.Text
                Me.data_forma_cheque.Rows(i).Cells(3).Value = Me.txt_numero.Text

            End If

            If Me.txt_tipo_cobro.Text = 1 Then

                Me.data_forma_cheque.Rows(i).Cells(0).Value = Me.txt_tipo_cobro.Text
                Me.data_forma_cheque.Rows(i).Cells(1).Value = Me.lbl_tipo.Text
                Me.data_forma_cheque.Rows(i).Cells(2).Value = Me.txt_total.Text
                barra_carga.Show()
                barra_carga.PictureBox1.Refresh()

            End If

            i = i + 1

        Catch ex As Exception

        End Try

    End Sub

    Private Sub verifica_forma_cobro()

        conex = conecta()
        tbl.Clear()

        If Me.txt_tipo_cobro.Text = 2 Then

            '' si es para ventas hago esto
            comando = New SqlDataAdapter("select *from cheque_01 where id_cheque = '" & RTrim(Me.txt_numero.Text) & "' and banco = '" & RTrim(Me.lbl_banco.Text) & "' and estado = 'E'", conex)
            comando.Fill(tbl)
            comando.Dispose()

            If tbl.Rows.Count >= 1 Then
                If conex.State = ConnectionState.Closed Then conex.Open()
                coma = New SqlCommand("Update cheque_01 set estado = 'I' where id_cheque = '" & RTrim(Me.txt_numero.Text) & "' and banco = '" & RTrim(Me.lbl_banco.Text) & "' and estado = 'E'", conex)
                coma.ExecuteNonQuery()
                coma.Dispose()
                tbl.Clear()
                flag = False
                conex.Close()
                Exit Sub
            End If

            ' si es para compras hago esto
            comando = New SqlDataAdapter("select *from cheque_01 where id_cheque = '" & RTrim(Me.txt_numero.Text) & "' and banco = '" & RTrim(Me.lbl_banco.Text) & "' and estado = 'I'", conex)
            comando.Fill(tbl)
            comando.Dispose()

            If tbl.Rows.Count >= 1 Then
                If conex.State = ConnectionState.Closed Then conex.Open()
                coma = New SqlCommand("Update cheque_01 set estado = 'E' where id_cheque = '" & RTrim(Me.txt_numero.Text) & "' and banco = '" & RTrim(Me.lbl_banco.Text) & "' and estado = 'I'", conex)
                coma.ExecuteNonQuery()
                coma.Dispose()
                tbl.Clear()
                flag = False
                conex.Close()
                Exit Sub
            End If

            Exit Sub

        End If

        If Me.txt_tipo_cobro.Text = 4 Then
            comando = New SqlDataAdapter("select *from vale_01 where numero = '" & RTrim(Me.txt_num.Text) & "'", conex)
            comando.Fill(tbl)
            comando.Dispose()
            Exit Sub
        End If

        If Me.txt_tipo_cobro.Text = 3 Then
            comando = New SqlDataAdapter("select *from ticket_01 where id_tiket = '" & RTrim(Me.txt_num.Text) & "'", conex)
            comando.Fill(tbl)
            comando.Dispose()
            Exit Sub
        End If

        If Me.txt_tipo_cobro.Text = 5 Then
            comando = New SqlDataAdapter("select *from t_credito where id_credito = '" & RTrim(Me.txt_num.Text) & "'", conex)
            comando.Fill(tbl)
            comando.Dispose()
            Exit Sub
        End If

        If Me.txt_tipo_cobro.Text = 6 Then
            comando = New SqlDataAdapter("select *from t_debito where id_debito = '" & RTrim(Me.txt_num.Text) & "'", conex)
            comando.Fill(tbl)
            comando.Dispose()
            Exit Sub
        End If

    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_banco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_banco.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class