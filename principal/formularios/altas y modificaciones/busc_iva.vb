Public Class busc_iva

    Dim iva As New pymsoft.prov_vend_list_bco

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click
        iva.adapter = "select *from iva_01 where nombre like '" & Me.txt_iva.Text & "%'"
        iva.tabla = "iva_01"
        iva.cabecera_nombre = "I.V.A"
        iva.formulario = Me
        iva.buscar()
        Me.DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            iva.instruccion = "select *from iva_01 where id_iva like '" & Me.DataGridView1.SelectedCells(0).Value & "'"
            iva.codigo = "id_iva"
            iva.nombre = "iva_insc"
            iva.cargar()

            If Form_articulos.txt_estado_form.Text = 1 And Form_articulos.page = 0 Then

                Form_articulos.txt_codigo_iva.Text = iva.text
                Form_articulos.lbl_tipo_iva.Text = iva.text2
                Form_articulos.txt_impuestos_internos.Focus()

            End If

            If Form_articulos.txt_estado_form.Text = 3 And Form_articulos.page = 2 Then

                Form_articulos.txt_codigo_iva_expotador.Text = iva.text
                Form_articulos.lbl_tipo_iva_exportador.Text = iva.text2
                Form_articulos.cmd_exporta.Focus()

            End If

            If Form_compras.txt_estado_form.Text = 1 Then
                iva.codigo = "id_iva"
                iva.nombre = "iva_insc"
                iva.cargar()

                If iva.text = "1" Then Form_compras.lbl_iva.Text = "I.V.A 21 %"
                If iva.text = "2" Then Form_compras.lbl_iva.Text = "I.V.A 10.5 %"
                If iva.text = "3" Then Form_compras.lbl_iva.Text = "Exento"
                If iva.text = "4" Then Form_compras.lbl_iva.Text = "I.V.A 27 %"
                Form_compras.txt_cod_iva.Text = iva.text

            End If

            'If Val(Form_articulos.lbl_tipo_iva.Text) = "21" Then
            'Form_articulos.lbl_nombre_iva.Text = " % " & "Resp.Insc"
            'End If
            'If Val(Form_articulos.lbl_tipo_iva.Text) = "10.5" Then
            'Form_articulos.lbl_nombre_iva.Text = " % " & "Resp.No Insc"
            'End If
            'If Val(Form_articulos.lbl_tipo_iva.Text) = "0" Then
            'Form_articulos.lbl_nombre_iva.Text = " % " & "Exento"
            'End If

            Me.Dispose()

        End If
    End Sub

    Private Sub txt_provincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_iva.KeyDown
        If e.KeyCode = Keys.Return Then
            iva.instruccion = "select *from iva_01 where nombre like '" & Me.txt_iva.Text & "%'"
            iva.tabla = "iva_01"
            iva.cabecera_nombre = "I.V.A"
            iva.formulario = Me
            iva.buscar()
            Me.DataGridView1.Focus()
        End If
    End Sub

    Public Sub tipo_iva()

        iva.instruccion = "select *from iva_01 where id_iva like '" & Form_compras.txt_cod_iva.Text & "'"

        iva.codigo = "id_iva"
        iva.nombre = "iva_insc"
        iva.cargar()

        If iva.text = "1" Then Form_compras.lbl_iva.Text = "I.V.A 21 %"
        If iva.text = "2" Then Form_compras.lbl_iva.Text = "I.V.A 10.5 %"
        If iva.text = "3" Then Form_compras.lbl_iva.Text = "Exento"
        If iva.text = "4" Then Form_compras.lbl_iva.Text = "I.V.A 27 %"

    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click
        Me.Close()
    End Sub

End Class