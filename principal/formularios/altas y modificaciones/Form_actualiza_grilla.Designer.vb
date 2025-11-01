<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_actualiza_grilla
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
        Me.cmd_actualiza = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_precio_civa = New System.Windows.Forms.TextBox
        Me.txt_costo = New System.Windows.Forms.TextBox
        Me.txt_codigo_iva = New mitextbox1.texto_solonum
        Me.lbl_tipo_iva = New System.Windows.Forms.Label
        Me.lbl_nombre_iva = New System.Windows.Forms.Label
        Me.lbl_nom_imp_int = New System.Windows.Forms.Label
        Me.txt_impuestos_internos = New mitextbox1.texto_solonum
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txt_utilidad = New System.Windows.Forms.TextBox
        Me.label25 = New System.Windows.Forms.Label
        Me.txt_precio_siva = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_pciva = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.txt_pos_fila = New System.Windows.Forms.TextBox
        Me.txt_desc2 = New System.Windows.Forms.TextBox
        Me.txt_desc3 = New System.Windows.Forms.TextBox
        Me.txt_pago_total = New System.Windows.Forms.TextBox
        Me.txt_desc1 = New System.Windows.Forms.TextBox
        Me.txt_flete = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_nombre = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_actualiza
        '
        Me.cmd_actualiza.BackColor = System.Drawing.Color.Black
        Me.cmd_actualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualiza.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualiza.Location = New System.Drawing.Point(119, 492)
        Me.cmd_actualiza.Name = "cmd_actualiza"
        Me.cmd_actualiza.Size = New System.Drawing.Size(129, 47)
        Me.cmd_actualiza.TabIndex = 12
        Me.cmd_actualiza.Text = "Actualizar"
        Me.cmd_actualiza.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gray
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 549)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(358, 1)
        Me.Label5.TabIndex = 62
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_precio_civa
        '
        Me.txt_precio_civa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_precio_civa.ForeColor = System.Drawing.Color.Red
        Me.txt_precio_civa.Location = New System.Drawing.Point(443, 162)
        Me.txt_precio_civa.Name = "txt_precio_civa"
        Me.txt_precio_civa.ReadOnly = True
        Me.txt_precio_civa.Size = New System.Drawing.Size(58, 20)
        Me.txt_precio_civa.TabIndex = 43
        Me.txt_precio_civa.TabStop = False
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(124, 34)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(63, 20)
        Me.txt_costo.TabIndex = 1
        Me.txt_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_codigo_iva
        '
        Me.txt_codigo_iva.Location = New System.Drawing.Point(123, 279)
        Me.txt_codigo_iva.Name = "txt_codigo_iva"
        Me.txt_codigo_iva.Size = New System.Drawing.Size(63, 20)
        Me.txt_codigo_iva.TabIndex = 7
        Me.txt_codigo_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_tipo_iva
        '
        Me.lbl_tipo_iva.BackColor = System.Drawing.Color.Gray
        Me.lbl_tipo_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_iva.ForeColor = System.Drawing.Color.White
        Me.lbl_tipo_iva.Location = New System.Drawing.Point(216, 279)
        Me.lbl_tipo_iva.Name = "lbl_tipo_iva"
        Me.lbl_tipo_iva.Size = New System.Drawing.Size(44, 20)
        Me.lbl_tipo_iva.TabIndex = 46
        Me.lbl_tipo_iva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_nombre_iva
        '
        Me.lbl_nombre_iva.BackColor = System.Drawing.Color.Gray
        Me.lbl_nombre_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre_iva.ForeColor = System.Drawing.Color.White
        Me.lbl_nombre_iva.Location = New System.Drawing.Point(260, 279)
        Me.lbl_nombre_iva.Name = "lbl_nombre_iva"
        Me.lbl_nombre_iva.Size = New System.Drawing.Size(98, 20)
        Me.lbl_nombre_iva.TabIndex = 47
        Me.lbl_nombre_iva.Text = "%"
        Me.lbl_nombre_iva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_nom_imp_int
        '
        Me.lbl_nom_imp_int.BackColor = System.Drawing.Color.Gray
        Me.lbl_nom_imp_int.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom_imp_int.ForeColor = System.Drawing.Color.White
        Me.lbl_nom_imp_int.Location = New System.Drawing.Point(216, 321)
        Me.lbl_nom_imp_int.Name = "lbl_nom_imp_int"
        Me.lbl_nom_imp_int.Size = New System.Drawing.Size(142, 20)
        Me.lbl_nom_imp_int.TabIndex = 49
        Me.lbl_nom_imp_int.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_impuestos_internos
        '
        Me.txt_impuestos_internos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_impuestos_internos.Location = New System.Drawing.Point(123, 322)
        Me.txt_impuestos_internos.MaxLength = 9
        Me.txt_impuestos_internos.Name = "txt_impuestos_internos"
        Me.txt_impuestos_internos.Size = New System.Drawing.Size(63, 22)
        Me.txt_impuestos_internos.TabIndex = 8
        Me.txt_impuestos_internos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(28, 372)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 15)
        Me.Label21.TabIndex = 51
        Me.Label21.Text = "Utilidad :"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(190, 368)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(17, 19)
        Me.Label27.TabIndex = 52
        Me.Label27.Text = "%"
        '
        'txt_utilidad
        '
        Me.txt_utilidad.AcceptsReturn = True
        Me.txt_utilidad.Location = New System.Drawing.Point(123, 368)
        Me.txt_utilidad.Name = "txt_utilidad"
        Me.txt_utilidad.Size = New System.Drawing.Size(63, 20)
        Me.txt_utilidad.TabIndex = 9
        Me.txt_utilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label25
        '
        Me.label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label25.ForeColor = System.Drawing.Color.Black
        Me.label25.Location = New System.Drawing.Point(26, 411)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(80, 20)
        Me.label25.TabIndex = 53
        Me.label25.Text = "Precio s/iva :"
        '
        'txt_precio_siva
        '
        Me.txt_precio_siva.BackColor = System.Drawing.Color.White
        Me.txt_precio_siva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio_siva.ForeColor = System.Drawing.Color.Red
        Me.txt_precio_siva.Location = New System.Drawing.Point(123, 409)
        Me.txt_precio_siva.Name = "txt_precio_siva"
        Me.txt_precio_siva.ReadOnly = True
        Me.txt_precio_siva.Size = New System.Drawing.Size(63, 22)
        Me.txt_precio_siva.TabIndex = 10
        Me.txt_precio_siva.TabStop = False
        Me.txt_precio_siva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(26, 453)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 18)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Precio c/iva :"
        '
        'txt_pciva
        '
        Me.txt_pciva.BackColor = System.Drawing.Color.White
        Me.txt_pciva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pciva.ForeColor = System.Drawing.Color.Red
        Me.txt_pciva.Location = New System.Drawing.Point(123, 451)
        Me.txt_pciva.Name = "txt_pciva"
        Me.txt_pciva.ReadOnly = True
        Me.txt_pciva.Size = New System.Drawing.Size(63, 22)
        Me.txt_pciva.TabIndex = 11
        Me.txt_pciva.TabStop = False
        Me.txt_pciva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Costo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Tipo i.v.a :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Imp. Internos :"
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Location = New System.Drawing.Point(249, 35)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.Size = New System.Drawing.Size(34, 20)
        Me.txt_codigo_producto.TabIndex = 62
        Me.txt_codigo_producto.Visible = False
        '
        'txt_pos_fila
        '
        Me.txt_pos_fila.AcceptsTab = True
        Me.txt_pos_fila.Location = New System.Drawing.Point(289, 35)
        Me.txt_pos_fila.Name = "txt_pos_fila"
        Me.txt_pos_fila.Size = New System.Drawing.Size(27, 20)
        Me.txt_pos_fila.TabIndex = 63
        Me.txt_pos_fila.Visible = False
        '
        'txt_desc2
        '
        Me.txt_desc2.Location = New System.Drawing.Point(124, 111)
        Me.txt_desc2.Name = "txt_desc2"
        Me.txt_desc2.Size = New System.Drawing.Size(63, 20)
        Me.txt_desc2.TabIndex = 3
        Me.txt_desc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_desc3
        '
        Me.txt_desc3.Location = New System.Drawing.Point(123, 150)
        Me.txt_desc3.Name = "txt_desc3"
        Me.txt_desc3.Size = New System.Drawing.Size(63, 20)
        Me.txt_desc3.TabIndex = 4
        Me.txt_desc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_pago_total
        '
        Me.txt_pago_total.Location = New System.Drawing.Point(123, 235)
        Me.txt_pago_total.Name = "txt_pago_total"
        Me.txt_pago_total.Size = New System.Drawing.Size(63, 20)
        Me.txt_pago_total.TabIndex = 6
        Me.txt_pago_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_desc1
        '
        Me.txt_desc1.Location = New System.Drawing.Point(123, 73)
        Me.txt_desc1.Name = "txt_desc1"
        Me.txt_desc1.Size = New System.Drawing.Size(63, 20)
        Me.txt_desc1.TabIndex = 2
        Me.txt_desc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_flete
        '
        Me.txt_flete.Location = New System.Drawing.Point(124, 192)
        Me.txt_flete.Name = "txt_flete"
        Me.txt_flete.Size = New System.Drawing.Size(63, 20)
        Me.txt_flete.TabIndex = 5
        Me.txt_flete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(28, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Desc 1 :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Desc 2 :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(28, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Desc 3 :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(28, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 15)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Flete :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(25, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 15)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Desc pago total"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(190, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 19)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "%"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(190, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 19)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "%"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(190, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 19)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "%"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(190, 193)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 19)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "%"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.lbl_nombre)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_flete)
        Me.GroupBox1.Controls.Add(Me.txt_desc1)
        Me.GroupBox1.Controls.Add(Me.txt_pago_total)
        Me.GroupBox1.Controls.Add(Me.txt_desc3)
        Me.GroupBox1.Controls.Add(Me.txt_desc2)
        Me.GroupBox1.Controls.Add(Me.txt_pos_fila)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_producto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_pciva)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txt_precio_siva)
        Me.GroupBox1.Controls.Add(Me.label25)
        Me.GroupBox1.Controls.Add(Me.txt_utilidad)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txt_impuestos_internos)
        Me.GroupBox1.Controls.Add(Me.lbl_nom_imp_int)
        Me.GroupBox1.Controls.Add(Me.lbl_nombre_iva)
        Me.GroupBox1.Controls.Add(Me.lbl_tipo_iva)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_iva)
        Me.GroupBox1.Controls.Add(Me.txt_costo)
        Me.GroupBox1.Controls.Add(Me.txt_precio_civa)
        Me.GroupBox1.Location = New System.Drawing.Point(5, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 482)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbl_nombre
        '
        Me.lbl_nombre.Enabled = False
        Me.lbl_nombre.Location = New System.Drawing.Point(3, 8)
        Me.lbl_nombre.MaxLength = 120
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(371, 20)
        Me.lbl_nombre.TabIndex = 79
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(190, 236)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 19)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "%"
        '
        'Form_actualiza_grilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(383, 555)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmd_actualiza)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_actualiza_grilla"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizacion precios "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_actualiza As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_precio_civa As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_iva As mitextbox1.texto_solonum
    Friend WithEvents lbl_tipo_iva As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre_iva As System.Windows.Forms.Label
    Friend WithEvents lbl_nom_imp_int As System.Windows.Forms.Label
    Friend WithEvents txt_impuestos_internos As mitextbox1.texto_solonum
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_utilidad As System.Windows.Forms.TextBox
    Friend WithEvents label25 As System.Windows.Forms.Label
    Friend WithEvents txt_precio_siva As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_pciva As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_pos_fila As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_pago_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_flete As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre As System.Windows.Forms.TextBox
End Class
