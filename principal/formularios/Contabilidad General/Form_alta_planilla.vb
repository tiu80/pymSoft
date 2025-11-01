Imports System.Data
Imports System.Data.SqlClient

Public Class Form_alta_planilla

    Dim num As New pymsoft.numerodecimales
    Dim stc As New pymsoft.prov_vend_list_bco
    Dim coman As SqlCommand
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl As New DataTable, tbl1 As New DataTable

    Private Sub txt_numero_palnilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_palnilla.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_n_comprobante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_comprobante.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_cuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cuenta.KeyDown

        If e.KeyCode = Keys.F1 Then
            busc_cuenta.Show()
        End If

    End Sub

    Private Sub txt_cuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cuenta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_saldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_saldo.KeyPress
        num.positivos_punto(e, Me.txt_saldo)
    End Sub

    Private Sub cmd_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_guardar.Click

        If Me.txt_cod_pllanilla.Text = "" Or Me.txt_desc_asiento.Text = "" Or Me.txt_descripcion.Text = "" Or Me.txt_cuenta.Text = "" Or Me.txt_n_comprobante.Text = "" Or Me.txt_numero_palnilla.Text = "" Or Me.txt_saldo.Text = "" Then
            MessageBox.Show("Complete todos los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("insert into planilla01(id_planilla,numero_planilla,descripcion,desc_asiento,num_movimiento,cuenta,fec_ini,fec_fin,saldo,nom_cuenta) values ('" & Me.txt_cod_pllanilla.Text & "','" & Me.txt_numero_palnilla.Text & "','" & Me.txt_descripcion.Text & "','" & Me.txt_desc_asiento.Text & "','" & Me.txt_n_comprobante.Text & "','" & Me.txt_cuenta.Text & "','" & Me.dt_fec_ini.Text & "','" & Me.dt_fec_fin.Text & "','" & Me.txt_saldo.Text & "','" & Me.lbl_nom_cta.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()
        conex.Close()

        Me.txt_cod_pllanilla.Text = ""
        Me.txt_numero_palnilla.Text = ""
        Me.txt_desc_asiento.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_cuenta.Text = ""
        Me.lbl_nom_cta.Text = ""
        Me.txt_saldo.Text = ""
        Me.txt_n_comprobante.Text = ""

    End Sub

    Private Sub Form_alta_planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            conex = conecta()
            tbl.Clear()

            comando = New SqlDataAdapter("select id_planilla,numero_planilla,descripcion,desc_asiento,num_movimiento,cuenta,nom_cuenta,fec_ini,fec_fin,saldo from planilla01", conex)
            comando.Fill(tbl)

            Me.txt_cod_pllanilla.Text = tbl.Rows(0).Item(0)
            Me.txt_cod_interno.Text = tbl.Rows(0).Item(0)
            Me.txt_numero_palnilla.Text = tbl.Rows(0).Item(1)
            Me.txt_descripcion.Text = tbl.Rows(0).Item(2)
            Me.txt_desc_asiento.Text = tbl.Rows(0).Item(3)
            Me.txt_n_comprobante.Text = tbl.Rows(0).Item(4)
            Me.txt_cuenta.Text = tbl.Rows(0).Item(5)
            Me.lbl_nom_cta.Text = tbl.Rows(0).Item(6)
            Me.dt_fec_ini.Text = tbl.Rows(0).Item(7)
            Me.dt_fec_fin.Text = tbl.Rows(0).Item(8)
            Me.txt_saldo.Text = tbl.Rows(0).Item(9)

            Me.cmd_guardar.Enabled = False

        Catch ex As Exception

            Me.cmd_guardar.Enabled = True

        End Try

    End Sub

    Private Sub carga_planilla()

        Try

            conex = conecta()
            tbl.Clear()

            comando = New SqlDataAdapter("select id_planilla,numero_planilla,descripcion,desc_asiento,num_movimiento,cuenta,nom_cuenta,fec_ini,fec_fin,saldo from planilla01 where id_planilla = '" & RTrim(Me.txt_cod_pllanilla.Text) & "'", conex)
            comando.Fill(tbl)

            Me.txt_cod_pllanilla.Text = tbl.Rows(0).Item(0)
            Me.txt_cod_interno.Text = tbl.Rows(0).Item(0)
            Me.txt_numero_palnilla.Text = tbl.Rows(0).Item(1)
            Me.txt_descripcion.Text = tbl.Rows(0).Item(2)
            Me.txt_desc_asiento.Text = tbl.Rows(0).Item(3)
            Me.txt_n_comprobante.Text = tbl.Rows(0).Item(4)
            Me.txt_cuenta.Text = tbl.Rows(0).Item(5)
            Me.lbl_nom_cta.Text = tbl.Rows(0).Item(6)
            Me.dt_fec_ini.Text = tbl.Rows(0).Item(7)
            Me.dt_fec_fin.Text = tbl.Rows(0).Item(8)
            Me.txt_saldo.Text = tbl.Rows(0).Item(9)

            Me.cmd_guardar.Enabled = False
            Me.cmd_eliminar.Enabled = True
            Me.cmd_actualiza.Enabled = True

            Me.txt_numero_palnilla.Focus()

        Catch ex As Exception

            Me.txt_numero_palnilla.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_desc_asiento.Text = ""
            Me.txt_n_comprobante.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.dt_fec_ini.Text = ""
            Me.dt_fec_fin.Text = ""
            Me.txt_saldo.Text = ""
            Me.cmd_guardar.Enabled = True
            Me.cmd_eliminar.Enabled = False
            Me.cmd_actualiza.Enabled = False
            Me.txt_numero_palnilla.Focus()

        End Try

    End Sub

    Private Sub txt_cod_pllanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_pllanilla.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Call carga_planilla()
        End If

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        Try

            If Me.txt_cod_pllanilla.Text = "" Or Me.txt_desc_asiento.Text = "" Or Me.txt_descripcion.Text = "" Or Me.txt_cuenta.Text = "" Or Me.txt_n_comprobante.Text = "" Or Me.txt_numero_palnilla.Text = "" Or Me.txt_saldo.Text = "" Then
                MessageBox.Show("Complete todos los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("update planilla01 set id_planilla = '" & Me.txt_cod_pllanilla.Text & "',numero_planilla = '" & Me.txt_numero_palnilla.Text & "',descripcion = '" & Me.txt_descripcion.Text & "',desc_asiento = '" & Me.txt_desc_asiento.Text & "',num_movimiento = '" & Me.txt_n_comprobante.Text & "',cuenta = '" & Me.txt_cuenta.Text & "',fec_ini = '" & Me.dt_fec_ini.Text & "',fec_fin = '" & Me.dt_fec_fin.Text & "',saldo = '" & Me.txt_saldo.Text & "',nom_cuenta = '" & Me.lbl_nom_cta.Text & "' where id_planilla = '" & Me.txt_cod_interno.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()
            conex.Close()

            Me.txt_cod_pllanilla.Text = ""
            Me.txt_numero_palnilla.Text = ""
            Me.txt_desc_asiento.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.txt_saldo.Text = ""
            Me.txt_n_comprobante.Text = ""
            Me.txt_cod_pllanilla.Focus()

        Catch ex As Exception

            MessageBox.Show("Ya existe el codigo", "pyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Dim x As Integer = MessageBox.Show("Esta seguro que desea borrar", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x = 6 Then

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("DELETE planilla01 where id_planilla = '" & Me.txt_cod_pllanilla.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()
            conex.Close()

            Me.txt_cod_pllanilla.Text = ""
            Me.txt_numero_palnilla.Text = ""
            Me.txt_desc_asiento.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.txt_saldo.Text = ""
            Me.txt_n_comprobante.Text = ""
            Me.txt_cod_pllanilla.Focus()

        End If

    End Sub

    Private Sub txt_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cuenta.LostFocus

        stc.instruccion = "select * from plan_cuenta where cuenta like '" & RTrim(Me.txt_cuenta.Text) & "'"
        stc.codigo = "cuenta"
        stc.nombre = "nombre"
        stc.cargar()

        If stc.validar = True Then
            Me.txt_cuenta.Text = stc.text
            Me.lbl_nom_cta.Text = stc.text2
            Me.dt_fec_ini.Focus()
        Else
            Me.txt_cuenta.Text = ""
            Me.txt_cuenta.Focus()
        End If

    End Sub
End Class