Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class Form_iva_ventas

    Dim iva As String
    Dim tbl As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub Form_iva_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cmb_tipo.Text = Me.cmb_tipo.Items(0)
        Me.cmb_tipo_iva.Text = Me.cmb_tipo_iva.Items(0)

    End Sub

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.txt_estado_form.Text = 1 Then Call carga_iva_factura()

        If Me.txt_estado_form.Text = 2 Then Call carga_iva_factura_compras()

    End Sub

    Private Sub cmd_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub cmb_tipo_iva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo_iva.SelectedIndexChanged

        If Me.cmb_tipo_iva.SelectedItem = "Total" Then
            iva = Me.cmb_tipo_iva.Items(0)  ' total
        End If

        If Me.cmb_tipo_iva.SelectedItem = "Responsable Inscripto" Or Me.cmb_tipo_iva.SelectedItem = "Monotributo" Then
            iva = Me.cmb_tipo_iva.Items(1)   ' inscripto
        End If

        'If Me.cmb_tipo_iva.SelectedItem = "Monotributo" Then
        'iva = Me.cmb_tipo_iva.Items(2)   ' monotributo
        'End If

        If Me.cmb_tipo_iva.SelectedItem = "Consumidor Final" Then
            iva = Me.cmb_tipo_iva.Items(3)   ' c. final
        End If

        If Me.cmb_tipo_iva.SelectedItem = "No Categorizado" Then
            iva = Me.cmb_tipo_iva.Items(4)   ' monotributo
        End If

        If Me.cmb_tipo_iva.SelectedItem = " No Inscripto" Then
            iva = Me.cmb_tipo_iva.Items(5)   ' No Categorizado
        End If

    End Sub

    Private Sub txt_p_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_p_venta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dt_fec_desde.Focus()
        End If
    End Sub

    Private Sub carga_iva_factura()

        Try

            Dim rep As New iva_vta
            Dim tbl1 As New DataTable
            Dim selectionFormula As String = ""

            conex = conecta()

            barra_carga.Show()
            barra_carga.PictureBox1.Refresh()

            rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
            rep.SetDatabaseLogon(conexion.usuario, "")

            tbl.Clear()

            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim txt1 As CrystalDecisions.CrystalReports.Engine.TextObject

            txt = rep.Section2.ReportObjects.Item("mes")
            txt.Text = Me.dt_fec_desde.Value.Month

            txt1 = rep.Section2.ReportObjects.Item("año")
            txt1.Text = Me.dt_fec_desde.Value.Year

            If Me.cmb_tipo.Text = RTrim("Total") Then

                If iva = "Total" Then

                    If Me.txt_p_venta.Text <> "" Then
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.id_cli=fact_tot.id_cliente and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)

                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula
                    End If

                Else

                    If Me.txt_p_venta.Text <> "" Then

                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "'and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact <> 'RE' and fact_cab.tipo_fact <> 'RS' and fact_cab.tipo_fact <> 'PD' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    End If

                End If

            End If

            If Me.cmb_tipo.Text = RTrim("Facturas") Then

                If iva = "Total" Then

                    If Me.txt_p_venta.Text <> "" Then
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "'and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact = 'FC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_fact} = 'FC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact = 'FC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'FC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    End If

                Else

                    If Me.txt_p_venta.Text <> "" Then
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "'and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact = 'FC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact = 'FC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RE' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'RS' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} <> 'PD'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    End If

                End If

            End If

            If Me.cmb_tipo.Text = RTrim("N. Creditos") Then

                If iva = "Total" Then

                    If Me.txt_p_venta.Text <> "" Then
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "'and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact = 'NC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_fact} = 'NC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_fact = 'NC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_fact} = 'NC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    End If

                Else

                    If Me.txt_p_venta.Text <> "" Then
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = 1 and fact_cab.talon = fact_tot.talon2 and fact_cab.prefijo_fact = '" & RTrim(Me.txt_p_venta.Text) & "'and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact = 'NC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "

                        If Not String.IsNullOrEmpty(Me.txt_p_venta.Text) Then
                            selectionFormula &= "{fact_cab.prefijo_fact} = " & RTrim(Me.txt_p_venta.Text) & " AND "
                        End If

                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} = 'NC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    Else
                        'comando = New SqlDataAdapter("select fec_emision,tipo_fact,num_fact1,prefijo_fact,letra_fact,nombre,tipo_iva,cuit,ing_bruto1,sub_total,exento,iva_ins,imp_interno1,total from fact_cab inner join fact_tot on fact_cab.fec_emision >= '" & RTrim(Me.dt_fec_desde.Text) & "' and fact_cab.fec_emision <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and fact_cab.talon = fact_tot.talon2 and fact_cab.talon = '1' and fact_cab.num_fact1= fact_tot.num_factura and fact_cab.prefijo_fact = fact_tot.pref and fact_cab.letra_fact = fact_tot.letra and fact_cab.tipo_fact = fact_tot.tipo_factura and fact_cab.tipo_iva = '" & iva & "' and fact_cab.tipo_fact = 'NC' ORDER BY num_fact1,prefijo_fact,letra_fact,tipo_fact ASC", conex)
                        'comando.Fill(tbl)
                        'comando.Dispose()

                        ' Construir la fórmula paso a paso
                        selectionFormula &= "{fact_cab.fec_emision} >= Date('" & Me.dt_fec_desde.Text & "') AND "
                        selectionFormula &= "{fact_cab.fec_emision} <= Date('" & Me.dt_fec_hasta.Text & "') AND "
                        selectionFormula &= "{fact_cab.talon} = 1 AND "
                        selectionFormula &= "{fact_cab.tipo_iva} = '" & iva & "' AND "
                        selectionFormula &= "{fact_cab.tipo_fact} = 'NC'"

                        ' Asignar la fórmula al reporte
                        rep.RecordSelectionFormula = selectionFormula

                    End If

                End If

            End If

            'rep.SetDataSource(tbl)

            Form_repcli_01.CrystalReportViewer1.ReportSource = rep
            Form_repcli_01.CrystalReportViewer1.RefreshReport()
            Form_repcli_01.Show()

            barra_carga.Timer1.Enabled = True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information, "Pym Soft")
            barra_carga.Timer1.Enabled = True
            Me.Close()

        Finally

            Me.Dispose()

        End Try

    End Sub

    Private Sub carga_iva_factura_compras()

        Dim rep As New iva_compra

        conex = conecta()

        barra_carga.Show()
        barra_carga.PictureBox1.Refresh()

        rep.DataSourceConnections(0).SetConnection(conexion.server, conexion.db, False)
        rep.SetDatabaseLogon(conexion.usuario, "")

        tbl.Clear()

        If RTrim(Me.cmb_tipo_iva.Text) = "Total" Then

            If Me.cmb_tipo.Text = RTrim("Total") Then

                If iva = "Total" Then

                    If Me.txt_p_venta.Text <> "" Then
                        comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.talon = '" & Trim(Me.txt_p_venta.Text) & "' and compra_cab.talon = compra_tot.talon2 and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                        comando.Fill(tbl)
                    Else
                        comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.talon = '1' and compra_cab.talon = compra_tot.talon2 and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                        comando.Fill(tbl)
                    End If

                Else

                    If Me.txt_p_venta.Text <> "" Then
                        comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.talon = '" & Trim(Me.txt_p_venta.Text) & "' and compra_cab.talon = compra_tot.talon2 and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo_iva = '" & RTrim(iva) & "' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                        comando.Fill(tbl)
                    Else
                        comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.talon = '1' and compra_cab.talon = compra_tot.talon2 and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo_iva = '" & RTrim(iva) & "' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                        comando.Fill(tbl)
                    End If

                End If

            End If

            If Me.cmb_tipo.Text = RTrim("Facturas") Then

                If iva = "Total" Then

                    comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo = 'FC' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                    comando.Fill(tbl)

                Else

                    comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo = 'FC' and compra_cab.tipo_iva = '" & RTrim(iva) & "' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                    comando.Fill(tbl)

                End If

            End If

            If Me.cmb_tipo.Text = RTrim("N. Creditos") Then

                If iva = "Total" Then

                    comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo = 'NC' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                    comando.Fill(tbl)

                Else

                    comando = New SqlDataAdapter("select fec_emi,tipo,numero,prefijo,letra,nombre,tipo_iva,cuit,total,exento,iva_ins,imp_interno,neto from compra_cab inner join compra_tot on compra_cab.fec_emi >= '" & RTrim(Me.dt_fec_desde.Text) & "' and compra_cab.fec_emi <= '" & RTrim(Me.dt_fec_hasta.Text) & "' and compra_cab.numero = compra_tot.num1 and compra_cab.prefijo = compra_tot.pre1 and compra_cab.letra = compra_tot.lt1 and compra_cab.tipo = compra_tot.tipo2 and compra_cab.tipo = 'NC' and compra_cab.tipo_iva = '" & RTrim(iva) & "' and compra_cab.id_cliente = compra_tot.id_cli1", conex)
                    comando.Fill(tbl)

                End If

            End If

        End If

        rep.SetDataSource(tbl)

        barra_carga.Timer1.Enabled = True

        Form_repcli_01.CrystalReportViewer1.ReportSource = rep
        Form_repcli_01.CrystalReportViewer1.RefreshReport()
        Form_repcli_01.Show()

        Me.Dispose()


    End Sub
End Class