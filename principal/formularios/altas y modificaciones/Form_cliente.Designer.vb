<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cliente
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cliente))
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.cmd_borrar = New System.Windows.Forms.Button
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txt_idcli = New mitextbox1.texto_solonum
        Me.txt_codpostal = New System.Windows.Forms.TextBox
        Me.txt_zona = New mitextbox1.texto_solonum
        Me.txt_provincia = New mitextbox1.texto_solonum
        Me.txt_localidad = New mitextbox1.texto_solonum
        Me.txt_sucursal = New mitextbox1.texto_solonum
        Me.txt_vendedor = New mitextbox1.texto_solonum
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txt_buscador = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.opt_gastosserv = New System.Windows.Forms.RadioButton
        Me.opt_furgon = New System.Windows.Forms.RadioButton
        Me.opt_proovedor = New System.Windows.Forms.RadioButton
        Me.opt_cliente = New System.Windows.Forms.RadioButton
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_interno = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.cmb_tipocliente = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl_zona = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lbl_localidad = New System.Windows.Forms.Label
        Me.lbl_provincia = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_mail = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_fax = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_iva = New System.Windows.Forms.MaskedTextBox
        Me.txt_ingbrutos = New System.Windows.Forms.MaskedTextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmb_iva = New System.Windows.Forms.ComboBox
        Me.lbl_vendedor = New System.Windows.Forms.Label
        Me.lbl_sucursal = New System.Windows.Forms.Label
        Me.cmb_rubro = New System.Windows.Forms.ComboBox
        Me.txt_observacion = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.dt_fecha = New System.Windows.Forms.DateTimePicker
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_muestraestado = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(1, 623)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(166, 58)
        Me.cmd_aceptar.TabIndex = 15
        Me.cmd_aceptar.Text = "Guardar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'cmd_borrar
        '
        Me.cmd_borrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_borrar.BackColor = System.Drawing.Color.Black
        Me.cmd_borrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_borrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_borrar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_borrar.Location = New System.Drawing.Point(847, 623)
        Me.cmd_borrar.Name = "cmd_borrar"
        Me.cmd_borrar.Size = New System.Drawing.Size(166, 58)
        Me.cmd_borrar.TabIndex = 14
        Me.cmd_borrar.Text = "Borrar"
        Me.cmd_borrar.UseVisualStyleBackColor = False
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(434, 623)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(166, 58)
        Me.cmd_actualizar.TabIndex = 13
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_estado_form.Location = New System.Drawing.Point(274, 5)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(40, 21)
        Me.txt_estado_form.TabIndex = 9
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.White
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(929, -2)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(84, 63)
        Me.Label34.TabIndex = 11
        Me.Label34.Text = "Clientes"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(838, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(95, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'txt_idcli
        '
        Me.txt_idcli.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_idcli.Location = New System.Drawing.Point(135, 5)
        Me.txt_idcli.Name = "txt_idcli"
        Me.txt_idcli.Size = New System.Drawing.Size(74, 21)
        Me.txt_idcli.TabIndex = 0
        Me.txt_idcli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txt_idcli, "F1 - Busqueda ")
        '
        'txt_codpostal
        '
        Me.txt_codpostal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codpostal.Location = New System.Drawing.Point(548, 86)
        Me.txt_codpostal.MaxLength = 4
        Me.txt_codpostal.Name = "txt_codpostal"
        Me.txt_codpostal.Size = New System.Drawing.Size(55, 21)
        Me.txt_codpostal.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txt_codpostal, "F1 - Busqueda")
        '
        'txt_zona
        '
        Me.txt_zona.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zona.Location = New System.Drawing.Point(135, 149)
        Me.txt_zona.Name = "txt_zona"
        Me.txt_zona.Size = New System.Drawing.Size(55, 21)
        Me.txt_zona.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.txt_zona, "F1 - Busqueda")
        '
        'txt_provincia
        '
        Me.txt_provincia.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_provincia.Location = New System.Drawing.Point(732, 83)
        Me.txt_provincia.Name = "txt_provincia"
        Me.txt_provincia.Size = New System.Drawing.Size(55, 21)
        Me.txt_provincia.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txt_provincia, "F1 - Busqueda")
        '
        'txt_localidad
        '
        Me.txt_localidad.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_localidad.Location = New System.Drawing.Point(135, 122)
        Me.txt_localidad.Name = "txt_localidad"
        Me.txt_localidad.Size = New System.Drawing.Size(55, 21)
        Me.txt_localidad.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txt_localidad, "F1 - Busqueda")
        '
        'txt_sucursal
        '
        Me.txt_sucursal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sucursal.Location = New System.Drawing.Point(732, 119)
        Me.txt_sucursal.Name = "txt_sucursal"
        Me.txt_sucursal.Size = New System.Drawing.Size(55, 21)
        Me.txt_sucursal.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txt_sucursal, "F1 - Busqueda")
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(135, 269)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(55, 21)
        Me.txt_vendedor.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.txt_vendedor, "F1 - Busqueda")
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1, 326)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1012, 296)
        Me.DataGridView1.TabIndex = 100
        Me.DataGridView1.TabStop = False
        '
        'txt_buscador
        '
        Me.txt_buscador.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_buscador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_buscador.Location = New System.Drawing.Point(794, 298)
        Me.txt_buscador.Name = "txt_buscador"
        Me.txt_buscador.Size = New System.Drawing.Size(213, 22)
        Me.txt_buscador.TabIndex = 58
        Me.txt_buscador.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(714, 302)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 15)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Buscador"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.opt_gastosserv)
        Me.GroupBox6.Controls.Add(Me.opt_furgon)
        Me.GroupBox6.Controls.Add(Me.opt_proovedor)
        Me.GroupBox6.Controls.Add(Me.opt_cliente)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(377, -5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(414, 30)
        Me.GroupBox6.TabIndex = 56
        Me.GroupBox6.TabStop = False
        '
        'opt_gastosserv
        '
        Me.opt_gastosserv.AutoSize = True
        Me.opt_gastosserv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_gastosserv.Location = New System.Drawing.Point(284, 7)
        Me.opt_gastosserv.Name = "opt_gastosserv"
        Me.opt_gastosserv.Size = New System.Drawing.Size(111, 18)
        Me.opt_gastosserv.TabIndex = 3
        Me.opt_gastosserv.Text = "Gastos y Servicio"
        Me.opt_gastosserv.UseVisualStyleBackColor = True
        '
        'opt_furgon
        '
        Me.opt_furgon.AutoSize = True
        Me.opt_furgon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_furgon.Location = New System.Drawing.Point(203, 8)
        Me.opt_furgon.Name = "opt_furgon"
        Me.opt_furgon.Size = New System.Drawing.Size(59, 18)
        Me.opt_furgon.TabIndex = 2
        Me.opt_furgon.Text = "Furgon"
        Me.opt_furgon.UseVisualStyleBackColor = True
        '
        'opt_proovedor
        '
        Me.opt_proovedor.AutoSize = True
        Me.opt_proovedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_proovedor.Location = New System.Drawing.Point(98, 8)
        Me.opt_proovedor.Name = "opt_proovedor"
        Me.opt_proovedor.Size = New System.Drawing.Size(75, 18)
        Me.opt_proovedor.TabIndex = 1
        Me.opt_proovedor.Text = "Proveedor"
        Me.opt_proovedor.UseVisualStyleBackColor = True
        '
        'opt_cliente
        '
        Me.opt_cliente.AutoSize = True
        Me.opt_cliente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_cliente.Location = New System.Drawing.Point(13, 8)
        Me.opt_cliente.Name = "opt_cliente"
        Me.opt_cliente.Size = New System.Drawing.Size(57, 18)
        Me.opt_cliente.TabIndex = 0
        Me.opt_cliente.Text = "Cliente"
        Me.opt_cliente.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(796, 33)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 19)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "*"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(796, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 19)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "*"
        '
        'txt_interno
        '
        Me.txt_interno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_interno.Location = New System.Drawing.Point(218, 5)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(50, 21)
        Me.txt_interno.TabIndex = 55
        Me.txt_interno.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo.ForeColor = System.Drawing.Color.Red
        Me.txt_tipo.Location = New System.Drawing.Point(135, 89)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(55, 21)
        Me.txt_tipo.TabIndex = 47
        Me.txt_tipo.TabStop = False
        Me.txt_tipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_tipocliente
        '
        Me.cmb_tipocliente.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipocliente.ForeColor = System.Drawing.Color.Red
        Me.cmb_tipocliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmb_tipocliente.Items.AddRange(New Object() {"Cliente", "Proveedor", "Gastos y Servicio", "Furgon"})
        Me.cmb_tipocliente.Location = New System.Drawing.Point(204, 87)
        Me.cmb_tipocliente.MaxDropDownItems = 3
        Me.cmb_tipocliente.Name = "cmb_tipocliente"
        Me.cmb_tipocliente.Size = New System.Drawing.Size(196, 23)
        Me.cmb_tipocliente.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "TIPO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(14, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 14)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "CODIGO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 14)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "DIRECCION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "NOMBRE"
        '
        'txt_direccion
        '
        Me.txt_direccion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.Location = New System.Drawing.Point(135, 59)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(652, 21)
        Me.txt_direccion.TabIndex = 2
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(135, 32)
        Me.txt_nombre.MaxLength = 119
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(652, 21)
        Me.txt_nombre.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(609, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(13, 16)
        Me.Label23.TabIndex = 71
        Me.Label23.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(422, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 14)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "CODIGO POSTAL"
        '
        'lbl_zona
        '
        Me.lbl_zona.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_zona.ForeColor = System.Drawing.Color.Red
        Me.lbl_zona.Location = New System.Drawing.Point(215, 143)
        Me.lbl_zona.Name = "lbl_zona"
        Me.lbl_zona.Size = New System.Drawing.Size(260, 25)
        Me.lbl_zona.TabIndex = 79
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(196, 151)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(13, 16)
        Me.Label36.TabIndex = 78
        Me.Label36.Text = "*"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(13, 149)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(37, 14)
        Me.Label35.TabIndex = 77
        Me.Label35.Text = "ZONA"
        '
        'lbl_localidad
        '
        Me.lbl_localidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localidad.ForeColor = System.Drawing.Color.Red
        Me.lbl_localidad.Location = New System.Drawing.Point(215, 118)
        Me.lbl_localidad.Name = "lbl_localidad"
        Me.lbl_localidad.Size = New System.Drawing.Size(260, 25)
        Me.lbl_localidad.TabIndex = 73
        '
        'lbl_provincia
        '
        Me.lbl_provincia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_provincia.ForeColor = System.Drawing.Color.Red
        Me.lbl_provincia.Location = New System.Drawing.Point(815, 82)
        Me.lbl_provincia.Name = "lbl_provincia"
        Me.lbl_provincia.Size = New System.Drawing.Size(187, 25)
        Me.lbl_provincia.TabIndex = 76
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(798, 85)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(13, 16)
        Me.Label32.TabIndex = 75
        Me.Label32.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "LOCALIDAD"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(375, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "MAIL"
        '
        'txt_mail
        '
        Me.txt_mail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mail.Location = New System.Drawing.Point(458, 202)
        Me.txt_mail.MaxLength = 25
        Me.txt_mail.Name = "txt_mail"
        Me.txt_mail.Size = New System.Drawing.Size(316, 21)
        Me.txt_mail.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(706, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 14)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "CELULAR"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(196, 124)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(13, 16)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "*"
        '
        'txt_fax
        '
        Me.txt_fax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fax.Location = New System.Drawing.Point(794, 171)
        Me.txt_fax.Name = "txt_fax"
        Me.txt_fax.Size = New System.Drawing.Size(208, 21)
        Me.txt_fax.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(375, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "TELEFONO"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(643, 88)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 14)
        Me.Label31.TabIndex = 74
        Me.Label31.Text = "PROVINCIA"
        '
        'txt_telefono
        '
        Me.txt_telefono.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.Location = New System.Drawing.Point(458, 171)
        Me.txt_telefono.MaxLength = 17
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(208, 21)
        Me.txt_telefono.TabIndex = 10
        '
        'txt_iva
        '
        Me.txt_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.Location = New System.Drawing.Point(135, 208)
        Me.txt_iva.Mask = "00-00000000-0"
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.Size = New System.Drawing.Size(149, 21)
        Me.txt_iva.TabIndex = 12
        Me.txt_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ingbrutos
        '
        Me.txt_ingbrutos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ingbrutos.Location = New System.Drawing.Point(135, 238)
        Me.txt_ingbrutos.Mask = "00-00000000-0"
        Me.txt_ingbrutos.Name = "txt_ingbrutos"
        Me.txt_ingbrutos.Size = New System.Drawing.Size(149, 21)
        Me.txt_ingbrutos.TabIndex = 14
        Me.txt_ingbrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(275, 204)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(13, 16)
        Me.Label26.TabIndex = 87
        Me.Label26.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(294, 211)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(13, 16)
        Me.Label25.TabIndex = 86
        Me.Label25.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "ING. BRUTOS"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 14)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "CUIT"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(14, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 14)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "TIPO CLIENTE:"
        '
        'cmb_iva
        '
        Me.cmb_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_iva.FormattingEnabled = True
        Me.cmb_iva.Items.AddRange(New Object() {"Monotributo", "Responsable Inscripto", "Consumidor Final", "Exento", "No Inscripto", "No Categorizado"})
        Me.cmb_iva.Location = New System.Drawing.Point(135, 176)
        Me.cmb_iva.Name = "cmb_iva"
        Me.cmb_iva.Size = New System.Drawing.Size(219, 23)
        Me.cmb_iva.TabIndex = 9
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vendedor.ForeColor = System.Drawing.Color.Red
        Me.lbl_vendedor.Location = New System.Drawing.Point(217, 269)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(237, 21)
        Me.lbl_vendedor.TabIndex = 99
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sucursal.ForeColor = System.Drawing.Color.Red
        Me.lbl_sucursal.Location = New System.Drawing.Point(815, 113)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(177, 27)
        Me.lbl_sucursal.TabIndex = 100
        '
        'cmb_rubro
        '
        Me.cmb_rubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rubro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_rubro.FormattingEnabled = True
        Me.cmb_rubro.Items.AddRange(New Object() {"OTRO"})
        Me.cmb_rubro.Location = New System.Drawing.Point(458, 233)
        Me.cmb_rubro.Name = "cmb_rubro"
        Me.cmb_rubro.Size = New System.Drawing.Size(126, 23)
        Me.cmb_rubro.TabIndex = 15
        '
        'txt_observacion
        '
        Me.txt_observacion.AcceptsReturn = True
        Me.txt_observacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_observacion.Location = New System.Drawing.Point(135, 295)
        Me.txt_observacion.MaxLength = 50
        Me.txt_observacion.Multiline = True
        Me.txt_observacion.Name = "txt_observacion"
        Me.txt_observacion.Size = New System.Drawing.Size(573, 29)
        Me.txt_observacion.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(14, 271)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "VENDEDOR"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(13, 302)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 14)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "OBSERVACIONES"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(643, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 14)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "LISTA"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(799, 120)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(12, 15)
        Me.Label28.TabIndex = 97
        Me.Label28.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(375, 268)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 16)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "RUBRO"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(197, 274)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 15)
        Me.Label27.TabIndex = 96
        Me.Label27.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(1023, 624)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(13, 16)
        Me.Label30.TabIndex = 104
        Me.Label30.Text = "*"
        '
        'dt_fecha
        '
        Me.dt_fecha.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_fecha.Location = New System.Drawing.Point(696, 231)
        Me.dt_fecha.Name = "dt_fecha"
        Me.dt_fecha.Size = New System.Drawing.Size(125, 21)
        Me.dt_fecha.TabIndex = 105
        Me.dt_fecha.Value = New Date(2016, 8, 25, 0, 0, 0, 0)
        Me.dt_fecha.Visible = False
        '
        'cmb_estado
        '
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.cmb_estado.Location = New System.Drawing.Point(830, 258)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(90, 23)
        Me.cmb_estado.TabIndex = 101
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(714, 262)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 14)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "ESTADO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(603, 233)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 14)
        Me.Label22.TabIndex = 106
        Me.Label22.Text = "FECHA ALTA"
        Me.Label22.Visible = False
        '
        'txt_muestraestado
        '
        Me.txt_muestraestado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_muestraestado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_muestraestado.ForeColor = System.Drawing.Color.Red
        Me.txt_muestraestado.Location = New System.Drawing.Point(794, 259)
        Me.txt_muestraestado.Name = "txt_muestraestado"
        Me.txt_muestraestado.ReadOnly = True
        Me.txt_muestraestado.Size = New System.Drawing.Size(30, 22)
        Me.txt_muestraestado.TabIndex = 17
        Me.txt_muestraestado.TabStop = False
        Me.txt_muestraestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(375, 235)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 14)
        Me.Label19.TabIndex = 107
        Me.Label19.Text = "RUBRO"
        '
        'Form_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1014, 681)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.dt_fecha)
        Me.Controls.Add(Me.cmb_estado)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txt_muestraestado)
        Me.Controls.Add(Me.lbl_vendedor)
        Me.Controls.Add(Me.lbl_sucursal)
        Me.Controls.Add(Me.cmb_rubro)
        Me.Controls.Add(Me.txt_observacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_sucursal)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_vendedor)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txt_iva)
        Me.Controls.Add(Me.txt_ingbrutos)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmb_iva)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_zona)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txt_codpostal)
        Me.Controls.Add(Me.txt_zona)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.lbl_localidad)
        Me.Controls.Add(Me.lbl_provincia)
        Me.Controls.Add(Me.txt_provincia)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_mail)
        Me.Controls.Add(Me.txt_localidad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_fax)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.txt_buscador)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txt_interno)
        Me.Controls.Add(Me.txt_idcli)
        Me.Controls.Add(Me.txt_tipo)
        Me.Controls.Add(Me.cmb_tipocliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_aceptar)
        Me.Controls.Add(Me.cmd_actualizar)
        Me.Controls.Add(Me.cmd_borrar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_cliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Altas Clientes"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents cmd_borrar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_buscador As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_gastosserv As System.Windows.Forms.RadioButton
    Friend WithEvents opt_furgon As System.Windows.Forms.RadioButton
    Friend WithEvents opt_proovedor As System.Windows.Forms.RadioButton
    Friend WithEvents opt_cliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_interno As System.Windows.Forms.TextBox
    Friend WithEvents txt_idcli As mitextbox1.texto_solonum
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipocliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents lbl_zona As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txt_codpostal As System.Windows.Forms.TextBox
    Friend WithEvents txt_zona As mitextbox1.texto_solonum
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lbl_localidad As System.Windows.Forms.Label
    Public WithEvents lbl_provincia As System.Windows.Forms.Label
    Friend WithEvents txt_provincia As mitextbox1.texto_solonum
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_mail As System.Windows.Forms.TextBox
    Friend WithEvents txt_localidad As mitextbox1.texto_solonum
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_fax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_ingbrutos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_iva As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents cmb_rubro As System.Windows.Forms.ComboBox
    Friend WithEvents txt_observacion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_sucursal As mitextbox1.texto_solonum
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_vendedor As mitextbox1.texto_solonum
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents dt_fecha As System.Windows.Forms.DateTimePicker
    Public WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_muestraestado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
