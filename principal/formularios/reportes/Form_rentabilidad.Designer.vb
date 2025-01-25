<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_rentabilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_rentabilidad))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Check_talonario = New System.Windows.Forms.CheckBox
        Me.txt_cod_vendedor = New System.Windows.Forms.TextBox
        Me.cmb_nombre = New System.Windows.Forms.ComboBox
        Me.lbl_nom = New System.Windows.Forms.Label
        Me.cmb_ordena = New System.Windows.Forms.ComboBox
        Me.Lbl_nombre = New System.Windows.Forms.Label
        Me.cmb_agrupacion = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dt_fec_hasta = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_desde = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_acepta1 = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Check_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_cod_vendedor)
        Me.GroupBox1.Controls.Add(Me.cmb_nombre)
        Me.GroupBox1.Controls.Add(Me.lbl_nom)
        Me.GroupBox1.Controls.Add(Me.cmb_ordena)
        Me.GroupBox1.Controls.Add(Me.Lbl_nombre)
        Me.GroupBox1.Controls.Add(Me.cmb_agrupacion)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dt_fec_hasta)
        Me.GroupBox1.Controls.Add(Me.dt_fec_desde)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(772, 360)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Check_talonario
        '
        Me.Check_talonario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Check_talonario.AutoSize = True
        Me.Check_talonario.BackColor = System.Drawing.Color.Black
        Me.Check_talonario.Location = New System.Drawing.Point(204, 310)
        Me.Check_talonario.Name = "Check_talonario"
        Me.Check_talonario.Size = New System.Drawing.Size(29, 17)
        Me.Check_talonario.TabIndex = 6
        Me.Check_talonario.Tag = " "
        Me.Check_talonario.Text = " "
        Me.Check_talonario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check_talonario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Check_talonario.UseVisualStyleBackColor = False
        '
        'txt_cod_vendedor
        '
        Me.txt_cod_vendedor.Location = New System.Drawing.Point(439, 200)
        Me.txt_cod_vendedor.Name = "txt_cod_vendedor"
        Me.txt_cod_vendedor.Size = New System.Drawing.Size(27, 20)
        Me.txt_cod_vendedor.TabIndex = 24
        Me.txt_cod_vendedor.Visible = False
        '
        'cmb_nombre
        '
        Me.cmb_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nombre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_nombre.FormattingEnabled = True
        Me.cmb_nombre.Items.AddRange(New Object() {"Total", "Vendedor"})
        Me.cmb_nombre.Location = New System.Drawing.Point(204, 259)
        Me.cmb_nombre.Name = "cmb_nombre"
        Me.cmb_nombre.Size = New System.Drawing.Size(219, 23)
        Me.cmb_nombre.TabIndex = 5
        Me.cmb_nombre.Visible = False
        '
        'lbl_nom
        '
        Me.lbl_nom.AutoSize = True
        Me.lbl_nom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom.Location = New System.Drawing.Point(93, 263)
        Me.lbl_nom.Name = "lbl_nom"
        Me.lbl_nom.Size = New System.Drawing.Size(55, 15)
        Me.lbl_nom.TabIndex = 23
        Me.lbl_nom.Text = "Nombre:"
        Me.lbl_nom.Visible = False
        '
        'cmb_ordena
        '
        Me.cmb_ordena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ordena.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ordena.FormattingEnabled = True
        Me.cmb_ordena.Items.AddRange(New Object() {"Codigo", "Alfabeticamente"})
        Me.cmb_ordena.Location = New System.Drawing.Point(204, 146)
        Me.cmb_ordena.Name = "cmb_ordena"
        Me.cmb_ordena.Size = New System.Drawing.Size(219, 23)
        Me.cmb_ordena.TabIndex = 3
        '
        'Lbl_nombre
        '
        Me.Lbl_nombre.AutoSize = True
        Me.Lbl_nombre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_nombre.Location = New System.Drawing.Point(93, 149)
        Me.Lbl_nombre.Name = "Lbl_nombre"
        Me.Lbl_nombre.Size = New System.Drawing.Size(74, 15)
        Me.Lbl_nombre.TabIndex = 16
        Me.Lbl_nombre.Text = "Ordenacion:"
        '
        'cmb_agrupacion
        '
        Me.cmb_agrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_agrupacion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_agrupacion.FormattingEnabled = True
        Me.cmb_agrupacion.Items.AddRange(New Object() {"Total", "Vendedor"})
        Me.cmb_agrupacion.Location = New System.Drawing.Point(204, 200)
        Me.cmb_agrupacion.Name = "cmb_agrupacion"
        Me.cmb_agrupacion.Size = New System.Drawing.Size(219, 23)
        Me.cmb_agrupacion.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(93, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Agrupacion:"
        '
        'dt_fec_hasta
        '
        Me.dt_fec_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_hasta.Location = New System.Drawing.Point(204, 94)
        Me.dt_fec_hasta.Name = "dt_fec_hasta"
        Me.dt_fec_hasta.Size = New System.Drawing.Size(219, 20)
        Me.dt_fec_hasta.TabIndex = 2
        Me.dt_fec_hasta.Value = New Date(2023, 6, 11, 0, 0, 0, 0)
        '
        'dt_fec_desde
        '
        Me.dt_fec_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_desde.Location = New System.Drawing.Point(204, 39)
        Me.dt_fec_desde.Name = "dt_fec_desde"
        Me.dt_fec_desde.Size = New System.Drawing.Size(219, 20)
        Me.dt_fec_desde.TabIndex = 1
        Me.dt_fec_desde.Value = New Date(2023, 6, 11, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(93, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 44)
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
        Me.Label2.Location = New System.Drawing.Point(614, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 70)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Rentabilidad"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_acepta1
        '
        Me.cmd_acepta1.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta1.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta1.Location = New System.Drawing.Point(14, 452)
        Me.cmd_acepta1.Name = "cmd_acepta1"
        Me.cmd_acepta1.Size = New System.Drawing.Size(139, 68)
        Me.cmd_acepta1.TabIndex = 7
        Me.cmd_acepta1.Text = "Aceptar"
        Me.cmd_acepta1.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(637, 451)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(135, 68)
        Me.cmd_eliminar.TabIndex = 8
        Me.cmd_eliminar.Text = "Cancelar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(551, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'Form_rentabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmd_acepta1)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_rentabilidad"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadistico de Rentabilidad"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_acepta1 As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_ordena As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents cmb_agrupacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_nombre As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_nom As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_cod_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Check_talonario As System.Windows.Forms.CheckBox
End Class
