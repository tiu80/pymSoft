Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_factura

    Dim act As New pymsoft.parametro
    Dim fact As New pymsoft.factura
    Dim art As New pymsoft.articulo
    Dim tal As New pymsoft.talonario

    Dim tbl As New DataTable, tbl1 As DataTable, tb_fecha As New DataTable
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim sale As Boolean
    Public valor As String
    Dim baja, anulado As Boolean
    Dim x As Integer

    Private Sub Form_muestra_factura_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Form_muestra_cons_comp.txt_cierra_form.Text = 1
        Form_modifica_fecha.Dispose()
    End Sub

    Private Sub Form_muestra_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        'If RTrim(Me.txt_tipo.Text) = "PR" Then
        'MessageBox.Show("No se puede reimprimir Presupuesto desde aca.. Valla  a la consulta de comprobantes!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'Exit Sub
        'End If

        If Me.txt_verifica_anular_borrar.Text = 0 Then
            Me.tol_anula.Visible = False
            Me.tol_borra.Visible = False
        End If

        If Form_consulta_compras_det.txt_estado_form.Text = 1 And Form_muestra_cons_comp.es_recibo <> False Then

            Me.txt_estado_form.Text = 1
            Form_muestra_cons_comp.txt_estado_form.Text = 0
            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 240
            Me.DataGridView1.Columns(2).Width = 60
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 50
            Me.DataGridView1.Columns(6).Width = 50

            Me.DataGridView1.Columns(0).HeaderText = "Codigo"
            Me.DataGridView1.Columns(1).HeaderText = "Detalle"
            Me.DataGridView1.Columns(2).HeaderText = "Precio"
            Me.DataGridView1.Columns(3).HeaderText = "Total"
            Me.DataGridView1.Columns(4).HeaderText = "I.V.A"
            Me.DataGridView1.Columns(5).HeaderText = "Imp. Interno"
            Me.DataGridView1.Columns(6).HeaderText = "Exento"

            Exit Sub

        End If

        If Form_visualiza.txt_estado_form.Text = 3 Then

            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 240
            Me.DataGridView1.Columns(2).Width = 60
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 50
            Me.DataGridView1.Columns(6).Width = 50
            Me.DataGridView1.Columns(7).Width = 70

            Me.DataGridView1.Columns(0).HeaderText = "Codigo"
            Me.DataGridView1.Columns(1).HeaderText = "Detalle"
            Me.DataGridView1.Columns(2).HeaderText = "Total"
            Me.DataGridView1.Columns(3).HeaderText = "I.V.A"
            Me.DataGridView1.Columns(4).HeaderText = "Imp. Interno"
            Me.DataGridView1.Columns(5).HeaderText = "Exento"
            Me.DataGridView1.Columns(6).HeaderText = "Per I.V.A"
            Me.DataGridView1.Columns(7).HeaderText = "Per IB"

            Me.lbl_iva_nins.Text = "Per iva-ib"

            Exit Sub

        End If

        If Form_cta_cte.txt_estado_form.Text = 2 Then

            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 240
            Me.DataGridView1.Columns(2).Width = 60
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 50
            'Me.DataGridView1.Columns(6).Width = 50

            Me.DataGridView1.Columns(0).HeaderText = "Codigo"
            Me.DataGridView1.Columns(1).HeaderText = "Detalle"
            Me.DataGridView1.Columns(2).HeaderText = "Precio"
            Me.DataGridView1.Columns(3).HeaderText = "Total"
            Me.DataGridView1.Columns(4).HeaderText = "I.V.A"
            Me.DataGridView1.Columns(5).HeaderText = "Imp. Interno"
            'Me.DataGridView1.Columns(6).HeaderText = "Exento"

            Exit Sub

        End If

        If Form_muestra_cons_comp.es_recibo = True Then

            Me.txt_estado_form.Text = 1
            Form_muestra_cons_comp.txt_estado_form.Text = 0
            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 240
            Me.DataGridView1.Columns(2).Width = 60
            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(4).Width = 50
            Me.DataGridView1.Columns(5).Width = 50
            Me.DataGridView1.Columns(6).Width = 50
            Me.DataGridView1.Columns(7).Width = 50
            Me.DataGridView1.Columns(8).Width = 50
            Me.DataGridView1.Columns(9).Width = 70

            Me.DataGridView1.Columns(0).HeaderText = "Codigo"
            Me.DataGridView1.Columns(1).HeaderText = "Detalle"
            Me.DataGridView1.Columns(2).HeaderText = "Cantidad"
            Me.DataGridView1.Columns(3).HeaderText = "Precio"
            Me.DataGridView1.Columns(4).HeaderText = "Total"
            Me.DataGridView1.Columns(5).HeaderText = "Descuento"
            Me.DataGridView1.Columns(6).HeaderText = "I.V.A"
            Me.DataGridView1.Columns(7).HeaderText = "Imp. Interno"
            Me.DataGridView1.Columns(8).HeaderText = "Exento"
            Me.DataGridView1.Columns(9).HeaderText = "Uni sec"

        Else

            Me.txt_estado_form.Text = 1
            Form_muestra_cons_comp.txt_estado_form.Text = 0
            Me.DataGridView1.Columns(0).Width = 80
            Me.DataGridView1.Columns(1).Width = 70
            Me.DataGridView1.Columns(2).Width = 70
            Me.DataGridView1.Columns(3).Width = 70
            Me.DataGridView1.Columns(4).Width = 100

            Me.DataGridView1.Columns(0).HeaderText = "Fecha"
            Me.DataGridView1.Columns(1).HeaderText = "Tipo"
            Me.DataGridView1.Columns(2).HeaderText = "Letra"
            Me.DataGridView1.Columns(3).HeaderText = "Prefijo"
            Me.DataGridView1.Columns(4).HeaderText = "Numero"

            Me.lbl_sub_total.Text = ""
            Me.lbl_iva_ins.Text = ""
            Me.lbl_iva_nins.Text = ""
            Me.lbl_exento.Text = ""
            Me.lbl_imp_int.Text = ""

        End If

        Form_muestra_cons_comp.txt_cierra_form.Text = 2

        If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then

            Me.tol_anula.Visible = False
            Me.tol_borra.Visible = False
            Me.tol_forma_cobro.Visible = False

        End If

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Form_exporta.Show()
    End Sub

    Private Sub tol_anula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tol_anula.Click

        Dim a As Integer

        If Len(Trim(Me.txt_cae.Text)) > 5 Then
            MessageBox.Show("No se puede anular o borrar facturas con CAE", "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Trim(Me.txt_comprobante.Text) <> "compra" Then

            Call verifica_si_existe_en_recibo()
            Call verifica_art_bajas()
            Call verifica_arqueo()

            If sale = True Then
                Exit Sub
            End If

            If anulado = True Then
                MessageBox.Show("No se puede anular o borrar,el comprobante existe en un recibo!!", "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Form_visualiza.Close()
                Me.Close()
                Exit Sub
            End If

            If baja = True Then
                MessageBox.Show("Hay articulos dado de baja:" & " " & tbl1.Rows(x).Item(0) & " - " & tbl1.Rows(x).Item(1), "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form_visualiza.Close()
                Me.Close()
                Exit Sub
            End If

        End If

        Call verifica_fecha()

        If sale = True Then
            Exit Sub
        End If

        If principal.lbl_usu.Text <> "Administrador" Then
            MessageBox.Show("No tiene permisos", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Me.txt_estado_fact.Text = "Anulado" Then
            MessageBox.Show("El comprobante ya esta anulado", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        a = MessageBox.Show("Esta Seguro que desea anular!!!!", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            If RTrim(Me.txt_comprobante.Text) = "compra" Then
                Call borra()
                Exit Sub
            End If

            If RTrim(Form_visualiza.cmb_tipo.Text) = "RC" Then
                Call borra()
                Exit Sub
            End If

            If RTrim(Me.txt_f_pago.Text) = "Contado" Then Call borra_forma_cobro()

            act.instruccion = "update fact_cab set estado_fact = 'Anulado' where num_fact1 = '" & Me.txt_numero.Text & "' and prefijo_fact= '" & Me.txt_prefijo.Text & "' and letra_fact = '" & Me.txt_letra.Text & "' and tipo_fact= '" & Me.txt_tipo.Text & "'"
            act.abm()

            If RTrim(Me.txt_f_pago.Text) = "Cta Cte" Then
                act.instruccion = "delete cta_cte01 where tc= '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "'"
                act.abm()
                act.instruccion = "delete cta_cte_hist where tc= '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and num = '" & RTrim(Me.txt_numero.Text) & "'"
                act.abm()
            End If

            Call actualiza_stock()

            Me.Dispose()

        End If

    End Sub

    Private Sub tol_borra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tol_borra.Click

        If Len(Trim(Me.txt_cae.Text)) > 5 Then
            MessageBox.Show("No se puede anular o borrar facturas con CAE", "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Trim(Me.txt_comprobante.Text) <> "compra" Then

            If Trim(Me.txt_estado_fact.Text) <> "Activo" Then
                MessageBox.Show("No se puede borrar un comprobante anulado!!", "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Call verifica_si_existe_en_recibo()
            Call verifica_art_bajas()
            Call verifica_arqueo()

            If sale = True Then
                Exit Sub
            End If

            If anulado = True Then
                MessageBox.Show("No se puede anular o borrar,el comprobante existe en un recibo!!", "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Form_visualiza.Close()
                Me.Close()
                Exit Sub
            End If

            If baja = True Then
                MessageBox.Show("Hay articulos dado de baja:" & " " & tbl1.Rows(x).Item(0) & " - " & tbl1.Rows(x).Item(1), "Pym Soft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form_visualiza.Close()
                Me.Close()
                Exit Sub
            End If

        End If

        Call borra()

    End Sub

    Private Sub tool_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_imprime.Click

        If RTrim(Me.txt_comprobante.Text) = "venta" Then

            fact.tipo_fact = Me.txt_tipo.Text
            fact.form_txt_letra = Me.txt_letra.Text

            If Trim(Me.txt_tipo.Text) = "FC" Then fact.form_txt = "FACTURA"
            If Trim(Me.txt_tipo.Text) = "NC" Then fact.form_txt = "NOTA DE CREDITO"

            If Trim(Me.txt_tipo.Text) = "PR" Then
                fact.form_txt = "PRESUPUESTO"
                Me.txt_talon.Text = 99
            End If

            If Trim(Me.txt_tipo.Text) = "PD" Then fact.form_txt = "PEDIDO"
            If Trim(Me.txt_tipo.Text) = "ND" Then fact.form_txt = "NOTA DE DEBITO"

            fact.imprimir_factura(Trim(Me.txt_numero.Text), Trim(Me.txt_letra.Text), Trim(Me.txt_prefijo.Text), Trim(Me.txt_tipo.Text), Trim(Me.txt_talon.Text), fact.form_txt, Me.txt_tipo_iva.Text)

        End If

        If RTrim(Me.txt_comprobante.Text) = "cobro" Then

            If RTrim(Me.txt_tipo.Text = "RC") Then fact.imprime_recibo(Me.txt_letra.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_total_grilla.Text, Me.txt_talon.Text)
            If RTrim(Me.txt_tipo.Text = "OP") Then fact.imprime_orden_pago(Me.txt_letra.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_total_grilla.Text, Me.txt_talon.Text)

        End If

        If RTrim(Me.txt_comprobante.Text) = "" Then ' EN ESTE CASO ES REMITO
            fact.numero_factura = Me.txt_numero.Text
            fact.form_txt_letra = Me.txt_letra.Text
            fact.letra_fact = Me.txt_letra.Text
            fact.tipo_fact = Me.txt_tipo.Text
            fact.imprimir_remito()
        End If


    End Sub

    Public Sub actualiza_stock()

        Dim can As Single
        Dim i As Integer

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If RTrim(Me.txt_tipo.Text) = "PD" Then

                If RTrim(Me.DataGridView1.Rows(i).Cells(11).Value) = "NO" Then

                    art.instruccion = "select cantidad from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                    art.carga_preventa()
                    can = art.cantidad

                    can = can + Me.DataGridView1.Rows(i).Cells(2).Value

                    art.instruccion = "update art_01 set cantidad = '" & can & "',cant_ant= '" & can & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                    art.actualizar()

                    can = 0

                End If

            End If

            If RTrim(Me.txt_tipo.Text) = "FC" Or RTrim(Me.txt_tipo.Text) = "RS" Then

                art.instruccion = "select cantidad from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                art.carga_preventa()
                can = art.cantidad

                can = can + Me.DataGridView1.Rows(i).Cells(2).Value

                art.instruccion = "update art_01 set cantidad = '" & can & "',cant_ant= '" & can & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                art.actualizar()

                can = 0

            End If

            If RTrim(Me.txt_tipo.Text) = "NC" Or RTrim(Me.txt_tipo.Text) = "RE" Then

                art.instruccion = "select cantidad from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                art.carga_preventa()
                can = art.cantidad

                can = can - Me.DataGridView1.Rows(i).Cells(2).Value

                art.instruccion = "update art_01 set cantidad = '" & can & "',cant_ant= '" & can & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                art.actualizar()

                can = 0

            End If

        Next

    End Sub

    Private Sub tol_forma_cobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tol_forma_cobro.Click

        If RTrim(Me.txt_f_pago.Text) = "Cta Cte" Then
            MessageBox.Show("No se puede cambiar forma cobro cta cte", "PyM soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If RTrim(Me.txt_comprobante.Text) = "compra" Then
            MessageBox.Show("No se puede cambiar forma cobro", "PyM soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call verifica_arqueo()

        If sale = True Then
            Exit Sub
        End If

        Dim a As Integer = MessageBox.Show("Este comprobante ya tiene Forma de Cobro" & vbCrLf & "Desea Borrarlo!!!!", "PyM Soft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            Call borra_forma_cobro()

            Form_tipo_pago.txt_num.Text = Me.txt_numero.Text
            Form_tipo_pago.txt_letra.Text = Me.txt_letra.Text
            Form_tipo_pago.txt_pre.Text = Me.txt_prefijo.Text
            Form_tipo_pago.txt_tipo.Text = Me.txt_tipo.Text
            Form_tipo_pago.txt_fec_emi.Text = Me.dt_fec.Value
            If RTrim(Me.txt_tipo.Text) <> "RC" Then Form_tipo_pago.txt_p_venta.Text = Me.txt_prefijo.Text
            If RTrim(Me.txt_tipo.Text) = "RC" Then Form_tipo_pago.txt_p_venta.Text = Me.txt_p_venta.Text
            Form_tipo_pago.txt_talon.Text = Me.txt_talon.Text

            Form_tipo_pago.Show()

        End If

    End Sub

    Private Sub Tool_modifica_fec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_modifica_fec.Click

        Form_modifica_fecha.Show()

    End Sub

    Private Sub actualiza_numerador()

        Dim num As Integer

        conex = conecta()

        comando = New SqlDataAdapter("select *from numerador", conex)
        comando.Fill(tbl)

        If RTrim(Me.txt_letra.Text) = "A" And RTrim(Me.txt_tipo.Text) = "FC" And RTrim(Me.txt_prefijo.Text) = tbl.Rows(0).Item(1) Then
            num = tbl.Rows(0).Item(2) - 1
            tal.instruccion = "update numerador set fact_a = '" & num & "' where punto_venta like '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_letra.Text) = "B" And RTrim(Me.txt_tipo.Text) = "FC" And RTrim(Me.txt_prefijo.Text) = tbl.Rows(0).Item(1) Then
            num = tbl.Rows(0).Item(3) - 1
            tal.instruccion = "update numerador set fact_b = '" & num & "' where punto_venta like '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_letra.Text) = "C" And RTrim(Me.txt_tipo.Text) = "FC" Then
            num = tbl.Rows(0).Item(4) - 1
            tal.instruccion = "update numerador set fact_c = '" & num & "' where punto_venta = punto_venta"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_tipo.Text) = "RC" Then
            num = tbl.Rows(0).Item(5) - 1
            tal.instruccion = "update numerador set recibo = '" & num & "' where punto_venta = '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_tipo.Text) = "PD" Then
            num = tbl.Rows(0).Item(7) - 1
            tal.instruccion = "update numerador set pedido = '" & num & "' where punto_venta = '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_letra.Text) = "A" And RTrim(Me.txt_tipo.Text) = "NC" And RTrim(Me.txt_prefijo.Text) = tbl.Rows(0).Item(1) Then
            num = tbl.Rows(0).Item(8) - 1
            tal.instruccion = "update numerador set n_credito_a = '" & num & "' where punto_venta like '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

        If RTrim(Me.txt_letra.Text) = "B" And RTrim(Me.txt_tipo.Text) = "NC" And RTrim(Me.txt_prefijo.Text) = tbl.Rows(0).Item(1) Then
            num = tbl.Rows(0).Item(9) - 1
            tal.instruccion = "update numerador set n_credito_b = '" & num & "' where punto_venta like '" + Me.txt_prefijo.Text + "'"
            tal.actualizar()
            Exit Sub
        End If

    End Sub

    Private Sub borra_forma_cobro()

        act.instruccion = "DELETE vale_01 WHERE tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and numero = '" & RTrim(Me.txt_numero.Text) & "'"
        act.abm()

        act.instruccion = "DELETE ticket_01 WHERE tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and numero = '" & RTrim(Me.txt_numero.Text) & "'"
        act.abm()

        act.instruccion = "DELETE cheque_01 WHERE tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and numero = '" & RTrim(Me.txt_numero.Text) & "'"
        act.abm()

        act.instruccion = "DELETE t_credito WHERE tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and numero = '" & RTrim(Me.txt_numero.Text) & "'"
        act.abm()

        act.instruccion = "DELETE t_debito WHERE tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and numero = '" & RTrim(Me.txt_numero.Text) & "'"
        act.abm()

        If RTrim(Me.txt_tipo.Text) <> "RC" Then
            act.instruccion = "update fact_tot set total_cobro = total where num_factura = '" & Me.txt_numero.Text & "' and tipo_factura = '" & RTrim(Me.txt_tipo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and pref = '" & RTrim(Me.txt_prefijo.Text) & "'"
            act.abm()
        End If

        If RTrim(Me.txt_tipo.Text) = "RC" Then
            act.instruccion = "update recibo_tot set total_cobro = total ,efectivo = 'NO' where id_tot = '" & Me.txt_numero.Text & "' and tip = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre2 = '" & RTrim(Me.txt_prefijo.Text) & "'"
            act.abm()
        End If

    End Sub

    Private Sub verifica_fecha()

        tb_fecha.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select mes,año from p_carga01 where estado = 'A'", conex)
        comando.Fill(tb_fecha)

        If tb_fecha.Rows(0).Item(0) <> RTrim(Me.dt_fec.Value.Month) And tb_fecha.Rows(0).Item(1) <> RTrim(Me.dt_fec.Value.Year) Then
            MessageBox.Show("El mes no esta Habilitado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sale = True
        Else
            sale = False
        End If

    End Sub

    Private Sub verifica_arqueo()

        tbl.Clear()

        conex = conecta()

        If RTrim(Me.txt_tipo.Text) <> "RC" Then

            comando = New SqlDataAdapter("select arqueo from fact_cab where num_fact1 = '" & Me.txt_numero.Text & "' and tipo_fact = '" & Me.txt_tipo.Text & "' and letra_fact = '" & Me.txt_letra.Text & "' and prefijo_fact = '" & Me.txt_prefijo.Text & "'", conex)
            comando.Fill(tbl)

            If RTrim(tbl.Rows(0).Item(0)) = "A" Then
                MessageBox.Show("El comprobante ya esta arqueado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sale = True
            Else
                sale = False
            End If

        Else

            comando = New SqlDataAdapter("select arqueo from recibo_cab where id_rec = '" & Me.txt_numero.Text & "' and tc = '" & Me.txt_tipo.Text & "' and letra = '" & Me.txt_letra.Text & "' and pre = '" & Me.txt_prefijo.Text & "'", conex)
            comando.Fill(tbl)

            If RTrim(tbl.Rows(0).Item(0)) = "A" Then
                MessageBox.Show("El comprobante ya esta arqueado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sale = True
            Else
                sale = False
            End If

        End If

    End Sub

    Private Sub borra()

        Dim a, i As Integer

        Call verifica_fecha()
        If sale = True Then
            Exit Sub
        End If

        If principal.lbl_usu.Text <> "Administrador" Then
            MessageBox.Show("No tiene permisos", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        a = MessageBox.Show("Esta Seguro!!!!" & vbCrLf & "Esta Operacion Eliminara el Comprobante sin dejar Rastros", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            tbl.Clear()

            If RTrim(Me.txt_comprobante.Text) = "compra" Then

                act.instruccion = "DELETE compra_cab WHERE numero = '" & Me.txt_numero.Text & "' and prefijo= '" & Me.txt_prefijo.Text & "' and letra = '" & Me.txt_letra.Text & "' and tipo = '" & Me.txt_tipo.Text & "'"
                act.abm()
                act.instruccion = "DELETE compra_det WHERE num = '" & Me.txt_numero.Text & "' and pre= '" & Me.txt_prefijo.Text & "' and lt = '" & Me.txt_letra.Text & "' and tipo1= '" & Me.txt_tipo.Text & "'"
                act.abm()
                act.instruccion = "DELETE compra_tot WHERE num1 = '" & Me.txt_numero.Text & "' and pre1 = '" & Me.txt_prefijo.Text & "' and lt1 = '" & Me.txt_letra.Text & "' and tipo2 = '" & Me.txt_tipo.Text & "'"
                act.abm()

            End If

            If RTrim(Me.txt_comprobante.Text) = "venta" Then

                If RTrim(Me.txt_tipo.Text) = "FC" Or RTrim(Me.txt_tipo.Text) = "NC" Or RTrim(Me.txt_tipo.Text) = "PD" Or RTrim(Me.txt_tipo.Text) = "RE" Or RTrim(Me.txt_tipo.Text) = "RS" Or RTrim(Me.txt_tipo.Text) = "ND" Then

                    If RTrim(Me.txt_f_pago.Text) = "Contado" Then Call borra_forma_cobro()

                    act.instruccion = "DELETE fact_cab WHERE num_fact1 = '" & Me.txt_numero.Text & "' and prefijo_fact= '" & Me.txt_prefijo.Text & "' and letra_fact = '" & Me.txt_letra.Text & "' and tipo_fact= '" & Me.txt_tipo.Text & "'"
                    act.abm()
                    act.instruccion = "DELETE fact_det WHERE num_fact = '" & Me.txt_numero.Text & "' and prefijo_fact2= '" & Me.txt_prefijo.Text & "' and letra_fact1 = '" & Me.txt_letra.Text & "' and tipo_fact2= '" & Me.txt_tipo.Text & "'"
                    act.abm()
                    act.instruccion = "DELETE fact_tot WHERE num_factura = '" & Me.txt_numero.Text & "' and pref = '" & Me.txt_prefijo.Text & "' and letra = '" & Me.txt_letra.Text & "' and tipo_factura = '" & Me.txt_tipo.Text & "'"
                    act.abm()

                    If RTrim(Me.txt_f_pago.Text) = "Cta Cte" Then
                        act.instruccion = "delete cta_cte01 where tc= '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "'"
                        act.abm()
                        act.instruccion = "delete cta_cte_hist where tc= '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and num = '" & RTrim(Me.txt_numero.Text) & "'"
                        act.abm()
                    End If

                End If

            End If

            If RTrim(Me.txt_tipo.Text) = "RC" Then

                conex = conecta()
                Dim num, pre As Integer
                Dim lt, tc As String
                Dim tbl1 As New DataTable
                Dim valor, valor_grilla As Double

                Call borra_forma_cobro()

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    num = Me.DataGridView1.Rows(i).Cells(4).Value
                    pre = Me.DataGridView1.Rows(i).Cells(3).Value
                    tc = Me.DataGridView1.Rows(i).Cells(1).Value
                    lt = Me.DataGridView1.Rows(i).Cells(2).Value
                    valor_grilla = Me.DataGridView1.Rows(i).Cells(5).Value

                    tbl1.Clear()

                    comando = New SqlDataAdapter("select debito,credito from cta_cte01 WHERE num_fact = '" & num & "' and pre = '" & pre & "' and lt = '" & lt & "' and tc = '" & tc & "'", conex)
                    comando.Fill(tbl1)

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Then

                        If tbl1.Rows.Count <> Nothing Then
                            valor = valor_grilla + tbl1.Rows(0).Item(0)
                        Else
                            valor = valor_grilla
                        End If

                        act.instruccion = "DELETE cta_cte01 WHERE id_cta = '" & RTrim(num) & "' and pre = '" & RTrim(pre) & "' and lt = '" & RTrim(lt) & "' and tc = '" & RTrim(tc) & "'"
                        act.abm()
                        act.instruccion = "INSERT INTO cta_cte01(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado) VALUES('" & num & "','" & tc & "', '" & lt & "','" & pre & "','" + Me.txt_codigo_cli.Text + "','" + Me.txt_nombre.Text + "','" & Me.dt_fec.Value & "','" & Me.dt_fec.Value & "','" & valor & "', '','" & num & "', 'DEBE')"
                        act.abm()

                        act.instruccion = "update cta_cte_hist set estado = 'DEBE' where num = '" & num & "' and tc = '" & tc & "' and lt = '" & lt & "'and pre = '" & pre & "'"
                        act.abm()

                        'act.instruccion = "DELETE cta_cte_hist WHERE num = '" & RTrim(num) & "' and pre = '" & RTrim(pre) & "' and lt = '" & RTrim(lt) & "' and tc = '" & RTrim(tc) & "'"
                        'act.abm()
                        'act.instruccion = "INSERT INTO cta_cte_hist(num,tc,lt,pre,id_cli,cli,fec,debito,credito,estado) VALUES('" & num & "','" & tc & "', '" & lt & "','" & pre & "','" + Me.txt_codigo_cli.Text + "','" + Me.txt_nombre.Text + "','" & Me.dt_fec.Value & "','" & valor & "', '','DEBE')"
                        'act.abm()

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Then

                        If tbl1.Rows.Count <> Nothing Then
                            valor = valor_grilla + tbl1.Rows(0).Item(1)
                        Else
                            valor = valor_grilla
                        End If

                        act.instruccion = "DELETE cta_cte01 WHERE id_cta = '" & RTrim(num) & "' and pre = '" & RTrim(pre) & "' and lt = '" & RTrim(lt) & "' and tc = '" & RTrim(tc) & "'"
                        act.abm()

                        ' si anulo el recibo el RA se borra y se debe hacer nuevamente 
                        ' para que quede bien el historico cta cte - 10/02/2021
                        If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) <> "RA" Then
                            act.instruccion = "INSERT INTO cta_cte01(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado) VALUES('" & num & "','" & tc & "', '" & lt & "','" & pre & "','" + Me.txt_codigo_cli.Text + "','" + Me.txt_nombre.Text + "','" & Me.dt_fec.Value & "','" & Me.dt_fec.Value & "','', '" & valor & "','" & num & "', 'DEBE')"
                            act.abm()
                        End If

                        act.instruccion = "update cta_cte_hist set estado = 'DEBE' where num = '" & num & "' and tc = '" & tc & "' and lt = '" & lt & "'and pre = '" & pre & "'"
                        act.abm()

                        'act.instruccion = "DELETE cta_cte_hist WHERE num = '" & RTrim(num) & "' and pre = '" & RTrim(pre) & "' and lt = '" & RTrim(lt) & "' and tc = '" & RTrim(tc) & "'"
                        'act.abm()
                        'act.instruccion = "INSERT INTO cta_cte_hist(num,tc,lt,pre,id_cli,cli,fec,debito,credito,estado) VALUES('" & num & "','" & tc & "', '" & lt & "','" & pre & "','" + Me.txt_codigo_cli.Text + "','" + Me.txt_nombre.Text + "','" & Me.dt_fec.Value & "','','" & valor & "','DEBE')"
                        'act.abm()

                    End If

                Next

                act.instruccion = "DELETE recibo_cab WHERE id_rec = '" & Me.txt_numero.Text & "' and pre= '" & Me.txt_prefijo.Text & "' and letra = '" & Me.txt_letra.Text & "' and tc= '" & Me.txt_tipo.Text & "'"
                act.abm()
                act.instruccion = "DELETE recibo_det WHERE id_det = '" & Me.txt_numero.Text & "' and pre1= '" & Me.txt_prefijo.Text & "' and letra_01 = '" & Me.txt_letra.Text & "' and tc1= '" & Me.txt_tipo.Text & "'"
                act.abm()
                act.instruccion = "DELETE recibo_tot WHERE id_tot = '" & Me.txt_numero.Text & "' and pre2 = '" & Me.txt_prefijo.Text & "' and lt = '" & Me.txt_letra.Text & "' and tip = '" & Me.txt_tipo.Text & "'"
                act.abm()

                act.instruccion = "delete cta_cte_hist where tc= '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and num = '" & RTrim(Me.txt_numero.Text) & "'"
                act.abm()

                Form_visualiza.Dispose()

            End If


            If RTrim(Me.txt_tipo.Text) <> "RC" And RTrim(Me.txt_comprobante.Text) <> "compra" Then Call actualiza_stock()

            Me.Dispose()
            Form_muestra_cons_comp.Dispose()

        End If
    End Sub

    Private Sub Tool_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_comentario.Click
        Form_comentario.TextBox1.ReadOnly = True
        Form_comentario.Show()
    End Sub

    Private Sub verifica_si_existe_en_recibo()

        Dim t As New DataTable

        Try

            conex = conecta()

            comando = New SqlDataAdapter("select * from recibo_det where tipo_fact = '" & RTrim(Me.txt_tipo.Text) & "' and letra_fact = '" & RTrim(Me.txt_letra.Text) & "' and pre_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "'", conex)
            comando.Fill(t)

            If t.Rows.Count = Nothing Then
                anulado = False
            Else
                anulado = True
            End If

        Catch ex As Exception

            anulado = False

        Finally

            t.Dispose()

        End Try

    End Sub

    Private Sub verifica_art_bajas()

        Try

            conex = conecta()

            For x = 0 To Me.DataGridView1.Rows.Count - 2

                comando = New SqlDataAdapter("select id_art,nombre,estado from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(x).Cells(0).Value) & "'", conex)
                comando.Fill(tbl1)

                If tbl1.Rows(x).Item(2) = "Activo" Then
                    baja = False
                Else
                    baja = True
                    Exit For
                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Insert Then
            Dim a As Integer = MessageBox.Show("Este comprobante ya tiene Forma de Cobro" & vbCrLf & "Desea Cambiarla!!!!", "PyM Soft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If a = 6 Then

                Call borra_forma_cobro()
                Form_tipo_pago.txt_num.Text = Me.txt_numero.Text
                Form_tipo_pago.txt_letra.Text = Me.txt_letra.Text
                Form_tipo_pago.txt_pre.Text = Me.txt_prefijo.Text
                Form_tipo_pago.txt_tipo.Text = Me.txt_tipo.Text
                Form_tipo_pago.txt_fec_emi.Text = Me.dt_fec.Value
                Form_tipo_pago.txt_p_venta.Text = Me.txt_prefijo.Text
                Form_tipo_pago.txt_talon.Text = Me.txt_talon.Text

                Form_tipo_pago.Show()

            End If

        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

End Class