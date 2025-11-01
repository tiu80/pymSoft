<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_consulta_comprobante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_consulta_comprobante))
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_n_carga = New System.Windows.Forms.TextBox
        Me.lbl_n_carga = New System.Windows.Forms.Label
        Me.Check_talonario = New System.Windows.Forms.CheckBox
        Me.txt_acu = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_cliente_total = New System.Windows.Forms.ComboBox
        Me.cmb_modalidad = New System.Windows.Forms.ComboBox
        Me.cmb_tipo = New System.Windows.Forms.ComboBox
        Me.dt_fec_fin = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_ini = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(604, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 70)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Consulta Comprobantes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txt_n_carga)
        Me.GroupBox1.Controls.Add(Me.lbl_n_carga)
        Me.GroupBox1.Controls.Add(Me.Check_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_acu)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_cliente_total)
        Me.GroupBox1.Controls.Add(Me.cmb_modalidad)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo)
        Me.GroupBox1.Controls.Add(Me.dt_fec_fin)
        Me.GroupBox1.Controls.Add(Me.dt_fec_ini)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 347)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'txt_n_carga
        '
        Me.txt_n_carga.Location = New System.Drawing.Point(331, 310)
        Me.txt_n_carga.Name = "txt_n_carga"
        Me.txt_n_carga.Size = New System.Drawing.Size(86, 20)
        Me.txt_n_carga.TabIndex = 25
        Me.txt_n_carga.Visible = False
        '
        'lbl_n_carga
        '
        Me.lbl_n_carga.AutoSize = True
        Me.lbl_n_carga.Location = New System.Drawing.Point(271, 313)
        Me.lbl_n_carga.Name = "lbl_n_carga"
        Me.lbl_n_carga.Size = New System.Drawing.Size(53, 13)
        Me.lbl_n_carga.TabIndex = 24
        Me.lbl_n_carga.Text = "Nº Carga:"
        Me.lbl_n_carga.Visible = False
        '
        'Check_talonario
        '
        Me.Check_talonario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Check_talonario.AutoSize = True
        Me.Check_talonario.BackColor = System.Drawing.Color.Black
        Me.Check_talonario.Location = New System.Drawing.Point(206, 313)
        Me.Check_talonario.Name = "Check_talonario"
        Me.Check_talonario.Size = New System.Drawing.Size(29, 17)
        Me.Check_talonario.TabIndex = 18
        Me.Check_talonario.Tag = " "
        Me.Check_talonario.Text = " "
        Me.Check_talonario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check_talonario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Check_talonario.UseVisualStyleBackColor = False
        '
        'txt_acu
        '
        Me.txt_acu.Location = New System.Drawing.Point(451, 239)
        Me.txt_acu.Name = "txt_acu"
        Me.txt_acu.Size = New System.Drawing.Size(100, 20)
        Me.txt_acu.TabIndex = 11
        Me.txt_acu.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(73, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nombre"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Modalidad"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(73, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Tipo"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(73, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Hasta"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Desde"
        '
        'cmb_cliente_total
        '
        Me.cmb_cliente_total.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_cliente_total.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_cliente_total.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_cliente_total.FormattingEnabled = True
        Me.cmb_cliente_total.Location = New System.Drawing.Point(206, 265)
        Me.cmb_cliente_total.Name = "cmb_cliente_total"
        Me.cmb_cliente_total.Size = New System.Drawing.Size(211, 23)
        Me.cmb_cliente_total.TabIndex = 4
        Me.cmb_cliente_total.Visible = False
        '
        'cmb_modalidad
        '
        Me.cmb_modalidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_modalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_modalidad.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_modalidad.FormattingEnabled = True
        Me.cmb_modalidad.Items.AddRange(New Object() {"Total", "Cliente/Proveedor", "Vendedor", "Zona"})
        Me.cmb_modalidad.Location = New System.Drawing.Point(206, 211)
        Me.cmb_modalidad.Name = "cmb_modalidad"
        Me.cmb_modalidad.Size = New System.Drawing.Size(211, 23)
        Me.cmb_modalidad.TabIndex = 3
        '
        'cmb_tipo
        '
        Me.cmb_tipo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipo.FormattingEnabled = True
        Me.cmb_tipo.Items.AddRange(New Object() {"Facturas", "Debitos", "Recibos", "Pedidos", "Presupuestos"})
        Me.cmb_tipo.Location = New System.Drawing.Point(206, 154)
        Me.cmb_tipo.Name = "cmb_tipo"
        Me.cmb_tipo.Size = New System.Drawing.Size(211, 23)
        Me.cmb_tipo.TabIndex = 2
        '
        'dt_fec_fin
        '
        Me.dt_fec_fin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dt_fec_fin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_fin.Location = New System.Drawing.Point(206, 101)
        Me.dt_fec_fin.Name = "dt_fec_fin"
        Me.dt_fec_fin.Size = New System.Drawing.Size(211, 21)
        Me.dt_fec_fin.TabIndex = 1
        '
        'dt_fec_ini
        '
        Me.dt_fec_ini.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dt_fec_ini.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_ini.Location = New System.Drawing.Point(206, 47)
        Me.dt_fec_ini.Name = "dt_fec_ini"
        Me.dt_fec_ini.Size = New System.Drawing.Size(211, 21)
        Me.dt_fec_ini.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.cmd_cancelar)
        Me.GroupBox2.Controls.Add(Me.cmd_aceptar)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 415)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(791, 128)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_cancelar.BackColor = System.Drawing.Color.Black
        Me.cmd_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancelar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancelar.Location = New System.Drawing.Point(625, 39)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(136, 63)
        Me.cmd_cancelar.TabIndex = 1
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.UseVisualStyleBackColor = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(29, 39)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(136, 63)
        Me.cmd_aceptar.TabIndex = 0
        Me.cmd_aceptar.Text = "Aceptar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(526, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 70)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(50, 26)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(45, 20)
        Me.txt_estado_form.TabIndex = 10
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Form_consulta_comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 542)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_consulta_comprobante"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Comprobantes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dt_fec_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents dt_fec_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_cliente_total As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_modalidad As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_acu As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Check_talonario As System.Windows.Forms.CheckBox
    Friend WithEvents txt_n_carga As System.Windows.Forms.TextBox
    Friend WithEvents lbl_n_carga As System.Windows.Forms.Label
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
End Class
