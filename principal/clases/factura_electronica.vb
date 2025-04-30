Imports System.Data.SqlClient
Imports System.Net
Imports System.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography.Pkcs
Imports System.IO
Imports pym.WSFEV1

Namespace pymsoft

    Public Class factura_electronica

        ' Valores por defecto, globales en esta clase
        'Const url_wsaa As String = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL" ' Homologación
        Const url_wsaa As String = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl" '(produccion)
        'Const url_servicio As String = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx"
        Const url_servicio As String = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
        Const DEFAULT_SERVICIO As String = "wsfe"
        'Dim DEFAULT_CERTSIGNER As String = Application.StartupPath & "\certificado.pfx"
        Const DEFAULT_PROXY As String = Nothing
        Const DEFAULT_PROXY_USER As String = Nothing
        Const DEFAULT_PROXY_PASSWORD As String = ""
        Const DEFAULT_VERBOSE As Boolean = True
        Private _ultimoNroComprobante As Integer = 0
        Private _ultimoCAE As String = ""
        Private _ultimoVencimientoCAE As String = ""
        Private _respuestaAfip As String = ""
        Public sign As String = ""
        Public token As String = ""

        Public Shared VerboseMode As Boolean = False

        Public UniqueId As UInt32 ' Entero de 32 bits sin signo que identifica el requerimiento
        Public GenerationTime As DateTime ' Momento en que fue generado el requerimiento
        Public ExpirationTime As DateTime ' Momento en el que expira la solicitud
        Public Service As String ' Identificacion del WSN para el cual se solicita el TA
        Public XmlLoginTicketRequest As XmlDocument = Nothing
        Public XmlLoginTicketResponse As XmlDocument = Nothing
        Public RutaDelCertificadoFirmante As String
        Public XmlStrLoginTicketRequestTemplate As String = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>"
        Private _verboseMode As Boolean = True
        Private Shared _globalUniqueID As UInt32 = 0 ' OJO! NO ES THREAD-SAFE

        Private conex As SqlConnection
        Private coman As SqlCommand
        Private comando As SqlDataAdapter
        Private tb As DataTable

        Private diferencia_nocturna As TimeSpan
        Private horaentrada As DateTime
        Private horasalida As DateTime
        Private hora As Integer

        Private mconcepto, mtipo_doc, mnro_doc, mtipo_cbte, mpunto_vta,
                mcbt_desde, mcbt_hasta, mimp_total, mimp_tot_conc, mimp_neto,
                mimp_iva, mimp_trib, mimp_op_ex, mfecha_cbte, mfecha_venc_pago,
                mfecha_serv_desde, mfecha_serv_hasta,
                mmoneda_id, mmoneda_ctz, mtipoiva As String
        Private tipo, pto_vta, nro, fecha, cbte_nro As String
        Private id, Desc, base_imp, alic, importe As String
        Private cae As String
        Private estado As Boolean
        Private mcae As String
        Private mfec_cae As String
        Private multimonumero As String
        Private mimportecomprobante As String
        Private mneto10 As String
        Private mneto21 As String
        Private mexento As String
        Private mnumerosdistintos As Boolean
        Private mnumeroaplica As String
        Private Shared WSAA As Object, WSFEv1 As Object
        Private ms As New IO.MemoryStream
        Private mcondicionivareceptor As Integer

        ' Propiedades públicas
        Public Property RespuestaAfip()
            Set(ByVal value)
                _respuestaAfip = value
            End Set
            Get
                Return _respuestaAfip
            End Get
        End Property

        ' Propiedades públicas
        Public ReadOnly Property UltimoNroComprobante() As Integer
            Get
                Return _ultimoNroComprobante
            End Get
        End Property

        Public ReadOnly Property UltimoCAE() As String
            Get
                Return _ultimoCAE
            End Get
        End Property

        Public ReadOnly Property UltimoVencimientoCAE() As String
            Get
                Return _ultimoVencimientoCAE
            End Get
        End Property

        Public Property Condicion_IVA_recpetor()
            Set(ByVal value)
                mcondicionivareceptor = Val(value)
            End Set
            Get
                Return mcondicionivareceptor
            End Get
        End Property

        Public Property Comprobante_aplica()
            Set(ByVal value)
                mnumeroaplica = Val(value)
            End Set
            Get
                Return mnumeroaplica
            End Get
        End Property

        Public Property Exento()
            Set(ByVal value)
                mexento = Val(value)
            End Set
            Get
                Return mexento
            End Get
        End Property

        Public Property Neto_10()
            Set(ByVal value)
                mneto10 = Val(value)
            End Set
            Get
                Return mneto10
            End Get
        End Property

        Public Property Numeradores_distintos()
            Set(ByVal value)
                mnumerosdistintos = value
            End Set
            Get
                Return mnumerosdistintos
            End Get
        End Property

        Public Property Neto_21()
            Set(ByVal value)
                mneto21 = Val(value)
            End Set
            Get
                Return mneto21
            End Get
        End Property

        Public Property importe_comprobante()
            Set(ByVal value)
                mimportecomprobante = Val(value)
            End Set
            Get
                Return mimportecomprobante
            End Get
        End Property

        Public Property cae_afip()
            Set(ByVal value)
                mcae = Val(value)
            End Set
            Get
                Return mcae
            End Get
        End Property

        Public Property ultimo_numero_afip()
            Set(ByVal value)
                multimonumero = Val(value)
            End Set
            Get
                Return multimonumero
            End Get
        End Property

        Public Property Fecha_cae()
            Set(ByVal value)
                mfec_cae = Val(value)
            End Set
            Get
                Return mfec_cae
            End Get
        End Property

        Public Property Concepto()
            Set(ByVal value)
                mconcepto = Val(value)
            End Set
            Get
                Return mconcepto
            End Get
        End Property

        Public Property Tipo_documento()
            Set(ByVal value)
                mtipo_doc = Val(value)
            End Set
            Get
                Return mtipo_doc
            End Get
        End Property

        Public Property Numero_documento()
            Set(ByVal value)
                mnro_doc = Val(value)
            End Set
            Get
                Return mnro_doc
            End Get
        End Property

        Public Property Tipo_comprobante()
            Set(ByVal value)
                mtipo_cbte = Val(value)
            End Set
            Get
                Return mtipo_cbte
            End Get
        End Property

        Public Property Punto_venta()
            Set(ByVal value)
                mpunto_vta = Val(value)
            End Set
            Get
                Return mpunto_vta
            End Get
        End Property

        Public Property Comprobante_desde()
            Set(ByVal value)
                mcbt_desde = Val(value)
            End Set
            Get
                Return mcbt_desde
            End Get
        End Property

        Public Property Comprobante_hasta()
            Set(ByVal value)
                mcbt_hasta = Val(value)
            End Set
            Get
                Return mcbt_hasta
            End Get
        End Property

        Public Property Importe_total()
            Set(ByVal value)
                mimp_total = Val(value)
            End Set
            Get
                Return mimp_total
            End Get
        End Property

        Public Property Importe_total_conc()
            Set(ByVal value)
                mimp_tot_conc = "0.00"
            End Set
            Get
                Return mimp_tot_conc
            End Get
        End Property

        Public Property Importe_neto()
            Set(ByVal value)
                mimp_neto = Val(value)
            End Set
            Get
                Return mimp_neto
            End Get
        End Property

        Public Property Importe_iva()
            Set(ByVal value)
                mimp_iva = Val(value)
            End Set
            Get
                Return mimp_iva
            End Get
        End Property

        Public Property Importe_trib()
            Set(ByVal value)
                mimp_trib = "0.00"
            End Set
            Get
                Return mimp_trib
            End Get
        End Property

        Public Property Importe_op_ex()
            Set(ByVal value)
                mimp_op_ex = "0.00"
            End Set
            Get
                Return mimp_op_ex
            End Get
        End Property

        Public Property Fecha_comprobante()
            Set(ByVal value)
                mfecha_cbte = value
            End Set
            Get
                Return mfecha_cbte
            End Get
        End Property

        Public Property Fecha_vencimiento_pago()
            Set(ByVal value)
                mfecha_venc_pago = ""
            End Set
            Get
                Return mfecha_venc_pago
            End Get
        End Property

        Public Property Fecha_servidor_desde()
            Set(ByVal value)
                mfecha_serv_desde = ""
            End Set
            Get
                Return mfecha_serv_desde
            End Get
        End Property

        Public Property Fecha_servidor_hasta()
            Set(ByVal value)
                mfecha_serv_hasta = ""
            End Set
            Get
                Return mfecha_serv_hasta
            End Get
        End Property

        Public Property Tipo_moneda()
            Set(ByVal value)
                mmoneda_id = "PES"
            End Set
            Get
                Return "PES"
            End Get
        End Property

        Public Property Cotizacion_moneda()
            Set(ByVal value)
                mmoneda_ctz = "1.00"
            End Set
            Get
                Return "1.00"
            End Get
        End Property

        Public Property Tipo_iva()
            Set(ByVal value)
                mtipoiva = Val(value)
            End Set
            Get
                Return mtipoiva
            End Get
        End Property

        Private Sub ObtenerCAE(ByVal cuit As String, ByVal crt As String, ByVal key As String)

            Dim wsdl As String, proxy As String, cache As String
            Dim ok

            If WSFEv1 Is Nothing Then
                Console.WriteLine("Crear objeto interface Web Service de Factura Electrónica de Mercado Interno")
                WSFEv1 = CreateObject("WSFEv1")
            End If

            Try
                Console.WriteLine(WSFEv1.Version)
                Console.WriteLine(WSFEv1.InstallDir)

                'obtengo el sgn y token almacenados
                conex = conecta()
                tb = New DataTable
                tb.Clear()

                comando = New SqlDataAdapter("select Signn,Token,hora_token from Numerador where talon = 1", conex)
                comando.Fill(tb)
                comando.Dispose()

                horaentrada = Date.Now
                horasalida = tb.Rows(0).Item(2)

                hora = DateDiff(DateInterval.Hour, horaentrada, horasalida)
                hora = hora * (-1)

                If Trim(tb.Rows(0).Item(0)) = "" Or Trim(tb.Rows(0).Item(1)) = "" Or hora >= 11 Then
                    Autenticar(crt, key)
                    actualiza_sign_token(WSAA.Sign, WSAA.Token)
                    WSFEv1.Token = WSAA.Token
                    WSFEv1.Sign = WSAA.Sign
                Else
                    ' Setear tocken y sing de autorización (pasos previos)
                    WSFEv1.Token = Trim(tb.Rows(0).Item(1))
                    WSFEv1.Sign = Trim(tb.Rows(0).Item(0))
                End If

                WSFEv1.Cuit = RTrim(Replace(cuit, "-", ""))

                ' Conectar al Servicio Web de Facturación
                proxy = "" ' "usuario:clave@localhost:8000"
                'wsdl = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL"  ' homologación
                wsdl = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL" '(produccion)
                cache = "" 'Path
                ok = WSFEv1.Conectar(cache, wsdl, proxy)

                REM ' mostrar bitácora de depuración:
                Console.WriteLine(WSFEv1.DebugLog)

                REM ' Establezco los valores de la factura a autorizar:
                'Me.Tipo_comprobante = 6
                'Me.Punto_venta = 4002

            Catch

                ' Muestro los errores
                If WSFEv1.Traceback <> "" Then
                    MsgBox(WSFEv1.Traceback, vbExclamation, "Error")
                End If

            End Try
        End Sub

        Public Function verifica_sign_token(rutaPfx As String, clavePfx As String) As Boolean

            Dim est As Boolean

            'obtengo el sgn y token almacenados
            conex = conecta()
            tb = New DataTable
            tb.Clear()

            comando = New SqlDataAdapter("select Signn,Token,hora_token from Numerador where talon = 1", conex)
            comando.Fill(tb)
            comando.Dispose()

            horaentrada = Date.Now
            horasalida = tb.Rows(0).Item(2)

            hora = DateDiff(DateInterval.Hour, horaentrada, horasalida)
            hora = hora * (-1)

            If Trim(tb.Rows(0).Item(0)) = "" Or Trim(tb.Rows(0).Item(1)) = "" Or hora >= 11 Then
                Dim Ta As String = inicializa_ticket(rutaPfx, clavePfx)
                If Ta.ToString.Substring(0, 2) <> "99" Then
                    XmlLoginTicketResponse = New XmlDocument()
                    XmlLoginTicketResponse.LoadXml(Ta)
                    sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText
                    token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText
                    actualiza_sign_token(sign, token)
                    est = True
                Else
                    est = False
                End If
            Else
                ' Setear tocken y sing de autorización (pasos previos)
                token = Trim(tb.Rows(0).Item(1))
                sign = Trim(tb.Rows(0).Item(0))
                est = True
            End If

            Return est
            'WSFEv1.Cuit = Trim(Replace(cuit, "-", ""))

        End Function

        Private Sub actualiza_sign_token(ByVal Sign, ByVal Token)

            Try

                conex = New SqlConnection
                conex = conecta()
                If conex.State = ConnectionState.Closed Then conex.Open()

                coman = New SqlCommand("Update numerador set Token = '" & Trim(Token) & "',Signn = '" & Trim(Sign) & "',hora_token = '" & Date.Now.ToString("yyyyMMdd HH:mm:ss") & "' where talon = 1", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                If conex.State = ConnectionState.Open Then conex.Close()

            End Try

        End Sub

        Private Sub Autenticar(ByVal crt As String, ByVal key As String)
            Dim Path As String
            Dim tra As String, cms As String, ta As String
            Dim wsdl As String, proxy As String, cache As String = ""
            Dim certificado As String, claveprivada As String

            'Console.WriteLine(WSAA.Version)

            Try
                ' Una vez obtenido, se puede usar el mismo token y sign por 12 horas
                ' (este período se puede cambiar)


                'Console.WriteLine("Generar un Ticket de Requerimiento de Acceso (TRA) para WSFEv1")
                tra = WSAA.CreateTRA("wsfe")
                Console.WriteLine(tra)

                ' Especificar la ubicacion de los archivos certificado y clave privada
                Path = Environment.CurrentDirectory() + "\"
                ' Certificado: certificado es el firmado por la AFIP
                ' ClavePrivada: la clave privada usada para crear el certificado
                certificado = RTrim(crt) ' "prueba.crt" ' certificado de prueba
                claveprivada = RTrim(key) '"prueba.key" ' clave privada de prueba

                Console.WriteLine("Generar el mensaje firmado (CMS)")
                cms = WSAA.SignTRA(tra, Path + certificado, Path + claveprivada)
                Console.WriteLine(cms)

                Console.WriteLine("Llamar al web service para autenticar:")
                proxy = "" '"usuario:clave@localhost:8000"
                'wsdl = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl" ' Homologación
                wsdl = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl" '(produccion)
                WSAA.Conectar(cache, wsdl, proxy)
                ta = WSAA.LoginCMS(cms)

            Catch
                ' Muestro los errores
                If WSAA.Excepcion <> "" Then
                    MsgBox(WSAA.Traceback, vbExclamation, WSAA.Excepcion)
                End If

                MessageBox.Show(WSAA.Excepcion.ToString, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Sub

        Public Sub consulta_numero(ByVal cuit, ByVal crt, ByVal key, ByVal numero)

            'Console.WriteLine("DEMO Interfaz PyAfipWs WSFEv1 para vb.net")

            ' Crear objeto interface Web Service Autenticación y Autorización
            If WSAA Is Nothing Then
                WSAA = CreateObject("WSAA")
            End If

            ObtenerCAE(cuit, crt, key)

            WSFEv1.CompConsultar(Me.Tipo_comprobante, Me.Punto_venta, Me.ultimo_numero_afip)
            cae_afip = WSFEv1.cae
            importe_comprobante = WSFEv1.impTotal()
            Fecha_cae = WSFEv1.Vencimiento()

        End Sub

        Public Sub consulta_ultimo_numero(ByVal cuit, ByVal crt, ByVal key)

            'Console.WriteLine("DEMO Interfaz PyAfipWs WSFEv1 para vb.net")

            ' Crear objeto interface Web Service Autenticación y Autorización
            If WSAA Is Nothing Then
                WSAA = CreateObject("WSAA")
            End If

            ObtenerCAE(cuit, crt, key)

            Me.ultimo_numero_afip = WSFEv1.CompUltimoAutorizado(Me.Tipo_comprobante, Me.Punto_venta)

        End Sub

        Public Function carga_factura_electronica(ByVal iva10, ByVal iva21, ByVal letra_fact, ByVal cuit_empresa, ByVal crt, ByVal key, ByVal numero_comprobante, ByVal condicion_iva_receptor) As Boolean

            Dim cont As Short = 0
            Dim ok

            estado = False

            'Console.WriteLine("DEMO Interfaz PyAfipWs WSFEv1 para vb.net")

            ' Crear objeto interface Web Service Autenticación y Autorización
            If WSAA Is Nothing Then
                WSAA = CreateObject("WSAA")
            End If

            ObtenerCAE(cuit_empresa, crt, key)

            Try

                REM ' Establezco los valores de la factura a autorizar:
                'Me.Tipo_comprobante = 6
                'Me.Punto_venta = 4002
                cbte_nro = WSFEv1.CompUltimoAutorizado(Me.Tipo_comprobante, Me.Punto_venta)

                If cbte_nro = "" Then
                    Me.Comprobante_desde = 1            ' no hay comprobantes emitidos
                    Me.Comprobante_hasta = 1
                Else
                    Me.Comprobante_desde = CLng(cbte_nro + 1)   ' convertir a entero largo
                    Me.Comprobante_hasta = CLng(cbte_nro + 1)
                End If

                If Trim(numero_comprobante) <> Trim(Me.Comprobante_desde) Then
                    Me.Numeradores_distintos = True
                    Exit Function
                Else
                    Me.Numeradores_distintos = False
                End If

                ''' nuevos cambios segun RG5614 y RG 5616 ''''''''''''''''''''''
                If condicion_iva_receptor = "Consumidor Final" Then
                    Me.Condicion_IVA_recpetor = 5
                End If
                If condicion_iva_receptor = "Responsable Inscripto" Then
                    Me.Condicion_IVA_recpetor = 1
                End If
                If condicion_iva_receptor = "Monotributo" Then
                    Me.Condicion_IVA_recpetor = 6
                End If
                If condicion_iva_receptor = "Exento" Then
                    Me.Condicion_IVA_recpetor = 4
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ok = WSFEv1.CrearFactura(Me.Concepto, Me.Tipo_documento, Me.Numero_documento, Me.Tipo_comprobante, Me.Punto_venta,
                        Me.Comprobante_desde, Me.Comprobante_hasta, Me.Importe_total, Me.Importe_total_conc, Me.Importe_neto,
                        Me.Importe_iva, Me.Importe_trib, Me.Importe_op_ex, Me.Fecha_comprobante, Me.Fecha_vencimiento_pago,
                        Me.Fecha_servidor_desde, Me.Fecha_servidor_hasta, Me.Tipo_moneda, Me.Cotizacion_moneda, Nothing, Nothing)

                ok = WSFEv1.EstablecerCampoFactura("cancela_misma_moneda_ext", "N")
                ok = WSFEv1.EstablecerCampoFactura("condicion_iva_receptor_id", Me.Condicion_IVA_recpetor)

                If letra_fact <> "C" Then

                    ' si es credito/debito debo informar el comprobante al cual aplica
                    If Me.Tipo_comprobante = 3 Or Me.Tipo_comprobante = 8 Or Me.Tipo_comprobante = 2 Or Me.Tipo_comprobante = 7 Then
                        If Me.Tipo_comprobante = 3 Or Me.Tipo_comprobante = 2 Then tipo = 1
                        If Me.Tipo_comprobante = 8 Or Me.Tipo_comprobante = 7 Then tipo = 6
                        pto_vta = Me.Punto_venta
                        nro = Me.Comprobante_aplica
                        ok = WSFEv1.AgregarCmpAsoc(tipo, pto_vta, nro)
                    End If

                    If iva21 <> 0 Then
                        ' Agrego tasas de IVA
                        id = 5 '- -21%
                        base_imp = Me.Neto_21
                        importe = iva21
                        ok = WSFEv1.AgregarIva(id, base_imp, importe)
                    End If

                    If iva10 <> 0 Then
                        ' Agrego tasas de IVA
                        id = 4 ' -- 10.5%
                        base_imp = Me.Neto_10
                        importe = iva10
                        ok = WSFEv1.AgregarIva(id, base_imp, importe)
                    End If

                    If mexento <> 0 Then

                        ' Agrego tasas de IVA
                        id = 3 ' -- 0% exento
                        base_imp = Me.Exento
                        importe = "0.00" 'Me.Importe_iva
                        ok = WSFEv1.AgregarIva(id, base_imp, importe)

                    End If

                End If

                ' Habilito reprocesamiento automático (predeterminado):
                WSFEv1.Reprocesar = True

                ' Solicito CAE:
                cae = WSFEv1.CAESolicitar()

                ' Imprimo pedido y respuesta XML para depuración (errores de formato)
                If cae = "" Then
                    MsgBox(WSFEv1.XmlRequest)
                    MsgBox(WSFEv1.XmlResponse)
                End If

                Me.cae_afip = cae
                Me.Fecha_cae = WSFEv1.Vencimiento

                form_factura.lbl_cae.Text = cae
                form_factura.lbl_venc_cae.Text = WSFEv1.Vencimiento

                'Console.WriteLine("Resultado" & WSFEv1.Resultado)
                'Console.WriteLine("CAE", WSFEv1.CAE)
                'Console.WriteLine("Numero de comprobante:" & WSFEv1.CbteNro)
                'Console.WriteLine("Reprocesar:" & WSFEv1.Reprocesar)
                'Console.WriteLine("Reproceso:" & WSFEv1.Reproceso)
                'Console.WriteLine("EmisionTipo:" & WSFEv1.EmisionTipo)

                'MessageBox.Show("Resultado:" & WSFEv1.Resultado & " CAE: " & cae & " Venc: " & WSFEv1.Vencimiento & " Reproceso: " & WSFEv1.Reproceso, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If WSFEv1.ErrMsg <> "" Then
                    cont = cont + 1
                    'MessageBox.Show(cont, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MsgBox(WSFEv1.ErrMsg, vbExclamation, "Errores")
                End If

                'MessageBox.Show(estado, "msj", MessageBoxButtons.OK)

                If WSFEv1.Obs <> "" Then
                    'cont = cont + 1
                    'MessageBox.Show(cont, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MsgBox(WSFEv1.Obs, vbExclamation, "Observaciones")
                End If

                'MessageBox.Show(estado, "msj", MessageBoxButtons.OK)

            Catch ex As Exception

                ' Muestro los errores
                If WSFEv1.Traceback <> "" Then
                    MsgBox(WSFEv1.Traceback, vbExclamation, "Error")
                End If

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                cont = cont + 1


            End Try

            If cont = 0 Then estado = True

            Return estado

        End Function

        Function gerena_QR_factura(ByVal cuit_empresa, ByVal qr) As Byte()

            Dim cadena, cadenaBase64 As String

            cadena = "{" & "Ver:" & 1 & ","
            cadena = cadena & "fecha:" & Me.Fecha_comprobante.ToString.Substring(0, 4) & "-" & Me.Fecha_comprobante.ToString.Substring(4, 2) & "-" & Me.Fecha_comprobante.ToString.Substring(6, 2) & ","
            cadena = cadena & "cuit:" & Replace(cuit_empresa, "-", "") & ","
            cadena = cadena & "ptoVta:" & Me.Punto_venta & ","
            cadena = cadena & "tipoCmp:" & Me.Tipo_comprobante & ","
            cadena = cadena & "numeroCmp:" & Me.Comprobante_desde & ","
            cadena = cadena & "importe:" & Me.Importe_total & ","
            cadena = cadena & "moneda:" & "PES" & ","
            cadena = cadena & "ctz:" & 1 & ","
            cadena = cadena & "tipoDocRec:" & Me.Tipo_documento & ","
            cadena = cadena & "nroDocRec:" & Me.Numero_documento & ","
            cadena = cadena & "tipoCodAut:" & "E" & ","
            cadena = cadena & "codAut:" & Me.cae_afip & "}"

            Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(cadena)
            cadenaBase64 = Convert.ToBase64String(myByte)

            qr.Text = "https://www.afip.gob.ar/fe/qr/?p=" & cadenaBase64
            Dim img1 As Image = DirectCast(qr.Image.Clone, Image)
            img1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            'Dim b As Byte() = ms.ToArray()

            Return ms.ToArray()

            'conex = conecta()
            'conex.Open()

            'Dim sql As String = "Insert into Imagen (valor) Values(@miImagen)"
            'Dim cmd As New SqlClient.SqlCommand(sql, conex)
            'Dim param As New SqlClient.SqlParameter("@miImagen", SqlDbType.Image)
            'param.Value = b
            'cmd.Parameters.Add(param)
            'cmd.ExecuteNonQuery()

            'conex.Close()

        End Function


        ''' <summary>
        ''' '''''''''''''''''''''''''''''''''''''    CLASE NUEVA PARA WEB SERVICE SIN PYAFIPWS  '''''''''''''''''''''''''''''''''''''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function inicializa_ticket(rutaPfx As String, clavePfx As String) As Object

            Dim strUrlWsaaWsdl As String = url_wsaa 'wsaa de homologacion
            Dim strIdServicioNegocio As String = DEFAULT_SERVICIO
            Dim strRutaCertSigner As String = rutaPfx 'DEFAULT_CERTSIGNER
            Dim strPasswordSecureString As New SecureString
            Dim strProxy As String = DEFAULT_PROXY
            Dim strProxyUser As String = DEFAULT_PROXY_USER
            Dim strProxyPassword As String = DEFAULT_PROXY_PASSWORD
            Dim blnVerboseMode As Boolean = DEFAULT_VERBOSE


            ' Argumentos OK, entonces procesar normalmente...
            Dim objTicketRespuesta As factura_electronica
            Dim strTicketRespuesta As String

            Try

                objTicketRespuesta = New factura_electronica


                strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(strIdServicioNegocio, strUrlWsaaWsdl, strRutaCertSigner, strPasswordSecureString, strProxy, strProxyUser, strProxyPassword, blnVerboseMode, clavePfx)

            Catch excepcionAlObtenerTicket As Exception

                Return "99" & " " & excepcionAlObtenerTicket.Message

            End Try
            Return strTicketRespuesta
        End Function

        Public Shared Function FirmaBytesMensaje(
        ByVal argBytesMsg As Byte(),
        ByVal argCertFirmante As X509Certificate2
        ) As Byte()
            Const ID_FNC As String = "[FirmaBytesMensaje]"
            Try
                ' Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
                Dim infoContenido As New ContentInfo(argBytesMsg)
                Dim cmsFirmado As New SignedCms(infoContenido)

                ' Creo objeto CmsSigner que tiene las caracteristicas del firmante
                Dim cmsFirmante As New CmsSigner(argCertFirmante)
                cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly

                If VerboseMode Then
                    Console.WriteLine(ID_FNC + "***Firmando bytes del mensaje...")
                End If

                ' Firmo el mensaje PKCS #7
                cmsFirmado.ComputeSignature(cmsFirmante)

                If VerboseMode Then
                    Console.WriteLine(ID_FNC + "***OK mensaje firmado")
                End If

                ' Encodeo el mensaje PKCS #7.
                Return cmsFirmado.Encode()
            Catch excepcionAlFirmar As Exception
                Throw New Exception(ID_FNC + "***Error al firmar: " & excepcionAlFirmar.Message)
                Return Nothing
            End Try
        End Function

        Public Shared Function ObtieneCertificadoDesdeArchivo(
    ByVal argArchivo As String,
    ByVal argPassword As SecureString,
    ByVal password As String
    ) As X509Certificate2
            Const ID_FNC As String = "[ObtieneCertificadoDesdeArchivo]"
            Dim objCert As New X509Certificate2
            Try
                If argPassword.IsReadOnly = False Then
                    objCert.Import(File.ReadAllBytes(argArchivo), password, X509KeyStorageFlags.PersistKeySet)
                Else
                    objCert.Import(File.ReadAllBytes(argArchivo))
                End If
                Return objCert
            Catch excepcionAlImportarCertificado As Exception
                Throw New Exception(ID_FNC + "***Error al leer certificado: " + excepcionAlImportarCertificado.Message)
                Return Nothing
            End Try
        End Function

        Public Function ObtenerLoginTicketResponse(
            ByVal argServicio As String,
            ByVal argUrlWsaa As String,
            ByVal argRutaCertX509Firmante As String,
            ByVal argPassword As SecureString,
            ByVal argProxy As String,
            ByVal argProxyUser As String,
            ByVal argProxyPassword As String,
            ByVal argVerbose As Boolean,
            ByVal password As String
                ) As String

            Const ID_FNC As String = "[ObtenerLoginTicketResponse]"

            Me.RutaDelCertificadoFirmante = argRutaCertX509Firmante
            Me._verboseMode = argVerbose
            'Me.VerboseMode = argVerbose

            Dim cmsFirmadoBase64 As String
            Dim loginTicketResponse As String
            Dim xmlNodoUniqueId As XmlNode
            Dim xmlNodoGenerationTime As XmlNode
            Dim xmlNodoExpirationTime As XmlNode
            Dim xmlNodoService As XmlNode

            ' PASO 1: Genero el Login Ticket Request
            Try
                _globalUniqueID += 1

                XmlLoginTicketRequest = New XmlDocument()
                XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate)

                xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId")
                xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime")
                xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime")
                xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service")
                xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s")
                xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s")
                xmlNodoUniqueId.InnerText = CStr(_globalUniqueID)
                xmlNodoService.InnerText = argServicio
                Me.Service = argServicio

                If Me._verboseMode Then
                    Console.WriteLine(XmlLoginTicketRequest.OuterXml)
                End If

            Catch excepcionAlGenerarLoginTicketRequest As Exception
                Throw New Exception(ID_FNC + "***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace)
            End Try

            ' PASO 2: Firmo el Login Ticket Request
            Try
                If Me._verboseMode Then
                    Console.WriteLine(ID_FNC + "***Leyendo certificado: {0}", RutaDelCertificadoFirmante)
                End If

                Dim certFirmante As X509Certificate2 = ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, argPassword, password)

                If Me._verboseMode Then
                    Console.WriteLine(ID_FNC + "***Firmando: ")
                    Console.WriteLine(XmlLoginTicketRequest.OuterXml)
                End If

                ' Convierto el login ticket request a bytes, firmo el msg y convierto a Base64
                Dim EncodedMsg As Encoding = Encoding.UTF8
                Dim msgBytes As Byte() = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml)
                Dim encodedSignedCms As Byte() = FirmaBytesMensaje(msgBytes, certFirmante)
                cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms)

            Catch excepcionAlFirmar As Exception
                Throw New Exception(ID_FNC + "***Error FIRMANDO el LoginTicketRequest: " + excepcionAlFirmar.Message)
            End Try

            ' PASO 3: Invoco al WSAA para obtener el Login Ticket Response
            Try
                If Me._verboseMode Then
                    Console.WriteLine(ID_FNC + "***Llamando al WSAA en URL: {0}", argUrlWsaa)
                    Console.WriteLine(ID_FNC + "***Argumento en el request:")
                    Console.WriteLine(cmsFirmadoBase64)
                End If

                Dim servicioWsaa As New Wsaa.LoginCMSService()
                servicioWsaa.Url = argUrlWsaa

                ' Veo si hay que salir a traves de un proxy
                If argProxy IsNot Nothing Then
                    servicioWsaa.Proxy = New WebProxy(argProxy, True)
                    If argProxyUser IsNot Nothing Then
                        Dim Credentials As New NetworkCredential(argProxyUser, argProxyPassword)
                        servicioWsaa.Proxy.Credentials = Credentials
                    End If
                End If

                loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64)

                If Me._verboseMode Then
                    Console.WriteLine(ID_FNC + "***LoguinTicketResponse: ")
                    Console.WriteLine(loginTicketResponse)
                End If

            Catch excepcionAlInvocarWsaa As Exception
                Throw New Exception(ID_FNC + "***Error INVOCANDO al servicio WSAA: " + excepcionAlInvocarWsaa.Message)
            End Try

            ' PASO 4: Analizo el Login Ticket Response recibido del WSAA
            Try
                XmlLoginTicketResponse = New XmlDocument()
                XmlLoginTicketResponse.LoadXml(loginTicketResponse)

                Me.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText)
                Me.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText)
                Me.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText)
                sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText
                token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText

            Catch excepcionAlAnalizarLoginTicketResponse As Exception
                Throw New Exception(ID_FNC + "***Error ANALIZANDO el LoginTicketResponse: " + excepcionAlAnalizarLoginTicketResponse.Message)
            End Try

            Return loginTicketResponse

        End Function

        ' Método principal para obtener el último comprobante
        Public Function ObtenerUltimoComprobanteAutorizado(ByVal sign As String, ByVal token As String, ByVal cuit As Long, ByVal cbteTipo As Integer, ByVal ptoVta As Integer) As Integer

            Try
                ' Configurar seguridad (TLS 1.2 no está disponible en .NET 2.0, usamos SSL3)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                ' Seleccionar URL según ambiente
                Dim urlServicio As String = url_servicio

                ' Crear el objeto del servicio web
                Dim wsFE As New WSFEV1.Service
                wsFE.Url = urlServicio
                wsFE.Timeout = 30000 ' 30 segundos de timeout

                ' Configurar autenticación
                Dim authRequest As New WSFEV1.FEAuthRequest
                authRequest.Token = token
                authRequest.Sign = sign
                authRequest.Cuit = cuit

                ' Configurar proxy si es necesario
                'ConfigurarProxy(wsFE)

                ' Llamar al servicio
                Dim response As WSFEV1.FERecuperaLastCbteResponse =
                    wsFE.FECompUltimoAutorizado(authRequest, ptoVta, cbteTipo)

                ' Verificar respuesta
                If response Is Nothing Then
                    RespuestaAfip = "El servicio no devolvió respuesta"
                End If

                ' Verificar errores AFIP
                If response.Errors IsNot Nothing AndAlso response.Errors.Length > 0 Then
                    Dim errorMsg As String = ""
                    For Each err As WSFEV1.Err In response.Errors
                        errorMsg &= String.Format("Código: {0} - Mensaje: {1}{2}", err.Code, err.Msg, Environment.NewLine)
                    Next
                    RespuestaAfip = "Error AFIP: " & errorMsg
                End If

                ' Retornar el número de comprobante
                Return response.CbteNro

            Catch ex As WebException
                Dim errorResponse As String = ObtenerMensajeErrorWeb(ex)
                RespuestaAfip = "Error de conexión con AFIP: " & errorResponse
            Catch ex As Exception
                RespuestaAfip = "Error al obtener último comprobante: " & ex.Message
            End Try
        End Function

        ' Método para obtener mensajes de error de WebException
        Private Function ObtenerMensajeErrorWeb(ByVal ex As WebException) As String
            Try
                If ex.Response IsNot Nothing Then
                    Using reader As New IO.StreamReader(ex.Response.GetResponseStream())
                        Return reader.ReadToEnd()
                    End Using
                Else
                    Return ex.Message
                End If
            Catch
                Return ex.Message
            End Try
        End Function

        ' Autorizar una factura electrónica (adaptado para ARCA)
        Public Function AutorizarFactura(ByVal cuit_empresa As String, ByVal cbteNro As Integer,
                                        ByVal cndIvaReceptor As String, ByVal iva10 As Double, ByVal iva21 As Double, ByVal letra_fact As String, ByVal rutaPfx As String, ByVal clavePfx As String)

            estado = False

            estado = verifica_sign_token(rutaPfx, clavePfx)

            If estado = False Then
                RespuestaAfip = "No se puede obtener el ticker de acceso"
                Return False
            End If

            cbte_nro = ObtenerUltimoComprobanteAutorizado(Me.sign, Me.token, cuit_empresa, Me.Tipo_comprobante, Me.Punto_venta)

            If cbte_nro = "" Then
                Me.Comprobante_desde = 1            ' no hay comprobantes emitidos
                Me.Comprobante_hasta = 1
            Else
                Me.Comprobante_desde = CLng(cbte_nro + 1)   ' convertir a entero largo
                Me.Comprobante_hasta = CLng(cbte_nro + 1)
            End If

            If Trim(cbteNro) <> Trim(Me.Comprobante_desde) Then
                Me.Numeradores_distintos = True
                Return False
                Exit Function
            Else
                Me.Numeradores_distintos = False
            End If

            ''' nuevos cambios segun RG5614 y RG 5616 ''''''''''''''''''''''
            If cndIvaReceptor = "Consumidor Final" Then
                Me.Condicion_IVA_recpetor = 5
            End If
            If cndIvaReceptor = "Responsable Inscripto" Then
                Me.Condicion_IVA_recpetor = 1
            End If
            If cndIvaReceptor = "Monotributo" Then
                Me.Condicion_IVA_recpetor = 6
            End If
            If cndIvaReceptor = "Exento" Then
                Me.Condicion_IVA_recpetor = 4
            End If

            ' Configurar seguridad (TLS 1.2 no está disponible en .NET 2.0, usamos SSL3)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            ' Seleccionar URL según ambiente
            Dim urlServicio As String = url_servicio

            ' Crear el objeto del servicio web
            Dim servicio As New WSFEV1.Service With {
                .Url = urlServicio,
                .Timeout = 30000
            }

            ' Obtener TA (simulado - en producción usar WSAA)
            Dim authRequest As New WSFEV1.FEAuthRequest()
            authRequest.Cuit = cuit_empresa.Trim()
            authRequest.Token = token.Trim()
            authRequest.Sign = sign.Trim()

            ' --- 3. Crear encabezado de factura (Cabecera) ---
            Dim cabecera As New FECAECabRequest()
            cabecera.CantReg = 1 ' Cantidad de facturas
            cabecera.PtoVta = Me.Punto_venta
            cabecera.CbteTipo = Me.Tipo_comprobante

            ' --- 4. Crear detalle de factura ---
            Dim detalle As New FECAEDetRequest()
            detalle.Concepto = 1 ' Productos
            detalle.DocTipo = Me.Tipo_documento ' 96 = DNI (Consumidor Final)
            detalle.DocNro = Me.Numero_documento ' N° de documento
            detalle.CbteDesde = Me.Comprobante_desde ' N° de factura desde
            detalle.CbteHasta = Me.Comprobante_hasta ' N° de factura hasta
            detalle.CbteFch = Me.Fecha_comprobante 'DateTime.Now.ToString("yyyyMMdd") ' Fecha
            detalle.ImpTotal = Me.Importe_total ' Total con IVA
            detalle.ImpTotConc = Me.Importe_total_conc ' Importe neto no gravado
            detalle.ImpNeto = Me.Importe_neto ' Importe neto
            detalle.ImpOpEx = Me.Importe_op_ex ' Importe exento
            detalle.ImpTrib = Me.Importe_trib ' Tributos
            detalle.ImpIVA = Me.Importe_iva ' IVA
            detalle.FchServDesde = Me.Fecha_servidor_desde
            detalle.FchServHasta = Me.Fecha_servidor_hasta
            detalle.FchVtoPago = Me.Fecha_vencimiento_pago
            detalle.MonId = "PES" ' Moneda (Pesos)
            detalle.MonCotiz = 1 ' Cotización (1 para pesos)
            detalle.CondicionIVAReceptorId = Me.Condicion_IVA_recpetor
            detalle.CanMisMonExt = "N"
            detalle.MonCotizSpecified = True

            If letra_fact <> "C" Then

                ' agregamos la alicuota de iva
                Dim listaIva As New List(Of AlicIva)()

                ' si es credito/debito debo informar el comprobante al cual aplica
                If Me.Tipo_comprobante = 3 Or Me.Tipo_comprobante = 8 Or Me.Tipo_comprobante = 2 Or Me.Tipo_comprobante = 7 Then

                    ' --- Agregar comprobante asociado ---
                    Dim comprobanteAsociado As New CbteAsoc()

                    If Me.Tipo_comprobante = 3 Or Me.Tipo_comprobante = 2 Then
                        comprobanteAsociado.Tipo = 1 ' Tipo de comprobante asociado (ej: 1 para Factura A)
                    End If
                    If Me.Tipo_comprobante = 8 Or Me.Tipo_comprobante = 7 Then
                        comprobanteAsociado.Tipo = 6
                    End If

                    comprobanteAsociado.PtoVta = Me.Punto_venta ' Punto de venta del comprobante asociado
                    comprobanteAsociado.Nro = Me.Comprobante_aplica ' Número del comprobante asociado
                    comprobanteAsociado.Cuit = Me.Numero_documento ' CUIT del emisor del comprobante (solo si es diferent

                    detalle.CbtesAsoc = New CbteAsoc() {comprobanteAsociado}
                    'ok = WSFEv1.AgregarCmpAsoc(tipo, pto_vta, nro)
                End If

                If iva21 <> 0 Then
                    ' Agrego tasas de IVA
                    Dim iva21ali As New AlicIva() With {.Id = 5, .BaseImp = Me.Neto_21, .Importe = iva21}
                    listaIva.Add(iva21ali)
                End If

                If iva10 <> 0 Then
                    ' Agrego tasas de IVA
                    Dim iva10ali As New AlicIva() With {.Id = 4, .BaseImp = Me.Neto_10, .Importe = iva10}
                    listaIva.Add(iva10ali)
                End If

                If mexento <> 0 Then
                    ' Agrego tasas de IVA
                    Dim iva0ali As New AlicIva() With {.Id = 3, .BaseImp = Me.Exento, .Importe = 0}
                    listaIva.Add(iva0ali)
                End If

                detalle.Iva = listaIva.ToArray()

            End If

            ' --- 5. Agregar al array de detalles ---
            ' --- Crear la colección de detalles (en este caso, solo uno) ---
            Dim detalles(0) As WSFEV1.FECAEDetRequest
            detalles(0) = detalle

            ' --- Crear la solicitud completa ---
            Dim fecaereq As New WSFEV1.FECAERequest()
            fecaereq.FeCabReq = cabecera
            fecaereq.FeDetReq = detalles

            ' --- Llamar al WebService ---
            Try
                Dim respuesta As FECAEResponse = servicio.FECAESolicitar(authRequest, fecaereq)

                ' --- Procesar respuesta CORRECTAMENTE ---
                ' Verifica primero si la operación fue exitosa
                If respuesta.Errors IsNot Nothing AndAlso respuesta.Errors.Length > 0 Then
                    ' Hubo errores
                    'Form1.txtErr.Text = respuesta.Errors(0).Msg & " (Código: " & respuesta.Errors(0).Code & ")"
                    RespuestaAfip = respuesta.Errors(0).Msg & " (Código: " & respuesta.Errors(0).Code & ")"
                    estado = False
                Else
                    ' Verificar aprobación mediante la existencia de CAE
                    If respuesta.FeDetResp IsNot Nothing AndAlso respuesta.FeDetResp.Length > 0 Then
                        If Not String.IsNullOrEmpty(respuesta.FeDetResp(0).CAE) Then
                            'Console.WriteLine("Factura autorizada:")
                            Me.cae_afip = respuesta.FeDetResp(0).CAE
                            Me.Fecha_cae = respuesta.FeDetResp(0).CAEFchVto

                            form_factura.lbl_cae.Text = Me.cae_afip
                            form_factura.lbl_venc_cae.Text = Me.Fecha_cae

                            estado = True
                            'Form1.txtErr.Text = "CAE: " & respuesta.FeDetResp(0).CAE
                            'Form1.txtErr.Text = Form1.txtErr.Text & " " & "Vencimiento: " & respuesta.FeDetResp(0).CAEFchVto
                            'Form1.txtErr.Text = Form1.txtErr.Text & " " & "Número de comprobante: " & respuesta.FeDetResp(0).CbteDesde
                        Else
                            RespuestaAfip = "La factura fue rechazada por AFIP"
                            estado = False
                        End If
                    Else
                        RespuestaAfip = "No se recibió detalle de respuesta de AFIP"
                        estado = False
                    End If
                End If
            Catch ex As Exception
                RespuestaAfip = "Error al conectar con AFIP: " & ex.Message
                If ex.InnerException IsNot Nothing Then
                    RespuestaAfip = "Detalle interno: " & ex.InnerException.Message
                End If
                estado = False
            End Try

            Return estado

        End Function

        Public Sub ConsultarFacturaAFIP(cuitEmisor As String,
            tipoComprobante As Integer,
            puntoVenta As Integer,
            numeroComprobante As Long,
            token As String,
            sign As String)
            Try
                ' Configurar el servicio
                Dim request As New FECompConsultaReq()

                ' Configurar seguridad (TLS 1.2 no está disponible en .NET 2.0, usamos SSL3)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                ' Seleccionar URL según ambiente
                Dim urlServicio As String = url_servicio

                ' Crear el objeto del servicio web
                Dim servicio As New WSFEV1.Service With {
                .Url = urlServicio,
                .Timeout = 30000
            }

                ' Datos del comprobante a consultar
                request.CbteTipo = tipoComprobante ' Ej: 1 (Factura A), 6 (Factura B)
                request.CbteNro = numeroComprobante
                request.PtoVta = puntoVenta

                ' Autenticación con TA (Ticket de Acceso)
                Dim authRequest As New FEAuthRequest()
                authRequest.Token = token
                authRequest.Sign = sign
                authRequest.Cuit = CLng(cuitEmisor)

                ' Consultar comprobante
                Dim respuesta As FECompConsultaResponse = servicio.FECompConsultar(authRequest, request)

                ' Verifica primero si la operación fue exitosa
                If respuesta.Errors IsNot Nothing AndAlso respuesta.Errors.Length > 0 Then
                    ' Hubo errores
                    RespuestaAfip = respuesta.Errors(0).Msg & " (Código: " & respuesta.Errors(0).Code & ")"
                Else
                    ' Verificar aprobación mediante la existencia de CAE
                    'If respuesta.Errors IsNot Nothing AndAlso respuesta.Errors.Length > 0 Then
                    cae_afip = respuesta.ResultGet.CodAutorizacion
                    Fecha_cae = respuesta.ResultGet.FchVto
                    importe_comprobante = respuesta.ResultGet.ImpTotal
                    'End If
                End If
            Catch ex As Exception
                Console.WriteLine("Error al conectar con AFIP: " & ex.Message)
                If ex.InnerException IsNot Nothing Then
                    Console.WriteLine("Detalle interno: " & ex.InnerException.Message)
                End If
            End Try

        End Sub

    End Class

End Namespace

