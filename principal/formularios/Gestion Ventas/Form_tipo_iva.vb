Public Class form_tipo_iva

    Dim iva As New pymsoft.iva
    Dim num As New pymsoft.numerodecimales

    Private Sub form_tipo_iva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.cmb_estado_imp_int.Text = Me.cmb_estado_imp_int.Items(0)
        iva.instruccion1 = "select * from iva_01"
        iva.mostrar_iva()
        iva.instruccion1 = "select * from imp_interno"
        iva.mostrar_imp_interno()

    End Sub

    Private Sub cmb_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.cmb_estado.Text = "Activo" Then
            Me.TextBox1.Text = "A"
        Else
            Me.TextBox1.Text = "B"
        End If

    End Sub

    Private Sub limpiar()

        If Me.TabControl1.SelectedIndex = 0 Then

            Me.txt_iva_ins.Text = 0
            Me.txt_iva_nins.Text = 0
            Me.txt_cta_iva_cmp_in.Text = ""
            Me.txt_cta_iva_cmp_nins.Text = ""
            Me.txt_cta_iva_vta_in.Text = ""
            Me.txt_cta_iva_vta_nin.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_codigo_iva.Text = ""
            Me.txt_codigo_iva.Focus()

        End If

        If Me.TabControl1.SelectedIndex = 1 Then

            Me.txt_cod_imp_interno.Text = ""
            Me.txt_nombre_imp_int.Text = ""
            Me.txt_importe_imp.Text = ""
            Me.txt_cod_imp_interno.Focus()

        End If

    End Sub

    Private Sub limpiar_carga()

        If Me.TabControl1.SelectedIndex = 0 Then

            Me.txt_iva_ins.Text = 0
            Me.txt_iva_nins.Text = 0
            Me.txt_cta_iva_cmp_in.Text = ""
            Me.txt_cta_iva_cmp_nins.Text = ""
            Me.txt_cta_iva_vta_in.Text = ""
            Me.txt_cta_iva_vta_nin.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_codigo_iva.Focus()

        End If

        If Me.TabControl1.SelectedIndex = 1 Then

            Me.txt_nombre_imp_int.Text = ""
            Me.txt_importe_imp.Text = ""
            Me.txt_nombre_imp_int.Focus()

        End If

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        If Me.TabControl1.SelectedIndex = 0 Then

            iva.instruccion = "update iva_01 set nombre = '" & Me.txt_descripcion.Text & "', iva_insc = '" & Me.txt_iva_ins.Text & "',iva_ninsc ='" & Me.txt_iva_nins.Text & "',cta_vta_ins='" & Me.txt_cta_iva_vta_in.Text & "',cta_vta_nins ='" & Me.txt_cta_iva_vta_nin.Text & "',cta_cmp_ins ='" & Me.txt_cta_iva_cmp_in.Text & "',cta_cmp_nins ='" & Me.txt_cta_iva_cmp_nins.Text & "',fec_alta ='" & Me.dt_fec_alta.Text & "',letra_estado ='" & Me.TextBox1.Text & "',estado ='" & Me.cmb_estado.Text & "' where id_iva = '" & Me.txt_interno.Text & "'"
            iva.actualizar()
            Call limpiar()

        End If

        If Me.TabControl1.SelectedIndex = 1 Then

            iva.instruccion = "update imp_interno set cod_int = '" & Me.txt_cod_imp_interno.Text & "', nombre = '" & Me.txt_nombre_imp_int.Text & "',monto = '" & Me.txt_nombre_imp_int.Text & "', fec_alta ='" & Me.dt_fec_alta_imp_int.Text & "',letra ='" & Me.TextBox3.Text & "',estado ='" & Me.cmb_estado_imp_int.Text & "' where cod_int = '" & Me.txt_cod_interno1.Text & "'"
            iva.actualizar()
            Call limpiar()

        End If

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Dim x As Integer = MessageBox.Show("Esta seguro de Borrarlo!!", "PyM soft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If x = 6 Then

            If Me.TabControl1.SelectedIndex = 0 Then

                iva.instruccion = "DELETE iva_01 WHERE id_iva = '" & Me.txt_codigo_iva.Text & "'"
                iva.borrar()
                Call limpiar()

            End If

            If Me.TabControl1.SelectedIndex = 1 Then

                iva.instruccion = "DELETE imp_interno WHERE cod_int = '" & Me.txt_cod_imp_interno.Text & "'"
                iva.borrar()
                Call limpiar()

            End If

        End If

    End Sub

    Private Sub txt_codigo_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_iva.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            iva.instruccion1 = "select * from iva_01 where id_iva like '" & Me.txt_codigo_iva.Text & "'"
            iva.mostrar_iva()

            If iva.veri = False Then
                Call limpiar_carga()
            End If

            Me.txt_descripcion.Focus()

        End If

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        If Me.TabControl1.SelectedIndex = 0 Then

            iva.instruccion1 = "select id_iva from iva_01 where id_iva like '" & Me.txt_codigo_iva.Text & "'"
            iva.verificar_duplicado()

            If iva.duplicado = True Then
                iva.instruccion = "INSERT INTO iva_01(id_iva ,nombre,iva_insc, iva_ninsc, cta_vta_ins, cta_vta_nins, cta_cmp_ins, cta_cmp_nins, fec_alta, letra_estado, estado) VALUES('" + Me.txt_codigo_iva.Text + "' , '" + Me.txt_descripcion.Text + "','" + Me.txt_iva_ins.Text + "','" + Me.txt_iva_nins.Text + "','" + Me.txt_cta_iva_vta_in.Text + "','" + Me.txt_cta_iva_vta_nin.Text + "','" + Me.txt_cta_iva_cmp_in.Text + "','" + Me.txt_cta_iva_cmp_nins.Text + "','" + Me.dt_fec_alta.Text + "','" + Me.TextBox1.Text + "','" + Me.cmb_estado.Text + "')"
                iva.agregar()
                Call limpiar()
            End If

        End If

        If Me.TabControl1.SelectedIndex = 1 Then

            iva.instruccion1 = "select cod_int from imp_interno where cod_int like '" & Me.txt_codigo_iva.Text & "'"
            iva.verificar_duplicado()

            If iva.duplicado = True Then
                iva.instruccion = "INSERT INTO imp_interno(cod_int,nombre,monto,fec_alta,letra,estado) VALUES('" + Me.txt_cod_imp_interno.Text + "' , '" + Me.txt_nombre_imp_int.Text + "','" + Me.txt_importe_imp.Text + "','" + Me.dt_fec_alta_imp_int.Text + "','" + Me.TextBox3.Text + "','" + Me.cmb_estado_imp_int.Text + "')"
                iva.agregar()
                Call limpiar()
            End If

        End If

    End Sub

    Private Sub opt_iva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_iva.CheckedChanged

        If Me.opt_iva.Checked = True Then
            Me.TabControl1.SelectTab(0)
            Me.txt_codigo_iva.Focus()
        End If

    End Sub

    Private Sub opt_imp_interno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_imp_interno.CheckedChanged
        If Me.opt_imp_interno.Checked = True Then
            Me.TabControl1.SelectTab(1)
            Me.txt_cod_imp_interno.Focus()
        End If
    End Sub

    Private Sub cmb_estado_imp_int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_estado_imp_int.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmb_estado_imp_int_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_estado_imp_int.SelectedIndexChanged

        If Me.cmb_estado_imp_int.Text = "Activo" Then
            Me.TextBox3.Text = "A"
        Else
            Me.TextBox3.Text = "B"
        End If

    End Sub

    Private Sub txt_cod_imp_interno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_imp_interno.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            iva.instruccion1 = "select * from imp_interno where cod_int like '" & Me.txt_cod_imp_interno.Text & "'"
            iva.mostrar_imp_interno()

            If iva.veri = False Then
                Call limpiar_carga()
            End If

            Me.txt_nombre_imp_int.Focus()

        End If

    End Sub

    Private Sub cmb_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_estado.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_iva_ins_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_iva_ins.KeyPress
        num.positivos_punto(e, Me.txt_iva_ins)
    End Sub

    Private Sub txt_iva_nins_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_iva_nins.KeyPress
        num.positivos_punto(e, Me.txt_iva_nins)
    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\IVA_IMP.html")
    End Sub
End Class
