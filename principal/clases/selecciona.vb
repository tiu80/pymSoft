Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class selecciona

        Private conex As New SqlConnection
        Private minstruccion As String
        Private comando As SqlDataAdapter
        Private midataset As New DataSet
        Private mnombre_tabla As String
        Private mdatagrid As String
        Private mnumero As Integer
        Private mnumero1 As Integer
        Private mcadena As String
        Private mcadena1 As String
        Private mcadena2 As String
        Private mcadena3 As String
        Private mcadena4 As String
        Private mcadena5 As String
        Private mcadena6 As String
        Private mcadena7 As String
        Private mnumero2 As Integer
        Private mnumero3 As Integer
        Private mnumero4 As String
        Private mfec As Date

        Public Property telefono()
            Get
                Return mnumero4
            End Get
            Set(ByVal value)
                mnumero4 = value
            End Set
        End Property

        Public Property fecha_inicio()
            Get
                Return mfec
            End Get
            Set(ByVal value)
                mfec = value
            End Set
        End Property

        Public Property direccion()
            Get
                Return mcadena4
            End Get
            Set(ByVal value)
                mcadena4 = value
            End Set
        End Property

        Public Property localidad()
            Get
                Return mcadena5
            End Get
            Set(ByVal value)
                mcadena5 = value
            End Set
        End Property

        Public Property cod_localidad()
            Get
                Return mnumero2
            End Get
            Set(ByVal value)
                mnumero2 = value
            End Set
        End Property

        Public Property cod_postal()
            Get
                Return mnumero3
            End Get
            Set(ByVal value)
                mnumero3 = value
            End Set
        End Property

        Public Property codigo()
            Get
                Return mnumero
            End Get
            Set(ByVal value)
                mnumero = value
            End Set
        End Property

        Public Property ejercicio()
            Get
                Return mnumero1
            End Get
            Set(ByVal value)
                mnumero1 = value
            End Set
        End Property

        Public Property encuadre()
            Get
                Return mcadena
            End Get
            Set(ByVal value)
                mcadena = value
            End Set
        End Property

        Public Property cuit()
            Get
                Return mcadena1
            End Get
            Set(ByVal value)
                mcadena1 = value
            End Set
        End Property

        Public Property ing_brutos()
            Get
                Return mcadena2
            End Get
            Set(ByVal value)
                mcadena2 = value
            End Set
        End Property

        Public Property nombre()
            Get
                Return mcadena3
            End Get
            Set(ByVal value)
                mcadena3 = value
            End Set
        End Property

        Public Property CRT()
            Get
                Return mcadena6
            End Get
            Set(ByVal value)
                mcadena6 = value
            End Set
        End Property

        Public Property KEY()
            Get
                Return mcadena7
            End Get
            Set(ByVal value)
                mcadena7 = value
            End Set
        End Property

        Public Property nombre_tabla()
            Get
                Return mnombre_tabla
            End Get
            Set(ByVal value)
                mnombre_tabla = value
            End Set
        End Property

        Public Property datagrid()
            Get
                Return mdatagrid
            End Get
            Set(ByVal value)
                mdatagrid = value
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

        Public Sub agrega_grilla()

            comando = New SqlDataAdapter(minstruccion, conex)
            comando.Fill(midataset, nombre_tabla)

            datagrid.DataSource = midataset.Tables(nombre_tabla)

        End Sub

        Public Sub carga_campos()

            Try

                comando = New SqlDataAdapter(minstruccion, conex)
                comando.Fill(midataset, nombre_tabla)

                codigo = midataset.Tables(nombre_tabla).Rows(0).Item(0)   'codigo
                nombre = midataset.Tables(nombre_tabla).Rows(0).Item(1)    'nombre
                encuadre = midataset.Tables(nombre_tabla).Rows(0).Item(2)    'detalle ' encuadre
                cuit = midataset.Tables(nombre_tabla).Rows(0).Item(3)     ' cuit
                ing_brutos = midataset.Tables(nombre_tabla).Rows(0).Item(4)     ' ing_brutos
                ejercicio = midataset.Tables(nombre_tabla).Rows(0).Item(5)  'ejercicio
                direccion = midataset.Tables(nombre_tabla).Rows(0).Item(6)
                cod_postal = midataset.Tables(nombre_tabla).Rows(0).Item(7)
                localidad = midataset.Tables(nombre_tabla).Rows(0).Item(8)
                cod_localidad = midataset.Tables(nombre_tabla).Rows(0).Item(10)
                fecha_inicio = midataset.Tables(nombre_tabla).Rows(0).Item(9)
                telefono = midataset.Tables(nombre_tabla).Rows(0).Item(11)
                CRT = midataset.Tables(nombre_tabla).Rows(0).Item(12)
                KEY = midataset.Tables(nombre_tabla).Rows(0).Item(13)

            Catch ex As Exception

            End Try

        End Sub

        Public Sub New()
            conex = conecta()
        End Sub
    End Class

End Namespace
