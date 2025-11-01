Public Class busc_articulos

    Dim art As New pymsoft.articulo
    Dim fact As New pymsoft.factura
    Public entra As Boolean = False

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.txt_articulos.Text <> "" Then
            art.buscar(Me.txt_lista.Text)
        End If

    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()
        form_factura.txt_cierra_form.Text = 1

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                If Form_lista_oferta.txt_estado_form.Text = 1 Then

                    Call carga_codigo_seguimiento(Me.DataGridView1.SelectedCells(0).Value, Form_lista_oferta.txt_lista.Text)

                End If

                If Form_seguimiento_art.txt_estado_form.Text = 1 Then

                    Call carga_codigo_seguimiento(Me.DataGridView1.SelectedCells(0).Value, 1)

                End If

                If Form_inventario.txt_estado_form.Text = 1 Then

                    Call carga_codigo_seguimiento(Me.DataGridView1.SelectedCells(0).Value, 1)

                End If

                If form_factura.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

                If Form_articulos.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

                If Form_ventas_agrupacion.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

                If Form_factura_preventa.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

                If Form_presupuesto.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

                If Form_rep_etiquetas.txt_estado_form.Text = 1 Then

                    Call carga_codigo_seguimiento(Me.DataGridView1.SelectedCells(0).Value, Me.txt_lista.Text)

                End If

                If Form_rotulo_balanza.txt_estado_form.Text = 1 Then

                    Call carga_ultima_busqueda(Me.DataGridView1.SelectedCells(0).Value)

                End If

            End If

        Catch ex As Exception

        Finally

        End Try

    End Sub

    Private Sub busc_articulos_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If form_factura.txt_estado_form.Text = 1 Then form_factura.txt_cierra_form.Text = 1
    End Sub

    Private Sub busc_articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.opt_texto.Checked = True
        'Me.cmb_tipo_busc.Text = Me.cmb_tipo_busc.Items(0)
        If form_factura.txt_estado_form.Text = 1 Then form_factura.txt_cierra_form.Text = 2

    End Sub

    Public Sub carga_codigo_seguimiento(ByVal codigo As Integer, ByVal lista As Integer)

        art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,stock_corte,fec_modi,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 like '" & codigo & "' and art_precio.id_lista1 = '" & lista & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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
        art.codigo_12 = "stock_corte"
        art.codigo_13 = "fec_modi"
        art.codigo_14 = "id_iva"
        art.codigo_15 = "utilidad"
        art.codigo_16 = "id_proveedor"
        art.codigo_17 = "id_rubro"
        art.codigo_18 = "unidad_secundaria"
        art.codigo_19 = "peso_promedio"
        art.codigo_20 = "bonif_vta"

        art.cargar()

        If Form_lista_oferta.txt_estado_form.Text = 1 Then

            Form_lista_oferta.DataGridView1.Rows.Add()

            Dim i As Integer = Form_lista_oferta.DataGridView1.Rows.Count - 2

            Form_lista_oferta.DataGridView1.Rows(i).Cells(0).Value = art.nombre
            Form_lista_oferta.DataGridView1.Rows(i).Cells(1).Value = art.precio_civa

            If art.bonificacion_ventas <> 0 Then
                Form_lista_oferta.DataGridView1.Rows(i).Cells(2).Value = art.precio_civa - ((art.precio_civa * art.bonificacion_ventas) / 100)
            End If

            Form_lista_oferta.txt_art.Focus()

        End If

        If Form_seguimiento_art.txt_estado_form.Text = 1 Then

            Form_seguimiento_art.txt_codigo.Text = art.codigo
            Form_seguimiento_art.lbl_articulo.Text = art.nombre
            Form_seguimiento_art.dt_fec_emi.Text = art.codigo_barra
            Form_seguimiento_art.dt_fec_emi.Focus()

        End If

        If Form_ventas_agrupacion.txt_estado_form.Text = 1 Then

            Form_ventas_agrupacion.cmd_acepta1.Focus()

        End If

        If Form_inventario.txt_estado_form.Text = 1 Then

            Form_inventario.txt_codigo.Text = art.codigo
            Form_inventario.lbl_articulo.Text = art.nombre
            Form_inventario.stk_actual.Text = art.cantidad
            Form_inventario.txt_stk_ant.Text = art.costo
            Form_inventario.dt_fec_corte.Text = art.codigo_barra
            Form_inventario.txt_stk_ant.Enabled = True
            Form_inventario.txt_stk_ant.Focus()

        End If

        If Form_rep_etiquetas.txt_estado_form.Text = 1 Then

            Form_rep_etiquetas.cmb_desde.Text = art.codigo
            Form_rep_etiquetas.lbl_articulo.Text = art.nombre
            Form_rep_etiquetas.cmb_hasta.Text = art.codigo
            Form_rep_etiquetas.cmb_hasta.Focus()

        End If

        Me.Dispose()

    End Sub

    Private Sub txt_articulos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_articulos.KeyUp

        Try

            If Me.txt_articulos.Text <> "" Then
                art.buscar(Me.txt_lista.Text)
                form_factura.txt_ultima_busqueda.Text = Me.txt_articulos.Text
            Else
                Me.DataGridView1.DataSource = Nothing
                Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
                Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            End If

            If e.KeyCode = Keys.Return Then

                If Me.txt_articulos.Text = "" Then
                    Me.txt_articulos.Focus()
                    Exit Sub
                End If

                Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
                Me.DataGridView1.Focus()

            End If

            If e.KeyCode = Keys.F5 Then
                art.buscar_ultima_busqueda(Me.txt_lista.Text)
                Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
                Me.DataGridView1.Focus()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carga_ultima_busqueda(ByVal valor)

        If Form_articulos.txt_estado_form.Text = 1 Then

            art.instruccion = "select id_art1,id_lista1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_lista1 = '" & Form_articulos.txt_lista.Text & "' and art_precio.id_art1 = '" & Me.DataGridView1.SelectedCells(0).Value & "' and art_01.nombre = art_precio.nom"
            art.mostrar_datos()

            If art.verifica_campos = 0 Then

                Form_articulos.txt_codigo.Text = art.codigo
                Form_articulos.txt_interno.Text = art.codigo
                Form_articulos.txt_nombre.Text = art.descripcion
                Form_articulos.txt_rubro.Text = art.codigo_rubro
                Form_articulos.lbl_rubro.Text = art.nombre_rubro
                Form_articulos.txt_codigo_barra.Text = art.codigo_barra
                Form_articulos.txt_cantidad_bulto.Text = art.cantidad_bulto
                Form_articulos.txt_cantidad.Text = art.cantidad
                Form_articulos.txt_costo.Text = art.costo
                Form_articulos.lbl_tipo_iva.Text = art.iva
                Form_articulos.txt_codigo_iva.Text = art.codigo_iva
                Form_articulos.txt_impuestos_internos.Text = art.codigo_impuestos_internos
                Form_articulos.lbl_nom_imp_int.Text = art.impuestos_internos
                Form_articulos.txt_proveedor.Text = art.codigo_proveedor
                Form_articulos.lbl_proveedor.Text = art.nombre_proveedor
                Form_articulos.txt_utilidad.Text = art.uilidad
                Form_articulos.txt_precio_siva.Text = art.precio_siva
                Form_articulos.txt_precio_civa.Text = art.precio_civa
                Form_articulos.cmb_mueve_stok.Text = art.mueve_stok
                Form_articulos.txt_inputacion_compras.Text = art.codigo_compras
                Form_articulos.lbl_input_compras.Text = art.nombre_compras
                Form_articulos.txt_inputacion_ventas.Text = art.codigo_ventas
                Form_articulos.lbl_input_ventas.Text = art.nombre_ventas
                Form_articulos.dt_fec_alta.Text = art.fecha_alta
                Form_articulos.dt_fec_modificacion.Text = art.fecha_modificacion
                Form_articulos.cmb_estado.Text = art.estado
                Form_articulos.txt_descuento1.Text = art.descuento1
                Form_articulos.txt_descuento2.Text = art.descuento2
                Form_articulos.txt_descuento3.Text = art.descuento3
                Form_articulos.txt_flete.Text = art.flete
                Form_articulos.txt_pago_total.Text = art.pago_total
                Form_articulos.cmb_unid_med_secundaria.Text = art.unidad_secundaria
                Form_articulos.txt_peso_promedio.Text = art.peso_promedio
                Form_articulos.txt_bonif_ventas.Text = art.bonificacion_ventas

                Form_articulos.cmd_aceptar.Enabled = False
                Form_articulos.cmd_aceptar.BackColor = Color.LightGray
                Form_articulos.cmd_eliminar.Enabled = True
                Form_articulos.cmd_eliminar.BackColor = Color.Black
                Form_articulos.cmd_modificar.Enabled = True
                Form_articulos.cmd_modificar.BackColor = Color.Black
                Form_articulos.cmd_copiar.Enabled = True
                Form_articulos.cmd_copiar.BackColor = Color.Black

                If Val(Form_articulos.txt_codigo_iva.Text) = "1" Then
                    'Form_articulos.lbl_nombre_iva.Text = " % " & "Resp.Insc"
                    Form_articulos.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleRight
                End If
                If Val(Form_articulos.txt_codigo_iva.Text) = "2" Then
                    'Form_articulos.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
                    Form_articulos.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleRight
                End If
                If Val(Form_articulos.txt_codigo_iva.Text) = "3" Then
                    'Form_articulos.lbl_nombre_iva.Text = " % " & "Exento"
                    Form_articulos.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleRight
                End If

                Form_articulos.txt_nombre.Focus()
                Me.Close()

            End If

        End If

        If Form_ventas_agrupacion.txt_estado_form.Text = 1 Then

            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.DataGridView1.SelectedCells(0).Value & "' and art_precio.id_lista1 = '" & Me.txt_lista.Text & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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

                Form_ventas_agrupacion.txt_articulo.Text = art.codigo
                Form_ventas_agrupacion.lbl_nombre_articulo.Text = art.nombre
                Form_ventas_agrupacion.cmb_modalidad.Focus()

                Me.Close()
                Exit Sub

            End If

        End If

        If Form_factura_preventa.txt_estado_form.Text = 1 Then

            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & valor & "' and art_precio.id_lista1 = '" & RTrim(Form_factura_preventa.txt_cod_lis.Text) & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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

                Form_factura_preventa.DataGridView1.Rows.Add()

                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(0).Value = art.codigo
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(1).Value = art.nombre
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(3).Value = art.precio_siva
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(4).Value = art.precio_civa
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(5).Value = art.iva
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(6).Value = art.impuestos_internos
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(7).Value = art.exento
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(8).Value = "NO"
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(14).Value = art.costo
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(16).Value = art.proveedor
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(17).Value = art.rubro
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(19).Value = art.precio_civa
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(20).Value = 1
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(22).Value = art.precio_siva
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(24).Value = art.unidad_secundaria
                Form_factura_preventa.DataGridView1.Rows(Form_factura_preventa.fila).Cells(25).Value = Val(art.peso_promedio)
                Form_factura_preventa.txt_mueve_stock.Text = art.mueve_stok

                Form_cantidad_pedido.i = Form_factura_preventa.DataGridView1.Rows.Count - 1
                entra = True

                Form_cantidad_pedido.lbl_articulo.Text = art.nombre
                Form_cantidad_pedido.lbl_codigo.Text = art.codigo
                Form_cantidad_pedido.txt_precio.Text = art.precio_civa
                Form_cantidad_pedido.lbl_stock.Text = art.cantidad
                Form_cantidad_pedido.lbl_p_siva.Text = art.precio_siva
                Form_cantidad_pedido.lbl_p_civa.Text = art.precio_civa
                Form_cantidad_pedido.lbl_costo.Text = art.costo
                Form_cantidad_pedido.lbl_cant.Text = art.cantidad
                Form_cantidad_pedido.lbl_art_mueve_stok.Text = art.mueve_stok
                Form_cantidad_pedido.lbl_idiva.Text = art.codigo_iva
                Form_cantidad_pedido.lbl_iva.Text = art.iva
                Form_cantidad_pedido.txt_unidad_secundaria.Text = art.peso_promedio
                Form_cantidad_pedido.lbl_uni_sec.Text = art.unidad_secundaria

                Form_cantidad_pedido.Show()

            End If

        End If

        If form_factura.txt_factura_notaCredito.Text = 1 Or form_factura.txt_factura_notaCredito.Text = 2 Or form_factura.txt_factura_notaCredito.Text = 3 Or form_factura.txt_remito.Text = 1 Or form_factura.txt_remito.Text = 2 Or form_factura.txt_tipo_fact.Text = "PD" Then

            fact.carga_parametro()

            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & valor & "' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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

                'If RTrim(form_factura.txt_tipo_fact.Text) = "PD" Then

                'Dim c As Integer

                'For c = 0 To form_factura.DataGridView1.Rows.Count - 1
                'If RTrim(form_factura.DataGridView1.Rows(c).Cells(0).Value) = art.codigo Then
                'MessageBox.Show("Ya existe un articulo igual", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Me.Close()
                'Exit Sub
                'End If
                'Next

                'End If

                form_factura.codigo_iva = art.codigo_iva
                form_factura.porcentaje_impuesto = art.iva

                form_factura.txt_codigo_producto.Text = art.codigo
                form_factura.txt_nombre_producto.Text = art.nombre

                If fact.factura_en_c = "NO" Then
                    form_factura.txt_neto.Text = art.precio_siva
                Else
                    form_factura.txt_neto.Text = art.precio_civa
                    form_factura.txt_neto1.Text = art.precio_civa
                End If

                If RTrim(form_factura.txt_tipo_fact.Text) = "RE" Or RTrim(form_factura.txt_tipo_fact.Text) = "RS" Then
                    If fact.muestra_costo_remito = "SI" Then form_factura.txt_neto.Text = art.costo
                End If

                form_factura.lbl_uni_sec.Text = art.unidad_secundaria
                form_factura.txt_stock.Text = art.cantidad
                form_factura.lbl_bulto.Text = art.cantidad_bulto
                form_factura.txt_mueve_stok.Text = art.mueve_stok
                form_factura.txt_precioCiva.Text = art.precio_civa
                form_factura.txt_iva_ins.Text = art.iva_insc
                form_factura.txt_imp_interno.Text = art.impuestos_internos
                form_factura.txt_iva1.Text = art.iva
                form_factura.txt_exento1.Text = art.exento
                form_factura.txt_precio_costo.Text = art.costo
                form_factura.txt_utilidad.Text = art.uilidad
                form_factura.txt_cod_iva.Text = art.codigo_iva
                form_factura.txt_id_proveedor.Text = art.proveedor
                form_factura.txt_id_rubro.Text = art.rubro

                form_factura.txt_cantidad.ReadOnly = False
                form_factura.txt_desc_rcgo.ReadOnly = False

                If form_factura.lbl_uni_sec.Text = "NO" Then
                    form_factura.txt_unidad_secundaria.Visible = False
                    form_factura.lbl_unidad_secundaria.Visible = False
                    form_factura.txt_cantidad.Focus()
                Else
                    form_factura.txt_unidad_secundaria.Visible = True
                    form_factura.lbl_unidad_secundaria.Visible = True
                    form_factura.txt_unidad_secundaria.ReadOnly = False
                    form_factura.txt_unidad_secundaria.Text = art.peso_promedio
                    form_factura.txt_unidad_secundaria.Focus()
                    form_factura.txt_unidad_secundaria.SelectAll()
                End If


                Me.Dispose()

            Else

                form_factura.txt_codigo_producto.Text = ""
                form_factura.txt_nombre_producto.Text = ""
                form_factura.txt_stock.Text = ""

            End If

        End If

        If Form_presupuesto.txt_estado_form.Text = 1 Then

            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.DataGridView1.SelectedCells(0).Value & "' and art_precio.id_lista1 = '" & Me.txt_lista.Text & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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

                Form_presupuesto.txt_codigo_producto.Text = art.codigo
                Form_presupuesto.txt_nombre_producto.Text = art.nombre
                Form_presupuesto.txt_nombre_producto.BackColor = Color.LightGreen
                Form_presupuesto.txt_precio.Text = art.precio_civa
                Form_presupuesto.txt_precio_siva.Text = art.precio_siva
                Form_presupuesto.txt_iva.Text = art.iva_insc

                Form_presupuesto.txt_cantidad.ReadOnly = False
                Form_presupuesto.txt_cantidad.Focus()

                Me.Close()
                Exit Sub

            End If

        End If

        If Form_rotulo_balanza.txt_estado_form.Text = 1 Then

            art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.DataGridView1.SelectedCells(0).Value & "' and art_precio.id_lista1 = '" & Me.txt_lista.Text & "' and art_01.nombre = art_precio.nom and art_01.estado='Activo'"

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

                Form_rotulo_balanza.cmb_codigo.Text = art.codigo
                Form_rotulo_balanza.lbl_nombre_producto.Text = art.nombre
                Form_rotulo_balanza.lbl_cod_barra.Text = art.codigo_barra
                Form_rotulo_balanza.lbl_stock_prod.Text = art.cantidad
                Form_rotulo_balanza.cmb_cantidad.Focus()

                Me.Close()
                Exit Sub

            End If

        End If

    End Sub

End Class