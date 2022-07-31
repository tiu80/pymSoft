Public Class Form_busc_empleados

    Private Sub cmd_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_salir.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                Form_movimiento.carga_codigo_empleado(Me.DataGridView1.SelectedCells.Item(0).Value)
                Form_movimiento.llena_grilla_empleado()
                Form_movimiento.txt_cod_empleado.Text = Me.DataGridView1.SelectedCells.Item(0).Value
                Form_movimiento.lbl_nombre.Text = Me.DataGridView1.SelectedCells.Item(1).Value
                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description, "NOAL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class