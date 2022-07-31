Public Class Form_muestra_saldo

    Private Sub Form_muestra_saldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DataGridView1.Columns(0).Width = 100
        Me.DataGridView1.Columns(1).Width = 300
        Me.DataGridView1.Columns(2).Width = 100
        Me.DataGridView1.Columns(3).Width = 100

        Me.DataGridView1.Columns(0).HeaderText = "Codigo"
        Me.DataGridView1.Columns(1).HeaderText = "Detalle"
        Me.DataGridView1.Columns(2).HeaderText = "Debito"
        Me.DataGridView1.Columns(3).HeaderText = "Credito"

        Dim a As Integer = Me.DataGridView1.Rows.Count - 1
        Me.DataGridView1.Rows(a).DefaultCellStyle.BackColor = Color.LightGreen
        Me.txt_estado_form.Text = 1

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Form_exporta.Show()
    End Sub
End Class