<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_vendedor
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_vendedor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.txt_desc = New System.Windows.Forms.TextBox
        Me.txt_interno = New System.Windows.Forms.TextBox
        Me.lbl_tipo = New System.Windows.Forms.Label
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dt_fec_alta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.opt_preventa = New System.Windows.Forms.RadioButton
        Me.opt_mostrador = New System.Windows.Forms.RadioButton
        Me.opt_varios = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmd_borrar = New System.Windows.Forms.Button
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.cmd_pri = New System.Windows.Forms.Button
        Me.cmd_ult = New System.Windows.Forms.Button
        Me.cmd_ant = New System.Windows.Forms.Button
        Me.cmd_sig = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.txt_desc)
        Me.GroupBox1.Controls.Add(Me.txt_interno)
        Me.GroupBox1.Controls.Add(Me.lbl_tipo)
        Me.GroupBox1.Controls.Add(Me.cmb_estado)
        Me.GroupBox1.Controls.Add(Me.txt_tipo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dt_fec_alta)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_nombre)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 381)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(0, 220)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(790, 161)
        Me.DataGridView1.TabIndex = 15
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(125, 28)
        Me.txt_codigo.MaxLength = 9
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(73, 21)
        Me.txt_codigo.TabIndex = 0
        '
        'txt_desc
        '
        Me.txt_desc.Location = New System.Drawing.Point(528, 60)
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(154, 20)
        Me.txt_desc.TabIndex = 14
        Me.txt_desc.Visible = False
        '
        'txt_interno
        '
        Me.txt_interno.Location = New System.Drawing.Point(278, 29)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(38, 20)
        Me.txt_interno.TabIndex = 13
        Me.txt_interno.Visible = False
        '
        'lbl_tipo
        '
        Me.lbl_tipo.AutoSize = True
        Me.lbl_tipo.Location = New System.Drawing.Point(548, 104)
        Me.lbl_tipo.Name = "lbl_tipo"
        Me.lbl_tipo.Size = New System.Drawing.Size(39, 13)
        Me.lbl_tipo.TabIndex = 12
        Me.lbl_tipo.Text = "Label9"
        Me.lbl_tipo.Visible = False
        '
        'cmb_estado
        '
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"Activo", "Baja"})
        Me.cmb_estado.Location = New System.Drawing.Point(195, 183)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(121, 24)
        Me.cmb_estado.TabIndex = 4
        '
        'txt_tipo
        '
        Me.txt_tipo.BackColor = System.Drawing.Color.White
        Me.txt_tipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_tipo.Location = New System.Drawing.Point(129, 183)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(40, 25)
        Me.txt_tipo.TabIndex = 10
        Me.txt_tipo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(38, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(34, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Alta"
        '
        'dt_fec_alta
        '
        Me.dt_fec_alta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fec_alta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_alta.Location = New System.Drawing.Point(125, 149)
        Me.dt_fec_alta.Name = "dt_fec_alta"
        Me.dt_fec_alta.Size = New System.Drawing.Size(91, 21)
        Me.dt_fec_alta.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.opt_preventa)
        Me.GroupBox2.Controls.Add(Me.opt_mostrador)
        Me.GroupBox2.Controls.Add(Me.opt_varios)
        Me.GroupBox2.Location = New System.Drawing.Point(125, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(372, 50)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'opt_preventa
        '
        Me.opt_preventa.AutoSize = True
        Me.opt_preventa.ForeColor = System.Drawing.Color.Black
        Me.opt_preventa.Location = New System.Drawing.Point(271, 17)
        Me.opt_preventa.Name = "opt_preventa"
        Me.opt_preventa.Size = New System.Drawing.Size(78, 17)
        Me.opt_preventa.TabIndex = 2
        Me.opt_preventa.TabStop = True
        Me.opt_preventa.Text = "Preventista"
        Me.opt_preventa.UseVisualStyleBackColor = True
        '
        'opt_mostrador
        '
        Me.opt_mostrador.AutoSize = True
        Me.opt_mostrador.ForeColor = System.Drawing.Color.Black
        Me.opt_mostrador.Location = New System.Drawing.Point(131, 17)
        Me.opt_mostrador.Name = "opt_mostrador"
        Me.opt_mostrador.Size = New System.Drawing.Size(69, 17)
        Me.opt_mostrador.TabIndex = 1
        Me.opt_mostrador.TabStop = True
        Me.opt_mostrador.Text = "Mostador"
        Me.opt_mostrador.UseVisualStyleBackColor = True
        '
        'opt_varios
        '
        Me.opt_varios.AutoSize = True
        Me.opt_varios.Checked = True
        Me.opt_varios.ForeColor = System.Drawing.Color.Black
        Me.opt_varios.Location = New System.Drawing.Point(6, 18)
        Me.opt_varios.Name = "opt_varios"
        Me.opt_varios.Size = New System.Drawing.Size(54, 17)
        Me.opt_varios.TabIndex = 2
        Me.opt_varios.TabStop = True
        Me.opt_varios.Text = "Varios"
        Me.opt_varios.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(34, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TIPO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "DESCRIPCION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CODIGO"
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(125, 59)
        Me.txt_nombre.MaxLength = 50
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(372, 21)
        Me.txt_nombre.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(615, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 68)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Vendedores"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(788, 23)
        Me.Label8.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.cmd_borrar)
        Me.GroupBox3.Controls.Add(Me.cmd_actualizar)
        Me.GroupBox3.Controls.Add(Me.cmd_aceptar)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 461)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(790, 70)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'cmd_borrar
        '
        Me.cmd_borrar.BackColor = System.Drawing.Color.Black
        Me.cmd_borrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_borrar.Enabled = False
        Me.cmd_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_borrar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_borrar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_borrar.Location = New System.Drawing.Point(647, 12)
        Me.cmd_borrar.Name = "cmd_borrar"
        Me.cmd_borrar.Size = New System.Drawing.Size(131, 50)
        Me.cmd_borrar.TabIndex = 7
        Me.cmd_borrar.Text = "Borrar"
        Me.cmd_borrar.UseVisualStyleBackColor = False
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.Enabled = False
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(339, 12)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(131, 50)
        Me.cmd_actualizar.TabIndex = 6
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(10, 12)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(131, 50)
        Me.cmd_aceptar.TabIndex = 5
        Me.cmd_aceptar.Text = "Guardar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'cmd_pri
        '
        Me.cmd_pri.BackgroundImage = Global.pym.My.Resources.Resources.player_start
        Me.cmd_pri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_pri.Enabled = False
        Me.cmd_pri.Location = New System.Drawing.Point(270, 17)
        Me.cmd_pri.Name = "cmd_pri"
        Me.cmd_pri.Size = New System.Drawing.Size(38, 34)
        Me.cmd_pri.TabIndex = 9
        Me.cmd_pri.UseVisualStyleBackColor = True
        '
        'cmd_ult
        '
        Me.cmd_ult.BackgroundImage = Global.pym.My.Resources.Resources.player_end
        Me.cmd_ult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_ult.Enabled = False
        Me.cmd_ult.Location = New System.Drawing.Point(363, 17)
        Me.cmd_ult.Name = "cmd_ult"
        Me.cmd_ult.Size = New System.Drawing.Size(38, 34)
        Me.cmd_ult.TabIndex = 10
        Me.cmd_ult.UseVisualStyleBackColor = True
        '
        'cmd_ant
        '
        Me.cmd_ant.BackgroundImage = Global.pym.My.Resources.Resources.player_rew
        Me.cmd_ant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_ant.Enabled = False
        Me.cmd_ant.Location = New System.Drawing.Point(226, 17)
        Me.cmd_ant.Name = "cmd_ant"
        Me.cmd_ant.Size = New System.Drawing.Size(38, 34)
        Me.cmd_ant.TabIndex = 8
        Me.cmd_ant.UseVisualStyleBackColor = True
        '
        'cmd_sig
        '
        Me.cmd_sig.BackgroundImage = Global.pym.My.Resources.Resources.player_fwd
        Me.cmd_sig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_sig.Enabled = False
        Me.cmd_sig.Location = New System.Drawing.Point(407, 17)
        Me.cmd_sig.Name = "cmd_sig"
        Me.cmd_sig.Size = New System.Drawing.Size(38, 34)
        Me.cmd_sig.TabIndex = 11
        Me.cmd_sig.UseVisualStyleBackColor = True
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(656, 70)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(100, 20)
        Me.txt_estado_form.TabIndex = 12
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(553, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 68)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'form_vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_pri)
        Me.Controls.Add(Me.cmd_ult)
        Me.Controls.Add(Me.cmd_ant)
        Me.Controls.Add(Me.cmd_sig)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "form_vendedor"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENDEDORES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents dt_fec_alta As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_preventa As System.Windows.Forms.RadioButton
    Friend WithEvents opt_mostrador As System.Windows.Forms.RadioButton
    Friend WithEvents opt_varios As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents cmd_borrar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_tipo As System.Windows.Forms.Label
    Friend WithEvents cmd_pri As System.Windows.Forms.Button
    Friend WithEvents cmd_ult As System.Windows.Forms.Button
    Friend WithEvents cmd_ant As System.Windows.Forms.Button
    Friend WithEvents cmd_sig As System.Windows.Forms.Button
    Friend WithEvents txt_interno As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
