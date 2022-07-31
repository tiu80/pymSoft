Imports System.Data
Imports System.Data.SqlClient

Public Class Form_cta_cte

    Dim midataset As DataSet
    Dim conex As New SqlConnection
    Dim comando As SqlDataAdapter
    Dim comando1 As SqlCommand
    Dim cta_cte As New pymsoft.parametro
    Dim i, j, x, conta As Integer
    Dim total As Double
    Dim rep As ResumenCta
    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

    Private Sub Form_cta_cte_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Form_recibos.txt_estado_form.Text = 1 Then Form_recibos.txt_cierra_form.Text = 1
    End Sub

    Private Sub Form_cta_cte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        midataset = New DataSet
        rep = New ResumenCta

        If (Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2) And Form_recibos.activo = True Then Call carga_cta_cte_en_recibo()
        If Form_consul_cta_cte.txt_estado_form.Text = 1 Or Form_consul_cta_cte.txt_estado_form.Text = 2 Then Call consulta_cta_cte()

        barra_carga.Timer1.Enabled = True

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Escape Then

            j = Form_recibos.txt_fila.Text

            Form_recibos.acuenta = False

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If Me.DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen Then

                    Form_recibos.DataGridView1.Rows.Add()

                    Dim a As String = Me.DataGridView1.Rows(i).Cells(0).Value

                    Form_recibos.DataGridView1.Rows(j).Cells(0).Value = Me.DataGridView1.Rows(i).Cells(1).Value
                    Form_recibos.DataGridView1.Rows(j).Cells(1).Value = Me.DataGridView1.Rows(i).Cells(2).Value
                    Form_recibos.DataGridView1.Rows(j).Cells(2).Value = Me.DataGridView1.Rows(i).Cells(3).Value
                    Form_recibos.DataGridView1.Rows(j).Cells(3).Value = Me.DataGridView1.Rows(i).Cells(4).Value
                    Form_recibos.DataGridView1.Rows(j).Cells(4).Value = Me.DataGridView1.Rows(i).Cells(5).Value
                    Form_recibos.DataGridView1.Rows(j).Cells(5).Value = Me.DataGridView1.Rows(i).Cells(0).Value

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then
                        Form_recibos.DataGridView1.Rows(j).Cells(6).Value = Me.DataGridView1.Rows(i).Cells(6).Value
                        Form_recibos.DataGridView1.Rows(j).Cells(7).Value = Me.DataGridView1.Rows(i).Cells(6).Value
                        Form_recibos.DataGridView1.Rows(j).DefaultCellStyle.BackColor = Color.Beige
                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Then
                        Form_recibos.DataGridView1.Rows(j).Cells(6).Value = Me.DataGridView1.Rows(i).Cells(7).Value
                        Form_recibos.DataGridView1.Rows(j).Cells(7).Value = Me.DataGridView1.Rows(i).Cells(7).Value
                        Form_recibos.DataGridView1.Rows(j).DefaultCellStyle.BackColor = Color.LightGreen
                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Then
                        Form_recibos.acuenta = True
                    End If

                    cta_cte.instruccion = "Update cta_cte01 set estado = 'PAGADO' where num_fact = '" & Me.DataGridView1.Rows(i).Cells(4).Value & "' and tc = '" & Me.DataGridView1.Rows(i).Cells(1).Value & "' and lt = '" & Me.DataGridView1.Rows(i).Cells(2).Value & "' and pre = '" & Me.DataGridView1.Rows(i).Cells(3).Value & "'"
                    cta_cte.abm()

                    j = j + 1
                    Form_recibos.txt_fila.Text = j

                End If

            Next

            Form_recibos.txt_total.Text = Format(Me.txt_saldo.Text, "0.00")
            Me.Dispose()

        End If

        If e.KeyCode = Keys.Return Then

            'e.SuppressKeyPress = True

            If Form_recibos.txt_estado_form.Text = 1 Or Form_recibos.txt_estado_form.Text = 2 Then

                x = Me.DataGridView1.CurrentCell.RowIndex

                If Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor <> Color.LightGreen Then
                    Call acumulado()
                    conta = 1
                End If

                If Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.LightGreen Then
                    Call resta_acumulado()
                    conta = 2
                End If

                If conta = 1 Then
                    Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    Me.DataGridView1.Rows(x).DefaultCellStyle.BackColor = Color.White
                End If

            Else

                Call mostrar()

            End If

        End If

    End Sub

    Private Sub acumulado()
        Try

            If RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "FC" Or RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "ND" Then
                Me.txt_debito.Text = Me.txt_debito.Text + Val(Me.DataGridView1.Rows(x).Cells(6).Value)
            End If

            If RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "NC" Then
                Me.txt_credito.Text = Me.txt_credito.Text + Val(Me.DataGridView1.Rows(x).Cells(7).Value)
            End If

            If RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "RA" Then
                Me.txt_credito.Text = Me.txt_credito.Text + Val(Me.DataGridView1.Rows(x).Cells(7).Value)
                Form_recibos.ra = True
            End If

            Me.txt_saldo.Text = Format(Me.txt_debito.Text - Me.txt_credito.Text, "0.00")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub resta_acumulado()
        Try

            If RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "FC" Or RTrim(Me.DataGridView1.Rows(x).Cells(1).Value()) = "ND" Then
                Me.txt_debito.Text = Me.txt_debito.Text - Val(Me.DataGridView1.Rows(x).Cells(6).Value)
            Else
                Me.txt_credito.Text = Me.txt_credito.Text - Val(Me.DataGridView1.Rows(x).Cells(7).Value)
            End If

            Me.txt_saldo.Text = Format(Me.txt_debito.Text - Me.txt_credito.Text, "0.00")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carga_cta_cte_en_recibo()

        Try

            Dim ant As Double

            conex = conecta()

            ' si el talon3 es falso separo comprobnates blancos de negro, sino tarigo todo junto
            If Form_recibos.txt_tipo.Text = "RC" Then
                If Form_recibos.talon3 = False Then comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0,C.estado from cta_cte01 as C where (C.id_cli = '" & Trim(Form_recibos.txt_codigo.Text) & "' and C.estado = 'DEBE' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num_fact = F.num_fact1 and C.id_cli = F.id_cli)= '" & Trim(Form_recibos.txt_talonario_pred.Text) & "') or (C.tc='RA' and C.pre = '" & Trim(Form_recibos.txt_talonario_pred.Text) & "' and C.id_cli = '" & Trim(Form_recibos.txt_codigo.Text) & "') order by C.fecha_emi ASC", conex)
                If Form_recibos.talon3 = True Then comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0,C.estado from cta_cte01 as C where (C.id_cli = '" & Trim(Form_recibos.txt_codigo.Text) & "' and C.estado = 'DEBE') order by C.fecha_emi ASC", conex)
            End If

            If Form_recibos.txt_tipo.Text = "OP" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,0.0,estado,id_cli from cta_cte_pro where id_cli = '" & Trim(Form_recibos.txt_codigo.Text) & "' and estado = 'DEBE' order by fecha_emi ASC", conex)

            comando.Fill(midataset, "cta_cte01")
            comando.Dispose()

            Me.DataGridView1.DataSource = midataset.Tables("cta_cte01")

            Me.DataGridView1.Columns(0).Width = 85
            Me.DataGridView1.Columns(1).Width = 40
            Me.DataGridView1.Columns(2).Width = 30
            Me.DataGridView1.Columns(3).Width = 30
            Me.DataGridView1.Columns(4).Width = 70
            Me.DataGridView1.Columns(5).Width = 180
            Me.DataGridView1.Columns(6).Width = 80
            Me.DataGridView1.Columns(7).Width = 80
            Me.DataGridView1.Columns(8).Width = 80
            Me.DataGridView1.Columns(9).Width = 65

            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).HeaderText = "FECHA"
            Me.DataGridView1.Columns(1).HeaderText = "TC"
            Me.DataGridView1.Columns(2).HeaderText = "LT"
            Me.DataGridView1.Columns(3).HeaderText = "PRE"
            Me.DataGridView1.Columns(4).HeaderText = "NUMERO"
            Me.DataGridView1.Columns(5).HeaderText = "DESCRIPCION"
            Me.DataGridView1.Columns(6).HeaderText = "DEBITO"
            Me.DataGridView1.Columns(7).HeaderText = "CREDITO"
            Me.DataGridView1.Columns(8).HeaderText = "ACUMULADO"
            Me.DataGridView1.Columns(9).HeaderText = "ESTADO"

            Me.DataGridView1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            
            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                    ant = Val(Me.DataGridView1.Rows(i).Cells(6).Value)
                    Me.DataGridView1.Rows(i).Cells(6).Value = ant

                Else

                    ant = Val(Me.DataGridView1.Rows(i).Cells(7).Value)
                    Me.DataGridView1.Rows(i).Cells(7).Value = ant

                End If

            Next

            For i = 0 To Me.DataGridView1.Rows.Count - 2

                If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                    total = Format(total + Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")
                    Me.DataGridView1.Rows(i).Cells(8).Value = total

                Else

                    total = Format(total - Val(Me.DataGridView1.Rows(i).Cells(7).Value), "0.00")
                    Me.DataGridView1.Rows(i).Cells(8).Value = total

                End If

            Next

            Me.txt_comentario.Text = "Nombre y Apellido:" & "  " & Form_recibos.txt_cliente.Text & vbCrLf & "Direccion:" & "   " & Form_recibos.txt_direccion.Text & vbCrLf & "Tipo_iva:" & "   " & Form_recibos.txt_iva.Text & "   " & vbCrLf & "Fecha Emision:" & "  " & Form_recibos.dt_fec_emision.Text & "     " & vbCrLf & "Fecha Vencimiento:" & "  " & Form_recibos.dt_fec_vto.Text

        Catch ex As Exception

        Finally

            If Form_recibos.txt_estado_form.Text = 1 Then Form_recibos.txt_cierra_form.Text = 2

        End Try

    End Sub

    Private Sub consulta_cta_cte()

        Try

            Dim ant As Double

            conex = conecta()

            If Form_consul_cta_cte.txt_estado_form.Text = 1 Then

                'If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "6- Total" Then comando = New SqlDataAdapter("select fec,tc,lt,pre,num,debito,credito,0.0,estado from cta_cte_hist where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and fec >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fec <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fec,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "6- Total" Then comando = New SqlDataAdapter("select C.fec,C.tc,C.lt,C.pre,C.num,C.debito,C.credito,0.0,C.estado from cta_cte_hist as C where C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and C.fec >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and C.fec <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num = F.num_fact1 and C.id_cli = F.id_cli and C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "')= '" & Form_consul_cta_cte.talonario & "' or (select R.talon from Recibo_cab as R where C.tc = R.tc and C.lt = R.letra and C.pre = R.pre and C.num = R.id_rec and C.id_cli = R.id_cli and R.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "')= '" & Form_consul_cta_cte.talonario & "' order by C.fec,C.tc", conex)
                'If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "1- Deuda Cta Cte" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,0.0 from cta_cte01 where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "1- Deuda Cta Cte" Then comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0 from cta_cte01 as C where C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and C.fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and C.fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num_fact = F.num_fact1 and C.id_cli = F.id_cli)= '" & Form_consul_cta_cte.talonario & "' or (select R.talon from Recibo_cab as R where C.tc = R.tc and C.lt = R.letra and C.pre = R.pre and C.num_fact = R.id_rec and C.id_cli = R.id_cli)= '" & Form_consul_cta_cte.talonario & "' or (C.tc='RA' and C.pre = '" & Trim(Form_consul_cta_cte.talonario) & "' and C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "') order by C.fecha_emi,C.tc", conex)
                'If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "2- Facturas" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,0.0 from cta_cte01 where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and tc = 'FC' and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "2- Facturas" Then comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0 from cta_cte01 as C where C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and tc = 'FC' and C.fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and C.fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num_fact = F.num_fact1 and C.id_cli = F.id_cli)= '" & Form_consul_cta_cte.talonario & "' or (select R.talon from Recibo_cab as R where C.tc = R.tc and C.lt = R.letra and C.pre = R.pre and C.num_fact = R.id_rec and C.id_cli = R.id_cli)= '" & Form_consul_cta_cte.talonario & "' order by C.fecha_emi,C.tc", conex)
                'If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "3- N. Creditos" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,estado,0.0 from cta_cte01 where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and tc = 'NC' or tc = 'RA' and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "3- N. Creditos" Then comando = New SqlDataAdapter("select C.fecha_emi,C.tc,C.lt,C.pre,C.num_fact,C.cli,C.debito,C.credito,0.0 from cta_cte01 as C where C.id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and tc = 'NC' or tc = 'RA' and C.fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and C.fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' and (select F.talon from fact_cab as F where C.tc = F.tipo_fact and C.lt = F.letra_fact and C.pre = F.prefijo_fact and C.num_fact = F.num_fact1 and C.id_cli = F.id_cli)= '" & Form_consul_cta_cte.talonario & "' or (select R.talon from Recibo_cab as R where C.tc = R.tc and C.lt = R.letra and C.pre = R.pre and C.num_fact = R.id_rec and C.id_cli = R.id_cli)= '" & Form_consul_cta_cte.talonario & "' order by C.fecha_emi,C.tc", conex)

                comando.Fill(midataset, "cta_cte01")
                Me.DataGridView1.DataSource = midataset.Tables("cta_cte01")

            End If

            If Form_consul_cta_cte.txt_estado_form.Text = 2 Then

                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "6- Total" Then comando = New SqlDataAdapter("select fec,tc,lt,pre,num,debito,credito,0.0,estado,id_cli from cta_cte_hist_pro where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and fec >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fec <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fec,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "1- Deuda Cta Cte" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,0.0,id_cli from cta_cte_pro where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "2- Facturas" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,0.0,id_cli from cta_cte_pro where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and (tc = 'FC' or tc = 'ND') and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)
                If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "3- N. Creditos" Then comando = New SqlDataAdapter("select fecha_emi,tc,lt,pre,num_fact,cli,debito,credito,estado,0.0,id_cli from cta_cte_pro where id_cli = '" & RTrim(Form_consul_cta_cte.txt_codigo.Text) & "' and (tc = 'NC' or tc = 'RA') and fecha_emi >= '" & Form_consul_cta_cte.dt_fec_emi.Text & "' and fecha_emi <= '" & Form_consul_cta_cte.dt_fec_hasta.Text & "' order by fecha_emi,tc", conex)

                comando.Fill(midataset, "cta_cte_pro")
                Me.DataGridView1.DataSource = midataset.Tables("cta_cte_pro")

            End If

            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).HeaderText = "FECHA"
            Me.DataGridView1.Columns(1).HeaderText = "TC"
            Me.DataGridView1.Columns(2).HeaderText = "LT"
            Me.DataGridView1.Columns(3).HeaderText = "PRE"
            Me.DataGridView1.Columns(4).HeaderText = "NUMERO"

            If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) <> "6- Total" Then

                Me.DataGridView1.Columns(0).Width = 77
                Me.DataGridView1.Columns(1).Width = 50
                Me.DataGridView1.Columns(2).Width = 35
                Me.DataGridView1.Columns(3).Width = 30
                Me.DataGridView1.Columns(4).Width = 60
                Me.DataGridView1.Columns(5).Width = 200
                Me.DataGridView1.Columns(6).Width = 80
                Me.DataGridView1.Columns(7).Width = 80
                Me.DataGridView1.Columns(8).Width = 80

                Me.DataGridView1.Columns(5).HeaderText = "DESCRIPCION"
                Me.DataGridView1.Columns(6).HeaderText = "DEBITO"
                Me.DataGridView1.Columns(7).HeaderText = "CREDITO"
                Me.DataGridView1.Columns(8).HeaderText = "ACUMULADO"

            Else

                Me.DataGridView1.Columns(0).Width = 80
                Me.DataGridView1.Columns(1).Width = 60
                Me.DataGridView1.Columns(2).Width = 50
                Me.DataGridView1.Columns(3).Width = 50
                Me.DataGridView1.Columns(4).Width = 200
                Me.DataGridView1.Columns(5).Width = 80
                Me.DataGridView1.Columns(6).Width = 80
                Me.DataGridView1.Columns(7).Width = 80
                Me.DataGridView1.Columns(8).Width = 65

                Me.DataGridView1.Columns(5).HeaderText = "DEBITO"
                Me.DataGridView1.Columns(6).HeaderText = "CREDITO"
                Me.DataGridView1.Columns(7).HeaderText = "ACUMULADO"
                Me.DataGridView1.Columns(8).HeaderText = "ESTADO"

            End If

            Me.DataGridView1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) <> "6- Total" Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        ant = Val(Me.DataGridView1.Rows(i).Cells(6).Value)
                        Me.DataGridView1.Rows(i).Cells(6).Value = ant

                    Else

                        ant = Val(Me.DataGridView1.Rows(i).Cells(7).Value)
                        Me.DataGridView1.Rows(i).Cells(7).Value = ant

                    End If

                Next

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        total = Format(total + Me.DataGridView1.Rows(i).Cells(6).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(8).Value = total

                    Else

                        total = Format(total - Me.DataGridView1.Rows(i).Cells(7).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(8).Value = total

                    End If

                Next

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Then

                        Me.txt_credito.Text = Format(Me.txt_credito.Text - Val(Me.DataGridView1.Rows(i).Cells(7).Value), "0.00")

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        Me.txt_debito.Text = Format(Me.txt_debito.Text + Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")

                    End If

                Next

            End If

            If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "6- Total" Then

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        total = Format(total + Me.DataGridView1.Rows(i).Cells(5).Value, "0.00")
                        Me.DataGridView1.Rows(i).Cells(7).Value = total

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "OP" Then

                        total = Format(total - Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")
                        Me.DataGridView1.Rows(i).Cells(7).Value = total

                    End If

                Next

                For i = 0 To Me.DataGridView1.Rows.Count - 2

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "NC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RA" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "RC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "OP" Then

                        Me.txt_credito.Text = Format(Me.txt_credito.Text - Val(Me.DataGridView1.Rows(i).Cells(6).Value), "0.00")

                    End If

                    If RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "FC" Or RTrim(Me.DataGridView1.Rows(i).Cells(1).Value) = "ND" Then

                        Me.txt_debito.Text = Format(Me.txt_debito.Text + Val(Me.DataGridView1.Rows(i).Cells(5).Value), "0.00")

                    End If

                Next

            End If

            Me.txt_credito.Text = Me.txt_credito.Text * (-1)
            Me.txt_saldo.Text = Format(Me.txt_debito.Text - Me.txt_credito.Text, "0.00")

            If RTrim(Form_consul_cta_cte.cmb_modadildad.Text) = "6- Total" Then
                Me.txt_credito.Text = ""
                Me.txt_debito.Text = ""
            End If

            Me.txt_comentario.Text = "Nombre y Apellido:" & "  " & Form_consul_cta_cte.lbl_cliente.Text & vbCrLf & "fecha Emision:" & "   " & Form_consul_cta_cte.dt_fec_emi.Text & vbCrLf & "Fecha Vencimiento:" & "   " & Form_consul_cta_cte.dt_fec_hasta.Text & "   " & vbCrLf & "Modalidad:" & "  " & Form_consul_cta_cte.cmb_modadildad.Text & "     " & vbCrLf & "Saldo Actual:" & "  " & Me.txt_saldo.Text

        Catch ex As Exception

            MessageBox.Show("No hay Datos....", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Dispose()

        Finally

        End Try

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Form_exporta.Show()
    End Sub

    Private Sub mostrar()

        Dim tbl As New DataTable
        Dim valor As Double

        tbl.Clear()

        If Me.txt_estado_form.Text = 2 Then
            If Trim(Me.DataGridView1.SelectedCells(1).Value) <> "OP" Then Form_consulta_compras_det.carga_factura_compra(Me.DataGridView1.SelectedCells(1).Value, Me.DataGridView1.SelectedCells(2).Value, Me.DataGridView1.SelectedCells(3).Value, Me.DataGridView1.SelectedCells(4).Value, Me.DataGridView1.SelectedCells(9).Value)
            If Trim(Me.DataGridView1.SelectedCells(1).Value) = "OP" Then Form_consulta_compras_det.carga_orden_pago(Me.DataGridView1.SelectedCells(1).Value, Me.DataGridView1.SelectedCells(2).Value, Me.DataGridView1.SelectedCells(3).Value, Me.DataGridView1.SelectedCells(4).Value)
            Form_muestra_factura.Show()
            Exit Sub
        End If

        If RTrim(Me.DataGridView1.SelectedCells(1).Value) <> "RC" Then

            comando = New SqlDataAdapter("select codi_producto,detalle,cantidad1,precio_unidad,total1,descuento,iva_inscripto,imp_interno,exento1 from fact_det where fact_det.letra_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_det.num_fact = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_det.tipo_fact2 = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_det.fec_emi = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and fact_det.prefijo_fact2= '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' ", conex)
            comando.Fill(tbl)

            Form_muestra_factura.DataGridView1.DataSource = tbl

            comando1 = New SqlCommand("select sub_total,exento,iva_ins,iva_10,imp_interno1,total,descuento,comentario from fact_tot inner join fact_cab on fact_tot.num_factura = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_tot.tipo_factura = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_tot.pref = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "' and fact_tot.letra = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando1.ExecuteReader

            reader.Read()

            Form_muestra_factura.txt_gravado.Text = reader("Sub_total")
            Form_muestra_factura.txt_inscripto.Text = reader("iva_ins")
            Form_muestra_factura.txt_exento.Text = reader("exento")
            Form_muestra_factura.txt_no_inscripto.Text = reader("iva_10")
            Form_muestra_factura.txt_imp_interno_grilla.Text = reader("imp_interno1")
            Form_muestra_factura.txt_total_grilla.Text = reader("total")
            valor = reader("descuento")
            Form_muestra_factura.valor = reader("comentario")

            reader.Close()
            conex.Close()

            comando1 = New SqlCommand("select num_fact1,tipo_fact,prefijo_fact,letra_fact,fec_emision,id_cli,nombre,tipo_iva,cuit,direccion,lista,forma_pago,estado_fact,pago,talon from fact_cab where fact_cab.num_fact1 = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and fact_cab.fec_emision= '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and fact_cab.letra_fact= '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and fact_cab.tipo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.DataGridView1.SelectedCells(3).Value) & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            reader = comando1.ExecuteReader()
            reader.Read()

            Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Tipo_iva:" & "   " & reader("tipo_iva") & "   " & reader("cuit") & vbCrLf & "Comprobante:" & "  " & reader("tipo_fact") & " - " & reader("letra_fact") & " - " & reader("prefijo_fact") & " - " & reader("num_fact1") & "   -   " & "Lista:" & " " & reader("lista") & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emision") & "     " & reader("forma_pago") & "   -    " & reader("estado_fact") & "  " & reader("pago") & vbCrLf & "Descuento Total Factura:" & "   " & valor & "%" & vbCrLf & "Sub_total:" & " " & Form_muestra_factura.txt_gravado.Text & "    " & "Exento:" & " " & Form_muestra_factura.txt_exento.Text & "    " & "Iva 21%:" & " " & Form_muestra_factura.txt_inscripto.Text & "    " & "Iva 10.5%:" & " " & Form_muestra_factura.txt_no_inscripto.Text & "     " & "Imp. Interno:" & " " & Form_muestra_factura.txt_imp_interno_grilla.Text & "     " & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

            Form_muestra_factura.txt_tipo.Text = reader("tipo_fact")
            Form_muestra_factura.txt_letra.Text = reader("letra_fact")
            Form_muestra_factura.txt_prefijo.Text = reader("prefijo_fact")
            Form_muestra_factura.txt_numero.Text = reader("num_fact1")
            Form_muestra_factura.txt_estado_fact.Text = reader("estado_fact")
            Form_muestra_factura.dt_fec.Value = reader("fec_emision")
            Form_muestra_factura.txt_nombre.Text = reader("nombre")
            Form_muestra_factura.txt_f_pago.Text = reader("forma_pago")
            Form_muestra_factura.txt_talon.Text = reader("talon")
            Form_muestra_factura.txt_comprobante.Text = "venta"

            reader.Close()
            conex.Close()

        Else

            comando = New SqlDataAdapter("select fecha,tipo_fact,letra_fact,pre_fact,num_fact,cancelado from recibo_det inner join recibo_cab on recibo_det.letra_01 = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and recibo_det.id_det = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and recibo_det.tc1 = '" & RTrim(Me.DataGridView1.SelectedCells(1).Value) & "' and recibo_det.pre1='" & Me.DataGridView1.SelectedCells(3).Value & "' and recibo_cab.id_rec = recibo_det.id_det and recibo_cab.letra = recibo_det.letra_01 and recibo_cab.tc = recibo_det.tc1 and recibo_cab.pre = recibo_det.pre1", conex)
            comando.Fill(tbl)

            Form_muestra_factura.DataGridView1.DataSource = tbl

            comando1 = New SqlCommand("select total from recibo_tot where id_tot = '" & Me.DataGridView1.SelectedCells(4).Value & "' and lt = '" & Me.DataGridView1.SelectedCells(2).Value & "' and pre2='" & Me.DataGridView1.SelectedCells(3).Value & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            Dim reader As SqlDataReader = comando1.ExecuteReader

            reader.Read()

            Form_muestra_factura.txt_total_grilla.Text = reader("total")

            reader.Close()
            conex.Close()

            comando1 = New SqlCommand("select id_rec,tc,letra,pre,fec_emi,id_cli,nombre,direccion,saldo_ant,talon,p_venta2 from recibo_cab where recibo_cab.id_rec = '" & RTrim(Me.DataGridView1.SelectedCells(4).Value) & "' and recibo_cab.fec_emi = '" & RTrim(Me.DataGridView1.SelectedCells(0).Value) & "' and recibo_cab.letra = '" & RTrim(Me.DataGridView1.SelectedCells(2).Value) & "' and pre='" & Me.DataGridView1.SelectedCells(3).Value & "'", conex)
            If conex.State = ConnectionState.Closed Then conex.Open()

            reader = comando1.ExecuteReader
            reader.Read()

            Form_muestra_factura.txt_tipo.Text = reader("tc")
            Form_muestra_factura.txt_letra.Text = reader("letra")
            Form_muestra_factura.txt_prefijo.Text = reader("pre")
            Form_muestra_factura.txt_numero.Text = reader("id_rec")
            Form_muestra_factura.dt_fec.Value = reader("fec_emi")
            Form_muestra_factura.txt_nombre.Text = reader("nombre")
            Form_muestra_factura.txt_talon.Text = reader("talon")
            Form_muestra_factura.txt_comprobante.Text = "cobro"
            Form_muestra_factura.txt_p_venta.Text = reader("p_venta2")

            Form_muestra_factura.txt_comentario.Text = "Nombre y Apellido:" & "  " & reader("nombre") & vbCrLf & "Direccion:" & "   " & reader("direccion") & vbCrLf & "Comprobante:" & "  " & reader("tc") & " - " & reader("pre") & " - " & reader("letra") & " - " & reader("id_rec") & "     " & vbCrLf & "Fecha Emision:" & "  " & reader("fec_emi") & vbCrLf & "Saldo Anterior:" & "  " & reader("saldo_ant") & vbCrLf & "Total:" & "  " & Form_muestra_factura.txt_total_grilla.Text

            Form_muestra_cons_comp.es_recibo = False

            reader.Close()
            conex.Close()

        End If

        Form_muestra_factura.Show()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim PrinterSettings As New System.Drawing.Printing.PrinterSettings()
        Dim PageSettings As New System.Drawing.Printing.PageSettings(PrinterSettings)
        Dim pd As New PrintDialog

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, conexion.contraseña)

        rep.RecordSelectionFormula = "{cta_cte_hist.id_cli} = " & RTrim(Form_consul_cta_cte.txt_codigo.Text) & ""

        'rep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
        'rep.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper

        rep.PrintOptions.CopyTo(PrinterSettings, PageSettings)
        pd.PrinterSettings = PrinterSettings
        pd.AllowSomePages = True
        pd.AllowSelection = True

        If pd.ShowDialog = Windows.Forms.DialogResult.OK Then

            rep.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage)

        End If

    End Sub

    Private Sub Tool_elimina_ra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_elimina_ra.Click

        If RTrim(Me.DataGridView1.SelectedCells.Item(1).Value) = "RA" Then

            Dim a As Integer = MessageBox.Show("Esta Seguro!!!!" & vbCrLf & "Esta Operacion Eliminara el Comprobante sin dejar Rastros", "PymSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If a = 6 Then

                If conex.State = ConnectionState.Closed Then
                    conex = conecta()
                    conex.Open()
                End If

                comando1 = New SqlCommand("DELETE cta_cte01 WHERE tc = 'RA' and lt = '" & Trim(Me.DataGridView1.SelectedCells.Item(2).Value) & "' and pre = '" & Trim(Me.DataGridView1.SelectedCells.Item(3).Value) & "' and num_fact = '" & Trim(Me.DataGridView1.SelectedCells.Item(4).Value) & "'", conex)
                comando1.ExecuteNonQuery()
                comando1.Dispose()

                If conex.State = ConnectionState.Open Then conex.Close()

                midataset.Tables("cta_cte01").Clear()
                consulta_cta_cte()

            End If

        End If

    End Sub
End Class