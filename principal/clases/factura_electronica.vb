Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class factura_electronica

        Private conex As SqlConnection
        Private coman As SqlCommand
        Private comando As SqlDataAdapter
        Private tb As DataTable

        Private diferencia_nocturna As TimeSpan
        Private horaentrada As DateTime
        Private horasalida As DateTime
        Private hora As Integer

        Private mconcepto, mtipo_doc, mnro_doc, mtipo_cbte, mpunto_vta, _
                mcbt_desde, mcbt_hasta, mimp_total, mimp_tot_conc, mimp_neto, _
                mimp_iva, mimp_trib, mimp_op_ex, mfecha_cbte, mfecha_venc_pago, _
                mfecha_serv_desde, mfecha_serv_hasta, _
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

                'diferencia_nocturna = horasalida.Subtract(horaentrada)
                'hora = diferencia_nocturna.Hours

                ' Generar un nuevo ticket de acceso si no existe o ha expirado;
                ' de lo contrario, se reutiliza el solicitado anteriormente
                ' (el objeto WSAA debe permanecer instanciado en memoria)
                'If WSAA.Token = "" Or WSAA.Sign = "" Then
                If Trim(tb.Rows(0).Item(0)) = "" Or Trim(tb.Rows(0).Item(1)) = "" Or hora >= 11 Then
                    Autenticar(crt, key)
                    actualiza_sign_token()
                    WSFEv1.Token = WSAA.Token
                    WSFEv1.Sign = WSAA.Sign
                Else
                    ' Setear tocken y sing de autorización (pasos previos)
                    WSFEv1.Token = Trim(tb.Rows(0).Item(1))
                    WSFEv1.Sign = Trim(tb.Rows(0).Item(0))
                End If

                ' Setear tocken y sing de autorización (pasos previos)
                'WSFEv1.Token = WSAA.Token
                'WSFEv1.Sign = WSAA.Sign

                ' CUIT del emisor (debe estar registrado en la AFIP)
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

        Private Sub actualiza_sign_token()

            Try

                conex = New SqlConnection
                conex = conecta()
                If conex.State = ConnectionState.Closed Then conex.Open()

                coman = New SqlCommand("Update numerador set Token = '" & Trim(WSAA.Token) & "',Signn = '" & Trim(WSAA.Sign) & "',hora_token = '" & Date.Now.ToString("yyyyMMdd HH:mm:ss") & "' where talon = 1", conex)
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

                ok = WSFEv1.CrearFactura(Me.Concepto, Me.Tipo_documento, Me.Numero_documento, Me.Tipo_comprobante, Me.Punto_venta, _
                        Me.Comprobante_desde, Me.Comprobante_hasta, Me.Importe_total, Me.Importe_total_conc, Me.Importe_neto, _
                        Me.Importe_iva, Me.Importe_trib, Me.Importe_op_ex, Me.Fecha_comprobante, Me.Fecha_vencimiento_pago, _
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

    End Class

End Namespace

