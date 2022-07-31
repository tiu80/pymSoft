<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ventas_agrupacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ventas_agrupacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_nombre_articulo = New System.Windows.Forms.Label
        Me.txt_articulo = New System.Windows.Forms.TextBox
        Me.cmb_nombre_cat = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmb_modalidad = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dt_fec_hasta = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_desde = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmd_acepta1 = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.lbl_nombre_articulo)
        Me.GroupBox1.Controls.Add(Me.txt_articulo)
        Me.GroupBox1.Controls.Add(Me.cmb_nombre_cat)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmb_modalidad)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dt_fec_hasta)
        Me.GroupBox1.Controls.Add(Me.dt_fec_desde)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(-3, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 463)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'lbl_nombre_articulo
        '
        Me.lbl_nombre_articulo.AutoSize = True
        Me.lbl_nombre_articulo.Location = New System.Drawing.Point(296, 121)
        Me.lbl_nombre_articulo.Name = "lbl_nombre_articulo"
        Me.lbl_nombre_articulo.Size = New System.Drawing.Size(0, 13)
        Me.lbl_nombre_articulo.TabIndex = 33
        '
        'txt_articulo
        '
        Me.txt_articulo.Location = New System.Drawing.Point(213, 118)
        Me.txt_articulo.Name = "txt_articulo"
        Me.txt_articulo.Size = New System.Drawing.Size(77, 20)
        Me.txt_articulo.TabIndex = 2
        '
        'cmb_nombre_cat
        '
        Me.cmb_nombre_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nombre_cat.Enabled = False
        Me.cmb_nombre_cat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_nombre_cat.FormattingEnabled = True
        Me.cmb_nombre_cat.Location = New System.Drawing.Point(213, 231)
        Me.cmb_nombre_cat.Name = "cmb_nombre_cat"
        Me.cmb_nombre_cat.Size = New System.Drawing.Size(219, 23)
        Me.cmb_nombre_cat.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(93, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Nombre:"
        '
        'cmb_modalidad
        '
        Me.cmb_modalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_modalidad.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_modalidad.FormattingEnabled = True
        Me.cmb_modalidad.Items.AddRange(New Object() {"Total", "Zona", "Vendedor"})
        Me.cmb_modalidad.Location = New System.Drawing.Point(213, 176)
        Me.cmb_modalidad.Name = "cmb_modalidad"
        Me.cmb_modalidad.Size = New System.Drawing.Size(219, 23)
        Me.cmb_modalidad.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Categoria:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(93, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Articulo:"
        '
        'dt_fec_hasta
        '
        Me.dt_fec_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_hasta.Location = New System.Drawing.Point(213, 70)
        Me.dt_fec_hasta.Name = "dt_fec_hasta"
        Me.dt_fec_hasta.Size = New System.Drawing.Size(219, 20)
        Me.dt_fec_hasta.TabIndex = 1
        Me.dt_fec_hasta.Value = New Date(2019, 4, 13, 21, 8, 9, 0)
        '
        'dt_fec_desde
        '
        Me.dt_fec_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_desde.Location = New System.Drawing.Point(213, 24)
        Me.dt_fec_desde.Name = "dt_fec_desde"
        Me.dt_fec_desde.Size = New System.Drawing.Size(219, 20)
        Me.dt_fec_desde.TabIndex = 0
        Me.dt_fec_desde.Value = New Date(2019, 4, 13, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(94, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Fecha Desde:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(574, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 70)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Estadistica venta por articulo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(483, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 70)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'cmd_acepta1
        '
        Me.cmd_acepta1.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta1.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta1.Location = New System.Drawing.Point(17, 548)
        Me.cmd_acepta1.Name = "cmd_acepta1"
        Me.cmd_acepta1.Size = New System.Drawing.Size(139, 68)
        Me.cmd_acepta1.TabIndex = 24
        Me.cmd_acepta1.Text = "Aceptar"
        Me.cmd_acepta1.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(629, 548)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(135, 68)
        Me.cmd_eliminar.TabIndex = 25
        Me.cmd_eliminar.Text = "Cancelar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(17, 12)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(29, 20)
        Me.txt_estado_form.TabIndex = 29
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Form_ventas_agrupacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 628)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmd_acepta1)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form_ventas_agrupacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadistica ventas por articulo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_acepta1 As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents cmb_modalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_nombre_cat As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre_articulo As System.Windows.Forms.Label
    Friend WithEvents txt_articulo As System.Windows.Forms.TextBox
End Class
