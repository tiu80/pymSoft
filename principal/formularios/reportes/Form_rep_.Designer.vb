<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_rep_etiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_rep_etiquetas))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_hasta = New System.Windows.Forms.ComboBox
        Me.cmb_desde = New System.Windows.Forms.ComboBox
        Me.lbl_articulo = New System.Windows.Forms.Label
        Me.chk_proveedor = New System.Windows.Forms.CheckBox
        Me.chk_rubro = New System.Windows.Forms.CheckBox
        Me.chk_codigo = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.opt_cod_barra = New System.Windows.Forms.RadioButton
        Me.opt_cod = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_lista = New text_solo_num.solo_numeros
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.cmd_cancelar = New System.Windows.Forms.Button
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(518, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 70)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(-1, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(626, 70)
        Me.Label1.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(616, -2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 70)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Reporte etiquetas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmb_hasta)
        Me.GroupBox1.Controls.Add(Me.cmb_desde)
        Me.GroupBox1.Controls.Add(Me.lbl_articulo)
        Me.GroupBox1.Controls.Add(Me.chk_proveedor)
        Me.GroupBox1.Controls.Add(Me.chk_rubro)
        Me.GroupBox1.Controls.Add(Me.chk_codigo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_lista)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(783, 308)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'cmb_hasta
        '
        Me.cmb_hasta.FormattingEnabled = True
        Me.cmb_hasta.Location = New System.Drawing.Point(473, 135)
        Me.cmb_hasta.Name = "cmb_hasta"
        Me.cmb_hasta.Size = New System.Drawing.Size(272, 21)
        Me.cmb_hasta.TabIndex = 2
        '
        'cmb_desde
        '
        Me.cmb_desde.FormattingEnabled = True
        Me.cmb_desde.Location = New System.Drawing.Point(124, 136)
        Me.cmb_desde.Name = "cmb_desde"
        Me.cmb_desde.Size = New System.Drawing.Size(272, 21)
        Me.cmb_desde.TabIndex = 1
        '
        'lbl_articulo
        '
        Me.lbl_articulo.AutoSize = True
        Me.lbl_articulo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_articulo.ForeColor = System.Drawing.Color.Red
        Me.lbl_articulo.Location = New System.Drawing.Point(121, 166)
        Me.lbl_articulo.Name = "lbl_articulo"
        Me.lbl_articulo.Size = New System.Drawing.Size(0, 16)
        Me.lbl_articulo.TabIndex = 11
        '
        'chk_proveedor
        '
        Me.chk_proveedor.AutoSize = True
        Me.chk_proveedor.Location = New System.Drawing.Point(686, 20)
        Me.chk_proveedor.Name = "chk_proveedor"
        Me.chk_proveedor.Size = New System.Drawing.Size(75, 17)
        Me.chk_proveedor.TabIndex = 10
        Me.chk_proveedor.TabStop = False
        Me.chk_proveedor.Text = "Proveedor"
        Me.chk_proveedor.UseVisualStyleBackColor = True
        '
        'chk_rubro
        '
        Me.chk_rubro.AutoSize = True
        Me.chk_rubro.Location = New System.Drawing.Point(623, 20)
        Me.chk_rubro.Name = "chk_rubro"
        Me.chk_rubro.Size = New System.Drawing.Size(55, 17)
        Me.chk_rubro.TabIndex = 9
        Me.chk_rubro.TabStop = False
        Me.chk_rubro.Text = "Rubro"
        Me.chk_rubro.UseVisualStyleBackColor = True
        '
        'chk_codigo
        '
        Me.chk_codigo.AutoSize = True
        Me.chk_codigo.Checked = True
        Me.chk_codigo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_codigo.Location = New System.Drawing.Point(553, 20)
        Me.chk_codigo.Name = "chk_codigo"
        Me.chk_codigo.Size = New System.Drawing.Size(59, 17)
        Me.chk_codigo.TabIndex = 8
        Me.chk_codigo.TabStop = False
        Me.chk_codigo.Text = "Codigo"
        Me.chk_codigo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(218, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 16)
        Me.Label6.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.opt_cod_barra)
        Me.GroupBox2.Controls.Add(Me.opt_cod)
        Me.GroupBox2.Location = New System.Drawing.Point(189, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 72)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'opt_cod_barra
        '
        Me.opt_cod_barra.AutoSize = True
        Me.opt_cod_barra.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_cod_barra.Location = New System.Drawing.Point(257, 32)
        Me.opt_cod_barra.Name = "opt_cod_barra"
        Me.opt_cod_barra.Size = New System.Drawing.Size(114, 19)
        Me.opt_cod_barra.TabIndex = 1
        Me.opt_cod_barra.Text = "Codigo de barra"
        Me.opt_cod_barra.UseVisualStyleBackColor = True
        '
        'opt_cod
        '
        Me.opt_cod.AutoSize = True
        Me.opt_cod.Checked = True
        Me.opt_cod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_cod.Location = New System.Drawing.Point(55, 32)
        Me.opt_cod.Name = "opt_cod"
        Me.opt_cod.Size = New System.Drawing.Size(65, 19)
        Me.opt_cod.TabIndex = 0
        Me.opt_cod.TabStop = True
        Me.opt_cod.Text = "Codigo"
        Me.opt_cod.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(424, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Codigo:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Lista:"
        '
        'txt_lista
        '
        Me.txt_lista.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_lista.Location = New System.Drawing.Point(124, 82)
        Me.txt_lista.Name = "txt_lista"
        Me.txt_lista.Size = New System.Drawing.Size(81, 20)
        Me.txt_lista.TabIndex = 0
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_aceptar.Image = Global.pym.My.Resources.Resources.printer
        Me.cmd_aceptar.Location = New System.Drawing.Point(122, 413)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(204, 84)
        Me.cmd_aceptar.TabIndex = 19
        Me.cmd_aceptar.Text = "Imprimir"
        Me.cmd_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_aceptar.UseVisualStyleBackColor = True
        '
        'cmd_cancelar
        '
        Me.cmd_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmd_cancelar.Image = Global.pym.My.Resources.Resources.cancel
        Me.cmd_cancelar.Location = New System.Drawing.Point(446, 413)
        Me.cmd_cancelar.Name = "cmd_cancelar"
        Me.cmd_cancelar.Size = New System.Drawing.Size(204, 84)
        Me.cmd_cancelar.TabIndex = 20
        Me.cmd_cancelar.Text = "Cancelar"
        Me.cmd_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_cancelar.UseVisualStyleBackColor = True
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(28, 27)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(61, 20)
        Me.txt_estado_form.TabIndex = 21
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Form_rep_etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.cmd_cancelar)
        Me.Controls.Add(Me.cmd_aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form_rep_etiquetas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE ETIQUETAS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_lista As text_solo_num.solo_numeros
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_cod_barra As System.Windows.Forms.RadioButton
    Friend WithEvents opt_cod As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmd_cancelar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chk_proveedor As System.Windows.Forms.CheckBox
    Friend WithEvents chk_rubro As System.Windows.Forms.CheckBox
    Friend WithEvents chk_codigo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents lbl_articulo As System.Windows.Forms.Label
    Friend WithEvents cmb_desde As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_hasta As System.Windows.Forms.ComboBox
End Class
