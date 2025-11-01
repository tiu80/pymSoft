Imports System.Data
Imports System.Data.SqlClient

Public Class Form_arqueo_caja

    Dim conex As New SqlConnection
    Dim comando As SqlCommand
    Dim midataset As New DataSet
    Dim comando1 As SqlDataAdapter
    Dim total_cheque1, total_vale1, total_efectivo, total_ctacte, total_ticket1, total_cheque2, total_ticket2, total_credito1, total_debito1, total_credito2, total_debito2, total_ingreso_egreso As Single
    Dim valor As Char
    Dim talon As Integer
    Dim arqueo As Boolean
    Dim t1 As Boolean = False
    Dim t2 As Boolean = False
    Dim planilla As Boolean
    Dim trans As SqlTransaction

    Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject


    Private Sub Form_arqueo_caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conex = conecta()
        If conex.State = ConnectionState.Closed Then conex.Open()
        Me.dt_fec_arqueo.Value = Date.Now
        Me.dt_comparacion.Value = Date.Now

    End Sub

    Private Sub List_contado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles List_contado.KeyDown

        If e.KeyCode = Keys.Return Then

            midataset.Clear()

            If Me.List_contado.Text = "1- Efectivo" & "   " & "-----> " & " " & total_efectivo Then
                Call muestra_efectivo()
                Me.lbl_muestra.Text = "1- Efectivo"
            End If

            If Me.List_contado.Text = "2- Cheque" & "   " & "-----> " & " " & total_cheque1 Then
                valor = "F"
                Call muestra_cheque(valor)
                Me.lbl_muestra.Text = "2- Cheque"
            End If

            If Me.List_contado.Text = "4- Vales" & "   " & "--------> " & " " & total_vale1 Then
                Call muestra_vale()
                Me.lbl_muestra.Text = "4- Vales"
            End If

            If Me.List_contado.Text = "3- Tickets" & "   " & "------> " & " " & total_ticket1 Then
                valor = "F"
                Call muestra_ticket(valor)
                Me.lbl_muestra.Text = "3- Tickets"
            End If

            If Me.List_contado.Text = "5- T. Credito" & "  " & "----> " & " " & total_credito1 Then
                valor = "F"
                Call muestra_t_credito(valor)
                Me.lbl_muestra.Text = "5- T. Credito"
            End If

            If Me.List_contado.Text = "6- T. Debito" & "  " & "----> " & " " & total_debito1 Then
                valor = "F"
                Call muestra_t_debito(valor)
                Me.lbl_muestra.Text = "6- T. Dedito"
            End If

            If Me.List_contado.Text = "7- Otros" & "  " & "----> " & " " & total_ingreso_egreso Then
                Call muestra_Ingreso_egreso()
                Me.lbl_muestra.Text = "7- Otros"
            End If


        End If

    End Sub

    Private Sub muestra_Ingreso_egreso()

        Dim tbl1 As New DataTable

        comando1 = New SqlDataAdapter("select fecha,tipo,id,importe,comentario from IngresoEgreso where ptovta = '" & RTrim(Me.txt_punto_venta.Text) & "' and fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "'", conex)
        comando1.Fill(tbl1)
        comando1.Dispose()

        Me.DataGrid_contado.DataSource = tbl1

        Me.DataGrid_contado.Columns(0).Width = 100
        Me.DataGrid_contado.Columns(1).Width = 120
        Me.DataGrid_contado.Columns(2).Width = 120
        Me.DataGrid_contado.Columns(3).Width = 120
        Me.DataGrid_contado.Columns(4).Width = 580

        Me.DataGrid_contado.Columns(0).HeaderText = "Fec Emi"
        Me.DataGrid_contado.Columns(1).HeaderText = "Tipo"
        Me.DataGrid_contado.Columns(2).HeaderText = "id"
        Me.DataGrid_contado.Columns(3).HeaderText = "Importe"
        Me.DataGrid_contado.Columns(4).HeaderText = "Comentario"

        Me.DataGrid_contado.Columns(3).DefaultCellStyle.BackColor = Color.LightGreen

        tbl1.Dispose()

    End Sub

    Private Sub muestra_efectivo()

        Dim tbl1 As New DataTable

        comando1 = New SqlDataAdapter("select fec_emision,tipo_fact,letra_fact,prefijo_fact,num_fact1,nombre,total_cobro,forma_pago from fact_cab inner join fact_tot on fact_tot.efectivo= 'SI' and fact_cab.prefijo_fact = '" & RTrim(Me.txt_punto_venta.Text) & "' and fact_cab.fec_emision = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.letra_fact = fact_tot.letra and fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.talon = fact_tot.talon2 and fact_cab.forma_pago= 'Contado' and estado_fact = 'Activo' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' order by fact_cab.num_fact1 asc", conex)
        comando1.Fill(tbl1)
        comando1.Dispose()

        Me.DataGrid_contado.DataSource = tbl1

        Me.DataGrid_contado.Columns(0).Width = 83
        Me.DataGrid_contado.Columns(1).Width = 40
        Me.DataGrid_contado.Columns(2).Width = 40
        Me.DataGrid_contado.Columns(3).Width = 40
        Me.DataGrid_contado.Columns(4).Width = 80
        Me.DataGrid_contado.Columns(5).Width = 300
        Me.DataGrid_contado.Columns(6).Width = 90

        Me.DataGrid_contado.Columns(0).HeaderText = "Fec Emi"
        Me.DataGrid_contado.Columns(1).HeaderText = "Tp"
        Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
        Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
        Me.DataGrid_contado.Columns(4).HeaderText = "Num"
        Me.DataGrid_contado.Columns(5).HeaderText = "Nombre"
        Me.DataGrid_contado.Columns(6).HeaderText = "Importe"

        Me.DataGrid_contado.Columns(7).Visible = False
        Me.DataGrid_contado.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        tbl1.Dispose()

    End Sub

    Private Sub muestra_cta_cte()

        Dim tbl As New DataTable

        comando1 = New SqlDataAdapter("select fec_emi,tc,pre,letra,id_rec,nombre,total_cobro from recibo_cab inner join recibo_tot on recibo_tot.efectivo= 'SI' and recibo_cab.fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.tc = recibo_tot.tip order by id_rec ", conex)
        comando1.Fill(tbl)

        Me.DataGrid_cobranza.DataSource = tbl

        Me.DataGrid_cobranza.Columns(0).Width = 100
        Me.DataGrid_cobranza.Columns(1).Width = 35
        Me.DataGrid_cobranza.Columns(2).Width = 30
        Me.DataGrid_cobranza.Columns(3).Width = 30
        Me.DataGrid_cobranza.Columns(4).Width = 45
        Me.DataGrid_cobranza.Columns(5).Width = 170
        Me.DataGrid_cobranza.Columns(6).Width = 80

        Me.DataGrid_cobranza.Columns(0).HeaderText = "Fecha Emi"
        Me.DataGrid_cobranza.Columns(1).HeaderText = "tp"
        Me.DataGrid_cobranza.Columns(2).HeaderText = "Pre"
        Me.DataGrid_cobranza.Columns(3).HeaderText = "Lt"
        Me.DataGrid_cobranza.Columns(4).HeaderText = "Num"
        Me.DataGrid_cobranza.Columns(5).HeaderText = "Nombre"
        Me.DataGrid_cobranza.Columns(6).HeaderText = "Importe"

        Me.DataGrid_cobranza.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        tbl.Dispose()

    End Sub

    Private Sub muestra_cheque(ByVal valor)

        comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,banco,fec_acred,detalle,total from cheque_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = '" & valor & "' order by numero", conex)
        comando1.Fill(midataset, "cheque_01")
        comando1.Dispose()

        If valor = "F" Then

            Me.DataGrid_contado.DataSource = midataset.Tables("cheque_01")

            Me.DataGrid_contado.Columns(0).Width = 100
            Me.DataGrid_contado.Columns(1).Width = 35
            Me.DataGrid_contado.Columns(2).Width = 30
            Me.DataGrid_contado.Columns(3).Width = 30
            Me.DataGrid_contado.Columns(4).Width = 45
            Me.DataGrid_contado.Columns(5).Width = 200
            Me.DataGrid_contado.Columns(6).Width = 70
            Me.DataGrid_contado.Columns(7).Width = 250
            Me.DataGrid_contado.Columns(8).Width = 70

            Me.DataGrid_contado.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_contado.Columns(1).HeaderText = "tc"
            Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
            Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
            Me.DataGrid_contado.Columns(4).HeaderText = "Numero"
            Me.DataGrid_contado.Columns(5).HeaderText = "Banco"
            Me.DataGrid_contado.Columns(6).HeaderText = "F.Acred"
            Me.DataGrid_contado.Columns(7).HeaderText = "Nombre"
            Me.DataGrid_contado.Columns(8).HeaderText = "Importe"

            Me.DataGrid_contado.Columns(8).DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If valor = "R" Then

            Me.DataGrid_cobranza.DataSource = midataset.Tables("cheque_01")

            Me.DataGrid_cobranza.Columns(0).Width = 83
            Me.DataGrid_cobranza.Columns(1).Width = 25
            Me.DataGrid_cobranza.Columns(2).Width = 25
            Me.DataGrid_cobranza.Columns(3).Width = 25
            Me.DataGrid_cobranza.Columns(4).Width = 63
            Me.DataGrid_cobranza.Columns(5).Width = 200
            Me.DataGrid_cobranza.Columns(6).Width = 83
            Me.DataGrid_cobranza.Columns(7).Width = 250
            Me.DataGrid_cobranza.Columns(8).Width = 90

            Me.DataGrid_cobranza.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_cobranza.Columns(1).HeaderText = "tc"
            Me.DataGrid_cobranza.Columns(2).HeaderText = "Lt"
            Me.DataGrid_cobranza.Columns(3).HeaderText = "Pre"
            Me.DataGrid_cobranza.Columns(4).HeaderText = "Numero"
            Me.DataGrid_cobranza.Columns(5).HeaderText = "Banco"
            Me.DataGrid_cobranza.Columns(6).HeaderText = "F.Acred"
            Me.DataGrid_cobranza.Columns(7).HeaderText = "Nombre"
            Me.DataGrid_cobranza.Columns(8).HeaderText = "Importe"

            Me.DataGrid_cobranza.Columns(8).DefaultCellStyle.BackColor = Color.LightGreen

        End If

    End Sub

    Private Sub muestra_vale()

        comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from vale_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' order by numero", conex)
        comando1.Fill(midataset, "vale_01")
        comando1.Dispose()

        Me.DataGrid_contado.DataSource = midataset.Tables("vale_01")

        Me.DataGrid_contado.Columns(0).Width = 83
        Me.DataGrid_contado.Columns(1).Width = 40
        Me.DataGrid_contado.Columns(2).Width = 40
        Me.DataGrid_contado.Columns(3).Width = 40
        Me.DataGrid_contado.Columns(4).Width = 80
        Me.DataGrid_contado.Columns(5).Width = 300
        Me.DataGrid_contado.Columns(6).Width = 90

        Me.DataGrid_contado.Columns(0).HeaderText = "F.Emi"
        Me.DataGrid_contado.Columns(1).HeaderText = "tc"
        Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
        Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
        Me.DataGrid_contado.Columns(4).HeaderText = "Numero"
        Me.DataGrid_contado.Columns(5).HeaderText = "Nombre"
        Me.DataGrid_contado.Columns(6).HeaderText = "Importe"

        Me.DataGrid_contado.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

    End Sub

    Private Sub muestra_ticket(ByVal valor)

        comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from ticket_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = '" & valor & "' order by numero", conex)
        comando1.Fill(midataset, "ticket_01")
        comando1.Dispose()

        If valor = "F" Then

            Me.DataGrid_contado.DataSource = midataset.Tables("ticket_01")

            Me.DataGrid_contado.Columns(0).Width = 83
            Me.DataGrid_contado.Columns(1).Width = 40
            Me.DataGrid_contado.Columns(2).Width = 40
            Me.DataGrid_contado.Columns(3).Width = 40
            Me.DataGrid_contado.Columns(4).Width = 80
            Me.DataGrid_contado.Columns(5).Width = 300
            Me.DataGrid_contado.Columns(6).Width = 90

            Me.DataGrid_contado.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_contado.Columns(1).HeaderText = "tc"
            Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
            Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
            Me.DataGrid_contado.Columns(4).HeaderText = "Numero"
            Me.DataGrid_contado.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_contado.Columns(6).HeaderText = "Importe"

            Me.DataGrid_contado.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If valor = "R" Then

            Me.DataGrid_cobranza.DataSource = midataset.Tables("ticket_01")

            Me.DataGrid_cobranza.Columns(0).Width = 83
            Me.DataGrid_cobranza.Columns(1).Width = 40
            Me.DataGrid_cobranza.Columns(2).Width = 40
            Me.DataGrid_cobranza.Columns(3).Width = 40
            Me.DataGrid_cobranza.Columns(4).Width = 80
            Me.DataGrid_cobranza.Columns(5).Width = 240
            Me.DataGrid_cobranza.Columns(6).Width = 90

            Me.DataGrid_cobranza.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_cobranza.Columns(1).HeaderText = "tc"
            Me.DataGrid_cobranza.Columns(2).HeaderText = "Lt"
            Me.DataGrid_cobranza.Columns(3).HeaderText = "Pre"
            Me.DataGrid_cobranza.Columns(4).HeaderText = "Numero"
            Me.DataGrid_cobranza.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_cobranza.Columns(6).HeaderText = "Importe"

            Me.DataGrid_cobranza.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If

    End Sub

    Private Sub muestra_t_credito(ByVal valor)

        comando1 = New SqlDataAdapter("select f_emi,tc,lt,prefijo,numero,cli_1,importe from t_credito where f_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = '" & valor & "' order by numero", conex)
        comando1.Fill(midataset, "t_credito")
        comando1.Dispose()

        If valor = "F" Then

            Me.DataGrid_contado.DataSource = midataset.Tables("t_credito")

            Me.DataGrid_contado.Columns(0).Width = 83
            Me.DataGrid_contado.Columns(1).Width = 40
            Me.DataGrid_contado.Columns(2).Width = 40
            Me.DataGrid_contado.Columns(3).Width = 40
            Me.DataGrid_contado.Columns(4).Width = 80
            Me.DataGrid_contado.Columns(5).Width = 300
            Me.DataGrid_contado.Columns(6).Width = 90

            Me.DataGrid_contado.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_contado.Columns(1).HeaderText = "tc"
            Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
            Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
            Me.DataGrid_contado.Columns(4).HeaderText = "Numero"
            Me.DataGrid_contado.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_contado.Columns(6).HeaderText = "Importe"

            Me.DataGrid_contado.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If valor = "R" Then

            Me.DataGrid_cobranza.DataSource = midataset.Tables("t_credito")

            Me.DataGrid_cobranza.Columns(0).Width = 83
            Me.DataGrid_cobranza.Columns(1).Width = 40
            Me.DataGrid_cobranza.Columns(2).Width = 40
            Me.DataGrid_cobranza.Columns(3).Width = 40
            Me.DataGrid_cobranza.Columns(4).Width = 80
            Me.DataGrid_cobranza.Columns(5).Width = 300
            Me.DataGrid_cobranza.Columns(6).Width = 90

            Me.DataGrid_cobranza.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_cobranza.Columns(1).HeaderText = "tc"
            Me.DataGrid_cobranza.Columns(2).HeaderText = "Lt"
            Me.DataGrid_cobranza.Columns(3).HeaderText = "Pre"
            Me.DataGrid_cobranza.Columns(4).HeaderText = "Numero"
            Me.DataGrid_cobranza.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_cobranza.Columns(6).HeaderText = "Importe"

            Me.DataGrid_cobranza.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If


    End Sub

    Private Sub muestra_t_debito(ByVal valor)

        comando1 = New SqlDataAdapter("select fecha,tc,lt,prefijo,numero,cliente,importe from t_debito where fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = '" & valor & "' order by numero", conex)
        comando1.Fill(midataset, "t_debito")
        comando1.Dispose()

        If valor = "F" Then

            Me.DataGrid_contado.DataSource = midataset.Tables("t_debito")

            Me.DataGrid_contado.Columns(0).Width = 83
            Me.DataGrid_contado.Columns(1).Width = 40
            Me.DataGrid_contado.Columns(2).Width = 40
            Me.DataGrid_contado.Columns(3).Width = 40
            Me.DataGrid_contado.Columns(4).Width = 80
            Me.DataGrid_contado.Columns(5).Width = 240
            Me.DataGrid_contado.Columns(6).Width = 90

            Me.DataGrid_contado.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_contado.Columns(1).HeaderText = "tc"
            Me.DataGrid_contado.Columns(2).HeaderText = "Lt"
            Me.DataGrid_contado.Columns(3).HeaderText = "Pre"
            Me.DataGrid_contado.Columns(4).HeaderText = "Numero"
            Me.DataGrid_contado.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_contado.Columns(6).HeaderText = "Importe"

            Me.DataGrid_contado.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If valor = "R" Then

            Me.DataGrid_cobranza.DataSource = midataset.Tables("t_debito")

            Me.DataGrid_cobranza.Columns(0).Width = 83
            Me.DataGrid_cobranza.Columns(1).Width = 40
            Me.DataGrid_cobranza.Columns(2).Width = 40
            Me.DataGrid_cobranza.Columns(3).Width = 40
            Me.DataGrid_cobranza.Columns(4).Width = 80
            Me.DataGrid_cobranza.Columns(5).Width = 240
            Me.DataGrid_cobranza.Columns(6).Width = 90

            Me.DataGrid_cobranza.Columns(0).HeaderText = "F.Emi"
            Me.DataGrid_cobranza.Columns(1).HeaderText = "tc"
            Me.DataGrid_cobranza.Columns(2).HeaderText = "Lt"
            Me.DataGrid_cobranza.Columns(3).HeaderText = "Pre"
            Me.DataGrid_cobranza.Columns(4).HeaderText = "Numero"
            Me.DataGrid_cobranza.Columns(5).HeaderText = "Nombre"
            Me.DataGrid_cobranza.Columns(6).HeaderText = "Importe"

            Me.DataGrid_cobranza.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen

        End If

    End Sub

    Private Sub total_Contado()

        Try

            Dim i As Integer
            Dim total As Single = 0
            midataset.Clear()

            Me.lbl_contado.Text = "0.00"

            If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emision,tipo_fact,forma_pago,total_cobro,estado_fact,efectivo from fact_cab inner join fact_tot on fact_cab.prefijo_fact = '" & RTrim(Me.txt_punto_venta.Text) & "' and fact_cab.fec_emision = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.letra_fact = fact_tot.letra and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.talon = fact_tot.talon2 and fact_cab.tipo_fact <> 'RC' order by tipo_fact ", conex)
            If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emision,tipo_fact,forma_pago,total_cobro,estado_fact,efectivo from fact_cab inner join fact_tot on fact_cab.talon = '1' and fact_cab.fec_emision = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.letra_fact = fact_tot.letra and fact_cab.num_fact1 = fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.talon = fact_tot.talon2 and fact_cab.tipo_fact <> 'RC' order by tipo_fact ", conex)

            comando1.Fill(midataset, "fact_cab")
            comando1.Dispose()

            For i = 0 To midataset.Tables("fact_cab").Rows.Count - 1

                If RTrim(midataset.Tables("fact_cab").Rows(i).Item(5)) = "SI" Then

                    If RTrim(midataset.Tables("fact_cab").Rows(i).Item(1)) = "FC" And RTrim(midataset.Tables("fact_cab").Rows(i).Item(2)) = "Contado" And RTrim(midataset.Tables("fact_cab").Rows(i).Item(4)) = "Activo" Then
                        total = total + midataset.Tables("fact_cab").Rows(i).Item(3)
                    End If

                    If RTrim(midataset.Tables("fact_cab").Rows(i).Item(1)) = "NC" And RTrim(midataset.Tables("fact_cab").Rows(i).Item(2)) = "Contado" And RTrim(midataset.Tables("fact_cab").Rows(i).Item(4)) = "Activo" Then
                        total = total - midataset.Tables("fact_cab").Rows(i).Item(3)
                    End If

                End If

            Next

            total_efectivo = Format(total, "0.00")

        Catch ex As Exception
            total_efectivo = 0
        End Try

    End Sub

    Private Sub total_ingreso_egresos()

        Try

            Dim i As Integer
            Dim total As Single = 0
            midataset.Clear()

            Me.lbl_contado.Text = "0.00"

            If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fecha,tipo,id,importe,comentario from IngresoEgreso where ptovta = '" & RTrim(Me.txt_punto_venta.Text) & "' and fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "'", conex)

            comando1.Fill(midataset, "IngresoEgreso")
            comando1.Dispose()

            For i = 0 To midataset.Tables("IngresoEgreso").Rows.Count - 1

                If RTrim(midataset.Tables("IngresoEgreso").Rows(i).Item(1)) = "Ingreso Varios" Then

                    total = total + midataset.Tables("IngresoEgreso").Rows(i).Item(3)

                Else

                    total = total - midataset.Tables("IngresoEgreso").Rows(i).Item(3)

                End If

            Next

            total_ingreso_egreso = Format(total, "0.00")

        Catch ex As Exception

            total_ingreso_egreso = 0

        End Try

    End Sub

    Private Sub total_cta_cte()

        Try

            Dim i As Integer
            Dim total4 As Single = 0
            midataset.Clear()
            midataset.Dispose()

            Me.lbl_cta_cte.Text = "0.00"

            'If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,letra,id_rec,nombre,total_cobro,efectivo from recibo_cab inner join recibo_tot on recibo_cab.fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and recibo_cab.p_venta2 = '" & RTrim(Me.txt_punto_venta.Text) & "' and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.tc = recibo_tot.tip ", conex)
            If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select R.fec_emi1,R.tip,R.lt,R.id_tot,'',(R.total - C.total),efectivo from recibo_tot as R left outer join cheque_01 as C on R.tip = C.tc and R.lt = C.lt and R.pre2 = C.prefijo and R.id_tot = C.numero where R.fec_emi1 = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and R.p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)

            'If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,letra,id_rec,nombre,total_cobro,efectivo from recibo_cab inner join recibo_tot on recibo_cab.fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and recibo_cab.talon = '1' and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.tc = recibo_tot.tip ", conex)
            'If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,letra,id_rec,nombre,total_cobro,efectivo from recibo_cab inner join recibo_tot on recibo_cab.fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and recibo_cab.talon = '1' and recibo_cab.id_rec = recibo_tot.id_tot and recibo_cab.letra = recibo_tot.lt and recibo_cab.pre = recibo_tot.pre2 and recibo_cab.tc = recibo_tot.tip ", conex)
            If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select R.fec_emi1,R.tip,R.lt,R.id_tot,'',(R.total - C.total),efectivo from recibo_tot as R left outer join cheque_01 as C on R.tip = C.tc and R.lt = C.lt and R.pre2 = C.prefijo and R.id_tot = C.numero where R.fec_emi1 = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and R.p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "' and R.talon2 = 1", conex)

            comando1.Fill(midataset, "recibo_cab")
            comando1.Dispose()

            For i = 0 To midataset.Tables("recibo_cab").Rows.Count - 1

                If RTrim(midataset.Tables("recibo_cab").Rows(i).Item(6)) = "SI" Then

                    total4 = total4 + midataset.Tables("recibo_cab").Rows(i).Item(5)

                End If

            Next

            total_ctacte = Format(total4, "0.00")

        Catch ex As Exception
            total_ctacte = 0
        End Try

    End Sub

    Private Sub total_cheque()

        Dim i As Integer
        Dim total As Single = 0
        Dim total1 As Single = 0
        midataset.Clear()
        midataset.Dispose()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,banco,fec_acred,detalle,total from cheque_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,banco,fec_acred,detalle,total from cheque_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and talon = '1'", conex)

        comando1.Fill(midataset, "cheque_01")
        comando1.Dispose()

        For i = 0 To midataset.Tables("cheque_01").Rows.Count - 1

            total = total + midataset.Tables("cheque_01").Rows(i).Item(8)

        Next

        midataset.Clear()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,banco,fec_acred,detalle,total from cheque_01 where fec_emi = '" & Me.dt_fec_arqueo.Text & "' and modo = 'R' and p_venta = '" & Me.txt_punto_venta.Text & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,banco,fec_acred,detalle,total from cheque_01 where fec_emi = '" & Me.dt_fec_arqueo.Text & "' and modo = 'R' and talon = '1'", conex)

        comando1.Fill(midataset, "cheque_01")
        comando1.Dispose()

        For i = 0 To midataset.Tables("cheque_01").Rows.Count - 1

            total1 = total1 + midataset.Tables("cheque_01").Rows(i).Item(8)

        Next

        total_cheque1 = total
        total_cheque2 = total1

    End Sub

    Private Sub total_vale()

        Dim i As Integer
        Dim total As Single = 0
        midataset.Clear()
        midataset.Dispose()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from vale_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and prefijo ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from vale_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon ='1'", conex)

        comando1.Fill(midataset, "vale_01")
        comando1.Dispose()

        For i = 0 To midataset.Tables("vale_01").Rows.Count - 1
            total = total + midataset.Tables("vale_01").Rows(i).Item(6)
        Next

        total_vale1 = total

    End Sub

    Private Sub total_credito()

        Dim i As Integer
        Dim total As Single = 0
        Dim total1 As Single = 0
        midataset.Clear()
        midataset.Dispose()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select f_emi,tc,lt,prefijo,numero,cli_1,importe from t_credito where f_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select f_emi,tc,lt,prefijo,numero,cli_1,importe from t_credito where f_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and talon ='1'", conex)

        comando1.Fill(midataset, "t_credito")
        comando1.Dispose()

        For i = 0 To midataset.Tables("t_credito").Rows.Count - 1
            total = total + midataset.Tables("t_credito").Rows(i).Item(6)
        Next

        midataset.Clear()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select f_emi,tc,lt,prefijo,numero,cli_1,importe from t_credito where f_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'R' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select f_emi,tc,lt,prefijo,numero,cli_1,importe from t_credito where f_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'R' and talon ='1'", conex)

        comando1.Fill(midataset, "t_credito")
        comando1.Dispose()

        For i = 0 To midataset.Tables("t_credito").Rows.Count - 1
            total1 = total1 + midataset.Tables("t_credito").Rows(i).Item(6)
        Next


        total_credito1 = total
        total_credito2 = total1

    End Sub

    Private Sub total_dedito()

        Dim i As Integer
        Dim total As Single = 0
        Dim total1 As Single = 0
        midataset.Clear()
        midataset.Dispose()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fecha,tc,lt,prefijo,numero,cliente,importe from t_debito where fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fecha,tc,lt,prefijo,numero,cliente,importe from t_debito where fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'F' and talon ='1'", conex)

        comando1.Fill(midataset, "t_debito")
        comando1.Dispose()

        For i = 0 To midataset.Tables("t_debito").Rows.Count - 1
            total = total + midataset.Tables("t_debito").Rows(i).Item(6)
        Next

        midataset.Clear()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fecha,tc,lt,prefijo,numero,cliente,importe from t_debito where fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'R' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fecha,tc,lt,prefijo,numero,cliente,importe from t_debito where fecha = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo = 'R' and talon ='1'", conex)

        comando1.Fill(midataset, "t_debito")
        comando1.Dispose()

        For i = 0 To midataset.Tables("t_debito").Rows.Count - 1
            total1 = total1 + midataset.Tables("t_debito").Rows(i).Item(6)
        Next

        total_debito1 = total
        total_debito2 = total1

    End Sub

    Private Sub total_ticket()

        Dim i As Integer
        Dim total As Single = 0
        Dim total1 As Single = 0
        midataset.Clear()
        midataset.Dispose()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from ticket_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo ='F' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from ticket_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo ='F' and talon ='1'", conex)

        comando1.Fill(midataset, "ticket_01")
        comando1.Dispose()

        For i = 0 To midataset.Tables("ticket_01").Rows.Count - 1
            total = total + midataset.Tables("ticket_01").Rows(i).Item(6)
        Next

        midataset.Clear()

        If Me.txt_punto_venta.Text <> "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from ticket_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo= 'R' and p_venta ='" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando1 = New SqlDataAdapter("select fec_emi,tc,lt,prefijo,numero,detalle,total from ticket_01 where fec_emi = '" & RTrim(Me.dt_fec_arqueo.Text) & "' and modo= 'R' and talon ='1'", conex)

        comando1.Fill(midataset, "ticket_01")
        comando1.Dispose()

        For i = 0 To midataset.Tables("ticket_01").Rows.Count - 1
            total1 = total1 + midataset.Tables("ticket_01").Rows(i).Item(6)
        Next

        total_ticket1 = total
        total_ticket2 = total1

    End Sub

    Private Sub total()
        Me.lbl_contado.Text = Format(total_efectivo + total_vale1 + total_cheque1 + total_ticket1 + total_credito1 + total_debito1 + total_ingreso_egreso, "0.00")
        Me.lbl_cta_cte.Text = Format(total_ctacte + total_cheque2 + total_ticket2 + total_credito2 + total_debito2, "0.00")
        Me.lbl_total.Text = Format(Val(Me.lbl_contado.Text) + Val(Me.lbl_cta_cte.Text), "0.00")
    End Sub

    Private Sub list_cobranza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles list_cobranza.KeyDown

        If e.KeyCode = Keys.Return Then

            midataset.Clear()

            If Me.list_cobranza.Text = "1- Efectivo" & "   " & " -----> " & " " & total_ctacte Then
                Call muestra_cta_cte()
                Me.lbl_muestra1.Text = "1- Efectivo"
            End If

            If Me.list_cobranza.Text = "2- Cheque" & "    " & "-----> " & " " & total_cheque2 Then
                valor = "R"
                Call muestra_cheque(valor)
                Me.lbl_muestra1.Text = "2- Cheque"
            End If

            If Me.list_cobranza.Text = "3- Tickets" & "   " & "------> " & " " & total_ticket2 Then
                valor = "R"
                Call muestra_ticket(valor)
                Me.lbl_muestra1.Text = "3- Tickets"
            End If

            If Me.list_cobranza.Text = "5- T. Credito" & " " & "--> " & " " & total_credito2 Then
                valor = "R"
                Call muestra_t_credito(valor)
                Me.lbl_muestra1.Text = "5- T. Credito"
            End If

            If Me.list_cobranza.Text = "6- T. Debito" & " " & "--> " & " " & total_debito2 Then
                valor = "R"
                Call muestra_t_debito(valor)
                Me.lbl_muestra1.Text = "6- T. Dedito"
            End If

        End If

    End Sub

    Private Sub existencia_valores()

        midataset.Dispose()
        Me.List_contado.Items.Clear()
        Me.list_cobranza.Items.Clear()
        Me.DataGrid_contado.DataSource = Nothing
        Call total_cta_cte()
        Call total_cheque()
        Call total_vale()
        Call total_ticket()
        Call total_credito()
        Call total_dedito()
        Call total_Contado()
        Call total_ingreso_egresos()
        Call total()

        If Me.dt_fec_arqueo.Value > Me.dt_comparacion.Value Then Me.List_contado.Items.Clear()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from fact_cab where fec_emision ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and fact_cab.prefijo_fact = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from fact_cab where fec_emision ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and fact_cab.talon = '1'", conex)

        Dim reader As SqlDataReader = comando.ExecuteReader

        While reader.Read()

            'If total_efectivo <> 0 Then Me.List_contado.Items.Add("1- Efectivo" & "   " & "-----> " & " " & total_efectivo)
            Me.List_contado.Items.Add("1- Efectivo" & "   " & "-----> " & " " & total_efectivo)
            Exit While

        End While

        reader.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from cheque_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from cheque_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader1 As SqlDataReader = comando.ExecuteReader

        While reader1.Read()

            'If total_cheque1 <> 0 Then Me.List_contado.Items.Add("2- Cheque" & "   " & "-----> " & " " & total_cheque1)
            'If total_cheque2 <> 0 Then Me.list_cobranza.Items.Add("2- Cheque" & "    " & "-----> " & " " & total_cheque2)
            Me.List_contado.Items.Add("2- Cheque" & "   " & "-----> " & " " & total_cheque1)
            Me.list_cobranza.Items.Add("2- Cheque" & "    " & "-----> " & " " & total_cheque2)
            Exit While

        End While

        reader1.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from vale_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from vale_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader2 As SqlDataReader = comando.ExecuteReader

        While reader2.Read()

            'If total_vale1 <> 0 Then Me.List_contado.Items.Add("4- Vales" & "   " & "--------> " & " " & total_vale1)
            Me.List_contado.Items.Add("4- Vales" & "   " & "--------> " & " " & total_vale1)
            Exit While

        End While

        reader2.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from ticket_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from ticket_01 where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader3 As SqlDataReader = comando.ExecuteReader

        While reader3.Read()

            'If total_ticket1 <> 0 Then Me.List_contado.Items.Add("3- Tickets" & "   " & "------> " & " " & total_ticket1)
            'If total_ticket2 <> 0 Then Me.list_cobranza.Items.Add("3- Tickets" & "   " & "------> " & " " & total_ticket2)
            Me.List_contado.Items.Add("3- Tickets" & "   " & "------> " & " " & total_ticket1)
            Me.list_cobranza.Items.Add("3- Tickets" & "   " & "------> " & " " & total_ticket2)
            Exit While

        End While

        reader3.Close()

        If RTrim(Me.txt_punto_venta.Text) <> "" Then comando = New SqlCommand("select *from recibo_cab where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta2 = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from recibo_cab where fec_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader4 As SqlDataReader = comando.ExecuteReader

        While reader4.Read()

            'If total_ctacte <> 0 Then Me.list_cobranza.Items.Add("1- Efectivo" & "   " & " -----> " & " " & total_ctacte)
            Me.list_cobranza.Items.Add("1- Efectivo" & "   " & " -----> " & " " & total_ctacte)
            Exit While

        End While

        reader4.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from t_credito where f_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text = "" Then comando = New SqlCommand("select *from t_credito where f_emi ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader5 As SqlDataReader = comando.ExecuteReader

        While reader5.Read()

            'If total_credito1 <> 0 Then Me.List_contado.Items.Add("5- T. Credito" & "  " & "----> " & " " & total_credito1)
            'If total_credito2 <> 0 Then Me.list_cobranza.Items.Add("5- T. Credito" & "  " & "----> " & " " & total_credito2)
            Me.List_contado.Items.Add("5- T. Credito" & "  " & "----> " & " " & total_credito1)
            Me.list_cobranza.Items.Add("5- T. Credito" & "  " & "----> " & " " & total_credito2)
            Exit While

        End While

        reader5.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from t_debito where fecha ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and p_venta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from t_debito where fecha ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and talon = '1'", conex)

        Dim reader6 As SqlDataReader = comando.ExecuteReader

        While reader6.Read()

            'If total_debito1 <> 0 Then Me.List_contado.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito1)
            'If total_debito2 <> 0 Then Me.list_cobranza.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito2)
            Me.List_contado.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito1)
            Me.list_cobranza.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito2)
            Exit While

        End While

        reader6.Close()

        If Me.txt_punto_venta.Text <> "" Then comando = New SqlCommand("select *from IngresoEgreso where fecha ='" & RTrim(Me.dt_fec_arqueo.Text) & "' and ptovta = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)

        Dim reader7 As SqlDataReader = comando.ExecuteReader

        While reader7.Read()

            'If total_debito1 <> 0 Then Me.List_contado.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito1)
            'If total_debito2 <> 0 Then Me.list_cobranza.Items.Add("6- T. Debito" & "  " & "----> " & " " & total_debito2)
            Me.List_contado.Items.Add("7- Otros" & "  " & "----> " & " " & total_ingreso_egreso)
            Exit While

        End While

        reader7.Close()
        comando.Dispose()

        Me.List_contado.Focus()

    End Sub

    Private Sub txt_punto_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_punto_venta.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then

            If Me.txt_punto_venta.Text = "" Then
                Me.txt_punto_venta.Focus()
            Else
                Call existencia_valores()
            End If

        End If

    End Sub

    Private Sub dt_fec_arqueo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dt_fec_arqueo.KeyDown

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Then
            Me.txt_punto_venta.Focus()
            Me.txt_punto_venta.SelectAll()
        End If

    End Sub

    Private Sub tool_arqueo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_arqueo.Click

        ' proviosrio porque nom se usa
        Exit Sub

        If Me.lbl_cta_cte.Text = 0 And Me.lbl_contado.Text = 0 Then
            MessageBox.Show("No hay ningun comprobante para arquear", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Call verifica_cuenta()
        Call verifica_arqueo()
        Call verifica_planilla()

        If planilla = False Then
            MessageBox.Show("No existe la planilla de caja nº 1..Verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' ver que se arquee la las facturas y recibos ( arqueo = A )

        If arqueo = True Then Exit Sub

        Dim x As Integer = MessageBox.Show("Comfirma Arqueo ?", "PyMsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If x = 6 Then

            Dim tb As New DataTable
            tb.Clear()
            conex = conecta()

            If Me.lbl_contado.Text > 0 Then

                If t1 = False Then
                    MessageBox.Show("No existe la cuenta 301 (RECAUDACION CONTADO)...verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.Serializable)
                End If

                comando = New SqlCommand("update fact_cab set arqueo = 'A' where arqueo = 'B' and fec_emision = '" & Me.dt_fec_arqueo.Text & "'", conex)
                comando.Transaction = trans
                comando.ExecuteNonQuery()
                comando.Dispose()

                comando = New SqlCommand("insert into planilla_caja(num_interno,fec_emi,cuenta,det_cuenta,entrada,salida,np,tp,mes,año,operacion,num_comprobante,bco,movimiento) values ('" & Date.Now.Day & Date.Now.Month & Date.Now.Year & "','" & Me.dt_fec_arqueo.Text & "','301','RECAUDACION CONTADO','" & Me.lbl_contado.Text & "','','1','1','" & Date.Now.Month & "', '" & Date.Now.Year & "','1000','','','')", conex)
                comando.Transaction = trans
                comando.ExecuteNonQuery()
                comando.Dispose()

            End If

            If Me.lbl_cta_cte.Text > 0 Then

                If t2 = False Then
                    MessageBox.Show("No existe la cuenta 302 (RECAUDACION CTA CTE)...verifique!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If conex.State = ConnectionState.Closed Then
                    conex.Open()
                    trans = conex.BeginTransaction(IsolationLevel.Serializable)
                End If

                comando = New SqlCommand("update recibo_cab set arqueo = 'A' where arqueo = 'B' and fec_emi = '" & Me.dt_fec_arqueo.Text & "'", conex)
                comando.Transaction = trans
                comando.ExecuteNonQuery()
                comando.Dispose()

                comando = New SqlCommand("insert into planilla_caja(num_interno,fec_emi,cuenta,det_cuenta,entrada,salida,np,tp,mes,año,operacion,num_comprobante,bco,movimiento) values ('" & Date.Now.Day & Date.Now.Month & Date.Now.Year & "','" & Me.dt_fec_arqueo.Text & "','302','RECAUDACION CTA CTE','" & Me.lbl_cta_cte.Text & "','','1','1','" & Date.Now.Month & "', '" & Date.Now.Year & "','1000','','','')", conex)
                comando.Transaction = trans
                comando.ExecuteNonQuery()
                comando.Dispose()

            End If

            trans.Commit()
            conex.Close()

            MessageBox.Show("El arqueo se realizo correctamente", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

            Me.Close()
            tb.Dispose()

        End If

    End Sub

    Private Sub txt_punto_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_punto_venta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub verifica_arqueo()

        Dim tb1 As New DataTable

        tb1.Clear()
        conex = conecta()

        If Me.txt_punto_venta.Text = "" Then

            comando1 = New SqlDataAdapter("select arqueo from fact_cab where fec_emision = '" & Me.dt_fec_arqueo.Text & "' and talon = '1'", conex)
            comando1.Fill(tb1)
            comando1.Dispose()

        End If

        If Me.txt_punto_venta.Text <> "" Then

            comando1 = New SqlDataAdapter("select arqueo from fact_cab where fec_emision = '" & Me.dt_fec_arqueo.Text & "' and prefijo_fact = '" & RTrim(Me.txt_punto_venta.Text) & "'", conex)
            comando1.Fill(tb1)
            comando1.Dispose()

        End If

        If RTrim(tb1.Rows(0).Item(0)) = "A" Then
            MessageBox.Show("Comprobantes Arqueados", "pyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            arqueo = True
        Else
            arqueo = False
        End If

        tb1.Dispose()

    End Sub

    Private Sub verifica_cuenta()

        Dim tb2 As New DataTable
        Dim i As Integer

        tb2.Clear()
        conex = conecta()

        comando1 = New SqlDataAdapter("select nombre,cuenta from plan_cuenta where cuenta = '301' or cuenta = '302'", conex)
        comando1.Fill(tb2)
        comando1.Dispose()

        For i = 0 To tb2.Rows.Count - 1

            If RTrim(tb2.Rows(i).Item(1)) = "301" Then

                t1 = True

            End If

            If RTrim(tb2.Rows(i).Item(1)) = "302" Then

                t2 = True

            End If

        Next

        tb2.Dispose()

    End Sub

    Private Sub verifica_planilla()

        Dim tb3 As New DataTable

        tb3.Clear()
        conex = conecta()

        comando1 = New SqlDataAdapter("select id_planilla,numero_planilla from planilla01 where numero_planilla = '1'", conex)
        comando1.Fill(tb3)
        comando1.Dispose()

        If tb3.Rows.Count = Nothing Then

            planilla = False

        Else

            planilla = True

        End If

        tb3.Dispose()

    End Sub

    Private Sub cmd_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_help.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\manual\arqueo.html")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim rep As New arqueo

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        txt = rep.Section2.ReportObjects.Item("efectivo_v")
        txt.Text = total_efectivo

        txt = rep.Section2.ReportObjects.Item("credito_v")
        txt.Text = total_credito1

        txt = rep.Section2.ReportObjects.Item("debito_v")
        txt.Text = total_debito1

        txt = rep.Section2.ReportObjects.Item("cheque_v")
        txt.Text = total_cheque1

        txt = rep.Section2.ReportObjects.Item("ingreso_egreso")
        txt.Text = total_ingreso_egreso

        txt = rep.Section2.ReportObjects.Item("total_v")
        txt.Text = Me.lbl_contado.Text

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        txt = rep.Section2.ReportObjects.Item("efectivo_c")
        txt.Text = total_ctacte

        txt = rep.Section2.ReportObjects.Item("credito_c")
        txt.Text = total_credito2

        txt = rep.Section2.ReportObjects.Item("debito_c")
        txt.Text = total_debito2

        txt = rep.Section2.ReportObjects.Item("cheque_c")
        txt.Text = total_cheque2

        txt = rep.Section2.ReportObjects.Item("total_c")
        txt.Text = Me.lbl_cta_cte.Text

        txt = rep.Section2.ReportObjects.Item("total_arqueo")
        txt.Text = Me.lbl_total.Text

        txt = rep.Section2.ReportObjects.Item("fecha")
        txt.Text = Me.dt_fec_arqueo.Text

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        barra_carga.Timer1.Enabled = True

    End Sub

End Class