Public Class form_menu

    Dim men As New pymsoft.menu
    Dim val As Boolean
    Dim verifica As Boolean

    Private Sub Tree_modulo_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Tree_modulo.AfterSelect

        If Me.Tree_modulo.SelectedNode.Text = "Altas y Actualizaciones" Then

            Me.TabControl1.SelectTab(0)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Gestion Ventas" Then

            Me.TabControl1.SelectTab(1)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Contabilidad General" Then

            Me.TabControl1.SelectTab(3)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Gestion Compras" Then

            Me.TabControl1.SelectTab(2)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Configuracion" Then

            Me.TabControl1.SelectTab(4)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Reportes/Estadisticos" Then

            Me.TabControl1.SelectTab(6)
            Me.Tree_modulo.Focus()

        End If

        If Me.Tree_modulo.SelectedNode.Text = "Stock" Then

            Me.TabControl1.SelectTab(5)
            Me.Tree_modulo.Focus()

        End If

    End Sub

    Private Sub cmd_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_agregar.Click

        Call verifica_datos()

        If verifica = True Then

            men.instruccion = "select id_menu from sub_menu_01 where id_menu like '" & Me.txt_codigo.Text & "'"
            men.verifica_duplicado()

            If men.verifica = True Then

                val = True

                Call recorre_arbol()

                MessageBox.Show("Configuracion Guardada", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Call recorre_arbol_limpia()

                Me.Dispose()

            End If

        End If

    End Sub

    Public Sub recorre_arbol()

        Dim i As Integer

        For i = 0 To Me.Tree_modulo.Nodes.Count - 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_altas
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.tree_ventas
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_compras
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_contabilidad
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_config
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_stock
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            men.padre = Me.Tree_modulo.Nodes(i).Text
            men.arbol = Me.Tree_reporte
            If val = True Then men.carga_Modulo()
            If val = False Then men.actualiza_Modulo()

            i = i + 1

            If val = True Then men.carga_menu()
            If val = False Then men.actualiza_menu()

        Next

    End Sub

    Public Sub recorre_arbol_limpia()

        Dim i As Integer

        For i = 0 To Me.Tree_modulo.Nodes.Count - 1

            men.arbol = Me.Tree_altas
            men.limpiar()

            i = i + 1

            men.arbol = Me.tree_ventas
            men.limpiar()

            i = i + 1

            men.arbol = Me.Tree_compras
            men.limpiar()

            i = i + 1

            men.arbol = Me.Tree_contabilidad
            men.limpiar()

            i = i + 1

            men.arbol = Me.Tree_config
            men.limpiar()

            i = i + 1

            men.arbol = Me.Tree_stock
            men.limpiar()

            i = i + 1

            men.arbol = Me.Tree_reporte
            men.limpiar()

            i = i + 1

        Next

        If men.valida = True Then Me.txt_codigo.Text = ""
        Me.txt_nombre.Text = ""

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        Call verifica_datos()

        If verifica = True Then

            val = False

            Call recorre_arbol()

            Call recorre_arbol_limpia()

            Me.txt_codigo.Focus()

        End If

    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click

        Dim a As Short = MessageBox.Show("Esta seguro que desea borrar el Menu", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            men.instruccion = "DELETE sub_menu_01 WHERE id_menu= '" & Me.txt_codigo.Text & "'"
            men.abm()

            men.instruccion = "DELETE menu01 WHERE id_menu01 = '" & Me.txt_codigo.Text & "'"
            men.abm()

            men.instruccion = "update menu_usu set menu= ' ' where menu ='" & Me.txt_codigo.Text & "'"
            men.abm()

            Call recorre_arbol_limpia()

            Me.txt_codigo.Focus()

        End If

    End Sub

    Public Sub verifica_datos()

        If Me.txt_codigo.Text = "" Or Me.txt_nombre.Text = "" Then
            MessageBox.Show("Complete los capos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            verifica = False
        Else
            verifica = True
        End If

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            men.modulo = "Altas y Actualizaciones"
            men.arbol = Me.Tree_altas
            men.mostrar_sub_menu()

            men.modulo = "Gestion Ventas"
            men.arbol = Me.tree_ventas
            men.mostrar_sub_menu()

            men.modulo = "Gestion Compras"
            men.arbol = Me.Tree_compras
            men.mostrar_sub_menu()

            men.modulo = "Contabilidad General"
            men.arbol = Me.Tree_contabilidad
            men.mostrar_sub_menu()

            men.modulo = "Configuracion"
            men.arbol = Me.Tree_config
            men.mostrar_sub_menu()

            men.modulo = "Stock"
            men.arbol = Me.Tree_stock
            men.mostrar_sub_menu()

            men.modulo = "Reportes/Estadisticos"
            men.arbol = Me.Tree_reporte
            men.mostrar_sub_menu()

            men.mostrar_menu()

            men.mostrar_nombre_menu()
            Me.txt_nombre.Focus()

            If Me.txt_codigo.Text = 1 Then

                Me.Tree_altas.Enabled = False
                Me.Tree_modulo.Enabled = False
                Me.txt_nombre.Enabled = False

            Else

                Me.Tree_modulo.Enabled = True
                Me.Tree_altas.Enabled = True
                Me.txt_nombre.Enabled = True

            End If

        End If

        If e.KeyCode = Keys.F10 Then

            Me.txt_codigo.Text = 1
            Me.txt_nombre.Text = "Administrador"

            men.instruccion = "DELETE sub_menu_01 WHERE id_menu= '" & Me.txt_codigo.Text & "'"
            men.abm()

            men.instruccion = "DELETE menu01 WHERE id_menu01 = '" & Me.txt_codigo.Text & "'"
            men.abm()

            val = True
            recorre_arbol()

        End If

    End Sub

End Class
