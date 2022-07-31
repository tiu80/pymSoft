<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_inventario))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dt_corte_inicia = New System.Windows.Forms.DateTimePicker
        Me.opt_inicia1 = New System.Windows.Forms.RadioButton
        Me.opt_inicia = New System.Windows.Forms.RadioButton
        Me.cmd_inicia = New System.Windows.Forms.Button
        Me.cmd_inicializa = New System.Windows.Forms.Button
        Me.dt_fec_corte = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_alta = New System.Windows.Forms.DateTimePicker
        Me.stk_actual = New mitextbox1.texto_solonum
        Me.txt_stk_ant = New mitextbox1.texto_solonum
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.lbl_articulo = New System.Windows.Forms.Label
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.cmd_actualiza = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbl_lista = New System.Windows.Forms.Label
        Me.Check_stc_actual = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbl_acu = New System.Windows.Forms.Label
        Me.lbl_total = New System.Windows.Forms.Label
        Me.lbl_avance = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.dt_fec_corte)
        Me.GroupBox2.Controls.Add(Me.dt_fec_alta)
        Me.GroupBox2.Controls.Add(Me.stk_actual)
        Me.GroupBox2.Controls.Add(Me.txt_stk_ant)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 207)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dt_corte_inicia)
        Me.GroupBox1.Controls.Add(Me.opt_inicia1)
        Me.GroupBox1.Controls.Add(Me.opt_inicia)
        Me.GroupBox1.Controls.Add(Me.cmd_inicia)
        Me.GroupBox1.Controls.Add(Me.cmd_inicializa)
        Me.GroupBox1.Location = New System.Drawing.Point(279, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 174)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Fecha corte Inicializacion:"
        '
        'dt_corte_inicia
        '
        Me.dt_corte_inicia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_corte_inicia.Location = New System.Drawing.Point(187, 24)
        Me.dt_corte_inicia.Name = "dt_corte_inicia"
        Me.dt_corte_inicia.Size = New System.Drawing.Size(108, 20)
        Me.dt_corte_inicia.TabIndex = 6
        '
        'opt_inicia1
        '
        Me.opt_inicia1.AutoSize = True
        Me.opt_inicia1.Location = New System.Drawing.Point(14, 128)
        Me.opt_inicia1.Name = "opt_inicia1"
        Me.opt_inicia1.Size = New System.Drawing.Size(164, 17)
        Me.opt_inicia1.TabIndex = 5
        Me.opt_inicia1.TabStop = True
        Me.opt_inicia1.Text = "Inicializa corte de stock si = 0"
        Me.opt_inicia1.UseVisualStyleBackColor = True
        '
        'opt_inicia
        '
        Me.opt_inicia.AutoSize = True
        Me.opt_inicia.Location = New System.Drawing.Point(14, 75)
        Me.opt_inicia.Name = "opt_inicia"
        Me.opt_inicia.Size = New System.Drawing.Size(121, 17)
        Me.opt_inicia.TabIndex = 4
        Me.opt_inicia.TabStop = True
        Me.opt_inicia.Text = "Inicializa corte stock"
        Me.opt_inicia.UseVisualStyleBackColor = True
        '
        'cmd_inicia
        '
        Me.cmd_inicia.BackColor = System.Drawing.Color.Black
        Me.cmd_inicia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_inicia.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_inicia.Location = New System.Drawing.Point(192, 122)
        Me.cmd_inicia.Name = "cmd_inicia"
        Me.cmd_inicia.Size = New System.Drawing.Size(103, 29)
        Me.cmd_inicia.TabIndex = 3
        Me.cmd_inicia.Text = "Iniciar"
        Me.cmd_inicia.UseVisualStyleBackColor = False
        '
        'cmd_inicializa
        '
        Me.cmd_inicializa.BackColor = System.Drawing.Color.Black
        Me.cmd_inicializa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_inicializa.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_inicializa.Location = New System.Drawing.Point(192, 69)
        Me.cmd_inicializa.Name = "cmd_inicializa"
        Me.cmd_inicializa.Size = New System.Drawing.Size(103, 29)
        Me.cmd_inicializa.TabIndex = 1
        Me.cmd_inicializa.Text = "Iniciar"
        Me.cmd_inicializa.UseVisualStyleBackColor = False
        '
        'dt_fec_corte
        '
        Me.dt_fec_corte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_corte.Location = New System.Drawing.Point(139, 162)
        Me.dt_fec_corte.Name = "dt_fec_corte"
        Me.dt_fec_corte.Size = New System.Drawing.Size(108, 20)
        Me.dt_fec_corte.TabIndex = 5
        '
        'dt_fec_alta
        '
        Me.dt_fec_alta.Enabled = False
        Me.dt_fec_alta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_alta.Location = New System.Drawing.Point(139, 109)
        Me.dt_fec_alta.Name = "dt_fec_alta"
        Me.dt_fec_alta.Size = New System.Drawing.Size(108, 20)
        Me.dt_fec_alta.TabIndex = 4
        '
        'stk_actual
        '
        Me.stk_actual.Enabled = False
        Me.stk_actual.Location = New System.Drawing.Point(139, 60)
        Me.stk_actual.Name = "stk_actual"
        Me.stk_actual.Size = New System.Drawing.Size(90, 20)
        Me.stk_actual.TabIndex = 3
        Me.stk_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_stk_ant
        '
        Me.txt_stk_ant.Enabled = False
        Me.txt_stk_ant.Location = New System.Drawing.Point(139, 17)
        Me.txt_stk_ant.Name = "txt_stk_ant"
        Me.txt_stk_ant.Size = New System.Drawing.Size(90, 20)
        Me.txt_stk_ant.TabIndex = 2
        Me.txt_stk_ant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha Corte:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha Alta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Stock Actual:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Stock Anterior:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Codigo Articulo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(448, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 72)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Inventario"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(151, 91)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(90, 20)
        Me.txt_codigo.TabIndex = 0
        Me.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_articulo
        '
        Me.lbl_articulo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_articulo.ForeColor = System.Drawing.Color.Red
        Me.lbl_articulo.Location = New System.Drawing.Point(44, 119)
        Me.lbl_articulo.Name = "lbl_articulo"
        Me.lbl_articulo.Size = New System.Drawing.Size(345, 18)
        Me.lbl_articulo.TabIndex = 17
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.BackColor = System.Drawing.Color.Black
        Me.cmd_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancelar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancelar.Location = New System.Drawing.Point(460, 13)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(128, 54)
        Me.cmd_cancelar.TabIndex = 7
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.UseVisualStyleBackColor = False
        '
        'cmd_actualiza
        '
        Me.cmd_actualiza.BackColor = System.Drawing.Color.Black
        Me.cmd_actualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualiza.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualiza.Location = New System.Drawing.Point(18, 13)
        Me.cmd_actualiza.Name = "cmd_actualiza"
        Me.cmd_actualiza.Size = New System.Drawing.Size(128, 54)
        Me.cmd_actualiza.TabIndex = 6
        Me.cmd_actualiza.Text = "Actualizar"
        Me.cmd_actualiza.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(164, 18)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(77, 20)
        Me.txt_estado_form.TabIndex = 20
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(401, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 72)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'lbl_lista
        '
        Me.lbl_lista.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lista.ForeColor = System.Drawing.Color.Black
        Me.lbl_lista.Location = New System.Drawing.Point(253, 72)
        Me.lbl_lista.Name = "lbl_lista"
        Me.lbl_lista.Size = New System.Drawing.Size(289, 18)
        Me.lbl_lista.TabIndex = 24
        '
        'Check_stc_actual
        '
        Me.Check_stc_actual.AutoSize = True
        Me.Check_stc_actual.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_stc_actual.Location = New System.Drawing.Point(305, 89)
        Me.Check_stc_actual.Name = "Check_stc_actual"
        Me.Check_stc_actual.Size = New System.Drawing.Size(136, 19)
        Me.Check_stc_actual.TabIndex = 25
        Me.Check_stc_actual.Text = "Habilita Stock Actual"
        Me.Check_stc_actual.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmd_cancelar)
        Me.GroupBox3.Controls.Add(Me.cmd_actualiza)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 353)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(605, 75)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Yellow
        Me.Button1.Location = New System.Drawing.Point(514, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 36)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Iguala stock arriba con debajo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lbl_acu
        '
        Me.lbl_acu.AutoSize = True
        Me.lbl_acu.Location = New System.Drawing.Point(606, 131)
        Me.lbl_acu.Name = "lbl_acu"
        Me.lbl_acu.Size = New System.Drawing.Size(13, 13)
        Me.lbl_acu.TabIndex = 30
        Me.lbl_acu.Text = "0"
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(562, 131)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(13, 13)
        Me.lbl_total.TabIndex = 29
        Me.lbl_total.Text = "0"
        '
        'lbl_avance
        '
        Me.lbl_avance.AutoSize = True
        Me.lbl_avance.Location = New System.Drawing.Point(513, 131)
        Me.lbl_avance.Name = "lbl_avance"
        Me.lbl_avance.Size = New System.Drawing.Size(13, 13)
        Me.lbl_avance.TabIndex = 28
        Me.lbl_avance.Text = "0"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Yellow
        Me.Button2.Location = New System.Drawing.Point(515, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 36)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Corrige defasaje"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Form_inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(632, 436)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lbl_acu)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lbl_avance)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Check_stc_actual)
        Me.Controls.Add(Me.lbl_lista)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.lbl_articulo)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_inventario"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTARIO"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_stk_ant As mitextbox1.texto_solonum
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents dt_fec_corte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_alta As System.Windows.Forms.DateTimePicker
    Friend WithEvents stk_actual As mitextbox1.texto_solonum
    Friend WithEvents lbl_articulo As System.Windows.Forms.Label
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents cmd_actualiza As System.Windows.Forms.Button
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_inicializa As System.Windows.Forms.Button
    Friend WithEvents cmd_inicia As System.Windows.Forms.Button
    Friend WithEvents opt_inicia1 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_inicia As System.Windows.Forms.RadioButton
    Friend WithEvents dt_corte_inicia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_lista As System.Windows.Forms.Label
    Friend WithEvents Check_stc_actual As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl_acu As System.Windows.Forms.Label
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents lbl_avance As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
