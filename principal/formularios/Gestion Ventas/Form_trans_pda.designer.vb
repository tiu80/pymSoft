<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_trans_pda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_trans_pda))
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_nombre_carga = New System.Windows.Forms.Label
        Me.txt_carga = New mitextbox1.texto_solonum
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_lista = New System.Windows.Forms.Label
        Me.txt_lista = New mitextbox1.texto_solonum
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.txt_vendedor = New mitextbox1.texto_solonum
        Me.lbl_vendedor = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chk_proveedores = New System.Windows.Forms.CheckBox
        Me.chk_pedido_prov = New System.Windows.Forms.CheckBox
        Me.Check_rubro = New System.Windows.Forms.CheckBox
        Me.Check_usuario = New System.Windows.Forms.CheckBox
        Me.Check_stock = New System.Windows.Forms.CheckBox
        Me.Check_cta_cte = New System.Windows.Forms.CheckBox
        Me.Check_producto = New System.Windows.Forms.CheckBox
        Me.Check_cliente = New System.Windows.Forms.CheckBox
        Me.dt_fecha_caja = New System.Windows.Forms.DateTimePicker
        Me.txt_directorio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Check_recibir = New System.Windows.Forms.CheckBox
        Me.Check_enviar = New System.Windows.Forms.CheckBox
        Me.txt_recibir = New System.Windows.Forms.TextBox
        Me.txt_enviar = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.cmd_inicia = New System.Windows.Forms.Button
        Me.lbl_prog = New System.Windows.Forms.Label
        Me.lbl_nom = New System.Windows.Forms.Label
        Me.chk_carga_masiva_productos = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(622, -3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 70)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Transferidor Pda"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(546, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 70)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_nombre_carga)
        Me.GroupBox1.Controls.Add(Me.txt_carga)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_lista)
        Me.GroupBox1.Controls.Add(Me.txt_lista)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.lbl_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.dt_fecha_caja)
        Me.GroupBox1.Controls.Add(Me.txt_directorio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Check_recibir)
        Me.GroupBox1.Controls.Add(Me.Check_enviar)
        Me.GroupBox1.Controls.Add(Me.txt_recibir)
        Me.GroupBox1.Controls.Add(Me.txt_enviar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(778, 385)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbl_nombre_carga
        '
        Me.lbl_nombre_carga.AutoSize = True
        Me.lbl_nombre_carga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre_carga.ForeColor = System.Drawing.Color.Blue
        Me.lbl_nombre_carga.Location = New System.Drawing.Point(292, 208)
        Me.lbl_nombre_carga.Name = "lbl_nombre_carga"
        Me.lbl_nombre_carga.Size = New System.Drawing.Size(0, 16)
        Me.lbl_nombre_carga.TabIndex = 26
        '
        'txt_carga
        '
        Me.txt_carga.Enabled = False
        Me.txt_carga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_carga.Location = New System.Drawing.Point(126, 205)
        Me.txt_carga.Name = "txt_carga"
        Me.txt_carga.Size = New System.Drawing.Size(156, 21)
        Me.txt_carga.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Carga"
        '
        'lbl_lista
        '
        Me.lbl_lista.AutoSize = True
        Me.lbl_lista.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lista.ForeColor = System.Drawing.Color.Blue
        Me.lbl_lista.Location = New System.Drawing.Point(289, 102)
        Me.lbl_lista.Name = "lbl_lista"
        Me.lbl_lista.Size = New System.Drawing.Size(0, 15)
        Me.lbl_lista.TabIndex = 23
        '
        'txt_lista
        '
        Me.txt_lista.BackColor = System.Drawing.Color.White
        Me.txt_lista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lista.Location = New System.Drawing.Point(126, 99)
        Me.txt_lista.Name = "txt_lista"
        Me.txt_lista.Size = New System.Drawing.Size(156, 21)
        Me.txt_lista.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(653, 158)
        Me.ProgressBar1.Maximum = 100000000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 17
        Me.ProgressBar1.Visible = False
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(126, 131)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(156, 21)
        Me.txt_vendedor.TabIndex = 5
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vendedor.ForeColor = System.Drawing.Color.Blue
        Me.lbl_vendedor.Location = New System.Drawing.Point(288, 134)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(0, 15)
        Me.lbl_vendedor.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Vendedor"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_carga_masiva_productos)
        Me.GroupBox2.Controls.Add(Me.chk_proveedores)
        Me.GroupBox2.Controls.Add(Me.chk_pedido_prov)
        Me.GroupBox2.Controls.Add(Me.Check_rubro)
        Me.GroupBox2.Controls.Add(Me.Check_usuario)
        Me.GroupBox2.Controls.Add(Me.Check_stock)
        Me.GroupBox2.Controls.Add(Me.Check_cta_cte)
        Me.GroupBox2.Controls.Add(Me.Check_producto)
        Me.GroupBox2.Controls.Add(Me.Check_cliente)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(744, 136)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones:"
        '
        'chk_proveedores
        '
        Me.chk_proveedores.AutoSize = True
        Me.chk_proveedores.Location = New System.Drawing.Point(614, 68)
        Me.chk_proveedores.Name = "chk_proveedores"
        Me.chk_proveedores.Size = New System.Drawing.Size(86, 17)
        Me.chk_proveedores.TabIndex = 14
        Me.chk_proveedores.Text = "Proveedores"
        Me.chk_proveedores.UseVisualStyleBackColor = True
        '
        'chk_pedido_prov
        '
        Me.chk_pedido_prov.AutoSize = True
        Me.chk_pedido_prov.Location = New System.Drawing.Point(614, 29)
        Me.chk_pedido_prov.Name = "chk_pedido_prov"
        Me.chk_pedido_prov.Size = New System.Drawing.Size(122, 17)
        Me.chk_pedido_prov.TabIndex = 13
        Me.chk_pedido_prov.Text = "Pedido Proveedores"
        Me.chk_pedido_prov.UseVisualStyleBackColor = True
        '
        'Check_rubro
        '
        Me.Check_rubro.AutoSize = True
        Me.Check_rubro.Location = New System.Drawing.Point(448, 29)
        Me.Check_rubro.Name = "Check_rubro"
        Me.Check_rubro.Size = New System.Drawing.Size(60, 17)
        Me.Check_rubro.TabIndex = 11
        Me.Check_rubro.Text = "Rubros"
        Me.Check_rubro.UseVisualStyleBackColor = True
        '
        'Check_usuario
        '
        Me.Check_usuario.AutoSize = True
        Me.Check_usuario.Location = New System.Drawing.Point(448, 68)
        Me.Check_usuario.Name = "Check_usuario"
        Me.Check_usuario.Size = New System.Drawing.Size(67, 17)
        Me.Check_usuario.TabIndex = 12
        Me.Check_usuario.Text = "Usuarios"
        Me.Check_usuario.UseVisualStyleBackColor = True
        '
        'Check_stock
        '
        Me.Check_stock.AutoSize = True
        Me.Check_stock.Location = New System.Drawing.Point(257, 68)
        Me.Check_stock.Name = "Check_stock"
        Me.Check_stock.Size = New System.Drawing.Size(54, 17)
        Me.Check_stock.TabIndex = 10
        Me.Check_stock.Text = "Stock"
        Me.Check_stock.UseVisualStyleBackColor = True
        '
        'Check_cta_cte
        '
        Me.Check_cta_cte.AutoSize = True
        Me.Check_cta_cte.Location = New System.Drawing.Point(257, 29)
        Me.Check_cta_cte.Name = "Check_cta_cte"
        Me.Check_cta_cte.Size = New System.Drawing.Size(61, 17)
        Me.Check_cta_cte.TabIndex = 9
        Me.Check_cta_cte.Text = "Cta Cte"
        Me.Check_cta_cte.UseVisualStyleBackColor = True
        '
        'Check_producto
        '
        Me.Check_producto.AutoSize = True
        Me.Check_producto.Location = New System.Drawing.Point(36, 68)
        Me.Check_producto.Name = "Check_producto"
        Me.Check_producto.Size = New System.Drawing.Size(74, 17)
        Me.Check_producto.TabIndex = 8
        Me.Check_producto.Text = "Productos"
        Me.Check_producto.UseVisualStyleBackColor = True
        '
        'Check_cliente
        '
        Me.Check_cliente.AutoSize = True
        Me.Check_cliente.Location = New System.Drawing.Point(36, 29)
        Me.Check_cliente.Name = "Check_cliente"
        Me.Check_cliente.Size = New System.Drawing.Size(63, 17)
        Me.Check_cliente.TabIndex = 7
        Me.Check_cliente.Text = "Clientes"
        Me.Check_cliente.UseVisualStyleBackColor = True
        '
        'dt_fecha_caja
        '
        Me.dt_fecha_caja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fecha_caja.Location = New System.Drawing.Point(126, 165)
        Me.dt_fecha_caja.Name = "dt_fecha_caja"
        Me.dt_fecha_caja.Size = New System.Drawing.Size(156, 20)
        Me.dt_fecha_caja.TabIndex = 8
        '
        'txt_directorio
        '
        Me.txt_directorio.BackColor = System.Drawing.Color.White
        Me.txt_directorio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_directorio.Location = New System.Drawing.Point(126, 71)
        Me.txt_directorio.Name = "txt_directorio"
        Me.txt_directorio.ReadOnly = True
        Me.txt_directorio.Size = New System.Drawing.Size(156, 21)
        Me.txt_directorio.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "fecha de caja"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Lista"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Directorio"
        '
        'Check_recibir
        '
        Me.Check_recibir.AutoSize = True
        Me.Check_recibir.Location = New System.Drawing.Point(704, 46)
        Me.Check_recibir.Name = "Check_recibir"
        Me.Check_recibir.Size = New System.Drawing.Size(15, 14)
        Me.Check_recibir.TabIndex = 21
        Me.Check_recibir.UseVisualStyleBackColor = True
        '
        'Check_enviar
        '
        Me.Check_enviar.AutoSize = True
        Me.Check_enviar.Location = New System.Drawing.Point(704, 20)
        Me.Check_enviar.Name = "Check_enviar"
        Me.Check_enviar.Size = New System.Drawing.Size(15, 14)
        Me.Check_enviar.TabIndex = 20
        Me.Check_enviar.UseVisualStyleBackColor = True
        '
        'txt_recibir
        '
        Me.txt_recibir.AcceptsReturn = True
        Me.txt_recibir.BackColor = System.Drawing.Color.White
        Me.txt_recibir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_recibir.Location = New System.Drawing.Point(126, 43)
        Me.txt_recibir.Name = "txt_recibir"
        Me.txt_recibir.ReadOnly = True
        Me.txt_recibir.Size = New System.Drawing.Size(572, 21)
        Me.txt_recibir.TabIndex = 2
        '
        'txt_enviar
        '
        Me.txt_enviar.BackColor = System.Drawing.Color.White
        Me.txt_enviar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_enviar.Location = New System.Drawing.Point(126, 16)
        Me.txt_enviar.Name = "txt_enviar"
        Me.txt_enviar.ReadOnly = True
        Me.txt_enviar.Size = New System.Drawing.Size(572, 21)
        Me.txt_enviar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Recibir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Enviar"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(32, 18)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(26, 20)
        Me.txt_estado_form.TabIndex = 16
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'cmd_inicia
        '
        Me.cmd_inicia.BackColor = System.Drawing.Color.Black
        Me.cmd_inicia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_inicia.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_inicia.Location = New System.Drawing.Point(605, 460)
        Me.cmd_inicia.Name = "cmd_inicia"
        Me.cmd_inicia.Size = New System.Drawing.Size(155, 64)
        Me.cmd_inicia.TabIndex = 13
        Me.cmd_inicia.Text = "INICIAR"
        Me.cmd_inicia.UseVisualStyleBackColor = False
        '
        'lbl_prog
        '
        Me.lbl_prog.AutoSize = True
        Me.lbl_prog.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prog.Location = New System.Drawing.Point(720, 513)
        Me.lbl_prog.Name = "lbl_prog"
        Me.lbl_prog.Size = New System.Drawing.Size(0, 14)
        Me.lbl_prog.TabIndex = 18
        '
        'lbl_nom
        '
        Me.lbl_nom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom.ForeColor = System.Drawing.Color.Blue
        Me.lbl_nom.Location = New System.Drawing.Point(499, 502)
        Me.lbl_nom.Name = "lbl_nom"
        Me.lbl_nom.Size = New System.Drawing.Size(100, 22)
        Me.lbl_nom.TabIndex = 19
        '
        'chk_carga_masiva_productos
        '
        Me.chk_carga_masiva_productos.AutoSize = True
        Me.chk_carga_masiva_productos.Location = New System.Drawing.Point(36, 103)
        Me.chk_carga_masiva_productos.Name = "chk_carga_masiva_productos"
        Me.chk_carga_masiva_productos.Size = New System.Drawing.Size(140, 17)
        Me.chk_carga_masiva_productos.TabIndex = 15
        Me.chk_carga_masiva_productos.Text = "Carga masiva productos"
        Me.chk_carga_masiva_productos.UseVisualStyleBackColor = True
        '
        'Form_trans_pda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.lbl_nom)
        Me.Controls.Add(Me.lbl_prog)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_inicia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_trans_pda"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferidor de Imformacion de  pocket pc"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Check_recibir As System.Windows.Forms.CheckBox
    Friend WithEvents Check_enviar As System.Windows.Forms.CheckBox
    Friend WithEvents txt_recibir As System.Windows.Forms.TextBox
    Friend WithEvents txt_enviar As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dt_fecha_caja As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_directorio As System.Windows.Forms.TextBox
    Friend WithEvents Check_stock As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cta_cte As System.Windows.Forms.CheckBox
    Friend WithEvents Check_producto As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cliente As System.Windows.Forms.CheckBox
    Friend WithEvents Check_usuario As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents txt_vendedor As mitextbox1.texto_solonum
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents txt_lista As mitextbox1.texto_solonum
    Friend WithEvents lbl_lista As System.Windows.Forms.Label
    Friend WithEvents Check_rubro As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pedido_prov As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_inicia As System.Windows.Forms.Button
    Friend WithEvents lbl_prog As System.Windows.Forms.Label
    Friend WithEvents lbl_nom As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txt_carga As mitextbox1.texto_solonum
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre_carga As System.Windows.Forms.Label
    Friend WithEvents chk_proveedores As System.Windows.Forms.CheckBox
    Friend WithEvents chk_carga_masiva_productos As System.Windows.Forms.CheckBox
End Class
