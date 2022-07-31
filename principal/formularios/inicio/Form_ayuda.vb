Public Class Form_ayuda

    Private Sub mover_arbol()

        Try

            If Me.TreeView1.SelectedNode.Text = "Facturacion" Then

                Me.TabControl1.SelectTab(0)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Altas" Then

                Me.TabControl1.SelectTab(1)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Cuenta Corriente" Then

                Me.TabControl1.SelectTab(2)
                Me.TreeView1.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Call mover_arbol()
    End Sub

    Private Sub TreeView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyDown
        Call mover_arbol()
    End Sub

    Private Sub TreeView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyUp
        Call mover_arbol()
    End Sub

End Class