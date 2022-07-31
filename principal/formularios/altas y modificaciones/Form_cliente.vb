Imports System.Data
Imports System.Data.SqlClient

Public Class Form_cliente

    Dim cli As New pymsoft.cliente1
    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim zzz As New pymsoft.vendedor
    Dim val As Short = 0

    Dim comando As SqlDataAdapter
    Dim tb As DataTable
    Dim conex As New SqlConnection

    Private Sub Form_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dt_fecha.Value = Date.Now.Date
        Me.cmb_tipocliente.Text = Me.cmb_tipocliente.Items(0)
        Me.cmb_iva.Text = Me.cmb_iva.Items(0)
        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.txt_estado_form.Text = 1
        Me.cmb_rubro.Text = Me.cmb_rubro.Items(0)
        Me.opt_cliente.Checked = True

        Me.cmd_actualizar.Enabled = False
        Me.cmd_actualizar.BackColor = Color.LightGray
        Me.cmd_borrar.Enabled = False
        Me.cmd_borrar.BackColor = Color.LightGray

        If form_factura.txt_estado_form.Text = 1 Then
            Me.txt_idcli.Text = cli.calcula_maximo_id() + 1
            Me.cmb_iva.Text = "Consumidor Final"
            Me.txt_iva.Text = "000000000000"
            Me.txt_codpostal.Text = "5900"
            Me.txt_localidad.Text = 1
            Me.lbl_localidad.Text = "Villa Maria"
            Me.txt_provincia.Text = 1
            Me.lbl_provincia.Text = "Cordoba"
            Me.txt_vendedor.Text = 10
            Me.lbl_vendedor.Text = "Mostrador"
            Me.txt_sucursal.Text = 1
            Me.lbl_sucursal.Text = "General"

            Me.txt_nombre.TabIndex = 0
            Me.txt_idcli.TabIndex = 112
            Me.txt_nombre.Focus()
        Else
            'cli.insruccion = "select * from cli_01 order by tipo_cliente,id_cli ASC"
            'cli.cargar_registro()
            'cli.carga_grilla_clientes("Cliente")
        End If

        Me.cmb_rubro.Text = Me.cmb_rubro.Items(0)

    End Sub

    Private Sub cargar_localidad()

        xxx.instruccion = "select *from localidad where id_loc like '" & Me.txt_localidad.Text & "'"
        xxx.codigo = "id_loc"
        xxx.nombre = "nom_localidad"
        xxx.cargar()
        Me.lbl_localidad.Text = xxx.text2
        Me.txt_localidad.Text = xxx.text
        Me.txt_zona.Focus()
        Me.txt_zona.SelectAll()

    End Sub

    Private Sub cargar_provincia()

        xxx.instruccion = "select *from prov_01 where id_prov like '" & Me.txt_provincia.Text & "%'"
        xxx.codigo = "id_prov"
        xxx.nombre = "nombre"
        xxx.cargar()
        Me.lbl_provincia.Text = xxx.text2
        Me.txt_provincia.Text = xxx.text
        Me.txt_localidad.Focus()
        Me.txt_localidad.SelectAll()

    End Sub

    Private Sub cargar_zona()

        xxx.instruccion = "select id_zona,zona from zona_01 where id_zona like '" & Me.txt_zona.Text & "%'"
        xxx.codigo = "id_zona"
        xxx.nombre = "zona"
        xxx.cargar()
        Me.lbl_zona.Text = xxx.text2
        Me.txt_zona.Text = xxx.text
        Me.txt_sucursal.Focus()
        Me.txt_sucursal.SelectAll()

    End Sub

    Private Sub carga_vendedor()
        zzz.instruccion = "select *from vend_01 where id_vendedor like '" & Me.txt_vendedor.Text & "'"
        zzz.codigo_vend = "id_vendedor"
        zzz.nombre_vend = "nombre"
        zzz.cargar_vendedor()
        Me.txt_vendedor.Text = zzz.text
        Me.lbl_vendedor.Text = zzz.text2
        Me.txt_observacion.Focus()
        Me.txt_observacion.SelectAll()
    End Sub

    Private Sub carga_sucursal()
        xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_sucursal.Text & "'"
        xxx.codigo = "id_lis"
        xxx.nombre = "nombre"
        xxx.cargar()
        Me.txt_sucursal.Text = xxx.text
        Me.lbl_sucursal.Text = xxx.text2
        Me.cmb_iva.Focus()
    End Sub

    Private Sub carga_rubro()
        xxx.instruccion = "select *from rub_01 where id_rubro like '" & Me.cmb_rubro.Text & "'"
        xxx.codigo = "id_rubro"
        xxx.nombre = "nombre"
        xxx.cargar()
        Me.cmb_rubro.Text = xxx.text
        Me.cmb_rubro.Text = xxx.text2
        Me.txt_observacion.Focus()
    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\cliente.html")
    End Sub

    Private Sub cmb_tipocliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_tipocliente.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_codpostal.Focus()
            Me.txt_codpostal.SelectAll()
        End If
    End Sub

    Private Sub cmb_tipocliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_tipocliente.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmb_tipocliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipocliente.SelectedIndexChanged

        If Me.cmb_tipocliente.Text = "Cliente" Then
            Me.txt_tipo.Text = "C"
        End If
        If Me.cmb_tipocliente.Text = "Proveedor" Then
            Me.txt_tipo.Text = "P"
        End If
        If Me.cmb_tipocliente.Text = "Gastos y Servicio" Then
            Me.txt_tipo.Text = "G"
        End If
        If Me.cmb_tipocliente.Text = "Furgon" Then
            Me.txt_tipo.Text = "F"
        End If

    End Sub

    Private Sub opt_cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_cliente.CheckedChanged
        If Me.opt_cliente.Checked = True And form_factura.txt_estado_form.Text = 0 Then

            cli.insruccion = "select * from cli_01 where tipo_cliente='Cliente' order by id_cli DESC"
            cli.cargar_registro()
            cli.carga_grilla_clientes("Cliente")

        End If
    End Sub

    Private Sub opt_proovedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_proovedor.CheckedChanged

        If Me.opt_proovedor.Checked = True Then

            cli.insruccion = "select * from cli_01 where tipo_cliente='Proveedor' order by id_cli DESC"
            cli.cargar_registro()
            cli.carga_grilla_clientes("Proveedor")

        End If

    End Sub

    Private Sub opt_furgon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_furgon.CheckedChanged

        If Me.opt_furgon.Checked = True Then

            cli.insruccion = "select * from cli_01 where tipo_cliente='Furgon' order by id_cli DESC"
            cli.cargar_registro()
            cli.carga_grilla_clientes("Furgon")

        End If

    End Sub

    Private Sub opt_gastosserv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_gastosserv.CheckedChanged

        If Me.opt_gastosserv.Checked = True Then

            cli.insruccion = "select * from cli_01 where tipo_cliente= 'Gastos y Servicio' order by id_cli DESC"
            cli.cargar_registro()
            cli.carga_grilla_clientes("Gastos y Servicio")

        End If

    End Sub

    Private Sub cmb_estado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_estado.KeyDown

        If e.KeyCode = Keys.Return Then
            If Me.cmd_aceptar.Enabled = True Then
                Me.cmd_aceptar.Focus()
            Else
                Me.cmd_actualizar.Focus()
            End If
        End If

    End Sub

    Private Sub cmb_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_estado.KeyPress

        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub cmb_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_estado.SelectedIndexChanged

        If Me.cmb_estado.SelectedIndex = 0 Then

            Me.txt_muestraestado.Text = "A"

        End If

        If Me.cmb_estado.SelectedIndex = 1 Then

            Me.txt_muestraestado.Text = "B"

        End If

    End Sub

    Private Sub txt_codpostal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codpostal.KeyDown

        If Not ((e.KeyValue >= 48 And e.KeyValue <= 57) OrElse (e.KeyValue >= 96 And e.KeyValue <= 105) OrElse (e.KeyValue = 8 OrElse e.KeyValue = 46)) Then

            e.Handled = True
            e.SuppressKeyPress = True

        End If

        If e.KeyCode = Keys.Return Then

            Me.txt_provincia.Focus()
            Me.txt_provincia.SelectAll()

        End If

    End Sub

    Private Sub txt_fax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fax.KeyDown

        If Not ((e.KeyValue >= 48 And e.KeyValue <= 57) OrElse (e.KeyValue >= 96 And e.KeyValue <= 105) OrElse (e.KeyValue = 8 OrElse e.KeyValue = 46)) Then

            e.Handled = True

            e.SuppressKeyPress = True

        End If

        If e.KeyCode = Keys.Return Then
            If e.KeyCode = Keys.Return Then
                Me.txt_mail.Focus()
                Me.txt_mail.SelectAll()
            End If
        End If

    End Sub

    Private Sub txt_iva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_iva.GotFocus
        Me.txt_iva.SelectAll()
    End Sub

    Private Sub txt_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_iva.KeyDown

        If Not ((e.KeyValue >= 48 And e.KeyValue <= 57) OrElse (e.KeyValue >= 96 And e.KeyValue <= 105) OrElse (e.KeyValue = 8 OrElse e.KeyValue = 46)) Then

            e.Handled = True

            e.SuppressKeyPress = True

        End If

        Dim a As Boolean

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            If RTrim(Me.cmb_iva.Text) <> "Consumidor Final" Then
                a = cli.validarcuit(Me.txt_iva.Text)
            Else
                a = True
            End If

            If a = False Then

                MessageBox.Show("Verifique cuit", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_iva.Focus()
                val = 1
                Exit Sub

            End If

            val = 0

            cli.validar_cuit()

            Me.txt_ingbrutos.Focus()
            Me.txt_ingbrutos.SelectAll()

        End If

    End Sub

    Private Sub txt_ingbrutos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ingbrutos.KeyDown

        If Not ((e.KeyValue >= 48 And e.KeyValue <= 57) OrElse (e.KeyValue >= 96 And e.KeyValue <= 105) OrElse (e.KeyValue = 8 OrElse e.KeyValue = 46)) Then

            e.Handled = True

            e.SuppressKeyPress = True

        End If

        If e.KeyCode = Keys.Return Then
            Me.txt_telefono.Focus()
            Me.txt_telefono.SelectAll()
        End If

    End Sub

    Private Sub cmb_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_iva.KeyDown

        If e.KeyCode = Keys.Return Then
            Me.txt_iva.Focus()
            Me.txt_iva.SelectAll()
        End If

    End Sub

    Private Sub cmb_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_iva.KeyPress

        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub cmb_rubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_rubro.KeyDown

        If e.KeyCode = Keys.Return Then
            Me.txt_observacion.Focus()
            Me.txt_observacion.SelectAll()
        End If

    End Sub

    Private Sub cmb_rubro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_rubro.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_idcli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_idcli.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_cliente.Show()

        End If

        If Not ((e.KeyValue >= 48 And e.KeyValue <= 57) OrElse (e.KeyValue >= 96 And e.KeyValue <= 105) OrElse (e.KeyValue = 8 OrElse e.KeyValue = 46)) Then

            e.Handled = True

            e.SuppressKeyPress = True

        End If

        If e.KeyCode = Keys.Return Then

            cli.valida_cliente1()
            Me.txt_nombre.Focus()

        End If

        If e.KeyCode = Keys.Tab Then

            cli.valida_cliente1()
            Me.txt_nombre.Focus()

        End If

    End Sub

    Private Sub txt_localidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_localidad.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_localidad.Show()

        End If

        If e.KeyCode = Keys.Return Then

            Call cargar_localidad()

        End If

        If e.KeyCode = Keys.Tab Then

            Call cargar_localidad()

        End If

    End Sub

    Private Sub txt_provincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_provincia.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_provincia.Show()

        End If

        If e.KeyCode = Keys.Return Then

            Call cargar_provincia()

        End If

        If e.KeyCode = Keys.Tab Then

            Call cargar_provincia()

        End If

    End Sub

    Private Sub txt_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_vendedor.KeyDown

        If e.KeyCode = Keys.F1 Then
            busc_vendedor.Show()
        End If
        If e.KeyCode = Keys.Tab Then

            Call carga_vendedor()

        End If

        If e.KeyCode = Keys.Return Then

            Call carga_vendedor()

        End If

    End Sub

    Private Sub txt_sucursal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_sucursal.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_lista.Show()

        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            Call carga_sucursal()

        End If

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        Dim a As Boolean = True

        If RTrim(Me.cmb_iva.Text) <> "Consumidor Final" Then a = cli.validarcuit(Me.txt_iva.Text)

        If a = False Then
            MessageBox.Show("Verifique C.U.I.T", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        cli.actualizar()

        Me.txt_idcli.Focus()

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Dim b As Boolean = True

        If RTrim(Me.cmb_iva.Text) <> "Consumidor Final" Then b = cli.validarcuit(Me.txt_iva.Text)

        If b = False Then
            MessageBox.Show("Verifique C.U.I.T", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        cli.validar_registro()
        cli.agregar()

        If form_factura.txt_estado_form.Text = 1 Then
            form_factura.txt_codigo.Text = Me.txt_idcli.Text
            Me.Dispose()
        End If

        cli.limpiar()

    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click

        Dim x As Boolean = cli.verifica_movimiento_cta_cte(Me.txt_idcli.Text)
        Dim x1 As Boolean = cli.verifica_movimiento_facturacion(Me.txt_idcli.Text)
        Dim x2 As Boolean = cli.verifica_en_producto(Me.txt_idcli.Text)

        If x = True Or x1 = True Or x2 = True Then Exit Sub

        cli.borrar()

    End Sub

    Private Sub txt_zona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_zona.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_zona.Show()

        End If

        If e.KeyCode = Keys.Return Then

            Call cargar_zona()

        End If

        If e.KeyCode = Keys.Tab Then

            Call cargar_zona()

        End If

    End Sub

    Private Sub txt_telefono_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_telefono.KeyDown

        If e.KeyCode = Keys.Return Then
            Me.txt_fax.Focus()
            Me.txt_fax.SelectAll()
        End If

    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress

        If InStr(1, "0123456789-/ " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub txt_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nombre.KeyDown

        If e.KeyCode = Keys.Return Then
            Me.txt_direccion.Focus()
            Me.txt_direccion.SelectAll()
        End If

    End Sub

    Private Sub txt_direccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_direccion.KeyDown

        If e.KeyCode = Keys.Return Then
            Me.cmb_tipocliente.Focus()
            Me.cmb_tipocliente.SelectAll()
        End If

    End Sub

    Private Sub txt_buscador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_buscador.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.txt_buscador.Text <> "" Then

                tb = New DataTable
                'Me.DataGridView1.Rows.Clear()

                conex = conecta()

                comando = New SqlDataAdapter("select * from cli_01 where (nombre like '%" & Trim(Me.txt_buscador.Text) & "%' or id_cli like '%" & Trim(Me.txt_buscador.Text) & "%' or cuit like '%" & Trim(Me.txt_buscador.Text) & "%')", conex)
                comando.Fill(tb)
                comando.Dispose()

                Me.DataGridView1.DataSource = tb

                Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
                Me.txt_buscador.Text = ""
                Me.DataGridView1.Focus()

            Else

                tb = New DataTable
                'Me.DataGridView1.Rows.Clear()

                conex = conecta()

                comando = New SqlDataAdapter("select * from cli_01", conex)
                comando.Fill(tb)
                comando.Dispose()

                Me.DataGridView1.DataSource = tb

                Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
                Me.txt_buscador.Text = ""
                Me.DataGridView1.Focus()

            End If

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            cli.mostrar_registro_navegador(Me.DataGridView1.SelectedCells.Item(0).Value)
            Me.txt_idcli.Focus()
            Me.txt_idcli.SelectAll()
        End If

    End Sub

    Private Sub txt_mail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_mail.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_vendedor.Focus()
            Me.txt_vendedor.SelectAll()
        End If
    End Sub

    Private Sub txt_observacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_observacion.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.cmd_aceptar.Enabled = False Then
                Me.cmd_actualizar.Focus()
            Else
                Me.cmd_aceptar.Focus()
            End If
        End If
    End Sub

End Class