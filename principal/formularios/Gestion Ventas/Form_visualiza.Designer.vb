<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_visualiza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_visualiza))
        Me.cmb_tipo = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_talonario = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmd_cancela = New System.Windows.Forms.Button
        Me.cmd_acepta = New System.Windows.Forms.Button
        Me.txt_prefijo = New System.Windows.Forms.TextBox
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_tipo
        '
        Me.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipo.FormattingEnabled = True
        Me.cmb_tipo.Location = New System.Drawing.Point(162, 47)
        Me.cmb_tipo.Name = "cmb_tipo"
        Me.cmb_tipo.Size = New System.Drawing.Size(78, 26)
        Me.cmb_tipo.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmb_talonario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_estado_form)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo)
        Me.GroupBox1.Controls.Add(Me.txt_prefijo)
        Me.GroupBox1.Controls.Add(Me.txt_letra)
        Me.GroupBox1.Controls.Add(Me.txt_numero)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 191)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmb_talonario
        '
        Me.cmb_talonario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_talonario.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_talonario.FormattingEnabled = True
        Me.cmb_talonario.Items.AddRange(New Object() {"1", "2"})
        Me.cmb_talonario.Location = New System.Drawing.Point(85, 47)
        Me.cmb_talonario.Name = "cmb_talonario"
        Me.cmb_talonario.Size = New System.Drawing.Size(58, 26)
        Me.cmb_talonario.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Talonario"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(16, 22)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(28, 20)
        Me.txt_estado_form.TabIndex = 10
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(184, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(436, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(334, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Prefijo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(264, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Letra"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.cmd_cancela)
        Me.GroupBox2.Controls.Add(Me.cmd_acepta)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 91)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'cmd_cancela
        '
        Me.cmd_cancela.BackColor = System.Drawing.Color.Black
        Me.cmd_cancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_cancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_cancela.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_cancela.Location = New System.Drawing.Point(402, 16)
        Me.cmd_cancela.Name = "cmd_cancela"
        Me.cmd_cancela.Size = New System.Drawing.Size(127, 63)
        Me.cmd_cancela.TabIndex = 5
        Me.cmd_cancela.Text = "Cancelar"
        Me.cmd_cancela.UseVisualStyleBackColor = False
        '
        'cmd_acepta
        '
        Me.cmd_acepta.BackColor = System.Drawing.Color.Black
        Me.cmd_acepta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_acepta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_acepta.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_acepta.Location = New System.Drawing.Point(10, 16)
        Me.cmd_acepta.Name = "cmd_acepta"
        Me.cmd_acepta.Size = New System.Drawing.Size(127, 63)
        Me.cmd_acepta.TabIndex = 4
        Me.cmd_acepta.Text = "Aceptar"
        Me.cmd_acepta.UseVisualStyleBackColor = False
        '
        'txt_prefijo
        '
        Me.txt_prefijo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_prefijo.Location = New System.Drawing.Point(331, 48)
        Me.txt_prefijo.Name = "txt_prefijo"
        Me.txt_prefijo.Size = New System.Drawing.Size(50, 25)
        Me.txt_prefijo.TabIndex = 3
        Me.txt_prefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_letra.Location = New System.Drawing.Point(258, 47)
        Me.txt_letra.MaxLength = 1
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(50, 25)
        Me.txt_letra.TabIndex = 2
        Me.txt_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numero
        '
        Me.txt_numero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(406, 48)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(126, 25)
        Me.txt_numero.TabIndex = 4
        Me.txt_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Form_visualiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(588, 202)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_visualiza"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualizador comprobantes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_cancela As System.Windows.Forms.Button
    Friend WithEvents cmd_acepta As System.Windows.Forms.Button
    Friend WithEvents txt_prefijo As System.Windows.Forms.TextBox
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents cmb_talonario As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
