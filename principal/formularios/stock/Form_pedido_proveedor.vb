Imports System.Data
Imports System.Data.SqlClient

Public Class Form_pedido_proveedor

    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim tbl1 As New DataTable, tbl As New DataTable, tblxx As New DataTable
    Dim i As Integer

    Private Sub Form_pedido_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        Me.cmb_prove.Text = Me.cmb_prove.Items(0)
        Me.dt_fec_desde.Text = Date.Now

        conex = conecta()
        tbl1.Clear()
        Me.cmb_prove.Items.Clear()

        comando = New SqlDataAdapter("select nombre,id_cli from cli_01 where tipo_cliente = 'Proveedor' ORDER BY nombre ASC", conex)
        comando.Fill(tbl1)

        For i = 0 To tbl1.Rows.Count - 1

            Me.cmb_prove.Items.Add(tbl1.Rows(i).Item(0))
            Me.txt_cod_prov.Text = tbl1.Rows(i).Item(1)

        Next

        Me.cmb_prove.Text = Me.cmb_prove.Items(0)
        tbl1.Dispose()

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Dim x As Integer
        Dim aux As String = ""
        tbl.Clear()

        selecciona_codigo_proveedor(Me.cmb_prove.Text)

        If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

            comando = New SqlDataAdapter("select nombre,cantidad,sum(cantidad1) as cantidad1,cantidad_sin_stock,codi_producto,rubro from fact_det inner join art_01 on RTRIM(fact_det.codi_producto) = RTRIM(art_01.id_art) and RTRIM(fact_det.cod_prov) = RTRIM(art_01.id_proveedor) and fact_det.cod_prov = '" & RTrim(Me.txt_cod_prov.Text) & "' and fact_det.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_det.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' WHERE tipo_fact2 <> 'RE' group by nombre,cantidad,codi_producto,cantidad_sin_stock,rubro order by codi_producto ASC", conex)
            comando.Fill(tbl)
            comando.Dispose()

            Form_muestra_pedido_prov.DataGridView1.Columns.Add("0", "0")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("1", "1")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("2", "2")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("3", "PEDIDO")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("rubro", "rubro")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("costo", "COSTO")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("costo1", "COSTO1")

            Form_muestra_pedido_prov.DataGridView1.Columns(0).Width = 350
            Form_muestra_pedido_prov.DataGridView1.Columns(1).Width = 100
            Form_muestra_pedido_prov.DataGridView1.Columns(2).Width = 100

            Form_muestra_pedido_prov.DataGridView1.Columns(0).HeaderText = "NOMBRE"
            Form_muestra_pedido_prov.DataGridView1.Columns(1).HeaderText = "STOCK"
            If Me.chk_pendiente.Checked = True Then Form_muestra_pedido_prov.DataGridView1.Columns(2).HeaderText = "PENDIENTE"
            If Me.chk_pendiente.Checked = False Then Form_muestra_pedido_prov.DataGridView1.Columns(2).HeaderText = "FACTURADO/RESERVADO"

            Form_muestra_pedido_prov.DataGridView1.DefaultCellStyle.BackColor = Color.LightSteelBlue
            Form_muestra_pedido_prov.DataGridView1.Columns(0).DefaultCellStyle.BackColor = Color.White

            Form_muestra_pedido_prov.DataGridView1.Columns(4).Visible = False
            Form_muestra_pedido_prov.DataGridView1.Columns(6).Visible = False

            For x = 0 To tbl.Rows.Count - 1

                tblxx.Clear()
                comando = New SqlDataAdapter("select costo from art_precio where id_art1 = '" & RTrim(tbl.Rows(x).Item(4)) & "'", conex)
                comando.Fill(tblxx)
                comando.Dispose()

                Form_muestra_pedido_prov.DataGridView1.Rows.Add()
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(0).Value = tbl.Rows(x).Item(0)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(1).Value = tbl.Rows(x).Item(1)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(2).Value = tbl.Rows(x).Item(2)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(4).Value = tbl.Rows(x).Item(5)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(5).Value = tblxx.Rows(0).Item(0)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(6).Value = tblxx.Rows(0).Item(0)

                If Me.chk_pendiente.Checked = True Then

                    If RTrim(tbl.Rows(x).Item(3)) = "NO" Then
                        Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(2).Value = 0
                    End If

                    If tbl.Rows(x).Item(1) >= tbl.Rows(x).Item(2) Then
                        Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(2).Value = 0
                    End If

                    If aux = RTrim(tbl.Rows(x).Item(0)) Then
                        Form_muestra_pedido_prov.DataGridView1.Rows(x - 1).Visible = False
                    End If

                    aux = tbl.Rows(x).Item(0)

                End If

            Next

            Form_muestra_pedido_prov.txt_comentario.Text = "Fecha:" & "  " & Me.dt_fec_desde.Text & "  " & "Hasta:" & "  " & Me.dt_fec_hasta.Text & vbCrLf & "Ordenacion:" & "   " & Me.cmb_ordena.Text & vbCrLf & "Proveedor:" & "   " & Me.cmb_prove.Text

            Form_muestra_pedido_prov.Show()

        Else

            comando = New SqlDataAdapter("select nombre,cantidad,sum(cantidad1) as cantidad1,cantidad_sin_stock,codi_producto from fact_det inner join art_01 on fact_det.codi_producto = art_01.id_art and fact_det.cod_prov = art_01.id_proveedor and fact_det.cod_prov = '" & RTrim(Me.txt_cod_prov.Text) & "' and fact_det.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_det.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' group by nombre,cantidad,codi_producto,cantidad_sin_stock order by nombre ASC ", conex)
            comando.Fill(tbl)
            comando.Dispose()

            Form_muestra_pedido_prov.DataGridView1.Columns.Add("0", "0")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("1", "1")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("2", "2")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("3", "PEDIDO")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("rubro", "rubro")

            Form_muestra_pedido_prov.DataGridView1.Columns(0).Width = 350
            Form_muestra_pedido_prov.DataGridView1.Columns(1).Width = 100
            Form_muestra_pedido_prov.DataGridView1.Columns(2).Width = 100

            Form_muestra_pedido_prov.DataGridView1.Columns(0).HeaderText = "NOMBRE"
            Form_muestra_pedido_prov.DataGridView1.Columns(1).HeaderText = "STOCK"
            If Me.chk_pendiente.Checked = True Then Form_muestra_pedido_prov.DataGridView1.Columns(2).HeaderText = "PENDIENTE"
            If Me.chk_pendiente.Checked = False Then Form_muestra_pedido_prov.DataGridView1.Columns(2).HeaderText = "FACTURADO/RESERVADO"
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("costo", "COSTO")
            Form_muestra_pedido_prov.DataGridView1.Columns.Add("costo1", "COSTO1")

            Form_muestra_pedido_prov.DataGridView1.DefaultCellStyle.BackColor = Color.LightSteelBlue
            Form_muestra_pedido_prov.DataGridView1.Columns(0).DefaultCellStyle.BackColor = Color.White

            Form_muestra_pedido_prov.DataGridView1.Columns(4).Visible = False
            Form_muestra_pedido_prov.DataGridView1.Columns(6).Visible = False

            For x = 0 To tbl.Rows.Count - 1

                tblxx.Clear()
                comando = New SqlDataAdapter("select costo from art_precio where id_art1 = '" & RTrim(tbl.Rows(x).Item(4)) & "'", conex)
                comando.Fill(tblxx)
                comando.Dispose()

                Form_muestra_pedido_prov.DataGridView1.Rows.Add()
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(0).Value = tbl.Rows(x).Item(0)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(1).Value = tbl.Rows(x).Item(1)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(2).Value = tbl.Rows(x).Item(2)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(5).Value = tblxx.Rows(0).Item(0)
                Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(6).Value = tblxx.Rows(0).Item(0)

                If Me.chk_pendiente.Checked = True Then

                    If tbl.Rows(x).Item(1) >= tbl.Rows(x).Item(2) Then Form_muestra_pedido_prov.DataGridView1.Rows(x).Cells(2).Value = 0

                    If aux = RTrim(tbl.Rows(x).Item(0)) Then
                        Form_muestra_pedido_prov.DataGridView1.Rows(x - 1).Visible = False
                    End If

                    aux = tbl.Rows(x).Item(0)

                End If

            Next

            Form_muestra_pedido_prov.txt_comentario.Text = "Fecha:" & "  " & Me.dt_fec_desde.Text & "  " & "Hasta:" & "  " & Me.dt_fec_hasta.Text & vbCrLf & "Ordenacion:" & "   " & Me.cmb_ordena.Text & vbCrLf & "Proveedor:" & "   " & Me.cmb_prove.Text

            Form_muestra_pedido_prov.Show()

        End If

    End Sub

    Private Sub selecciona_codigo_proveedor(ByVal nombre As String)

        Dim tbl_ As New DataTable

        Try

            conex = conecta()
            tbl_.Clear()

            comando = New SqlDataAdapter("select id_cli from cli_01 where nombre = '" & RTrim(nombre) & "'", conex)
            comando.Fill(tbl_)
            comando.Dispose()

            Me.txt_cod_prov.Text = tbl_.Rows(0).Item(0)

        Catch ex As Exception

        Finally

            tbl_.Dispose()

        End Try

    End Sub


    Private Sub cmb_prove_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_prove.SelectedIndexChanged

        Dim tbl2 As New DataTable

        Try

            conex = conecta()
            tbl2.Clear()

            comando = New SqlDataAdapter("select id_cli from cli_01 where nombre = '" & RTrim(Me.cmb_prove.Text) & "'", conex)
            comando.Fill(tbl2)
            comando.Dispose()

            Me.txt_cod_prov.Text = tbl2.Rows(0).Item(0)

        Catch ex As Exception

        Finally

            tbl2.Dispose()

        End Try

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

End Class