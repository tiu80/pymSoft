Imports System.Math
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_stock

    Dim i As Integer
    Dim costo1, venta1 As Single
    Dim tabla As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim st As New pymsoft.parametro

    Dim reporte As New pymsoft.reporte

    Private Sub Form_muestra_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        Me.txt_estado_form.Text = 1

        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 300
        Me.DataGridView1.Columns(2).Width = 70
        Me.DataGridView1.Columns(3).Width = 70
        Me.DataGridView1.Columns(4).Width = 55
        Me.DataGridView1.Columns(5).Width = 55
        Me.DataGridView1.Columns(6).Width = 60
        Me.DataGridView1.Columns(7).Width = 60

        Me.DataGridView1.Columns(0).HeaderText = "Codigo"
        Me.DataGridView1.Columns(1).HeaderText = "Detalle"
        Me.DataGridView1.Columns(2).HeaderText = "Cantidad"
        Me.DataGridView1.Columns(3).HeaderText = "Bultos"
        Me.DataGridView1.Columns(4).HeaderText = "Unidad"
        Me.DataGridView1.Columns(5).HeaderText = "Contiene"
        Me.DataGridView1.Columns(6).HeaderText = "V.Costo"
        Me.DataGridView1.Columns(7).HeaderText = "V.Venta"

        comando = New SqlDataAdapter("select codigo,detalle,cantidad,unidad,bulto,contiene,costo,venta from Grilla_01 where id_colum = '1'", conex)
        comando.Fill(tabla)

        Call calcula_bulto()
        Call calcula_unidad()
        Call costo()
        Call venta()

        If RTrim(tabla.Rows(0).Item(0)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(0, True)
            Me.DataGridView1.Columns(0).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(0, False)
            Me.DataGridView1.Columns(0).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(1)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(1, True)
            Me.DataGridView1.Columns(1).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(1, False)
            Me.DataGridView1.Columns(1).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(2)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(2, True)
            Me.DataGridView1.Columns(2).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(2, False)
            Me.DataGridView1.Columns(2).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(3)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(3, True)
            Me.DataGridView1.Columns(3).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(3, False)
            Me.DataGridView1.Columns(3).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(4)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(4, True)
            Me.DataGridView1.Columns(4).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(4, False)
            Me.DataGridView1.Columns(4).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(5)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(5, True)
            Me.DataGridView1.Columns(5).Visible = True
        Else
            Me.CheckedListBox1.SetItemChecked(5, False)
            Me.DataGridView1.Columns(5).Visible = False
        End If
        If RTrim(tabla.Rows(0).Item(6)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(6, True)
            Me.DataGridView1.Columns(6).Visible = True
            Me.lbl_costo.Text = "Valor Costo -------------->" & "    " & costo1
        Else
            Me.CheckedListBox1.SetItemChecked(6, False)
            Me.DataGridView1.Columns(6).Visible = False
            Me.lbl_costo.Text = ""
        End If
        If RTrim(tabla.Rows(0).Item(7)) = "SI" Then
            Me.CheckedListBox1.SetItemChecked(7, True)
            Me.DataGridView1.Columns(7).Visible = True
            Me.lbl_venta.Text = "Valor Venta -------------->" & "    " & venta1
        Else
            Me.CheckedListBox1.SetItemChecked(7, False)
            Me.DataGridView1.Columns(7).Visible = False
            Me.lbl_venta.Text = ""
        End If
        
        Dim z As Integer = Me.DataGridView1.Rows.Count - 1
        Me.DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.LightGray
        Me.DataGridView1.Rows(z).DefaultCellStyle.BackColor = Color.LightGray

        barra_carga.Timer1.Enabled = True

        Me.txt_comentario.Text = "Lista:" & "  " & Form_stock.txt_codigo.Text & " : " & Form_stock.lbl_lista.Text & vbCrLf & "Proveedor:" & "   " & Form_stock.txt_proveedor.Text & " : " & Form_stock.lbl_proveedor.Text & vbCrLf & "Rubro:" & "  " & Form_stock.txt_rubro.Text & " : " & Form_stock.lbl_rubro.Text & vbCrLf & "Ordenado por: " & "   " & Form_stock.cmb_ordena.Text & vbCrLf & "Valor Costo:" & "   " & costo1 & vbCrLf & "Valor Venta:" & "  " & venta1

    End Sub

    Private Sub cmd_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_guardar.Click

        Dim i As Integer
        Dim a As Boolean

        For i = 0 To Me.CheckedListBox1.Items.Count - 1

            a = Me.CheckedListBox1.GetItemChecked(i)

            If a = False Then
                Me.DataGridView1.Columns(i).Visible = False
                If i = 0 Then
                    st.instruccion = "update Grilla_01 set codigo = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 1 Then
                    st.instruccion = "update Grilla_01 set detalle = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 2 Then
                    st.instruccion = "update Grilla_01 set cantidad = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 3 Then
                    st.instruccion = "update Grilla_01 set bulto = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 4 Then
                    st.instruccion = "update Grilla_01 set unidad = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 5 Then
                    st.instruccion = "update Grilla_01 set contiene = 'NO' where id_colum = '1'"
                    st.abm()
                End If
                If i = 6 Then
                    st.instruccion = "update Grilla_01 set costo = 'NO' where id_colum = '1'"
                    st.abm()
                    Me.lbl_costo.Text = ""
                End If
                If i = 7 Then
                    st.instruccion = "update Grilla_01 set venta = 'NO' where id_colum = '1'"
                    st.abm()
                    Me.lbl_venta.Text = ""
                End If

            Else

                Me.DataGridView1.Columns(i).Visible = True
                If i = 0 Then
                    st.instruccion = "update Grilla_01 set codigo = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 1 Then
                    st.instruccion = "update Grilla_01 set detalle = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 2 Then
                    st.instruccion = "update Grilla_01 set cantidad = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 3 Then
                    st.instruccion = "update Grilla_01 set bulto = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 4 Then
                    st.instruccion = "update Grilla_01 set unidad = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 5 Then
                    st.instruccion = "update Grilla_01 set contiene = 'SI' where id_colum = '1'"
                    st.abm()
                End If
                If i = 6 Then
                    st.instruccion = "update Grilla_01 set costo = 'SI' where id_colum = '1'"
                    Me.lbl_costo.Text = "Valor Costo -------------->" & "    " & costo1
                    st.abm()
                End If
                If i = 7 Then
                    st.instruccion = "update Grilla_01 set venta = 'SI' where id_colum = '1'"
                    st.abm()
                    Me.lbl_venta.Text = "Valor Venta -------------->" & "    " & venta1
                End If
            End If

        Next

        Me.CheckedListBox1.Visible = False
        Me.cmd_guardar.Visible = False

    End Sub

    Private Sub calcula_bulto()

        Dim a As Double

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            a = Me.DataGridView1.Rows(i).Cells(2).Value / Me.DataGridView1.Rows(i).Cells(5).Value

            Me.DataGridView1.Rows(i).Cells(3).Value = Truncate(a)

        Next

    End Sub

    Private Sub calcula_unidad()

        Dim x As Double

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            x = Format(Me.DataGridView1.Rows(i).Cells(2).Value - Me.DataGridView1.Rows(i).Cells(3).Value * Me.DataGridView1.Rows(i).Cells(5).Value, "0.00")

            Me.DataGridView1.Rows(i).Cells(4).Value = x

        Next

    End Sub

    Private Sub costo()

        Dim a As Single

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            a = (Me.DataGridView1.Rows(i).Cells(2).Value) * (Me.DataGridView1.Rows(i).Cells(6).Value)

            Me.DataGridView1.Rows(i).Cells(6).Value = Format(a, "0.00")
            costo1 = Format(costo1 + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")

        Next

        Me.lbl_costo.Text = Me.lbl_costo.Text & "    " & costo1

    End Sub

    Private Sub venta()

        Dim a As Single

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            a = (Me.DataGridView1.Rows(i).Cells(2).Value) * (Me.DataGridView1.Rows(i).Cells(7).Value)

            Me.DataGridView1.Rows(i).Cells(7).Value = Format(a, "0.00")
            venta1 = Format(venta1 + Me.DataGridView1.Rows(i).Cells(7).Value, "0.00")

        Next

        Me.lbl_venta.Text = Me.lbl_venta.Text & "    " & venta1

    End Sub

    Private Sub Tool_columnas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_columnas.Click
        Me.cmd_guardar.Visible = True
        Me.CheckedListBox1.Visible = True
    End Sub

    Private Sub Tool_exporta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_exporta.Click
        Form_exporta.Show()
    End Sub

    Private Sub Tool_imprime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_imprime.Click

        Dim rep As Object = Nothing
        Dim x As String
        Dim PrinterSettings As New System.Drawing.Printing.PrinterSettings()
        Dim PageSettings As New System.Drawing.Printing.PageSettings(PrinterSettings)
        Dim pd As New PrintDialog

        x = reporte.carga_datos("stock")

        If x = "stock" Then
            rep = New stock
        End If

        Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt2 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt3 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txt4 As CrystalDecisions.CrystalReports.Engine.TextObject

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper

        rep.PrintOptions.CopyTo(PrinterSettings, PageSettings)
        pd.PrinterSettings = PrinterSettings
        pd.AllowSomePages = True
        pd.AllowSelection = True

        If Form_stock.txt_proveedor.Text = 0 And Form_stock.txt_rubro.Text = 0 Then

            txt = rep.Section2.ReportObjects.Item("nom_lista")
            txt.Text = Form_stock.lbl_lista.Text

            txt1 = rep.Section2.ReportObjects.Item("mod1")
            txt1.Text = "Total"

            If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

                rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

            End If

            barra_carga.Timer1.Enabled = True

            Exit Sub

        End If

        If Form_stock.txt_proveedor.Text <> 0 And Form_stock.txt_rubro.Text = 0 Then

            txt = rep.Section2.ReportObjects.Item("nom_lista")
            txt.Text = Form_stock.lbl_lista.Text

            txt1 = rep.Section2.ReportObjects.Item("mod1")
            txt1.Text = "Proveedor"

            txt2 = rep.Section2.ReportObjects.Item("nom_pro")
            txt2.Text = Form_stock.lbl_proveedor.Text

            rep.RecordSelectionFormula = "{art_01.id_proveedor} = " & RTrim(Form_stock.txt_proveedor.Text) & ""

            If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

                rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

            End If

            barra_carga.Timer1.Enabled = True

            Exit Sub

        End If

        If Form_stock.txt_proveedor.Text = 0 And Form_stock.txt_rubro.Text <> 0 Then

            txt = rep.Section2.ReportObjects.Item("nom_lista")
            txt.Text = Form_stock.lbl_lista.Text

            txt1 = rep.Section2.ReportObjects.Item("mod1")
            txt1.Text = "Rubro"

            txt2 = rep.Section2.ReportObjects.Item("nom_rub")
            txt2.Text = Form_stock.lbl_rubro.Text

            rep.RecordSelectionFormula = "{art_01.id_rubro} = " & RTrim(Form_stock.txt_rubro.Text) & ""

            If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

                rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

            End If

            barra_carga.Timer1.Enabled = True

            Exit Sub

        End If

        If Form_stock.txt_proveedor.Text <> 0 And Form_stock.txt_rubro.Text <> 0 Then

            txt = rep.Section2.ReportObjects.Item("nom_lista")
            txt.Text = Form_stock.lbl_lista.Text

            txt1 = rep.Section2.ReportObjects.Item("mod1")
            txt1.Text = "Proveedor"

            txt2 = rep.Section2.ReportObjects.Item("mod2")
            txt2.Text = "Rubro"

            txt3 = rep.Section2.ReportObjects.Item("nom_pro")
            txt3.Text = Form_stock.lbl_proveedor.Text

            txt4 = rep.Section2.ReportObjects.Item("nom_rub")
            txt4.Text = Form_stock.lbl_rubro.Text

            rep.RecordSelectionFormula = "{art_01.id_rubro} = '" & Trim(Form_stock.txt_rubro.Text) & "' and {art_01.id_proveedor} = '" & Trim(Form_stock.txt_proveedor.Text) & "'"

            If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

                rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

            End If

            barra_carga.Timer1.Enabled = True

            Exit Sub

        End If

    End Sub

End Class