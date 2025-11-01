Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class parametro

        Dim conex As New SqlConnection
        Dim comando1 As SqlDataAdapter
        Dim midataset As New DataSet
        Private minstruccion, minstruccion1 As String
        Private mverifica As Boolean

        Public Property verifica()
            Get
                Return mverifica
            End Get
            Set(ByVal value)
                mverifica = value
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

        Public Property instruccion1()
            Get
                Return minstruccion1
            End Get
            Set(ByVal value)
                minstruccion1 = value
            End Set
        End Property

        Public Sub New()
            conex = conecta()
        End Sub

        Public Sub abm()

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                verifica = True

            Catch ex As Exception

                verifica = False

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub verifica_duplicado()

            Dim comando2 As New SqlCommand(minstruccion, conex)

            If conex.State = ConnectionState.Closed Then conex.Open()
            Dim reader As SqlDataReader = comando2.ExecuteReader

            Try

                While reader.Read

                    mverifica = False
                    MessageBox.Show("El Numero Esta en uso", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    comando2.Dispose()
                    reader.Close()
                    conex.Close()
                    Exit Sub

                End While

            Catch ex As Exception

            End Try

            mverifica = True
            conex.Close()
            comando2.Dispose()
            reader.Close()

        End Sub

        Public Sub mostrar_datos()

            Try

                midataset.Clear()
                midataset.Dispose()

                Dim comando As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader

                reader.Read()

                'form_parametros.txt_codigo.Text = reader("id_parametro")
                form_parametros.txt_interno.Text = reader("id_parametro")
                form_parametros.txt_descripcion.Text = reader("descripcion")

                comando.Dispose()
                reader.Close()

                comando1 = New SqlDataAdapter(minstruccion1, conex)
                comando1.Fill(midataset, "parametro_01")
                comando1.Dispose()

                If form_parametros.txt_verifica.Text = 1 Then

                    form_parametros.DataGridView1.Columns.Remove("codigo")
                    form_parametros.DataGridView1.Columns.Remove("Descripcion")
                    form_parametros.DataGridView1.Columns.Remove("Estado")

                    form_parametros.txt_verifica.Text = 2
                    form_parametros.cont = 0

                End If

                form_parametros.DataGridView1.DataSource = midataset.Tables(0)

                mverifica = True

            Catch ex As Exception

                mverifica = False
                midataset.Dispose()
                midataset.Clear()

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub verifica_config_duplicado()

            Dim comando2 As New SqlCommand(minstruccion, conex)

            If conex.State = ConnectionState.Closed Then conex.Open()
            Dim reader As SqlDataReader = comando2.ExecuteReader

            Try

                While reader.Read

                    mverifica = False
                    MessageBox.Show("El Usuario ya tiene una Configuracion!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    comando2.Dispose()
                    reader.Close()
                    conex.Close()
                    Exit Sub

                End While

            Catch ex As Exception

            End Try

            mverifica = True
            conex.Close()
            comando2.Dispose()
            reader.Close()

        End Sub

    End Class

End Namespace
