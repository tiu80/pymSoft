Imports System.Data
Imports System.Data.SqlClient

Namespace pymsoft

    Public Class menu

        Inherits parametro

        Dim conex As New SqlConnection
        Dim comando As SqlDataAdapter
        Dim midataset As New DataSet

        Private mpadre As String
        Private marbol As TreeView
        Private mvalor As String
        Private mvalor1 As String
        Private mvalor2 As String
        Private mmodulo As String
        Private mverifica As Boolean = True

        Dim i As Integer

        Public Property arbol()
            Get
                Return marbol
            End Get
            Set(ByVal value)
                marbol = value
            End Set
        End Property

        Public Property valida()
            Get
                Return mverifica
            End Get
            Set(ByVal value)
                mverifica = value
            End Set
        End Property

        Public Property modulo()
            Get
                Return mmodulo
            End Get
            Set(ByVal value)
                mmodulo = value
            End Set
        End Property

        Public Property padre()
            Get
                Return mpadre
            End Get
            Set(ByVal value)
                mpadre = value
            End Set
        End Property

        Public Property valor()
            Get
                Return mvalor
            End Get
            Set(ByVal value)
                mvalor = value
            End Set
        End Property

        Public Property valor1()
            Get
                Return mvalor1
            End Get
            Set(ByVal value)
                mvalor1 = value
            End Set
        End Property

        Public Property valor2()
            Get
                Return mvalor2
            End Get
            Set(ByVal value)
                mvalor2 = value
            End Set
        End Property

        Public Sub New()
            mpadre = ""
            mvalor = ""
            mvalor1 = ""
            mvalor2 = ""
            conex = conecta()
        End Sub

        Public Sub carga_Modulo()

            For i = 0 To marbol.Nodes.Count - 1

                If marbol.Nodes(i).Checked = True Then

                    Me.instruccion = "INSERT INTO sub_menu_01(id_menu,nombre,modulo,sub_modulo,estado,pos) VALUES('" & form_menu.txt_codigo.Text & "' , '" & form_menu.txt_nombre.Text & "', '" + Me.padre + "', '" + marbol.Nodes(i).Text + "', 'A','" & i & "')"
                    Me.abm()

                Else

                    If Trim(form_menu.txt_codigo.Text) <> 1 Then Me.instruccion = "INSERT INTO sub_menu_01(id_menu,nombre,modulo,sub_modulo,estado,pos) VALUES('" & form_menu.txt_codigo.Text & "' , '" & form_menu.txt_nombre.Text & "', '" + Me.padre + "', '" + marbol.Nodes(i).Text + "', 'B','" & i & "')"
                    If Trim(form_menu.txt_codigo.Text) = 1 Then Me.instruccion = "INSERT INTO sub_menu_01(id_menu,nombre,modulo,sub_modulo,estado,pos) VALUES('" & form_menu.txt_codigo.Text & "' , '" & form_menu.txt_nombre.Text & "', '" + Me.padre + "', '" + marbol.Nodes(i).Text + "', 'A','" & i & "')"
                    Me.abm()

                End If

            Next

        End Sub

        Public Sub actualiza_Modulo()

            For i = 0 To marbol.Nodes.Count - 1

                If marbol.Nodes(i).Checked = True Then

                    Dim b As String = marbol.Nodes(i).Text

                    Me.instruccion = "update sub_menu_01 set id_menu= '" & form_menu.txt_codigo.Text & "', nombre = '" & form_menu.txt_nombre.Text & "', estado= 'A' where sub_modulo= '" + marbol.Nodes(i).Text + "' and id_menu= '" & form_menu.txt_interno.Text & "'"
                    Me.abm()

                Else

                    Dim a As String = marbol.Nodes(i).Text

                    Me.instruccion = "update sub_menu_01 set id_menu= '" & form_menu.txt_codigo.Text & "', nombre = '" & form_menu.txt_nombre.Text & "', estado= 'B' where sub_modulo= '" + marbol.Nodes(i).Text + "' and id_menu= '" & form_menu.txt_interno.Text & "'"
                    Me.abm()

                End If

            Next

        End Sub

        Public Sub limpiar()

            For i = 0 To marbol.Nodes.Count - 1

                If marbol.Nodes(i).Checked = True Then

                    marbol.Nodes(i).Checked = False

                End If

            Next

            For i = 0 To form_menu.Tree_modulo.Nodes.Count - 1

                If form_menu.Tree_modulo.Nodes(i).Checked = True Then
                    form_menu.Tree_modulo.Nodes(i).Checked = False
                End If

            Next

        End Sub

        Public Sub carga_menu()

            For i = 0 To form_menu.Tree_modulo.Nodes.Count - 1

                If form_menu.Tree_modulo.Nodes(i).Checked = True Then

                    Me.instruccion = "INSERT INTO menu01(id_menu01,nombre,estado) VALUES('" & form_menu.txt_codigo.Text & "' , '" + form_menu.Tree_modulo.Nodes(i).Text + "', 'A')"
                    Me.abm()

                Else

                    If Trim(form_menu.txt_codigo.Text) <> 1 Then Me.instruccion = "INSERT INTO menu01(id_menu01,nombre,estado) VALUES('" & form_menu.txt_codigo.Text & "' , '" + form_menu.Tree_modulo.Nodes(i).Text + "', 'B')"
                    If Trim(form_menu.txt_codigo.Text) = 1 Then Me.instruccion = "INSERT INTO menu01(id_menu01,nombre,estado) VALUES('" & form_menu.txt_codigo.Text & "' , '" + form_menu.Tree_modulo.Nodes(i).Text + "', 'A')"
                    Me.abm()

                End If

            Next

        End Sub

        Public Sub actualiza_menu()

            For i = 0 To form_menu.Tree_modulo.Nodes.Count - 1

                If form_menu.Tree_modulo.Nodes(i).Checked = True Then

                    Me.instruccion = "update menu01 set id_menu01= '" & form_menu.txt_codigo.Text & "',estado= 'A' where nombre ='" & form_menu.Tree_modulo.Nodes(i).Text & "' and id_menu01= '" & form_menu.txt_interno.Text & "'"
                    Me.abm()

                Else

                    Me.instruccion = "update menu01 set id_menu01= '" & form_menu.txt_codigo.Text & "',estado= 'B' where nombre ='" & form_menu.Tree_modulo.Nodes(i).Text & "' and id_menu01= '" & form_menu.txt_interno.Text & "'"
                    Me.abm()

                End If

            Next

        End Sub

        Public Sub mostrar_sub_menu()
            Try

                comando = New SqlDataAdapter("select * from sub_menu_01 where modulo like '" + RTrim(mmodulo) + "' and id_menu like '" & form_menu.txt_codigo.Text & "' order by pos", conex)
                comando.Fill(midataset, "sub_menu_01")

                If RTrim(midataset.Tables("sub_menu_01").Rows(0).Item(0)) = 1 Then
                    form_menu.Tree_modulo.Enabled = False
                    form_menu.Tree_altas.Enabled = False
                    form_menu.cmd_actualizar.Enabled = False
                    form_menu.cmd_agregar.Enabled = False
                    form_menu.cmd_borrar.Enabled = False
                    form_menu.txt_nombre.Enabled = False
                    Exit Sub
                End If

                For i = 0 To midataset.Tables(0).Rows.Count - 1

                    If RTrim(midataset.Tables(0).Rows(i).Item(4)) = "A" Then


                        marbol.Nodes(i).Checked = True

                    Else

                        marbol.Nodes(i).Checked = False

                    End If

                Next

            Catch ex As Exception

                form_menu.Tree_modulo.Enabled = True
                form_menu.Tree_altas.Enabled = True
                form_menu.cmd_actualizar.Enabled = True
                form_menu.cmd_agregar.Enabled = True
                form_menu.cmd_borrar.Enabled = True
                form_menu.txt_nombre.Enabled = True

            Finally

                midataset.Dispose()
                midataset.Clear()

            End Try

        End Sub

        Public Sub mostrar_nombre_menu()

            Try

                Dim comando2 As New SqlCommand("select *from sub_menu_01 where id_menu like '" & form_menu.txt_codigo.Text & "'", conex)

                If conex.State = ConnectionState.Closed Then conex.Open()
                Dim reader As SqlDataReader = comando2.ExecuteReader

                reader.Read()

                form_menu.txt_nombre.Text = reader("nombre")
                form_menu.txt_interno.Text = reader("id_menu")

                mverifica = True

                reader.Close()

            Catch ex As Exception

                form_menu.txt_nombre.Text = ""
                form_menu.txt_interno.Text = ""
                mverifica = False
                form_menu.recorre_arbol_limpia()

            Finally

                conex.Close()

            End Try

        End Sub

        Public Sub mostrar_menu()

            comando = New SqlDataAdapter("select *from menu01 where id_menu01 = '" & form_menu.txt_codigo.Text & "'", conex)
            comando.Fill(midataset, "menu01")

            For i = 0 To midataset.Tables("menu01").Rows.Count - 1

                If RTrim(midataset.Tables("menu01").Rows(i).Item(3)) = "A" Then

                    form_menu.Tree_modulo.Nodes(i).Checked = True

                Else

                    form_menu.Tree_modulo.Nodes(i).Checked = False

                End If

            Next

            midataset.Dispose()
            midataset.Clear()

        End Sub

    End Class

End Namespace
