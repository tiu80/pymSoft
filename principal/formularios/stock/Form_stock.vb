Imports System.Data
Imports System.Data.SqlClient

Public Class Form_stock

    Dim stc As New pymsoft.prov_vend_list_bco
    Dim arc As New pymsoft.parametro
    Dim tabla As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub Form_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_ordena.Text = Me.cmb_ordena.Items(0)
        conex = conecta()
    End Sub

    Private Sub carga_lista()

        stc.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_codigo.Text & "'"
        stc.codigo = "id_lis"
        stc.nombre = "nombre"
        stc.cargar()
        Me.txt_codigo.Text = stc.text
        Me.lbl_lista.Text = stc.text2
        Me.txt_proveedor.Focus()

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            carga_lista()
        End If
        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
        End If
    End Sub

    Private Sub txt_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_proveedor.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            stc.instruccion = "select *from cli_01 where id_cli like '" & Me.txt_proveedor.Text & "' AND tipo_cliente = 'Proveedor'"
            stc.codigo = "id_cli"
            stc.nombre = "nombre"
            stc.cargar()
            Me.txt_proveedor.Text = stc.text
            Me.lbl_proveedor.Text = stc.text2
            Me.txt_rubro.Focus()
        End If
        If e.KeyCode = Keys.F1 Then
            busc_proveedor.Show()
        End If
    End Sub

    Private Sub txt_rubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rubro.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            stc.instruccion = "select id_rubro,nombre from rub_01 where id_rubro like '" & Me.txt_rubro.Text & "'"
            stc.codigo = "id_rubro"
            stc.nombre = "nombre"
            stc.cargar()
            Me.txt_rubro.Text = stc.text
            Me.lbl_rubro.Text = stc.text2
            Me.cmb_ordena.Focus()
        End If
        If e.KeyCode = Keys.F1 Then
            busc_rubro.Show()
        End If
    End Sub

    Private Sub cmb_ordena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_ordena.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.Check_cero.Focus()
        End If
    End Sub

    Private Sub Check_movimeinto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_movimeinto.CheckedChanged
        If Me.Check_movimeinto.Checked = True Then
            Me.GroupBox2.Visible = True
        Else
            Me.GroupBox2.Visible = False
        End If
    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        tabla.Clear()

        If Me.txt_proveedor.Text = "" Or Me.txt_rubro.Text = "" Then
            Me.txt_rubro.Text = 0
            Me.txt_proveedor.Text = 0
        End If

        If Me.txt_codigo.Text = "" Or Me.txt_codigo.Text = 0 Then
            MessageBox.Show("Debe seleccionar una lista", "PymSoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        If Me.txt_codigo.Text <> 0 And Me.txt_proveedor.Text = 0 And Me.txt_rubro.Text = 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo'", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 = '" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.nombre ASC", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

        End If

        If Me.txt_codigo.Text <> 0 And Me.txt_proveedor.Text <> 0 And Me.txt_rubro.Text <> 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on  art_01.id_rubro='" & RTrim(Me.txt_rubro.Text) & "' and art_01.id_proveedor ='" & RTrim(Me.txt_proveedor.Text) & "' and art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by id_art Asc ", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_01.id_rubro='" & RTrim(Me.txt_rubro.Text) & "' and art_01.id_proveedor ='" & RTrim(Me.txt_proveedor.Text) & "' and art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.nombre ", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

        End If

        If Me.txt_codigo.Text <> 0 And Me.txt_proveedor.Text <> 0 And Me.txt_rubro.Text = 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_01.id_proveedor ='" & RTrim(Me.txt_proveedor.Text) & "' and art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.id_art", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_01.id_proveedor ='" & RTrim(Me.txt_proveedor.Text) & "' and art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.nombre ", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

        End If

        If Me.txt_codigo.Text <> 0 And Me.txt_proveedor.Text = 0 And Me.txt_rubro.Text <> 0 Then

            If RTrim(Me.cmb_ordena.Text) = "Codigo" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_rubro = '" & RTrim(Me.txt_rubro.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.id_art", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

            If RTrim(Me.cmb_ordena.Text) = "Alfabeticamente" Then

                comando = New SqlDataAdapter("select id_art,nombre,cantidad,0,0.0,cantidad_bulto,costo,precio_civa from art_01 inner join art_precio on art_precio.id_lista1 ='" & RTrim(Me.txt_codigo.Text) & "' and art_01.id_rubro = '" & RTrim(Me.txt_rubro.Text) & "' and art_01.id_art = art_precio.id_art1 and art_01.estado ='Activo' order by art_01.nombre", conex)
                comando.Fill(tabla)
                comando.Dispose()

            End If

        End If

        Form_muestra_stock.DataGridView1.DataSource = tabla

        Form_muestra_stock.Show()

    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        If Me.txt_codigo.Text = "" Then
            Me.txt_codigo.Text = 0
            Me.lbl_lista.Text = "Todos los Registros"
        End If
    End Sub

    Private Sub txt_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_proveedor.LostFocus
        If Me.txt_proveedor.Text = "" Then
            Me.txt_proveedor.Text = 0
            Me.lbl_proveedor.Text = "Todos los Registros"
        End If
    End Sub

    Private Sub txt_rubro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rubro.LostFocus
        If Me.txt_rubro.Text = "" Then
            Me.txt_rubro.Text = 0
            Me.lbl_rubro.Text = "Todos los Registros"
        End If
    End Sub

    Private Sub Check_cero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Check_cero.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_aceptar.Focus()
        End If
    End Sub
End Class