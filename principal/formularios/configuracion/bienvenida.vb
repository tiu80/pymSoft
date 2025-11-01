Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.Form

Public NotInheritable Class bienvenida

    Dim conex As New SqlConnection
    Dim comando As SqlCommand
    Dim comando1 As SqlDataAdapter
    Dim midataset As New DataSet
    Dim nombre As String
    Dim menu_usu As String
    Dim param As String
    Dim fact As New pymsoft.factura

    Private Sub bienvenida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Timer1.Enabled = True

        Me.lbl_version.Text = My.Application.Info.Version.Major
        Me.lbl_version1.Text = My.Application.Info.Version.Minor
        Me.lbl_version3.Text = My.Application.Info.Version.Revision
        Me.lbl_copy.Text = My.Application.Info.Copyright

        Form_login.Hide()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Timer1.Interval = 100 Then
            Me.Timer1.Enabled = False
            Call carga_menu()
            Call cargar_sub_menu()
            Me.Hide()
        End If
    End Sub

    Private Sub carga_menu()

        Try

            Dim i, j As Integer

            conex = conecta()

            comando = New SqlCommand("select *from menu_usu where usuario like '" & Form_login.cmb_usuario.Text & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando.ExecuteReader

            While reader.Read()

                nombre = reader("usuario")
                menu_usu = reader("menu")
                param = reader("parametro")

            End While

            conex.Close()

            comando1 = New SqlDataAdapter("select *from menu01 where id_menu01 like '" + menu_usu + "'", conex)
            comando1.Fill(midataset, "menu01")

            i = 0
            j = 0

            If RTrim(midataset.Tables("menu01").Rows(0).Item(3)) = "B" Then   ' altas
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(0).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(1).Item(3)) = "B" Then            ' ventas

                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(1).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(2).Item(3)) = "B" Then   ' Compras
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(2).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(3).Item(3)) = "B" Then   'contabilidad
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(3).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(4).Item(3)) = "B" Then    'configuracion
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(4).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(5).Item(3)) = "B" Then      'stock
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(5).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(6).Item(3)) = "B" Then       'estadisticos y Reportes
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
                j = i
                i = i - 1
            Else
                j = j + 1
                Me.lbl_menu.Text = midataset.Tables("menu01").Rows(6).Item(2)
                Me.lbl_menu.Refresh()
            End If

            i = i + 1

            If RTrim(midataset.Tables("menu01").Rows(7).Item(3)) = "B" Then       'Exportador e Importador
                Dim a As String = principal.TreeView1.Nodes(j).Text
                principal.TreeView1.Nodes(j).Remove()
            End If

            reader.Close()

        Catch ex As Exception

            MessageBox.Show("Falta Menu para este usuario", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Form_login.Dispose()

        Finally

            conex.Close()

        End Try

    End Sub

    Public Sub cargar_sub_menu()

        Dim i As Integer

        comando1 = New SqlDataAdapter("select *from sub_menu_01 where id_menu like '" + menu_usu + "'", conex)
        comando1.Fill(midataset, "sub_menu_01")

        If midataset.Tables("sub_menu_01").Rows.Count = 0 Then
            MessageBox.Show("Falta Sub Menu para este usuario", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Form_login.Dispose()
        End If

        If nombre <> "Administrador" Then

            For i = 0 To midataset.Tables("sub_menu_01").Rows.Count - 1

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cliente.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cliente.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cli.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Provincia" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_provincia.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Provincia" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_provincia.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Provincia" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_prov.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_articulo.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_articulo.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_art.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Localidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_localidad.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Localidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_localidad.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Localidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_loca.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Vendedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vendedor.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Vendedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vendedor.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Vendedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_vend.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Rubro" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rubro.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Rubro" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rubro.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Rubro" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_rub.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Sucursal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_sucursal.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Sucursal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_sucursal.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Sucursal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_sucu.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Tipo I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_tipo_iva.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Tipo I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_tipo_iva.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Tipo I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_iva.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_zona.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_zona.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_zona.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Bancos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_banco.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Bancos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_banco.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Bancos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_banco.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Ofertas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_lista_ofertas.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Ofertas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_lista_ofertas.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Ofertas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_lista_oferta.Visible = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_factura.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Nota Credito" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_nota_credito.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Nota Credito" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_nota_credito.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Nota Credito" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_n_credito.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Ingreso Cobranza" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_recibos.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Ingreso Cobranza" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_recibos.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Ingreso Cobranza" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_recibo.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cambio Numerador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_numerador.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cambio Numerador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_numerador.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cambio Numerador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_numerador.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobantes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_comprobantes.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobantes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_comprobantes.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobantes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cons_comproban.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Arqueo Caja" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_arqueo_caja.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Arqueo Caja" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_arqueo_caja.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Arqueo Caja" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_arqueo.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador." And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vizualiza_fact.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador." And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vizualiza_fact.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador." And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_visu_fact.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Recibos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_balance_saldos.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Recibos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_balance_saldos.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Recibos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_balance_saldos.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_cta_cte.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_cta_cte.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cons_cta_cte.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Preventa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura_preventa.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Preventa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura_preventa.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Preventa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_factura_preventa.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cierre Fiscal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cierre_fiscal.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cierre Fiscal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cierre_fiscal.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cierre Fiscal" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cierre_fiscal.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_iva_ventas.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_iva_ventas.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro I.V.A" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_iva_ventas.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Resumen cta" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_resumen_cta.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Resumen cta" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_resumen_cta.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Resumen cta" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_resumen_cta.Visible = False

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Usuario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_usuario.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Usuario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_usuario.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Usuario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_usuario.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Menu" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_menu.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Menu" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_menu.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Menu" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_menu.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Parametros" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_parametros.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Parametros" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_parametros.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Parametros" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_param.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Asigna" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_asigna.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Asigna" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_asigna.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Asigna" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_asigna.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Habilita P. carga" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_habilita_mes.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Habilita P. carga" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_habilita_mes.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Habilita P. carga" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_habilita_mes.Visible = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rep_precios.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rep_precios.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Clientes" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_rep_precio.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Precios" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_repo_precios.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Precios" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_repo_precios.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Precios" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_repo_precios.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Rentabilidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rentabilidad.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Rentabilidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_rentabilidad.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Rentabilidad" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_rep_rentabilidad.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Ventas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vta_agru.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Ventas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_vta_agru.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Ventas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_ventas_general.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_repcta_cte.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_repcta_cte.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Reportes Cta Cte" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_rep_ctacte.Visible = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Entrada" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_remito_ent.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Entrada" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_remito_ent.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Entrada" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_remito_ent.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Salida" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_remito_sal.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Salida" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_remito_sal.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Remito Salida" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_remito_sal.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta x Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_consul_x_movim.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta x Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_consul_x_movim.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta x Articulos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_movimxarticulo.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cliente Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_cliente_proveedor.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cliente Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_cliente_proveedor.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Cliente Proveedor" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cons_cliente_prov.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador Remitos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_visualiza_remito.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador Remitos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_visualiza_remito.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador Remitos" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_visu_rem.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Inventario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_inventario.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Inventario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_inventario.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Inventario" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_inventario.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Stock" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_stock.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Stock" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_stock.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Stock" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_consul_stock.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Pedido Proveedores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_pedido_a_prov.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Pedido Proveedores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_stock.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Pedido Proveedores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_pedido.Visible = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura_compra.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_factura_compra.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Factura Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_fact_compras.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "N. Credito Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_n_credito_compra.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "N. Credito Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_n_credito_compra.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "N. Credito Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_n_compras.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_visualiza_compra.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_visualiza_compra.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Visualizador" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_visualiza_compra.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro i.v.a Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_iva_compras.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro i.v.a Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_iva_compras.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Libro i.v.a Compras" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_iva_compras.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobante" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_consulta_comprobantes_c.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobante" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cons_comprobantes_c.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Comprobante" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_consulta_comprobante_compras.Visible = False

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_alta_planilla.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_alta_planilla.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_alta_planilla.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_carga_planilla.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_consulta_planilla.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Consulta Planilla" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_carga_planilla.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Plan Cuentas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_plan_cuenta.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Plan Cuentas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_plan_cuenta.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Plan Cuentas" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_plan_cuenta.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cartera Valores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cartera_valores.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cartera Valores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_cartera_valores.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Cartera Valores" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cartera_valores.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Empresa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_empresa.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Empresa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_empresa.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Empresa" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_empresa.Visible = False

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Cartera" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_alta_cartera.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Cartera" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_alta_cartera.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Alta Cartera" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_cartera.Visible = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Transferidor pda" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_trans_pda.Enabled = False
                'If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Transferidor pda" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.cmd_trans_pda.BackgroundImage = Nothing
                If RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(4)) = "Transferidor pda" And RTrim(midataset.Tables("sub_menu_01").Rows(i).Item(5)) = "B" Then principal.lbl_trans_pda.Visible = False

            Next

        End If

        fact.carga_parametro()

        principal.txt_lista_pred.Text = fact.lista_predeterminada

        principal.Show()

    End Sub

    Public Sub LimpiarControles()
        Dim myControl As Control

        For Each myControl In form_factura.Controls

            'Verificamos si el control es un TextBox
            If (TypeOf (myControl) Is Button) Then

                If CType(myControl, Button).Visible = False Then

                    CType(myControl, Label).Visible = False

                End If

            End If

            If (TypeOf (myControl) Is Label) Then

                CType(myControl, Label).Text = ""

            End If

        Next

    End Sub

End Class
