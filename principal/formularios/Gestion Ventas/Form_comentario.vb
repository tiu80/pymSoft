Public Class Form_comentario

    Private Sub form_comentario_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If form_factura.txt_estado_form.Text = 1 Then form_factura.comentario = Me.TextBox1.Text
        If Form_muestra_factura.txt_estado_form.Text = 1 Then Form_muestra_factura.valor = Me.TextBox1.Text
    End Sub

    Private Sub Form_comentario_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Close()
    End Sub

    Private Sub Form_comentario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form_muestra_factura.txt_estado_form.Text = 1 Then Me.TextBox1.Text = Form_muestra_factura.valor
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class