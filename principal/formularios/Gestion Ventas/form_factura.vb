Imports System.Data
Imports System.Data.SqlClient

Public Class form_factura

    Dim fact As New pymsoft.factura
    Dim art As New pymsoft.articulo
    Dim cli As New pymsoft.cliente1
    Dim tal As New pymsoft.talonario
    Dim vend As New pymsoft.vendedor
    Dim sel As New pymsoft.selecciona
    Dim lis As New pymsoft.prov_vend_list_bco
    Dim fact_elec As New pymsoft.factura_electronica
    Dim num As New pymsoft.numerodecimales
    Dim reporte As New pymsoft.reporte
    Dim año, mes, dia, precio_codbar, nom_codbar, cuit_empresa As String
    Dim trans As SqlTransaction
    Dim cant1, temp_precio As Double
    Dim fila_actual As Boolean
    Dim tbl As New DataTable, tbbl As New DataTable, tbbl1 As New DataTable, tb1 As New DataTable, tt As New DataTable, tb_cant As New DataTable, tb_cuit As New DataTable
    Dim comando As New SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl1 As New DataTable, tbl2 As New DataTable, tb As New DataTable
    Dim coman As SqlCommand
    Dim conta As Integer
    Dim valor As String = ""
    Public factor_k, monto, imp, ivas, cant, neto_10, neto_21 As Double
    Dim cantidad_anterior As Double = 0
    Public err_1 As Short = 0
    Public abre As Integer = 0
    Dim cabecera, lee_cod_aut_1_vez As Short
    Public codigo_iva As Short
    Dim muestra_tipo_pago As Boolean
    Dim codigo_bar, nom_computadora, iva_valor As String
    Public porcentaje_impuesto As String
    Public sale As Boolean = False, numerador As Boolean = True, fecha_mala As Boolean = True, estado = False
    Dim i, j, x, cont, pos As Short
    Dim valor_anterior, valor_anterior1, valor_anterior2, interno, insc, insc_10, exento As Single
    Dim total As Decimal
    Dim coma As Short
    Dim error_cantidad As Boolean = True, entra_en_grilla As Boolean = True, renta As Boolean = True, total_01 As Boolean = True, verifica As Boolean = False, band As Boolean = True, cta_cte As Boolean = False, entra_ean13 As Boolean = False
    Dim cuenta, z, y, fila_ped
    Dim pedido As Integer = 6
    Dim cuenta_fila As Integer = 1
    Public tipo As String, valor_total As String = 0, a As String
    Public tipo1, ticket, cuit As String
    Public comentario As String
    Dim cod_barra As Boolean = False, veri_remito As Boolean = True, veri_comprobante As Boolean = True, lee_enter As Boolean = True, no_entrar As Boolean = True
    Public existe_num As Boolean = False, ativo As Boolean = False
    Dim cant_var As String = "1"
    Dim qr As Byte()

    Private Sub form_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        barra_carga.Timer1.Enabled = True

        If Form_recibos.txt_estado_form.Text = 1 Or Form_presupuesto.txt_estado_form.Text = 1 Then
            MessageBox.Show("Hay un comprobante abierto...Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        nom_computadora = My.Computer.Name
        Me.txt_estado_form.Text = 1

        If Trim(Me.txt_factura_notaCredito.Text) = 1 Or RTrim(Form_login.txt_tipoo.Text) = 1 Then
            Me.txt_factura_notaCredito.Text = 1
            Me.Text = "FACTURA"
            Me.txt_form.Text = Me.Text
            Me.txt_tipo_fact.Text = "FC"
        End If

        If Trim(Me.txt_factura_notaCredito.Text) = 2 Then

            Me.Text = "NOTA DE CREDITO"
            Me.txt_form.Text = Me.Text
            Me.txt_tipo_fact.Text = "NC"

        End If

        If Trim(Me.txt_factura_notaCredito.Text) = 3 Then

            Me.Text = "NOTA DE DEBITO"
            Me.txt_form.Text = Me.Text
            Me.txt_tipo_fact.Text = "ND"

        End If

        Me.dt_fec_emision.Text = Date.Now
        Me.dt_fec_vto.Text = Date.Now

        fact.carga_parametro()

        'Si es de contado
        If fact.condicion_venta = 1 Then
            Me.cmb_forma_pago.Text = Me.cmb_forma_pago.Items(0)
        Else
            Me.cmb_forma_pago.Text = Me.cmb_forma_pago.Items(1)
        End If

        If fact.Habilita_descuento_gral = "SI" Then
            Me.txt_descuento_gral.Enabled = True
        Else
            Me.txt_descuento_gral.Enabled = False
        End If

        ticket = fact.imprime_tikets
        Me.txt_talonario_pred.Text = fact.Talonario_predeterminado

        If RTrim(Me.txt_remito.Text) = 1 Then
            Me.Text = "REMITO ENTRADA"
            Me.txt_form.Text = Me.Text
            ticket = "NO"
            veri_remito = False
        End If

        If RTrim(Me.txt_remito.Text) = 2 Then
            Me.Text = "REMITO SALIDA"
            Me.txt_form.Text = Me.Text
            ticket = "NO"
            veri_remito = False
        End If

        If fact.Pide_talonario_factura = "SI" And (RTrim(Me.txt_tipo_fact.Text) = "FC" Or RTrim(Me.txt_tipo_fact.Text) = "NC" Or RTrim(Me.txt_tipo_fact.Text) = "ND") Then

            If veri_remito <> False Then

                Dim x As String = InputBox("Ingrese Talonario" & vbCrLf & " " & vbCrLf & "1- Talonario Fiscal" & vbCrLf & "2- Talonario Alternativo", "PyM Soft", 2)

                If x = "1" Then
                    Me.txt_talonario_pred.Text = x
                    fact.Talonario_predeterminado = x
                End If

                If x = "2" Then
                    Me.txt_talonario_pred.Text = x
                    fact.Talonario_predeterminado = x
                End If

                If x <> "1" And x <> "2" Then

                    MessageBox.Show("No existe Talonario!!!!", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Form_login.txt_tipoo.Text = 0
                    Me.Dispose()
                    Exit Sub

                End If

            End If

        End If

        Me.txt_lista_predet.Text = fact.lista_predeterminada
        Me.txt_codigo_producto.MaxLength = fact.longitud_codigo_barra

        If fact.mueve_stock = "NO" Then
            Me.txt_stock.Visible = False
            'Me.lbl_bulto.Visible = False
            Me.Label10.Visible = False
            'Me.Label20.Visible = False
        End If

        If RTrim(Me.txt_tipo_fact.Text) = "PD" Or RTrim(Form_login.txt_tipo_letra.Text) = "PD" Then
            Me.txt_tipo_fact.Text = "PD"
            tipo1 = "PD"
            fact.Talonario_predeterminado = 2
            Me.txt_talonario_pred.Text = 2
        End If

        If RTrim(fact.cliente_fijo) <> 0 And RTrim(Me.txt_tipo_fact.Text) <> "PD" Then

            If Me.txt_remito.Text <> 1 And Me.txt_remito.Text <> 2 Then
                Call carga_registro(fact.cliente_fijo)
            End If

        End If

        If RTrim(fact.condicion_venta) = 1 Then
            Me.cmb_forma_pago.Text = Me.cmb_forma_pago.Items(0)
        Else
            Me.cmb_forma_pago.Text = Me.cmb_forma_pago.Items(1)
        End If

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then

            ativo = False
            busc_cliente.Show()

            If Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2 Then
                Me.txt_vendedor.Enabled = False
            End If

        End If

        If e.KeyCode = Keys.F2 Then
            Form_cliente.Show()
        End If

        If e.KeyCode = Keys.Return Then

            ativo = False
            Call carga_registro(Me.txt_codigo.Text)
            ativo = True

        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub txt_codigo_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.GotFocus

        If total_01 = True Then
            If Me.txt_remito.Text = 0 Then Call muestra_total()
            total_01 = False
            Me.Text = Me.Text & " - " & Me.cmb_forma_pago.Text & " - " & "Talonario:" & " " & Me.txt_talonario_pred.Text & "  -  " & "Nº Carga:" & " " & Me.txt_n_carga.Text
        End If

    End Sub

    Private Sub txt_codigo_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyDown
        Try

            Dim valor As Short = 0

            If e.KeyCode = Keys.F1 Then
                busc_articulos.txt_lista.Text = Me.txt_cod_lista.Text
                busc_articulos.Show()
            End If

            If e.KeyCode = Keys.Return Then

                If Me.DataGridView1.Rows.Count > 1 Then
                    pos = Me.DataGridView1.CurrentCell.RowIndex
                End If

                lee_enter = False
                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.txt_codigo_producto.Text & "' and art_precio.id_lista1 = '" & RTrim(Me.txt_cod_lista.Text) & "' and art_01.nombre = art_precio.nom and art_01.estado = 'Activo'"
                Call carga_codigo()

            End If

            If e.KeyCode = Keys.Escape Then

                Me.DataGridView1.Focus()
                Me.txt_codigo_producto.Enabled = False
                Me.txt_cantidad.Enabled = False
                Me.txt_desc_rcgo.Enabled = False

                Me.txt_imp_interno_grilla.Text = Format(interno, "0.00")
                Me.txt_inscripto.Text = Format(insc, "0.00")
                Me.txt_insc_10.Text = Format(insc_10, "0.00")
                Me.txt_exento.Text = Format(exento, "0.00")

                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""

                Call calcula_sub_total()

            End If

            If e.KeyCode = Keys.Space Then

                Me.txt_codigo_producto.Enabled = False
                Me.txt_cantidad.Enabled = False
                Me.txt_desc_rcgo.Enabled = False

                Me.txt_imp_interno_grilla.Text = Format(interno, "0.00")
                Me.txt_inscripto.Text = Format(insc, "0.00")
                Me.txt_insc_10.Text = Format(insc_10, "0.00")
                Me.txt_exento.Text = Format(exento, "0.00")

                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""

                Call calcula_sub_total()
                Call larga_comprobante()

            End If

            'If e.KeyCode = Keys.F2 And Me.txt_tipo_fact.Text = "PD" Then

            'Form_pendiente.Show()

            'End If

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
    'If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
    'e.KeyChar = ""
    'End If
    'End Sub

    Private Sub txt_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad.KeyDown

        Try

            Dim i As Short = 0

            If e.KeyCode = Keys.Return Then

                If Me.txt_cantidad.Text = Nothing Then Exit Sub

                tb1.Clear()
                conex = conecta()

                comando = New SqlDataAdapter("select cantidad from art_01 where art_01.id_art = '" & RTrim(Me.txt_codigo_producto.Text) & "' and art_01.nombre = '" & RTrim(Me.txt_nombre_producto.Text) & "' and art_01.estado = 'Activo'", conex)
                comando.Fill(tb1)
                comando.Dispose()

                Me.txt_cantidad.Text = Format(Me.txt_cantidad.Text + 0.0, "0.00")

                If lee_enter = True Then Exit Sub

                If cod_barra = False Then

                    If fact.mueve_stock = "NO" Then
                        Me.txt_mueve_stok.Text = "NO"
                    End If

                    If ((Me.txt_factura_notaCredito.Text = 1 And Trim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 2 And Trim(Me.txt_mueve_stok.Text) = "SI")) And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                        If Val(tb1.Rows(0).Item(0)) = 0 Or Val(tb1.Rows(0).Item(0)) < Val(Me.txt_cantidad.Text) Then

                            If RTrim(Me.txt_tipo_fact.Text) = "PD" Then

                                conex = conecta()
                                If conex.State = ConnectionState.Closed Then conex.Open()

                                comando = New SqlDataAdapter("select * from ped_det where num= '" & RTrim(Me.txt_numero.Text) & "' and pre ='" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and id_art2 = '" & RTrim(Me.txt_codigo_producto.Text) & "' and pc = '" & RTrim(My.Computer.Name) & "'", conex)
                                comando.Fill(tbbl)

                                If tbbl.Rows.Count = Nothing Then

                                    fila_ped = fila_ped + 1

                                    Dim tot As Double = Format(Me.txt_precioCiva.Text * Me.txt_cantidad.Text, "0.00")
                                    Dim ins As Double = Format(tot - (tot / Val("1." & porcentaje_impuesto)), "0.00")

                                    coman = New SqlCommand("INSERT INTO ped_det(fecha,num,tc,pre,lt,id_art2,detalle,cant,descuento,p_siva,total,p_civa,talon,lista,iva,iva_ins,fila,costo,cod_prov,cod_rub,deta,pc,vendedor1) VALUES('" & Me.dt_fec_emision.Text & "','" & Me.txt_numero.Text & "' ,'" & Me.txt_tipo_fact.Text & "', '" + Me.txt_prefijo.Text + "','" + Me.txt_letra.Text + "','" & Me.txt_codigo_producto.Text & "','" & Me.txt_nombre_producto.Text & "','" & Me.txt_cantidad.Text & "','" & Me.txt_desc_rcgo.Text & "','" & Me.txt_neto.Text & "','" & tot & "','" & Me.txt_precioCiva.Text & "','" & Me.txt_talonario_pred.Text & "','" & Me.txt_cod_lista.Text & "','" & Me.txt_iva1.Text & "','" & ins & "','" & fila_ped & "','" & Me.txt_precio_costo.Text & "','" & Me.txt_id_proveedor.Text & "','" & Me.txt_id_rubro.Text & "','" & Me.txt_nombre_producto.Text & "','" & My.Computer.Name & "','" & Me.txt_vendedor.Text & "')", conex)
                                    coman.ExecuteNonQuery()

                                    coman.Dispose()
                                    conex.Close()

                                End If

                                tbbl.Clear()
                                tbbl.Dispose()

                            End If

                            MessageBox.Show("Stock Insuficiente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txt_codigo_producto.Focus()
                            Me.txt_cantidad.Text = ""
                            Me.txt_neto.Text = ""
                            Me.txt_codigo_producto.Text = ""
                            Me.txt_nombre_producto.Text = ""
                            Me.txt_stock.Text = ""
                            Me.lbl_bulto.Text = ""
                            Me.txt_desc_rcgo.Text = ""

                            If error_cantidad = False Then

                                i = Me.DataGridView1.CurrentCell.RowIndex - 1

                                If verifica = True Then

                                    If conex.State = ConnectionState.Closed Then conex.Open()

                                    coman = New SqlCommand("delete ped_det where id_art2 = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num = '" & RTrim(Me.txt_numero.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "'", conex)
                                    coman.ExecuteNonQuery()

                                    coman.Dispose()
                                    conex.Close()

                                End If

                                If fact.mueve_stock = "SI" Or Me.txt_mueve_stok.Text = "SI" Then Call act_falla_stk(Me.DataGridView1, nom_computadora, i)

                                Dim c As String = Me.DataGridView1.Rows(i).Cells(4).Value

                                total = total - Me.DataGridView1.Rows(i).Cells(4).Value
                                Me.lbl_Marcador_precio.Text = Format(total, "0.00")
                                Me.lbl_Marcador_precio.Text = Me.lbl_Marcador_precio.Text
                                x = x - 1
                                z = z - 1

                                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))
                                verifica = False
                                fact.fila = fact.fila - 1

                                error_cantidad = True

                                cont = cont - 1
                                Me.lbl_cont.Text = cont

                            End If

                            Exit Sub

                        End If

                    End If

                    tb1.Dispose()

                    If fact.pide_precio = "NO" And fact.habilita_descuento = "NO" And fact.cantidad_automatica = "NO" Then Call calcula_total()

                    If Me.txt_cantidad.Text = "" Then
                        Me.txt_cantidad.Text = "0.00"
                    End If

                    If Me.txt_cantidad.Text <= 0 Then
                        MessageBox.Show("Error Cantidad", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.txt_cantidad.Focus()
                        Exit Sub
                    End If

                    If fact.pide_precio = "SI" Then
                        Me.txt_neto.Enabled = True
                        Me.txt_neto.BackColor = Color.Red
                        Me.txt_neto.ForeColor = Color.White
                        Me.txt_neto.Focus()
                        Me.txt_neto.SelectAll()
                    Else
                        Me.txt_desc_rcgo.Enabled = True
                        Me.txt_desc_rcgo.ReadOnly = False
                        Me.txt_desc_rcgo.Focus()
                    End If

                    temp_precio = Me.txt_neto.Text

                    If Me.txt_desc_rcgo.Visible = False And fact.pide_precio = "NO" Then
                        Call cargar_datos()
                    End If

                End If

            End If

            If e.KeyCode = Keys.Escape Then

                Me.txt_cantidad.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""
                Me.txt_neto.Text = ""
                Me.txt_codigo_producto.Text = ""
                Me.txt_codigo_producto.Focus()

            End If

            If e.KeyCode = Keys.F2 Then

                'If RTrim(Me.txt_tipo_fact.Text) = "FC" Or RTrim(Me.txt_tipo_fact.Text) = "NC" Or RTrim(Me.txt_tipo_fact.Text) = "PD" Then Exit Sub

                If RTrim(principal.lbl_usu.Text) <> "Administrador" Then Exit Sub

                Dim t As New DataTable

                t.Clear()
                conex = conecta()

                comando = New SqlDataAdapter("select desc1,desc2,desc3,flete,pago_total,cod_imp from art_precio where id_art1 = '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
                comando.Fill(t)
                comando.Dispose()

                Form_actualiza_grilla.txt_codigo_producto.Text = Me.txt_codigo_producto.Text

                Form_actualiza_grilla.lbl_nombre.Text = Me.txt_nombre_producto.Text
                Form_actualiza_grilla.txt_costo.Text = Me.txt_precio_costo.Text
                Form_actualiza_grilla.lbl_nom_imp_int.Text = Me.txt_imp_interno.Text
                Form_actualiza_grilla.txt_impuestos_internos.Text = t.Rows(0).Item(5)
                Form_actualiza_grilla.txt_utilidad.Text = Me.txt_utilidad.Text
                Form_actualiza_grilla.txt_precio_siva.Text = Me.txt_neto.Text
                Form_actualiza_grilla.txt_pciva.Text = Me.txt_precioCiva.Text
                Form_actualiza_grilla.txt_codigo_iva.Text = Me.txt_cod_iva.Text
                Form_actualiza_grilla.txt_desc1.Text = t.Rows(0).Item(0)
                Form_actualiza_grilla.txt_desc2.Text = t.Rows(0).Item(1)
                Form_actualiza_grilla.txt_desc3.Text = t.Rows(0).Item(2)
                Form_actualiza_grilla.txt_flete.Text = t.Rows(0).Item(3)
                Form_actualiza_grilla.txt_pago_total.Text = t.Rows(0).Item(4)

                If Me.txt_cod_iva.Text = "1" Then
                    Form_actualiza_grilla.lbl_tipo_iva.Text = Trim(porcentaje_impuesto)
                    Form_actualiza_grilla.lbl_nombre_iva.Text = " % " & "Resp.Insc"
                    Form_actualiza_grilla.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter
                End If
                If Me.txt_cod_iva.Text = "2" Then
                    Form_actualiza_grilla.lbl_tipo_iva.Text = Trim(porcentaje_impuesto)
                    Form_actualiza_grilla.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
                    Form_actualiza_grilla.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter
                End If
                If Me.txt_cod_iva.Text = "3" Then
                    Form_actualiza_grilla.lbl_tipo_iva.Text = Trim(porcentaje_impuesto)
                    Form_actualiza_grilla.lbl_nombre_iva.Text = " % " & "Exento"
                    Form_actualiza_grilla.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter
                End If

                Form_actualiza_grilla.Show()

            End If

            If e.KeyCode = Keys.F1 Then
                Me.txt_nombre_producto.Focus()
                Me.txt_nombre_producto.SelectAll()
            End If

            cod_barra = False
            lee_enter = False

        Catch ex As Exception

            trans.Rollback()

        Finally

        End Try

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        num.positivos_punto(e, Me.txt_cantidad)
    End Sub

    Private Sub txt_desc_rcgo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desc_rcgo.KeyPress

        num.negativos_punto(e, Me.txt_desc_rcgo)

    End Sub

    Private Sub txt_desc_rcgo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_rcgo.KeyDown

        If e.KeyCode = Keys.Return Then

            ' pongo en cero la variable cont para que no me deje poner mas de un signo - (menos)
            num.cont = 0

            If Val(Me.txt_desc_rcgo.Text) < -99.99 Or Val(Me.txt_desc_rcgo.Text) > 99.99 Then
                Exit Sub
            End If

            If Val(Me.txt_cantidad.Text) > 0 Then
                Call cargar_datos()
            Else
                Exit Sub
            End If

        End If

        If e.KeyCode = Keys.Escape Then

            Me.txt_cantidad.Text = ""
            Me.txt_nombre_producto.Text = ""
            Me.txt_stock.Text = ""
            Me.lbl_bulto.Text = ""
            Me.txt_codigo_producto.Text = ""
            Me.txt_desc_rcgo.Text = ""
            Me.txt_neto.Text = ""
            Me.txt_codigo_producto.Focus()

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            valor = ""

            If e.KeyCode = Keys.Space Then

                Me.txt_codigo_producto.Enabled = False
                Me.txt_cantidad.Enabled = False
                Me.txt_desc_rcgo.Enabled = False

                Me.txt_imp_interno_grilla.Text = Format(interno, "0.00")
                Me.txt_inscripto.Text = Format(insc, "0.00")
                Me.txt_insc_10.Text = Format(insc_10, "0.00")
                Me.txt_exento.Text = Format(exento, "0.00")

                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""

                Call calcula_sub_total()
                Call larga_comprobante()

            End If

            If e.KeyCode = Keys.Return Then

                Me.txt_cantidad.ReadOnly = False

                Me.txt_cantidad.Enabled = True
                Me.txt_codigo_producto.Enabled = True
                Me.txt_desc_rcgo.Enabled = True
                Me.txt_cantidad.Focus()

                err_1 = 1

                i = Me.DataGridView1.CurrentCell.RowIndex
                fila_actual = True
                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,precio_civa,costo,impuestos,iva,exento,utilidad,id_iva,id_proveedor,id_rubro,mueve_stok,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "' and art_precio.id_lista1 = '" & Me.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre "

                art.codigo_1 = "id_art1"
                art.codigo_2 = "nombre"
                art.codigo_3 = "precio_siva"
                art.codigo_4 = "cantidad"
                art.codigo_5 = "cantidad_bulto"
                art.codigo_6 = "mueve_stok"
                art.codigo_7 = "precio_civa"
                art.codigo_12 = "costo"
                art.codigo_13 = "impuestos"
                art.codigo_10 = "iva"
                art.codigo_8 = "exento"
                art.codigo_14 = "id_iva"
                art.codigo_15 = "utilidad"
                art.codigo_16 = "id_proveedor"
                art.codigo_17 = "id_rubro"
                art.codigo_18 = "unidad_secundaria"
                art.codigo_19 = "peso_promedio"
                art.codigo_20 = "bonif_vta"

                art.cargar()

                If art.valida = False Then
                    Me.txt_codigo_producto.Focus()
                    Exit Sub
                End If

                Me.txt_codigo_producto.Text = art.codigo
                Me.txt_nombre_producto.Text = art.nombre

                If fact.factura_en_c = "SI" Then
                    Me.txt_neto1.Text = art.precio_civa
                    Me.txt_neto.Text = art.precio_civa
                End If

                If fact.factura_en_c = "NO" Then Me.txt_neto.Text = art.precio_siva
                Me.lbl_uni_sec.Text = art.unidad_secundaria
                Me.txt_stock.Text = art.cantidad
                Me.txt_precioCiva.Text = art.precio_civa
                Me.lbl_bulto.Text = art.cantidad_bulto
                Me.txt_precio_costo.Text = art.costo
                Me.txt_imp_interno.Text = art.impuestos_internos
                Me.txt_iva1.Text = art.iva
                Me.txt_exento1.Text = art.exento
                Me.txt_cantidad.Text = Me.DataGridView1.Rows(i).Cells(2).Value
                Me.txt_desc_rcgo.Text = Me.DataGridView1.Rows(i).Cells(5).Value
                Me.txt_utilidad.Text = art.uilidad
                Me.txt_cod_iva.Text = art.codigo_iva

                If Trim(Me.lbl_uni_sec.Text) = "SI" Then
                    Me.lbl_unidad_secundaria.Visible = True
                    Me.txt_unidad_secundaria.Visible = True
                    Me.txt_unidad_secundaria.ReadOnly = False
                    Me.txt_unidad_secundaria.Text = Me.DataGridView1.Rows(i).Cells(17).Value
                    Me.txt_unidad_secundaria.Focus()
                    Me.txt_unidad_secundaria.SelectAll()
                Else
                    Me.lbl_unidad_secundaria.Visible = False
                    Me.txt_unidad_secundaria.Visible = False
                    Me.txt_unidad_secundaria.Text = 0
                    Me.txt_cantidad.Enabled = True
                    Me.txt_cantidad.Focus()
                    Me.txt_cantidad.SelectAll()
                End If

                cantidad_anterior = Me.txt_cantidad.Text

                If RTrim(art.mueve_stok) = "NO" Then
                    Me.txt_stock.Text = ""
                    'Me.lbl_bulto.Text = ""
                End If

                If (RTrim(fact.mueve_stock) = "SI" Or RTrim(Me.txt_mueve_stok.Text) = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.Serializable)
                    End If

                    tb_cant.Clear()

                    comando = New SqlDataAdapter("select cantidad from art_01 with(rowlock,xlock) where id_art = '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tb_cant)

                End If

                If ((Trim(Me.txt_factura_notaCredito.Text) = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI") Or (Trim(Me.txt_remito.Text) = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI")) And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    art.cantidad = Val(Me.txt_cantidad.Text)
                    art.stok = Val(tb_cant.Rows(0).Item(0))
                    valor = art.stok + art.cantidad

                    trans.Commit()
                    conex.Close()

                End If

                If (Trim(Me.txt_factura_notaCredito.Text) = 1 And Trim(Me.txt_mueve_stok.Text) = "NO") Or (Me.txt_remito.Text = 2 And Trim(Me.txt_mueve_stok.Text) = "NO") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    valor = art.cantidad

                End If

                If (Me.txt_factura_notaCredito.Text = 2 And Trim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 1 And Trim(Me.txt_mueve_stok.Text) = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    art.cantidad = Val(Me.txt_cantidad.Text)
                    art.stok = Val(tb_cant.Rows(0).Item(0))
                    valor = art.stok - art.cantidad

                    trans.Commit()
                    conex.Close()

                End If

                If (Me.txt_factura_notaCredito.Text = 2 And Trim(Me.txt_mueve_stok.Text) = "NO") Or (Me.txt_remito.Text = 1 And Trim(Me.txt_mueve_stok.Text) = "NO") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    valor = art.cantidad

                End If

                If (fact.mueve_stock = "SI" Or Me.txt_mueve_stok.Text = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                    End If

                    coman = New SqlCommand("update art_01 with (rowlock,xlock) set cantidad= '" & valor & "' where id_art= '" & Me.txt_codigo_producto.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()
                    conex.Close()

                End If

                art.instruccion = "select *from art_01 inner join art_precio on art_precio.id_lista1 = '" & Me.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_precio.id_art1 = '" & Me.txt_codigo_producto.Text & "'"
                art.codigo_4 = "cantidad"

                art.cargar()

                If Trim(art.mueve_stok) = "SI" And Trim(Me.txt_tipo_fact.Text) <> "PD" Then Me.txt_stock.Text = art.cantidad

                verifica = True

                error_cantidad = False
                entra_en_grilla = True
                lee_enter = False

                x = Me.DataGridView1.CurrentCell.RowIndex

            End If


            If e.KeyCode = Keys.Insert Then

                err_1 = 0

                Call limpia_totales()
                Me.txt_codigo_producto.Enabled = True
                Me.txt_cantidad.Enabled = True
                Me.txt_desc_rcgo.Enabled = True
                Me.txt_codigo_producto.Focus()

            End If

            If e.KeyCode = Keys.Delete Then

                err_1 = 1

                i = Me.DataGridView1.CurrentCell.RowIndex   ' fila actual

                If Me.DataGridView1.Rows(i).Cells(0).Value = Nothing Then Exit Sub

                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "' and art_precio.id_lista1 = '" & Me.txt_cod_lista.Text & "' and art_01.nombre = art_precio.nom "
                art.codigo_1 = "id_art1"
                art.codigo_2 = "nombre"
                art.codigo_3 = "precio_siva"
                art.codigo_4 = "cantidad"
                art.codigo_5 = "cantidad_bulto"
                art.codigo_6 = "mueve_stok"
                art.codigo_7 = "precio_civa"
                art.codigo_8 = "iva_insc"
                art.codigo_9 = "impuestos"
                art.codigo_10 = "iva"
                art.codigo_11 = "exento"
                art.codigo_12 = "costo"
                art.codigo_13 = "codigo_barra"
                art.codigo_14 = "id_iva"
                art.codigo_15 = "utilidad"
                art.codigo_16 = "id_proveedor"
                art.codigo_17 = "id_rubro"
                art.cargar() ' recupero stock de esa fila

                Me.txt_mueve_stok.Text = art.mueve_stok

                If Trim(fact.mueve_stock) = "SI" And Trim(Me.txt_mueve_stok.Text) = "SI" And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.Serializable)
                    End If

                    tb_cant.Clear()

                    comando = New SqlDataAdapter("select cantidad from art_01 with(rowlock,xlock) where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tb_cant)

                    If Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_tipo_fact.Text = "PD" Then

                        valor = Val(tb_cant.Rows(0).Item(0))
                        Me.txt_stk_ant.Text = valor + Val(Me.DataGridView1.Rows(i).Cells(2).Value) ' modifico la cantida x borrar la fila 

                        trans.Commit()
                        conex.Close()

                    End If

                    If Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Then

                        valor = Val(tb_cant.Rows(0).Item(0))
                        Me.txt_stk_ant.Text = valor - Val(Me.DataGridView1.Rows(i).Cells(2).Value)  ' modifico la cantida x borrar la fila 

                        trans.Commit()
                        conex.Close()

                    End If

                    If fact.mueve_stock = "SI" Or Me.txt_mueve_stok.Text = "SI" Then Call act_falla_stk(Me.DataGridView1, nom_computadora, i)

                    If conex.State = ConnectionState.Closed Then
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                    End If

                    coman = New SqlCommand("update art_01 with(rowlock,xlock) set cantidad= '" & Val(Me.txt_stk_ant.Text) & "' where id_art = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()    ' lo actualizo

                    trans.Commit()
                    conex.Close()

                End If

                x = i
                total = Format(total - Me.DataGridView1.Rows(i).Cells(4).Value, "0.00")
                Me.lbl_Marcador_precio.Text = Me.lbl_Marcador_precio.Text
                Me.lbl_Marcador_precio.Text = Format(total, "0.00")

                insc = Format(insc - Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                insc_10 = Format(insc_10 - Me.DataGridView1.Rows(i).Cells(13).Value, "0.00")
                interno = interno - Format(Me.DataGridView1.Rows(i).Cells(7).Value, "0.00")
                exento = exento - Me.DataGridView1.Rows(i).Cells(9).Value

                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))
                fact.fila = Me.DataGridView1.RowCount - 1    'borro la fila

                cont = cont - 1
                Me.lbl_cont.Text = cont

                If Me.DataGridView1.Rows.Count > 0 Then

                    z = z - 1

                    If fact.cantidad_automatica = "SI" Then
                        cuenta_fila = cuenta_fila - 1
                        y = y - 1
                    End If

                End If

            End If

            If e.KeyCode = Keys.F5 Then

                Call larga_comprobante()

            End If

            If e.KeyCode = Keys.F3 Then
                Form_comentario.Show()
            End If

        Catch ex As Exception

            sale = False
            If err_1 <> 1 Then MessageBox.Show(Err.Description & "Numero error:", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub larga_comprobante()

        ' si es credito o debito en afip 
        ' debo informar comprobante al cual aplica
        If Trim(Me.txt_factura_notaCredito.Text) = 2 Or Trim(Me.txt_factura_notaCredito.Text) = 3 Then
            If Me.txt_comprobante_aplicar.Text = "" Or Me.txt_comprobante_aplicar.Text = "0" Then
                MessageBox.Show("Debe informar el comprobante al cual aplica!!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.txt_comprobante_aplicar.Focus()
                Me.txt_comprobante_aplicar.SelectAll()
                Exit Sub
            Else
                fact_elec.Comprobante_aplica = Me.txt_comprobante_aplicar.Text
            End If
        End If

        If Trim(Me.txt_cliente.Text) = "CONSUMIDOR FINAL" And fact.Talonario_predeterminado = 1 And Me.txt_remito.Text = 0 Then
            If Me.txt_total_grilla.Text > 172000 Then
                MessageBox.Show("El cliente consumidor final no puede superar los $172000!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If Me.DataGridView1.Rows(0).Cells(0).Value = Nothing Then
            MsgBox("No hay Datos", MsgBoxStyle.Information, "PyMsoft")
            Me.txt_codigo_producto.Enabled = True
            Me.txt_codigo_producto.Focus()
            Me.txt_codigo_producto.SelectAll()
            Exit Sub
        End If

        For i = 0 To Me.DataGridView1.Rows.Count - 2
            If Me.DataGridView1.Rows(i).Cells(4).Value = 0 Then
                MessageBox.Show("verifique Precio 0!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next

        If Me.txt_total_grilla.Text <= 0 Then
            MsgBox("Error importe factura", MsgBoxStyle.Information, "PyMsoft")
            Exit Sub
        End If

        valor = pedido

        If (RTrim(Me.txt_tipo_fact.Text) = "PD" Or RTrim(fact.ventana_imprime_factura) = "SI") Then

            If fact.Imprime_en_fiscal = "SI" And fact.Talonario_predeterminado = 1 Then
                fact.opcion_comprobante = "NO"
                If pedido = 2 Then Exit Sub
            Else
                pedido = MessageBox.Show("Imprime comprobante!!!!", "PyMsoft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                valor = pedido
                If pedido = 2 Then
                    Me.txt_codigo_producto.Enabled = True
                    Me.txt_codigo_producto.Focus()
                    Me.txt_codigo_producto.SelectAll()
                    Exit Sub
                End If

            End If

        End If

        If RTrim(Me.txt_tipo_fact.Text) <> "PD" And fact.si_o_no_factura = "SI" Then

            valor = MessageBox.Show("Confirma Comprobante", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

        Else

            'valor = 6

        End If

        If valor = 6 Or valor = 7 Then

            'Call actualiza_numeradores()

            If Me.txt_factura_notaCredito.Text = 1 And tipo1 <> "PD" Then
                tipo = "FC"
            End If

            If Me.txt_factura_notaCredito.Text = 2 And tipo1 <> "PD" Then
                tipo = "NC"
            End If

            If Me.txt_factura_notaCredito.Text = 3 And tipo1 <> "PD" Then
                tipo = "ND"
            End If

            If Me.txt_remito.Text = 1 Then
                tipo = "RE"
            End If

            If Me.txt_remito.Text = 2 Then
                tipo = "RS"
            End If

            If Me.txt_tipo_fact.Text = "PD" Then
                tipo = "PD"
            End If

            muestra_tipo_pago = False

            'muestro el tipo de pago x si quiero cargar cheques y demas
            If band = True And fact.muestra_tipo_pago = "SI" And tipo <> "RE" And tipo <> "RS" And tipo <> "PD" And Trim(Me.cmb_forma_pago.Text) <> "Cta Cte" Then

                muestra_tipo_pago = True

                Form_tipo_pago.txt_num.Text = Me.txt_numero.Text
                Form_tipo_pago.txt_letra.Text = Me.txt_letra.Text
                Form_tipo_pago.txt_pre.Text = Me.txt_prefijo.Text
                Form_tipo_pago.txt_tipo.Text = Me.txt_tipo_fact.Text
                Form_tipo_pago.txt_fec_emi.Text = Me.dt_fec_emision.Text
                Form_tipo_pago.txt_p_venta.Text = Me.txt_prefijo.Text
                Form_tipo_pago.txt_talon.Text = Me.txt_talonario_pred.Text
                Form_tipo_pago.Show()

            Else

                If tipo = "FC" Or tipo = "NC" Then Call imprime_fiscal() ' imprime en controlador fiscal

            End If

            If muestra_tipo_pago = False Then

                If fact.sale_factura = 1 Then
                    Exit Sub
                End If

                If fact.muestra_tipo_pago = "NO" Or RTrim(Me.cmb_forma_pago.Text) = "Cta Cte" Then
                    Call imprime_y_cierra()
                End If

                If cta_cte = True Then
                    Call imprime_y_cierra()
                End If

                If RTrim(tipo1) = "PD" Then
                    Call imprime_y_cierra()
                End If

                If tipo = "RE" Or tipo = "RS" Then
                    Call imprime_y_cierra()
                End If

            End If

        End If

    End Sub

    Private Sub cmb_forma_pago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_forma_pago.KeyDown
        If e.KeyCode = Keys.Return Then

            If fact.Pide_lista = "SI" Then Me.txt_cod_lista.Enabled = True
            If Me.txt_remito.Text = 0 Then Call muestra_total()

            If Me.cmb_forma_pago.Text = "Contado" Then
                band = True
            Else
                band = False
                Me.dt_fec_vto.Text = Now.Date.AddDays(15)
            End If

            If Me.txt_n_carga.Enabled = True Then
                Me.txt_n_carga.Focus()
            Else
                Me.txt_codigo_producto.Focus()
            End If

        End If
    End Sub

    Public Sub muestra_total()

        If fact.muestra_marcador_total = "SI" Then

            'Me.lbl_Marcador_precio.BackColor = Color.White
            Me.lbl_forma_pago.Visible = False
            Me.lbl_vto.Visible = False
            Me.dt_fec_vto.Visible = False
            Me.cmb_forma_pago.Visible = False
            Me.dt_fec_emision.Visible = False
            Me.lbl_fec_emision.Visible = False
            Me.lbl_Marcador_precio.Text = "0.00"
            Me.lbl_importe.Visible = True
            'Me.lbl_importe.BackColor = Color.White
            Me.lbl_importe.Text = "IMPORTE:"
            Me.lbl_items.Visible = True
            'Me.lbl_items.BackColor = Color.White
            Me.lbl_items.Text = "ITEMS:"
            Me.lbl_cont.Visible = True
            'Me.lbl_cont.BackColor = Color.White
            Me.lbl_cont.Text = "0"

        End If

    End Sub

    Private Sub calcula_total()

        total = Format(total + Me.DataGridView1.Rows(z).Cells(4).Value, "0.00")

        If fact.muestra_marcador_total = "SI" Then Me.lbl_Marcador_precio.Text = total

        If fact.cantidad_automatica = "SI" Then
            y = y + 1
            cuenta_fila = cuenta_fila + 1
        End If

    End Sub

    Private Sub calcula_total_automatico()

        total = Format(total + Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 2).Cells(4).Value, "0.00")

        If fact.muestra_marcador_total = "SI" Then Me.lbl_Marcador_precio.Text = total

        If fact.cantidad_automatica = "SI" Or entra_ean13 = True Then
            y = y + 1
            cuenta_fila = cuenta_fila + 1
            z = z + 1
        End If

    End Sub

    Public Sub cargar_datos()

        If Me.lbl_uni_sec.Text = "SI" And (Me.txt_unidad_secundaria.Text = Nothing Or Val(Me.txt_unidad_secundaria.Text) = 0) Then
            Me.txt_unidad_secundaria.Focus()
            Me.txt_unidad_secundaria.SelectAll()
            Exit Sub
        End If

        Dim valor As Single = 0
        Dim cant As Double

        fact.sale = False

        Me.tipo1 = Me.txt_tipo_fact.Text

        If Me.txt_desc_rcgo.Text = "" Then
            Me.txt_desc_rcgo.Text = 0
        End If


        If verifica = False Then

            cant = Me.txt_cantidad.Text
            fact.precio_final = Me.txt_precioCiva.Text

            fact.unidad_medida = Me.lbl_uni_sec.Text
            fact.valor_unidad_medida = Me.txt_unidad_secundaria.Text
            fact.grilla = Me.DataGridView1
            fact.codigo_fact = Me.txt_codigo_producto.Text
            fact.nombre = Me.txt_nombre_producto.Text
            fact.cantidad = cant
            fact.desc_rcgo = Val(Me.txt_desc_rcgo.Text)
            fact.impuesto = Me.txt_imp_interno.Text * cant
            fact.iva = Trim(porcentaje_impuesto)
            fact.Codigo_iva = codigo_iva
            If fact.factura_en_c = "SI" Then fact.precio = Me.txt_neto1.Text
            If fact.factura_en_c = "NO" Then fact.precio = Me.txt_neto.Text
            fact.exento = Me.txt_exento1.Text
            fact.total = fact.total
            fact.precio_civa = Me.txt_precioCiva.Text
            fact.costo = Me.txt_precio_costo.Text
            fact.proveedor = Me.txt_id_proveedor.Text
            fact.rubro = Me.txt_id_rubro.Text

            If Me.txt_iva1.Text = 0 Then
                fact.exento = Me.txt_neto.Text
                fact.precio_civa = Me.txt_neto.Text
            End If

            If Me.tipo1 = "FC" Or Me.tipo1 = "NC" Or Me.txt_tipo_fact.Text = "PD" Then
                If fact.valida_rentabilidad = "SI" Then Call valida_rentabilidad()
            End If

            If fact.precio <= 0 Then
                MessageBox.Show("Verifique precio 0!!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If renta = True Then
                fact.cargar_factura()
            Else
                Exit Sub
                renta = True
            End If

            If fact.sale = True Then

                Me.txt_codigo_producto.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_stock.Text = ""
                Me.txt_cantidad.Text = ""
                Me.txt_desc_rcgo.Text = ""
                Me.txt_neto.Text = ""
                Me.txt_unidad_secundaria.Text = ""
                Me.txt_codigo_producto.Focus()
                Exit Sub

            End If

            cont = cont + 1
            Me.lbl_cont.Text = cont

            fila_actual = False

            Call modifica_stock()

            Call calcula_total()

            z = z + 1

        Else

            If Me.tipo1 = "FC" Or Me.tipo1 = "NC" Or Me.txt_tipo_fact.Text = "PD" Then
                If fact.valida_rentabilidad = "SI" Then Call valida_rentabilidad()
            End If

            If renta <> True Then
                Exit Sub
                renta = True
            End If

            j = i
            fact.unidad_medida = art.unidad_secundaria
            fact.valor_unidad_medida = Me.txt_unidad_secundaria.Text
            fact.modifica_grilla_factura = j
            fact.codigo_fact = Me.txt_codigo_producto.Text
            fact.nombre = Me.txt_nombre_producto.Text
            fact.cantidad = Me.txt_cantidad.Text
            fact.impuesto = Me.txt_imp_interno.Text * Me.txt_cantidad.Text
            fact.precio_final = Me.txt_precioCiva.Text
            fact.desc_rcgo = Me.txt_desc_rcgo.Text
            fact.iva = Trim(porcentaje_impuesto)
            fact.Codigo_iva = codigo_iva
            If fact.factura_en_c = "SI" Then fact.precio = Me.txt_neto1.Text
            If fact.factura_en_c = "NO" Then fact.precio = Me.txt_neto.Text
            fact.exento = Me.txt_exento1.Text
            fact.costo = Me.txt_precio_costo.Text
            fact.proveedor = art.proveedor
            fact.rubro = art.rubro

            If Me.txt_iva1.Text = 0 Then
                fact.exento = Me.txt_neto.Text
                fact.precio_civa = Me.txt_neto.Text
            End If

            Call modifica_stock()

            valor_anterior = Me.DataGridView1.Rows(j).Cells(4).Value

            fact.modifica_grilla()

            verifica = False

            If entra_en_grilla = False Then
                error_cantidad = False
            Else
                error_cantidad = True
            End If

            total = total + Me.DataGridView1.Rows(j).Cells(4).Value - valor_anterior
            Me.lbl_Marcador_precio.Text = Format(total, "0.00")
            Me.lbl_Marcador_precio.Text = Me.lbl_Marcador_precio.Text

        End If

        If RTrim(fact.mueve_stock) = "SI" And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
                trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
            End If

            If RTrim(Me.txt_mueve_stok.Text) = "SI" Then

                coman = New SqlCommand("update art_01 with(rowlock,xlock) set cantidad= '" & Me.txt_cantidad.Text & "' where id_art= '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
                coman.Transaction = trans
                coman.ExecuteNonQuery()

            Else

                coman = New SqlCommand("update art_01 with(rowlock,xlock) set cantidad= '0' where id_art= '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
                coman.Transaction = trans
                coman.ExecuteNonQuery()

            End If

            trans.Commit()
            conex.Close()

        End If

        Me.txt_cantidad.Text = Format(Me.txt_cantidad.Text + 0.0, "0.00")

        Call limpia()
        Me.txt_cantidad.ReadOnly = True
        Me.txt_desc_rcgo.ReadOnly = True

    End Sub

    Private Sub form_factura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Form_comentario.Close()
        Form_pendiente.Close()

        If Me.txt_cierra_form.Text = 2 Then

            e.Cancel = True
            busc_cliente.TopMost = True
            busc_articulos.TopMost = True

        Else

            If sale = True Then

                'If conex.State = ConnectionState.Closed Then
                'conex = conecta()
                'conex.Open()
                'End If

                'coman = New SqlCommand("update art_01 set cantidad= cant_ant where cantidad = cant_ant", conex)
                'coman.ExecuteNonQuery()
                'coman.Dispose()

                'coman = New SqlCommand("update art_01 set cant_ant = cantidad where cantidad <> cant_ant", conex)
                'coman.ExecuteNonQuery()
                'coman.Dispose()

                sale = False

                'If conex.State = ConnectionState.Open Then
                'conex.Close()
                'End If

                Call guarda_factura()

                Call borra_tabla_art_act(nom_computadora)

                If Me.txt_factura_notaCredito.Text = 1 Or tipo1 = "PD" Then
                    abre = 1
                    Form_tipo_pago.txt_abre.Text = 1
                End If

            Else

                If Me.txt_factura_notaCredito.Text = 1 Or tipo1 = "PD" Then
                    abre = 0
                    Form_tipo_pago.txt_abre.Text = 0
                End If

                Form_login.txt_tipoo.Text = 0

                conex.Close()

                Form_tipo_pago.Dispose()

                'If existe_num = False Then   ' verifico que no se borre si el problema es el numerador solamnete

                'art.instruccion = "DELETE fact_cab WHERE num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and letra_fact = '" & RTrim(Me.txt_letra.Text) & "' and prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact = '" & RTrim(Me.txt_tipo_fact.Text) & "' and talon = '" & Me.txt_talonario_pred.Text & "'"
                'art.actualizar()

                'art.instruccion = "DELETE fact_det WHERE num_fact = '" & RTrim(Me.txt_numero.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo_fact.Text) & "' and talon1 = '" & Me.txt_talonario_pred.Text & "'"
                'art.actualizar()

                'art.instruccion = "DELETE fact_tot WHERE num_factura = '" & RTrim(Me.txt_numero.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and pref = '" & RTrim(Me.txt_prefijo.Text) & "' and tipo_factura = '" & RTrim(Me.txt_tipo_fact.Text) & "' and talon2 = '" & Me.txt_talonario_pred.Text & "'"
                'art.actualizar()

                'art.instruccion = "DELETE cta_cte01 WHERE num_fact = '" & RTrim(Me.txt_numero.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "'"
                'art.actualizar()

                'art.instruccion = "DELETE cta_cte_hist WHERE num = '" & RTrim(Me.txt_numero.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "'"
                'art.actualizar()

                'art.instruccion = "DELETE ped_det WHERE num = '" & RTrim(Me.txt_numero.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "'"
                'art.actualizar()

                'End If

                Form_login.act_stk(nom_computadora)

            End If

        End If

        If Me.txt_tipo_fact.Text = "RS" Or Me.txt_tipo_fact.Text = "RE" Or Me.txt_tipo_fact.Text = "NC" Or Me.txt_tipo_fact.Text = "ND" Then
            barra_carga.Timer1.Enabled = True
        End If

        If conex.State = ConnectionState.Open Then
            conex.Close()
        End If

    End Sub

    Public Sub imprimir(ByVal num As Integer)

        If RTrim(Me.txt_tipo_fact.Text) = "PD" Then

            If pedido = 6 Then

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                coman = New SqlCommand("update fact_det set asterisco = '*' where num_fact = '" & RTrim(num) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo_fact.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and talon1 = '" & RTrim(Me.txt_talonario_pred.Text) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                If conex.State = ConnectionState.Open Then
                    conex.Close()
                End If

                fact.form_txt_letra = Me.txt_letra.Text
                fact.numero_factura = tal.numerador - 1
                fact.letra_fact = Me.txt_letra.Text
                fact.prefijo_factura = Me.txt_prefijo.Text
                fact.tipo_fact = Me.txt_tipo_fact.Text
                fact.cantidad_sin_stock = "NO"
                fact.imprimir_pedido()

            End If

        End If

        If RTrim(Me.txt_tipo_fact.Text) <> "PD" Then

            ' imprime en fiscal ticketera epson tm 220 y si esta habilitado para que me muestre la ventana de
            ' dialogo pedido debe estar en 6 para que imprima

            If RTrim(fact.fiscal_epson) = "SI" And pedido = 6 And RTrim(fact.Imprime_en_fiscal = "NO") Then

                If RTrim(fact.imprime_tikets) = "SI" Then

                    fact.imprimir_factura(tal.numerador - 1, Me.txt_letra.Text, Me.txt_prefijo.Text, Me.txt_tipo_fact.Text, Me.txt_talonario_pred.Text, fact.form_txt, Me.txt_iva_solo.Text)
                    Exit Sub

                End If

            End If

        End If

        ' salgo para no entrar aca abajo sino hace lios

        If fact.habilita_impresora_factura = "SI" And Me.txt_talonario_pred.Text <> 1 And pedido = 6 Then

            If tipo1 <> "PD" And Me.txt_remito.Text <> 1 And Me.txt_remito.Text <> 2 Then

                'If fact.muestra_cuadro_impresion = "SI" Then

                'reporte.carga_formato_factura(Me.txt_letra.Text)

                'reporte.formato.RecordSelectionFormula = "{fact_det.num_fact}= " & Me.txt_numero.Text & " and {fact_det.letra_fact1} = '" & Me.txt_letra.Text & "' and {fact_det.prefijo_fact2} = " & Me.txt_prefijo.Text & " and {fact_det.tipo_fact2}= '" & Me.txt_tipo_fact.Text & "' and {fact_det.talon1} = " & Me.txt_talonario_pred.Text & ""

                'If Me.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                'reporte.formato.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                'reporte.formato.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                'reporte.formato.PrinterSettings = PrintDialog1.PrinterSettings
                'reporte.formato.PrintToPrinter(Me.PrintDialog1.PrinterSettings.Copies, Me.PrintDialog1.PrinterSettings.Collate, Me.PrintDialog1.PrinterSettings.FromPage, Me.PrintDialog1.PrinterSettings.ToPage)

                'Form_repfact.CrystalReportViewer1.ReportSource = reporte.formato
                'Form_repfact.CrystalReportViewer1.RefreshReport()
                'Form_repfact.Show()

                'Exit Sub

                'End If

                'Else

                fact.form_txt_letra = Me.txt_letra.Text
                fact.form_txt = Me.txt_form.Text
                fact.imprimir_factura(Me.txt_numero.Text, Me.txt_letra.Text, Me.txt_prefijo.Text, Me.txt_tipo_fact.Text, Me.txt_talonario_pred.Text, fact.form_txt, Me.txt_iva_solo.Text)


                'End If

            End If

        End If

        ' esta opcion es nueva se agrego para marina etrat cuando muestra dialogo imprime y factura en afip
        If fact.habilita_impresora_factura = "SI" And Me.txt_talonario_pred.Text = 1 And fact.ventana_imprime_factura = "SI" And fact.Imprime_en_fiscal = "NO" And fact.Factura_electronica_AFIP = "SI" And pedido = 6 Then

            fact.form_txt_letra = Me.txt_letra.Text
            fact.form_txt = Me.txt_form.Text
            fact.imprimir_factura(Me.txt_numero.Text, Me.txt_letra.Text, Me.txt_prefijo.Text, Me.txt_tipo_fact.Text, Me.txt_talonario_pred.Text, fact.form_txt, Me.txt_iva_solo.Text)

        End If

        ' esta opcion es igula que la anterior solo que muestra dialogo esta en NO y factura en afip SI
        If fact.habilita_impresora_factura = "SI" And Me.txt_talonario_pred.Text = 1 And fact.ventana_imprime_factura = "NO" And fact.Imprime_en_fiscal = "NO" And fact.Factura_electronica_AFIP = "SI" And pedido = 6 Then

            fact.form_txt_letra = Me.txt_letra.Text
            fact.form_txt = Me.txt_form.Text
            fact.imprimir_factura(Me.txt_numero.Text, Me.txt_letra.Text, Me.txt_prefijo.Text, Me.txt_tipo_fact.Text, Me.txt_talonario_pred.Text, fact.form_txt, Me.txt_iva_solo.Text)

        End If

        If fact.habilita_impresion_remito = "SI" And pedido = 6 Then

            If Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2 Then

                fact.form_txt_letra = Me.txt_letra.Text
                fact.form_txt = Me.txt_form.Text
                fact.numero_factura = Me.txt_numero.Text
                fact.letra_fact = Me.txt_letra.Text
                fact.tipo_fact = Me.txt_tipo_fact.Text
                fact.imprimir_remito()

            End If
        End If

    End Sub

    Private Sub txt_numero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus

        Dim z As String = ""

        If RTrim(Me.txt_tipo_fact.Text) = "FC" Then z = "FC"
        If RTrim(Me.txt_tipo_fact.Text) = "NC" Then z = "NC"
        If RTrim(Me.txt_tipo_fact.Text) = "ND" Then z = "ND"

        If fact.sale = True Then
            Me.txt_numero.Focus()
        Else
            Me.txt_prefijo.Enabled = False
            Me.txt_numero.Enabled = False
        End If

    End Sub

    Public Sub habilita_numeradores()

        Dim i As Integer = 0

        If fact.prefijo_factura = "SI" Then
            Me.txt_prefijo.Enabled = True
            Me.txt_prefijo.Focus()
            i = 1
        Else
            Me.txt_prefijo.Enabled = False
        End If

        If fact.numero_factura = "SI" Then
            Me.txt_numero.Enabled = True
            If i = 0 Then
                Me.txt_numero.Focus()
                i = 1
            End If
        Else
            Me.txt_numero.Enabled = False
        End If

        If fact.muestra_fecha_emi = "SI" Then
            Me.dt_fec_emision.Enabled = True
            If i = 0 Then
                Me.dt_fec_emision.Focus()
                i = 1
            End If
        Else
            Me.dt_fec_emision.Enabled = False
        End If

        If fact.muestra_fecha_vto = "SI" Then
            Me.dt_fec_vto.Enabled = True
            If i = 0 Then
                Me.dt_fec_vto.Focus()
                i = 1
            End If
        Else
            Me.dt_fec_vto.Enabled = False
        End If

        If fact.forma_cobro = "SI" And tipo1 <> "PD" Then
            Me.cmb_forma_pago.Enabled = True
            If i = 0 Then
                Me.cmb_forma_pago.Focus()
                Me.lbl_forma_pago.BackColor = Color.Red
                i = 1
            End If
        Else
            Me.cmb_forma_pago.Enabled = False
        End If

        If fact.pide_n_carga = "SI" Then
            Me.lbl_n_carga.Visible = True
            Me.txt_n_carga.Visible = True
            Me.txt_n_carga.Enabled = True
            If i = 0 Then
                Me.txt_n_carga.Focus()
                i = 1
            End If
        Else
            Me.lbl_n_carga.Visible = False
            Me.txt_n_carga.Visible = False
            Me.txt_n_carga.Enabled = False
        End If

        If fact.habilita_vendedor = "SI" Then
            Me.txt_vendedor.Enabled = True
            If i = 0 Then
                Me.txt_vendedor.Focus()
                i = 1
            End If
        Else
            Me.txt_vendedor.Enabled = False
            If fact.forma_cobro = "NO" And Me.txt_cod_lista.Enabled = True Then Me.txt_cod_lista.Focus()
            Me.txt_codigo_producto.Focus()
            If fact.forma_cobro = "SI" Then
                Me.cmb_forma_pago.Focus()
            Else
                Me.txt_codigo_producto.Enabled = True
            End If
        End If

        If fact.Pide_lista = "SI" Then
            Me.txt_cod_lista.Enabled = True
            If i = 0 Then
                Me.txt_cod_lista.Focus()
                Me.txt_codigo_producto.Enabled = True
                i = 1
            End If
        Else
            Me.txt_cod_lista.Enabled = False
            If fact.forma_cobro = "SI" Then
                Me.cmb_forma_pago.Focus()
                Me.txt_codigo_producto.Enabled = True
            End If
            If fact.forma_cobro = "NO" And fact.Pide_lista = "NO" And fact.habilita_vendedor = "NO" Then
                Me.txt_codigo_producto.Enabled = True
                Me.txt_codigo_producto.Focus()
            End If
            If fact.forma_cobro = "NO" And fact.Pide_lista = "NO" And fact.habilita_vendedor = "SI" Then
                Me.txt_codigo_producto.Enabled = True
            End If
            If fact.pide_n_carga = "SI" Then
                Me.txt_n_carga.Focus()
                total_01 = True
            End If
        End If

        If Me.cmb_forma_pago.Enabled = False And Me.txt_vendedor.Enabled = False And Me.txt_cod_lista.Enabled = False And Me.txt_n_carga.Enabled = False And Me.txt_tipo_fact.Text = "PD" Then
            Me.txt_codigo_producto.Enabled = True
            Me.txt_codigo_producto.Focus()
        End If

    End Sub

    Public Sub valida_rentabilidad()

        Dim precio_1, sub_t, tot, final As Single
        Dim valida As Boolean = True

        precio_1 = Val((Me.txt_neto.Text * (-Val(Me.txt_desc_rcgo.Text)))) / 100
        sub_t = Val(Me.txt_neto.Text) - precio_1

        tot = sub_t / Me.txt_precio_costo.Text

        tot = tot * 100
        final = tot - 100
        final = Format(final, "0.00")

        If fact.valida_rentabilidad = "SI" Then

            If Val(final) <= Val(fact.importe_rentabilidad) Then

                MessageBox.Show("Verifique Rentabilidad: " & " " & final, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                renta = False
                valida = False
            Else
                renta = True

            End If

        End If

    End Sub

    Public Sub habilita_desc()

        If fact.habilita_descuento = "SI" Then
            Me.txt_desc_rcgo.Visible = True
            Me.lbl_des_rcgo.Visible = True
        Else
            Me.txt_desc_rcgo.Visible = False
            Me.lbl_des_rcgo.Visible = False
        End If

    End Sub


    Public Sub limpia()

        Me.txt_codigo_producto.Text = ""
        Me.txt_cantidad.Text = ""
        Me.txt_desc_rcgo.Text = ""
        Me.txt_nombre_producto.Text = ""
        Me.txt_unidad_secundaria.Text = ""
        Me.lbl_unidad_secundaria.Visible = False
        Me.txt_unidad_secundaria.Visible = False
        Me.txt_codigo_producto.Focus()

    End Sub

    Private Sub cantidad_automatica_si()

        'cambio echo para prego 17/08/2016
        If art.codigo_barra = "" Then
            Me.txt_cantidad.Focus()
            Me.txt_cantidad.SelectAll()
            Exit Sub
        End If

        If fact.mueve_stock = "NO" Then
            Me.txt_mueve_stok.Text = "NO"
        End If

        If (Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI") Then

            If Val(Me.txt_stock.Text) = 0 Or Val(Me.txt_stock.Text) < Val(Me.txt_cantidad.Text) Then

                MessageBox.Show("Stock Insuficiente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txt_codigo_producto.Focus()
                Me.txt_cantidad.Text = ""
                Me.txt_neto.Text = ""
                Me.txt_codigo_producto.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""

                If error_cantidad = False Then

                    i = Me.DataGridView1.CurrentCell.RowIndex

                    total = total - Me.DataGridView1.Rows(i - 1).Cells(4).Value
                    Me.lbl_Marcador_precio.Text = Format(total, "0.00")
                    Me.lbl_Marcador_precio.Text = Me.lbl_Marcador_precio.Text
                    x = x - 1

                    Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i - 1))
                    verifica = False
                    fact.fila = fact.fila - 1

                    error_cantidad = True

                    cont = cont - 1
                    Me.lbl_cont.Text = cont

                End If

                Exit Sub

            End If

        End If

        cant = Me.txt_cantidad.Text
        fact.precio_final = Me.txt_precioCiva.Text

        fact.unidad_medida = "NO"
        fact.grilla = Me.DataGridView1
        fact.codigo_fact = Me.txt_codigo_producto.Text
        fact.nombre = Me.txt_nombre_producto.Text
        fact.cantidad = cant
        fact.desc_rcgo = Val(Me.txt_desc_rcgo.Text)
        fact.impuesto = Me.txt_imp_interno.Text * cant
        fact.iva = Trim(porcentaje_impuesto)
        fact.Codigo_iva = codigo_iva
        fact.precio = Me.txt_neto.Text
        fact.exento = Me.txt_exento1.Text
        fact.total = fact.total
        fact.precio_civa = Me.txt_precioCiva.Text
        fact.costo = Me.txt_precio_costo.Text

        If Me.tipo1 = "FC" Or Me.tipo1 = "NC" Then Call valida_rentabilidad()

        If fact.cantidad_automatica = "SI" Then Me.txt_desc_rcgo.Text = "0.00"

        If fact.pide_precio = "SI" And fact.Actualiza_precio_en_factura = "SI" Then
            Me.txt_neto.Text = fact.precio_civa
            Me.txt_neto.Focus()
            Me.txt_neto.SelectAll()
            cod_barra = False
            Exit Sub
        End If

        If renta = True Then
            fact.cargar_factura()
            If fact.sale = True Then Exit Sub
        Else
            Exit Sub
            renta = True
        End If

        If fact.mueve_stock = "SI" Then
            Call falla_stk(Me.txt_codigo_producto.Text, Me.txt_nombre_producto.Text, nom_computadora, Me.txt_cantidad.Text, Me.txt_tipo_fact.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_letra.Text, Me.txt_talonario_pred.Text, Me.DataGridView1.Rows.Count - 1)
        End If

        If cuenta_fila <= fact.cantidad_item_factura Then
            cont = cont + 1
            Me.lbl_cont.Text = cont
        End If

        ' si es remito pasa x aca 
        If (Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2) Then
            If fact.cantidad_automatica = "SI" Then Call calcula_total_automatico()
        Else
            ' esto sta puestopor el remito cuando se pasa codigobarra... VERRR
            If fact.pide_precio = "NO" And fact.habilita_descuento = "NO" And cuenta_fila <= fact.cantidad_item_factura Then Call calcula_total_automatico()
        End If

        'If fact.cantidad_automatica = "SI" And entra_ean13 = False Then Call calcula_total_automatico()

        'If entra_ean13 = True Then Call calcula_total_automatico()

        If fact.sale = True Then

            Me.txt_codigo_producto.Text = ""
            Me.txt_nombre_producto.Text = ""
            Me.txt_stock.Text = ""
            Me.txt_cantidad.Text = ""
            Me.txt_desc_rcgo.Text = ""
            Me.txt_neto.Text = ""
            Me.txt_codigo_producto.Focus()
            fact.sale = False
            Exit Sub

        End If

        If Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Then

            art.cantidad = Format(Val(Me.txt_cantidad.Text), "0.00")
            art.stok = Format(Val(Me.txt_stock.Text), "0.00")
            Me.txt_cantidad.Text = art.stok - art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO" Or Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO" Then

            Me.txt_cantidad.Text = art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Then

            art.cantidad = Format(Val(Me.txt_cantidad.Text), "0.00")
            art.stok = Format(Val(Me.txt_stock.Text), "0.00")
            Me.txt_cantidad.Text = art.stok + art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO" Or Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO" Then

            Me.txt_cantidad.Text = art.cantidad

        End If

        If Me.tipo1 <> "PD" Then

            art.instruccion = "update art_01 set cantidad= '" & Me.txt_cantidad.Text & "' where id_art= '" & Me.txt_codigo_producto.Text & "'"
            art.actualizar()

        End If

        Me.txt_codigo_producto.Focus()
        Me.txt_cantidad.Text = ""
        Me.txt_neto.Text = ""
        Me.txt_codigo_producto.Text = ""
        Me.txt_nombre_producto.Text = ""
        Me.txt_stock.Text = ""
        Me.lbl_bulto.Text = ""

    End Sub

    Public Sub carga_codigo()

        If Me.txt_codigo_producto.Text = "" Then Exit Sub

        Me.txt_cantidad.ReadOnly = False
        Me.txt_desc_rcgo.ReadOnly = False

        Me.txt_codigo_producto.SelectAll()

        art.codigo_1 = "id_art1"
        art.codigo_2 = "nombre"
        art.codigo_3 = "precio_siva"
        art.codigo_4 = "cantidad"
        art.codigo_5 = "cantidad_bulto"
        art.codigo_6 = "mueve_stok"
        art.codigo_7 = "precio_civa"
        art.codigo_8 = "iva_insc"
        art.codigo_9 = "impuestos"
        art.codigo_10 = "iva"
        art.codigo_11 = "exento"
        art.codigo_12 = "costo"
        art.codigo_13 = "codigo_barra"
        art.codigo_14 = "id_iva"
        art.codigo_15 = "utilidad"
        art.codigo_16 = "id_proveedor"
        art.codigo_17 = "id_rubro"
        art.codigo_18 = "unidad_secundaria"
        art.codigo_19 = "peso_promedio"
        art.codigo_20 = "bonif_vta"

        art.cargar()

        If art.valida = True Then

            'If Me.txt_tipo_fact.Text = "PD" Then
            'Dim c As Integer

            'For c = 0 To Me.DataGridView1.Rows.Count - 1
            'If RTrim(Me.DataGridView1.Rows(c).Cells(0).Value) = art.codigo Then
            'MessageBox.Show("Ya existe un articulo igual", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Exit Sub
            'End If
            'Next

            'End If

            Me.txt_codigo_producto.Text = art.codigo
            Me.txt_nombre_producto.Text = art.nombre

            If fact.factura_en_c = "NO" Then
                Me.txt_neto.Text = art.precio_siva
            Else
                Me.txt_neto.Text = art.precio_civa
                Me.txt_neto1.Text = art.precio_civa
            End If

            If Me.txt_tipo_fact.Text = "RE" Or Me.txt_tipo_fact.Text = "RS" Then
                If fact.muestra_costo_remito = "SI" Then Me.txt_neto.Text = art.costo
            End If

            Me.lbl_uni_sec.Text = art.unidad_secundaria
            Me.txt_unidad_secundaria.Text = art.peso_promedio
            Me.txt_stock.Text = art.cantidad
            Me.lbl_bulto.Text = art.cantidad_bulto
            Me.txt_mueve_stok.Text = art.mueve_stok
            Me.txt_precioCiva.Text = art.precio_civa
            Me.txt_iva_ins.Text = art.iva_insc
            Me.txt_imp_interno.Text = art.impuestos_internos
            Me.txt_iva1.Text = art.iva
            Me.txt_exento1.Text = art.exento
            Me.txt_precio_costo.Text = art.costo
            Me.txt_utilidad.Text = art.uilidad
            Me.txt_cod_iva.Text = art.codigo_iva
            Me.txt_id_proveedor.Text = art.proveedor
            Me.txt_id_rubro.Text = art.rubro
            valor_total = Len(art.codigo_barra)

            If Trim(Me.lbl_uni_sec.Text) = "SI" Then
                Me.lbl_unidad_secundaria.Visible = True
                Me.txt_unidad_secundaria.Visible = True
                Me.txt_unidad_secundaria.ReadOnly = False
                Me.txt_unidad_secundaria.Focus()
            Else
                Me.lbl_unidad_secundaria.Visible = False
                Me.txt_unidad_secundaria.Visible = False
                Me.txt_cantidad.Enabled = True
                Me.txt_cantidad.Focus()
            End If

            Call selecciona_valor_impuesto(Me.txt_cod_iva.Text)

            If RTrim(art.mueve_stok) = "NO" Then
                Me.txt_stock.Text = ""
                'Me.lbl_bulto.Text = ""
            End If

            If fact.cantidad_automatica = "SI" Then
                Me.txt_cantidad.Text = Val(cant_var)
                cantidad_automatica_si()
                cant_var = 1
            End If

        Else

            Me.txt_stock.Text = ""

        End If

    End Sub

    Public Sub carga_codigo_automatico()

        ' factura sin pedir cantidad

        If Me.txt_codigo_producto.Text = "" Then Exit Sub

        Me.txt_codigo_producto.SelectAll()

        art.codigo_1 = "id_art1"
        art.codigo_2 = "nombre"
        art.codigo_3 = "precio_siva"
        art.codigo_4 = "cantidad"
        art.codigo_5 = "cantidad_bulto"
        art.codigo_6 = "mueve_stok"
        art.codigo_7 = "precio_civa"
        art.codigo_8 = "iva_insc"
        art.codigo_9 = "impuestos"
        art.codigo_10 = "iva"
        art.codigo_11 = "exento"
        art.codigo_12 = "costo"
        art.codigo_13 = "codigo_barra"
        art.codigo_14 = "id_iva"
        art.codigo_15 = "utilidad"
        art.codigo_16 = "id_proveedor"
        art.codigo_17 = "id_rubro"
        art.codigo_18 = "unidad_secundaria"
        art.codigo_19 = "peso_promedio"
        art.codigo_20 = "bonif_vta"

        art.cargar()

        If art.valida = True Then

            Me.txt_codigo_producto.Text = art.codigo
            Me.txt_nombre_producto.Text = art.nombre

            If fact.factura_en_c = "NO" Then
                Me.txt_neto.Text = art.precio_siva
            Else
                Me.txt_neto.Text = art.precio_civa
                Me.txt_neto1.Text = art.precio_siva
            End If

            Me.lbl_uni_sec.Text = art.unidad_secundaria
            Me.txt_unidad_secundaria.Text = art.peso_promedio
            Me.txt_stock.Text = art.cantidad
            Me.lbl_bulto.Text = art.cantidad_bulto
            Me.txt_mueve_stok.Text = art.mueve_stok
            Me.txt_precioCiva.Text = art.precio_civa
            Me.txt_iva_ins.Text = art.iva_insc
            Me.txt_imp_interno.Text = art.impuestos_internos
            Me.txt_iva1.Text = art.iva
            Me.txt_exento1.Text = art.exento
            Me.txt_precio_costo.Text = art.costo
            Me.txt_utilidad.Text = art.uilidad
            Me.txt_cod_iva.Text = art.codigo_iva
            valor_total = Len(art.codigo_barra)
            Me.txt_cantidad.Text = Val(cant_var)

            Call selecciona_valor_impuesto(Me.txt_cod_iva.Text)

            If RTrim(art.mueve_stok) = "NO" Then
                Me.txt_stock.Text = ""
                'Me.lbl_bulto.Text = ""
            End If

        Else

            Me.txt_stock.Text = ""
            Exit Sub

        End If

        If fact.mueve_stock = "NO" Then
            Me.txt_mueve_stok.Text = "NO"
        End If

        If (Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI") Then

            If Val(Me.txt_stock.Text) = 0 Or Val(Me.txt_stock.Text) < Val(Me.txt_cantidad.Text) Then

                MessageBox.Show("Stock Insuficiente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txt_codigo_producto.Focus()
                Me.txt_cantidad.Text = ""
                Me.txt_neto.Text = ""
                Me.txt_codigo_producto.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_stock.Text = ""
                Me.lbl_bulto.Text = ""

                If error_cantidad = False Then

                    i = Me.DataGridView1.CurrentCell.RowIndex

                    total = total - Me.DataGridView1.Rows(i - 1).Cells(4).Value
                    Me.lbl_Marcador_precio.Text = Format(total, "0.00")
                    Me.lbl_Marcador_precio.Text = Me.lbl_Marcador_precio.Text
                    x = x - 1

                    Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i - 1))
                    verifica = False
                    fact.fila = fact.fila - 1

                    error_cantidad = True

                    cont = cont - 1
                    Me.lbl_cont.Text = cont

                End If

                Exit Sub

            End If

        End If

        cant = Me.txt_cantidad.Text
        fact.precio_final = Me.txt_precioCiva.Text

        fact.unidad_medida = Me.lbl_uni_sec.Text
        fact.grilla = Me.DataGridView1
        fact.codigo_fact = Me.txt_codigo_producto.Text
        fact.nombre = Me.txt_nombre_producto.Text
        fact.cantidad = cant
        fact.desc_rcgo = Val(Me.txt_desc_rcgo.Text)
        fact.impuesto = Me.txt_imp_interno.Text * cant
        fact.iva = Trim(porcentaje_impuesto)
        fact.Codigo_iva = codigo_iva
        fact.precio = Me.txt_neto.Text
        fact.exento = Me.txt_exento1.Text
        fact.total = fact.total
        fact.precio_civa = Me.txt_precioCiva.Text
        fact.costo = Me.txt_precio_costo.Text

        If Me.tipo1 = "FC" Or Me.tipo1 = "NC" Then Call valida_rentabilidad()

        If fact.cantidad_automatica = "SI" Then Me.txt_desc_rcgo.Text = "0.00"

        If fact.pide_precio = "SI" And fact.Actualiza_precio_en_factura = "SI" Then
            Me.txt_neto.Text = fact.precio_civa
            Me.txt_neto.Focus()
            Me.txt_neto.SelectAll()
            cod_barra = False
            Exit Sub
        End If

        If renta = True Then
            fact.cargar_factura()
            If fact.sale = True Then Exit Sub
        Else
            Exit Sub
            renta = True
        End If

        If fact.mueve_stock = "SI" Then
            Call falla_stk(Me.txt_codigo_producto.Text, Me.txt_nombre_producto.Text, nom_computadora, Me.txt_cantidad.Text, Me.txt_tipo_fact.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_letra.Text, Me.txt_talonario_pred.Text, Me.DataGridView1.Rows.Count - 1)
        End If

        If cuenta_fila <= fact.cantidad_item_factura Then
            cont = cont + 1
            Me.lbl_cont.Text = cont
        End If

        'If fact.pide_precio = "NO" And fact.habilita_descuento = "NO" And cuenta_fila <= fact.cantidad_item_factura Then Call calcula_total_automatico()
        'If (Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2) And fact.cantidad_automatica = "SI" Then Call calcula_total_automatico()
        'If fact.cantidad_automatica = "SI" And entra_ean13 = False Then Call calcula_total_automatico()
        ' si es remito pasa x aca 

        lee_cod_aut_1_vez = 1 = 0

        If (Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2) Then
            If fact.cantidad_automatica = "SI" Then Call calcula_total_automatico()
        Else
            ' esto sta puestopor el remito cuando se pasa codigobarra... VERRR
            If fact.pide_precio = "NO" And fact.habilita_descuento = "NO" And cuenta_fila <= fact.cantidad_item_factura Then
                Call calcula_total_automatico()
                lee_cod_aut_1_vez = 1
            End If
        End If

        If entra_ean13 = True And lee_cod_aut_1_vez = 0 Then Call calcula_total_automatico()

        If fact.sale = True Then

            Me.txt_codigo_producto.Text = ""
            Me.txt_nombre_producto.Text = ""
            Me.txt_stock.Text = ""
            Me.txt_cantidad.Text = ""
            Me.txt_desc_rcgo.Text = ""
            Me.txt_neto.Text = ""
            Me.txt_codigo_producto.Focus()
            fact.sale = False
            Exit Sub

        End If

        If Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Then

            art.cantidad = Format(Val(Me.txt_cantidad.Text), "0.00")
            art.stok = Format(Val(Me.txt_stock.Text), "0.00")
            Me.txt_cantidad.Text = art.stok - art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO" Or Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO" Then

            Me.txt_cantidad.Text = art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI" Or Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI" Then

            art.cantidad = Format(Val(Me.txt_cantidad.Text), "0.00")
            art.stok = Format(Val(Me.txt_stock.Text), "0.00")
            Me.txt_cantidad.Text = art.stok + art.cantidad

        End If

        If Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO" Or Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO" Then

            Me.txt_cantidad.Text = art.cantidad

        End If

        If Me.tipo1 <> "PD" Then

            art.instruccion = "update art_01 set cantidad= '" & Me.txt_cantidad.Text & "' where id_art= '" & Me.txt_codigo_producto.Text & "'"
            art.actualizar()

        End If

        Me.txt_codigo_producto.Focus()
        Me.txt_cantidad.Text = ""
        Me.txt_neto.Text = ""
        Me.txt_codigo_producto.Text = ""
        Me.txt_nombre_producto.Text = ""
        Me.txt_stock.Text = ""
        Me.lbl_bulto.Text = ""
        cant_var = 1

    End Sub

    Private Sub carga_codigo_barra()

        art.codigo_1 = "id_art1"
        art.codigo_2 = "nombre"
        art.codigo_3 = "precio_siva"
        art.codigo_4 = "cantidad"
        art.codigo_5 = "cantidad_bulto"
        art.codigo_6 = "mueve_stok"
        art.codigo_7 = "precio_civa"
        art.codigo_8 = "iva_insc"
        art.codigo_9 = "impuestos"
        art.codigo_10 = "iva"
        art.codigo_11 = "exento"
        art.codigo_12 = "costo"
        art.codigo_13 = "codigo_barra"
        art.codigo_14 = "id_iva"
        art.codigo_15 = "utilidad"
        art.codigo_16 = "id_proveedor"
        art.codigo_17 = "id_rubro"
        art.codigo_18 = "unidad_secundaria"
        art.codigo_19 = "peso_promedio"
        art.codigo_20 = "bonif_vta"

        art.cargar()

        If art.valida = True Then

            codigo_bar = art.codigo_barra

        Else

            Me.txt_stock.Text = ""

        End If
    End Sub

    Private Sub txt_codigo_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyUp

        Try

            'If no_entrar = False Then

            If e.KeyCode = Keys.Return Then

                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and codigo_barra like '" & RTrim(Me.txt_codigo_producto.Text) & "' and art_01.estado ='Activo'"
                Call carga_codigo_barra()

                'If fact.cantidad_automatica = "NO" Then

                lee_enter = True

                If Me.txt_codigo_producto.Text.Length > 0 Then

                    If RTrim(Me.txt_codigo_producto.Text.Substring(0, 1)) = 2 Then
                        entra_ean13 = True
                        Call lee_codigo_ean13_balanza()
                    Else

                        If Trim(Me.txt_codigo_producto.Text) = Trim(codigo_bar) Then
                            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and codigo_barra like '" & RTrim(Me.txt_codigo_producto.Text) & "' and art_01.estado ='Activo'"
                            Call carga_codigo()
                            If fact.pide_precio = "SI" And fact.Actualiza_precio_en_factura = "SI" Then
                                cod_barra = False
                            Else
                                cod_barra = True
                            End If
                            entra_ean13 = False
                        End If

                    End If

                End If

            End If

            no_entrar = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lee_codigo_producto_automatico(ByVal cod As String)

        art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and codigo_barra like '" & RTrim(cod) & "' and art_01.estado='Activo'"
        Call carga_codigo_automatico()

    End Sub

    Private Sub lee_codigo_ean13_balanza()

        If RTrim(Me.txt_codigo_producto.Text.Length) = 13 Then

            precio_codbar = RTrim(Me.txt_codigo_producto.Text.ToString.Substring(6, 7))
            nom_codbar = Me.txt_codigo_producto.Text.ToString.Substring(0, 6)

            For i = 0 To precio_codbar.Length - 2
                If precio_codbar.ToString.Substring(i, 1) = 0 Then
                    coma = coma + 1
                Else
                    If precio_codbar.ToString.Substring(i, 1) <> 0 Then Exit For
                End If
            Next

            ' este es para importes de 1000 a 9999
            If coma = 0 Then
                precio_codbar = precio_codbar.ToString.Substring(0, 6)
                precio_codbar = precio_codbar.ToString.Substring(0, 4) & "." & precio_codbar.ToString.Substring(4, 2)
            End If

            ' este es para importes de 100 a 999
            If coma = 1 Then
                precio_codbar = precio_codbar.ToString.Substring(1, 5)
                precio_codbar = precio_codbar.ToString.Substring(0, 3) & "." & precio_codbar.ToString.Substring(3, 2)
            End If

            ' este es para importe de 10 a 99
            If coma = 2 Then
                precio_codbar = precio_codbar.ToString.Substring(2, 4)
                precio_codbar = precio_codbar.ToString.Substring(0, 2) & "." & precio_codbar.ToString.Substring(2, 2)
            End If

            ' este es para importe de 1 a 9
            If coma = 3 Then
                precio_codbar = precio_codbar.ToString.Substring(3, 3)
                precio_codbar = precio_codbar.ToString.Substring(0, 1) & "." & precio_codbar.ToString.Substring(1, 2)
            End If

            coma = 0
            cant_var = precio_codbar

            If coma > 2 Then
                Me.txt_codigo_producto.SelectAll()
                Exit Sub
            End If

            Call lee_codigo_producto_automatico(nom_codbar)

        End If

    End Sub

    Private Sub txt_vendedor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        If Me.txt_vendedor.Text = "" Then
            e.Cancel = False
            Me.txt_vendedor.Focus()
        Else
            Me.txt_codigo_producto.Enabled = True
            Me.txt_codigo_producto.Focus()
            Me.txt_vendedor.Enabled = False
        End If

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

    Public Sub imprime_y_cierra()

        sale = True

        If RTrim(Me.txt_tipo_fact.Text) = "FC" Then Form_login.txt_tipoo.Text = Me.txt_factura_notaCredito.Text
        If RTrim(tipo1) = "PD" Then Form_login.txt_tipo_letra.Text = "PD"

        Me.Close()

        If abre = 1 Then
            abre = 0
            Form_login.Timer3.Enabled = True
        End If

        Exit Sub

    End Sub

    Private Sub txt_neto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_neto.KeyDown

        If e.KeyCode = Keys.Return Then
            'Me.txt_precioCiva.Text = Me.txt_neto.Text

            If fact.factura_en_c = "SI" Then
                Me.txt_precioCiva.Text = Me.txt_neto1.Text
                Me.txt_neto1.Text = Me.txt_neto.Text
            Else
                If Trim(Me.txt_iva1.Text) = Trim(porcentaje_impuesto) Then
                    If Me.txt_neto.Text <> temp_precio Then
                        Me.txt_precioCiva.Text = Me.txt_neto.Text
                        Me.txt_neto.Text = Format(Me.txt_neto.Text / Val("1." & porcentaje_impuesto), "0.00")
                    End If
                End If
            End If

            If fact.Actualiza_precio_en_factura = "SI" Then

                Dim ivaa_inss As Double = Format(Me.txt_precioCiva.Text - Me.txt_neto.Text, "0.00")
                Dim costoo As Double = Format(Me.txt_neto.Text / Val("1." & Me.txt_utilidad.Text), "0.00")

                art.instruccion = "update art_precio set costo = '" & costoo & "',id_iva ='" & Trim(Me.txt_cod_iva.Text) & "',iva ='" & Trim(Me.txt_iva1.Text) & "',utilidad='" & Trim(Me.txt_utilidad.Text) & "',precio_siva='" & Me.txt_neto.Text & "',precio_civa='" & Me.txt_precioCiva.Text & "',iva_insc= '" & ivaa_inss & "' where id_art1 = '" & Trim(Me.txt_codigo_producto.Text) & "' and id_lista1 = '" & Trim(Me.txt_cod_lista.Text) & "'"
                art.actualizar()

                ivaa_inss = Nothing
                costoo = Nothing

            End If

            If Me.txt_desc_rcgo.Visible = False Then Call cargar_datos()
            Me.txt_desc_rcgo.Focus()

        End If

    End Sub

    Public Sub actualiza_numeradores()

        tal.incrementa_numerador()

    End Sub

    Private Sub limpia_totales()

        Me.txt_gravado.Text = ""
        Me.txt_exento.Text = ""
        Me.txt_inscripto.Text = ""
        Me.txt_insc_10.Text = ""
        Me.txt_imp_interno_grilla.Text = ""
        Me.txt_total_grilla.Text = ""

    End Sub

    Public Sub imprime_fiscal()

        If Me.txt_talonario_pred.Text = 2 Or fact.Imprime_en_fiscal = "NO" Then
            Exit Sub
        End If

        '''''''''''' FISCAL HASAR TICKET - FACTURA

        If RTrim(fact.fiscal_hasar) = "SI" Then

            If RTrim(Me.txt_tipo_fact.Text) = "FC" Then

                If fact.opcion_comprobante = "SI" Then

                    Form_tipo_comprobante.ShowDialog()

                    If Form_tipo_comprobante.x = 1 Then fact.imprime_ticket_fiscal_hasraf715() ' hasar 715 f

                    If Form_tipo_comprobante.x = 2 Then fact.imprime_factura_A_fiscal_h715f() ' hasar 715 f

                    If Form_tipo_comprobante.x = 3 Then fact.imprime_factura_B_fiscal_h715f() ' hasar 715 f

                Else

                    If RTrim(fact.imprime_tikets) = "SI" Then

                        fact.imprime_ticket_fiscal_hasraf715()  ' hasar 715 f

                    End If

                    If RTrim(fact.imprime_factura) = "SI" Then

                        If Me.txt_letra.Text = "A" Then

                            fact.imprime_factura_A_fiscal_h715f() ' hasar 715 f

                        End If

                        If Me.txt_letra.Text = "B" Then

                            fact.imprime_factura_B_fiscal_h715f() 'hasar 715 f

                        End If

                    End If

                End If

            End If

            '''''''''''' FISCAL HASAR NOTA DE CRTEDITO

            If RTrim(Me.txt_tipo_fact.Text) = "NC" Then

                If RTrim(fact.imprime_factura) = "SI" Then

                    If Me.txt_letra.Text = "B" Then

                        fact.imprime_N_credito_B_fiscal_h715f()

                    End If

                    If Me.txt_letra.Text = "A" Then

                        fact.imprime_Nota_credito_A_fiscal_h715f()

                    End If

                End If

            End If

        End If

        '''''''''''' FISCAL EPSON TICKET - FACTURA

        If RTrim(fact.fiscal_epson) = "SI" Then

            If RTrim(Me.txt_tipo_fact.Text) = "FC" Then

                If fact.opcion_comprobante = "SI" Then

                    Form_tipo_comprobante.ShowDialog()

                    If Form_tipo_comprobante.x = 1 Then fact.imprime_ticket_fisca_epson_tm220()

                    If Form_tipo_comprobante.x = 2 Then fact.imprime_factura_A_fiscal_epson_tm220()

                    If Form_tipo_comprobante.x = 3 Then fact.imprime_factura_B_fiscal_epson_tm220()

                Else

                    If RTrim(fact.imprime_factura) = "SI" Then

                        If Me.txt_letra.Text = "A" Then

                            fact.imprime_factura_A_fiscal_epson_tm220()

                        End If

                        If Me.txt_letra.Text = "B" Then

                            fact.imprime_factura_B_fiscal_epson_tm220()

                        End If

                    End If

                    If RTrim(fact.imprime_tikets) = "SI" Then

                        fact.imprime_ticket_fisca_epson_tm220()

                    End If

                End If

            End If

            '''''''''''' FISCAL EPSON NOTA DE CRTEDITO

            If RTrim(Me.txt_tipo_fact.Text) = "NC" Then

                If RTrim(fact.imprime_factura) = "SI" Then

                    If Me.txt_letra.Text = "B" Then

                        fact.imprime_Nota_C_B_fiscal_epson_tm220()

                    End If

                    If Me.txt_letra.Text = "A" Then

                        fact.imprime_Nota_C_A_fiscal_epson_tm220()

                    End If

                End If

            End If

        End If

    End Sub

    Public Sub verifica_fecha(ByVal mes As Integer, ByVal año As Integer)

        Dim tbl As New DataTable
        tbl.Clear()
        'Dim comando As SqlDataAdapter
        'Dim conex As New SqlConnection
        Dim contaa As Integer

        conex = conecta()

        comando = New SqlDataAdapter("select mes,año from p_carga01 where estado = 'A'", conex)
        comando.Fill(tbl)
        comando.Dispose()

        For i = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i).Item(0) = mes And tbl.Rows(i).Item(1) = año Then
                contaa = contaa + 1
            End If
        Next

        If contaa = 0 Then
            MessageBox.Show("El mes no esta Habilitado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fecha_mala = False
        Else
            fecha_mala = True
        End If

        tbl.Dispose()

    End Sub

    Public Function verifica_fecha(ByVal mes As String, ByVal año As String) As Boolean

        Dim tbl As New DataTable
        Dim comando As SqlDataAdapter
        Dim conex As New SqlConnection

        conex = conecta()

        comando = New SqlDataAdapter("select mes,año from p_carga01 where estado = 'A' and mes = '" & RTrim(mes) & "' and año = '" & RTrim(año) & "'", conex)
        comando.Fill(tbl)

        If tbl.Rows.Count = Nothing Then
            MessageBox.Show("El mes no esta Habilitado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form_modifica_fecha.Dispose()
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub calcula_imp_int()

        Dim iva As Double = ivas / 100
        Dim interno As Double = imp / 100

        Dim precio_base As Double = monto * (1 + iva + interno)

        Dim fijo As Double = monto * interno

        factor_k = 1 / (1 + interno)

    End Sub

    Private Sub calcula_sub_total()

        Dim i As Integer

        insc = 0
        insc_10 = 0
        interno = 0
        exento = 0
        neto_21 = 0
        neto_10 = 0

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            insc = Format(insc + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
            insc_10 = Format(insc_10 + Me.DataGridView1.Rows(i).Cells(13).Value, "0.00")
            interno = Format(interno + Me.DataGridView1.Rows(i).Cells(7).Value, "0.00")
            exento = Format(exento + Me.DataGridView1.Rows(i).Cells(9).Value, "0.00")

            ' se reemplaza Trim(porcentaje_impuesto) por 21 y 10.5 porque pone el mismo valor en las 2 variables
            If Trim(Me.DataGridView1.Rows(i).Cells(8).Value) = "21" Then
                ' si tiene cantidad secundaria la multiplico por la misma sino por la cantidad comun
                If Trim(Me.DataGridView1.Rows(i).Cells(17).Value) = 0 Then
                    neto_21 = Format(neto_21 + (Me.DataGridView1.Rows(i).Cells(3).Value * Me.DataGridView1.Rows(i).Cells(2).Value), "0.00")
                Else
                    neto_21 = Format(neto_21 + (Me.DataGridView1.Rows(i).Cells(3).Value * Me.DataGridView1.Rows(i).Cells(17).Value), "0.00")
                End If
            End If

            If Trim(Me.DataGridView1.Rows(i).Cells(8).Value) = "10.5" Then
                If Trim(Me.DataGridView1.Rows(i).Cells(17).Value) = 0 Then
                    neto_10 = Format(neto_10 + (Me.DataGridView1.Rows(i).Cells(3).Value * Me.DataGridView1.Rows(i).Cells(2).Value), "0.00")
                Else
                    neto_10 = Format(neto_10 + (Me.DataGridView1.Rows(i).Cells(3).Value * Me.DataGridView1.Rows(i).Cells(17).Value), "0.00")
                End If
            End If

        Next

        If Val(Me.lbl_Marcador_precio.Text) > 0 Then
            Me.txt_total_grilla.Text = Me.lbl_Marcador_precio.Text
        Else
            Me.txt_total_grilla.Text = exento
        End If

        Try

            ' si tiene un descuento hago lo siguiente
            If Me.txt_descuento_gral.Text <> "" And Val(Me.txt_descuento_gral.Text) > 0 Then
                Me.txt_total_grilla.Text = Format(Me.txt_total_grilla.Text - (Me.txt_total_grilla.Text * Me.txt_descuento_gral.Text) / 100, "0.00")
                'Me.lbl_Marcador_precio.Text = Me.txt_total_grilla.Text
                insc = Format(insc - (insc * Me.txt_descuento_gral.Text) / 100, "0.00")
                insc_10 = insc_10 - (insc_10 * Me.txt_descuento_gral.Text) / 100
                exento = exento - (exento * Me.txt_descuento_gral.Text) / 100
                interno = interno - (interno * Me.txt_descuento_gral.Text) / 100
            End If

        Catch ex As Exception

        End Try

        Me.txt_exento.Text = exento
        Me.txt_inscripto.Text = insc
        Me.txt_insc_10.Text = insc_10
        Me.txt_imp_interno_grilla.Text = interno

        Me.txt_gravado.Text = Format(Me.txt_total_grilla.Text - insc - insc_10 - interno - exento, "0.00")

    End Sub

    Public Sub guarda_factura()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        qr = System.Text.Encoding.UTF8.GetBytes(1)

        If Trim(Me.txt_tipo_fact.Text) = "FC" Or Trim(Me.txt_tipo_fact.Text) = "NC" Or Trim(Me.txt_tipo_fact.Text) = "ND" Then
            'SI HABILTO LA FACTURA ELECTRONICA Y EL TALONARIO ES 1 ENTONCES HAGO ESTO y graba afip esta en SI
            If fact.Factura_electronica_AFIP = "SI" And fact.Talonario_predeterminado = 1 And fact.Graba_AFIP = "SI" Then

                sel.instruccion = "select *from empresa_01"
                sel.nombre_tabla = "empresa_01"
                sel.carga_campos()

                fact_elec.Concepto = 1

                ''' FACTURA '''
                If Trim(Me.txt_tipo_fact.Text) = "FC" Then

                    If Trim(Me.txt_letra.Text) = "A" Then
                        fact_elec.Tipo_comprobante = 1
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Consumidor Final" And Trim(Me.txt_cliente.Text) <> "CONSUMIDOR FINAL" Then
                        fact_elec.Tipo_comprobante = 6
                        fact_elec.Tipo_documento = 96
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Consumidor Final" And Trim(Me.txt_cliente.Text) = "CONSUMIDOR FINAL" Then
                        fact_elec.Tipo_comprobante = 6
                        fact_elec.Tipo_documento = 99
                        fact_elec.Numero_documento = 0
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Exento" Then
                        fact_elec.Tipo_comprobante = 6
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "C" Then
                        fact_elec.Tipo_comprobante = 11
                        fact_elec.Tipo_documento = 99
                        fact_elec.Numero_documento = 0
                    End If

                End If

                '' CREDITO ''
                If Trim(Me.txt_tipo_fact.Text) = "NC" Then

                    If Trim(Me.txt_letra.Text) = "A" Then
                        fact_elec.Tipo_comprobante = 3
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Consumidor Final" Then
                        fact_elec.Tipo_comprobante = 8
                        fact_elec.Tipo_documento = 99
                        fact_elec.Numero_documento = 0
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Exento" Then
                        fact_elec.Tipo_comprobante = 8
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "C" Then
                        fact_elec.Tipo_comprobante = 13
                        fact_elec.Tipo_documento = 99
                        fact_elec.Numero_documento = 0
                    End If

                End If

                '' DEBITO ''
                If Trim(Me.txt_tipo_fact.Text) = "ND" Then

                    If Trim(Me.txt_letra.Text) = "A" Then
                        fact_elec.Tipo_comprobante = 2
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Consumidor Final" Then
                        If Me.txt_total_grilla.Text > 1000 Then
                            fact_elec.Tipo_comprobante = 7
                            fact_elec.Tipo_documento = 96
                            fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                        Else
                            fact_elec.Tipo_comprobante = 7
                            fact_elec.Tipo_documento = 99
                            fact_elec.Numero_documento = 0
                        End If
                    End If

                    If Trim(Me.txt_letra.Text) = "B" And Trim(Me.txt_iva_solo.Text) = "Exento" Then
                        fact_elec.Tipo_comprobante = 7
                        fact_elec.Tipo_documento = 80
                        fact_elec.Numero_documento = RTrim(Replace(Me.txt_cuit.Text, "-", ""))
                    End If

                End If

                fact_elec.Punto_venta = Me.txt_prefijo.Text
                fact_elec.Comprobante_desde = CLng(Me.txt_numero.Text)
                fact_elec.Comprobante_hasta = CLng(Me.txt_numero.Text)
                fact_elec.Importe_total = Me.txt_total_grilla.Text
                fact_elec.Exento = Me.txt_exento.Text

                If Trim(Me.txt_letra.Text) <> "C" Then
                    fact_elec.Importe_neto = Val(Me.txt_gravado.Text) + Val(Me.txt_exento.Text)
                    fact_elec.Importe_iva = Val(Me.txt_inscripto.Text) + Val(Me.txt_insc_10.Text)
                Else
                    fact_elec.Importe_neto = Me.txt_total_grilla.Text
                    fact_elec.Importe_iva = "0.00"
                End If

                fact_elec.Fecha_comprobante = Format(Date.Now, "yyyyMMdd")
                fact_elec.Neto_10 = neto_10
                fact_elec.Neto_21 = neto_21

                'qr = fact_elec.gerena_QR_factura(sel.cuit, QrCodeImgControl1)

                'MessageBox.Show(Me.txt_insc_10.Text & " " & Me.txt_inscripto.Text & " " & Me.txt_letra.Text & " " & sel.cuit & " " & sel.CRT & " " & sel.KEY & " " & CLng(Me.txt_numero.Text), "variables", MessageBoxButtons.OK, MessageBoxIcon.Information)

                estado = fact_elec.carga_factura_electronica(Me.txt_insc_10.Text, Me.txt_inscripto.Text, Me.txt_letra.Text, sel.cuit, sel.CRT, sel.KEY, CLng(Me.txt_numero.Text))
                'estado = True

                If fact_elec.Numeradores_distintos = True Then
                    MessageBox.Show("La numeracion del sistemas no es laisma que AFIP.. Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                If estado = False Then
                    MessageBox.Show("La Factura no se grabo en el AFIP....Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                Else
                    qr = fact_elec.gerena_QR_factura(sel.cuit, QrCodeImgControl1)
                End If

            End If

        End If

        Call actualiza_numeradores()

        If (estado = True Or fact.Factura_electronica_AFIP = "NO" Or fact.Talonario_predeterminado = 2 Or Me.txt_tipo_fact.Text = "RE" Or Me.txt_tipo_fact.Text = "RS" Or fact.Graba_AFIP = "NO") Then guarda_factura_part2()

    End Sub

    Private Sub guarda_factura_part2()

        Try

            Dim pago, detalle As String
            Dim pos As Integer

            'fact_elec.cae_afip = Me.lbl_cae.Text
            'fact_elec.Fecha_cae = Replace(CDate(Me.lbl_venc_cae.Text).ToString("yyyy/MM/dd"), "/", "")

            If veri_comprobante = True Then

                If RTrim(Me.cmb_forma_pago.Text) = "Contado" Then
                    pago = "PAGADO"
                Else
                    pago = "DEBE"
                End If

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    'conex_tb = conecta()
                    conex.Open()
                    'trans = conex.BeginTransaction()
                End If

                ' actualizo la tabla ped_det por si otro ordenaodr cambio los numeradores

                coman = New SqlCommand("update ped_det with(rowlock,xlock) set num = '" & tal.numerador - 1 & "' where pc = '" & RTrim(My.Computer.Name) & "'", conex)
                'coman.Transaction = trans
                coman.ExecuteNonQuery()
                'trans.Commit()
                coman.Dispose()

                ' comienzo con la carga del comprobante

                coman = New SqlCommand("INSERT INTO fact_cab (num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,fec_vto,id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,lista,forma_pago,estado_fact,id_lista,talon,ing_bruto1,arqueo,pago,hora,cae,venc_cae,qr) VALUES('" & tal.numerador - 1 & "','" & tipo & "','" & Me.txt_prefijo.Text & "' , '" & Me.txt_letra.Text & "','" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_cliente.Text & "','" & Me.txt_iva_solo.Text & "','" & Me.cuit & "','" & Me.txt_direccion.Text & "','" & Me.txt_vendedor.Text & "','" & Me.txt_nom_vendedor.Text & "','" & Me.txt_lista.Text & "','" & Me.cmb_forma_pago.Text & "','Activo', '" & Me.txt_lista_predet.Text & "', '" & Me.txt_talonario_pred.Text & "', '" & Me.txt_ingbrutos.Text & "','B','" & pago & "','" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "','" & Me.lbl_cae.Text & "','" & Me.lbl_venc_cae.Text & "',@qr)", conex)
                'coman.Transaction = trans
                Dim param As New SqlClient.SqlParameter("@qr", SqlDbType.Image)
                param.Value = qr
                coman.Parameters.Add(param)
                coman.ExecuteNonQuery()
                coman.Dispose()

                If RTrim(Me.cmb_forma_pago.Text) = "Cta Cte" Then

                    If tipo = "FC" Or tipo = "ND" Then

                        coman = New SqlCommand("INSERT INTO cta_cte01 (id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,confirma,cod_vend) VALUES('" & tal.numerador - 1 & "','" & tipo & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','" + Me.txt_codigo.Text + "','" + Me.txt_cliente.Text + "','" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Val(Me.txt_total_grilla.Text) & "', '','" & tal.numerador - 1 & "', 'DEBE','P','" & Me.txt_vendedor.Text & "')", conex)
                        'coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        cta_cte = True

                        coman = New SqlCommand("INSERT INTO cta_cte_hist (num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" & tal.numerador - 1 & "','" & tipo & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','" & Val(Me.txt_total_grilla.Text) & "', '','DEBE','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_cliente.Text & "')", conex)
                        'coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                    If tipo = "NC" Then

                        coman = New SqlCommand("INSERT INTO cta_cte01 (id_cta,tc,lt,pre,id_cli,cli,fecha_emi,fecha_vto,debito,credito,num_fact,estado,confirma,cod_vend) VALUES('" & tal.numerador - 1 & "','" & tipo & "','" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','" + Me.txt_codigo.Text + "','" + Me.txt_cliente.Text + "','" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "',' ','" & Val(Me.txt_total_grilla.Text) & "','" & tal.numerador - 1 & "','DEBE','P', '" & Me.txt_vendedor.Text & "')", conex)
                        'coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        cta_cte = True

                        coman = New SqlCommand("INSERT INTO cta_cte_hist (num,tc,lt,pre,debito,credito,estado,fec,id_cli,cli) VALUES('" & tal.numerador - 1 & "','" & tipo & "', '" + Me.txt_letra.Text + "','" + Me.txt_prefijo.Text + "','','" & Val(Me.txt_total_grilla.Text) & "','DEBE','" & Me.dt_fec_emision.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_cliente.Text & "')", conex)
                        'coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    detalle = Me.DataGridView1.Rows(i).Cells(1).Value

                    If RTrim(Me.txt_tipo_fact.Text) = "PD" Then

                        tbbl1.Clear()
                        comando = New SqlDataAdapter("select * from ped_det where num= '" & RTrim(tal.numerador - 1) & "' and pre ='" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pc = '" & RTrim(My.Computer.Name) & "'", conex)
                        comando.Fill(tbbl1)
                        comando.Dispose()

                    End If

                    selecciona_porcentaje_impuesto(Me.DataGridView1.Rows(i).Cells(8).Value)

                    iva_valor = 0

                    'If Trim(Me.DataGridView1.Rows(i).Cells(8).Value) = Trim(porcentaje_impuesto) Then
                    If Trim(codigo_iva) = 1 Then '21%
                        iva_valor = Me.DataGridView1.Rows(i).Cells(6).Value
                    End If

                    'If Trim(Me.DataGridView1.Rows(i).Cells(8).Value) = Trim(porcentaje_impuesto) Then
                    If Trim(codigo_iva) = 2 Then '10.5%
                        iva_valor = Me.DataGridView1.Rows(i).Cells(13).Value
                    End If

                    If conex.State = ConnectionState.Closed Then
                        conex.Open()
                    End If

                    coman = New SqlCommand("INSERT INTO fact_det (fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,cod_prov,cod_rub,nom_producto,vend1,n_carga,val_uni_sec) VALUES('" & Me.dt_fec_emision.Text & "','" & tal.numerador - 1 & "' ,'" & tipo & "', '" + Me.txt_prefijo.Text + "','" + Me.txt_letra.Text + "','" & Me.DataGridView1.Rows(i).Cells(0).Value & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','" & Val(Me.DataGridView1.Rows(i).Cells(5).Value) & "','" & iva_valor & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(9).Value & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Me.DataGridView1.Rows(i).Cells(4).Value & "','" & Me.DataGridView1.Rows(i).Cells(10).Value & "', '" & Me.DataGridView1.Rows(i).Cells(11).Value & "', '" & Me.txt_lista_predet.Text & "', '" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & Me.txt_talonario_pred.Text & "','SI','" & i & "','" & Me.DataGridView1.Rows(i).Cells(14).Value & "','" & Me.DataGridView1.Rows(i).Cells(15).Value & "','" & Me.DataGridView1.Rows(i).Cells(16).Value & "','" & detalle & "','" & Me.txt_vendedor.Text & "','" & Me.txt_n_carga.Text & "','" & Me.DataGridView1.Rows(i).Cells(17).Value & "')", conex)
                    'coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    ' si es tipo furgon no actulizo el proveedor en la tabla articulos
                    If tipo = "RE" Or tipo = "RS" Then

                        If RTrim(Me.txt_tipo_cliente.Text) <> "Furgon" Then

                            coman = New SqlCommand("update art_01 set proveedor = '" & Me.txt_cliente.Text & "',id_proveedor = '" & Me.txt_codigo.Text & "' where  id_art = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "'", conex)
                            'coman.Transaction = trans
                            coman.ExecuteNonQuery()
                            coman.Dispose()

                        End If

                    End If

                    pos = i
                    detalle = ""

                Next

                coman = New SqlCommand("INSERT INTO fact_tot (num_factura,letra,tipo_factura,pref,id_cliente,nombre_cli,total,iva_ins,exento,imp_interno1,iva_10,sub_total,fecha_emision1,descuento,total_cobro,talon2,efectivo,comentario) VALUES('" & tal.numerador - 1 & "','" + Me.txt_letra.Text + "','" & tipo & "','" + Me.txt_prefijo.Text + "','" + Me.txt_codigo.Text + "','" + Me.txt_cliente.Text + "','" & Val(Me.txt_total_grilla.Text) & "','" & Val(Me.txt_inscripto.Text) & "','" & Val(Me.txt_exento.Text) & "','" & Val(Me.txt_imp_interno_grilla.Text) & "','" & Val(Me.txt_insc_10.Text) & "','" & Val(Me.txt_gravado.Text) & "','" & Me.dt_fec_emision.Text & "','" & Val(Me.txt_descuento_gral.Text) & "','" & Val(Me.txt_total_grilla.Text) & "', '" & Me.txt_talonario_pred.Text & "','SI','" & comentario & "')", conex)
                'coman.Transaction = trans
                coman.ExecuteNonQuery()
                coman.Dispose()

                If Me.txt_total_cobro.Text = 1 Then

                    coman = New SqlCommand("update fact_tot set total_cobro = '" + Me.txt_importe_cobro.Text + "' where num_factura = '" & tal.numerador - 1 & "' and letra = '" + Me.txt_letra.Text + "' and pref = '" + Me.txt_prefijo.Text + "' and tipo_factura= '" + Me.txt_tipo_fact.Text + "'", conex)
                    'coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    If Me.txt_modifica_efectivo.Text = 1 Then

                        coman = New SqlCommand("update fact_tot set efectivo = 'NO' where num_factura = '" & tal.numerador - 1 & "' and letra = '" + Me.txt_letra.Text + "' and pref = '" + Me.txt_prefijo.Text + "' and tipo_factura ='" & Me.txt_tipo_fact.Text & "'", conex)
                        'coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

            End If

            'If conex.State = ConnectionState.Open Then conex.Close()
            'Call imprimir(tal.numerador - 1)

            If RTrim(Me.txt_tipo_fact.Text) = "PD" Then

                tt.Clear()
                comando = New SqlDataAdapter("select fecha,num,tc,pre,lt,id_art2,detalle,cant,descuento,p_siva,p_civa,total,talon,lista,iva,iva_ins,costo,cod_prov,cod_rub,deta from ped_det where pc = '" & RTrim(My.Computer.Name) & "'", conex)
                comando.Fill(tt)
                comando.Dispose()

                'If conex.State = ConnectionState.Closed Then
                'conex = conecta()
                'conex.Open()
                'trans = conex.BeginTransaction
                'End If

                For i = 0 To tbbl1.Rows.Count - 1

                    pos = pos + 1

                    coman = New SqlCommand("INSERT INTO fact_det with(rowlock,xlock)(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,cod_prov,cod_rub,nom_producto,vend1) VALUES('" & tt.Rows(i).Item(0) & "','" & tt.Rows(i).Item(1) & "' ,'" & tt.Rows(i).Item(2) & "', '" & tt.Rows(i).Item(3) & "','" & tt.Rows(i).Item(4) & "','" & tt.Rows(i).Item(5) & "','" & tt.Rows(i).Item(6) & "','" & tt.Rows(i).Item(7) & "','" & tt.Rows(i).Item(8) & "','" & tt.Rows(i).Item(15) & "','','','" & tt.Rows(i).Item(9) & "','" & tt.Rows(i).Item(11) & "','" & tt.Rows(i).Item(14) & "', '" & tt.Rows(i).Item(10) & "', '" & tt.Rows(i).Item(13) & "', '" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & tt.Rows(i).Item(12) & "','SI','" & pos & "','" & tt.Rows(i).Item(16) & "','" & tt.Rows(i).Item(17) & "','" & tt.Rows(i).Item(18) & "','" & tt.Rows(i).Item(19) & "','" & Me.txt_vendedor.Text & "')", conex)
                    'coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                Next

                'trans.Commit()

            End If

            'trans.Commit()

            conex.Close()

            Call imprimir(tal.numerador - 1)

            art.instruccion = "DELETE ped_det WHERE pc = '" & RTrim(My.Computer.Name) & "'"
            art.actualizar()

        Catch ex As Exception

            'trans.Rollback()

        Finally

        End Try

    End Sub

    Private Sub txt_cod_lista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_lista.KeyDown

        Try

            If e.KeyCode = Keys.F1 Then
                busc_lista.Show()
            End If

            If e.KeyCode = Keys.Return Then

                conex = conecta()

                comando = New SqlDataAdapter("select *from lista_01 where id_lis = '" & Me.txt_cod_lista.Text & "'", conex)
                comando.Fill(tbl)

                Me.txt_cod_lista.Text = tbl.Rows(0).Item(0)
                Me.txt_lista.Text = tbl.Rows(0).Item(1)

                Me.txt_codigo_producto.Enabled = True
                Me.txt_codigo_producto.Focus()
                Me.txt_cod_lista.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "PyM soft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub falla_stk(ByVal codigo, ByVal nombre, ByVal computer, ByVal cantidad, ByVal tipo, ByVal numero, ByVal prefijo, ByVal letra, ByVal talonario, ByVal fila)

        ' carga articulos en tabla especial por posibles cortes de luz

        tbl2.Clear()

        conex = conecta()
        comando = New SqlDataAdapter("select *from act_art where codart = '" & codigo & "' and computer = '" & computer & "'", conex)
        comando.Fill(tbl2)
        comando.Dispose()

        If tbl2.Rows.Count = Nothing Then

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            coman = New SqlCommand("INSERT INTO act_art(codart,des,cant,computer,tipo,numero,pre,lt,talonario,fila) VALUES('" & codigo & "' , '" & nombre & "', '" & cantidad & "', '" & computer & "','" & tipo & "','" & numero & "','" & prefijo & "','" & letra & "','" & talonario & "','" & fila & "')", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

        Else

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            If fila_actual = True Then
                cant1 = (tbl2.Rows(0).Item(2) + cantidad) - cantidad_anterior

                coman = New SqlCommand("UPDATE act_art set cant = '" & cant1 & "' where codart = '" & codigo & "' and computer = '" & computer & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                conex.Close()
                Exit Sub

            End If

            If fila_actual = False Then
                cant1 = (tbl2.Rows(0).Item(2) + cantidad)

                coman = New SqlCommand("UPDATE act_art set cant = '" & cant1 & "' where codart = '" & codigo & "' and computer = '" & computer & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                conex.Close()
                Exit Sub

            End If

        End If

        conex.Close()

    End Sub

    Public Sub act_falla_stk(ByVal grilla, ByVal computer, ByVal pos)

        Try

            tbl2 = New DataTable
            tbl2.Clear()

            Dim cant2 As Double

            conex = conecta()
            comando = New SqlDataAdapter("select cant,tipo from act_art where codart = '" & RTrim(grilla.Rows(pos).Cells(0).Value) & "' and computer = '" & computer & "'", conex)
            comando.Fill(tbl2)

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            If RTrim(tbl2.Rows(0).Item(1)) = "FC" Or RTrim(tbl2.Rows(0).Item(1)) = "RS" Or RTrim(tbl2.Rows(0).Item(1)) = "PD" Then cant2 = tbl2.Rows(0).Item(0) - grilla.Rows(pos).Cells(2).Value
            If RTrim(tbl2.Rows(0).Item(1)) = "NC" Or RTrim(tbl2.Rows(0).Item(1)) = "RE" Then cant2 = tbl2.Rows(0).Item(0) - grilla.Rows(pos).Cells(2).Value

            coman = New SqlCommand("UPDATE act_art set cant = '" & cant2 & "' where codart = '" & RTrim(grilla.Rows(pos).Cells(0).Value) & "' and computer = '" & computer & "'", conex)
            coman.ExecuteNonQuery()

        Catch ex As Exception

        Finally

            tbl2.Dispose()
            conex.Close()

        End Try

    End Sub

    Private Sub modifica_stk_falla(ByVal grilla, ByVal computer, ByVal cantidad)

        tbl2.Clear()
        Dim cant3 As Double

        conex = conecta()
        comando = New SqlDataAdapter("select cant,tipo from act_art where codart = '" & RTrim(grilla.Rows(i).Cells(0).Value) & "' and computer = '" & computer & "'", conex)
        comando.Fill(tbl2)

        If conex.State = ConnectionState.Closed Then
            conex.Open()
        End If

        Dim f As Integer = grilla.Rows(i).Cells(2).Value

        If RTrim(tbl2.Rows(0).Item(5)) = "FC" Or RTrim(tbl2.Rows(0).Item(5)) = "RS" Or RTrim(tbl2.Rows(0).Item(5)) = "PD" Then cant3 = cantidad + tbl2.Rows(0).Item(3) - grilla.Rows(i).Cells(2).Value
        If RTrim(tbl2.Rows(0).Item(5)) = "NC" Or RTrim(tbl2.Rows(0).Item(5)) = "RE" Then cant3 = tbl2.Rows(0).Item(3) - grilla.Rows(i).Cells(2).Value + cantidad

        coman = New SqlCommand("UPDATE act_art set cant = '" & cant3 & "' where codart = '" & RTrim(grilla.Rows(i).Cells(0).Value) & "' and computer = '" & computer & "'", conex)
        coman.ExecuteNonQuery()

        conex.Close()

    End Sub

    Public Sub borra_tabla_art_act(ByVal computer)

        If conex.State = ConnectionState.Closed Then
            conex = conecta()
            conex.Open()
        End If

        coman = New SqlCommand("DELETE act_art where computer = '" & computer & "'", conex)
        coman.ExecuteNonQuery()
        coman.Dispose()

        If conex.State = ConnectionState.Open Then
            conex.Close()
        End If

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        If RTrim(Me.txt_tipo_fact.Text) = "FC" Then System.Diagnostics.Process.Start(Application.StartupPath & "\manual\factura.html")
    End Sub

    Public Sub verifica_numerador_existente()

        Dim tb_existe As New DataTable

        Try

            tb_existe.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact = '" & RTrim(Me.txt_tipo_fact.Text) & "' and letra_fact= '" & RTrim(Me.txt_letra.Text) & "' and prefijo_fact= '" & RTrim(Me.txt_prefijo.Text) & "' and talon = '" & Me.txt_talonario_pred.Text & "'", conex)
            comando.Fill(tb_existe)
            comando.Dispose()

            If tb_existe.Rows.Count <> Nothing Then
                MessageBox.Show("El numero ya existe", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                existe_num = True
            Else
                existe_num = False
            End If

        Catch ex As Exception

            MessageBox.Show("No se cargaron los numeradores", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        Finally

            tb_existe.Dispose()

        End Try

    End Sub

    Public Sub verifica_cabecera_sin_datos()

        Try

            Dim tb_c As New DataTable

            tb_c.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact = '" & RTrim(Me.txt_tipo_fact.Text) & "' and letra_fact= '" & RTrim(Me.txt_letra.Text) & "' and prefijo_fact= '" & RTrim(Me.txt_prefijo.Text) & "' and talon = '" & Me.txt_talonario_pred.Text & "'", conex)
            comando.Fill(tb_c)

            If tb_c.Rows.Count <> Nothing Then
                cabecera = cabecera + 1
            End If

            tb_c.Clear()

            comando = New SqlDataAdapter("select num_fact,tipo_fact2,letra_fact1,prefijo_fact2 from fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo_fact.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and prefijo_fact2= '" & RTrim(Me.txt_prefijo.Text) & "' and talon1 = '" & Me.txt_talonario_pred.Text & "'", conex)
            comando.Fill(tb_c)

            If tb_c.Rows.Count <> Nothing Then
                cabecera = cabecera + 1
            End If

            tb_c.Clear()

            comando = New SqlDataAdapter("select num_factura,tipo_factura,letra,pref from fact_tot where num_factura = '" & RTrim(Me.txt_numero.Text) & "' and tipo_factura = '" & RTrim(Me.txt_tipo_fact.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and pref = '" & RTrim(Me.txt_prefijo.Text) & "' and talon2 = '" & Me.txt_talonario_pred.Text & "'", conex)
            comando.Fill(tb_c)

            If tb_c.Rows.Count <> Nothing Then
                cabecera = cabecera + 1
            End If

            If cabecera <> 0 And cabecera <> 3 Then
                MessageBox.Show("Desea borrar la factura incompleta?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            tb_c.Dispose()
            comando.Dispose()

        Catch ex As Exception

            MessageBox.Show("No se cargaron los numeradores", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

    End Sub

    Private Sub modifica_stock()

        If (RTrim(fact.mueve_stock) = "SI" Or RTrim(Me.txt_mueve_stok.Text) = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            Call falla_stk(Me.txt_codigo_producto.Text, Me.txt_nombre_producto.Text, nom_computadora, Me.txt_cantidad.Text, Me.txt_tipo_fact.Text, Me.txt_numero.Text, Me.txt_prefijo.Text, Me.txt_letra.Text, Me.txt_talonario_pred.Text, Me.DataGridView1.Rows.Count - 1)

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
                trans = conex.BeginTransaction(IsolationLevel.Serializable)
            End If

            tb_cant.Clear()

            comando = New SqlDataAdapter("select cantidad from art_01 with(rowlock,xlock) where id_art = '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
            comando.SelectCommand.Transaction = trans
            comando.Fill(tb_cant)

        End If

        'If RTrim(Me.txt_mueve_stok.Text) = "SI" And Me.txt_tipo_fact.Text = "PD" Then

        'art.cantidad = Val(Me.txt_cantidad.Text)
        'art.stok = Val(tb_cant.Rows(0).Item(0))
        'Me.txt_cantidad.Text = art.stok - art.cantidad

        'trans.Commit()
        'conex.Close()
        'Exit Sub

        'End If

        If (RTrim(Me.txt_mueve_stok.Text) = "NO" Or RTrim(Me.txt_mueve_stok.Text) = "SI") And Me.txt_tipo_fact.Text = "PD" Then

            Me.txt_cantidad.Text = art.cantidad
            Exit Sub

        End If

        If (Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            art.cantidad = Val(Me.txt_cantidad.Text)
            art.stok = Val(tb_cant.Rows(0).Item(0))
            Me.txt_cantidad.Text = art.stok - art.cantidad

            trans.Commit()
            conex.Close()
            Exit Sub

        End If

        If (Me.txt_factura_notaCredito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO") Or (Me.txt_remito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            Me.txt_cantidad.Text = art.cantidad
            Exit Sub

        End If

        If (Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "SI") Or (Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "SI") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            art.cantidad = Val(Me.txt_cantidad.Text)
            art.stok = Val(tb_cant.Rows(0).Item(0))
            Me.txt_cantidad.Text = art.stok + art.cantidad

            trans.Commit()
            conex.Close()
            Exit Sub

        End If

        If (Me.txt_factura_notaCredito.Text = 2 And RTrim(Me.txt_mueve_stok.Text) = "NO") Or (Me.txt_remito.Text = 1 And RTrim(Me.txt_mueve_stok.Text) = "NO") And Trim(Me.txt_tipo_fact.Text) <> "PD" Then

            Me.txt_cantidad.Text = art.cantidad
            Exit Sub

        End If

    End Sub

    Private Sub carga_registro(ByVal codigo)

        'If Me.txt_remito.Text = 0 Then cli.insruccion = "select *from cli_01 where id_cli like '" & codigo & "' and tipo_cliente like 'Cliente'"
        'If Me.txt_remito.Text <> 0 Then cli.insruccion = "select *from cli_01 where id_cli like '" & codigo & "' and tipo_cliente <> 'Cliente'"

        cli.insruccion = "select * from cli_01 where id_cli like '" & codigo & "' and estado = 'ACTIVO'"
        cli.cargar_registro()

        If Trim(Me.txt_cliente.Text) <> "CONSUMIDOR FINAL" And fact.Talonario_predeterminado = 1 And Me.txt_remito.Text = 0 Then
            If Me.txt_cuit.Text = "  -        -" Or Len(Trim(Replace(Me.txt_cuit.Text, "-", ""))) < 7 Then
                MessageBox.Show("Verifique cuit del cliente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Exit Sub
            End If
        End If

        If fact.vendedor_x_defecto <> 0 Then
            conex = conecta()
            comando = New SqlDataAdapter("select id_vendedor,nombre from vend_01 where id_vendedor= '" & fact.vendedor_x_defecto & "'", conex)
            comando.Fill(tb)
            comando.Dispose()
            Me.txt_vendedor.Text = tb.Rows(0).Item(0)
            Me.txt_nom_vendedor.Text = tb.Rows(0).Item(1)
            tb.Clear()
            tb.Dispose()
        End If

        If cli.verifica = False Then Exit Sub
        cli.carga_letra()
        Dim a As Char = Me.txt_factura_notaCredito.Text
        If fact.Talonario_predeterminado = "1" Then tal.instruccion = "select *from numerador where talon ='" & fact.Talonario_predeterminado & "' and punto_venta = '" & fact.punto_venta & "'"
        If fact.Talonario_predeterminado = "2" Then tal.instruccion = "select *from numerador where talon ='" & fact.Talonario_predeterminado & "'"
        tal.carga_numerador_factura()
        Call verifica_numerador_existente()
        If existe_num = True Then Me.Close()
        Call habilita_numeradores()
        Call habilita_desc()

        If RTrim(Me.txt_tipo_fact.Text) = "RE" Or RTrim(Me.txt_tipo_fact.Text) = "RS" Then
            fact.instruccion = "select *from fact_cab where num_fact1= '" & Me.txt_numero.Text & "' and letra_fact = '" & Me.txt_letra.Text & "' and prefijo_fact= '" & Me.txt_prefijo.Text & "'"
        Else
            fact.instruccion = "select *from fact_cab where num_fact1= '" & Me.txt_numero.Text & "' and tipo_fact = '" & Me.txt_tipo_fact.Text & "' and letra_fact = '" & Me.txt_letra.Text & "' and prefijo_fact= '" & Me.txt_prefijo.Text & "' and talon = '" & Me.txt_talonario_pred.Text & "'"
        End If

        Call verifica_fecha(Me.dt_fec_emision.Value.Month, Me.dt_fec_emision.Value.Year)

        art.instruccion = "DELETE ped_det WHERE num = '" & RTrim(Me.txt_numero.Text) & "' and lt = '" & RTrim(Me.txt_letra.Text) & "' and pre = '" & RTrim(Me.txt_prefijo.Text) & "' and tc = '" & RTrim(Me.txt_tipo_fact.Text) & "'"
        art.actualizar()

        Call calcula_saldo_cta_cte()

        If fact.Habilita_facturacion_especial = "SI" And fact.Talonario_predeterminado = 2 Then
            Call selecciona_lista_determinada(9999)
        Else
            Call selecciona_lista_determinada(Me.txt_lista_predet.Text)
        End If

        If fecha_mala = False Then
            numerador = False
            Call actualiza_numeradores()
            Me.Dispose()
            Exit Sub
        End If

        If fact.sale = True Then
            Me.txt_letra.Text = a
            numerador = False
            Call actualiza_numeradores()
            Me.Dispose()
            Exit Sub
        End If

        If Me.txt_remito.Text = 1 Or Me.txt_remito.Text = 2 Then
            Me.txt_vendedor.Enabled = False
            Me.txt_codigo_producto.Enabled = True
            Me.txt_codigo_producto.Focus()
            Me.txt_desc_rcgo.Visible = False
            Me.lbl_des_rcgo.Visible = False
            Me.txt_cod_lista.Enabled = False
        End If

    End Sub

    Public Sub calcula_saldo_cta_cte()

        Dim tb_saldo As New DataTable
        Dim i, x As Integer
        Dim suma, suma1 As Double

        tb_saldo.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select tc,debito,credito,fecha_emi,fecha_vto from cta_cte01 where id_cli = '" & RTrim(Me.txt_codigo.Text) & "'", conex)
        comando.Fill(tb_saldo)
        comando.Dispose()

        For i = 0 To tb_saldo.Rows.Count - 1

            x = DateDiff(DateInterval.Day, tb_saldo.Rows(i).Item(3), tb_saldo.Rows(i).Item(4))

            If RTrim(tb_saldo.Rows(i).Item(0)) = "FC" Or RTrim(tb_saldo.Rows(i).Item(0)) = "ND" Then

                suma = Format(suma + tb_saldo.Rows(i).Item(1), "0.00")

                If x >= 15 Then
                    suma1 = Format(suma1 + tb_saldo.Rows(i).Item(1), "0.00")
                End If

            End If

            If RTrim(tb_saldo.Rows(i).Item(0)) = "NC" Or RTrim(tb_saldo.Rows(i).Item(0)) = "RA" Then

                suma = Format(suma - tb_saldo.Rows(i).Item(2), "0.00")

                If x >= 15 Then
                    suma1 = Format(suma1 - tb_saldo.Rows(i).Item(2), "0.00")
                End If

            End If

        Next

        Me.lbl_saldo_cta.Text = suma
        Me.lbl_saldo_venc.Text = suma1

    End Sub

    Private Sub txt_neto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_neto.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_desc_rcgo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_rcgo.KeyUp

        If Me.txt_desc_rcgo.Text = "-." Then
            Me.txt_desc_rcgo.Text = ""
            Exit Sub
        End If

    End Sub

    Private Sub txt_n_carga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_n_carga.KeyDown

        If e.KeyCode = Keys.Return Then

            lis.instruccion = "select id,carga from carga_01 where id like '" & Trim(Me.txt_n_carga.Text) & "'"
            lis.codigo = "id"
            lis.nombre = "carga"
            lis.cargar()

            Me.txt_n_carga.Text = (lis.text)
            Me.lbl_nombre_carga.Text = Trim(lis.text2)

            If Me.txt_n_carga.Text = "" Then
                Me.txt_n_carga.Focus()
                Exit Sub
            End If

            Me.txt_n_carga.Enabled = False

            If Me.txt_vendedor.Enabled = True Then
                Me.txt_vendedor.Focus()
            Else
                If Me.txt_cod_lista.Enabled = True Then
                    Me.txt_cod_lista.Focus()
                Else
                    Me.txt_codigo_producto.Focus()
                End If
            End If
        End If

        If e.KeyCode = Keys.F1 Then

            busc_carga.Show()

        End If

    End Sub

    Private Sub txt_n_carga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_carga.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Public Sub selecciona_lista_determinada(ByVal lista As Short)

        Dim tb_list As New DataTable
        tb_list.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select id_lis,nombre from lista_01 where id_lis = '" & Trim(lista) & "'", conex)
        comando.Fill(tb_list)
        comando.Dispose()

        Me.txt_cod_lista.Text = tb_list.Rows(0).Item(0)
        Me.txt_lista.Text = tb_list.Rows(0).Item(1)
        Me.txt_lista_predet.Text = tb_list.Rows(0).Item(0)

        tb_list.Dispose()

    End Sub

    Private Sub txt_neto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_neto.LostFocus
        Me.txt_neto.BackColor = Color.LightGray
        Me.txt_neto.ForeColor = Color.Black
    End Sub

    Private Sub txt_nombre_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nombre_producto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_cantidad.SelectAll()
            Me.txt_cantidad.Focus()
        End If
    End Sub

    Private Sub selecciona_valor_impuesto(ByVal cod As Integer)

        Dim tb_ivaa As New DataTable
        tb_ivaa.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select iva_insc,id_iva from iva_01 where id_iva = '" & RTrim(cod) & "'", conex)
        comando.Fill(tb_ivaa)
        comando.Dispose()

        porcentaje_impuesto = Trim(tb_ivaa.Rows(0).Item(0))
        codigo_iva = Trim(tb_ivaa.Rows(0).Item(1))

        tb_ivaa.Dispose()

    End Sub

    Private Sub selecciona_porcentaje_impuesto(ByVal porcentaje As String)

        Dim tb_ivaa As New DataTable
        tb_ivaa.Clear()

        comando = New SqlDataAdapter("select id_iva,iva_insc from iva_01 where iva_insc = '" & RTrim(porcentaje) & "'", conex)
        comando.Fill(tb_ivaa)
        comando.Dispose()

        porcentaje_impuesto = Trim(tb_ivaa.Rows(0).Item(1))
        codigo_iva = Trim(tb_ivaa.Rows(0).Item(0))

        tb_ivaa.Dispose()

    End Sub

    Private Sub txt_descuento_gral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descuento_gral.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DataGridView1.Focus()
            Me.txt_codigo_producto.Enabled = False
            Me.txt_cantidad.Enabled = False
            Me.txt_desc_rcgo.Enabled = False

            Me.txt_stock.Text = ""
            Me.lbl_bulto.Text = ""

            Call calcula_sub_total()
        End If
    End Sub

    Private Sub txt_descuento_gral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_gral.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_unidad_secundaria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_unidad_secundaria.GotFocus
        Me.txt_unidad_secundaria.BackColor = Color.Red
        Me.txt_unidad_secundaria.ForeColor = Color.White
    End Sub

    Private Sub txt_unidad_secundaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_unidad_secundaria.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_unidad_secundaria.Text = Nothing Or Val(Me.txt_unidad_secundaria.Text) <= 0 Then Exit Sub
            Me.txt_cantidad.Focus()
            Me.txt_cantidad.SelectAll()
        End If
    End Sub

    Private Sub txt_unidad_secundaria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_unidad_secundaria.KeyPress
        num.positivos_punto(e, Me.txt_unidad_secundaria)
    End Sub

    Private Sub txt_comprobante_aplicar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comprobante_aplicar.KeyPress
        num.positivos_punto(e, Me.txt_comprobante_aplicar)
    End Sub

End Class

