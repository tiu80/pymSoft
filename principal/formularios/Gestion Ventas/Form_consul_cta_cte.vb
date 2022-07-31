Public Class Form_consul_cta_cte

    Dim cli As New pymsoft.cliente1
    Public activo As Boolean = False
    Public talonario As Short = 2

    Private Sub Form_consul_cta_cte_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Form_cta_cte.Dispose()
    End Sub

    Private Sub Form_consul_cat_cte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form_recibos.txt_estado_form.Text = 1 Then
            MessageBox.Show("Finalize el recibo y vuelva a intentarlo", "pyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Me.cmb_modadildad.Text = Me.cmb_modadildad.Items(0)
    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown
        If e.KeyCode = Keys.F1 Then
            activo = False
            busc_cliente.Show()
        End If
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            activo = False
            If Me.txt_estado_form.Text = 1 Then cli.insruccion = "select id_cli,nombre from cli_01 where id_cli like '" & RTrim(Me.txt_codigo.Text) & "' and tipo_cliente = 'Cliente' and estado = 'ACTIVO'"
            If Me.txt_estado_form.Text = 2 Then cli.insruccion = "select id_cli,nombre from cli_01 where id_cli like '" & RTrim(Me.txt_codigo.Text) & "' and tipo_cliente = 'Proveedor' and estado = 'ACTIVO'"
            cli.cargar_registro()
            activo = True
            If cli.verifica = False Then
                Me.lbl_cliente.Text = ""
            Else
                Me.dt_fec_emi.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()
        Form_cta_cte.txt_estado_form.Text = Me.txt_estado_form.Text
        Form_cta_cte.Show()
    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub dt_fec_emi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_emi.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_hasta.Focus()
        End If
    End Sub

    Private Sub dt_fec_hasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_hasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_modadildad.Focus()
        End If
    End Sub

    Private Sub cmb_modadildad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_modadildad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_aceptar.Focus()
        End If
    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
            talonario = 1
        Else
            Me.Check_talonario.BackColor = Color.Black
            talonario = 2
        End If
    End Sub

End Class