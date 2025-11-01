Public Class form_config_rep

    Dim rep As New pymsoft.reporte
    Dim conex As New SqlClient.SqlConnection

    Private Sub cmd_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_aceptar.Click

        If Me.txt_codigo.Text = "" Or Me.txt_descripcion.Text = "" Or Me.txt_reporte.Text = "" Then
            MessageBox.Show("Complete los campos", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txt_codigo.Focus()
            Exit Sub
        End If

        rep.instruccion = "INSERT INTO reporte_01(id,descripcion,reporte,impresora) VALUES('" & Me.txt_codigo.Text & "' , '" & Me.txt_descripcion.Text & "','" & Me.txt_reporte.Text & "','" & Me.txt_impresora.Text & "')"
        rep.abm()

        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_reporte.Text = ""
        Me.Close()

    End Sub

    Private Sub txt_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If e.KeyCode = Keys.F1 Then
            Me.cmd_aceptar.Enabled = True
            Me.cmd_aceptar.BackColor = Color.Black
            Me.cmd_borrar.Enabled = True
            Me.cmd_borrar.BackColor = Color.Black
        End If

        If e.KeyCode = Keys.F2 Then
            Form_muestra_reportes.Show()
        End If

    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub form_config_rep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'PgcDataSet.reporte_01' Puede moverla o quitarla según sea necesario.
        conex = conecta()

        Me.Reporte_01TableAdapter.Connection = conex
        Me.Reporte_01TableAdapter.Fill(Me.PgcDataSet.reporte_01)

        rep.instruccion = "select id,descripcion,reporte from reporte_01"
        rep.mostrar_reporte()

        Me.cmd_aceptar.BackColor = Color.LightGray
        Me.cmd_borrar.BackColor = Color.LightGray

    End Sub

    Private Sub cmd_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_actualizar.Click

        rep.instruccion = "update reporte_01 set descripcion= '" & Me.txt_descripcion.Text & "',reporte = '" & Me.txt_reporte.Text & "',impresora = '" & Me.txt_impresora.Text & "' where id = '" & RTrim(Me.txt_codigo.Text) & "'"
        rep.abm()

        MessageBox.Show("Datos Actualizados!!!", "PyMsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.Close()

    End Sub

    Private Sub cmd_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_borrar.Click

        rep.instruccion = "delete reporte_01 where id = '" & Me.txt_codigo.Text & "'"
        rep.abm()

        Me.Close()

    End Sub

End Class