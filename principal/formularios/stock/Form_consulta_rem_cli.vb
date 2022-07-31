Imports System.Data
Imports System.Data.SqlClient

Public Class Form_consulta_rem_cli

    Public tbl As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim cli As New pymsoft.cliente1
    Public activo As Boolean = False

    Private Sub Form_consulta_rem_cli_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.txt_estado_form.Text = 0
        Me.Dispose()
    End Sub

    Private Sub Form_consulta_rem_cli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_filtro.Text = Me.cmb_filtro.Items(0)
        Me.cmb_agrupacion.Text = Me.cmb_agrupacion.Items(0)
        Me.txt_estado_form.Text = 1
        Me.txt_codigo.Text = ""
        Me.lbl_cliente.Text = ""
        Me.txt_codigo.Focus()
        conex = conecta()
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then
            activo = False
            Me.txt_estado_form.Text = 1
            busc_cliente.Show()
        End If

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_estado_form.Text = 1
            activo = False
            cli.insruccion = "select *from cli_01 where id_cli like '" & Me.txt_codigo.Text & "'"
            cli.cargar_registro()
            activo = True
        End If

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        tbl.Clear()

        If Me.cmb_agrupacion.Text = "Total" Then
            comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,total from fact_cab inner join fact_tot on fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.talon = fact_tot.talon2 and fact_cab.id_cli = '" & RTrim(Me.txt_codigo.Text) & "' where fact_cab.fec_emision >= '" & Me.dt_fec_desde.Text & "' and fact_cab.fec_emision <= '" & Me.dt_fec_hasta.Text & "' and (fact_cab.tipo_fact = 'RE' or fact_cab.tipo_fact = 'RS')", conex)
            comando.Fill(tbl)
        End If

        If Me.cmb_agrupacion.Text = "Entrada" Then
            comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,total from fact_cab inner join fact_tot on fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.talon = fact_tot.talon2 and fact_cab.id_cli = '" & RTrim(Me.txt_codigo.Text) & "' where fact_cab.fec_emision >= '" & Me.dt_fec_desde.Text & "' and fact_cab.fec_emision <= '" & Me.dt_fec_hasta.Text & "' and fact_cab.tipo_fact = 'RE'", conex)
            comando.Fill(tbl)
        End If

        If Me.cmb_agrupacion.Text = "Salida" Then
            comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,total from fact_cab inner join fact_tot on fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.talon = fact_tot.talon2 and fact_cab.id_cli = '" & RTrim(Me.txt_codigo.Text) & "' where fact_cab.fec_emision >= '" & Me.dt_fec_desde.Text & "' and fact_cab.fec_emision <= '" & Me.dt_fec_hasta.Text & "' and fact_cab.tipo_fact = 'RS'", conex)
            comando.Fill(tbl)
        End If

        Form_muestra_rem_cli.Show()

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub
End Class