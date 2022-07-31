<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_tipo_iva
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_tipo_iva))
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_help = New System.Windows.Forms.Button
        Me.txt_interno = New System.Windows.Forms.TextBox
        Me.txt_codigo_iva = New mitextbox1.texto_solonum
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_cta_iva_cmp_nins = New text_solo_num.solo_numeros
        Me.txt_cta_iva_cmp_in = New text_solo_num.solo_numeros
        Me.txt_cta_iva_vta_nin = New text_solo_num.solo_numeros
        Me.txt_cta_iva_vta_in = New text_solo_num.solo_numeros
        Me.txt_iva_nins = New text_solo_num.solo_numeros
        Me.txt_iva_ins = New text_solo_num.solo_numeros
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.dt_fec_alta = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_cod_imp_interno = New mitextbox1.texto_solonum
        Me.txt_cod_interno1 = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_nombre_imp_int = New System.Windows.Forms.TextBox
        Me.txt_importe_imp = New text_solo_num.solo_numeros
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.cmb_estado_imp_int = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.dt_fec_alta_imp_int = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmd_acepta1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.opt_iva = New System.Windows.Forms.RadioButton
        Me.opt_imp_interno = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(640, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 60)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipoas de I.v.a"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(341, 479)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(117, 48)
        Me.cmd_actualizar.TabIndex = 11
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(658, 479)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(117, 48)
        Me.cmd_eliminar.TabIndex = 12
        Me.cmd_eliminar.Text = "Borrar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(565, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 61)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(789, 447)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(781, 421)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmd_help)
        Me.GroupBox1.Controls.Add(Me.txt_interno)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_iva)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(-6, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmd_help
        '
        Me.cmd_help.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_help.BackgroundImage = CType(resources.GetObject("cmd_help.BackgroundImage"), System.Drawing.Image)
        Me.cmd_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_help.FlatAppearance.BorderSize = 0
        Me.cmd_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_help.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_help.Location = New System.Drawing.Point(751, 15)
        Me.cmd_help.Name = "cmd_help"
        Me.cmd_help.Size = New System.Drawing.Size(16, 18)
        Me.cmd_help.TabIndex = 46
        Me.cmd_help.TabStop = False
        Me.ToolTip1.SetToolTip(Me.cmd_help, "AYUDA")
        Me.cmd_help.UseVisualStyleBackColor = True
        '
        'txt_interno
        '
        Me.txt_interno.Location = New System.Drawing.Point(383, 16)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(100, 20)
        Me.txt_interno.TabIndex = 2
        Me.txt_interno.Visible = False
        '
        'txt_codigo_iva
        '
        Me.txt_codigo_iva.Location = New System.Drawing.Point(274, 16)
        Me.txt_codigo_iva.Name = "txt_codigo_iva"
        Me.txt_codigo_iva.Size = New System.Drawing.Size(100, 20)
        Me.txt_codigo_iva.TabIndex = 0
        Me.txt_codigo_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Codigo I.V.A"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Silver
        Me.Label13.Location = New System.Drawing.Point(5, 315)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(771, 5)
        Me.Label13.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.txt_cta_iva_cmp_nins)
        Me.GroupBox2.Controls.Add(Me.txt_cta_iva_cmp_in)
        Me.GroupBox2.Controls.Add(Me.txt_cta_iva_vta_nin)
        Me.GroupBox2.Controls.Add(Me.txt_cta_iva_vta_in)
        Me.GroupBox2.Controls.Add(Me.txt_iva_nins)
        Me.GroupBox2.Controls.Add(Me.txt_iva_ins)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.cmb_estado)
        Me.GroupBox2.Controls.Add(Me.dt_fec_alta)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(789, 366)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(380, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 18)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(380, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 18)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "%"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Location = New System.Drawing.Point(274, 22)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(251, 21)
        Me.txt_descripcion.TabIndex = 1
        '
        'txt_cta_iva_cmp_nins
        '
        Me.txt_cta_iva_cmp_nins.Location = New System.Drawing.Point(274, 217)
        Me.txt_cta_iva_cmp_nins.Name = "txt_cta_iva_cmp_nins"
        Me.txt_cta_iva_cmp_nins.Size = New System.Drawing.Size(100, 21)
        Me.txt_cta_iva_cmp_nins.TabIndex = 7
        Me.txt_cta_iva_cmp_nins.Text = "0"
        Me.txt_cta_iva_cmp_nins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cta_iva_cmp_in
        '
        Me.txt_cta_iva_cmp_in.Location = New System.Drawing.Point(274, 179)
        Me.txt_cta_iva_cmp_in.Name = "txt_cta_iva_cmp_in"
        Me.txt_cta_iva_cmp_in.Size = New System.Drawing.Size(100, 21)
        Me.txt_cta_iva_cmp_in.TabIndex = 6
        Me.txt_cta_iva_cmp_in.Text = "0"
        Me.txt_cta_iva_cmp_in.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cta_iva_vta_nin
        '
        Me.txt_cta_iva_vta_nin.Location = New System.Drawing.Point(274, 131)
        Me.txt_cta_iva_vta_nin.Name = "txt_cta_iva_vta_nin"
        Me.txt_cta_iva_vta_nin.Size = New System.Drawing.Size(100, 21)
        Me.txt_cta_iva_vta_nin.TabIndex = 5
        Me.txt_cta_iva_vta_nin.Text = "0"
        Me.txt_cta_iva_vta_nin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cta_iva_vta_in
        '
        Me.txt_cta_iva_vta_in.Location = New System.Drawing.Point(274, 103)
        Me.txt_cta_iva_vta_in.Name = "txt_cta_iva_vta_in"
        Me.txt_cta_iva_vta_in.Size = New System.Drawing.Size(100, 21)
        Me.txt_cta_iva_vta_in.TabIndex = 4
        Me.txt_cta_iva_vta_in.Text = "0"
        Me.txt_cta_iva_vta_in.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_nins
        '
        Me.txt_iva_nins.Location = New System.Drawing.Point(274, 76)
        Me.txt_iva_nins.Name = "txt_iva_nins"
        Me.txt_iva_nins.Size = New System.Drawing.Size(100, 21)
        Me.txt_iva_nins.TabIndex = 3
        Me.txt_iva_nins.Text = "0"
        Me.txt_iva_nins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_ins
        '
        Me.txt_iva_ins.Location = New System.Drawing.Point(274, 49)
        Me.txt_iva_ins.Name = "txt_iva_ins"
        Me.txt_iva_ins.Size = New System.Drawing.Size(100, 21)
        Me.txt_iva_ins.TabIndex = 2
        Me.txt_iva_ins.Text = "0"
        Me.txt_iva_ins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox1.Location = New System.Drawing.Point(222, 308)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(33, 25)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_estado
        '
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"Activo", "Baja"})
        Me.cmb_estado.Location = New System.Drawing.Point(274, 308)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(100, 24)
        Me.cmb_estado.TabIndex = 9
        '
        'dt_fec_alta
        '
        Me.dt_fec_alta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_alta.Location = New System.Drawing.Point(274, 280)
        Me.dt_fec_alta.Name = "dt_fec_alta"
        Me.dt_fec_alta.Size = New System.Drawing.Size(100, 21)
        Me.dt_fec_alta.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(55, 318)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 16)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Estado"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(55, 285)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Fecha Alta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(55, 219)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(186, 16)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Cta I.V.A No Inscripto compras"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(55, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Cta I.V.A Inscripto Compras"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(6, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(770, 5)
        Me.Label9.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(55, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(159, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Cta I.V.A No Inscripto vtas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(55, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Cta I.V.A Inscripto vtas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(55, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "I.V.A No Inscripto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(55, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "I.V.A Inscripto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(55, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Descripcion"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(781, 421)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.txt_cod_imp_interno)
        Me.GroupBox5.Controls.Add(Me.txt_cod_interno1)
        Me.GroupBox5.Location = New System.Drawing.Point(-4, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(789, 75)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(151, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(134, 16)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Codigo Imp. Interno"
        '
        'txt_cod_imp_interno
        '
        Me.txt_cod_imp_interno.Location = New System.Drawing.Point(313, 30)
        Me.txt_cod_imp_interno.Name = "txt_cod_imp_interno"
        Me.txt_cod_imp_interno.Size = New System.Drawing.Size(100, 20)
        Me.txt_cod_imp_interno.TabIndex = 0
        Me.txt_cod_imp_interno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_interno1
        '
        Me.txt_cod_interno1.Location = New System.Drawing.Point(445, 31)
        Me.txt_cod_interno1.Name = "txt_cod_interno1"
        Me.txt_cod_interno1.Size = New System.Drawing.Size(100, 20)
        Me.txt_cod_interno1.TabIndex = 21
        Me.txt_cod_interno1.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txt_nombre_imp_int)
        Me.GroupBox4.Controls.Add(Me.txt_importe_imp)
        Me.GroupBox4.Controls.Add(Me.TextBox3)
        Me.GroupBox4.Controls.Add(Me.cmb_estado_imp_int)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.dt_fec_alta_imp_int)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Location = New System.Drawing.Point(-1, 96)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(786, 326)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(295, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(15, 16)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "$"
        '
        'txt_nombre_imp_int
        '
        Me.txt_nombre_imp_int.Location = New System.Drawing.Point(310, 32)
        Me.txt_nombre_imp_int.Name = "txt_nombre_imp_int"
        Me.txt_nombre_imp_int.Size = New System.Drawing.Size(251, 20)
        Me.txt_nombre_imp_int.TabIndex = 1
        '
        'txt_importe_imp
        '
        Me.txt_importe_imp.Location = New System.Drawing.Point(310, 90)
        Me.txt_importe_imp.Name = "txt_importe_imp"
        Me.txt_importe_imp.Size = New System.Drawing.Size(70, 20)
        Me.txt_importe_imp.TabIndex = 2
        Me.txt_importe_imp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox3.Location = New System.Drawing.Point(310, 220)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(33, 25)
        Me.TextBox3.TabIndex = 27
        Me.TextBox3.TabStop = False
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_estado_imp_int
        '
        Me.cmb_estado_imp_int.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado_imp_int.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.cmb_estado_imp_int.FormattingEnabled = True
        Me.cmb_estado_imp_int.Items.AddRange(New Object() {"Activo", "Baja"})
        Me.cmb_estado_imp_int.Location = New System.Drawing.Point(368, 220)
        Me.cmb_estado_imp_int.Name = "cmb_estado_imp_int"
        Me.cmb_estado_imp_int.Size = New System.Drawing.Size(100, 24)
        Me.cmb_estado_imp_int.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(148, 224)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 16)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Estado"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(148, 146)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 16)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Fecha Alta"
        '
        'dt_fec_alta_imp_int
        '
        Me.dt_fec_alta_imp_int.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_alta_imp_int.Location = New System.Drawing.Point(310, 146)
        Me.dt_fec_alta_imp_int.Name = "dt_fec_alta_imp_int"
        Me.dt_fec_alta_imp_int.Size = New System.Drawing.Size(100, 20)
        Me.dt_fec_alta_imp_int.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(148, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 16)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Importe"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(148, 36)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 16)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Descripcion"
        '
        'cmd_acepta1
        '
        Me.cmd_acepta1.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta1.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta1.Location = New System.Drawing.Point(14, 479)
        Me.cmd_acepta1.Name = "cmd_acepta1"
        Me.cmd_acepta1.Size = New System.Drawing.Size(117, 48)
        Me.cmd_acepta1.TabIndex = 10
        Me.cmd_acepta1.Text = "Guardar"
        Me.cmd_acepta1.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.opt_iva)
        Me.GroupBox3.Controls.Add(Me.opt_imp_interno)
        Me.GroupBox3.Location = New System.Drawing.Point(178, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 44)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'opt_iva
        '
        Me.opt_iva.AutoSize = True
        Me.opt_iva.Location = New System.Drawing.Point(12, 17)
        Me.opt_iva.Name = "opt_iva"
        Me.opt_iva.Size = New System.Drawing.Size(69, 17)
        Me.opt_iva.TabIndex = 0
        Me.opt_iva.TabStop = True
        Me.opt_iva.Text = "Tipo i.v.a"
        Me.opt_iva.UseVisualStyleBackColor = True
        '
        'opt_imp_interno
        '
        Me.opt_imp_interno.AutoSize = True
        Me.opt_imp_interno.Location = New System.Drawing.Point(126, 17)
        Me.opt_imp_interno.Name = "opt_imp_interno"
        Me.opt_imp_interno.Size = New System.Drawing.Size(81, 17)
        Me.opt_imp_interno.TabIndex = 1
        Me.opt_imp_interno.TabStop = True
        Me.opt_imp_interno.Text = "Imp. Interno"
        Me.opt_imp_interno.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(573, 60)
        Me.Label1.TabIndex = 2
        '
        'form_tipo_iva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmd_acepta1)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.cmd_actualizar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "form_tipo_iva"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipos Iva e Impuestos Internos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_interno As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_iva As mitextbox1.texto_solonum
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_iva_cmp_nins As text_solo_num.solo_numeros
    Friend WithEvents txt_cta_iva_cmp_in As text_solo_num.solo_numeros
    Friend WithEvents txt_cta_iva_vta_nin As text_solo_num.solo_numeros
    Friend WithEvents txt_cta_iva_vta_in As text_solo_num.solo_numeros
    Friend WithEvents txt_iva_nins As text_solo_num.solo_numeros
    Friend WithEvents txt_iva_ins As text_solo_num.solo_numeros
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents dt_fec_alta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmd_acepta1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_imp_interno As System.Windows.Forms.RadioButton
    Friend WithEvents opt_iva As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_imp_interno As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_interno1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_imp_int As System.Windows.Forms.TextBox
    Friend WithEvents txt_importe_imp As text_solo_num.solo_numeros
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_estado_imp_int As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_alta_imp_int As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmd_help As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
