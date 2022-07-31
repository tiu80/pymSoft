<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_muestra_planilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_muestra_planilla))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_inputacion = New mitextbox1.texto_solonum
        Me.cmd_guarda_mov = New System.Windows.Forms.Button
        Me.txt_numero_planilla = New System.Windows.Forms.TextBox
        Me.txt_codigo_planilla = New System.Windows.Forms.TextBox
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Tool_eminina_item = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Tool_eminima_mov = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Tool_imprime = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Tool_exporta = New System.Windows.Forms.ToolStripButton
        Me.lbl_imputacion = New System.Windows.Forms.Label
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.grupo = New System.Windows.Forms.GroupBox
        Me.opt_salida = New System.Windows.Forms.RadioButton
        Me.opt_entrada = New System.Windows.Forms.RadioButton
        Me.txt_importe = New System.Windows.Forms.TextBox
        Me.dt_fec_acredit = New System.Windows.Forms.DateTimePicker
        Me.txt_num_comprobante = New System.Windows.Forms.TextBox
        Me.txt_detalle = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_movimiento = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.DataGridView1.Location = New System.Drawing.Point(-6, 275)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(788, 262)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nº interno"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "Cuenta"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Detalle"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 280
        '
        'Column4
        '
        Me.Column4.HeaderText = "Entrada"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Salida"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "num comprobante"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "bco"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "movimiento"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "descripcion"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txt_inputacion)
        Me.GroupBox1.Controls.Add(Me.cmd_guarda_mov)
        Me.GroupBox1.Controls.Add(Me.txt_numero_planilla)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_planilla)
        Me.GroupBox1.Controls.Add(Me.cmd_cancelar)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.lbl_imputacion)
        Me.GroupBox1.Controls.Add(Me.txt_estado_form)
        Me.GroupBox1.Controls.Add(Me.cmd_aceptar)
        Me.GroupBox1.Controls.Add(Me.grupo)
        Me.GroupBox1.Controls.Add(Me.txt_importe)
        Me.GroupBox1.Controls.Add(Me.dt_fec_acredit)
        Me.GroupBox1.Controls.Add(Me.txt_num_comprobante)
        Me.GroupBox1.Controls.Add(Me.txt_detalle)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_movimiento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 278)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_inputacion
        '
        Me.txt_inputacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inputacion.Location = New System.Drawing.Point(188, 115)
        Me.txt_inputacion.MaxLength = 9
        Me.txt_inputacion.Name = "txt_inputacion"
        Me.txt_inputacion.Size = New System.Drawing.Size(190, 22)
        Me.txt_inputacion.TabIndex = 3
        Me.txt_inputacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmd_guarda_mov
        '
        Me.cmd_guarda_mov.BackColor = System.Drawing.Color.Black
        Me.cmd_guarda_mov.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_guarda_mov.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_guarda_mov.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_guarda_mov.Location = New System.Drawing.Point(649, 184)
        Me.cmd_guarda_mov.Name = "cmd_guarda_mov"
        Me.cmd_guarda_mov.Size = New System.Drawing.Size(108, 74)
        Me.cmd_guarda_mov.TabIndex = 56
        Me.cmd_guarda_mov.Text = "Guardar Movimiento"
        Me.cmd_guarda_mov.UseVisualStyleBackColor = False
        '
        'txt_numero_planilla
        '
        Me.txt_numero_planilla.Location = New System.Drawing.Point(702, 20)
        Me.txt_numero_planilla.Name = "txt_numero_planilla"
        Me.txt_numero_planilla.Size = New System.Drawing.Size(30, 20)
        Me.txt_numero_planilla.TabIndex = 55
        Me.txt_numero_planilla.Visible = False
        '
        'txt_codigo_planilla
        '
        Me.txt_codigo_planilla.Location = New System.Drawing.Point(666, 20)
        Me.txt_codigo_planilla.Name = "txt_codigo_planilla"
        Me.txt_codigo_planilla.Size = New System.Drawing.Size(30, 20)
        Me.txt_codigo_planilla.TabIndex = 54
        Me.txt_codigo_planilla.Visible = False
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.BackColor = System.Drawing.Color.Black
        Me.cmd_cancelar.Enabled = False
        Me.cmd_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancelar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_cancelar.Location = New System.Drawing.Point(478, 197)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(60, 54)
        Me.cmd_cancelar.TabIndex = 8
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(188, 256)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(116, 27)
        Me.Panel1.TabIndex = 53
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tool_eminina_item, Me.ToolStripSeparator1, Me.Tool_eminima_mov, Me.ToolStripSeparator2, Me.Tool_imprime, Me.ToolStripSeparator3, Me.Tool_exporta})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(116, 23)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Tool_eminina_item
        '
        Me.Tool_eminina_item.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_eminina_item.Enabled = False
        Me.Tool_eminina_item.Image = CType(resources.GetObject("Tool_eminina_item.Image"), System.Drawing.Image)
        Me.Tool_eminina_item.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_eminina_item.Name = "Tool_eminina_item"
        Me.Tool_eminina_item.Size = New System.Drawing.Size(23, 20)
        Me.Tool_eminina_item.Text = "Eminina Items"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'Tool_eminima_mov
        '
        Me.Tool_eminima_mov.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_eminima_mov.Enabled = False
        Me.Tool_eminima_mov.Image = CType(resources.GetObject("Tool_eminima_mov.Image"), System.Drawing.Image)
        Me.Tool_eminima_mov.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_eminima_mov.Name = "Tool_eminima_mov"
        Me.Tool_eminima_mov.Size = New System.Drawing.Size(23, 20)
        Me.Tool_eminima_mov.Text = "Elimina Movimiento"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'Tool_imprime
        '
        Me.Tool_imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_imprime.Enabled = False
        Me.Tool_imprime.Image = CType(resources.GetObject("Tool_imprime.Image"), System.Drawing.Image)
        Me.Tool_imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_imprime.Name = "Tool_imprime"
        Me.Tool_imprime.Size = New System.Drawing.Size(23, 20)
        Me.Tool_imprime.Text = "Imprimir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'Tool_exporta
        '
        Me.Tool_exporta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_exporta.Enabled = False
        Me.Tool_exporta.Image = CType(resources.GetObject("Tool_exporta.Image"), System.Drawing.Image)
        Me.Tool_exporta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_exporta.Name = "Tool_exporta"
        Me.Tool_exporta.Size = New System.Drawing.Size(23, 20)
        Me.Tool_exporta.Text = "Exportar"
        '
        'lbl_imputacion
        '
        Me.lbl_imputacion.AutoSize = True
        Me.lbl_imputacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_imputacion.ForeColor = System.Drawing.Color.Red
        Me.lbl_imputacion.Location = New System.Drawing.Point(393, 118)
        Me.lbl_imputacion.Name = "lbl_imputacion"
        Me.lbl_imputacion.Size = New System.Drawing.Size(0, 16)
        Me.lbl_imputacion.TabIndex = 52
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(630, 20)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(30, 20)
        Me.txt_estado_form.TabIndex = 51
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.Enabled = False
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_aceptar.Location = New System.Drawing.Point(405, 197)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(61, 54)
        Me.cmd_aceptar.TabIndex = 7
        Me.cmd_aceptar.Text = "Aceptar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'grupo
        '
        Me.grupo.Controls.Add(Me.opt_salida)
        Me.grupo.Controls.Add(Me.opt_entrada)
        Me.grupo.Location = New System.Drawing.Point(186, 198)
        Me.grupo.Name = "grupo"
        Me.grupo.Size = New System.Drawing.Size(193, 47)
        Me.grupo.TabIndex = 6
        Me.grupo.TabStop = False
        '
        'opt_salida
        '
        Me.opt_salida.AutoSize = True
        Me.opt_salida.Location = New System.Drawing.Point(127, 19)
        Me.opt_salida.Name = "opt_salida"
        Me.opt_salida.Size = New System.Drawing.Size(54, 17)
        Me.opt_salida.TabIndex = 1
        Me.opt_salida.Text = "Salida"
        Me.opt_salida.UseVisualStyleBackColor = True
        '
        'opt_entrada
        '
        Me.opt_entrada.AutoSize = True
        Me.opt_entrada.Checked = True
        Me.opt_entrada.Location = New System.Drawing.Point(16, 19)
        Me.opt_entrada.Name = "opt_entrada"
        Me.opt_entrada.Size = New System.Drawing.Size(62, 17)
        Me.opt_entrada.TabIndex = 0
        Me.opt_entrada.TabStop = True
        Me.opt_entrada.Text = "Entrada"
        Me.opt_entrada.UseVisualStyleBackColor = True
        '
        'txt_importe
        '
        Me.txt_importe.Location = New System.Drawing.Point(187, 177)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(191, 20)
        Me.txt_importe.TabIndex = 5
        Me.txt_importe.Text = "0.00"
        Me.txt_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dt_fec_acredit
        '
        Me.dt_fec_acredit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_acredit.Location = New System.Drawing.Point(187, 146)
        Me.dt_fec_acredit.Name = "dt_fec_acredit"
        Me.dt_fec_acredit.Size = New System.Drawing.Size(192, 20)
        Me.dt_fec_acredit.TabIndex = 4
        '
        'txt_num_comprobante
        '
        Me.txt_num_comprobante.Location = New System.Drawing.Point(188, 85)
        Me.txt_num_comprobante.Name = "txt_num_comprobante"
        Me.txt_num_comprobante.Size = New System.Drawing.Size(191, 20)
        Me.txt_num_comprobante.TabIndex = 2
        Me.txt_num_comprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_detalle
        '
        Me.txt_detalle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_detalle.Location = New System.Drawing.Point(188, 48)
        Me.txt_detalle.MaxLength = 149
        Me.txt_detalle.Multiline = True
        Me.txt_detalle.Name = "txt_detalle"
        Me.txt_detalle.Size = New System.Drawing.Size(536, 27)
        Me.txt_detalle.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(60, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tipo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(60, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Importe:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(60, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Fecha Acreditacion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(60, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Imputacion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nº comprobante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Detalle:"
        '
        'cmb_movimiento
        '
        Me.cmb_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_movimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_movimiento.FormattingEnabled = True
        Me.cmb_movimiento.Location = New System.Drawing.Point(187, 17)
        Me.cmb_movimiento.Name = "cmb_movimiento"
        Me.cmb_movimiento.Size = New System.Drawing.Size(400, 23)
        Me.cmb_movimiento.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tipo Moviminiento:"
        '
        'Form_muestra_planilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_muestra_planilla"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOVIMIENTOS PLANILLA"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grupo.ResumeLayout(False)
        Me.grupo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_detalle As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grupo As System.Windows.Forms.GroupBox
    Friend WithEvents opt_salida As System.Windows.Forms.RadioButton
    Friend WithEvents opt_entrada As System.Windows.Forms.RadioButton
    Friend WithEvents txt_importe As System.Windows.Forms.TextBox
    Friend WithEvents dt_fec_acredit As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_num_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents lbl_imputacion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Tool_eminina_item As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_eminima_mov As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_imprime As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_exporta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txt_numero_planilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_planilla As System.Windows.Forms.TextBox
    Friend WithEvents cmd_guarda_mov As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_inputacion As mitextbox1.texto_solonum
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
