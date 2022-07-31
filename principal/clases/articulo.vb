Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft

    Public Class articulo

        Dim conex As New SqlConnection

        Dim descuentos As Boolean = False

        Private minstruccion As String
        Private miva As String
        Private mimpuestos_internos As Single
        Private mcod_imp As Integer
        Private mcosto As Single
        Private mutilidad As Single
        Private mprecio_siva As Single
        Private mprecio_civa As Single
        Private mmueve_stok As String
        Private mcodigo As String
        Private mnombre As String
        Private mdescripcion As String
        Private mcod_rubro As Integer
        Private mnom_rubro As String
        Private mcod_barra As String
        Private mcantidad As Single
        Private mcant_bulto As Integer
        Private mcod_prov As Integer
        Private mnom_prov As String
        Private mid_lista As Integer
        Private mnom_lista As String
        Private mid_compras As Integer
        Private mnom_compras As String
        Private mid_ventas As Integer
        Private mnom_ventas As String
        Private mfec_alta As Date
        Private mfec_mod As Date
        Private mestado As String
        Private mverifica_campos
        Private mborra As Integer
        Private mexento As Single
        Private mcodigo_iva As Integer
        Private mduplicado As Boolean
        Private mnavegador As String
        Private mform As Object
        Private mcodigo_tabla
        Private mdescuento1 As Single
        Private mdescuento2 As Single
        Private mdescuento3 As Single
        Private mflete As Single
        Private mpagototal As Single
        Private mmoneda As String
        Private munidad_secundaria As String
        Private mpeso_promedio As Single
        Private mvalormoneda As String
        Private mbonificacion_vetas As Single
        Private x As String
        Private xx As String
        Private xxx As String
        Private xxxx As String
        Private xxxxx As String
        Private xxxxxx As String
        Private xxxxxxx As String
        Private xxxxxxxx As String
        Private xxxxxxxxx As String
        Private xxxxxxxxxx As String
        Private xxxxxxxxxxx As String
        Private xxxxxxxxxxxx As String
        Private xxxxxxxxxxxxx As String
        Private mprov As Integer
        Private mrub As Integer
        Private z As String
        Private zz As String
        Private zzz As String
        Private zzzz As String
        Private zzzz1 As String
        Private zzzz2 As String
        Private zzzz3 As String
        Private mvalida As Boolean
        Private miva_insc As Single
        Private mstok As Decimal

        Private recorre As BindingManagerBase
        Dim midataset As New DataSet

        Public Sub New()
            minstruccion = minstruccion
            miva = miva
            mimpuestos_internos = mimpuestos_internos
            mcosto = mcosto
            mutilidad = mutilidad
            mprecio_siva = mprecio_siva
            mprecio_civa = mprecio_civa
            mmueve_stok = mmueve_stok
        End Sub

        Public Property bonificacion_ventas()
            Set(ByVal value)
                mbonificacion_vetas = Val(value)
            End Set
            Get
                Return mbonificacion_vetas
            End Get
        End Property

        Public Property descuento1()
            Set(ByVal value)
                mdescuento1 = Val(value)
            End Set
            Get
                Return mdescuento1
            End Get
        End Property

        Public Property descuento2()
            Set(ByVal value)
                mdescuento2 = Val(value)
            End Set
            Get
                Return mdescuento2
            End Get
        End Property

        Public Property descuento3()
            Set(ByVal value)
                mdescuento3 = Val(value)
            End Set
            Get
                Return mdescuento3
            End Get
        End Property

        Public Property flete()
            Set(ByVal value)
                mflete = Val(value)
            End Set
            Get
                Return mflete
            End Get
        End Property

        Public Property moneda()
            Set(ByVal value)
                mmoneda = value
            End Set
            Get
                Return mmoneda
            End Get
        End Property

        Public Property unidad_secundaria()
            Set(ByVal value)
                munidad_secundaria = value
            End Set
            Get
                Return munidad_secundaria
            End Get
        End Property

        Public Property peso_promedio()
            Set(ByVal value)
                mpeso_promedio = value
            End Set
            Get
                Return mpeso_promedio
            End Get
        End Property

        Public Property valor_moneda()
            Set(ByVal value)
                mvalormoneda = value
            End Set
            Get
                Return mvalormoneda
            End Get
        End Property

        Public Property pago_total()
            Set(ByVal value)
                mpagototal = Val(value)
            End Set
            Get
                Return mpagototal
            End Get
        End Property

        Public WriteOnly Property instruccion()
            Set(ByVal value)
                minstruccion = value
            End Set
        End Property

        Public Property iva()
            Set(ByVal value)
                If value = 0 Then
                    miva = 1
                    mexento = 1
                Else
                    miva = value
                    mexento = 0

                End If
            End Set
            Get
                Return miva
            End Get
        End Property

        Public Property impuestos_internos()
            Get
                Return mimpuestos_internos
            End Get
            Set(ByVal value)
                If value <> Nothing Then
                    mimpuestos_internos = value
                Else
                    mimpuestos_internos = 0
                End If
            End Set
        End Property

        Public Property codigo_impuestos_internos()
            Get
                Return mcod_imp
            End Get
            Set(ByVal value)
                If value <> Nothing Then
                    mcod_imp = value
                Else
                    mcod_imp = 0
                End If
            End Set
        End Property

        Public Property costo()
            Get
                Return mcosto
            End Get
            Set(ByVal value)
                mcosto = value
            End Set
        End Property

        Public Property uilidad()
            Set(ByVal value)
                mutilidad = value
            End Set
            Get
                Return mutilidad
            End Get
        End Property

        Public Property precio_siva()
            Get
                Return mprecio_siva
            End Get
            Set(ByVal value)
                mprecio_siva = value
            End Set
        End Property

        Public Property mueve_stok()
            Get
                Return mmueve_stok
            End Get
            Set(ByVal value)
                mmueve_stok = value
            End Set
        End Property

        Public Property precio_civa()
            Get
                Return mprecio_civa
            End Get
            Set(ByVal value)
                mprecio_civa = value
            End Set
        End Property

        Public Property nombre()
            Set(ByVal value)
                mnombre = value
            End Set
            Get
                Return mnombre
            End Get
        End Property

        Public Property codigo()
            Set(ByVal value)
                If value <> "" Then
                    mcodigo = value
                End If
            End Set
            Get
                Return mcodigo
            End Get
        End Property

        Public Property descripcion()
            Set(ByVal value)
                mdescripcion = value
            End Set
            Get
                Return mdescripcion
            End Get
        End Property

        Public Property codigo_rubro()
            Set(ByVal value)
                mcod_rubro = value
            End Set
            Get
                Return mcod_rubro
            End Get
        End Property

        Public Property nombre_rubro()
            Set(ByVal value)
                mnom_rubro = value
            End Set
            Get
                Return mnom_rubro
            End Get
        End Property

        Public Property codigo_barra()
            Set(ByVal value)
                mcod_barra = value
            End Set
            Get
                Return mcod_barra
            End Get
        End Property

        Public Property cantidad()
            Set(ByVal value)
                mcantidad = value
            End Set
            Get
                Return mcantidad
            End Get
        End Property

        Public Property cantidad_bulto()
            Set(ByVal value)
                mcant_bulto = value
            End Set
            Get
                Return mcant_bulto
            End Get
        End Property

        Public Property codigo_proveedor()
            Set(ByVal value)
                mcod_prov = value
            End Set
            Get
                Return mcod_prov
            End Get
        End Property

        Public Property nombre_proveedor()
            Set(ByVal value)
                mnom_prov = value
            End Set
            Get
                Return mnom_prov
            End Get
        End Property

        Public Property codigo_lista()
            Set(ByVal value)
                mid_lista = value
            End Set
            Get
                Return mid_lista
            End Get
        End Property

        Public Property nombre_lista()
            Set(ByVal value)
                mnom_lista = value
            End Set
            Get
                Return mnom_lista
            End Get
        End Property

        Public Property codigo_compras()
            Set(ByVal value)
                mid_compras = value
            End Set
            Get
                Return mid_compras
            End Get
        End Property

        Public Property nombre_compras()
            Set(ByVal value)
                mnom_compras = value
            End Set
            Get
                Return mnom_compras
            End Get
        End Property

        Public Property codigo_ventas()
            Set(ByVal value)
                mid_ventas = value
            End Set
            Get
                Return mid_ventas
            End Get
        End Property

        Public Property nombre_ventas()
            Set(ByVal value)
                mnom_ventas = value
            End Set
            Get
                Return mnom_ventas
            End Get
        End Property

        Public Property fecha_alta()
            Set(ByVal value)
                mfec_alta = value
            End Set
            Get
                Return mfec_alta
            End Get
        End Property

        Public Property fecha_modificacion()
            Set(ByVal value)
                mfec_mod = value
            End Set
            Get
                Return mfec_mod
            End Get
        End Property

        Public Property estado()
            Set(ByVal value)
                mestado = value
            End Set
            Get
                Return mestado
            End Get
        End Property

        Public Property verifica_campos()
            Get
                Return mverifica_campos
            End Get
            Set(ByVal value)
                mverifica_campos = value
            End Set
        End Property

        Public Property borra()
            Get
                Return mborra
            End Get
            Set(ByVal value)
                mborra = value
            End Set
        End Property

        Public Property exento()
            Get
                Return mexento
            End Get
            Set(ByVal value)
                mexento = value
            End Set
        End Property

        Public Property duplicado()
            Get
                Return mduplicado
            End Get
            Set(ByVal value)
                mduplicado = value
            End Set
        End Property

        Public Property instruccion_navegador()
            Get
                Return mnavegador
            End Get
            Set(ByVal value)
                mnavegador = value
            End Set
        End Property

        Public Property formulario()
            Get
                Return mform
            End Get
            Set(ByVal value)
                mform = value
            End Set
        End Property

        Public Property codigo_tabla_navegador()
            Get
                Return mcodigo_tabla
            End Get
            Set(ByVal value)
                mcodigo_tabla = value
            End Set

        End Property

        Public Property codigo_1()
            Get
                Return x
            End Get
            Set(ByVal value)
                x = value
            End Set
        End Property

        Public Property codigo_2()
            Get
                Return xx
            End Get
            Set(ByVal value)
                xx = value
            End Set
        End Property

        Public Property codigo_3()
            Get
                Return xxx
            End Get
            Set(ByVal value)
                xxx = value
            End Set
        End Property

        Public Property codigo_4()
            Get
                Return xxxx
            End Get
            Set(ByVal value)
                xxxx = value
            End Set
        End Property

        Public Property codigo_5()
            Get
                Return xxxxx
            End Get
            Set(ByVal value)
                xxxxx = value
            End Set
        End Property

        Public Property codigo_6()
            Get
                Return xxxxxx
            End Get
            Set(ByVal value)
                xxxxxx = value
            End Set
        End Property

        Public Property codigo_7()
            Get
                Return xxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxx = value
            End Set
        End Property

        Public Property codigo_8()
            Get
                Return xxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxx = value
            End Set
        End Property

        Public Property codigo_9()
            Get
                Return xxxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxxx = value
            End Set
        End Property

        Public Property codigo_10()
            Get
                Return xxxxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxxxx = value
            End Set
        End Property

        Public Property codigo_11()
            Get
                Return xxxxxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxxxxx = value
            End Set
        End Property

        Public Property codigo_12()
            Get
                Return xxxxxxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxxxxxx = value
            End Set
        End Property

        Public Property codigo_13()
            Get
                Return xxxxxxxxxxxxx
            End Get
            Set(ByVal value)
                xxxxxxxxxxxxx = value
            End Set
        End Property

        Public Property codigo_14()
            Get
                Return z
            End Get
            Set(ByVal value)
                z = value
            End Set
        End Property

        Public Property codigo_15()
            Get
                Return zz
            End Get
            Set(ByVal value)
                zz = value
            End Set
        End Property

        Public Property codigo_16()
            Get
                Return zzz
            End Get
            Set(ByVal value)
                zzz = value
            End Set
        End Property

        Public Property codigo_17()
            Get
                Return zzzz
            End Get
            Set(ByVal value)
                zzzz = value
            End Set
        End Property

        Public Property codigo_18()
            Get
                Return zzzz1
            End Get
            Set(ByVal value)
                zzzz1 = value
            End Set
        End Property

        Public Property codigo_19()
            Get
                Return zzzz2
            End Get
            Set(ByVal value)
                zzzz2 = value
            End Set
        End Property

        Public Property codigo_20()
            Get
                Return zzzz3
            End Get
            Set(ByVal value)
                zzzz3 = value
            End Set
        End Property

        Public Property valida()
            Get
                Return mvalida
            End Get
            Set(ByVal value)
                mvalida = value
            End Set
        End Property

        Public Property stok()
            Get
                Return mstok
            End Get
            Set(ByVal value)
                mstok = value
            End Set
        End Property

        Public Property iva_insc()
            Get
                Return miva_insc
            End Get
            Set(ByVal value)
                miva_insc = value
            End Set
        End Property

        Public Property codigo_iva()
            Get
                Return mcodigo_iva
            End Get
            Set(ByVal value)
                mcodigo_iva = value
            End Set
        End Property

        Public Property proveedor()
            Get
                Return mprov
            End Get
            Set(ByVal value)
                mprov = value
            End Set
        End Property

        Public Property rubro()
            Get
                Return mrub
            End Get
            Set(ByVal value)
                mrub = value
            End Set
        End Property


        Public Sub guardar()

            Try

                Dim insertar As New SqlCommand(minstruccion, conex)
                If conex.State = ConnectionState.Closed Then conex.Open()

                insertar.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub calcular_precio_final()

            Dim p_siva As Double = 0

            ' calcula descuentos, fletes, y demas si es distinto a exento

            If mexento = 0 Then

                p_siva = calcula_descuentos_total(Me.mcosto, Me.mprecio_siva, Me.mdescuento1, Me.mdescuento2, Me.mdescuento3, Me.mflete, Me.mpagototal)

                ' si entro a algun opcion de descuento calcula en base a eso sino lo hace normal

                If descuentos = False Then

                    Me.precio_siva = (Me.mcosto * Me.uilidad) / 100 + Me.mcosto
                    Me.precio_civa = (Me.precio_siva * Me.iva) / 100 + Me.precio_siva + Me.impuestos_internos
                    Me.mueve_stok = Me.costo / Me.precio_civa
                    Me.iva_insc = Format((Me.precio_siva * Me.iva) / 100, "0.00")

                Else

                    Me.precio_siva = (p_siva * Me.uilidad) / 100 + p_siva
                    Me.precio_civa = (Me.precio_siva * Me.iva) / 100 + Me.precio_siva + Me.impuestos_internos
                    Me.mueve_stok = Me.costo / Me.precio_civa
                    Me.iva_insc = Format((Me.precio_siva * Me.iva) / 100, "0.00")

                End If

            Else

                ' hace lo mismo que para un exento de iva

                p_siva = calcula_descuentos_total(Me.mcosto, Me.mprecio_siva, Me.mdescuento1, Me.mdescuento2, Me.mdescuento3, Me.mflete, Me.mpagototal)

                If descuentos = True Then

                    Me.precio_siva = Format((p_siva * Me.uilidad) / 100 + p_siva + Me.mimpuestos_internos, "0.000")
                    Me.precio_civa = Me.precio_siva
                    Me.mueve_stok = Me.costo / Me.precio_civa

                Else

                    Me.precio_siva = Format((p_siva * Me.uilidad) / 100 + p_siva + Me.mimpuestos_internos, "0.000")
                    Me.precio_civa = Me.precio_siva
                    Me.mueve_stok = Me.costo / Me.precio_civa

                End If

            End If

            descuentos = False

        End Sub

        Public Function calcula_descuentos_total(ByVal costo As Double, ByVal psiva As Double, ByVal desc1 As Double, ByVal desc2 As Double, ByVal desc3 As Double, ByVal flete As Double, ByVal pago_total As Double) As Double

            psiva = costo

            If desc1 <> 0 Then

                psiva = costo - (costo * desc1) / 100
                descuentos = True

            End If

            If desc2 <> 0 Then

                If descuentos = False Then
                    psiva = costo - (costo * desc2) / 100
                Else
                    psiva = psiva - (psiva * desc2) / 100
                End If

                descuentos = True

            End If

            If desc3 <> 0 Then

                If descuentos = False Then
                    psiva = costo - (costo * desc3) / 100
                Else
                    psiva = psiva - (psiva * desc3) / 100
                End If

                descuentos = True

            End If

            If flete <> 0 Then

                If descuentos = False Then
                    psiva = costo + (costo * flete) / 100
                Else
                    psiva = psiva + (psiva * flete) / 100
                End If

                descuentos = True

            End If

            If pago_total <> 0 Then

                If descuentos = False Then
                    psiva = costo - (costo * pago_total) / 100
                Else
                    psiva = psiva - (psiva * pago_total) / 100
                End If

                descuentos = True

            End If

            Return psiva

        End Function

        Public Sub calcular_precio_final_monotributo()

            Dim p_siva As Double = 0

            p_siva = calcula_descuentos_total(Me.mcosto, Me.mprecio_siva, Me.mdescuento1, Me.mdescuento2, Me.mdescuento3, Me.mflete, Me.mpagototal)

            If descuentos = True Then

                Me.precio_civa = Format((p_siva * Me.uilidad) / 100 + p_siva + Me.impuestos_internos, "0.000")
                Me.precio_siva = Me.precio_civa

            Else

                Me.precio_civa = Format((Me.mcosto * Me.uilidad) / 100 + Me.mcosto + Me.impuestos_internos, "0.000")
                Me.precio_siva = Me.precio_civa

            End If

        End Sub

        Public Sub verificar_duplicado()

            Try

                Dim comando As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader

                reader.Read()

                If RTrim(reader(mnombre)) = mcodigo Then

                    MsgBox("El numero esta en uso", MsgBoxStyle.Information, "PymSoft")
                    mduplicado = True
                    Exit Sub

                End If

                comando.Dispose()

            Catch ex As Exception

                mduplicado = False

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub mostrar_datos()
            Try

                conex = conecta()
                Dim comando As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader

                reader.Read()

                mcodigo = reader("id_art1")
                mdescripcion = reader("nombre")
                mcod_rubro = reader("id_rubro")
                mnom_rubro = reader("rubro")
                mcod_barra = reader("codigo_barra")
                mcantidad = reader("cantidad")
                mcant_bulto = reader("cantidad_bulto")
                mcosto = reader("costo")
                miva = reader("iva")
                mcodigo_iva = reader("id_iva")
                mimpuestos_internos = reader("impuestos")
                mcod_imp = reader("cod_imp")
                mcod_prov = reader("id_proveedor")
                mnom_prov = reader("proveedor")
                mid_lista = reader("id_lista1")
                mnom_lista = reader("lista")
                mutilidad = reader("utilidad")
                mprecio_siva = reader("precio_siva")
                mprecio_civa = reader("precio_civa")
                mmueve_stok = reader("mueve_stok")
                mid_compras = reader("cod_imp_compras")
                mnom_compras = reader("nom_imp_compras")
                mid_ventas = reader("cod_imp_ventas")
                mnom_ventas = reader("nom_imp_ventas")
                mfec_alta = reader("fec_alta")
                mfec_mod = reader("fec_modi")
                mestado = reader("estado")
                mdescuento1 = reader("desc1")
                mdescuento2 = reader("desc2")
                mdescuento3 = Val(reader("desc3"))
                mflete = Val(reader("flete"))
                mpagototal = Val(reader("pago_total"))
                mmoneda = reader("moneda")
                mvalormoneda = reader("valor_moneda")
                munidad_secundaria = reader("unidad_secundaria")
                mpeso_promedio = reader("peso_promedio")
                mbonificacion_vetas = reader("bonif_vta")

                reader.Close()
                mverifica_campos = 0

            Catch ex As Exception

                Call limpiar2()
                mverifica_campos = 1


            Finally

                conex.Close()

            End Try

        End Sub

        Private Sub limpiar2()

            Form_articulos.txt_cantidad.Text = ""
            Form_articulos.txt_cantidad_bulto.Text = ""
            Form_articulos.txt_codigo_barra.Text = ""
            Form_articulos.txt_costo.Text = ""
            Form_articulos.txt_impuestos_internos.Text = ""
            Form_articulos.txt_inputacion_compras.Text = ""
            Form_articulos.txt_inputacion_ventas.Text = ""
            Form_articulos.txt_precio_siva.Text = ""
            Form_articulos.txt_nombre.Text = ""
            Form_articulos.txt_precio_civa.Text = ""
            Form_articulos.txt_proveedor.Text = ""
            Form_articulos.txt_rubro.Text = ""
            Form_articulos.txt_utilidad.Text = ""
            Form_articulos.lbl_input_compras.Text = ""
            Form_articulos.lbl_nom_imp_int.Text = ""
            Form_articulos.lbl_input_ventas.Text = ""
            Form_articulos.lbl_proveedor.Text = ""
            Form_articulos.lbl_rubro.Text = ""
            Form_articulos.lbl_tipo_iva.Text = ""
            Form_articulos.txt_codigo_iva.Text = ""
            Form_articulos.txt_descuento1.Text = ""
            Form_articulos.txt_descuento2.Text = ""
            Form_articulos.txt_descuento3.Text = ""
            Form_articulos.txt_flete.Text = ""
            Form_articulos.txt_pago_total.Text = ""
            Form_articulos.txt_peso_promedio.Text = 0
            Form_articulos.txt_bonif_ventas.Text = ""

        End Sub

        Public Sub borrar()

            Try

                Dim deletin As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                deletin.ExecuteNonQuery()


            Catch ex As Exception


            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub actualizar()

            Try

                conex = conecta()
                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                Insercion.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub buscar(ByVal lista As Integer)

            Try

                Dim midataset As New DataSet

                conex = conecta()

                'If busc_articulos.opt_texto.Checked = True Then
                Dim comando1 As New SqlDataAdapter("select id_art1,nombre,cantidad,precio_civa from art_01 inner join art_precio on (art_precio.nom like '%" & RTrim(busc_articulos.txt_articulos.Text) & "%' or art_precio.id_art1 like '" & RTrim(busc_articulos.txt_articulos.Text) & "%') and art_precio.id_lista1 = '" & lista & "' and art_precio.nom = art_01.nombre and art_precio.id_art1 = art_01.id_art and art_01.estado='Activo' order by nombre ASC ", conex)
                comando1.Fill(midataset, "art_01")
                comando1.Dispose()
                'End If

                'If busc_articulos.opt_codigo.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_precio.id_art1 like '" & RTrim(busc_articulos.txt_articulos.Text) & "%' and art_precio.id_lista1 = '" & lista & "' and art_precio.id_art1 = art_01.id_art and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by id_art ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_proveedor.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.proveedor like '" & RTrim(busc_articulos.txt_articulos.Text) & "%' and art_precio.id_lista1 = '" & lista & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.proveedor ASC ", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_rubro.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.rubro like '" & RTrim(busc_articulos.txt_articulos.Text) & "%' and art_precio.id_lista1 = '" & lista & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.rubro ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_escanner.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.codigo_barra like '" & RTrim(busc_articulos.txt_articulos.Text) & "%' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.codigo_barra ASC ", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                busc_articulos.DataGridView1.DataSource = midataset.Tables("art_01")

                busc_articulos.DataGridView1.Columns(0).Width = 140
                busc_articulos.DataGridView1.Columns(1).Width = 370
                busc_articulos.DataGridView1.Columns(2).Width = 100
                busc_articulos.DataGridView1.Columns(3).Width = 100

                busc_articulos.DataGridView1.Columns(0).HeaderText = "Codigo"
                busc_articulos.DataGridView1.Columns(1).HeaderText = "Descripcion"
                busc_articulos.DataGridView1.Columns(2).HeaderText = "Stock"
                busc_articulos.DataGridView1.Columns(3).HeaderText = "Precio c/iva"
                midataset.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try


        End Sub

        Public Sub cargar()

            Try

                conex = conecta()

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                mcodigo = reader(x)
                mnombre = reader(xx)
                mprecio_siva = reader(xxx)
                mcantidad = reader(xxxx)
                mcant_bulto = reader(xxxxx)
                mmueve_stok = reader(xxxxxx)
                mprecio_civa = reader(xxxxxxx)
                miva_insc = reader(xxxxxxxx)
                mimpuestos_internos = reader(xxxxxxxxx)
                miva = reader(xxxxxxxxxx)
                mexento = reader(xxxxxxxxxxx)
                mcosto = reader(xxxxxxxxxxxx)
                mcod_barra = reader(xxxxxxxxxxxxx)
                mcodigo_iva = reader(z)
                mutilidad = reader(zz)
                mprov = reader(zzz)
                mrub = reader(zzzz)
                munidad_secundaria = reader(zzzz1)
                mpeso_promedio = reader(zzzz2)
                mbonificacion_vetas = reader(zzzz3)

                mvalida = True

                reader.Close()

            Catch ex As Exception

                mvalida = False

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub descuenta_stock()

            Try

                conex = conecta()

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                Insercion.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub carga_preventa()

            Try

                conex = conecta()

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                mcantidad = reader("cantidad")
                mmueve_stok = reader("mueve_stok")
                mcodigo_iva = reader("id_iva")
                miva = reader("iva")

                reader.Close()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub buscar_ultima_busqueda(ByVal lista)

            Try

                Dim midataset As New DataSet

                conex = conecta()

                'If busc_articulos.opt_texto.Checked = True Then
                Dim comando1 As New SqlDataAdapter("select id_art1,nombre,cantidad,precio_civa from art_01 inner join art_precio on (art_precio.nom like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%' or art_precio.id_art1 like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%') and art_precio.id_lista1 = '" & lista & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.nombre ASC", conex)
                comando1.Fill(midataset, "art_01")
                comando1.Dispose()
                'End If

                'If busc_articulos.opt_codigo.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_precio.id_art1 like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.nombre ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_proveedor.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.proveedor like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.nombre ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_rubro.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.rubro like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.nombre ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                'If busc_articulos.opt_escanner.Checked = True Then
                'Dim comando1 As New SqlDataAdapter("select id_art,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.codigo_barra like '" & RTrim(form_factura.txt_ultima_busqueda.Text) & "%' and art_precio.id_lista1 = '" & form_factura.txt_cod_lista.Text & "' and art_precio.nom = art_01.nombre and art_01.estado='Activo' order by art_01.nombre ASC", conex)
                'comando1.Fill(midataset, "art_01")
                'End If

                busc_articulos.DataGridView1.DataSource = midataset.Tables("art_01")

                busc_articulos.DataGridView1.Columns(0).Width = 140
                busc_articulos.DataGridView1.Columns(1).Width = 370
                busc_articulos.DataGridView1.Columns(2).Width = 100
                busc_articulos.DataGridView1.Columns(3).Width = 100

                busc_articulos.DataGridView1.Columns(0).HeaderText = "Codigo"
                busc_articulos.DataGridView1.Columns(1).HeaderText = "Descripcion"
                busc_articulos.DataGridView1.Columns(2).HeaderText = "Stock"
                busc_articulos.DataGridView1.Columns(3).HeaderText = "Precio c/iva"
                midataset.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

    End Class

End Namespace
