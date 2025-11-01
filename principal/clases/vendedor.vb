Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft
    Public Class vendedor

        Private xcodigo As Integer
        Private xnombre As String
        Private xtipo As String
        Private xfecha As Date
        Private xestado As String
        Private xinstruccion As String
        Private xtexto As String
        Private xtexto2 As String
        Private xcodigo_vend As String
        Private xnombre_vend As String
        Private mvalidar As Boolean
        Private recorre As BindingManagerBase
        Dim existencia, mverifica As Boolean
        Private valor As Integer = 1
        Public pos As Integer
        Dim midataset As New DataSet

        Dim conex As New SqlConnection

        Dim comando1 As New SqlDataAdapter

        Public Property verifica()
            Get
                Return mverifica
            End Get
            Set(ByVal value)
                mverifica = value
            End Set
        End Property



        Public Property codigo()
            Get
                Return xcodigo
            End Get
            Set(ByVal value)
                If form_vendedor.txt_codigo.Text = "" Then
                    valor = 0
                Else
                    value = xcodigo
                End If
            End Set
        End Property

        Public Property nombre()
            Get
                Return xnombre
            End Get
            Set(ByVal value)
                If form_vendedor.txt_nombre.Text = "" Then
                    valor = 0
                Else
                    value = xnombre
                End If
            End Set
        End Property

        Public Property tipo()
            Get
                Return xtipo
            End Get
            Set(ByVal value)
                If form_vendedor.opt_varios.Checked = True Then
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_varios.Text
                    value = xcodigo
                End If
                If form_vendedor.opt_preventa.Checked = True Then
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_preventa.Text
                    value = xcodigo
                End If
                If form_vendedor.opt_mostrador.Checked = True Then
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_mostrador.Text
                    value = xcodigo
                End If
            End Set
        End Property

        Public Property fecha()
            Get
                Return xfecha
            End Get
            Set(ByVal value)
                value = xfecha
            End Set
        End Property

        Public Property estado()
            Get
                Return xestado
            End Get
            Set(ByVal value)
                value = xestado
            End Set
        End Property

        Public WriteOnly Property instruccion()
            Set(ByVal value)
                xinstruccion = value
            End Set
        End Property

        Public ReadOnly Property text()
            Get
                Return xtexto
            End Get
        End Property

        Public ReadOnly Property text2()
            Get
                Return xtexto2
            End Get
        End Property

        Public Property codigo_vend()
            Get
                Return xcodigo_vend
            End Get
            Set(ByVal value)
                xcodigo_vend = value
            End Set
        End Property

        Public Property nombre_vend()
            Get
                Return xnombre_vend
            End Get
            Set(ByVal value)
                xnombre_vend = value
            End Set
        End Property

        Public Property validar()
            Get
                Return mvalidar
            End Get
            Set(ByVal value)
                mvalidar = value
            End Set
        End Property


        Public Sub New()
            conex = conecta()
            comando1 = New SqlDataAdapter("select *from vend_01", conex)
        End Sub

        Public Sub carga_vendedores_grilla()

            Dim tb As New DataTable
            Dim comando1 As New SqlDataAdapter("select *from vend_01", conex)
            comando1.Fill(tb)

            form_vendedor.DataGridView1.DataSource = tb

            form_vendedor.DataGridView1.Columns(0).Width = 60
            form_vendedor.DataGridView1.Columns(1).Width = 260
            form_vendedor.DataGridView1.Columns(2).Width = 160
            form_vendedor.DataGridView1.Columns(5).Width = 50

            comando1.Dispose()
            tb.Dispose()

        End Sub

        Public Sub agregar_vendedor()

            Me.codigo = form_vendedor.txt_codigo.Text
            Me.nombre = form_vendedor.txt_nombre.Text

            If valor = 0 Then
                MsgBox("Complete los Campos", MsgBoxStyle.Exclamation, "PyMsoft")
                valor = 1
                Exit Sub
            End If

            If valor = 1 Then
                Call verifica_existencia()
                'Call verifica_p_venta()
            End If

            If existencia = False Then

                Me.tipo = form_vendedor.lbl_tipo.Text
                Me.fecha = form_vendedor.dt_fec_alta.Text
                Me.estado = form_vendedor.cmb_estado.Text

                Dim comando1 As New SqlDataAdapter("select *from vend_01", conex)

                Try

                    Dim Sql_insert1 As String

                    Sql_insert1 = "INSERT INTO vend_01(id_vendedor,nombre,tipo_vendedor,fec_alta,estado,letra_estado) VALUES('" + form_vendedor.txt_codigo.Text + "' , '" + form_vendedor.txt_desc.Text + "', '" + form_vendedor.lbl_tipo.Text + "' , '" + form_vendedor.dt_fec_alta.Text + "', '" + form_vendedor.cmb_estado.Text + "', '" + form_vendedor.txt_tipo.Text + "')"
                    Dim Insercion As New SqlCommand(Sql_insert1, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()
                    MsgBox("Registro Cargado", MsgBoxStyle.Information, "PyMsoft")
                    Call limpiar()
                    Me.carga_vendedores_grilla()

                Catch ex As Exception

                    MsgBox("Error, Numero en uso o Incorrecto", MsgBoxStyle.Exclamation, "PyMsoft")

                Finally

                    conex.Close()
                    comando1.Dispose()

                End Try

            Else

                MsgBox("Registro ocupado", MsgBoxStyle.Exclamation, "PyMsoft")

            End If

        End Sub

        Private Sub limpiar()

            form_vendedor.txt_codigo.Text = ""
            form_vendedor.txt_nombre.Text = ""
            form_vendedor.txt_codigo.Focus()

        End Sub

        Public Sub mostrar()

            Dim midataset As New DataSet

            Dim comando1 As New SqlDataAdapter("select *from vend_01", conex)

            comando1.Fill(midataset, "vend_01")

            Try

                form_vendedor.txt_codigo.Text = midataset.Tables("vend_01").Rows(pos).Item("id_vendedor").ToString
                form_vendedor.txt_interno.Text = midataset.Tables("vend_01").Rows(pos).Item("id_vendedor").ToString
                form_vendedor.txt_nombre.Text = midataset.Tables("vend_01").Rows(pos).Item("nombre").ToString
                form_vendedor.dt_fec_alta.Text = midataset.Tables("vend_01").Rows(pos).Item("fec_alta").ToString
                form_vendedor.txt_codigo.Text = midataset.Tables("vend_01").Rows(pos).Item("id_vendedor").ToString
                form_vendedor.cmb_estado.Text = midataset.Tables("vend_01").Rows(pos).Item("estado").ToString
                form_vendedor.txt_tipo.Text = midataset.Tables("vend_01").Rows(pos).Item("letra_estado").ToString

                If midataset.Tables("vend_01").Rows(pos).Item("tipo_vendedor") = "Cigarrero" Then
                    form_vendedor.opt_varios.Checked = True
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_varios.Text
                End If
                If midataset.Tables("vend_01").Rows(pos).Item("tipo_vendedor") = "Salon" Then
                    form_vendedor.opt_mostrador.Checked = True
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_mostrador.Text
                End If
                If midataset.Tables("vend_01").Rows(pos).Item("tipo_vendedor") = "Preventista" Then
                    form_vendedor.opt_preventa.Checked = True
                    form_vendedor.lbl_tipo.Text = form_vendedor.opt_preventa.Text
                End If

            Catch ex As Exception

            Finally

                midataset.Dispose()
                comando1.Dispose()
                conex.Close()

            End Try

        End Sub

        Public Sub cargar(ByVal cod As Integer)


            Try

                If form_vendedor.txt_estado_form.Text = 1 Then

                    Dim comando3 As New SqlCommand("select *from vend_01 where id_vendedor like '" & cod & "' ", conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Dim reader As SqlDataReader = comando3.ExecuteReader

                    reader.Read()

                    form_vendedor.txt_codigo.Text = reader("id_vendedor")
                    form_vendedor.txt_interno.Text = reader("id_vendedor")
                    form_vendedor.txt_nombre.Text = reader("nombre")
                    form_vendedor.dt_fec_alta.Text = reader("fec_alta")

                    If reader("tipo_vendedor") = "Varios" Then
                        form_vendedor.opt_varios.Checked = True
                    End If
                    If reader("tipo_vendedor") = "Mostrador" Then
                        form_vendedor.opt_mostrador.Checked = True
                    End If
                    If reader("tipo_vendedor") = "Preventista" Then
                        form_vendedor.opt_preventa.Checked = True
                    End If

                    form_vendedor.cmb_estado.Text = reader("estado")
                    form_vendedor.txt_tipo.Text = reader("letra_estado")

                    form_vendedor.cmd_actualizar.Enabled = True
                    form_vendedor.cmd_actualizar.BackColor = Color.Black
                    form_vendedor.cmd_borrar.Enabled = True
                    form_vendedor.cmd_borrar.BackColor = Color.Black
                    form_vendedor.cmd_aceptar.Enabled = False
                    form_vendedor.cmd_aceptar.BackColor = Color.LightGray

                    form_vendedor.txt_codigo.Enabled = False
                    Call habilita_navegador()

                    form_vendedor.txt_nombre.Focus()
                    reader.Close()
                    comando3.Dispose()

                End If

                If form_factura.txt_estado_form.Text = 1 Then

                    Dim comando As New SqlCommand("select *from vend_01 where id_vendedor like '" & form_factura.txt_vendedor.Text & "'", conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Dim reader As SqlDataReader = comando.ExecuteReader

                    reader.Read()

                    form_factura.txt_vendedor.Text = reader("id_vendedor")
                    form_factura.txt_nom_vendedor.Text = reader("nombre")
                    reader.Close()
                    If form_factura.txt_cod_lista.Enabled = False Then form_factura.txt_codigo_producto.Enabled = True
                    form_factura.txt_codigo_producto.Focus()
                    mverifica = True

                    comando.Dispose()

                End If

                If Form_recibos.txt_estado_form.Text = 1 Then

                    Dim comando As New SqlCommand("select *from vend_01 where id_vendedor like '" & cod & "'", conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Dim reader As SqlDataReader = comando.ExecuteReader

                    reader.Read()

                    Form_recibos.txt_vendedor.Text = reader("id_vendedor")
                    Form_recibos.txt_nom_vendedor.Text = reader("nombre")
                    reader.Close()
                    Form_recibos.txt_comprobante.Focus()
                    mverifica = True

                    comando.Dispose()

                End If

            Catch ex As Exception

                If form_vendedor.txt_estado_form.Text = 1 Then
                    form_vendedor.txt_nombre.Text = ""
                    form_vendedor.txt_nombre.Focus()

                    form_vendedor.cmd_actualizar.Enabled = False
                    form_vendedor.cmd_actualizar.BackColor = Color.LightGray
                    form_vendedor.cmd_borrar.Enabled = False
                    form_vendedor.cmd_borrar.BackColor = Color.LightGray
                    form_vendedor.cmd_aceptar.Enabled = True
                    form_vendedor.cmd_aceptar.BackColor = Color.Black

                    Call desabilita_navegador()
                    existencia = False
                End If

                If form_factura.txt_estado_form.Text = 1 Then
                    form_factura.txt_vendedor.Text = ""
                    form_factura.txt_vendedor.Focus()
                    mverifica = False
                End If

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub actualizar()

            If existencia = False Then

                Try

                    Dim sql_insert As String

                    sql_insert = "update vend_01 set id_vendedor= '" & form_vendedor.txt_codigo.Text & "', nombre = '" & form_vendedor.txt_desc.Text & "', tipo_vendedor= '" & form_vendedor.lbl_tipo.Text & "',fec_alta='" & form_vendedor.dt_fec_alta.Text & "',estado='" & form_vendedor.cmb_estado.Text & "',letra_estado='" & form_vendedor.txt_tipo.Text & "' where id_vendedor ='" & form_vendedor.txt_interno.Text & "'"
                    Dim Insercion As New SqlCommand(sql_insert, conex)
                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()

                    sql_insert = "update cli_01 set vendedor= '" & form_vendedor.txt_codigo.Text & "', nom_vendedor = '" & form_vendedor.txt_desc.Text & "' where vendedor ='" & form_vendedor.txt_interno.Text & "'"
                    Insercion = New SqlCommand(sql_insert, conex)
                    Insercion.ExecuteNonQuery()

                    sql_insert = "update pda set vendedor = '" & form_vendedor.txt_codigo.Text & "', nom_vend = '" & form_vendedor.txt_desc.Text & "' where vendedor ='" & form_vendedor.txt_interno.Text & "'"
                    Insercion = New SqlCommand(sql_insert, conex)
                    Insercion.ExecuteNonQuery()

                    form_vendedor.txt_interno.Text = form_vendedor.txt_codigo.Text

                    form_vendedor.cmd_actualizar.Enabled = False
                    form_vendedor.cmd_actualizar.BackColor = Color.LightGray
                    form_vendedor.cmd_borrar.Enabled = False
                    form_vendedor.cmd_borrar.BackColor = Color.LightGray
                    form_vendedor.cmd_aceptar.Enabled = True
                    form_vendedor.cmd_aceptar.BackColor = Color.Black

                    Call verifica_p_venta()
                    Call desabilita_navegador()
                    Me.carga_vendedores_grilla()
                    Call limpiar()

                Catch ex As Exception

                    MsgBox("Registro ocupado", MsgBoxStyle.Exclamation, "PyMsoft")

                Finally

                    conex.Close()

                End Try

            End If

        End Sub

        Public Function verifica_existencia() As Boolean

            Dim comando3 As New SqlCommand("select *from vend_01 where id_vendedor like '%" & form_vendedor.txt_codigo.Text & "%' ", conex)

            If conex.State = ConnectionState.Closed Then conex.Open()
            Dim reader As SqlDataReader = comando3.ExecuteReader

            reader.Read()

            Try

                If reader("id_vendedor") = form_vendedor.txt_codigo.Text Then

                    existencia = True
                    Return True

                End If

            Catch ex As Exception

                form_vendedor.txt_nombre.Text = ""
                existencia = False
                Return False

            Finally

                conex.Close()
                comando3.Dispose()
                reader.Close()

            End Try

        End Function

        Public Function verifica_p_venta() As Boolean

            Dim comando3 As New SqlCommand("select * from numerador where punto_venta like '%" & form_vendedor.txt_codigo.Text & "%' ", conex)

            If conex.State = ConnectionState.Closed Then conex.Open()
            Dim reader As SqlDataReader = comando3.ExecuteReader

            reader.Read()

            Try

                If reader("punto_venta") = form_vendedor.txt_codigo.Text Then

                    existencia = True
                    Return True

                End If

            Catch ex As Exception

                existencia = False
                Return False

            Finally

                conex.Close()
                comando3.Dispose()
                reader.Close()

            End Try

        End Function

        Public Sub borrar()

            Dim borrar As Integer

            Try

                borrar = MessageBox.Show("Esta seguro que desea borrar el registro", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If borrar = 6 Then

                    verifica_relaciones()

                    If mvalidar = False Then

                        Dim sql_delet As String

                        sql_delet = "DELETE vend_01 WHERE id_vendedor= '" & form_vendedor.txt_codigo.Text & "'"

                        Dim deletin As New SqlCommand(sql_delet, conex)

                        If conex.State = ConnectionState.Closed Then conex.Open()
                        deletin.ExecuteNonQuery()

                        deletin.Dispose()

                        form_vendedor.cmd_actualizar.Enabled = False
                        form_vendedor.cmd_actualizar.BackColor = Color.LightGray
                        form_vendedor.cmd_borrar.Enabled = False
                        form_vendedor.cmd_borrar.BackColor = Color.LightGray
                        form_vendedor.cmd_aceptar.Enabled = True
                        form_vendedor.cmd_aceptar.BackColor = Color.Black

                        Call desabilita_navegador()

                        Call limpiar()
                        Me.carga_vendedores_grilla()

                    End If

                End If

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Private Sub verifica_relaciones()

            Dim comando As New SqlDataAdapter("select * from cli_01 where vendedor = '" & form_vendedor.txt_codigo.Text & "'", conex)
            comando.Fill(midataset, "cli_01")

            mvalidar = False

            If midataset.Tables("cli_01").Rows.Count > 0 Then
                MessageBox.Show("existen registros asociados a este registro!!!.. no se puede eliminar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mvalidar = True
            End If

        End Sub

        Public Sub sig()

            recorre.Position += 1
            form_vendedor.txt_codigo.Text = midataset.Tables("vend_01").Rows(recorre.Position).Item("id_vendedor")
            Call cargar(form_vendedor.txt_codigo.Text)

        End Sub

        Public Sub ant()

            recorre.Position -= 1
            form_vendedor.txt_codigo.Text = midataset.Tables("vend_01").Rows(recorre.Position).Item("id_vendedor")
            Call cargar(form_vendedor.txt_codigo.Text)


        End Sub

        Public Sub inicio()

            recorre.Position = 1
            form_vendedor.txt_codigo.Text = recorre.Position
            Call cargar(form_vendedor.txt_codigo.Text)

        End Sub

        Public Sub fin()

            recorre.Position = recorre.Count + 1
            form_vendedor.txt_codigo.Text = midataset.Tables("vend_01").Rows(recorre.Position).Item("id_vendedor")
            Call cargar(form_vendedor.txt_codigo.Text)

        End Sub

        Public Sub carga2()

            comando1.Fill(midataset, "vend_01")

            recorre = form_vendedor.BindingContext(midataset, "vend_01")

        End Sub

        Private Sub habilita_navegador()

            form_vendedor.cmd_sig.Enabled = True
            form_vendedor.cmd_ant.Enabled = True
            form_vendedor.cmd_pri.Enabled = True
            form_vendedor.cmd_ult.Enabled = True

        End Sub

        Private Sub desabilita_navegador()

            form_vendedor.cmd_sig.Enabled = False
            form_vendedor.cmd_ant.Enabled = False
            form_vendedor.cmd_pri.Enabled = False
            form_vendedor.cmd_ult.Enabled = False

        End Sub

        Public Sub buscar()

            Dim buscar As New SqlDataAdapter("select *from vend_01 where nombre like '" & busc_vendedor.txt_vendedor.Text & "%'", conex)

            buscar.Fill(midataset, "vend_01")

            busc_vendedor.DataGridView1.DataSource = midataset.Tables("vend_01")

            busc_vendedor.DataGridView1.Columns(0).Width = 100
            busc_vendedor.DataGridView1.Columns(1).Width = 300

            busc_vendedor.DataGridView1.Columns(0).HeaderText = "CODIGO"
            busc_vendedor.DataGridView1.Columns(1).HeaderText = "PROVINCIA"

            conex.Close()
            buscar.Dispose()
            midataset.Dispose()

        End Sub

        Public Sub cargar_vendedor()

            Try

                Dim comando2 As New SqlCommand(xinstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                xtexto = reader(xcodigo_vend)
                xtexto2 = reader(xnombre_vend)

                reader.Close()

            Catch ex As Exception

                xtexto2 = ""

            Finally

                conex.Close()
                busc_vendedor.Dispose()

            End Try

        End Sub

        Public Sub actualiza_vend_facturas()

            Try

                Dim sql_insert As String

                sql_insert = "update fact_cab set nom_vendedor = '" & form_vendedor.txt_nombre.Text & "', vendedor = '" & form_vendedor.txt_codigo.Text & "' where vendedor ='" & form_vendedor.txt_interno.Text & "'"

                Dim Insercion As New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try


        End Sub

    End Class

End Namespace
