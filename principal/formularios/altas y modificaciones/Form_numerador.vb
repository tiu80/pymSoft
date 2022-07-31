Imports System.Data
Imports System.Data.SqlClient

Public Class Form_numerador

    Dim tal As New pymsoft.talonario
    Dim fact As New pymsoft.factura
    Dim veri As Boolean

    Dim coman As SqlCommand
    Dim conex As New SqlConnection

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

        tal.instruccion = "INSERT INTO numerador(talon,punto_venta,fact_a,fact_b,fact_c,recibo,remito,pedido,n_credito_a,n_credito_b) VALUES('" + Me.txt_talonario.Text + "' , '" + Me.txt_punto_venta.Text + "','" + Me.txt_fact_a.Text + "','" + Me.txt_fact_b.Text + "','" + Me.txt_fact_c.Text + "','" + Me.txt_recibo.Text + "','" + Me.txt_remito.Text + "','" + Me.txt_pedido.Text + "','" + Me.txt_n_credito_a.Text + "','" + Me.txt_n_credito_b.Text + "')"
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
        Me.txt_n_credito_a.Text = 0
        Me.txt_n_credito_b.Text = 0
        Me.txt_punto_venta.Focus()
        Me.txt_punto_venta.SelectAll()

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        tal.verifiva_numerador()

        If Form_factura_preventa.txt_estado_form.Text <> 1 Then

            If tal.verifica = True And tal.evalua = True Then
                tal.instruccion = "update numerador set talon = '" & Me.txt_talonario.Text & "',punto_venta = '" & Me.txt_punto_venta.Text & "', fact_a = '" & Me.txt_fact_a.Text & "',fact_b ='" & Me.txt_fact_b.Text & "',fact_c='" & Me.txt_fact_c.Text & "',recibo ='" & Me.txt_recibo.Text & "',remito ='" & Me.txt_remito.Text & "',pedido ='" & Me.txt_pedido.Text & "',n_credito_a ='" & Me.txt_n_credito_a.Text & "',n_credito_b ='" & Me.txt_n_credito_b.Text & "' where punto_venta = '" & Me.txt_int_p_vta.Text & "' and talon = '" & Me.txt_talonario.Text & "'"
                tal.actualizar()
                tal.instruccion = "update numerador set remito ='" & Me.txt_remito.Text & "', pedido = '" & Me.txt_pedido.Text & "', recibo = '" & Me.txt_recibo.Text & "' where talon <> '0'"
                tal.actualizar()

                MessageBox.Show("Numerador actualizado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                tal.instruccion = "select *from numerador"
                tal.mostrar()
                Exit Sub

            End If

        End If

        If Form_factura_preventa.txt_estado_form.Text = 1 Then

            If tal.verifica = False Then

                tal.instruccion = "select *from numerador"
                tal.mostrar()
                tal.verifica = True
                Exit Sub

            End If

            Me.Hide()
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

        If Form_factura_preventa.txt_estado_form.Text = 1 Then

            If Form_factura_preventa.txt_talon.Text = 2 Then tal.instruccion = "select *from numerador where talon ='2'"
            If Form_factura_preventa.txt_talon.Text = 1 Then tal.instruccion = "select *from numerador "
            tal.mostrar()
            Me.txt_talonario.Focus()

            Me.cmd_guardar.Enabled = False
            Me.cmd_eliminar.Enabled = False

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
                Me.cmd_eliminar.Enabled = False
                Me.cmd_guardar.Enabled = False
            End If

        End If

    End Sub

    Private Sub actualiza_numerador_preventa()

        Dim numero_factura As Integer = 0
        Dim i As Integer = 0

        ' actualiza a factura C

        If RTrim(Form_factura_preventa.lt) = "C" Then

            tal.instruccion = "update fact_cab set num_fact1 = '" & Me.txt_fact_c.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'C',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            tal.instruccion = "update fact_det set num_fact = '" & Me.txt_fact_c.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'C',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
            tal.actualizar()

            tal.instruccion = "update fact_tot set num_factura = '" & Me.txt_fact_c.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'C',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            numero_factura = Me.txt_fact_c.Text

        End If

        ' actualiza a factura B

        If RTrim(Form_factura_preventa.lt) = "B" Then

            tal.instruccion = "update fact_cab set num_fact1 = '" & Me.txt_fact_b.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'B',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            tal.instruccion = "update fact_det set num_fact = '" & Me.txt_fact_b.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'B',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
            tal.actualizar()

            tal.instruccion = "update fact_tot set num_factura = '" & Me.txt_fact_b.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'B',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            numero_factura = Me.txt_fact_b.Text

        End If

        ' actualiza a factura A

        If RTrim(Form_factura_preventa.lt) = "A" Then

            tal.instruccion = "update fact_cab set num_fact1 = '" & Me.txt_fact_a.Text & "', tipo_fact = 'FC', prefijo_fact = '" & Me.txt_punto_venta.Text & "', letra_fact = 'A',talon = '" & Me.txt_talonario.Text & "' ,forma_pago = 'Cta Cte', pago='DEBE' where tipo_fact ='PD' and num_fact1 = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact = '" & Form_factura_preventa.lt & "' and talon = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            tal.instruccion = "update fact_det set num_fact = '" & Me.txt_fact_a.Text & "', tipo_fact2 = 'FC', prefijo_fact2 = '" & Me.txt_punto_venta.Text & "', letra_fact1 = 'A',talon1 = '" & Me.txt_talonario.Text & "' where tipo_fact2 ='PD' and num_fact = '" & Form_factura_preventa.txt_numero.Text & "' and  prefijo_fact2 = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra_fact1 = '" & Form_factura_preventa.lt & "'  and talon1 = '" & Form_factura_preventa.txt_talon.Text & "' "
            tal.actualizar()

            tal.instruccion = "update fact_tot set num_factura = '" & Me.txt_fact_a.Text & "', tipo_factura = 'FC', pref= '" & Me.txt_punto_venta.Text & "', letra = 'A',talon2 = '" & Me.txt_talonario.Text & "' where tipo_factura ='PD' and num_factura = '" & Form_factura_preventa.txt_numero.Text & "' and  pref = '" & Form_factura_preventa.txt_prefijo.Text & "' and letra = '" & Form_factura_preventa.lt & "' and talon2 = '" & Form_factura_preventa.txt_talon.Text & "'"
            tal.actualizar()

            numero_factura = Me.txt_fact_a.Text

        End If

        'imprime factura

        If Form_factura_preventa.az = 6 Then

            fact.form_txt_letra = Form_factura_preventa.lt
            fact.tipo_fact = "FC"
            fact.form_txt = "FACTURA"
            fact.imprimir_factura(numero_factura, Form_factura_preventa.lt, Me.txt_punto_venta.Text, fact.tipo_fact)

        End If

        form_factura.borra_tabla_art_act(Form_factura_preventa.nom_computadora)

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("INSERT INTO cta_cte01(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,confirma,cod_vend) VALUES('" & numero_factura & "','FC', '" + Form_factura_preventa.lt + "','" + Me.txt_punto_venta.Text + "','" + Form_factura_preventa.txt_cod_cli.Text + "','" + Form_factura_preventa.txt_nombre.Text + "','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Val(Form_factura_preventa.txt_total_grilla.Text) & "', '','" & numero_factura & "', 'DEBE','P','" & Form_factura_preventa.txt_vendedor.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman = New SqlCommand("INSERT INTO cta_cte_hist(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" & numero_factura & "','FC', '" + Form_factura_preventa.lt + "','" + Me.txt_punto_venta.Text + "','" & Val(Form_factura_preventa.txt_total_grilla.Text) & "', '','DEBE','" & Form_factura_preventa.txt_fecHA_emi.Text & "','" & Form_factura_preventa.txt_cod_cli.Text & "','" & Form_factura_preventa.txt_nombre.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

        form_factura.actualiza_numeradores()

        conex.Close()
        Form_factura_preventa.Dispose()
        Form_muestra_cons_comp.carga_seleccion_cosulta()
        Me.Dispose()

    End Sub

End Class
