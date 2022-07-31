<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_factura_preventa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_factura_preventa))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_mueve_stock = New System.Windows.Forms.TextBox
        Me.txt_cod_lis = New System.Windows.Forms.TextBox
        Me.txt_vendedor = New System.Windows.Forms.TextBox
        Me.txt_fecHA_emi = New System.Windows.Forms.TextBox
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.txt_cod_cli = New System.Windows.Forms.TextBox
        Me.txt_talon = New System.Windows.Forms.TextBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_prefijo = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.txt_total_grilla = New System.Windows.Forms.TextBox
        Me.txt_imp_interno_grilla = New System.Windows.Forms.TextBox
        Me.txt_insc_10 = New System.Windows.Forms.TextBox
        Me.txt_inscripto = New System.Windows.Forms.TextBox
        Me.txt_exento = New System.Windows.Forms.TextBox
        Me.txt_gravado = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tool_quita_art = New System.Windows.Forms.ToolStripButton
        Me.tool_reemplaza_art = New System.Windows.Forms.ToolStripButton
        Me.tool_pedido = New System.Windows.Forms.ToolStripButton
        Me.Tool_borra_pedido = New System.Windows.Forms.ToolStripButton
        Me.Tool_agerga_item = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Tool_txt_descuento = New System.Windows.Forms.ToolStripTextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txt_muestra_datos = New System.Windows.Forms.TextBox
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.txt_cuit = New System.Windows.Forms.TextBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txt_mueve_stock)
        Me.GroupBox1.Controls.Add(Me.txt_cod_lis)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.txt_fecHA_emi)
        Me.GroupBox1.Controls.Add(Me.txt_nombre)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cli)
        Me.GroupBox1.Controls.Add(Me.txt_talon)
        Me.GroupBox1.Controls.Add(Me.txt_numero)
        Me.GroupBox1.Controls.Add(Me.txt_prefijo)
        Me.GroupBox1.Controls.Add(Me.txt_tipo)
        Me.GroupBox1.Controls.Add(Me.txt_total_grilla)
        Me.GroupBox1.Controls.Add(Me.txt_imp_interno_grilla)
        Me.GroupBox1.Controls.Add(Me.txt_insc_10)
        Me.GroupBox1.Controls.Add(Me.txt_inscripto)
        Me.GroupBox1.Controls.Add(Me.txt_exento)
        Me.GroupBox1.Controls.Add(Me.txt_gravado)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_letra)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 443)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_mueve_stock
        '
        Me.txt_mueve_stock.Location = New System.Drawing.Point(284, 10)
        Me.txt_mueve_stock.Name = "txt_mueve_stock"
        Me.txt_mueve_stock.Size = New System.Drawing.Size(32, 20)
        Me.txt_mueve_stock.TabIndex = 55
        Me.txt_mueve_stock.Visible = False
        '
        'txt_cod_lis
        '
        Me.txt_cod_lis.Location = New System.Drawing.Point(727, 11)
        Me.txt_cod_lis.Name = "txt_cod_lis"
        Me.txt_cod_lis.Size = New System.Drawing.Size(36, 20)
        Me.txt_cod_lis.TabIndex = 54
        Me.txt_cod_lis.Visible = False
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(685, 11)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(36, 20)
        Me.txt_vendedor.TabIndex = 53
        Me.txt_vendedor.Visible = False
        '
        'txt_fecHA_emi
        '
        Me.txt_fecHA_emi.Location = New System.Drawing.Point(643, 11)
        Me.txt_fecHA_emi.Name = "txt_fecHA_emi"
        Me.txt_fecHA_emi.Size = New System.Drawing.Size(36, 20)
        Me.txt_fecHA_emi.TabIndex = 52
        Me.txt_fecHA_emi.Visible = False
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(596, 11)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(36, 20)
        Me.txt_nombre.TabIndex = 51
        Me.txt_nombre.Visible = False
        '
        'txt_cod_cli
        '
        Me.txt_cod_cli.Location = New System.Drawing.Point(554, 12)
        Me.txt_cod_cli.Name = "txt_cod_cli"
        Me.txt_cod_cli.Size = New System.Drawing.Size(36, 20)
        Me.txt_cod_cli.TabIndex = 50
        Me.txt_cod_cli.Visible = False
        '
        'txt_talon
        '
        Me.txt_talon.Location = New System.Drawing.Point(499, 11)
        Me.txt_talon.Name = "txt_talon"
        Me.txt_talon.Size = New System.Drawing.Size(42, 20)
        Me.txt_talon.TabIndex = 49
        Me.txt_talon.Visible = False
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(442, 10)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(42, 20)
        Me.txt_numero.TabIndex = 48
        Me.txt_numero.Visible = False
        '
        'txt_prefijo
        '
        Me.txt_prefijo.Location = New System.Drawing.Point(392, 10)
        Me.txt_prefijo.Name = "txt_prefijo"
        Me.txt_prefijo.Size = New System.Drawing.Size(42, 20)
        Me.txt_prefijo.TabIndex = 47
        Me.txt_prefijo.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Location = New System.Drawing.Point(307, 9)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(31, 20)
        Me.txt_tipo.TabIndex = 45
        Me.txt_tipo.Visible = False
        '
        'txt_total_grilla
        '
        Me.txt_total_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_total_grilla.BackColor = System.Drawing.Color.White
        Me.txt_total_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_grilla.ForeColor = System.Drawing.Color.Black
        Me.txt_total_grilla.Location = New System.Drawing.Point(643, 417)
        Me.txt_total_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_total_grilla.Name = "txt_total_grilla"
        Me.txt_total_grilla.ReadOnly = True
        Me.txt_total_grilla.Size = New System.Drawing.Size(142, 21)
        Me.txt_total_grilla.TabIndex = 44
        Me.txt_total_grilla.TabStop = False
        Me.txt_total_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_imp_interno_grilla
        '
        Me.txt_imp_interno_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_imp_interno_grilla.BackColor = System.Drawing.Color.White
        Me.txt_imp_interno_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_imp_interno_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_interno_grilla.ForeColor = System.Drawing.Color.Black
        Me.txt_imp_interno_grilla.Location = New System.Drawing.Point(517, 417)
        Me.txt_imp_interno_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_imp_interno_grilla.Name = "txt_imp_interno_grilla"
        Me.txt_imp_interno_grilla.ReadOnly = True
        Me.txt_imp_interno_grilla.Size = New System.Drawing.Size(127, 21)
        Me.txt_imp_interno_grilla.TabIndex = 43
        Me.txt_imp_interno_grilla.TabStop = False
        Me.txt_imp_interno_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_insc_10
        '
        Me.txt_insc_10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_insc_10.BackColor = System.Drawing.Color.White
        Me.txt_insc_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_insc_10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_insc_10.ForeColor = System.Drawing.Color.Black
        Me.txt_insc_10.Location = New System.Drawing.Point(386, 417)
        Me.txt_insc_10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_insc_10.Name = "txt_insc_10"
        Me.txt_insc_10.ReadOnly = True
        Me.txt_insc_10.Size = New System.Drawing.Size(132, 21)
        Me.txt_insc_10.TabIndex = 42
        Me.txt_insc_10.TabStop = False
        Me.txt_insc_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_inscripto
        '
        Me.txt_inscripto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_inscripto.BackColor = System.Drawing.Color.White
        Me.txt_inscripto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_inscripto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inscripto.ForeColor = System.Drawing.Color.Black
        Me.txt_inscripto.Location = New System.Drawing.Point(262, 417)
        Me.txt_inscripto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_inscripto.Name = "txt_inscripto"
        Me.txt_inscripto.ReadOnly = True
        Me.txt_inscripto.Size = New System.Drawing.Size(124, 21)
        Me.txt_inscripto.TabIndex = 41
        Me.txt_inscripto.TabStop = False
        Me.txt_inscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_exento
        '
        Me.txt_exento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_exento.BackColor = System.Drawing.Color.White
        Me.txt_exento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_exento.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exento.ForeColor = System.Drawing.Color.Black
        Me.txt_exento.Location = New System.Drawing.Point(137, 417)
        Me.txt_exento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_exento.Name = "txt_exento"
        Me.txt_exento.ReadOnly = True
        Me.txt_exento.Size = New System.Drawing.Size(126, 21)
        Me.txt_exento.TabIndex = 40
        Me.txt_exento.TabStop = False
        Me.txt_exento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_gravado
        '
        Me.txt_gravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_gravado.BackColor = System.Drawing.Color.White
        Me.txt_gravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gravado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gravado.ForeColor = System.Drawing.Color.Black
        Me.txt_gravado.Location = New System.Drawing.Point(7, 417)
        Me.txt_gravado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_gravado.Name = "txt_gravado"
        Me.txt_gravado.ReadOnly = True
        Me.txt_gravado.Size = New System.Drawing.Size(131, 21)
        Me.txt_gravado.TabIndex = 39
        Me.txt_gravado.TabStop = False
        Me.txt_gravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(643, 398)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(142, 19)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(517, 398)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 19)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Imp. Interno"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(386, 398)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 19)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "I.V.A 10.5%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(262, 398)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 19)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "I.V.A 21%"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(137, 398)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(126, 19)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Exento"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 398)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 19)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Sub Total"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_letra
        '
        Me.txt_letra.Location = New System.Drawing.Point(344, 10)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(37, 20)
        Me.txt_letra.TabIndex = 2
        Me.txt_letra.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(7, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 25)
        Me.Panel1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_quita_art, Me.tool_reemplaza_art, Me.tool_pedido, Me.Tool_borra_pedido, Me.Tool_agerga_item, Me.ToolStripLabel1, Me.Tool_txt_descuento})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(248, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tool_quita_art
        '
        Me.tool_quita_art.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_quita_art.Image = Global.pym.My.Resources.Resources.cancel
        Me.tool_quita_art.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_quita_art.Name = "tool_quita_art"
        Me.tool_quita_art.Size = New System.Drawing.Size(23, 22)
        Me.tool_quita_art.Text = "Quita articulo"
        '
        'tool_reemplaza_art
        '
        Me.tool_reemplaza_art.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_reemplaza_art.Image = Global.pym.My.Resources.Resources.add
        Me.tool_reemplaza_art.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_reemplaza_art.Name = "tool_reemplaza_art"
        Me.tool_reemplaza_art.Size = New System.Drawing.Size(23, 22)
        Me.tool_reemplaza_art.Text = "Reemplaza articulo"
        '
        'tool_pedido
        '
        Me.tool_pedido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_pedido.Image = Global.pym.My.Resources.Resources.server
        Me.tool_pedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_pedido.Name = "tool_pedido"
        Me.tool_pedido.Size = New System.Drawing.Size(23, 22)
        Me.tool_pedido.Text = "Confirmar factura"
        '
        'Tool_borra_pedido
        '
        Me.Tool_borra_pedido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_borra_pedido.Image = CType(resources.GetObject("Tool_borra_pedido.Image"), System.Drawing.Image)
        Me.Tool_borra_pedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_borra_pedido.Name = "Tool_borra_pedido"
        Me.Tool_borra_pedido.Size = New System.Drawing.Size(23, 22)
        Me.Tool_borra_pedido.Text = "Borra pedido"
        '
        'Tool_agerga_item
        '
        Me.Tool_agerga_item.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_agerga_item.Image = CType(resources.GetObject("Tool_agerga_item.Image"), System.Drawing.Image)
        Me.Tool_agerga_item.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_agerga_item.Name = "Tool_agerga_item"
        Me.Tool_agerga_item.Size = New System.Drawing.Size(23, 22)
        Me.Tool_agerga_item.Text = "Agregar articulo"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "desc.:"
        '
        'Tool_txt_descuento
        '
        Me.Tool_txt_descuento.Name = "Tool_txt_descuento"
        Me.Tool_txt_descuento.Size = New System.Drawing.Size(50, 25)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(7, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(778, 358)
        Me.DataGridView1.TabIndex = 0
        '
        'txt_muestra_datos
        '
        Me.txt_muestra_datos.BackColor = System.Drawing.Color.White
        Me.txt_muestra_datos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_muestra_datos.Location = New System.Drawing.Point(-1, 1)
        Me.txt_muestra_datos.Multiline = True
        Me.txt_muestra_datos.Name = "txt_muestra_datos"
        Me.txt_muestra_datos.ReadOnly = True
        Me.txt_muestra_datos.Size = New System.Drawing.Size(791, 95)
        Me.txt_muestra_datos.TabIndex = 1
        Me.txt_muestra_datos.Text = "0"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(674, 36)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(36, 20)
        Me.txt_estado_form.TabIndex = 55
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.UseSystemPasswordChar = True
        Me.txt_estado_form.Visible = False
        '
        'txt_cuit
        '
        Me.txt_cuit.Location = New System.Drawing.Point(264, 67)
        Me.txt_cuit.Name = "txt_cuit"
        Me.txt_cuit.Size = New System.Drawing.Size(151, 20)
        Me.txt_cuit.TabIndex = 56
        Me.txt_cuit.Visible = False
        '
        'txt_iva
        '
        Me.txt_iva.Location = New System.Drawing.Point(430, 67)
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.Size = New System.Drawing.Size(100, 20)
        Me.txt_iva.TabIndex = 57
        Me.txt_iva.Visible = False
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(581, 26)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(24, 30)
        Me.QrCodeImgControl1.TabIndex = 58
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        Me.QrCodeImgControl1.Visible = False
        '
        'Form_factura_preventa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.QrCodeImgControl1)
        Me.Controls.Add(Me.txt_iva)
        Me.Controls.Add(Me.txt_cuit)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.txt_muestra_datos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_factura_preventa"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturacion Preventa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_muestra_datos As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_imp_interno_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_insc_10 As System.Windows.Forms.TextBox
    Friend WithEvents txt_inscripto As System.Windows.Forms.TextBox
    Friend WithEvents txt_exento As System.Windows.Forms.TextBox
    Friend WithEvents txt_gravado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tool_quita_art As System.Windows.Forms.ToolStripButton
    Friend WithEvents tool_reemplaza_art As System.Windows.Forms.ToolStripButton
    Friend WithEvents tool_pedido As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_prefijo As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_talon As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cli As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecHA_emi As System.Windows.Forms.TextBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_lis As System.Windows.Forms.TextBox
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents Tool_borra_pedido As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_agerga_item As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_mueve_stock As System.Windows.Forms.TextBox
    Friend WithEvents txt_cuit As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Tool_txt_descuento As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
End Class
