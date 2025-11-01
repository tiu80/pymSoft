Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_planilla

    Dim stc As New pymsoft.prov_vend_list_bco
    Dim num As New pymsoft.numerodecimales
    Dim tbl As New DataTable, tbl1 As New DataTable, tbl2 As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim coman As SqlCommand
    Dim funo As Boolean = True, estado As Boolean = False
    Public cont As Integer

    Private Sub txt_num_comprobante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_num_comprobante.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_imputacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.F1 Then
            busc_cuenta.Show()
        End If

    End Sub

    Private Sub txt_imputacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe.KeyPress
        num.positivos_punto(e, Me.txt_importe)
    End Sub

    Private Sub Form_muestra_planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        tbl.Clear()

        comando = New SqlDataAdapter("select detalle from mov_01 ORDER BY detalle ASC", conex)
        comando.Fill(tbl)

        Me.cmb_movimiento.DataSource = tbl
        Me.cmb_movimiento.ValueMember = "detalle"

        Me.cmd_aceptar.BackColor = Color.LightGray
        Me.cmd_cancelar.BackColor = Color.LightGray

    End Sub

    Private Sub carga_tipo_movimiento()

        conex = conecta()
        tbl1.Clear()

        comando = New SqlDataAdapter("select detalle,cuenta,det_cuenta,mov,det_mov from mov_01 where detalle = '" & RTrim(Me.cmb_movimiento.Text) & "'", conex)
        comando.Fill(tbl1)

        If RTrim(tbl1.Rows(0).Item(4)) = "3- Cuenta - Sin Detalle" Then
            Call Cuenta_sin_Detalle()
        End If

        If RTrim(tbl1.Rows(0).Item(4)) = "1- Cuenta - Detalle" Then
            Call Cuenta_Detalle()
        End If

        If RTrim(tbl1.Rows(0).Item(4)) = "2- Cuenta - Detalle / F1" Then
            Call Cuenta_Detalle_F1()
        End If

        If RTrim(tbl1.Rows(0).Item(3)) = "Salida - Acreedor" Then
            Me.opt_entrada.Enabled = False
            Me.opt_salida.Checked = True
        Else
            Me.opt_entrada.Enabled = True
            Me.opt_entrada.Checked = True
        End If

    End Sub

    Private Sub Cuenta_Detalle()

        Me.txt_num_comprobante.Enabled = True
        Me.txt_inputacion.Enabled = True
        Me.dt_fec_acredit.Enabled = True
        Me.txt_importe.Enabled = True
        Me.grupo.Enabled = True

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_cancelar.Enabled = True
        Me.cmd_cancelar.BackColor = Color.Black

        Me.txt_detalle.Focus()

        funo = False

    End Sub

    Private Sub Cuenta_Detalle_F1()

        Me.txt_inputacion.Text = tbl1.Rows(0).Item(1)
        Me.lbl_imputacion.Text = tbl1.Rows(0).Item(2)

        Me.txt_num_comprobante.Enabled = False
        Me.txt_inputacion.Enabled = False
        Me.dt_fec_acredit.Enabled = False
        Me.txt_importe.Enabled = False
        Me.grupo.Enabled = False

        Me.cmd_aceptar.Enabled = False
        Me.cmd_aceptar.BackColor = Color.LightGray
        Me.cmd_cancelar.Enabled = False
        Me.cmd_cancelar.BackColor = Color.LightGray

        Me.txt_detalle.Focus()

        funo = True

    End Sub

    Private Sub Cuenta_sin_Detalle()

        Me.txt_inputacion.Text = tbl1.Rows(0).Item(1)
        Me.lbl_imputacion.Text = tbl1.Rows(0).Item(2)

        Me.txt_num_comprobante.Enabled = False
        Me.txt_inputacion.Enabled = False
        Me.dt_fec_acredit.Enabled = False
        Me.txt_importe.Enabled = True
        Me.grupo.Enabled = True

        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black
        Me.cmd_cancelar.Enabled = True
        Me.cmd_cancelar.BackColor = Color.Black

        Me.txt_detalle.Focus()

    End Sub

    Private Sub cmb_movimiento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_movimiento.LostFocus
        Call carga_tipo_movimiento()
    End Sub

    Private Sub txt_detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_detalle.KeyDown
        If e.KeyCode = Keys.F1 Then
            If funo = True Then
                Call carga_cartera()
            End If
        End If
    End Sub

    Private Sub carga_cartera()

        Dim tbl_cheque As New DataTable, tbl_vale As New DataTable

        If RTrim(Me.cmb_movimiento.Text) = "EXTRACCION DE CHEQUES" Then

            conex = conecta()
            tbl_cheque.Clear()

            comando = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where estado = 'I'", conex)
            comando.Fill(tbl_cheque)

            Form_muestra_cartera.DataGridView1.DataSource = tbl_cheque
            Form_muestra_cartera.txt_info.Text = ""

            Form_muestra_cartera.TextBox1.Visible = True
            Form_muestra_cartera.Label1.Visible = True
            Form_muestra_cartera.BackColor = Color.DarkGray

            Form_muestra_cartera.txt_info.Text = "Tipo de Movimiento:" & "  " & Me.cmb_movimiento.Text & vbCrLf & "Modalidad:" & "  " & "Total" & vbCrLf & "Tipo de Planilla:" & "  " & Form_planilla.cmb_planilla.Text & vbCrLf & "Estado:" & "  " & "Cartera - Ingreso "

            Form_muestra_cartera.Text = "CARTERA DE CHEQUES"
            cont = cont + 1

            Form_muestra_cartera.Show()
            Exit Sub

        End If

        If RTrim(Me.cmb_movimiento.Text) = "EXTRACCION DE VALES" Then

            conex = conecta()
            tbl_vale.Clear()

            comando = New SqlDataAdapter("select fec_emi,id_vale,detalle,total from vale_01 where estado = 'I'", conex)
            comando.Fill(tbl_vale)

            Form_muestra_cartera.DataGridView1.DataSource = tbl_vale
            Form_muestra_cartera.txt_info.Text = ""

            Form_muestra_cartera.TextBox1.Visible = True
            Form_muestra_cartera.Label1.Visible = True
            Form_muestra_cartera.BackColor = Color.DarkGray

            Form_muestra_cartera.txt_info.Text = "Tipo de Movimiento:" & "  " & Me.cmb_movimiento.Text & vbCrLf & "Modalidad:" & "  " & "Total" & vbCrLf & "Tipo de Planilla:" & "  " & Form_planilla.cmb_planilla.Text & vbCrLf & "Estado:" & "  " & "Cartera - Ingreso "

            Form_muestra_cartera.Text = "CARTERA DE VALES"

            Form_muestra_cartera.Show()
            Exit Sub

        End If

    End Sub

    Private Sub guarda_movimiento_planilla()

        If Form_planilla.existe_movimiento = False Then   ' guardo simepre y cuando no exista el movimiento asi no se duplica en la tabla

            Dim i As Integer
            Dim tb_caja As New DataTable

            conex = conecta()
            tbl2.Clear()

            comando = New SqlDataAdapter("select num_movimiento from planilla01 where descripcion = '" & RTrim(Form_planilla.cmb_planilla.Text) & "'", conex)
            comando.Fill(tbl2)

            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("update planilla01 set num_movimiento = '" & tbl2.Rows(0).Item(0) + 2 & "' where descripcion = '" & RTrim(Form_planilla.cmb_planilla.Text) & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                Dim detalle As String = Me.DataGridView1.Rows(i).Cells(2).Value & "  " & Me.DataGridView1.Rows(i).Cells(6).Value

                coman = New SqlCommand("insert into planilla_caja(num_interno,fec_emi,cuenta,det_cuenta,entrada,salida,np,tp,mes,año,operacion,num_comprobante,bco,movimiento,des) values ('" & Me.DataGridView1.Rows(i).Cells(0).Value & "','" & Form_planilla.DateTimePicker1.Text & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & detalle & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Me.DataGridView1.Rows(i).Cells(4).Value & "','" & Me.txt_numero_planilla.Text & "','" & Me.txt_codigo_planilla.Text & "','" & Form_planilla.DateTimePicker1.Value.Month & "','" & Form_planilla.DateTimePicker1.Value.Year & "','" & i & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "','" & Me.DataGridView1.Rows(i).Cells(6).Value & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(8).Value & "')", conex)
                coman.ExecuteNonQuery()

                coman.Dispose()
                detalle = Nothing

            Next

            estado = True
            conex.Close()
            Me.Close()
            Form_planilla.Close()

        End If

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Call carga_item_grilla()

    End Sub

    Private Sub Tool_eminina_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_eminina_item.Click

        Call elimina_item()

    End Sub

    Private Sub carga_item_grilla()

        Try

            If Me.txt_importe.Text = "" Or Me.txt_importe.Text.ToString = "0.00" Or Val(Me.txt_importe.Text) = 0 Then Exit Sub

            Dim z As Integer

            z = Me.DataGridView1.Rows.Count

            Me.DataGridView1.Rows.Add()

            Me.DataGridView1.Rows(z).Cells(0).Value = Form_planilla.txt_numero_int.Text
            Me.DataGridView1.Rows(z).Cells(1).Value = Me.txt_inputacion.Text
            Me.DataGridView1.Rows(z).Cells(2).Value = Me.lbl_imputacion.Text
            Me.DataGridView1.Rows(z).Cells(8).Value = Me.txt_detalle.Text

            If Me.opt_entrada.Checked = True Then
                If RTrim(tbl1.Rows(0).Item(3)) = "Salida - Acreedor" Then Me.txt_importe.Text = Me.txt_importe.Text * (-1)
                Me.DataGridView1.Rows(z).Cells(3).Value = Me.txt_importe.Text
            End If

            If Me.opt_salida.Checked = True Then
                If RTrim(tbl1.Rows(0).Item(3)) = "Entrada - Deudor" Then Me.txt_importe.Text = Me.txt_importe.Text * (-1)
                Me.DataGridView1.Rows(z).Cells(4).Value = Me.txt_importe.Text
            End If

            Me.DataGridView1.Rows(z).Cells(7).Value = Me.cmb_movimiento.Text

            Me.txt_detalle.Text = ""
            Me.txt_inputacion.Text = ""
            Me.lbl_imputacion.Text = ""
            Me.txt_importe.Text = ""
            Me.txt_num_comprobante.Text = ""
            Me.cmb_movimiento.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_guarda_mov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_guarda_mov.Click

        If Me.DataGridView1.Rows.Count = Nothing Then Exit Sub
        Call guarda_movimiento_planilla()

    End Sub

    Private Sub Tool_eminima_mov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_eminima_mov.Click

        Form_planilla.existe_movimiento = False
        Call elimina_movimiento()

    End Sub

    Private Sub Tool_exporta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_exporta.Click
        Form_exporta.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub elimina_item()

        Try

            Dim i As Integer = Me.DataGridView1.CurrentCell.RowIndex   ' fila actual

            ' VERIFICA QUE EXISTA EL MOVIMIENTO EN LA PLANILLA PARA ese items

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            ' elimina un cheque

            If RTrim(Me.DataGridView1.Rows(i).Cells(7).Value) = "EXTRACCION DE CHEQUES" Then

                coman = New SqlCommand("update cheque_01 set estado = 'I' where id_cheque = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "' and banco = '" & RTrim(Me.DataGridView1.Rows(i).Cells(6).Value) & "' and total = '" & RTrim(Val(Me.DataGridView1.Rows(i).Cells(3).Value)) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                coman = New SqlCommand("delete planilla_caja where num_comprobante = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "' and num_interno = '" & Form_planilla.txt_numero_int.Text & "' and bco = '" & RTrim(Me.DataGridView1.Rows(i).Cells(6).Value) & "' and entrada = '" & RTrim(Val(Me.DataGridView1.Rows(i).Cells(3).Value)) & "'", conex)
                coman.ExecuteNonQuery()
                conex.Close()

            End If

            Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub elimina_movimiento()

        Dim x As Integer

        x = MessageBox.Show("Esta seguro que desea borrar el movimiento?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x = 7 Then Exit Sub

        Try

            Dim i As Integer

            ' VERIFICA QUE EXISTA EL MOVIMIENTO EN LA PLANILLA 

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("delete planilla_caja where num_interno = '" & Form_planilla.txt_numero_int.Text & "'", conex)
            coman.ExecuteNonQuery()

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                If RTrim(Me.DataGridView1.Rows(i).Cells(7).Value) = "EXTRACCION DE CHEQUES" Then

                    coman = New SqlCommand("update cheque_01 set estado = 'I' where id_cheque = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "' and banco = '" & RTrim(Me.DataGridView1.Rows(i).Cells(6).Value) & "' and total = '" & RTrim(Val(Me.DataGridView1.Rows(i).Cells(3).Value)) & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                End If

            Next

            Me.DataGridView1.Rows.Clear()

        Catch ex As Exception

        Finally

            conex.Close()
            Me.Close()
            Form_planilla.Close()

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Delete Then
            If Me.Tool_eminina_item.Enabled = True Then
                Call elimina_item()
            End If
        End If

    End Sub

    Private Sub Form_muestra_planilla_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If estado = False Then

            Dim i As Integer

            If RTrim(Me.cmb_movimiento.Text) = "EXTRACCION DE CHEQUES" Then

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                End If

                For i = 0 To Me.DataGridView1.Rows.Count - 1

                    coman = New SqlCommand("update cheque_01 set estado = 'I' where id_cheque = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "' and banco = '" & RTrim(Me.DataGridView1.Rows(i).Cells(6).Value) & "' and total = '" & RTrim(Val(Me.DataGridView1.Rows(i).Cells(3).Value)) & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                Next

                conex.Close()

            End If

            If RTrim(Me.cmb_movimiento.Text) = "EXTRACCION DE VALES" Then

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                End If

                For i = 0 To Me.DataGridView1.Rows.Count - 1

                    coman = New SqlCommand("update vale_01 set estado = 'I' where id_vale = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "' and total = '" & RTrim(Val(Me.DataGridView1.Rows(i).Cells(3).Value)) & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                Next

                conex.Close()

            End If

        End If

    End Sub


    Private Sub txt_inputacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_inputacion.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            stc.instruccion = "select * from plan_cuenta where cuenta like '" & RTrim(Me.txt_inputacion.Text) & "'"
            stc.codigo = "cuenta"
            stc.nombre = "nombre"
            stc.cargar()

            If stc.validar = True Then
                Me.txt_inputacion.Text = stc.text
                Me.lbl_imputacion.Text = stc.text2
                Me.dt_fec_acredit.Focus()
            Else
                Me.txt_inputacion.Text = ""
                Me.txt_inputacion.Focus()
            End If

        End If

        If e.KeyCode = Keys.F1 Then

            Me.txt_estado_form.Text = 1
            busc_cuenta.Show()

        End If

    End Sub

End Class