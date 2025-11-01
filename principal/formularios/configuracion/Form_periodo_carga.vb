Imports System.Data
Imports System.Data.SqlClient

Public Class Form_periodo_carga

    Dim par As New pymsoft.parametro
    Dim modifica As Boolean = True
    Dim tbl As New DataTable, tb As New DataTable
    Dim comando As SqlDataAdapter
    Dim conex As New SqlConnection

    Private Sub Form_periodo_carga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j, valor As Integer

        valor = 2009
        For i = 2009 To 2100
            Me.ComboBox1.Items.Add(valor)
            valor = valor + 1
            j = j + 1
        Next

        tb.Clear()
        conex = conecta()

        comando = New SqlDataAdapter("select año from p_carga01 where año=año", conex)
        comando.Fill(tb)

        Me.ComboBox1.Text = tb.Rows(0).Item(0)

        tb.Dispose()

    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.GroupBox1.Visible = True
            Call carga_config()
        End If
    End Sub

    Private Sub Check_enero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_enero.CheckedChanged
        If modifica = True Then
            If Me.Check_enero.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '1'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '1'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_febrero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_febrero.CheckedChanged
        If modifica = True Then
            If Me.Check_febrero.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '2'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '2'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_marzo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_marzo.CheckedChanged
        If modifica = True Then
            If Me.Check_marzo.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '3'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '3'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_abril_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_abril.CheckedChanged
        If modifica = True Then
            If Me.Check_abril.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '4'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '4'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_mayo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_mayo.CheckedChanged
        If modifica = True Then
            If Me.Check_mayo.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '5'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '5'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_junio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_junio.CheckedChanged
        If modifica = True Then
            If Me.Check_junio.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '6'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '6'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_julio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_julio.CheckedChanged
        If modifica = True Then
            If Me.Check_julio.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '7'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '7'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_agosto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_agosto.CheckedChanged
        If modifica = True Then
            If Me.Check_agosto.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '8'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '8'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_setiembre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_setiembre.CheckedChanged
        If modifica = True Then
            If Me.Check_setiembre.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '9'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '9'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_octubre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_octubre.CheckedChanged
        If modifica = True Then
            If Me.Check_octubre.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '10'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '10'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_noviembre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_noviembre.CheckedChanged
        If modifica = True Then
            If Me.Check_noviembre.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A', año= '" & Me.ComboBox1.Text & "' where mes= '11'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '11'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub Check_diciembre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_diciembre.CheckedChanged
        If modifica = True Then
            If Me.Check_diciembre.Checked = True Then
                par.instruccion = "update p_carga01 set estado='A',año= '" & Me.ComboBox1.Text & "' where mes= '12'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            Else
                par.instruccion = "update p_carga01 set estado='B', año= '" & Me.ComboBox1.Text & "' where mes= '12'"
                par.abm()
                par.instruccion = "update p_carga01 set año= '" & Me.ComboBox1.Text & "' where mes <> '0'"
                par.abm()
            End If
        End If
    End Sub

    Private Sub carga_config()

        tbl.Clear()

        Try

            Me.ComboBox1.Text = Me.ComboBox1.SelectedItem

            conex = conecta()

            comando = New SqlDataAdapter("select *from p_carga01 where año = '" & RTrim(Me.ComboBox1.Text) & "'", conex)
            comando.Fill(tbl)

            modifica = True

            If tbl.Rows.Count = 0 Then

                modifica = False

                Me.Check_enero.Checked = False
                Me.Check_febrero.Checked = False
                Me.Check_marzo.Checked = False
                Me.Check_abril.Checked = False
                Me.Check_mayo.Checked = False
                Me.Check_junio.Checked = False
                Me.Check_julio.Checked = False
                Me.Check_agosto.Checked = False
                Me.Check_setiembre.Checked = False
                Me.Check_octubre.Checked = False
                Me.Check_noviembre.Checked = False
                Me.Check_diciembre.Checked = False

                modifica = True

            End If

            If RTrim(tbl.Rows(0).Item(2)) = "A" Then
                Me.Check_enero.Checked = True
            Else
                Me.Check_enero.Checked = False
            End If

            If RTrim(tbl.Rows(1).Item(2)) = "A" Then
                Me.Check_febrero.Checked = True
            Else
                Me.Check_febrero.Checked = False
            End If

            If RTrim(tbl.Rows(2).Item(2)) = "A" Then
                Me.Check_marzo.Checked = True
            Else
                Me.Check_marzo.Checked = False
            End If

            If RTrim(tbl.Rows(3).Item(2)) = "A" Then
                Me.Check_abril.Checked = True
            Else
                Me.Check_abril.Checked = False
            End If

            If RTrim(tbl.Rows(4).Item(2)) = "A" Then
                Me.Check_mayo.Checked = True
            Else
                Me.Check_mayo.Checked = False
            End If

            If RTrim(tbl.Rows(5).Item(2)) = "A" Then
                Me.Check_junio.Checked = True
            Else
                Me.Check_junio.Checked = False
            End If

            If RTrim(tbl.Rows(6).Item(2)) = "A" Then
                Me.Check_julio.Checked = True
            Else
                Me.Check_julio.Checked = False
            End If

            If RTrim(tbl.Rows(7).Item(2)) = "A" Then
                Me.Check_agosto.Checked = True
            Else
                Me.Check_agosto.Checked = False
            End If

            If RTrim(tbl.Rows(8).Item(2)) = "A" Then
                Me.Check_setiembre.Checked = True
            Else
                Me.Check_setiembre.Checked = False
            End If

            If RTrim(tbl.Rows(9).Item(2)) = "A" Then
                Me.Check_octubre.Checked = True
            Else
                Me.Check_octubre.Checked = False
            End If

            If RTrim(tbl.Rows(10).Item(2)) = "A" Then
                Me.Check_noviembre.Checked = True
            Else
                Me.Check_noviembre.Checked = False
            End If

            If RTrim(tbl.Rows(11).Item(2)) = "A" Then
                Me.Check_diciembre.Checked = True
            Else
                Me.Check_diciembre.Checked = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.GroupBox1.Visible = True
        Call carga_config()
    End Sub
End Class