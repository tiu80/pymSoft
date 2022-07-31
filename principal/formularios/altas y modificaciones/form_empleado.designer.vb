<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_empleado
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_empleado))
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Codigo_Barra = New System.Windows.Forms.Label
        Me.txt_legajo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_dni = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_foto = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.cmd_busca_foto = New System.Windows.Forms.Button
        Me.cmd_imprime_tar = New System.Windows.Forms.Button
        Me.txt_busca_empl = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmb_calcula_horas_noct = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmb_sector = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmd_imprime_qr = New System.Windows.Forms.Button
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chk_todos = New System.Windows.Forms.CheckBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Code EAN13", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(82, 563)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(195, 84)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Black
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.Yellow
        Me.btnGenerar.Location = New System.Drawing.Point(402, 563)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(147, 84)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Actualizar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Codigo_Barra
        '
        Me.Codigo_Barra.AutoSize = True
        Me.Codigo_Barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigo_Barra.Location = New System.Drawing.Point(7, 16)
        Me.Codigo_Barra.Name = "Codigo_Barra"
        Me.Codigo_Barra.Size = New System.Drawing.Size(63, 16)
        Me.Codigo_Barra.TabIndex = 7
        Me.Codigo_Barra.Text = "LEGAJO:"
        '
        'txt_legajo
        '
        Me.txt_legajo.BackColor = System.Drawing.Color.White
        Me.txt_legajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_legajo.Location = New System.Drawing.Point(110, 13)
        Me.txt_legajo.MaxLength = 20
        Me.txt_legajo.Name = "txt_legajo"
        Me.txt_legajo.Size = New System.Drawing.Size(116, 24)
        Me.txt_legajo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "NOMBRE:"
        '
        'txt_nombre
        '
        Me.txt_nombre.BackColor = System.Drawing.Color.White
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(110, 51)
        Me.txt_nombre.MaxLength = 50
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(266, 24)
        Me.txt_nombre.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "DIRECCION:"
        '
        'txt_direccion
        '
        Me.txt_direccion.BackColor = System.Drawing.Color.White
        Me.txt_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.Location = New System.Drawing.Point(110, 88)
        Me.txt_direccion.MaxLength = 40
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(266, 24)
        Me.txt_direccion.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "TELEFONO:"
        '
        'txt_telefono
        '
        Me.txt_telefono.BackColor = System.Drawing.Color.White
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.Location = New System.Drawing.Point(110, 125)
        Me.txt_telefono.MaxLength = 12
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(190, 24)
        Me.txt_telefono.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "D.N.I:"
        '
        'txt_dni
        '
        Me.txt_dni.BackColor = System.Drawing.Color.White
        Me.txt_dni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dni.Location = New System.Drawing.Point(110, 162)
        Me.txt_dni.Name = "txt_dni"
        Me.txt_dni.Size = New System.Drawing.Size(190, 24)
        Me.txt_dni.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "FOTO:"
        '
        'txt_foto
        '
        Me.txt_foto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_foto.Location = New System.Drawing.Point(110, 198)
        Me.txt_foto.MaxLength = 254
        Me.txt_foto.Multiline = True
        Me.txt_foto.Name = "txt_foto"
        Me.txt_foto.Size = New System.Drawing.Size(201, 52)
        Me.txt_foto.TabIndex = 17
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(402, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(607, 506)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(110, 403)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 153)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 584)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 42)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "CODIGO BARRA"
        '
        'OpenFileDialog1
        '
        '
        'cmd_busca_foto
        '
        Me.cmd_busca_foto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmd_busca_foto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_busca_foto.Location = New System.Drawing.Point(320, 215)
        Me.cmd_busca_foto.Name = "cmd_busca_foto"
        Me.cmd_busca_foto.Size = New System.Drawing.Size(59, 21)
        Me.cmd_busca_foto.TabIndex = 20
        Me.cmd_busca_foto.Text = "...."
        Me.cmd_busca_foto.UseVisualStyleBackColor = False
        '
        'cmd_imprime_tar
        '
        Me.cmd_imprime_tar.BackColor = System.Drawing.Color.Black
        Me.cmd_imprime_tar.FlatAppearance.BorderSize = 0
        Me.cmd_imprime_tar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_imprime_tar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_imprime_tar.Location = New System.Drawing.Point(712, 563)
        Me.cmd_imprime_tar.Name = "cmd_imprime_tar"
        Me.cmd_imprime_tar.Size = New System.Drawing.Size(147, 84)
        Me.cmd_imprime_tar.TabIndex = 21
        Me.cmd_imprime_tar.Text = "Imprimir tarjeta"
        Me.cmd_imprime_tar.UseVisualStyleBackColor = False
        '
        'txt_busca_empl
        '
        Me.txt_busca_empl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_busca_empl.Location = New System.Drawing.Point(402, 7)
        Me.txt_busca_empl.Name = "txt_busca_empl"
        Me.txt_busca_empl.Size = New System.Drawing.Size(533, 31)
        Me.txt_busca_empl.TabIndex = 999
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(323, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "BUSCAR:"
        '
        'cmb_calcula_horas_noct
        '
        Me.cmb_calcula_horas_noct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_calcula_horas_noct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_calcula_horas_noct.FormattingEnabled = True
        Me.cmb_calcula_horas_noct.Items.AddRange(New Object() {"NO", "SI"})
        Me.cmb_calcula_horas_noct.Location = New System.Drawing.Point(110, 314)
        Me.cmb_calcula_horas_noct.Name = "cmb_calcula_horas_noct"
        Me.cmb_calcula_horas_noct.Size = New System.Drawing.Size(86, 28)
        Me.cmb_calcula_horas_noct.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 307)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 54)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "CALCULA HORAS NOCTURNAS:"
        '
        'cmb_sector
        '
        Me.cmb_sector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sector.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_sector.FormattingEnabled = True
        Me.cmb_sector.Items.AddRange(New Object() {"Administracion", "Repartos", "Ventas"})
        Me.cmb_sector.Location = New System.Drawing.Point(110, 266)
        Me.cmb_sector.Name = "cmb_sector"
        Me.cmb_sector.Size = New System.Drawing.Size(201, 28)
        Me.cmb_sector.Sorted = True
        Me.cmb_sector.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "SECTOR:"
        '
        'cmd_imprime_qr
        '
        Me.cmd_imprime_qr.BackColor = System.Drawing.Color.Black
        Me.cmd_imprime_qr.FlatAppearance.BorderSize = 0
        Me.cmd_imprime_qr.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_imprime_qr.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_imprime_qr.Location = New System.Drawing.Point(859, 563)
        Me.cmd_imprime_qr.Name = "cmd_imprime_qr"
        Me.cmd_imprime_qr.Size = New System.Drawing.Size(147, 84)
        Me.cmd_imprime_qr.TabIndex = 32
        Me.cmd_imprime_qr.Text = "Imprimir QR"
        Me.cmd_imprime_qr.UseVisualStyleBackColor = False
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(283, 563)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(100, 63)
        Me.QrCodeImgControl1.TabIndex = 33
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.FlatAppearance.BorderSize = 0
        Me.cmd_eliminar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(550, 563)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(147, 84)
        Me.cmd_eliminar.TabIndex = 1000
        Me.cmd_eliminar.Text = "Borrar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'cmb_estado
        '
        Me.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"Alta", "Baja"})
        Me.cmb_estado.Location = New System.Drawing.Point(110, 366)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(86, 28)
        Me.cmb_estado.TabIndex = 1002
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 372)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 18)
        Me.Label8.TabIndex = 1001
        Me.Label8.Text = "ESTADO:"
        '
        'chk_todos
        '
        Me.chk_todos.AutoSize = True
        Me.chk_todos.Location = New System.Drawing.Point(944, 17)
        Me.chk_todos.Name = "chk_todos"
        Me.chk_todos.Size = New System.Drawing.Size(56, 17)
        Me.chk_todos.TabIndex = 1003
        Me.chk_todos.Text = "Todos"
        Me.chk_todos.UseVisualStyleBackColor = True
        '
        'form_empleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1009, 655)
        Me.Controls.Add(Me.chk_todos)
        Me.Controls.Add(Me.cmb_estado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.QrCodeImgControl1)
        Me.Controls.Add(Me.cmd_imprime_qr)
        Me.Controls.Add(Me.cmb_sector)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmb_calcula_horas_noct)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_busca_empl)
        Me.Controls.Add(Me.cmd_imprime_tar)
        Me.Controls.Add(Me.cmd_busca_foto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txt_foto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_dni)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.Codigo_Barra)
        Me.Controls.Add(Me.txt_legajo)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.lblCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "form_empleado"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMPLEADOS"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Codigo_Barra As System.Windows.Forms.Label
    Friend WithEvents txt_legajo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_dni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_foto As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmd_busca_foto As System.Windows.Forms.Button
    Friend WithEvents cmd_imprime_tar As System.Windows.Forms.Button
    Friend WithEvents txt_busca_empl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_calcula_horas_noct As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmb_sector As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmd_imprime_qr As System.Windows.Forms.Button
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chk_todos As System.Windows.Forms.CheckBox
End Class
