<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_rep_cliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_rep_cliente))
        Me.cmd_acepta1 = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_detalle_agrupacion = New System.Windows.Forms.ComboBox
        Me.lbl_detalle_agrupacion = New System.Windows.Forms.Label
        Me.cmb_agrupacion = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_ordena = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.dt_fec_hasta = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_desde = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.opt_cli = New System.Windows.Forms.RadioButton
        Me.opt_prov = New System.Windows.Forms.RadioButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_acepta1
        '
        Me.cmd_acepta1.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta1.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta1.Location = New System.Drawing.Point(24, 454)
        Me.cmd_acepta1.Name = "cmd_acepta1"
        Me.cmd_acepta1.Size = New System.Drawing.Size(117, 66)
        Me.cmd_acepta1.TabIndex = 6
        Me.cmd_acepta1.Text = "Aceptar"
        Me.cmd_acepta1.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(647, 454)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(117, 66)
        Me.cmd_eliminar.TabIndex = 7
        Me.cmd_eliminar.Text = "Cancelar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(563, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 70)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmb_detalle_agrupacion)
        Me.GroupBox1.Controls.Add(Me.lbl_detalle_agrupacion)
        Me.GroupBox1.Controls.Add(Me.cmb_agrupacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_ordena)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmb_estado)
        Me.GroupBox1.Controls.Add(Me.dt_fec_hasta)
        Me.GroupBox1.Controls.Add(Me.dt_fec_desde)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(772, 367)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmb_detalle_agrupacion
        '
        Me.cmb_detalle_agrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_detalle_agrupacion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_detalle_agrupacion.FormattingEnabled = True
        Me.cmb_detalle_agrupacion.Location = New System.Drawing.Point(229, 248)
        Me.cmb_detalle_agrupacion.Name = "cmb_detalle_agrupacion"
        Me.cmb_detalle_agrupacion.Size = New System.Drawing.Size(203, 23)
        Me.cmb_detalle_agrupacion.TabIndex = 4
        Me.cmb_detalle_agrupacion.Visible = False
        '
        'lbl_detalle_agrupacion
        '
        Me.lbl_detalle_agrupacion.AutoSize = True
        Me.lbl_detalle_agrupacion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_detalle_agrupacion.Location = New System.Drawing.Point(95, 251)
        Me.lbl_detalle_agrupacion.Name = "lbl_detalle_agrupacion"
        Me.lbl_detalle_agrupacion.Size = New System.Drawing.Size(46, 15)
        Me.lbl_detalle_agrupacion.TabIndex = 27
        Me.lbl_detalle_agrupacion.Text = "Detalle"
        Me.lbl_detalle_agrupacion.Visible = False
        '
        'cmb_agrupacion
        '
        Me.cmb_agrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_agrupacion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_agrupacion.FormattingEnabled = True
        Me.cmb_agrupacion.Items.AddRange(New Object() {"Total", "Localidad", "Zona", "Provincia"})
        Me.cmb_agrupacion.Location = New System.Drawing.Point(229, 196)
        Me.cmb_agrupacion.Name = "cmb_agrupacion"
        Me.cmb_agrupacion.Size = New System.Drawing.Size(203, 23)
        Me.cmb_agrupacion.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(95, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Agrupacion"
        '
        'cmb_ordena
        '
        Me.cmb_ordena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ordena.Enabled = False
        Me.cmb_ordena.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ordena.FormattingEnabled = True
        Me.cmb_ordena.Items.AddRange(New Object() {"Codigo", "Alfabeticamente"})
        Me.cmb_ordena.Location = New System.Drawing.Point(229, 145)
        Me.cmb_ordena.Name = "cmb_ordena"
        Me.cmb_ordena.Size = New System.Drawing.Size(203, 23)
        Me.cmb_ordena.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(93, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Ordenacion"
        '
        'cmb_estado
        '
        Me.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.cmb_estado.Location = New System.Drawing.Point(229, 306)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(203, 23)
        Me.cmb_estado.TabIndex = 5
        '
        'dt_fec_hasta
        '
        Me.dt_fec_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_hasta.Location = New System.Drawing.Point(229, 96)
        Me.dt_fec_hasta.Name = "dt_fec_hasta"
        Me.dt_fec_hasta.Size = New System.Drawing.Size(203, 20)
        Me.dt_fec_hasta.TabIndex = 1
        '
        'dt_fec_desde
        '
        Me.dt_fec_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_desde.Location = New System.Drawing.Point(229, 51)
        Me.dt_fec_desde.Name = "dt_fec_desde"
        Me.dt_fec_desde.Size = New System.Drawing.Size(203, 20)
        Me.dt_fec_desde.TabIndex = 0
        Me.dt_fec_desde.Value = New Date(2008, 12, 1, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(93, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Fecha Desde:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(95, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Estado"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(618, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 70)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Reporte Clientes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.opt_prov)
        Me.GroupBox2.Controls.Add(Me.opt_cli)
        Me.GroupBox2.Location = New System.Drawing.Point(141, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 60)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        '
        'opt_cli
        '
        Me.opt_cli.AutoSize = True
        Me.opt_cli.Checked = True
        Me.opt_cli.Location = New System.Drawing.Point(93, 22)
        Me.opt_cli.Name = "opt_cli"
        Me.opt_cli.Size = New System.Drawing.Size(62, 17)
        Me.opt_cli.TabIndex = 0
        Me.opt_cli.TabStop = True
        Me.opt_cli.Text = "Clientes"
        Me.opt_cli.UseVisualStyleBackColor = True
        '
        'opt_prov
        '
        Me.opt_prov.AutoSize = True
        Me.opt_prov.Location = New System.Drawing.Point(194, 22)
        Me.opt_prov.Name = "opt_prov"
        Me.opt_prov.Size = New System.Drawing.Size(85, 17)
        Me.opt_prov.TabIndex = 1
        Me.opt_prov.Text = "Proveedores"
        Me.opt_prov.UseVisualStyleBackColor = True
        '
        'Form_rep_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmd_acepta1)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_rep_cliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE CLIENTES/PROVEEDOR"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_acepta1 As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_ordena As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents dt_fec_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_agrupacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_detalle_agrupacion As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_detalle_agrupacion As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_prov As System.Windows.Forms.RadioButton
    Friend WithEvents opt_cli As System.Windows.Forms.RadioButton
End Class
