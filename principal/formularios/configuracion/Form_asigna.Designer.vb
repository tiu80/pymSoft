<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_asigna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_asigna))
        Me.list_usu = New System.Windows.Forms.ListBox
        Me.list_menu = New System.Windows.Forms.ListBox
        Me.List_parametro = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_actualiza = New System.Windows.Forms.Button
        Me.cmd_asinga = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_estado = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'list_usu
        '
        Me.list_usu.BackColor = System.Drawing.Color.White
        Me.list_usu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list_usu.FormattingEnabled = True
        Me.list_usu.ItemHeight = 15
        Me.list_usu.Location = New System.Drawing.Point(2, 89)
        Me.list_usu.Name = "list_usu"
        Me.list_usu.Size = New System.Drawing.Size(439, 94)
        Me.list_usu.Sorted = True
        Me.list_usu.TabIndex = 0
        '
        'list_menu
        '
        Me.list_menu.BackColor = System.Drawing.Color.White
        Me.list_menu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list_menu.FormattingEnabled = True
        Me.list_menu.ItemHeight = 15
        Me.list_menu.Location = New System.Drawing.Point(2, 211)
        Me.list_menu.Name = "list_menu"
        Me.list_menu.Size = New System.Drawing.Size(439, 94)
        Me.list_menu.Sorted = True
        Me.list_menu.TabIndex = 1
        '
        'List_parametro
        '
        Me.List_parametro.BackColor = System.Drawing.Color.White
        Me.List_parametro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List_parametro.FormattingEnabled = True
        Me.List_parametro.ItemHeight = 15
        Me.List_parametro.Location = New System.Drawing.Point(2, 332)
        Me.List_parametro.Name = "List_parametro"
        Me.List_parametro.Size = New System.Drawing.Size(439, 94)
        Me.List_parametro.Sorted = True
        Me.List_parametro.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(318, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 63)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Asignacion"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_actualiza)
        Me.GroupBox1.Controls.Add(Me.cmd_asinga)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 467)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 64)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmd_actualiza
        '
        Me.cmd_actualiza.BackColor = System.Drawing.Color.Black
        Me.cmd_actualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualiza.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualiza.Location = New System.Drawing.Point(295, 18)
        Me.cmd_actualiza.Name = "cmd_actualiza"
        Me.cmd_actualiza.Size = New System.Drawing.Size(103, 34)
        Me.cmd_actualiza.TabIndex = 1
        Me.cmd_actualiza.Text = "Actualizar"
        Me.cmd_actualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmd_actualiza.UseVisualStyleBackColor = False
        '
        'cmd_asinga
        '
        Me.cmd_asinga.BackColor = System.Drawing.Color.Black
        Me.cmd_asinga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_asinga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_asinga.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_asinga.Location = New System.Drawing.Point(15, 18)
        Me.cmd_asinga.Name = "cmd_asinga"
        Me.cmd_asinga.Size = New System.Drawing.Size(103, 36)
        Me.cmd_asinga.TabIndex = 0
        Me.cmd_asinga.Text = "Asignar"
        Me.cmd_asinga.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmd_asinga.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 443)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Estado"
        '
        'cmb_estado
        '
        Me.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_estado.FormattingEnabled = True
        Me.cmb_estado.Items.AddRange(New Object() {"Activo", "Baja"})
        Me.cmb_estado.Location = New System.Drawing.Point(110, 440)
        Me.cmb_estado.Name = "cmb_estado"
        Me.cmb_estado.Size = New System.Drawing.Size(125, 23)
        Me.cmb_estado.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(3, 313)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Parametros"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(5, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(3, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Menu"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(238, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Form_asigna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(442, 536)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmb_estado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.List_parametro)
        Me.Controls.Add(Me.list_menu)
        Me.Controls.Add(Me.list_usu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_asigna"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNACION MENU - USUARIO"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents list_usu As System.Windows.Forms.ListBox
    Friend WithEvents list_menu As System.Windows.Forms.ListBox
    Friend WithEvents List_parametro As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_asinga As System.Windows.Forms.Button
    Friend WithEvents cmd_actualiza As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
