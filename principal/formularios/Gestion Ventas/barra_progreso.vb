Imports System.Data.SqlClient
Imports System.Data

Public Class barra_progreso

    Dim conex As New SqlConnection("Data Source=(local);Initial Catalog=pgc;Integrated Security=True")
    Dim midataset As New DataSet
    Dim comando As New SqlDataAdapter("select *from cli_01", conex)
    Dim i As Integer

    Private Sub barra_progreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        comando.Fill(midataset, "cli_01")

        Me.barra.Minimum = 0
        Me.barra.Maximum = midataset.Tables("cli_01").Rows.Count

        For i = barra.Minimum To barra.Maximum - 1

            barra.Value = i + 1
            Label1.Text = CLng((barra.Value * 100) / barra.Maximum) & " %"

        Next

    End Sub

End Class