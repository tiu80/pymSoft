Imports System.Data
Imports System.Data.SqlClient

Public Class Form_moneda

    Dim comando As SqlDataAdapter
    Dim tb As DataTable
    Dim conex As New SqlConnection
    Dim coman As SqlCommand
    Dim i As Integer

    Dim art As New pymsoft.articulo
    Dim fact As New pymsoft.factura

    Private Sub Form_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fact.carga_parametro()

        Me.cmb_moneda.Text = Me.cmb_moneda.Items(0)

        selecciona_datos()

    End Sub

    Private Sub selecciona_datos()

        tb = New DataTable
        tb.Clear()

        Try

            conex = conecta()

            comando = New SqlDataAdapter("Select fecha,id,importe from moneda order by fecha", conex)
            comando.Fill(tb)
            comando.Dispose()

            Me.DataGridView1.DataSource = tb

            Me.cmd_modificar.BackColor = Color.LightGray

        Catch ex As Exception

            tb.Dispose()

        End Try

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Try

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("INSERT INTO moneda(id,fecha,importe) VALUES('" + Me.cmb_moneda.Text + "' , '" + Me.dt_fecha.Text + "','" + Me.txt_importe.Text + "')", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            principal.lbl_moneda.Text = Me.cmb_moneda.Text & " " & Me.txt_importe.Text

            selecciona_datos()

            Me.dt_fecha.Focus()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally

            If conex.State = ConnectionState.Open Then conex.Close()

        End Try
        
    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click

        Try

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("DELETE moneda WHERE id = '" & Me.DataGridView1.SelectedCells(1).Value & "' and fecha = '" & Me.DataGridView1.SelectedCells(0).Value & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            Me.dt_fecha.Focus()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally

            If conex.State = ConnectionState.Open Then conex.Close()
            selecciona_datos()

        End Try

    End Sub

    Private Sub cmd_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_modificar.Click

        Try

            conex = conecta()
            If conex.State = ConnectionState.Closed Then conex.Open()

            coman = New SqlCommand("update moneda set importe = '" & Me.txt_importe.Text & "' where id ='" & Me.cmb_moneda.Text & "' and fecha = '" & Me.dt_fecha.Text & "'", conex)
            coman.ExecuteNonQuery()
            coman.Dispose()

            Me.cmd_aceptar.Enabled = True
            Me.cmd_aceptar.BackColor = Color.Black
            Me.cmd_eliminar.Enabled = True
            Me.cmd_eliminar.BackColor = Color.Black
            Me.cmd_modificar.Enabled = False
            Me.cmd_modificar.BackColor = Color.LightGray

            Me.dt_fecha.Focus()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally

            If conex.State = ConnectionState.Open Then conex.Close()
            selecciona_datos()

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Return Then
            Try

                Me.cmb_moneda.Text = Me.DataGridView1.SelectedCells(1).Value
                Me.dt_fecha.Text = Me.DataGridView1.SelectedCells(0).Value
                Me.txt_importe.Text = Me.DataGridView1.SelectedCells(2).Value

                Me.cmd_aceptar.Enabled = False
                Me.cmd_aceptar.BackColor = Color.LightGray
                Me.cmd_eliminar.Enabled = False
                Me.cmd_eliminar.BackColor = Color.LightGray
                Me.cmd_modificar.Enabled = True
                Me.cmd_modificar.BackColor = Color.Black

                Me.dt_fecha.Enabled = False
                Me.cmb_moneda.Enabled = False

                Me.txt_importe.Focus()
                Me.txt_importe.SelectAll()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub dt_fecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fecha.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmb_moneda.Focus()
        End If
    End Sub

    Private Sub cmb_moneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_moneda.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txt_importe.Focus()
        End If
    End Sub

    Private Sub txt_importe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_importe.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cmd_aceptar.Focus()
        End If
    End Sub

    Private Sub txt_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    
    Private Sub cmd_ajusta_precio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ajusta_precio.Click


        Dim x As Short = MessageBox.Show("Actualiza Precios moneda seleccionada??", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If x = 6 Then

            tb = New DataTable
            tb.Clear()

            Try

                conex = conecta()

                comando = New SqlDataAdapter("select id_art1,precio_civa,iva,cod_imp,ABS(utilidad),desc1,desc2,desc3,flete,pago_total,valor_moneda from art_precio where moneda = '" & Me.DataGridView1.SelectedCells(1).Value & "'", conex)
                comando.Fill(tb)
                comando.Dispose()

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                For i = 0 To tb.Rows.Count - 1

                    ' si el producto no tiene valor_moneda lo calculo en base a la seleccionada
                    If tb.Rows(i).Item(10) = 0 Then
                        art.precio_civa = Val(tb.Rows(i).Item(1)) * Val(Me.DataGridView1.SelectedCells(2).Value)
                    Else
                        art.precio_civa = (Val(tb.Rows(i).Item(1)) / Val(tb.Rows(i).Item(10))) * Val(Me.DataGridView1.SelectedCells(2).Value)
                    End If

                    art.precio_siva = art.precio_civa / ("1." & tb.Rows(i).Item(2))
                    art.costo = art.precio_siva / ("1." & Replace(tb.Rows(i).Item(4), ".", ""))
                    art.iva_insc = art.precio_civa - art.precio_siva

                    coman = New SqlCommand("update art_precio with (rowlock,xlock) set costo ='" & Format(art.costo, "0.00") & "',precio_siva='" & Format(art.precio_siva, "0.00") & "',precio_civa='" & Format(art.precio_civa, "0.00") & "',exento= '" & Format(art.exento, "0.00") & "',iva_insc= '" & Format(art.iva_insc, "0.00") & "',valor_moneda= '" & Format(Val(Me.DataGridView1.SelectedCells(2).Value), "0.00") & "' where id_art1 = '" & Trim(tb.Rows(i).Item(0)) & "'", conex)
                    coman.ExecuteNonQuery()
                    coman.Dispose()

                Next

                MessageBox.Show("Proceso terminado correctamente!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception

                MessageBox.Show(ex.Message, "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                If conex.State = ConnectionState.Open Then
                    conex.Close()
                End If

                tb.Dispose()

            End Try

        End If

    End Sub

End Class