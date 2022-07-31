Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_asignacion

    Dim comando As SqlDataAdapter
    Dim midataset As New DataSet
    Dim conex As New SqlConnection

    Private Sub Form_muestra_asignacion_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        midataset.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Form_muestra_asignacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        comando = New SqlDataAdapter("select usuario,menu,parametro from menu_usu", conex)
        comando.Fill(midataset, "menu_usu")

        Me.DataGridView1.DataSource = midataset.Tables(0)

        Me.DataGridView1.Columns(0).Width = 135
        Me.DataGridView1.Columns(1).Width = 65
        Me.DataGridView1.Columns(2).Width = 65

    End Sub
End Class