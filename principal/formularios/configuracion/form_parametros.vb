Imports System.Data
Imports System.Data.SqlClient

Public Class form_parametros

    Dim par As New pymsoft.parametro
    Public cont, a, b As Integer
    Dim verifica, veri As Boolean
    Dim copiar As Boolean = False

    Dim tabla As New DataTable, tbl As New DataTable, tbl1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            e.SuppressKeyPress = True
            a = Me.DataGridView1.CurrentRow.Index

            If Me.DataGridView1.SelectedCells(2).Value = "NO" Or Me.DataGridView1.SelectedCells(2).Value = "SI" Then

                Me.opt_no.Visible = True
                Me.opt_si.Visible = True
                Me.cmd_ok.Visible = True
                Me.lbl_habilita.Visible = True
                Me.txt_parametro.Visible = False
                Me.lbl_descripcion.Visible = True
                Me.lbl_descripcion.Text = Me.DataGridView1.SelectedCells(1).Value

                If Me.DataGridView1.SelectedCells(2).Value = "NO" Then
                    Me.opt_no.Checked = True
                Else
                    Me.opt_si.Checked = True
                End If

            Else

                Me.opt_no.Visible = False
                Me.opt_si.Visible = False
                Me.txt_parametro.Visible = True
                Me.cmd_ok.Visible = True
                Me.lbl_habilita.Visible = True
                Me.lbl_descripcion.Visible = True
                Me.lbl_descripcion.Text = Me.DataGridView1.SelectedCells(1).Value
                Me.txt_parametro.Focus()

                Me.txt_parametro.Text = Me.DataGridView1.SelectedCells(2).Value
                Me.txt_parametro.SelectAll()

            End If

        End If

    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Me.cmd_actualizar.Enabled = True
        Me.cmd_actualizar.BackColor = Color.Black

        If Me.opt_si.Visible = True Then
            If Me.opt_si.Checked = True Then
                Me.DataGridView1.Rows(a).Cells(2).Value = "SI"
            End If
        End If

        If Me.opt_no.Visible = True Then
            If Me.opt_no.Checked = True Then
                Me.DataGridView1.Rows(a).Cells(2).Value = "NO"
            End If
        End If

        If Me.txt_parametro.Visible = True Then
            Me.DataGridView1.Rows(a).Cells(2).Value = Me.txt_parametro.Text
        End If

        If Me.DataGridView1.Rows(21).Cells(2).Value = "SI" And a = "21" Then
            Me.DataGridView1.Rows(22).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(21).Cells(2).Value = "SI"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(21).Cells(2).Value = "NO" And a = "21" Then
            Me.DataGridView1.Rows(22).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(21).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(22).Cells(2).Value = "SI" And a = "22" Then
            Me.DataGridView1.Rows(22).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(21).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(22).Cells(2).Value = "NO" And a = "22" Then
            Me.DataGridView1.Rows(22).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(21).Cells(2).Value = "SI"
            Exit Sub
        End If

        ''''''''''''''''''''''''' PUERTOS FISCALES '''''''''''''''

        If Me.DataGridView1.Rows(24).Cells(2).Value = "SI" And a = "24" Then
            Me.DataGridView1.Rows(25).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(24).Cells(2).Value = "SI"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(24).Cells(2).Value = "NO" And a = "24" Then
            Me.DataGridView1.Rows(25).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(24).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(25).Cells(2).Value = "SI" And a = "25" Then
            Me.DataGridView1.Rows(25).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(24).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(25).Cells(2).Value = "NO" And a = "25" Then
            Me.DataGridView1.Rows(25).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(24).Cells(2).Value = "SI"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(36).Cells(2).Value = "SI" And a = "36" Then
            Me.DataGridView1.Rows(36).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(37).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(36).Cells(2).Value = "NO" And a = "36" Then
            Me.DataGridView1.Rows(36).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(37).Cells(2).Value = "SI"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(37).Cells(2).Value = "SI" And a = "37" Then
            Me.DataGridView1.Rows(37).Cells(2).Value = "SI"
            Me.DataGridView1.Rows(36).Cells(2).Value = "NO"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(37).Cells(2).Value = "NO" And a = "37" Then
            Me.DataGridView1.Rows(37).Cells(2).Value = "NO"
            Me.DataGridView1.Rows(36).Cells(2).Value = "SI"
            Exit Sub
        End If

        If Me.DataGridView1.Rows(40).Cells(2).Value <> 0 Then

            tbl.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select nombre from vend_01 where id_vendedor = '" & RTrim(Me.DataGridView1.Rows(40).Cells(2).Value) & "'", conex)
            comando.Fill(tbl)

            If tbl.Rows.Count = Nothing Then
                MessageBox.Show("No existe Vendedor", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DataGridView1.Rows(40).Cells(2).Value = 0
                Me.txt_parametro.Text = ""
            Else
                Me.txt_parametro.Visible = False
                Me.cmd_ok.Visible = False
                Me.lbl_descripcion.Visible = False
            End If

            Exit Sub

        End If

        If Me.DataGridView1.Rows(45).Cells(2).Value <> 0 And a = "45" Then

            tbl1.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select * from cli_01 where id_cli = '" & RTrim(Me.txt_parametro.Text) & "'", conex)
            comando.Fill(tbl1)

            If tbl1.Rows.Count = Nothing Then
                MessageBox.Show("No existe cliente", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DataGridView1.Rows(45).Cells(2).Value = 0
                Me.txt_parametro.Text = ""
            Else
                Me.txt_parametro.Visible = False
                Me.cmd_ok.Visible = False
                Me.lbl_descripcion.Visible = False
            End If

            Exit Sub

        End If

        If Me.DataGridView1.Rows(47).Cells(2).Value <> 1 And Me.DataGridView1.Rows(47).Cells(2).Value <> 2 And a = "47" Then
            MessageBox.Show("Seleccione una opcion correcta", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.opt_no.Visible = False
        Me.opt_si.Visible = False
        Me.lbl_descripcion.Visible = False
        Me.cmd_ok.Visible = False
        Me.txt_parametro.Visible = False
        Me.lbl_habilita.Visible = False

        Me.DataGridView1.Focus()

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Try

            Call verifica_datos()

            If verifica = True Then

                Dim i As Integer

                par.instruccion = "select id_parametro from parametro_01 where id_parametro like '" & Me.txt_codigo.Text & "'"
                par.verifica_duplicado()

                If par.verifica = True Then

                    For i = 0 To Me.DataGridView1.Rows.Count - 1

                        par.instruccion = "INSERT INTO parametro_01(id_parametro,descripcion,cod_interno,nom_param,estado) VALUES('" & Me.txt_codigo.Text & "' , '" & Me.txt_descripcion.Text & "','" & Me.DataGridView1.Rows(i).Cells(0).Value & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "')"
                        par.abm()

                    Next

                    Me.txt_codigo.Text = ""
                    Me.txt_descripcion.Text = ""
                    MessageBox.Show("Parametro Guardado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DataGridView1.DataSource = Nothing
                    Me.DataGridView1.Rows.Clear()
                    Me.DataGridView1.Columns.Remove("codigo")
                    Me.DataGridView1.Columns.Remove("Descripcion")
                    Me.DataGridView1.Columns.Remove("Estado")
                    Call carga_grilla()
                    Me.txt_codigo.Focus()

                    Me.cmd_copiar.Enabled = True
                    Me.cmd_copiar.BackColor = Color.Black

                    copiar = False

                End If

            End If

        Catch ex As Exception

        Finally

            Me.Close()

        End Try

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        Try


            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

                If copiar = False Then carga_parametro(Me.txt_codigo.Text)
                If copiar = True Then carga_parametro(Me.txt_interno.Text)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carga_parametro(ByVal codigo As Integer)

        par.instruccion = "select *from parametro_01 where id_parametro like '" & codigo & "'"
        par.instruccion1 = "select Cod_interno,nom_param,estado from parametro_01 where id_parametro like '" & codigo & "'"

        par.mostrar_datos()
        Me.cmd_actualizar.Enabled = False
        Me.cmd_actualizar.BackColor = Color.LightGray

        If Me.txt_codigo.Text = 1 Then
            Me.txt_codigo.Enabled = False
            Me.cmd_borrar.Enabled = False
            Me.cmd_borrar.BackColor = Color.LightGray
            Me.cmd_aceptar.Enabled = False
            Me.cmd_aceptar.BackColor = Color.LightGray
            Me.txt_descripcion.Enabled = False
        End If

        If par.verifica = True Then

            Me.DataGridView1.Columns(0).Width = 73
            Me.DataGridView1.Columns(1).Width = 283
            Me.DataGridView1.Columns(2).Width = 70

            Me.DataGridView1.Columns(0).HeaderText = "Codigo"
            Me.DataGridView1.Columns(1).HeaderText = "Descripcion"
            Me.DataGridView1.Columns(2).HeaderText = "Estado"

        Else

            Me.txt_descripcion.Text = ""
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.Rows.Clear()

            cont = cont + 1

            If cont > 1 Then

                Me.DataGridView1.Columns.Remove("codigo")
                Me.DataGridView1.Columns.Remove("Descripcion")
                Me.DataGridView1.Columns.Remove("Estado")

            End If

            Call carga_grilla()

        End If

        Me.txt_descripcion.Focus()


    End Sub

    Public Sub carga_grilla()

        Me.DataGridView1.Columns.Add("codigo", "Codigo")
        Me.DataGridView1.Columns.Add("Descripcion", "Descripcion")
        Me.DataGridView1.Columns.Add("Estado", "Estado")

        Me.DataGridView1.Columns(0).Width = 73
        Me.DataGridView1.Columns(1).Width = 283
        Me.DataGridView1.Columns(2).Width = 70

        Me.DataGridView1.Rows.Add(1, "CANTIDAD DETALLE", "10")
        Me.DataGridView1.Rows.Add(2, "PIDE TIPO PAGO", "NO")
        Me.DataGridView1.Rows.Add(3, "PIDE FECHA EMISION", "NO")
        Me.DataGridView1.Rows.Add(4, "PIDE FECHA VENCIMIENTO", "NO")
        Me.DataGridView1.Rows.Add(5, "PIDE MARCADOR IMPORTE", "NO")
        Me.DataGridView1.Rows.Add(6, "PIDE DESCUENTO", "NO")
        Me.DataGridView1.Rows.Add(7, "RENTABILIDAD MINIMA", "12")
        Me.DataGridView1.Rows.Add(8, "VALIDA RENTABILIDAD", "NO")
        Me.DataGridView1.Rows.Add(9, "CANTIDAD COPIAS", "2")
        Me.DataGridView1.Rows.Add(10, "PIDE PREFIJO FACTURA", "NO")
        Me.DataGridView1.Rows.Add(11, "PIDE NUMERO FACTURA", "NO")
        Me.DataGridView1.Rows.Add(12, "PIDE VENDEDOR", "NO")
        Me.DataGridView1.Rows.Add(13, "HABILITA IMPRESION FACTURA", "NO")
        Me.DataGridView1.Rows.Add(14, "MUEVE STOCK", "SI")
        Me.DataGridView1.Rows.Add(15, "PIDE PRECIO", "SI")
        Me.DataGridView1.Rows.Add(16, "HABILITA IMPRESION REMITO", "SI")
        Me.DataGridView1.Rows.Add(17, "LONGITUD CODIGO BARRA", "13")
        Me.DataGridView1.Rows.Add(18, "LISTA PREDETERMINADA", "0")
        Me.DataGridView1.Rows.Add(19, "BAUDE RATE", "9600")
        Me.DataGridView1.Rows.Add(20, "COM", "3")
        Me.DataGridView1.Rows.Add(21, "AUTO DETECTA MODELO", "SI")
        Me.DataGridView1.Rows.Add(22, "IMPRIME TICKET", "SI")
        Me.DataGridView1.Rows.Add(23, "IMPRIME FACTURA", "NO")
        Me.DataGridView1.Rows.Add(24, "CANTIDAD COPIAS FISCALES", "1")
        Me.DataGridView1.Rows.Add(25, "HABILITA PUERTO COM", "SI")
        Me.DataGridView1.Rows.Add(26, "HABILITA TCP/IP", "NO")
        Me.DataGridView1.Rows.Add(27, "DIRECCION IP", "127.0.0.1")
        Me.DataGridView1.Rows.Add(28, "TALONARIO PREDETERMINADO", "1")
        Me.DataGridView1.Rows.Add(29, "PIDE FORMA COBRO", "NO")
        Me.DataGridView1.Rows.Add(30, "PIDE TALONARIO", "NO")
        Me.DataGridView1.Rows.Add(31, "PIDE PREFIJO RECIBO", "NO")
        Me.DataGridView1.Rows.Add(32, "PIDE NUMERO RECIBO", "NO")
        Me.DataGridView1.Rows.Add(33, "PIDE LISTA", "NO")
        Me.DataGridView1.Rows.Add(34, "CANTIDAD AUTOMATICA", "NO")
        Me.DataGridView1.Rows.Add(35, "MUESTRA CUADRO IMPRESION", "NO")
        Me.DataGridView1.Rows.Add(36, "PUNTO VENTA", "1")
        Me.DataGridView1.Rows.Add(37, "FISCAL HASAR", "SI")
        Me.DataGridView1.Rows.Add(38, "FISCAL EPSON", "NO")
        Me.DataGridView1.Rows.Add(39, "FACTURA EN C", "NO")
        Me.DataGridView1.Rows.Add(40, "IMPRIME EN FISCAL", "SI")
        Me.DataGridView1.Rows.Add(41, "VENDEDOR", "0")
        Me.DataGridView1.Rows.Add(42, "PIDE VENDEDOR RECIBO", "SI")
        Me.DataGridView1.Rows.Add(43, "USA UTILIDAD ARTICULO", "SI")
        Me.DataGridView1.Rows.Add(44, "MUESTRA COSTO REMITO", "SI")
        Me.DataGridView1.Rows.Add(45, "PIDE OPCION COMPROBANTE", "SI")
        Me.DataGridView1.Rows.Add(46, "CLIENTE FIJO", "0")
        Me.DataGridView1.Rows.Add(47, "SI O NO EN FACTURA", "SI")
        Me.DataGridView1.Rows.Add(48, "CONDICION DE VENTA(1-CONTADO,2-CTA CTE)", "1")
        Me.DataGridView1.Rows.Add(49, "HABILITA CONSULTA MIXTA", "SI")
        Me.DataGridView1.Rows.Add(50, "PIDE Nº CARGA", "NO")
        Me.DataGridView1.Rows.Add(51, "COPIAS INPRESORA COMUN", "1")
        Me.DataGridView1.Rows.Add(52, "VENTANA IMPRIME FACTURA", "NO")
        Me.DataGridView1.Rows.Add(53, "FACTURA ELECTRONICA AFIP", "NO")
        Me.DataGridView1.Rows.Add(54, "GRABA AFIP", "NO")
        Me.DataGridView1.Rows.Add(55, "ACTUALIZA PRECIO EN FACTURA", "NO")
        Me.DataGridView1.Rows.Add(56, "HABILITA DESCUENTO GRAL", "NO")
        Me.DataGridView1.Rows.Add(57, "HABILITA ESPECIAL", "NO")

        Me.txt_verifica.Text = 1

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        Dim i As Integer

        Call verific_punto_venta()

        If veri = False Then
            MessageBox.Show("Verifique Punto Venta", "PyMsoft", MessageBoxButtons.OK)
            Exit Sub
        End If

        Call verifica_lista()

        If veri = False Then
            MessageBox.Show("Verifique Lista Predeterminada", "PyMsoft", MessageBoxButtons.OK)
            Exit Sub
        End If

        Call verifica_talonario_fiscal()

        If veri = False Then
            MessageBox.Show("Verifique Talonario Predeterminado", "PyMsoft", MessageBoxButtons.OK)
            Exit Sub
        End If

        Call verifica_datos()

        If verifica = True Then

            par.instruccion = "update parametro_01 set id_parametro= '" & Me.txt_codigo.Text & "', descripcion= '" & Me.txt_descripcion.Text & "' where id_parametro ='" & Me.txt_interno.Text & "'"
            par.abm()

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                par.instruccion = "update parametro_01 set estado= '" & Me.DataGridView1.Rows(i).Cells(2).Value & "' where id_parametro ='" & Me.txt_interno.Text & "' and nom_param = '" & Me.DataGridView1.Rows(i).Cells(1).Value & "'"
                par.abm()

            Next

            MessageBox.Show("Parametro Actualizado", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click

        Dim a As Short = MessageBox.Show("Esta seguro que desea borrar el Parametro", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

        If a = 6 Then

            par.instruccion = "DELETE parametro_01 WHERE id_parametro= '" & Me.txt_codigo.Text & "'"
            par.abm()

            par.instruccion = "update menu_usu set parametro= ' ' where parametro ='" & Me.txt_codigo.Text & "'"
            par.abm()

            Me.Dispose()

        End If

    End Sub

    Public Sub verifica_datos()

        If Me.txt_codigo.Text = "" Or Me.txt_descripcion.Text = "" Then
            MessageBox.Show("Complete los capos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            verifica = False
        Else
            verifica = True
        End If

    End Sub

    Private Sub verifica_lista()

        conex = conecta()

        comando = New SqlDataAdapter("select *from lista_01 where id_lis = '" & RTrim(Me.DataGridView1.Rows(17).Cells(2).Value) & "'", conex)
        comando.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            veri = False
        Else
            veri = True
        End If

        conex.Close()

    End Sub

    Private Sub verifica_talonario_fiscal()

        conex = conecta()
        tabla.Clear()

        comando = New SqlDataAdapter("select *from numerador where talon = '" & RTrim(Me.DataGridView1.Rows(27).Cells(2).Value) & "'", conex)
        comando.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            veri = False
        Else
            veri = True
        End If

        conex.Close()

    End Sub

    Private Sub verific_punto_venta()

        conex = conecta()
        tabla.Clear()

        comando = New SqlDataAdapter("select *from numerador where punto_venta = '" & RTrim(Me.DataGridView1.Rows(35).Cells(2).Value) & "'", conex)
        comando.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            veri = False
        Else
            veri = True
        End If

        conex.Close()

    End Sub

    Private Sub txt_parametro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_parametro.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_ok.Focus()
        End If
    End Sub

    Private Sub cmd_copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_copiar.Click

        Dim t As New DataTable
        conex = conecta()

        comando = New SqlDataAdapter("select max(id_parametro) from parametro_01", conex)
        comando.Fill(t)
        comando.Dispose()

        Me.txt_codigo.Text = t.Rows(0).Item(0) + 1

        Me.txt_codigo.Enabled = False
        Me.txt_descripcion.Text = ""
        Me.txt_descripcion.Enabled = True
        Me.txt_descripcion.Focus()
        Me.txt_descripcion.SelectAll()


        Me.cmd_aceptar.Enabled = True
        Me.cmd_aceptar.BackColor = Color.Black

        Me.cmd_copiar.Enabled = False
        Me.cmd_copiar.BackColor = Color.LightGray

        copiar = True
        t.Dispose()

    End Sub

End Class