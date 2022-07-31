<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cantidad_pedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cantidad_pedido))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_uni_sec = New System.Windows.Forms.Label
        Me.txt_unidad_secundaria = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_precio_original = New System.Windows.Forms.Label
        Me.lbl_iva = New System.Windows.Forms.Label
        Me.lbl_idiva = New System.Windows.Forms.Label
        Me.lbl_descuento = New System.Windows.Forms.Label
        Me.lbl_art_mueve_stok = New System.Windows.Forms.Label
        Me.lbl_letra = New System.Windows.Forms.Label
        Me.lbl_indice = New System.Windows.Forms.Label
        Me.txt_precio = New System.Windows.Forms.TextBox
        Me.lbl_costo = New System.Windows.Forms.Label
        Me.lbl_p_civa = New System.Windows.Forms.Label
        Me.lbl_p_siva = New System.Windows.Forms.Label
        Me.txt_desc_rcgo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl_stok_ant = New System.Windows.Forms.Label
        Me.lbl_cant = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.lbl_stock = New System.Windows.Forms.Label
        Me.lbl_articulo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_bonif_vta = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.lbl_bonif_vta)
        Me.GroupBox1.Controls.Add(Me.lbl_uni_sec)
        Me.GroupBox1.Controls.Add(Me.txt_unidad_secundaria)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_precio_original)
        Me.GroupBox1.Controls.Add(Me.lbl_iva)
        Me.GroupBox1.Controls.Add(Me.lbl_idiva)
        Me.GroupBox1.Controls.Add(Me.lbl_descuento)
        Me.GroupBox1.Controls.Add(Me.lbl_art_mueve_stok)
        Me.GroupBox1.Controls.Add(Me.lbl_letra)
        Me.GroupBox1.Controls.Add(Me.lbl_indice)
        Me.GroupBox1.Controls.Add(Me.txt_precio)
        Me.GroupBox1.Controls.Add(Me.lbl_costo)
        Me.GroupBox1.Controls.Add(Me.lbl_p_civa)
        Me.GroupBox1.Controls.Add(Me.lbl_p_siva)
        Me.GroupBox1.Controls.Add(Me.txt_desc_rcgo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_stok_ant)
        Me.GroupBox1.Controls.Add(Me.lbl_cant)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbl_codigo)
        Me.GroupBox1.Controls.Add(Me.txt_cantidad)
        Me.GroupBox1.Controls.Add(Me.lbl_stock)
        Me.GroupBox1.Controls.Add(Me.lbl_articulo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 291)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbl_uni_sec
        '
        Me.lbl_uni_sec.AutoSize = True
        Me.lbl_uni_sec.Location = New System.Drawing.Point(229, 160)
        Me.lbl_uni_sec.Name = "lbl_uni_sec"
        Me.lbl_uni_sec.Size = New System.Drawing.Size(44, 13)
        Me.lbl_uni_sec.TabIndex = 26
        Me.lbl_uni_sec.Text = "uni_sec"
        Me.lbl_uni_sec.Visible = False
        '
        'txt_unidad_secundaria
        '
        Me.txt_unidad_secundaria.Enabled = False
        Me.txt_unidad_secundaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_unidad_secundaria.Location = New System.Drawing.Point(77, 190)
        Me.txt_unidad_secundaria.Name = "txt_unidad_secundaria"
        Me.txt_unidad_secundaria.Size = New System.Drawing.Size(73, 21)
        Me.txt_unidad_secundaria.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Peso:"
        '
        'lbl_precio_original
        '
        Me.lbl_precio_original.AutoSize = True
        Me.lbl_precio_original.Location = New System.Drawing.Point(190, 144)
        Me.lbl_precio_original.Name = "lbl_precio_original"
        Me.lbl_precio_original.Size = New System.Drawing.Size(50, 13)
        Me.lbl_precio_original.TabIndex = 23
        Me.lbl_precio_original.Text = "precio ori"
        Me.lbl_precio_original.Visible = False
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(55, 9)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(21, 13)
        Me.lbl_iva.TabIndex = 22
        Me.lbl_iva.Text = "iva"
        Me.lbl_iva.Visible = False
        '
        'lbl_idiva
        '
        Me.lbl_idiva.AutoSize = True
        Me.lbl_idiva.Location = New System.Drawing.Point(20, 9)
        Me.lbl_idiva.Name = "lbl_idiva"
        Me.lbl_idiva.Size = New System.Drawing.Size(29, 13)
        Me.lbl_idiva.TabIndex = 21
        Me.lbl_idiva.Text = "idiva"
        Me.lbl_idiva.Visible = False
        '
        'lbl_descuento
        '
        Me.lbl_descuento.AutoSize = True
        Me.lbl_descuento.Location = New System.Drawing.Point(186, 196)
        Me.lbl_descuento.Name = "lbl_descuento"
        Me.lbl_descuento.Size = New System.Drawing.Size(57, 13)
        Me.lbl_descuento.TabIndex = 20
        Me.lbl_descuento.Text = "descuento"
        Me.lbl_descuento.Visible = False
        '
        'lbl_art_mueve_stok
        '
        Me.lbl_art_mueve_stok.AutoSize = True
        Me.lbl_art_mueve_stok.Location = New System.Drawing.Point(172, 60)
        Me.lbl_art_mueve_stok.Name = "lbl_art_mueve_stok"
        Me.lbl_art_mueve_stok.Size = New System.Drawing.Size(89, 13)
        Me.lbl_art_mueve_stok.TabIndex = 19
        Me.lbl_art_mueve_stok.Text = "art_mueve_stock"
        Me.lbl_art_mueve_stok.Visible = False
        '
        'lbl_letra
        '
        Me.lbl_letra.AutoSize = True
        Me.lbl_letra.Location = New System.Drawing.Point(183, 9)
        Me.lbl_letra.Name = "lbl_letra"
        Me.lbl_letra.Size = New System.Drawing.Size(27, 13)
        Me.lbl_letra.TabIndex = 18
        Me.lbl_letra.Text = "letra"
        Me.lbl_letra.Visible = False
        '
        'lbl_indice
        '
        Me.lbl_indice.AutoSize = True
        Me.lbl_indice.Location = New System.Drawing.Point(184, 214)
        Me.lbl_indice.Name = "lbl_indice"
        Me.lbl_indice.Size = New System.Drawing.Size(35, 13)
        Me.lbl_indice.TabIndex = 17
        Me.lbl_indice.Text = "indice"
        Me.lbl_indice.Visible = False
        '
        'txt_precio
        '
        Me.txt_precio.Enabled = False
        Me.txt_precio.Location = New System.Drawing.Point(77, 115)
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(75, 20)
        Me.txt_precio.TabIndex = 0
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(186, 80)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(33, 13)
        Me.lbl_costo.TabIndex = 15
        Me.lbl_costo.Text = "costo"
        Me.lbl_costo.Visible = False
        '
        'lbl_p_civa
        '
        Me.lbl_p_civa.AutoSize = True
        Me.lbl_p_civa.Location = New System.Drawing.Point(184, 118)
        Me.lbl_p_civa.Name = "lbl_p_civa"
        Me.lbl_p_civa.Size = New System.Drawing.Size(62, 13)
        Me.lbl_p_civa.TabIndex = 14
        Me.lbl_p_civa.Text = "precio_civa"
        Me.lbl_p_civa.Visible = False
        '
        'lbl_p_siva
        '
        Me.lbl_p_siva.AutoSize = True
        Me.lbl_p_siva.Location = New System.Drawing.Point(186, 97)
        Me.lbl_p_siva.Name = "lbl_p_siva"
        Me.lbl_p_siva.Size = New System.Drawing.Size(61, 13)
        Me.lbl_p_siva.TabIndex = 13
        Me.lbl_p_siva.Text = "precio_siva"
        Me.lbl_p_siva.Visible = False
        '
        'txt_desc_rcgo
        '
        Me.txt_desc_rcgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_rcgo.Location = New System.Drawing.Point(78, 235)
        Me.txt_desc_rcgo.Name = "txt_desc_rcgo"
        Me.txt_desc_rcgo.Size = New System.Drawing.Size(73, 21)
        Me.txt_desc_rcgo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Dsc/Rgo:"
        '
        'lbl_stok_ant
        '
        Me.lbl_stok_ant.AutoSize = True
        Me.lbl_stok_ant.Location = New System.Drawing.Point(158, 78)
        Me.lbl_stok_ant.Name = "lbl_stok_ant"
        Me.lbl_stok_ant.Size = New System.Drawing.Size(0, 13)
        Me.lbl_stok_ant.TabIndex = 10
        Me.lbl_stok_ant.Visible = False
        '
        'lbl_cant
        '
        Me.lbl_cant.AutoSize = True
        Me.lbl_cant.Location = New System.Drawing.Point(184, 175)
        Me.lbl_cant.Name = "lbl_cant"
        Me.lbl_cant.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cant.TabIndex = 9
        Me.lbl_cant.Text = "Label4"
        Me.lbl_cant.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Precio:"
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Location = New System.Drawing.Point(79, 59)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(39, 13)
        Me.lbl_codigo.TabIndex = 6
        Me.lbl_codigo.Text = "Label4"
        Me.lbl_codigo.Visible = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.Location = New System.Drawing.Point(77, 152)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(73, 21)
        Me.txt_cantidad.TabIndex = 1
        '
        'lbl_stock
        '
        Me.lbl_stock.BackColor = System.Drawing.Color.Blue
        Me.lbl_stock.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stock.ForeColor = System.Drawing.Color.White
        Me.lbl_stock.Location = New System.Drawing.Point(76, 73)
        Me.lbl_stock.Name = "lbl_stock"
        Me.lbl_stock.Size = New System.Drawing.Size(76, 24)
        Me.lbl_stock.TabIndex = 4
        Me.lbl_stock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_articulo
        '
        Me.lbl_articulo.BackColor = System.Drawing.Color.Blue
        Me.lbl_articulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_articulo.ForeColor = System.Drawing.Color.White
        Me.lbl_articulo.Location = New System.Drawing.Point(76, 31)
        Me.lbl_articulo.Name = "lbl_articulo"
        Me.lbl_articulo.Size = New System.Drawing.Size(191, 25)
        Me.lbl_articulo.TabIndex = 3
        Me.lbl_articulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cantidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Stock:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Articulo:"
        '
        'lbl_bonif_vta
        '
        Me.lbl_bonif_vta.AutoSize = True
        Me.lbl_bonif_vta.BackColor = System.Drawing.Color.Red
        Me.lbl_bonif_vta.ForeColor = System.Drawing.Color.White
        Me.lbl_bonif_vta.Location = New System.Drawing.Point(77, 259)
        Me.lbl_bonif_vta.Name = "lbl_bonif_vta"
        Me.lbl_bonif_vta.Size = New System.Drawing.Size(13, 13)
        Me.lbl_bonif_vta.TabIndex = 27
        Me.lbl_bonif_vta.Text = "0"
        Me.lbl_bonif_vta.Visible = False
        '
        'Form_cantidad_pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(288, 298)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cantidad_pedido"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cantidad Articulo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_articulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbl_stock As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_cant As System.Windows.Forms.Label
    Friend WithEvents lbl_stok_ant As System.Windows.Forms.Label
    Friend WithEvents txt_desc_rcgo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_p_civa As System.Windows.Forms.Label
    Friend WithEvents lbl_p_siva As System.Windows.Forms.Label
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_indice As System.Windows.Forms.Label
    Friend WithEvents lbl_letra As System.Windows.Forms.Label
    Friend WithEvents lbl_art_mueve_stok As System.Windows.Forms.Label
    Friend WithEvents lbl_descuento As System.Windows.Forms.Label
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
    Friend WithEvents lbl_idiva As System.Windows.Forms.Label
    Friend WithEvents lbl_precio_original As System.Windows.Forms.Label
    Friend WithEvents txt_unidad_secundaria As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_uni_sec As System.Windows.Forms.Label
    Friend WithEvents lbl_bonif_vta As System.Windows.Forms.Label
End Class
