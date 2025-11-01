Imports System.Data
Imports System.Data.SqlClient

Public Class Form_consulta_compras

    Dim comando As SqlDataAdapter
    Dim tb As New DataTable, tb1 As New DataTable
    Dim comando1 As SqlCommand
    Dim conex As New SqlConnection
    Dim talonario As Short
    Dim fact As New pymsoft.factura

    Private Sub Form_consulta_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)
        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)
        fact.carga_parametro()
        If fact.habilita_consulta_mixta = "NO" Then Me.Check_talonario.Visible = False
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

        tb.Clear()
        tb1.Clear()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        conex = conecta()

        If Me.cmb_tipo.Text = "Factura" Then
            comando = New SqlDataAdapter("select fec_emi,tipo,prefijo,letra,numero,nombre,total,id_cliente from compra_cab inner join compra_tot on compra_cab.talon = '" & talonario & "' and compra_cab.numero = compra_tot.num1 and compra_cab.letra = compra_tot.lt1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.id_cliente = compra_tot.id_cli1 where fec_emi >= '" & Me.dt_fec_ini.Text & "' and fec_emi <= '" & Me.dt_fec_fin.Text & "' and compra_cab.tipo='FC'", conex)
            comando.Fill(tb)

            Form_consulta_compras_det.DataGridView1.DataSource = tb
        End If

        If Me.cmb_tipo.Text = "Nota de Credito" Then
            comando = New SqlDataAdapter("select fec_emi,tipo,prefijo,letra,numero,nombre,total,id_cliente from compra_cab inner join compra_tot on compra_cab.talon = '" & talonario & "' and compra_cab.numero = compra_tot.num1 and compra_cab.letra = compra_tot.lt1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.id_cliente = compra_tot.id_cli1 where fec_emi >= '" & Me.dt_fec_ini.Text & "' and fec_emi <= '" & Me.dt_fec_fin.Text & "' and compra_cab.tipo='NC'", conex)
            comando.Fill(tb)

            Form_consulta_compras_det.DataGridView1.DataSource = tb
        End If

        If Me.cmb_tipo.Text = "Orden Pago" Then
            comando = New SqlDataAdapter("select fec_emi,id_rec,tc,letra,pre,nombre,total from recibo_cab inner join recibo_tot on recibo_cab.talon = '" & talonario & "' and recibo_cab.talon = recibo_tot.talon2 and recibo_cab.p_venta2 = recibo_tot.p_venta and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.tc = recibo_tot.tip and recibo_cab.pre = recibo_tot.pre2 where fec_emi >= '" & Me.dt_fec_ini.Text & "' and fec_emi <= '" & Me.dt_fec_fin.Text & "' and recibo_cab.tc = 'OP' order by recibo_cab.fec_emi,recibo_cab.id_rec,recibo_cab.tc,recibo_cab.letra,recibo_cab.pre", conex)
            comando.Fill(tb1)

            Form_consulta_compras_det.DataGridView1.DataSource = tb1
        End If

        Form_consulta_compras_det.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub dt_fec_ini_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_ini.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_fin.Focus()
        End If
    End Sub

    Private Sub dt_fec_fin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_fin.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_tipo.Focus()
        End If
    End Sub

    Private Sub cmb_tipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_tipo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_modalidad.Focus()
        End If
    End Sub

    Private Sub cmb_modalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_modalidad.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmb_cliente_total.Visible = True Then
                Me.cmb_cliente_total.Focus()
            Else
                Me.cmd_aceptar.Focus()
            End If
        End If
    End Sub

End Class