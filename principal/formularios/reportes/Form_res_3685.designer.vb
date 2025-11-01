<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_res_3685
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_res_3685))
        Me.cmd_guardar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_path = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_cargo = New System.Windows.Forms.ComboBox
        Me.txt_dni_agente = New System.Windows.Forms.TextBox
        Me.txt_apellido_agente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmd_presenta = New System.Windows.Forms.ComboBox
        Me.cmd_mes = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmd_año = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.opt_venta = New System.Windows.Forms.RadioButton
        Me.opt_compra = New System.Windows.Forms.RadioButton
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.chk_iva_digital = New System.Windows.Forms.CheckBox
        Me.cmd_exporta_excel = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_guardar
        '
        Me.cmd_guardar.Location = New System.Drawing.Point(577, 370)
        Me.cmd_guardar.Name = "cmd_guardar"
        Me.cmd_guardar.Size = New System.Drawing.Size(53, 23)
        Me.cmd_guardar.TabIndex = 39
        Me.cmd_guardar.Text = "...."
        Me.cmd_guardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(107, 375)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "GUARDAR EN:"
        '
        'txt_path
        '
        Me.txt_path.Location = New System.Drawing.Point(308, 372)
        Me.txt_path.Name = "txt_path"
        Me.txt_path.ReadOnly = True
        Me.txt_path.Size = New System.Drawing.Size(263, 20)
        Me.txt_path.TabIndex = 41
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Yellow
        Me.Button1.Location = New System.Drawing.Point(218, 505)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(315, 70)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "GENERAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_cargo)
        Me.GroupBox1.Controls.Add(Me.txt_dni_agente)
        Me.GroupBox1.Controls.Add(Me.txt_apellido_agente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(28, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 125)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Persona:"
        '
        'cmb_cargo
        '
        Me.cmb_cargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_cargo.ForeColor = System.Drawing.Color.Red
        Me.cmb_cargo.FormattingEnabled = True
        Me.cmb_cargo.Items.AddRange(New Object() {"APODERADO", "EMPLEADO"})
        Me.cmb_cargo.Location = New System.Drawing.Point(278, 90)
        Me.cmb_cargo.Name = "cmb_cargo"
        Me.cmb_cargo.Size = New System.Drawing.Size(210, 21)
        Me.cmb_cargo.TabIndex = 2
        '
        'txt_dni_agente
        '
        Me.txt_dni_agente.Location = New System.Drawing.Point(278, 55)
        Me.txt_dni_agente.MaxLength = 8
        Me.txt_dni_agente.Name = "txt_dni_agente"
        Me.txt_dni_agente.Size = New System.Drawing.Size(210, 20)
        Me.txt_dni_agente.TabIndex = 1
        '
        'txt_apellido_agente
        '
        Me.txt_apellido_agente.Location = New System.Drawing.Point(278, 19)
        Me.txt_apellido_agente.MaxLength = 40
        Me.txt_apellido_agente.Name = "txt_apellido_agente"
        Me.txt_apellido_agente.Size = New System.Drawing.Size(335, 20)
        Me.txt_apellido_agente.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(79, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "CARGO DEL RESPONSABLE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(79, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "D.N.I. DEL RESPONSABLE:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "APELLIDO Y NOMBRE DEL RESPONSABLE:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmd_presenta)
        Me.GroupBox2.Controls.Add(Me.cmd_mes)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cmd_año)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(28, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(750, 141)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Empresa:"
        '
        'cmd_presenta
        '
        Me.cmd_presenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmd_presenta.ForeColor = System.Drawing.Color.Red
        Me.cmd_presenta.FormattingEnabled = True
        Me.cmd_presenta.Items.AddRange(New Object() {"0- ORIGINAL" & Global.Microsoft.VisualBasic.ChrW(9), "1- RESTRICTIVA", "2- RESTRICTIVA", "3- RESTRICTIVA", "4- RESTRICTIVA", "5- RESTRICTIVA", "6- RESTRICTIVA", "7- RESTRICTIVA", "8- RESTRICTIVA", "9- RESTRICTIVA"})
        Me.cmd_presenta.Location = New System.Drawing.Point(276, 94)
        Me.cmd_presenta.Name = "cmd_presenta"
        Me.cmd_presenta.Size = New System.Drawing.Size(169, 21)
        Me.cmd_presenta.TabIndex = 6
        '
        'cmd_mes
        '
        Me.cmd_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmd_mes.ForeColor = System.Drawing.Color.Red
        Me.cmd_mes.FormattingEnabled = True
        Me.cmd_mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmd_mes.Location = New System.Drawing.Point(274, 36)
        Me.cmd_mes.Name = "cmd_mes"
        Me.cmd_mes.Size = New System.Drawing.Size(75, 21)
        Me.cmd_mes.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(79, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "PRESENTA"
        '
        'cmd_año
        '
        Me.cmd_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmd_año.ForeColor = System.Drawing.Color.Red
        Me.cmd_año.FormattingEnabled = True
        Me.cmd_año.Items.AddRange(New Object() {"2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043"})
        Me.cmd_año.Location = New System.Drawing.Point(361, 36)
        Me.cmd_año.Name = "cmd_año"
        Me.cmd_año.Size = New System.Drawing.Size(88, 21)
        Me.cmd_año.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(79, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "PERIODO:"
        '
        'opt_venta
        '
        Me.opt_venta.AutoSize = True
        Me.opt_venta.Checked = True
        Me.opt_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_venta.ForeColor = System.Drawing.Color.Black
        Me.opt_venta.Location = New System.Drawing.Point(433, 34)
        Me.opt_venta.Name = "opt_venta"
        Me.opt_venta.Size = New System.Drawing.Size(68, 19)
        Me.opt_venta.TabIndex = 44
        Me.opt_venta.TabStop = True
        Me.opt_venta.Text = "Ventas"
        Me.opt_venta.UseVisualStyleBackColor = True
        '
        'opt_compra
        '
        Me.opt_compra.AutoSize = True
        Me.opt_compra.Enabled = False
        Me.opt_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_compra.ForeColor = System.Drawing.Color.Black
        Me.opt_compra.Location = New System.Drawing.Point(295, 34)
        Me.opt_compra.Name = "opt_compra"
        Me.opt_compra.Size = New System.Drawing.Size(82, 19)
        Me.opt_compra.TabIndex = 43
        Me.opt_compra.Text = "Compras"
        Me.opt_compra.UseVisualStyleBackColor = True
        '
        'chk_iva_digital
        '
        Me.chk_iva_digital.AutoSize = True
        Me.chk_iva_digital.Location = New System.Drawing.Point(309, 437)
        Me.chk_iva_digital.Name = "chk_iva_digital"
        Me.chk_iva_digital.Size = New System.Drawing.Size(122, 17)
        Me.chk_iva_digital.TabIndex = 45
        Me.chk_iva_digital.Text = "Formato I.V.A Digital"
        Me.chk_iva_digital.UseVisualStyleBackColor = True
        '
        'cmd_exporta_excel
        '
        Me.cmd_exporta_excel.BackgroundImage = CType(resources.GetObject("cmd_exporta_excel.BackgroundImage"), System.Drawing.Image)
        Me.cmd_exporta_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_exporta_excel.FlatAppearance.BorderSize = 0
        Me.cmd_exporta_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_exporta_excel.Location = New System.Drawing.Point(746, 21)
        Me.cmd_exporta_excel.Name = "cmd_exporta_excel"
        Me.cmd_exporta_excel.Size = New System.Drawing.Size(32, 32)
        Me.cmd_exporta_excel.TabIndex = 46
        Me.cmd_exporta_excel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13})
        Me.DataGridView1.Location = New System.Drawing.Point(595, 531)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(211, 79)
        Me.DataGridView1.TabIndex = 47
        Me.DataGridView1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nombre"
        Me.Column1.Name = "Column1"
        '
        'Column19
        '
        Me.Column19.HeaderText = "cond_iva"
        Me.Column19.Name = "Column19"
        '
        'Column20
        '
        Me.Column20.HeaderText = "cuit"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "tipo_iva"
        Me.Column21.Name = "Column21"
        '
        'Column22
        '
        Me.Column22.HeaderText = "letra"
        Me.Column22.Name = "Column22"
        '
        'Column23
        '
        Me.Column23.HeaderText = "sucurs"
        Me.Column23.Name = "Column23"
        '
        'Column24
        '
        Me.Column24.HeaderText = "comprobante"
        Me.Column24.Name = "Column24"
        '
        'Column2
        '
        Me.Column2.HeaderText = "fecha"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "imp_total"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "alicuota1"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "iva1"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "neto1"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = ""
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "alicuota2"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = ""
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "iva2"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "neto2"
        Me.Column13.Name = "Column13"
        '
        'Form_res_3685
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(807, 611)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmd_exporta_excel)
        Me.Controls.Add(Me.chk_iva_digital)
        Me.Controls.Add(Me.opt_venta)
        Me.Controls.Add(Me.opt_compra)
        Me.Controls.Add(Me.cmd_guardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_path)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_res_3685"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regimen de Informacion Compras y Ventas - Res. 3685 / I.V.A Digital"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_guardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_path As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_cargo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_dni_agente As System.Windows.Forms.TextBox
    Friend WithEvents txt_apellido_agente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_presenta As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmd_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents opt_venta As System.Windows.Forms.RadioButton
    Friend WithEvents opt_compra As System.Windows.Forms.RadioButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chk_iva_digital As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exporta_excel As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
