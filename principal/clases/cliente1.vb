Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class cliente1

        Dim conex As New SqlConnection

        Dim valida As Boolean

        Dim comando1 As SqlDataAdapter

        Dim midataset As New DataSet

        Dim tb As DataTable

        Private minstruccion As String
        Private miva As String
        Private mcuit
        Private mverifica As Boolean
        Private mletra As Char

        Public Property insruccion()
            Get
                Return minstruccion
            End Get
            Set(ByVal value)
                minstruccion = value
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

        Public Property iva_solo()
            Get
                Return miva
            End Get
            Set(ByVal value)
                miva = value
            End Set
        End Property

        Public Property cuit()
            Get
                Return mcuit
            End Get
            Set(ByVal value)
                mcuit = value
            End Set
        End Property

        Public Property letra()
            Get
                Return mletra
            End Get
            Set(ByVal value)
                mletra = value
            End Set
        End Property

        Public Sub agregar()

            Try

                If valida = False Then

                    Dim Sql_insert As String

                    Sql_insert = "INSERT INTO cli_01(id_cli,nombre,direccion,tipo_cliente,cod_postal,localidad,telefono,fax,mail,tipo_iva,cuit,ing_brutos,vendedor,nom_vendedor,cod_list,nom_lista,rubro,observaciones,estado,fecha,num_loc,id_prov,provincia,id_zona,zona) VALUES('" + Form_cliente.txt_idcli.Text + "' , '" + Form_cliente.txt_nombre.Text + "', '" + Form_cliente.txt_direccion.Text + "', '" + Form_cliente.cmb_tipocliente.Text + "', '" + Form_cliente.txt_codpostal.Text + "', '" + Form_cliente.lbl_localidad.Text + "', '" + Form_cliente.txt_telefono.Text + "', '" + Form_cliente.txt_fax.Text + "', '" + Form_cliente.txt_mail.Text + "', '" + Form_cliente.cmb_iva.Text + "', '" + Form_cliente.txt_iva.Text + "', '" + Form_cliente.txt_ingbrutos.Text + "', '" + Form_cliente.txt_vendedor.Text + "','" + Form_cliente.lbl_vendedor.Text + "', '" + Form_cliente.txt_sucursal.Text + "','" + Form_cliente.lbl_sucursal.Text + "', '" + Form_cliente.cmb_rubro.Text + "', '" + Form_cliente.txt_observacion.Text + "', '" + Form_cliente.cmb_estado.Text + "', '" & Form_cliente.dt_fecha.Text & "', '" & Form_cliente.txt_localidad.Text & "','" & Form_cliente.txt_provincia.Text & "','" & Form_cliente.lbl_provincia.Text & "','" + Form_cliente.txt_zona.Text + "','" + Form_cliente.lbl_zona.Text + "')"
                    Dim Insercion As New SqlCommand(Sql_insert, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()
                    Insercion.Dispose()

                End If

            Catch ex As Exception

            Finally

                'If form_factura.txt_estado_form.Text <> 1 Then
                'midataset.Tables("cli_01").Clear()
                'comando1.Fill(midataset, "cli_01")
                'comando1.Dispose()
                'End If

                conex.Close()

            End Try


        End Sub

        Public Sub buscar()

            Try

                conex = conecta()
                Dim midataset As New DataSet

                If form_factura.txt_estado_form.Text = 1 Or form_factura.txt_estado_form.Text = 2 Then

                    'If RTrim(form_factura.txt_tipo_fact.Text) <> "RE" Or RTrim(form_factura.txt_tipo_fact.Text) <> "RS" Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Cliente' order by nombre ASC", conex)
                    'If RTrim(form_factura.txt_tipo_fact.Text) = "RE" Or RTrim(form_factura.txt_tipo_fact.Text) = "RS" Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente <> 'Cliente' order by nombre ASC", conex)
                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and estado = 'ACTIVO' order by nombre ASC", conex)

                    comando1.Fill(midataset, "cli_01")
                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_consulta_rem_cli.txt_estado_form.Text = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and (tipo_cliente like 'Furgon' or tipo_cliente = 'Proveedor') and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_consul_cta_cte.txt_estado_form.Text = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente = 'Cliente' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_consul_cta_cte.txt_estado_form.Text = 2 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente = 'Proveedor' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_recibos.txt_estado_form.Text = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Cliente' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_recibos.txt_estado_form.Text = 2 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Proveedor' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If RTrim(Form_compras.txt_estado_form.Text) = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and (tipo_cliente like 'Gastos y Servicio' or tipo_cliente like 'Proveedor') and estado = 'ACTIVO' order by nombre ASC", conex)

                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_resumen_cta.txt_estado_form.Text = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Cliente' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Cliente' and estado = 'ACTIVO' order by nombre ASC", conex)
                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If RTrim(form_factura.txt_remito.Text) = 0 And Trim(Form_cliente.txt_estado_form.Text = 1) Then

                    If Form_cliente.opt_cliente.Checked = True Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Cliente' and estado = 'ACTIVO' order by nombre ASC", conex)
                    If Form_cliente.opt_proovedor.Checked = True Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Proveedor' and estado = 'ACTIVO' order by nombre ASC", conex)
                    If Form_cliente.opt_gastosserv.Checked = True Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Gastos y Servicio' and estado = 'ACTIVO' order by nombre ASC", conex)
                    If Form_cliente.opt_furgon.Checked = True Then comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Furgon' and estado = 'ACTIVO' order by nombre ASC", conex)

                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If RTrim(form_factura.txt_remito.Text) <> 0 Or RTrim(Form_consulta_rem_cli.txt_estado_form.Text) = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Furgon' or tipo_cliente like 'Proveedor' and estado = 'ACTIVO' order by nombre ASC", conex)

                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

                If RTrim(form_factura.txt_remito.Text) <> 0 Or RTrim(Form_presupuesto.txt_estado_form.Text) = 1 Then

                    comando1 = New SqlDataAdapter("select *from cli_01 where nombre like '" & busc_cliente.txt_buscar.Text & "%' and tipo_cliente like 'Furgon' or tipo_cliente like 'Proveedor' and estado = 'ACTIVO' order by nombre ASC", conex)

                    comando1.Fill(midataset, "cli_01")

                    busc_cliente.DataGridView1.DataSource = midataset.Tables("cli_01")

                    busc_cliente.DataGridView1.Columns(0).Width = 100
                    busc_cliente.DataGridView1.Columns(1).Width = 200
                    busc_cliente.DataGridView1.Columns(2).Width = 250
                    busc_cliente.DataGridView1.Columns(3).Width = 150

                    comando1.Dispose()
                    midataset.Dispose()

                    busc_cliente.DataGridView1.Focus()
                    Exit Sub

                End If

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub limpiar()

            If valida = False Then

                Form_cliente.txt_idcli.Text = ""
                Form_cliente.txt_nombre.Text = ""
                Form_cliente.txt_direccion.Text = ""
                Form_cliente.txt_localidad.Text = ""
                Form_cliente.txt_codpostal.Text = ""
                Form_cliente.txt_telefono.Text = ""
                Form_cliente.txt_mail.Text = ""
                Form_cliente.txt_fax.Text = ""
                Form_cliente.txt_iva.Text = ""
                Form_cliente.txt_ingbrutos.Text = ""
                Form_cliente.txt_vendedor.Text = ""
                Form_cliente.lbl_vendedor.Text = ""
                Form_cliente.txt_observacion.Text = ""
                Form_cliente.txt_sucursal.Text = ""
                Form_cliente.lbl_sucursal.Text = ""
                Form_cliente.lbl_localidad.Text = ""
                Form_cliente.lbl_provincia.Text = ""
                Form_cliente.txt_provincia.Text = ""
                Form_cliente.txt_zona.Text = ""
                Form_cliente.lbl_zona.Text = ""

            End If

        End Sub

        Public Sub carga_grilla_clientes(ByVal tipo As String)

            tb = New DataTable
            tb.Clear()

            conex = conecta()

            comando1 = New SqlDataAdapter("Select * from cli_01 where tipo_cliente = '" & Trim(tipo) & "'", conex)
            comando1.Fill(tb)
            comando1.Dispose()

            Form_cliente.DataGridView1.DataSource = tb

            Form_cliente.DataGridView1.Columns(1).Width = 250
            Form_cliente.DataGridView1.Columns(2).Width = 250

            tb.Dispose()

        End Sub

        Public Sub cargar_registro()

            Try

                conex = conecta()

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader
                comando2.Dispose()

                reader.Read()

                If Form_cliente.txt_estado_form.Text = 1 Then

                    Form_cliente.txt_interno.Text = reader("id_cli")
                    Form_cliente.txt_idcli.Text = reader("id_cli")
                    Form_cliente.txt_nombre.Text = reader("nombre")
                    Form_cliente.txt_direccion.Text = reader("direccion")
                    Form_cliente.cmb_tipocliente.Text = reader("tipo_cliente")
                    Form_cliente.txt_codpostal.Text = reader("cod_postal")
                    Form_cliente.lbl_localidad.Text = reader("localidad")
                    Form_cliente.txt_localidad.Text = reader("num_loc")
                    Form_cliente.txt_provincia.Text = reader("id_prov")
                    Form_cliente.lbl_provincia.Text = reader("provincia")
                    Form_cliente.txt_telefono.Text = reader("telefono")
                    Form_cliente.txt_fax.Text = reader("fax")
                    Form_cliente.txt_mail.Text = reader("mail")
                    Form_cliente.cmb_iva.Text = reader("tipo_iva")
                    Form_cliente.txt_iva.Text = reader("cuit")
                    Form_cliente.txt_ingbrutos.Text = reader("ing_brutos")
                    Form_cliente.txt_vendedor.Text = reader("vendedor")
                    Form_cliente.lbl_vendedor.Text = reader("nom_vendedor")
                    Form_cliente.txt_sucursal.Text = reader("cod_list")
                    Form_cliente.lbl_sucursal.Text = reader("nom_lista")
                    Form_cliente.cmb_rubro.Text = reader("rubro")
                    Form_cliente.txt_observacion.Text = reader("observaciones")
                    Form_cliente.cmb_estado.Text = reader("estado")
                    Form_cliente.dt_fecha.Text = reader("fecha")
                    Form_cliente.txt_zona.Text = reader("id_zona")
                    Form_cliente.lbl_zona.Text = reader("zona")

                    If Trim(Form_cliente.cmb_estado.Text) = "ACTIVO" Then
                        Form_cliente.txt_muestraestado.Text = "A"
                    Else
                        Form_cliente.txt_muestraestado.Text = "B"
                    End If

                    Form_cliente.cmd_actualizar.Enabled = True
                    Form_cliente.cmd_actualizar.BackColor = Color.Black
                    Form_cliente.cmd_borrar.Enabled = True
                    Form_cliente.cmd_borrar.BackColor = Color.Black
                    Form_cliente.cmd_aceptar.Enabled = False
                    Form_cliente.cmd_aceptar.BackColor = Color.LightGray

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_consulta_rem_cli.txt_estado_form.Text = 1 Then

                    Form_consulta_rem_cli.txt_codigo.Text = reader("id_cli")
                    Form_consulta_rem_cli.lbl_cliente.Text = reader("nombre")
                    Form_consulta_rem_cli.dt_fec_desde.Focus()

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If form_factura.txt_estado_form.Text = 1 And form_factura.ativo = False Then

                    form_factura.ativo = True

                    form_factura.txt_codigo.Text = reader("id_cli")
                    form_factura.txt_cliente.Text = reader("nombre")
                    form_factura.txt_direccion.Text = reader("direccion")
                    form_factura.txt_direccion.Text = form_factura.txt_direccion.Text & "   -   " & reader("localidad")
                    form_factura.txt_iva.Text = reader("tipo_iva")
                    Me.iva_solo = reader("tipo_iva")
                    form_factura.txt_iva_solo.Text = Me.iva_solo
                    Me.cuit = reader("cuit")
                    form_factura.cuit = Me.cuit
                    form_factura.txt_cuit.Text = reader("cuit")
                    form_factura.txt_iva.Text = form_factura.txt_iva.Text & "    " & "-" & "    "
                    form_factura.txt_iva.Text = form_factura.txt_iva.Text & reader("cuit")
                    form_factura.txt_vendedor.Text = reader("vendedor")
                    form_factura.txt_nom_vendedor.Text = reader("nom_vendedor")
                    form_factura.txt_cod_lista.Text = reader("cod_list")
                    form_factura.txt_lista.Text = reader("nom_lista")
                    form_factura.txt_ingbrutos.Text = reader("ing_brutos")
                    form_factura.txt_tipo_cliente.Text = reader("tipo_cliente")

                    form_factura.txt_codigo.Enabled = False

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) And Form_recibos.activo = False Then

                    Form_recibos.activo = True

                    Form_recibos.txt_codigo.Text = reader("id_cli")
                    Form_recibos.txt_cliente.Text = reader("nombre")
                    Form_recibos.txt_direccion.Text = reader("direccion")
                    Form_recibos.txt_direccion.Text = Form_recibos.txt_direccion.Text & "   -   " & reader("localidad")
                    Form_recibos.txt_iva.Text = reader("tipo_iva")
                    Me.iva_solo = reader("tipo_iva")
                    Me.cuit = reader("cuit")
                    Form_recibos.txt_iva.Text = Form_recibos.txt_iva.Text & "    " & "-" & "    "
                    Form_recibos.txt_iva.Text = Form_recibos.txt_iva.Text & reader("cuit")
                    Form_recibos.txt_vendedor.Text = reader("vendedor")
                    Form_recibos.txt_nom_vendedor.Text = reader("nom_vendedor")

                    If Form_recibos.txt_prefijo.Enabled = False Then
                        Form_recibos.txt_prefijo.Text = 0
                    End If

                    Form_recibos.txt_codigo.Enabled = False
                    Form_recibos.txt_comprobante.Focus()

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If (RTrim(Form_consul_cta_cte.txt_estado_form.Text) = 1 Or RTrim(Form_consul_cta_cte.txt_estado_form.Text) = 2) And Form_consul_cta_cte.activo = False Then

                    Form_consul_cta_cte.activo = True

                    Form_consul_cta_cte.txt_codigo.Text = reader("id_cli")
                    Form_consul_cta_cte.lbl_cliente.Text = reader("nombre")
                    Form_consul_cta_cte.dt_fec_emi.Focus()

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_resumen_cta.txt_estado_form.Text = 1 And Form_resumen_cta.activo = False Then

                    Form_resumen_cta.activo = True

                    Form_resumen_cta.txt_codigo.Text = reader("id_cli")
                    Form_resumen_cta.lbl_cliente.Text = reader("nombre")
                    Form_resumen_cta.dt_fec_emi.Focus()

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_presupuesto.txt_estado_form.Text = 1 And Form_presupuesto.activo = False Then

                    Form_presupuesto.activo = True

                    Form_presupuesto.txt_codigo.Text = reader("id_cli")
                    Form_presupuesto.txt_cliente.Text = reader("nombre")
                    Form_presupuesto.txt_direccion.Text = reader("direccion") & "   -   " & reader("localidad")
                    Form_presupuesto.txt_telef.Text = reader("telefono")
                    Form_presupuesto.txt_validez.Focus()
                    Form_presupuesto.txt_codigo.Enabled = False

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_consulta_rem_cli.txt_estado_form.Text = 1 And Form_consulta_rem_cli.activo = False Then

                    Form_consulta_rem_cli.activo = True

                    Form_consulta_rem_cli.txt_codigo.Text = reader("id_cli")
                    Form_consulta_rem_cli.lbl_cliente.Text = reader("nombre")
                    Form_consulta_rem_cli.dt_fec_desde.Focus()

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_compras.txt_estado_form.Text = 1 And Form_compras.activo = True Then

                    Form_compras.txt_codigo.Text = reader("id_cli")
                    Form_compras.txt_cliente.Text = reader("nombre")
                    Form_compras.txt_direccion.Text = reader("direccion")
                    Form_compras.txt_cuit.Text = reader("cuit")
                    Form_compras.txt_iva.Text = reader("tipo_iva") & " - " & reader("cuit")
                    Form_compras.txt_tipo_iva.Text = reader("tipo_iva")
                    Form_compras.txt_lista.Text = reader("nom_lista")
                    Form_compras.txt_prefijo.Focus()

                    If reader("tipo_iva") = "Monotributo" Then Form_compras.txt_letra.Text = "C"
                    If reader("tipo_iva") = "Responsable Inscripto" Then Form_compras.txt_letra.Text = "A"
                    If reader("tipo_iva") = "Exento" Then Form_compras.txt_letra.Text = "B"

                    If reader("tipo_iva") = "Consumidor Final" Then
                        MessageBox.Show("Verifique Tipo Iva", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Form_compras.Dispose()
                    End If

                    reader.Close()

                    busc_cliente.Dispose()
                    comando2.Dispose()
                    mverifica = True

                    Exit Sub

                End If

                If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then

                    Dim cod As Integer = reader("id_cli")
                    Dim nom As String = reader("nombre")
                    Dim dir As String = reader("direccion")
                    Dim cuitt As String = reader("cuit")
                    Dim tip_iv As String = reader("tipo_iva")
                    Dim ing_b As String = reader("ing_brutos")

                    reader.Close()
                    comando2.Dispose()

                    Me.iva_solo = tip_iv
                    Me.carga_letra()

                    Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(5).Value = nom

                    Dim coman As New SqlCommand("update fact_cab set letra_fact = '" & Me.letra & "',id_cli = '" & cod & "',nombre = '" & nom & "',tipo_iva = '" & tip_iv & "',cuit = '" & cuitt & "',direccion = '" & dir & "',ing_bruto1 = '" & ing_b & "' where num_fact1 = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(2).Value & "' and tipo_fact = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(1).Value & "' and prefijo_fact = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(4).Value & "' and letra_fact = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(3).Value & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    Dim comannn As New SqlCommand("update fact_det set letra_fact1 = '" & Me.letra & "' where num_fact = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(2).Value & "' and tipo_fact2 = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(1).Value & "' and prefijo_fact2 = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(4).Value & "' and letra_fact1 = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(3).Value & "'", conex)
                    comannn.ExecuteNonQuery()
                    comannn.Dispose()

                    Dim comann As New SqlCommand("update fact_tot set letra = '" & Me.letra & "',nombre_cli = '" & nom & "',id_cliente = '" & cod & "' where num_factura = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(2).Value & "' and tipo_factura = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(1).Value & "' and pref = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(4).Value & "' and letra = '" & Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(3).Value & "'", conex)
                    comann.ExecuteNonQuery()
                    comann.Dispose()

                    Form_muestra_cons_comp.DataGridView1.Rows(Form_muestra_cons_comp.pos).Cells(3).Value = Me.letra

                    busc_cliente.Dispose()
                    mverifica = True

                    Exit Sub

                End If

            Catch ex As Exception

                mverifica = False
                Form_recibos.activo = False
                Me.limpiar()

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub actualizar()

            Try

                Dim sql_insert As String
                Dim Insercion As SqlCommand
                Dim tb As New DataTable
                Dim comando As SqlDataAdapter

                sql_insert = "update cli_01 set id_cli= '" & Form_cliente.txt_idcli.Text & "', nombre = '" & Form_cliente.txt_nombre.Text & "', direccion= '" & Form_cliente.txt_direccion.Text & "',tipo_cliente='" & Form_cliente.cmb_tipocliente.Text & "',cod_postal='" & Form_cliente.txt_codpostal.Text & "',localidad='" & Form_cliente.lbl_localidad.Text & "',telefono='" & Form_cliente.txt_telefono.Text & "',fax='" & Form_cliente.txt_fax.Text & "',mail='" & Form_cliente.txt_mail.Text & "',tipo_iva='" & Form_cliente.cmb_iva.Text & "',cuit='" & Form_cliente.txt_iva.Text & "',ing_brutos='" & Form_cliente.txt_ingbrutos.Text & "',vendedor='" & Form_cliente.txt_vendedor.Text & "',nom_vendedor='" & Form_cliente.lbl_vendedor.Text & "',cod_list='" & Form_cliente.txt_sucursal.Text & "',nom_lista='" & Form_cliente.lbl_sucursal.Text & "',rubro='" & Form_cliente.cmb_rubro.Text & "',observaciones='" & Form_cliente.txt_observacion.Text & "',estado='" & Form_cliente.cmb_estado.Text & "',fecha='" & Form_cliente.dt_fecha.Text & "',num_loc= '" & Form_cliente.txt_localidad.Text & "', id_prov='" & Form_cliente.txt_provincia.Text & "',provincia='" & Form_cliente.lbl_provincia.Text & "',id_zona = '" & Form_cliente.txt_zona.Text & "',zona= '" & Form_cliente.lbl_zona.Text & "' where id_cli ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update cta_cte01 set id_cli = '" & Form_cliente.txt_idcli.Text & "', cli = '" & Form_cliente.txt_nombre.Text & "',cod_vend = '" & Form_cliente.txt_vendedor.Text & "' where id_cli ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update cta_cte_hist set id_cli = '" & Form_cliente.txt_idcli.Text & "', cli = '" & Form_cliente.txt_nombre.Text & "' where id_cli ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update fact_cab set id_cli= '" & Form_cliente.txt_idcli.Text & "', nombre = '" & Form_cliente.txt_nombre.Text & "', direccion= '" & Form_cliente.txt_direccion.Text & "',tipo_iva='" & Form_cliente.cmb_iva.Text & "',cuit='" & Form_cliente.txt_iva.Text & "',ing_bruto1='" & Form_cliente.txt_ingbrutos.Text & "',vendedor='" & Form_cliente.txt_vendedor.Text & "',nom_vendedor='" & Form_cliente.lbl_vendedor.Text & "',id_lista='" & Form_cliente.txt_sucursal.Text & "',lista='" & Form_cliente.lbl_sucursal.Text & "'  where id_cli ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update fact_tot set id_cliente= '" & Form_cliente.txt_idcli.Text & "', nombre_cli = '" & Form_cliente.txt_nombre.Text & "' where id_cliente ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update recibo_cab set id_cli= '" & Form_cliente.txt_idcli.Text & "', nombre = '" & Form_cliente.txt_nombre.Text & "', direccion= '" & Form_cliente.txt_direccion.Text & "',cod_vendedor='" & Form_cliente.txt_vendedor.Text & "',nom_vendedor='" & Form_cliente.lbl_vendedor.Text & "' where id_cli = '" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update recibo_det set id_cli01 = '" & Form_cliente.txt_idcli.Text & "' where id_cli01 ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                sql_insert = "update recibo_tot set id_cliente= '" & Form_cliente.txt_idcli.Text & "' where id_cliente ='" & RTrim(Form_cliente.txt_interno.Text) & "'"

                Insercion = New SqlCommand(sql_insert, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                ' verifico si es un proveedor para actualizar los articulos

                tb.Clear()
                conex = conecta()

                comando = New SqlDataAdapter("select tipo_cliente from cli_01 where id_cli = '" & RTrim(Form_cliente.txt_idcli.Text) & "'", conex)
                comando.Fill(tb)
                comando.Dispose()

                If RTrim(tb.Rows(0).Item(0)) = "Proveedor" Then

                    sql_insert = "update art_01 set id_proveedor = '" & Form_cliente.txt_idcli.Text & "',proveedor = '" & Form_cliente.txt_nombre.Text & "' where id_proveedor = '" & Form_cliente.txt_interno.Text & "'"

                    Insercion = New SqlCommand(sql_insert, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()
                    Insercion.Dispose()

                End If

                Form_cliente.cmd_actualizar.Enabled = False
                Form_cliente.cmd_actualizar.BackColor = Color.LightGray
                Form_cliente.cmd_borrar.Enabled = False
                Form_cliente.cmd_borrar.BackColor = Color.LightGray
                Form_cliente.cmd_aceptar.Enabled = True
                Form_cliente.cmd_aceptar.BackColor = Color.Black

                Call limpiar()

                Insercion.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub validar_registro()

            If Form_cliente.txt_idcli.Text = "" Or Form_cliente.txt_nombre.Text = "" Or Form_cliente.txt_direccion.Text = "" Or Form_cliente.txt_localidad.Text = "" Or Form_cliente.txt_codpostal.Text = "" Or Form_cliente.txt_iva.Text = "" Or Form_cliente.txt_vendedor.Text = "" Or Form_cliente.txt_sucursal.Text = "" Or Form_cliente.txt_provincia.Text = "" Or Form_cliente.lbl_provincia.Text = "" Then

                valida = True
                MsgBox("Debe completar los campos marcados", MsgBoxStyle.Information, "PymSoft")

            Else

                valida = False
                Call validar_cliente()

            End If

        End Sub

        Public Sub borrar()

            Dim borrar As Integer

            Try

                borrar = MsgBox("Esta seguro que desea borrar el registro", MsgBoxStyle.YesNo, "PymSoft")

                If borrar = 6 Then

                    Dim midataset As New DataSet

                    Dim sql_delet As String

                    sql_delet = "DELETE cli_01 WHERE id_cli= '" & Form_cliente.txt_idcli.Text & "'"

                    Dim deletin As New SqlCommand(sql_delet, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    deletin.ExecuteNonQuery()

                    Form_cliente.cmd_actualizar.Enabled = False
                    Form_cliente.cmd_actualizar.BackColor = Color.LightGray
                    Form_cliente.cmd_borrar.Enabled = False
                    Form_cliente.cmd_borrar.BackColor = Color.LightGray
                    Form_cliente.cmd_aceptar.Enabled = True
                    Form_cliente.cmd_aceptar.BackColor = Color.Black

                    Call limpiar()

                End If


            Catch ex As Exception


            Finally

                midataset.Tables("cli_01").Clear()
                comando1.Fill(midataset, "cli_01")
                conex.Close()
                midataset.Dispose()

            End Try

        End Sub

        Private Sub validar_cliente()

            Try

                conex = conecta()

                Dim comando3 As New SqlCommand("select id_cli,nombre,cuit,tipo_iva from cli_01 where (id_cli = '" & Form_cliente.txt_idcli.Text & "' or nombre = '" & Form_cliente.txt_nombre.Text & "' or cuit = '" & Form_cliente.txt_iva.Text & "') and Tipo_cliente = '" & Trim(Form_cliente.cmb_tipocliente.Text) & "'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando3.ExecuteReader

                reader.Read()

                If reader("tipo_iva") = "Consumidor Final" Then

                    If reader("id_cli") = Form_cliente.txt_idcli.Text Or reader("nombre") = Form_cliente.txt_nombre.Text Then

                        MsgBox("El numero,nombre o cuit estan en uso!!!", MsgBoxStyle.MsgBoxSetForeground, "PymSoft")
                        Form_cliente.txt_idcli.Focus()

                        valida = True

                    End If

                Else

                    If reader("id_cli") = Form_cliente.txt_idcli.Text Or reader("nombre") = Form_cliente.txt_nombre.Text Or reader("cuit") = Form_cliente.txt_iva.Text Then

                        MsgBox("El numero,nombre o cuit estan en uso!!!", MsgBoxStyle.MsgBoxSetForeground, "PymSoft")
                        Form_cliente.txt_idcli.Focus()

                        valida = True

                    End If

                End If

                comando3.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Function validarcuit(ByVal p_cuit As String) As Boolean

            Dim coeficiente As New ArrayList
            Dim i, sumador, veri_nro, resultado As Integer
            Dim cuit_temp As String
            coeficiente.Add(5)
            coeficiente.Add(4)
            coeficiente.Add(3)
            coeficiente.Add(2)
            coeficiente.Add(7)
            coeficiente.Add(6)
            coeficiente.Add(5)
            coeficiente.Add(4)
            coeficiente.Add(3)
            coeficiente.Add(2)
            cuit = Trim(p_cuit)
            cuit_temp = ""
            For i = 1 To Len(cuit)      'separo cualquier caracter que no tenga que ver con numeros
                If Asc(Mid(cuit, i, 1)) >= 48 And Asc(Mid(cuit, i, 1)) <= 57 Then
                    cuit_temp = cuit_temp & Mid(cuit, i, 1)
                End If
            Next
            cuit_temp = Trim(cuit_temp)
            If Len(cuit_temp) <> 11 Then            ' si to estan todos los digitos
                MsgBox("No están todos los dígitos. ", vbDefaultButton1, "Error en el C.U.I.T.")
            Else
                sumador = 0
                Dim verificador As Integer = CInt(Val(Mid(cuit_temp, 11, 1))) 'tomo el digito verificador
                For i = 0 To 9
                    sumador = sumador + CInt(Mid(cuit_temp, i + 1, 1)) * CInt(coeficiente.Item(i))
                    'separo cada digito y lo multiplico por el coeficiente
                Next
                resultado = sumador Mod 11
                resultado = 11 - resultado  'saco el digito verificador
                If (resultado = 11) Then resultado = 0
                veri_nro = verificador
                If veri_nro <> resultado Then
                    validarcuit = False
                Else
                    cuit_temp = Mid(cuit_temp, 1, 2) & "-" & Mid(cuit_temp, 3, 8) & "-" & Mid(cuit_temp, 11, 1)
                    validarcuit = True
                End If
            End If

        End Function

        Public Function calcula_maximo_id() As Integer

            Try

                conex = conecta()

                Dim comando3 As New SqlCommand("select max(id_cli) from cli_01 where tipo_cliente like 'Cliente'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando3.ExecuteReader

                reader.Read()

                calcula_maximo_id = reader.Item(0)

                comando3.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Function


        Public Sub valida_cliente1()

            Try

                conex = conecta()

                Dim comando3 As New SqlCommand("select id_cli from cli_01 where id_cli like '" & Form_cliente.txt_idcli.Text & "'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando3.ExecuteReader

                While reader.Read()

                    Call mostrar_registro_navegador(Form_cliente.txt_idcli.Text)
                    Exit Sub

                End While

                Form_cliente.cmd_aceptar.Enabled = True
                Form_cliente.cmd_aceptar.BackColor = Color.Black
                Form_cliente.cmd_actualizar.Enabled = False
                Form_cliente.cmd_actualizar.BackColor = Color.LightGray
                Form_cliente.cmd_borrar.Enabled = False
                Form_cliente.cmd_borrar.BackColor = Color.LightGray
                Form_cliente.txt_nombre.Focus()
                Call limpiar2()
                Call llena_registros_puntuales()

                reader.Close()
                comando3.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Private Sub llena_registros_puntuales()

            If Form_cliente.cmb_iva.Text = "Consumidor Final" Then
                Form_cliente.txt_iva.Text = "00000000000"
            End If

            Form_cliente.dt_fecha.Value = Date.Now

        End Sub


        Public Sub mostrar_registro_navegador(ByVal cliente As String)

            Try

                conex = conecta()

                Dim comando2 As New SqlCommand("select *from cli_01 where id_cli = '" & cliente & "'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader
                comando2.Dispose()

                reader.Read()

                Form_cliente.txt_interno.Text = reader("id_cli")
                Form_cliente.txt_idcli.Text = reader("id_cli")
                Form_cliente.txt_nombre.Text = reader("nombre")
                Form_cliente.txt_direccion.Text = reader("direccion")
                Form_cliente.cmb_tipocliente.Text = reader("tipo_cliente")
                Form_cliente.txt_codpostal.Text = reader("cod_postal")
                Form_cliente.lbl_localidad.Text = reader("localidad")
                Form_cliente.txt_provincia.Text = reader("id_prov")
                Form_cliente.lbl_provincia.Text = reader("provincia")
                Form_cliente.txt_localidad.Text = reader("num_loc")
                Form_cliente.txt_telefono.Text = reader("telefono")
                Form_cliente.txt_fax.Text = reader("fax")
                Form_cliente.txt_mail.Text = reader("mail")
                Form_cliente.cmb_iva.Text = reader("tipo_iva")
                Form_cliente.txt_iva.Text = reader("cuit")
                Form_cliente.txt_ingbrutos.Text = reader("ing_brutos")
                Form_cliente.txt_vendedor.Text = reader("vendedor")
                Form_cliente.lbl_vendedor.Text = reader("nom_vendedor")
                Form_cliente.txt_sucursal.Text = reader("cod_list")
                Form_cliente.lbl_sucursal.Text = reader("nom_lista")
                Form_cliente.cmb_rubro.Text = reader("rubro")
                Form_cliente.txt_observacion.Text = reader("observaciones")
                Form_cliente.cmb_estado.Text = reader("estado")
                Form_cliente.dt_fecha.Text = reader("fecha")
                Form_cliente.txt_zona.Text = reader("id_zona")
                Form_cliente.lbl_zona.Text = reader("zona")

                If Trim(Form_cliente.cmb_estado.Text) = "ACTIVO" Then
                    Form_cliente.txt_muestraestado.Text = "A"
                Else
                    Form_cliente.txt_muestraestado.Text = "B"
                End If

                reader.Close()

                Form_cliente.cmd_actualizar.Enabled = True
                Form_cliente.cmd_actualizar.BackColor = Color.Black
                Form_cliente.cmd_borrar.Enabled = True
                Form_cliente.cmd_borrar.BackColor = Color.Black
                Form_cliente.cmd_aceptar.Enabled = False
                Form_cliente.cmd_aceptar.BackColor = Color.LightGray

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Private Sub limpiar2()

            Form_cliente.txt_nombre.Text = ""
            Form_cliente.txt_direccion.Text = ""
            Form_cliente.txt_localidad.Text = ""
            Form_cliente.txt_codpostal.Text = ""
            Form_cliente.txt_telefono.Text = ""
            Form_cliente.txt_mail.Text = ""
            Form_cliente.txt_fax.Text = ""
            Form_cliente.txt_iva.Text = ""
            Form_cliente.txt_ingbrutos.Text = ""
            Form_cliente.txt_vendedor.Text = ""
            Form_cliente.lbl_vendedor.Text = ""
            Form_cliente.txt_observacion.Text = ""
            Form_cliente.txt_sucursal.Text = ""
            Form_cliente.lbl_sucursal.Text = ""
            Form_cliente.lbl_localidad.Text = ""
            Form_cliente.txt_provincia.Text = ""
            Form_cliente.lbl_provincia.Text = ""
            Form_cliente.txt_zona.Text = ""
            Form_cliente.lbl_zona.Text = ""

        End Sub

        Public Sub validar_cuit()

            Try

                conex = conecta()

                Dim comando3 As New SqlCommand("select cuit from cli_01 where cuit like '" & Form_cliente.txt_iva.Text & "'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando3.ExecuteReader

                reader.Read()

                If reader("cuit") = Form_cliente.txt_iva.Text Then

                    MsgBox("El numero esta en uso", MsgBoxStyle.MsgBoxSetForeground, "PymSoft")
                    Form_cliente.txt_iva.Focus()

                End If

                comando3.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub carga_letra()

            If form_factura.txt_estado_form.Text = 1 Then

                If Trim(form_factura.txt_remito.Text) <> 1 And Trim(form_factura.txt_remito.Text) <> 2 Then
                    If (form_factura.ticket = "SI" Or form_factura.txt_talonario_pred.Text = 2) Then
                        form_factura.txt_letra.Text = "C"
                        Exit Sub
                    End If
                End If

                If Me.iva_solo = "Responsable Inscripto" Or Me.iva_solo = "Monotributo" Then
                    form_factura.txt_letra.Text = "A"
                Else
                    form_factura.txt_letra.Text = "B"
                End If

            End If

            If Form_recibos.txt_estado_form.Text = 1 Then

                If RTrim(Form_recibos.fact.factura_en_c) = "SI" Then
                    Form_recibos.txt_letra.Text = "C"
                    Exit Sub
                End If

                If Me.iva_solo = "Responsable Inscripto" Then
                    Form_recibos.txt_letra.Text = "A"
                Else
                    Form_recibos.txt_letra.Text = "B"
                End If

            End If

            If Form_recibos.txt_estado_form.Text = 2 Then
                Form_recibos.txt_letra.Text = "X"
            End If

            If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then

                If busc_cliente.factura_en_c = "SI" Then

                    Me.letra = "C"

                Else

                    If Me.iva_solo = "Responsable Inscripto" Then
                        Me.letra = "A"
                    Else
                        Me.letra = "B"
                    End If

                End If

            End If

        End Sub

        Public Function verifica_movimiento_cta_cte(ByVal codcli As Integer) As Boolean

            Dim tb As New DataTable

            tb.Clear()

            conex = conecta()

            comando1 = New SqlDataAdapter("select * from cta_cte_hist where id_cli = '" & RTrim(codcli) & "'", conex)
            comando1.Fill(tb)
            comando1.Dispose()

            If tb.Rows.Count = Nothing Then
                Return False
            Else
                MessageBox.Show("No se puede borrar... Tiene movimientos en cta cte", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            End If

            tb.Dispose()

        End Function

        Public Function verifica_movimiento_facturacion(ByVal codcli As Integer) As Boolean

            Dim tb As New DataTable

            tb.Clear()

            conex = conecta()

            comando1 = New SqlDataAdapter("select * from fact_cab where id_cli = '" & RTrim(codcli) & "'", conex)
            comando1.Fill(tb)
            comando1.Dispose()

            If tb.Rows.Count = Nothing Then
                Return False
            Else
                MessageBox.Show("No se puede borrar... Tiene movimientos en facturacion", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            End If

            tb.Dispose()

        End Function

        Public Function verifica_en_producto(ByVal codcli As Integer) As Boolean

            Dim tb As New DataTable

            tb.Clear()

            conex = conecta()

            comando1 = New SqlDataAdapter("select * from art_01 where id_proveedor = '" & RTrim(codcli) & "'", conex)
            comando1.Fill(tb)
            comando1.Dispose()

            If tb.Rows.Count = Nothing Then
                Return False
            Else
                MessageBox.Show("No se puede borrar... esta asociado a productos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            End If

            tb.Dispose()

        End Function


    End Class

End Namespace
