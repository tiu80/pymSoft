Imports System.Data
Imports System.Data.SqlClient

Public Class Form_consulta_comprobante

    Dim conex As New SqlConnection
    Public midataset As New DataSet
    Public talonario, index As Integer
    Dim fact As New pymsoft.factura
    Dim comando As SqlDataAdapter

    Private Sub Form_consulta_comprobante_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Form_muestra_cons_comp.Dispose()
        Form_muestra_factura.Dispose()
    End Sub

    Private Sub Form_consulta_comprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub Form_consulta_comprobante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)

        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)
        Me.Check_talonario.BackColor = Color.Black
        fact.carga_parametro()
        If fact.habilita_consulta_mixta = "NO" Then Me.Check_talonario.Visible = False
        conex = conecta()

        If Trim(principal.lbl_usu.Text) <> "Administrador" Then

            Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(2)
            Me.cmb_modalidad.Enabled = False

        End If

    End Sub

    Private Sub cmb_modalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_modalidad.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmb_cliente_total.Visible = True Then
                Me.cmb_cliente_total.Focus()
            ElseIf Me.txt_n_carga.Visible = True Then
                Me.txt_n_carga.Focus()
            Else
                Me.cmd_aceptar.Focus()
            End If
        End If
    End Sub

    Private Sub cmb_modalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_modalidad.SelectedIndexChanged

        Dim midataset As New DataSet
        Dim a As Boolean = True

        If Me.cmb_modalidad.Text = "Cliente/Proveedor" Then

            Me.cmb_cliente_total.Visible = True
            Me.Label7.Visible = True

            If Me.txt_estado_form.Text = 0 Then comando = New SqlDataAdapter("select nombre from cli_01 where tipo_cliente = 'Cliente' ORDER BY nombre ASC", conex)
            comando.Fill(midataset, "cli_01")
            comando.Dispose()

            Me.cmb_cliente_total.DataSource = midataset.Tables("cli_01")
            Me.cmb_cliente_total.ValueMember = "nombre"

            a = False

        End If

        If Me.cmb_modalidad.Text = "Vendedor" Then

            Me.cmb_cliente_total.Visible = True
            Me.Label7.Visible = True

            If Trim(principal.lbl_usu.Text) <> "Administrador" Then

                Me.cmb_cliente_total.Items.Add(principal.lbl_usu.Text)
                Me.cmb_cliente_total.Text = Me.cmb_cliente_total.Items(0)
                Me.cmb_cliente_total.Enabled = False

            Else

                comando = New SqlDataAdapter("select nombre from vend_01 ORDER BY nombre ASC", conex)
                comando.Fill(midataset, "vend_01")
                comando.Dispose()

                Me.cmb_cliente_total.DataSource = midataset.Tables("vend_01")
                Me.cmb_cliente_total.ValueMember = "nombre"

            End If

            a = False

        End If

        If Me.cmb_modalidad.Text = "Zona" Then

            Me.cmb_cliente_total.Visible = True
            Me.Label7.Visible = True

            comando = New SqlDataAdapter("select zona from zona_01 ORDER BY zona ASC", conex)
            comando.Fill(midataset, "zona_01")
            comando.Dispose()

            Me.cmb_cliente_total.DataSource = midataset.Tables("zona_01")
            Me.cmb_cliente_total.ValueMember = "zona"

            a = False

        End If

        If a = True Then
            Me.cmb_cliente_total.Visible = False
            Me.Label7.Visible = False
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

        midataset.Clear()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        Form_muestra_cons_comp.Show()

    End Sub


    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click

        Me.Dispose()

    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
        Else
            Me.Check_talonario.BackColor = Color.Black
        End If
    End Sub

    Private Sub txt_n_carga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_carga.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmb_tipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_tipo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_modalidad.Focus()
        End If
    End Sub

    Private Sub cmb_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_tipo.SelectedIndexChanged

        If RTrim(Me.cmb_tipo.Text) = "Pedidos" Then
            If fact.pide_n_carga = "SI" Then Me.lbl_n_carga.Visible = True
            If fact.pide_n_carga = "SI" Then Me.txt_n_carga.Visible = True
        Else
            If fact.pide_n_carga = "NO" Then Me.lbl_n_carga.Visible = False
            If fact.pide_n_carga = "NO" Then Me.txt_n_carga.Visible = False
        End If

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

    Private Sub cmb_cliente_total_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_cliente_total.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_n_carga.Visible = True Then
                Me.txt_n_carga.Focus()
            Else
                Me.cmd_aceptar.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_aceptar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmd_aceptar.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class