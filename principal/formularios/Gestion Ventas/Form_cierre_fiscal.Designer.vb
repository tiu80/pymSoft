<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cierre_fiscal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cierre_fiscal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AxHASAR1 = New AxFiscalPrinterLib.AxHASAR
        Me.cmd_cierre_x = New System.Windows.Forms.Button
        Me.cmd_cierre_z = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxHASAR1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AxHASAR1)
        Me.GroupBox1.Controls.Add(Me.cmd_cierre_x)
        Me.GroupBox1.Controls.Add(Me.cmd_cierre_z)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'AxHASAR1
        '
        Me.AxHASAR1.Enabled = True
        Me.AxHASAR1.Location = New System.Drawing.Point(231, 152)
        Me.AxHASAR1.Name = "AxHASAR1"
        Me.AxHASAR1.OcxState = CType(resources.GetObject("AxHASAR1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxHASAR1.Size = New System.Drawing.Size(32, 32)
        Me.AxHASAR1.TabIndex = 2
        '
        'cmd_cierre_x
        '
        Me.cmd_cierre_x.BackColor = System.Drawing.Color.Black
        Me.cmd_cierre_x.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cierre_x.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cierre_x.Location = New System.Drawing.Point(39, 127)
        Me.cmd_cierre_x.Name = "cmd_cierre_x"
        Me.cmd_cierre_x.Size = New System.Drawing.Size(175, 28)
        Me.cmd_cierre_x.TabIndex = 1
        Me.cmd_cierre_x.Text = "Cierre X"
        Me.cmd_cierre_x.UseVisualStyleBackColor = False
        '
        'cmd_cierre_z
        '
        Me.cmd_cierre_z.BackColor = System.Drawing.Color.Black
        Me.cmd_cierre_z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cierre_z.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cierre_z.Location = New System.Drawing.Point(39, 31)
        Me.cmd_cierre_z.Name = "cmd_cierre_z"
        Me.cmd_cierre_z.Size = New System.Drawing.Size(175, 28)
        Me.cmd_cierre_z.TabIndex = 0
        Me.cmd_cierre_z.Text = "Cierre Z"
        Me.cmd_cierre_z.UseVisualStyleBackColor = False
        '
        'Form_cierre_fiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(292, 204)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cierre_fiscal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Fiscal"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AxHASAR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_cierre_x As System.Windows.Forms.Button
    Friend WithEvents cmd_cierre_z As System.Windows.Forms.Button
    Friend WithEvents AxHASAR1 As AxFiscalPrinterLib.AxHASAR
End Class
