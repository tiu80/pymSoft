Imports System.Data
Imports System.Data.SqlClient

Public Class Form_actualiza_grilla

    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim art As New pymsoft.articulo
    Dim fact As New pymsoft.factura
    Dim num As New pymsoft.numerodecimales
    Dim iva, p_ant As Double

    Dim tb As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim coman As SqlCommand

    Private Sub txt_costo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_costo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_codigo_iva.Focus()
        End If

        If e.KeyCode = Keys.F2 Then
            Me.lbl_nombre.Enabled = True
            Me.lbl_nombre.Focus()
            Me.lbl_nombre.SelectAll()
        End If
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_costo.KeyPress
        num.positivos_punto(e, Me.txt_costo)
    End Sub

    Private Sub txt_codigo_iva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_iva.GotFocus
        Me.txt_codigo_iva.SelectAll()
    End Sub

    Private Sub txt_codigo_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_iva.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from iva_01 where id_iva like '" & Me.txt_codigo_iva.Text & "'"
            xxx.codigo = "id_iva"
            xxx.nombre = "iva_insc"
            xxx.cargar()
            Me.txt_codigo_iva.Text = xxx.text
            Me.lbl_tipo_iva.Text = xxx.text2

            Call carga_config_iva()

            Me.txt_impuestos_internos.Focus()

        End If

    End Sub

    Private Sub Form_actualiza_grilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_costo.Focus()
        fact.carga_parametro()

        p_ant = Me.txt_pciva.Text

        Call carga_config_iva()

    End Sub

    Private Sub txt_impuestos_internos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_impuestos_internos.GotFocus
        Me.txt_impuestos_internos.SelectAll()
    End Sub

    Private Sub txt_impuestos_internos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_impuestos_internos.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

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

            If fact.usa_utilidad_en_articulo = "SI" Then
                Me.txt_utilidad.Focus()
                Exit Sub
            Else
                Me.txt_precio_siva.Focus()
                Me.txt_precio_siva.ReadOnly = False
            End If

            If fact.factura_en_c = "NO" Then
                Me.txt_utilidad.Enabled = False
                Me.txt_pciva.Enabled = True
                Me.txt_pciva.ReadOnly = False
                Me.txt_pciva.BackColor = Color.White
                Me.txt_pciva.SelectAll()
                Me.txt_pciva.Focus()
            End If

        End If
    End Sub

    Private Sub txt_utilidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_utilidad.GotFocus
        Me.txt_utilidad.Select()
    End Sub

    Private Sub txt_utilidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_utilidad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_actualiza.Focus()
        End If
    End Sub

    Private Sub txt_utilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_utilidad.KeyPress
        num.positivos_punto(e, Me.txt_utilidad)
    End Sub

    Private Sub txt_utilidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_utilidad.LostFocus

        If Me.txt_codigo_iva.Text = Nothing Then
            MessageBox.Show("Selccione un codigo de iva correcto", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txt_codigo_iva.Focus()
            Exit Sub
        End If

        art.costo = Me.txt_costo.Text
        art.iva = Me.lbl_tipo_iva.Text
        art.impuestos_internos = Me.lbl_nom_imp_int.Text
        art.uilidad = Me.txt_utilidad.Text
        art.descuento1 = Me.txt_desc1.Text
        art.descuento2 = Me.txt_desc2.Text
        art.descuento3 = Me.txt_desc3.Text
        art.flete = Me.txt_flete.Text
        art.pago_total = Me.txt_pago_total.Text

        If fact.factura_en_c = "NO" Then art.calcular_precio_final()
        If fact.factura_en_c = "SI" Then art.calcular_precio_final_monotributo()

        Me.txt_precio_siva.Text = Format(art.precio_siva, "0.000")
        Me.txt_pciva.Text = Format(art.precio_civa, "0.000")

        iva = Format(Me.txt_pciva.Text - Me.txt_precio_siva.Text, "0.00")

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        If Form_articulos.opt_act_grilla.Checked = True Then

            iva = Format(Me.txt_pciva.Text - Me.txt_precio_siva.Text, "0.00")

            If Me.txt_costo.Text <> "" And Me.txt_codigo_iva.Text <> "" And Me.txt_utilidad.Text <> "" Then

                art.instruccion = "update art_01 set fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_art = '" & Me.txt_codigo_producto.Text & "' and id_lista = '" & Form_articulos.txt_list.Text & "'"
                art.actualizar()

                art.instruccion = "update art_precio set costo ='" & Me.txt_costo.Text & "',id_iva ='" & Me.txt_codigo_iva.Text & "',iva ='" & Me.lbl_tipo_iva.Text & "',cod_imp = '" & Me.txt_impuestos_internos.Text & "',impuestos ='" & Me.lbl_nom_imp_int.Text & "',utilidad='" & Me.txt_utilidad.Text & "',precio_siva='" & Me.txt_precio_siva.Text & "',precio_civa='" & Me.txt_pciva.Text & "',iva_insc= '" & iva & "',desc1 = '" & Val(Me.txt_desc1.Text) & "',desc2 = '" & Val(Me.txt_desc2.Text) & "',desc3 = '" & Val(Me.txt_desc3.Text) & "',flete = '" & Val(Me.txt_flete.Text) & "',pago_total = '" & Val(Me.txt_pago_total.Text) & "' where id_art1 = '" & Me.txt_codigo_producto.Text & "' and id_lista1 = '" & Form_articulos.txt_list.Text & "'"
                art.actualizar()

                Call carga_tabla_precio_01()
                Call modifica_grilla()

                Me.Close()

            Else

                MessageBox.Show("Complete los campos!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

        Else

            If Me.txt_costo.Text <> "" And Me.txt_codigo_iva.Text <> "" And Me.txt_utilidad.Text <> "" Then

                'If form_factura.tipo1 <> "PD" And form_factura.txt_tipo_fact.Text <> "FC" And form_factura.txt_tipo_fact.Text <> "NC" Then

                art.instruccion = "update art_precio set costo ='" & Me.txt_costo.Text & "',id_iva ='" & Me.txt_codigo_iva.Text & "',iva ='" & Me.lbl_tipo_iva.Text & "',cod_imp = '" & Me.txt_impuestos_internos.Text & "',impuestos ='" & Me.lbl_nom_imp_int.Text & "',utilidad='" & Me.txt_utilidad.Text & "',precio_siva='" & Me.txt_precio_siva.Text & "',precio_civa='" & Me.txt_pciva.Text & "',iva_insc= '" & iva & "',desc1= '" & Val(Me.txt_desc1.Text) & "',desc2 = '" & Val(Me.txt_desc2.Text) & "',desc3 = '" & Val(Me.txt_desc3.Text) & "',flete = '" & Val(Me.txt_flete.Text) & "',pago_total = '" & Val(Me.txt_pago_total.Text) & "',nom = '" & Me.lbl_nombre.Text & "' where id_art1 = '" & RTrim(Me.txt_codigo_producto.Text) & "' and id_lista1 = '" & RTrim(form_factura.txt_cod_lista.Text) & "'"
                art.actualizar()

                art.instruccion = "update art_01 set nombre = '" & Me.lbl_nombre.Text & "',fec_modi = '" & CDate(Date.Now).ToString("dd/MM/yyyy") & "' where id_art = '" & Me.txt_codigo_producto.Text & "' and id_lista = '" & RTrim(form_factura.txt_cod_lista.Text) & "'"
                art.actualizar()

                form_factura.txt_nombre_producto.Text = Me.lbl_nombre.Text

                'End If

                form_factura.txt_neto.Text = Me.txt_precio_siva.Text
                form_factura.txt_neto1.Text = Me.txt_precio_siva.Text
                form_factura.txt_precioCiva.Text = Me.txt_pciva.Text
                form_factura.txt_iva_ins.Text = Format(Me.txt_pciva.Text - Me.txt_precio_siva.Text, "0.00")
                form_factura.txt_imp_interno.Text = Me.txt_impuestos_internos.Text
                form_factura.txt_iva1.Text = Me.lbl_tipo_iva.Text
                If Me.txt_codigo_iva.Text = "0" Then form_factura.txt_exento1.Text = Me.txt_precio_siva.Text
                form_factura.txt_precio_costo.Text = Me.txt_costo.Text
                form_factura.txt_utilidad.Text = Me.txt_utilidad.Text
                form_factura.txt_cod_iva.Text = Me.txt_codigo_iva.Text

                Me.Close()

            Else

                MessageBox.Show("Complete los campos!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

        End If

    End Sub

    Private Sub modifica_grilla()

        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(1).Value = Me.txt_costo.Text
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(2).Value = Me.lbl_tipo_iva.Text
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(3).Value = iva
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(6).Value = Me.txt_utilidad.Text

        If Me.txt_impuestos_internos.Text = "" Or Val(Me.txt_impuestos_internos.Text) = 0 Then
            Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(5).Value = 0
            Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(10).Value = 0
        Else
            Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(5).Value = Val(Me.lbl_nom_imp_int.Text)
            Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(10).Value = Val(Me.txt_impuestos_internos.Text)
        End If

        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(7).Value = Me.txt_precio_siva.Text
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(8).Value = Me.txt_pciva.Text
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(12).Value = Val(Me.txt_desc1.Text)
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(13).Value = Val(Me.txt_desc2.Text)
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(14).Value = Val(Me.txt_desc3.Text)
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(15).Value = Val(Me.txt_flete.Text)
        Form_articulos.datagrid1.Rows(Me.txt_pos_fila.Text).Cells(16).Value = Val(Me.txt_pago_total.Text)

    End Sub

    Private Sub txt_impuestos_internos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_impuestos_internos.LostFocus
        If Me.txt_impuestos_internos.Text = "" Then
            Me.txt_impuestos_internos.Text = 0
        End If
    End Sub

    Private Sub txt_precio_siva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_precio_siva.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_precio_siva.Text > 0 Then
                Me.cmd_actualiza.Focus()
            Else
                Me.txt_precio_siva.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_precio_siva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_siva.LostFocus
        If fact.factura_en_c = "SI" Then Me.txt_pciva.Text = Me.txt_precio_siva.Text
        Dim val As Double = Format(Me.txt_precio_siva.Text / Me.txt_costo.Text, "0.0000")
        Me.txt_utilidad.Text = Format(val * 100, "0.000") - 100
        'Me.cmd_actualiza.Focus()
    End Sub

    Private Sub carga_config_iva()

        conex = conecta()
        tb.Clear()

        comando = New SqlDataAdapter("select iva_insc from iva_01 where id_iva = '" & RTrim(Me.txt_codigo_iva.Text) & "'", conex)
        comando.Fill(tb)

        If tb.Rows.Count = Nothing Then
            Exit Sub
        End If

        If Me.txt_codigo_iva.Text = 1 Then

            Me.lbl_tipo_iva.Text = tb.Rows(0).Item(0)
            Me.lbl_nombre_iva.Text = " % " & "Resp.Insc"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter

        End If

        If Me.txt_codigo_iva.Text = 2 Then

            Me.lbl_tipo_iva.Text = tb.Rows(0).Item(0)
            Me.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter

        End If

        If Me.txt_codigo_iva.Text = 3 Then

            Me.lbl_tipo_iva.Text = tb.Rows(0).Item(0)
            Me.lbl_nombre_iva.Text = " % " & "Exento"
            Me.lbl_tipo_iva.TextAlign = ContentAlignment.MiddleCenter

        End If

    End Sub

    Private Sub carga_tabla_precio_01()

        Dim tt As New DataTable
        Dim var As Double

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        tt.Clear()

        comando = New SqlDataAdapter("select id_art,detalle,precio,lista,precio_nuevo from precio_01 where id_art = '" & RTrim(Me.txt_codigo_producto.Text) & "'", conex)
        comando.Fill(tt)

        var = Format(Me.txt_pciva.Text - p_ant, "0.00")

        If tt.Rows.Count = Nothing Then

            If var <> 0 Then

                coman = New SqlCommand("insert into precio_01(id_art,detalle,precio,lista,precio_nuevo,variacion) values ('" & Me.txt_codigo_producto.Text & "','" & Me.lbl_nombre.Text & "','" & p_ant & "','" & Form_articulos.txt_list.Text & "','" & Me.txt_pciva.Text & "','" & var & "')", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()

                If conex.State = ConnectionState.Open Then conex.Close()
                tt.Dispose()

            End If

        Else

            If RTrim(tt.Rows(0).Item(4)) <> RTrim(Me.txt_pciva.Text) Then

                If var <> 0 Then

                    coman = New SqlCommand("update precio_01 set precio = '" & p_ant & "',precio_nuevo = '" & Me.txt_pciva.Text & "',variacion = '" & var & "' where id_art = '" & Me.txt_codigo_producto.Text & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                    If conex.State = ConnectionState.Open Then conex.Close()
                    tt.Dispose()

                End If

            End If

        End If

    End Sub

    Private Sub txt_desc1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desc1.KeyPress
        num.positivos_punto(e, Me.txt_desc1)
    End Sub

    Private Sub txt_desc2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desc2.KeyPress
        num.positivos_punto(e, Me.txt_desc2)
    End Sub

    Private Sub txt_desc3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desc3.KeyPress
        num.positivos_punto(e, Me.txt_desc3)
    End Sub

    Private Sub txt_flete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_flete.KeyPress
        num.positivos_punto(e, Me.txt_flete)
    End Sub

    Private Sub txt_pago_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pago_total.KeyPress
        num.positivos_punto(e, Me.txt_pago_total)
    End Sub

    Private Sub txt_pciva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pciva.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_actualiza.Focus()
        End If
    End Sub

    Private Sub txt_pciva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pciva.LostFocus

        Dim val1 As Double

        If Me.txt_codigo_iva.Text = 1 Then  ' si es inscripto
            val1 = 1 & "." & Me.lbl_tipo_iva.Text
            Me.txt_precio_siva.Text = Format(Me.txt_pciva.Text / val1, "0.000")
        End If

        If Me.txt_codigo_iva.Text = 2 Then ' si es N. inscripto
            val1 = Me.lbl_tipo_iva.Text
            Me.txt_precio_siva.Text = Format(Me.txt_pciva.Text - (Me.txt_pciva.Text / val1), "0.000")
        End If

        If Me.txt_codigo_iva.Text = 3 Then ' si es exento
            Me.txt_precio_siva.Text = Me.txt_pciva.Text
        End If

        Dim val As Double = Format(Me.txt_precio_siva.Text / Me.txt_costo.Text, "0.0000")
        Me.txt_utilidad.Text = Format((val * 100) - 100, "0.000")
        Me.cmd_actualiza.Focus()

    End Sub

    Private Sub lbl_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbl_nombre.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_costo.Focus()
            Me.txt_costo.SelectAll()
            Me.lbl_nombre.Enabled = False
        End If
    End Sub

End Class