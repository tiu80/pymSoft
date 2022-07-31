<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_actualizador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_actualizador))
        Me.cmd_inicia = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_recibir = New System.Windows.Forms.CheckBox
        Me.cmd_buscar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_lista = New System.Windows.Forms.ComboBox
        Me.sucursal = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.opt_remitos = New System.Windows.Forms.RadioButton
        Me.opt_articulos = New System.Windows.Forms.RadioButton
        Me.txt_recibir = New System.Windows.Forms.TextBox
        Me.txt_enviar = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_inicia
        '
        Me.cmd_inicia.BackColor = System.Drawing.Color.Black
        Me.cmd_inicia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_inicia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_inicia.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_inicia.Location = New System.Drawing.Point(202, 370)
        Me.cmd_inicia.Name = "cmd_inicia"
        Me.cmd_inicia.Size = New System.Drawing.Size(332, 74)
        Me.cmd_inicia.TabIndex = 18
        Me.cmd_inicia.Text = "INICIAR"
        Me.cmd_inicia.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.chk_recibir)
        Me.GroupBox1.Controls.Add(Me.cmd_buscar)
        Me.GroupBox1.Controls.Add(Me.cmd_inicia)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txt_recibir)
        Me.GroupBox1.Controls.Add(Me.txt_enviar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(778, 459)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'chk_recibir
        '
        Me.chk_recibir.AutoSize = True
        Me.chk_recibir.Location = New System.Drawing.Point(421, 60)
        Me.chk_recibir.Name = "chk_recibir"
        Me.chk_recibir.Size = New System.Drawing.Size(15, 14)
        Me.chk_recibir.TabIndex = 23
        Me.chk_recibir.UseVisualStyleBackColor = True
        '
        'cmd_buscar
        '
        Me.cmd_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmd_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_buscar.Location = New System.Drawing.Point(420, 16)
        Me.cmd_buscar.Name = "cmd_buscar"
        Me.cmd_buscar.Size = New System.Drawing.Size(54, 23)
        Me.cmd_buscar.TabIndex = 22
        Me.cmd_buscar.Text = "..."
        Me.cmd_buscar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmb_lista)
        Me.GroupBox2.Controls.Add(Me.sucursal)
        Me.GroupBox2.Controls.Add(Me.cmb_sucursal)
        Me.GroupBox2.Controls.Add(Me.opt_remitos)
        Me.GroupBox2.Controls.Add(Me.opt_articulos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 270)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 116)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(759, 154)
        Me.DataGridView1.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(286, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Lista:"
        '
        'cmb_lista
        '
        Me.cmb_lista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_lista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_lista.FormattingEnabled = True
        Me.cmb_lista.Location = New System.Drawing.Point(355, 25)
        Me.cmb_lista.Name = "cmb_lista"
        Me.cmb_lista.Size = New System.Drawing.Size(288, 24)
        Me.cmb_lista.TabIndex = 25
        '
        'sucursal
        '
        Me.sucursal.AutoSize = True
        Me.sucursal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sucursal.Location = New System.Drawing.Point(286, 76)
        Me.sucursal.Name = "sucursal"
        Me.sucursal.Size = New System.Drawing.Size(63, 16)
        Me.sucursal.TabIndex = 22
        Me.sucursal.Text = "Sucursal:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.Enabled = False
        Me.cmb_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(355, 70)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(288, 24)
        Me.cmb_sucursal.TabIndex = 23
        '
        'opt_remitos
        '
        Me.opt_remitos.AutoSize = True
        Me.opt_remitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_remitos.Location = New System.Drawing.Point(118, 74)
        Me.opt_remitos.Name = "opt_remitos"
        Me.opt_remitos.Size = New System.Drawing.Size(76, 20)
        Me.opt_remitos.TabIndex = 2
        Me.opt_remitos.TabStop = True
        Me.opt_remitos.Text = "Remitos"
        Me.opt_remitos.UseVisualStyleBackColor = True
        '
        'opt_articulos
        '
        Me.opt_articulos.AutoSize = True
        Me.opt_articulos.Checked = True
        Me.opt_articulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_articulos.Location = New System.Drawing.Point(118, 29)
        Me.opt_articulos.Name = "opt_articulos"
        Me.opt_articulos.Size = New System.Drawing.Size(77, 20)
        Me.opt_articulos.TabIndex = 0
        Me.opt_articulos.TabStop = True
        Me.opt_articulos.Text = "Articulos"
        Me.opt_articulos.UseVisualStyleBackColor = True
        '
        'txt_recibir
        '
        Me.txt_recibir.AcceptsReturn = True
        Me.txt_recibir.BackColor = System.Drawing.Color.White
        Me.txt_recibir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_recibir.Location = New System.Drawing.Point(126, 57)
        Me.txt_recibir.Name = "txt_recibir"
        Me.txt_recibir.ReadOnly = True
        Me.txt_recibir.Size = New System.Drawing.Size(288, 21)
        Me.txt_recibir.TabIndex = 2
        '
        'txt_enviar
        '
        Me.txt_enviar.BackColor = System.Drawing.Color.White
        Me.txt_enviar.Enabled = False
        Me.txt_enviar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_enviar.Location = New System.Drawing.Point(126, 16)
        Me.txt_enviar.Name = "txt_enviar"
        Me.txt_enviar.ReadOnly = True
        Me.txt_enviar.Size = New System.Drawing.Size(288, 21)
        Me.txt_enviar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(23, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Recibir:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(23, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Enviar:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(543, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 70)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(619, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 70)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Actualizador"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.SelectedPath = "C:\Users\pabloc\SkyDrive"
        '
        'Form_actualizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_actualizador"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmd_inicia As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_recibir As System.Windows.Forms.TextBox
    Friend WithEvents txt_enviar As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents opt_remitos As System.Windows.Forms.RadioButton
    Friend WithEvents opt_articulos As System.Windows.Forms.RadioButton
    Friend WithEvents sucursal As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_lista As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_buscar As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chk_recibir As System.Windows.Forms.CheckBox
End Class
