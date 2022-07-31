Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net

Public Class Form_lista_oferta

    Dim xxx As New pymsoft.prov_vend_list_bco
    Dim correo1 As New pymsoft.enviar_mail
    Dim comando As SqlCommand
    Dim conex As New SqlConnection
    Dim coma As SqlDataAdapter

    Private Sub txt_lista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lista.KeyDown

        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then

            xxx.instruccion = "select *from lista_01 where id_lis like '" & Me.txt_lista.Text & "'"
            xxx.codigo = "id_lis"
            xxx.nombre = "nombre"
            xxx.cargar()
            Me.txt_lista.Text = xxx.text
            Me.lbl_lista.Text = xxx.text2

            Me.txt_art.Focus()

        End If

        If e.KeyCode = Keys.F1 Then
            busc_lista.Show()
        End If

    End Sub

    Private Sub txt_art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_art.KeyDown

        If e.KeyCode = Keys.F1 Then
            If Me.txt_lista.Text <> "" Then
                busc_articulos.txt_lista.Text = Me.txt_lista.Text
                busc_articulos.Show()
            End If
        End If

    End Sub

    Private Sub Form_lista_oferta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_lista.Focus()
        Me.DateTimePicker2.Text = Date.Now.AddDays(7)
    End Sub

    Private Sub Tool_guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_guarda.Click

        Dim i As Integer
        Dim x As String

        x = MessageBox.Show("Esto borrara la lista anterior,si existe.. Desea continuar ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x = 7 Then Exit Sub

        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()

        comando = New SqlCommand("delete list_oferta", conex)
        comando.ExecuteNonQuery()

        comando.Dispose()

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            Dim v As String = Me.DataGridView1.Rows(i).Cells(1).Value

            If IsNumeric(Me.DataGridView1.Rows(i).Cells(1).Value) = False Then
                MessageBox.Show("Compruebe precios,..error en artculo:" & " " & Me.DataGridView1.Rows(i).Cells(0).Value, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Next

        For i = 0 To Me.DataGridView1.Rows.Count - 2

            Dim s As String = Me.DataGridView1.Rows(i).Cells(1).Value

            comando = New SqlCommand("insert into list_oferta(detalle,precio,precio_bonif,fec_desde,fec_hasta) values ('" & Me.DataGridView1.Rows(i).Cells(0).Value & "', '" & Me.DataGridView1.Rows(i).Cells(1).Value & "','" & Me.DataGridView1.Rows(i).Cells(2).Value & "','" & Me.DateTimePicker1.Text & "', '" & Me.DateTimePicker2.Text & "')", conex)
            comando.ExecuteNonQuery()

            comando.Dispose()

        Next

        conex.Close()

    End Sub

    Private Sub Tool_carga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_carga.Click

        Dim tbl As New DataTable
        Dim i As Integer

        conex = conecta()

        Me.DataGridView1.Rows.Clear()

        coma = New SqlDataAdapter("select detalle,precio,precio_bonif from list_oferta", conex)
        coma.Fill(tbl)
        coma.Dispose()

        For i = 0 To tbl.Rows.Count - 1

            Me.DataGridView1.Rows.Add()

            Me.DataGridView1.Rows(i).Cells(0).Value = tbl.Rows(i).Item(0)
            Me.DataGridView1.Rows(i).Cells(1).Value = tbl.Rows(i).Item(1)
            Me.DataGridView1.Rows(i).Cells(2).Value = tbl.Rows(i).Item(2)

        Next

    End Sub

    Private Sub Tool_imprime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_imprime.Click

        Dim rep As New ofertas

        rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        rep.PrintToPrinter(1, False, 0, 0)

    End Sub

    Private Sub Tool_borra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_borra.Click

        Call borrar()

    End Sub

    Private Sub borrar()

        Try

            Dim z As Integer = Me.DataGridView1.CurrentCell.RowIndex

            Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(z))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Delete Then

            Call borrar()

        End If

        If e.KeyCode = Keys.F2 Then

            Me.DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        End If

    End Sub

    Private Sub tool_previa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tool_previa.Click

        Dim rep As New ofertas

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, "")

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\Manual\oferta.html")
    End Sub

    Private Sub tool_mail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tool_mail.Click

        'correo1.enviar_mail("pablo_tiu@hotmail.com", "pcpymsoft@gmail.com", "Lista de precios", "C:\Users\usuario\Downloads\caldera.pdf", "", "smtp.gmail.com", 587, "pcpymsoft@gmail.com", 28064563)

    End Sub

End Class