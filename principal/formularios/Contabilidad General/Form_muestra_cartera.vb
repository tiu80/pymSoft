Imports System.Data
Imports System.Data.SqlClient

Public Class Form_muestra_cartera

    Dim suma As Double
    Dim comando As SqlCommand
    Dim coman As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tb As New DataTable
    Dim j, i As Integer

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Try

            Dim x As Integer = Me.DataGridView1.CurrentCell.RowIndex

            If e.KeyCode = Keys.Escape Then

                Dim valor As Integer = MessageBox.Show("¿Esta seguro de extraer estos valores?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If valor = 6 Then

                    suma = 0
                    conex = conecta()
                    If conex.State = ConnectionState.Closed Then conex.Open()

                    For i = 0 To Me.DataGridView1.Rows.Count - 1

                        If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue Then

                            If Form_cartera_valores.txt_estado_form.Text = 1 Then

                                If RTrim(Form_cartera_valores.cmb_tipo_cartera.Text) = "CARTERA CHEQUES" Then

                                    comando = New SqlCommand("update cheque_01 set estado = 'E' where id_cheque = '" & RTrim(Me.DataGridView1.Rows(x).Cells(1).Value) & "' and detalle = '" & RTrim(Me.DataGridView1.Rows(x).Cells(2).Value) & "' and total = '" & RTrim(Me.DataGridView1.Rows(x).Cells(5).Value) & "'", conex)
                                    comando.ExecuteNonQuery()
                                    comando.Dispose()

                                End If

                            End If

                            If Form_planilla.txt_estado_form.Text = 1 Then

                                If RTrim(Form_muestra_planilla.cmb_movimiento.Text) = "EXTRACCION DE CHEQUES" Then

                                    comando = New SqlCommand("update cheque_01 set estado = 'E' where id_cheque = '" & RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) & "' and detalle = '" & RTrim(Me.DataGridView1.Rows(i).Cells(2).Value) & "' and total = '" & RTrim(Me.DataGridView1.Rows(i).Cells(5).Value) & "'", conex)
                                    comando.ExecuteNonQuery()
                                    comando.Dispose()

                                    Form_muestra_planilla.DataGridView1.Rows.Add()

                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(0).Value = Form_planilla.txt_numero_int.Text
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(1).Value = Form_muestra_planilla.txt_inputacion.Text
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(2).Value = "EXTRACCION DE CHEQUES"
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(3).Value = Me.DataGridView1.Rows(i).Cells(5).Value
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(5).Value = Me.DataGridView1.Rows(i).Cells(1).Value
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(6).Value = Me.DataGridView1.Rows(i).Cells(4).Value
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(7).Value = Form_muestra_planilla.cmb_movimiento.Text

                                    j = j + 1

                                End If

                                If RTrim(Form_muestra_planilla.cmb_movimiento.Text) = "EXTRACCION DE VALES" Then

                                    comando = New SqlCommand("update vale_01 set estado = 'E' where id_vale = '" & RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) & "' and detalle = '" & RTrim(Me.DataGridView1.Rows(i).Cells(2).Value) & "' and total = '" & RTrim(Me.DataGridView1.Rows(i).Cells(3).Value) & "'", conex)
                                    comando.ExecuteNonQuery()
                                    comando.Dispose()

                                    Form_muestra_planilla.DataGridView1.Rows.Add()

                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(0).Value = Form_planilla.txt_numero_int.Text
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(1).Value = Form_muestra_planilla.txt_inputacion.Text
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(2).Value = "EXTRACCION DE VALES"
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(3).Value = Me.DataGridView1.Rows(i).Cells(3).Value
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(5).Value = Me.DataGridView1.Rows(i).Cells(1).Value
                                    Form_muestra_planilla.DataGridView1.Rows(j).Cells(7).Value = Form_muestra_planilla.cmb_movimiento.Text

                                    j = j + 1

                                End If

                            End If

                            Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))
                            i = i - 1
                            Me.lbl_importe.Text = ""

                        End If

                        x = x - 1

                    Next

                    Me.Close()

                End If

            End If

            If e.KeyCode = Keys.Return Then

                If Form_planilla.txt_estado_form.Text = 1 Then

                    If RTrim(Form_muestra_planilla.cmb_movimiento.Text) = "EXTRACCION DE CHEQUES" Then

                        If Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor <> Color.LightBlue Then
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.LightBlue
                            suma = Format(suma + Val(Me.DataGridView1.Rows(x).Cells(5).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        Else
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.White
                            suma = Format(suma - Val(Me.DataGridView1.Rows(x).Cells(5).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        End If

                    End If

                    If RTrim(Form_muestra_planilla.cmb_movimiento.Text) = "EXTRACCION DE VALES" Then

                        If Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor <> Color.LightBlue Then
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.LightBlue
                            suma = Format(suma + Val(Me.DataGridView1.Rows(x).Cells(3).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        Else
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.White
                            suma = Format(suma - Val(Me.DataGridView1.Rows(x).Cells(3).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        End If

                    End If

                End If

                If Form_cartera_valores.txt_estado_form.Text = 1 Then

                    If Form_cartera_valores.opt_egreso.Checked <> True Then

                        If Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor <> Color.LightBlue Then
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.LightBlue
                            suma = Format(suma + Val(Me.DataGridView1.Rows(x).Cells(5).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        Else
                            Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.White
                            suma = Format(suma - Val(Me.DataGridView1.Rows(x).Cells(5).Value), "0.00")
                            Me.lbl_importe.Text = suma
                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            Me.Close()

        End Try

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Return Then
            me.DataGridView1.Focus
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        conex = conecta()
        tb.Clear()

        coman = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where estado = 'I' and (detalle like '" & RTrim(Me.TextBox1.Text) & "%' or id_cheque like '" & RTrim(Me.TextBox1.Text) & "%')", conex)
        coman.Fill(tb)
        coman.Dispose()

        Me.DataGridView1.DataSource = tb

        If e.KeyCode = Keys.Return Then
            Me.DataGridView1.Focus()
        End If

    End Sub

    Private Sub Form_muestra_cartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form_muestra_planilla.txt_estado_form.Text = 1 Then
            j = Form_muestra_planilla.DataGridView1.Rows.Count
        End If
    End Sub
End Class