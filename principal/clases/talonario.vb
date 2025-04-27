Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft

    Public Class talonario

        Dim conex As New SqlConnection
        Dim coman As SqlCommand
        Dim trans As SqlTransaction
        Private minstruccion As String
        Private mnumero As Integer
        Private mverifica As Boolean = True
        Private mevalua As Boolean = True

        Public Property evalua()
            Get
                Return mevalua
            End Get
            Set(ByVal value)
                mevalua = value
            End Set
        End Property

        Public Property instruccion()
            Get
                Return minstruccion
            End Get
            Set(ByVal value)
                minstruccion = value
            End Set
        End Property

        Public Property numerador()
            Get
                Return mnumero
            End Get
            Set(ByVal value)
                mnumero = value
            End Set
        End Property

        Public Property verifica()
            Get
                Return mverifica
            End Get
            Set(ByVal value)
                mverifica = value
            End Set
        End Property

        Public Sub New()
            conex = conecta()
        End Sub

        Public Sub agregar()

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub actualizar()

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                Insercion.Dispose()

            Catch ex As Exception


            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub actualizar_con_qr(ByVal qr As Byte())

            Try

                If conex.State = ConnectionState.Closed Then conex.Open()

                Dim Insercion As New SqlCommand(minstruccion, conex)
                Dim param As New SqlClient.SqlParameter("@qr", SqlDbType.Image)
                param.Value = qr
                Insercion.Parameters.Add(param)
                Insercion.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub mostrar()

            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                Form_numerador.txt_talonario.Text = reader("talon")
                Form_numerador.txt_interno.Text = reader("talon")
                Form_numerador.txt_punto_venta.Text = reader("punto_venta")
                Form_numerador.txt_int_p_vta.Text = reader("punto_venta")
                Form_numerador.txt_fact_a.Text = reader("fact_a")
                Form_numerador.txt_int_facta.Text = reader("fact_a")
                Form_numerador.txt_fact_b.Text = reader("fact_b")
                Form_numerador.txt_int_factb.Text = reader("fact_b")
                Form_numerador.txt_fact_c.Text = reader("fact_c")
                Form_numerador.txt_int_factc.Text = reader("fact_c")
                Form_numerador.txt_remito.Text = reader("remito")
                Form_numerador.txt_int_remito.Text = reader("remito")
                Form_numerador.txt_recibo.Text = reader("recibo")
                Form_numerador.txt_int_recibo.Text = reader("recibo")
                Form_numerador.txt_pedido.Text = reader("pedido")
                Form_numerador.txt_int_pedido.Text = reader("pedido")
                Form_numerador.txt_int_nc_a.Text = reader("n_credito_a")
                Form_numerador.txt_n_credito_a.Text = reader("n_credito_a")
                Form_numerador.txt_n_credito_b.Text = reader("n_credito_b")
                Form_numerador.txt_int_nc_b.Text = reader("n_credito_b")
                Form_numerador.txt_n_credito_c.Text = reader("n_credito_c")
                Form_numerador.txt_int_nc_c.Text = reader("n_credito_c")
                Form_numerador.txt_orden_pago.Text = reader("orden_pago")
                Form_numerador.txt_debito_a.Text = reader("n_debito_a")
                Form_numerador.txt_int_debito_a.Text = reader("n_debito_a")
                Form_numerador.txt_debito_b.Text = reader("n_debito_b")
                Form_numerador.txt_int_debito_b.Text = reader("n_debito_b")
                Form_numerador.txt_debito_c.Text = reader("n_debito_c")
                Form_numerador.txt_int_debito_c.Text = reader("n_debito_c")
                Form_numerador.txt_int_orden_pago.Text = reader("orden_pago")
                Form_numerador.txt_cae.Text = Trim(reader("cae"))
                Form_numerador.txt_venc_cae.Text = Format(reader("venc_cae"), "ddMMyyyy")

                Form_numerador.cmd_guardar.Enabled = False
                Form_numerador.cmd_guardar.BackColor = Color.LightGray
                Form_numerador.cmd_actualizar.Enabled = True
                Form_numerador.cmd_actualizar.BackColor = Color.Black
                Form_numerador.cmd_eliminar.Enabled = True
                Form_numerador.cmd_eliminar.BackColor = Color.Black

            Catch ex As Exception

                Form_numerador.limpiar()
                Form_numerador.cmd_guardar.Enabled = True
                Form_numerador.cmd_guardar.BackColor = Color.Black
                Form_numerador.cmd_actualizar.Enabled = False
                Form_numerador.cmd_actualizar.BackColor = Color.LightGray
                Form_numerador.cmd_eliminar.Enabled = False
                Form_numerador.cmd_eliminar.BackColor = Color.LightGray

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub carga_numerador_factura()

            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                If form_factura.txt_estado_form.Text = 1 And form_factura.tipo1 <> "PD" Then

                    form_factura.lbl_cae.Text = reader("cae")
                    form_factura.lbl_venc_cae.Text = reader("venc_cae")

                    If form_factura.txt_factura_notaCredito.Text = 1 Or form_factura.txt_factura_notaCredito.Text = 2 Then

                        If form_factura.txt_letra.Text = "C" Then

                            form_factura.txt_numero.Text = reader("fact_c")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "A" Then

                            form_factura.txt_numero.Text = reader("fact_a")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "B" Then

                            form_factura.txt_numero.Text = reader("fact_b")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                    End If

                    If form_factura.txt_factura_notaCredito.Text = 2 And form_factura.tipo1 <> "PD" Then

                        If form_factura.txt_letra.Text = "A" Then

                            form_factura.txt_numero.Text = reader("n_credito_a")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "B" Then

                            form_factura.txt_numero.Text = reader("n_credito_b")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "C" Then

                            form_factura.txt_numero.Text = reader("n_credito_c")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                    End If

                    If form_factura.txt_factura_notaCredito.Text = 3 And form_factura.tipo1 <> "PD" Then

                        If form_factura.txt_letra.Text = "A" Then

                            form_factura.txt_numero.Text = reader("n_debito_a")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "B" Then

                            form_factura.txt_numero.Text = reader("n_debito_b")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                        If form_factura.txt_letra.Text = "C" Then

                            form_factura.txt_numero.Text = reader("n_debito_c")
                            form_factura.txt_prefijo.Text = reader("punto_venta")

                        End If

                    End If

                    If form_factura.txt_remito.Text = 1 Or form_factura.txt_remito.Text = 2 Then

                        If form_factura.txt_letra.Text = "A" Then

                            form_factura.txt_numero.Text = reader("remito")

                        End If

                        If form_factura.txt_letra.Text = "B" Then

                            form_factura.txt_numero.Text = reader("remito")

                        End If

                    End If

                End If

                If Form_recibos.txt_estado_form.Text = 1 Then

                    Form_recibos.txt_numero.Text = reader("recibo")

                End If

                If Form_recibos.txt_estado_form.Text = 2 Then

                    Form_recibos.txt_numero.Text = reader("orden_pago")

                End If

                If form_factura.tipo1 = "PD" Then

                    form_factura.lbl_cae.Text = reader("cae")
                    form_factura.lbl_venc_cae.Text = reader("venc_cae")

                    form_factura.txt_numero.Text = reader("pedido")
                    form_factura.txt_prefijo.Text = "3"

                End If

                reader.Close()

            Catch ex As Exception

                MsgBox("Verifique Numeradores", MsgBoxStyle.Information, "PyMsoft")
                form_factura.Dispose()

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub incrementa_numerador()

            Try

                ' si es factura, n.credito,remito,pedido

                If RTrim(form_factura.txt_estado_form.Text) = 1 Then

                    If RTrim(form_factura.txt_talonario_pred.Text) = "1" Then

                        If RTrim(form_factura.txt_tipo_fact.Text) <> "RS" And RTrim(form_factura.txt_tipo_fact.Text) <> "RE" Then
                            Me.instruccion = "select *from numerador with(rowlock,xlock) where talon ='" & form_factura.txt_talonario_pred.Text & "' and punto_venta = '" & form_factura.txt_prefijo.Text & "'"
                            Me.selecciona_numerador_actual()
                        Else
                            Me.instruccion = "select *from numerador with(rowlock,xlock) where talon ='" & form_factura.txt_talonario_pred.Text & "'"
                            Me.selecciona_numerador_actual()
                        End If

                    Else

                        Me.instruccion = "select *from numerador with(rowlock,xlock) where talon ='" & form_factura.txt_talonario_pred.Text & "'"
                        Me.selecciona_numerador_actual()

                    End If

                End If

                ' si es factura preventa

                If RTrim(Form_factura_preventa.txt_estado_form.Text) = 1 Then

                    If Form_numerador.txt_talonario.Text = "1" Then

                        Me.instruccion = "select *from numerador with(rowlock,xlock) where talon = '" & Form_numerador.txt_talonario.Text & "' and punto_venta = '" & Form_numerador.txt_punto_venta.Text & "'"
                        Me.selecciona_numerador_actual()

                    Else

                        Me.instruccion = "select *from numerador with(rowlock,xlock) where talon ='" & Form_numerador.txt_talonario.Text & "'"
                        Me.selecciona_numerador_actual()

                    End If

                End If

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                End If

                Dim comando2 As SqlCommand
                comando2 = New SqlCommand(minstruccion, conex)

                comando2.Transaction = trans
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                ' preventa factura

                If RTrim(Form_factura_preventa.txt_estado_form.Text) = 1 Then

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "C" Then

                        Me.numerador = reader("fact_c") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_c = '" & Me.numerador & "' where punto_venta like '" + Form_numerador.txt_punto_venta.Text + "' and talon = '" & Form_numerador.txt_talonario.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "A" Then

                        Me.numerador = reader("fact_a") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_a = '" & Me.numerador & "' where punto_venta like '" + Form_numerador.txt_punto_venta.Text + "' and talon = '" & Form_numerador.txt_talonario.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "B" Then

                        Me.numerador = reader("fact_b") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_b = '" & Me.numerador & "' where punto_venta like '" + Form_numerador.txt_punto_venta.Text + "' and talon = '" & Form_numerador.txt_talonario.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    reader.Close()

                    Exit Sub

                End If

                ' factura contado

                If RTrim(form_factura.txt_estado_form.Text) = 1 And RTrim(form_factura.txt_tipo_fact.Text) = "FC" Then

                    If RTrim(form_factura.txt_letra.Text) = "C" Then

                        Me.numerador = reader("fact_c") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_c = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "A" Then

                        Me.numerador = reader("fact_a") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_a = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "B" Then

                        Me.numerador = reader("fact_b") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set fact_b = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    reader.Close()

                    Exit Sub

                End If

                ' nota credito contado

                If RTrim(form_factura.txt_estado_form.Text) = 1 And RTrim(form_factura.txt_tipo_fact.Text) = "NC" Then

                    If RTrim(form_factura.txt_letra.Text) = "A" Then

                        Me.numerador = reader("n_credito_a") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_credito_a = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "B" Then

                        Me.numerador = reader("n_credito_b") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_credito_b = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "C" Then

                        Me.numerador = reader("n_credito_c") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_credito_c = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    reader.Close()

                    Exit Sub

                End If

                ' nota debito contado

                If RTrim(form_factura.txt_estado_form.Text) = 1 And RTrim(form_factura.txt_tipo_fact.Text) = "ND" Then

                    If RTrim(form_factura.txt_letra.Text) = "A" Then

                        Me.numerador = reader("n_debito_a") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_debito_a = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "B" Then

                        Me.numerador = reader("n_debito_b") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_debito_b = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    If RTrim(form_factura.txt_letra.Text) = "C" Then

                        Me.numerador = reader("n_debito_c") + 1

                        reader.Close()

                        coman = New SqlCommand("update numerador with(rowlock,xlock) set n_debito_c = '" & Me.numerador & "' where punto_venta like '" + form_factura.txt_prefijo.Text + "' and talon = '" & form_factura.txt_talonario_pred.Text & "'", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()

                        trans.Commit()

                        conex.Close()
                        Exit Sub

                    End If

                    reader.Close()

                    Exit Sub

                End If


                ' remito

                If RTrim(form_factura.txt_remito.Text) = 1 Or RTrim(form_factura.txt_remito.Text) = 2 Then

                    Me.numerador = reader("remito") + 1

                    reader.Close()

                    coman = New SqlCommand("update numerador with(rowlock,xlock) set remito = '" & Me.numerador & "' where Talon <> '0'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()

                    reader.Close()

                    conex.Close()
                    Exit Sub

                End If

                'recibos

                If RTrim(Form_recibos.txt_estado_form.Text) = 1 Then

                    Me.numerador = reader("recibo") + 1

                    reader.Close()

                    coman = New SqlCommand("update numerador with(rowlock,xlock) set recibo = '" & Me.numerador & "' where punto_venta like '" + Form_recibos.txt_prefijo.Text + "' and talon = '" & Form_recibos.txt_talonario_pred.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()

                    conex.Close()
                    Exit Sub

                End If

                'Orden Pago

                If RTrim(Form_recibos.txt_estado_form.Text) = 2 Then

                    Me.numerador = reader("orden_pago") + 1

                    reader.Close()

                    coman = New SqlCommand("update numerador with(rowlock,xlock) set orden_pago = '" & Me.numerador & "' where punto_venta like '" + Form_recibos.txt_prefijo.Text + "' and talon = '" & Form_recibos.txt_talonario_pred.Text & "'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()

                    conex.Close()
                    Exit Sub

                End If

                'pedidos

                If RTrim(form_factura.txt_tipo_fact.Text) = "PD" Then

                    Me.numerador = reader("pedido") + 1

                    reader.Close()

                    coman = New SqlCommand("update numerador with(rowlock,xlock) set pedido = '" & Me.numerador & "' where talon <> '0'", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    trans.Commit()

                    conex.Close()
                    Exit Sub

                End If

                reader.Close()

            Catch ex As Exception

                trans.Rollback()

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub borrar()

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                Insercion.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub verifiva_numerador()

            Try

                If Form_numerador.txt_fact_a.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_fact_a.Text) <> RTrim(Form_numerador.txt_int_facta.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_fact_a.Text) & "' and tipo_fact = 'FC' and letra_fact='A' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_fact_b.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_fact_b.Text) <> RTrim(Form_numerador.txt_int_factb.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_fact_b.Text) & "' and tipo_fact = 'FC' and letra_fact='B' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_fact_c.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_fact_c.Text) <> RTrim(Form_numerador.txt_int_factc.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_fact_c.Text) & "' and tipo_fact = 'FC' and letra_fact='C' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_recibo.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_recibo.Text) <> RTrim(Form_numerador.txt_int_recibo.Text) Then
                    Me.instruccion = "select id_rec,letra,pre,tc from recibo_cab where id_rec = '" & RTrim(Form_numerador.txt_recibo.Text) & "' and tc = 'RC' and talon <> '0'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_remito.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_remito.Text) <> RTrim(Form_numerador.txt_int_remito.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_remito.Text) & "' and tipo_fact = 'RE' and talon <> '0'"
                    Me.comprobar_verifica()

                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_remito.Text) & "' and tipo_fact = 'RS' and talon <> '0'"
                    Me.comprobar_verifica()

                    Exit Sub
                End If

                If Form_numerador.txt_pedido.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_pedido.Text) <> RTrim(Form_numerador.txt_int_pedido.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_pedido.Text) & "' and tipo_fact = 'PD' and letra_fact='A' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()

                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_pedido.Text) & "' and tipo_fact = 'PD' and letra_fact='B' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()

                    Exit Sub
                End If

                If Form_numerador.txt_n_credito_a.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_n_credito_a.Text) <> RTrim(Form_numerador.txt_int_nc_a.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_n_credito_a.Text) & "' and tipo_fact = 'NC' and letra_fact='A' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_n_credito_b.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_n_credito_b.Text) <> RTrim(Form_numerador.txt_int_nc_b.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_n_credito_b.Text) & "' and tipo_fact = 'NC' and letra_fact='B' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_n_credito_c.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_n_credito_c.Text) <> RTrim(Form_numerador.txt_int_nc_c.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_n_credito_b.Text) & "' and tipo_fact = 'NC' and letra_fact='C' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_orden_pago.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_orden_pago.Text) <> RTrim(Form_numerador.txt_int_orden_pago.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_orden_pago.Text) & "' and tipo_fact = 'OP' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_debito_a.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_debito_a.Text) <> RTrim(Form_numerador.txt_int_debito_a.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_debito_a.Text) & "' and tipo_fact = 'ND' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

                If Form_numerador.txt_debito_b.Text = 0 Then Me.evalua = False

                If RTrim(Form_numerador.txt_debito_b.Text) <> RTrim(Form_numerador.txt_int_debito_b.Text) Then
                    Me.instruccion = "select num_fact1,tipo_fact,letra_fact,prefijo_fact from fact_cab where num_fact1 = '" & RTrim(Form_numerador.txt_debito_b.Text) & "' and tipo_fact = 'ND' and prefijo_fact= '" & RTrim(Form_numerador.txt_punto_venta.Text) & "' and talon = '" & Form_numerador.txt_talonario.Text & "'"
                    Me.comprobar_verifica()
                    Exit Sub
                End If

            Catch ex As Exception

                MessageBox.Show("Error..No puede dejar sin un valor", "PyMsoft", MessageBoxButtons.OK)

            End Try

        End Sub

        Public Sub comprobar_verifica()

            Dim comando2 As New SqlCommand(minstruccion, conex)

            If conex.State = ConnectionState.Closed Then conex.Open()
            Dim reader As SqlDataReader = comando2.ExecuteReader

            mverifica = True

            Try

                While reader.Read

                    mverifica = False
                    MessageBox.Show("El Numero Esta en uso", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reader.Close()
                    conex.Close()
                    Exit Sub

                End While

            Catch ex As Exception

            Finally

                conex.Close()
                reader.Close()

            End Try

        End Sub

        Public Sub pasa_pedido_a_factura()
            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                If RTrim(Form_factura_preventa.txt_letra.Text) = "A" Then

                    Form_factura_preventa.num_fact = reader("fact_a")
                    Form_factura_preventa.pref_fact = reader("punto_venta")

                End If

                If RTrim(Form_factura_preventa.txt_letra.Text) = "B" Then

                    Form_factura_preventa.num_fact = reader("fact_b")
                    Form_factura_preventa.pref_fact = reader("punto_venta")

                End If

                If RTrim(Form_factura_preventa.txt_letra.Text) = "C" Then

                    Form_factura_preventa.num_fact = reader("fact_c")
                    Form_factura_preventa.pref_fact = reader("punto_venta")

                End If

                reader.Close()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub selecciona_numerador_actual()

            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.Serializable)
                End If

                comando2.Transaction = trans
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                If RTrim(form_factura.txt_estado_form.Text) = 1 And RTrim(form_factura.tipo1) <> "PD" Then

                    If RTrim(form_factura.txt_factura_notaCredito.Text) = 1 Or RTrim(form_factura.txt_factura_notaCredito.Text) = 2 Then

                        If RTrim(form_factura.txt_letra.Text) = "C" Then

                            Me.numerador = reader("fact_c")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "A" Then

                            Me.numerador = reader("fact_a")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "B" Then

                            Me.numerador = reader("fact_b")

                        End If

                    End If

                    If RTrim(form_factura.txt_factura_notaCredito.Text) = 2 And RTrim(form_factura.tipo1) <> "PD" Then

                        If RTrim(form_factura.txt_letra.Text) = "A" Then

                            Me.numerador = reader("n_credito_a")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "B" Then

                            Me.numerador = reader("n_credito_b")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "C" Then

                            Me.numerador = reader("n_credito_c")

                        End If

                    End If

                    If RTrim(form_factura.txt_factura_notaCredito.Text) = 3 And RTrim(form_factura.tipo1) <> "PD" Then

                        If RTrim(form_factura.txt_letra.Text) = "A" Then

                            Me.numerador = reader("n_debito_a")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "B" Then

                            Me.numerador = reader("n_debito_b")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "C" Then

                            Me.numerador = reader("n_debito_c")

                        End If

                    End If

                    If RTrim(form_factura.txt_remito.Text) = 1 Or RTrim(form_factura.txt_remito.Text) = 2 Then

                        If RTrim(form_factura.txt_letra.Text) = "A" Then

                            Me.numerador = reader("remito")

                        End If

                        If RTrim(form_factura.txt_letra.Text) = "B" Then

                            Me.numerador = reader("remito")

                        End If

                    End If

                End If

                If RTrim(Form_factura_preventa.txt_estado_form.Text) = 1 Then

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "C" Then

                        Me.numerador = reader("fact_c")

                    End If

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "A" Then

                        Me.numerador = reader("fact_a")

                    End If

                    If RTrim(Form_factura_preventa.txt_letra.Text) = "B" Then

                        Me.numerador = reader("fact_b")

                    End If

                End If

                If RTrim(Form_recibos.txt_estado_form.Text) = 1 Then

                    Me.numerador = reader("recibo")

                End If

                If RTrim(form_factura.tipo1) = "PD" Then

                    Me.numerador = reader("pedido")

                End If

                reader.Close()

            Catch ex As Exception

                trans.Rollback()

            Finally

                trans.Commit()
                conex.Close()

            End Try

        End Sub

    End Class

End Namespace
