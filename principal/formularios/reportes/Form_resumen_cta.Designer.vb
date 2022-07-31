<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_resumen_cta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_resumen_cta))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Check_talonario = New System.Windows.Forms.CheckBox
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.lbl_cliente = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dt_fec_hasta = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_emi = New System.Windows.Forms.DateTimePicker
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(510, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 67)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(573, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 67)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Resumen de cuenta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.BackColor = System.Drawing.Color.Black
        Me.cmd_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancelar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancelar.Location = New System.Drawing.Point(629, 452)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(128, 65)
        Me.cmd_cancelar.TabIndex = 26
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.UseVisualStyleBackColor = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(21, 452)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(128, 65)
        Me.cmd_aceptar.TabIndex = 25
        Me.cmd_aceptar.Text = "Aceptar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Check_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_estado_form)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.lbl_cliente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dt_fec_hasta)
        Me.GroupBox1.Controls.Add(Me.dt_fec_emi)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 363)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'Check_talonario
        '
        Me.Check_talonario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Check_talonario.AutoSize = True
        Me.Check_talonario.BackColor = System.Drawing.Color.Black
        Me.Check_talonario.Location = New System.Drawing.Point(232, 316)
        Me.Check_talonario.Name = "Check_talonario"
        Me.Check_talonario.Size = New System.Drawing.Size(29, 17)
        Me.Check_talonario.TabIndex = 25
        Me.Check_talonario.Tag = " "
        Me.Check_talonario.Text = " "
        Me.Check_talonario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check_talonario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Check_talonario.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(669, 45)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(100, 20)
        Me.txt_estado_form.TabIndex = 24
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(232, 103)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(198, 20)
        Me.txt_codigo.TabIndex = 0
        Me.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cliente.ForeColor = System.Drawing.Color.Red
        Me.lbl_cliente.Location = New System.Drawing.Point(438, 106)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(0, 16)
        Me.lbl_cliente.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(132, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Desde"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(129, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Codigo Cliente"
        '
        'dt_fec_hasta
        '
        Me.dt_fec_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_hasta.Location = New System.Drawing.Point(232, 246)
        Me.dt_fec_hasta.Name = "dt_fec_hasta"
        Me.dt_fec_hasta.Size = New System.Drawing.Size(198, 20)
        Me.dt_fec_hasta.TabIndex = 2
        '
        'dt_fec_emi
        '
        Me.dt_fec_emi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_emi.Location = New System.Drawing.Point(232, 173)
        Me.dt_fec_emi.Name = "dt_fec_emi"
        Me.dt_fec_emi.Size = New System.Drawing.Size(198, 20)
        Me.dt_fec_emi.TabIndex = 1
        '
        'Form_resumen_cta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmd_cancelar)
        Me.Controls.Add(Me.cmd_aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_resumen_cta"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESUMEN DE CUENTA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_emi As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents Check_talonario As System.Windows.Forms.CheckBox
End Class
