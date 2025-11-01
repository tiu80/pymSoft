Imports System.Data
Imports System.Data.SqlClient

Public Class Form_actualizador

    Dim res As DialogResult
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim tb As New DataTable, tb1 As New DataTable, tbl2 As New DataTable, tb2 As New DataTable, tb_stk As New DataTable, tb_stk1 As New DataTable
    Dim lista As Integer
    Dim fact As New pymsoft.factura
    Dim mueve_stk As String
    Dim reader As SqlDataReader
    Dim sr As IO.StreamReader
    Dim y As Integer
    Dim cant As Double
    Dim tip As String

    Private Sub cmd_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_buscar.Click
        res = Me.FolderBrowserDialog1.ShowDialog()

        If res = Windows.Forms.DialogResult.OK Then
            Me.txt_enviar.Text = Me.FolderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub opt_articulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_articulos.CheckedChanged

        If Me.opt_articulos.Checked = True Then
            Me.cmb_lista.Enabled = True
            Me.cmb_sucursal.Enabled = False

            Me.DataGridView1.DataSource = Nothing
        End If

    End Sub

    Private Sub opt_remitos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_remitos.CheckedChanged

        If Me.opt_remitos.Checked = True Then
            Me.cmb_lista.Enabled = False
            Me.cmb_sucursal.Enabled = True

            Call llena_grilla()

        End If

    End Sub

    Private Sub Form_actualizador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        tb.Clear()
        tb1.Clear()

        comando = New SqlDataAdapter("select nombre from lista_01 where id_lis <> 1", conex)
        comando.Fill(tb)

        Me.cmb_lista.DataSource = tb
        Me.cmb_lista.ValueMember = "nombre"

        comando = New SqlDataAdapter("select nombre from cli_01 where tipo_cliente = 'Furgon'", conex)
        comando.Fill(tb1)

        Me.cmb_sucursal.DataSource = tb1
        Me.cmb_sucursal.ValueMember = "nombre"

        fact.carga_parametro()
        mueve_stk = fact.mueve_stock

        If principal.lbl_usu.Text <> "Administrador" Then
            Me.cmd_buscar.Enabled = False
        End If

    End Sub

    Private Sub cmd_inicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inicia.Click

        If Me.opt_articulos.Checked = True Then
            If Me.chk_recibir.Checked = False Then Call genera_articulos()
            If Me.chk_recibir.Checked = True Then Call recibe_articulos()
        End If

        If Me.opt_remitos.Checked = True Then
            MessageBox.Show("Importante !! No facture durante este proceso", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If Me.chk_recibir.Checked = False Then genera_remito_remoto()
            If Me.chk_recibir.Checked = True Then recibe_remito_remoto()
        End If

    End Sub

    Private Sub genera_articulos()

        Dim i As Integer
        tbl2 = New DataTable
        Dim sw As System.IO.StreamWriter

        Try

            If Me.txt_enviar.Text = "" Then
                MessageBox.Show("selecione la ruta para ENVIAR el archivo !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            If IO.File.Exists(Me.txt_enviar.Text & "\" & "articulos.txt") Then
                Dim a As Integer = MessageBox.Show("Existe un archivo desea sobrescribirlo ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If a = 6 Then IO.File.Delete(Me.txt_enviar.Text & "\" & "articulos.txt")
                If a <> 6 Then Exit Sub
            End If

            lista = selecciona_lista()

            comando = New SqlDataAdapter("select id_art1,nombre,precio_siva,precio_civa,iva_insc,cod_imp,impuestos,id_iva,iva,exento,rubro,costo,id_lista1,id_rubro,codigo_barra,cantidad_bulto,id_proveedor,proveedor,lista,mueve_stok,fec_alta,fec_modi,estado,stock_corte,utilidad,desc1,desc2,desc3,flete,pago_total from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.estado = 'Activo' and art_precio.id_lista1 = '" & RTrim(lista) & "'", conex)
            comando.Fill(tbl2)

            sw = New IO.StreamWriter(Me.txt_enviar.Text & "\" & "articulos.txt")

            For i = 0 To tbl2.Rows.Count - 1

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10) & "|" & tbl2.Rows(i).Item(11) & "|" & tbl2.Rows(i).Item(12) & "|" & tbl2.Rows(i).Item(13) & "|" & tbl2.Rows(i).Item(14) & "|" & tbl2.Rows(i).Item(15) & "|" & tbl2.Rows(i).Item(16) & "|" & tbl2.Rows(i).Item(17) & "|" & tbl2.Rows(i).Item(18) & "|" & tbl2.Rows(i).Item(19) & "|" & tbl2.Rows(i).Item(20) & "|" & tbl2.Rows(i).Item(21) & "|" & tbl2.Rows(i).Item(22) & "|" & tbl2.Rows(i).Item(23) & "|" & tbl2.Rows(i).Item(24) & "|" & tbl2.Rows(i).Item(25) & "|" & tbl2.Rows(i).Item(26) & "|" & tbl2.Rows(i).Item(27) & "|" & tbl2.Rows(i).Item(28))
                barra_carga.Refresh()

            Next

            sw.Close()
            MessageBox.Show("Proceso Terminado Correctamente!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            barra_carga.Timer1.Enabled = True
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub llena_grilla()

        conex = conecta()
        tb2.Clear()

        comando = New SqlDataAdapter("select fec_emision,tipo_fact,letra_fact,prefijo_fact,num_fact1,total,comentario from fact_cab inner join fact_tot on fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.talon = fact_tot.talon2 and fact_cab.arqueo = 'B' and fact_cab.nombre = '" & RTrim(Me.cmb_sucursal.Text) & "' where fact_cab.tipo_fact = 'RE' or fact_cab.tipo_fact = 'RS'", conex)
        comando.Fill(tb2)

        Me.DataGridView1.DataSource = tb2

        Me.DataGridView1.Columns(0).Width = 90
        Me.DataGridView1.Columns(1).Width = 50
        Me.DataGridView1.Columns(2).Width = 50
        Me.DataGridView1.Columns(3).Width = 50
        Me.DataGridView1.Columns(4).Width = 50
        Me.DataGridView1.Columns(5).Width = 70
        Me.DataGridView1.Columns(6).Width = 340

        Me.DataGridView1.Columns(0).HeaderText = "Fecha"
        Me.DataGridView1.Columns(1).HeaderText = "tipo"
        Me.DataGridView1.Columns(2).HeaderText = "letra"
        Me.DataGridView1.Columns(3).HeaderText = "Pre"
        Me.DataGridView1.Columns(4).HeaderText = "Numero"
        Me.DataGridView1.Columns(5).HeaderText = "Total"
        Me.DataGridView1.Columns(6).HeaderText = "comentario"

    End Sub

    Function selecciona_lista()

        Dim tb3 As New DataTable

        conex = conecta()
        tb3.Clear()

        comando = New SqlDataAdapter("select id_lis from lista_01 where nombre = '" & RTrim(Me.cmb_lista.Text) & "'", conex)
        comando.Fill(tb3)

        Return tb3.Rows(0).Item(0)

    End Function

    Private Sub recibe_articulos()

        Dim tabla As New DataTable, tb_comp As New DataTable
        Dim x(25) As String

        Try

            If Me.txt_recibir.Text = "" Then
                MessageBox.Show("selecione la ruta para RECIBIR el archivo !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            lista = selecciona_lista()

            MessageBox.Show("Este proceso puede durar unos MINUTOS!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            coman = New SqlCommand("DELETE art_precio where id_lista1 = '" & RTrim(lista) & "'", conex)
            coman.ExecuteNonQuery()

            coman.Dispose()

            ' agrega articulos que no existen
            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & "articulos.txt")   'lee cabecera pedido

            While sr.EndOfStream = False

                coman = New SqlCommand("select id_art from art_01 where id_art = '" & x(0) & "'", conex)
                reader = coman.ExecuteReader
                coman.Dispose()

                reader.Read()

                x = Split(sr.ReadLine, "|")

                If reader.HasRows = False Then

                    reader.Close()

                    coman = New SqlCommand("INSERT INTO art_01(id_art,nombre,id_rubro,rubro,codigo_barra,id_proveedor,proveedor,id_lista,lista,mueve_stok,fec_alta,fec_modi,estado,stock_corte,cantidad,cantidad_bulto,cant_ant,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas) VALUES('" & x(0) & "','" & x(1) & "','" & x(13) & "','" & x(10) & "','" & x(14) & "','" & x(16) & "','" & x(17) & "','1','GENERAL','" & x(19) & "','" & x(20) & "','" & x(21) & "','" & x(22) & "','" & x(23) & "',0,0,0,0,0,0,0)", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                Else

                    reader.Close()

                End If

            End While

            sr.Close()

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & "articulos.txt")   'lee cabecera pedido

            comando = New SqlDataAdapter("select id_art from art_01", conex)
            comando.Fill(tb_comp)

            ' actualiza y borra articulos que no nexiste

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                barra_carga.PictureBox1.Refresh()
                coman = New SqlCommand("INSERT INTO art_precio(id_art1,nom,id_lista1,costo,iva_insc,id_iva,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,estado1,cod,desc1,desc2,desc3,flete,pago_total) VALUES('" & x(0) & "','" & x(1) & "','" & x(12) & "','" & x(11) & "','" & x(4) & "','" & x(7) & "','" & x(8) & "','" & x(5) & "','" & x(6) & "','" & x(9) & "','" & x(23) & "','" & x(2) & "','" & x(3) & "','" & x(22) & "','" & x(0) & "','" & x(24) & "','" & x(25) & "','" & x(26) & "','" & x(27) & "','" & x(28) & "')", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                While tb_comp.Rows.Count-1
                    If tb_comp.Rows(y).Item(0) = x(0) Then

                        coman = New SqlCommand("UPDATE art_01 set id_art = '" & x(0) & "',nombre = '" & x(1) & "',id_rubro = '" & x(13) & "',rubro = '" & x(10) & "',codigo_barra = '" & x(14) & "',id_proveedor = '" & x(16) & "',proveedor = '" & x(17) & "',id_lista = '1',lista='GENERAL',mueve_stok = '" & x(19) & "',fec_alta = '" & x(20) & "',fec_modi= '" & x(21) & "',estado = '" & x(22) & "',stock_corte = '" & x(23) & "' where id_art = '" & RTrim(x(0)) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()
                        Exit While

                    End If

                    y = y + 1

                    If y = tb.Rows.Count - 1 Then
                        coman = New SqlCommand("delete art_01 where id_art = '" & x(0) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()
                    End If

                End While

                y = 0

            End While

            sr.Close()

            If IO.File.Exists(Me.txt_recibir.Text & "\" & "articulos.txt") Then
                IO.File.Delete(Me.txt_recibir.Text & "\" & "articulos.txt")
            End If

            If conex.State = ConnectionState.Open Then conex.Close()
            MessageBox.Show("Proceso Terminado Correctamente !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK)
            barra_carga.Timer1.Enabled = True

        Finally

            barra_carga.Timer1.Enabled = True
            Me.Close()

        End Try


    End Sub

    Private Sub genera_remito_remoto()

        Dim i As Integer, pos As Integer
        tbl2 = New DataTable
        Dim tbl3 As New DataTable
        Dim sw As System.IO.StreamWriter

        tbl2.Clear()
        tbl3.Clear()

        Try

            If Me.txt_enviar.Text = "" Then
                MessageBox.Show("selecione la ruta para ENVIAR el archivo !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If IO.File.Exists(Me.txt_enviar.Text & "\" & "remito.txt") Then
                Dim a As Integer = MessageBox.Show("Existe un archivo desea sobrescribirlo ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If a = 6 Then IO.File.Delete(Me.txt_enviar.Text & "\" & "remito.txt")
                If a <> 6 Then Exit Sub
            End If


            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            ' convino la tabla detalle y totales para generar el remito

            comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,precio_civa1,iva1,total1,iva_inscripto,imp_interno,exento1,cod_lista,mes,año,costo,cod_rub,total,iva_ins,iva_10,exento,imp_interno1,sub_total,comentario,cod_prov from fact_det inner join fact_tot on num_fact = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(4).Value) & "' and letra_fact1= '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(2).Value) & "' and tipo_fact2 = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(1).Value) & "' and prefijo_fact2 = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(3).Value) & "' and num_fact=num_factura and letra_fact1 = letra and tipo_factura = tipo_fact2 and prefijo_fact2 = pref and talon1 = talon2", conex)
            comando.Fill(tbl2)

            comando = New SqlDataAdapter("select num_fact1,tipo_fact,prefijo_fact,letra_fact,id_cli,nombre,tipo_iva,cuit,direccion,id_lista,lista,estado_fact,talon,fec_emision,fec_vto from fact_cab where num_fact1 = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(4).Value) & "' and letra_fact= '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(2).Value) & "' and tipo_fact = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(1).Value) & "' and prefijo_fact = '" & RTrim(Me.DataGridView1.SelectedRows(i).Cells(3).Value) & "'", conex)
            comando.Fill(tbl3)

            If RTrim(tbl3.Rows(0).Item(1)) = "RS" Then
                tip = "RE"
            Else
                tip = "RS"
            End If

            sw = New IO.StreamWriter(Me.txt_enviar.Text & "\" & "remito.txt")

            For i = 0 To tbl2.Rows.Count - 1

                tb_stk.Clear()

                sw.WriteLine(tbl3.Rows(0).Item(0) & "|" & tbl3.Rows(0).Item(1) & "|" & tbl3.Rows(0).Item(2) & "|" & tbl3.Rows(0).Item(3) & "|" & tbl3.Rows(0).Item(4) & "|" & tbl3.Rows(0).Item(5) & "|" & tbl3.Rows(0).Item(6) & "|" & tbl3.Rows(0).Item(7) & "|" & tbl3.Rows(0).Item(8) & "|" & tbl3.Rows(0).Item(9) & "|" & tbl3.Rows(0).Item(10) & "|" & tbl3.Rows(0).Item(11) & "|" & tbl3.Rows(0).Item(12) & "|" & tbl3.Rows(0).Item(13) & "|" & tbl3.Rows(0).Item(14) & "|" & tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10) & "|" & tbl2.Rows(i).Item(11) & "|" & tbl2.Rows(i).Item(12) & "|" & tbl2.Rows(i).Item(13) & "|" & tbl2.Rows(i).Item(14) & "|" & tbl2.Rows(i).Item(15) & "|" & tbl2.Rows(i).Item(16) & "|" & tbl2.Rows(i).Item(17) & "|" & tbl2.Rows(i).Item(18) & "|" & tbl2.Rows(i).Item(19) & "|" & tbl2.Rows(i).Item(20) & "|" & tbl2.Rows(i).Item(21) & "|" & tbl2.Rows(i).Item(22))
                barra_carga.Refresh()

                If RTrim(mueve_stk) = "SI" Then

                    comando = New SqlDataAdapter("select cantidad from art_01 where id_art = '" & RTrim(tbl2.Rows(i).Item(0)) & "'", conex)
                    comando.Fill(tb_stk)

                    If tip = "RS" Then cant = Format(tb_stk.Rows(0).Item(0) - tbl2.Rows(i).Item(2), "0.00")
                    If tip = "RE" Then cant = Format(tb_stk.Rows(0).Item(0) + tbl2.Rows(i).Item(2), "0.00")

                    coman = New SqlCommand("update art_01 set cantidad = '" & cant & "' where id_art = '" & RTrim(tbl2.Rows(i).Item(0)) & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            Next

            pos = Me.DataGridView1.CurrentCell.RowIndex
            Call genera_remito_automatico(pos, tip)

            sw.Close()
            If conex.State = ConnectionState.Open Then conex.Close()
            MessageBox.Show("Proceso Terminado Correctamente!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            barra_carga.Timer1.Enabled = True
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub genera_remito_automatico(ByVal x, ByVal tipo)

        coman = New SqlCommand("update fact_cab set arqueo = 'A' where arqueo = 'B' and num_fact1 = '" & RTrim(Me.DataGridView1.Rows(x).Cells(4).Value) & "' and letra_fact= '" & RTrim(Me.DataGridView1.Rows(x).Cells(2).Value) & "' and tipo_fact = '" & RTrim(Me.DataGridView1.Rows(x).Cells(1).Value) & "' and prefijo_fact = '" & RTrim(Me.DataGridView1.Rows(x).Cells(3).Value) & "'", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

        coman = New SqlCommand("INSERT INTO fact_cab(num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,fec_vto,id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,lista,forma_pago,estado_fact,id_lista,talon,ing_bruto1,arqueo,pago) select num_fact1,'" & tipo & "','99',letra_fact,fec_emision,fec_vto,id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,lista,forma_pago,estado_fact,id_lista,talon,ing_bruto1,arqueo,pago from fact_cab where num_fact1 = '" & RTrim(Me.DataGridView1.Rows(x).Cells(4).Value) & "' and letra_fact= '" & RTrim(Me.DataGridView1.Rows(x).Cells(2).Value) & "' and tipo_fact = '" & RTrim(Me.DataGridView1.Rows(x).Cells(1).Value) & "' and prefijo_fact = '" & RTrim(Me.DataGridView1.Rows(x).Cells(3).Value) & "'", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

        coman = New SqlCommand("INSERT INTO fact_det(fec_emi,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,cod_prov,cod_rub,nom_producto,vend1,n_carga) select fec_emi,num_fact,'" & tipo & "','99',letra_fact1,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,cod_prov,cod_rub,nom_producto,vend1,n_carga from fact_det where num_fact = '" & RTrim(Me.DataGridView1.Rows(x).Cells(4).Value) & "' and letra_fact1 = '" & RTrim(Me.DataGridView1.Rows(x).Cells(2).Value) & "' and tipo_fact2 = '" & RTrim(Me.DataGridView1.Rows(x).Cells(1).Value) & "' and prefijo_fact2 = '" & RTrim(Me.DataGridView1.Rows(x).Cells(3).Value) & "'", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

        coman = New SqlCommand("INSERT INTO fact_tot(num_factura,letra,tipo_factura,pref,id_cliente,nombre_cli,total,iva_ins,exento,imp_interno1,iva_10,sub_total,fecha_emision1,descuento,total_cobro,talon2,efectivo,comentario) select num_factura,letra,'" & tipo & "','99',id_cliente,nombre_cli,total,iva_ins,exento,imp_interno1,iva_10,sub_total,fecha_emision1,descuento,total_cobro,talon2,efectivo,comentario from fact_tot where num_factura = '" & RTrim(Me.DataGridView1.Rows(x).Cells(4).Value) & "' and letra = '" & RTrim(Me.DataGridView1.Rows(x).Cells(2).Value) & "' and tipo_factura = '" & RTrim(Me.DataGridView1.Rows(x).Cells(1).Value) & "' and pref = '" & RTrim(Me.DataGridView1.Rows(x).Cells(3).Value) & "'", conex)
        coman.ExecuteNonQuery()

        coman.Dispose()

    End Sub

    Private Sub txt_recibir_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_recibir.KeyUp

        If e.KeyCode = Keys.F10 Then
            Me.txt_recibir.ReadOnly = False
        End If

    End Sub

    Private Sub recibe_remito_remoto()

        Dim x(35) As String
        Dim cont As Integer = 0

        Try

            If Me.txt_recibir.Text = "" Then
                MessageBox.Show("selecione la ruta para RECIBIR el archivo !!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & "remito.txt")   'lee cabecera pedido

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                If cont = 0 Then

                    coman = New SqlCommand("INSERT INTO fact_cab(num_fact1,tipo_fact,prefijo_fact,letra_fact,id_cli,nombre,tipo_iva,cuit,direccion,id_lista,lista,estado_fact,talon,fec_emision,fec_vto,vendedor,nom_vendedor,forma_pago,ing_bruto1,arqueo,pago) values ('" & x(0) & "','" & x(1) & "','99','" & x(3) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','" & x(7) & "','" & x(8) & "','" & x(9) & "','" & x(10) & "','" & x(11) & "','" & x(12) & "','" & x(13) & "','" & x(14) & "',0,'','',0,'','')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    coman = New SqlCommand("INSERT INTO fact_tot(num_factura,tipo_factura,pref,letra,id_cliente,total,iva_ins,iva_10,exento,imp_interno1,sub_total,descuento,nombre_cli,fecha_emision1,total_cobro,talon2,efectivo,comentario) VALUES ('" & x(0) & "','" & x(1) & "','99','" & x(3) & "','" & x(4) & "','" & x(30) & "','" & x(31) & "','" & x(32) & "','" & x(33) & "','" & x(34) & "','" & x(35) & "','" & x(36) & "','" & x(5) & "','" & x(13) & "','" & x(30) & "','" & x(12) & "','','" & x(36) & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    cont = cont + 1

                End If

                coman = New SqlCommand("INSERT INTO fact_det(num_fact,tipo_fact2,prefijo_fact2,letra_fact1,codi_producto,detalle,cantidad1,precio_unidad,precio_civa1,iva1,total1,iva_inscripto,imp_interno,exento1,cod_lista,mes,año,costo,cod_rub,fec_emi,descuento,talon1,cantidad_sin_stock,fila,cod_prov,nom_producto,vend1,asterisco,n_carga) values ('" & x(0) & "','" & x(1) & "','99','" & x(3) & "','" & x(15) & "','" & x(16) & "','" & x(17) & "','" & x(18) & "','" & x(19) & "','" & x(20) & "','" & x(21) & "','" & x(22) & "','" & x(23) & "','" & x(24) & "','" & x(25) & "','" & x(26) & "','" & x(27) & "','" & x(28) & "','" & x(29) & "','" & x(13) & "',0,'" & x(12) & "','NO',0,'" & x(37) & "','',0,'',0)", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                '''''''' actualiza el stock dependinedo si es remito de salida o de entrada

                If RTrim(mueve_stk) = "SI" Then

                    tb_stk1.Clear()

                    comando = New SqlDataAdapter("select cantidad from art_01 where id_art = '" & RTrim(x(15)) & "'", conex)
                    comando.Fill(tb_stk1)

                    If RTrim(x(1)) = "RS" Then cant = Format(tb_stk1.Rows(0).Item(0) - x(17), "0.00")
                    If RTrim(x(1)) = "RE" Then cant = Format(tb_stk1.Rows(0).Item(0) + x(17), "0.00")

                    coman = New SqlCommand("update art_01 set cantidad = '" & cant & "' where id_art = '" & RTrim(x(15)) & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            End While

            sr.Close()

            If IO.File.Exists(Me.txt_recibir.Text & "\" & "remito.txt") Then
                IO.File.Delete(Me.txt_recibir.Text & "\" & "remito.txt")
            End If

            If conex.State = ConnectionState.Open Then conex.Close()
            MessageBox.Show("Proceso Terminado Correctamente!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK)

        Finally

            barra_carga.Timer1.Enabled = True
            Me.Close()

        End Try

    End Sub

End Class