Imports System.Data
Imports System.Data.SqlClient

Public Class Form_inventario

    Dim conex As New SqlConnection
    Dim tabla As New DataTable
    Dim tabla1 As New DataTable
    Dim comando As SqlDataAdapter
    Dim coman As SqlCommand
    Dim inv As New pymsoft.parametro
    Dim list As New pymsoft.prov_vend_list_bco
    Dim num As New pymsoft.numerodecimales

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.txt_codigo.Text <> "" Then busc_articulos.carga_codigo_seguimiento(Me.txt_codigo.Text, 1)
            Me.txt_stk_ant.Enabled = True
        End If

        If e.KeyCode = Keys.F1 Then
            busc_articulos.txt_lista.Text = principal.txt_lista_pred.Text
            busc_articulos.Show()
        End If

        If e.KeyCode = Keys.F10 Then
            Me.Button1.Enabled = True
        End If

    End Sub

    Private Sub txt_stk_ant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_stk_ant.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            If Me.Check_stc_actual.Checked = True Then
                Me.stk_actual.Focus()
                Exit Sub
            End If

            Me.dt_fec_corte.Focus()

        End If
    End Sub

    Private Sub stk_actual_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stk_actual.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.dt_fec_corte.Focus()
        End If
    End Sub

    Private Sub Form_inventario_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        tabla.Dispose()
        tabla1.Dispose()
    End Sub
    
    Private Sub Form_inventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_estado_form.Text = 1
        Me.opt_inicia.Checked = True
        conex = conecta()
    End Sub

    Private Sub cmd_inicializa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inicializa.Click
        Dim i As Integer

        If Me.opt_inicia.Checked = True Then

            tabla1.Clear()

            comando = New SqlDataAdapter("select fec_emision from fact_cab where fec_emision >= '" & Me.dt_corte_inicia.Text & "'", conex)
            comando.Fill(tabla1)

            If tabla1.Rows.Count <> 0 Then
                MessageBox.Show("No puede haber facturas el mismo dia ni posterior al corte de stock", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim a As Short = MessageBox.Show("Este Proceso Cargara el stock actual al corte de stock" & vbCrLf & "Esta Seguro!!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            If a = 6 Then

                barra_carga.Show()
                barra_carga.PictureBox1.Refresh()

                comando = New SqlDataAdapter("select nombre,cantidad,stock_corte,id_art from art_01", conex)
                comando.Fill(tabla)

                For i = 0 To tabla.Rows.Count - 1

                    inv.instruccion = "update art_01 set stock_corte = '" & tabla.Rows(i).Item(1) & "', fec_modi='" & Me.dt_corte_inicia.Text & "' where id_art = '" & tabla.Rows(i).Item(3) & "'"
                    inv.abm()

                    barra_carga.PictureBox1.Refresh()

                Next

                MessageBox.Show("proceso Terminado correctamente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_inicia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inicia.Click

        Dim i As Integer

        If Me.opt_inicia1.Checked = True Then

            tabla1.Clear()

            comando = New SqlDataAdapter("select fec_emision from fact_cab where fec_emision= '" & Me.dt_corte_inicia.Text & "'", conex)
            comando.Fill(tabla1)

            Dim a As Short = MessageBox.Show("Este Proceso Cargara el stock actual al corte de stock cuyos valores son 0 " & vbCrLf & "Esta Seguro!!!!", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            If a = 6 Then

                barra_carga.Show()
                barra_carga.PictureBox1.Refresh()

                comando = New SqlDataAdapter("select nombre,cantidad,stock_corte,id_art from art_01 where stock_corte = '0'", conex)
                comando.Fill(tabla)

                If tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron valores en 0", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                For i = 0 To tabla.Rows.Count - 1

                    inv.instruccion = "update art_01 set stock_corte = '" & tabla.Rows(i).Item(1) & "', fec_modi='" & Me.dt_corte_inicia.Text & "' where art_01 = '" & RTrim(tabla.Rows(i).Item(3)) & "'"
                    inv.abm()

                    barra_carga.PictureBox1.Refresh()

                Next

                MessageBox.Show("proceso Terminado correctamente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        End If

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub cmd_actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualiza.Click

        If Me.txt_stk_ant.Text = Me.stk_actual.Text Then

            inv.instruccion = "update art_01 set stock_corte = '" & Me.txt_stk_ant.Text & "', fec_modi= '" & Me.dt_fec_corte.Text & "' where id_art= '" & RTrim(Me.txt_codigo.Text) & "'"
            inv.abm()

            MessageBox.Show("La actualizacion finalizo correctamente!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call limpia()
            Me.txt_codigo.Focus()
            Me.stk_actual.Enabled = False

        End If

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click

        Me.Dispose()

    End Sub

    Private Sub limpia()

        Me.txt_codigo.Text = ""
        Me.lbl_articulo.Text = ""
        Me.txt_stk_ant.Text = ""

    End Sub

    Private Sub Check_stc_actual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_stc_actual.CheckedChanged
        If Me.Check_stc_actual.Checked = True Then
            Me.stk_actual.Enabled = True
            Me.txt_codigo.Focus()
        Else
            Me.stk_actual.Enabled = False
            Me.txt_codigo.Focus()
        End If
    End Sub

    Private Sub stk_actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles stk_actual.KeyPress
        num.positivos_punto(e, Me.stk_actual)
    End Sub

    Private Sub txt_stk_ant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_stk_ant.KeyPress
        num.positivos_punto(e, Me.txt_stk_ant)
    End Sub

    Public Sub calcula_acumulado()

        Dim i, j As Integer
        Dim aux As Double
        Dim acu As Single = Form_seguimiento_art.corte
        Dim tb As New DataTable, tb_art As New DataTable

        comando = New SqlDataAdapter("select nombre,stock_corte from art_01 order by nombre ASC", conex)
        comando.Fill(tb_art)

        For j = 0 To tb_art.Rows.Count - 1

            tb.Clear()

            comando = New SqlDataAdapter("select tipo_fact2,cantidad1,nom_producto,codi_producto from fact_det where nom_producto = '" & RTrim(tb_art.Rows(j).Item(0)) & "'", conex)
            comando.Fill(tb)

            acu = tb_art.Rows(j).Item(1)

            If tb.Rows.Count <> Nothing Then

                For i = 0 To tb.Rows.Count - 1

                    If RTrim(tb.Rows(i).Item(0)) = "FC" Or RTrim(tb.Rows(i).Item(0)) = "RS" Or RTrim(tb.Rows(i).Item(0)) = "PD" Then

                        acu = acu - tb.Rows(i).Item(1)
                        aux = acu
                        acu = aux


                    End If

                    If RTrim(tb.Rows(i).Item(0)) = "NC" Or RTrim(tb.Rows(i).Item(0)) = "RE" Then

                        acu = acu + tb.Rows(i).Item(1)
                        aux = acu
                        acu = aux

                    End If

                Next

                If acu < 0 Then

                    conex = conecta()
                    conex.Open()

                    coman = New SqlCommand("update art_01 set cantidad = '0' where id_art = '" & RTrim(tb.Rows(0).Item(3)) & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()
                    conex.Close()

                End If

                If acu >= 0 Then

                    conex = conecta()
                    conex.Open()

                    coman = New SqlCommand("update art_01 set cantidad = '" & acu & "' where id_art = '" & RTrim(tb.Rows(0).Item(3)) & "'", conex)
                    coman.ExecuteNonQuery()

                    coman.Dispose()
                    conex.Close()

                End If

            End If

        Next

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call corrige_stock_arriba_con_el_de_abajo()
    End Sub

    Private Sub corrige_stock_arriba_con_el_de_abajo()

        Dim art As New DataTable
        Dim fecha, id_art As String
        Dim i, j As Integer
        Dim acu As Single

        art.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select id_art,fec_modi,isnull(stock_corte,0) from art_01 order by convert(int,id_art)", conex)
        comando.Fill(art)
        comando.Dispose()

        For i = 0 To art.Rows.Count - 1

            fecha = art.Rows(i).Item(1)
            id_art = art.Rows(i).Item(0)
            acu = art.Rows(i).Item(2)

            tabla.Clear()

            comando = New SqlDataAdapter("select tipo_fact,letra_fact,prefijo_fact,num_fact1,fec_emision,nombre,cantidad1,estado_fact,talon,fact_det.codi_producto from fact_cab inner join fact_det on fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.tipo_fact = fact_det.tipo_fact2 and fact_cab.letra_fact = fact_det.letra_fact1 and fact_cab.prefijo_fact = fact_det.prefijo_fact2 and fact_cab.num_fact1 = fact_det.num_fact and fact_cab.talon = fact_det.talon1 where fact_det.codi_producto = '" & Trim(id_art) & "' and fact_cab.fec_emision >= '" & fecha & "' and fact_cab.fec_emision <= '01-01-2100' order by fec_emision", conex)
            comando.Fill(tabla)
            comando.Dispose()

            For j = 0 To tabla.Rows.Count - 1

                If RTrim(tabla.Rows(j).Item(0)) = "FC" Or RTrim(tabla.Rows(j).Item(0)) = "RS" Or RTrim(tabla.Rows(j).Item(0)) = "PD" Or RTrim(tabla.Rows(j).Item(0)) = "ND" Then

                    acu = Format(acu - tabla.Rows(j).Item(6), "0.00")

                    If RTrim(tabla.Rows(j).Item(7)) = "Anulado" Then

                        acu = Format(acu + tabla.Rows(j).Item(6), "0.00")

                    End If

                End If

                If RTrim(tabla.Rows(j).Item(0)) = "NC" Or RTrim(tabla.Rows(j).Item(0)) = "RE" Then

                    acu = Format(acu + tabla.Rows(j).Item(6), "0.00")

                    If RTrim(tabla.Rows(j).Item(7)) = "Anulado" Then

                        acu = Format(acu - tabla.Rows(j).Item(6), "0.00")

                    End If

                End If

            Next

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
            End If

            coman = New SqlCommand("UPDATE ART_01 SET CANTIDAD = '" & acu & "' where id_art = '" & id_art & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            Me.lbl_acu.Text = acu
            Me.lbl_acu.Refresh()
            acu = 0

            Me.lbl_total.Text = art.Rows.Count - 1
            Me.lbl_total.Refresh()

            Me.lbl_avance.Text = Me.lbl_avance.Text + 1
            Me.lbl_avance.Refresh()

        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call calcula_acumulado()
    End Sub
End Class