Imports System.Data
Imports System.Data.SqlClient

Public Class Form_factura_preventa

    Dim total As Single
    Public num_fact, pref_fact As Decimal
    Public i, fila_en_db As Integer
    Dim art As New pymsoft.articulo
    Dim tal As New pymsoft.talonario
    Public fact As New pymsoft.factura
    Public fac_elect As New pymsoft.factura_electronica
    Dim coman As SqlCommand
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim porcentaje_impuesto As String

    Dim pos, j, cont As Integer
    Dim tbbl As New DataTable, tabla_fact As New DataTable, tb_reccta As New DataTable
    Public fila, az As Integer
    Public nom_computadora, lt, tipo_iva As String
    Public edita As String
    Public neto_10, neto_21 As Double
    Const una_vez As Short = 0
    Dim sale As Short = 0

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                i = Me.DataGridView1.CurrentCell.RowIndex
                Me.DataGridView1.Rows(i).Cells(20).Value = 0

                If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange Then
                    Call Fila_verde_o_Naranja()
                End If

                If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Then
                    Call Fila_verde_o_Naranja()
                End If

                If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White Then
                    Call Fila_Blanca()
                End If

            End If

            If e.KeyCode = Keys.F5 Then

                Call carga_factura()

            End If

            If e.KeyCode = Keys.Delete Then

                pos = Me.DataGridView1.CurrentCell.RowIndex   ' fila actual
                fila_en_db = Me.DataGridView1.SelectedCells(23).Value
                Call elimina_fila(fila_en_db, pos)

            End If

            If e.KeyCode = Keys.F1 Then

                Call agrega_articulo()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Fila_Blanca()

        'Call carga_letra_comprobante()

        lt = Me.txt_letra.Text

        Form_cantidad_pedido.lbl_codigo.Text = Me.DataGridView1.SelectedCells.Item(0).Value
        Form_cantidad_pedido.lbl_articulo.Text = Me.DataGridView1.SelectedCells.Item(1).Value
        Form_cantidad_pedido.lbl_p_siva.Text = Me.DataGridView1.SelectedCells.Item(3).Value
        Form_cantidad_pedido.lbl_costo.Text = Me.DataGridView1.SelectedCells.Item(14).Value
        Form_cantidad_pedido.txt_precio.Text = Me.DataGridView1.SelectedCells.Item(19).Value
        Form_cantidad_pedido.lbl_p_civa.Text = Me.DataGridView1.SelectedCells.Item(19).Value
        If Val(Me.DataGridView1.SelectedCells.Item(18).Value) = 0 Then
            Form_cantidad_pedido.txt_desc_rcgo.Text = ""
            Form_cantidad_pedido.lbl_descuento.Text = ""
        Else
            Form_cantidad_pedido.txt_desc_rcgo.Text = Val(Me.DataGridView1.SelectedCells.Item(18).Value)
            Form_cantidad_pedido.lbl_descuento.Text = Val(Me.DataGridView1.SelectedCells.Item(18).Value)
        End If

        Form_cantidad_pedido.lbl_uni_sec.Text = Me.DataGridView1.SelectedCells.Item(24).Value
        Form_cantidad_pedido.txt_unidad_secundaria.Text = Me.DataGridView1.SelectedCells.Item(25).Value

        art.instruccion = "select cantidad,mueve_stok,id_iva,iva from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 where id_art = '" & Form_cantidad_pedido.lbl_codigo.Text & "'"
        art.carga_preventa()

        Form_cantidad_pedido.lbl_stok_ant.Text = art.cantidad
        Form_cantidad_pedido.lbl_art_mueve_stok.Text = art.mueve_stok
        Form_cantidad_pedido.txt_cantidad.Text = Me.DataGridView1.SelectedCells.Item(2).Value
        Form_cantidad_pedido.lbl_stock.Text = art.cantidad
        Form_cantidad_pedido.lbl_cant.Text = Me.DataGridView1.SelectedCells.Item(2).Value
        Form_cantidad_pedido.lbl_indice.Text = i
        Form_cantidad_pedido.lbl_idiva.Text = art.codigo_iva
        Form_cantidad_pedido.lbl_iva.Text = art.iva

        If Me.DataGridView1.SelectedCells.Item(12).Value = "1" And fact.mueve_stock = "SI" And edita = "SI" And RTrim(Form_cantidad_pedido.lbl_art_mueve_stok.Text) = "SI" Then
            Form_cantidad_pedido.lbl_stock.Text = Format(art.cantidad + Form_cantidad_pedido.txt_cantidad.Text, "0.00")
        End If

        If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Then
            Me.DataGridView1.SelectedCells.Item(12).Value = "0"
        End If

        ' si el descuento es diferente a la bonificaion de ventas la muestro
        If Val(Me.DataGridView1.SelectedCells.Item(18).Value) <> Val(Me.DataGridView1.SelectedCells.Item(26).Value) Then
            Form_cantidad_pedido.lbl_bonif_vta.Visible = True
            Form_cantidad_pedido.lbl_bonif_vta.Text = "BONIF. ESPECIAL VENTA" & "  " & Val(Me.DataGridView1.SelectedCells.Item(26).Value) & "%"
        Else
            Form_cantidad_pedido.lbl_bonif_vta.Visible = False
        End If

        Me.DataGridView1.Rows(i).Cells(12).Value = ""

        'Form_cantidad_pedido.txt_desc_rcgo.Text = ""
        Form_cantidad_pedido.Show()

    End Sub

    Private Sub Fila_verde_o_Naranja()

        'Call carga_letra_comprobante()

        art.instruccion = "select cantidad,mueve_stok,id_iva,iva from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 where id_art = '" & Me.DataGridView1.SelectedCells.Item(0).Value & "'"
        art.carga_preventa()

        Form_cantidad_pedido.lbl_stock.Text = art.cantidad
        Form_cantidad_pedido.lbl_stok_ant.Text = art.cantidad
        Form_cantidad_pedido.lbl_art_mueve_stok.Text = art.mueve_stok
        Form_cantidad_pedido.lbl_idiva.Text = art.codigo_iva
        Form_cantidad_pedido.lbl_iva.Text = art.iva

        If Me.DataGridView1.SelectedCells.Item(12).Value = "1" And RTrim(fact.mueve_stock) = "SI" And RTrim(Form_cantidad_pedido.lbl_art_mueve_stok.Text) = "SI" Then
            Form_cantidad_pedido.lbl_stock.Text = Format(art.cantidad + Val(Me.DataGridView1.SelectedCells.Item(2).Value), "0.00")
        End If

        Form_cantidad_pedido.lbl_codigo.Text = Me.DataGridView1.SelectedCells.Item(0).Value
        Form_cantidad_pedido.lbl_uni_sec.Text = Me.DataGridView1.SelectedCells.Item(24).Value
        Form_cantidad_pedido.txt_unidad_secundaria.Text = Me.DataGridView1.SelectedCells.Item(25).Value

        If Me.DataGridView1.SelectedCells.Item(21).Value = 0 Then ' si la fila esta editada no puedo modificar la cantidad
            Form_cantidad_pedido.txt_cantidad.Enabled = True
            Form_cantidad_pedido.txt_desc_rcgo.Enabled = True
        Else
            Form_cantidad_pedido.txt_cantidad.Enabled = False
        End If

        'Form_cantidad_pedido.txt_precio.Enabled = True
        'Form_cantidad_pedido.txt_precio.Focus()
        Form_cantidad_pedido.lbl_articulo.Text = Me.DataGridView1.Rows(i).Cells(1).Value
        Form_cantidad_pedido.txt_precio.Text = Me.DataGridView1.Rows(i).Cells(4).Value
        Form_cantidad_pedido.lbl_indice.Text = i
        Form_cantidad_pedido.lbl_letra.Text = Me.txt_letra.Text
        'Me.txt_letra.Text = lt
        Form_cantidad_pedido.lbl_p_siva.Text = Format(Me.DataGridView1.SelectedCells.Item(3).Value, "0.00")
        Form_cantidad_pedido.lbl_costo.Text = Format(Me.DataGridView1.SelectedCells.Item(14).Value, "0.00")
        Form_cantidad_pedido.lbl_p_civa.Text = Format(Me.DataGridView1.SelectedCells.Item(19).Value, "0.00")
        Form_cantidad_pedido.txt_cantidad.Text = Me.DataGridView1.SelectedCells.Item(2).Value
        Form_cantidad_pedido.lbl_cant.Text = Me.DataGridView1.SelectedCells.Item(2).Value
        If Val(Me.DataGridView1.SelectedCells.Item(18).Value) = 0 Then
            Form_cantidad_pedido.txt_desc_rcgo.Text = ""
            Form_cantidad_pedido.lbl_descuento.Text = ""
        Else
            Form_cantidad_pedido.txt_desc_rcgo.Text = Val(Me.DataGridView1.SelectedCells.Item(18).Value)
            Form_cantidad_pedido.lbl_descuento.Text = Val(Me.DataGridView1.SelectedCells.Item(18).Value)
        End If

        ' si el descuento es diferente a la bonificaion de ventas la muestro
        If Val(Me.DataGridView1.SelectedCells.Item(18).Value) <> Val(Me.DataGridView1.SelectedCells.Item(26).Value) Then
            Form_cantidad_pedido.lbl_bonif_vta.Visible = True
            Form_cantidad_pedido.lbl_bonif_vta.Text = "BONIF. ESPECIAL VENTA" & "  " & Val(Me.DataGridView1.SelectedCells.Item(26).Value) & "%"
        Else
            Form_cantidad_pedido.lbl_bonif_vta.Visible = False
        End If

        Me.DataGridView1.Rows(i).Cells(12).Value = "1"

        Form_cantidad_pedido.Show()

    End Sub

    Private Sub Form_factura_preventa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Form_cantidad_pedido.Dispose()
    End Sub

    Private Sub Form_factura_preventa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim x As Integer
        nom_computadora = My.Computer.Name

        Me.DataGridView1.Columns(0).Width = 80
        Me.DataGridView1.Columns(1).Width = 320
        Me.DataGridView1.Columns(2).Width = 65
        Me.DataGridView1.Columns(3).Width = 60
        Me.DataGridView1.Columns(4).Width = 60
        Me.DataGridView1.Columns(5).Width = 50
        Me.DataGridView1.Columns(11).Width = 70
        Me.DataGridView1.Columns(18).Width = 70
        Me.DataGridView1.Columns(25).Width = 70

        Me.DataGridView1.Columns(0).HeaderText = "Codigo"
        Me.DataGridView1.Columns(1).HeaderText = "Detalle"
        Me.DataGridView1.Columns(2).HeaderText = "Cantidad"
        Me.DataGridView1.Columns(4).HeaderText = "Precio"
        Me.DataGridView1.Columns(11).HeaderText = "Total"
        Me.DataGridView1.Columns(18).HeaderText = "dsc/rgo"
        Me.DataGridView1.Columns(25).HeaderText = "Peso"

        fact.carga_parametro()

        If fact.Habilita_descuento_gral = "SI" Then
            Me.Tool_txt_descuento.Enabled = True
        Else
            Me.Tool_txt_descuento.Enabled = False
        End If

        ' xx se usa para ver los articulos que no se imprimieron para ponerles *

        For x = 0 To Me.DataGridView1.Rows.Count - 1

            If (RTrim(Me.DataGridView1.Rows(x).Cells(8).Value) = "NO" Or RTrim(Me.DataGridView1.Rows(x).Cells(8).Value) = "xx") Then 'And fact.factura_en_c = "NO" Then

                Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.Orange
                Me.DataGridView1.Rows(x).Cells(12).Value = "1"

            Else

                Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.White

            End If

        Next

        edita = "NO"

    End Sub

    Private Sub tool_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_pedido.Click

        Call carga_factura()

    End Sub

    Private Sub calcula_totales_grilla()

        Dim i As Integer
        Dim exento, ins, ins_10, imp, sub_tot As Double

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Or Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange Then

                total = Format(total + Val(Me.DataGridView1.Rows(i).Cells(11).Value), "0.00")
                exento = Format(exento + Val(Me.DataGridView1.Rows(i).Cells(7).Value), "0.00")

                selecciona_valor_impuesto(1)

                If Val(Me.DataGridView1.Rows(i).Cells(5).Value) = porcentaje_impuesto Then ' 21%
                    ins = Format(ins + Val(Me.DataGridView1.Rows(i).Cells(9).Value), "0.00")
                    neto_21 = Format(neto_21 + Val(Me.DataGridView1.Rows(i).Cells(10).Value), "0.00")
                End If

                selecciona_valor_impuesto(2)

                If Val(Me.DataGridView1.Rows(i).Cells(5).Value) = porcentaje_impuesto Then '10.5 %
                    ins_10 = Format(ins_10 + Val(Me.DataGridView1.Rows(i).Cells(9).Value), "0.00")
                    neto_10 = Format(neto_10 + Val(Me.DataGridView1.Rows(i).Cells(10).Value), "0.00")
                End If

                imp = Format(imp + Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.000")

                ' si es cantidad hago esto y si es unidad secundaria lo otro
                If Trim(Me.DataGridView1.Rows(i).Cells(24).Value) = "NO" Then
                    sub_tot = Format(sub_tot + (Val(Me.DataGridView1.Rows(i).Cells(3).Value) * Val(Me.DataGridView1.Rows(i).Cells(2).Value)), "0.00")
                Else
                    sub_tot = Format(sub_tot + (Val(Me.DataGridView1.Rows(i).Cells(3).Value) * Val(Me.DataGridView1.Rows(i).Cells(25).Value)), "0.00")
                End If

                'sub_tot = Format(total - exento - ins - ins_10 - imp, "0.00")

            End If

            If i = Me.DataGridView1.Rows.Count - 1 Then
                sub_tot = Format(sub_tot - exento, "0.00")
            End If

        Next

        Try

            ' si tiene un descuento hago lo siguiente
            If Me.Tool_txt_descuento.Text <> "" And Val(Me.Tool_txt_descuento.Text) > 0 Then
                total = total - (total * Me.Tool_txt_descuento.Text) / 100
                sub_tot = sub_tot - (sub_tot * Me.Tool_txt_descuento.Text) / 100
                ins = ins - (ins * Me.Tool_txt_descuento.Text) / 100
                ins_10 = ins_10 - (ins_10 * Me.Tool_txt_descuento.Text) / 100
                exento = exento - (exento * Me.Tool_txt_descuento.Text) / 100
                imp = imp - (imp * Me.Tool_txt_descuento.Text) / 100
            End If

        Catch ex As Exception

        End Try

        'Me.txt_total_grilla.Text = total
        Me.txt_exento.Text = exento
        Me.txt_inscripto.Text = ins
        Me.txt_insc_10.Text = ins_10
        Me.txt_imp_interno_grilla.Text = imp
        Me.txt_gravado.Text = sub_tot

        'sub_tot = Format(total - ins - ins_10 - imp - exento, "0.00")
        Me.txt_total_grilla.Text = Format(sub_tot + ins + ins_10 + imp + exento, "0.00")

        tal.instruccion = "update fact_tot set total = '" & total & "', iva_ins = '" & ins & "',iva_10 = '" & ins_10 & "', exento= '" & exento & "', imp_interno1 = '" & imp & "',sub_total = '" & sub_tot & "',descuento = '" & Val(Me.Tool_txt_descuento.Text) & "' where tipo_factura ='PD' and num_factura = '" & RTrim(Me.txt_numero.Text) & "' and  pref = '" & RTrim(Me.txt_prefijo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and talon2 = '" & RTrim(Me.txt_talon.Text) & "'"
        tal.actualizar()

        tal.instruccion = "update fact_tot set total = '" & total & "', iva_ins = '" & ins & "',iva_10 = '" & ins_10 & "', exento= '" & exento & "', imp_interno1 = '" & imp & "',sub_total = '" & sub_tot & "',descuento = '" & Val(Me.Tool_txt_descuento.Text) & "' where tipo_factura ='FC' and num_factura = '" & RTrim(Me.txt_numero.Text) & "' and  pref = '" & RTrim(Me.txt_prefijo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and talon2 = '" & RTrim(Me.txt_talon.Text) & "'"
        tal.actualizar()

    End Sub

    Private Sub selecciona_valor_impuesto(ByVal cod As Integer)

        Dim tb_ivaa As New DataTable
        tb_ivaa.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select iva_insc,id_iva from iva_01 where id_iva = '" & RTrim(cod) & "'", conex)
        comando.Fill(tb_ivaa)
        comando.Dispose()

        If tb_ivaa.Rows.Count > 0 Then
            porcentaje_impuesto = Trim(tb_ivaa.Rows(0).Item(0))
        End If

        tb_ivaa.Dispose()

    End Sub

    Private Sub form_factura_preventa_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Form_login.verifica = True
        Form_login.act_stk(nom_computadora)

    End Sub

    Private Sub asigna_fila_nuevos()

        Dim tb_fila As New DataTable
        Dim fila_nueva As Integer

        tb_fila.Clear()

        comando = New SqlDataAdapter("select max(fila) from fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 ='" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = 'PD' and letra_fact1 = '" & RTrim(lt) & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "'", conex)
        comando.Fill(tb_fila)
        comando.Dispose()

        fila_nueva = tb_fila.Rows(0).Item(0) + 1

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If Trim(Me.DataGridView1.Rows(i).Cells(23).Value) = "" Then

                Me.DataGridView1.Rows(i).Cells(23).Value = fila_nueva
                fila_nueva = fila_nueva + 1

            End If

        Next

        tb_fila.Dispose()

    End Sub

    Private Sub actualiza_a_factura_pc()

        Dim i As Integer
        Dim es_factura = "", es_factura1 = "", es_factura2 As String = ""
        Dim tabla As New DataTable, tabla1 As New DataTable

        lt = Me.txt_letra.Text

        conex = conecta()

        ' aca le asigno filas a los articulos nuevos cargados en la consulta de pedido
        Call asigna_fila_nuevos()

        tabla_fact.Clear()

        comando = New SqlDataAdapter("select codi_producto,detalle from fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 ='" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = 'PD' and letra_fact1 = '" & RTrim(lt) & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and cantidad_sin_stock = 'NO'", conex)
        comando.Fill(tabla_fact)
        comando.Dispose()

        ' actualizo la hora en la cabecera

        tal.instruccion = "update fact_cab set hora = '" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "' where tipo_fact ='PD' and num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and  prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact = '" & RTrim(lt) & "' and talon = '" & RTrim(Me.txt_talon.Text) & "'"
        tal.actualizar()

        ' carga e imprime pedido con stok

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White Then

                comando = New SqlDataAdapter("select * from fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 ='" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = 'PD' and letra_fact1 = '" & RTrim(lt) & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "'", conex)
                comando.Fill(tabla1)

                If tabla1.Rows.Count = Nothing Then

                    tal.instruccion = "INSERT INTO fact_det(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,nom_producto,vend1,costo,cod_prov,cod_rub,val_uni_sec) VALUES('" & Me.txt_fecHA_emi.Text & "','" & Me.txt_numero.Text & "' ,'" & Me.txt_tipo.Text & "', '" & Me.txt_prefijo.Text & "','" & lt & "','" & Val(Me.DataGridView1.Rows(i).Cells(0).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','','" & Me.DataGridView1.Rows(i).Cells(9).Value & "','" & Me.DataGridView1.Rows(i).Cells(6).Value & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(19).Value & "','" & Me.DataGridView1.Rows(i).Cells(11).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "', '" & Me.DataGridView1.Rows(i).Cells(3).Value & "', '" & Me.txt_cod_lis.Text & "','" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & Me.txt_talon.Text & "','SI','" & Me.DataGridView1.Rows(i).Cells(23).Value & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.txt_vendedor.Text & "','" & Me.DataGridView1.Rows(i).Cells(15).Value & "','" & Me.DataGridView1.Rows(i).Cells(16).Value & "','" & Me.DataGridView1.Rows(i).Cells(17).Value & "','" & Me.DataGridView1.Rows(i).Cells(25).Value & "')"
                    tal.actualizar()

                    'tal.instruccion = "update fact_det set cantidad_sin_stock = 'SI',cantidad1 = '" & Me.DataGridView1.Rows(i).Cells(2).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(lt) & "' and codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and fila = '" & Me.DataGridView1.Rows(i).Cells(23).Value & "'"
                    'tal.actualizar()

                    Me.DataGridView1.Rows(i).Cells(8).Value = "SI"

                End If

                es_factura = "NO"
                tabla1.Clear()

            End If

            If (Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Or Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange) And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = "NO" Then

                comando = New SqlDataAdapter("select * from fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 ='" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = 'PD' and letra_fact1 = '" & RTrim(lt) & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and fila ='" & Trim(Me.DataGridView1.Rows(i).Cells(23).Value) & "'", conex)
                comando.Fill(tabla1)
                comando.Dispose()

                Dim x As String = Me.DataGridView1.Rows(i).Cells(18).Value

                If tabla1.Rows.Count = Nothing Then

                    tal.instruccion = "INSERT INTO fact_det(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,nom_producto,vend1,costo,cod_prov,cod_rub,val_uni_sec) VALUES('" & Me.txt_fecHA_emi.Text & "','" & Me.txt_numero.Text & "' ,'" & Me.txt_tipo.Text & "', '" & Me.txt_prefijo.Text & "','" & lt & "','" & Val(Me.DataGridView1.Rows(i).Cells(0).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','" & Me.DataGridView1.Rows(i).Cells(18).Value & "','" & Me.DataGridView1.Rows(i).Cells(9).Value & "','" & Me.DataGridView1.Rows(i).Cells(6).Value & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Me.DataGridView1.Rows(i).Cells(11).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "', '" & Me.DataGridView1.Rows(i).Cells(19).Value & "', '" & Me.txt_cod_lis.Text & "','" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & Me.txt_talon.Text & "','NO','" & Trim(Me.DataGridView1.Rows(i).Cells(23).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.txt_vendedor.Text & "','" & Me.DataGridView1.Rows(i).Cells(15).Value & "','" & Me.DataGridView1.Rows(i).Cells(16).Value & "','" & Me.DataGridView1.Rows(i).Cells(17).Value & "','" & Me.DataGridView1.Rows(i).Cells(25).Value & "')"
                    tal.actualizar()

                    tal.instruccion = "delete act_art where codart = '" & Me.DataGridView1.Rows(i).Cells(0).Value & "' and tipo = '" & Me.txt_tipo.Text & "' and lt = '" & lt & "' and pre = '" & Me.txt_prefijo.Text & "' and numero = '" & Me.txt_numero.Text & "' and talonario = '" & Me.txt_talon.Text & "' and computer = '" & nom_computadora & "'"
                    tal.actualizar()

                    Me.DataGridView1.Rows(i).Cells(8).Value = "NO"
                    es_factura1 = "SI"

                Else

                    tal.instruccion = "update fact_det set cantidad1 = '" & Me.DataGridView1.Rows(i).Cells(2).Value & "',precio_unidad = '" & Me.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Me.DataGridView1.Rows(i).Cells(19).Value & "',iva1 = '" & Me.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Me.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Me.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Me.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Me.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Me.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Me.DataGridView1.Rows(i).Cells(18).Value & "',cantidad_sin_stock ='NO',val_uni_sec = '" & Me.DataGridView1.Rows(i).Cells(25).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(lt) & "' and codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and fila ='" & Me.DataGridView1.Rows(i).Cells(23).Value & "'"
                    tal.actualizar()

                    Me.DataGridView1.Rows(i).Cells(8).Value = "NO"
                    es_factura1 = "SI"

                End If

                tabla1.Clear()

            End If

            If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Or Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange And RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = "SI" Then

                comando = New SqlDataAdapter("select * from fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 ='" & RTrim(Me.txt_prefijo.Text) & "' and tipo_fact2 = 'PD' and letra_fact1 = '" & RTrim(lt) & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and fila ='" & Trim(Me.DataGridView1.Rows(i).Cells(23).Value) & "'", conex)
                comando.Fill(tabla1)
                comando.Dispose()

                If tabla1.Rows.Count = Nothing Then

                    tal.instruccion = "INSERT INTO fact_det(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,nom_producto,vend1,costo,cod_prov,cod_rub,val_uni_sec) VALUES('" & Me.txt_fecHA_emi.Text & "','" & Me.txt_numero.Text & "' ,'" & Me.txt_tipo.Text & "', '" & Me.txt_prefijo.Text & "','" & lt & "','" & Val(Me.DataGridView1.Rows(i).Cells(0).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','','" & Me.DataGridView1.Rows(i).Cells(9).Value & "','" & Me.DataGridView1.Rows(i).Cells(6).Value & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Me.DataGridView1.Rows(i).Cells(11).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "', '" & Me.DataGridView1.Rows(i).Cells(19).Value & "', '" & Me.txt_cod_lis.Text & "','" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & Me.txt_talon.Text & "','SI','" & Trim(Me.DataGridView1.Rows(i).Cells(23).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.txt_vendedor.Text & "','" & Me.DataGridView1.Rows(i).Cells(15).Value & "','" & Me.DataGridView1.Rows(i).Cells(16).Value & "','" & Me.DataGridView1.Rows(i).Cells(17).Value & "','" & Me.DataGridView1.Rows(i).Cells(25).Value & "')"
                    tal.actualizar()

                    es_factura2 = "SI"

                End If

            End If

            tabla1.Clear()

        Next

        If RTrim(es_factura) = "NO" Then

            Dim ax As Integer = MessageBox.Show("Imprime Nota Pedido!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If ax = 6 Then

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                coman = New SqlCommand("update fact_det set asterisco = '*' where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & lt & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and cantidad_sin_stock ='NO'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()
                conex.Close()

                fact.numero_factura = Me.txt_numero.Text
                fact.letra_fact = lt
                fact.prefijo_factura = Me.txt_prefijo.Text
                fact.tipo_fact = Me.txt_tipo.Text
                fact.cantidad_sin_stock = "NO"
                fact.form_txt_letra = Me.txt_letra.Text
                fact.imprimir_pedido()

            Else

                For i = 0 To Me.DataGridView1.Rows.Count - 1

                    For j = 0 To tabla_fact.Rows.Count - 1

                        If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = RTrim(tabla_fact.Rows(j).Item(0)) Then

                            cont = cont + 1

                            If cont = tabla_fact.Rows.Count Then

                                tal.instruccion = "update fact_det set cantidad_sin_stock = 'NO' where codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num_fact = '" & Me.txt_numero.Text & "' and tipo_fact2 = '" & Me.txt_tipo.Text & "' and prefijo_fact2 = '" & Me.txt_prefijo.Text & "' and letra_fact1 = '" & lt & "' and talon1 = '" & Me.txt_talon.Text & "' and fila = '" & Me.DataGridView1.Rows(i).Cells(23).Value & "'"
                                tal.actualizar()

                            End If

                        End If

                    Next

                    cont = 0

                Next

                cont = 0

            End If

            form_factura.borra_tabla_art_act(My.Computer.Name)

            conex.Close()
            tabla.Dispose()
            tabla1.Dispose()
            Me.Dispose()
            Form_muestra_cons_comp.carga_seleccion_cosulta()
            Exit Sub

        End If

        If RTrim(es_factura1) = "SI" Or RTrim(es_factura2) = "SI" Then

            az = MessageBox.Show("Imprime Factura!!!", "PyMsoft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If az = 6 Or az = 7 Then

                Dim tb_1 As New DataTable
                tb_1.Clear()

                conex = conecta()

                comando = New SqlDataAdapter("select detalle,asterisco,codi_producto,fila,costo from fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & lt & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "'", conex)
                comando.Fill(tb_1)
                comando.Dispose()

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                End If

                For i = 0 To tb_1.Rows.Count - 1

                    If RTrim(tb_1.Rows(i).Item(1).ToString) = Nothing Then

                        coman = New SqlCommand("update fact_det set detalle = '" & "  **  " & "  " & tb_1.Rows(i).Item(0) & "' where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & lt & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and codi_producto = '" & RTrim(tb_1.Rows(i).Item(2)) & "' and fila = '" & RTrim(tb_1.Rows(i).Item(3)) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                Next

                If conex.State = ConnectionState.Open Then
                    conex.Close()
                    tb_1.Dispose()
                End If

            End If

                If az <> 2 Then

                Call carga_letra_comprobante()

                ' abre numeradores para actualizar numeros de factura en blanco o en negro
                Call verifica_recibo_cta()
                form_factura.borra_tabla_art_act(My.Computer.Name)
                Form_numerador.Show()
                Exit Sub

            End If

        End If

        Dim y As Integer = MessageBox.Show("Imprime Nota Pedido!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If y = 6 Then

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
            End If

            coman = New SqlCommand("update fact_det set asterisco = '*' where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & lt & "' and talon1 = '" & RTrim(Me.txt_talon.Text) & "' and cantidad_sin_stock ='NO'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If

            fact.numero_factura = Me.txt_numero.Text
                fact.letra_fact = lt
                fact.prefijo_factura = Me.txt_prefijo.Text
                fact.tipo_fact = Me.txt_tipo.Text
                fact.cantidad_sin_stock = "NO"
                fact.form_txt_letra = Me.txt_letra.Text
                fact.imprimir_pedido()

                form_factura.borra_tabla_art_act(My.Computer.Name)

                conex.Close()
                tabla.Dispose()
                tabla1.Dispose()
                Me.Dispose()
                Form_muestra_cons_comp.carga_seleccion_cosulta()
                Exit Sub

            Else

                For i = 0 To Me.DataGridView1.Rows.Count - 1

                For j = 0 To tabla_fact.Rows.Count - 1

                    If RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) = RTrim(tabla_fact.Rows(j).Item(0)) Then

                        cont = cont + 1

                        If cont = tabla_fact.Rows.Count Then

                            tal.instruccion = "update fact_det set cantidad_sin_stock = 'NO' where codi_producto = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value) & "' and num_fact = '" & Me.txt_numero.Text & "' and tipo_fact2 = '" & Me.txt_tipo.Text & "' and prefijo_fact2 = '" & Me.txt_prefijo.Text & "' and letra_fact1 = '" & lt & "' and talon1 = '" & Me.txt_talon.Text & "' and fila ='" & RTrim(Me.DataGridView1.Rows(i).Cells(23).Value) & "'"
                            tal.actualizar()

                        End If

                    End If

                Next

                cont = 0

            Next

            cont = 0

        End If

        form_factura.borra_tabla_art_act(My.Computer.Name)

        conex.Close()
        tabla.Dispose()
        tabla1.Dispose()
        Me.Dispose()
        Form_muestra_cons_comp.carga_seleccion_cosulta()

    End Sub

    Private Sub carga_letra_comprobante()

        If fact.imprime_tikets = "SI" Then
            lt = Me.txt_letra.Text
            Me.txt_letra.Text = "C"
        Else
            lt = Me.txt_letra.Text
        End If

        If fact.factura_en_c = "NO" Then
            carga_tipo_cliente()
            If RTrim(tipo_iva) = "Responsable Inscripto" Or RTrim(tipo_iva) = "Monotributo" Then
                lt = Me.txt_letra.Text
                Me.txt_letra.Text = "A"
            Else
                lt = Me.txt_letra.Text
                Me.txt_letra.Text = "B"
            End If
        End If

    End Sub


    Private Sub carga_factura()


        'Call carga_letra_comprobante()
        Call calcula_totales_grilla()

        total = 0

        If Me.txt_total_grilla.Text = "" Or Me.txt_total_grilla.Text = "0" Then
            MessageBox.Show("No hay ningun pedido finalizado", "PyMsoft", MessageBoxButtons.OK)
            Exit Sub
        End If

        If RTrim(Me.txt_letra.Text) = "A" Then

            Call actualiza_a_factura_pc()

        End If

        If RTrim(Me.txt_letra.Text) = "B" Then

            Call actualiza_a_factura_pc()

        End If

        If RTrim(Me.txt_letra.Text) = "C" Then

            Call actualiza_a_factura_pc()

        End If

    End Sub

    Private Sub carga_tipo_cliente()

        Dim tb_cli As New DataTable
        conex = conecta()

        comando = New SqlDataAdapter("select tipo_iva from cli_01 where id_cli = '" & RTrim(Me.txt_cod_cli.Text) & "'", conex)
        comando.Fill(tb_cli)
        comando.Dispose()

        tipo_iva = tb_cli.Rows(0).Item(0)

        tb_cli.Dispose()

    End Sub

    Private Sub elimina_fila(ByVal pos_db As Integer, ByVal pos_grid As Integer)

        Dim tb As New DataTable, tb1 As New DataTable, tbl1 As New DataTable
        Dim cantidad As Double
        Dim i As Integer

        Dim z As Integer = MessageBox.Show("Elimina articulo de todos los pedidos!!", "PymSoft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If z = 2 Then Exit Sub

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        If z = 7 Then   ' borra solo este pedido

            If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.LightGreen Or Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.Orange Then

                comando = New SqlDataAdapter("select sum(cantidad) from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "'", conex)
                comando.Fill(tb)
                comando.Dispose()

                cantidad = tb.Rows(0).Item(0) + Me.DataGridView1.Rows(pos).Cells(2).Value

                coman = New SqlCommand("update art_01 set cantidad = '" & cantidad & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()
                tb.Dispose()

                If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.LightGreen Then

                    form_factura.act_falla_stk(Me.DataGridView1, nom_computadora, pos)

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and fila = '" & pos_db & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

                If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.Orange Then

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and fila = '" & pos_db & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            End If

            If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor <> Color.LightGreen Or Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor <> Color.Orange Then

                coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and fila = '" & pos_db & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()

            End If

        End If

        If z = 6 Then     'borra todo

            If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.LightGreen Or Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.Orange Then

                comando = New SqlDataAdapter("select cantidad from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "'", conex)
                comando.Fill(tb1)
                comando.Dispose()

                cantidad = tb1.Rows(0).Item(0)

                comando = New SqlDataAdapter("select cantidad1 from fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and tipo_fact2 = 'PD'", conex)
                comando.Fill(tbl1)
                comando.Dispose()

                For i = 0 To tbl1.Rows.Count - 1
                    cantidad = cantidad + tbl1.Rows(i).Item(0)
                Next

                coman = New SqlCommand("update art_01 set cantidad = '" & cantidad & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()
                tb1.Dispose()

                If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.LightGreen Then

                    form_factura.act_falla_stk(Me.DataGridView1, nom_computadora, pos)

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and tipo_fact2 = 'PD' and cantidad_sin_stock ='NO'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

                If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor = Color.Orange Then

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and tipo_fact2 = 'PD' and cantidad_sin_stock ='NO'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            End If

            If Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor <> Color.LightGreen Or Me.DataGridView1.Rows(pos).DefaultCellStyle.BackColor <> Color.Orange Then

                If fact.mueve_stock = "SI" Then

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and tipo_fact2 = 'PD' and cantidad_sin_stock ='SI'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                Else

                    coman = New SqlCommand("delete fact_det where codi_producto = '" & RTrim(Me.DataGridView1.Rows(pos).Cells(0).Value) & "' and tipo_fact2 = 'PD'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            End If

        End If

        Dim articulo As String = Trim(Me.DataGridView1.Rows(pos_grid).Cells(0).Value)

        For i = 0 To Me.DataGridView1.Rows.Count - 1
            If Trim(articulo) = Trim(Me.DataGridView1.Rows(i).Cells(0).Value) Then
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))
                Me.DataGridView1.Refresh()
                i = i - 1
            End If
        Next
        

        If Me.DataGridView1.Rows(0).Cells(0).Value = Nothing Then

            Dim e As Integer = MessageBox.Show("Quiere Eliminar el Pedido!!", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If e = 6 Then

                coman = New SqlCommand("delete fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and talon1 = '" & Me.txt_talon.Text & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()

                coman = New SqlCommand("delete fact_cab where num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact = '" & RTrim(Me.txt_tipo.Text) & "' and talon = '" & Me.txt_talon.Text & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()

                coman = New SqlCommand("delete fact_tot where num_factura = '" & RTrim(Me.txt_numero.Text) & "' and pref = '" & RTrim(Me.txt_prefijo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and tipo_factura = '" & RTrim(Me.txt_tipo.Text) & "' and talon2 = '" & Me.txt_talon.Text & "'", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()
                conex.Close()

                Me.Dispose()

            End If

        End If

        conex.Close()

    End Sub

    Private Sub tool_quita_art_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_quita_art.Click

        Try

            pos = Me.DataGridView1.CurrentCell.RowIndex   ' fila actual
            fila_en_db = Me.DataGridView1.SelectedCells(23).Value
            Call elimina_fila(fila_en_db, pos)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Tool_borra_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_borra_pedido.Click

        'If Me.DataGridView1.Rows.Count = Nothing Then

        Dim q As Integer = MessageBox.Show("Quiere Eliminar el Pedido!!", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If q = 6 Then

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("delete fact_det where num_fact = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact2 = '" & RTrim(Me.txt_tipo.Text) & "' and talon1 = '" & Me.txt_talon.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()

            coman = New SqlCommand("delete fact_cab where num_fact1 = '" & RTrim(Me.txt_numero.Text) & "' and prefijo_fact = '" & RTrim(Me.txt_prefijo.Text) & "' and letra_fact = '" & RTrim(Me.txt_letra.Text) & "' and tipo_fact = '" & RTrim(Me.txt_tipo.Text) & "' and talon = '" & Me.txt_talon.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()

            coman = New SqlCommand("delete fact_tot where num_factura = '" & RTrim(Me.txt_numero.Text) & "' and pref = '" & RTrim(Me.txt_prefijo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and tipo_factura = '" & RTrim(Me.txt_tipo.Text) & "' and talon2 = '" & Me.txt_talon.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()
            conex.Close()

            Dim can As Single
            Dim i As Integer

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                If RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = "NO" Or RTrim(Me.DataGridView1.Rows(i).Cells(8).Value) = "xx" Then

                    If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange Then

                        art.instruccion = "select cantidad from art_01 where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                        art.carga_preventa()
                        can = art.cantidad

                        can = can + Me.DataGridView1.Rows(i).Cells(2).Value

                        art.instruccion = "update art_01 set cantidad = '" & can & "',cant_ant= '" & can & "' where id_art = '" & RTrim(Me.DataGridView1.Rows(i).Cells(0).Value & "'")
                        art.actualizar()

                        can = 0

                    End If

                End If

            Next

            Form_muestra_cons_comp.carga_seleccion_cosulta()
            Me.Dispose()

        End If

    End Sub

    Private Sub Tool_agerga_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_agerga_item.Click

        Call agrega_articulo()

    End Sub

    Private Sub agrega_articulo()

        If Me.DataGridView1.Rows.Count = fact.cantidad_item_factura Then
            MessageBox.Show("No se pueden agregar mas articulos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        fila = Me.DataGridView1.Rows.Count
        busc_articulos.txt_lista.Text = Me.txt_cod_lis.Text
        busc_articulos.txt_estado_form.Text = 1
        busc_articulos.Show()

    End Sub

    Private Sub verifica_recibo_cta()

        Try

            tb_reccta.Clear()

            comando = New SqlDataAdapter("select * from cta_cte01 where id_cta = '" & Me.txt_cod_cli.Text & "' and tc ='RA'", conex)
            comando.Fill(tb_reccta)

            Dim x As String = tb_reccta.Rows(0).Item(0)

            MessageBox.Show("Este Cliente tiene un Recibo a cuenta !!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Tool_txt_descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tool_txt_descuento.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class