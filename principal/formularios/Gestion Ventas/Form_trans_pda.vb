Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.WebRequest

Public Class Form_trans_pda

    Dim tbl As New DataTable, tbl2 As New DataTable, tb_error As New DataTable, ttb As New DataTable, t As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim xx As New pymsoft.parametro
    Dim zzz As New pymsoft.vendedor
    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim fact As New pymsoft.factura
    Dim filas, fila_det, cod_bco, talon_cobro As Integer
    Dim a As Boolean
    Dim x(20) As String, existe_pedido As String = "N"
    Dim sr As IO.StreamReader
    Dim coman As SqlCommand
    Dim forma_pago As String = "", letra As String = ""
    Dim pago As String = ""
    Dim sale As Boolean = True, mensaje As Boolean = True
    Dim nom_rub, nom_prov As String

    Dim trans As SqlTransaction

    Private Sub cmd_inicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inicia.Click

        'Dim aa() As String

        Try

            'Dim sr As IO.StreamReader
            'Dim coman As SqlCommand
            'Dim tt As New DataTable
            'Dim num As Integer = 1000
            'Dim id_rub As String

            'conex = conecta()
            'conex.Open()

            'sr = New IO.StreamReader("c:\articulos.csv")

            'While sr.EndOfStream = False

            'aa = Split(sr.ReadLine, ";")

            'Dim stk As String

            'If Val(aa(3)) >= Val(aa(4)) Then
            'stk = Format(Val(aa(3)) - Val(aa(4)), "0.00")
            'Else
            'stk = Val(aa(3))
            'End If

            'coman = New SqlCommand("update art_01 set stock_corte = '" & stk & "' where id_art = '" & num & "'", conex)
            'coman.ExecuteNonQuery()

            'tt.Clear()

            'comando = New SqlDataAdapter("select zona from zona_01 where id_zona = '" & RTrim(aa(7)) & "'", conex)
            'comando.Fill(tt)

            'coman = New SqlCommand("insert into rub_01(id_rubro,nombre) values ('" & num & "','" & Replace(aa(0), "'", "") & "')", conex)
            'coman.ExecuteNonQuery()
            'coman.Dispose()

            'num = num + 1

            'Dim rub As String = Replace(aa(3), "'", "")

            'comando = New SqlDataAdapter("select id_rubro from rub_01 where nombre = '" & RTrim(rub) & "'", conex)
            'comando.Fill(tt)

            'If tt.Rows.Count = 0 Then
            'id_rub = "0"
            'Else
            'id_rub = tt.Rows(0).Item(0)
            'End If

            'coman = New SqlCommand("insert into art_01(id_art,nombre,id_lista,id_rubro,cantidad_bulto,cantidad,id_proveedor,mueve_stok,cant_ant,stock_corte,fec_alta,fec_modi,estado,rubro,lista,proveedor,codigo_barra,cod_imp_ventas,nom_imp_ventas,cod_imp_compras,nom_imp_compras) values ('" & aa(0) & "','" & Replace(aa(1), "'", "") & "','1','1','1','0','1000','SI','0','0','" & Form_login.DateTimePicker1.Text & "','" & Form_login.DateTimePicker1.Text & "','Activo','VARIOS','GENERAL','VARIOS','',0,0,0,0)", conex)
            'coman.ExecuteNonQuery()
            'coman.Dispose()

            'Dim costo, utilidad As Double
            'Dim es_dolar As String

            'If aa(3) = "" Then
            'costo = 1
            'Else
            'costo = aa(3)
            'End If

            'If aa(6) = "" Then
            'utilidad = 1
            'Else
            'costo = aa(6)
            'End If

            'If Trim(aa(5)) = "False" Or Trim(aa(5)) = "" Then
            'es_dolar = "$"
            'Else
            'es_dolar = "USD"
            'End If

            'Dim p_siva As Double = Replace(aa(2), ",", ".")
            'p_siva = Format(p_siva / 1.21, "0.00")

            'coman = New SqlCommand("insert into art_precio(id_art1,nom,id_lista1,costo,id_iva,iva_insc,iva,cod_imp,impuestos,exento,utilidad,precio_siva,precio_civa,cod,estado1,desc1,desc2,desc3,flete,pago_total,moneda,valor_moneda) values ('" & aa(0) & "','" & Replace(aa(1), "'", "") & "','1','" & costo & "','1','','21','0','0','0','" & utilidad & "','" & p_siva & "','" & Replace(aa(2), ",", ".") & "','" & aa(0) & "','Activo',0,0,0,0,0,'" & es_dolar & "',0)", conex)
            'coman.ExecuteNonQuery()
            'coman.Dispose()

            'Dim loc, tel, prov, cel, mail, obs As String

            'If aa(3) = "" Then
            'Loc = "VILLA MARIA"
            'Else
            'Loc = aa(3)
            'End If

            'If aa(6) = "" Then
            'tel = ""
            'Else
            'tel = aa(6)
            'End If

            'If aa(7) = "" Then
            'cel = ""
            'Else
            'cel = aa(7)
            'End If

            'coman = New SqlCommand("INSERT INTO cli_01(id_cli,nombre,direccion,tipo_cliente,localidad,cod_postal,telefono,fax,mail,tipo_iva,cuit,ing_brutos,vendedor,nom_vendedor,cod_list,nom_lista,rubro,observaciones,estado,fecha,num_loc,id_prov,provincia,id_zona,zona) VALUES('" & aa(0) & "' , '" & aa(1) & "', '" & aa(2) & "', 'Cliente', '" & Loc() & "', '5900', '" & tel & "','" & cel & "','','Consumidor Final', '00-00000000-0', '', '1','MOSTRADOR','1','GENERAL','','','ACTIVO','" & Form_login.DateTimePicker1.Text & "','1','1','CORDOBA','1','VILLA MARIA')", conex)
            'coman.ExecuteNonQuery()

            'If aa(2) = "" Then
            'loc = "VILLA MARIA"
            'Else
            'loc = aa(2)
            'End If

            'If aa(3) = "" Then
            'loc = "CORDOBA"
            'Else
            'loc = aa(3)
            'End If

            'If aa(4) = "" Then
            'tel = ""
            'Else
            'tel = aa(4)
            'End If

            'If aa(6) = "" Then
            'mail = ""
            'Else
            'mail = aa(6)
            'End If

            'If aa(5) = "" Then
            'obs = ""
            'Else
            'obs = aa(5) & " - " & aa(7)
            'End If

            'coman = New SqlCommand("INSERT INTO cli_01(id_cli,nombre,direccion,tipo_cliente,localidad,cod_postal,telefono,fax,mail,tipo_iva,cuit,ing_brutos,vendedor,nom_vendedor,cod_list,nom_lista,rubro,observaciones,estado,fecha,num_loc,id_prov,provincia,id_zona,zona) VALUES('" & num & "' , '" & aa(0) & "', '" & aa(1) & "', 'Proveedor', '" & loc & "', '5900', '" & tel & "','','" & mail & "','Consumidor Final', '00-00000000-0', '', '1','MOSTRADOR','1','GENERAL','','" & obs & "','ACTIVO','" & Form_login.DateTimePicker1.Text & "','1','1','CORDOBA','1','VILLA MARIA')", conex)
            'coman.ExecuteNonQuery()

            'num = num + 1

            'tt.Clear()

            'comando = New SqlDataAdapter("select nombre from cli_01 where id_cli = '" & RTrim(aa(0)) & "'", conex)
            'comando.Fill(tt)

            'coman = New SqlCommand("INSERT INTO cta_cte01(id_cta,cli,tc,lt,pre,num_fact,id_cli,fecha_emi,fecha_vto,debito,credito,confirma,estado,cod_vend) VALUES('" & aa(3) & "' , '" & tt.Rows(0).Item(0) & "', 'FC','" & aa(4) & "', '99', '" & aa(3) & "', '" & aa(0) & "', '" & aa(1) & "','" & aa(2) & "','" & aa(5) & "', '', 'P', 'DEBE','1')", conex)
            'coman.ExecuteNonQuery()

            'coman.Dispose()

            'End While

            'conex.Close()
            'Exit Sub

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.cmd_inicia.Enabled = False
            Me.cmd_inicia.BackColor = Color.LightGray

            If tbl.Rows.Count = Nothing Then

                xx.instruccion = "insert into pda(enviar,recibir,directorio,lista,vendedor,nom_vend,nom_list) values ('" & Me.txt_enviar.Text & "','" & Me.txt_recibir.Text & "','" & Me.txt_directorio.Text & "','" & Me.txt_lista.Text & "','" & Me.txt_vendedor.Text & "','" & Me.lbl_vendedor.Text & "','" & Me.lbl_lista.Text & "')"
                xx.abm()

                MessageBox.Show("Comfiguracion Cargada !!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.Close()

            Else

                'elimina datos de la pc
                t.Clear()

                conex = conecta()

                comando = New SqlDataAdapter("select recibir from pda", conex)
                comando.Fill(t)

                If Me.Check_enviar.Checked = True Then Call genera_items_pda()

                If Me.Check_recibir.Checked = True Then Call genera_items_remoto()

            End If

        Catch ex As Exception

            MessageBox.Show("comprobante :" & x(3) & " - " & x(2) & " - " & x(1) & " - " & x(0) & " - " & x(4), "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

            trans.Rollback()

        Finally

            Me.txt_carga.Text = ""
            Me.lbl_nombre_carga.Text = ""

            Me.cmd_inicia.Enabled = True
            Me.cmd_inicia.BackColor = Color.Black

        End Try

    End Sub

    Private Sub Form_trans_pda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_enviar.Focus()

        Try

            conex = conecta()

            comando = New SqlDataAdapter("select enviar,recibir,directorio,lista,nom_list,vendedor,nom_vend from pda", conex)
            comando.Fill(tbl)

            Me.txt_enviar.Text = tbl.Rows(0).Item(0)
            Me.txt_recibir.Text = tbl.Rows(0).Item(1)
            Me.txt_directorio.Text = tbl.Rows(0).Item(2)
            Me.txt_lista.Text = tbl.Rows(0).Item(3)
            Me.lbl_lista.Text = tbl.Rows(0).Item(4)
            Me.txt_vendedor.Text = tbl.Rows(0).Item(5)
            Me.lbl_vendedor.Text = tbl.Rows(0).Item(6)

            fact.carga_parametro()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_enviar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_enviar.KeyDown

        If e.KeyCode = Keys.F10 Then

            Me.txt_directorio.ReadOnly = False
            Me.txt_directorio.BackColor = Color.White
            Me.txt_enviar.ReadOnly = False
            Me.txt_enviar.BackColor = Color.White
            Me.txt_recibir.ReadOnly = False
            Me.txt_recibir.BackColor = Color.White
            Me.txt_lista.ReadOnly = False
            Me.txt_lista.BackColor = Color.White
            Me.txt_lista.Enabled = True

        End If

        If e.KeyCode = Keys.F12 Then

            Dim a As Integer = MessageBox.Show("Esta segurto de borrar", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If a = 6 Then

                xx.instruccion = "delete from pda"
                xx.abm()
                Me.Close()

            End If

        End If

    End Sub

    Private Sub genera_items_remoto()

        If Me.txt_carga.Enabled = True And Me.lbl_nombre_carga.Text = "" Then
            MessageBox.Show("Seleccione una carga!!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txt_carga.Focus()
            Me.txt_carga.SelectAll()
            Exit Sub
        End If

        Call ingresa_clientes()
        Call ingresa_pedidos()
        Call ingresa_recibos()
        Call ingresa_cobros()
        Call ingresa_productos_masivos()

        For Each fichero As String In Directory.GetFiles(t.Rows(0).Item(0) + "\" + Me.txt_vendedor.Text, "*.txt")
            File.Delete(fichero)
        Next

        'File.Delete(t.Rows(0).Item(0) + Me.txt_vendedor.Text + "\cli01.txt")
        'File.Delete(t.Rows(0).Item(0) + Me.txt_vendedor.Text + "\ped*.txt")
        'File.Delete(t.Rows(0).Item(0) + Me.txt_vendedor.Text + "\comp01.txt")
        'File.Delete(t.Rows(0).Item(0) + Me.txt_vendedor.Text + "\cobro01.txt")
        'File.Delete(t.Rows(0).Item(0) + Me.txt_vendedor.Text + "\rec01.txt")

        If mensaje = True Then
            MessageBox.Show("Proceso terminado correctamente !!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If mensaje = False Then
            MessageBox.Show("Proceso terminado con Errores !!", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub

    Private Sub genera_items_pda()

        Dim i As Integer
        Dim tbl2 As DataTable, tbl3 As DataTable, tbl4 As New DataTable

        conex = conecta()

        If Me.Check_cliente.Checked = True Then

            Me.lbl_nom.Text = "cliente.txt"

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select id_cli,nombre,direccion,tipo_iva,telefono,localidad,vendedor,cod_list,rubro,estado,cuit,ing_brutos from cli_01 where vendedor = '" & Me.txt_vendedor.Text & "' and tipo_cliente ='Cliente'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "cliente.txt")

            For i = 0 To tbl2.Rows.Count - 1

                If tbl2.Rows(i).Item(10) = "" Then tbl2.Rows(i).Item(10) = "0"

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10) & "|" & tbl2.Rows(i).Item(11))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        If Me.chk_proveedores.Checked = True Then

            Me.lbl_nom.Text = "proveedores.txt"

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select id_cli,nombre,direccion,tipo_iva,telefono,localidad,vendedor,cod_list,rubro,estado,cuit,ing_brutos from cli_01 where vendedor = '" & Me.txt_vendedor.Text & "' and tipo_cliente ='Proveedor'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "proveedor.txt")

            For i = 0 To tbl2.Rows.Count - 1

                If tbl2.Rows(i).Item(10) = "" Then tbl2.Rows(i).Item(10) = "0"

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10) & "|" & tbl2.Rows(i).Item(11))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        If Me.Check_producto.Checked = True Then

            Me.lbl_nom.Text = "producto.txt"

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select id_art1,nombre,cantidad,precio_siva,precio_civa,iva_insc,impuestos,iva,exento,rubro,costo from art_01 inner join art_precio on art_01.id_art = art_precio.id_art1 and art_01.estado = 'Activo' and art_precio.id_lista1 = '" & RTrim(Me.txt_lista.Text) & "'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "producto.txt")

            For i = 0 To tbl2.Rows.Count - 1

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()
            tbl2.Dispose()

        End If

        If Me.Check_cta_cte.Checked = True Then

            Me.lbl_nom.Text = "cta cte.txt"

            '' actualizo la cuenta corriente del vendedor redondeando los importes
            '' antes de enviar los datos al txt

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
            End If

            coman = New SqlCommand("update cta_cte01 set debito = floor(debito),credito = floor(credito) where cod_vend = " & Trim(Me.txt_vendedor.Text) & "", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If

            conex = conecta()

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select distinct id_cli,cli,tc,lt,pre,num_fact,debito,credito,fecha_emi,fecha_vto,estado,confirma,cod_vend from cta_cte01 where estado = 'DEBE' and cod_vend = '" & RTrim(Me.txt_vendedor.Text) & "' order by cli ASC", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "cta cte.txt")

            For i = 0 To tbl2.Rows.Count - 1

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2) & "|" & tbl2.Rows(i).Item(3) & "|" & tbl2.Rows(i).Item(4) & "|" & tbl2.Rows(i).Item(5) & "|" & tbl2.Rows(i).Item(6) & "|" & tbl2.Rows(i).Item(7) & "|" & tbl2.Rows(i).Item(8) & "|" & tbl2.Rows(i).Item(9) & "|" & tbl2.Rows(i).Item(10) & "|" & tbl2.Rows(i).Item(11) & "|" & tbl2.Rows(i).Item(12))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        If Me.Check_stock.Checked = True Then

            Me.lbl_nom.Text = "stock.txt"

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select id_art,nombre,cantidad from art_01 where estado = 'Activo'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "stock.txt")

            For i = 0 To tbl2.Rows.Count - 1

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1) & "|" & tbl2.Rows(i).Item(2))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        If Me.Check_rubro.Checked = True Then

            Me.lbl_nom.Text = "Rubros.txt"

            tbl3 = New DataTable

            comando = New SqlDataAdapter("select id_rubro,nombre from rub_01", conex)
            comando.Fill(tbl3)
            comando.Dispose()

            Dim sw1 As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "rubro.txt")

            For i = 0 To tbl3.Rows.Count - 1

                sw1.WriteLine(tbl3.Rows(i).Item(0) & "|" & tbl3.Rows(i).Item(1))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw1.Close()
            tbl3.Dispose()

        End If

        If Me.Check_usuario.Checked = True Then

            Me.lbl_nom.Text = "usuario.txt"

            tbl2 = New DataTable

            comando = New SqlDataAdapter("select id_vendedor,nombre from vend_01 where id_vendedor = '" & Me.txt_vendedor.Text & "'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "usuario.txt")

            For i = 0 To tbl2.Rows.Count - 1

                sw.WriteLine(tbl2.Rows(i).Item(0) & "|" & tbl2.Rows(i).Item(1))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        If Me.chk_pedido_prov.Checked = True Then

            Me.lbl_nom.Text = "pedido_prov.txt"

            tbl4.Clear()

            comando = New SqlDataAdapter("select fec_emi,fec_hasta,nombre,cantidad,proveedor from pedido_01", conex)
            comando.Fill(tbl4)
            comando.Dispose()

            Dim sw As New IO.StreamWriter(Me.txt_enviar.Text & "\" & Me.txt_vendedor.Text & "\" & "pedido_prov.txt")

            For i = 0 To tbl4.Rows.Count - 1

                sw.WriteLine(tbl4.Rows(i).Item(0) & "|" & tbl4.Rows(i).Item(1) & "|" & tbl4.Rows(i).Item(2) & "|" & tbl4.Rows(i).Item(3) & "|" & tbl4.Rows(i).Item(4))
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                Application.DoEvents()
                Me.lbl_prog.Text = Me.ProgressBar1.Value

            Next

            sw.Close()

        End If

        Me.Close()

    End Sub

    Private Sub Check_enviar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_enviar.CheckedChanged

        If Me.Check_enviar.Checked = True Then
            Me.txt_recibir.Enabled = False
            Me.txt_recibir.BackColor = Color.LightGray
            Me.Check_recibir.Enabled = False

            Me.txt_enviar.Focus()

        End If

        If Me.Check_enviar.Checked = False Then
            Me.txt_recibir.Enabled = True
            Me.txt_recibir.BackColor = Color.White
            Me.Check_recibir.Enabled = True

        End If

    End Sub

    Private Sub Check_recibir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_recibir.CheckedChanged

        If Me.Check_recibir.Checked = True Then
            Me.txt_enviar.Enabled = False
            Me.txt_enviar.BackColor = Color.LightGray
            Me.Check_enviar.Enabled = False

            Me.GroupBox2.Enabled = False
            Me.txt_recibir.Focus()

            If fact.pide_n_carga = "SI" Then
                Me.txt_carga.Enabled = True
            Else
                Me.txt_carga.Enabled = False
            End If

        End If

        If Me.Check_recibir.Checked = False Then
            Me.txt_enviar.Enabled = True
            Me.txt_enviar.BackColor = Color.White
            Me.Check_enviar.Enabled = True

            Me.GroupBox2.Enabled = True

            If Me.txt_carga.Enabled = True Then
                Me.txt_carga.Enabled = False
                Me.txt_carga.Text = ""
                Me.lbl_nombre_carga.Text = ""
            End If

        End If

    End Sub


    Private Sub txt_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub carga_vendedor()
        zzz.instruccion = "select *from vend_01 where id_vendedor like '" & Me.txt_vendedor.Text & "'"
        zzz.codigo_vend = "id_vendedor"
        zzz.nombre_vend = "nombre"
        zzz.cargar_vendedor()
        Me.txt_vendedor.Text = zzz.text
        Me.lbl_vendedor.Text = zzz.text2
        Me.dt_fecha_caja.Focus()
    End Sub

    Private Sub txt_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_vendedor.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_vendedor.Show()

        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            Call carga_vendedor()

        End If

    End Sub

    Private Sub txt_lista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lista.KeyDown

        If e.KeyCode = Keys.F1 Then

            busc_lista.Show()

        End If

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            Call carga_sucursal()

        End If

    End Sub

    Private Sub carga_sucursal()
        xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_lista.Text & "'"
        xxx.codigo = "id_lis"
        xxx.nombre = "nombre"
        xxx.cargar()
        Me.txt_lista.Text = xxx.text
        Me.lbl_lista.Text = xxx.text2
        Me.txt_vendedor.Focus()
    End Sub

    Private Sub ingresa_clientes()

        If File.Exists(Me.txt_recibir.Text & "\" & "cli01.txt") Then

            Dim tbl3 As New DataTable

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & "cli01.txt")

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
                trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
            End If

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                tbl3.Clear()

                comando = New SqlDataAdapter("select *from cli_01 where id_cli = '" & RTrim(x(0)) & "'", conex)
                comando.SelectCommand.Transaction = trans
                comando.Fill(tbl3)

                If tbl3.Rows.Count = Nothing Then

                    coman = New SqlCommand("insert into cli_01(id_cli,nombre,direccion,tipo_cliente,cod_postal,localidad,telefono,tipo_iva,cuit,ing_brutos,vendedor,cod_list,rubro,estado) values ('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','" & x(7) & "','" & x(8) & "','" & x(9) & "','" & x(10) & "','" & x(11) & "','" & x(12) & "','" & x(13) & "')", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()

                    coman.Dispose()

                End If

            End While

            trans.Commit()

            conex.Close()

            sr.Close()
            sr.Dispose()
            tbl3.Dispose()
            File.Delete(Me.txt_recibir.Text & "\" & "cli01.txt")

        End If
      
    End Sub

    Private Sub seleciona_letra_cliente()

        ' SELECCIO EL CLIENTE DEL TXT
        comando = New SqlDataAdapter("select id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,ing_brutos,nom_lista,cod_list from cli_01 where id_cli = '" & x(14) & "'", conex)
        comando.SelectCommand.Transaction = trans
        comando.Fill(ttb)

        ' VERIFICO EL TIPO DE CLIENTE PARA COLOCOAR LA LETRA
        If RTrim(fact.factura_en_c) = "SI" Then
            letra = "C"
        Else
            If RTrim(ttb.Rows(0).Item(2)) = "Responsable Inscripto" Then
                letra = "A"
            Else
                letra = "B"
            End If
        End If

    End Sub

    Private Sub ingresa_pedidos()

        Dim pos As Integer

        Try

            Dim di As DirectoryInfo = New DirectoryInfo(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\")
            Dim fi As Object
            Dim cadena As String = ""

            For Each fi In di.GetFiles("ped*.txt")

                existe_pedido = "S"

                Dim lt As String, valor, tc As String, fec As String = "", comentario As String
                Dim num As Integer, pre As Integer, talon As Integer
                Dim tbl1 As New DataTable, tb_dat As New DataTable
                Dim total As Double, iva_ins As Double, iva_10 As Double, imp As Double, exento As Double, sub_tot As Double, total_cobro As Double
                Dim i As Integer, z As Integer

                conex = conecta()

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                End If

                'fact.carga_parametro()

                sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & fi.ToString)   'lee cabecera pedido

                While sr.EndOfStream = False

                    x = Split(sr.ReadLine, "|")

                    Call seleciona_letra_cliente()

                    ' VERIFICO QUE LA FACTURA SE CARGUE UNA VEZ EN LA CABECERA
                    comando = New SqlDataAdapter("select distinct num_fact1,tipo_fact,prefijo_fact,letra_fact from fact_cab where num_fact1 = '" & x(0) & "' and prefijo_fact = '" & x(1) & "' and letra_fact = '" & letra & "' and tipo_fact = '" & x(3) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl1)
                    comando.Dispose()

                    If tbl1.Rows.Count = Nothing Then

                        If RTrim(x(3)) = "PD" Then
                            forma_pago = "Contado"
                            pago = "PAGADO"
                        End If

                        coman = New SqlCommand("INSERT INTO fact_cab(num_fact1,prefijo_fact,letra_fact,tipo_fact,id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,ing_bruto1,lista,forma_pago,estado_fact,id_lista,talon,arqueo,pago,fec_emision,fec_vto) VALUES('" & x(0) & "','" & x(1) & "','" & letra & "','" & x(3) & "','" & ttb.Rows(0).Item(0) & "','" & ttb.Rows(0).Item(1) & "','" & ttb.Rows(0).Item(2) & "','" & ttb.Rows(0).Item(3) & "','" & ttb.Rows(0).Item(4) & "','" & ttb.Rows(0).Item(5) & "','" & ttb.Rows(0).Item(6) & "','" & ttb.Rows(0).Item(7) & "','" & ttb.Rows(0).Item(8) & "','" & forma_pago & "','Activo','" & ttb.Rows(0).Item(9) & "','" & x(17) & "','B','" & pago & "','" & x(16) & "','" & x(16) & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    Else

                        If z = 0 Then
                            MessageBox.Show("Existen Pedidos duplicados,Verifique....!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            z = z + 1
                            Exit Sub
                        End If

                    End If

                    ttb.Clear()
                    tbl1.Clear()
                    z = z + 1

                End While

                sr.Close()
                sr.Dispose()

                sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & fi.ToString) 'lee cabecera pedido
                fila_det = 0

                While sr.EndOfStream = False

                    x = Split(sr.ReadLine, "|")

                    Call seleciona_letra_cliente()

                    pos = pos + 1

                    comando = New SqlDataAdapter("select id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,ing_brutos,nom_lista,cod_list from cli_01 where id_cli = '" & x(14) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(ttb)
                    comando.Dispose()

                    comando = New SqlDataAdapter("select id_rubro,id_proveedor from art_01 where id_art = '" & RTrim(x(15)) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tb_dat)
                    comando.Dispose()

                    If RTrim(fact.mueve_stock) = "SI" Then
                        valor = "SI"
                    Else
                        valor = "NO"
                    End If

                    If RTrim(x(11)) = "10" Then x(11) = "10.5"

                    coman = New SqlCommand("INSERT INTO fact_det(fec_emi,num_fact,prefijo_fact2,letra_fact1,tipo_fact2,codi_producto,detalle,cantidad1,descuento,iva_inscripto,imp_interno,exento1,precio_unidad,total1,iva1,precio_civa1,cod_lista,mes,año,talon1,cantidad_sin_stock,fila,costo,nom_producto,cod_rub,cod_prov,vend1,n_carga,val_uni_sec) VALUES('" & x(16) & "','" & x(0) & "','" & x(1) & "','" & letra & "','" & x(3) & "','" & x(15) & "','" & x(4) & "','" & x(5) & "','" & x(8) & "','" & x(12) & "','" & x(9) & "','" & x(10) & "','" & x(6) & "','" & x(13) & "','" & x(11) & "','" & x(7) & "','" & ttb.Rows(0).Item(9) & "','" & Date.Now.Month & "', '" & Date.Now.Year & "','" & x(17) & "','" & valor & "','" & fila_det & "','" & x(20) & "','" & x(4) & "','" & tb_dat.Rows(0).Item(0) & "', '" & tb_dat.Rows(0).Item(1) & "','" & ttb.Rows(0).Item(5) & "','" & Me.txt_carga.Text & "',0)", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    ttb.Clear()
                    tb_dat.Clear()

                    filas = filas + 1
                    fila_det = fila_det + 1

                End While

                sr.Close()
                sr.Dispose()
                ttb.Dispose()
                tb_dat.Dispose()

                sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & fi.ToString)   'lee cabecera pedido

                x = Split(sr.ReadLine, "|")
                Dim j As Integer

                For j = 0 To filas - 1

                    Call seleciona_letra_cliente()

                    comando = New SqlDataAdapter("select num_factura,tipo_factura,pref,letra from fact_tot where num_factura = '" & x(0) & "' and pref = '" & x(1) & "' and letra = '" & letra & "' and tipo_factura = '" & x(3) & "' order by num_factura", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl2)
                    comando.Dispose()

                    If tbl2.Rows.Count = Nothing Then

                        comando = New SqlDataAdapter("select num_fact,tipo_fact2,prefijo_fact2,letra_fact1 from fact_det where num_fact = '" & x(0) & "' and prefijo_fact2 = '" & x(1) & "' and letra_fact1 = '" & letra & "' and tipo_fact2 = '" & x(3) & "' order by num_fact", conex)
                        comando.SelectCommand.Transaction = trans
                        comando.Fill(tbl1)
                        comando.Dispose()

                        comando = New SqlDataAdapter("select id_cli,nombre,tipo_iva,cuit,direccion,vendedor,nom_vendedor,ing_brutos,nom_lista,cod_list from cli_01 where id_cli = '" & x(14) & "'", conex)
                        comando.SelectCommand.Transaction = trans
                        comando.Fill(ttb)
                        comando.Dispose()

                        num = x(0)
                        pre = x(1)
                        lt = letra
                        tc = x(3)

                        For i = 0 To tbl1.Rows.Count - 1

                            total = total + x(13)
                            imp = imp + x(9)
                            exento = exento + x(10)
                            If RTrim(x(11)) = "21" Then iva_ins = iva_ins + x(12)
                            If RTrim(x(11)) = "10.5" Then iva_10 = iva_10 + x(12)
                            sub_tot = sub_tot + (x(6) * x(5))
                            fec = x(16)
                            talon = x(17)
                            comentario = x(21)

                            If i > 0 Then j = j + 1

                            x = Split(sr.ReadLine, "|")

                        Next

                        If RTrim(tc) = "PD" Then total_cobro = total

                        If RTrim(fact.factura_en_c) = "SI" Then
                            lt = "C"
                        End If

                        coman = New SqlCommand("INSERT INTO fact_tot(num_factura,pref,letra,tipo_factura,id_cliente,nombre_cli,total,iva_ins,exento,imp_interno1,iva_10,sub_total,fecha_emision1,descuento,total_cobro,talon2,efectivo,comentario) VALUES('" & num & "','" & pre & "','" & lt & "','" & tc & "','" & ttb.Rows(0).Item(0) & "','" & ttb.Rows(0).Item(1) & "','" & total & "', '" & iva_ins & "', '" & exento & "','" & imp & "', '" & iva_10 & "','" & sub_tot & "','" & fec & "','0','" & total_cobro & "','" & talon & "','SI','" & comentario & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        tbl1.Clear()
                        ttb.Clear()
                        total = 0
                        imp = 0
                        exento = 0
                        iva_ins = 0
                        iva_10 = 0
                        sub_tot = 0

                    End If

                    tbl2.Clear()

                Next

                trans.Commit()

                conex.Close()

                sr.Close()
                cadena = fi.ToString().Substring(0, 3)
                IO.File.Delete(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & fi.ToString)

            Next

            If existe_pedido = "N" Then
                MessageBox.Show("No se encontro ningun pedido !!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Mensaje" & pos, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally

        End Try

    End Sub

    Private Sub ingresa_recibos()

        If File.Exists(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt") Then

            Dim tbl1a As New DataTable, tblb As New DataTable, tbl2a As New DataTable, tbl3 As New DataTable, t_ven As New DataTable, valida_cta_cte As New DataTable, tb_sale As New DataTable, tb_max As New DataTable
            Dim z As Integer
            Dim saldo As Double

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            Dim xx As Integer = MessageBox.Show("Se estan recibiendo recibos..¿Desea Imprimirlos?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            ' RECIBO CABECERA

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt")   'lee cabecera recibo

            While sr.EndOfStream = False

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                End If

                x = Split(sr.ReadLine, "|")

                talon_cobro = x(18)

                tb_max.Clear()

                ' verifico que no exista el recibo en la cabecera
                comando = New SqlDataAdapter("select distinct id_rec,pre,tc,letra from recibo_cab where id_rec = '" & x(0) & "' and pre = '" & x(1) & "' and tc = '" & x(2) & "' and letra = '" & x(3) & "'", conex)
                comando.Fill(tbl1a)
                comando.Dispose()

                ' verifico que en error_cta_cte no haya nada ingresado igual al numero del recibo
                comando = New SqlDataAdapter("select * from error_cta_cte where numero = '" & x(0) & "' and pre = '" & x(1) & "' and tc = '" & x(2) & "' and lt = '" & x(3) & "' and pc = '" & My.Computer.Name & "'", conex)
                comando.Fill(tb_sale)
                comando.Dispose()

                'actualiza el hist. de la cta cte 
                coman = New SqlCommand("update cta_cte_hist set estado = 'PAGADO' where num = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "' and id_cli = '" & x(4) & "'", conex)
                coman.ExecuteNonQuery()
                coman.Dispose()

                If tbl1a.Rows.Count = Nothing And tb_sale.Rows.Count = Nothing Then

                    ' verifica que las ctas ctes no se hayan modificado manualmente en el sistema antes de ser actualizadas

                    valida_cta_cte.Clear()

                    If RTrim(x(9)) = "FC" Or RTrim(x(9)) = "ND" Then ' si es factura leo el debito para comparar

                        comando = New SqlDataAdapter("select debito,credito from cta_cte01 where num_fact = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "'", conex)
                        comando.Fill(valida_cta_cte)
                        comando.Dispose()

                        If valida_cta_cte.Rows.Count = Nothing Then

                            sale = False
                            Call error_cta_cte()

                        Else

                            If Trim(valida_cta_cte.Rows(0).Item(0)) <> Trim(Val(x(14))) Then
                                sale = False
                                Call error_cta_cte()
                            Else
                                sale = True
                            End If

                        End If

                    End If

                    If RTrim(x(9)) = "NC" Or RTrim(x(9)) = "RA" Then ' si es n. credito leo el debito para comparar

                        comando = New SqlDataAdapter("select debito,credito from cta_cte01 where num_fact = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "'", conex)
                        comando.Fill(valida_cta_cte)
                        comando.Dispose()

                        If RTrim(valida_cta_cte.Rows(0).Item(1)) <> RTrim(x(14)) Then
                            sale = False
                            Call error_cta_cte()
                        Else
                            sale = True
                        End If

                    End If

                    '  Ingresa cabecera recibo siempre que no se hayan modificado las ctas ctes   

                    If sale = True Then

                        comando = New SqlDataAdapter("select nombre,direccion from cli_01 where id_cli = '" & x(4) & "'", conex)
                        comando.Fill(tblb)
                        comando.Dispose()

                        comando = New SqlDataAdapter("select id_vendedor,nombre from vend_01 where id_vendedor = '" & x(21) & "'", conex)
                        comando.Fill(t_ven)
                        comando.Dispose()

                        coman = New SqlCommand("INSERT INTO recibo_cab(id_rec,pre,tc,letra,id_cli,fec_emi,fec_vto,nombre,direccion,saldo_ant,arqueo,talon,p_venta2,pago,cod_vendedor,nom_vendedor) VALUES('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','" & tblb.Rows(0).Item(0) & "','" & tblb.Rows(0).Item(1) & "','','B','" & x(18) & "','" & x(1) & "','PAGADO','" & t_ven.Rows(0).Item(0) & "','" & t_ven.Rows(0).Item(1) & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        coman = New SqlCommand("INSERT INTO cta_cte_hist(num,pre,tc,lt,debito,credito,estado,fec,id_cli,cli) VALUES('" & x(0) & "','" & x(1) & "', '" & x(2) & "','" & x(3) & "','','" & x(15) & "','PAGADO','" & x(5) & "','" & x(4) & "' , '" & tblb.Rows(0).Item(0) & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                Else

                    If z = 0 Then
                        MessageBox.Show("Existen recibos duplicados,Verifique....!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        z = z + 1
                        mensaje = False
                        Exit Sub
                    End If

                End If

                tbl1a.Clear()
                tblb.Clear()
                tb_sale.Clear()
                t_ven.Clear()
                z = z + 1

            End While

            sr.Close()
            sr.Dispose()

            ' RECIBO DETALLE

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt")   'lee cabecera pedido

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                ' comparo para saber si ingreso  o no la cta cte por si no coinside
                tb_error.Clear()

                comando = New SqlDataAdapter("select * from error_cta_cte where numero = '" & x(0) & "' and pre = '" & x(1) & "' and tc = '" & x(2) & "' and lt = '" & x(3) & "' and pc = '" & My.Computer.Name & "'", conex)
                comando.Fill(tb_error)
                comando.Dispose()

                If tb_error.Rows.Count = Nothing Then

                    coman = New SqlCommand("INSERT INTO recibo_det(id_det,pre1,tc1,letra_01,id_cli01,fecha,num_fact,pre_fact,tipo_fact,letra_fact,descripcion,cancelado,total,talon1,p_venta1) VALUES('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(5) & "','" & x(7) & "','" & x(8) & "','" & x(9) & "','" & x(10) & "','" & x(11) & "','" & x(13) & "','" & x(14) & "','" & x(18) & "','" & x(1) & "')", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    If RTrim(x(9)) = "FC" And RTrim(x(20)) = "PAGADO" Or RTrim(x(9)) = "NC" And RTrim(x(20)) = "PAGADO" Or RTrim(x(9)) = "RA" And RTrim(x(20)) = "PAGADO" Or RTrim(x(9)) = "ND" And RTrim(x(20)) = "PAGADO" Then

                        coman = New SqlCommand("delete cta_cte01 where id_cta = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                    If (RTrim(x(9)) = "FC" And RTrim(x(20)) = "DEBE") Or (RTrim(x(9)) = "ND" And RTrim(x(20)) = "DEBE") Then

                        saldo = Format(x(14) - x(13), "0.00")

                        coman = New SqlCommand("delete cta_cte01 where id_cta = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        coman = New SqlCommand("insert into cta_cte01(id_cta,cli,tc,lt,pre,num_fact,id_cli,fecha_emi,fecha_vto,debito,credito,estado,confirma,cod_vend) values('" & x(7) & "','" & x(11) & "','" & x(9) & "','" & x(10) & "','" & x(8) & "','" & x(7) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','" & saldo & "','','DEBE','P','" & x(21) & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                    If (RTrim(x(9)) = "NC" And RTrim(x(20)) = "DEBE") Or (RTrim(x(9)) = "RA" And RTrim(x(20)) = "DEBE") Then

                        If RTrim(x(9)) <> "RA" Then
                            saldo = Format(x(14) - x(13), "0.00")
                        Else
                            saldo = Format(x(14))
                        End If

                        coman = New SqlCommand("delete cta_cte01 where id_cta = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "'", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                        coman = New SqlCommand("insert into cta_cte01(id_cta,cli,tc,lt,pre,num_fact,id_cli,fecha_emi,fecha_vto,debito,credito,estado,confirma,cod_vend) values('" & x(7) & "','" & x(11) & "','" & x(9) & "','" & x(10) & "','" & x(8) & "','" & x(7) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','','" & saldo & "','DEBE','P','" & x(21) & "')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

            End While

            sr.Close()
            sr.Dispose()

            ' RECIBO TOTAL

            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt")   'lee cabecera pedido

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                ' comparo para saber si ingreso  o no la cta cte por si no coinside
                tb_error.Clear()

                comando = New SqlDataAdapter("select * from error_cta_cte where numero = '" & x(0) & "' and pre = '" & x(1) & "' and tc = '" & x(2) & "' and lt = '" & x(3) & "' and pc = '" & My.Computer.Name & "'", conex)
                comando.Fill(tb_error)
                comando.Dispose()

                If tb_error.Rows.Count = Nothing Then

                    comando = New SqlDataAdapter("select id_tot,pre2,tip,lt from recibo_tot where id_tot = '" & x(0) & "' and pre2 = '" & x(1) & "' and tip = '" & x(2) & "' and lt = '" & x(3) & "' order by id_tot", conex)
                    comando.Fill(tbl2a)
                    comando.Dispose()

                    If tbl2a.Rows.Count = Nothing Then

                        coman = New SqlCommand("INSERT INTO recibo_tot(id_tot,pre2,tip,lt,id_cliente,total,total_cobro,efectivo,fec_emi1,talon2,p_venta,pago) VALUES('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(15) & "','" & x(16) & "', 'SI', '" & x(5) & "','" & x(18) & "', '" & x(1) & "','PAGADO')", conex)
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                    tbl2a.Clear()

                    mensaje = True

                Else

                    mensaje = False

                End If

            End While

            ' imprime recibos

            sr.Close()
            sr.Dispose()

            If xx = 6 Then

                Dim num As Integer = 0

                sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt")   'lee cabecera recibo

                While sr.EndOfStream = False

                    x = Split(sr.ReadLine, "|")

                    If x(0) <> num Then

                        fact.imprime_recibo(x(3), x(0), x(1), x(15), 2)
                        num = x(0)

                    End If

                End While

            End If

            sr.Close()
            sr.Dispose()

            File.Delete(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "rec01.txt")

            If conex.State = ConnectionState.Closed Then
                conex.Open()
            End If

            coman = New SqlCommand("delete error_cta_cte", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            conex.Close()

        End If

    End Sub

    Private Sub ingresa_cobros()

        If File.Exists(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "cobro01.txt") Then

            Dim tbl8 As New DataTable, tbl9 As New DataTable, tbl10 As New DataTable, tbl11 As New DataTable
            sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "cobro01.txt")

            conex = conecta()

            If conex.State = ConnectionState.Closed Then
                conex.Open()
                trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
            End If

            While sr.EndOfStream = False

                x = Split(sr.ReadLine, "|")

                If RTrim(x(11)) = "cheque" Then

                    carga_codigo_banco(x(7))

                    tbl8.Clear()

                    comando = New SqlDataAdapter("select * from cheque_01 where id_cheque = '" & Trim(x(0)) & "' and prefijo = '" & x(1) & "' and tc = '" & x(2) & "' and lt = '" & x(3) & "' and numero = '" & x(0) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl8)
                    comando.Dispose()

                    If tbl8.Rows.Count = Nothing Then

                        coman = New SqlCommand("insert into cheque_01(id_cheque,prefijo,tc,lt,fec_emi,fec_acred,detalle,banco,total,modo,p_venta,numero,estado,talon,cod_banco) values ('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(5) & "','" & x(6) & "','" & x(7) & "','" & x(8) & "','" & x(9) & "','" & x(1) & "','" & x(0) & "','I','" & talon_cobro & "','" & cod_bco & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

                If RTrim(x(11)) = "ticket" Then

                    tbl9.Clear()

                    comando = New SqlDataAdapter("select *from ticket_01 where id_tiket = '" & Trim(x(0)) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl9)
                    comando.Dispose()

                    If tbl9.Rows.Count = Nothing Then

                        coman = New SqlCommand("insert into ticket_01(id_tiket,prefijo,tc,lt,fec_emi,detalle,total,modo,p_venta,numero,estado,talon) values ('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(6) & "','" & x(8) & "','" & x(9) & "','" & x(1) & "','" & x(12) & "','I','" & talon_cobro & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

                If RTrim(x(11)) = "t.credito" Then

                    tbl10.Clear()

                    comando = New SqlDataAdapter("select *from t_credito where id_credito = '" & Trim(x(0)) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl10)
                    comando.Dispose()

                    If tbl10.Rows.Count = Nothing Then

                        coman = New SqlCommand("insert into t_credito(id_credito,prefijo,tc,lt,f_emi,cli_01,importe,modo,p_venta,numero,estado,talon) values ('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(6) & "','" & x(8) & "','" & x(9) & "','" & x(1) & "','" & x(12) & "','I','" & talon_cobro & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

                If RTrim(x(11)) = "t.debito" Then

                    tbl11.Clear()

                    comando = New SqlDataAdapter("select *from t_debito where id_debito = '" & Trim(x(0)) & "'", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl11)
                    comando.Dispose()

                    If tbl11.Rows.Count = Nothing Then

                        coman = New SqlCommand("insert into t_debito(id_debito,prefijo,tc,lt,fecha,cliente,importe,modo,p_venta,numero,estado,talon) values ('" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(4) & "','" & x(6) & "','" & x(8) & "','" & x(9) & "','" & x(1) & "','" & x(12) & "','I','" & talon_cobro & "')", conex)
                        coman.Transaction = trans
                        coman.ExecuteNonQuery()
                        coman.Dispose()

                    End If

                End If

            End While

            trans.Commit()

            conex.Close()

            sr.Close()
            sr.Dispose()
            File.Delete(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & "cobro01.txt")

        End If

    End Sub

    Private Sub error_cta_cte()

        conex = conecta()

        If conex.State = ConnectionState.Closed Then
            conex.Open()
        End If
       
        coman = New SqlCommand("insert into error_cta_cte(numero,pre,tc,lt,importe,pc) values ( '" & x(0) & "','" & x(1) & "','" & x(2) & "','" & x(3) & "','" & x(15) & "','" & My.Computer.Name & "')", conex)
        coman.ExecuteNonQuery()
        coman.Dispose()

        'actualiza el hist. de la cta cte 

        coman = New SqlCommand("update cta_cte_hist set estado = 'DEBE' where num = '" & x(7) & "' and pre = '" & x(8) & "' and tc = '" & x(9) & "' and lt = '" & x(10) & "' and id_cli = '" & x(4) & "'", conex)
        coman.ExecuteNonQuery()
        coman.Dispose()

        conex.Close()

        If mensaje = True Then
            MessageBox.Show("El recibo numero: " & "  " & x(2) & " - " & x(1) & " - " & x(0) & " ---> $" & x(15) & " " & "No coincide con cta cte,..Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Function existeObjeto(ByVal dir As String) As Boolean

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential("usuario", "123")

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function

    Public Function subirarchivo(ByVal carpeta, ByVal direccion, ByVal archivo)

        Dim clsRequest As System.Net.FtpWebRequest = _
           DirectCast(System.Net.WebRequest.Create(direccion & RTrim(Me.txt_directorio.Text) & RTrim(Me.txt_vendedor.Text) & "/" & archivo), System.Net.FtpWebRequest)
        clsRequest.Credentials = New System.Net.NetworkCredential("usuario", "123")
        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        clsRequest.UsePassive = False

        ' read in file...
        Dim bFile() As Byte = System.IO.File.ReadAllBytes(carpeta)

        ' upload file...
        Dim clsStream As System.IO.Stream = _
            clsRequest.GetRequestStream()
        clsStream.Write(bFile, 0, bFile.Length)
        clsStream.Close()
        clsStream.Dispose()

        Return True

    End Function

    Public Function eliminarFichero(ByVal fichero As String) As String

        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del fichero a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(fichero)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential("usuario", "123")

        ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
        peticionFTP.UsePassive = False

        Try
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
            ' Si todo ha ido bien, devolvemos String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try

    End Function

    Private Sub txt_carga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_carga.KeyDown

        If e.KeyCode = Keys.Return Then

            xxx.instruccion = "select id,carga from carga_01 where id like '" & Trim(Me.txt_carga.Text) & "'"
            xxx.codigo = "id"
            xxx.nombre = "carga"
            xxx.cargar()

            Me.txt_carga.Text = (xxx.text)
            Me.lbl_nombre_carga.Text = Trim(xxx.text2)

            If Me.txt_carga.Text = "" Then
                Me.txt_carga.Focus()
                Exit Sub
            End If

            Me.Check_cliente.Focus()

        End If

        If e.KeyCode = Keys.F1 Then

            busc_carga.Show()

        End If

    End Sub

    Private Sub carga_codigo_banco(ByVal nombre As String)
        xxx.instruccion = "select * from bco_01 where nombre = '" & Trim(nombre) & "'"
        xxx.codigo = "id_bco"
        xxx.nombre = "nombre"
        xxx.cargar()
        cod_bco = xxx.text
    End Sub

    Private Sub ingresa_productos_masivos()

        Dim pos As Integer

        Try

            Dim di As DirectoryInfo = New DirectoryInfo(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\")
            Dim fi As Object
            Dim cadena As String = ""
            Dim max As Integer
            Dim ps, pc, ins As Double

            For Each fi In di.GetFiles("prod*.txt")

                existe_pedido = "S"
                Dim tbl1 As New DataTable, tb_dat As New DataTable

                conex = conecta()

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.RepeatableRead)
                End If

                sr = New IO.StreamReader(Me.txt_recibir.Text & "\" & Me.txt_vendedor.Text & "\" & fi.ToString)   'lee cabecera pedido

                While sr.EndOfStream = False

                    x = Split(sr.ReadLine, "|")

                    tbl1.Clear()

                    ' selecciono maximo id producto
                    comando = New SqlDataAdapter("select MAX(CONVERT(INT,id_art)) from art_01", conex)
                    comando.SelectCommand.Transaction = trans
                    comando.Fill(tbl1)
                    comando.Dispose()

                    If tbl1.Rows(0).Item(0).ToString = Nothing Then
                        max = 1
                    Else
                        max = Val(tbl1.Rows(0).Item(0)) + 1
                    End If

                    busca_nombre_rubro(x(4))
                    busca_nombre_proveedor(x(3))

                    coman = New SqlCommand("INSERT INTO art_01(id_art,nombre,codigo_barra,id_proveedor,id_rubro,cantidad,cantidad_bulto,proveedor,rubro,id_lista,lista,mueve_stok,cod_imp_compras,nom_imp_compras,cod_imp_ventas,nom_imp_ventas,fec_alta,fec_modi,estado,cant_ant,stock_corte) VALUES('" & max & "','" & Trim(x(1)) & "','" & Trim(x(2)) & "','" & Trim(x(3)) & "','" & Trim(x(4)) & "',0,1,'" & Trim(nom_prov) & "','" & Trim(nom_rub) & "','" & Trim(Me.txt_lista.Text) & "','" & Trim(Me.lbl_lista.Text) & "','SI','','','','','" & Date.Now.ToString("yyyyMMdd HH:mm:ss") & "','" & Date.Now.ToString("yyyyMMdd HH:mm:ss") & "','Activo',0,0)", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                    ps = Format(x(5) + ((x(5) * x(6)) / 100), "0.00")
                    pc = Format(ps + (ps * 0.21), "0.00")
                    ins = Format(pc - ps, "0.00")

                    coman = New SqlCommand("INSERT INTO art_precio(id_art1,nom,id_lista1,costo,id_iva,iva,cod_imp,impuestos,utilidad,precio_siva,precio_civa,iva_insc,exento,cod,estado1,desc1,desc2,desc3,flete,pago_total) VALUES('" & max & "','" & Trim(x(1)) & "','" & Trim(Me.txt_lista.Text) & "','" & Trim(x(5)) & "',1,21,0,0,'" & Trim(x(6)) & "','" & Trim(ps) & "','" & Trim(pc) & "','" & Trim(ins) & "',0,'" & max & "','Activo',0,0,0,0,0)", conex)
                    coman.Transaction = trans
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                End While

                trans.Commit()

                sr.Close()
                sr.Dispose()

            Next

        Catch ex As Exception

            trans.Rollback()
            MessageBox.Show(ex.Message, "Mensaje" & pos, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally

        End Try

    End Sub

    Private Sub busca_nombre_rubro(ByVal id As Integer)

        xxx.instruccion = "select id_rubro,nombre from rub_01 where id_rubro = '" & id & "'"
        xxx.codigo = "id_rubro"
        xxx.nombre = "nombre"
        xxx.cargar()

        nom_rub = xxx.text2

    End Sub

    Private Sub busca_nombre_proveedor(ByVal id As Integer)

        xxx.instruccion = "select id_cli,nombre from cli_01 where id_cli = '" & id & "'"
        xxx.codigo = "id_cli"
        xxx.nombre = "nombre"
        xxx.cargar()

        nom_prov = xxx.text2

    End Sub

End Class