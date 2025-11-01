<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_tipo_comprobante
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmd_tickets = New System.Windows.Forms.Button
        Me.cmd_factura = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmd_tickets
        '
        Me.cmd_tickets.BackColor = System.Drawing.Color.Black
        Me.cmd_tickets.FlatAppearance.BorderSize = 0
        Me.cmd_tickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_tickets.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_tickets.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_tickets.Location = New System.Drawing.Point(19, 32)
        Me.cmd_tickets.Name = "cmd_tickets"
        Me.cmd_tickets.Size = New System.Drawing.Size(106, 42)
        Me.cmd_tickets.TabIndex = 0
        Me.cmd_tickets.Text = "TICKETS"
        Me.cmd_tickets.UseVisualStyleBackColor = False
        '
        'cmd_factura
        '
        Me.cmd_factura.BackColor = System.Drawing.Color.Black
        Me.cmd_factura.FlatAppearance.BorderSize = 0
        Me.cmd_factura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_factura.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_factura.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_factura.Location = New System.Drawing.Point(156, 32)
        Me.cmd_factura.Name = "cmd_factura"
        Me.cmd_factura.Size = New System.Drawing.Size(106, 42)
        Me.cmd_factura.TabIndex = 1
        Me.cmd_factura.Text = "FACTURA"
        Me.cmd_factura.UseVisualStyleBackColor = False
        '
        'Form_tipo_comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmd_factura)
        Me.Controls.Add(Me.cmd_tickets)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form_tipo_comprobante"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_tickets As System.Windows.Forms.Button
    Friend WithEvents cmd_factura As System.Windows.Forms.Button
End Class
