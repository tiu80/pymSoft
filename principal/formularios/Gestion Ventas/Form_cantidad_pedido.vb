Imports System.Data
Imports System.Data.SqlClient

Public Class Form_cantidad_pedido

    Public i As Integer = 0
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim coman As SqlCommand
    Dim total, total1, total2 As Single
    Dim temp, temp1, temp2, cant_temp As Double
    Public ins, nins, exento, imp_interno, sub_total As Double
    Dim entra As Boolean = False, mod_precio As Boolean = False

    Dim trans As SqlTransaction

    Dim art As New pymsoft.articulo
    Dim num As New pymsoft.numerodecimales
    Dim fact As New pymsoft.factura

    Private Sub txt_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                If Trim(Me.lbl_uni_sec.Text) = "NO" Then
                    Me.txt_unidad_secundaria.Enabled = False
                Else
                    Me.txt_unidad_secundaria.Enabled = True
                End If

                If Me.txt_unidad_secundaria.Enabled = False Then
                    'Call carga_grilla()
                    Me.txt_desc_rcgo.Focus()
                    Me.txt_desc_rcgo.SelectAll()

                Else

                    Me.txt_unidad_secundaria.Focus()
                    Me.txt_unidad_secundaria.SelectAll()
                    Me.txt_unidad_secundaria.BackColor = Color.Red
                    Me.txt_unidad_secundaria.ForeColor = Color.White

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        num.positivos_punto(e, Me.txt_cantidad)
    End Sub

    Public Sub calcula_totales(ByVal cantidad_peso)

        If RTrim(Val(Me.txt_desc_rcgo.Text)) = "" Or RTrim(Val(Me.txt_desc_rcgo.Text)) = 0 Then

            Call selecciona_precio_real()

            total = cantidad_peso * Me.lbl_p_siva.Text   'total sin iva
            Form_factura_preventa.DataGridView1.Rows(i).Cells(10).Value = Format(total, "0.00")

            total1 = cantidad_peso * Me.lbl_p_civa.Text   ' total con iva
            Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value = Format(total1, "0.00")

            total2 = Me.lbl_costo.Text * cantidad_peso  ' total costo
            Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value = Format(total2, "0.00")

            Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Me.lbl_p_civa.Text
            Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value = Me.lbl_p_siva.Text

            Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value = Me.txt_desc_rcgo.Text
            Form_factura_preventa.DataGridView1.Rows(i).Cells(19).Value = Me.lbl_p_civa.Text
            Form_factura_preventa.DataGridView1.Rows(i).Cells(22).Value = Me.lbl_p_siva.Text

        Else

            If Form_factura_preventa.fact.factura_en_c = "SI" Then

                Call selecciona_precio_real()

                Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value = Format(Me.lbl_p_civa.Text - (-(Me.lbl_p_civa.Text * Me.txt_desc_rcgo.Text) / 100), "0.000")
                total = (cantidad_peso * Me.lbl_p_civa.Text) - ((cantidad_peso * Me.lbl_p_civa.Text) * (-Me.txt_desc_rcgo.Text)) / 100   'total sin iva
                Form_factura_preventa.DataGridView1.Rows(i).Cells(10).Value = Format(total, "0.00")

                Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Me.lbl_precio_original.Text
                Form_factura_preventa.DataGridView1.Rows(i).Cells(19).Value = Me.lbl_precio_original.Text
                total1 = (cantidad_peso * Me.lbl_p_civa.Text) - ((cantidad_peso * Me.lbl_p_civa.Text) * (-Me.txt_desc_rcgo.Text)) / 100   'total sin iva
                Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value = Format(total1, "0.00")

                total2 = Me.lbl_costo.Text * cantidad_peso  ' total costo
                Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value = Format(total2, "0.00")

                Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value = Me.txt_desc_rcgo.Text

            Else

                Call selecciona_precio_real()

                Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value = Format(Me.lbl_p_siva.Text - (-(Me.lbl_p_siva.Text * Me.txt_desc_rcgo.Text) / 100), "0.000")
                total = cantidad_peso * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value   'total sin iva
                Form_factura_preventa.DataGridView1.Rows(i).Cells(10).Value = Format(total, "0.00")

                Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Format(Me.lbl_p_civa.Text - (-(Me.lbl_p_civa.Text * Me.txt_desc_rcgo.Text) / 100), "0.000")
                total1 = cantidad_peso * Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value)  ' total con iva
                Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value = Format(total1, "0.00")

                total2 = Me.lbl_costo.Text * cantidad_peso  ' total costo
                Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value = Format(total2, "0.000")

                Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value = Me.txt_desc_rcgo.Text

            End If

        End If

    End Sub

    Private Sub selecciona_precio_real()

        If fact.factura_en_c = "NO" Then

            Dim tb_precio As New DataTable
            tb_precio.Clear()

            conex = conecta()

            comando = New SqlDataAdapter("select costo,precio_siva,precio_civa from art_precio where id_art1 = '" & RTrim(Me.lbl_codigo.Text) & "'", conex)
            comando.Fill(tb_precio)
            comando.Dispose()

            If mod_precio = False Then

                Me.lbl_costo.Text = Format(tb_precio.Rows(0).Item(0), "0.000")
                Me.lbl_p_siva.Text = Format(tb_precio.Rows(0).Item(1), "0.000")
                Me.lbl_p_civa.Text = Format(tb_precio.Rows(0).Item(2), "0.000")

            Else

                ''Dim ins As Double = Format(tot - (tot / Val("1." & porcentaje_impuesto)), "0.00")
                Me.lbl_precio_original.Text = Format(tb_precio.Rows(0).Item(2), "0.000")
                Me.lbl_p_civa.Text = Me.txt_precio.Text
                Me.lbl_p_siva.Text = Format(Me.txt_precio.Text / Val("1." & Val(Form_factura_preventa.DataGridView1.SelectedCells(5).Value)), "0.000")

            End If

        Else

            Dim tb_precio As New DataTable
            tb_precio.Clear()

            conex = conecta()

            comando = New SqlDataAdapter("select costo,precio_siva,precio_civa from art_precio where id_art1 = '" & RTrim(Me.lbl_codigo.Text) & "'", conex)
            comando.Fill(tb_precio)
            comando.Dispose()

            If mod_precio = False Then

                Me.lbl_precio_original.Text = Format(tb_precio.Rows(0).Item(2), "0.000")
                Me.lbl_costo.Text = Format(tb_precio.Rows(0).Item(0), "0.000")
                Me.lbl_p_siva.Text = Format(tb_precio.Rows(0).Item(1), "0.000")
                Me.lbl_p_civa.Text = Format(tb_precio.Rows(0).Item(2), "0.000")
                Me.txt_desc_rcgo.ReadOnly = True

            Else

                Me.lbl_precio_original.Text = Format(tb_precio.Rows(0).Item(2), "0.000")
                Me.lbl_p_civa.Text = Me.txt_precio.Text
                Me.lbl_p_siva.Text = Me.txt_precio.Text

            End If

        End If

    End Sub

    Private Sub actualiza_grilla_cantidad()

        Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value = Me.txt_cantidad.Text

        If fact.mueve_stock = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

            If (RTrim(Me.lbl_cant.Text) <> RTrim(Me.txt_cantidad.Text)) Or Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White Then

                Try

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.Serializable)
                    End If

                    If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(8).Value) = "NO" Or Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White Then Me.lbl_cant.Text = 0

                    Me.lbl_stock.Text = Format(Me.lbl_stock.Text - Me.txt_cantidad.Text + Me.lbl_cant.Text, "0.00")

                    coman = New SqlCommand("update art_01 with (rowlock,xlock) set cantidad= '" & Me.lbl_stock.Text & "' where id_art= '" & Me.lbl_codigo.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    'coman = New SqlCommand("update fact_det set cantidad_sin_stock = 'NO',cantidad1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value & "',precio_unidad = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value & "',iva1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value & "',val_uni_sec = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Form_factura_preventa.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Form_factura_preventa.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Form_factura_preventa.lt) & "' and codi_producto = '" & RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value) & "' and fila = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(23).Value & "'", conex)
                    'coman.Transaction = trans
                    'coman.ExecuteNonQuery()

                    coman = New SqlCommand("update fact_det set cantidad1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value & "',precio_unidad = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value & "',iva1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value & "',val_uni_sec = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Form_factura_preventa.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Form_factura_preventa.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Form_factura_preventa.lt) & "' and codi_producto = '" & RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value) & "' and fila = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(23).Value & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    Form_factura_preventa.DataGridView1.Rows(i).Cells(21).Value = "1" ' si edito la cantidad le pongo 1

                    trans.Commit()

                Catch ex As Exception

                    trans.Rollback()

                Finally

                    conex.Close()

                End Try

            Else

                Form_factura_preventa.edita = "NO"
                Form_factura_preventa.DataGridView1.Rows(i).Cells(21).Value = "0" ' si NO edito la cantidad le pongo 0

            End If

        End If

        If fact.mueve_stock = "NO" And RTrim(Me.lbl_art_mueve_stok.Text) = "NO" Then

            art.instruccion = "update fact_det set cantidad_sin_stock = 'NO',cantidad1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value & "',precio_unidad = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value & "',iva1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value & "',val_uni_sec = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Form_factura_preventa.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Form_factura_preventa.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Form_factura_preventa.lt) & "' and codi_producto = '" & RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value) & "' and fila = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(23).Value & "'"
            art.actualizar()

            Form_factura_preventa.DataGridView1.Rows(i).Cells(21).Value = "1" ' si edito la cantidad le pongo 1

            conex.Close()

        End If

    End Sub

    Private Sub actualiza_grilla_cantidad_busqueda(ByVal pos As Integer)

        Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value = Me.txt_cantidad.Text

        If fact.mueve_stock = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

            If RTrim(Me.lbl_cant.Text) <> RTrim(Me.txt_cantidad.Text) Then

                Try

                    Call form_factura.falla_stk(Me.lbl_codigo.Text, Me.lbl_articulo.Text, My.Computer.Name, Me.txt_cantidad.Text, Form_factura_preventa.txt_tipo.Text, Form_factura_preventa.txt_numero.Text, Form_factura_preventa.txt_prefijo.Text, Form_factura_preventa.txt_letra.Text, Form_factura_preventa.txt_talon.Text, Form_factura_preventa.DataGridView1.Rows(Me.lbl_indice.Text).Cells(23).Value)

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.Serializable)
                    End If

                    temp2 = Me.txt_cantidad.Text

                    Me.lbl_stock.Text = Format(Me.lbl_stock.Text - Me.txt_cantidad.Text, "0.00")

                    coman = New SqlCommand("update art_01 with (rowlock,xlock) set cantidad= '" & Me.lbl_stock.Text & "' where id_art= '" & Me.lbl_codigo.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    coman = New SqlCommand("update fact_det set cantidad_sin_stock = 'NO',cantidad1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value & "',precio_unidad = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value & "',iva1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value & "',val_uni_sec = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Form_factura_preventa.txt_numero.Text) & "' and prefijo_fact2 = '" & RTrim(Form_factura_preventa.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Form_factura_preventa.lt) & "' and codi_producto = '" & RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value) & "' and fila ='" & pos & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    'coman = New SqlCommand("INSERT INTO fact_det(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,nom_producto,vend1,costo,cod_prov,cod_rub) VALUES('01011900','" & Trim(Form_factura_preventa.txt_numero.Text) & "' ,'PD','" & Trim(Form_factura_preventa.txt_prefijo.Text) & "','" & RTrim(Form_factura_preventa.lt) & "','" & Val(Me.DataGridView1.Rows(i).Cells(0).Value) & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','','" & Me.DataGridView1.Rows(i).Cells(9).Value & "','" & Me.DataGridView1.Rows(i).Cells(6).Value & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(19).Value & "','" & Me.DataGridView1.Rows(i).Cells(11).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "', '" & Me.DataGridView1.Rows(i).Cells(3).Value & "', '" & Me.txt_cod_lis.Text & "','" & Date.Now.Month & "', '" & Date.Now.Year & "', '" & Me.txt_talon.Text & "','NO','" & i & "','" & Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value & "','" & Me.txt_vendedor.Text & "','" & Me.DataGridView1.Rows(i).Cells(15).Value & "','" & Me.DataGridView1.Rows(i).Cells(16).Value & "','" & Me.DataGridView1.Rows(i).Cells(17).Value & "')", conex)
                    'coman.Transaction = trans
                    'coman.ExecuteNonQuery()
                    'coman.Dispose()

                    Form_factura_preventa.edita = "SI"
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(12).Value = ""

                    trans.Commit()

                Catch ex As Exception

                    trans.Rollback()

                Finally

                    conex.Close()

                End Try

            Else

                Form_factura_preventa.edita = "NO"
                Form_factura_preventa.DataGridView1.Rows(i).Cells(12).Value = "1"

            End If

        End If

    End Sub

    Private Sub calcula_iva()

        If fact.factura_en_c = "NO" Then

            If RTrim(Val(Me.txt_desc_rcgo.Text)) = "" Or RTrim(Val(Me.txt_desc_rcgo.Text)) = 0 Then

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "21" Then
                If Trim(Me.lbl_idiva.Text) = "1" Then
                    'temp = Format(total1 - total, "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "NO" Then temp = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "SI" Then temp = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    imp_interno = imp_interno + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = temp
                End If

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "10.5" Then
                If Trim(Me.lbl_idiva.Text) = "2" Then
                    'temp1 = Format(total1 - total, "0.00")
                    Me.lbl_iva.Text = Val(Me.lbl_iva.Text * 10)
                    If Trim(Me.lbl_uni_sec.Text) = "NO" Then temp1 = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "SI" Then temp1 = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    imp_interno = imp_interno + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = temp1
                End If

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "0" Then
                If Trim(Me.lbl_idiva.Text) = "3" Then
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value)
                End If

            Else

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "21" Then
                If Trim(Me.lbl_idiva.Text) = "1" Then
                    'temp = Format(total1 - total, "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "NO" Then temp = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "SI" Then temp = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    imp_interno = imp_interno + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = temp
                End If

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "10.5" Then
                If Trim(Me.lbl_idiva.Text) = "2" Then
                    'temp1 = Format(total1 - total, "0.00")
                    Me.lbl_iva.Text = Val(Me.lbl_iva.Text * 10)
                    If Trim(Me.lbl_uni_sec.Text) = "NO" Then temp1 = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    If Trim(Me.lbl_uni_sec.Text) = "SI" Then temp1 = Format((Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value * Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value) * Val("0." & Me.lbl_iva.Text), "0.00")
                    imp_interno = imp_interno + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value)
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = temp1
                End If

                'If RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value) = "0" Then
                If Trim(Me.lbl_idiva.Text) = "3" Then
                    Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value = Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value)
                End If

            End If

        Else

            imp_interno = 0
            Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value = 0

        End If

        art.instruccion = "update fact_det set precio_unidad = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(3).Value & "',precio_civa1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(4).Value & "',iva1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(5).Value & "',imp_interno = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(6).Value & "',exento1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(7).Value & "',iva_inscripto = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(9).Value & "',total1 = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(11).Value & "',costo = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value & "',descuento = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(18).Value & "' where tipo_fact2 ='PD' and num_fact = '" & RTrim(Form_factura_preventa.txt_numero.Text) & "' and  prefijo_fact2 = '" & RTrim(Form_factura_preventa.txt_prefijo.Text) & "' and letra_fact1 = '" & RTrim(Form_factura_preventa.lt) & "' and codi_producto = '" & RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value) & "' and fila ='" & Form_factura_preventa.DataGridView1.Rows(i).Cells(23).Value & "'"
        art.actualizar()

        'End If

    End Sub

    Private Sub falla_stk(ByVal codigo, ByVal nombre, ByVal computer, ByVal cantidad, ByVal tipo, ByVal fila)

        If RTrim(fact.mueve_stock) = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

            ' carga articulos en tabla especial por posibles cortes de luz

            Dim tbl2 As New DataTable

            tbl2.Clear()

            conex = conecta()
            comando = New SqlDataAdapter("select * from act_art where codart = '" & codigo & "' and computer = '" & computer & "'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
                trans = conex.BeginTransaction(IsolationLevel.Serializable)
            End If

            If tbl2.Rows.Count = Nothing Then

                coman = New SqlCommand("INSERT INTO act_art(codart,des,cant,computer,tipo,numero,lt,pre,talonario,fila) VALUES('" & codigo & "' , '" & nombre & "', '" & cantidad & "', '" & computer & "','" & tipo & "','" & Form_factura_preventa.txt_numero.Text & "','" & Form_factura_preventa.txt_letra.Text & "','" & Form_factura_preventa.txt_prefijo.Text & "','" & Form_factura_preventa.txt_talon.Text & "','" & fila & "')", conex)
                coman.Transaction = trans
                coman.ExecuteNonQuery()
                coman.Dispose()

            Else

                cant_temp = tbl2.Rows(0).Item(2) + cantidad

                coman = New SqlCommand("UPDATE act_art set cant = '" & cant_temp & "' where codart = '" & codigo & "' and tipo = '" & tipo & "' and numero = '" & Form_factura_preventa.txt_numero.Text & "' and lt = '" & Form_factura_preventa.txt_letra.Text & "' and pre = '" & Form_factura_preventa.txt_prefijo.Text & "' and talonario = '" & Form_factura_preventa.txt_talon.Text & "' and computer = '" & computer & "'", conex)
                coman.Transaction = trans
                coman.ExecuteNonQuery()
                coman.Dispose()

            End If

            trans.Commit()

            conex.Close()
            tbl2.Dispose()
            cant_temp = 0

        End If

    End Sub

    Private Sub txt_desc_rcgo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_rcgo.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                If Me.txt_desc_rcgo.Text = "" Then Me.txt_desc_rcgo.Text = 0

                Call carga_grilla()

            End If

            busc_articulos.txt_estado_form.Text = 0

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carga_grilla()

        entra = False

        If Val(Me.txt_cantidad.Text) <= 0 Or Me.txt_cantidad.Text = "" Then
            Exit Sub
        End If

        If busc_articulos.entra = False Then i = Form_factura_preventa.i

        If fact.mueve_stock = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

            If (Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen) And (Val(Me.txt_cantidad.Text) <= Val(Me.lbl_stock.Text)) Then

                If Val(Me.lbl_stock.Text) <= Val(Me.txt_cantidad.Text) And RTrim(fact.mueve_stock) = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                    End If

                    coman = New SqlCommand("update art_01 with (rowlock,xlock) set cantidad= '" & Format(Me.lbl_stok_ant.Text + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value), "0.00") & "' where id_art= '" & Me.lbl_codigo.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()
                    conex.Close()
                    Me.Hide()

                End If

            End If

        End If

        If fact.mueve_stock = "NO" Then

            If Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Then

                If Val(Me.lbl_stock.Text) <= Val(Me.txt_cantidad.Text) And RTrim(fact.mueve_stock) = "SI" And RTrim(Me.lbl_art_mueve_stok.Text) = "SI" Then

                    If conex.State = ConnectionState.Closed Then
                        conex = conecta()
                        conex.Open()
                        trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                    End If

                    coman = New SqlCommand("update art_01 with (rowlock,xlock) set cantidad= '" & Format(Me.lbl_stok_ant.Text + Val(Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value), "0.00") & "' where id_art= '" & Me.lbl_codigo.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()
                    conex.Close()
                    Me.Hide()

                End If

            End If

        End If

        If Val(Me.txt_cantidad.Text) <= Val(Me.lbl_stock.Text) Or fact.mueve_stock = "NO" Or RTrim(Form_factura_preventa.txt_mueve_stock.Text) = "NO" Or RTrim(Me.lbl_art_mueve_stok.Text) = "NO" Then

            entra = True

            If Form_factura_preventa.DataGridView1.Rows(i).Cells(20).Value = 0 Then
                Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value = Me.txt_unidad_secundaria.Text
                Form_factura_preventa.DataGridView1.Rows(i).Cells(15).Value = Format(Val(Me.txt_cantidad.Text) * Form_factura_preventa.DataGridView1.SelectedCells(14).Value, "0.00")
                Call actualiza_grilla_cantidad()
                Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                Form_factura_preventa.DataGridView1.Rows(i).Cells(8).Value = "NO"
                If Trim(Me.lbl_cant.Text) <> RTrim(Me.txt_cantidad.Text) Then Me.falla_stk(Me.lbl_codigo.Text, Me.lbl_articulo.Text, Form_factura_preventa.nom_computadora, Me.txt_cantidad.Text, Form_factura_preventa.txt_tipo.Text, Form_factura_preventa.DataGridView1.Rows(Me.lbl_indice.Text).Cells(23).Value)
            End If

            If Form_factura_preventa.DataGridView1.Rows(i).Cells(20).Value = 1 Then
                'Call actualiza_grilla_cantidad_busqueda(i)
                Form_factura_preventa.DataGridView1.Rows(i).Cells(8).Value = "SI"
                Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value = Me.txt_cantidad.Text
                Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value = Me.txt_unidad_secundaria.Text
                Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If

            If Me.lbl_uni_sec.Text = "NO" Then
                Call calcula_totales(Me.txt_cantidad.Text)
            Else
                Call calcula_totales(Me.txt_unidad_secundaria.Text)
            End If

            Call calcula_iva()

            Me.txt_cantidad.Text = ""
            Me.txt_desc_rcgo.Text = ""
            Form_factura_preventa.DataGridView1.Focus()
            Me.Close()

        Else   ' sino tengo stock hago esto otro

            entra = True

            art.instruccion = "delete act_art where codart = '" & Form_factura_preventa.DataGridView1.Rows(i).Cells(0).Value & "' and computer = '" & Form_factura_preventa.nom_computadora & "'"
            art.actualizar()

            Form_factura_preventa.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Form_factura_preventa.DataGridView1.Rows(i).Cells(2).Value = Me.txt_cantidad.Text
            Form_factura_preventa.DataGridView1.Rows(i).Cells(25).Value = Me.txt_unidad_secundaria.Text
            Form_factura_preventa.DataGridView1.Rows(i).Cells(12).Value = "0"
            Form_factura_preventa.DataGridView1.Rows(i).Cells(8).Value = "SI"
            Form_factura_preventa.DataGridView1.Rows(i).Cells(1).Value = Replace(RTrim(Form_factura_preventa.DataGridView1.Rows(i).Cells(1).Value), "**", "")
            MessageBox.Show("Stock Insuficiente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Me.txt_cantidad.Text = ""
            Me.txt_desc_rcgo.Text = ""
            Form_factura_preventa.DataGridView1.Focus()
            Me.Close()

        End If

        If busc_articulos.entra = True Then busc_articulos.Dispose()

    End Sub

    Private Sub Form_cantidad_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        'If fact.factura_en_c = "SI" Then
        If busc_articulos.entra = False Then
            Me.txt_precio.Enabled = True
            Me.txt_precio.SelectAll()
            Me.txt_precio.Focus()
        Else
            Me.txt_precio.Enabled = False
            Me.txt_cantidad.SelectAll()
            Me.txt_cantidad.Focus()
        End If

        Me.txt_desc_rcgo.ReadOnly = False
        'End If

    End Sub

    Private Sub txt_precio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_precio.KeyDown
        If e.KeyCode = Keys.Return Then

            Me.txt_cantidad.Focus()
            Me.txt_cantidad.SelectAll()

            mod_precio = False

            If Trim(Me.txt_precio.Text) <> Trim(Me.lbl_p_civa.Text) Then
                If Val(Me.txt_desc_rcgo.Text) = 0 Then
                    Me.txt_desc_rcgo.ReadOnly = True
                    mod_precio = True
                End If
            End If

        End If
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio.KeyPress
        num.positivos_punto(e, Me.txt_precio)
    End Sub

    Private Sub txt_unidad_secundaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_unidad_secundaria.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_unidad_secundaria.Text = Nothing Or Val(Me.txt_unidad_secundaria.Text) <= 0 Then Exit Sub
            Me.txt_desc_rcgo.Focus()
            Me.txt_desc_rcgo.SelectAll()
        End If
    End Sub

    Private Sub txt_unidad_secundaria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_unidad_secundaria.KeyPress
        num.positivos_punto(e, Me.txt_unidad_secundaria)
    End Sub

End Class