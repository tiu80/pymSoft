Imports System.Data
Imports System.Data.SqlClient

Public Class Form_reporte_precios

    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim fact As New pymsoft.factura
    Dim tabla As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub txt_cod_list_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_list.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_cod_list.Text & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_list.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            If xxx.validar = False Then
                Me.txt_cod_list.Focus()
                Exit Sub
            End If

            Me.txt_cod_prov.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
        End If

    End Sub

    Private Sub txt_cod_prov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_prov.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from list_01 where id_lista like '" & Me.txt_cod_prov.Text & "'"
            xxx.codigo = "id_lista"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_prov.Text = xxx.text
            Me.lbl_prov.Text = xxx.text2

            If xxx.validar = False Then
                Me.txt_cod_prov.Text = "0"
                Me.lbl_prov.Text = "Todos los Registros"
            End If

            Me.txt_cod_rub.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_proveedor.Show()
        End If

    End Sub

    Private Sub txt_cod_rub_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_rub.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from rub_01 where id_rubro like '" & Me.txt_cod_rub.Text & "'"
            xxx.codigo = "id_rubro"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_rub.Text = xxx.text
            Me.lbl_rubro.Text = xxx.text2

            If xxx.validar = False Then
                Me.txt_cod_rub.Text = "0"
                Me.lbl_rubro.Text = "Todos los Registros"
            End If

            Me.dt_fec_desde.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_rubro.Show()
        End If

    End Sub

    Private Sub Form_reporte_precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_estado_form.Text = 1
        Me.cmb_estado.Text = Me.cmb_estado.Items(0)
        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        fact.carga_parametro()
        Call carga_lista_definida()

    End Sub

    Private Sub carga_lista_definida()
        Try

            xxx.instruccion = "select *from lista_01 where id_lis like '" & fact.lista_predeterminada & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_cod_list.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            Me.txt_cod_prov.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click


        Dim rep As New precios

        conex = conecta()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        tabla.Clear()

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text = 0 And Me.txt_cod_rub.Text = 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_precio where id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and estado1 = '" & RTrim(Me.cmb_estado.Text) & "' order by cod ASC", conex)
                comando.Fill(tabla)

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_precio where id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and estado1 = '" & RTrim(Me.cmb_estado.Text) & "' order by nom ASC", conex)
                comando.Fill(tabla)

            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text <> 0 And Me.txt_cod_rub.Text = 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and art_01.id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and art_01.estado = '" & RTrim(Me.cmb_estado.Text) & "' order by art_precio.id_art1 ASC", conex)
                comando.Fill(tabla)

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and art_01.id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and art_01.estado = '" & RTrim(Me.cmb_estado.Text) & "' order by art_precio.nom ASC", conex)
                comando.Fill(tabla)

            End If

        End If

        If Me.txt_cod_list.Text <> 0 And Me.txt_cod_prov.Text <> 0 And Me.txt_cod_rub.Text <> 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and art_01.id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and art_01.id_rubro = '" & RTrim(Me.txt_cod_rub.Text) & "' and art_01.estado = '" & RTrim(Me.cmb_estado.Text) & "' order by art_precio.id_art1 ASC", conex)
                comando.Fill(tabla)

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art1,nom,costo,iva,utilidad,precio_siva,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_cod_list.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.id_lista = art_precio.id_lista1 and art_01.id_proveedor = '" & RTrim(Me.txt_cod_prov.Text) & "' and art_01.id_rubro = '" & RTrim(Me.txt_cod_rub.Text) & "' and art_01.estado = '" & RTrim(Me.cmb_estado.Text) & "' order by art_precio.nom ASC", conex)
                comando.Fill(tabla)

            End If

        End If

        rep.SetDataSource(tabla)
        rep.Refresh()

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

        Me.Dispose()

    End Sub

End Class