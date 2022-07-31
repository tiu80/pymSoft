Imports System.Data
Imports System.Data.SqlClient

Public Class busc_cliente

    Dim cli As New pymsoft.cliente1
    Dim tal As New pymsoft.talonario
    Dim fact As New pymsoft.factura
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tb As New DataTable
    Public factura_en_c As String

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click

        If Me.txt_buscar.Text <> "" Then
            cli.buscar()
        End If

    End Sub

    Private Sub cmd_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cerrar.Click

        Me.Dispose()
        form_factura.txt_cierra_form.Text = 1
        Form_recibos.txt_cierra_form.Text = 1

    End Sub

    Private Sub txt_buscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_buscar.KeyDown

        If e.KeyCode = Keys.Return Then

            cli.buscar()

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.DataGridView1.Rows(0).Cells(0).Value.ToString = "" Then Exit Sub

            If form_factura.txt_estado_form.Text = 1 Or RTrim(form_factura.tipo1) = "PD" Then

                If form_factura.ativo = False Then

                    form_factura.verifica_fecha(form_factura.dt_fec_emision.Value.Month, form_factura.dt_fec_emision.Value.Year)

                    If form_factura.fecha_mala = False Then
                        form_factura.Dispose()
                        Me.Dispose()
                        Exit Sub
                    End If

                    cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                    cli.cargar_registro()
                    If fact.vendedor_x_defecto <> 0 Then
                        conex = conecta()
                        comando = New SqlDataAdapter("select id_vendedor,nombre from vend_01 where id_vendedor= '" & fact.vendedor_x_defecto & "'", conex)
                        comando.Fill(tb)
                        form_factura.txt_vendedor.Text = tb.Rows(0).Item(0)
                        form_factura.txt_nom_vendedor.Text = tb.Rows(0).Item(1)
                        tb.Clear()
                        tb.Dispose()
                    End If
                    cli.carga_letra()
                    If form_factura.txt_talonario_pred.Text = "1" Then tal.instruccion = "select *from numerador where talon ='" & form_factura.txt_talonario_pred.Text & "' and punto_venta ='" & fact.punto_venta & "'"
                    If form_factura.txt_talonario_pred.Text = "2" Then tal.instruccion = "select *from numerador where talon ='" & form_factura.txt_talonario_pred.Text & "'"
                    tal.carga_numerador_factura()
                    Call form_factura.verifica_numerador_existente()
                    If form_factura.existe_num = True Then
                        form_factura.Close()
                        Me.Close()
                        Exit Sub
                    End If
                    form_factura.habilita_numeradores()
                    form_factura.habilita_desc()

                    form_factura.calcula_saldo_cta_cte()

                    If fact.Habilita_facturacion_especial = "SI" And form_factura.txt_talonario_pred.Text = 2 Then
                        form_factura.selecciona_lista_determinada(9999)
                    Else
                        form_factura.selecciona_lista_determinada(form_factura.txt_lista_predet.Text)
                    End If

                End If

            End If

            If Form_compras.txt_estado_form.Text = 1 And Form_compras.activo = True Then

                cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()
                Exit Sub

            End If

            If (RTrim(Form_consul_cta_cte.txt_estado_form.Text) = 1 Or RTrim(Form_consul_cta_cte.txt_estado_form.Text) = 2) And Form_consul_cta_cte.activo = False Then

                cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()

            End If

            If Form_resumen_cta.txt_estado_form.Text = 1 And Form_resumen_cta.activo = False Then

                cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()

            End If

            If Form_consulta_rem_cli.txt_estado_form.Text = 1 And Form_consulta_rem_cli.activo = False Then

                cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()
                Form_consulta_rem_cli.txt_estado_form.Text = 0

            End If

            If Form_presupuesto.txt_estado_form.Text = 1 And Form_presupuesto.activo = False Then

                cli.insruccion = "select *from cli_01 where id_cli = '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()

            End If

            If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) And Form_recibos.activo = False Then

                cli.insruccion = "select *from cli_01 where id_cli like '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()
                cli.carga_letra()
                tal.instruccion = "select *from numerador where talon ='" & Form_recibos.txt_talonario_pred.Text & "'"
                tal.carga_numerador_factura()
                Form_recibos.verifica_numerador_existente()
                If Form_recibos.existe_num = True Then
                    Form_recibos.Close()
                    Me.Close()
                    Exit Sub
                End If
                form_factura.verifica_fecha(Form_recibos.dt_fec_emision.Value.Month, Form_recibos.dt_fec_emision.Value.Year)
                If form_factura.fecha_mala = False Then Form_recibos.Close()
                Form_recibos.total_cta_cte()

                If fact.Pide_prefijo_recibo = "SI" Then
                    Form_recibos.txt_prefijo.Enabled = True
                    Form_recibos.txt_prefijo.Focus()
                End If

                If fact.Pide_numero_recibo = "SI" Then
                    Form_recibos.txt_numero.Enabled = True
                    Form_recibos.txt_numero.Focus()
                End If

                If fact.pide_vendedor_recibo = "SI" Then
                    Form_recibos.txt_vendedor.Enabled = True
                    Form_recibos.txt_vendedor.Focus()
                End If

                Form_recibos.txt_numerador_respaldo.Text = tal.numerador - 1

                Me.Dispose()

            End If

            If fact.sale = True Then
                form_factura.numerador = False
                Call form_factura.actualiza_numeradores()
                Me.Dispose()
                form_factura.Dispose()
                Exit Sub
            End If

            If RTrim(form_factura.txt_factura_notaCredito.Text) <> 1 And RTrim(form_factura.txt_factura_notaCredito.Text) <> 2 And RTrim(form_factura.tipo1) <> "PD" Then

                form_factura.txt_codigo_producto.Focus()
                form_factura.txt_cod_lista.Enabled = False
                form_factura.txt_vendedor.Enabled = False
                form_factura.txt_codigo_producto.Enabled = True
                form_factura.txt_codigo_producto.Focus()
                form_factura.txt_desc_rcgo.Visible = False
                form_factura.lbl_des_rcgo.Visible = False

            Else

                'form_factura.habilita_desc()
                'form_factura.habilita_numeradores()

            End If

            If Form_cliente.txt_estado_form.Text = 1 Then

                cli.insruccion = "select *from cli_01 where id_cli like '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()

            End If

            If Form_muestra_cons_comp.txt_estado_form.Text = 1 Then

                cli.insruccion = "select *from cli_01 where id_cli like '" & Me.DataGridView1.SelectedCells(0).Value & "' order by nombre ASC"
                cli.cargar_registro()

            End If

        End If

    End Sub

    Private Sub busc_cliente_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If form_factura.txt_estado_form.Text = 1 Then form_factura.txt_cierra_form.Text = 1
        If Form_recibos.txt_estado_form.Text = 1 Then Form_recibos.txt_cierra_form.Text = 1
    End Sub

    Private Sub busc_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If form_factura.txt_estado_form.Text = 1 Then form_factura.txt_cierra_form.Text = 2
        If Form_recibos.txt_estado_form.Text = 1 Then Form_recibos.txt_cierra_form.Text = 2
        fact.carga_parametro()
        factura_en_c = fact.factura_en_c
    End Sub
End Class