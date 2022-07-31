Imports System.Data
Imports System.Data.SqlClient

Public Class Form_rep_etiquetas

    Dim carga As New pymsoft.factura
    Dim reporte As New pymsoft.reporte
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim tb As New DataTable, tb1 As New DataTable, tb2 As New DataTable, tb3 As New DataTable, tb4 As New DataTable
    Dim tipo, i As Integer
    Dim codart As String

    Private Sub imprime(ByVal codigo As String)

        Dim rep As Object = Nothing
        Dim x As String

        If Me.chk_codigo.Checked = True Then

            If Me.cmb_desde.Text = "" Then Exit Sub

            x = reporte.carga_datos("etiquetas")

            If x = "etiquetas" Then
                rep = New etiquetas
            End If

            x = reporte.carga_datos("etiquetas2")

            If x = "etiquetas2" Then
                rep = New etiquetas2
            End If

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

            rep.RecordSelectionFormula = "{art_precio.id_art1}= '" & RTrim(codigo) & "' and {art_precio.id_lista1} = " & RTrim(Me.txt_lista.Text) & ""

            'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
            If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
            rep.PrintToPrinter(1, False, 0, 0)

            rep.Dispose()

            Me.cmb_desde.Focus()
            Me.cmb_desde.SelectAll()

        End If

        If Me.chk_rubro.Checked = True Then

            If Me.cmb_desde.Text = "" Then Exit Sub

            tb3.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select id_art,id_lista from art_01 where rubro = '" & RTrim(Me.cmb_desde.Text) & "'", conex)
            comando.Fill(tb3)

            For i = 0 To tb3.Rows.Count - 1

                x = reporte.carga_datos("etiquetas")

                If x = "etiquetas" Then
                    rep = New etiquetas
                End If

                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

                rep.RecordSelectionFormula = "{art_01.id_art}= '" & RTrim(tb3.Rows(i).Item(0)) & "' and {art_01.id_lista} = " & RTrim(tb3.Rows(i).Item(1)) & ""

                rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                rep.PrintToPrinter(1, False, 0, 0)

                rep.Dispose()

            Next

            Me.txt_lista.Focus()
            tb3.Dispose()

        End If

        If Me.chk_proveedor.Checked = True Then

            If Me.cmb_desde.Text = "" Then Exit Sub

            tb4.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select id_art,id_lista from art_01 where proveedor = '" & RTrim(Me.cmb_desde.Text) & "'", conex)
            comando.Fill(tb4)

            For i = 0 To tb4.Rows.Count - 1

                x = reporte.carga_datos("etiquetas")

                If x = "etiquetas" Then
                    rep = New etiquetas
                End If

                rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
                rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

                rep.RecordSelectionFormula = "{art_01.id_art}= '" & RTrim(tb4.Rows(i).Item(0)) & "' and {art_01.id_lista} = " & RTrim(tb4.Rows(i).Item(1)) & ""

                rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora
                rep.PrintToPrinter(1, False, 0, 0)

                rep.Dispose()

            Next

            Me.txt_lista.Focus()
            tb4.Dispose()

        End If

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub Form_rep_etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1

        carga.carga_parametro()

        Me.txt_lista.Text = carga.lista_predeterminada

        conex = conecta()

        comando = New SqlDataAdapter("select nombre from lista_01 where id_lis = '" & RTrim(Me.txt_lista.Text) & "'", conex)
        comando.Fill(tb)
        comando.Dispose()

        Me.Label6.Text = tb.Rows(0).Item(0)
        tb.Dispose()

    End Sub

    Private Sub chk_codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_codigo.CheckedChanged
        If Me.chk_codigo.Checked = True Then
            Me.chk_proveedor.Checked = False
            Me.chk_rubro.Checked = False
            Me.cmb_hasta.Enabled = False

            Call limpia()
        End If
    End Sub

    Private Sub chk_rubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_rubro.CheckedChanged
        If Me.chk_rubro.Checked = True Then
            Me.chk_codigo.Checked = False
            Me.chk_proveedor.Checked = False
            Me.cmb_hasta.Enabled = True

            tipo = 1
            Call carga_tipo("rub_01")

        End If
    End Sub

    Private Sub chk_proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_proveedor.CheckedChanged
        If Me.chk_proveedor.Checked = True Then
            Me.chk_rubro.Checked = False
            Me.chk_codigo.Checked = False
            Me.cmb_hasta.Enabled = True

            tipo = 2
            Call carga_tipo("cli_01")

        End If
    End Sub

    Private Sub cmb_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_desde.GotFocus
        Me.cmb_desde.SelectAll()
    End Sub

    Private Sub cmb_desde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_desde.KeyDown
        If e.KeyCode = Keys.F1 Then
            busc_articulos.txt_lista.Text = Me.txt_lista.Text
            busc_articulos.Show()
        End If
        If e.KeyCode = Keys.Return Then
            If Me.cmb_hasta.Enabled = False Then
                busca_producto()
            End If
        End If
    End Sub

    Private Sub busca_producto()
        Try

            tb1.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select nombre,id_art from art_01 where id_art = '" & RTrim(Me.cmb_desde.Text) & "'", conex)
            comando.Fill(tb1)
            comando.Dispose()

            Me.lbl_articulo.Text = tb1.Rows(0).Item(0)
            codart = tb1.Rows(0).Item(1)
            Me.cmb_hasta.Text = Me.cmb_desde.Text

            imprime(codart)

            tb1.Dispose()

        Catch ex As Exception

            Call lee_codigo_barra(Me.cmb_desde.Text)

        End Try

    End Sub

    Private Sub cmb_desde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_desde.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmb_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_hasta.GotFocus
        Me.cmb_hasta.SelectAll()
    End Sub

    Private Sub cmb_hasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_hasta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub carga_tipo(ByVal valor As String)

        tb2.Clear()
        conex = conecta()

        If tipo = 1 Then
            comando = New SqlDataAdapter("select nombre from" & " " & valor, conex)
            comando.Fill(tb2)
            comando.Dispose()
        End If

        If tipo = 2 Then
            comando = New SqlDataAdapter("select nombre from" & " " & valor & " " & " where tipo_cliente = 'Proveedor'", conex)
            comando.Fill(tb2)
            comando.Dispose()
        End If

        Me.cmb_desde.DataSource = tb2
        Me.cmb_desde.DisplayMember = "nombre"

        Me.cmb_desde.DropDownStyle = ComboBoxStyle.DropDownList
        Me.lbl_articulo.Text = ""

    End Sub

    Private Sub limpia()

        Me.cmb_desde.DataSource = Nothing
        Me.cmb_desde.DropDownStyle = ComboBoxStyle.DropDown
        Me.cmb_desde.Focus()

    End Sub

    Private Sub txt_lista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lista.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_desde.Focus()
        End If
    End Sub

    Private Sub lee_codigo_barra(ByVal codigo As String)

        Try

            tb1.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select nombre,id_art from art_01 where codigo_barra = '" & RTrim(Me.cmb_desde.Text) & "'", conex)
            comando.Fill(tb1)
            comando.Dispose()

            Me.lbl_articulo.Text = tb1.Rows(0).Item(0)
            codart = tb1.Rows(0).Item(1)
            Me.cmb_hasta.Text = Me.cmb_desde.Text

            tb1.Dispose()

            imprime(codart)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class