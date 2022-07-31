Imports System.DateTime
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class activate

        Private mfecha As DateTime
        Private mcont As Integer
        Dim minstruccion As String
        Dim conex As New SqlConnection

        Public Property fecha()
            Get
                Return mfecha
            End Get
            Set(ByVal value)
                mfecha = value
            End Set
        End Property

        Public Property cont()
            Get
                Return mcont
            End Get
            Set(ByVal value)
                mcont = value
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

        Public Sub abm()

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

    End Class

End Namespace
