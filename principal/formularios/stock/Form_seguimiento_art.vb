Imports System.Data
Imports System.Data.SqlClient

Public Class Form_seguimiento_art

    Public tipo As Short
    Public corte As Single
    Dim conex As New SqlConnection
    Dim tabla As New DataTable
    Dim tabla1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Public val As Short
    Dim talonario As Integer
    Dim fact As New pymsoft.factura

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            tipo = 1
            If Me.txt_codigo.Text <> "" Then busc_articulos.carga_codigo_seguimiento(Me.txt_codigo.Text, 1)
        End If

        If e.KeyCode = Keys.F1 Then
            tipo = 2
            busc_articulos.txt_lista.Text = principal.txt_lista_pred.Text
            busc_articulos.Show()
        End If

    End Sub

    Private Sub Form_seguimiento_art_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_modadildad.Text = Me.cmb_modadildad.Items(0)
        Me.txt_estado_form.Text = 1
        Me.Check_talonario.BackColor = Color.Black
        conex = conecta()
        fact.carga_parametro()

        If fact.habilita_consulta_mixta = "NO" Then
            Me.Check_talonario.Visible = False
            Me.cmb_modadildad.Items.Remove(Me.cmb_modadildad.Items(2))
        End If

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.Check_talonario.Visible = True Then

            If Me.Check_talonario.Checked = True Then
                talonario = 1  ' blanco
            Else
                talonario = 2   ' negro
            End If

        Else

            talonario = 1

        End If

        val = 1
        Call muestra_cabeceras()

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click

        Me.Dispose()

    End Sub

    Public Sub muestra_cabeceras()

        Try

            tabla.Clear()
            tabla1.Clear()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            If RTrim(Me.cmb_modadildad.Text) <> "3- Combinado" Then

                comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,nombre,cantidad1,estado_fact,talon from fact_cab inner join fact_det on fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.letra_fact = fact_det.letra_fact1 and fact_cab.prefijo_fact = fact_det.prefijo_fact2 and fact_cab.num_fact1 = fact_det.num_fact and fact_cab.talon = fact_det.talon1 and fact_cab.talon = '" & talonario & "' and fact_det.codi_producto = '" & RTrim(Me.txt_codigo.Text) & "' where fact_cab.fec_emision >= '" & Me.dt_fec_emi.Text & "' and fact_cab.fec_emision <= '" & Me.dt_fec_hasta.Text & "' order by fec_emision", conex)
                comando.Fill(tabla)
                comando.Dispose()
                comando = New SqlDataAdapter("select cantidad,fec_modi,stock_corte from art_01 where id_art='" & Me.txt_codigo.Text & "'", conex)
                comando.Fill(tabla1)
                comando.Dispose()

            Else

                comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,nombre,cantidad1,estado_fact,talon from fact_cab inner join fact_det on fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.letra_fact = fact_det.letra_fact1 and fact_cab.prefijo_fact = fact_det.prefijo_fact2 and fact_cab.num_fact1 = fact_det.num_fact and fact_cab.talon = fact_det.talon1 and fact_det.codi_producto = '" & RTrim(Me.txt_codigo.Text) & "' where fact_cab.fec_emision >= '" & Me.dt_fec_emi.Text & "' and fact_cab.fec_emision <= '" & Me.dt_fec_hasta.Text & "' order by fec_emision", conex)
                comando.Fill(tabla)
                comando.Dispose()
                comando = New SqlDataAdapter("select cantidad,fec_modi,stock_corte from art_01 where id_art='" & Me.txt_codigo.Text & "'", conex)
                comando.Fill(tabla1)
                comando.Dispose()

            End If

            If tabla.Rows.Count = 0 Then
                MessageBox.Show("No hay Datos para Mostrar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                barra_carga.Timer1.Enabled = True
                Exit Sub
            End If

            Form_muestra_seguim.txt_codigo.Text = Me.txt_codigo.Text
            Form_muestra_seguim.txt_fec_emi.Text = Me.dt_fec_emi.Text
            Form_muestra_seguim.txt_fec_hasta.Text = Me.dt_fec_hasta.Text

            corte = tabla1.Rows(0).Item(2)

            Form_muestra_seguim.DataGridView1.DataSource = tabla

            Form_muestra_seguim.txt_comentario.Text = "Movimiento del :" & "  " & Me.dt_fec_emi.Text & "    " & "Hasta" & "   " & Me.dt_fec_hasta.Text & vbCrLf & "Modalidad:" & "  " & Me.cmb_modadildad.Text & "     " & "Lista:" & principal.txt_lista_pred.Text & vbCrLf & "Articulo: " & "   " & Me.txt_codigo.Text & " " & Me.lbl_articulo.Text & vbCrLf & "Fecha Corte:" & " " & tabla1.Rows(0).Item(1) & " " & ":" & tabla1.Rows(0).Item(2) & vbCrLf & "Stock Actual:" & " " & tabla1.Rows(0).Item(0) & vbCrLf & "Estado:" & " " & tabla.Rows(0).Item(7)

            Form_muestra_seguim.Show()

            Dim a As Integer = Form_muestra_seguim.DataGridView1.Rows.Count - 1
            Form_muestra_seguim.DataGridView1.Rows(a).DefaultCellStyle.BackColor = Color.LightGreen

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
        Else
            Me.Check_talonario.BackColor = Color.Black
        End If
    End Sub

End Class