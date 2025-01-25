Imports System.Data.SqlClient
Imports System.Data
Imports OCXFISLib

Namespace pymsoft

    Public Class factura

        Dim conex As New SqlConnection
        Dim comando1 As SqlDataAdapter
        Dim comando As SqlCommand
        Dim midataset As New DataSet
        Dim eps As OCXFISLib.DriverFiscal
        Dim nError As Long
        Dim sub_cadena As String, lfe As String, tce As String
        Dim puerto As String
        Dim baude As Integer

        Dim reporte As New pymsoft.reporte
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

        Private des, descuento As String
        Private cant, monto, imp, ivas, p_civa As Double
        Private i As Integer

        Private mgrilla As Object
        Private mfila As Integer
        Private mcodigo_fact As String
        Private mnombre As String
        Private mcantidad As Double
        Private mprecio As Single
        Private mprecio_final As Single
        Private mrec_des As String
        Private mtotal As Single
        Private sub_total, desc As Single
        Private mstok As Single
        Private mimpuesto As Single
        Private mfila1 As Integer
        Private minstruccion As String
        Private miva As String
        Private mexento As Single
        Private msale As Boolean
        Private mcant_item_factuta As Short
        Private mmuestra_tipo_pago As String
        Private mmuestra_fecha_emi As String
        Private mmuestra_fecha_vto As String
        Private mmuestra_marcador_total As String
        Private mhabilita_descuento As String
        Private mvalida_rentabilidad As String
        Private mimporte_rentabilidad As Short
        Private mcantidad_copias As Short
        Private mprecio_civa As Single
        Private mprefijo_fact As String
        Private mnumero_fact As String
        Private mcosto As Single
        Private mhab_imp_fact As String
        Private mhab_imp_rem As String
        Private mvendedor As String
        Private mmueve_stock As String
        Private mform_txt_letra As String
        Private mform_txt As String
        Private mletra_fact As String
        Private mtipo_fact As String
        Private mpide_precio As String
        Private mlong_cod_barra As Integer
        Private mlista_pre As Integer
        Private mbaude_rate As Integer
        Private mCom As Integer
        Private mdetecta_modelo As String
        Private mimprime_fact As String
        Private mimprime_tic As String
        Private mcopia_fiscal As Integer
        Private mhabilita_com As String
        Private mhabilita_tcp As String
        Private mdir_ip As String
        Private mtalonario_pre As Integer
        Private mforma_cobro As String
        Private mpide_talonario_factura As String
        Private mpide_num_recibo As String
        Private mpide_pre_recibo As String
        Private mpide_lista As String
        Private mcantidad_automatica As String
        Private mmuestra_cuadro_impresion As String
        Private msale_factura As Integer
        Private mpunto_venta As Integer
        Private mfiscal_hasar As String
        Private mfiscal_epson As String
        Private mfacturac As String
        Private mcant_sin_stock As String
        Private mimprime_en_fiscal As String
        Private mprov As Integer
        Private mrub As Integer
        Private mvendedor_defecto As Integer
        Private mvendedor_recibo As String
        Private mutilidad_art As String
        Private mcosto_remito As String
        Private mopcion_comprobante
        Private mcliente_fijo As Integer
        Private msi_o_no As String
        Private mcondicion_vta As Integer
        Private mhabilita_consulta_mixta As String
        Private mn_carga As String
        Private mcopias_impresora_comun As String
        Private mventana_imprime_factura As String
        Private mfactura_electronica As String
        Private mhabilita_descuento_gral As String
        Private mhabilita_facturacion_especial As String
        Private mgraba_afip As String
        Private mact_pre_en_fact As String
        Private mcodiva As Integer
        Private munidad_medida As String
        Private mvalor_unidad_medida As Single

        Public Property valor_unidad_medida()
            Get
                Return mvalor_unidad_medida
            End Get
            Set(ByVal value)
                mvalor_unidad_medida = Val(value)
            End Set
        End Property

        Public Property unidad_medida()
            Get
                Return munidad_medida
            End Get
            Set(ByVal value)
                munidad_medida = value
            End Set
        End Property

        Public Property Habilita_facturacion_especial()
            Get
                Return mhabilita_facturacion_especial
            End Get
            Set(ByVal value)
                mhabilita_facturacion_especial = value
            End Set
        End Property

        Public Property Habilita_descuento_gral()
            Get
                Return mhabilita_descuento_gral
            End Get
            Set(ByVal value)
                mhabilita_descuento_gral = value
            End Set
        End Property

        Public Property Codigo_iva()
            Get
                Return mcodiva
            End Get
            Set(ByVal value)
                mcodiva = value
            End Set
        End Property

        Public Property Actualiza_precio_en_factura()
            Get
                Return mact_pre_en_fact
            End Get
            Set(ByVal value)
                mact_pre_en_fact = value
            End Set
        End Property

        Public Property Graba_AFIP()
            Get
                Return mgraba_afip
            End Get
            Set(ByVal value)
                mgraba_afip = value
            End Set
        End Property

        Public Property Factura_electronica_AFIP()
            Get
                Return mfactura_electronica
            End Get
            Set(ByVal value)
                mfactura_electronica = value
            End Set
        End Property


        Public Property ventana_imprime_factura()
            Get
                Return mventana_imprime_factura
            End Get
            Set(ByVal value)
                mventana_imprime_factura = value
            End Set
        End Property

        Public Property pide_n_carga()
            Get
                Return mn_carga
            End Get
            Set(ByVal value)
                mn_carga = value
            End Set
        End Property

        Public Property habilita_consulta_mixta()
            Get
                Return mhabilita_consulta_mixta
            End Get
            Set(ByVal value)
                mhabilita_consulta_mixta = value
            End Set
        End Property

        Public Property condicion_venta()
            Get
                Return mcondicion_vta
            End Get
            Set(ByVal value)
                mcondicion_vta = value
            End Set
        End Property

        Public Property cliente_fijo()
            Get
                Return mcliente_fijo
            End Get
            Set(ByVal value)
                mcliente_fijo = value
            End Set
        End Property

        Public Property si_o_no_factura()
            Get
                Return msi_o_no
            End Get
            Set(ByVal value)
                msi_o_no = value
            End Set
        End Property

        Public Property opcion_comprobante()
            Get
                Return mopcion_comprobante
            End Get
            Set(ByVal value)
                mopcion_comprobante = value
            End Set
        End Property

        Public Property muestra_costo_remito()
            Get
                Return mcosto_remito
            End Get
            Set(ByVal value)
                mcosto_remito = value
            End Set
        End Property

        Public Property usa_utilidad_en_articulo()
            Get
                Return mutilidad_art
            End Get
            Set(ByVal value)
                mutilidad_art = value
            End Set
        End Property

        Public Property pide_vendedor_recibo()
            Get
                Return mvendedor_recibo
            End Get
            Set(ByVal value)
                mvendedor_recibo = value
            End Set
        End Property

        Public Property vendedor_x_defecto()
            Get
                Return mvendedor_defecto
            End Get
            Set(ByVal value)
                mvendedor_defecto = value
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

        Public Property Imprime_en_fiscal()
            Get
                Return mimprime_en_fiscal
            End Get
            Set(ByVal value)
                mimprime_en_fiscal = value
            End Set
        End Property

        Public Property cantidad_sin_stock()
            Get
                Return mcant_sin_stock
            End Get
            Set(ByVal value)
                mcant_sin_stock = value
            End Set
        End Property

        Public Property factura_en_c()
            Get
                Return mfacturac
            End Get
            Set(ByVal value)
                mfacturac = value
            End Set
        End Property


        Public Property fiscal_epson()
            Get
                Return mfiscal_epson
            End Get
            Set(ByVal value)
                mfiscal_epson = value
            End Set
        End Property

        Public Property fiscal_hasar()
            Get
                Return mfiscal_hasar
            End Get
            Set(ByVal value)
                mfiscal_hasar = value
            End Set
        End Property

        Public Property punto_venta()
            Get
                Return mpunto_venta
            End Get
            Set(ByVal value)
                mpunto_venta = value
            End Set
        End Property

        Public Property sale_factura()
            Get
                Return msale_factura
            End Get
            Set(ByVal value)
                msale_factura = value
            End Set
        End Property

        Public Property muestra_cuadro_impresion()
            Get
                Return mmuestra_cuadro_impresion
            End Get
            Set(ByVal value)
                mmuestra_cuadro_impresion = value
            End Set
        End Property

        Public Property cantidad_automatica()
            Get
                Return mcantidad_automatica
            End Get
            Set(ByVal value)
                mcantidad_automatica = value
            End Set
        End Property

        Public Property Pide_lista()
            Get
                Return mpide_lista
            End Get
            Set(ByVal value)
                mpide_lista = value
            End Set
        End Property

        Public Property Pide_prefijo_recibo()
            Get
                Return mpide_pre_recibo
            End Get
            Set(ByVal value)
                mpide_pre_recibo = value
            End Set
        End Property

        Public Property Pide_numero_recibo()
            Get
                Return mpide_num_recibo
            End Get
            Set(ByVal value)
                mpide_num_recibo = value
            End Set
        End Property

        Public Property Pide_talonario_factura()
            Get
                Return mpide_talonario_factura
            End Get
            Set(ByVal value)
                mpide_talonario_factura = value
            End Set
        End Property

        Public Property forma_cobro()
            Get
                Return mforma_cobro
            End Get
            Set(ByVal value)
                mforma_cobro = value
            End Set
        End Property

        Public Property Talonario_predeterminado()
            Get
                Return mtalonario_pre
            End Get
            Set(ByVal value)
                mtalonario_pre = value
            End Set
        End Property

        Public Property Direccion_Ip()
            Get
                Return mdir_ip
            End Get
            Set(ByVal value)
                mdir_ip = value
            End Set
        End Property

        Public Property habilita_tcp()
            Get
                Return mhabilita_tcp
            End Get
            Set(ByVal value)
                mhabilita_tcp = value
            End Set
        End Property

        Public Property habilita_puerto_com()
            Get
                Return mhabilita_com
            End Get
            Set(ByVal value)
                mhabilita_com = value
            End Set
        End Property

        Public Property copias_fiscales()
            Get
                Return mcopia_fiscal
            End Get
            Set(ByVal value)
                mcopia_fiscal = value
            End Set
        End Property

        Public Property imprime_tikets()
            Get
                Return mimprime_tic
            End Get
            Set(ByVal value)
                mimprime_tic = value
            End Set
        End Property

        Public Property imprime_factura()
            Get
                Return mimprime_fact
            End Get
            Set(ByVal value)
                mimprime_fact = value
            End Set
        End Property

        Public Property detecta_modelo()
            Get
                Return mdetecta_modelo
            End Get
            Set(ByVal value)
                mdetecta_modelo = value
            End Set
        End Property

        Public Property Puerto_Com()
            Get
                Return mCom
            End Get
            Set(ByVal value)
                mCom = value
            End Set
        End Property

        Public Property baude_rate()
            Get
                Return mbaude_rate
            End Get
            Set(ByVal value)
                mbaude_rate = value
            End Set
        End Property


        Public Property lista_predeterminada()
            Get
                Return mlista_pre
            End Get
            Set(ByVal value)
                mlista_pre = value
            End Set
        End Property

        Public Property longitud_codigo_barra()
            Get
                Return mlong_cod_barra
            End Get
            Set(ByVal value)
                mlong_cod_barra = value
            End Set
        End Property

        Public Property habilita_impresion_remito()
            Get
                Return mhab_imp_rem
            End Get
            Set(ByVal value)
                mhab_imp_rem = value
            End Set
        End Property

        Public Property pide_precio()
            Get
                Return mpide_precio
            End Get
            Set(ByVal value)
                mpide_precio = value
            End Set
        End Property

        Public Property letra_fact()
            Get
                Return mletra_fact
            End Get
            Set(ByVal value)
                mletra_fact = value
            End Set
        End Property

        Public Property tipo_fact()
            Get
                Return mtipo_fact
            End Get
            Set(ByVal value)
                mtipo_fact = value
            End Set
        End Property

        Public Property form_txt()
            Get
                Return mform_txt
            End Get
            Set(ByVal value)
                mform_txt = value
            End Set
        End Property

        Public Property form_txt_letra()
            Get
                Return mform_txt_letra
            End Get
            Set(ByVal value)
                mform_txt_letra = value
            End Set
        End Property

        Public Property mueve_stock()
            Get
                Return mmueve_stock
            End Get
            Set(ByVal value)
                mmueve_stock = value
            End Set
        End Property

        Public Property habilita_vendedor()
            Get
                Return mvendedor
            End Get
            Set(ByVal value)
                mvendedor = value
            End Set
        End Property

        Public Property habilita_impresora_factura()
            Get
                Return mhab_imp_fact
            End Get
            Set(ByVal value)
                mhab_imp_fact = value
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

        Public Property prefijo_factura()
            Get
                Return mprefijo_fact
            End Get
            Set(ByVal value)
                mprefijo_fact = value
            End Set
        End Property

        Public Property numero_factura()
            Get
                Return mnumero_fact
            End Get
            Set(ByVal value)
                mnumero_fact = value
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

        Public Property cantidad_copias()
            Get
                Return mcantidad_copias
            End Get
            Set(ByVal value)
                mcantidad_copias = value
            End Set
        End Property

        Public Property importe_rentabilidad()
            Get
                Return mimporte_rentabilidad
            End Get
            Set(ByVal value)
                mimporte_rentabilidad = value
            End Set
        End Property

        Public Property valida_rentabilidad()
            Get
                Return mvalida_rentabilidad
            End Get
            Set(ByVal value)
                mvalida_rentabilidad = value
            End Set
        End Property

        Public Property habilita_descuento()
            Get
                Return mhabilita_descuento
            End Get
            Set(ByVal value)
                mhabilita_descuento = value
            End Set
        End Property

        Public Property cantidad_item_factura()
            Get
                Return mcant_item_factuta
            End Get
            Set(ByVal value)
                mcant_item_factuta = value
            End Set
        End Property

        Public Property muestra_tipo_pago()
            Get
                Return mmuestra_tipo_pago
            End Get
            Set(ByVal value)
                mmuestra_tipo_pago = value
            End Set
        End Property

        Public Property muestra_fecha_emi()
            Get
                Return mmuestra_fecha_emi
            End Get
            Set(ByVal value)
                mmuestra_fecha_emi = value
            End Set
        End Property

        Public Property muestra_fecha_vto()
            Get
                Return mmuestra_fecha_vto
            End Get
            Set(ByVal value)
                mmuestra_fecha_vto = value
            End Set
        End Property

        Public Property muestra_marcador_total()
            Get
                Return mmuestra_marcador_total
            End Get
            Set(ByVal value)
                mmuestra_marcador_total = value
            End Set
        End Property

        Public Sub carga_parametro()

            Dim param As String = ""

            comando = New SqlCommand("select * from menu_usu where usuario = '" & Trim(Form_login.cmb_usuario.Text) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando.ExecuteReader
            comando.Dispose()

            While reader.Read()

                param = reader("parametro")

            End While

            conex.Close()

            Dim i As Integer

            comando1 = New SqlDataAdapter("select cod_pra,id_parametro,descripcion,nom_param,estado,cod_interno from parametro_01 where id_parametro like '" + param + "'", conex)
            comando1.Fill(midataset, "parametro_01")
            comando1.Dispose()

            If midataset.Tables("parametro_01").Rows.Count = 0 Then
                MessageBox.Show("Falta Parametros para este usuario", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Form_login.Dispose()
            End If

            For i = 0 To midataset.Tables("parametro_01").Rows.Count - 1

                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "CANTIDAD DETALLE" Then Me.cantidad_item_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE TIPO PAGO" Then Me.muestra_tipo_pago = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE PREFIJO FACTURA" Then Me.prefijo_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE NUMERO FACTURA" Then Me.numero_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE FECHA EMISION" Then Me.muestra_fecha_emi = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE FECHA VENCIMIENTO" Then Me.muestra_fecha_vto = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE MARCADOR IMPORTE" Then Me.muestra_marcador_total = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "VALIDA RENTABILIDAD" Then Me.valida_rentabilidad = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "RENTABILIDAD MINIMA" Then Me.importe_rentabilidad = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE DESCUENTO" Then Me.habilita_descuento = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE VENDEDOR" Then Me.habilita_vendedor = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA IMPRESION FACTURA" Then Me.habilita_impresora_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE PRECIO" Then Me.pide_precio = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA IMPRESION REMITO" Then Me.habilita_impresion_remito = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "LONGITUD CODIGO BARRA" Then Me.longitud_codigo_barra = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "LISTA PREDETERMINADA" Then Me.lista_predeterminada = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "MUEVE STOCK" Then Me.mueve_stock = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "BAUDE RATE" Then Me.baude_rate = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "COM" Then Me.Puerto_Com = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "IMPRIME TICKET" Then Me.imprime_tikets = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "IMPRIME FACTURA" Then Me.imprime_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "AUTO DETECTA MODELO" Then Me.detecta_modelo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "CANTIDAD COPIAS FISCALES" Then Me.copias_fiscales = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA PUERTO COM" Then Me.habilita_puerto_com = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA TCP/IP" Then Me.habilita_tcp = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "DIRECCION IP" Then Me.Direccion_Ip = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "TALONARIO PREDETERMINADO" Then Me.Talonario_predeterminado = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE FORMA COBRO" Then Me.forma_cobro = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE TALONARIO" Then Me.Pide_talonario_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE PREFIJO RECIBO" Then Me.Pide_prefijo_recibo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE NUMERO RECIBO" Then Me.Pide_numero_recibo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE LISTA" Then Me.Pide_lista = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "CANTIDAD AUTOMATICA" Then Me.cantidad_automatica = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "MUESTRA CUADRO IMPRESION" Then Me.muestra_cuadro_impresion = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PUNTO VENTA" Then Me.punto_venta = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "FISCAL HASAR" Then Me.fiscal_hasar = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "FISCAL EPSON" Then Me.fiscal_epson = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "FACTURA EN C" Then Me.factura_en_c = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "IMPRIME EN FISCAL" Then Me.Imprime_en_fiscal = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "VENDEDOR" Then Me.vendedor_x_defecto = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE VENDEDOR RECIBO" Then Me.pide_vendedor_recibo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "USA UTILIDAD ARTICULO" Then Me.usa_utilidad_en_articulo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "MUESTRA COSTO REMITO" Then Me.muestra_costo_remito = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE OPCION COMPROBANTE" Then Me.opcion_comprobante = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "CLIENTE FIJO" Then Me.cliente_fijo = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "SI O NO EN FACTURA" Then Me.si_o_no_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "CONDICION DE VENTA(1-CONTADO,2-CTA CTE)" Then Me.condicion_venta = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA CONSULTA MIXTA" Then Me.habilita_consulta_mixta = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "PIDE Nº CARGA" Then Me.pide_n_carga = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "COPIAS INPRESORA COMUN" Then Me.copias_impresora_comun = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "VENTANA IMPRIME FACTURA" Then Me.ventana_imprime_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "FACTURA ELECTRONICA AFIP" Then Me.Factura_electronica_AFIP = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "GRABA AFIP" Then Me.Graba_AFIP = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "ACTUALIZA PRECIO EN FACTURA" Then Me.Actualiza_precio_en_factura = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA DESCUENTO GRAL" Then Me.Habilita_descuento_gral = midataset.Tables("parametro_01").Rows(i).Item(4)
                If RTrim(midataset.Tables("parametro_01").Rows(i).Item(3)) = "HABILITA ESPECIAL" Then Me.Habilita_facturacion_especial = midataset.Tables("parametro_01").Rows(i).Item(4)

            Next

        End Sub

        Public Property copias_impresora_comun()
            Get
                Return mcopias_impresora_comun
            End Get
            Set(ByVal value)
                mcopias_impresora_comun = value
            End Set
        End Property

        Public Property grilla()
            Get
                Return mgrilla
            End Get
            Set(ByVal value)
                mgrilla = value
            End Set
        End Property

        Public Property fila()
            Get
                Return mfila
            End Get
            Set(ByVal value)
                mfila = value
            End Set
        End Property

        Public Property codigo_fact()
            Get
                Return mcodigo_fact
            End Get
            Set(ByVal value)
                mcodigo_fact = value
            End Set
        End Property

        Public Property nombre()
            Get
                Return mnombre
            End Get
            Set(ByVal value)
                mnombre = value
            End Set
        End Property

        Public Property cantidad()
            Get
                Return mcantidad
            End Get
            Set(ByVal value)
                mcantidad = value
            End Set
        End Property

        Public Property modifica_grilla_factura()
            Get
                Return mfila1
            End Get
            Set(ByVal value)
                mfila1 = value
            End Set
        End Property

        Public Property precio()
            Get
                Return mprecio
            End Get
            Set(ByVal value)

                Dim temp As Single

                If mrec_des <> "" Then
                    mprecio = Format((form_factura.txt_neto.Text * mrec_des) / 100 + form_factura.txt_neto.Text, "0.000")
                Else
                    mprecio = value
                End If

                If Me.unidad_medida = "NO" Then
                    temp = Format((mcantidad * mprecio), "0.000")
                Else
                    temp = Format((mvalor_unidad_medida * mprecio), "0.000")
                End If

                If Me.impuesto = 0 And RTrim(Me.Codigo_iva) = "1" Then mtotal = (temp * miva) / 100 + temp ' si es inscripto 21 %
                If Me.impuesto = 0 And RTrim(Me.Codigo_iva) = "2" Then mtotal = ((temp * miva) / 100) + temp 'si es no inscripto 10.5 %
                If Me.impuesto = 0 And RTrim(Me.Codigo_iva) = "3" Then mtotal = temp 'exento
                If Me.impuesto <> 0 Then mtotal = (temp * miva) / 100 + temp + mimpuesto
                sub_total = mtotal

            End Set
        End Property

        Public Property desc_rcgo()
            Get
                Return mrec_des
            End Get
            Set(ByVal value)

                If value > 0 Or value < 0 Then

                    mrec_des = value
                    desc = (mtotal * mrec_des) / 100
                    mtotal = sub_total + desc
                    mrec_des = value

                Else

                    mrec_des = value
                    desc = (mtotal * mrec_des) / 100
                    mtotal = sub_total + desc
                    mrec_des = ""

                End If

            End Set
        End Property

        Public Property total()
            Get
                Return mtotal
            End Get
            Set(ByVal value)

                mtotal = value

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

        Public Property precio_final()
            Get
                Return mprecio_final
            End Get
            Set(ByVal value)
                mprecio_final = value
            End Set
        End Property

        Public Property impuesto()
            Get
                Return mimpuesto
            End Get
            Set(ByVal value)
                mimpuesto = value
            End Set
        End Property

        Public Property iva()
            Get
                Return miva
            End Get
            Set(ByVal value)
                miva = value
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

        Public Property sale()
            Get
                Return msale
            End Get
            Set(ByVal value)
                msale = value
            End Set
        End Property

        Public Sub cargar_factura()

            If mfila < Me.cantidad_item_factura Then

                Dim temp As Single

                If form_factura.txt_desc_rcgo.Text = "-" Or form_factura.txt_desc_rcgo.Text = "" Then
                    form_factura.txt_desc_rcgo.Text = 0
                End If

                mgrilla.Rows.Add()

                mgrilla.FirstDisplayedScrollingRowIndex = mfila

                mgrilla.Rows(mfila).Cells(7).Value = 0   ' llena con 0 las filas para q no de error
                mgrilla.Rows(mfila).Cells(9).Value = 0
                mgrilla.Rows(mfila).Cells(6).Value = 0
                mgrilla.Rows(mfila).Cells(13).Value = 0

                mgrilla.Rows(mfila).Cells(0).Value = mcodigo_fact
                mgrilla.Rows(mfila).Cells(1).Value = mnombre
                mgrilla.Rows(mfila).Cells(2).Value = mcantidad
                If form_factura.txt_iva1.Text <> 0 Then mgrilla.Rows(mfila).Cells(3).Value = mprecio
                If form_factura.txt_iva1.Text = 0 Then mgrilla.Rows(mfila).Cells(3).Value = mprecio

                If Me.factura_en_c = "NO" Then
                    mgrilla.Rows(mfila).Cells(4).Value = Format(mtotal, "0.000")
                Else
                    If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila).Cells(4).Value = Format(mprecio * mcantidad, "0.000")
                    If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila).Cells(4).Value = Format(mprecio * mvalor_unidad_medida, "0.000")
                End If

                mgrilla.Rows(mfila).Cells(5).Value = mrec_des
                mgrilla.Rows(mfila).Cells(7).Value = Format(mimpuesto, "0.00")
                mgrilla.Rows(mfila).Cells(8).Value = miva

                If Me.munidad_medida = "NO" Then temp = (mexento * mcantidad)
                If Me.munidad_medida = "SI" Then temp = (mexento * mvalor_unidad_medida)

                mgrilla.Rows(mfila).Cells(10).Value = miva
                mgrilla.Rows(mfila).Cells(11).Value = mprecio_civa

                If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila).Cells(14).Value = Format(mcosto * mcantidad, "0.00")
                If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila).Cells(14).Value = Format(mcosto * mvalor_unidad_medida, "0.00")

                mgrilla.Rows(mfila).Cells(15).Value = mprov
                mgrilla.Rows(mfila).Cells(16).Value = mrub
                mgrilla.Rows(mfila).Cells(17).Value = mvalor_unidad_medida
                Dim des As Single = (temp * form_factura.txt_desc_rcgo.Text / 100) * (-1)
                mgrilla.Rows(mfila).Cells(9).Value = Format(temp - des, "0.00")

                If RTrim(form_factura.txt_cod_iva.Text) = 3 Then ' iva exento
                    mgrilla.Rows(mfila).Cells(6).Value = 0
                End If

                If RTrim(form_factura.txt_cod_iva.Text) = 1 Then ' iva 21
                    If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila).Cells(6).Value = (mcantidad * mprecio) * miva / 100
                    If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila).Cells(6).Value = (mvalor_unidad_medida * mprecio) * miva / 100
                End If

                If RTrim(form_factura.txt_cod_iva.Text) = 2 Then ' iva 10.5 Then
                    If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila).Cells(13).Value = Format(mtotal - (mprecio * mcantidad), "0.00")
                    If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila).Cells(13).Value = Format(mtotal - (mprecio * mvalor_unidad_medida), "0.00")
                End If

                mgrilla.Rows(mfila).Cells(6).Value = Format(mgrilla.Rows(mfila).Cells(6).Value, "0.00")
                mfila = mfila + 1

            Else

                MsgBox("Comprobante LLeno", MsgBoxStyle.Information, "PyMsoft")
                sale = True

            End If

        End Sub

        Public Sub modifica_grilla()

            Dim temp As Single

            mgrilla.Rows(mfila1).Cells(7).Value = 0   ' llena con 0 las filas para q no de error
            mgrilla.Rows(mfila1).Cells(9).Value = 0
            mgrilla.Rows(mfila1).Cells(6).Value = 0
            mgrilla.Rows(mfila1).Cells(13).Value = 0

            mgrilla.Rows(mfila1).Cells(0).Value = mcodigo_fact
            mgrilla.Rows(mfila1).Cells(1).Value = mnombre
            mgrilla.Rows(mfila1).Cells(2).Value = mcantidad
            If mgrilla.Rows(mfila1).Cells(10).Value = miva Or mgrilla.Rows(mfila1).Cells(10).Value = miva Then mgrilla.Rows(mfila1).Cells(3).Value = mprecio
            If mgrilla.Rows(mfila1).Cells(10).Value = 0 Then mgrilla.Rows(mfila1).Cells(3).Value = mexento

            mgrilla.Rows(mfila1).Cells(11).Value = mprecio_civa

            If Me.factura_en_c = "NO" Then
                mgrilla.Rows(mfila1).Cells(4).Value = Format(mtotal, "0.00")
            Else
                If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila1).Cells(4).Value = Format(mprecio * mcantidad, "0.00")
                If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila1).Cells(4).Value = Format(mprecio * mvalor_unidad_medida, "0.00")
            End If

            mgrilla.Rows(mfila1).Cells(5).Value = mrec_des
            mgrilla.Rows(mfila1).Cells(7).Value = mimpuesto
            mgrilla.Rows(mfila1).Cells(8).Value = miva

            If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila1).Cells(14).Value = Format(form_factura.txt_precio_costo.Text * mcantidad, "0.00")
            If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila1).Cells(14).Value = Format(form_factura.txt_precio_costo.Text * mvalor_unidad_medida, "0.00")

            If mgrilla.Rows(mfila1).Cells(10).Value = 0 And Me.munidad_medida = "NO" Then temp = mexento * mcantidad
            If mgrilla.Rows(mfila1).Cells(10).Value = 0 And Me.munidad_medida = "SI" Then temp = mexento * mvalor_unidad_medida

            Dim des As Single = (temp * form_factura.txt_desc_rcgo.Text / 100) * (-1)

            mgrilla.Rows(mfila1).Cells(9).Value = Format(temp - des, "0.00")

            If RTrim(form_factura.txt_cod_iva.Text) = 3 Then ' iva exento Then

                mgrilla.Rows(mfila1).Cells(3).Value = Format(mgrilla.Rows(mfila1).Cells(3).Value * form_factura.txt_desc_rcgo.Text / 100 - mgrilla.Rows(mfila1).Cells(3).Value * (-1), "0.000")
                mgrilla.Rows(mfila1).Cells(4).Value = mgrilla.Rows(mfila1).Cells(9).Value

            End If

            If RTrim(form_factura.txt_cod_iva.Text) = 1 Then ' iva 21 Then

                If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila1).Cells(6).Value = (mcantidad * mprecio) * mgrilla.Rows(mfila1).Cells(10).Value / 100
                If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila1).Cells(6).Value = (mvalor_unidad_medida * mprecio) * mgrilla.Rows(mfila1).Cells(10).Value / 100
                mgrilla.Rows(mfila1).Cells(3).Value = mprecio

            End If

            If RTrim(form_factura.txt_cod_iva.Text) = 2 Then ' iva 10.5 Then

                If Me.munidad_medida = "NO" Then mgrilla.Rows(mfila1).Cells(13).Value = Format((mcantidad * mprecio) * mgrilla.Rows(mfila1).Cells(10).Value / 100, "0.00")
                If Me.munidad_medida = "SI" Then mgrilla.Rows(mfila1).Cells(13).Value = Format((mvalor_unidad_medida * mprecio) * mgrilla.Rows(mfila1).Cells(10).Value / 100, "0.00")

            End If

            mgrilla.Rows(mfila1).Cells(6).Value = Format(mgrilla.Rows(mfila1).Cells(6).Value, "0.00")
            mgrilla.Rows(mfila1).Cells(17).Value = mvalor_unidad_medida


        End Sub

        Public Sub guardar_factura()
            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                Insercion.Dispose()

                conex.Close()

            Catch ex As Exception

            End Try

        End Sub

        Public Sub New()
            eps = New OCXFISLib.DriverFiscal
            conex = conecta()
        End Sub

        Public Sub imprimir_factura(ByVal numero As Integer, ByVal letra As String, ByVal prefijo As Integer, ByVal tipo As String, ByVal talon As String, ByVal comprobante As String, ByVal tipo_iva As String)

            Try

                Dim x As String
                Dim i As Integer
                Dim entra As Boolean = False
                Dim copias As Integer = Me.copias_impresora_comun

                If talon = 1 Or talon = 3 Then

                    If RTrim(letra) = "A" Then   ' pide letra factura

                        Dim rep As Object = Nothing

                        If entra = False Then
                            x = reporte.carga_datos("fact_A")

                            If x = "fact_A" Then
                                rep = New fact_A
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_A_afip")

                            If x = "fact_A_afip" Then
                                rep = New Fact_A_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_A_afip_congelados")

                            If x = "fact_A_afip_congelados" Then
                                rep = New Fact_A_afip_congelados
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("Fact_A_afip_bodrito")

                            If x = "Fact_A_afip_bodrito" Then
                                rep = New Fact_A_afip_bodrito
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("Fact_A_afip_erica")

                            If x = "Fact_A_afip_erica" Then
                                rep = New Fact_A_afip_erica
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("Fact_A_afip_gama")

                            If x = "Fact_A_afip_gama" Then
                                rep = New Fact_A_afip_gama
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220_afip")

                            If x = "epson_tm220_afip" Then
                                rep = New epson_tm220_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220")

                            If x = "epson_tm220" Then
                                rep = New epson_tm220
                                entra = True
                            End If
                        End If

                        txt = rep.Section1.ReportObjects.Item("comprobante")
                        txt.Text = comprobante  ' pide nombre formulario

                        If tipo_iva = "Monotributo" Then
                            txt = rep.Section5.ReportObjects.Item("txt_leyenda_monotributo")
                            txt.Text = "El crédito fiscal discriminado en el presente comprobante, sólo podrá ser computado a efectos del Régimen de Sostenimiento e Inclusión Fiscal para Pequeños Contribuyentes de la Ley Nº 27.618"  ' pide nombre formulario
                        End If

                        rep.RecordSelectionFormula = "{fact_det.num_fact}= " & numero & " and {fact_det.letra_fact1} = '" & letra & "' and {fact_det.prefijo_fact2} = " & prefijo & " and {fact_det.tipo_fact2}= '" & tipo & "' and {fact_det.talon1} = " & talon & ""

                        If Me.muestra_cuadro_impresion = "NO" Then

                            For i = 0 To copias - 1

                                txt = rep.Section1.ReportObjects.Item("ori_dupli")

                                If i = 0 Then
                                    txt.Text = "Original"
                                Else
                                    txt.Text = "Duplicado"
                                End If

                                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                                rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                                'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                                'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                                If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                                rep.PrintToPrinter(1, False, 0, 0)
                            Next

                        Else

                            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                            Form_repfact.CrystalReportViewer1.ReportSource = rep
                            Form_repfact.CrystalReportViewer1.RefreshReport()
                            Form_repfact.Show()

                        End If

                    End If

                    If RTrim(letra) = "B" Then

                        Dim rep As Object = Nothing

                        If entra = False Then
                            x = reporte.carga_datos("fact_B")

                            If x = "fact_B" Then
                                rep = New fact_B
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_B_afip")

                            If x = "fact_B_afip" Then
                                rep = New fact_B_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_B_afip_congelados")

                            If x = "fact_B_afip_congelados" Then
                                rep = New fact_B_afip_congelados
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_B_afip_gama")

                            If x = "fact_B_afip_gama" Then
                                rep = New fact_B_afip_gama
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_B_afip_bodrito")

                            If x = "fact_B_afip_bodrito" Then
                                rep = New fact_B_afip_bodrito
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_B_afip_erica")

                            If x = "fact_B_afip_erica" Then
                                rep = New fact_B_afip_erica
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220_afip")

                            If x = "epson_tm220_afip" Then
                                rep = New epson_tm220_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220")

                            If x = "epson_tm220" Then
                                rep = New epson_tm220
                                entra = True
                            End If
                        End If

                        txt = rep.Section1.ReportObjects.Item("comprobante")
                        txt.Text = comprobante  ' pide nombre formulario

                        rep.RecordSelectionFormula = "{fact_det.num_fact}= " & numero & " and {fact_det.letra_fact1} = '" & letra & "' and {fact_det.prefijo_fact2} = " & prefijo & " and {fact_det.tipo_fact2}= '" & tipo & "' and {fact_det.talon1} = " & talon & ""

                        If Me.muestra_cuadro_impresion = "NO" Then

                            For i = 0 To copias - 1

                                txt = rep.Section1.ReportObjects.Item("ori_dupli")

                                If i = 0 Then
                                    txt.Text = "Original"
                                Else
                                    txt.Text = "Duplicado"
                                End If

                                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                                rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                                'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                                'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                                If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                                rep.PrintToPrinter(1, False, 0, 0)
                            Next

                        Else

                            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                            Form_repfact.CrystalReportViewer1.ReportSource = rep
                            Form_repfact.CrystalReportViewer1.RefreshReport()
                            Form_repfact.Show()

                        End If


                    End If

                    If RTrim(letra) = "C" Then

                        Dim rep As Object = Nothing

                        If entra = False Then
                            x = reporte.carga_datos("fact_c_afip")

                            If x = "fact_c_afip" Then
                                rep = New fact_C_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_C")

                            If x = "fact_C" Then
                                rep = New fact_C
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_c_membrete")

                            If x = "fact_c_membrete" Then
                                rep = New fact_c_membrete
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_c_membrete_mitad")

                            If x = "fact_c_membrete_mitad" Then
                                rep = New fact_c_membrete_mitad
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_c_membrete_mitad_bodrito")

                            If x = "fact_c_membrete_mitad_bodrito" Then
                                rep = New fact_c_membrete_mitad_bodrito
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("fact_c_membrete_mitad_general")

                            If x = "fact_c_membrete_mitad_general" Then
                                rep = New fact_c_membrete_mitad_general
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220_afip")

                            If x = "epson_tm220_afip" Then
                                rep = New epson_tm220_afip
                                entra = True
                            End If
                        End If

                        If entra = False Then
                            x = reporte.carga_datos("epson_tm220")

                            If x = "epson_tm220" Then
                                rep = New epson_tm220
                                entra = True
                            End If
                        End If

                        'txt = rep.Section1.ReportObjects.Item("comprobante")
                        'txt.Text = comprobante  ' pide nombre formulario

                        rep.RecordSelectionFormula = "{fact_det.num_fact}= " & numero & " and {fact_det.letra_fact1} = '" & letra & "' and {fact_det.prefijo_fact2} = " & prefijo & " and {fact_det.tipo_fact2}= '" & tipo & "' and {fact_det.talon1} = " & talon & ""

                        If Me.muestra_cuadro_impresion = "NO" Then

                            For i = 0 To copias - 1
                                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                                rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                                'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                                'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                                rep.PrintToPrinter(1, False, 0, 0)
                            Next

                        Else

                            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                            Form_repfact.CrystalReportViewer1.ReportSource = rep
                            Form_repfact.CrystalReportViewer1.RefreshReport()
                            Form_repfact.Show()

                        End If

                    End If

                End If

                'IMPRIMIO FORMATO FACTURA EN NEGRO POR ESO USO ESTOS REPORTES
                If talon = 2 Then

                    ' si es talonario en negro solo imprimo 1 copia y no le doy bola al parametro
                    copias = 1

                    x = reporte.carga_datos("fact_C")

                    Dim rep As Object = Nothing

                    If x = "fact_C" Then
                        rep = New fact_C
                    End If

                    x = reporte.carga_datos("fact_c_membrete")

                    If x = "fact_c_membrete" Then
                        rep = New fact_c_membrete
                    End If

                    x = reporte.carga_datos("fact_c_membrete_mitad")

                    If x = "fact_c_membrete_mitad" Then
                        rep = New fact_c_membrete_mitad
                    End If

                    x = reporte.carga_datos("fact_c_membrete_mitad_bodrito")

                    If x = "fact_c_membrete_mitad_bodrito" Then
                        rep = New fact_c_membrete_mitad_bodrito
                    End If

                    x = reporte.carga_datos("fact_c_membrete_mitad_general")

                    If x = "fact_c_membrete_mitad_general" Then
                        rep = New fact_c_membrete_mitad_general
                    End If

                    x = reporte.carga_datos("epson_tm220")

                    If x = "epson_tm220" Then
                        rep = New epson_tm220
                    End If

                    'txt = rep.Section1.ReportObjects.Item("comprobante")
                    'txt.Text = comprobante  ' pide nombre formulario

                    rep.RecordSelectionFormula = "{fact_det.num_fact}= " & numero & " and {fact_det.letra_fact1} = '" & letra & "' and {fact_det.prefijo_fact2} = " & prefijo & " and {fact_det.tipo_fact2}= '" & tipo & "' and {fact_det.talon1} = " & talon & ""

                    'txt = CType(rep.ReportDefinition.ReportObjects.Item("comprobante"), CrystalDecisions.CrystalReports.Engine.TextObject)

                    'If Trim(tipo) = "FC" Then
                    'txt.Text = "PRESUPUESTO"
                    'Else
                    'txt.Text = "NOTA DE CREDITO"
                    'End If

                    If Me.muestra_cuadro_impresion = "NO" Then

                        For i = 0 To copias - 1
                            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                            rep.PrintToPrinter(1, False, 0, 0)
                        Next

                    Else
                        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                        Form_repfact.CrystalReportViewer1.ReportSource = rep
                        Form_repfact.CrystalReportViewer1.RefreshReport()
                        Form_repfact.Show()

                    End If


                End If

                If RTrim(letra) = "P" Then

                    Dim rep As Object = Nothing

                    x = reporte.carga_datos("presupuesto")

                    If x = "presupuesto" Then
                        rep = New presupuesto
                    End If

                    x = reporte.carga_datos("presupuestoBV")

                    If x = "presupuestoBV" Then
                        rep = New presupuestoBV
                    End If

                    'Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

                    'txt = rep.Section1.ReportObjects.Item("tipo_fact")
                    'txt.Text = Me.form_txt

                    rep.RecordSelectionFormula = "{presupuesto.num}= " & numero & ""

                    If Me.muestra_cuadro_impresion = "NO" Then

                        For i = 0 To 1 'copias - 1
                            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                            'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                            'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                            rep.PrintToPrinter(1, False, 0, 0)
                        Next

                    Else

                        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)
                        Form_repfact.CrystalReportViewer1.ReportSource = rep
                        Form_repfact.CrystalReportViewer1.RefreshReport()
                        Form_repfact.Show()

                    End If


                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Try

        End Sub

        Public Sub imprime_recibo(ByVal letra, ByVal numero, ByVal prefijo, ByVal total, ByVal talon)

            Dim tbl As New DataTable
            Dim i As Integer
            Dim cheq As Double
            Dim x As String

            tbl.Clear()

            Dim rep As Object = Nothing

            x = reporte.carga_datos("recibo")

            If x = "recibo" Then
                rep = New recibo
            End If

            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt3 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt4 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt5 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt6 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt7 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt8 As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt9 As CrystalDecisions.CrystalReports.Engine.TextObject

            comando1 = New SqlDataAdapter("select id_cheque,banco,total from cheque_01 where tc = 'RC' and lt = '" & RTrim(letra) & "' and numero = '" & RTrim(numero) & "' and prefijo = '" & RTrim(prefijo) & "' and talon = '" & RTrim(talon) & "'", conex)
            comando1.Fill(tbl)

            conex = conecta()

            If tbl.Rows.Count <> Nothing Then

                For i = 0 To tbl.Rows.Count - 1

                    txt = rep.Section4.ReportObjects.Item("txt_2")
                    txt.Text = "CHEQUE:"

                    txt1 = rep.Section4.ReportObjects.Item("txt_22")
                    txt1.Text = tbl.Rows(i).Item(0) & "    " & tbl.Rows(i).Item(1) & "    " & "$" & "" & tbl.Rows(i).Item(2)

                    cheq = Format(cheq + tbl.Rows(i).Item(2), "0.00")

                    i = i + 1
                    If i = tbl.Rows.Count Then Exit For

                    txt2 = rep.Section4.ReportObjects.Item("txt_3")
                    txt2.Text = "CHEQUE:"

                    txt3 = rep.Section4.ReportObjects.Item("txt_33")
                    txt3.Text = tbl.Rows(i).Item(0) & "    " & tbl.Rows(i).Item(1) & "    " & "$" & "" & tbl.Rows(i).Item(2)

                    cheq = Format(cheq + tbl.Rows(i).Item(2), "0.00")

                    i = i + 1
                    If i = tbl.Rows.Count Then Exit For

                    txt4 = rep.Section4.ReportObjects.Item("txt_4")
                    txt4.Text = "CHEQUE:"

                    txt5 = rep.Section4.ReportObjects.Item("txt_44")
                    txt5.Text = tbl.Rows(i).Item(0) & "    " & tbl.Rows(i).Item(1) & "    " & "$" & "" & tbl.Rows(i).Item(2)

                    cheq = Format(cheq + tbl.Rows(i).Item(2), "0.00")

                    i = i + 1
                    If i = tbl.Rows.Count Then Exit For

                    txt8 = rep.Section4.ReportObjects.Item("txt_5")
                    txt8.Text = "CHEQUE:"

                    txt9 = rep.Section4.ReportObjects.Item("txt_55")
                    txt9.Text = tbl.Rows(i).Item(0) & "    " & tbl.Rows(i).Item(1) & "    " & "$" & "" & tbl.Rows(i).Item(2)

                    cheq = Format(cheq + tbl.Rows(i).Item(2), "0.00")

                Next

            End If

            txt6 = rep.Section4.ReportObjects.Item("txt_1")
            txt6.Text = "EFECTIVO:"

            txt7 = rep.Section4.ReportObjects.Item("txt_11")
            txt7.Text = "$" & "" & Format(total - cheq, "0.00")

            rep.RecordSelectionFormula = "{recibo_det.id_det}= " & numero & " and {recibo_det.pre1} = " & prefijo & " and {recibo_det.tc1}= 'RC' and {recibo_det.letra_01}= '" & letra & "' and {recibo_det.talon1}= " & talon & ""

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")
            rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
            rep.PrintToPrinter(2, False, 0, 0)

            'Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            'Form_repcli_01.CrystalReportViewer1.RefreshReport()
            'Form_repcli_01.Show()

        End Sub

        Public Sub imprime_orden_pago(ByVal letra, ByVal numero, ByVal prefijo, ByVal total, ByVal talon)

            Dim x As String
            Dim rep As Object = Nothing

            x = reporte.carga_datos("orden_pago")

            If x = "orden_pago" Then
                rep = New orden_pago
            End If

            rep.RecordSelectionFormula = "{recibo_det.id_det}= " & numero & " and {recibo_det.pre1} = " & prefijo & " and {recibo_det.tc1}= 'OP' and {recibo_det.letra_01}= '" & letra & "' and {recibo_det.talon1}= " & talon & ""

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")
            'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
            rep.PrintToPrinter(1, False, 0, 0)

        End Sub


        Public Sub imprimir_remito()

            Dim x As String

            If RTrim(Me.form_txt_letra) = "A" Then   ' pide letra factura

                Dim rep As Object = Nothing

                x = reporte.carga_datos("remito")

                If x = "remito" Then
                    rep = New remito
                End If

                Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

                txt = rep.Section1.ReportObjects.Item("tipo_fact")
                txt.Text = Me.form_txt  ' pide nombre formulario

                rep.RecordSelectionFormula = "{fact_det.num_fact}= " & Me.numero_factura & " and {fact_det.letra_fact1} = '" & Me.letra_fact & "' and {fact_det.tipo_fact2}= '" & Me.tipo_fact & "'"

                'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                'rep.PrintOptions.PrinterName = "HP LaserJet 1100 (MS)"
                'form_factura.PrintDialog1.ShowDialog()
                'rep.PrintToPrinter(1, False, 0, 0)

                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                rep.SetDatabaseLogon(conexion.usuario, "")
                Form_repcli_01.CrystalReportViewer1.ReportSource = rep
                Form_repcli_01.CrystalReportViewer1.RefreshReport()
                Form_repcli_01.Show()

            End If

            If RTrim(Me.form_txt_letra) = "B" Or RTrim(Me.form_txt_letra) = "X" Then

                Dim rep As Object = Nothing

                x = reporte.carga_datos("remito")

                If x = "remito" Then
                    rep = New remito
                End If

                Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

                txt = rep.Section1.ReportObjects.Item("tipo_fact")
                txt.Text = Me.form_txt

                rep.RecordSelectionFormula = "{fact_det.num_fact}= " & Me.numero_factura & " and {fact_det.letra_fact1} = '" & Me.letra_fact & "' and {fact_det.tipo_fact2}= '" & Me.tipo_fact & "'"

                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                rep.SetDatabaseLogon(conexion.usuario, "")
                Form_repcli_01.CrystalReportViewer1.ReportSource = rep
                Form_repcli_01.CrystalReportViewer1.RefreshReport()
                Form_repcli_01.Show()

            End If

        End Sub

        Public Sub imprimir_pedido()

            Dim rep As Object = Nothing
            Dim x As String

            x = reporte.carga_datos("pedido")

            If x = "pedido" Then
                rep = New pedido
            End If

            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

            txt = rep.Section1.ReportObjects.Item("tipo_fact")
            txt.Text = "NOTA DE PEDIDO"

            rep.RecordSelectionFormula = "{fact_det.num_fact}= " & Me.numero_factura & " and {fact_det.letra_fact1} = '" & Me.letra_fact & "' and {fact_det.tipo_fact2}= '" & Me.tipo_fact & "' and {fact_det.prefijo_fact2}= " & Me.prefijo_factura & ""

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")
            rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
            rep.PrintToPrinter(1, False, 0, 0)

            'Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            'Form_repcli_01.CrystalReportViewer1.RefreshReport()
            'Form_repcli_01.Show()

        End Sub

        Public Sub imprime_ticket_fiscal_hasraf715()

            Try

                '''''''''''  imprimir ticket c. final   ''''''' ticketera hasar 715 f '''''''''


                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                If imp.ToString = "" Then
                    imp = 0
                End If

                If Me.habilita_puerto_com = "SI" Then

                    If Me.detecta_modelo = "SI" Then
                        form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                        form_factura.AxHASAR1.Baudios = Me.baude_rate
                        form_factura.AxHASAR1.AutodetectarControlador()
                        form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
                    Else
                        form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                        form_factura.AxHASAR1.Baudios = Me.baude_rate
                        form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
                    End If

                End If

                If Me.habilita_tcp = "SI" Then

                    form_factura.AxHASAR1.Transporte = FiscalPrinterLib.TiposDeTransporte.SOCKET_TCP
                    form_factura.AxHASAR1.Puerto = 7227
                    form_factura.AxHASAR1.DireccionIP = "127.0.0.1"

                End If

                form_factura.AxHASAR1.ReintentoConstante = True
                form_factura.AxHASAR1.Comenzar()
                form_factura.AxHASAR1.TratarDeCancelarTodo()
                form_factura.AxHASAR1.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_C)
                form_factura.AxHASAR1.DescripcionesLargas = False

                form_factura.AxHASAR1.BorrarFantasiaEncabezadoCola(False, True, True)

                form_factura.AxHASAR1.set_Encabezado(11, "Forma pago:" & " " & form_factura.cmb_forma_pago.Text)
                form_factura.AxHASAR1.get_Encabezado(11)
                form_factura.AxHASAR1.set_Encabezado(12, "Numero Control:" & " " & form_factura.txt_numero.Text)
                form_factura.AxHASAR1.get_Encabezado(12)
                form_factura.AxHASAR1.set_Encabezado(13, "Usuario:" & " " & principal.lbl_usu.Text)
                form_factura.AxHASAR1.get_Encabezado(13)
                form_factura.AxHASAR1.set_Encabezado(14, "        " & "¡¡ GRACIAS X SU COMPRA !!")
                form_factura.AxHASAR1.get_Encabezado(14)

                Dim copias As String = Me.copias_fiscales
                form_factura.AxHASAR1.ConfigurarControlador(FiscalPrinterLib.ParametrosDeConfiguracion.COPIAS_DOCUMENTOS, copias)

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    form_factura.AxHASAR1.ImpuestoInternoFijo = True

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.000")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.000")
                        des = des & " " & descuento & " " & "%"
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.000")

                    form_factura.AxHASAR1.ImprimirItem(des, cant, p_civa, ivas, imp)

                Next

                form_factura.AxHASAR1.ImprimirPago("Efectivo", 0)

                If Form_tipo_pago.txt_descuento.Text <> "" Then form_factura.AxHASAR1.DescuentoGeneral("Bonificacion", Form_tipo_pago.txt_descuento.Text, True)
                form_factura.AxHASAR1.CerrarComprobanteFiscal()
                form_factura.AxHASAR1.Finalizar()

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            End Try

        End Sub

        Public Sub imprime_ticket_epson(ByVal numero As Integer, ByVal letra As String, ByVal prefijo As Integer, ByVal tipo As String)

            Dim rep As New epson_tm220
            'Dim tabla As New DataTable

            'tabla.Clear()

            'comando1 = New SqlDataAdapter("select * from fact_det where num_fact = '" & numero & "' and letra_fact1 = '" & letra & "' and prefijo_fact2 = '" & prefijo & "' and tipo_fact2 = '" & tipo & "'", conex)
            'comando1.Fill(tabla)

            'rep.SetDataSource(tabla)
            'rep.Refresh()

            rep.RecordSelectionFormula = "{fact_det.num_fact}= " & numero & " and {fact_det.letra_fact1} = '" & letra & "' and {fact_det.prefijo_fact2} = " & prefijo & " and {fact_det.tipo_fact2}= '" & tipo & "'"

            'Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            'Form_repcli_01.CrystalReportViewer1.RefreshReport()
            'Form_repcli_01.Show()

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")
            rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
            rep.PrintToPrinter(1, False, 0, 0)

            'form_factura.AxPrinterFiscal1.OpenTicket("G")

            'For i = 0 To form_factura.DataGridView1.Rows.Count - 2

            'ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
            'descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
            'cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
            'monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
            'imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
            'des = ""

            'If descuento = "" Then
            'p_civa = Format(((monto * ivas) / 100 + monto), "0.000")
            'Else
            'p_civa = Format(((monto * ivas) / 100 + monto), "0.000")
            'p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.000")
            'End If

            'If imp > 0 Then p_civa = Format(p_civa + imp, "0.000")

            'If form_factura.txt_factura_notaCredito.Text = 1 Then
            'p_civa = cant * p_civa
            'des = cant & " " & form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString
            'End If

            'form_factura.AxPrinterFiscal1.SendTicketItem(des, 1, p_civa, ivas, i, "0", "0")

            'Next

            'form_factura.AxPrinterFiscal1.CloseTicket()

        End Sub

        Public Sub imprime_ticket_fisca_epson_tm220()

            Form_tipo_pago.cmd_acepta.Enabled = False
            Form_tipo_pago.cmd_cancela.Enabled = False
            Form_tipo_pago.Enabled = False
            form_factura.Enabled = False

            Try

                puerto = "COM" & Me.Puerto_Com
                baude = Me.baude_rate

                nError = eps.IF_OPEN(puerto, baude)
                nError = eps.EpsonTicket.TIQUEABRE("C")

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    ivas = ivas

                    If des.Length >= 20 Then
                        sub_cadena = des.Substring(0, 15)
                    Else
                        sub_cadena = des
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    nError = eps.EpsonTicket.TIQUEITEM("    " & sub_cadena, cant, p_civa, ivas, "M", 1, 0, 0)

                Next

                eps.EpsonTicket.TIQUECIERRA("T")

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            Finally

                eps.IF_CLOSE()

            End Try


        End Sub

        Public Sub imprime_factura_A_fiscal_epson_tm220()

            Try

                ''''''''''''''''''''' imprime factura A en fiscal Epson tm220 ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                puerto = "COM" & Me.Puerto_Com
                baude = Me.baude_rate

                nError = eps.IF_OPEN(puerto, baude)

                nError = eps.EpsonTicket.FACTABRE("T", "C", "A", 1, "P", 10, "I", "I", form_factura.txt_cliente.Text, "", "CUIT", cuit, "N", form_factura.txt_direccion.Text, "", "", form_factura.txt_numero.Text, "", "C")

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = Format(form_factura.DataGridView1.Rows(i).Cells(3).Value, "0.000")
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    ivas = ivas

                    If des.Length >= 20 Then
                        sub_cadena = des.Substring(0, 20)
                    Else
                        sub_cadena = des
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    nError = eps.EpsonTicket.FACTITEM(sub_cadena, cant, monto, ivas, "M", 1, 0, "", "", "", 0, imp)

                Next

                nError = eps.EpsonTicket.FACTCIERRA("T", "A", "")

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                nError = eps.IF_CLOSE()
                form_factura.Close()

            Finally

                nError = eps.IF_CLOSE()

            End Try

        End Sub

        Public Sub imprime_factura_B_fiscal_epson_tm220()

            Try

                ''''''''''''''''''''' imprime factura B en fiscal Epson tm220 ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                If RTrim(form_factura.txt_iva_solo.Text) = "Monotributo" Then
                    lfe = "M"
                    tce = "CUIT"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = "Consumidor Final" Then
                    lfe = "F"
                    tce = "NDOC"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = "Exento" Then
                    lfe = "E"
                    tce = "CUIT"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = " No Categorizado" Then
                    lfe = "S"
                    tce = "NDOC"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = " No Inscripto" Then
                    lfe = "R"
                    tce = "NDOC"
                End If

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                puerto = "COM" & Me.Puerto_Com
                baude = Me.baude_rate

                nError = eps.IF_OPEN(puerto, baude)

                nError = eps.EpsonTicket.FACTABRE("T", "C", "B", 1, "P", 10, "I", lfe, form_factura.txt_cliente.Text, "", tce, cuit, "N", form_factura.txt_direccion.Text, "", "", form_factura.txt_numero.Text, "", "C")

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = Format(form_factura.DataGridView1.Rows(i).Cells(3).Value, "0.000")
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    ivas = ivas

                    If des.Length >= 20 Then
                        sub_cadena = des.Substring(0, 20)
                    Else
                        sub_cadena = des
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    nError = eps.EpsonTicket.FACTITEM(sub_cadena, cant, p_civa, ivas, "M", 1, 0, "", "", "", 0, imp)

                Next

                nError = eps.EpsonTicket.FACTCIERRA("T", "B", "")

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                nError = eps.IF_CLOSE()
                form_factura.Close()

            Finally

                nError = eps.IF_CLOSE()

            End Try

        End Sub

        Public Sub imprime_Nota_C_A_fiscal_epson_tm220()

            Try

                ''''''''''''''''''''' imprime factura A en fiscal Epson tm220 ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                puerto = "COM" & Me.Puerto_Com
                baude = Me.baude_rate

                nError = eps.IF_OPEN(puerto, baude)

                nError = eps.EpsonTicket.FACTABRE("M", "C", "A", 1, "P", 10, "I", "I", form_factura.txt_cliente.Text, "", "CUIT", cuit, "N", form_factura.txt_direccion.Text, "", "", form_factura.txt_numero.Text, "", "C")

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = Format(form_factura.DataGridView1.Rows(i).Cells(3).Value, "0.000")
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    'ivas = ivas / 100
                    ivas = ivas

                    If des.Length >= 20 Then
                        sub_cadena = des.Substring(0, 20)
                    Else
                        sub_cadena = des
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    nError = eps.EpsonTicket.FACTITEM(sub_cadena, cant, monto, ivas, "M", 1, 0, "", "", "", 0, imp)

                Next

                nError = eps.EpsonTicket.FACTCIERRA("M", "A", "Gracias x su Compra!")

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                nError = eps.IF_CLOSE()
                form_factura.Close()

            Finally

                nError = eps.IF_CLOSE()

            End Try

        End Sub

        Public Sub imprime_Nota_C_B_fiscal_epson_tm220()

            Try

                ''''''''''''''''''''' imprime factura B en fiscal Epson tm220 ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                If RTrim(form_factura.txt_iva_solo.Text) = "Monotributo" Then
                    lfe = "M"
                    tce = "CUIT"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = "Consumidor Final" Then
                    lfe = "F"
                    tce = "NDOC"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = "Exento" Then
                    lfe = "E"
                    tce = "CUIT"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = " No Categorizado" Then
                    lfe = "S"
                    tce = "NDOC"
                End If
                If RTrim(form_factura.txt_iva_solo.Text) = " No Inscripto" Then
                    lfe = "R"
                    tce = "NDOC"
                End If

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                puerto = "COM" & Me.Puerto_Com
                baude = Me.baude_rate

                nError = eps.IF_OPEN(puerto, baude)

                nError = eps.EpsonTicket.FACTABRE("M", "C", "B", 1, "P", 10, "I", lfe, form_factura.txt_cliente.Text, "", tce, cuit, "N", form_factura.txt_direccion.Text, "", "", form_factura.txt_numero.Text, "", "C")

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = Format(form_factura.DataGridView1.Rows(i).Cells(3).Value, "0.000")
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    'ivas = ivas / 100
                    ivas = ivas

                    If des.Length >= 20 Then
                        sub_cadena = des.Substring(0, 20)
                    Else
                        sub_cadena = des
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    nError = eps.EpsonTicket.FACTITEM(sub_cadena, cant, p_civa, ivas, "M", 1, 0, "", "", "", 0, imp)

                Next

                nError = eps.EpsonTicket.FACTCIERRA("M", "B", "Gracias x su Compra!")

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                nError = eps.IF_CLOSE()
                form_factura.Close()

            Finally

                nError = eps.IF_CLOSE()

            End Try

        End Sub

        Public Sub imprime_factura_B_fiscal_h715f()

            Try

                ''''''''''''''''''''' imprime factura B en fiscal hasar 715f ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                form_factura.AxHASAR1.Baudios = Me.baude_rate
                form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715

                form_factura.AxHASAR1.ReintentoConstante = True
                form_factura.AxHASAR1.Comenzar()
                form_factura.AxHASAR1.TratarDeCancelarTodo()

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                If RTrim(form_factura.txt_iva_solo.Text) = "Monotributo" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.MONOTRIBUTO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = "Consumidor Final" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.CONSUMIDOR_FINAL, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = "Exento" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_EXENTO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = " No Categorizado" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.NO_CATEGORIZADO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = " No Inscripto" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_NO_INSCRIPTO, form_factura.txt_direccion.Text)

                form_factura.AxHASAR1.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_FACTURA_B)
                form_factura.AxHASAR1.DescripcionesLargas = True

                form_factura.AxHASAR1.BorrarFantasiaEncabezadoCola(False, True, True)

                form_factura.AxHASAR1.set_Encabezado(11, "Forma pago:" & " " & form_factura.cmb_forma_pago.Text)
                form_factura.AxHASAR1.get_Encabezado(11)
                form_factura.AxHASAR1.set_Encabezado(12, "Numero Control:" & " " & form_factura.txt_numero.Text)
                form_factura.AxHASAR1.get_Encabezado(12)
                form_factura.AxHASAR1.set_Encabezado(13, "        " & "¡¡ GRACIAS X SU COMPRA !!")
                form_factura.AxHASAR1.get_Encabezado(13)

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    form_factura.AxHASAR1.ImpuestoInternoFijo = True

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    form_factura.AxHASAR1.ImprimirItem(des, cant, p_civa, ivas, imp)

                Next


                form_factura.AxHASAR1.CerrarComprobanteFiscal()
                form_factura.AxHASAR1.Finalizar()

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            End Try

        End Sub

        Public Sub imprime_factura_A_fiscal_h715f()

            Try

                ''''''''''''''''''''' imprime factura A en fiscal hasar 715f ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                form_factura.AxHASAR1.Baudios = Me.baude_rate
                form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715

                form_factura.AxHASAR1.ReintentoConstante = True
                form_factura.AxHASAR1.Comenzar()
                form_factura.AxHASAR1.TratarDeCancelarTodo()

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO, form_factura.txt_direccion.Text)
                form_factura.AxHASAR1.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_FACTURA_A)
                form_factura.AxHASAR1.DescripcionesLargas = True

                form_factura.AxHASAR1.BorrarFantasiaEncabezadoCola(False, True, True)

                form_factura.AxHASAR1.set_Encabezado(11, "Forma pago:" & " " & form_factura.cmb_forma_pago.Text)
                form_factura.AxHASAR1.get_Encabezado(11)
                form_factura.AxHASAR1.set_Encabezado(12, "Numero Control:" & " " & form_factura.txt_numero.Text)
                form_factura.AxHASAR1.get_Encabezado(12)
                form_factura.AxHASAR1.set_Encabezado(13, "        " & "¡¡ GRACIAS X SU COMPRA !!")
                form_factura.AxHASAR1.get_Encabezado(13)

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    form_factura.AxHASAR1.ImpuestoInternoFijo = True

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    form_factura.AxHASAR1.ImprimirItem(des, cant, p_civa, ivas, imp)

                Next


                form_factura.AxHASAR1.CerrarComprobanteFiscal()
                form_factura.AxHASAR1.Finalizar()

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            End Try

        End Sub

        Public Sub imprime_Nota_credito_A_fiscal_h715f()

            Try

                ''''''''''''''''''''' imprime factura A en fiscal hasar 715f ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                form_factura.AxHASAR1.Baudios = Me.baude_rate
                form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715

                form_factura.AxHASAR1.ReintentoConstante = True
                form_factura.AxHASAR1.Comenzar()
                form_factura.AxHASAR1.TratarDeCancelarTodo()

                Dim cuit As String = Replace(form_factura.txt_cuit.Text, "-", "")

                Dim FS As String = Chr(28)
                Dim comando As String = Chr(147) & FS & "1" & FS & form_factura.txt_numero.Text
                form_factura.AxHASAR1.Enviar(comando)

                form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO, form_factura.txt_direccion.Text)
                form_factura.AxHASAR1.AbrirDNFH(FiscalPrinterLib.DocumentosNoFiscales.TICKET_NOTA_CREDITO_A)
                form_factura.AxHASAR1.DescripcionesLargas = True

                form_factura.AxHASAR1.BorrarFantasiaEncabezadoCola(False, True, True)

                form_factura.AxHASAR1.set_Encabezado(11, "Forma pago:" & " " & form_factura.cmb_forma_pago.Text)
                form_factura.AxHASAR1.get_Encabezado(11)
                form_factura.AxHASAR1.set_Encabezado(12, "Numero Control:" & " " & form_factura.txt_numero.Text)
                form_factura.AxHASAR1.get_Encabezado(12)
                form_factura.AxHASAR1.set_Encabezado(13, "        " & "¡¡ GRACIAS X SU COMPRA !!")
                form_factura.AxHASAR1.get_Encabezado(13)

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    form_factura.AxHASAR1.ImpuestoInternoFijo = True

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    form_factura.AxHASAR1.ImprimirItem(des, cant, p_civa, ivas, imp)

                Next

                form_factura.AxHASAR1.CerrarDNFH()
                form_factura.AxHASAR1.Finalizar()

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            End Try

        End Sub

        Public Sub imprime_N_credito_B_fiscal_h715f()

            Try

                ''''''''''''''''''''' imprime nota credito B en fiscal hasar 715f ''''''''''''''''''''''''''

                Form_tipo_pago.cmd_acepta.Enabled = False
                Form_tipo_pago.cmd_cancela.Enabled = False
                Form_tipo_pago.Enabled = False
                form_factura.Enabled = False

                form_factura.AxHASAR1.Puerto = Me.Puerto_Com
                form_factura.AxHASAR1.Baudios = Me.baude_rate
                form_factura.AxHASAR1.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715

                form_factura.AxHASAR1.ReintentoConstante = True
                form_factura.AxHASAR1.Comenzar()
                form_factura.AxHASAR1.TratarDeCancelarTodo()

                Dim cuit As String = ""
                If RTrim(form_factura.txt_iva_solo.Text) <> "Consumidor Final" Then cuit = Replace(form_factura.txt_cuit.Text, "-", "")

                If RTrim(form_factura.txt_iva_solo.Text) = "Monotributo" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.MONOTRIBUTO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = "Consumidor Final" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, "222222222", FiscalPrinterLib.TiposDeDocumento.TIPO_NINGUNO, FiscalPrinterLib.TiposDeResponsabilidades.CONSUMIDOR_FINAL, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = "Exento" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_EXENTO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = " No Categorizado" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.NO_CATEGORIZADO, form_factura.txt_direccion.Text)
                If RTrim(form_factura.txt_iva_solo.Text) = " No Inscripto" Then form_factura.AxHASAR1.DatosCliente(form_factura.txt_cliente.Text, cuit, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_NO_INSCRIPTO, form_factura.txt_direccion.Text)

                Dim FS As String = Chr(28)
                Dim comando As String = Chr(147) & FS & "1" & FS & form_factura.txt_numero.Text
                form_factura.AxHASAR1.Enviar(comando)

                form_factura.AxHASAR1.AbrirDNFH(FiscalPrinterLib.DocumentosNoFiscales.TICKET_NOTA_CREDITO_B)
                form_factura.AxHASAR1.DescripcionesLargas = True

                form_factura.AxHASAR1.BorrarFantasiaEncabezadoCola(False, True, True)

                form_factura.AxHASAR1.set_Encabezado(11, "Forma pago:" & " " & form_factura.cmb_forma_pago.Text)
                form_factura.AxHASAR1.get_Encabezado(11)
                form_factura.AxHASAR1.set_Encabezado(12, "Numero Control:" & " " & form_factura.txt_numero.Text)
                form_factura.AxHASAR1.get_Encabezado(12)
                form_factura.AxHASAR1.set_Encabezado(13, "        " & "¡¡ GRACIAS X SU COMPRA !!")
                form_factura.AxHASAR1.get_Encabezado(13)

                For i = 0 To form_factura.DataGridView1.Rows.Count - 2

                    ivas = form_factura.DataGridView1.Rows(i).Cells(10).Value
                    descuento = form_factura.DataGridView1.Rows(i).Cells(5).Value.ToString
                    cant = form_factura.DataGridView1.Rows(i).Cells(2).Value
                    monto = form_factura.DataGridView1.Rows(i).Cells(3).Value
                    imp = (form_factura.DataGridView1.Rows(i).Cells(7).Value / cant)
                    des = form_factura.DataGridView1.Rows(i).Cells(1).Value.ToString

                    form_factura.AxHASAR1.ImpuestoInternoFijo = True

                    If descuento = "" Then
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                    Else
                        p_civa = Format(((monto * ivas) / 100 + monto), "0.00")
                        p_civa = Format((p_civa * descuento) / 100 + p_civa, "0.00")
                    End If

                    If imp > 0 Then p_civa = Format(p_civa + imp, "0.00")

                    form_factura.AxHASAR1.ImprimirItem(des, cant, p_civa, ivas, imp)

                Next


                form_factura.AxHASAR1.CerrarDNFH()
                form_factura.AxHASAR1.Finalizar()

            Catch ex As Exception

                MsgBox(Err.Description, MsgBoxStyle.Exclamation, "PyM Soft")
                form_factura.err_1 = 1
                msale_factura = 1
                form_factura.Close()

            End Try

        End Sub

    End Class

End Namespace
