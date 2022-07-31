Imports System.Data
Imports System.Data.SqlClient

Public Class Form_plan_cuenta

    Dim coman As SqlCommand
    Dim conex As New SqlConnection
    Dim tbl As New DataTable, tbl_dup As New DataTable
    Dim comando As SqlDataAdapter
    Dim fila, col As Integer
    Dim sale As Boolean

    Private Sub Form_plan_cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer

        Me.cmb_nuevo.Text = Me.cmb_nuevo.Items(0)

        tbl.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select *from plan_cuenta", conex)
        comando.Fill(tbl)

        For i = 0 To tbl.Rows.Count - 1

            Me.DataGridView1.Rows.Add()

            Me.DataGridView1.Rows(i).Cells(0).Value = tbl.Rows(i).Item(0)
            Me.DataGridView1.Rows(i).Cells(1).Value = tbl.Rows(i).Item(1)
            Me.DataGridView1.Rows(i).Cells(2).Value = tbl.Rows(i).Item(2)
            Me.DataGridView1.Rows(i).Cells(3).Value = tbl.Rows(i).Item(3)
            Me.DataGridView1.Rows(i).Cells(4).Value = tbl.Rows(i).Item(4)

        Next

        Me.DataGridView1.Columns(0).DefaultCellStyle.BackColor = Color.LightBlue
        Me.DataGridView1.Columns(1).DefaultCellStyle.BackColor = Color.LightGreen
        Me.DataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.LightSalmon
        Me.DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.LightYellow

    End Sub

    Private Sub cmd_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_agregar.Click

        Call verifica_duplicado()

        If sale = True Then Exit Sub

        If Me.txt_codigo.Text = "" Or Me.txt_nombre.Text = "" Then
            MessageBox.Show("Complete todos los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim ins As Integer = Me.DataGridView1.CurrentCell.RowIndex
        Me.DataGridView1.Rows.Insert(ins + 1)

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        If RTrim(Me.cmb_nuevo.Text) = "CAPITULO" Then

            coman = New SqlCommand("insert into plan_cuenta(capitulo,cuenta) values ('" & Me.txt_nombre.Text & "', '" & Me.txt_codigo.Text & "')", conex)
            coman.ExecuteNonQuery()

            conex.Close()
            coman.Dispose()

            Me.DataGridView1.Rows(ins + 1).Cells(0).Value = Me.txt_nombre.Text
            Me.DataGridView1.Rows(ins + 1).Cells(4).Value = Me.txt_codigo.Text

        End If

        If RTrim(Me.cmb_nuevo.Text) = "SUB CAPITULO" Then

            coman = New SqlCommand("insert into plan_cuenta(sub_capitulo,cuenta) values ('" & Me.txt_nombre.Text & "', '" & Me.txt_codigo.Text & "')", conex)
            coman.ExecuteNonQuery()

            conex.Close()
            coman.Dispose()

            Me.DataGridView1.Rows(ins + 1).Cells(1).Value = Me.txt_nombre.Text
            Me.DataGridView1.Rows(ins + 1).Cells(4).Value = Me.txt_codigo.Text

        End If

        If RTrim(Me.cmb_nuevo.Text) = "RUBRO" Then

            coman = New SqlCommand("insert into plan_cuenta(rubro,cuenta) values ('" & Me.txt_nombre.Text & "', '" & Me.txt_codigo.Text & "')", conex)
            coman.ExecuteNonQuery()

            conex.Close()
            coman.Dispose()

            Me.DataGridView1.Rows(ins + 1).Cells(2).Value = Me.txt_nombre.Text
            Me.DataGridView1.Rows(ins + 1).Cells(4).Value = Me.txt_codigo.Text

        End If

        If RTrim(Me.cmb_nuevo.Text) = "NOMBRE" Then

            coman = New SqlCommand("insert into plan_cuenta(nombre,cuenta) values ('" & Me.txt_nombre.Text & "', '" & Me.txt_codigo.Text & "')", conex)
            coman.ExecuteNonQuery()

            conex.Close()
            coman.Dispose()

            Me.DataGridView1.Rows(ins + 1).Cells(3).Value = Me.txt_nombre.Text
            Me.DataGridView1.Rows(ins + 1).Cells(4).Value = Me.txt_codigo.Text

        End If

        Me.txt_codigo.Focus()

    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        Me.txt_codigo.SelectAll()
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click

        Try

            Dim x As Integer = MessageBox.Show("Esta seguro de borrar este campo", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If x <> 6 Then Exit Sub

            If col = 0 Then
                MessageBox.Show("No se puede borrar un capitulo", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            fila = Me.DataGridView1.CurrentCell.RowIndex

            coman = New SqlCommand("delete plan_cuenta where cuenta = '" & RTrim(Me.DataGridView1.Rows(fila).Cells(4).Value) & "'", conex)
            coman.ExecuteNonQuery()

            conex.Close()
            coman.Dispose()

            Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(fila))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.GotFocus
        Me.txt_nombre.SelectAll()
    End Sub

    Private Sub cmd_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_salir.Click
        Me.Close()
    End Sub

    Private Sub cmd_edita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_edita.Click

        If sale = True Then Exit Sub

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        If col = 0 Then
            coman = New SqlCommand("update plan_cuenta set cuenta = '" & Me.txt_codigo.Text & "',capitulo = '" & Me.txt_nombre.Text & "' where cuenta = '" & RTrim(Me.DataGridView1.Rows(fila).Cells(4).Value) & "'", conex)
            coman.ExecuteNonQuery()

            Me.DataGridView1.Rows(fila).Cells(4).Value = Me.txt_codigo.Text
            Me.DataGridView1.Rows(fila).Cells(0).Value = Me.txt_nombre.Text

        End If

        If col = 1 Then
            coman = New SqlCommand("update plan_cuenta set cuenta = '" & Me.txt_codigo.Text & "',sub_capitulo = '" & Me.txt_nombre.Text & "' where cuenta = '" & RTrim(Me.DataGridView1.Rows(fila).Cells(4).Value) & "'", conex)
            coman.ExecuteNonQuery()

            Me.DataGridView1.Rows(fila).Cells(4).Value = Me.txt_codigo.Text
            Me.DataGridView1.Rows(fila).Cells(1).Value = Me.txt_nombre.Text

        End If

        If col = 2 Then
            coman = New SqlCommand("update plan_cuenta set cuenta = '" & Me.txt_codigo.Text & "',rubro = '" & Me.txt_nombre.Text & "' where cuenta = '" & RTrim(Me.DataGridView1.Rows(fila).Cells(4).Value) & "'", conex)
            coman.ExecuteNonQuery()

            Me.DataGridView1.Rows(fila).Cells(4).Value = Me.txt_codigo.Text
            Me.DataGridView1.Rows(fila).Cells(2).Value = Me.txt_nombre.Text

        End If

        If col = 3 Then
            coman = New SqlCommand("update plan_cuenta set cuenta = '" & Me.txt_codigo.Text & "',nombre = '" & Me.txt_nombre.Text & "' where cuenta = '" & RTrim(Me.DataGridView1.Rows(fila).Cells(4).Value) & "'", conex)
            coman.ExecuteNonQuery()

            Me.DataGridView1.Rows(fila).Cells(4).Value = Me.txt_codigo.Text
            Me.DataGridView1.Rows(fila).Cells(3).Value = Me.txt_nombre.Text

        End If

        Me.txt_codigo.Text = ""
        Me.txt_nombre.Text = ""

        Me.cmb_nuevo.Enabled = True

        conex.Close()
        coman.Dispose()

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            If e.KeyCode = Keys.Return Then

                Me.txt_codigo.Text = ""
                Me.txt_nombre.Text = ""

                fila = Me.DataGridView1.CurrentCell.RowIndex
                col = Me.DataGridView1.CurrentCell.ColumnIndex

                Me.cmb_nuevo.Enabled = False

                Me.txt_codigo.Text = Me.DataGridView1.Rows(fila).Cells(4).Value
                Me.txt_nombre.Text = Me.DataGridView1.Rows(fila).Cells(col).Value

                If col = 0 Then
                    Me.cmb_nuevo.Text = Me.cmb_nuevo.Items(0)
                End If

                If col = 1 Then
                    Me.cmb_nuevo.Text = Me.cmb_nuevo.Items(1)
                End If

                If col = 2 Then
                    Me.cmb_nuevo.Text = Me.cmb_nuevo.Items(2)
                End If

                If col = 3 Then
                    Me.cmb_nuevo.Text = Me.cmb_nuevo.Items(3)
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_imprimir.Click

        Dim rep As New plan_cuenta

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

    End Sub

    Private Sub verifica_duplicado()

        conex = conecta()
        tbl_dup.Clear()

        comando = New SqlDataAdapter("select cuenta from plan_cuenta where cuenta = '" & RTrim(Me.txt_codigo.Text) & "'", conex)
        comando.Fill(tbl_dup)

        If tbl_dup.Rows.Count <> Nothing Then
            MessageBox.Show("Existe una cuenta con este numero", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            sale = True
        Else
            sale = False
        End If

    End Sub

End Class