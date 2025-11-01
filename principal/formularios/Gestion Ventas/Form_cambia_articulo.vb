Imports System.Data
Imports System.Data.SqlClient

Public Class Form_cambia_articulo

    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim tbl As New DataTable, tbl1 As New DataTable, tbl2 As New DataTable
    Dim cont, i As Integer

    Private Sub txt_busqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyUp

        If Me.txt_busqueda.Text <> "" Then
            Call busca_articulo()
        Else
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
            Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
        End If

        If e.KeyCode = Keys.Return Then

            If Me.txt_busqueda.Text = "" Then
                Me.txt_busqueda.Focus()
                Exit Sub
            End If

            Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
            Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
            Me.DataGridView1.Focus()

        End If

    End Sub

    Private Sub busca_articulo()

        conex = conecta()
        tbl.Clear()

        Dim comando1 As New SqlDataAdapter("select id_art1,nombre,cantidad,precio_civa from art_01 inner join art_precio on art_01.id_lista = art_precio.id_lista1 and art_01.id_art = art_precio.id_art1 and art_precio.nom like '" & RTrim(Me.txt_busqueda.Text) & "%' and art_precio.nom = art_01.nombre and art_01.estado = 'Activo'", conex)
        comando1.Fill(tbl)
        Me.DataGridView1.DataSource = tbl

        Me.DataGridView1.Columns(0).Width = 130
        Me.DataGridView1.Columns(1).Width = 350
        Me.DataGridView1.Columns(2).Visible = False
        Me.DataGridView1.Columns(3).Visible = False

        Me.DataGridView1.Columns(0).HeaderText = "ID"
        Me.DataGridView1.Columns(1).HeaderText = "NOMBRE"

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then

            If cont = 0 Then

                Me.lbl_art_en_pedido.Text = Me.DataGridView1.SelectedCells(1).Value
                cont = cont + 1
                Exit Sub

            End If

            If cont = 1 Then

                Me.lbl_art_reemplaza.Text = Me.DataGridView1.SelectedCells(1).Value
                cont = 0
                Exit Sub

            End If

        End If

    End Sub

    Private Sub cmd_cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cambiar.Click

        Dim p_s, p_c, imp, exento, iva_insc, desc

        tbl1.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,descuento,cod_lista,num_fact,tipo_fact2,prefijo_fact2,letra_fact1,talon1 from fact_det where fec_emi >= '" & RTrim(Form_consulta_comprobante.dt_fec_ini.Text) & "' and fec_emi <= '" & RTrim(Form_consulta_comprobante.dt_fec_fin.Text) & "' and detalle = '" & RTrim(Me.lbl_art_en_pedido.Text) & "' and tipo_fact2 = 'PD'", conex)
        comando.Fill(tbl1)

        If tbl1.Rows.Count = Nothing Then

            MessageBox.Show("No existe el articulo!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub

        Else

            'busco el articulo a reemplazar en los pedidos con todos sus precios

            tbl2.Clear()
            conex = conecta()

            comando = New SqlDataAdapter("select id_art1,nom,precio_siva,precio_civa,iva_insc,impuestos,exento from art_precio where nom = '" & RTrim(Me.lbl_art_reemplaza.Text) & "' and id_lista1 = '" & RTrim(tbl1.Rows(0).Item(4)) & "'", conex)
            comando.Fill(tbl2)

            For i = 0 To tbl1.Rows.Count - 1

                p_s = tbl1.Rows(i).Item(2) * tbl2.Rows(0).Item(2)  ' calculo el nuevo precio sin iva

                If tbl1.Rows(i).Item(3) = 0 Then
                    p_c = tbl1.Rows(i).Item(2) * tbl2.Rows(0).Item(3)  ' calculo el nuevo precio con iva sin descuento
                Else
                    Dim temp As Double = tbl1.Rows(i).Item(2) * tbl2.Rows(0).Item(3)
                    p_c = (temp * tbl1.Rows(i).Item(3) / 100) - temp   ' calculo el nuevo precio con iva con descuento
                End If

                imp = tbl2.Rows(0).Item(5)  ' imp interno
                exento = tbl2.Rows(0).Item(6)  ' exento
                iva_insc = Format(p_c - p_s, "0.00")  ' calculo iva inscripto
                desc = tbl1.Rows(0).Item(3)  ' descuento

                If conex.State = ConnectionState.Closed Then conex.Open()

                coman = New SqlCommand("update fact_det set codi_producto = '" & tbl2.Rows(0).Item(0) & "',detalle = '" & tbl2.Rows(0).Item(1) & "',nom_producto = '" & tbl2.Rows(0).Item(1) & "',precio_unidad = '" & p_s & "',precio_civa1 = '" & p_c & "',imp_interno = '" & imp & "',exento1 = '" & exento & "',iva_inscripto = '" & iva_insc & "',descuento = '" & desc & "' where codi_producto = '" & RTrim(tbl1.Rows(i).Item(0)) & "' and tipo_fact2 = 'PD' and cantidad_sin_stock = 'SI' and num_fact = '" & tbl1.Rows(i).Item(5) & "' and tipo_fact2 = '" & tbl1.Rows(i).Item(6) & "' and prefijo_fact2 = '" & tbl1.Rows(i).Item(7) & "' and letra_fact1 = '" & tbl1.Rows(i).Item(8) & "' and talon1 = '" & tbl1.Rows(i).Item(9) & "'", conex)
                coman.ExecuteNonQuery()

                conex.Close()
                coman.Dispose()

            Next

            MessageBox.Show("La actualizacion termino correctamente!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.Close()

        End If

    End Sub

End Class
