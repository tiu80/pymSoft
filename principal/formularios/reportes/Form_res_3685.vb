Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class Form_res_3685

    Dim conex As SqlConnection
    Dim comando As SqlDataAdapter, comando1 As SqlDataAdapter
    Dim tb As New DataTable, tb_iva As New DataTable
    Dim sw As IO.StreamWriter, sw1 As IO.StreamWriter

    Dim porcentaje_impuesto, descuento As Double
    Dim signo, cero, fecha, tipo_comp, pto_vta, num_comp, despacho, cond_iva, cuit, razon_social, importe_total, importe_neto, importe_no_neto, importe_exento, percepcion_iva, percepcion_nacional, percepcion_ing, percepcion_muni, impuesto_interno, importe_iva_compra, cod_alicuota, codigo_operacion, importe_no_categorizado As String
    Dim largo, cant_alic, j, x, i, codigo_iva As Integer
    Dim temp_neto, temp_iva, temp_iva21, temp_iva10, temp_neto21, temp_neto10, cuiii, tipo_doc, iva21, iva10 As String

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        If Me.chk_iva_digital.Checked = False Then
            compras_ventas()
        Else
            iva_digital()
        End If

    End Sub

    Private Sub iva_digital()

        Try

            tb.Clear()

            conex = New SqlConnection
            conex = conecta()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            comando = New SqlDataAdapter("select replace(convert(char(11),F.fecha_emision1,111),'/','') as fecha,F.tipo_factura as tipo_comp,F.pref as punto_vta,F.num_factura as comprobante,'                ' as despacho,(select top 1 case when tipo_iva = 'Consumidor Final' then 96 else 80 end from cli_01 as C where C.id_cli = F.id_cliente) as codigo_documento,(select top 1 replace(cuit,'-','') from cli_01 as C where C.id_cli = F.id_cliente),(select top 1 nombre from cli_01 as C where C.id_cli = F.id_cliente),F.total as Total_operacion,F.sub_total as Total_sin_neto,F.sub_total,'000000000000000' as Total_imp_Nacional,'000000000000000' as Imp_Municipales,'000000000000000' as Imp_internos,'PES' as Tipo_moneda,'0001000000' as Valor_moneda,' ' as codigo_operacion,'000000000000000' as otros_tributos,'00000000000','                              ','000000000000000',substring(F.letra,0, 2) as letra_comprobante,F.iva_ins,F.iva_10,F.descuento from fact_tot as F where year(F.fecha_emision1) ='" & Me.cmd_año.Text & "' and month(F.fecha_emision1) = '" & Me.cmd_mes.Text & "' and (F.tipo_factura ='FC' or F.tipo_factura ='NC' or F.tipo_factura ='ND') and F.talon2 =1 order by f.fecha_emision1 ASC", conex)
            comando.Fill(tb)
            comando.Dispose()

            sw = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_comprobante_d.txt", True, Encoding.ASCII)
            sw1 = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_Alicuotas_d.txt", True, Encoding.ASCII)

            For i = 0 To tb.Rows.Count - 1

                codigo_operacion = " "
                descuento = tb.Rows(i).Item(24)

                tb_iva.Clear()
                'comando1 = New SqlDataAdapter("select iva1,cantidad1*sum(precio_unidad),replace(sum(cast(iva_inscripto as float)),',','') from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1 order by iva1 desc", conex)
                ' si descuento general es igual a 0 hago esto
                If Val(descuento) = 0 Then
                    comando1 = New SqlDataAdapter("select iva1,case when ISNULL(val_uni_sec,0) = 0 then cantidad1*sum(precio_unidad) else Round(val_uni_sec*sum(precio_unidad),3,0) end,replace(sum(cast(iva_inscripto as float)),',','')  from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1,val_uni_sec order by iva1 desc", conex)
                Else
                    comando1 = New SqlDataAdapter("select iva1,case when ISNULL(val_uni_sec,0) = 0 then cantidad1*sum(precio_unidad) - (cantidad1*sum(precio_unidad) * '" & descuento & "')/100 else Round(val_uni_sec*sum(precio_unidad),3,0) - (Round(val_uni_sec*sum(precio_unidad),3,0) * '" & descuento & "')/100 end,replace(sum(cast(iva_inscripto as float)) - (sum(cast(iva_inscripto as float))* '" & descuento & "') /100,',','') from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1,val_uni_sec order by iva1 desc", conex)
                End If

                comando1.Fill(tb_iva)
                comando1.Dispose()

                For x = 0 To tb_iva.Rows.Count - 1

                    selecciona_valor_impuesto(tb_iva.Rows(x).Item(0))

                    If codigo_iva = 1 Then '21%
                        temp_iva21 = Format(Val(temp_iva21) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                        temp_neto21 = Format(Val(temp_neto21) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                    End If

                    If codigo_iva = 2 Then ' 10.5%
                        temp_iva10 = Format(Val(temp_iva10) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                        temp_neto10 = Format(Val(temp_neto10) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                    End If

                Next

                fecha = tb.Rows(i).Item(0)

                ' OBTENGO EL TIPO DE COMPROBANTE
                If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "001" ' FACTURA A
                If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "003" ' CREDITO A

                If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "006" ' FACTURA A
                If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "008" ' CREDITO A

                If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "002" ' DEBITO A
                If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "007" ' DEBITO B

                ' punto de venta
                largo = tb.Rows(i).Item(2).ToString.Length
                For j = largo To 5 - 1
                    cero = cero & "0"
                Next
                pto_vta = cero & tb.Rows(i).Item(2)
                cero = ""

                ' numero comprobante
                largo = tb.Rows(i).Item(3).ToString.Length
                For j = largo To 20 - 1
                    cero = cero & "0"
                Next
                num_comp = cero & tb.Rows(i).Item(3)
                cero = ""

                ' SI EL CLIENTE SE LLAMA CONSUMIDOR FINAL Y ES DE TIPO CONSUMIDOR FINAL Y ES MENOR A 172000 PESOS HAGO ESTO
                If Trim(tb.Rows(i).Item(7)) = "CONSUMIDOR FINAL" And tb.Rows(i).Item(5) = 96 And Val(tb.Rows(i).Item(8)) < 172000 Then
                    tipo_doc = 99
                    cuiii = 0
                Else
                    tipo_doc = tb.Rows(i).Item(5)
                    cuiii = Trim(tb.Rows(i).Item(6))
                End If

                'cuit
                largo = Trim(cuiii.Length)
                For j = largo To 20 - 1
                    cero = cero & "0"
                Next
                cuit = cero & cuiii
                cero = ""
                cuiii = ""

                ' razon social -- completo con espacios
                largo = tb.Rows(i).Item(7).ToString.Length
                If largo > 30 Then
                    razon_social = tb.Rows(i).Item(7).ToString.Substring(0, 30)
                Else
                    razon_social = tb.Rows(i).Item(7).ToString
                    For j = largo To 30 - 1
                        razon_social = razon_social & " "
                    Next
                End If

                ' Importe total comprobante
                importe_total = Replace(Format(tb.Rows(i).Item(8), "0.00"), ".", "")
                importe_total = Replace(importe_total, "-", "")
                largo = importe_total.ToString.Length
                For j = largo To 15 - 1
                    cero = cero & "0"
                Next
                importe_total = cero & importe_total
                cero = ""

                ' importe no neto
                importe_no_neto = Replace(tb.Rows(i).Item(9), ".", "")
                importe_no_neto = Replace(importe_no_neto, "-", "")
                largo = importe_no_neto.ToString.Length
                If importe_no_neto < 0 Then
                    signo = "-"
                    importe_no_neto = Replace(importe_no_neto, "-", "")
                Else
                    signo = ""
                End If
                For j = largo To 15 - 1
                    cero = cero & "0"
                Next
                importe_no_neto = "000000000000000" 'signo & cero & importe_no_neto
                cero = ""

                importe_exento = "000000000000000"
                'cero = ""

                'percepcion nacional
                percepcion_nacional = tb.Rows(i).Item(11)

                'percepcion Municipal
                percepcion_muni = tb.Rows(i).Item(12)

                'Impuesto Interno
                impuesto_interno = tb.Rows(i).Item(13)

                cant_alic = 0
                percepcion_iva = "000000000000000"
                percepcion_ing = "000000000000000"
                importe_iva_compra = "000000000000000"
                importe_no_categorizado = "000000000000000"

                ' Cantidad Alicuotas
                ' pueden ser cero o mas  
                ' aca significa que no tiene alicuotas de iva
                If RTrim(tb.Rows(i).Item(22)) = 0 And RTrim(tb.Rows(i).Item(23)) = 0 Then

                    codigo_operacion = "N"
                    importe_exento = importe_total

                    cant_alic = cant_alic + 1
                    cod_alicuota = "0003"

                    ' Importe Alicuota Iva
                    importe_iva_compra = "000000000000000"
                    cero = ""

                    ' importe neto
                    importe_neto = "000000000000000"
                    cero = ""

                    'sw1.Write(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra & vbLf & vbCr)
                    sw1.WriteLine(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra)

                End If

                ' aca si tiene alicuotas de iva
                If RTrim(tb.Rows(i).Item(22)) > 0 Then

                    cant_alic = cant_alic + 1
                    cod_alicuota = "0005"

                    ' Importe Alicuota Iva
                    importe_iva_compra = Replace(temp_iva21, ".", "")
                    importe_iva_compra = Replace(importe_iva_compra, "-", "")
                    largo = importe_iva_compra.ToString.Length
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_iva_compra = cero & importe_iva_compra
                    cero = ""

                    ' importe neto
                    importe_neto = Replace(temp_neto21, ".", "")
                    importe_neto = Replace(importe_neto, "-", "")
                    largo = importe_neto.ToString.Length
                    If importe_neto < 0 Then
                        signo = "-"
                        importe_neto = Replace(importe_neto, "-", "")
                    Else
                        signo = ""
                    End If
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_neto = signo & cero & importe_neto
                    cero = ""

                    sw1.WriteLine(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra)

                End If

                If RTrim(tb.Rows(i).Item(23)) > 0 Then

                    cant_alic = cant_alic + 1
                    cod_alicuota = "0004"

                    ' Importe Alicuota Iva
                    importe_iva_compra = Replace(temp_iva10, ".", "")
                    importe_iva_compra = Replace(importe_iva_compra, "-", "")
                    largo = importe_iva_compra.ToString.Length
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_iva_compra = cero & importe_iva_compra
                    cero = ""

                    ' importe neto
                    importe_neto = Replace(temp_neto10, ".", "")
                    importe_neto = Replace(importe_neto, "-", "")
                    largo = importe_neto.ToString.Length
                    If importe_neto < 0 Then
                        signo = "-"
                        importe_neto = Replace(importe_neto, "-", "")
                    Else
                        signo = ""
                    End If
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_neto = signo & cero & importe_neto
                    cero = ""

                    sw1.WriteLine(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra)

                End If

                If cant_alic > 0 Then
                    sw.WriteLine(fecha & tipo_comp & pto_vta & num_comp & num_comp & tipo_doc & cuit & razon_social & importe_total & importe_no_neto & importe_no_categorizado & importe_exento & percepcion_nacional & percepcion_ing & percepcion_muni & impuesto_interno & "PES" & "0001000000" & cant_alic & codigo_operacion & "000000000000000" & fecha)
                End If

                barra_carga.Refresh()

                temp_iva = 0
                temp_neto = 0
                temp_iva21 = 0
                temp_iva10 = 0
                temp_neto21 = 0
                temp_neto10 = 0

            Next

            sw.Close()
            sw1.Close()

            MessageBox.Show("Finalizado correctamente!!!", "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception

            MessageBox.Show(ex.Message & " " & tb.Rows(i).Item(1) & " " & tb.Rows(i).Item(2) & " " & tb.Rows(i).Item(3), "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            barra_carga.Timer1.Enabled = True

        End Try

    End Sub

    Private Sub compras_ventas()

        Try

            tb.Clear()

            conex = New SqlConnection
            conex = conecta()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' genero el archivo --REGINFO_CV_COMPRAS_CBTE y REGINFO_CV_COMPRAS_ALIVUOTAS

            If Me.opt_compra.Checked = True Then

                comando = New SqlDataAdapter("select replace(convert(char(11),F.fechasql,111),'/','') as fecha,(select DISTINCT clasecbte from tabladecomprobantes as tb where tb.tipo = F.tipoid) as tipo_comp,'0' + substring(comprobante,2, 4) as punto_vta,'000000000000' + substring(F.comprobante,6, 8) as comprobante,'                ' as despacho,'80' as codigo_documento,(select right('000000000' + CAST(P.identificacion as char),50) from proveedores as P where P.cuenta = F.cuentaproveedor),Rtrim(F.razonsocial),F.totalcbte as Total_operacion,F.totalnogravado as Total_sin_neto,F.totalnogravado as total_exento,'000000000000000' as Total_imp_Nacional,'000000000000000' as Imp_Municipales,'000000000000000' as Imp_internos,'PES' as Tipo_moneda,'0001000000' as Valor_moneda,' ' as codigo_operacion,'000000000000000' as otros_tributos,'00000000000','                              ','000000000000000',substring(comprobante,0, 2) as letra_comprobante,F.tipoid,F.numeroid from facturaspro as F where year(F.fechaivasql) ='" & Me.cmd_año.Text & "' and month(F.fechaivasql) = '" & Me.cmd_mes.Text & "' order by f.fechasql ASC", conex)
                comando.Fill(tb)
                Dim x As Integer = tb.Rows.Count

                sw = New IO.StreamWriter(Me.txt_path.Text & "\" & "Compras_comprobante.txt", True, Encoding.ASCII)
                sw1 = New IO.StreamWriter(Me.txt_path.Text & "\" & "Compras_Alicuotas.txt", True, Encoding.ASCII)


                For i = 0 To tb.Rows.Count - 1

                    If RTrim(tb.Rows(i).Item(1)) = 11 Or RTrim(tb.Rows(i).Item(1)) = 12 Or RTrim(tb.Rows(i).Item(1)) = 13 Then

                        ' verifi que por lo menos exista una licuota para cargar el registro
                        tb_iva.Clear()
                        comando1 = New SqlDataAdapter("select I.importeiva,I.alicuota,I.importegravado from ivacompras as I where I.tipoid = '" & tb.Rows(i).Item(22) & "'  and I.numeroid = '" & tb.Rows(i).Item(23) & "'", conex)
                        comando1.Fill(tb_iva)

                        If tb_iva.Rows.Count > 0 Then

                            'If tb.Rows(i).Item(3) = "00000000000000001131" Then
                            'Dim nn As Integer = i
                            'Dim tipoid As Integer = tb.Rows(i).Item(22)
                            'Dim numeroid As Integer = tb.Rows(i).Item(23)
                            'End If

                            fecha = tb.Rows(i).Item(0)

                            ' OBTENGO EL TIPO DE COMPROBANTE
                            If RTrim(tb.Rows(i).Item(1)) = 11 And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "001" ' FACTURA A
                            If RTrim(tb.Rows(i).Item(1)) = 12 And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "002" ' DEBITO A
                            If RTrim(tb.Rows(i).Item(1)) = 13 And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "003" ' CREDITO A

                            If RTrim(tb.Rows(i).Item(1)) = 11 And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "006" ' FACTURA A
                            If RTrim(tb.Rows(i).Item(1)) = 12 And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "007" ' DEBITO A
                            If RTrim(tb.Rows(i).Item(1)) = 13 And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "008" ' CREDITO A

                            pto_vta = tb.Rows(i).Item(2)
                            num_comp = tb.Rows(i).Item(3)
                            despacho = tb.Rows(i).Item(4)
                            cuit = tb.Rows(i).Item(6).ToString.Substring(0, 20)

                            ' razon social -- completo con espacios
                            largo = tb.Rows(i).Item(7).ToString.Length
                            If largo > 30 Then
                                razon_social = tb.Rows(i).Item(7).ToString.Substring(0, 30)
                            Else
                                razon_social = tb.Rows(i).Item(7).ToString
                                For j = largo To 30 - 1
                                    razon_social = razon_social & " "
                                Next
                            End If

                            ' Importe total comprobante
                            importe_total = Replace(tb.Rows(i).Item(8), ".", "")
                            importe_total = Replace(importe_total, "-", "")
                            largo = importe_total.ToString.Length
                            For j = largo To 15 - 1
                                cero = cero & "0"
                            Next
                            importe_total = cero & importe_total
                            cero = ""

                            ' importe no neto
                            importe_no_neto = Replace(tb.Rows(i).Item(9), ".", "")
                            importe_no_neto = Replace(importe_no_neto, "-", "")
                            largo = importe_no_neto.ToString.Length
                            If importe_no_neto < 0 Then
                                signo = "-"
                                importe_no_neto = Replace(importe_no_neto, "-", "")
                            Else
                                signo = ""
                            End If
                            For j = largo To 15 - 1
                                cero = cero & "0"
                            Next
                            importe_no_neto = signo & cero & importe_no_neto
                            cero = ""

                            ' importe no Exento
                            'importe_exento = Replace(tb.Rows(i).Item(10), ".", "")
                            'largo = importe_exento.ToString.Length
                            'If importe_exento < 0 Then
                            'signo = "-"
                            'importe_exento = Replace(importe_exento, "-", "")
                            'Else
                            'signo = ""
                            'End If
                            'For j = largo To 15 - 1
                            'cero = cero & "0"
                            'Next
                            'importe_exento = signo & cero & importe_exento
                            importe_exento = "000000000000000"
                            'cero = ""

                            'percepcion nacional
                            percepcion_nacional = tb.Rows(i).Item(11)

                            'percepcion Municipal
                            percepcion_muni = tb.Rows(i).Item(12)

                            'Impuesto Interno
                            impuesto_interno = tb.Rows(i).Item(13)

                            cant_alic = 0
                            percepcion_iva = "000000000000000"
                            percepcion_ing = "000000000000000"
                            importe_iva_compra = "000000000000000"

                            For x = 0 To tb_iva.Rows.Count - 1

                                ' Precepcion iva
                                If RTrim(tb_iva.Rows(x).Item(1)) = 70 Then

                                    percepcion_iva = Replace(tb_iva.Rows(x).Item(0), ".", "")
                                    percepcion_iva = Replace(percepcion_iva, "-", "")
                                    largo = percepcion_iva.ToString.Length
                                    For j = largo To 15 - 1
                                        cero = cero & "0"
                                    Next
                                    percepcion_iva = cero & percepcion_iva
                                    cero = ""

                                End If

                                ' Precepcion Ingresos Brutos
                                If RTrim(tb_iva.Rows(x).Item(1)) = 50 Then

                                    percepcion_ing = Replace(tb_iva.Rows(x).Item(0), ".", "")
                                    percepcion_ing = Replace(percepcion_ing, "-", "")
                                    largo = percepcion_ing.ToString.Length
                                    For j = largo To 15 - 1
                                        cero = cero & "0"
                                    Next
                                    percepcion_ing = cero & percepcion_ing
                                    cero = ""

                                End If

                                ' Cantidad Alicuotas
                                If RTrim(tb_iva.Rows(x).Item(1)) = 10 Or RTrim(tb_iva.Rows(x).Item(1)) = 13 Or RTrim(tb_iva.Rows(x).Item(1)) = 15 Then
                                    cant_alic = cant_alic + 1
                                End If

                                If tb_iva.Rows(x).Item(1) = 10 Then ' iva 21
                                    cod_alicuota = "0005"
                                End If

                                If tb_iva.Rows(x).Item(1) = 13 Then ' iva 10.5
                                    cod_alicuota = "0004"
                                End If

                                If tb_iva.Rows(x).Item(1) = 15 Then ' iva 27
                                    cod_alicuota = "0006"
                                End If


                                If RTrim(tb_iva.Rows(x).Item(1)) = 10 Or RTrim(tb_iva.Rows(x).Item(1)) = 13 Or RTrim(tb_iva.Rows(x).Item(1)) = 15 Then

                                    ' Importe Alicuota Iva
                                    temp_iva = Format(temp_iva + tb_iva.Rows(x).Item(0), "0.00")
                                    importe_iva_compra = Replace(tb_iva.Rows(x).Item(0), ".", "")
                                    importe_iva_compra = Replace(importe_iva_compra, "-", "")
                                    largo = importe_iva_compra.ToString.Length
                                    For j = largo To 15 - 1
                                        cero = cero & "0"
                                    Next
                                    importe_iva_compra = cero & importe_iva_compra
                                    cero = ""

                                    ' importe neto
                                    temp_neto = tb_iva.Rows(x).Item(2)
                                    importe_neto = Replace(temp_neto, ".", "")
                                    importe_neto = Replace(importe_neto, "-", "")
                                    largo = importe_neto.ToString.Length
                                    If importe_neto < 0 Then
                                        signo = "-"
                                        importe_neto = Replace(importe_neto, "-", "")
                                    Else
                                        signo = ""
                                    End If
                                    For j = largo To 15 - 1
                                        cero = cero & "0"
                                    Next
                                    importe_neto = signo & cero & importe_neto
                                    cero = ""

                                    sw1.Write(tipo_comp & pto_vta & num_comp & 80 & cuit & importe_neto & cod_alicuota & importe_iva_compra & vbLf & vbCr)

                                End If

                            Next

                            ' Suma Importe Alicuota Iva
                            temp_iva = Replace(temp_iva, ".", "")
                            temp_iva = Replace(temp_iva, "-", "")
                            largo = temp_iva.ToString.Length
                            For j = largo To 15 - 1
                                cero = cero & "0"
                            Next
                            temp_iva = cero & temp_iva
                            cero = ""

                            comando1.Dispose()

                            sw.Write(fecha & tipo_comp & pto_vta & num_comp & despacho & 80 & cuit & razon_social & importe_total & importe_no_neto & importe_exento & percepcion_iva & percepcion_nacional & percepcion_ing & percepcion_muni & impuesto_interno & "PES" & "0001000000" & cant_alic & " " & temp_iva & "000000000000000" & "00000000000" & "                              " & "000000000000000" & vbLf & vbCr)
                            barra_carga.Refresh()

                            temp_iva = 0
                            temp_neto = 0

                        End If

                    End If

                Next

                sw.Close()
                sw1.Close()
                comando.Dispose()

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' genero el archivo --REGINFO_CV_VENTAS_CBTE y REGINFO_CV_VENTAS_ALIVUOTAS
            If Me.opt_venta.Checked = True Then

                comando = New SqlDataAdapter("select replace(convert(char(11),F.fecha_emision1,111),'/','') as fecha,F.tipo_factura as tipo_comp,F.pref as punto_vta,F.num_factura as comprobante,'                ' as despacho,(select top 1 case when tipo_iva = 'Consumidor Final' then 96 else 80 end from cli_01 as C where C.id_cli = F.id_cliente) as codigo_documento,(select top 1 replace(cuit,'-','') from cli_01 as C where C.id_cli = F.id_cliente),(select top 1 nombre from cli_01 as C where C.id_cli = F.id_cliente),F.total as Total_operacion,F.sub_total as Total_sin_neto,F.sub_total,'000000000000000' as Total_imp_Nacional,'000000000000000' as Imp_Municipales,'000000000000000' as Imp_internos,'PES' as Tipo_moneda,'0001000000' as Valor_moneda,' ' as codigo_operacion,'000000000000000' as otros_tributos,'00000000000','                              ','000000000000000',substring(F.letra,0, 2) as letra_comprobante,F.iva_ins,F.iva_10 from fact_tot as F where year(F.fecha_emision1) ='" & Me.cmd_año.Text & "' and month(F.fecha_emision1) = '" & Me.cmd_mes.Text & "' and (F.tipo_factura ='FC' or F.tipo_factura ='NC' or F.tipo_factura ='ND') and F.talon2 =1 order by f.fecha_emision1 ASC", conex)
                comando.Fill(tb)
                comando.Dispose()

                'Dim x As Integer = tb.Rows.Count

                sw = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_comprobante.txt", True, Encoding.ASCII)
                sw1 = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_Alicuotas.txt", True, Encoding.ASCII)

                For i = 0 To tb.Rows.Count - 1

                    codigo_operacion = " "

                    tb_iva.Clear()
                    ' comando anterior que no tiene en cuenta la cantidad secunadaria
                    'comando1 = New SqlDataAdapter("select iva1,cantidad1*sum(precio_unidad),replace(sum(cast(iva_inscripto as float)),',','') from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1 order by iva1 desc", conex)
                    comando1 = New SqlDataAdapter("select iva1,case when val_uni_sec = 0 then cantidad1*sum(precio_unidad) else Round(val_uni_sec*sum(precio_unidad),3,0) end,replace(sum(cast(iva_inscripto as float)),',','')  from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1,val_uni_sec order by iva1 desc", conex)
                    comando1.Fill(tb_iva)
                    comando1.Dispose()

                    For x = 0 To tb_iva.Rows.Count - 1

                        selecciona_valor_impuesto(tb_iva.Rows(x).Item(0))

                        If codigo_iva = 1 Then '21%
                            temp_iva21 = Format(Val(temp_iva21) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                            temp_neto21 = Format(Val(temp_neto21) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                        End If

                        If codigo_iva = 2 Then ' 10.5%
                            temp_iva10 = Format(Val(temp_iva10) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                            temp_neto10 = Format(Val(temp_neto10) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                        End If

                        If codigo_iva = 3 Then ' 0%
                            temp_neto21 = Format(Val(temp_neto21) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                        End If

                    Next

                    fecha = tb.Rows(i).Item(0)

                    ' OBTENGO EL TIPO DE COMPROBANTE
                    If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "001" ' FACTURA A
                    If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "003" ' CREDITO A

                    If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "006" ' FACTURA A
                    If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "008" ' CREDITO A

                    If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "002" ' DEBITO A
                    If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "007" ' DEBITO B

                    ' punto de venta
                    largo = tb.Rows(i).Item(2).ToString.Length
                    For j = largo To 5 - 1
                        cero = cero & "0"
                    Next
                    pto_vta = cero & tb.Rows(i).Item(2)
                    cero = ""

                    ' numero comprobante
                    largo = tb.Rows(i).Item(3).ToString.Length
                    For j = largo To 20 - 1
                        cero = cero & "0"
                    Next
                    num_comp = cero & tb.Rows(i).Item(3)
                    cero = ""

                    ' SI EL CLIENTE SE LLAMA CONSUMIDOR FINAL Y ES DE TIPO CONSUMIDOR FINAL Y ES MENOR A 1000 PESOS HAGO ESTO
                    If Trim(tb.Rows(i).Item(7)) = "CONSUMIDOR FINAL" And tb.Rows(i).Item(5) = 96 And Val(tb.Rows(i).Item(8)) < 1000 Then
                        tipo_doc = 99
                        cuiii = 0
                    Else
                        tipo_doc = tb.Rows(i).Item(5)
                        cuiii = Trim(tb.Rows(i).Item(6))
                    End If

                    'cuit
                    largo = Trim(cuiii.Length)
                    For j = largo To 20 - 1
                        cero = cero & "0"
                    Next
                    cuit = cero & cuiii
                    cero = ""
                    cuiii = ""

                    ' razon social -- completo con espacios
                    largo = tb.Rows(i).Item(7).ToString.Length
                    If largo > 30 Then
                        razon_social = tb.Rows(i).Item(7).ToString.Substring(0, 30)
                    Else
                        razon_social = tb.Rows(i).Item(7).ToString
                        For j = largo To 30 - 1
                            razon_social = razon_social & " "
                        Next
                    End If

                    ' Importe total comprobante
                    importe_total = Replace(Format(tb.Rows(i).Item(8), "0.00"), ".", "")
                    importe_total = Replace(importe_total, "-", "")
                    largo = importe_total.ToString.Length
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_total = cero & importe_total
                    cero = ""

                    ' importe no neto
                    importe_no_neto = Replace(tb.Rows(i).Item(9), ".", "")
                    importe_no_neto = Replace(importe_no_neto, "-", "")
                    largo = importe_no_neto.ToString.Length
                    If importe_no_neto < 0 Then
                        signo = "-"
                        importe_no_neto = Replace(importe_no_neto, "-", "")
                    Else
                        signo = ""
                    End If
                    For j = largo To 15 - 1
                        cero = cero & "0"
                    Next
                    importe_no_neto = "000000000000000" 'signo & cero & importe_no_neto
                    cero = ""

                    importe_exento = "000000000000000"
                    'cero = ""

                    'percepcion nacional
                    percepcion_nacional = tb.Rows(i).Item(11)

                    'percepcion Municipal
                    percepcion_muni = tb.Rows(i).Item(12)

                    'Impuesto Interno
                    impuesto_interno = tb.Rows(i).Item(13)

                    cant_alic = 0
                    percepcion_iva = "000000000000000"
                    percepcion_ing = "000000000000000"
                    importe_iva_compra = "000000000000000"

                    ' Cantidad Alicuotas
                    ' pueden ser cero o mas  
                    ' aca significa que no tiene alicuotas de iva
                    If RTrim(tb.Rows(i).Item(22)) = 0 And RTrim(tb.Rows(i).Item(23)) = 0 Then

                        codigo_operacion = "N"
                        importe_exento = importe_total

                        cant_alic = cant_alic + 1
                        cod_alicuota = "0003"

                        ' Importe Alicuota Iva
                        importe_iva_compra = "000000000000000"
                        cero = ""

                        ' importe neto
                        importe_neto = "000000000000000"
                        cero = ""

                        sw1.Write(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra & vbLf & vbCr)

                    End If

                    ' aca si tiene alicuotas de iva
                    If RTrim(tb.Rows(i).Item(22)) > 0 Then

                        cant_alic = cant_alic + 1
                        cod_alicuota = "0005"

                        ' Importe Alicuota Iva
                        importe_iva_compra = Replace(temp_iva21, ".", "")
                        importe_iva_compra = Replace(importe_iva_compra, "-", "")
                        largo = importe_iva_compra.ToString.Length
                        For j = largo To 15 - 1
                            cero = cero & "0"
                        Next
                        importe_iva_compra = cero & importe_iva_compra
                        cero = ""

                        ' importe neto
                        importe_neto = Replace(temp_neto21, ".", "")
                        importe_neto = Replace(importe_neto, "-", "")
                        largo = importe_neto.ToString.Length
                        If importe_neto < 0 Then
                            signo = "-"
                            importe_neto = Replace(importe_neto, "-", "")
                        Else
                            signo = ""
                        End If
                        For j = largo To 15 - 1
                            cero = cero & "0"
                        Next
                        importe_neto = signo & cero & importe_neto
                        cero = ""

                        sw1.Write(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra & vbLf & vbCr)

                    End If

                    If RTrim(tb.Rows(i).Item(23)) > 0 Then

                        cant_alic = cant_alic + 1
                        cod_alicuota = "0004"

                        ' Importe Alicuota Iva
                        importe_iva_compra = Replace(temp_iva10, ".", "")
                        importe_iva_compra = Replace(importe_iva_compra, "-", "")
                        largo = importe_iva_compra.ToString.Length
                        For j = largo To 15 - 1
                            cero = cero & "0"
                        Next
                        importe_iva_compra = cero & importe_iva_compra
                        cero = ""

                        ' importe neto
                        importe_neto = Replace(temp_neto10, ".", "")
                        importe_neto = Replace(importe_neto, "-", "")
                        largo = importe_neto.ToString.Length
                        If importe_neto < 0 Then
                            signo = "-"
                            importe_neto = Replace(importe_neto, "-", "")
                        Else
                            signo = ""
                        End If
                        For j = largo To 15 - 1
                            cero = cero & "0"
                        Next
                        importe_neto = signo & cero & importe_neto
                        cero = ""

                        sw1.Write(tipo_comp & pto_vta & num_comp & importe_neto & cod_alicuota & importe_iva_compra & vbLf & vbCr)

                    End If

                    If cant_alic > 0 Then
                        sw.Write(fecha & tipo_comp & pto_vta & num_comp & num_comp & tipo_doc & cuit & razon_social & importe_total & importe_no_neto & importe_exento & percepcion_iva & percepcion_nacional & percepcion_ing & percepcion_muni & impuesto_interno & "PES" & "0001000000" & cant_alic & codigo_operacion & "000000000000000" & fecha & vbLf & vbCr)
                    End If

                    barra_carga.Refresh()

                    temp_iva = 0
                    temp_neto = 0
                    temp_iva21 = 0
                    temp_iva10 = 0
                    temp_neto21 = 0
                    temp_neto10 = 0

                Next

                sw.Close()
                sw1.Close()
                'comando.Dispose()

            End If

            MessageBox.Show("Finalizado correctamente!!!", "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception

            MessageBox.Show(ex.Message & " " & tb.Rows(i).Item(1) & " " & tb.Rows(i).Item(2) & " " & tb.Rows(i).Item(3), "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            barra_carga.Timer1.Enabled = True

        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        'System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/YYYY"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        Me.cmb_cargo.Text = Me.cmb_cargo.Items(0)
        Me.cmd_mes.Text = Me.cmd_mes.Items(0)
        Me.cmd_año.Text = Date.Now.Year
        Me.cmd_presenta.Text = Me.cmd_presenta.Items(0)

    End Sub

    Private Sub selecciona_valor_impuesto(ByVal valor As Decimal)

        Dim tb_ivaa As New DataTable
        tb_ivaa.Clear()

        conex = conecta()

        comando = New SqlDataAdapter("select iva_insc,id_iva from iva_01 where iva_insc = '" & Trim(valor) & "'", conex)
        comando.Fill(tb_ivaa)
        comando.Dispose()

        porcentaje_impuesto = tb_ivaa.Rows(0).Item(0)
        codigo_iva = tb_ivaa.Rows(0).Item(1)

        tb_ivaa.Dispose()

    End Sub

    Private Sub cmd_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd_guardar.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.txt_path.Text = Me.FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub cmd_exporta_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exporta_excel.Click

        Try

            tb.Clear()

            conex = New SqlConnection
            conex = conecta()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            comando = New SqlDataAdapter("select convert(char(11),F.fecha_emision1,103) as fecha,F.tipo_factura as tipo_comp,F.pref as punto_vta,F.num_factura as comprobante,'                ' as despacho,(select top 1 case tipo_iva when 'Consumidor Final' then 3 when 'Responsable Inscripto' then 1 when 'Monotributo' then 5 when 'Exento' then 4 end from cli_01 as C where C.id_cli = F.id_cliente) as condicion_iva,(select top 1 cuit from cli_01 as C where C.id_cli = F.id_cliente),(select top 1 substring(nombre,0,199) from cli_01 as C where C.id_cli = F.id_cliente) as nombre,F.total as Total_operacion,F.sub_total as Total_sin_neto,F.sub_total,'000000000000000' as Total_imp_Nacional,'000000000000000' as Imp_Municipales,'000000000000000' as Imp_internos,'PES' as Tipo_moneda,'0001000000' as Valor_moneda,' ' as codigo_operacion,'000000000000000' as otros_tributos,'00000000000','                              ','000000000000000',substring(F.letra,0, 2) as letra_comprobante,F.iva_ins,F.iva_10,F.descuento from fact_tot as F where year(F.fecha_emision1) = '" & Me.cmd_año.Text & "' and month(F.fecha_emision1) = '" & Me.cmd_mes.Text & "' and (F.tipo_factura ='FC' or F.tipo_factura ='NC' or F.tipo_factura ='ND') and F.talon2 =1 order by f.fecha_emision1 ASC", conex)
            comando.Fill(tb)
            comando.Dispose()

            'sw = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_comprobante_d.txt", True, Encoding.ASCII)
            'sw1 = New IO.StreamWriter(Me.txt_path.Text & "\" & "Ventas_Alicuotas_d.txt", True, Encoding.ASCII)

            For i = 0 To tb.Rows.Count - 1

                codigo_operacion = " "
                descuento = tb.Rows(i).Item(24)

                tb_iva.Clear()
                'comando1 = New SqlDataAdapter("select iva1,cantidad1*sum(precio_unidad),replace(sum(cast(iva_inscripto as float)),',','') from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1 order by iva1 desc", conex)
                ' si descuento general es igual a 0 hago esto
                If Val(descuento) = 0 Then
                    comando1 = New SqlDataAdapter("select iva1,case when ISNULL(val_uni_sec,0) = 0 then cantidad1*sum(precio_unidad) else Round(val_uni_sec*sum(precio_unidad),3,0) end,replace(sum(cast(iva_inscripto as float)),',','')  from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1,val_uni_sec order by iva1 desc", conex)
                Else
                    comando1 = New SqlDataAdapter("select iva1,case when ISNULL(val_uni_sec,0) = 0 then cantidad1*sum(precio_unidad) - (cantidad1*sum(precio_unidad) * '" & descuento & "')/100 else Round(val_uni_sec*sum(precio_unidad),3,0) - (Round(val_uni_sec*sum(precio_unidad),3,0) * '" & descuento & "')/100 end,replace(sum(cast(iva_inscripto as float)) - (sum(cast(iva_inscripto as float))* '" & descuento & "') /100,',','') from fact_det where tipo_fact2 = '" & Trim(tb.Rows(i).Item(1)) & "' and prefijo_fact2 = '" & Trim(tb.Rows(i).Item(2)) & "' and num_fact = '" & Trim(tb.Rows(i).Item(3)) & "' and letra_fact1 = '" & Trim(tb.Rows(i).Item(21)) & "' and talon1 = 1 group by iva1,cantidad1,val_uni_sec order by iva1 desc", conex)
                End If

                comando1.Fill(tb_iva)
                comando1.Dispose()

                For x = 0 To tb_iva.Rows.Count - 1

                    selecciona_valor_impuesto(tb_iva.Rows(x).Item(0))

                    If codigo_iva = 1 Then '21%
                        temp_iva21 = Format(Val(temp_iva21) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                        temp_neto21 = Format(Val(temp_neto21) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                        iva21 = porcentaje_impuesto
                    End If

                    If codigo_iva = 2 Then ' 10.5%
                        temp_iva10 = Format(Val(temp_iva10) + Val(tb_iva.Rows(x).Item(2)), "0.00")
                        temp_neto10 = Format(Val(temp_neto10) + Val(tb_iva.Rows(x).Item(1)), "0.00")
                        iva10 = porcentaje_impuesto
                    End If

                Next

                fecha = tb.Rows(i).Item(0)

                ' OBTENGO EL TIPO DE COMPROBANTE
                If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "1" ' FACTURA A
                If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "3" ' CREDITO A

                If RTrim(tb.Rows(i).Item(1)) = "FC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "6" ' FACTURA A
                If RTrim(tb.Rows(i).Item(1)) = "NC" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "8" ' CREDITO A

                If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "A" Then tipo_comp = "2" ' DEBITO A
                If RTrim(tb.Rows(i).Item(1)) = "ND" And RTrim(tb.Rows(i).Item(21)) = "B" Then tipo_comp = "7" ' DEBITO B

                ' punto de venta
                pto_vta = tb.Rows(i).Item(2).ToString()

                ' numero comprobante
                num_comp = tb.Rows(i).Item(3).ToString()

                ' SI EL CLIENTE SE LLAMA CONSUMIDOR FINAL Y ES DE TIPO CONSUMIDOR FINAL Y ES MENOR A 1000 PESOS HAGO ESTO
                If Trim(tb.Rows(i).Item(7)) = "CONSUMIDOR FINAL" And tb.Rows(i).Item(5) = 3 And Val(tb.Rows(i).Item(8)) < 172000 Then
                    'cond_iva = 99
                    cond_iva = tb.Rows(i).Item(5)
                    cuiii = 1
                Else
                    cond_iva = tb.Rows(i).Item(5)
                    cuiii = Trim(tb.Rows(i).Item(6))
                End If

                razon_social = tb.Rows(i).Item(7)

                ' Importe total comprobante
                importe_total = Replace(Format(tb.Rows(i).Item(8), "0.00"), ".", ",")

                ' importe no neto
                importe_no_neto = Replace(Format(tb.Rows(i).Item(9), "0.00"), ".", ",")

                Me.DataGridView1.Rows.Add()
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Value = razon_social
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = cond_iva
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2).Value = cuiii
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(3).Value = tipo_comp
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(4).Value = tb.Rows(i).Item(21) ' letra
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(5).Value = pto_vta
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(6).Value = num_comp
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(7).Value = fecha
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(8).Value = importe_total
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(9).Value = iva21
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(10).Value = ""
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(11).Value = Replace(temp_iva21, ".", ",")
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(12).Value = Replace(temp_neto21, ".", ",")
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(13).Value = ""
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(14).Value = ""
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(15).Value = Replace(iva10, ".", ",")
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(16).Value = ""
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(17).Value = Replace(temp_iva10, ".", ",")
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(18).Value = Replace(temp_neto10, ".", ",")

                'sw.WriteLine(fecha & tipo_comp & pto_vta & num_comp & num_comp & tipo_doc & cuit & razon_social & importe_total & importe_no_neto & importe_no_categorizado & importe_exento & percepcion_nacional & percepcion_ing & percepcion_muni & impuesto_interno & "PES" & "0001000000" & cant_alic & codigo_operacion & "000000000000000" & fecha)

                barra_carga.Refresh()

                iva21 = ""
                iva10 = ""
                temp_iva = 0
                temp_neto = 0
                temp_iva21 = 0
                temp_iva10 = 0
                temp_neto21 = 0
                temp_neto10 = 0

            Next

            'sw.Close()
            'sw1.Close()

            MessageBox.Show("Finalizado correctamente!!!", "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception

            MessageBox.Show(ex.Message & " " & tb.Rows(i).Item(1) & " " & tb.Rows(i).Item(2) & " " & tb.Rows(i).Item(3), "PyMSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            barra_carga.Timer1.Enabled = True

            Call ExportarDatosExcelSinCabecera(Me.DataGridView1, Nothing, "", 1)

        End Try

    End Sub
End Class
