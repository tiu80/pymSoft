Imports System.Data
Imports System.Data.SqlClient

Public Class Form_pendiente

    Dim conex As New SqlConnection
    Dim tbbl As New DataTable
    Dim comando As SqlDataAdapter

    Private Sub Form_pendiente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call carga_datos()

    End Sub

    Public Sub carga_datos()

        conex = conecta()
        tbbl.Clear()

        comando = New SqlDataAdapter("select id_art2,detalle,cant from ped_det where num= '" & RTrim(form_factura.txt_numero.Text) & "' and pre ='" & RTrim(form_factura.txt_prefijo.Text) & "' and tc = '" & RTrim(form_factura.txt_tipo_fact.Text) & "' and lt = '" & RTrim(form_factura.txt_letra.Text) & "' and pc = '" & RTrim(My.Computer.Name) & "'", conex)
        comando.Fill(tbbl)

        Me.DataGridView1.DataSource = tbbl

        Me.DataGridView1.Columns(0).Width = 60
        Me.DataGridView1.Columns(1).Width = 260
        Me.DataGridView1.Columns(2).Width = 50

        Me.DataGridView1.Columns(0).HeaderText = "cod"
        Me.DataGridView1.Columns(1).HeaderText = "descripcion"
        Me.DataGridView1.Columns(2).HeaderText = "cant"

    End Sub

End Class