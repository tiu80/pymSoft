Imports System.Data
Imports System.Data.SqlClient

Public Class Form_balance_saldo

    Dim comando As SqlDataAdapter
    Dim tabla As New DataSet
    Dim conex As New SqlConnection

    Private Sub Form_balance_saldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_ordenacion.Text = Me.cmb_ordenacion.Items(0)
        Me.cmb_filtro.Text = Me.cmb_filtro.Items(0)
        Me.dt_fec_tope.Text = Date.Now
        conex = conecta()
    End Sub

    Private Sub cmb_filtro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_filtro.SelectedIndexChanged

        If Me.cmb_filtro.Text = "Total" Then

            Me.lbl_tipo_filtro.Visible = False
            Me.cmb_descripcion.Visible = False

        End If

        If Me.cmb_filtro.Text = "Cliente" Then

            Me.lbl_tipo_filtro.Visible = True
            Me.cmb_descripcion.Visible = True

            Dim comando As New SqlDataAdapter("select nombre from cli_01 order by nombre", conex)

            comando.Fill(tabla, "cli_01")

            Me.cmb_descripcion.DataSource = tabla.Tables("cli_01")
            Me.cmb_descripcion.ValueMember = "nombre"

        End If

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        Dim i As Integer
        Dim debe, haber, saldo As Single

        tabla.Tables.Clear()

        If Me.cmb_filtro.Text = "Total" Then

            If Me.cmb_ordenacion.Text = "Alfabeticamente" Then
                comando = New SqlDataAdapter("select id_cli,cli,sum(debito) as debito ,sum(credito) as credito from cta_cte01 where fecha_emi <= '" & Me.dt_fec_tope.Text & "' group by cli,id_cli order by cli", conex)
                comando.Fill(tabla, "cta_cte01")
            End If

            If Me.cmb_ordenacion.Text = "Codigo" Then
                comando = New SqlDataAdapter("select id_cli,cli,sum(debito) as debito ,sum(credito) as debito from cta_cte01 where fecha_emi <= '" & Me.dt_fec_tope.Text & "' group by id_cli,cli order by id_cli", conex)
                comando.Fill(tabla, "cta_cte01")
            End If

            Form_muestra_saldo.DataGridView1.DataSource = tabla.Tables("cta_cte01")

            Form_muestra_saldo.txt_comentario.Text = "Ordenacion:" & "   " & Me.cmb_ordenacion.Text & " " & vbCrLf & "Fecha tope:" & "   " & Me.dt_fec_tope.Text & vbCrLf & "Desde:" & "   " & Me.txt_desde.Text & "  " & "Hasta:" & "   " & Me.txt_hasta.Text & vbCrLf & "Filtro:" & "   " & Me.cmb_filtro.Text

            For i = 0 To Form_muestra_saldo.DataGridView1.Rows.Count - 2

                debe = debe + Val(Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value)
                haber = haber + Val(Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value)

                Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value = Format(Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value, "0.00")
                Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value = Format(Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value, "0.00")

            Next

            saldo = Format(debe - haber, "0.00")

            Form_muestra_saldo.txt_comentario1.Text = "Debito:" & "  " & debe & vbCrLf & "Credito:" & " " & haber & vbCrLf & "Saldo:" & "   " & saldo

        End If

        If Me.cmb_filtro.Text = "Cliente" Then

            comando = New SqlDataAdapter("select id_cli,cli,sum(debito) as debito ,sum(credito) as credito from cta_cte01 where fecha_emi <= '" & Me.dt_fec_tope.Text & "' and cli = '" & RTrim(Me.cmb_descripcion.Text) & "' group by cli,id_cli ", conex)
            comando.Fill(tabla, "cta_cte01")

            Form_muestra_saldo.DataGridView1.DataSource = tabla.Tables("cta_cte01")

            Form_muestra_saldo.txt_comentario.Text = "Ordenacion:" & "   " & Me.cmb_ordenacion.Text & " " & vbCrLf & "Fecha tope:" & "   " & Me.dt_fec_tope.Text & vbCrLf & "Desde:" & "   " & Me.txt_desde.Text & "  " & "Hasta:" & "   " & Me.txt_hasta.Text & vbCrLf & "Filtro:" & "   " & Me.cmb_filtro.Text & vbCrLf & "Nombre:" & "   " & Me.cmb_descripcion.Text

            For i = 0 To Form_muestra_saldo.DataGridView1.Rows.Count - 2

                debe = debe + Val(Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value)
                haber = haber + Val(Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value)

                Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value = Format(Form_muestra_saldo.DataGridView1.Rows(i).Cells(2).Value, "0.00")
                Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value = Format(Form_muestra_saldo.DataGridView1.Rows(i).Cells(3).Value, "0.00")

            Next

            saldo = Format(debe - haber, "0.00")

            Form_muestra_saldo.txt_comentario1.Text = "Debito:" & "  " & debe & vbCrLf & "Credito:" & " " & haber & vbCrLf & "Saldo:" & "   " & saldo

        End If

        Form_muestra_saldo.Show()

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click

        Me.Dispose()

    End Sub
End Class