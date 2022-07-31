<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_parametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_parametros))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_descripcion = New System.Windows.Forms.Label
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.lbl_habilita = New System.Windows.Forms.Label
        Me.opt_no = New System.Windows.Forms.RadioButton
        Me.opt_si = New System.Windows.Forms.RadioButton
        Me.txt_parametro = New mitextbox1.texto_solonum
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.cmd_borrar = New System.Windows.Forms.Button
        Me.txt_interno = New System.Windows.Forms.TextBox
        Me.txt_verifica = New System.Windows.Forms.TextBox
        Me.cmd_copiar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 80)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(487, 336)
        Me.DataGridView1.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(13, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(46, 15)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion"
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(99, 13)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(100, 20)
        Me.txt_codigo.TabIndex = 0
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Location = New System.Drawing.Point(99, 45)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(270, 20)
        Me.txt_descripcion.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_descripcion)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.lbl_habilita)
        Me.GroupBox1.Controls.Add(Me.opt_no)
        Me.GroupBox1.Controls.Add(Me.opt_si)
        Me.GroupBox1.Controls.Add(Me.txt_parametro)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 413)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 54)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'lbl_descripcion
        '
        Me.lbl_descripcion.AutoSize = True
        Me.lbl_descripcion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descripcion.ForeColor = System.Drawing.Color.Blue
        Me.lbl_descripcion.Location = New System.Drawing.Point(196, 23)
        Me.lbl_descripcion.Name = "lbl_descripcion"
        Me.lbl_descripcion.Size = New System.Drawing.Size(0, 15)
        Me.lbl_descripcion.TabIndex = 5
        Me.lbl_descripcion.Visible = False
        '
        'cmd_ok
        '
        Me.cmd_ok.BackColor = System.Drawing.Color.Black
        Me.cmd_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_ok.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_ok.Location = New System.Drawing.Point(396, 18)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(43, 23)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.UseVisualStyleBackColor = False
        Me.cmd_ok.Visible = False
        '
        'lbl_habilita
        '
        Me.lbl_habilita.AutoSize = True
        Me.lbl_habilita.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_habilita.Location = New System.Drawing.Point(10, 23)
        Me.lbl_habilita.Name = "lbl_habilita"
        Me.lbl_habilita.Size = New System.Drawing.Size(46, 15)
        Me.lbl_habilita.TabIndex = 2
        Me.lbl_habilita.Text = "Habilta"
        Me.lbl_habilita.Visible = False
        '
        'opt_no
        '
        Me.opt_no.AutoSize = True
        Me.opt_no.Checked = True
        Me.opt_no.Location = New System.Drawing.Point(119, 24)
        Me.opt_no.Name = "opt_no"
        Me.opt_no.Size = New System.Drawing.Size(41, 17)
        Me.opt_no.TabIndex = 1
        Me.opt_no.TabStop = True
        Me.opt_no.Text = "NO"
        Me.opt_no.UseVisualStyleBackColor = True
        Me.opt_no.Visible = False
        '
        'opt_si
        '
        Me.opt_si.AutoSize = True
        Me.opt_si.Location = New System.Drawing.Point(78, 24)
        Me.opt_si.Name = "opt_si"
        Me.opt_si.Size = New System.Drawing.Size(35, 17)
        Me.opt_si.TabIndex = 0
        Me.opt_si.Text = "SI"
        Me.opt_si.UseVisualStyleBackColor = True
        Me.opt_si.Visible = False
        '
        'txt_parametro
        '
        Me.txt_parametro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_parametro.Location = New System.Drawing.Point(68, 20)
        Me.txt_parametro.Name = "txt_parametro"
        Me.txt_parametro.Size = New System.Drawing.Size(92, 21)
        Me.txt_parametro.TabIndex = 4
        Me.txt_parametro.Visible = False
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.BackColor = System.Drawing.Color.Black
        Me.cmd_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_aceptar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_aceptar.Location = New System.Drawing.Point(16, 485)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(95, 35)
        Me.cmd_aceptar.TabIndex = 2
        Me.cmd_aceptar.Text = "Guardar"
        Me.cmd_aceptar.UseVisualStyleBackColor = False
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(138, 485)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(95, 35)
        Me.cmd_actualizar.TabIndex = 3
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'cmd_borrar
        '
        Me.cmd_borrar.BackColor = System.Drawing.Color.Black
        Me.cmd_borrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_borrar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_borrar.Location = New System.Drawing.Point(376, 485)
        Me.cmd_borrar.Name = "cmd_borrar"
        Me.cmd_borrar.Size = New System.Drawing.Size(95, 35)
        Me.cmd_borrar.TabIndex = 4
        Me.cmd_borrar.Text = "Borrar"
        Me.cmd_borrar.UseVisualStyleBackColor = False
        '
        'txt_interno
        '
        Me.txt_interno.Location = New System.Drawing.Point(230, 13)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(58, 20)
        Me.txt_interno.TabIndex = 6
        Me.txt_interno.Visible = False
        '
        'txt_verifica
        '
        Me.txt_verifica.Location = New System.Drawing.Point(399, 13)
        Me.txt_verifica.Name = "txt_verifica"
        Me.txt_verifica.Size = New System.Drawing.Size(43, 20)
        Me.txt_verifica.TabIndex = 7
        Me.txt_verifica.Text = "2"
        Me.txt_verifica.Visible = False
        '
        'cmd_copiar
        '
        Me.cmd_copiar.BackColor = System.Drawing.Color.Black
        Me.cmd_copiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_copiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_copiar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_copiar.Location = New System.Drawing.Point(255, 485)
        Me.cmd_copiar.Name = "cmd_copiar"
        Me.cmd_copiar.Size = New System.Drawing.Size(95, 35)
        Me.cmd_copiar.TabIndex = 8
        Me.cmd_copiar.Text = "Copiar"
        Me.cmd_copiar.UseVisualStyleBackColor = False
        '
        'form_parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 536)
        Me.Controls.Add(Me.cmd_copiar)
        Me.Controls.Add(Me.txt_verifica)
        Me.Controls.Add(Me.txt_interno)
        Me.Controls.Add(Me.cmd_borrar)
        Me.Controls.Add(Me.cmd_actualizar)
        Me.Controls.Add(Me.cmd_aceptar)
        Me.Controls.Add(Me.txt_descripcion)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "form_parametros"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "parametros"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents cmd_borrar As System.Windows.Forms.Button
    Friend WithEvents lbl_habilita As System.Windows.Forms.Label
    Friend WithEvents opt_no As System.Windows.Forms.RadioButton
    Friend WithEvents opt_si As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_parametro As mitextbox1.texto_solonum
    Friend WithEvents lbl_descripcion As System.Windows.Forms.Label
    Friend WithEvents txt_interno As System.Windows.Forms.TextBox
    Friend WithEvents txt_verifica As System.Windows.Forms.TextBox
    Friend WithEvents cmd_copiar As System.Windows.Forms.Button
End Class
