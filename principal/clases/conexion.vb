Imports System.Data
Imports System.Data.SqlClient

Module conexion

    Dim conex, conex1 As SqlConnection
    Public server, server1 As String
    Public db, db1 As String
    Public usuario, usuario1 As String
    Public contrase�a, contrase�a1 As String

    Public Function conecta()

        Dim sr As IO.StreamReader
        Dim aa() As String
        Dim bb As String
        Static cont As Integer = 0

        If cont = 0 Then

            If IO.File.Exists(Application.StartupPath & "\db.txt") Then

                sr = New IO.StreamReader(Application.StartupPath & "\db.txt")

                While sr.EndOfStream = False

                    aa = Split(sr.ReadLine, ";")

                    bb = aa(0).ToString.Substring(0, 2)

                    If RTrim(bb) <> "--" Then

                        server = aa(0)
                        db = aa(1)
                        usuario = aa(2)
                        contrase�a = aa(3)

                        cont = cont + 1

                    End If

                End While

            End If

        End If

        server = server
        db = db
        usuario = usuario
        contrase�a = contrase�a

        conex = New SqlConnection("Data Source=" & server & ";Initial Catalog=" & db & ";Persist Security Info=false;User ID=" & usuario & ";password=" & contrase�a & ";MultipleActiveResultSets=" & True)

        'conex = New SqlConnection("Data Source=" & My.Computer.Name & ";Initial Catalog=pgc;Persist Security Info=false;User ID=sa")

        'Dim conex As New SqlConnection("Data Source= 25.147.4.65,1433;Initial Catalog=pgc;Persist Security Info=false;User ID=sa")

        Return conex

    End Function

    Public Function conecta1()

        Dim sr As IO.StreamReader
        Dim aa() As String
        Dim bb As String
        Static cont As Integer = 0

        If cont = 0 Then

            If IO.File.Exists(Application.StartupPath & "\db1.txt") Then

                sr = New IO.StreamReader(Application.StartupPath & "\db1.txt")

                While sr.EndOfStream = False

                    aa = Split(sr.ReadLine, ";")

                    bb = aa(0).ToString.Substring(0, 2)

                    If RTrim(bb) <> "--" Then

                        server1 = aa(0)
                        db1 = aa(1)
                        usuario1 = aa(2)
                        contrase�a1 = aa(3)

                        cont = cont + 1

                    End If

                End While

            End If

        End If

        server1 = server1
        db1 = db1
        usuario1 = usuario1
        contrase�a1 = contrase�a1

        conex1 = New SqlConnection("Data Source=" & server1 & ";Initial Catalog=" & db1 & ";Persist Security Info=false;User ID=" & usuario1 & ";password=" & contrase�a1 & ";MultipleActiveResultSets=" & True)

        'conex = New SqlConnection("Data Source=" & My.Computer.Name & ";Initial Catalog=pgc;Persist Security Info=false;User ID=sa")

        'Dim conex As New SqlConnection("Data Source= 25.147.4.65,1433;Initial Catalog=pgc;Persist Security Info=false;User ID=sa")

        Return conex1

    End Function

End Module
