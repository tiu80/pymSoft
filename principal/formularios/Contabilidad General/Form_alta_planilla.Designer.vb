<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_alta_planilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_alta_planilla))
        Me.cmd_guardar = New System.Windows.Forms.Button
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_cod_interno = New System.Windows.Forms.TextBox
        Me.txt_cod_pllanilla = New mitextbox1.texto_solonum
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_numero_palnilla = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_nom_cta = New System.Windows.Forms.Label
        Me.txt_saldo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dt_fec_fin = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_ini = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_cuenta = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_n_comprobante = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_desc_asiento = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_actualiza = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_guardar
        '
        Me.cmd_guardar.BackColor = System.Drawing.Color.Black
        Me.cmd_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_guardar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_guardar.Location = New System.Drawing.Point(16, 470)
        Me.cmd_guardar.Name = "cmd_guardar"
        Me.cmd_guardar.Size = New System.Drawing.Size(139, 56)
        Me.cmd_guardar.TabIndex = 10
        Me.cmd_guardar.Text = "Guardar"
        Me.cmd_guardar.UseVisualStyleBackColor = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(640, 470)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(135, 53)
        Me.cmd_eliminar.TabIndex = 12
        Me.cmd_eliminar.Text = "Borrar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(576, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(632, -4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 62)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "ALTA PLANILLA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txt_cod_interno)
        Me.GroupBox1.Controls.Add(Me.txt_cod_pllanilla)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_numero_palnilla)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(-3, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_cod_interno
        '
        Me.txt_cod_interno.Location = New System.Drawing.Point(494, 48)
        Me.txt_cod_interno.Name = "txt_cod_interno"
        Me.txt_cod_interno.Size = New System.Drawing.Size(39, 20)
        Me.txt_cod_interno.TabIndex = 53
        Me.txt_cod_interno.Visible = False
        '
        'txt_cod_pllanilla
        '
        Me.txt_cod_pllanilla.BackColor = System.Drawing.Color.White
        Me.txt_cod_pllanilla.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_pllanilla.Location = New System.Drawing.Point(240, 48)
        Me.txt_cod_pllanilla.MaxLength = 9
        Me.txt_cod_pllanilla.Name = "txt_cod_pllanilla"
        Me.txt_cod_pllanilla.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_cod_pllanilla.Size = New System.Drawing.Size(238, 22)
        Me.txt_cod_pllanilla.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Ejercicio Contable:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(93, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Codigo Planilla:"
        '
        'txt_numero_palnilla
        '
        Me.txt_numero_palnilla.BackColor = System.Drawing.Color.White
        Me.txt_numero_palnilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_palnilla.Location = New System.Drawing.Point(240, 79)
        Me.txt_numero_palnilla.Name = "txt_numero_palnilla"
        Me.txt_numero_palnilla.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_numero_palnilla.Size = New System.Drawing.Size(238, 21)
        Me.txt_numero_palnilla.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Numero Planilla:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.lbl_nom_cta)
        Me.GroupBox2.Controls.Add(Me.txt_saldo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.dt_fec_fin)
        Me.GroupBox2.Controls.Add(Me.dt_fec_ini)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_cuenta)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txt_n_comprobante)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_descripcion)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_desc_asiento)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(-3, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(787, 294)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lbl_nom_cta
        '
        Me.lbl_nom_cta.AutoSize = True
        Me.lbl_nom_cta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom_cta.ForeColor = System.Drawing.Color.Red
        Me.lbl_nom_cta.Location = New System.Drawing.Point(492, 137)
        Me.lbl_nom_cta.Name = "lbl_nom_cta"
        Me.lbl_nom_cta.Size = New System.Drawing.Size(0, 15)
        Me.lbl_nom_cta.TabIndex = 64
        '
        'txt_saldo
        '
        Me.txt_saldo.BackColor = System.Drawing.Color.White
        Me.txt_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_saldo.Location = New System.Drawing.Point(239, 259)
        Me.txt_saldo.Name = "txt_saldo"
        Me.txt_saldo.Size = New System.Drawing.Size(238, 21)
        Me.txt_saldo.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(92, 260)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(74, 15)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Saldo Incial:"
        '
        'dt_fec_fin
        '
        Me.dt_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_fin.Location = New System.Drawing.Point(239, 218)
        Me.dt_fec_fin.Name = "dt_fec_fin"
        Me.dt_fec_fin.Size = New System.Drawing.Size(238, 20)
        Me.dt_fec_fin.TabIndex = 8
        '
        'dt_fec_ini
        '
        Me.dt_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_ini.Location = New System.Drawing.Point(239, 176)
        Me.dt_fec_ini.Name = "dt_fec_ini"
        Me.dt_fec_ini.Size = New System.Drawing.Size(238, 20)
        Me.dt_fec_ini.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(92, 218)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Fecha fin:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(92, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(76, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Fecha inicio:"
        '
        'txt_cuenta
        '
        Me.txt_cuenta.BackColor = System.Drawing.Color.White
        Me.txt_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cuenta.Location = New System.Drawing.Point(239, 134)
        Me.txt_cuenta.Name = "txt_cuenta"
        Me.txt_cuenta.Size = New System.Drawing.Size(238, 21)
        Me.txt_cuenta.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(92, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(49, 15)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Cuenta:"
        '
        'txt_n_comprobante
        '
        Me.txt_n_comprobante.BackColor = System.Drawing.Color.White
        Me.txt_n_comprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_n_comprobante.Location = New System.Drawing.Point(239, 92)
        Me.txt_n_comprobante.Name = "txt_n_comprobante"
        Me.txt_n_comprobante.Size = New System.Drawing.Size(238, 21)
        Me.txt_n_comprobante.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(92, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(64, 15)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Nº Interno:"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(239, 18)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(238, 21)
        Me.txt_descripcion.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Descripcion:"
        '
        'txt_desc_asiento
        '
        Me.txt_desc_asiento.BackColor = System.Drawing.Color.White
        Me.txt_desc_asiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_asiento.Location = New System.Drawing.Point(239, 55)
        Me.txt_desc_asiento.Name = "txt_desc_asiento"
        Me.txt_desc_asiento.Size = New System.Drawing.Size(238, 21)
        Me.txt_desc_asiento.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(92, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(118, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Descripcion Asiento:"
        '
        'cmd_actualiza
        '
        Me.cmd_actualiza.BackColor = System.Drawing.Color.Black
        Me.cmd_actualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualiza.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualiza.Location = New System.Drawing.Point(325, 470)
        Me.cmd_actualiza.Name = "cmd_actualiza"
        Me.cmd_actualiza.Size = New System.Drawing.Size(139, 53)
        Me.cmd_actualiza.TabIndex = 11
        Me.cmd_actualiza.Text = "Actualizar"
        Me.cmd_actualiza.UseVisualStyleBackColor = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(12, 18)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(41, 20)
        Me.txt_estado_form.TabIndex = 56
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Form_alta_planilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_actualiza)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmd_guardar)
        Me.Controls.Add(Me.cmd_eliminar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_alta_planilla"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALTA PLANILLA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_guardar As System.Windows.Forms.Button
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_numero_palnilla As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_desc_asiento As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_n_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_saldo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmd_actualiza As System.Windows.Forms.Button
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nom_cta As System.Windows.Forms.Label
    Friend WithEvents txt_cod_pllanilla As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_interno As System.Windows.Forms.TextBox
End Class
