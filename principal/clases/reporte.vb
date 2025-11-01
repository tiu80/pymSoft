Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class reporte

        Inherits parametro

        Dim coman As SqlCommand
        Dim conex As New SqlConnection
        Dim comando As SqlDataAdapter

        Private mreporte As String
        Private mcodigo As String
        Private mdescripcion As String
        Private mformato As Object
        Private mimpresora As String
        Dim sale As Boolean

        Public Property reporte()
            Get
                Return mreporte
            End Get
            Set(ByVal value)
                mreporte = value
            End Set
        End Property

        Public Property impresora()
            Get
                Return mimpresora
            End Get
            Set(ByVal value)
                mimpresora = value
            End Set
        End Property

        Public Property formato()
            Get
                Return mformato
            End Get
            Set(ByVal value)
                mformato = value
            End Set
        End Property

        Public Property codigo()
            Get
                Return mcodigo
            End Get
            Set(ByVal value)
                mcodigo = value
            End Set
        End Property

        Public Property descripcion()
            Get
                Return mdescripcion
            End Get
            Set(ByVal value)
                mdescripcion = value
            End Set
        End Property

        Public Sub mostrar_reporte()

            Try

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                Dim comando As New SqlCommand(instruccion, conex)
                Dim reader As SqlDataReader = comando.ExecuteReader

                reader.Read()

                form_config_rep.txt_codigo.Text = reader("id")
                form_config_rep.txt_descripcion.Text = reader("descripcion")
                form_config_rep.txt_reporte.Text = reader("reporte")

                reader.Close()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Function carga_datos(ByVal reporte As String) As String

            Dim tb As New DataTable

            Try

                tb.Clear()
                conex = conecta()

                comando = New SqlDataAdapter("select top 1 reporte,impresora from reporte_01 where reporte = '" & Trim(reporte) & "'", conex)
                comando.Fill(tb)
                comando.Dispose()

                mimpresora = tb.Rows(0).Item(1).ToString

                If tb.Rows.Count = Nothing Then
                    Return 0
                Else
                    Return tb.Rows(0).Item(0)
                End If

            Catch ex As Exception

            Finally
                tb.Dispose()
            End Try

        End Function

        Public Sub carga_formato_factura(ByVal letra)

            Dim x As String = ""

            x = carga_datos("fact_A")

            If RTrim(letra) = "A" And x = "fact_A" And sale = False Then
                mformato = New fact_A
                sale = True
            End If

            x = carga_datos("fact_A_afip")

            If x = "fact_A_afip" Then
                mformato = New Fact_A_afip
                sale = True
            End If

            x = carga_datos("Fact_A_afip_bodrito")

            If x = "Fact_A_afip_bodrito" Then
                mformato = New Fact_A_afip_bodrito
                sale = True
            End If


            x = carga_datos("fact_B")

            If RTrim(letra) = "B" And x = "fact_B" And sale = False Then
                mformato = New fact_B
                sale = True
            End If

            x = carga_datos("fact_B_afip")

            If x = "fact_B_afip" Then
                mformato = New fact_B_afip
                sale = True
            End If

            x = carga_datos("fact_B_afip_bodrito")

            If x = "fact_B_afip_bodrito" Then
                mformato = New fact_B_afip_bodrito
                sale = True
            End If


            x = carga_datos("fact_C")

            If RTrim(letra) = "C" And x = "fact_C" And sale = False Then
                mformato = New fact_C
                sale = True
            End If

            x = carga_datos("fact_c_membrete")

            If RTrim(letra) = "C" And x = "fact_c_membrete" And sale = False Then
                mformato = New fact_c_membrete
                sale = True
            End If

            x = carga_datos("fact_c_membrete_mitad")
            If RTrim(letra) = "C" And x = "fact_c_membrete_mitad" And sale = False Then
                mformato = New fact_c_membrete
                sale = True
            End If

            x = carga_datos("fact_c_afip")
            If x = "fact_c_afip" Then
                mformato = New fact_C_afip
                sale = True
            End If

            x = carga_datos("fact_c_membrete_mitad_bodrito")
            If x = "fact_c_membrete_mitad_bodrito" Then
                mformato = New fact_c_membrete_mitad_bodrito
                sale = True
            End If

            x = carga_datos("fact_c_membrete_mitad_general")
            If x = "fact_c_membrete_mitad_general" Then
                mformato = New fact_c_membrete_mitad_general
                sale = True
            End If

            x = carga_datos("epson_tm220_afip")
            If x = "epson_tm220_afip" Then
                mformato = New epson_tm220_afip
                sale = True
            End If

            If sale = False Then x = carga_datos("presupuesto")
            If x = "presupuesto" And sale = False Then
                mformato = New presupuesto
                sale = True
            End If

            sale = False

        End Sub

        Public Sub New()
            sale = False
        End Sub

    End Class

End Namespace

