Public Class form_vendedor

    Dim ven As New pymsoft.vendedor
    Dim ver As Boolean = True

    Private Sub cmb_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_estado.SelectedIndexChanged

        If Me.cmb_estado.SelectedIndex = 0 Then
            Me.txt_tipo.Text = "A"
        End If
        If Me.cmb_estado.SelectedIndex = 1 Then
            Me.txt_tipo.Text = "B"
        End If

    End Sub

    Private Sub form_vendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.txt_estado_form.Text = 1
        ven.carga2()
        ven.carga_vendedores_grilla()

        Me.cmd_actualizar.BackColor = Color.LightGray
        Me.cmd_borrar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        ven.agregar_vendedor()
        ven.carga2()

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click
        ven.actualiza_vend_facturas()
        ven.actualizar()
    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

        If Me.txt_nombre.Text <> "" Then
            Me.txt_desc.Text = Me.txt_nombre.Text
        End If

    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click
        If ver = True Then
            ven.borrar()
        Else
            MsgBox("No se puede Borrar", MsgBoxStyle.Information, "PyMsoft")
            ven.mostrar()
        End If
    End Sub

    Private Sub cmd_sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_sig.Click
        ven.sig()
    End Sub

    Private Sub cmd_ult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ult.Click
        ven.fin()
    End Sub

    Private Sub cmd_pri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_pri.Click
        ven.inicio()
    End Sub

    Private Sub cmd_ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ant.Click
        ven.ant()
    End Sub

    Private Sub txt_codigo_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Return Then
            ven.cargar(Me.txt_codigo.Text)
        End If
        If e.KeyCode = Keys.Tab Then
            ven.cargar(Me.txt_codigo.Text)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then
            ven.cargar(Me.DataGridView1.SelectedCells(0).Value)
        End If
    End Sub

    Private Sub opt_varios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_varios.CheckedChanged
        If Me.opt_varios.Checked = True Then
            Me.lbl_tipo.Text = "Varios"
        End If
    End Sub

    Private Sub opt_mostrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_mostrador.CheckedChanged
        If Me.opt_mostrador.Checked = True Then
            Me.lbl_tipo.Text = "Mostrador"
        End If
    End Sub

    Private Sub opt_preventa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_preventa.CheckedChanged
        If Me.opt_preventa.Checked = True Then
            Me.lbl_tipo.Text = "Preventa"
        End If
    End Sub
End Class