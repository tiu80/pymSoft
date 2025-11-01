Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_articulos

    Dim art As New pymsoft.articulo
    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim fact As New pymsoft.factura
    Dim exp As New pymsoft.parametro
    Dim num As New pymsoft.numerodecimales

    Dim valor_moneda As Double

    Dim vacio As Boolean
    Dim tabla As New DataTable, tabla1 As New DataTable, tabla2 As New DataTable, tbl_dupli As New DataTable
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Public compara, compara1, duplicado As Boolean
    Dim reader As SqlDataReader
    Public control As String = ""
    Public page As Short = 0

    Dim trans As SqlTransaction

    Private Sub txt_rubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rubro.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from rub_01 where id_rubro like '" & Me.txt_rubro.Text & "'"
            xxx.codigo = "id_rubro"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_rubro.Text = xxx.text
            Me.lbl_rubro.Text = xxx.text2

            Me.txt_proveedor.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_rubro.Show()
        End If

    End Sub

    Private Sub txt_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_proveedor.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from cli_01 where id_cli like '" & Me.txt_proveedor.Text & "' and tipo_cliente ='Proveedor'"
            xxx.codigo = "id_cli"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_proveedor.Text = xxx.text
            Me.lbl_proveedor.Text = xxx.text2

            Me.cmb_unid_med_secundaria.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_proveedor.Show()
        End If

    End Sub

    Private Sub txt_lista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lista.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_lista.Text & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_lista.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            Me.txt_codigo.Focus()

            Call limpiar()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()

            Call limpiar()

        End If

    End Sub

    Private Sub txt_inputacion_compras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_inputacion_compras.KeyDown
        If e.KeyCode = Keys.Tab Then
            Me.txt_inputacion_ventas.Focus()
        End If
    End Sub

    Private Sub txt_inputacion_ventas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_inputacion_ventas.KeyDown
        If e.KeyCode = Keys.Tab Then
            Me.dt_fec_alta.Focus()
        End If
    End Sub

    Private Sub Form_articulos_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call ClearMemory()
        tabla.Dispose()
    End Sub

    Private Sub Form_articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            page = 0

            Me.cmb_estado.Text = Me.cmb_estado.Items(0)
            Me.cmb_moneda.Text = Me.cmb_moneda.Items(0)
            Me.cmb_mueve_stok.Text = Me.cmb_mueve_stok.Items(0)
            Me.cmb_unid_med_secundaria.Text = Me.cmb_unid_med_secundaria.Items(1)
            Me.txt_estado_form.Text = 1
            Me.cmb_origen.Text = Me.cmb_origen.Items(0)

            fact.carga_parametro()

            Call carga_lista_definida()

            conex = conecta()

            Dim tb As New DataTable
            'comando = New SqlDataAdapter("select MAX(CONVERT(INT,id_art)) from art_01", conex)
            comando = New SqlDataAdapter("select top 1 id_art from art_01 where id_lista = 1 order by fec_alta desc,id_art", conex)
            comando.Fill(tb)
            comando.Dispose()

            Dim pos As Integer = tb.Rows.Count - 1
            Me.txt_codigo.Text = tb.Rows(pos).Item(0)

            art.formulario = Me
            Call cargar_datos(Me.txt_lista.Text, Me.txt_codigo.Text)
            Me.txt_codigo.Focus()

            tb.Clear()
            tb.Dispose()

            carga_grilla_productos()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try

    End Sub

    Private Sub carga_grilla_productos()

        Me.DataGridView1.Rows.Clear()

        conex = New SqlConnection
        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        If Me.chk_estado.Checked = False Then
            coman = New SqlCommand("select top 100 id_lista1,lista,id_art1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,mueve_stok,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 where art_precio.id_lista1 = '" & RTrim(Me.txt_lista.Text) & "' and art_01.estado <> 'Baja' order by convert(int,id_art1)", conex)
        Else
            coman = New SqlCommand("select top 100 id_lista1,lista,id_art1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,mueve_stok,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 where art_precio.id_lista1 = '" & RTrim(Me.txt_lista.Text) & "' order by convert(int,id_art1)", conex)
        End If

        reader = coman.ExecuteReader()

        If reader.HasRows Then

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            Do While reader.Read()
                Me.DataGridView1.Rows.Add()
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Value = Trim(reader.Item("id_lista1"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = Trim(reader.Item("lista"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2).Value = Trim(reader.Item("id_art1"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(3).Value = Trim(reader.Item("nombre"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(4).Value = Trim(reader.Item("id_rubro"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(5).Value = Trim(reader.Item("rubro"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(6).Value = Trim(reader.Item("codigo_barra"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(7).Value = Trim(reader.Item("cantidad"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(8).Value = Trim(reader.Item("cantidad_bulto"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(9).Value = Trim(reader.Item("id_proveedor"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(10).Value = Trim(reader.Item("proveedor"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(11).Value = Trim(reader.Item("mueve_stok"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(12).Value = Trim(reader.Item("fec_alta"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(13).Value = Trim(reader.Item("fec_modi"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(14).Value = Trim(reader.Item("estado"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(15).Value = Trim(reader.Item("costo"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(16).Value = Trim(reader.Item("id_iva"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(17).Value = Trim(reader.Item("iva"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(18).Value = Trim(reader.Item("iva_insc"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(19).Value = Trim(reader.Item("cod_imp"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(20).Value = Trim(reader.Item("impuestos"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(21).Value = Trim(reader.Item("exento"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(22).Value = Trim(reader.Item("utilidad"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(23).Value = Trim(reader.Item("precio_civa"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(24).Value = Trim(reader.Item("precio_siva"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(25).Value = Trim(reader.Item("desc1"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(26).Value = Trim(reader.Item("desc2"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(27).Value = Trim(reader.Item("desc3"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(28).Value = Trim(reader.Item("flete"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(29).Value = Trim(reader.Item("pago_total"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(30).Value = Trim(reader.Item("moneda"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(31).Value = Trim(reader.Item("valor_moneda"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(32).Value = Trim(reader.Item("unidad_secundaria"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(33).Value = Trim(reader.Item("peso_promedio"))
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(34).Value = Trim(reader.Item("bonif_vta"))
                barra_carga.PictureBox1.Refresh()
            Loop

            barra_carga.Timer1.Enabled = True

        End If

        reader.Close()
        If conex.State = ConnectionState.Open Then conex.Close()
        coman.Dispose()
        conex.Dispose()

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Call verifica_campos_vacios()

        art.instruccion = "select id_art from art_01 where id_art = '" & Trim(Me.txt_codigo.Text) & "' and id_lista = '" & Trim(Me.txt_lista.Text) & "'"
        art.nombre = "id_art"
        art.codigo = RTrim(Me.txt_codigo.Text)
        art.verificar_duplicado()

        If art.duplicado = True Then
            Exit Sub
        End If

        If vacio = False Then

            selecciona_datos_moneda()

            art.instruccion = "INSERT INTO art_01(id_art,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,cant_ant,stock_corte,unidad_secundaria,peso_promedio) VALUES('" + Me.txt_codigo.Text + "','" + Me.txt_nombre.Text + "','" + Me.txt_rubro.Text + "','" + Me.lbl_rubro.Text + "','" + Me.txt_codigo_barra.Text + "','" + Me.txt_cantidad.Text + "','" + Me.txt_cantidad_bulto.Text + "','" + Me.txt_proveedor.Text + "','" + Me.lbl_proveedor.Text + "','" + Me.txt_lista.Text + "','" + Me.lbl_lista.Text + "','" + Me.cmb_mueve_stok.Text + "','" + Me.txt_inputacion_compras.Text + "','" + Me.lbl_input_compras.Text + "','" + Me.txt_inputacion_ventas.Text + "','" + Me.lbl_input_ventas.Text + "','" + Me.dt_fec_alta.Text + "','" + Me.dt_fec_modificacion.Text + "','" + Me.cmb_estado.Text + "', '" + Me.txt_cantidad.Text + "','0','" & Trim(Me.cmb_unid_med_secundaria.Text) & "','" & Val(Me.txt_peso_promedio.Text) & "')"
            art.guardar()

            art.instruccion = "INSERT INTO art_precio(id_art1,nom,id_lista1,costo,id_iva,iva,cod_imp,impuestos,utilidad,precio_siva,precio_civa,iva_insc,exento,cod,estado1,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,bonif_vta) VALUES('" + Me.txt_codigo.Text + "','" & Me.txt_nombre.Text & "','" + Me.txt_lista.Text + "','" + Me.txt_costo.Text + "','" & +Me.txt_codigo_iva.Text & "','" + Me.lbl_tipo_iva.Text + "','" + Me.txt_impuestos_internos.Text + "','" + Me.lbl_nom_imp_int.Text + "','" + Me.txt_utilidad.Text + "','" + Me.txt_precio_siva.Text + "','" + Me.txt_precio_civa.Text + "','" & art.iva_insc & "','0','" & Me.txt_codigo.Text & "','" & Me.cmb_estado.Text & "','" & Val(Me.txt_descuento1.Text) & "','" & Val(Me.txt_descuento2.Text) & "','" & Val(Me.txt_descuento3.Text) & "','" & Val(Me.txt_flete.Text) & "','" & Val(Me.txt_pago_total.Text) & "','" & Me.cmb_moneda.Text & "','" & valor_moneda & "','" & Me.txt_bonif_ventas.Text & "')"
            art.guardar()

            If RTrim(Me.txt_codigo_iva.Text) = 3 Then
                art.instruccion = "update art_precio set exento= '" & Me.txt_precio_civa.Text & "' where id_art1 = '" & RTrim(Me.txt_codigo.Text) & "' and id_lista1 = '" & RTrim(Me.txt_lista.Text) & "'"
                art.actualizar()
            End If

            Call limpiar()
            Me.txt_codigo.Focus()

        End If

    End Sub

    Private Sub cmb_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txt_codigo_barra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_barra.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_cantidad_bulto.Focus()
            Me.txt_cantidad_bulto.SelectAll()
        End If
    End Sub

    Private Sub txt_codigo_barra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_barra.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        num.positivos_punto(e, Me.txt_cantidad)
    End Sub

    Private Sub txt_cantidad_bulto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad_bulto.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_cantidad_bulto.Text = "" Then
                Me.txt_cantidad_bulto.Focus()
                Exit Sub
            End If

            Me.cmb_mueve_stok.Focus()
            Me.cmb_mueve_stok.SelectAll()
        End If
    End Sub

    Private Sub txt_cantidad_bulto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_bulto.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_costo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_costo.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_codigo_iva.Enabled = True Then
                Me.txt_codigo_iva.Focus()
                Me.txt_codigo_iva.SelectAll()
            Else
                Me.txt_impuestos_internos.Focus()
                Me.txt_impuestos_internos.SelectAll()
            End If
        End If
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_costo.KeyPress
        num.positivos_punto(e, Me.txt_costo)
    End Sub

    Private Sub txt_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_proveedor.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_lista_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lista.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmb_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_estado.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txt_utilidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_utilidad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_moneda.Focus()
        End If
    End Sub

    Private Sub txt_utilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_utilidad.KeyPress
        num.positivos_punto(e, Me.txt_utilidad)
    End Sub

    Private Sub txt_utilidad_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_utilidad.LostFocus

        Try

            art.costo = Me.txt_costo.Text
            art.iva = Me.lbl_tipo_iva.Text
            art.impuestos_internos = Me.lbl_nom_imp_int.Text
            art.uilidad = Me.txt_utilidad.Text
            art.descuento1 = Val(Me.txt_descuento1.Text)
            art.descuento2 = Val(Me.txt_descuento2.Text)
            art.descuento3 = Val(Me.txt_descuento3.Text)
            art.flete = Val(Me.txt_flete.Text)
            art.pago_total = Val(Me.txt_pago_total.Text)

            If fact.factura_en_c = "NO" Then art.calcular_precio_final()
            If fact.factura_en_c = "SI" Then art.calcular_precio_final_monotributo()

            Me.txt_precio_siva.Text = Format(art.precio_siva, "0.000")
            Me.txt_precio_civa.Text = Format(art.precio_civa, "0.000")

        Catch ex As Exception

        Finally

        End Try

    End Sub

    Private Sub txt_recargo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_utilidad.Validating
        If Me.txt_utilidad.Text = "" Then
            e.Cancel = False
            Me.txt_utilidad.Focus()
        End If
    End Sub

    Private Sub txt_costo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_costo.Validating
        If Me.txt_costo.Text = "" Then
            e.Cancel = False
            Me.txt_costo.Focus()
        End If
    End Sub

    Private Sub verifica_campos_vacios()

        If Me.txt_codigo.Text = "" Or Me.txt_nombre.Text = "" Or Me.txt_proveedor.Text = "" Or Me.txt_rubro.Text = "" Or Me.txt_cantidad_bulto.Text = "" Or Me.txt_costo.Text = "" Or Me.txt_lista.Text = "" Or Me.txt_utilidad.Text = "" Then

            MsgBox("Complete los Campos marcados", MsgBoxStyle.Information, "PyMSoft")
            Me.txt_codigo.Focus()
            vacio = True

        Else

            vacio = False

        End If

    End Sub

    Private Sub cargar_datos(ByVal lista As String, ByVal codigo As String)

        art.instruccion = "select id_art1,id_lista1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_lista1 = '" & Trim(lista) & "' and art_precio.id_art1 = '" & Trim(codigo) & "' and art_01.id_art = art_precio.id_art1"
        art.mostrar_datos()

        If art.verifica_campos = 0 Then

            Me.txt_codigo.Text = art.codigo
            Me.txt_interno.Text = art.codigo
            Me.txt_nombre.Text = art.descripcion
            Me.txt_rubro.Text = art.codigo_rubro
            Me.lbl_rubro.Text = art.nombre_rubro
            Me.txt_codigo_barra.Text = art.codigo_barra
            Me.txt_cantidad_bulto.Text = art.cantidad_bulto
            Me.txt_cantidad.Text = art.cantidad
            Me.txt_costo.Text = art.costo
            Me.lbl_tipo_iva.Text = art.iva
            Me.txt_codigo_iva.Text = art.codigo_iva
            Me.txt_impuestos_internos.Text = art.codigo_impuestos_internos
            Me.lbl_nom_imp_int.Text = art.impuestos_internos
            Me.txt_proveedor.Text = art.codigo_proveedor
            Me.lbl_proveedor.Text = art.nombre_proveedor
            Me.txt_utilidad.Text = art.uilidad
            Me.txt_precio_siva.Text = art.precio_siva
            Me.txt_precio_civa.Text = art.precio_civa
            Me.cmb_mueve_stok.Text = art.mueve_stok
            Me.txt_inputacion_compras.Text = art.codigo_compras
            Me.lbl_input_compras.Text = art.nombre_compras
            Me.txt_inputacion_ventas.Text = art.codigo_ventas
            Me.lbl_input_ventas.Text = art.nombre_ventas
            Me.dt_fec_alta.Text = art.fecha_alta
            Me.dt_fec_modificacion.Text = art.fecha_modificacion
            Me.cmb_estado.Text = art.estado
            Me.txt_descuento1.Text = art.descuento1
            Me.txt_descuento2.Text = art.descuento2
            Me.txt_descuento3.Text = art.descuento3
            Me.txt_flete.Text = art.flete
            Me.txt_pago_total.Text = art.pago_total
            Me.cmb_unid_med_secundaria.Text = art.unidad_secundaria
            Me.txt_peso_promedio.Text = art.peso_promedio
            Me.txt_bonif_ventas.Text = art.bonificacion_ventas

            If Trim(art.moneda) = "$" Then
                Me.cmb_moneda.Text = Me.cmb_moneda.Items(0)
            ElseIf art.moneda = "USD" Then
                Me.cmb_moneda.Text = Me.cmb_moneda.Items(1)
            Else
                Me.cmb_moneda.Text = Me.cmb_moneda.Items(2)
            End If


            Me.cmd_aceptar.Enabled = False
            Me.cmd_aceptar.BackColor = Color.LightGray
            Me.cmd_eliminar.Enabled = True
            Me.cmd_eliminar.BackColor = Color.Black
            Me.cmd_modificar.Enabled = True
            Me.cmd_modificar.BackColor = Color.Black
            Me.cmd_copiar.Enabled = True
            Me.cmd_copiar.BackColor = Color.Black

            If RTrim(Me.txt_codigo_iva.Text) = 1 Then
                'Me.lbl_nombre_iva.Text = " % " & "Resp.Insc"
                Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
            End If
            If RTrim(Me.txt_codigo_iva.Text) = 2 Then
                'Me.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
                Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
            End If
            If RTrim(Me.txt_codigo_iva.Text) = 3 Then
                'Me.lbl_nombre_iva.Text = " % " & "Exento"
                Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
            End If

        Else

            If fact.factura_en_c = "SI" Then
                Me.txt_codigo_iva.Text = 1
                Call carga_iva(1)
                Me.txt_codigo_iva.Enabled = False
            End If

            Me.txt_cantidad_bulto.Text = 1

            Me.cmd_aceptar.Enabled = True
            Me.cmd_aceptar.BackColor = Color.Black
            Me.cmd_eliminar.Enabled = False
            Me.cmd_eliminar.BackColor = Color.LightGray
            Me.cmd_modificar.Enabled = False
            Me.cmd_modificar.BackColor = Color.LightGray
            Me.cmd_copiar.Enabled = False
            Me.cmd_copiar.BackColor = Color.LightGray

            Me.dt_fec_alta.Value = Date.Now
            Me.dt_fec_modificacion.Value = Date.Now

        End If

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Dim borrar As Integer = MsgBox("Esta seguro que desea borrar el registro", MsgBoxStyle.YesNo, "PymSoft")

        If borrar = 6 Then

            art.instruccion = "DELETE art_01 WHERE id_art= '" & Me.txt_codigo.Text & "' and id_lista = '" & Me.txt_lista.Text & "'"
            art.borrar()

            art.instruccion = "DELETE art_precio WHERE id_art1 = '" & Me.txt_codigo.Text & "' and id_lista1 = '" & Me.txt_lista.Text & "'"
            art.borrar()

            Call carga_navega()

            If borrar = 6 Then
                Me.cmd_modificar.Enabled = False
                Me.cmd_modificar.BackColor = Color.LightGray
                Me.cmd_eliminar.Enabled = False
                Me.cmd_eliminar.BackColor = Color.LightGray
                Me.cmd_aceptar.Enabled = True
                Me.cmd_aceptar.BackColor = Color.Black
                Me.cmd_copiar.Enabled = False
                Me.cmd_copiar.BackColor = Color.LightGray
                Call limpiar()
            Else
                Me.cmd_modificar.Enabled = True
                Me.cmd_modificar.BackColor = Color.Black
                Me.cmd_eliminar.Enabled = True
                Me.cmd_eliminar.BackColor = Color.Black
                Me.cmd_aceptar.Enabled = False
                Me.cmd_aceptar.BackColor = Color.LightGray
                Me.cmd_aceptar.Enabled = True
                Me.cmd_aceptar.BackColor = Color.Black
                Me.txt_lista.Focus()
            End If

        End If

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        Call verifica_campos_vacios()

        If vacio = True Then
            vacio = False
            Exit Sub
        End If

        Call verifica_duplicado()

        If duplicado = True Then
            duplicado = False
            Exit Sub
        End If

        'selecciona_datos_moneda()

        If conex.State = ConnectionState.Closed Then
            conex = conecta()
            conex.Open()
            trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
        End If

        coman = New SqlCommand("update art_01 with (rowlock,xlock) set id_art= '" & Me.txt_codigo.Text & "', nombre = '" & Me.txt_nombre.Text & "', id_rubro = '" & Me.txt_rubro.Text & "',rubro ='" & Me.lbl_rubro.Text & "',codigo_barra='" & Me.txt_codigo_barra.Text & "',cantidad ='" & Me.txt_cantidad.Text & "',cantidad_bulto ='" & Me.txt_cantidad_bulto.Text & "',id_proveedor ='" & Me.txt_proveedor.Text & "',proveedor='" & Me.lbl_proveedor.Text & "',id_lista='" & Me.txt_lista.Text & "',lista='" & Me.lbl_lista.Text & "',mueve_stok ='" & Me.cmb_mueve_stok.Text & "',cod_imp_compras ='" & Me.txt_inputacion_compras.Text & "',nom_imp_compras = '" & Me.lbl_input_compras.Text & "',cod_imp_ventas= '" & Me.txt_inputacion_ventas.Text & "', nom_imp_ventas='" & Me.lbl_input_ventas.Text & "',fec_modi='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "',estado='" & Me.cmb_estado.Text & "',cant_ant= '" & Me.txt_cantidad.Text & "',unidad_secundaria = '" & Trim(Me.cmb_unid_med_secundaria.Text) & "',peso_promedio = '" & Val(Me.txt_peso_promedio.Text) & "' where id_art = '" & Me.txt_interno.Text & "' and id_lista = '" & Me.txt_lista.Text & "'", conex)
        coman.Transaction = trans
        coman.ExecuteNonQuery()
        coman.Dispose()

        coman = New SqlCommand("update art_precio with (rowlock,xlock) set id_art1 = '" & Me.txt_codigo.Text & "', nom = '" & Me.txt_nombre.Text & "',costo ='" & Me.txt_costo.Text & "',id_iva ='" & Me.txt_codigo_iva.Text & "',iva ='" & Me.lbl_tipo_iva.Text & "',cod_imp = '" & Me.txt_impuestos_internos.Text & "',impuestos ='" & Me.lbl_nom_imp_int.Text & "',id_lista1 ='" & Me.txt_lista.Text & "',utilidad='" & Me.txt_utilidad.Text & "',precio_siva='" & Me.txt_precio_siva.Text & "',precio_civa='" & Me.txt_precio_civa.Text & "',exento= '" & Me.txt_precio_civa.Text & "',iva_insc= '" & art.iva_insc & "',cod = '" & Me.txt_codigo.Text & "',estado1 = '" & Me.cmb_estado.Text & "',desc1 = '" & Val(Me.txt_descuento1.Text) & "',desc2 = '" & Val(Me.txt_descuento2.Text) & "',desc3 = '" & Val(Me.txt_descuento3.Text) & "',flete = '" & Val(Me.txt_flete.Text) & "',pago_total = '" & Val(Me.txt_pago_total.Text) & "',moneda = '" & Me.cmb_moneda.Text & "',bonif_vta = '" & Me.txt_bonif_ventas.Text & "' where id_art1 = '" & Me.txt_interno.Text & "' and id_lista1 = '" & Me.txt_lista.Text & "'", conex)
        coman.Transaction = trans
        coman.ExecuteNonQuery()
        coman.Dispose()

        If RTrim(Me.txt_codigo_iva.Text) = 3 Then
            coman = New SqlCommand("update art_precio with (rowlock,xlock) set exento= '" & Me.txt_precio_civa.Text & "' where id_art1 = '" & RTrim(Me.txt_codigo.Text) & "' and id_lista1 = '" & RTrim(Me.txt_lista.Text) & "'", conex)
            coman.Transaction = trans
            coman.ExecuteNonQuery()
            coman.Dispose()
        Else
            coman = New SqlCommand("update art_precio with (rowlock,xlock) set exento= '0' where id_art1 = '" & RTrim(Me.txt_codigo.Text) & "' and id_lista1 = '" & RTrim(Me.txt_lista.Text) & "'", conex)
            coman.Transaction = trans
            coman.ExecuteNonQuery()
            coman.Dispose()
        End If

        trans.Commit()
        conex.Close()

        Me.txt_codigo.Focus()

        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray
        Me.cmd_eliminar.Enabled = False
        Me.cmd_eliminar.BackColor = Color.LightGray
        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_copiar.Enabled = False
        Me.cmd_copiar.BackColor = Color.LightGray

        Call limpiar()

    End Sub

    Private Sub txt_rubro_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_rubro.Validating
        If Me.txt_rubro.Text = "" Or xxx.validar = False Then
            e.Cancel = False
            Me.txt_rubro.Focus()
        End If
    End Sub

    Private Sub txt_proveedor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_proveedor.Validating
        If Me.txt_proveedor.Text = "" Or xxx.validar = False Then
            e.Cancel = False
            Me.txt_proveedor.Focus()
        End If
    End Sub

    Private Sub cmb_mueve_stok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_mueve_stok.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_rubro.Focus()
            Me.txt_rubro.SelectAll()
        End If
    End Sub

    Private Sub cmb_mueve_stok_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_mueve_stok.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txt_codigo_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_iva.KeyDown

        Try

            If e.KeyCode = Keys.F1 Then
                busc_iva.Show()
            End If

            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

                Call carga_iva(Me.txt_codigo_iva.Text)

                Me.txt_impuestos_internos.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carga_iva(ByVal cod As Integer)

        xxx.instruccion = "select *from iva_01 where id_iva like '" & cod & "'"
        xxx.codigo = "id_iva"
        xxx.nombre = "iva_insc"
        xxx.cargar()
        Me.txt_codigo_iva.Text = xxx.text
        Me.lbl_tipo_iva.Text = xxx.text2

        If RTrim(Me.txt_codigo_iva.Text) = 1 Then
            'Me.lbl_nombre_iva.Text = " % " & "Resp.Insc"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
        End If
        If RTrim(Me.txt_codigo_iva.Text) = 2 Then
            'Me.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
        End If
        If RTrim(Me.txt_codigo_iva.Text) = 3 Then
            'Me.lbl_nombre_iva.Text = " % " & "Exento"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleLeft
        End If

    End Sub

    Public Sub limpiar()

        Me.txt_cantidad.Text = ""
        Me.txt_cantidad_bulto.Text = ""
        Me.txt_codigo.Text = ""
        Me.txt_codigo_barra.Text = ""
        Me.txt_costo.Text = ""
        Me.txt_impuestos_internos.Text = ""
        Me.txt_inputacion_compras.Text = ""
        Me.txt_inputacion_ventas.Text = ""
        Me.txt_precio_siva.Text = ""
        Me.txt_nombre.Text = ""
        Me.txt_precio_civa.Text = ""
        Me.txt_proveedor.Text = ""
        Me.txt_rubro.Text = ""
        Me.txt_utilidad.Text = ""
        Me.lbl_input_compras.Text = ""
        Me.lbl_input_ventas.Text = ""
        Me.lbl_proveedor.Text = ""
        Me.lbl_rubro.Text = ""
        Me.txt_interno.Text = ""
        Me.txt_codigo_iva.Text = ""
        Me.lbl_nom_imp_int.Text = ""
        Me.txt_descuento1.Text = ""
        Me.txt_descuento2.Text = ""
        Me.txt_descuento3.Text = ""
        Me.txt_flete.Text = ""
        Me.txt_pago_total.Text = ""
        Me.lbl_tipo_iva.Text = ""
        Me.txt_peso_promedio.Text = 0
        Me.txt_peso_promedio.Enabled = False

    End Sub

    Private Sub opt_art_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_art.CheckedChanged
        If Me.opt_art.Checked = True Then
            Me.TabControl1.SelectTab(0)
            Me.txt_estado_form.Text = 1
            page = 0
        End If
    End Sub

    Private Sub opt_act_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_act.CheckedChanged
        If Me.opt_act.Checked = True Then
            Me.TabControl1.SelectTab(1)
            Me.txt_estado_form.Text = 2
            'Me.cmd_pri.Enabled = False
            'Me.cmd_sig.Enabled = False
            'Me.cmd_ult.Enabled = False
            'Me.cmd_ant.Enabled = False
        End If
    End Sub

    Private Sub cmd_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cargar.Click

        Dim i As Integer
        Dim precio_siva, precio_civa, precio_costo, utilidad, iva_ins, impuestos As Double

        If Me.opt_articulo.Checked = False Then

            If Me.txt_origen.Text = "" Or Me.txt_destino.Text = "" Or Me.txt_rango_desde.Text = "" Or Me.txt_rango_hasta.Text = "" Or Me.txt_porcentaje.Text = "" Or Me.txt_porcentaje.Text = "0.00" Then
                MessageBox.Show("Complete los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        Dim lista_origen As New DataTable
        Dim lista_destino As New DataTable
        Dim comando As SqlDataAdapter
        Dim conex As SqlConnection

        conex = conecta()

        If Me.opt_articulo.Checked = True Then

            comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "'", conex)
            comando.Fill(lista_origen)
            comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "'", conex)
            comando.Fill(lista_destino)

        Else

            If RTrim(Me.desde.Text) = "R" And RTrim(Me.hasta.Text) = "R" Then
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_rubro='" & RTrim(Me.txt_rango_desde.Text) & "'", conex)
                comando.Fill(lista_origen)
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_rubro='" & RTrim(Me.txt_rango_desde.Text) & "'", conex)
                comando.Fill(lista_destino)
            End If


            If RTrim(Me.desde.Text) = "R" And RTrim(Me.hasta.Text) = "P" Then
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_rubro='" & RTrim(Me.txt_rango_desde.Text) & "' and art_01.id_proveedor ='" & Me.txt_rango_hasta.Text & "'", conex)
                comando.Fill(lista_origen)
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_rubro='" & RTrim(Me.txt_rango_desde.Text) & "' and art_01.id_proveedor ='" & Me.txt_rango_hasta.Text & "'", conex)
                comando.Fill(lista_destino)
            End If

            If RTrim(Me.desde.Text) = "P" And RTrim(Me.hasta.Text) = "R" Then
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on  art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_proveedor='" & RTrim(Me.txt_rango_desde.Text) & "' and art_01.id_rubro ='" & RTrim(Me.txt_rango_hasta.Text) & "'", conex)
                comando.Fill(lista_origen)
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on  art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_proveedor='" & RTrim(Me.txt_rango_desde.Text) & "' and art_01.id_rubro ='" & RTrim(Me.txt_rango_hasta.Text) & "'", conex)
                comando.Fill(lista_destino)
            End If


            If RTrim(Me.desde.Text) = "P" And RTrim(Me.hasta.Text) = "P" Then
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_proveedor='" & RTrim(Me.txt_rango_hasta.Text) & "'", conex)
                comando.Fill(lista_origen)
                comando = New SqlDataAdapter("select id_art1,nombre,costo,precio_siva,precio_civa,utilidad,iva,iva_insc,impuestos,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1 = '" & RTrim(Me.txt_origen.Text) & "' and art_01.id_proveedor='" & RTrim(Me.txt_rango_hasta.Text) & "'", conex)
                comando.Fill(lista_destino)
            End If

        End If

        If lista_destino.Rows.Count = 0 Then
            MessageBox.Show("No existe una Lista Destino", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
            Exit Sub
        End If

        If Me.opt_utilidad.Checked = True Then     ''''' utilidad

            If Me.opt_aumento.Checked = True Then

                If fact.factura_en_c = "NO" Then

                    For i = 0 To lista_origen.Rows.Count - 1

                        ' calculos todos los descuentos y luego termino de sacar el precio final

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        utilidad = Me.txt_porcentaje.Text + lista_origen.Rows(i).Item(5)
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_siva = Format(p_siva * utilidad / 100 + p_siva, "0.000")
                        precio_civa = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100 + precio_siva + impuestos, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set utilidad = '" & utilidad & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                Else

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        utilidad = Me.txt_porcentaje.Text + lista_origen.Rows(i).Item(5)
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_civa = Format((p_siva * utilidad) / 100 + p_siva + impuestos, "0.00")
                        precio_siva = Format(precio_civa, "0.00")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set utilidad = '" & utilidad & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                End If

            End If


            If Me.opt_descuento.Checked = True Then

                If fact.factura_en_c = "NO" Then

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        utilidad = lista_origen.Rows(i).Item(5) - Me.txt_porcentaje.Text
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_siva = Format(p_siva * utilidad / 100 + p_siva, "0.000")
                        precio_civa = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100 + precio_siva + impuestos, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set utilidad = '" & utilidad & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                Else

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        utilidad = lista_origen.Rows(i).Item(5) - Me.txt_porcentaje.Text
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_civa = Format((p_siva * utilidad) / 100 + p_siva + impuestos, "0.000")
                        precio_siva = Format(precio_civa, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set utilidad = '" & utilidad & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                End If

            End If

        End If


        If Me.opt_precio.Checked = True Then   '''''' precio costo

            If Me.opt_aumento.Checked = True Then

                If fact.factura_en_c = "NO" Then

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        precio_costo = Format((p_siva * Me.txt_porcentaje.Text / 100) + p_siva, "0.000")
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_siva = Format((precio_costo * lista_origen.Rows(i).Item(5) / 100) + precio_costo, "0.000")
                        precio_civa = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100 + precio_siva + impuestos, "0.000")
                        iva_ins = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set costo = '" & precio_costo & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "', iva_insc = '" & iva_ins & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                Else

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        precio_costo = Format((p_siva * Me.txt_porcentaje.Text / 100) + p_siva, "0.000")
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_civa = Format((precio_costo * lista_origen.Rows(i).Item(5)) / 100 + precio_costo, "0.000")
                        precio_siva = Format(precio_civa, "0.000")
                        iva_ins = Format(precio_civa - precio_siva, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set costo = '" & precio_costo & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "', iva_insc = '" & iva_ins & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                End If

            End If

            If Me.opt_descuento.Checked = True Then

                If fact.factura_en_c = "NO" Then

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        precio_costo = Format((p_siva * (-Me.txt_porcentaje.Text) / 100) + p_siva, "0.000")
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_siva = Format((precio_costo * lista_origen.Rows(i).Item(5) / 100) + precio_costo, "0.000")
                        precio_civa = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100 + precio_siva + impuestos, "0.000")
                        iva_ins = Format(precio_siva * lista_origen.Rows(i).Item(6) / 100, "0.000")

                        exp.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_lista = '" & RTrim(Me.txt_destino.Text) & "' and id_art = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        exp.instruccion = "update art_precio set costo = '" & precio_costo & "', precio_siva = '" & precio_siva & "', precio_civa = '" & precio_civa & "', iva_insc = '" & iva_ins & "' where id_lista1 = '" & RTrim(Me.txt_destino.Text) & "' and id_art1 = '" & lista_destino.Rows(i).Item(0) & "'"
                        exp.abm()

                        barra_carga.PictureBox1.Refresh()

                    Next

                Else

                    For i = 0 To lista_origen.Rows.Count - 1

                        Dim p_siva = art.calcula_descuentos_total(lista_origen.Rows(i).Item(2), lista_origen.Rows(i).Item(3), lista_origen.Rows(i).Item(9), lista_origen.Rows(i).Item(10), lista_origen.Rows(i).Item(11), lista_origen.Rows(i).Item(12), lista_origen.Rows(i).Item(13))

                        precio_costo = Format((p_siva * (-Me.txt_porcentaje.Text) / 100) + p_siva, "0.000")
                        impuestos = lista_origen.Rows(i).Item(8)
                        precio_civa = Format((precio_costo * lista_origen.Rows(i).Item(5)) / 100 + precio_costo, "0.000")
                        precio_siva = Format(precio_civa, "0.000")
                        iva_ins = Format(precio_civa - precio_siva, "0.000")

                        barra_carga.PictureBox1.Refresh()

                    Next

                End If

            End If

        End If

        MessageBox.Show("Proceso terminado correctamente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

        barra_carga.Timer1.Enabled = True
        Me.Dispose()

    End Sub

    Private Sub txt_origen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_origen.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
            compara = True
        End If

        If e.KeyCode = Keys.Return Then
            xxx.instruccion = "select *from lista_01 where id_lis like '" & RTrim(Me.txt_origen.Text) & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_origen.Text = xxx.text
            Me.lbl_origen.Text = xxx.text2
            Me.txt_destino.Focus()
        End If
    End Sub

    Private Sub txt_destino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_destino.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
            compara = False
        End If

        If e.KeyCode = Keys.Return Then
            xxx.instruccion = "select *from lista_01 where id_lis like '" & RTrim(Me.txt_destino.Text) & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_destino.Text = xxx.text()
            Me.lbl_destino.Text = xxx.text2

            If Me.txt_rango_hasta.Visible = True Then
                Me.txt_rango_desde.Focus()
            Else
                Me.txt_porcentaje.Focus()
            End If

        End If

    End Sub

    Private Sub txt_rango_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rango_desde.GotFocus
        Me.txt_origen.Enabled = False
        Me.txt_destino.Enabled = False
    End Sub

    Private Sub txt_rango_desde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rango_desde.KeyDown
        If e.KeyCode = Keys.F1 Then
            If Me.opt_rubro.Checked = True Then
                busc_rubro.Show()
                compara1 = True
                Me.desde.Text = "R"
            End If

            If Me.opt_proveedor.Checked = True Then
                busc_proveedor.Show()
                compara1 = True
                Me.desde.Text = "P"
            End If
        End If

        If e.KeyCode = Keys.Return Then

            If Me.opt_rubro.Checked = True Then
                xxx.instruccion = "select *from rub_01 where id_rubro like '" & RTrim(Me.txt_rango_desde.Text) & "'"
                xxx.codigo = "id_rubro"
                xxx.nombre = "nombre"
                xxx.cargar()
                Me.txt_rango_desde.Text = xxx.text
                Me.lbl_rango_desde.Text = xxx.text2
                Me.txt_rango_hasta.Focus()
                Me.desde.Text = "R"
            End If

            If Me.opt_proveedor.Checked = True Then
                xxx.instruccion = "select *from cli_01 where id_cli like '" & RTrim(Me.txt_rango_desde.Text) & "' and tipo_cliente ='Proveedor'"
                xxx.codigo = "id_cli"
                xxx.nombre = "nombre"
                xxx.cargar()
                Me.txt_rango_desde.Text = xxx.text
                Me.lbl_rango_desde.Text = xxx.text2()
                Me.txt_rango_hasta.Focus()
                Me.desde.Text = "P"
            End If

        End If
    End Sub

    Private Sub txt_rango_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rango_hasta.KeyDown
        If e.KeyCode = Keys.F1 Then
            If Me.opt_rubro.Checked = True Then
                busc_rubro.Show()
                compara1 = False
                Me.hasta.Text = "R"
            End If

            If Me.opt_proveedor.Checked = True Then
                busc_proveedor.Show()
                compara1 = False
                Me.hasta.Text = "P"
            End If
        End If

        If e.KeyCode = Keys.Return Then

            If Me.opt_rubro.Checked = True Then
                xxx.instruccion = "select *from rub_01 where id_rubro like '" & RTrim(Me.txt_rango_hasta.Text) & "'"
                xxx.codigo = "id_rubro"
                xxx.nombre = "nombre"
                xxx.cargar()
                Me.txt_rango_hasta.Text = xxx.text
                Me.lbl_rango_hasta.Text = xxx.text2
                Me.txt_porcentaje.Focus()
                Me.hasta.Text = "R"
            End If

            If Me.opt_proveedor.Checked = True Then
                xxx.instruccion = "select *from cli_01 where id_cli like '" & RTrim(Me.txt_rango_hasta.Text) & "' and tipo_cliente ='Proveedor'"
                xxx.codigo = "id_cli"
                xxx.nombre = "nombre"
                xxx.cargar()
                Me.txt_rango_hasta.Text = xxx.text
                Me.lbl_rango_hasta.Text = xxx.text2
                Me.txt_porcentaje.Focus()
                Me.hasta.Text = "P"
            End If

        End If

    End Sub

    Private Sub opt_articulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_articulo.CheckedChanged
        If Me.opt_articulo.Checked = True Then
            Me.lbl_rango_d.Visible = False
            Me.lbl_rango_h.Visible = False
            Me.txt_rango_desde.Visible = False
            Me.txt_rango_hasta.Visible = False
            Me.lbl_rango_hasta.Visible = False
            Me.lbl_rango_desde.Visible = False
        End If
    End Sub

    Private Sub opt_rubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_rubro.CheckedChanged
        If Me.opt_rubro.Checked = True Then
            Me.lbl_rango_d.Visible = True
            Me.lbl_rango_h.Visible = True
            Me.txt_rango_desde.Visible = True
            Me.txt_rango_hasta.Visible = True
            Me.lbl_rango_hasta.Visible = True
            Me.lbl_rango_desde.Visible = True
        End If
    End Sub

    Private Sub opt_proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_proveedor.CheckedChanged
        If Me.opt_proveedor.Checked = True Then

            Me.lbl_rango_d.Visible = True
            Me.lbl_rango_h.Visible = True
            Me.txt_rango_desde.Visible = True
            Me.txt_rango_hasta.Visible = True

            If RTrim(Me.desde.Text) = "R" Then
                MessageBox.Show("No esta permitida esta combinacion", "PyMsoft", MessageBoxButtons.OK)
                Me.opt_rubro.Checked = True
            End If

        End If
    End Sub

    Private Sub txt_modo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje.GotFocus
        Me.Group_forma.Enabled = False
        Me.Group_modo.Enabled = False
        Me.Group_rango.Enabled = False
        Me.txt_rango_desde.Enabled = False
        Me.txt_rango_hasta.Enabled = False
    End Sub

    Private Sub txt_modo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_porcentaje.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then
            Me.cmd_cargar.Focus()
        End If
    End Sub

    Private Sub opt_exporta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_exporta.CheckedChanged
        If Me.opt_exporta.Checked = True Then
            Me.TabControl1.SelectTab(2)
            Me.txt_estado_form.Text = 3
            page = 2
            'Me.cmd_pri.Enabled = False
            'Me.cmd_sig.Enabled = False
            'Me.cmd_ult.Enabled = False
            'Me.cmd_ant.Enabled = False
            Me.txt_lis_origen.Text = 1
            Call carga_lista_origen()
        End If
    End Sub

    Private Sub carga_lista_origen()

        conex = conecta()

        comando = New SqlDataAdapter("select id_art,nom,costo,iva_insc,id_iva,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,lista,id_lista1,estado,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,bonif_vta from art_precio inner join art_01 on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1= '" & Trim(Me.txt_lis_origen.Text) & "'", conex)
        comando.Fill(tabla)
        comando.Dispose()

        Me.txt_lis_origen.Text = tabla.Rows(0).Item(13)
        Me.lbl_lis_origen.Text = tabla.Rows(0).Item(12)

        Me.txt_lis_origen.Focus()

    End Sub

    Private Sub txt_lis_destino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lis_destino.KeyDown

        If e.KeyCode = Keys.F1 Then
            control = "D"
            busc_lista.Show()
        End If

        If e.KeyCode = Keys.Return Then
            xxx.instruccion = "select *from lista_01 where id_lis = '" & RTrim(Me.txt_lis_destino.Text) & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_lis_destino.Text = xxx.text
            Me.lbl_lis_destino.Text = xxx.text2
            Me.txt_codigo_iva_expotador.Focus()
            Me.txt_codigo_iva_expotador.SelectAll()
        End If

    End Sub

    Private Sub carga_lista()

        conex = conecta()

        tabla.Clear()

        comando = New SqlDataAdapter("select id_art,nom,costo,iva_insc,id_iva,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,lista,id_lista1,estado,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,bonif_vta from art_precio inner join art_01 on art_01.id_art = art_precio.id_art1 and art_precio.id_lista1= '" & Trim(Me.txt_lis_origen.Text) & "'", conex)
        comando.Fill(tabla)
        comando.Dispose()

    End Sub

    Private Sub cmd_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exporta.Click

        Call carga_lista()
        Call carga_lista_nueva()

    End Sub

    Public Sub carga_lista_nueva()

        Dim i As Integer
        Dim sale As Boolean = True

        Try

            If Me.txt_lis_origen.Text = Me.txt_lis_destino.Text Then
                MessageBox.Show("La Lista Destino no puede ser igual que la de Origen !!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txt_lis_destino.Focus()
                Exit Sub
            End If

            conex = conecta()

            tabla1.Clear()

            comando = New SqlDataAdapter("select * from art_precio where id_lista1 = '" & Me.txt_lis_destino.Text & "'", conex)
            comando.Fill(tabla1)
            comando.Dispose()

            If tabla1.Rows.Count > 0 Then
                Dim x As Integer = MessageBox.Show("La lista ya existe: desea Actualizarla? .. Este proceso puede durar varios minutos y sobreescribira la lista destino!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If x = 6 Then
                    sale = True
                Else
                    sale = False
                End If
            End If

            If Me.txt_lis_destino.Text = "" Then
                MessageBox.Show("Complete los Campos!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_lis_destino.Focus()
                Exit Sub
            End If

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()
            If sale = True Then

                art.instruccion = "DELETE art_precio where id_lista1 = '" & RTrim(Me.txt_lis_destino.Text) & "'"
                art.guardar()

                For i = 0 To tabla.Rows.Count - 1

                    art.costo = tabla.Rows(i).Item(2)

                    If Me.txt_codigo_iva_expotador.Text <> "" Then
                        art.iva = Me.lbl_tipo_iva_exportador.Text
                    Else
                        art.codigo_iva = tabla.Rows(i).Item(4)
                        art.iva = tabla.Rows(i).Item(5)
                    End If

                    art.impuestos_internos = tabla.Rows(i).Item(7)
                    art.uilidad = tabla.Rows(i).Item(9)
                    art.descuento1 = Val(tabla.Rows(i).Item(15))
                    art.descuento2 = Val(tabla.Rows(i).Item(16))
                    art.descuento3 = Val(tabla.Rows(i).Item(17))
                    art.flete = Val(tabla.Rows(i).Item(18))
                    art.pago_total = Val(tabla.Rows(i).Item(19))

                    If fact.factura_en_c = "NO" Then art.calcular_precio_final()
                    If fact.factura_en_c = "SI" Then art.calcular_precio_final_monotributo()

                    art.iva_insc = Format(art.precio_civa - art.precio_siva, "0.000")

                    barra_carga.PictureBox1.Refresh()

                    If Me.txt_codigo_iva_expotador.Text <> "" Then
                        art.instruccion = "INSERT INTO art_precio(id_art1,nom,id_lista1,costo,iva_insc,id_iva,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,estado1,cod,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,bonif_vta) VALUES('" & tabla.Rows(i).Item(0) & "','" & tabla.Rows(i).Item(1) & "','" & Me.txt_lis_destino.Text & "','" & art.costo & "','" & art.iva_insc & "','" & Me.txt_codigo_iva_expotador.Text & "','" & Me.lbl_tipo_iva_exportador.Text & "','" & tabla.Rows(i).Item(6) & "','" & tabla.Rows(i).Item(7) & "','" & tabla.Rows(i).Item(8) & "','" & art.uilidad & "','" & art.precio_siva & "','" & art.precio_civa & "','" & tabla.Rows(i).Item(14) & "','" & tabla.Rows(i).Item(0) & "','" & tabla.Rows(i).Item(15) & "','" & tabla.Rows(i).Item(16) & "','" & tabla.Rows(i).Item(17) & "','" & tabla.Rows(i).Item(18) & "','" & tabla.Rows(i).Item(19) & "','" & tabla.Rows(i).Item(20) & "','" & tabla.Rows(i).Item(21) & "','" & tabla.Rows(i).Item(22) & "')"
                    Else
                        art.instruccion = "INSERT INTO art_precio(id_art1,nom,id_lista1,costo,iva_insc,id_iva,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,estado1,cod,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,bonif_vta) VALUES('" & tabla.Rows(i).Item(0) & "','" & tabla.Rows(i).Item(1) & "','" & Me.txt_lis_destino.Text & "','" & art.costo & "','" & art.iva_insc & "','" & art.codigo_iva & "','" & art.iva & "','" & tabla.Rows(i).Item(6) & "','" & tabla.Rows(i).Item(7) & "','" & tabla.Rows(i).Item(8) & "','" & art.uilidad & "','" & art.precio_siva & "','" & art.precio_civa & "','" & tabla.Rows(i).Item(14) & "','" & tabla.Rows(i).Item(0) & "','" & tabla.Rows(i).Item(15) & "','" & tabla.Rows(i).Item(16) & "','" & tabla.Rows(i).Item(17) & "','" & tabla.Rows(i).Item(18) & "','" & tabla.Rows(i).Item(19) & "','" & tabla.Rows(i).Item(20) & "','" & tabla.Rows(i).Item(21) & "','" & tabla.Rows(i).Item(22) & "')"
                    End If

                    art.guardar()

                Next

                MessageBox.Show("La Lista se Transfirio Correctamente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            MessageBox.Show("Error en " + tabla.Rows(i).Item(0) + " " + tabla.Rows(i).Item(1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally

            barra_carga.Timer1.Enabled = True
            Me.Dispose()

        End Try

    End Sub

    Public Sub carga_navega()

        art.instruccion_navegador = "select id_art1,id_lista1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,bonif_vta from art_precio inner join art_01 on art_01.id_art = art_precio.id_art1 and art_01.nombre = art_precio.nom and art_precio.id_lista1 = '" & Me.txt_lista.Text & "' "
        art.nombre = "art_precio"
        art.formulario = Me
        art.codigo_tabla_navegador = "id_art1"
        art.codigo = Me.txt_codigo.Text

    End Sub

    Private Sub carga_lista_definida()
        Try

            xxx.instruccion = "select *from lista_01 where id_lis = '" & Trim(fact.lista_predeterminada) & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_lista.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            Me.txt_codigo.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub busca_impuesto()

        xxx.instruccion = "select *from imp_interno where cod_int like '" & RTrim(Me.txt_impuestos_internos.Text) & "'"
        xxx.codigo = "cod_int"
        xxx.nombre = "monto"
        xxx.cargar()

        If xxx.validar = True Then
            Me.txt_impuestos_internos.Text = xxx.text
            Me.lbl_nom_imp_int.Text = xxx.text2
        Else
            Me.txt_impuestos_internos.Text = ""
            Me.lbl_nom_imp_int.Text = ""
        End If

        Me.txt_descuento1.Focus()

    End Sub

    Private Sub txt_impuestos_internos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_impuestos_internos.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_imp_interno.Show()
        End If
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_impuestos_internos.Text <> "" Then Call busca_impuesto()
            Me.txt_descuento1.Focus()
            Me.txt_descuento1.SelectAll()
        End If
    End Sub

    Private Sub txt_impuestos_internos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_impuestos_internos.KeyPress
        num.positivos_punto(e, Me.txt_impuestos_internos)
    End Sub

    Private Sub txt_impuestos_internos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_impuestos_internos.LostFocus
        art.impuestos_internos = Me.lbl_nom_imp_int.Text
        art.codigo_impuestos_internos = Me.txt_impuestos_internos.Text
    End Sub

    Private Sub opt_act_grilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_act_grilla.CheckedChanged
        If Me.opt_act_grilla.Checked = True Then
            Me.TabControl1.SelectTab(3)
            Me.txt_estado_form.Text = 4
            'Me.cmd_pri.Enabled = False
            'Me.cmd_sig.Enabled = False
            'Me.cmd_ult.Enabled = False
            'Me.cmd_ant.Enabled = False
            Me.txt_list.SelectAll()
            Me.txt_list.Focus()
            Me.txt_list.Text = principal.txt_lista_pred.Text
            tabla2.Clear()
        End If
    End Sub

    Private Sub txt_list_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_list.KeyDown

        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_list.Text & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_list.Text = xxx.text
            Me.lbl_list.Text = xxx.text2

            Me.txt_prov.Focus()

        End If

    End Sub

    Private Sub txt_prov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_prov.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_proveedor.Show()
        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from cli_01 where id_cli like '" & Me.txt_prov.Text & "' and tipo_cliente ='Proveedor'"
            xxx.codigo = "id_cli"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_prov.Text = xxx.text
            Me.lbl_prov.Text = xxx.text2

            Me.txt_rub.Focus()

        End If
    End Sub

    Private Sub txt_rub_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rub.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_rubro.Show()
        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from rub_01 where id_rubro like '" & Me.txt_rub.Text & "'"
            xxx.codigo = "id_rubro"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_rub.Text = xxx.text
            Me.lbl_rub.Text = xxx.text2

            Me.cmd_buscar.Focus()

        End If

    End Sub

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click

        conex = conecta()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        tabla2.Clear()

        If Me.txt_list.Text <> "" And Me.txt_rub.Text = "" And Me.txt_prov.Text = "" Then
            comando = New SqlDataAdapter("select distinct nom,costo,iva,iva_insc,exento,impuestos,utilidad,precio_siva,precio_civa,id_iva,cod_imp,id_art1,desc1,desc2,desc3,flete,pago_total from art_precio where art_precio.id_lista1 = '" & Me.txt_list.Text & "' and art_precio.estado1 ='Activo'", conex)
            comando.Fill(tabla2)
            comando.Dispose()
            Me.datagrid1.DataSource = tabla2
            Call carga_cabecera()
            Me.datagrid1.Focus()
        End If

        If Me.txt_list.Text <> "" And Me.txt_rub.Text <> "" And Me.txt_prov.Text = "" Then
            comando = New SqlDataAdapter("select distinct nom,costo,iva,iva_insc,exento,impuestos,utilidad,precio_siva,precio_civa,id_iva,cod_imp,id_art1,desc1,desc2,desc3,flete,pago_total from art_precio inner join art_01 on art_precio.id_lista1 = '" & Me.txt_list.Text & "' and art_01.id_rubro = '" & Me.txt_rub.Text & "' and art_01.id_art = art_precio.id_art1 and art_01.nombre = art_precio.nom and art_precio.estado1 ='Activo'", conex)
            comando.Fill(tabla2)
            comando.Dispose()
            Me.datagrid1.DataSource = tabla2
            Call carga_cabecera()
            Me.datagrid1.Focus()
        End If

        If Me.txt_list.Text <> "" And Me.txt_rub.Text = "" And Me.txt_prov.Text <> "" Then
            comando = New SqlDataAdapter("select distinct nom,costo,iva,iva_insc,exento,impuestos,utilidad,precio_siva,precio_civa,id_iva,cod_imp,id_art1,desc1,desc2,desc3,flete,pago_total from art_precio inner join art_01 on art_precio.id_lista1 = '" & Me.txt_list.Text & "' and art_01.id_proveedor = '" & Me.txt_prov.Text & "' and art_01.id_art = art_precio.id_art1 and art_01.nombre = art_precio.nom and art_precio.estado1 ='Activo'", conex)
            comando.Fill(tabla2)
            comando.Dispose()
            Me.datagrid1.DataSource = tabla2
            Call carga_cabecera()
            Me.datagrid1.Focus()
        End If

        If Me.txt_list.Text <> "" And Me.txt_rub.Text <> "" And Me.txt_prov.Text <> "" Then
            comando = New SqlDataAdapter("select distinct nom,costo,iva,iva_insc,exento,impuestos,utilidad,precio_siva,precio_civa,id_iva,cod_imp,id_art1,desc1,desc2,desc3,flete,pago_total from art_precio inner join art_01 on art_precio.id_lista1 = '" & Me.txt_list.Text & "' and art_01.id_rubro = '" & Me.txt_rub.Text & "' and art_01.id_proveedor = '" & Me.txt_prov.Text & "' and art_01.id_art = art_precio.id_art1 and art_01.nombre = art_precio.nom and art_precio.estado1 ='Activo'", conex)
            comando.Fill(tabla2)
            comando.Dispose()
            Me.datagrid1.DataSource = tabla2
            Call carga_cabecera()
            Me.datagrid1.Focus()
        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub carga_cabecera()

        Me.datagrid1.Columns(0).HeaderText = "Nombre"
        Me.datagrid1.Columns(1).HeaderText = "Costo"
        Me.datagrid1.Columns(2).HeaderText = "Iva"
        Me.datagrid1.Columns(3).HeaderText = "Iva Ins"
        Me.datagrid1.Columns(4).HeaderText = "Exento"
        Me.datagrid1.Columns(5).HeaderText = "Imp.Int"
        Me.datagrid1.Columns(6).HeaderText = "Utilidad"
        Me.datagrid1.Columns(7).HeaderText = "P. siva"
        Me.datagrid1.Columns(8).HeaderText = "P. civa"

        Me.datagrid1.Columns(0).Width = 260
        Me.datagrid1.Columns(1).Width = 50
        Me.datagrid1.Columns(2).Width = 50
        Me.datagrid1.Columns(3).Width = 70
        Me.datagrid1.Columns(4).Width = 50
        Me.datagrid1.Columns(5).Width = 50
        Me.datagrid1.Columns(6).Width = 50
        Me.datagrid1.Columns(7).Width = 70
        Me.datagrid1.Columns(8).Width = 70
        Me.datagrid1.Columns(9).Visible = False
        Me.datagrid1.Columns(10).Visible = False
        'Me.datagrid1.Columns(11).Visible = False
        Me.datagrid1.Columns(12).Visible = False
        Me.datagrid1.Columns(13).Visible = False
        Me.datagrid1.Columns(14).Visible = False
        Me.datagrid1.Columns(15).Visible = False
        Me.datagrid1.Columns(16).Visible = False

    End Sub

    Private Sub datagrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles datagrid1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                Form_actualiza_grilla.txt_pos_fila.Text = Me.datagrid1.CurrentCell.RowIndex

                Form_actualiza_grilla.txt_codigo_producto.Text = Me.datagrid1.SelectedCells.Item(11).Value

                Form_actualiza_grilla.lbl_nombre.Text = Me.datagrid1.SelectedCells.Item(0).Value
                Form_actualiza_grilla.txt_costo.Text = Me.datagrid1.SelectedCells.Item(1).Value
                Form_actualiza_grilla.lbl_nom_imp_int.Text = Me.datagrid1.SelectedCells.Item(5).Value
                Form_actualiza_grilla.txt_utilidad.Text = Me.datagrid1.SelectedCells.Item(6).Value
                Form_actualiza_grilla.txt_precio_siva.Text = Me.datagrid1.SelectedCells.Item(7).Value
                Form_actualiza_grilla.txt_pciva.Text = Me.datagrid1.SelectedCells.Item(8).Value
                Form_actualiza_grilla.txt_codigo_iva.Text = Me.datagrid1.SelectedCells.Item(9).Value
                Form_actualiza_grilla.txt_impuestos_internos.Text = Me.datagrid1.SelectedCells.Item(10).Value
                Form_actualiza_grilla.txt_desc1.Text = Me.datagrid1.SelectedCells.Item(12).Value
                Form_actualiza_grilla.txt_desc2.Text = Me.datagrid1.SelectedCells.Item(13).Value
                Form_actualiza_grilla.txt_desc3.Text = Me.datagrid1.SelectedCells.Item(14).Value
                Form_actualiza_grilla.txt_flete.Text = Me.datagrid1.SelectedCells.Item(15).Value
                Form_actualiza_grilla.txt_pago_total.Text = Me.datagrid1.SelectedCells.Item(16).Value
                Form_actualiza_grilla.Show()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_precio_siva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_precio_siva.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_precio_siva.Text = "" Then
                Me.txt_precio_siva.Focus()
                Exit Sub
            End If

            If Me.cmd_modificar.Enabled = False Then Me.cmd_aceptar.Focus()
            If Me.cmd_aceptar.Enabled = False Then Me.cmd_modificar.Focus()

        End If
    End Sub

    Private Sub txt_precio_siva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_siva.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_precio_siva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_siva.LostFocus

        Try
            Me.txt_precio_civa.Text = Me.txt_precio_siva.Text
            Dim val As Double = Format(Me.txt_precio_siva.Text / Me.txt_costo.Text, "0.0000")
            Me.txt_utilidad.Text = Format((val * 100) - 100, "0.000")
            Me.cmd_aceptar.Focus()
        Catch ex As Exception
            Me.txt_precio_siva.Focus()
        End Try

    End Sub

    Private Sub verifica_duplicado()

        If RTrim(Me.txt_codigo.Text) = RTrim(Me.txt_interno.Text) Then Exit Sub

        tbl_dupli.Rows.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select * from art_01 where id_art = '" & Trim(Me.txt_codigo.Text) & "' and id_lista = '" & Trim(Me.txt_lista.Text) & "'", conex)
        comando.Fill(tbl_dupli)

        If tbl_dupli.Rows.Count <> Nothing Then
            MessageBox.Show("El codigo ya existe", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            duplicado = True
        Else
            duplicado = False
        End If

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\articulo.html")
    End Sub

    Private Sub txt_codigo_barra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.LostFocus

        Try

            If Me.txt_codigo_barra.Text = 0 Or Val(Me.txt_codigo_barra.Text) = Nothing Then Exit Sub

            Dim tt As New DataTable

            conex = conecta()
            tt.Clear()

            comando = New SqlDataAdapter("select id_art,nombre from art_01 where codigo_barra = '" & RTrim(Me.txt_codigo_barra.Text) & "'", conex)
            comando.Fill(tt)

            If tt.Rows.Count <> Nothing Then
                MessageBox.Show("El articulo: " & tt.Rows(0).Item(1) & " " & "ya existe !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            tt.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_pago_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txt_pago_total.SelectAll()
    End Sub

    Private Sub txt_descuento1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento1.GotFocus
        Me.txt_descuento1.SelectAll()
    End Sub

    Private Sub txt_descuento1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descuento1.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_descuento2.Focus()
            Me.txt_descuento2.SelectAll()
        End If
    End Sub

    Private Sub txt_descuento1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento1.KeyPress
        num.positivos_punto(e, Me.txt_descuento1)
    End Sub

    Private Sub txt_descuento2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento2.GotFocus
        Me.txt_descuento2.SelectAll()
    End Sub

    Private Sub txt_descuento2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descuento2.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_descuento3.Focus()
            Me.txt_descuento3.SelectAll()
        End If
    End Sub

    Private Sub txt_descuento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento2.KeyPress
        num.positivos_punto(e, Me.txt_descuento2)
    End Sub

    Private Sub txt_descuento3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento3.GotFocus
        Me.txt_descuento3.SelectAll()
    End Sub

    Private Sub txt_descuento3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_descuento3.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_flete.Focus()
            Me.txt_flete.SelectAll()
        End If
    End Sub

    Private Sub txt_descuento3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento3.KeyPress
        num.positivos_punto(e, Me.txt_descuento3)
    End Sub

    Private Sub txt_flete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_flete.GotFocus
        Me.txt_flete.SelectAll()
    End Sub

    Private Sub txt_flete_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_flete.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_pago_total.Focus()
            Me.txt_pago_total.SelectAll()
        End If
    End Sub

    Private Sub txt_flete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_flete.KeyPress
        num.positivos_punto(e, Me.txt_flete)
    End Sub

    Private Sub txt_pago_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        num.positivos_punto(e, Me.txt_pago_total)
    End Sub

    Private Sub txt_codigo_iva_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_codigo_iva.Validating
        If Me.txt_codigo_iva.Text = "" Then
            e.Cancel = False
            Me.txt_codigo_iva.Focus()
        End If
    End Sub

    Private Sub txt_pago_total_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pago_total.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            If fact.usa_utilidad_en_articulo = "SI" Then
                Me.txt_utilidad.Focus()
                Exit Sub
            End If

            If fact.factura_en_c = "SI" Then
                Me.txt_utilidad.Enabled = False
                Me.txt_precio_siva.Enabled = True
                Me.txt_precio_siva.BackColor = Color.White
                Me.txt_precio_siva.ReadOnly = False
                Me.txt_precio_siva.Focus()
            Else
                Me.txt_utilidad.Enabled = False
                Me.txt_precio_civa.Enabled = True
                Me.txt_precio_civa.BackColor = Color.White
                Me.txt_precio_civa.ReadOnly = False
                Me.txt_precio_civa.Focus()
            End If

        End If

    End Sub

    Private Sub txt_precio_civa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_precio_civa.KeyDown
        If e.KeyCode = Keys.Return Then
            'If Me.cmd_modificar.Enabled = False Then Me.cmd_aceptar.Focus()
            'If Me.cmd_aceptar.Enabled = False Then Me.cmd_modificar.Focus()
            Me.cmb_moneda.Focus()
        End If
    End Sub

    Private Sub txt_precio_civa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_civa.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_precio_civa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_civa.LostFocus

        Try

            Dim val1 As Double

            If Me.txt_codigo_iva.Text = 1 Then  ' si es inscripto
                val1 = 1 & "." & Me.lbl_tipo_iva.Text
                Me.txt_precio_siva.Text = Format(Me.txt_precio_civa.Text / val1, "0.000")
                art.iva_insc = Format(Me.txt_precio_civa.Text - Me.txt_precio_siva.Text, "0.00")
            End If

            If Me.txt_codigo_iva.Text = 2 Then ' si es N. inscripto
                val1 = Me.lbl_tipo_iva.Text
                Me.txt_precio_siva.Text = Format(Me.txt_precio_civa.Text - (Me.txt_precio_civa.Text / val1), "0.000")
                art.iva_insc = Format(Me.txt_precio_civa.Text - Me.txt_precio_siva.Text, "0.00")
            End If

            If Me.txt_codigo_iva.Text = 3 Then ' si es exento
                Me.txt_precio_siva.Text = Me.txt_precio_civa.Text
            End If

            Dim val As Double = Format(Me.txt_precio_siva.Text / Me.txt_costo.Text, "0.0000")
            Me.txt_utilidad.Text = Format((val * 100) - 100, "0.000")
            Me.cmd_aceptar.Focus()

        Catch ex As Exception

            Me.txt_precio_civa.Focus()

        End Try

    End Sub

    Private Sub txt_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nombre.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_nombre.Text = "" Then
                Me.txt_nombre.Focus()
                Exit Sub
            End If

            Me.txt_codigo_barra.Focus()
            Me.txt_codigo_barra.SelectAll()
        End If
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        Try

            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

                'Me.txt_codigo.Text = Convert.ToInt32(Me.txt_codigo.Text)

                If Me.txt_codigo.Text = "" Then
                    Me.txt_codigo.Focus()
                    Exit Sub
                End If

                Call carga_navega()

                Call cargar_datos(Me.txt_lista.Text, Me.txt_codigo.Text)
                Me.txt_nombre.Focus()
                Me.txt_codigo_barra.MaxLength = fact.longitud_codigo_barra

            End If

            If e.Alt = True Then
                If e.KeyCode = Keys.F1 Then
                    Me.txt_cantidad.Visible = True
                    Me.Label14.Visible = True
                End If
            End If

            If e.KeyCode = Keys.F1 Then
                busc_articulos.txt_lista.Text = Me.txt_lista.Text
                busc_articulos.Show()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_copiar.Click

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = False
        Me.cmd_eliminar.BackColor = Color.LightGray
        Me.cmd_modificar.Enabled = False
        Me.cmd_modificar.BackColor = Color.LightGray
        Me.cmd_copiar.Enabled = False
        Me.cmd_copiar.BackColor = Color.LightGray

        Me.dt_fec_alta.Value = Date.Now
        Me.dt_fec_modificacion.Value = Date.Now

        selecciona_maximo_id_articulo()

    End Sub

    Private Sub selecciona_maximo_id_articulo()

        Dim ttv As New DataTable

        Try

            ttv.Clear()

            conex = conecta()

            comando = New SqlDataAdapter("select MAX(CONVERT(INT,id_art)) from art_01", conex)
            comando.Fill(ttv)
            comando.Dispose()

            If ttv.Rows.Count > 0 Then
                Me.txt_codigo.Text = Val(ttv.Rows(0).Item(0)) + 1
                Me.txt_nombre.Focus()
                Me.txt_nombre.SelectAll()
            End If


        Catch ex As Exception

        Finally

            ttv.Dispose()

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            Try

                Call cargar_datos(Me.DataGridView1.SelectedCells.Item(0).Value, Me.DataGridView1.SelectedCells.Item(2).Value)
                Me.txt_nombre.Focus()
                Me.txt_nombre.SelectAll()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub txt_buscador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_buscador.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.txt_buscador.Text <> "" Then

                Me.DataGridView1.Rows.Clear()

                conex = conecta()
                If conex.State = ConnectionState.Closed Then conex.Open()

                coman = New SqlCommand("select id_lista1,lista,id_art1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,mueve_stok,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and art_precio.id_lista1 = '" & RTrim(Me.txt_lista.Text) & "' where (nombre like '%" & Trim(Me.txt_buscador.Text) & "%' or id_art like '%" & Trim(Me.txt_buscador.Text) & "%' or proveedor like '%" & Trim(Me.txt_buscador.Text) & "%' or rubro like '%" & Trim(Me.txt_buscador.Text) & "%') order by nombre ASC", conex)

                reader = coman.ExecuteReader()

                If reader.HasRows Then

                    Do While reader.Read()
                        Me.DataGridView1.Rows.Add()
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Value = Trim(reader.Item("id_lista1"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = Trim(reader.Item("lista"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2).Value = Trim(reader.Item("id_art1"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(3).Value = Trim(reader.Item("nombre"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(4).Value = Trim(reader.Item("id_rubro"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(5).Value = Trim(reader.Item("rubro"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(6).Value = Trim(reader.Item("codigo_barra"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(7).Value = Trim(reader.Item("cantidad"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(8).Value = Trim(reader.Item("cantidad_bulto"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(9).Value = Trim(reader.Item("id_proveedor"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(10).Value = Trim(reader.Item("proveedor"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(11).Value = Trim(reader.Item("mueve_stok"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(12).Value = Trim(reader.Item("fec_alta"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(13).Value = Trim(reader.Item("fec_modi"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(14).Value = Trim(reader.Item("estado"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(15).Value = Trim(reader.Item("costo"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(16).Value = Trim(reader.Item("id_iva"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(17).Value = Trim(reader.Item("iva"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(18).Value = Trim(reader.Item("iva_insc"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(19).Value = Trim(reader.Item("cod_imp"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(20).Value = Trim(reader.Item("impuestos"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(21).Value = Trim(reader.Item("exento"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(22).Value = Trim(reader.Item("utilidad"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(23).Value = Trim(reader.Item("precio_civa"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(24).Value = Trim(reader.Item("precio_siva"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(25).Value = Trim(reader.Item("desc1"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(26).Value = Trim(reader.Item("desc2"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(27).Value = Trim(reader.Item("desc3"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(28).Value = Trim(reader.Item("flete"))
                        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(29).Value = Trim(reader.Item("pago_total"))
                        barra_carga.PictureBox1.Refresh()
                    Loop

                    Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                    Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
                    Me.txt_buscador.Text = ""
                    Me.DataGridView1.Focus()

                End If

                reader.Close()
                If conex.State = ConnectionState.Open Then conex.Close()
                coman.Dispose()

            End If

        End If
    End Sub

    Private Sub chk_estado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_estado.CheckedChanged
        carga_grilla_productos()
    End Sub

    Private Sub selecciona_datos_moneda()

        Dim tb As New DataTable
        tb.Clear()

        valor_moneda = 0

        Try

            conex = conecta()

            comando = New SqlDataAdapter("Select fecha,id,importe from moneda where id = '" & Trim(Me.cmb_moneda.Text) & "' and fecha = '" & Trim(Form_login.DateTimePicker1.Text) & "'", conex)
            comando.Fill(tb)
            comando.Dispose()

            valor_moneda = tb.Rows(0).Item(2)

        Catch ex As Exception

        Finally

            tb.Dispose()

        End Try

    End Sub

    Private Sub cmb_moneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_moneda.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmd_modificar.Enabled = False Then Me.cmd_aceptar.Focus()
            If Me.cmd_aceptar.Enabled = False Then Me.cmd_modificar.Focus()
        End If
    End Sub

    Private Sub cmb_unid_med_secundaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_unid_med_secundaria.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmb_unid_med_secundaria.Text = "SI" Then
                Me.txt_peso_promedio.Enabled = True
                Me.txt_peso_promedio.Focus()
                Me.txt_peso_promedio.SelectAll()
            Else
                Me.txt_peso_promedio.Enabled = False
                Me.txt_peso_promedio.Text = 0
                Me.txt_bonif_ventas.Focus()
            End If
        End If
    End Sub

    Private Sub txt_peso_promedio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_peso_promedio.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_bonif_ventas.Focus()
            Me.txt_bonif_ventas.SelectAll()
        End If
    End Sub

    Private Sub txt_lis_origen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lis_origen.KeyDown

        If e.KeyCode = Keys.F1 Then
            control = "O"
            busc_lista.Show()
        End If

        If e.KeyCode = Keys.Return Then
            xxx.instruccion = "select *from lista_01 where id_lis = '" & RTrim(Me.txt_lis_origen.Text) & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_lis_origen.Text = xxx.text
            Me.lbl_lis_origen.Text = xxx.text2
            Me.txt_lis_destino.Focus()
            Me.txt_lis_destino.SelectAll()

        End If

    End Sub

    Private Sub txt_bonif_ventas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bonif_ventas.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_costo.SelectAll()
            Me.txt_costo.Focus()
        End If
    End Sub


    Private Sub txt_bonif_ventas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_bonif_ventas.KeyPress
        num.positivos_punto(e, Me.txt_bonif_ventas)
    End Sub

    Private Sub txt_codigo_iva_expotador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_iva_expotador.KeyDown

        Try

            If e.KeyCode = Keys.F1 Then
                busc_iva.Show()
            End If

            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

                xxx.instruccion = "select *from iva_01 where id_iva like '" & Me.txt_codigo_iva_expotador.Text & "'"
                xxx.codigo = "id_iva"
                xxx.nombre = "iva_insc"
                xxx.cargar()
                Me.txt_codigo_iva_expotador.Text = xxx.text
                Me.lbl_tipo_iva_exportador.Text = xxx.text2

                Me.cmd_exporta.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class