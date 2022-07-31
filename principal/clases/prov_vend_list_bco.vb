Imports System.Data.SqlClient
Imports System.Data

Namespace pymsoft
    Public Class prov_vend_list_bco

        Dim midataset As New DataSet()
        Dim conex As New SqlConnection
        Dim verifica_codigo1 As Boolean

        Private madaptador As String
        Private mtabla As String
        Private mtabla1 As String
        Private mformulario As Object
        Private mcodigo As String
        Private mnombre As String
        Private minstruccion As String
        Private minstruccion1 As String
        Private mcabecera As String
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

        Public WriteOnly Property tabla1()
            Set(ByVal value)
                mtabla1 = value
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

        Public WriteOnly Property nombre()
            Set(ByVal value)
                mnombre = value
            End Set
        End Property

        Public WriteOnly Property instruccion()
            Set(ByVal value)
                minstruccion = value
            End Set
        End Property

        Public WriteOnly Property instruccion1()
            Set(ByVal value)
                minstruccion1 = value
            End Set
        End Property

        Public WriteOnly Property cabecera_nombre()
            Set(ByVal value)
                mcabecera = value
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

                    midataset.Tables(mtabla).Rows.Add(fila)

                    Dim Insercion As New SqlCommand(minstruccion, conex)

                    If conex.State = ConnectionState.Closed Then conex.Open()
                    Insercion.ExecuteNonQuery()
                    Insercion.Dispose()

                    mformulario.txt_codigo.Text = ""
                    mformulario.txt_nombre.Text = ""
                    mformulario.txt_codigo.Focus()

                End If

            Catch ex As Exception

            Finally

                midataset.Dispose()
                conex.Close()

            End Try

        End Sub

        Public Function verifica_movimiento() As Boolean

            Dim comando As New SqlDataAdapter(minstruccion, conex)
            comando.Fill(midataset, mtabla1)
            comando.Dispose()

            mvalidar = False

            If midataset.Tables(mtabla1).Rows.Count > 0 Then
                MessageBox.Show("existen registros asociados a este articulo!!!.. no se puede eliminar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mvalidar = True
            End If

        End Function

        Public Sub verifica_codigo()

            If mformulario.txt_codigo.Text = "" Or mformulario.txt_nombre.Text = "" Then

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

                If Trim(reader(mcodigo)) = Trim(mformulario.txt_codigo.Text) Or Trim(reader(mnombre)) = Trim(mformulario.txt_nombre.Text) Then

                    MsgBox("El codigo o descripcion ya existen!!!", MsgBoxStyle.MsgBoxSetForeground, "PymSoft")
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

            Dim a As Integer

            Dim comando As New SqlDataAdapter(madaptador, conex)

            Try

                If form_lista.sale = True Then a = MsgBox("Esta seguro que desea eliminar el regitro seleccionado!!!", MsgBoxStyle.YesNo, "PymSoft")
                If form_lista.sale = False Then a = 6

                If a = 6 Then

                    verifica_relaciones()

                    If mvalidar = False Then

                        Dim Insercion As New SqlCommand(minstruccion, conex)

                        If conex.State = ConnectionState.Closed Then conex.Open()
                        Insercion.ExecuteNonQuery()
                        Insercion.Dispose()

                        midataset.Tables(mtabla).Clear()

                    End If

                Else

                    midataset.Tables(mtabla).Clear()

                End If


            Catch ex As Exception

            Finally

                mformulario.txt_codigo.Focus()
                conex.Close()
                midataset.Dispose()
                midataset.Tables(mtabla).Clear()
                comando.Fill(midataset, mtabla)

            End Try

        End Sub

        Private Sub verifica_relaciones()

            Dim comando As New SqlDataAdapter(minstruccion1, conex)
            comando.Fill(midataset, mtabla1)
            comando.Dispose()

            mvalidar = False

            If midataset.Tables(mtabla1).Rows.Count > 0 Then
                MessageBox.Show("existen registros asociados a este registro!!!.. no se puede eliminar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mvalidar = True
            End If

        End Sub

        Public Sub actualizar()

            Try

                Dim Insercion As New SqlCommand(minstruccion, conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Insercion.ExecuteNonQuery()
                Insercion.Dispose()

                mformulario.txt_codigo.Focus()

            Catch ex As Exception

            Finally

                conex.Close()
                midataset.Dispose()
                Call verifica_codigo()
                mformulario.txt_codigo.Text = ""
                mformulario.txt_nombre.Text = ""
                midataset.Tables(mtabla).Clear()
                Dim comando As New SqlDataAdapter(madaptador, conex)
                comando.Fill(midataset, mtabla)

            End Try

        End Sub

        Public Sub buscar()

            midataset.Clear()
            Dim buscar As New SqlDataAdapter(minstruccion, conex)

            buscar.Fill(midataset, mtabla)

            mformulario.DataGridView1.DataSource = midataset.Tables(mtabla)

            mformulario.DataGridView1.Columns(0).Width = 100
            mformulario.DataGridView1.Columns(1).Width = 300

            mformulario.DataGridView1.Columns(0).HeaderText = "CODIGO"
            mformulario.DataGridView1.Columns(1).HeaderText = mcabecera

            buscar.Dispose()
            conex.Close()
            midataset.Dispose()

        End Sub

        Public Sub limpiar()

            mformulario.txt_codigo.Text = ""
            mformulario.txt_nombre.Text = ""
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
                mvalidar = True

                comando2.Dispose()
                reader.Close()

            Catch ex As Exception

                mtexto2 = ""
                mtexto = ""
                mvalidar = False

            Finally

                conex.Close()

            End Try

        End Sub

    End Class

End Namespace
