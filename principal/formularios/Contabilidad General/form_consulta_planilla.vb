Imports System.Data
imports System.Data.SqlClient

Public Class form_consulta_planilla

    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim tb As New DataTable, tb1 As New DataTable, tb2 As New DataTable, tbl As New DataTable

    Private Sub form_consulta_planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        tb.Clear()
        tbl.Clear()
        Me.cmb_planilla.Items.Clear()
        Dim i As Integer

        comando = New SqlDataAdapter("select descripcion from planilla01", conex)
        comando.Fill(tb)

        For i = 0 To tb.Rows.Count - 1
            Me.cmb_planilla.Items.Add(tb.Rows(i).Item(0))
        Next

        Me.cmb_planilla.Text = Me.cmb_planilla.Items(0)

        comando = New SqlDataAdapter("select detalle from mov_01 ORDER BY detalle ASC", conex)
        comando.Fill(tbl)

        Me.cmb_movimientos.Items.Add("TOTAL")

        For i = 0 To tbl.Rows.Count - 1
            Me.cmb_movimientos.Items.Add(tbl.Rows(i).Item(0))
        Next

        Me.cmb_movimientos.Text = Me.cmb_movimientos.Items(0)

    End Sub

    Private Sub cmb_planilla_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_planilla.LostFocus

        conex = conecta()
        tb1.Clear()

        comando = New SqlDataAdapter("select numero_planilla from planilla01 where descripcion = '" & RTrim(Me.cmb_planilla.Text) & "'", conex)
        comando.Fill(tb1)

        Me.txt_cod_planilla.Text = tb1.Rows(0).Item(0)
        Me.txt_cod_planilla.ReadOnly = True
        Me.dt_fec_desde.Focus()

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Form_detalle_planilla.txt_estado_form.Text = 1
        Form_detalle_planilla.Show()

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

End Class