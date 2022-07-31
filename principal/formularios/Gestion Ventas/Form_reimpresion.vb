Imports System.Data
Imports System.Data.SqlClient

Public Class Form_reimpresion

    Dim reporte As New pymsoft.reporte
    Dim fact As New pymsoft.factura
    Dim tb As New DataTable
    Dim conex As New SqlConnection
    Dim coman As SqlDataAdapter

    Private Sub Form_reimpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)
        fact.carga_parametro()

    End Sub

    Private Sub txt_prefijo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_prefijo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_numero_desde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_desde.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_numero_hasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_hasta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_letra.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmd_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_imprimir.Click

        Dim i, j, valor As Integer
        Dim rep As Object

        Dim x As String = ""
        j = fact.copias_impresora_comun

        Me.txt_letra.Text = UCase(Me.txt_letra.Text)

        valor = Val(Me.txt_numero_hasta.Text) - Val(Me.txt_numero_desde.Text)

        If valor < 0 Then
            MessageBox.Show("Seleccione valores correctos!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_numero_desde.Text = ""
            Me.txt_numero_hasta.Text = ""
            Me.txt_numero_desde.Focus()
            Exit Sub
        End If

        For i = Me.txt_numero_desde.Text To Me.txt_numero_hasta.Text

            reporte.carga_formato_factura(Me.txt_letra.Text)
            rep = reporte.formato
            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")

            For j = 0 To j - 1
                rep.RecordSelectionFormula = "{fact_cab.num_fact1}= " & i & " and {fact_cab.letra_fact} = '" & RTrim(Me.txt_letra.Text) & "' and {fact_cab.prefijo_fact} = " & RTrim(Me.txt_prefijo.Text) & " and {fact_cab.tipo_fact}= '" & RTrim(Me.cmb_tipo.Text) & "'"
                rep.PrintToPrinter(1, False, 0, 0)
            Next

        Next

        rep = Nothing
        Me.Close()

    End Sub

End Class