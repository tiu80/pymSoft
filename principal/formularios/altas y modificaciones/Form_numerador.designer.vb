<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_numerador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_numerador))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_talonario = New mitextbox1.texto_solonum
        Me.txt_interno = New System.Windows.Forms.TextBox
        Me.cmd_eliminar = New System.Windows.Forms.Button
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.cmd_guardar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_punto_venta = New mitextbox1.texto_solonum
        Me.txt_int_nc_b = New System.Windows.Forms.TextBox
        Me.txt_int_nc_a = New System.Windows.Forms.TextBox
        Me.txt_int_pedido = New System.Windows.Forms.TextBox
        Me.txt_int_remito = New System.Windows.Forms.TextBox
        Me.txt_int_recibo = New System.Windows.Forms.TextBox
        Me.txt_int_factc = New System.Windows.Forms.TextBox
        Me.txt_int_factb = New System.Windows.Forms.TextBox
        Me.txt_int_facta = New System.Windows.Forms.TextBox
        Me.txt_int_p_vta = New System.Windows.Forms.TextBox
        Me.txt_n_credito_b = New text_solo_num.solo_numeros
        Me.txt_n_credito_a = New text_solo_num.solo_numeros
        Me.txt_pedido = New text_solo_num.solo_numeros
        Me.txt_remito = New text_solo_num.solo_numeros
        Me.txt_recibo = New text_solo_num.solo_numeros
        Me.txt_fact_c = New text_solo_num.solo_numeros
        Me.txt_fact_b = New text_solo_num.solo_numeros
        Me.txt_fact_a = New text_solo_num.solo_numeros
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txt_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_interno)
        Me.GroupBox1.Controls.Add(Me.cmd_eliminar)
        Me.GroupBox1.Controls.Add(Me.cmd_actualizar)
        Me.GroupBox1.Controls.Add(Me.cmd_guardar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 359)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_talonario
        '
        Me.txt_talonario.Location = New System.Drawing.Point(180, 11)
        Me.txt_talonario.Name = "txt_talonario"
        Me.txt_talonario.Size = New System.Drawing.Size(100, 20)
        Me.txt_talonario.TabIndex = 0
        Me.txt_talonario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_interno
        '
        Me.txt_interno.Location = New System.Drawing.Point(299, 12)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(42, 20)
        Me.txt_interno.TabIndex = 23
        Me.txt_interno.Visible = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_eliminar.BackgroundImage = Global.pym.My.Resources.Resources.cancel
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_eliminar.Location = New System.Drawing.Point(263, 310)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_eliminar.TabIndex = 22
        Me.cmd_eliminar.Text = "Borrar"
        Me.cmd_eliminar.UseVisualStyleBackColor = True
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_actualizar.BackgroundImage = Global.pym.My.Resources.Resources.reload
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_actualizar.Location = New System.Drawing.Point(150, 310)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_actualizar.TabIndex = 21
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = True
        '
        'cmd_guardar
        '
        Me.cmd_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_guardar.BackgroundImage = Global.pym.My.Resources.Resources.button_ok1
        Me.cmd_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_guardar.Location = New System.Drawing.Point(42, 310)
        Me.cmd_guardar.Name = "cmd_guardar"
        Me.cmd_guardar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_guardar.TabIndex = 20
        Me.cmd_guardar.Text = "Guardar"
        Me.cmd_guardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Talonario"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txt_punto_venta)
        Me.GroupBox2.Controls.Add(Me.txt_int_nc_b)
        Me.GroupBox2.Controls.Add(Me.txt_int_nc_a)
        Me.GroupBox2.Controls.Add(Me.txt_int_pedido)
        Me.GroupBox2.Controls.Add(Me.txt_int_remito)
        Me.GroupBox2.Controls.Add(Me.txt_int_recibo)
        Me.GroupBox2.Controls.Add(Me.txt_int_factc)
        Me.GroupBox2.Controls.Add(Me.txt_int_factb)
        Me.GroupBox2.Controls.Add(Me.txt_int_facta)
        Me.GroupBox2.Controls.Add(Me.txt_int_p_vta)
        Me.GroupBox2.Controls.Add(Me.txt_n_credito_b)
        Me.GroupBox2.Controls.Add(Me.txt_n_credito_a)
        Me.GroupBox2.Controls.Add(Me.txt_pedido)
        Me.GroupBox2.Controls.Add(Me.txt_remito)
        Me.GroupBox2.Controls.Add(Me.txt_recibo)
        Me.GroupBox2.Controls.Add(Me.txt_fact_c)
        Me.GroupBox2.Controls.Add(Me.txt_fact_b)
        Me.GroupBox2.Controls.Add(Me.txt_fact_a)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 269)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_punto_venta
        '
        Me.txt_punto_venta.Location = New System.Drawing.Point(173, 15)
        Me.txt_punto_venta.Name = "txt_punto_venta"
        Me.txt_punto_venta.Size = New System.Drawing.Size(100, 20)
        Me.txt_punto_venta.TabIndex = 29
        Me.txt_punto_venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_int_nc_b
        '
        Me.txt_int_nc_b.Location = New System.Drawing.Point(292, 244)
        Me.txt_int_nc_b.Name = "txt_int_nc_b"
        Me.txt_int_nc_b.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_nc_b.TabIndex = 28
        Me.txt_int_nc_b.Visible = False
        '
        'txt_int_nc_a
        '
        Me.txt_int_nc_a.Location = New System.Drawing.Point(292, 215)
        Me.txt_int_nc_a.Name = "txt_int_nc_a"
        Me.txt_int_nc_a.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_nc_a.TabIndex = 27
        Me.txt_int_nc_a.Visible = False
        '
        'txt_int_pedido
        '
        Me.txt_int_pedido.Location = New System.Drawing.Point(292, 189)
        Me.txt_int_pedido.Name = "txt_int_pedido"
        Me.txt_int_pedido.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_pedido.TabIndex = 26
        Me.txt_int_pedido.Visible = False
        '
        'txt_int_remito
        '
        Me.txt_int_remito.Location = New System.Drawing.Point(292, 160)
        Me.txt_int_remito.Name = "txt_int_remito"
        Me.txt_int_remito.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_remito.TabIndex = 25
        Me.txt_int_remito.Visible = False
        '
        'txt_int_recibo
        '
        Me.txt_int_recibo.Location = New System.Drawing.Point(292, 133)
        Me.txt_int_recibo.Name = "txt_int_recibo"
        Me.txt_int_recibo.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_recibo.TabIndex = 24
        Me.txt_int_recibo.Visible = False
        '
        'txt_int_factc
        '
        Me.txt_int_factc.Location = New System.Drawing.Point(292, 104)
        Me.txt_int_factc.Name = "txt_int_factc"
        Me.txt_int_factc.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_factc.TabIndex = 23
        Me.txt_int_factc.Visible = False
        '
        'txt_int_factb
        '
        Me.txt_int_factb.Location = New System.Drawing.Point(292, 74)
        Me.txt_int_factb.Name = "txt_int_factb"
        Me.txt_int_factb.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_factb.TabIndex = 22
        Me.txt_int_factb.Visible = False
        '
        'txt_int_facta
        '
        Me.txt_int_facta.Location = New System.Drawing.Point(292, 45)
        Me.txt_int_facta.Name = "txt_int_facta"
        Me.txt_int_facta.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_facta.TabIndex = 21
        Me.txt_int_facta.Visible = False
        '
        'txt_int_p_vta
        '
        Me.txt_int_p_vta.Location = New System.Drawing.Point(292, 15)
        Me.txt_int_p_vta.Name = "txt_int_p_vta"
        Me.txt_int_p_vta.Size = New System.Drawing.Size(42, 20)
        Me.txt_int_p_vta.TabIndex = 20
        Me.txt_int_p_vta.Visible = False
        '
        'txt_n_credito_b
        '
        Me.txt_n_credito_b.Location = New System.Drawing.Point(173, 244)
        Me.txt_n_credito_b.Name = "txt_n_credito_b"
        Me.txt_n_credito_b.Size = New System.Drawing.Size(100, 20)
        Me.txt_n_credito_b.TabIndex = 19
        Me.txt_n_credito_b.Text = "0"
        Me.txt_n_credito_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_n_credito_a
        '
        Me.txt_n_credito_a.Location = New System.Drawing.Point(173, 217)
        Me.txt_n_credito_a.Name = "txt_n_credito_a"
        Me.txt_n_credito_a.Size = New System.Drawing.Size(100, 20)
        Me.txt_n_credito_a.TabIndex = 18
        Me.txt_n_credito_a.Text = "0"
        Me.txt_n_credito_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(173, 189)
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(100, 20)
        Me.txt_pedido.TabIndex = 17
        Me.txt_pedido.Text = "0"
        Me.txt_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_remito
        '
        Me.txt_remito.Location = New System.Drawing.Point(173, 160)
        Me.txt_remito.Name = "txt_remito"
        Me.txt_remito.Size = New System.Drawing.Size(100, 20)
        Me.txt_remito.TabIndex = 16
        Me.txt_remito.Text = "0"
        Me.txt_remito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_recibo
        '
        Me.txt_recibo.Location = New System.Drawing.Point(173, 132)
        Me.txt_recibo.Name = "txt_recibo"
        Me.txt_recibo.Size = New System.Drawing.Size(100, 20)
        Me.txt_recibo.TabIndex = 15
        Me.txt_recibo.Text = "0"
        Me.txt_recibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_c
        '
        Me.txt_fact_c.Location = New System.Drawing.Point(173, 104)
        Me.txt_fact_c.Name = "txt_fact_c"
        Me.txt_fact_c.Size = New System.Drawing.Size(100, 20)
        Me.txt_fact_c.TabIndex = 14
        Me.txt_fact_c.Text = "0"
        Me.txt_fact_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_b
        '
        Me.txt_fact_b.Location = New System.Drawing.Point(173, 74)
        Me.txt_fact_b.Name = "txt_fact_b"
        Me.txt_fact_b.Size = New System.Drawing.Size(100, 20)
        Me.txt_fact_b.TabIndex = 13
        Me.txt_fact_b.Text = "0"
        Me.txt_fact_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_a
        '
        Me.txt_fact_a.Location = New System.Drawing.Point(173, 45)
        Me.txt_fact_a.Name = "txt_fact_a"
        Me.txt_fact_a.Size = New System.Drawing.Size(100, 20)
        Me.txt_fact_a.TabIndex = 2
        Me.txt_fact_a.Text = "0"
        Me.txt_fact_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Numero N. Credito ""B"""
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Numero N. Credito ""A"""
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Numero Pedido"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Numero Remito"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Numero Recibo"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Numero Factura ""C"""
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Numero Factura ""B"""
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Numero Factura ""A"""
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numero Punto Venta"
        '
        'Form_numerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(392, 366)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_numerador"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Numeradores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmd_eliminar As System.Windows.Forms.Button
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents cmd_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_n_credito_b As text_solo_num.solo_numeros
    Friend WithEvents txt_n_credito_a As text_solo_num.solo_numeros
    Friend WithEvents txt_pedido As text_solo_num.solo_numeros
    Friend WithEvents txt_remito As text_solo_num.solo_numeros
    Friend WithEvents txt_recibo As text_solo_num.solo_numeros
    Friend WithEvents txt_fact_c As text_solo_num.solo_numeros
    Friend WithEvents txt_fact_b As text_solo_num.solo_numeros
    Friend WithEvents txt_fact_a As text_solo_num.solo_numeros
    Friend WithEvents txt_interno As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_recibo As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_factc As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_factb As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_facta As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_p_vta As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_nc_b As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_nc_a As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_remito As System.Windows.Forms.TextBox
    Friend WithEvents txt_talonario As mitextbox1.texto_solonum
    Friend WithEvents txt_punto_venta As mitextbox1.texto_solonum

End Class
