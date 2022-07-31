<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_repcta_cte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_repcta_cte))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmd_conciliador = New System.Windows.Forms.Button
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_convinado = New System.Windows.Forms.CheckBox
        Me.chk_historico = New System.Windows.Forms.CheckBox
        Me.Check_talonario = New System.Windows.Forms.CheckBox
        Me.dt_fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.cmb_descripcion = New System.Windows.Forms.ComboBox
        Me.lbl_tipo_filtro = New System.Windows.Forms.Label
        Me.dt_fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.txt_hasta = New System.Windows.Forms.TextBox
        Me.cmb_filtro = New System.Windows.Forms.ComboBox
        Me.cmb_ordenacion = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmb_zona = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmb_descripcion1 = New System.Windows.Forms.ComboBox
        Me.lbl_descripcion1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.cmb_tipo1 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmb_descipcion2 = New System.Windows.Forms.ComboBox
        Me.lbl_descripcion2 = New System.Windows.Forms.Label
        Me.cmb_tipo2 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cmd_conciliador)
        Me.Panel1.Controls.Add(Me.cmd_cancelar)
        Me.Panel1.Controls.Add(Me.cmd_aceptar)
        Me.Panel1.Location = New System.Drawing.Point(7, 439)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 86)
        Me.Panel1.TabIndex = 24
        '
        'cmd_conciliador
        '
        Me.cmd_conciliador.BackColor = System.Drawing.Color.Black
        Me.cmd_conciliador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_conciliador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_conciliador.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_conciliador.Location = New System.Drawing.Point(302, 19)
        Me.cmd_conciliador.Name = "cmd_conciliador"
        Me.cmd_conciliador.Size = New System.Drawing.Size(127, 52)
        Me.cmd_conciliador.TabIndex = 17
        Me.cmd_conciliador.Text = "conciliador"
        Me.cmd_conciliador.UseVisualStyleBackColor = False
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.BackColor = System.Drawing.Color.Black
        Me.cmd_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancelar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancelar.Location = New System.Drawing.Point(624, 19)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(127, 52)
        Me.cmd_cancelar.TabIndex = 16
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.UseVisualStyleBackColor = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(15, 19)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(127, 52)
        Me.cmd_aceptar.TabIndex = 15
        Me.cmd_aceptar.Text = "Aceptar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(550, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 68)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(642, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 68)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "REPORTE CTA CTE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(-3, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(786, 387)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(778, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cta cte Ventas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.chk_convinado)
        Me.GroupBox1.Controls.Add(Me.chk_historico)
        Me.GroupBox1.Controls.Add(Me.Check_talonario)
        Me.GroupBox1.Controls.Add(Me.dt_fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.cmb_descripcion)
        Me.GroupBox1.Controls.Add(Me.lbl_tipo_filtro)
        Me.GroupBox1.Controls.Add(Me.dt_fecha_desde)
        Me.GroupBox1.Controls.Add(Me.txt_hasta)
        Me.GroupBox1.Controls.Add(Me.cmb_filtro)
        Me.GroupBox1.Controls.Add(Me.cmb_ordenacion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(771, 359)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'chk_convinado
        '
        Me.chk_convinado.AutoSize = True
        Me.chk_convinado.Location = New System.Drawing.Point(471, 329)
        Me.chk_convinado.Name = "chk_convinado"
        Me.chk_convinado.Size = New System.Drawing.Size(77, 17)
        Me.chk_convinado.TabIndex = 22
        Me.chk_convinado.Text = "Convinado"
        Me.chk_convinado.UseVisualStyleBackColor = True
        '
        'chk_historico
        '
        Me.chk_historico.AutoSize = True
        Me.chk_historico.Location = New System.Drawing.Point(304, 329)
        Me.chk_historico.Name = "chk_historico"
        Me.chk_historico.Size = New System.Drawing.Size(106, 17)
        Me.chk_historico.TabIndex = 21
        Me.chk_historico.Text = "Muestra historico"
        Me.chk_historico.UseVisualStyleBackColor = True
        '
        'Check_talonario
        '
        Me.Check_talonario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Check_talonario.AutoSize = True
        Me.Check_talonario.BackColor = System.Drawing.Color.Black
        Me.Check_talonario.Location = New System.Drawing.Point(180, 329)
        Me.Check_talonario.Name = "Check_talonario"
        Me.Check_talonario.Size = New System.Drawing.Size(29, 17)
        Me.Check_talonario.TabIndex = 20
        Me.Check_talonario.Tag = " "
        Me.Check_talonario.Text = " "
        Me.Check_talonario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check_talonario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Check_talonario.UseVisualStyleBackColor = False
        '
        'dt_fecha_hasta
        '
        Me.dt_fecha_hasta.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fecha_hasta.Location = New System.Drawing.Point(180, 143)
        Me.dt_fecha_hasta.Name = "dt_fecha_hasta"
        Me.dt_fecha_hasta.Size = New System.Drawing.Size(230, 20)
        Me.dt_fecha_hasta.TabIndex = 11
        '
        'cmb_descripcion
        '
        Me.cmb_descripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_descripcion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_descripcion.FormattingEnabled = True
        Me.cmb_descripcion.Items.AddRange(New Object() {"Total", "Cliente", "Vendedor", "Provincia"})
        Me.cmb_descripcion.Location = New System.Drawing.Point(180, 284)
        Me.cmb_descripcion.Name = "cmb_descripcion"
        Me.cmb_descripcion.Size = New System.Drawing.Size(230, 23)
        Me.cmb_descripcion.TabIndex = 14
        Me.cmb_descripcion.Visible = False
        '
        'lbl_tipo_filtro
        '
        Me.lbl_tipo_filtro.AutoSize = True
        Me.lbl_tipo_filtro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_filtro.Location = New System.Drawing.Point(55, 287)
        Me.lbl_tipo_filtro.Name = "lbl_tipo_filtro"
        Me.lbl_tipo_filtro.Size = New System.Drawing.Size(76, 15)
        Me.lbl_tipo_filtro.TabIndex = 19
        Me.lbl_tipo_filtro.Text = "Descripcion:"
        Me.lbl_tipo_filtro.Visible = False
        '
        'dt_fecha_desde
        '
        Me.dt_fecha_desde.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fecha_desde.Location = New System.Drawing.Point(180, 94)
        Me.dt_fecha_desde.Name = "dt_fecha_desde"
        Me.dt_fecha_desde.Size = New System.Drawing.Size(230, 20)
        Me.dt_fecha_desde.TabIndex = 10
        '
        'txt_hasta
        '
        Me.txt_hasta.BackColor = System.Drawing.Color.White
        Me.txt_hasta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hasta.Location = New System.Drawing.Point(180, 192)
        Me.txt_hasta.Name = "txt_hasta"
        Me.txt_hasta.ReadOnly = True
        Me.txt_hasta.Size = New System.Drawing.Size(230, 21)
        Me.txt_hasta.TabIndex = 12
        Me.txt_hasta.Text = "ZZZ"
        '
        'cmb_filtro
        '
        Me.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_filtro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_filtro.FormattingEnabled = True
        Me.cmb_filtro.Items.AddRange(New Object() {"Total", "Cliente", "Vendedor", "Provincia", "Zona"})
        Me.cmb_filtro.Location = New System.Drawing.Point(180, 234)
        Me.cmb_filtro.Name = "cmb_filtro"
        Me.cmb_filtro.Size = New System.Drawing.Size(230, 23)
        Me.cmb_filtro.TabIndex = 13
        '
        'cmb_ordenacion
        '
        Me.cmb_ordenacion.BackColor = System.Drawing.Color.White
        Me.cmb_ordenacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ordenacion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ordenacion.FormattingEnabled = True
        Me.cmb_ordenacion.Items.AddRange(New Object() {"Alfabeticamente", "Codigo"})
        Me.cmb_ordenacion.Location = New System.Drawing.Point(180, 43)
        Me.cmb_ordenacion.Name = "cmb_ordenacion"
        Me.cmb_ordenacion.Size = New System.Drawing.Size(230, 23)
        Me.cmb_ordenacion.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(60, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Filtro:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(60, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fecha Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Oredenado Por:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.cmb_zona)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.cmb_descripcion1)
        Me.TabPage2.Controls.Add(Me.lbl_descripcion1)
        Me.TabPage2.Controls.Add(Me.DateTimePicker1)
        Me.TabPage2.Controls.Add(Me.cmb_tipo1)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(778, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Saldos Vencidos Ventas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmb_zona
        '
        Me.cmb_zona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_zona.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_zona.FormattingEnabled = True
        Me.cmb_zona.Items.AddRange(New Object() {"Zona"})
        Me.cmb_zona.Location = New System.Drawing.Point(200, 215)
        Me.cmb_zona.Name = "cmb_zona"
        Me.cmb_zona.Size = New System.Drawing.Size(230, 23)
        Me.cmb_zona.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(80, 218)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 15)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Zona:"
        Me.Label16.Visible = False
        '
        'cmb_descripcion1
        '
        Me.cmb_descripcion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_descripcion1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_descripcion1.FormattingEnabled = True
        Me.cmb_descripcion1.Location = New System.Drawing.Point(201, 151)
        Me.cmb_descripcion1.Name = "cmb_descripcion1"
        Me.cmb_descripcion1.Size = New System.Drawing.Size(230, 23)
        Me.cmb_descripcion1.TabIndex = 23
        Me.cmb_descripcion1.Visible = False
        '
        'lbl_descripcion1
        '
        Me.lbl_descripcion1.AutoSize = True
        Me.lbl_descripcion1.BackColor = System.Drawing.Color.White
        Me.lbl_descripcion1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descripcion1.Location = New System.Drawing.Point(81, 154)
        Me.lbl_descripcion1.Name = "lbl_descripcion1"
        Me.lbl_descripcion1.Size = New System.Drawing.Size(76, 15)
        Me.lbl_descripcion1.TabIndex = 25
        Me.lbl_descripcion1.Text = "Descripcion:"
        Me.lbl_descripcion1.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(201, 43)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(89, 20)
        Me.DateTimePicker1.TabIndex = 21
        '
        'cmb_tipo1
        '
        Me.cmb_tipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipo1.FormattingEnabled = True
        Me.cmb_tipo1.Items.AddRange(New Object() {"Vendedor", "Total"})
        Me.cmb_tipo1.Location = New System.Drawing.Point(201, 91)
        Me.cmb_tipo1.Name = "cmb_tipo1"
        Me.cmb_tipo1.Size = New System.Drawing.Size(230, 23)
        Me.cmb_tipo1.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(81, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Filtro:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(81, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 15)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Fecha Desde:"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.DateTimePicker2)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.cmb_descipcion2)
        Me.TabPage3.Controls.Add(Me.lbl_descripcion2)
        Me.TabPage3.Controls.Add(Me.cmb_tipo2)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(778, 361)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Saldos Vencidos Compras"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(198, 45)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(89, 20)
        Me.DateTimePicker2.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(78, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Fecha Desde:"
        '
        'cmb_descipcion2
        '
        Me.cmb_descipcion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_descipcion2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_descipcion2.FormattingEnabled = True
        Me.cmb_descipcion2.Location = New System.Drawing.Point(198, 153)
        Me.cmb_descipcion2.Name = "cmb_descipcion2"
        Me.cmb_descipcion2.Size = New System.Drawing.Size(230, 23)
        Me.cmb_descipcion2.TabIndex = 31
        Me.cmb_descipcion2.Visible = False
        '
        'lbl_descripcion2
        '
        Me.lbl_descripcion2.AutoSize = True
        Me.lbl_descripcion2.BackColor = System.Drawing.Color.White
        Me.lbl_descripcion2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descripcion2.Location = New System.Drawing.Point(78, 156)
        Me.lbl_descripcion2.Name = "lbl_descripcion2"
        Me.lbl_descripcion2.Size = New System.Drawing.Size(76, 15)
        Me.lbl_descripcion2.TabIndex = 33
        Me.lbl_descripcion2.Text = "Descripcion:"
        Me.lbl_descripcion2.Visible = False
        '
        'cmb_tipo2
        '
        Me.cmb_tipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipo2.FormattingEnabled = True
        Me.cmb_tipo2.Items.AddRange(New Object() {"Proveedor", "Total"})
        Me.cmb_tipo2.Location = New System.Drawing.Point(198, 93)
        Me.cmb_tipo2.Name = "cmb_tipo2"
        Me.cmb_tipo2.Size = New System.Drawing.Size(230, 23)
        Me.cmb_tipo2.TabIndex = 30
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(78, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 15)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Filtro:"
        '
        'Form_repcta_cte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_repcta_cte"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE CUENTA CORRIENTE"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dt_fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_descripcion As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo_filtro As System.Windows.Forms.Label
    Friend WithEvents dt_fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_hasta As System.Windows.Forms.TextBox
    Friend WithEvents cmb_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_ordenacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmb_descripcion1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_descripcion1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_tipo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cmb_descipcion2 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_descripcion2 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmb_zona As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Check_talonario As System.Windows.Forms.CheckBox
    Friend WithEvents chk_historico As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_conciliador As System.Windows.Forms.Button
    Friend WithEvents chk_convinado As System.Windows.Forms.CheckBox
End Class
