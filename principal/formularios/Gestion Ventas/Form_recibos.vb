Imports System.Data
Imports System.Data.SqlClient

Public Class Form_recibos

    Dim cli As New pymsoft.cliente1
    Dim tal As New pymsoft.talonario
    Dim rec As New pymsoft.parametro
    Public fact As New pymsoft.factura
    Dim vend As New pymsoft.vendedor
    Dim fec_emi, letra, numero, num1, desc, tipo As String
    Dim importe, total1, saldo1 As Single
    Dim i, z, x, pref, pre, ab As Integer
    Public verifica As Short = 0
    Dim ban As Boolean = True
    Public comprobante As Boolean = False, repetido As Boolean = True, acuenta As Boolean = False
    Public ra As Boolean = False, existe_num As Boolean, activo As Boolean = False
    Public talon3 As Boolean = False

    Dim tbl As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim trans As SqlTransaction
    Dim coman As SqlCommand

    Dim num As New pymsoft.numerodecimales

    Private Sub form_recibos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try

            If Me.txt_cierra_form.Text = 2 Then

                e.Cancel = True
                busc_cliente.TopMost = True

            End If

            If comprobante = True Then
                Call guarda_recibo()
            Else
                Form_tipo_pago.Close()
            End If

            'tal.instruccion = "update recibo_tot set total_cobro = '" & Me.txt_dif_cobro.Text & "', efectivo = 'SI' where id_tot ='" & Me.txt_num.Text & "' and lt = '" & Me.txt_letra.Text & "' and tip = 'RC'"
            'tal.actualizar()

            tal.instruccion = "Update cta_cte01 set estado = 'DEBE' where estado = 'PAGADO'"
            tal.actualizar()

            If comprobante = True And Me.txt_tipo.Text = "RC" Then Form_login.Timer4.Enabled = True

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Form_recibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' este se usa para poder hacer recibos en comprobantes blanco y negro
        talon3 = False

        If form_factura.txt_estado_form.Text = 1 Then
            MessageBox.Show("Hay un comprobante abierto...Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        If Form_cta_cte.txt_estado_form.Text = 1 Or Form_cta_cte.txt_estado_form.Text = 2 Then
            MessageBox.Show("Ya hay un formulario de cta cta abierto!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        If Me.txt_tipo.Text = "RC" Then

            tal.instruccion = "Update cta_cte01 set estado = 'DEBE' where confirma = 'P'"
            tal.actualizar()

            form_factura.tipo1 = "RC"

        End If

        If Me.txt_tipo.Text = "OP" Then

            tal.instruccion = "Update cta_cte_pro set estado = 'DEBE' where confirma = 'P'"
            tal.actualizar()

            form_factura.tipo1 = "OP"

        End If

        Me.DataGridView1.Columns(0).Width = "60"
        Me.DataGridView1.Columns(1).Width = "60"
        Me.DataGridView1.Columns(2).Width = "60"
        Me.DataGridView1.Columns(3).Width = "60"
        Me.DataGridView1.Columns(4).Width = "200"
        Me.dt_fec_emision.Text = Date.Now
        Me.dt_fec_vto.Text = Date.Now

        fact.carga_parametro()

        Me.txt_talonario_pred.Text = fact.Talonario_predeterminado

        If fact.Pide_talonario_factura = "SI" Then

            Dim x As String = InputBox("Ingrese Talonario" & vbCrLf & " " & vbCrLf & "1- Talonario Fiscal" & vbCrLf & "2- Talonario Alternativo" & vbCrLf & "3- Ambos", "PyM Soft", 2)

            If x = "1" Then
                Me.txt_talonario_pred.Text = x
                fact.Talonario_predeterminado = x
            End If

            If x = "2" Or x = "3" Then
                If x = "3" Then
                    Me.txt_talonario_pred.Text = 2
                    fact.Talonario_predeterminado = 2
                    talon3 = True
                Else
                    Me.txt_talonario_pred.Text = x
                    fact.Talonario_predeterminado = x
                    talon3 = False
                End If
            End If

            If x <> "1" And x <> "2" And x <> "3" Then

                MessageBox.Show("No existe Talonario!!!!", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Dispose()
                Exit Sub

            End If

        End If

        conex = conecta()
        comando = New SqlDataAdapter("select punto_venta from numerador where talon = '" & Me.txt_talonario_pred.Text & "'", conex)
        comando.Fill(tbl)

        Me.txt_p_venta.Text = tbl.Rows(0).Item(0)
        tbl.Clear()

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_cliente.Show()

        End If

        If e.KeyCode = Keys.Return Then

            If Me.txt_tipo.Text = "RC" Then cli.insruccion = "select *from cli_01 where id_cli = '" & Trim(Me.txt_codigo.Text) & "' and tipo_cliente ='Cliente' and estado = 'ACTIVO'"
            If Me.txt_tipo.Text = "OP" Then cli.insruccion = "select *from cli_01 where id_cli = '" & Trim(Me.txt_codigo.Text) & "' and tipo_cliente = 'Proveedor' and estado = 'ACTIVO'"
            cli.cargar_registro()
            If cli.verifica = False Then Exit Sub
            cli.carga_letra()

            If Me.txt_tipo.Text = "RC" Then
                If fact.Talonario_predeterminado = "1" Then tal.instruccion = "select talon,punto_venta,recibo from numerador with(rowlock,xlock) where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & fact.punto_venta & "'"
                If fact.Talonario_predeterminado = "2" Then tal.instruccion = "select talon,punto_venta,recibo from numerador with(rowlock,xlock) where talon ='" & fact.Talonario_predeterminado & "'"
            End If

            If Me.txt_tipo.Text = "OP" Then
                If fact.Talonario_predeterminado = "1" Then tal.instruccion = "select talon,punto_venta,orden_pago from numerador with(rowlock,xlock) where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & fact.punto_venta & "'"
                If fact.Talonario_predeterminado = "2" Then tal.instruccion = "select talon,punto_venta,orden_pago from numerador with(rowlock,xlock) where talon ='" & fact.Talonario_predeterminado & "'"
            End If

            tal.carga_numerador_factura()
            Call verifica_numerador_existente()
            If existe_num = True Then Me.Close()
            form_factura.verifica_fecha(Me.dt_fec_emision.Value.Month, Me.dt_fec_emision.Value.Year)
            If form_factura.fecha_mala = False Then Me.Close()
            Call total_cta_cte()

            Me.txt_numerador_respaldo.Text = Me.txt_numero.Text

            If fact.Pide_numero_recibo = "SI" Then
                Me.txt_numero.Enabled = True
            End If

            If fact.Pide_prefijo_recibo = "SI" Then
                Me.txt_prefijo.Enabled = True
                Me.txt_prefijo.Focus()
            End If

            If fact.pide_vendedor_recibo = "SI" Then
                Me.txt_vendedor.Enabled = True
                Me.txt_vendedor.Focus()
            End If

            If fact.sale = True Then
                Me.Close()
            End If

            End If

    End Sub

    Private Sub txt_comprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_comprobante.KeyDown

        If e.KeyCode = Keys.F1 Then
            Form_cta_cte.Show()
        End If

        If e.KeyCode = Keys.Space Then

            Call confirma_recibo()

        End If

        If e.KeyCode = Keys.F3 Then

            If acuenta = True Then
                MessageBox.Show("Ya ingreso un recibo a cuenta...!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.txt_comprobante.Text = "RA"
            Me.txt_letra1.Text = Me.txt_letra.Text
            Me.txt_num.Text = Me.txt_numero.Text
            Me.txt_pre.Text = Me.txt_talonario_pred.Text
            Me.txt_total_general.Enabled = True
            Me.txt_total_general.ReadOnly = False
            Me.txt_total_general.Focus()
            ra = False

            acuenta = True

        End If

        If e.KeyCode = Keys.Escape Then
            Me.DataGridView1.Focus()
            Call calcula_total()
        End If

    End Sub

    Private Sub cmd_busca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_busca.Click

        Form_cta_cte.Show()

    End Sub

    Private Sub form_factura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Me.txt_cierra_form.Text = 2 Then

            e.Cancel = True
            Form_cta_cte.TopMost = True

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.F5 Then

                Call confirma_recibo()

            End If

            If e.KeyCode = Keys.Insert Then

                Me.txt_comprobante.Focus()

            End If

            If e.KeyCode = Keys.Return Then

                Me.txt_total_general.Enabled = True

                z = Me.DataGridView1.CurrentCell.RowIndex
                Me.txt_total_general.ReadOnly = False

                Me.txt_total_general.Text = Me.DataGridView1.Rows(z).Cells(6).Value
                Me.txt_total_general.SelectAll()
                Me.txt_total_general.Focus()

            End If

            If e.KeyCode = Keys.Delete Then

                i = Me.DataGridView1.CurrentCell.RowIndex

                tal.instruccion = "Update cta_cte01 set estado = 'DEBE' where num_fact = '" & Me.DataGridView1.Rows(i).Cells(3).Value & "' and tc = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "' and lt = '" & Me.DataGridView1.Rows(i).Cells(1).Value & "' and pre = '" & Me.DataGridView1.Rows(i).Cells(2).Value & "'"
                tal.actualizar()

                Me.txt_fila.Text = Me.txt_fila.Text - 1

                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))

                Call suma_total_general()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub confirma_recibo()

        If Me.DataGridView1.Rows.Count < 1 Then
            MessageBox.Show("No hay Datos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.DataGridView1.Rows.Count > 30 Then
            MessageBox.Show("Hay mas de 30 comprobantes seleccionados", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.txt_total.Text < 0 Then
            MessageBox.Show("El monto total no puede ser negativo", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call calcula_total()

        Dim a As Integer = MessageBox.Show("Confirma Comprobante!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        If a = 6 Then

            ab = MessageBox.Show("Desea imprimir el Comprobante", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            conex = conecta()
            comando = New SqlDataAdapter("select talon from numerador where talon = '" & Me.txt_talonario_pred.Text & "'", conex)
            comando.Fill(tbl)

            Form_tipo_pago.txt_num.Text = Me.txt_numero.Text
            Form_tipo_pago.txt_letra.Text = Me.txt_letra.Text
            Form_tipo_pago.txt_pre.Text = Me.txt_prefijo.Text
            Form_tipo_pago.txt_tipo.Text = Me.txt_tipo.Text
            Form_tipo_pago.txt_fec_emi.Text = Me.dt_fec_emision.Text
            Form_tipo_pago.txt_p_venta.Text = Me.txt_p_venta.Text
            Form_tipo_pago.txt_talon.Text = tbl.Rows(0).Item(1)
            Form_tipo_pago.Show()
            tbl.Clear()

        End If

    End Sub

    Private Sub actualiza_cta_cte_pro()

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            fec_emi = Me.DataGridView1.Rows(i).Cells(5).Value
            letra = Me.DataGridView1.Rows(i).Cells(1).Value
            pref = Me.DataGridView1.Rows(i).Cells(2).Value
            numero = Me.DataGridView1.Rows(i).Cells(3).Value
            desc = Me.DataGridView1.Rows(i).Cells(4).Value
            tipo = Me.DataGridView1.Rows(i).Cells(0).Value
            importe = Me.DataGridView1.Rows(i).Cells(6).Value
            total1 = Me.DataGridView1.Rows(i).Cells(7).Value
            saldo1 = Me.DataGridView1.Rows(i).Cells(8).Value

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RA" And ra = False Then

                fact.instruccion = "INSERT INTO cta_cte_pro(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,cod_vend,confirma) VALUES('" & numero & "','RA', '" & letra & "','" & pref & "','" + Me.txt_codigo.Text + "','" + Me.txt_cliente.Text + "','" & fec_emi & "','" & Me.dt_fec_vto.Text & "','','" & importe & "','" & numero & "', 'DEBE','" & Me.txt_vendedor.Text & "','P')"
                fact.guardar_factura()

                Exit Sub

            End If

            If importe = total1 Then  ' si el importe es igual al total lE PONE PAGADO sino lo actualiza

                fact.instruccion = "delete cta_cte_pro where tc= '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                fact.guardar_factura()

            Else

                If RTrim(tipo) = "FC" Then

                    fact.instruccion = "update cta_cte_pro set tc= '" & RTrim(tipo) & "',lt = '" & RTrim(letra) & "',pre = '" & RTrim(pref) & "',num_fact = '" & RTrim(numero) & "',debito = '" & RTrim(saldo1) & "',estado = 'DEBE' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                    fact.guardar_factura()

                End If

                If RTrim(tipo) = "NC" Then

                    fact.instruccion = "update cta_cte_pro set tc= '" & RTrim(tipo) & "',lt = '" & RTrim(letra) & "',pre = '" & RTrim(pref) & "',num_fact = '" & RTrim(numero) & "',credito = '" & RTrim(saldo1) & "', estado = 'DEBE' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                    fact.guardar_factura()

                End If

            End If

        Next

    End Sub

    Private Sub actualiza_cta_cte()

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            fec_emi = Me.DataGridView1.Rows(i).Cells(5).Value
            letra = Me.DataGridView1.Rows(i).Cells(1).Value
            pref = Me.DataGridView1.Rows(i).Cells(2).Value
            numero = Me.DataGridView1.Rows(i).Cells(3).Value
            desc = Me.DataGridView1.Rows(i).Cells(4).Value
            tipo = Me.DataGridView1.Rows(i).Cells(0).Value
            importe = Me.DataGridView1.Rows(i).Cells(6).Value
            total1 = Me.DataGridView1.Rows(i).Cells(7).Value
            saldo1 = Me.DataGridView1.Rows(i).Cells(8).Value

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RA" And ra = False Then

                fact.instruccion = "INSERT INTO cta_cte01(id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,cod_vend,confirma) VALUES('" & numero & "','RA', '" & letra & "','" & pref & "','" + Me.txt_codigo.Text + "','" + Me.txt_cliente.Text + "','" & fec_emi & "','" & Me.dt_fec_vto.Text & "','','" & importe & "','" & numero & "', 'DEBE','" & Me.txt_vendedor.Text & "','P')"
                fact.guardar_factura()

                Exit Sub

            End If

            If importe = total1 Then  ' si el importe es igual al total lE PONE PAGADO sino lo actualiza

                fact.instruccion = "delete cta_cte01 where tc= '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                fact.guardar_factura()

            Else

                If RTrim(tipo) = "FC" Or RTrim(tipo) = "ND" Then

                    fact.instruccion = "update cta_cte01 set tc= '" & RTrim(tipo) & "',lt = '" & RTrim(letra) & "',pre = '" & RTrim(pref) & "',num_fact = '" & RTrim(numero) & "',debito = '" & RTrim(saldo1) & "',estado = 'DEBE' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                    fact.guardar_factura()

                End If

                If RTrim(tipo) = "NC" Then

                    fact.instruccion = "update cta_cte01 set tc= '" & RTrim(tipo) & "',lt = '" & RTrim(letra) & "',pre = '" & RTrim(pref) & "',num_fact = '" & RTrim(numero) & "',credito = '" & RTrim(saldo1) & "', estado = 'DEBE' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pref) & "' and num_fact = '" & RTrim(numero) & "'"
                    fact.guardar_factura()

                End If

            End If

        Next

    End Sub

    Private Sub txt_total_general_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_total_general.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.txt_total_general.Text = "" Then Exit Sub

            If RTrim(Me.txt_comprobante.Text) = "RA" Then

                Me.DataGridView1.Rows.Add()

                x = Me.DataGridView1.Rows.Count - 1

                Me.DataGridView1.Rows(x).Cells(0).Value = Me.txt_comprobante.Text
                Me.DataGridView1.Rows(x).Cells(1).Value = Me.txt_letra1.Text
                Me.DataGridView1.Rows(x).Cells(2).Value = Me.txt_pre.Text
                Me.DataGridView1.Rows(x).Cells(3).Value = Me.txt_num.Text
                Me.DataGridView1.Rows(x).Cells(4).Value = Me.txt_cliente.Text
                Me.DataGridView1.Rows(x).Cells(5).Value = Me.dt_fec_emision.Text
                Me.DataGridView1.Rows(x).Cells(6).Value = Me.txt_total_general.Text
                Me.DataGridView1.Rows(x).Cells(7).Value = Me.txt_total_general.Text
                Me.DataGridView1.Rows(x).Cells(8).Value = Me.txt_total_general.Text
                Me.txt_total.Text = Me.txt_total_general.Text

                Me.txt_total_general.Text = ""
                Me.txt_comprobante.Text = ""
                Me.txt_pre.Text = ""
                Me.txt_letra1.Text = ""
                Me.txt_num.Text = ""
                Me.txt_comprobante.Focus()

                Exit Sub

            End If

            If Val(Me.txt_total_general.Text) = 0 Or Me.txt_total_general.Text = "" Then Exit Sub

            If Val(Me.txt_total_general.Text) < Val(Me.DataGridView1.Rows(z).Cells(6).Value) Then

                Me.DataGridView1.Rows(z).Cells(6).Value = Me.txt_total_general.Text
                Me.DataGridView1.Rows(z).Cells(8).Value = Me.DataGridView1.Rows(z).Cells(7).Value - Me.DataGridView1.Rows(z).Cells(6).Value

                Call suma_total_general()

            Else

                MessageBox.Show("Verifique Importe", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

            Me.txt_comprobante.Focus()
            Me.txt_total_general.ReadOnly = True
            Me.txt_total_general.Enabled = False
            Me.txt_total_general.Text = ""

        End If

        If e.KeyCode = Keys.Escape Then
            Me.DataGridView1.Focus()
            Me.txt_total_general.Text = ""
        End If

    End Sub

    Private Sub txt_total_general_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total_general.KeyPress
        num.positivos_punto(e, Me.txt_total_general)
    End Sub

    Private Sub txt_numero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numero.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then
            Me.dt_fec_emision.Focus()
        End If
    End Sub

    Private Sub txt_numero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus

        If fact.sale = True Then
            verifica = 1
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub suma_total_general()

        Dim i As Integer
        Dim tot As Double

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "ND" Then

                tot = tot + Me.DataGridView1.Rows(i).Cells(6).Value

            End If

            If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = "NC" Then

                tot = tot - Me.DataGridView1.Rows(i).Cells(6).Value

            End If

        Next

        Me.txt_total.Text = Format(tot, "0.00")

    End Sub

    Public Sub total_cta_cte()

        Dim tbl1 As New DataTable
        Dim total, total1 As Double

        conex = conecta()
        comando = New SqlDataAdapter("select tc,debito,credito from cta_cte01 where id_cli = '" & RTrim(Me.txt_codigo.Text) & "' and cli = '" & RTrim(Me.txt_cliente.Text) & "' and estado = 'DEBE'", conex)
        comando.Fill(tbl1)

        For i = 0 To tbl1.Rows.Count - 1

            If RTrim(tbl1.Rows(i).Item(0)) = "FC" Or RTrim(tbl1.Rows(i).Item(0)) = "ND" Then

                total = total + Val(tbl1.Rows(i).Item(1))

            Else

                total1 = total1 - Val(tbl1.Rows(i).Item(2)) * (-1)

            End If

        Next

        Me.txt_saldo_ant.Text = Format(total - total1, "0.00")

    End Sub

    Public Sub guarda_recibo()

        Try

            Call actualiza_numerador()

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
            End If

            coman = New SqlCommand("INSERT INTO recibo_cab(id_rec,letra,tc,pre,fec_emi,fec_vto,id_cli,nombre,direccion,saldo_ant,arqueo,talon,p_venta2,pago,cod_vendedor,nom_vendedor) VALUES('" & Me.txt_numero.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_tipo.Text & "','" & Me.txt_prefijo.Text & "','" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_cliente.Text & "','" & Me.txt_direccion.Text & "','" & Me.txt_saldo_ant.Text & "','B','" & Me.txt_talonario_pred.Text & "','" & Me.txt_p_venta.Text & "','PAGADO','" & Me.txt_vendedor.Text & "','" & Me.txt_nom_vendedor.Text & "')", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                fec_emi = Me.DataGridView1.Rows(i).Cells(5).Value
                letra = Me.DataGridView1.Rows(i).Cells(1).Value
                numero = Me.DataGridView1.Rows(i).Cells(3).Value
                desc = Me.DataGridView1.Rows(i).Cells(4).Value
                tipo = Me.DataGridView1.Rows(i).Cells(0).Value
                importe = Me.DataGridView1.Rows(i).Cells(6).Value
                total1 = Me.DataGridView1.Rows(i).Cells(7).Value
                pre = Me.DataGridView1.Rows(i).Cells(2).Value

                coman = New SqlCommand("INSERT INTO recibo_det(id_det,letra_01,pre1,id_cli01,letra_fact,tipo_fact,pre_fact,num_fact,descripcion,fecha,cancelado,total,tc1,talon1,p_venta1) VALUES('" & Me.txt_numero.Text & "','" + Me.txt_letra.Text + "','" & Me.txt_prefijo.Text & "','" & Me.txt_codigo.Text & "','" & letra & "','" & tipo & "','" & pre & "','" & numero & "','" & desc & "','" & fec_emi & "','" & importe & "','" & total1 & "', '" & Me.txt_tipo.Text & "','" & Me.txt_talonario_pred.Text & "','" & Me.txt_p_venta.Text & "')", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

            Next

            coman = New SqlCommand("INSERT INTO recibo_tot(id_tot,lt,pre2,id_cliente,total,total_cobro,tip,efectivo,fec_emi1,talon2,p_venta,pago) VALUES('" & Me.txt_numero.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_prefijo.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_total.Text & "','" & Me.txt_total_cobro.Text & "', '" & Me.txt_tipo.Text & "','SI', '" & Me.dt_fec_emision.Text & "','" & Me.txt_talonario_pred.Text & "','" & Me.txt_p_venta.Text & "','PAGADO')", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If Me.txt_total_cobro.Text = 1 Then

                'coman = New SqlCommand("update recibo_tot set total_cobro = '" + Me.txt_importe_cobro.Text + "' where id_tot = '" + Me.txt_numero.Text + "' and lt = '" + Me.txt_letra.Text + "' and pre2 = '" + Me.txt_prefijo.Text + "' and tip = '" & Me.txt_tipo.Text & "'", conex)
                'coman.ExecuteNonQuery()
                'coman.Dispose()

                If Me.txt_modifica_efectivo.Text = 1 Then
                    coman = New SqlCommand("update recibo_tot set efectivo = 'NO' where id_tot = '" + Me.txt_numero.Text + "' and lt = '" + Me.txt_letra.Text + "' and pre2 = '" + Me.txt_prefijo.Text + "' and tip = '" & Me.txt_tipo.Text & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()
                End If

            End If

            If Me.txt_tipo.Text = "RC" Then
                Call actualiza_cta_cte()
                Call actualiza_cta_cte_hist()
            End If

            If Me.txt_tipo.Text = "OP" Then
                Call actualiza_cta_cte_pro()
                Call actualiza_cta_cte_hist_pro()
            End If

            If ab = 6 Then
                If Me.txt_tipo.Text = "RC" Then Call imprime_recibo()
                If Me.txt_tipo.Text = "OP" Then Call imprime_orden_pago()
            End If

            verifica = 1

        Catch ex As Exception

        Finally

            conex.Close()

        End Try

    End Sub

    Public Sub actualiza_numerador()

        'tal.instruccion = "select max(recibo) from numerador where id_num ='" & fact.Talonario_predeterminado & "'"
        'tal.incrementa_numerador()

        Dim tb_rec As New DataTable

        conex = conecta()

        comando = New SqlDataAdapter("select max(recibo),max(orden_pago) from numerador with(rowlock,xlock) where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & Me.txt_p_venta.Text & "'", conex)
        comando.Fill(tb_rec)

        If conex.State = ConnectionState.Closed Then
            conex = conecta()
            conex.Open()
        End If

        If Me.txt_tipo.Text = "RC" Then

            coman = New SqlCommand("update numerador with(rowlock,xlock) set recibo = '" & tb_rec.Rows(0).Item(0) + 1 & "' where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & Me.txt_p_venta.Text & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            conex.Close()
            tb_rec.Dispose()
            comando.Dispose()
            Exit Sub

        End If

        If Me.txt_tipo.Text = "OP" Then

            coman = New SqlCommand("update numerador with(rowlock,xlock) set orden_pago = '" & tb_rec.Rows(0).Item(1) + 1 & "' where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & Me.txt_p_venta.Text & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            conex.Close()
            tb_rec.Dispose()
            comando.Dispose()
            Exit Sub

        End If

    End Sub

    Private Sub imprime_recibo()

        fact.imprime_recibo(Me.txt_letra.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_total.Text, Me.txt_talonario_pred.Text)

    End Sub

    Private Sub imprime_orden_pago()

        fact.imprime_orden_pago(Me.txt_letra.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_total.Text, Me.txt_talonario_pred.Text)

    End Sub

    Private Sub txt_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_vendedor.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_vendedor.Show()
        End If

        If e.KeyCode = Keys.Return Then

            vend.cargar(Me.txt_vendedor.Text)
            If vend.verifica = True Then Me.txt_vendedor.Enabled = False

        End If

    End Sub

    Private Sub calcula_total()

        Dim i As Integer
        Dim suma As Double

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If Trim(Me.DataGridView1.Rows(i).Cells(0).Value) = "FC" Or Trim(Me.DataGridView1.Rows(i).Cells(0).Value) = "ND" Then

                'Dim x As Double = Me.DataGridView1.Rows(i).Cells(6).Value

                suma = Format(suma + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")

            End If

            If Trim(Me.DataGridView1.Rows(i).Cells(0).Value) = "NC" Then

                suma = Format(suma - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")

            End If

            If Trim(Me.DataGridView1.Rows(i).Cells(0).Value) = "RA" Then

                If ra = True Then
                    suma = Format(suma - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                End If

                If ra = False Then
                    suma = Format(suma + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                End If

            End If

        Next

        Me.txt_total.Text = suma

    End Sub

    Private Sub actualiza_cta_cte_hist()

        Dim tb1 As New DataTable, tb2 As New DataTable
        Dim i As Integer

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            tb1.Clear()
            tb2.Clear()
            conex = conecta()

            Dim j As Integer = 0
            Dim suma As Double = 0

            comando = New SqlDataAdapter("select cancelado,total from recibo_det where num_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(3).Value) & "' and tipo_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and letra_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) & "' and pre_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(2).Value) & "'", conex)
            comando.Fill(tb1)
            comando.Dispose()

            ' verifica que no este inresado el recibo

            comando = New SqlDataAdapter("select *from cta_cte_hist where num = '" & RTrim(Me.txt_numero.Text) & "' and tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "'", conex)
            comando.Fill(tb2)
            comando.Dispose()

            If tb2.Rows.Count = Nothing Then
                repetido = True
            Else
                repetido = False
            End If

            For j = 0 To tb1.Rows.Count - 1

                suma = Format(suma + tb1.Rows(j).Item(0), "0.00")

            Next

            If suma = RTrim(tb1.Rows(0).Item(1)) Then

                conex = conecta()
                If conex.State = ConnectionState.Closed Then conex.Open()

                letra = Me.DataGridView1.Rows(i).Cells(1).Value
                tipo = Me.DataGridView1.Rows(i).Cells(0).Value
                pre = Me.DataGridView1.Rows(i).Cells(2).Value
                num1 = Me.DataGridView1.Rows(i).Cells(3).Value

                ' ingresa en tabla para guardar historial cta cte 

                coman = New SqlCommand("update cta_cte_hist set estado = 'PAGADO' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pre) & "' and num = '" & RTrim(num1) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                If repetido = True Then
                    coman = New SqlCommand("INSERT INTO cta_cte_hist(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" + Me.txt_numero.Text + "','" & Me.txt_tipo.Text & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','','" & Me.txt_total.Text & "','PAGADO','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "' , '" & Me.txt_cliente.Text & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()
                End If

                conex.Close()

            Else

                If conex.State = ConnectionState.Closed Then conex.Open()

                If repetido = True Then
                    coman = New SqlCommand("INSERT INTO cta_cte_hist(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" + Me.txt_numero.Text + "','" & Me.txt_tipo.Text & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','','" & Me.txt_total.Text & "','PAGADO','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "' , '" & Me.txt_cliente.Text & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()
                End If

                conex.Close()

                End If

        Next

    End Sub

    Private Sub actualiza_cta_cte_hist_pro()

        Dim tb1 As New DataTable, tb2 As New DataTable
        Dim i As Integer

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            tb1.Clear()
            tb2.Clear()
            conex = conecta()

            Dim j As Integer = 0
            Dim suma As Double = 0

            comando = New SqlDataAdapter("select cancelado,total from recibo_det where num_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(3).Value) & "' and tipo_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and letra_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) & "' and pre_fact = '" & RTrim(Me.DataGridView1.Rows(i).Cells(2).Value) & "'", conex)
            comando.Fill(tb1)

            ' verifica que no este inresado el recibo

            comando = New SqlDataAdapter("select *from cta_cte_hist_pro where num = '" & RTrim(Me.txt_numero.Text) & "' and tc = '" & RTrim(Me.txt_tipo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "'", conex)
            comando.Fill(tb2)

            If tb2.Rows.Count = Nothing Then
                repetido = True
            Else
                repetido = False
            End If

            For j = 0 To tb1.Rows.Count - 1

                suma = Format(suma + tb1.Rows(j).Item(0), "0.00")

            Next

            If suma = RTrim(tb1.Rows(0).Item(1)) Then

                conex = conecta()
                If conex.State = ConnectionState.Closed Then conex.Open()

                letra = Me.DataGridView1.Rows(i).Cells(1).Value
                tipo = Me.DataGridView1.Rows(i).Cells(0).Value
                pre = Me.DataGridView1.Rows(i).Cells(2).Value
                num1 = Me.DataGridView1.Rows(i).Cells(3).Value

                ' ingresa en tabla para guardar historial cta cte 

                coman = New SqlCommand("update cta_cte_hist_pro set estado = 'PAGADO' where tc = '" & RTrim(tipo) & "' and lt = '" & RTrim(letra) & "' and pre = '" & RTrim(pre) & "' and num = '" & RTrim(num1) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                If repetido = True Then
                    coman = New SqlCommand("INSERT INTO cta_cte_hist_pro(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" + Me.txt_numero.Text + "','" & Me.txt_tipo.Text & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','','" & Me.txt_total.Text & "','PAGADO','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "' , '" & Me.txt_cliente.Text & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()
                End If

                coman.Dispose()
                conex.Close()

            Else

                If conex.State = ConnectionState.Closed Then conex.Open()

                If repetido = True Then
                    coman = New SqlCommand("INSERT INTO cta_cte_hist_pro(num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" + Me.txt_numero.Text + "','" & Me.txt_tipo.Text & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','','" & Me.txt_total.Text & "','PAGADO','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "' , '" & Me.txt_cliente.Text & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()
                End If

                coman.Dispose()
                conex.Close()

            End If

        Next

    End Sub


    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\manual\recibo.html")
    End Sub

    Public Sub verifica_numerador_existente()

        Dim tb_existe As New DataTable

        tb_existe.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select * from recibo_cab where id_rec = '" & RTrim(Me.txt_numero.Text) & "' and tc = '" & RTrim(Me.txt_tipo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and talon = '" & Me.txt_talonario_pred.Text & "'", conex)
        comando.Fill(tb_existe)

        If tb_existe.Rows.Count <> Nothing Then
            MessageBox.Show("El numero ya existe", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            existe_num = True
        Else
            existe_num = False
        End If

        tb_existe.Dispose()

    End Sub

End Class