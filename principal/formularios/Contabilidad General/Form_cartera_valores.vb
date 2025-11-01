Imports System.Data
Imports System.Data.SqlClient

Public Class Form_cartera_valores

    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection
    Dim tbl As New DataTable, tbl1 As New DataTable, tbl_cheque As New DataTable, tot As New DataTable
    Dim valor As String

    Private Sub Form_cartera_valores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conex = conecta()
        tbl.Clear()

        comando = New SqlDataAdapter("select cartera from cartera", conex)
        comando.Fill(tbl)
        comando.Dispose()

        Me.cmb_tipo_cartera.DataSource = tbl
        Me.cmb_tipo_cartera.ValueMember = "cartera"

        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)
        Me.cmb_modalidad.Text = Me.cmb_modalidad.Items(0)

        valor = Me.opt_ingreso.Text

    End Sub

    Private Sub cmb_modalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_modalidad.SelectedIndexChanged

        If RTrim(Me.cmb_modalidad.Text) = "Clientes" Then

            Me.lbl_nombre.Visible = True
            Me.cmb_nombre.Visible = True

            conex = conecta()
            tbl1.Clear()

            comando = New SqlDataAdapter("select nombre from cli_01 where tipo_cliente = 'Cliente' order by nombre ASC", conex)
            comando.Fill(tbl1)
            comando.Dispose()

            Me.cmb_nombre.DataSource = tbl1
            Me.cmb_nombre.ValueMember = "nombre"

        End If

        If RTrim(Me.cmb_modalidad.Text) = "Proveedor" Then

            Me.lbl_nombre.Visible = True
            Me.cmb_nombre.Visible = True

            conex = conecta()
            tbl1.Clear()

            comando = New SqlDataAdapter("select nombre from cli_01 where tipo_cliente = 'Proveedor' order by nombre ASC", conex)
            comando.Fill(tbl1)
            comando.Dispose()

            Me.cmb_nombre.DataSource = tbl1
            Me.cmb_nombre.ValueMember = "nombre"

        End If

        If RTrim(Me.cmb_modalidad.Text) = "Todos" Then

            Me.lbl_nombre.Visible = False
            Me.cmb_nombre.Visible = False

        End If

    End Sub

    Private Sub cmd_acepta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_acepta1.Click

        Call ingreso_cartera_total()
        Call ingreso_cartera_cliente()
        Call egreso_cartera_total()
        Call egreso_cartera_cliente()

    End Sub

    Private Sub cmd_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_eliminar.Click
        Me.Close()
    End Sub

    Private Sub opt_ingreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_ingreso.CheckedChanged
        valor = Me.opt_ingreso.Text
    End Sub

    Private Sub opt_egreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_egreso.CheckedChanged
        valor = Me.opt_egreso.Text
    End Sub

    Private Sub opt_acredita_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_acredita.CheckedChanged
        valor = Me.opt_acredita.Text
    End Sub

    Private Sub ingreso_cartera_total()

        ' busco cartera cheques por ingreso dentro de cartera , todos
        If RTrim(Me.cmb_modalidad.Text) = "Todos" Then
            If RTrim(Me.cmb_tipo_cartera.Text) = "CARTERA CHEQUES" And Me.opt_ingreso.Checked = True And RTrim(Me.cmb_tipo.Text) = "Cartera" Then

                conex = conecta()
                tbl_cheque.Clear()
                tot.Clear()

                comando = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where estado = 'I'", conex)
                comando.Fill(tbl_cheque)
                comando.Dispose()

                comando = New SqlDataAdapter("select sum(total) as total from cheque_01 where estado = 'I'", conex)
                comando.Fill(tot)
                comando.Dispose()

                Form_muestra_cartera.DataGridView1.DataSource = tbl_cheque
                Form_muestra_cartera.txt_info.Text = "Fecha Desde:" & " " & Me.dt_fec_desde.Text & "   " & "Hasta:" & " " & Me.dt_fec_hasta.Text & vbCrLf & "Tipo Cartera:" & " " & Me.cmb_tipo_cartera.Text & "      " & valor & vbCrLf & "Agrupacion:" & " " & Me.cmb_modalidad.Text & vbCrLf & "Tipo:" & " " & Me.cmb_tipo.Text & vbCrLf & "Total:" & " " & "$" & " " & tot.Rows(0).Item(0)

                Form_muestra_cartera.DataGridView1.Columns(0).HeaderText = "Emision"
                Form_muestra_cartera.DataGridView1.Columns(1).HeaderText = "Numero"
                Form_muestra_cartera.DataGridView1.Columns(2).HeaderText = "Nombre"
                Form_muestra_cartera.DataGridView1.Columns(3).HeaderText = "Acreditacion"
                Form_muestra_cartera.DataGridView1.Columns(4).HeaderText = "Banco"
                Form_muestra_cartera.DataGridView1.Columns(5).HeaderText = "Total"

                Form_muestra_cartera.DataGridView1.Columns(2).Width = 240

                Form_muestra_cartera.BackColor = Color.White
                'Form_muestra_cartera.Label1.Visible = False
                'Form_muestra_cartera.TextBox1.Visible = False

                Form_muestra_cartera.Show()
                Exit Sub

            End If

        End If

    End Sub

    Private Sub ingreso_cartera_cliente()

        ' busco cartera cheques por ingreso dentro de cartera , clientes
        If RTrim(Me.cmb_modalidad.Text) = "Clientes" Then
            If RTrim(Me.cmb_tipo_cartera.Text) = "CARTERA CHEQUES" And Me.opt_ingreso.Checked = True And RTrim(Me.cmb_tipo.Text) = "Cartera" Then

                conex = conecta()
                tbl_cheque.Clear()
                tot.Clear()

                comando = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where detalle = '" & RTrim(Me.cmb_nombre.Text) & "' and estado = 'I'", conex)
                comando.Fill(tbl_cheque)
                comando.Dispose()

                comando = New SqlDataAdapter("select sum(total) as total from cheque_01 where estado = 'I'", conex)
                comando.Fill(tot)
                comando.Dispose()

                Form_muestra_cartera.DataGridView1.DataSource = tbl_cheque
                Form_muestra_cartera.txt_info.Text = "Fecha Desde:" & " " & Me.dt_fec_desde.Text & "   " & "Hasta:" & " " & Me.dt_fec_hasta.Text & vbCrLf & "Tipo Cartera:" & " " & Me.cmb_tipo_cartera.Text & "      " & valor & vbCrLf & "Agrupacion:" & " " & Me.cmb_modalidad.Text & vbCrLf & "Tipo:" & " " & Me.cmb_tipo.Text & vbCrLf & "Total:" & " " & "$" & " " & tot.Rows(0).Item(0)

                Form_muestra_cartera.DataGridView1.Columns(0).HeaderText = "Emision"
                Form_muestra_cartera.DataGridView1.Columns(1).HeaderText = "Numero"
                Form_muestra_cartera.DataGridView1.Columns(2).HeaderText = "Nombre"
                Form_muestra_cartera.DataGridView1.Columns(3).HeaderText = "Acreditacion"
                Form_muestra_cartera.DataGridView1.Columns(4).HeaderText = "Banco"
                Form_muestra_cartera.DataGridView1.Columns(5).HeaderText = "Total"

                Form_muestra_cartera.DataGridView1.Columns(2).Width = 240

                Form_muestra_cartera.BackColor = Color.White
                Form_muestra_cartera.Label1.BackColor = Color.White
                Form_muestra_cartera.Label1.ForeColor = Color.White
                'Form_muestra_cartera.TextBox1.Visible = False

                Form_muestra_cartera.Show()
                Exit Sub

            End If
        End If

    End Sub

    Private Sub egreso_cartera_total()

        ' busco cartera cheques por egreso fuera de cartera , todos
        If RTrim(Me.cmb_modalidad.Text) = "Todos" Then
            If RTrim(Me.cmb_tipo_cartera.Text) = "CARTERA CHEQUES" And Me.opt_egreso.Checked = True And RTrim(Me.cmb_tipo.Text) = "Todos" Then

                conex = conecta()
                tbl_cheque.Clear()
                tot.Clear()

                comando = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where estado = 'E'", conex)
                comando.Fill(tbl_cheque)
                comando.Dispose()

                comando = New SqlDataAdapter("select sum(total) as total from cheque_01 where estado = 'E'", conex)
                comando.Fill(tot)
                comando.Dispose()

                Form_muestra_cartera.DataGridView1.DataSource = tbl_cheque
                Form_muestra_cartera.txt_info.Text = "Fecha Desde:" & " " & Me.dt_fec_desde.Text & "   " & "Hasta:" & " " & Me.dt_fec_hasta.Text & vbCrLf & "Tipo Cartera:" & " " & Me.cmb_tipo_cartera.Text & "      " & valor & vbCrLf & "Agrupacion:" & " " & Me.cmb_modalidad.Text & vbCrLf & "Tipo:" & " " & Me.cmb_tipo.Text & vbCrLf & "Total:" & " " & "$" & " " & tot.Rows(0).Item(0)

                Form_muestra_cartera.DataGridView1.Columns(0).HeaderText = "Emision"
                Form_muestra_cartera.DataGridView1.Columns(1).HeaderText = "Numero"
                Form_muestra_cartera.DataGridView1.Columns(2).HeaderText = "Nombre"
                Form_muestra_cartera.DataGridView1.Columns(3).HeaderText = "Acreditacion"
                Form_muestra_cartera.DataGridView1.Columns(4).HeaderText = "Banco"
                Form_muestra_cartera.DataGridView1.Columns(5).HeaderText = "Total"

                Form_muestra_cartera.DataGridView1.Columns(2).Width = 240

                Form_muestra_cartera.BackColor = Color.White
                Form_muestra_cartera.Label1.BackColor = Color.White
                Form_muestra_cartera.Label1.ForeColor = Color.White
                'Form_muestra_cartera.TextBox1.Visible = False

                Form_muestra_cartera.Show()
                Exit Sub

            End If
        End If

    End Sub

    Private Sub egreso_cartera_cliente()

        ' busco cartera cheques por ingreso dentro de cartera , clientes
        If RTrim(Me.cmb_modalidad.Text) = "Clientes" Then
            If RTrim(Me.cmb_tipo_cartera.Text) = "CARTERA CHEQUES" And Me.opt_egreso.Checked = True And RTrim(Me.cmb_tipo.Text) = "Todos" Then

                conex = conecta()
                tbl_cheque.Clear()
                tot.Clear()

                comando = New SqlDataAdapter("select fec_emi,id_cheque,detalle,fec_acred,banco,total from cheque_01 where detalle = '" & RTrim(Me.cmb_nombre.Text) & "' and estado = 'E'", conex)
                comando.Fill(tbl_cheque)
                comando.Dispose()

                comando = New SqlDataAdapter("select sum(total) as total from cheque_01 where estado = 'E'", conex)
                comando.Fill(tot)
                comando.Dispose()

                Form_muestra_cartera.DataGridView1.DataSource = tbl_cheque
                Form_muestra_cartera.txt_info.Text = "Fecha Desde:" & " " & Me.dt_fec_desde.Text & "   " & "Hasta:" & " " & Me.dt_fec_hasta.Text & vbCrLf & "Tipo Cartera:" & " " & Me.cmb_tipo_cartera.Text & "      " & valor & vbCrLf & "Agrupacion:" & " " & Me.cmb_modalidad.Text & vbCrLf & "Tipo:" & " " & Me.cmb_tipo.Text & vbCrLf & "Total:" & " " & "$" & " " & tot.Rows(0).Item(0)

                Form_muestra_cartera.DataGridView1.Columns(0).HeaderText = "Emision"
                Form_muestra_cartera.DataGridView1.Columns(1).HeaderText = "Numero"
                Form_muestra_cartera.DataGridView1.Columns(2).HeaderText = "Nombre"
                Form_muestra_cartera.DataGridView1.Columns(3).HeaderText = "Acreditacion"
                Form_muestra_cartera.DataGridView1.Columns(4).HeaderText = "Banco"
                Form_muestra_cartera.DataGridView1.Columns(5).HeaderText = "Total"

                Form_muestra_cartera.DataGridView1.Columns(2).Width = 240

                Form_muestra_cartera.BackColor = Color.White
                Form_muestra_cartera.Label1.BackColor = Color.White
                Form_muestra_cartera.Label1.ForeColor = Color.White
                'Form_muestra_cartera.TextBox1.Visible = False

                Form_muestra_cartera.Show()
                Exit Sub

            End If
        End If

    End Sub

End Class