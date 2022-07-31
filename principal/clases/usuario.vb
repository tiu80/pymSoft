Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft

    Public Class usuario

        Dim midataset As New DataSet()
        Dim conex As New SqlConnection
        Dim verifica_codigo1 As Boolean

        Private madaptador As String
        Private mtabla As String
        Private mformulario As Object
        Private mcodigo As String
        Private mnombre As String
        Private mnombre1 As String
        Private minstruccion As String
        Private mcabecera As String
        Private mcabecera1 As String
        Private mtexto As String
        Private mtexto2 As String
        Private mtexto3 As String
        Private mvalidar As Boolean


        Public WriteOnly Property adapter()
            Set(ByVal value)
                madaptador = value
            End Set
        End Property

        Public WriteOnly Property tabla()
            Set(ByVal value)
                mtabla = value
            End Set
        End Property

        Public WriteOnly Property formulario()
            Set(ByVal value)
                mformulario = value
            End Set
        End Property

        Public Property codigo()
            Set(ByVal value)
                mcodigo = value
            End Set
            Get
                Return mcodigo
            End Get
        End Property

        Public Property nombre()
            Set(ByVal value)
                mnombre = value
            End Set
            Get
                Return mnombre
            End Get
        End Property

        Public WriteOnly Property nombre1()
            Set(ByVal value)
                mnombre1 = value
            End Set
        End Property

        Public WriteOnly Property instruccion()
            Set(ByVal value)
                minstruccion = value
            End Set
        End Property

        Public WriteOnly Property cabecera_nombre()
            Set(ByVal value)
                mcabecera = value
            End Set
        End Property

        Public WriteOnly Property cabecera_nombre1()
            Set(ByVal value)
                mcabecera1 = value
            End Set
        End Property

        Public ReadOnly Property text()
            Get
                Return mtexto
            End Get
        End Property

        Public ReadOnly Property text2()
            Get
                Return mtexto2
            End Get
        End Property

        Public ReadOnly Property text3()
            Get
                Return mtexto3
            End Get
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
        End Sub

        Public Sub mostrar()

            Dim comando As New SqlDataAdapter(madaptador, conex)

            comando.Fill(midataset, mtabla)

            mformulario.DataGridView1.DataSource = midataset.Tables(mtabla)

            mformulario.DataGridView1.Columns(0).Width = 100
            mformulario.DataGridView1.Columns(1).Width = 300

            mformulario.DataGridView1.Columns(0).HeaderText = "CODIGO"
            mformulario.DataGridView1.Columns(1).HeaderText = mcabecera
            mformulario.DataGridView1.Columns(2).HeaderText = mcabecera1

            comando.Dispose()
            midataset.Dispose()
            conex.Close()

        End Sub

        Public Sub agregar()

            Try

                If verifica_codigo1 = True Then

                    Dim fila As Data.DataRow

                    fila = midataset.Tables(mtabla).NewRow()

                    fila(mcodigo) = mformulario.txt_codigo.Text
                    fila(mnombre) = mformulario.txt_nombre.Text
                    fila(mnombre1) = mformulario.txt_contraseña.Text

                    midataset.Tables(mtabla).Rows.Add(fila)

                    Dim Insercion As New SqlCommand(minstruccion, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()

                    mformulario.txt_codigo.Text = ""
                    mformulario.txt_nombre.Text = ""
                    mformulario.txt_contraseña.Text = ""
                    mformulario.txt_codigo.Focus()

                End If

            Catch ex As Exception

            Finally

                midataset.Dispose()
                conex.Close()

            End Try

        End Sub

        Public Sub verifica_codigo()

            If mformulario.txt_codigo.Text = "" Or mformulario.txt_nombre.Text = "" Or mformulario.txt_contraseña.Text = "" Then

                verifica_codigo1 = False
                MsgBox("Complete los campos", MsgBoxStyle.Exclamation, "PyMsoft")
                Exit Sub

            End If

            verifica_codigo1 = True

            Try

                Dim comando3 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando3.ExecuteReader

                reader.Read()

                If reader(codigo) = mformulario.txt_codigo.Text Or reader(nombre) = mformulario.txt_nombre.text Then

                    MsgBox("Existe un Usuario con estos datos", MsgBoxStyle.MsgBoxSetForeground, "PymSoft")
                    mformulario.txt_codigo.Focus()

                    verifica_codigo1 = False

                Else

                    verifica_codigo1 = True

                End If

                comando3.Dispose()

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub borrar()

            Dim comando As New SqlDataAdapter(madaptador, conex)

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()

                midataset.Tables(mtabla).Clear()

            Catch ex As Exception

            Finally

                mformulario.txt_codigo.Focus()
                conex.Close()
                midataset.Dispose()
                midataset.Tables(mtabla).Clear()
                comando.Fill(midataset, mtabla)

            End Try

        End Sub

        Public Sub actualizar()

            Try

                If verifica_codigo1 = True Then

                    Dim Insercion As New SqlCommand(minstruccion, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()

                    mformulario.txt_codigo.Focus()

                End If

            Catch ex As Exception

            Finally

                conex.Close()
                midataset.Dispose()
                Call verifica_codigo()
                mformulario.txt_codigo.Text = ""
                mformulario.txt_nombre.Text = ""
                mformulario.txt_contraseña.Text = ""
                midataset.Tables(mtabla).Clear()
                Dim comando As New SqlDataAdapter(madaptador, conex)
                comando.Fill(midataset, mtabla)

            End Try

        End Sub

        Public Sub buscar()

            Dim buscar As New SqlDataAdapter(minstruccion, conex)

            buscar.Fill(midataset, mtabla)

            mformulario.DataGridView1.DataSource = midataset.Tables(mtabla)

            mformulario.DataGridView1.Columns(0).Width = 100
            mformulario.DataGridView1.Columns(1).Width = 300

            mformulario.DataGridView1.Columns(0).HeaderText = "CODIGO"
            mformulario.DataGridView1.Columns(1).HeaderText = mcabecera
            mformulario.DataGridView1.Columns(2).HeaderText = mcabecera1

            buscar.Dispose()
            conex.Close()
            midataset.Dispose()

        End Sub

        Public Sub limpiar()

            mformulario.txt_codigo.Text = ""
            mformulario.txt_nombre.Text = ""
            mformulario.txt_contraseña.Text = ""
            mformulario.txt_codigo.Focus()

        End Sub

        Public Sub cargar()

            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                mtexto = reader(mcodigo)
                mtexto2 = reader(mnombre)
                mtexto3 = reader(mnombre1)
                mvalidar = True

                reader.Close()

            Catch ex As Exception

                mtexto2 = ""
                mtexto = ""
                mtexto3 = ""
                mvalidar = False

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub verifica_asignacion()

            Try

                Dim comando2 As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                While reader.Read

                    mvalidar = True
                    Exit Sub

                End While

            Catch ex As Exception

            Finally

                conex.Close()

            End Try

            mvalidar = False

        End Sub
    End Class

End Namespace
