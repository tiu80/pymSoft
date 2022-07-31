Public Class busc_imp_interno

    Dim iva As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        iva.adapter = "select *from imp_interno where nombre like '" & Me.txt_iva.Text & "%'"
        iva.tabla = "imp_interno"
        iva.cabecera_nombre = "Imp. Interno"
        iva.formulario = Me
        iva.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            iva.instruccion = "select *from imp_interno where cod_int like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            iva.codigo = "cod_int"
            iva.nombre = "monto"
            iva.cargar()

            If Form_articulos.txt_estado_form.Text = 1 Then

                Form_articulos.txt_impuestos_internos.Text = iva.text
                Form_articulos.lbl_nom_imp_int.Text = iva.text2
                Form_articulos.txt_descuento1.Focus()

            End If

            Me.Dispose()

        End If
    End Sub

    Private Sub txt_provincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_iva.KeyDown
        If e.KeyCode = Keys.Return Then
            iva.instruccion = "select *from imp_interno where nombre like '" & Me.txt_iva.Text & "%'"
            iva.tabla = "imp_interno"
            iva.cabecera_nombre = "Imp. Interno"
            iva.formulario = Me
            iva.buscar()
            Me.DataGridView1.Focus()
        End If
    End Sub

End Class