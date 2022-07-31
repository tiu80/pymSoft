Imports System.Data
Imports System.Data.SqlClient

Public Class Form_rotulo_balanza

    Dim verificador As Integer
    Dim reporte As New pymsoft.reporte
    Dim art As New pymsoft.articulo
    Dim com1 As IO.Ports.SerialPort = Nothing
    Dim Incoming, bruto, u_med As String
    Dim conex As New SqlConnection
    Dim tb As New DataTable
    Dim comando As SqlDataAdapter
    Dim cont, i As Integer
    Dim entra As Integer = 0
    Dim code_ean13 As String
    Dim cant As Double

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.cmb_codigo.Text = "" Or Me.txt_dias_vencimiento.Text = "" Then Exit Sub

        Dim x As String
        Dim rep As Object = Nothing

        x = reporte.carga_datos("rotulos")

        If x = "rotulos" Then
            rep = New rotulos
        End If

        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt3 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt4 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt5 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt6 As CrystalDecisions.CrystalReports.Engine.TextObject

        arma_codigo_barra()
        'Dim temp1 As String = Me.lbl_cod_barra.Text + Me.cmb_cantidad.Text

        txt = rep.Section1.ReportObjects.Item("codbarra") ' codigo de barra
        txt.Text = ean13(code_ean13)

        txt1 = rep.Section1.ReportObjects.Item("nomprod") ' nombre de producto
        txt1.Text = Me.lbl_nombre_producto.Text

        txt2 = rep.Section1.ReportObjects.Item("cant") ' cantidad producto
        txt2.Text = Me.cmb_cantidad.Text

        txt3 = rep.Section1.ReportObjects.Item("fec")  ' fecha Elaboracion producto
        txt3.Text = Me.DateTimePicker1.Text

        txt4 = rep.Section1.ReportObjects.Item("fec_venc")  ' fecha Vencimiento producto
        txt4.Text = Me.DateTimePicker1.Value.Date.AddDays(Me.txt_dias_vencimiento.Text)

        txt5 = rep.Section1.ReportObjects.Item("unidad_medida")  ' fecha Vencimiento producto
        txt5.Text = u_med

        txt6 = rep.Section1.ReportObjects.Item("codpro")  ' fecha Vencimiento producto
        txt6.Text = Me.cmb_codigo.Text

        'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        If reporte.impresora <> "" Then rep.PrintOptions.PrinterName = reporte.impresora

        If Me.txt_cantidad_copias.Text = "" Then Me.txt_cantidad_copias.Text = 0

        For i = 0 To Me.txt_cantidad_copias.Text - 1
            rep.PrintToPrinter(1, False, 0, 0)
        Next

        If Me.RadioButton2.Checked = True Then
            cant = Format(Me.cmb_cantidad.Text * Me.txt_cantidad_copias.Text, "0.00")
        Else
            cant = Me.cmb_cantidad.Text
        End If

        art.instruccion = "update art_01 set cantidad = cantidad + '" & cant & "' where id_art ='" & RTrim(Me.cmb_codigo.Text) & "'"
        art.actualizar()

        If cont = 0 Then
            art.instruccion = "INSERT INTO fact_cab (num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,fec_vto,id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,lista,forma_pago,estado_fact,id_lista,talon,ing_bruto1,arqueo,pago,hora) VALUES('" & tb.Rows(0).Item(0) + 1 & "','RE','1' , 'X','" & Me.DateTimePicker1.Text & "','" & Me.DateTimePicker1.Text & "','1000','VARIOS','Consumidor Final','00000000000','xxxxx','10','mostrador','1','Contado','Activo', '1', '2', '0','B','0','" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "')"
            art.actualizar()
        End If

        art.instruccion = "INSERT INTO fact_det (fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,cod_prov,cod_rub,nom_producto,vend1,n_carga) VALUES('" & Me.DateTimePicker1.Text & "','" & tb.Rows(0).Item(0) + 1 & "' ,'RE', '1','X','" & Me.cmb_codigo.Text & "','" & Me.lbl_nombre_producto.Text & "','" & cant & "','0','0','0','0','0','0','0', '0', '1', '" & Date.Now.Month & "', '" & Date.Now.Year & "', '2','NO','" & cont & "','0','0','0','0','10','0')"
        art.actualizar()

        If cont = 0 Then
            art.instruccion = "INSERT INTO fact_tot (num_factura,letra,tipo_factura,pref,id_cliente,nombre_cli,total,iva_ins,exento,imp_interno1,iva_10,sub_total,fecha_emision1,descuento,total_cobro,talon2,efectivo,comentario) VALUES('" & tb.Rows(0).Item(0) + 1 & "','X','RE','1','1000','VARIOS','1','1','1','1','1','1','" & Me.DateTimePicker1.Text & "','0','1', '2','SI','')"
            art.actualizar()
        End If

        Me.DataGridView1.Rows.Add()
        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Value = Me.lbl_nombre_producto.Text
        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = Me.cmb_cantidad.Text
        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2).Value = Me.cmb_codigo.Text

        Call cargar_datos()

        cont = cont + 1
        entra = 1

    End Sub

    Private Sub arma_codigo_barra()

        Dim code, code1, pes, temp As String
        Dim cod As Short
        Dim entero As Decimal

        cod = Me.lbl_cod_barra.Text.ToString.Length
        cod = 6 - cod

        For i = 0 To cod
            temp = temp + "0"
        Next
        code = temp & Me.lbl_cod_barra.Text
        temp = ""
        cod = 0

        entero = Math.Truncate(CDec(Me.cmb_cantidad.Text))
        code1 = Replace(Me.cmb_cantidad.Text, ".", "")

        If entero > 0 And entero <= 9 Then
            pes = "00" & code1
            cod = pes.ToString.Length
            cod = 5 - cod
            For i = 0 To cod - 1
                temp = temp & "0"
            Next
            pes = "00" & code1 & temp
        End If
        temp = ""

        If entero >= 10 And entero <= 99 Then
            pes = "0" & code1
            cod = pes.ToString.Length
            cod = 5 - cod
            For i = 0 To cod - 1
                temp = temp & "0"
            Next
            pes = "0" & code1 & temp
        End If
        temp = ""

        If entero >= 100 And entero <= 999 Then
            pes = code1
            cod = pes.ToString.Length
            cod = 5 - cod
            For i = 0 To cod - 1
                temp = temp & "0"
            Next
            pes = code1 & temp
        End If
        temp = ""

        code_ean13 = code & pes

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Close()
    End Sub

    Private Sub Form_rep_etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_estado_form.Text = 1

        tb.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select remito from numerador where talon = 2 and punto_venta=1", conex)
        comando.Fill(tb)

    End Sub

    Function Generar_EAN128(ByVal Codigo As String) As String
        ' V 2.0.0
        ' Esta función permite generar el código de barras para mostrarlo con la fuente CODE128.TTF
        ' - Parametros : cadenas del código
        ' - Retorno: retorna una cadena que permite representar generar el código de barras con la fuente CODE128.TTF
        '            retorna una cadena vacía si no se puede representar el código de barras

        Dim i, checksum, mini, dummy As Decimal
        Dim code128 As String
        Dim tableB As Boolean
        code128 = ""

        If Len(Codigo) > 0 Then
            ' Verificar si los caracteres son válidos
            For i = 1 To Len(Codigo)
                Select Case Asc(Mid(Codigo, i, 1))
                    Case 32 To 126, 203
                    Case Else
                        Codigo = ""
                        Exit For
                End Select
            Next
        End If

        If Len(Codigo) > 0 Then
            'Calcular de la cadena de código optimizando el uso de las tablas B y C
            tableB = True

            i = 1 ' Iniciar el indice de la cadena
            Do While i <= Len(Codigo)
                If tableB Then
                    'Ver si interesa cambiar a la tabla C si para 4 dígitos de inicio o final sino 6 dígitos
                    mini = IIf(i = 1 Or i + 3 = Len(Codigo), 4, 6)
                    mini = TestNum(Codigo, i, mini)
                    If mini < 0 Then 'Cambiando a la tabla C
                        If i = 1 Then 'Iniciando con la tabla C
                            code128 = Chr(210)
                        Else 'Cambiar a la tabla C
                            code128 = code128 & Chr(204)
                        End If
                        tableB = False
                    Else
                        If i = 1 Then code128 = Chr(209) 'Iniciando con la tabla B
                    End If
                End If

                If Not tableB Then
                    'Si estabamos en la tabla C se intentan procesar 2 dígitos
                    mini = 2
                    mini = TestNum(Codigo, i, mini)
                    If mini < 0 Then 'Procesar 2 dígitos
                        dummy = Val(Mid(Codigo, i, 2))
                        dummy = IIf(dummy < 95, dummy + 32, dummy + 105)
                        code128 = code128 & Chr(dummy)
                        i = i + 2
                    Else 'Si no tiene 2 dígitos se cambia a la tabla B
                        code128 = code128 & Chr(205)
                        tableB = True
                    End If
                End If

                If tableB Then
                    'Procesar 1 dígito con la tabla B
                    code128 = code128 & Mid(Codigo, i, 1)
                    i = i + 1
                End If
            Loop

            'Calcular el checksum
            For i = 1 To Len(code128)
                dummy = Asc(Mid(code128, i, 1))
                dummy = IIf(dummy < 127, dummy - 32, dummy - 105)
                If i = 1 Then checksum = dummy
                checksum = (checksum + (i - 1) * dummy) Mod 103
            Next

            'Calculando el código ASCII de checksum
            checksum = IIf(checksum < 95, checksum + 32, checksum + 105)

            'Añadir el checksum y parar
            code128 = code128 & Chr(checksum) & Chr(211)
        End If

        Generar_EAN128 = code128

    End Function

    Function TestNum(ByVal Codigo As String, ByVal i As Integer, ByVal mini As Integer) As Decimal
        'Si los caracteres de la variable mini desde la variable i son numericos entonces se devuelve 0
        mini = mini - 1
        If i + mini <= Len(Codigo) Then
            Do While mini >= 0
                If Asc(Mid(Codigo, i + mini, 1)) < 48 Or Asc(Mid(Codigo, i + mini, 1)) > 57 Then Exit Do
                mini = mini - 1
            Loop
        End If
        TestNum = mini
    End Function

    Public Function ean13(ByVal chaine)

        Dim checksum, first, CodeBarre As String
        Dim tableA As Boolean
        Dim i As Integer
        ean13 = ""
        Dim xx As Integer = Len(chaine)
        If Len(chaine) = 12 Then
            For i = 1 To 12
                If Asc(Mid(chaine, i, 1)) < 48 Or Asc(Mid(chaine, i, 1)) > 57 Then
                    i = 0
                    Exit For
                End If
            Next
            If i = 13 Then
                For i = 12 To 1 Step -2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                checksum = checksum * 3
                For i = 11 To 1 Step -2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                verificador = (10 - checksum Mod 10) Mod 10
                chaine = chaine & verificador
                'codigo_barra = chaine
                CodeBarre = Microsoft.VisualBasic.Left(chaine, 1) & Chr(65 + Val(Mid(chaine, 2, 1)))
                first = Val(Microsoft.VisualBasic.Left(chaine, 1))
                For i = 3 To 7
                    tableA = False
                    Select Case i
                        Case 3
                            Select Case first
                                Case 0 To 3
                                    tableA = True
                            End Select
                        Case 4
                            Select Case first
                                Case 0, 4, 7, 8
                                    tableA = True
                            End Select
                        Case 5
                            Select Case first
                                Case 0, 1, 4, 5, 9
                                    tableA = True
                            End Select
                        Case 6
                            Select Case first
                                Case 0, 2, 5, 6, 7
                                    tableA = True
                            End Select
                        Case 7
                            Select Case first
                                Case 0, 3, 6, 8, 9
                                    tableA = True
                            End Select
                    End Select
                    If tableA Then
                        CodeBarre = CodeBarre & Chr(65 + Val(Mid(chaine, i, 1)))
                    Else
                        CodeBarre = CodeBarre & Chr(75 + Val(Mid(chaine, i, 1)))
                    End If
                Next
                CodeBarre = CodeBarre & "*"
                For i = 8 To 13
                    CodeBarre = CodeBarre & Chr(97 + Val(Mid(chaine, i, 1)))
                Next
                CodeBarre = CodeBarre & "+"
                ean13 = CodeBarre
            End If
        End If
    End Function

    Private Sub cmb_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_articulos.txt_lista.Text = 1
            busc_articulos.Show()

        End If

        If e.KeyCode = Keys.Return Then

            cargar_datos()

        End If

    End Sub

    Private Sub cargar_datos()

        art.instruccion = "select id_art1,id_lista1,nombre,id_rubro,rubro,codigo_barra,cantidad,cantidad_bulto,id_proveedor,proveedor,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,costo,id_iva,iva,iva_insc,cod_imp,impuestos,exento,utilidad,precio_civa,precio_siva,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda,unidad_secundaria,peso_promedio from art_01 inner join art_precio on art_precio.id_art1 = '" & RTrim(Me.cmb_codigo.Text) & "' and art_01.nombre = art_precio.nom"
        art.mostrar_datos()

        If art.verifica_campos = 0 Then

            Me.cmb_codigo.Text = art.codigo
            Me.lbl_nombre_producto.Text = art.descripcion
            Me.lbl_cod_barra.Text = art.codigo_barra
            Me.lbl_stock_prod.Text = art.cantidad

            Me.cmb_cantidad.Focus()

        Else

            Me.cmb_codigo.Text = ""
            Me.lbl_nombre_producto.Text = ""
            Me.lbl_cod_barra.Text = ""
            Me.cmb_codigo.Focus()

        End If

    End Sub

    Private Sub cmb_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_cantidad.KeyDown

        If e.KeyCode = Keys.Return Then

            Me.cmd_aceptar.Enabled = True
            Me.cmd_aceptar.Focus()

        End If

    End Sub

    Private Sub cmd_captura_peso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' Receive strings from a serial port
        Try

            com1 = My.Computer.Ports.OpenSerialPort("COM1")
            com1.ReadTimeout = 1000
            Do
                Incoming = com1.ReadLine()
                bruto = Incoming
                Me.cmb_cantidad.Text = bruto

                If Incoming Is Nothing Then
                    Exit Do
                Else
                    'returnStr &= Incoming & vbCrLf
                    Exit Do
                End If
            Loop
            'Call calcula_codigo_barra_caja()
        Catch ex As TimeoutException
            'returnStr = "Error: Serial Port read timed out."
            MessageBox.Show("Verifique puerto comunicaciones", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If com1 IsNot Nothing Then com1.Close()
        End Try

    End Sub

    Private Sub Form_rotulo_balanza_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If entra = 1 Then

            art.instruccion = "update numerador set remito = remito + 1 where talon = '2' and punto_venta = 1"
            art.actualizar()

        End If

    End Sub

    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_dias_vencimiento.Focus()
            Me.txt_dias_vencimiento.SelectAll()
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Delete Then

            Dim x As Short = MessageBox.Show("Esta seguro que desea borrar esa fila ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If x = 6 Then

                art.instruccion = "Delete fact_det where fila = '" & Me.DataGridView1.CurrentCell.RowIndex & "' and num_fact = '" & tb.Rows(0).Item(0) + 1 & "' and tipo_fact2 = 'RE' and prefijo_fact2 = 1 and letra_fact1 = 'X'"
                art.actualizar()

                art.instruccion = "update art_01 set cantidad = cantidad - '" & Me.DataGridView1.SelectedCells.Item(1).Value & "' where id_art ='" & RTrim(Me.DataGridView1.SelectedCells.Item(2).Value) & "'"
                art.actualizar()

                Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex))

            End If

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            u_med = "Kg"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            u_med = "Unid"
        End If
    End Sub

    Private Sub txt_cantidad_copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_copias.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_dias_vencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dias_vencimiento.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_codigo.Focus()
            Me.cmb_codigo.SelectAll()
        End If
    End Sub

    Private Sub txt_dias_vencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dias_vencimiento.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class