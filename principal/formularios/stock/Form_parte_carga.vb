Imports System.Data
Imports System.Data.SqlClient

Public Class Form_parte_carga

    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim conex As New SqlConnection
    Dim tb As New DataTable, tb1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim i As Integer
    Dim tot As Double

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        conex = conecta()
        tb.Clear()
        tb1.Clear()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView2.DataSource = Nothing

        comando = New SqlDataAdapter("select Distinct nombre as NOMBRE,(select total from fact_tot where fact_tot.letra = fact_cab.letra_fact and fact_tot.num_factura = fact_cab.num_fact1 and fact_tot.tipo_factura = fact_cab.tipo_fact and fact_tot.pref = fact_cab.prefijo_fact and fact_cab.talon = fact_tot.talon2)as TOTAL from fact_cab inner join fact_det on n_carga = '" & RTrim(Me.txt_n_carga.Text) & "' and fact_cab.fec_emision = '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_det.letra_fact1 = fact_cab.letra_fact and fact_det.num_fact = fact_cab.num_fact1 and fact_det.tipo_fact2 = fact_cab.tipo_fact and fact_det.prefijo_fact2= fact_cab.prefijo_fact and fact_cab.talon = fact_det.talon1", conex)
        comando.Fill(tb)

        Me.DataGridView1.DataSource = tb

        For i = 0 To tb.Rows.Count - 1
            tot = tot + Val(Me.DataGridView1.Rows(i).Cells(1).Value)
        Next

        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = tot
        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen

        Me.DataGridView1.Columns(0).Width = 400

        comando = New SqlDataAdapter("select D.nom_producto,FLOOR((sum(D.cantidad1)/(select cantidad_bulto from art_01 as A where A.id_art = D.codi_producto))),sum(D.cantidad1),(select cantidad_bulto from art_01 as A where A.id_art = D.codi_producto) as BULTO_X  from fact_det as D where D.n_carga = '" & RTrim(Me.txt_n_carga.Text) & "' and D.fec_emi = '" & RTrim(Me.dt_fec_desde.Text) & "' and D.tipo_fact2 = 'FC' group by D.nom_producto,D.codi_producto", conex)
        comando.Fill(tb1)

        Me.DataGridView2.DataSource = tb1

        For i = 0 To Me.DataGridView2.Rows.Count - 2

            Dim x As String = Me.DataGridView2.Rows(i).Cells(2).Value Mod Me.DataGridView2.Rows(i).Cells(3).Value
            Me.DataGridView2.Rows(i).Cells(2).Value = x

        Next

        Me.DataGridView2.Columns(0).HeaderText = "Producto"
        Me.DataGridView2.Columns(1).HeaderText = "Bultos"
        Me.DataGridView2.Columns(2).HeaderText = "Unidades"
        Me.DataGridView2.Columns(3).Visible = False

        Me.DataGridView2.Columns(0).Width = 510
        Me.DataGridView2.Columns(1).Width = 100
        Me.DataGridView2.Columns(2).Width = 100

        Me.txt_comentario.Text = "Numero carga:" & "  " & Me.txt_n_carga.Text & vbCrLf & "Fecha desde:" & "   " & Me.dt_fec_desde.Text

    End Sub

    Private Sub txt_n_carga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_n_carga.KeyDown

        If e.KeyCode = Keys.Return Then

            xxx.instruccion = "select id,carga from carga_01 where id like '" & Trim(Me.txt_n_carga.Text) & "'"
            xxx.codigo = "id"
            xxx.nombre = "carga"
            xxx.cargar()

            Me.txt_n_carga.Text = (xxx.text)
            Me.lbl_nombre_carga.Text = Trim(xxx.text2)

            If Me.txt_n_carga.Text = "" Then
                Me.txt_n_carga.Focus()
                Exit Sub
            End If

            Me.cmd_aceptar.Focus()

        End If

        If e.KeyCode = Keys.F1 Then

            busc_carga.Show()

        End If

    End Sub

    Private Sub txt_n_carga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_carga.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_exporta.Click

        Form_exporta.Show()

    End Sub

    Private Sub Form_parte_carga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_estado_form.Text = 1
    End Sub

End Class