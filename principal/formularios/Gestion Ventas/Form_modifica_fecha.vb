Public Class Form_modifica_fecha

    Dim act As New pymsoft.parametro
    Dim valor As Boolean

    Private Sub Form_modifica_fecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dt_fecha.Focus()
        Me.dt_fecha.Text = Form_muestra_factura.dt_fec.Value
    End Sub

    Private Sub actualiza_fecha()

        Try

            If RTrim(Form_muestra_factura.txt_comprobante.Text) = "compra" Then

                act.instruccion = "Update compra_cab set fec_emi= '" & Me.dt_fecha.Text & "' where numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra= '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update compra_det set fec_emi1= '" & Me.dt_fecha.Text & "' where num = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pre = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo1 = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update compra_tot set fec_emi2 = '" & Me.dt_fecha.Text & "' where num1 = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pre1= '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo2 = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt1 = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                Exit Sub

            End If

            If RTrim(Form_muestra_factura.txt_tipo.Text) <> "RC" Then

                act.instruccion = "Update fact_cab set fec_emision= '" & Me.dt_fecha.Text & "' where num_fact1 = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and prefijo_fact = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo_fact = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra_fact= '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update fact_det set fec_emi= '" & Me.dt_fecha.Text & "' where num_fact = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo_fact2 = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra_fact1 = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update fact_tot set fecha_emision1 = '" & Me.dt_fecha.Text & "' where num_factura = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pref = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tipo_factura = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

            Else

                act.instruccion = "Update recibo_cab set fec_emi = '" & Me.dt_fecha.Text & "' where id_rec = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pre = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update recibo_det set fecha = '" & Me.dt_fecha.Text & "' where id_det = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pre1 = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tc1 = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and letra_01 = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

                act.instruccion = "Update recibo_tot set fec_emi1 = '" & Me.dt_fecha.Text & "' where id_tot = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "' and pre2 = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and tip = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "'"
                act.abm()

            End If

            act.instruccion = "update cheque_01 set fec_emi = '" & Me.dt_fecha.Text & "' WHERE tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "'"
            act.abm()

            act.instruccion = "update vale_01 set fec_emi= '" & Me.dt_fecha.Text & "' WHERE tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "'"
            act.abm()

            act.instruccion = "update ticket_01 set fec_emi= '" & Me.dt_fecha.Text & "' WHERE tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "'"
            act.abm()

            act.instruccion = "DELETE t_credito set f_emi = '" & Me.dt_fecha.Text & "' WHERE tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "'"
            act.abm()

            act.instruccion = "DELETE t_debito set fecha = '" & Me.dt_fecha.Text & "' WHERE tc = '" & RTrim(Form_muestra_factura.txt_tipo.Text) & "' and lt = '" & RTrim(Form_muestra_factura.txt_letra.Text) & "' and prefijo = '" & RTrim(Form_muestra_factura.txt_prefijo.Text) & "' and numero = '" & RTrim(Form_muestra_factura.txt_numero.Text) & "'"
            act.abm()

        Catch ex As Exception

        Finally

            Me.Dispose()
            Form_muestra_factura.Dispose()

        End Try

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        valor = form_factura.verifica_fecha(Me.dt_fecha.Value.Month.ToString, Me.dt_fecha.Value.Year.ToString)

        If valor = True Then
            Call actualiza_fecha()
        End If

    End Sub
End Class