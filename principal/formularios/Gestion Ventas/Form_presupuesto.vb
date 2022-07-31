Imports System.Data
Imports System.Data.SqlClient

Public Class Form_presupuesto

    Dim conex As New SqlConnection
    Dim tb As New DataTable, tb1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim trans As SqlTransaction

    Dim art As New pymsoft.articulo
    Dim lee_enter As Boolean = False

    Dim rep As Object = Nothing
    Dim reporte As New pymsoft.reporte

    Dim fact As New pymsoft.factura
    Dim num As New pymsoft.numerodecimales

    Dim x As Integer, i As Integer, pos As Integer
    Dim tot As Double, iva1 As Double
    Dim xx As String
    Public activo As Boolean = False

    Private Sub Form_presupuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form_recibos.txt_estado_form.Text = 1 Or form_factura.txt_estado_form.Text = 1 Then
            MessageBox.Show("Hay un comprobante abierto...Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        fact.carga_parametro()
        Me.txt_estado_form.Text = 1

        conex = conecta()
        tb.Clear()

        comando = New SqlDataAdapter("select top 1 num from presupuesto order by num DESC", conex)
        comando.Fill(tb)

        If tb.Rows.Count = Nothing Then

            Me.lbl_numero.Text = 1

        Else

            Me.lbl_numero.Text = tb.Rows(0).Item(0) + 1

        End If

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        Try

            If e.KeyCode = Keys.F1 Then

                activo = False
                busc_cliente.Show()

            End If

            If e.KeyCode = Keys.Return Then

                activo = False

                conex = conecta()
                tb1.Clear()

                comando = New SqlDataAdapter("select id_cli,nombre,direccion,localidad,telefono from cli_01 where id_cli = '" & RTrim(Me.txt_codigo.Text) & "' and estado = 'ACTIVO'", conex)
                comando.Fill(tb1)
                comando.Dispose()

                If tb1.Rows.Count <> Nothing Then

                    Me.txt_codigo.Text = tb1.Rows(0).Item(0)
                    Me.txt_cliente.Text = tb1.Rows(0).Item(1)
                    Me.txt_direccion.Text = tb1.Rows(0).Item(2) & " - " & tb1.Rows(0).Item(3)
                    Me.txt_telef.Text = tb1.Rows(0).Item(4)
                    Me.txt_validez.Focus()
                    Me.txt_codigo.Enabled = False

                    activo = True

                End If

            End If

        Catch ex As Exception

            Me.txt_codigo.Focus()

        End Try

    End Sub

    Private Sub txt_validez_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_validez.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.txt_validez.Text = "" Then Exit Sub

            Me.txt_validez.Enabled = False
            Me.txt_codigo_producto.Enabled = True
            Me.txt_codigo_producto.Focus()

        End If

    End Sub

    Private Sub txt_validez_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_validez.KeyPress
        num.positivos_punto(e, Me.txt_validez)
    End Sub

    Private Sub txt_codigo_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyDown

        If e.KeyCode = Keys.F1 Then

            If fact.Habilita_facturacion_especial = "SI" Then
                If Me.Check_talonario.Checked = False Then
                    busc_articulos.txt_lista.Text = 9999
                Else
                    busc_articulos.txt_lista.Text = fact.lista_predeterminada
                End If
            Else
                busc_articulos.txt_lista.Text = fact.lista_predeterminada
            End If

            busc_articulos.Show()

        End If

        If e.KeyCode = Keys.Escape Then

            iva1 = 0
            tot = 0

            For i = 0 To Me.DataGridView1.Rows.Count - 1

                iva1 = Format(iva1 + Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")
                tot = Format(tot + Val(Me.DataGridView1.Rows(i).Cells(5).Value), "0.00")

            Next

            Me.txt_sub_total.Text = tot - iva1
            Me.txt_total.Text = tot
            Me.txt_iva_insc.Text = iva1

            Me.DataGridView1.Focus()

        End If

        If e.KeyCode = Keys.Return Then

            If Me.DataGridView1.Rows.Count > 1 Then
                pos = Me.DataGridView1.CurrentCell.RowIndex
            End If

            lee_enter = False

            If Me.Check_talonario.Checked = False Then
                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.txt_codigo_producto.Text & "' and art_precio.id_lista1 = '9999' and art_01.nombre = art_precio.nom and art_01.estado = 'Activo'"
            Else
                art.instruccion = "select id_art1,nombre,precio_siva,cantidad,cantidad_bulto,mueve_stok,precio_civa,iva_insc,impuestos,iva,exento,costo,codigo_barra,id_iva,utilidad,id_proveedor,id_rubro,unidad_secundaria,peso_promedio,bonif_vta from art_01 inner join art_precio on art_precio.id_art1 = '" & Me.txt_codigo_producto.Text & "' and art_precio.id_lista1 = '" & Trim(fact.lista_predeterminada) & "' and art_01.nombre = art_precio.nom and art_01.estado = 'Activo'"
            End If

            carga_codigo()

        End If

    End Sub

    Private Sub carga_codigo()

        If Me.txt_codigo_producto.Text = "" Then Exit Sub

        Me.txt_cantidad.ReadOnly = False
        Me.txt_desc_rcgo.ReadOnly = False

        Me.txt_codigo_producto.SelectAll()

        art.codigo_1 = "id_art1"
        art.codigo_2 = "nombre"
        art.codigo_3 = "precio_siva"
        art.codigo_4 = "cantidad"
        art.codigo_5 = "cantidad_bulto"
        art.codigo_6 = "mueve_stok"
        art.codigo_7 = "precio_civa"
        art.codigo_8 = "iva_insc"
        art.codigo_9 = "impuestos"
        art.codigo_10 = "iva"
        art.codigo_11 = "exento"
        art.codigo_12 = "costo"
        art.codigo_13 = "codigo_barra"
        art.codigo_14 = "id_iva"
        art.codigo_15 = "utilidad"
        art.codigo_16 = "id_proveedor"
        art.codigo_17 = "id_rubro"
        art.codigo_18 = "unidad_secundaria"
        art.codigo_19 = "peso_promedio"
        art.codigo_20 = "bonif_vta"

        art.cargar()

        If art.valida = True Then

            Me.txt_codigo_producto.Text = art.codigo
            Me.txt_nombre_producto.Text = art.nombre
            Me.txt_nombre_producto.BackColor = Color.LightGreen
            Me.txt_precio.Text = art.precio_civa
            Me.txt_precio_siva.Text = art.precio_siva
            Me.txt_iva.Text = art.iva_insc

            Me.txt_cantidad.Focus()
            Me.txt_cantidad.SelectAll()

        End If

    End Sub

    Private Sub txt_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad.KeyDown

        If e.KeyCode = Keys.Return Then

            Try

                If Me.txt_cantidad.Text.ToString = Nothing Or Me.txt_cantidad.Text <= 0 Then Exit Sub

                Me.txt_desc_rcgo.ReadOnly = False
                Me.txt_desc_rcgo.Focus()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub txt_desc_rcgo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_rcgo.KeyDown

        If e.KeyCode = Keys.Return Then

            If Me.txt_desc_rcgo.Text.ToString <> "" Then

                Me.DataGridView1.Rows.Add()

                x = Me.DataGridView1.Rows.Count - 1

                Me.DataGridView1.FirstDisplayedScrollingRowIndex = x

                Me.DataGridView1.Rows(x).Cells(0).Value = Me.txt_codigo_producto.Text
                Me.DataGridView1.Rows(x).Cells(1).Value = Me.txt_nombre_producto.Text
                Me.DataGridView1.Rows(x).Cells(2).Value = Me.txt_cantidad.Text
                Me.DataGridView1.Rows(x).Cells(3).Value = Format(Me.txt_precio.Text, "0.00")
                Me.DataGridView1.Rows(x).Cells(4).Value = Me.txt_desc_rcgo.Text
                Me.DataGridView1.Rows(x).Cells(5).Value = Format((Me.txt_cantidad.Text * Me.txt_precio.Text) - (Me.txt_cantidad.Text * Me.txt_precio.Text) * -(Me.txt_desc_rcgo.Text / 100), "0.00")
                Me.DataGridView1.Rows(x).Cells(6).Value = Format(Me.txt_cantidad.Text * Me.txt_iva.Text - (Me.txt_cantidad.Text * Me.txt_iva.Text) * Me.txt_desc_rcgo.Text / 100, "0.00")
                Me.DataGridView1.Rows(x).Cells(7).Value = Me.txt_precio_siva.Text
                Me.DataGridView1.Rows(x).Cells(8).Value = Format(Me.txt_precio_siva.Text * Me.txt_cantidad.Text, "0.00")

                Me.txt_cantidad.Text = ""
                Me.txt_desc_rcgo.Text = ""
                Me.txt_codigo_producto.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_nombre_producto.BackColor = Color.White
                Me.txt_codigo_producto.Focus()

            Else

                Me.DataGridView1.Rows.Add()

                x = Me.DataGridView1.Rows.Count - 1

                Me.DataGridView1.FirstDisplayedScrollingRowIndex = x

                Me.DataGridView1.Rows(x).Cells(0).Value = Me.txt_codigo_producto.Text
                Me.DataGridView1.Rows(x).Cells(1).Value = Me.txt_nombre_producto.Text
                Me.DataGridView1.Rows(x).Cells(2).Value = Me.txt_cantidad.Text
                Me.DataGridView1.Rows(x).Cells(3).Value = Me.txt_precio.Text
                Me.DataGridView1.Rows(x).Cells(5).Value = Format(Me.txt_cantidad.Text * Me.txt_precio.Text, "0.00")
                Me.DataGridView1.Rows(x).Cells(6).Value = Format(Me.txt_cantidad.Text * Me.txt_iva.Text, "0.00")
                Me.DataGridView1.Rows(x).Cells(7).Value = Me.txt_precio_siva.Text
                Me.DataGridView1.Rows(x).Cells(8).Value = Format(Me.txt_precio_siva.Text * Me.txt_cantidad.Text, "0.00")

                Me.txt_cantidad.Text = ""
                Me.txt_desc_rcgo.Text = ""
                Me.txt_codigo_producto.Text = ""
                Me.txt_nombre_producto.Text = ""
                Me.txt_nombre_producto.BackColor = Color.White
                Me.txt_codigo_producto.Focus()

            End If

        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Insert Then
            Me.txt_codigo_producto.Focus()
        End If

        If e.KeyCode = Keys.F5 Then

            Dim s As Integer = MessageBox.Show("Confirma presupuesto ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If s = 6 Then

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                For i = 0 To Me.DataGridView1.Rows.Count - 1

                    coman = New SqlCommand("insert into presupuesto(id_cli,validez,codart,descrip,precio,descuento,total1,fecha_emision1,num,cant,iva,su_tot,tot,fila,preciosiva,totalsiva) values ('" & Me.txt_codigo.Text & "','" & Me.txt_validez.Text & "','" & Me.DataGridView1.Rows(i).Cells(0).Value & "','" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(3).Value & "','" & Me.DataGridView1.Rows(i).Cells(4).Value & "','" & Me.DataGridView1.Rows(i).Cells(5).Value & "','" & Me.DateTimePicker1.Text & "','" & Me.lbl_numero.Text & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','" & Me.txt_iva_insc.Text & "','" & Me.txt_sub_total.Text & "','" & Me.txt_total.Text & "','" & i & "','" & Me.DataGridView1.Rows(i).Cells(7).Value & "','" & Me.DataGridView1.Rows(i).Cells(8).Value & "')", conex)
                    coman.ExecuteNonQuery()

                Next

                conex.Close()

                xx = reporte.carga_datos("presupuesto")

                If xx = "presupuesto" Then
                    rep = New presupuesto
                End If

                xx = reporte.carga_datos("presupuestoBV")

                If xx = "presupuestoBV" Then
                    rep = New presupuestoBV
                End If

                rep.RecordSelectionFormula = "{presupuesto.num}= " & RTrim(Me.lbl_numero.Text) & ""

                For i = 0 To 1
                    rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                    rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
                    rep.PrintToPrinter(1, False, 0, 0)
                Next

                Me.Close()

            End If

        End If

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        num.positivos_punto(e, Me.txt_cantidad)
    End Sub

    Private Sub txt_desc_rcgo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desc_rcgo.KeyPress
        num.negativos_punto(e, Me.txt_desc_rcgo)
    End Sub

    Private Sub Check_talonario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_talonario.CheckedChanged
        If Me.Check_talonario.Checked = True Then
            Me.Check_talonario.BackColor = Color.Transparent
        Else
            Me.Check_talonario.BackColor = Color.Black
        End If
    End Sub
End Class