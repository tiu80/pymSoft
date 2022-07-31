<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_tipo_pago
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txt_tipo_cobro = New mitextbox1.texto_solonum
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_numero = New mitextbox1.texto_solonum
        Me.Label3 = New System.Windows.Forms.Label
        Me.dt_fec_acred = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_banco = New mitextbox1.texto_solonum
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.lbl_tipo = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.txt_descuento = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_banco = New System.Windows.Forms.Label
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.data_forma_cheque = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_cancela = New System.Windows.Forms.Button
        Me.cmd_acepta = New System.Windows.Forms.Button
        Me.txt_num = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.txt_pre = New System.Windows.Forms.TextBox
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.txt_p_venta = New System.Windows.Forms.TextBox
        Me.txt_fec_emi = New System.Windows.Forms.TextBox
        Me.txt_talon = New System.Windows.Forms.TextBox
        Me.txt_abre = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.data_forma_cheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_tipo_cobro
        '
        Me.txt_tipo_cobro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_cobro.Location = New System.Drawing.Point(97, 16)
        Me.txt_tipo_cobro.Name = "txt_tipo_cobro"
        Me.txt_tipo_cobro.Size = New System.Drawing.Size(48, 21)
        Me.txt_tipo_cobro.TabIndex = 0
        Me.txt_tipo_cobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo Pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numero"
        '
        'txt_numero
        '
        Me.txt_numero.Enabled = False
        Me.txt_numero.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(97, 50)
        Me.txt_numero.MaxLength = 30
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(176, 21)
        Me.txt_numero.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripcion"
        '
        'dt_fec_acred
        '
        Me.dt_fec_acred.Enabled = False
        Me.dt_fec_acred.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fec_acred.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_acred.Location = New System.Drawing.Point(97, 153)
        Me.dt_fec_acred.Name = "dt_fec_acred"
        Me.dt_fec_acred.Size = New System.Drawing.Size(116, 21)
        Me.dt_fec_acred.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Banco"
        '
        'txt_banco
        '
        Me.txt_banco.Enabled = False
        Me.txt_banco.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_banco.Location = New System.Drawing.Point(97, 118)
        Me.txt_banco.Name = "txt_banco"
        Me.txt_banco.Size = New System.Drawing.Size(48, 21)
        Me.txt_banco.TabIndex = 3
        Me.txt_banco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Total"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(-2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(287, 48)
        Me.Label7.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(282, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 48)
        Me.Label8.TabIndex = 13
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Enabled = False
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(97, 83)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(249, 21)
        Me.txt_descripcion.TabIndex = 2
        '
        'lbl_tipo
        '
        Me.lbl_tipo.AutoSize = True
        Me.lbl_tipo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo.ForeColor = System.Drawing.Color.Red
        Me.lbl_tipo.Location = New System.Drawing.Point(159, 19)
        Me.lbl_tipo.Name = "lbl_tipo"
        Me.lbl_tipo.Size = New System.Drawing.Size(0, 15)
        Me.lbl_tipo.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Acreditacion"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_total)
        Me.GroupBox2.Controls.Add(Me.lbl_tipo)
        Me.GroupBox2.Controls.Add(Me.txt_descuento)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lbl_banco)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dt_fec_acred)
        Me.GroupBox2.Controls.Add(Me.txt_banco)
        Me.GroupBox2.Controls.Add(Me.txt_tipo_cobro)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 205)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 254)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(97, 221)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(77, 21)
        Me.txt_total.TabIndex = 6
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_descuento
        '
        Me.txt_descuento.Enabled = False
        Me.txt_descuento.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descuento.Location = New System.Drawing.Point(97, 187)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.Size = New System.Drawing.Size(77, 21)
        Me.txt_descuento.TabIndex = 5
        Me.txt_descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Descuento"
        '
        'lbl_banco
        '
        Me.lbl_banco.AutoSize = True
        Me.lbl_banco.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_banco.ForeColor = System.Drawing.Color.Red
        Me.lbl_banco.Location = New System.Drawing.Point(159, 121)
        Me.lbl_banco.Name = "lbl_banco"
        Me.lbl_banco.Size = New System.Drawing.Size(0, 15)
        Me.lbl_banco.TabIndex = 0
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(1, 0)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(64, 20)
        Me.txt_estado_form.TabIndex = 18
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'data_forma_cheque
        '
        Me.data_forma_cheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_forma_cheque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.data_forma_cheque.DefaultCellStyle = DataGridViewCellStyle1
        Me.data_forma_cheque.Location = New System.Drawing.Point(1, 56)
        Me.data_forma_cheque.Name = "data_forma_cheque"
        Me.data_forma_cheque.Size = New System.Drawing.Size(385, 148)
        Me.data_forma_cheque.TabIndex = 19
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Total"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 72
        '
        'Column4
        '
        Me.Column4.HeaderText = "numero"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "banco"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_cancela)
        Me.GroupBox1.Controls.Add(Me.cmd_acepta)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 448)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 65)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmd_cancela
        '
        Me.cmd_cancela.BackColor = System.Drawing.Color.Black
        Me.cmd_cancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_cancela.Enabled = False
        Me.cmd_cancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancela.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_cancela.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancela.Location = New System.Drawing.Point(237, 19)
        Me.cmd_cancela.Name = "cmd_cancela"
        Me.cmd_cancela.Size = New System.Drawing.Size(116, 37)
        Me.cmd_cancela.TabIndex = 8
        Me.cmd_cancela.Text = "Cancelar"
        Me.cmd_cancela.UseVisualStyleBackColor = False
        '
        'cmd_acepta
        '
        Me.cmd_acepta.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta.Enabled = False
        Me.cmd_acepta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_acepta.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta.Location = New System.Drawing.Point(12, 19)
        Me.cmd_acepta.Name = "cmd_acepta"
        Me.cmd_acepta.Size = New System.Drawing.Size(116, 37)
        Me.cmd_acepta.TabIndex = 7
        Me.cmd_acepta.Text = "Aceptar"
        Me.cmd_acepta.UseVisualStyleBackColor = False
        '
        'txt_num
        '
        Me.txt_num.Location = New System.Drawing.Point(89, 0)
        Me.txt_num.Name = "txt_num"
        Me.txt_num.Size = New System.Drawing.Size(56, 20)
        Me.txt_num.TabIndex = 20
        Me.txt_num.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Location = New System.Drawing.Point(151, 0)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(56, 20)
        Me.txt_tipo.TabIndex = 21
        Me.txt_tipo.Visible = False
        '
        'txt_pre
        '
        Me.txt_pre.Location = New System.Drawing.Point(220, 0)
        Me.txt_pre.Name = "txt_pre"
        Me.txt_pre.Size = New System.Drawing.Size(56, 20)
        Me.txt_pre.TabIndex = 22
        Me.txt_pre.Visible = False
        '
        'txt_letra
        '
        Me.txt_letra.Location = New System.Drawing.Point(1, 26)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(56, 20)
        Me.txt_letra.TabIndex = 23
        Me.txt_letra.Visible = False
        '
        'txt_p_venta
        '
        Me.txt_p_venta.Location = New System.Drawing.Point(63, 28)
        Me.txt_p_venta.Name = "txt_p_venta"
        Me.txt_p_venta.Size = New System.Drawing.Size(56, 20)
        Me.txt_p_venta.TabIndex = 24
        Me.txt_p_venta.Visible = False
        '
        'txt_fec_emi
        '
        Me.txt_fec_emi.Location = New System.Drawing.Point(128, 26)
        Me.txt_fec_emi.Name = "txt_fec_emi"
        Me.txt_fec_emi.Size = New System.Drawing.Size(56, 20)
        Me.txt_fec_emi.TabIndex = 25
        Me.txt_fec_emi.Visible = False
        '
        'txt_talon
        '
        Me.txt_talon.Location = New System.Drawing.Point(190, 26)
        Me.txt_talon.Name = "txt_talon"
        Me.txt_talon.Size = New System.Drawing.Size(56, 20)
        Me.txt_talon.TabIndex = 26
        Me.txt_talon.Visible = False
        '
        'txt_abre
        '
        Me.txt_abre.AcceptsTab = True
        Me.txt_abre.Location = New System.Drawing.Point(257, 26)
        Me.txt_abre.Name = "txt_abre"
        Me.txt_abre.Size = New System.Drawing.Size(19, 20)
        Me.txt_abre.TabIndex = 27
        Me.txt_abre.Text = "0"
        Me.txt_abre.Visible = False
        '
        'Form_tipo_pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(385, 517)
        Me.Controls.Add(Me.txt_abre)
        Me.Controls.Add(Me.txt_talon)
        Me.Controls.Add(Me.txt_fec_emi)
        Me.Controls.Add(Me.txt_p_venta)
        Me.Controls.Add(Me.txt_letra)
        Me.Controls.Add(Me.txt_pre)
        Me.Controls.Add(Me.txt_tipo)
        Me.Controls.Add(Me.txt_num)
        Me.Controls.Add(Me.data_forma_cheque)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_tipo_pago"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forma Cobro"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.data_forma_cheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_tipo_cobro As mitextbox1.texto_solonum
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_numero As mitextbox1.texto_solonum
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_acred As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_banco As mitextbox1.texto_solonum
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents lbl_banco As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents data_forma_cheque As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_cancela As System.Windows.Forms.Button
    Friend WithEvents cmd_acepta As System.Windows.Forms.Button
    Friend WithEvents txt_num As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_pre As System.Windows.Forms.TextBox
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents txt_p_venta As System.Windows.Forms.TextBox
    Friend WithEvents txt_fec_emi As System.Windows.Forms.TextBox
    Friend WithEvents txt_talon As System.Windows.Forms.TextBox
    Friend WithEvents txt_abre As System.Windows.Forms.TextBox
End Class
