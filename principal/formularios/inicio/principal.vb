Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class principal

    Dim tbl1 As New DataTable, tbl2 As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim act As New pymsoft.activate

    Private Sub TreeView1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.Disposed
        Call ClearMemory()
    End Sub

    Private Sub TreeView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyDown

        Call mover_arbol()

    End Sub

    Private Sub TreeView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyUp

        Call mover_arbol()

    End Sub


    Private Sub mover_arbol()

        Try

            If Me.TreeView1.SelectedNode.Text = "Altas y Actualizaciones" Then

                Me.TabControl1.SelectTab(0)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Gestion Ventas" Then

                Me.TabControl1.SelectTab(1)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Configuracion" Then

                Me.TabControl1.SelectTab(4)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Stock" Then

                Me.TabControl1.SelectTab(3)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Gestion Compras" Then

                Me.TabControl1.SelectTab(2)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Reportes/Estadisticos" Then

                Me.TabControl1.SelectTab(6)
                Me.TreeView1.Focus()

            End If

            If Me.TreeView1.SelectedNode.Text = "Contabilidad General" Then

                Me.TabControl1.SelectTab(5)
                Me.TreeView1.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Call mover_arbol()

    End Sub

    Private Sub cmd_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cliente.Click

        Form_cliente.Show()

    End Sub

    Private Sub cmd_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vendedor.Click

        form_vendedor.Show()

    End Sub

    Public Sub Principal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Dim x As Integer = MessageBox.Show("Esta seguro que desea salir ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If x = 6 Then

            Form_login.Dispose()
            Me.Dispose()

        Else

            e.Cancel = True

        End If

    End Sub

    Private Sub principal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.M Then
            Me.TreeView1.Focus()
        End If

        If e.KeyCode = Keys.U Then
            Call cambia_usuario()
        End If

    End Sub

    Private Sub principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.lbl_fec.Text = FormatDateTime(Now(), DateFormat.ShortDate)
        Me.lbl_usu.Text = Form_login.cmb_usuario.Text

        Me.Cursor = Cursors.Hand

        conex = conecta()

        comando = New SqlDataAdapter("select cont,fecha,estado from activate where id_act='1'", conex)
        comando.Fill(tbl1)

        If tbl1.Rows(0).Item(2) = "SI" Then

            If tbl1.Rows(0).Item(1) <> Form_login.DateTimePicker1.Text Then

                act.cont = tbl1.Rows(0).Item(0) + 1

                If act.cont >= 10 Then
                    MessageBox.Show("Vencio el periodo de prueba", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Form_login.Close()
                End If

                act.instruccion = "update activate set fecha='" & Form_login.DateTimePicker1.Text & "',cont = '" & act.cont & "' where id_act='1'"
                act.abm()

            End If

        End If

    End Sub

    Private Sub cmd_localidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_localidad.Click

        Form_localidad.Show()

    End Sub

    Private Sub cmd_provincia_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_provincia.Click

        provincia.Show()

    End Sub

    Private Sub cmd_banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_banco.Click

        Form_banco.Show()

    End Sub


    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_sucursal.Click

        form_lista.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rubro.Click

        Form_rubro.Show()

    End Sub

    Private Sub cmd_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_factura.Click

        Form_login.txt_tipo_letra.Text = "x"
        form_factura.txt_tipo_fact.Text = "FC"
        form_factura.txt_remito.Text = 0
        form_factura.txt_factura_notaCredito.Text = 1
        form_factura.Show()

    End Sub

    Private Sub cmd_nota_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_nota_credito.Click

        Form_login.txt_tipo_letra.Text = "x"
        form_factura.txt_tipo_fact.Text = "NC"
        form_factura.txt_remito.Text = 0
        form_factura.txt_factura_notaCredito.Text = 2
        form_factura.Show()

    End Sub

    Private Sub cmd_numerador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_numerador.Click

        Form_numerador.Show()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tipo_iva.Click

        form_tipo_iva.Show()

    End Sub

    Private Sub cmd_cons_comprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cons_comprobantes.Click

        Form_consulta_comprobante.Show()

    End Sub

    Private Sub cmd_recibos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_recibos.Click

        Form_recibos.txt_estado_form.Text = 1
        Form_recibos.txt_tipo.Text = "RC"
        Form_recibos.Show()

    End Sub

    Private Sub cmd_parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_parametros.Click

        form_parametros.Show()

    End Sub

    Private Sub cmd_usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_usuario.Click

        Form_usuario.Show()

    End Sub

    Private Sub cmd_asigna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_asigna.Click

        Form_asigna.Show()

    End Sub

    Private Sub cmd_remito_ent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_remito_ent.Click

        form_factura.txt_remito.Text = 1
        form_factura.txt_desc_rcgo.Visible = False
        form_factura.lbl_des_rcgo.Visible = False
        form_factura.cmb_forma_pago.Visible = False
        form_factura.lbl_forma_pago.Visible = False
        form_factura.lbl_Marcador_precio.Visible = False
        form_factura.txt_tipo_fact.Text = "RE"
        Form_login.txt_tipo_letra.Text = "x"
        form_factura.lbl_saldo_cta.Visible = False
        form_factura.lbl_saldo_venc.Visible = False
        form_factura.Label13.Visible = False
        form_factura.Label7.Visible = False
        form_factura.Show()

    End Sub

    Private Sub cmd_remito_sal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_remito_sal.Click

        form_factura.txt_remito.Text = 2
        form_factura.txt_desc_rcgo.Visible = False
        form_factura.lbl_des_rcgo.Visible = False
        form_factura.cmb_forma_pago.Visible = False
        form_factura.lbl_forma_pago.Visible = False
        form_factura.lbl_Marcador_precio.Visible = False
        form_factura.txt_tipo_fact.Text = "RS"
        Form_login.txt_tipo_letra.Text = "x"
        form_factura.lbl_saldo_cta.Visible = False
        form_factura.lbl_saldo_venc.Visible = False
        form_factura.Label13.Visible = False
        form_factura.Label7.Visible = False
        form_factura.Show()

    End Sub

    Private Sub cmd_vizualiza_fact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vizualiza_fact.Click

        Form_visualiza.txt_estado_form.Text = 1
        Form_visualiza.Show()

    End Sub

    Private Sub cmd_cons_cta_cte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cons_cta_cte.Click

        Form_consul_cta_cte.txt_estado_form.Text = 1
        Form_consul_cta_cte.Show()

    End Sub

    Private Sub cmd_arqueo_caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_arqueo_caja.Click

        Form_arqueo_caja.Show()

    End Sub

    Private Sub cmd_ing_comprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_factura_compra.Click

        Form_compras.Text = "Factura Compras"
        Form_compras.txt_tipo_fact.Text = "FC"
        Form_compras.txt_credito.Enabled = False
        Form_compras.Show()

    End Sub

    Private Sub cmd_n_credito_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_n_credito_compra.Click

        Form_compras.Text = "Nota de Credito Compras"
        Form_compras.txt_tipo_fact.Text = "NC"
        Form_compras.txt_debito.Enabled = False
        Form_compras.Show()

    End Sub

    Private Sub cmd_factura_preventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_factura_preventa.Click

        form_factura.Text = "Preventa"
        form_factura.tipo1 = "PD"
        Form_login.txt_tipoo.Text = 0
        form_factura.txt_tipo_fact.Text = "PD"
        form_factura.Show()

    End Sub

    Private Sub cmd_balance_saldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_balance_saldos.Click

        Form_balance_saldo.Show()

    End Sub

    Private Sub cmd_consul_x_movim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_consul_x_movim.Click

        Form_seguimiento_art.Show()
    End Sub

    Private Sub cmd_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inventario.Click

        Form_inventario.Show()

    End Sub

    Private Sub cmd_visualiza_remito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_visualiza_remito.Click

        Form_visualiza.txt_estado_form.Text = 2   '  diferencia entre remito y facturas
        Form_visualiza.Show()

    End Sub

    Private Sub cmd_empresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Form_empresa.Show()

    End Sub

    Private Sub cmd_articulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_articulo.Click
        Form_articulos.Show()
    End Sub

    Private Sub cmd_menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_menu.Click

        form_menu.Show()

    End Sub

    Private Sub cmd_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_stock.Click

        Form_stock.txt_estado_form.Text = 1
        Form_stock.Show()

    End Sub

    Private Sub cmd_cons_cliente_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cons_cliente_proveedor.Click

        Form_consulta_rem_cli.Show()

    End Sub

    Private Sub cmd_habilita_mes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_habilita_mes.Click

        Form_periodo_carga.Show()

    End Sub

    Private Sub cmd_cierre_fiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cierre_fiscal.Click

        Form_cierre_fiscal.Show()

    End Sub

    Private Sub cmd_iva_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_iva_ventas.Click

        Form_iva_ventas.txt_estado_form.Text = 1
        Form_iva_ventas.Show()

    End Sub

    Private Sub cmd_visualiza_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_visualiza_compra.Click

        Form_visualiza.txt_estado_form.Text = 3  ' diferencia facturas compras en los demas
        Form_visualiza.Show()

    End Sub

    Private Sub cmd_iva_compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_iva_compras.Click

        Form_iva_ventas.txt_estado_form.Text = 2
        Form_iva_ventas.Text = " Libro i.v.a Compras"
        Form_iva_ventas.Label7.Text = "LIBRO I.V.A COMPRAS"
        Form_iva_ventas.Show()

    End Sub

    Private Sub cmd_consulta_comprobantes_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_consulta_comprobantes_c.Click
        Form_consulta_compras.Show()
    End Sub

    Private Sub cmd_zona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_zona.Click

        Form_zona.Show()

    End Sub

    Private Sub cmd_ventas_general_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Form_ventas_agrupacion.Show()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Call cambia_usuario()

    End Sub

    Private Sub cmd_rentabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rentabilidad.Click
        Form_rentabilidad.Show()
    End Sub

    Private Sub cmd_rep_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rep_precios.Click
        Form_rep_cliente.Show()
    End Sub

    Private Sub cmd_vta_agru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vta_agru.Click
        Form_ventas_agrupacion.txt_estado_form.Text = 1
        Form_ventas_agrupacion.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_MINIMIZAR.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmd_repcta_cte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_repcta_cte.Click
        Form_repcta_cte.Show()
    End Sub

    Private Sub cmd_cartera_valores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cartera_valores.Click

        Form_cartera_valores.txt_estado_form.Text = 1
        Form_cartera_valores.Show()

    End Sub

    Private Sub cmd_alta_cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Form_cartera.Show()

    End Sub

    Private Sub cmd_lista_ofertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_lista_ofertas.Click

        Form_lista_oferta.txt_estado_form.Text = 1
        Form_lista_oferta.Show()

    End Sub

    Private Sub cmd_pedido_a_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_pedido_a_prov.Click

        Form_pedido_proveedor.Show()

    End Sub

    Private Sub cmd_resumen_cta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Form_resumen_cta.Show()

    End Sub

    Private Sub cmd_alta_planilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_alta_planilla.Click

        Form_alta_planilla.txt_estado_form.Text = 1
        Form_alta_planilla.Show()

    End Sub

    Private Sub cmd_plan_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_plan_cuenta.Click

        Form_plan_cuenta.Show()

    End Sub

    Private Sub cmd_repo_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_repo_precios.Click

        Form_reporte_precios.txt_estado_form.Text = 2
        Form_reporte_precios.Show()

    End Sub

    Private Sub cmd_alta_movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_alta_movimiento.Click

        Form_alta_movimiento.txt_estado_form.Text = 1
        Form_alta_movimiento.Show()

    End Sub

    Private Sub cmd_alta_cartera_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_alta_cartera.Click

        Form_cartera.Show()

    End Sub

    Private Sub cmd_empresa_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_empresa.Click

        Form_empresa.Show()

    End Sub

    Private Sub cambia_usuario()

        Dim i As Integer
        Dim fabierto As Integer = My.Application.OpenForms.Count - 1

        For i = fabierto To 0 Step -1
            Dim x As String = My.Application.OpenForms(i).Name
            If RTrim(My.Application.OpenForms(i).Name) <> "Form_login" Then
                If RTrim(My.Application.OpenForms(i).Name) <> "principal" Then My.Application.OpenForms(i).Close()
            Else
                Form_login.Timer2.Enabled = True
                My.Application.OpenForms(i).Show()
                Form_login.cmb_usuario.Focus()
            End If
        Next

    End Sub

   
    Private Sub cmd_reimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_reimpresion.Click

        Form_reimpresion.Show()

    End Sub

    Private Sub cmd_carga_planilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_carga_planilla.Click

        Form_planilla.txt_estado_form.Text = 1
        Form_planilla.Show()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        acerca_de.Show()
    End Sub

    Private Sub cmd_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_reportes.Click

        form_config_rep.Show()

    End Sub

    Private Sub cmd_presupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_presupuesto.Click

        Form_presupuesto.Show()

    End Sub

    Private Sub cmd_defasajes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_defasajes.Click

        Form_defasajes.Show()

    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        acerca_de.Show()

    End Sub

    Private Sub cmd_consulta_planilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_consulta_planilla.Click

        form_consulta_planilla.Show()

    End Sub

    Private Sub cmd_planilla_mayor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_planilla_mayor.Click

        Form_mayor_planilla.txt_estado_form.Text = 1
        Form_mayor_planilla.Show()

    End Sub

    Private Sub cmd_variacion_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_variacion_precios.Click

        Form_variacion_precios.Show()

    End Sub

    Private Sub cmd_rep_etiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rep_etiquetas.Click

        Form_rep_etiquetas.Show()

    End Sub

    Private Sub cmd_trans_pda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_trans_pda.Click

        Form_trans_pda.Show()
        Form_trans_pda.txt_estado_form.Text = 1

    End Sub

    Private Sub cmd_resumen_cta_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_resumen_cta.Click

        Form_resumen_cta.Show()

    End Sub

    Private Sub cmd_parte_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_parte_carga.Click

        Form_parte_carga.Show()

    End Sub

    Private Sub cmd_actualizador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizador.Click

        Form_actualizador.Show()

    End Sub

    Private Sub cmd_rotulos_balanza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rotulos_balanza.Click

        Form_rotulo_balanza.Show()

    End Sub

    Private Sub PictureBox2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'acerca_de.ShowDialog()
    End Sub

    Private Sub cmd_consulta_ctacte_pro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_consulta_ctacte_pro.Click

        Form_consul_cta_cte.txt_estado_form.Text = 2
        Form_consul_cta_cte.Show()

    End Sub

    Private Sub cmd_orden_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_orden_pago.Click
        Form_recibos.txt_estado_form.Text = 2
        Form_recibos.txt_tipo.Text = "OP"
        Form_recibos.Text = "Orden de Pago"
        Form_recibos.txt_vendedor.Visible = False
        Form_recibos.txt_nom_vendedor.Visible = False
        Form_recibos.Label8.Visible = False
        Form_recibos.Show()
    End Sub

    Private Sub cmd_resolucion_3685_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_resolucion_3685.Click
        Form_res_3685.Show()
    End Sub

    Private Sub cmd_empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_empleado.Click
        form_empleado.Show()
    End Sub

    Private Sub cmd_reporte_horario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reporte_horario.Click
        Form_movimiento.Show()
    End Sub

    Private Sub cmd_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_carga.Click

        Form_carga.Show()

    End Sub

    Private Sub cmd_nota_debito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_nota_debito.Click

        Form_login.txt_tipo_letra.Text = "x"
        form_factura.txt_tipo_fact.Text = "ND"
        form_factura.txt_remito.Text = 0
        form_factura.txt_factura_notaCredito.Text = 3
        form_factura.Show()

    End Sub

    Private Sub cmd_moneda_extranjera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_moneda_extranjera.Click
        form_moneda.show()
    End Sub

    Private Sub cmd_ingreso_egreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ingreso_egreso.Click
        Form_ingreso_egreso.Show()
    End Sub

End Class
