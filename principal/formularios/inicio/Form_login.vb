Imports System.Data
Imports System.Data.SqlClient

Public Class Form_login

    Dim tbl As New DataTable, tbl1 As New DataTable, tbl2 As New DataTable
    Dim conex As New SqlConnection
    Dim comando1 As SqlCommand
    Dim comando As SqlDataAdapter
    Dim midataset As New DataSet
    Dim art As New pymsoft.articulo
    Dim act As New pymsoft.activate
    Dim computadora As String
    Public cambia_usuario As Boolean = True
    Public verifica As Boolean

    Private Sub Form_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        'System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/YYYY"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        Call carga()
        Me.DateTimePicker1.Text = Date.Now
        computadora = My.Computer.Name

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click

        midataset.Dispose()
        Me.Dispose()

    End Sub

    Public Sub cargar()

        conex = conecta()
        conex.Open()

        comando1 = New SqlCommand("select *from usuario_01 where nombre like '" & Me.cmb_usuario.Text & "' and contraseña like '" & Me.txt_contraseña.Text & "'", conex)

        Dim reader As SqlDataReader = comando1.ExecuteReader

        While reader.Read()

            Me.txt_contraseña.Text = ""
            bienvenida.Show()

        End While

        conex.Close()
        reader.Close()

        Call verifica_si_existe_comprobante()
        Call act_stk(computadora)

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click


        Call verifica_activacion()
        Call cargar()

    End Sub

    Private Sub txt_contraseña_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_contraseña.KeyDown
        If e.KeyCode = Keys.Return Then
            Call verifica_activacion()
            Call cargar()
        End If
    End Sub

    Public Sub carga()

        midataset.Clear()

        conex = conecta()
        comando = New SqlDataAdapter("select *from menu_usu where estado like 'Activo'", conex)
        comando.Fill(midataset, "menu_usu")

        Me.cmb_usuario.DataSource = midataset.Tables(0)
        Me.cmb_usuario.DisplayMember = "usuario"

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Timer1.Interval = 200 Then
            Me.Show()
            Me.Timer1.Enabled = False
        End If
    End Sub

    Public Sub act_stk(ByVal computer)

        Try

            If conex.State = ConnectionState.Closed Then
                conex = conecta()
                conex.Open()
            End If

            If verifica = True Then

                Dim cant As Double = 0
                Dim i As Integer

                tbl1.Clear()

                comando = New SqlDataAdapter("select * from act_art where computer = '" & computer & "'", conex)
                comando.Fill(tbl1)
                comando.Dispose()

                For i = 0 To tbl1.Rows.Count - 1

                    comando = New SqlDataAdapter("select cantidad,mueve_stok from art_01 where id_art = '" & tbl1.Rows(i).Item(0) & "'", conex)
                    comando.Fill(tbl2)
                    comando.Dispose()

                    If RTrim(tbl1.Rows(i).Item(4)) = "FC" Or RTrim(tbl1.Rows(i).Item(4)) = "RS" Or RTrim(tbl1.Rows(i).Item(4)) = "PD" Then cant = tbl1.Rows(i).Item(2) + tbl2.Rows(0).Item(0)
                    If RTrim(tbl1.Rows(i).Item(4)) = "NC" Or RTrim(tbl1.Rows(i).Item(4)) = "RE" Then cant = tbl2.Rows(0).Item(0) - tbl1.Rows(i).Item(2)

                    If RTrim(tbl2.Rows(0).Item(1)) = "SI" Then

                        comando1 = New SqlCommand("Update art_01 set cantidad = '" & cant & "', cant_ant = 0 where id_art = '" & tbl1.Rows(i).Item(0) & "'", conex)
                        comando1.ExecuteNonQuery()
                        comando1.Dispose()

                    Else

                        comando1 = New SqlCommand("Update art_01 set cantidad = 0, cant_ant= 0 where id_art = '" & tbl1.Rows(i).Item(0) & "'", conex)
                        comando1.ExecuteNonQuery()
                        comando1.Dispose()

                    End If

                    tbl2.Clear()

                Next

            Else

                comando1 = New SqlCommand("Update art_01 set cant_ant= 0", conex)
                comando1.ExecuteNonQuery()
                comando1.Dispose()


            End If

            If form_factura.sale = False Then

                comando1 = New SqlCommand("delete act_art where computer = '" & computer & "'", conex)
                comando1.ExecuteNonQuery()
                comando1.Dispose()

                verifica = True

            End If

        Catch ex As Exception

        Finally

            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If

        End Try

    End Sub

    Private Sub verifica_activacion()

        Try

            Dim tbl0 As New DataTable

            conex = conecta()

            comando = New SqlDataAdapter("select fecha,cont from activate where estado = 'A'", conex)
            comando.Fill(tbl0)

            If tbl0.Rows.Count = Nothing Then Exit Sub

            If tbl0.Rows(0).Item(1) >= 45 Then
                MessageBox.Show("Active el Software", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
                Exit Sub
            End If

            If RTrim(tbl0.Rows(0).Item(0)) <> Me.DateTimePicker1.Text Then

                If conex.State = ConnectionState.Closed Then conex.Open()

                comando1 = New SqlCommand("update activate set cont = '" & tbl0.Rows(0).Item(1) + 1 & "',fecha = '" & Me.DateTimePicker1.Text & "'", conex)
                comando1.ExecuteNonQuery()

                conex.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Timer2.Interval = 50 Then
            cambia_usuario = False
            principal.Dispose()
            Me.Timer2.Enabled = False
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.Timer2.Interval = 50 Then
            form_factura.Show()
            Me.Timer3.Enabled = False
        End If
    End Sub

    Private Sub verifica_si_existe_comprobante()

        Dim ttb As New DataTable, tb_fact As New DataTable
        Dim i As Integer

        ttb.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select numero,tipo,lt,pre,talonario from act_art", conex)
        comando.Fill(ttb)

        For i = 0 To ttb.Rows.Count - 1

            tb_fact.Clear()

            comando = New SqlDataAdapter("select * from fact_cab where num_fact1 = '" & RTrim(ttb.Rows(i).Item(0)) & "' and tipo_fact = '" & RTrim(ttb.Rows(i).Item(1)) & "' and letra_fact = '" & RTrim(ttb.Rows(i).Item(2)) & "' and prefijo_fact = '" & RTrim(ttb.Rows(i).Item(3)) & "' and talon = '" & RTrim(ttb.Rows(i).Item(4)) & "'", conex)
            comando.Fill(tb_fact)

            If tb_fact.Rows.Count = Nothing Or RTrim(ttb.Rows(i).Item(1)) = "PD" Then
                verifica = True
            Else
                verifica = False
            End If

        Next

    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If Me.Timer4.Interval = 50 Then
            Form_recibos.txt_estado_form.Text = 1
            Form_recibos.txt_tipo.Text = "RC"
            Form_recibos.Show()
            Me.Timer4.Enabled = False
        End If
    End Sub
End Class