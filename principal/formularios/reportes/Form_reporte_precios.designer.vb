<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_reporte_precios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_reporte_precios))
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmd_acepta1 = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chk_inluye_rubro = New System.Windows.Forms.CheckBox
        Me.opt_rubro = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_ordena = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_rubro = New System.Windows.Forms.Label
        Me.lbl_prov = New System.Windows.Forms.Label
        Me.lbl_lista = New System.Windows.Forms.Label
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.dt_fec_hasta = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_desde = New System.Windows.Forms.DateTimePicker
        Me.txt_cod_rub = New mitextbox1.texto_solonum
        Me.txt_cod_prov = New mitextbox1.texto_solonum
        Me.txt_cod_list = New mitextbox1.texto_solonum
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_dias_a_revisar = New mitextbox1.texto_solonum
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(621, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 63)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Articulos/precios"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(536, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(113, 66)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'cmd_acepta1
        '
        Me.cmd_acepta1.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta1.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta1.Location = New System.Drawing.Point(19, 470)
        Me.cmd_acepta1.Name = "cmd_acepta1"
        Me.cmd_acepta1.Size = New System.Drawing.Size(117, 58)
        Me.cmd_acepta1.TabIndex = 8
        Me.cmd_acepta1.Text = "Aceptar"
        Me.cmd_acepta1.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(661, 470)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(117, 58)
        Me.cmd_eliminar.TabIndex = 9
        Me.cmd_eliminar.Text = "Cancelar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.AcceptsTab = True
        Me.txt_estado_form.Location = New System.Drawing.Point(4, 5)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(20, 20)
        Me.txt_estado_form.TabIndex = 17
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-2, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(793, 420)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(785, 394)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Precios Actuales"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.chk_inluye_rubro)
        Me.GroupBox1.Controls.Add(Me.opt_rubro)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmb_ordena)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbl_rubro)
        Me.GroupBox1.Controls.Add(Me.lbl_prov)
        Me.GroupBox1.Controls.Add(Me.lbl_lista)
        Me.GroupBox1.Controls.Add(Me.cmb_estado)
        Me.GroupBox1.Controls.Add(Me.dt_fec_hasta)
        Me.GroupBox1.Controls.Add(Me.dt_fec_desde)
        Me.GroupBox1.Controls.Add(Me.txt_cod_rub)
        Me.GroupBox1.Controls.Add(Me.txt_cod_prov)
        Me.GroupBox1.Controls.Add(Me.txt_cod_list)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(772, 377)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOMBRE})
        Me.DataGridView1.Location = New System.Drawing.Point(467, 138)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(303, 214)
        Me.DataGridView1.TabIndex = 26
        Me.DataGridView1.Visible = False
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 50
        '
        'NOMBRE
        '
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Width = 210
        '
        'chk_inluye_rubro
        '
        Me.chk_inluye_rubro.AutoSize = True
        Me.chk_inluye_rubro.Location = New System.Drawing.Point(337, 335)
        Me.chk_inluye_rubro.Name = "chk_inluye_rubro"
        Me.chk_inluye_rubro.Size = New System.Drawing.Size(86, 17)
        Me.chk_inluye_rubro.TabIndex = 25
        Me.chk_inluye_rubro.Text = "Incluir rubros"
        Me.chk_inluye_rubro.UseVisualStyleBackColor = True
        '
        'opt_rubro
        '
        Me.opt_rubro.AutoSize = True
        Me.opt_rubro.Location = New System.Drawing.Point(229, 338)
        Me.opt_rubro.Name = "opt_rubro"
        Me.opt_rubro.Size = New System.Drawing.Size(15, 14)
        Me.opt_rubro.TabIndex = 7
        Me.opt_rubro.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(93, 337)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Agrupar x Rubro"
        '
        'cmb_ordena
        '
        Me.cmb_ordena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ordena.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ordena.FormattingEnabled = True
        Me.cmb_ordena.Items.AddRange(New Object() {"Codigo", "Alfabeticamente"})
        Me.cmb_ordena.Location = New System.Drawing.Point(229, 247)
        Me.cmb_ordena.Name = "cmb_ordena"
        Me.cmb_ordena.Size = New System.Drawing.Size(203, 23)
        Me.cmb_ordena.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(93, 247)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Ordenacion"
        '
        'lbl_rubro
        '
        Me.lbl_rubro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rubro.ForeColor = System.Drawing.Color.Blue
        Me.lbl_rubro.Location = New System.Drawing.Point(441, 111)
        Me.lbl_rubro.Name = "lbl_rubro"
        Me.lbl_rubro.Size = New System.Drawing.Size(280, 20)
        Me.lbl_rubro.TabIndex = 14
        '
        'lbl_prov
        '
        Me.lbl_prov.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prov.ForeColor = System.Drawing.Color.Blue
        Me.lbl_prov.Location = New System.Drawing.Point(441, 69)
        Me.lbl_prov.Name = "lbl_prov"
        Me.lbl_prov.Size = New System.Drawing.Size(280, 20)
        Me.lbl_prov.TabIndex = 13
        '
        'lbl_lista
        '
        Me.lbl_lista.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lista.ForeColor = System.Drawing.Color.Blue
        Me.lbl_lista.Location = New System.Drawing.Point(438, 29)
        Me.lbl_lista.Name = "lbl_lista"
        Me.lbl_lista.Size = New System.Drawing.Size(283, 20)
        Me.lbl_lista.TabIndex = 12
        '
        'cmb_estado
        '
        Me.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"Activo", "Baja"})
        Me.cmb_estado.Location = New System.Drawing.Point(229, 293)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(203, 23)
        Me.cmb_estado.TabIndex = 6
        '
        'dt_fec_hasta
        '
        Me.dt_fec_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_hasta.Location = New System.Drawing.Point(229, 202)
        Me.dt_fec_hasta.Name = "dt_fec_hasta"
        Me.dt_fec_hasta.Size = New System.Drawing.Size(203, 20)
        Me.dt_fec_hasta.TabIndex = 4
        '
        'dt_fec_desde
        '
        Me.dt_fec_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_desde.Location = New System.Drawing.Point(229, 155)
        Me.dt_fec_desde.Name = "dt_fec_desde"
        Me.dt_fec_desde.Size = New System.Drawing.Size(203, 20)
        Me.dt_fec_desde.TabIndex = 3
        Me.dt_fec_desde.Value = New Date(2008, 12, 1, 0, 0, 0, 0)
        '
        'txt_cod_rub
        '
        Me.txt_cod_rub.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_rub.Location = New System.Drawing.Point(229, 111)
        Me.txt_cod_rub.Name = "txt_cod_rub"
        Me.txt_cod_rub.Size = New System.Drawing.Size(203, 21)
        Me.txt_cod_rub.TabIndex = 2
        Me.txt_cod_rub.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_prov
        '
        Me.txt_cod_prov.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_prov.Location = New System.Drawing.Point(229, 69)
        Me.txt_cod_prov.Name = "txt_cod_prov"
        Me.txt_cod_prov.Size = New System.Drawing.Size(203, 21)
        Me.txt_cod_prov.TabIndex = 1
        Me.txt_cod_prov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_list
        '
        Me.txt_cod_list.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_list.Location = New System.Drawing.Point(229, 28)
        Me.txt_cod_list.Name = "txt_cod_list"
        Me.txt_cod_list.Size = New System.Drawing.Size(203, 21)
        Me.txt_cod_list.TabIndex = 0
        Me.txt_cod_list.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(93, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Fecha Desde:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(93, 294)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Estado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Rubro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(93, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Proveedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Lista"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(785, 394)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Precios Desactualizados"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_dias_a_revisar)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(772, 377)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_dias_a_revisar
        '
        Me.txt_dias_a_revisar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dias_a_revisar.Location = New System.Drawing.Point(236, 25)
        Me.txt_dias_a_revisar.Name = "txt_dias_a_revisar"
        Me.txt_dias_a_revisar.Size = New System.Drawing.Size(85, 21)
        Me.txt_dias_a_revisar.TabIndex = 2
        Me.txt_dias_a_revisar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cantidad dias a revisar:"
        '
        'Form_reporte_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(790, 534)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_acepta1)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_reporte_precios"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes de Articulos/precios"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_acepta1 As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chk_inluye_rubro As System.Windows.Forms.CheckBox
    Friend WithEvents opt_rubro As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_ordena As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_rubro As System.Windows.Forms.Label
    Friend WithEvents lbl_prov As System.Windows.Forms.Label
    Friend WithEvents lbl_lista As System.Windows.Forms.Label
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents dt_fec_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_cod_rub As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_prov As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_list As mitextbox1.texto_solonum
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_dias_a_revisar As mitextbox1.texto_solonum
End Class
