Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Font
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class form_empleado

    Private fuente As Font
    Private directorioFuentes As String

    Dim conex1 As New SqlClient.SqlConnection
    Dim comando As SqlClient.SqlDataAdapter
    Dim coman As SqlClient.SqlCommand
    Dim reader As SqlDataReader

    Dim duplicado, existe As Boolean
    Dim tb As New DataTable
    Dim codbar, dni As String
    Dim longitud, indice As Integer
    Dim customerReport As ReportDocument
    Dim hn As Char = "N"
    Dim estado As Char = "A"
    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If txt_dni.Text = String.Empty Then
                lblCodigo.Text = "Tiene que haber un D.N.I"
            Else
                dni = arma_codigo_barra(Me.txt_dni.Text)
                lblCodigo.Text = ean13(dni)
                DataGridView1.Focus()

                llena_tabla_empleado()

                limpia_controles()
                cargar_empleados_grilla()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function arma_codigo_barra(ByVal valor As String) As String

        longitud = Len(valor)
        If longitud = 8 Then dni = txt_dni.Text & "0123"
        If longitud = 7 Then dni = txt_dni.Text & "01234"

        Return dni

    End Function

    Private Sub form_empleado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
    End Sub

    Private Sub form_empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If conex1.State = ConnectionState.Closed Then
                conex1 = conecta1()
                conex1.Open()
            End If

            deshabilita_botones_imprimir_borrar()

            Me.cmb_calcula_horas_noct.Text = Me.cmb_calcula_horas_noct.Items(0)
            Me.cmb_sector.Text = Me.cmb_sector.Items(0)
            Me.cmb_estado.Text = Me.cmb_estado.Items(0)

        Catch ex As Exception

            MessageBox.Show("Verifique existencia tablas!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()

        End Try

    End Sub

    Private Sub deshabilita_botones_imprimir_borrar()

        Me.cmd_imprime_tar.Enabled = False
        Me.cmd_imprime_tar.BackColor = Color.LightGray
        Me.cmd_imprime_qr.Enabled = False
        Me.cmd_imprime_qr.BackColor = Color.LightGray
        Me.cmd_eliminar.BackColor = Color.LightGray
        Me.cmd_eliminar.Enabled = False

    End Sub

    Private Sub habilita_botones_imprimir_borrar()

        Me.cmd_imprime_tar.Enabled = True
        Me.cmd_imprime_tar.BackColor = Color.Black
        Me.cmd_imprime_qr.Enabled = True
        Me.cmd_imprime_qr.BackColor = Color.Black
        Me.cmd_eliminar.BackColor = Color.Black
        Me.cmd_eliminar.Enabled = Enabled

    End Sub

    Private Sub cargar_empleados_ficha()

        Try

            tb.Clear()
            comando = New SqlClient.SqlDataAdapter("select id,nombre,direccion,'' as altura,codigoqr,telefono,id,rutafoto,codigobarra,sector,horas_nocturnas,estado from MEempleado where id = '" & RTrim(Me.txt_legajo.Text) & "' order by nombre ASC", conex1)
            comando.Fill(tb)

            txt_legajo.Text = Trim(tb.Rows(0).Item(0))
            txt_nombre.Text = Trim(tb.Rows(0).Item(1))
            txt_direccion.Text = Trim(tb.Rows(0).Item(2) & " " & tb.Rows(0).Item(3))
            txt_dni.Text = Trim(tb.Rows(0).Item(4))
            txt_telefono.Text = Trim(tb.Rows(0).Item(5))
            txt_foto.Text = Trim(tb.Rows(0).Item(7))
            PictureBox1.ImageLocation = txt_foto.Text
            codbar = Trim(tb.Rows(0).Item(8))

            indice = Me.cmb_sector.FindString(Trim(tb.Rows(0).Item(9)))
            Me.cmb_sector.Text = Me.cmb_sector.Items(indice)

            indice = Me.cmb_calcula_horas_noct.FindString(Trim(tb.Rows(0).Item(10)))
            Me.cmb_calcula_horas_noct.Text = Me.cmb_calcula_horas_noct.Items(indice)

            indice = Me.cmb_estado.FindString(Trim(tb.Rows(0).Item(11)))
            Me.cmb_estado.Text = Me.cmb_estado.Items(indice)

            Me.lblCodigo.Text = ean13(codbar)

            Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue
            Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

            habilita_botones_imprimir_borrar()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargar_empleados_grilla()

        tb.Clear()
        If Me.chk_todos.Checked = False Then comando = New SqlClient.SqlDataAdapter("select id,nombre,direccion,'' as altura,codigoqr,telefono,id,rutafoto,codigobarra,sector,horas_nocturnas,estado from MEempleado where nombre like '" & RTrim(Me.txt_busca_empl.Text) & "%' and estado = 'A' order by nombre ASC", conex1)
        If Me.chk_todos.Checked = True Then comando = New SqlClient.SqlDataAdapter("select id,nombre,direccion,'' as altura,codigoqr,telefono,id,rutafoto,codigobarra,sector,horas_nocturnas,estado from MEempleado where nombre like '" & RTrim(Me.txt_busca_empl.Text) & "%' and (estado = 'A' or estado = 'B') order by nombre ASC", conex1)
        comando.Fill(tb)

        DataGridView1.DataSource = tb

        DataGridView1.Columns(0).HeaderText = "Legajo"
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).HeaderText = "Nombre"
        DataGridView1.Columns(1).Width = 200

    End Sub

    Private Sub llena_datos_empleado()

        Try

            limpia_controles()

            txt_legajo.Text = Trim(DataGridView1.SelectedCells.Item(0).Value)
            txt_nombre.Text = Trim(DataGridView1.SelectedCells.Item(1).Value)
            txt_direccion.Text = Trim(DataGridView1.SelectedCells.Item(2).Value & " " & DataGridView1.SelectedCells.Item(3).Value)
            txt_dni.Text = Trim(DataGridView1.SelectedCells.Item(4).Value)
            txt_telefono.Text = Trim(DataGridView1.SelectedCells.Item(5).Value)
            txt_foto.Text = Trim(DataGridView1.SelectedCells.Item(7).Value)
            PictureBox1.ImageLocation = txt_foto.Text
            codbar = Trim(Me.DataGridView1.SelectedCells.Item(8).Value)

            indice = Me.cmb_sector.FindString(Trim(Me.DataGridView1.SelectedCells.Item(9).Value))
            Me.cmb_sector.Text = Me.cmb_sector.Items(indice)

            indice = Me.cmb_calcula_horas_noct.FindString(Trim(Me.DataGridView1.SelectedCells.Item(10).Value))
            Me.cmb_calcula_horas_noct.Text = Me.cmb_calcula_horas_noct.Items(indice)

            indice = Me.cmb_estado.FindString(Trim(Me.DataGridView1.SelectedCells.Item(11).Value))
            Me.cmb_estado.Text = Me.cmb_estado.Items(indice)

            Me.lblCodigo.Text = ean13(codbar)

            Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue
            Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

            habilita_botones_imprimir_borrar()

            Me.txt_busca_empl.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Public Function ean13(ByVal chaine)

        Dim checksum, first, CodeBarre, Codigo_Barra As String
        Dim tableA As Boolean
        Dim i, verificador As Integer
        ean13 = ""
        If Len(chaine) = 12 Then
            For i = 1 To 12
                If Asc(Mid(chaine, i, 1)) < 48 Or Asc(Mid(chaine, i, 1)) > 57 Then
                    i = 0
                    Exit For
                End If
            Next
            If i = 13 Then
                For i = 12 To 1 Step -2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                checksum = checksum * 3
                For i = 11 To 1 Step -2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                verificador = (10 - checksum Mod 10) Mod 10
                chaine = chaine & verificador
                Codigo_Barra = chaine
                CodeBarre = Microsoft.VisualBasic.Left(chaine, 1) & Chr(65 + Val(Mid(chaine, 2, 1)))
                first = Val(Microsoft.VisualBasic.Left(chaine, 1))
                For i = 3 To 7
                    tableA = False
                    Select Case i
                        Case 3
                            Select Case first
                                Case 0 To 3
                                    tableA = True
                            End Select
                        Case 4
                            Select Case first
                                Case 0, 4, 7, 8
                                    tableA = True
                            End Select
                        Case 5
                            Select Case first
                                Case 0, 1, 4, 5, 9
                                    tableA = True
                            End Select
                        Case 6
                            Select Case first
                                Case 0, 2, 5, 6, 7
                                    tableA = True
                            End Select
                        Case 7
                            Select Case first
                                Case 0, 3, 6, 8, 9
                                    tableA = True
                            End Select
                    End Select
                    If tableA Then
                        CodeBarre = CodeBarre & Chr(65 + Val(Mid(chaine, i, 1)))
                    Else
                        CodeBarre = CodeBarre & Chr(75 + Val(Mid(chaine, i, 1)))
                    End If
                Next
                CodeBarre = CodeBarre & "*"
                For i = 8 To 13
                    CodeBarre = CodeBarre & Chr(97 + Val(Mid(chaine, i, 1)))
                Next
                CodeBarre = CodeBarre & "+"
                ean13 = CodeBarre
            End If
        End If
    End Function

    Private Sub cmd_busca_foto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd_busca_foto.Click

        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        txt_foto.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = txt_foto.Text
    End Sub

    Private Sub llena_tabla_empleado()

        'If conex.State = ConnectionState.Closed Then conex.Open()
        'conex = conecta()

        Try

            coman = New SqlClient.SqlCommand("insert into MEempleado(id,rutafoto,codigobarra,sector,nombre,horas_nocturnas,codigoqr,direccion,telefono,estado) values ('" & Trim(Me.txt_legajo.Text) & "','" & Trim(Me.txt_foto.Text) & "','" & dni & "','" & Me.cmb_sector.Text & "','" & Trim(Me.txt_nombre.Text) & "','" & Trim(hn) & "','" & Trim(Me.txt_dni.Text) & "','" & Trim(Me.txt_direccion.Text) & "','" & Trim(Me.txt_telefono.Text) & "','" & Trim(estado) & "')", conex1)
            coman.ExecuteNonQuery()
            coman.Dispose()

        Catch ex As Exception

            coman = New SqlClient.SqlCommand("update MEempleado set rutafoto = '" & txt_foto.Text & "',codigobarra = '" & dni & "',sector = '" & Me.cmb_sector.Text & "',nombre = '" & Trim(Me.txt_nombre.Text) & "',horas_nocturnas = '" & Trim(hn) & "',codigoqr = '" & Trim(Me.txt_dni.Text) & "',direccion = '" & Trim(Me.txt_direccion.Text) & "',telefono = '" & Trim(Me.txt_telefono.Text) & "',estado ='" & Trim(estado) & "' where id = '" & Trim(Me.txt_legajo.Text) & "'", conex1)
            coman.ExecuteNonQuery()
            coman.Dispose()

        Finally

            'If conex.State = ConnectionState.Open Then conex.Close()

        End Try

    End Sub

    Private Sub cmd_imprime_tar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_imprime_tar.Click

        customerReport = New ReportDocument()
        customerReport.Load(Application.StartupPath & "\ficha.rpt")

        txt = customerReport.ReportDefinition.Sections("Section2").ReportObjects.Item("txtcodebar")
        txt.Text = ean13(codbar)

        txt = customerReport.ReportDefinition.Sections("Section2").ReportObjects.Item("txtnombre")
        txt.Text = Me.txt_nombre.Text

        'txt = customerReport.ReportDefinition.Sections("Section2").ReportObjects.Item("txtcodebar1")
        'txt.Text = ean13(codbar)

        'txt = customerReport.ReportDefinition.Sections("Section2").ReportObjects.Item("txtnombre1")
        'txt.Text = Me.txt_nombre.Text

        customerReport.PrintToPrinter(1, False, 0, 0)
       
    End Sub

    Private Sub txt_busca_empl_GotFocus(sender As Object, e As EventArgs) Handles txt_busca_empl.GotFocus
        Me.txt_busca_empl.SelectAll()
    End Sub

    Private Sub txt_busca_empl_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_busca_empl.KeyDown
        If e.KeyCode = Keys.Return Then

            If Me.txt_busca_empl.Text = "" Then
                Me.txt_busca_empl.Focus()
                Exit Sub
            End If

            Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGreen
            Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
            Me.DataGridView1.Focus()

        End If
    End Sub

    Private Sub txt_busca_empl_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_busca_empl.KeyUp
        If Me.txt_busca_empl.Text <> "" Then
            cargar_empleados_grilla()
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Then
            e.SuppressKeyPress = True
            llena_datos_empleado()
        End If
    End Sub

    Private Sub limpia_controles()

        txt_legajo.Text = ""
        txt_nombre.Text = ""
        txt_direccion.Text = ""
        txt_dni.Text = ""
        txt_telefono.Text = ""
        txt_foto.Text = ""
        PictureBox1.ImageLocation = ""
        codbar = ""
        Me.lblCodigo.Text = ""
        Me.txt_busca_empl.Text = ""

        deshabilita_botones_imprimir_borrar()

    End Sub

    Private Sub cmb_calcula_horas_noct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_calcula_horas_noct.SelectedIndexChanged
        If Me.cmb_calcula_horas_noct.Text = "SI" Then
            hn = "S"
        Else
            hn = "N"
        End If
    End Sub

    Private Sub txt_dni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_dni.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_dni_TextChanged(sender As Object, e As EventArgs) Handles txt_dni.TextChanged
        QrCodeImgControl1.Text = Me.txt_dni.Text
    End Sub

    Private Sub cmd_imprime_qr_Click(sender As Object, e As EventArgs) Handles cmd_imprime_qr.Click

        Dim img As Image = DirectCast(QrCodeImgControl1.Image.Clone, Image)
        Dim sv As New SaveFileDialog
        sv.AddExtension = True
        sv.FileName = Trim(Me.txt_nombre.Text)
        sv.Filter = "Imagen JPG (*.jpg)|*.jpg"
        sv.ShowDialog()
        If Not String.IsNullOrEmpty(sv.FileName) Then
            img.Save(sv.FileName)
        End If
        img.Dispose()

    End Sub

    Private Sub txt_legajo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_legajo.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txt_legajo.Text <> "" Then
                cargar_empleados_ficha()
            End If
        End If
    End Sub

    Private Sub txt_telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono.KeyPress
        If InStr(1, "0123456789-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_legajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_legajo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub verifica_codbarra_Y_qr_duplicado()

        Dim tb1 As New DataTable
        tb1.Clear()

        comando = New SqlDataAdapter("select * from MEempleado where codigobarra = '" & Trim(dni) & "' or codigoqr = '" & Trim(Me.txt_dni.Text) & "'", conex1)
        comando.Fill(tb1)

        If tb1.Rows.Count > 0 Then
            duplicado = True
        Else
            duplicado = False
        End If

        tb1.Dispose()
        comando.Dispose()

    End Sub

    Private Sub cmd_eliminar_Click(sender As Object, e As EventArgs) Handles cmd_eliminar.Click

        Dim x As Short = MessageBox.Show("Esta seguro que desea borra el registro??", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If x = 6 Then

            verifica_movimientos(Me.txt_legajo.Text)

            If existe = True Then
                MessageBox.Show("No se puede borra el registro... existe movimientos!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            coman = New SqlClient.SqlCommand("Delete from MEempleado where id = '" & Trim(Me.txt_legajo.Text) & "'", conex1)
            coman.ExecuteNonQuery()
            coman.Dispose()

            limpia_controles()

        End If

        x = Nothing

    End Sub

    Private Sub verifica_movimientos(ByVal codigo As String)

        Dim tb2 As New DataTable

        Try

            tb2.Clear()

            comando = New SqlDataAdapter("select * from MEmovempleado where id = '" & Trim(Me.txt_legajo.Text) & "'", conex1)
            comando.Fill(tb2)

            If tb2.Rows.Count > 0 Then
                existe = True
            Else
                existe = False
            End If

        Catch ex As Exception

        Finally

            tb2.Dispose()
            comando.Dispose()

        End Try

    End Sub

    Private Sub cmb_estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_estado.SelectedIndexChanged
        If Me.cmb_estado.Text = "Alta" Then
            estado = "A"
        Else
            estado = "B"
        End If
    End Sub
End Class