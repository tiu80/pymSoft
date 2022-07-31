Imports System.Data
Imports System.Data.SqlClient

Public Class Form_alta_movimiento

    Dim stc As New pymsoft.prov_vend_list_bco
    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            Call cargar_datos()
            Me.txt_descripcion.Focus()

        End If

    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
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

    Private Sub cmd_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_guardar.Click

        If Me.txt_codigo.Text = "" Or Me.txt_descripcion.Text = "" Or Me.txt_cuenta.Text = "" Then
            MessageBox.Show("Complete todos los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        coman = New SqlCommand("insert into mov_01(id_mov,detalle,cuenta,det_cuenta,fec_emi,fec_fin,mov,det_mov) values ('" & Me.txt_codigo.Text & "','" & Me.txt_descripcion.Text & "','" & Me.txt_cuenta.Text & "','" & Me.lbl_nom_cta.Text & "','" & Me.dt_fec_ini.Text & "','" & Me.dt_fec_fin.Text & "','" & Me.cmb_movimiento.Text & "','" & Me.cmb_det_mov.Text & "')", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()
        conex.Close()

        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_cuenta.Text = ""
        Me.lbl_nom_cta.Text = ""

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        Try

            Dim det As String = ""

            If Me.txt_codigo.Text = "" Or Me.txt_descripcion.Text = "" Then
                MessageBox.Show("Complete todos los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If RTrim(Me.txt_descrip_interna.Text) = "EXTRACCION DE VALES" Or RTrim(Me.txt_descrip_interna.Text) = "EXTRACCION DE CHEQUES" Or RTrim(Me.txt_descrip_interna.Text) = "PAGOS" Or RTrim(Me.txt_descrip_interna.Text) = "TRANSFERENCIAS" Or RTrim(Me.txt_descrip_interna.Text) = "MOVIMIENTOS VARIOS" Then
                det = Me.txt_descrip_interna.Text
            Else
                det = Me.txt_descripcion.Text
            End If

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("update mov_01 set id_mov = '" & Me.txt_codigo.Text & "',detalle = '" & det & "',cuenta = '" & Me.txt_cuenta.Text & "',det_cuenta = '" & Me.lbl_nom_cta.Text & "',fec_emi = '" & Me.dt_fec_ini.Text & "',fec_fin = '" & Me.dt_fec_fin.Text & "', mov = '" & Me.cmb_movimiento.Text & "',det_mov = '" & Me.cmb_det_mov.Text & "' where id_mov = '" & Me.txt_cod_interno.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()
            conex.Close()

            Me.txt_codigo.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.txt_codigo.Focus()

        Catch ex As Exception

            MessageBox.Show("Ya existe el codigo", "pyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Dim x As Integer = MessageBox.Show("Esta seguro que desea borrar", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x = 6 Then

            If RTrim(Me.txt_descrip_interna.Text) = "EXTRACCION DE VALES" Or RTrim(Me.txt_descrip_interna.Text) = "EXTRACCION DE CHEQUES" Or RTrim(Me.txt_descrip_interna.Text) = "PAGOS" Or RTrim(Me.txt_descrip_interna.Text) = "TRANSFERENCIAS" Or RTrim(Me.txt_descrip_interna.Text) = "MOVIMIENTOS VARIOS" Then
                MessageBox.Show("Este movimiento no se puede borrar", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("DELETE mov_01 where id_mov = '" & Me.txt_codigo.Text & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()
            conex.Close()

            Me.txt_codigo.Text = ""
            Me.txt_descripcion.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.txt_cod_interno.Focus()

        End If

    End Sub

    Private Sub Form_alta_movimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.cmd_guardar.Enabled = False
            Me.cmb_movimiento.Text = Me.cmb_movimiento.Items(0)
            Me.cmb_det_mov.Text = Me.cmb_det_mov.Items(0)

        Catch ex As Exception

            Me.cmd_guardar.Enabled = True

        End Try

    End Sub

    Private Sub txt_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cuenta.LostFocus

        stc.instruccion = "select * from plan_cuenta where cuenta like '" & RTrim(Me.txt_cuenta.Text) & "'"
        stc.codigo = "cuenta"
        stc.nombre = "nombre"
        stc.cargar()

        If stc.validar = True Then
            Me.txt_cuenta.Text = stc.text
            Me.lbl_nom_cta.Text = stc.text2
            Me.cmb_movimiento.Focus()
        Else
            Me.txt_cuenta.Text = ""
            Me.txt_cuenta.Focus()
        End If

    End Sub

    Private Sub cargar_datos()

        Try

            Dim tbl As New DataTable
            conex = conecta()

            comando = New SqlDataAdapter("select id_mov,detalle,cuenta,det_cuenta,fec_emi,fec_fin,mov,det_mov from mov_01 where id_mov = '" & RTrim(Me.txt_codigo.Text) & "'", conex)
            comando.Fill(tbl)

            Me.txt_codigo.Text = tbl.Rows(0).Item(0)
            Me.txt_cod_interno.Text = tbl.Rows(0).Item(0)
            Me.txt_cuenta.Text = tbl.Rows(0).Item(2)
            Me.txt_descrip_interna.Text = tbl.Rows(0).Item(1)
            Me.lbl_nom_cta.Text = tbl.Rows(0).Item(3)
            Me.txt_descripcion.Text = tbl.Rows(0).Item(1)
            Me.dt_fec_ini.Text = tbl.Rows(0).Item(4)
            Me.dt_fec_fin.Text = tbl.Rows(0).Item(5)
            Me.cmb_movimiento.Text = tbl.Rows(0).Item(6)
            Me.cmb_det_mov.Text = tbl.Rows(0).Item(7)

            tbl.Dispose()

        Catch ex As Exception

            Me.txt_codigo.Text = ""
            Me.txt_cod_interno.Text = ""
            Me.txt_cuenta.Text = ""
            Me.lbl_nom_cta.Text = ""
            Me.txt_descripcion.Text = ""
            Me.dt_fec_ini.Text = ""
            Me.dt_fec_fin.Text = ""

        End Try

    End Sub

    Private Sub cmb_movimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_movimiento.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmb_det_mov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_det_mov.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

End Class