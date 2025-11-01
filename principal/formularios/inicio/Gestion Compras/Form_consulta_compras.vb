Imports System.Data
Imports System.Data.SqlClient

Public Class Form_consulta_compras

    Dim comando As SqlDataAdapter
    Dim midataset As New DataSet
    Dim comando1 As SqlCommand
    Dim conex As New SqlConnection
    Dim talonario As Short

    Private Sub Form_consulta_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)
        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.Check_talonario.Checked = True Then
            talonario = 1  ' blanco
        Else
            talonario = 2   ' negro
        End If

        midataset.Clear()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        'comando = New SqlDataAdapter("select cuenta,detalle,neto,iva_ins,imp_interno,exento,per_iva,per_ib from compra_det inner join compra_tot on compra_det.lt = '" & RTrim(Me.txt_letra.Text) & "' and compra_det.num = '" & RTrim(Me.txt_numero.Text) & "' and compra_det.tipo1 = '" & RTrim(Me.cmb_tipo.Text) & "' and compra_det.pre = '" & RTrim(Me.txt_prefijo.Text) & "' where compra_det.num = compra_tot.num1 and compra_det.lt = compra_tot.lt1 and compra_det.pre = compra_tot.pre1 and compra_det.tipo1 = compra_tot.tipo2", conex)
        'comando.Fill(midataset, "compra_det")

        'Form_consulta_compras_det.DataGridView1.DataSource = midataset.Tables(0)

        'Form_consulta_compras_det.Show()

    End Sub
End Class