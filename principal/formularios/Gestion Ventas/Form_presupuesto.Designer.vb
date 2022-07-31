<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_presupuesto
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Check_talonario = New System.Windows.Forms.CheckBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.txt_precio = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.txt_iva_insc = New System.Windows.Forms.TextBox
        Me.txt_sub_total = New System.Windows.Forms.TextBox
        Me.txt_estado_form = New mitextbox1.texto_solonum
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_validez = New mitextbox1.texto_solonum
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_desc_rcgo = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_des_rcgo = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.gropu2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.lbl_numero = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_telef = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRECIO1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_precio_siva = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gropu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(83, 15)
        Me.txt_codigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_codigo.MaxLength = 9
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(67, 21)
        Me.txt_codigo.TabIndex = 12
        Me.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.Color.White
        Me.txt_cliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_cliente.Location = New System.Drawing.Point(156, 14)
        Me.txt_cliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(304, 22)
        Me.txt_cliente.TabIndex = 13
        Me.txt_cliente.TabStop = False
        Me.txt_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cliente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_precio_siva)
        Me.GroupBox1.Controls.Add(Me.Check_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_iva)
        Me.GroupBox1.Controls.Add(Me.txt_precio)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_total)
        Me.GroupBox1.Controls.Add(Me.txt_iva_insc)
        Me.GroupBox1.Controls.Add(Me.txt_sub_total)
        Me.GroupBox1.Controls.Add(Me.txt_estado_form)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_validez)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_desc_rcgo)
        Me.GroupBox1.Controls.Add(Me.txt_cantidad)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_producto)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_producto)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbl_des_rcgo)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.gropu2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_telef)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_direccion)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 526)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'Check_talonario
        '
        Me.Check_talonario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Check_talonario.AutoSize = True
        Me.Check_talonario.BackColor = System.Drawing.Color.Black
        Me.Check_talonario.Location = New System.Drawing.Point(397, 89)
        Me.Check_talonario.Name = "Check_talonario"
        Me.Check_talonario.Size = New System.Drawing.Size(29, 17)
        Me.Check_talonario.TabIndex = 43
        Me.Check_talonario.Tag = " "
        Me.Check_talonario.Text = " "
        Me.Check_talonario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check_talonario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Check_talonario.UseVisualStyleBackColor = False
        '
        'txt_iva
        '
        Me.txt_iva.AcceptsReturn = True
        Me.txt_iva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_iva.BackColor = System.Drawing.Color.White
        Me.txt_iva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.Location = New System.Drawing.Point(477, 155)
        Me.txt_iva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_iva.MaxLength = 13
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.ReadOnly = True
        Me.txt_iva.Size = New System.Drawing.Size(62, 22)
        Me.txt_iva.TabIndex = 42
        Me.txt_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_iva.Visible = False
        '
        'txt_precio
        '
        Me.txt_precio.AcceptsReturn = True
        Me.txt_precio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_precio.BackColor = System.Drawing.Color.White
        Me.txt_precio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.Location = New System.Drawing.Point(477, 129)
        Me.txt_precio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_precio.MaxLength = 13
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.ReadOnly = True
        Me.txt_precio.Size = New System.Drawing.Size(62, 22)
        Me.txt_precio.TabIndex = 41
        Me.txt_precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_precio.Visible = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(606, 499)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Total:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(608, 468)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 15)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "I.V.A:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(583, 435)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Sub Total:"
        '
        'txt_total
        '
        Me.txt_total.AcceptsReturn = True
        Me.txt_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(661, 492)
        Me.txt_total.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_total.MaxLength = 13
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(100, 25)
        Me.txt_total.TabIndex = 37
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_insc
        '
        Me.txt_iva_insc.AcceptsReturn = True
        Me.txt_iva_insc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_iva_insc.BackColor = System.Drawing.Color.White
        Me.txt_iva_insc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva_insc.ForeColor = System.Drawing.Color.Black
        Me.txt_iva_insc.Location = New System.Drawing.Point(661, 462)
        Me.txt_iva_insc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_iva_insc.MaxLength = 13
        Me.txt_iva_insc.Name = "txt_iva_insc"
        Me.txt_iva_insc.ReadOnly = True
        Me.txt_iva_insc.Size = New System.Drawing.Size(100, 25)
        Me.txt_iva_insc.TabIndex = 36
        Me.txt_iva_insc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_sub_total
        '
        Me.txt_sub_total.AcceptsReturn = True
        Me.txt_sub_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sub_total.BackColor = System.Drawing.Color.White
        Me.txt_sub_total.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sub_total.ForeColor = System.Drawing.Color.Black
        Me.txt_sub_total.Location = New System.Drawing.Point(661, 429)
        Me.txt_sub_total.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_sub_total.MaxLength = 13
        Me.txt_sub_total.Name = "txt_sub_total"
        Me.txt_sub_total.ReadOnly = True
        Me.txt_sub_total.Size = New System.Drawing.Size(100, 25)
        Me.txt_sub_total.TabIndex = 35
        Me.txt_sub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_estado_form.Location = New System.Drawing.Point(432, 88)
        Me.txt_estado_form.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_estado_form.MaxLength = 9
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(28, 21)
        Me.txt_estado_form.TabIndex = 34
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_estado_form.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(156, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "dias"
        '
        'txt_validez
        '
        Me.txt_validez.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_validez.Location = New System.Drawing.Point(83, 88)
        Me.txt_validez.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_validez.MaxLength = 9
        Me.txt_validez.Name = "txt_validez"
        Me.txt_validez.Size = New System.Drawing.Size(67, 21)
        Me.txt_validez.TabIndex = 32
        Me.txt_validez.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Validez:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(4, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(473, 1)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Label7"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(616, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Cantidad"
        '
        'txt_desc_rcgo
        '
        Me.txt_desc_rcgo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_desc_rcgo.BackColor = System.Drawing.Color.White
        Me.txt_desc_rcgo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_rcgo.Location = New System.Drawing.Point(684, 149)
        Me.txt_desc_rcgo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_desc_rcgo.MaxLength = 7
        Me.txt_desc_rcgo.Name = "txt_desc_rcgo"
        Me.txt_desc_rcgo.Size = New System.Drawing.Size(62, 22)
        Me.txt_desc_rcgo.TabIndex = 27
        Me.txt_desc_rcgo.TabStop = False
        Me.txt_desc_rcgo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cantidad
        '
        Me.txt_cantidad.AcceptsReturn = True
        Me.txt_cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cantidad.BackColor = System.Drawing.Color.White
        Me.txt_cantidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.Location = New System.Drawing.Point(684, 122)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cantidad.MaxLength = 13
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.ReadOnly = True
        Me.txt_cantidad.Size = New System.Drawing.Size(62, 22)
        Me.txt_cantidad.TabIndex = 25
        Me.txt_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_nombre_producto.BackColor = System.Drawing.Color.White
        Me.txt_nombre_producto.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_producto.Location = New System.Drawing.Point(18, 157)
        Me.txt_nombre_producto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.Size = New System.Drawing.Size(442, 20)
        Me.txt_nombre_producto.TabIndex = 24
        Me.txt_nombre_producto.TabStop = False
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_codigo_producto.BackColor = System.Drawing.Color.White
        Me.txt_codigo_producto.Enabled = False
        Me.txt_codigo_producto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_producto.Location = New System.Drawing.Point(128, 131)
        Me.txt_codigo_producto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.Size = New System.Drawing.Size(332, 21)
        Me.txt_codigo_producto.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Codigo Articulo"
        '
        'lbl_des_rcgo
        '
        Me.lbl_des_rcgo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_des_rcgo.AutoSize = True
        Me.lbl_des_rcgo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_des_rcgo.Location = New System.Drawing.Point(616, 153)
        Me.lbl_des_rcgo.Name = "lbl_des_rcgo"
        Me.lbl_des_rcgo.Size = New System.Drawing.Size(62, 15)
        Me.lbl_des_rcgo.TabIndex = 29
        Me.lbl_des_rcgo.Text = "Desc/Rgo"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.descrip, Me.precio, Me.PRECIO1, Me.DESC, Me.TOTAL, Me.iva, Me.Column1, Me.Column2})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(13, 184)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(748, 234)
        Me.DataGridView1.TabIndex = 22
        '
        'gropu2
        '
        Me.gropu2.Controls.Add(Me.Label6)
        Me.gropu2.Controls.Add(Me.DateTimePicker1)
        Me.gropu2.Controls.Add(Me.lbl_numero)
        Me.gropu2.Controls.Add(Me.Label4)
        Me.gropu2.Location = New System.Drawing.Point(477, 11)
        Me.gropu2.Name = "gropu2"
        Me.gropu2.Size = New System.Drawing.Size(284, 104)
        Me.gropu2.TabIndex = 21
        Me.gropu2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Fecha Emision:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(123, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(86, 20)
        Me.DateTimePicker1.TabIndex = 19
        '
        'lbl_numero
        '
        Me.lbl_numero.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_numero.Location = New System.Drawing.Point(66, 55)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(196, 23)
        Me.lbl_numero.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 24)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Nº"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Telefono"
        '
        'txt_telef
        '
        Me.txt_telef.BackColor = System.Drawing.Color.White
        Me.txt_telef.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telef.ForeColor = System.Drawing.Color.Black
        Me.txt_telef.Location = New System.Drawing.Point(83, 63)
        Me.txt_telef.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_telef.Name = "txt_telef"
        Me.txt_telef.Size = New System.Drawing.Size(377, 21)
        Me.txt_telef.TabIndex = 18
        Me.txt_telef.TabStop = False
        Me.txt_telef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Direccion"
        '
        'txt_direccion
        '
        Me.txt_direccion.BackColor = System.Drawing.Color.White
        Me.txt_direccion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.ForeColor = System.Drawing.Color.Black
        Me.txt_direccion.Location = New System.Drawing.Point(83, 40)
        Me.txt_direccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(377, 21)
        Me.txt_direccion.TabIndex = 14
        Me.txt_direccion.TabStop = False
        Me.txt_direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 80
        '
        'descrip
        '
        Me.descrip.Frozen = True
        Me.descrip.HeaderText = "DESCRIPCION"
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Width = 260
        '
        'precio
        '
        Me.precio.Frozen = True
        Me.precio.HeaderText = "CANTIDAD"
        Me.precio.Name = "precio"
        Me.precio.ReadOnly = True
        '
        'PRECIO1
        '
        Me.PRECIO1.Frozen = True
        Me.PRECIO1.HeaderText = "PRECIO"
        Me.PRECIO1.Name = "PRECIO1"
        Me.PRECIO1.ReadOnly = True
        Me.PRECIO1.Width = 80
        '
        'DESC
        '
        Me.DESC.Frozen = True
        Me.DESC.HeaderText = "DESCUENTO"
        Me.DESC.Name = "DESC"
        Me.DESC.ReadOnly = True
        Me.DESC.Width = 85
        '
        'TOTAL
        '
        Me.TOTAL.Frozen = True
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        '
        'iva
        '
        Me.iva.Frozen = True
        Me.iva.HeaderText = "iva"
        Me.iva.Name = "iva"
        Me.iva.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "preciosiva"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "totalsiva"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'txt_precio_siva
        '
        Me.txt_precio_siva.Location = New System.Drawing.Point(547, 129)
        Me.txt_precio_siva.Name = "txt_precio_siva"
        Me.txt_precio_siva.Size = New System.Drawing.Size(50, 20)
        Me.txt_precio_siva.TabIndex = 44
        Me.txt_precio_siva.Visible = False
        '
        'Form_presupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_presupuesto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presupuesto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gropu2.ResumeLayout(False)
        Me.gropu2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents gropu2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_telef As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_desc_rcgo As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_des_rcgo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_validez As mitextbox1.texto_solonum
    Friend WithEvents txt_estado_form As mitextbox1.texto_solonum
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva_insc As System.Windows.Forms.TextBox
    Friend WithEvents txt_sub_total As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents Check_talonario As System.Windows.Forms.CheckBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_precio_siva As System.Windows.Forms.TextBox
End Class
