<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_muestra_factura
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_muestra_factura))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txt_comentario = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dt_fec = New System.Windows.Forms.DateTimePicker
        Me.txt_año = New System.Windows.Forms.TextBox
        Me.txt_mes = New System.Windows.Forms.TextBox
        Me.txt_verifica_anular_borrar = New System.Windows.Forms.TextBox
        Me.txt_estado_fact = New System.Windows.Forms.TextBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_prefijo = New System.Windows.Forms.TextBox
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tool_imprime = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.tol_forma_cobro = New System.Windows.Forms.ToolStripButton
        Me.tol_anula = New System.Windows.Forms.ToolStripButton
        Me.tol_borra = New System.Windows.Forms.ToolStripButton
        Me.Tool_modifica_fec = New System.Windows.Forms.ToolStripButton
        Me.Tool_comentario = New System.Windows.Forms.ToolStripButton
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.group_total_fact = New System.Windows.Forms.GroupBox
        Me.txt_total_grilla = New System.Windows.Forms.TextBox
        Me.txt_imp_interno_grilla = New System.Windows.Forms.TextBox
        Me.txt_no_inscripto = New System.Windows.Forms.TextBox
        Me.txt_inscripto = New System.Windows.Forms.TextBox
        Me.txt_exento = New System.Windows.Forms.TextBox
        Me.txt_gravado = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.lbl_imp_int = New System.Windows.Forms.Label
        Me.lbl_iva_nins = New System.Windows.Forms.Label
        Me.lbl_iva_ins = New System.Windows.Forms.Label
        Me.lbl_exento = New System.Windows.Forms.Label
        Me.lbl_sub_total = New System.Windows.Forms.Label
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.txt_codigo_cli = New System.Windows.Forms.TextBox
        Me.txt_talon = New System.Windows.Forms.TextBox
        Me.txt_f_pago = New System.Windows.Forms.TextBox
        Me.txt_comprobante = New System.Windows.Forms.TextBox
        Me.txt_p_venta = New System.Windows.Forms.TextBox
        Me.txt_cae = New System.Windows.Forms.TextBox
        Me.txt_venc_cae = New System.Windows.Forms.TextBox
        Me.txt_tipo_iva = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.group_total_fact.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 130)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(793, 364)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        '
        'txt_comentario
        '
        Me.txt_comentario.BackColor = System.Drawing.Color.White
        Me.txt_comentario.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comentario.Location = New System.Drawing.Point(-1, 2)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ReadOnly = True
        Me.txt_comentario.Size = New System.Drawing.Size(793, 98)
        Me.txt_comentario.TabIndex = 100
        Me.txt_comentario.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dt_fec)
        Me.Panel1.Controls.Add(Me.txt_año)
        Me.Panel1.Controls.Add(Me.txt_mes)
        Me.Panel1.Controls.Add(Me.txt_verifica_anular_borrar)
        Me.Panel1.Controls.Add(Me.txt_estado_fact)
        Me.Panel1.Controls.Add(Me.txt_numero)
        Me.Panel1.Controls.Add(Me.txt_prefijo)
        Me.Panel1.Controls.Add(Me.txt_letra)
        Me.Panel1.Controls.Add(Me.txt_tipo)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(791, 31)
        Me.Panel1.TabIndex = 45
        '
        'dt_fec
        '
        Me.dt_fec.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec.Location = New System.Drawing.Point(607, 3)
        Me.dt_fec.Name = "dt_fec"
        Me.dt_fec.Size = New System.Drawing.Size(91, 20)
        Me.dt_fec.TabIndex = 9
        Me.dt_fec.Visible = False
        '
        'txt_año
        '
        Me.txt_año.Location = New System.Drawing.Point(536, 5)
        Me.txt_año.Name = "txt_año"
        Me.txt_año.Size = New System.Drawing.Size(53, 20)
        Me.txt_año.TabIndex = 8
        Me.txt_año.UseSystemPasswordChar = True
        Me.txt_año.Visible = False
        '
        'txt_mes
        '
        Me.txt_mes.Location = New System.Drawing.Point(477, 5)
        Me.txt_mes.Name = "txt_mes"
        Me.txt_mes.Size = New System.Drawing.Size(53, 20)
        Me.txt_mes.TabIndex = 7
        Me.txt_mes.UseSystemPasswordChar = True
        Me.txt_mes.Visible = False
        '
        'txt_verifica_anular_borrar
        '
        Me.txt_verifica_anular_borrar.Location = New System.Drawing.Point(736, 4)
        Me.txt_verifica_anular_borrar.Name = "txt_verifica_anular_borrar"
        Me.txt_verifica_anular_borrar.Size = New System.Drawing.Size(44, 20)
        Me.txt_verifica_anular_borrar.TabIndex = 6
        Me.txt_verifica_anular_borrar.Text = "0"
        Me.txt_verifica_anular_borrar.Visible = False
        '
        'txt_estado_fact
        '
        Me.txt_estado_fact.Location = New System.Drawing.Point(419, 5)
        Me.txt_estado_fact.Name = "txt_estado_fact"
        Me.txt_estado_fact.Size = New System.Drawing.Size(52, 20)
        Me.txt_estado_fact.TabIndex = 5
        Me.txt_estado_fact.Visible = False
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(370, 5)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(42, 20)
        Me.txt_numero.TabIndex = 4
        Me.txt_numero.Visible = False
        '
        'txt_prefijo
        '
        Me.txt_prefijo.Location = New System.Drawing.Point(320, 5)
        Me.txt_prefijo.Name = "txt_prefijo"
        Me.txt_prefijo.Size = New System.Drawing.Size(42, 20)
        Me.txt_prefijo.TabIndex = 3
        Me.txt_prefijo.Visible = False
        '
        'txt_letra
        '
        Me.txt_letra.Location = New System.Drawing.Point(272, 4)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(42, 20)
        Me.txt_letra.TabIndex = 2
        Me.txt_letra.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Location = New System.Drawing.Point(224, 4)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(42, 20)
        Me.txt_tipo.TabIndex = 1
        Me.txt_tipo.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tool_imprime, Me.ToolStripButton2, Me.tol_forma_cobro, Me.tol_anula, Me.tol_borra, Me.Tool_modifica_fec, Me.Tool_comentario})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(791, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tool_imprime
        '
        Me.tool_imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_imprime.Image = CType(resources.GetObject("tool_imprime.Image"), System.Drawing.Image)
        Me.tool_imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_imprime.Name = "tool_imprime"
        Me.tool_imprime.Size = New System.Drawing.Size(23, 22)
        Me.tool_imprime.Text = "imprimir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.pym.My.Resources.Resources.page_excel
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "exportar"
        '
        'tol_forma_cobro
        '
        Me.tol_forma_cobro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tol_forma_cobro.Image = CType(resources.GetObject("tol_forma_cobro.Image"), System.Drawing.Image)
        Me.tol_forma_cobro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tol_forma_cobro.Name = "tol_forma_cobro"
        Me.tol_forma_cobro.Size = New System.Drawing.Size(23, 22)
        Me.tol_forma_cobro.Text = "Cambiar forma cobro"
        '
        'tol_anula
        '
        Me.tol_anula.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tol_anula.Image = CType(resources.GetObject("tol_anula.Image"), System.Drawing.Image)
        Me.tol_anula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tol_anula.Name = "tol_anula"
        Me.tol_anula.Size = New System.Drawing.Size(23, 22)
        Me.tol_anula.Text = "Anular"
        '
        'tol_borra
        '
        Me.tol_borra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tol_borra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tol_borra.Image = CType(resources.GetObject("tol_borra.Image"), System.Drawing.Image)
        Me.tol_borra.ImageTransparentColor = System.Drawing.Color.Black
        Me.tol_borra.Name = "tol_borra"
        Me.tol_borra.Size = New System.Drawing.Size(23, 22)
        Me.tol_borra.Text = "Borrar"
        '
        'Tool_modifica_fec
        '
        Me.Tool_modifica_fec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_modifica_fec.Image = Global.pym.My.Resources.Resources.calendar1
        Me.Tool_modifica_fec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_modifica_fec.Name = "Tool_modifica_fec"
        Me.Tool_modifica_fec.Size = New System.Drawing.Size(23, 22)
        Me.Tool_modifica_fec.Text = "Modificar fecha"
        '
        'Tool_comentario
        '
        Me.Tool_comentario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_comentario.Image = Global.pym.My.Resources.Resources.page_edit
        Me.Tool_comentario.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_comentario.Name = "Tool_comentario"
        Me.Tool_comentario.Size = New System.Drawing.Size(23, 22)
        Me.Tool_comentario.Text = "Comentario"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(671, 9)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(100, 20)
        Me.txt_estado_form.TabIndex = 46
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'group_total_fact
        '
        Me.group_total_fact.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.group_total_fact.Controls.Add(Me.txt_total_grilla)
        Me.group_total_fact.Controls.Add(Me.txt_imp_interno_grilla)
        Me.group_total_fact.Controls.Add(Me.txt_no_inscripto)
        Me.group_total_fact.Controls.Add(Me.txt_inscripto)
        Me.group_total_fact.Controls.Add(Me.txt_exento)
        Me.group_total_fact.Controls.Add(Me.txt_gravado)
        Me.group_total_fact.Controls.Add(Me.Label19)
        Me.group_total_fact.Controls.Add(Me.lbl_imp_int)
        Me.group_total_fact.Controls.Add(Me.lbl_iva_nins)
        Me.group_total_fact.Controls.Add(Me.lbl_iva_ins)
        Me.group_total_fact.Controls.Add(Me.lbl_exento)
        Me.group_total_fact.Controls.Add(Me.lbl_sub_total)
        Me.group_total_fact.Location = New System.Drawing.Point(-1, 489)
        Me.group_total_fact.Name = "group_total_fact"
        Me.group_total_fact.Size = New System.Drawing.Size(793, 47)
        Me.group_total_fact.TabIndex = 47
        Me.group_total_fact.TabStop = False
        '
        'txt_total_grilla
        '
        Me.txt_total_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_total_grilla.BackColor = System.Drawing.Color.White
        Me.txt_total_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_grilla.ForeColor = System.Drawing.Color.Black
        Me.txt_total_grilla.Location = New System.Drawing.Point(633, 27)
        Me.txt_total_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_total_grilla.Name = "txt_total_grilla"
        Me.txt_total_grilla.ReadOnly = True
        Me.txt_total_grilla.Size = New System.Drawing.Size(160, 21)
        Me.txt_total_grilla.TabIndex = 56
        Me.txt_total_grilla.TabStop = False
        Me.txt_total_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_imp_interno_grilla
        '
        Me.txt_imp_interno_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_imp_interno_grilla.BackColor = System.Drawing.Color.White
        Me.txt_imp_interno_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_imp_interno_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_interno_grilla.ForeColor = System.Drawing.Color.Black
        Me.txt_imp_interno_grilla.Location = New System.Drawing.Point(507, 27)
        Me.txt_imp_interno_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_imp_interno_grilla.Name = "txt_imp_interno_grilla"
        Me.txt_imp_interno_grilla.ReadOnly = True
        Me.txt_imp_interno_grilla.Size = New System.Drawing.Size(141, 21)
        Me.txt_imp_interno_grilla.TabIndex = 55
        Me.txt_imp_interno_grilla.TabStop = False
        Me.txt_imp_interno_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_no_inscripto
        '
        Me.txt_no_inscripto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_no_inscripto.BackColor = System.Drawing.Color.White
        Me.txt_no_inscripto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_no_inscripto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_inscripto.ForeColor = System.Drawing.Color.Black
        Me.txt_no_inscripto.Location = New System.Drawing.Point(376, 27)
        Me.txt_no_inscripto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_no_inscripto.Name = "txt_no_inscripto"
        Me.txt_no_inscripto.ReadOnly = True
        Me.txt_no_inscripto.Size = New System.Drawing.Size(146, 21)
        Me.txt_no_inscripto.TabIndex = 54
        Me.txt_no_inscripto.TabStop = False
        Me.txt_no_inscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_inscripto
        '
        Me.txt_inscripto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_inscripto.BackColor = System.Drawing.Color.White
        Me.txt_inscripto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_inscripto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inscripto.ForeColor = System.Drawing.Color.Black
        Me.txt_inscripto.Location = New System.Drawing.Point(252, 27)
        Me.txt_inscripto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_inscripto.Name = "txt_inscripto"
        Me.txt_inscripto.ReadOnly = True
        Me.txt_inscripto.Size = New System.Drawing.Size(138, 21)
        Me.txt_inscripto.TabIndex = 53
        Me.txt_inscripto.TabStop = False
        Me.txt_inscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_exento
        '
        Me.txt_exento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_exento.BackColor = System.Drawing.Color.White
        Me.txt_exento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_exento.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exento.ForeColor = System.Drawing.Color.Black
        Me.txt_exento.Location = New System.Drawing.Point(127, 27)
        Me.txt_exento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_exento.Name = "txt_exento"
        Me.txt_exento.ReadOnly = True
        Me.txt_exento.Size = New System.Drawing.Size(140, 21)
        Me.txt_exento.TabIndex = 52
        Me.txt_exento.TabStop = False
        Me.txt_exento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_gravado
        '
        Me.txt_gravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_gravado.BackColor = System.Drawing.Color.White
        Me.txt_gravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gravado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gravado.ForeColor = System.Drawing.Color.Black
        Me.txt_gravado.Location = New System.Drawing.Point(0, 27)
        Me.txt_gravado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_gravado.Name = "txt_gravado"
        Me.txt_gravado.ReadOnly = True
        Me.txt_gravado.Size = New System.Drawing.Size(142, 21)
        Me.txt_gravado.TabIndex = 51
        Me.txt_gravado.TabStop = False
        Me.txt_gravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(633, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(160, 19)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_imp_int
        '
        Me.lbl_imp_int.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_imp_int.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_imp_int.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_imp_int.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_imp_int.Location = New System.Drawing.Point(507, 8)
        Me.lbl_imp_int.Name = "lbl_imp_int"
        Me.lbl_imp_int.Size = New System.Drawing.Size(141, 19)
        Me.lbl_imp_int.TabIndex = 49
        Me.lbl_imp_int.Text = "Imp. Interno"
        Me.lbl_imp_int.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_iva_nins
        '
        Me.lbl_iva_nins.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_iva_nins.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_iva_nins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_iva_nins.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_iva_nins.Location = New System.Drawing.Point(376, 8)
        Me.lbl_iva_nins.Name = "lbl_iva_nins"
        Me.lbl_iva_nins.Size = New System.Drawing.Size(146, 19)
        Me.lbl_iva_nins.TabIndex = 48
        Me.lbl_iva_nins.Text = "Iva 10.5%"
        Me.lbl_iva_nins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_iva_ins
        '
        Me.lbl_iva_ins.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_iva_ins.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_iva_ins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_iva_ins.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_iva_ins.Location = New System.Drawing.Point(252, 8)
        Me.lbl_iva_ins.Name = "lbl_iva_ins"
        Me.lbl_iva_ins.Size = New System.Drawing.Size(138, 19)
        Me.lbl_iva_ins.TabIndex = 47
        Me.lbl_iva_ins.Text = "Iva 21%"
        Me.lbl_iva_ins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_exento
        '
        Me.lbl_exento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_exento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_exento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_exento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_exento.Location = New System.Drawing.Point(127, 8)
        Me.lbl_exento.Name = "lbl_exento"
        Me.lbl_exento.Size = New System.Drawing.Size(140, 19)
        Me.lbl_exento.TabIndex = 46
        Me.lbl_exento.Text = "Exento"
        Me.lbl_exento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_sub_total
        '
        Me.lbl_sub_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_sub_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_sub_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_sub_total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sub_total.Location = New System.Drawing.Point(0, 8)
        Me.lbl_sub_total.Name = "lbl_sub_total"
        Me.lbl_sub_total.Size = New System.Drawing.Size(130, 19)
        Me.lbl_sub_total.TabIndex = 45
        Me.lbl_sub_total.Text = "Sub Total"
        Me.lbl_sub_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(606, 47)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(100, 20)
        Me.txt_nombre.TabIndex = 10
        Me.txt_nombre.Visible = False
        '
        'txt_codigo_cli
        '
        Me.txt_codigo_cli.Location = New System.Drawing.Point(500, 68)
        Me.txt_codigo_cli.Name = "txt_codigo_cli"
        Me.txt_codigo_cli.Size = New System.Drawing.Size(88, 20)
        Me.txt_codigo_cli.TabIndex = 48
        Me.txt_codigo_cli.Visible = False
        '
        'txt_talon
        '
        Me.txt_talon.Location = New System.Drawing.Point(418, 70)
        Me.txt_talon.Name = "txt_talon"
        Me.txt_talon.Size = New System.Drawing.Size(52, 20)
        Me.txt_talon.TabIndex = 49
        Me.txt_talon.Visible = False
        '
        'txt_f_pago
        '
        Me.txt_f_pago.Location = New System.Drawing.Point(632, 73)
        Me.txt_f_pago.Name = "txt_f_pago"
        Me.txt_f_pago.Size = New System.Drawing.Size(100, 20)
        Me.txt_f_pago.TabIndex = 50
        Me.txt_f_pago.Visible = False
        '
        'txt_comprobante
        '
        Me.txt_comprobante.Location = New System.Drawing.Point(48, 76)
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.Size = New System.Drawing.Size(100, 20)
        Me.txt_comprobante.TabIndex = 51
        Me.txt_comprobante.Visible = False
        '
        'txt_p_venta
        '
        Me.txt_p_venta.Location = New System.Drawing.Point(261, 68)
        Me.txt_p_venta.Name = "txt_p_venta"
        Me.txt_p_venta.Size = New System.Drawing.Size(100, 20)
        Me.txt_p_venta.TabIndex = 52
        Me.txt_p_venta.Visible = False
        '
        'txt_cae
        '
        Me.txt_cae.Location = New System.Drawing.Point(500, 42)
        Me.txt_cae.Name = "txt_cae"
        Me.txt_cae.Size = New System.Drawing.Size(70, 20)
        Me.txt_cae.TabIndex = 101
        Me.txt_cae.Visible = False
        '
        'txt_venc_cae
        '
        Me.txt_venc_cae.Location = New System.Drawing.Point(500, 16)
        Me.txt_venc_cae.Name = "txt_venc_cae"
        Me.txt_venc_cae.Size = New System.Drawing.Size(70, 20)
        Me.txt_venc_cae.TabIndex = 102
        Me.txt_venc_cae.Visible = False
        '
        'txt_tipo_iva
        '
        Me.txt_tipo_iva.Location = New System.Drawing.Point(261, 42)
        Me.txt_tipo_iva.Name = "txt_tipo_iva"
        Me.txt_tipo_iva.Size = New System.Drawing.Size(100, 20)
        Me.txt_tipo_iva.TabIndex = 103
        Me.txt_tipo_iva.Visible = False
        '
        'Form_muestra_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.txt_tipo_iva)
        Me.Controls.Add(Me.txt_venc_cae)
        Me.Controls.Add(Me.txt_cae)
        Me.Controls.Add(Me.txt_p_venta)
        Me.Controls.Add(Me.txt_comprobante)
        Me.Controls.Add(Me.txt_f_pago)
        Me.Controls.Add(Me.txt_talon)
        Me.Controls.Add(Me.txt_codigo_cli)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.group_total_fact)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.txt_comentario)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_muestra_factura"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobante"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.group_total_fact.ResumeLayout(False)
        Me.group_total_fact.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tool_imprime As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tol_forma_cobro As System.Windows.Forms.ToolStripButton
    Friend WithEvents tol_anula As System.Windows.Forms.ToolStripButton
    Friend WithEvents tol_borra As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents group_total_fact As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_imp_interno_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_no_inscripto As System.Windows.Forms.TextBox
    Friend WithEvents txt_inscripto As System.Windows.Forms.TextBox
    Friend WithEvents txt_exento As System.Windows.Forms.TextBox
    Friend WithEvents txt_gravado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lbl_imp_int As System.Windows.Forms.Label
    Friend WithEvents lbl_iva_nins As System.Windows.Forms.Label
    Friend WithEvents lbl_iva_ins As System.Windows.Forms.Label
    Friend WithEvents lbl_exento As System.Windows.Forms.Label
    Friend WithEvents lbl_sub_total As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_prefijo As System.Windows.Forms.TextBox
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_estado_fact As System.Windows.Forms.TextBox
    Friend WithEvents txt_verifica_anular_borrar As System.Windows.Forms.TextBox
    Friend WithEvents Tool_modifica_fec As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_año As System.Windows.Forms.TextBox
    Friend WithEvents txt_mes As System.Windows.Forms.TextBox
    Friend WithEvents dt_fec As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_cli As System.Windows.Forms.TextBox
    Friend WithEvents txt_talon As System.Windows.Forms.TextBox
    Friend WithEvents txt_f_pago As System.Windows.Forms.TextBox
    Friend WithEvents txt_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents Tool_comentario As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_p_venta As System.Windows.Forms.TextBox
    Friend WithEvents txt_cae As System.Windows.Forms.TextBox
    Friend WithEvents txt_venc_cae As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_iva As System.Windows.Forms.TextBox
End Class
