Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Form_defasajes

    Dim comando As SqlDataAdapter
    Dim tbl As New DataTable, tbl1 As New DataTable
    Dim conex As New SqlConnection
    Dim i, j, fila, cont As Integer
    Dim corte As Double

    Private Sub cmd_calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_calcular.Click

        Me.DataGridView1.Rows.Clear()
        fila = 0
        cont = 0

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        conex = conecta()

        tbl.Clear()
        comando = New SqlDataAdapter("select id_art,cantidad,stock_corte,nombre,fec_modi from art_01", conex)
        comando.Fill(tbl)

        For i = 0 To tbl.Rows.Count - 1

            tbl1.Clear()
            comando = New SqlDataAdapter("select cantidad1,tipo_fact2 from fact_det where codi_producto = '" & RTrim(tbl.Rows(i).Item(0)) & "' and fec_emi >= '" & RTrim(tbl.Rows(i).Item(4)) & "'", conex)
            comando.Fill(tbl1)

            If tbl1.Rows.Count <> Nothing Then

                corte = tbl.Rows(i).Item(2)

                For j = 0 To tbl1.Rows.Count - 1

                    If RTrim(tbl1.Rows(j).Item(1)) = "FC" Or RTrim(tbl1.Rows(j).Item(1)) = "RS" Or RTrim(tbl1.Rows(j).Item(1)) = "PD" Then
                        corte = corte - Val(tbl1.Rows(j).Item(0))
                    End If

                    If RTrim(tbl1.Rows(j).Item(1)) = "RE" Or RTrim(tbl1.Rows(j).Item(1)) = "NC" Then
                        corte = corte + Val(tbl1.Rows(j).Item(0))
                    End If

                    barra_carga.PictureBox1.Refresh()

                Next

                Me.DataGridView1.Rows.Add()

                Me.DataGridView1.Rows(fila).Cells(0).Value = tbl.Rows(i).Item(0)
                Me.DataGridView1.Rows(fila).Cells(1).Value = tbl.Rows(i).Item(3)
                Me.DataGridView1.Rows(fila).Cells(2).Value = tbl.Rows(i).Item(1)
                Me.DataGridView1.Rows(fila).Cells(3).Value = corte

                If corte = tbl.Rows(i).Item(1) Then Me.DataGridView1.Rows(fila).Visible = False

                If Me.DataGridView1.Rows(fila).Visible = True Then cont = cont + 1

                fila = fila + 1

            End If

            barra_carga.PictureBox1.Refresh()

        Next

        Me.DataGridView1.Columns(0).DefaultCellStyle.BackColor = Color.LightSalmon
        Me.DataGridView1.Columns(1).DefaultCellStyle.BackColor = Color.LightGreen
        Me.DataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.LightSkyBlue
        Me.DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.LightSkyBlue

        Me.Label1.Visible = True
        Me.Label2.Text = cont

        Me.DataGridView1.Focus()
        barra_carga.Timer1.Enabled = True

    End Sub

End Class