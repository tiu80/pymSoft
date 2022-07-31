Imports System.Data
Imports System.Data.SqlClient

Public Class Form_compras

    Dim cli As New pymsoft.cliente1
    Dim xx As New pymsoft.prov_vend_list_bco
    Dim xxx As New pymsoft.parametro
    Dim num As New pymsoft.numerodecimales
    Dim fact As New pymsoft.factura
    Dim i, cta, pos As Integer
    Dim cre, deb, sub_tot, tot, iva_ins, exento, imp, pi, pb As Double
    Dim desc As String
    Dim modifica As Boolean = True

    Dim tbl As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            cli.insruccion = "select *from cli_01 where id_cli like '" & Me.txt_codigo.Text & "' and tipo_cliente like 'Gastos y Servicio' or tipo_cliente like 'Proveedor'"
            cli.cargar_registro()
        End If

        If e.KeyCode = Keys.F1 Then
            busc_cliente.Show()
        End If

    End Sub

    Private Sub Form_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_forma_pago.Text = Me.cmb_forma_pago.Items(0)
        Me.txt_estado_form.Text = 1
        Me.dt_fec_arqueo.Text = Date.Now
        Me.dt_fec_emision.Text = Date.Now
        Me.dt_fec_vto.Text = Date.Now

        Me.Timer1.Enabled = True

    End Sub

    Private Sub cmb_forma_pago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_forma_pago.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_cod_cta.Focus()
        End If
    End Sub

    Private Sub cmb_forma_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_forma_pago.LostFocus
        Me.cmb_forma_pago.Enabled = False
        Me.txt_letra.ReadOnly = True
        Me.txt_numero.ReadOnly = True
        Me.txt_letra.BackColor = Color.White
        Me.txt_numero.BackColor = Color.White
        Me.txt_prefijo.ReadOnly = True
        Me.txt_prefijo.BackColor = Color.White
        Me.txt_codigo.Enabled = False
        Me.dt_fec_arqueo.Enabled = False
        Me.dt_fec_emision.Enabled = False
        Me.dt_fec_vto.Enabled = False
    End Sub

    Private Sub txt_cod_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_cta.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_cod_cta.Text = "" Then
                Me.txt_cod_cta.Focus()
                Exit Sub
            End If
            xx.instruccion = "select *from cta_01 where id_cta like '" & Me.txt_cod_cta.Text & "'"
            xx.codigo = "id_cta"
            xx.nombre = "nombre"
            xx.cargar()
            If xx.validar = False Then
                Me.txt_cod_cta.Focus()
                Exit Sub
            End If
            Me.txt_cod_cta.Text = xx.text
            Me.lbl_cuenta.Text = xx.text2
            Me.txt_cod_iva.Focus()
        End If

        If e.KeyCode = Keys.F1 Then
            busc_cuenta.Show()
        End If

        If e.KeyCode = Keys.Escape Then
            Me.DataGridView1.Focus()
        End If

    End Sub

    Private Sub txt_cod_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_iva.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_cod_iva.Text = "" Then
                Me.txt_cod_iva.Focus()
                Exit Sub
            End If
            xx.instruccion = "select *from iva_01 where id_iva like '" & Me.txt_cod_iva.Text & "'"
            xx.codigo = "id_iva"
            xx.nombre = "nombre"
            xx.cargar()
            If xx.validar = False Then
                Me.txt_cod_iva.Focus()
                Exit Sub
            End If
            Me.txt_cod_iva.Text = xx.text
            busc_iva.tipo_iva()
            If Me.txt_debito.Enabled = True Then Me.txt_debito.Focus()
            If Me.txt_credito.Enabled = True Then Me.txt_credito.Focus()
        End If

        If e.KeyCode = Keys.F1 Then
            busc_iva.Show()
        End If
    End Sub

    Private Sub txt_debito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_debito.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            If Me.txt_debito.Text = "" Then
                MessageBox.Show("Verifique Importes", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Call cargar_datos()

        End If

    End Sub

    Private Sub txt_credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_credito.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            If Me.txt_credito.Text = "" Then
                MessageBox.Show("Verifique Importes", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Call cargar_datos()

        End If

    End Sub

    Private Sub txt_neto_gravado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_neto_gravado.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_imp_interno.Focus()
        End If
    End Sub

    Private Sub txt_imp_interno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_imp_interno.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_exento1.Focus()
        End If
    End Sub

    Private Sub txt_exento1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_exento1.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_iva_inscripto.Focus()
        End If
    End Sub

    Private Sub txt_iva_inscripto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_iva_inscripto.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_per_ing_bruto.Focus()
        End If
    End Sub

    Private Sub txt_per_ing_bruto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_per_ing_bruto.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_per_iva.Focus()
        End If
    End Sub

    Private Sub dt_fec_arqueo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_arqueo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_forma_pago.Focus()
        End If
    End Sub

    Private Sub dt_fec_emision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_emision.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_vto.Focus()
        End If
    End Sub

    Private Sub dt_fec_vto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_vto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_arqueo.Focus()
        End If
    End Sub

    Private Sub txt_per_iva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_per_iva.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then
            Call modifica_grilla()
        End If
    End Sub

    Private Sub carga_grilla()

        If modifica = True Then Me.DataGridView1.Rows.Add()
        If modifica = False Then i = i - 1

        If Me.txt_credito.Text = "" Then Me.txt_neto_gravado.Text = Me.txt_debito.Text
        If Me.txt_debito.Text = "" Then Me.txt_neto_gravado.Text = Me.txt_credito.Text
        If Me.lbl_iva.Text = "I.V.A 21 %" Then Me.txt_iva_inscripto.Text = Format((Me.txt_neto_gravado.Text * 21) / 100, "0.00")
        If Me.lbl_iva.Text = "I.V.A 10.5 %" Then Me.txt_iva_inscripto.Text = Format((Me.txt_neto_gravado.Text * 10.5) / 100, "0.00")
        If Me.lbl_iva.Text = "Exento" Then Me.txt_iva_inscripto.Text = "0.00"

        Me.DataGridView1.Rows(i).Cells(0).Value = Me.txt_cod_cta.Text
        Me.DataGridView1.Rows(i).Cells(1).Value = Me.lbl_cuenta.Text
        If Me.txt_credito.Text = "" Then Me.DataGridView1.Rows(i).Cells(2).Value = Val(Me.txt_debito.Text) + Val(Me.txt_iva_inscripto.Text)
        If Me.txt_debito.Text = "" Then Me.DataGridView1.Rows(i).Cells(2).Value = Val(Me.txt_credito.Text) + Val(Me.txt_iva_inscripto.Text)
        If Me.lbl_iva.Text = "Exento" And Me.txt_credito.Text = "" Then Me.txt_exento1.Text = Me.txt_debito.Text
        If Me.lbl_iva.Text = "Exento" And Me.txt_debito.Text = "" Then Me.txt_exento1.Text = Me.txt_credito.Text
        Me.DataGridView1.Rows(i).Cells(3).Value = Me.txt_exento1.Text
        Me.DataGridView1.Rows(i).Cells(4).Value = Me.txt_imp_interno.Text
        Me.DataGridView1.Rows(i).Cells(5).Value = Me.txt_neto_gravado.Text
        Me.DataGridView1.Rows(i).Cells(7).Value = Me.txt_per_ing_bruto.Text
        Me.DataGridView1.Rows(i).Cells(6).Value = Me.txt_per_iva.Text
        Me.DataGridView1.Rows(i).Cells(8).Value = Me.txt_iva_inscripto.Text

        Me.DataGridView1.Rows(i).Cells(9).Value = Me.txt_cod_cta.Text
        Me.DataGridView1.Rows(i).Cells(10).Value = Me.lbl_cuenta.Text
        Me.DataGridView1.Rows(i).Cells(11).Value = Me.txt_cod_iva.Text
        Me.DataGridView1.Rows(i).Cells(12).Value = Me.lbl_iva.Text

        i = i + 1

        modifica = True

    End Sub

    Private Sub txt_prejijo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_prefijo.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_prefijo.Text = "" Then
                Me.txt_prefijo.Focus()
                Exit Sub
            End If
            Me.txt_numero.Focus()
        End If
    End Sub

    Private Sub txt_numero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numero.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_numero.Text = "" Then
                Me.txt_numero.Focus()
                Exit Sub
            End If
            Call verifica_numeradores()
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try
            Dim a As Integer

            If e.KeyCode = Keys.Delete Then
                pos = Me.DataGridView1.CurrentCell.RowIndex   ' fila actual
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(pos))
                i = i - 1
            End If

            If e.KeyCode = Keys.Insert Then
                Me.txt_cod_cta.Focus()
            End If

            If e.KeyCode = Keys.Return Then
                pos = Me.DataGridView1.CurrentCell.RowIndex
                Call modifica_grilla_compras()
            End If

            If e.KeyCode = Keys.F5 Then

                If Me.DataGridView1.Rows(0).Cells(0).Value = Nothing Then
                    MsgBox("No hay Datos", MsgBoxStyle.Information, "PyMsoft")
                    Exit Sub
                End If

                a = MessageBox.Show("Esta Seguro??", "PyMSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If a = 6 Then
                    Call calula_totales()
                    Call guarda_comprobante()
                    Me.Dispose()
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub modifica_grilla()

        Dim total As Single

        If Me.txt_credito.Text = "" Then total = Me.txt_debito.Text + Val(Me.txt_imp_interno.Text) + Me.txt_iva_inscripto.Text + Val(Me.txt_per_iva.Text) + Val(Me.txt_per_ing_bruto.Text)
        If Me.txt_debito.Text = "" Then total = Me.txt_credito.Text + Val(Me.txt_imp_interno.Text) + Me.txt_iva_inscripto.Text + Val(Me.txt_per_iva.Text) + Val(Me.txt_per_ing_bruto.Text)

        Me.DataGridView1.Rows(i - 1).Cells(2).Value = total
        Call limpia_totales()

        Me.Panel.Visible = False

        Me.txt_cod_cta.Focus()

    End Sub

    Private Sub limpia_totales()

        Me.txt_cod_cta.Text = ""
        Me.lbl_cuenta.Text = ""
        Me.txt_cod_iva.Text = ""
        Me.lbl_iva.Text = ""
        Me.txt_debito.Text = ""
        Me.txt_credito.Text = ""

    End Sub

    Private Sub cargar_datos()
        Dim a As Integer

        Me.Panel.Visible = True
        Me.txt_neto_gravado.Focus()

        Call carga_grilla()
        a = MessageBox.Show("Acepta Totales ??", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            deb = Val(Me.txt_debito.Text)
            cre = Val(Me.txt_credito.Text)
            cta = Me.txt_cod_cta.Text
            desc = Me.lbl_cuenta.Text

            Me.Panel.Visible = False
            Call limpia_totales()

            Me.txt_cod_cta.Focus()

        End If

    End Sub

    Private Sub guarda_comprobante()

        Dim i As Integer
        Dim tot As Double

        xxx.instruccion = "INSERT INTO compra_cab(numero,letra,prefijo,tipo,id_cliente,nombre,direccion,cuit,tipo_iva,forma_pago,lista,fec_emi,fec_vto,fec_arqueo,talon) VALUES('" & Me.txt_numero.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_prefijo.Text & "','" & Me.txt_tipo_fact.Text & "','" & Me.txt_codigo.Text & "','" & Me.txt_cliente.Text & "','" & Me.txt_direccion.Text & "','" & Me.txt_cuit.Text & "','" & Me.txt_tipo_iva.Text & "','" & Me.cmb_forma_pago.Text & "','" & Me.txt_lista.Text & "','" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Me.dt_fec_arqueo.Text & "','" & Me.txt_talonario_pred.Text & "')"
        xxx.abm()

        For i = 0 To Me.DataGridView1.Rows.Count - 1

            xxx.instruccion = "INSERT INTO compra_det(num,lt,pre,tipo1,id_cli,cuenta,detalle,fec_emi1,fec_vto1,fec_arqueo1,talon1) VALUES('" & Me.txt_numero.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_prefijo.Text & "' , '" & Me.txt_tipo_fact.Text & "','" & Me.txt_codigo.Text & "','" & cta & "','" & desc & "', '" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Me.dt_fec_arqueo.Text & "','" & Me.txt_talonario_pred.Text & "')"
            xxx.abm()

            tot = tot + Me.DataGridView1.Rows(i).Cells(2).Value

        Next

        xxx.instruccion = "INSERT INTO compra_tot(num1,lt1,pre1,tipo2,debito,credito,neto,imp_interno,exento,iva_ins,per_ib,per_iva,fec_emi2,fec_vto2,fec_arqueo2,total,talon2) VALUES ('" & Me.txt_numero.Text & "','" & Me.txt_letra.Text & "','" & Me.txt_prefijo.Text & "','" & Me.txt_tipo_fact.Text & "','" & deb & "','" & cre & "','" & sub_tot & "','" & imp & "','" & exento & "','" & iva_ins & "','" & pb & "','" & pi & "', '" & Me.dt_fec_emision.Text & "','" & Me.dt_fec_vto.Text & "','" & Me.dt_fec_arqueo.Text & "','" & tot & "','" & Me.txt_talonario_pred.Text & "')"
        xxx.abm()

    End Sub

    Private Sub verifica_numeradores()

        conex = conecta()
        tbl.Clear()

        comando = New SqlDataAdapter("select *from compra_cab where numero = '" & RTrim(Me.txt_numero.Text) & "' and prefijo = '" & RTrim(Me.txt_prefijo.Text) & "' and letra = '" & RTrim(Me.txt_letra.Text) & "' and tipo = '" & RTrim(Me.txt_tipo_fact.Text) & "'", conex)
        comando.Fill(tbl)

        If tbl.Rows.Count > 0 Then
            MessageBox.Show("El numero esta en uso !!!", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txt_numero.Focus()
            Me.dt_fec_arqueo.Enabled = False
            Me.dt_fec_emision.Enabled = False
            Me.dt_fec_vto.Enabled = False
            Me.txt_cod_cta.Enabled = False
            Me.txt_cod_iva.Enabled = False
            If Me.txt_tipo_fact.Text = "FC" Then Me.txt_debito.Enabled = False
            If Me.txt_tipo_fact.Text = "NC" Then Me.txt_credito.Enabled = False
            Exit Sub
        Else
            Me.dt_fec_arqueo.Enabled = True
            Me.dt_fec_emision.Enabled = True
            Me.dt_fec_vto.Enabled = True
            Me.txt_cod_cta.Enabled = True
            Me.txt_cod_iva.Enabled = True
            If Me.txt_tipo_fact.Text = "FC" Then Me.txt_debito.Enabled = True
            If Me.txt_tipo_fact.Text = "NC" Then Me.txt_credito.Enabled = True
            Me.dt_fec_emision.Focus()
        End If

    End Sub

    Private Sub calula_totales()

        Dim i As Integer

        For i = 0 To Me.DataGridView1.Rows.Count - 1
            tot = Format(tot + Val(Me.DataGridView1.Rows(i).Cells(2).Value), "0.00")
            exento = Format(exento + Val(Me.DataGridView1.Rows(i).Cells(3).Value), "0.00")
            iva_ins = Format(iva_ins + Val(Me.DataGridView1.Rows(i).Cells(8).Value), "0.00")
            pi = Format(pi + Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")
            pb = Format(pb + Val(Me.DataGridView1.Rows(i).Cells(7).Value), "0.00")
            imp = Format(imp + Val(Me.DataGridView1.Rows(i).Cells(4).Value), "0.00")
            sub_tot = Format(sub_tot + Val(Me.DataGridView1.Rows(i).Cells(5).Value), "0.00")
        Next

    End Sub

    Private Sub modifica_grilla_compras()

        Me.txt_cod_cta.Text = Me.DataGridView1.Rows(pos).Cells(9).Value
        Me.lbl_cuenta.Text = Me.DataGridView1.Rows(pos).Cells(10).Value
        Me.txt_cod_iva.Text = Me.DataGridView1.Rows(pos).Cells(11).Value
        Me.lbl_iva.Text = Me.DataGridView1.Rows(pos).Cells(12).Value

        If Me.txt_tipo_fact.Text = "FC" Then Me.txt_debito.Text = Me.DataGridView1.Rows(pos).Cells(5).Value
        If Me.txt_tipo_fact.Text = "NC" Then Me.txt_credito.Text = Me.DataGridView1.Rows(pos).Cells(5).Value

        Me.txt_cod_cta.Focus()

        modifica = False

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.Timer1.Enabled = False

        fact.carga_parametro()

        If fact.Pide_talonario_factura = "SI" Then

            Dim x As String = InputBox("Ingrese Talonario" & vbCrLf & " " & vbCrLf & "1- Talonario Fiscal" & vbCrLf & "2- Talonario X", "PyM Soft", 2)

            If x = "1" Then
                Me.txt_talonario_pred.Text = x
                fact.Talonario_predeterminado = x
            End If

            If x = "2" Then
                Me.txt_talonario_pred.Text = x
                fact.Talonario_predeterminado = x
            End If

            If x <> "1" And x <> "2" Then

                xxx.instruccion = "update menu_usu set integridad = '1' where estado= 'Activo'"   ' pone valor =0 para ver si se producen defasajes al cerrar aplicacion
                xxx.abm()

                MessageBox.Show("No existe Talonario!!!!", "PyM Soft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Dispose()
                Exit Sub

            End If

        Else

            Me.txt_talonario_pred.Text = fact.Talonario_predeterminado

        End If

    End Sub

    Private Sub txt_cod_cta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_cta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_cod_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_iva.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_debito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_debito.KeyPress
        num.positivos_punto(e, Me.txt_debito)
    End Sub

    Private Sub txt_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_credito.KeyPress
        num.positivos_punto(e, Me.txt_credito)
    End Sub

    Private Sub txt_neto_gravado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_neto_gravado.KeyPress
        num.positivos_punto(e, Me.txt_neto_gravado)
    End Sub

    Private Sub txt_imp_interno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_imp_interno.KeyPress
        num.positivos_punto(e, Me.txt_imp_interno)
    End Sub

    Private Sub txt_exento1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_exento1.KeyPress
        num.positivos_punto(e, Me.txt_exento1)
    End Sub

    Private Sub txt_iva_inscripto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_iva_inscripto.KeyPress
        num.positivos_punto(e, Me.txt_iva_inscripto)
    End Sub

    Private Sub txt_per_ing_bruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_per_ing_bruto.KeyPress
        num.positivos_punto(e, Me.txt_per_ing_bruto)
    End Sub

    Private Sub txt_per_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_per_iva.KeyPress
        num.positivos_punto(e, Me.txt_per_iva)
    End Sub
End Class
