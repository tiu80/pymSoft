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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_numerador))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmd_help = New System.Windows.Forms.Button()
        Me.txt_talonario = New mitextbox1.texto_solonum()
        Me.txt_interno = New System.Windows.Forms.TextBox()
        Me.cmd_eliminar = New System.Windows.Forms.Button()
        Me.cmd_actualizar = New System.Windows.Forms.Button()
        Me.cmd_guardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_int_debito_c = New System.Windows.Forms.TextBox()
        Me.txt_debito_c = New text_solo_num.solo_numeros()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txt_int_nc_c = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmd_consulta_comprobante_autorizado = New System.Windows.Forms.Button()
        Me.lbl_importe_cae = New text_solo_num.solo_numeros()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lbl_venc_cae = New System.Windows.Forms.MaskedTextBox()
        Me.txt_venc_cae = New System.Windows.Forms.MaskedTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_vencimiento_cae = New System.Windows.Forms.Label()
        Me.lbl_cae = New text_solo_num.solo_numeros()
        Me.txt_cae = New text_solo_num.solo_numeros()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_numero_aut = New mitextbox1.texto_solonum()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_pto_vta_aut = New mitextbox1.texto_solonum()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_tipo_aut = New mitextbox1.texto_solonum()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmd_verifica_ultimo_numero = New System.Windows.Forms.Button()
        Me.lbl_ultimo_comprobante = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_punto_venta_afip = New mitextbox1.texto_solonum()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_tipo_comprobante_afip = New mitextbox1.texto_solonum()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_n_credito_c = New text_solo_num.solo_numeros()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txt_int_debito_b = New System.Windows.Forms.TextBox()
        Me.txt_int_debito_a = New System.Windows.Forms.TextBox()
        Me.txt_debito_b = New text_solo_num.solo_numeros()
        Me.txt_debito_a = New text_solo_num.solo_numeros()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_int_orden_pago = New System.Windows.Forms.TextBox()
        Me.txt_orden_pago = New text_solo_num.solo_numeros()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_punto_venta = New mitextbox1.texto_solonum()
        Me.txt_int_nc_b = New System.Windows.Forms.TextBox()
        Me.txt_int_nc_a = New System.Windows.Forms.TextBox()
        Me.txt_int_pedido = New System.Windows.Forms.TextBox()
        Me.txt_int_remito = New System.Windows.Forms.TextBox()
        Me.txt_int_recibo = New System.Windows.Forms.TextBox()
        Me.txt_int_factc = New System.Windows.Forms.TextBox()
        Me.txt_int_factb = New System.Windows.Forms.TextBox()
        Me.txt_int_facta = New System.Windows.Forms.TextBox()
        Me.txt_int_p_vta = New System.Windows.Forms.TextBox()
        Me.txt_n_credito_b = New text_solo_num.solo_numeros()
        Me.txt_n_credito_a = New text_solo_num.solo_numeros()
        Me.txt_pedido = New text_solo_num.solo_numeros()
        Me.txt_remito = New text_solo_num.solo_numeros()
        Me.txt_recibo = New text_solo_num.solo_numeros()
        Me.txt_fact_c = New text_solo_num.solo_numeros()
        Me.txt_fact_b = New text_solo_num.solo_numeros()
        Me.txt_fact_a = New text_solo_num.solo_numeros()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl_respuesta_afip = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmd_help)
        Me.GroupBox1.Controls.Add(Me.txt_talonario)
        Me.GroupBox1.Controls.Add(Me.txt_interno)
        Me.GroupBox1.Controls.Add(Me.cmd_eliminar)
        Me.GroupBox1.Controls.Add(Me.cmd_actualizar)
        Me.GroupBox1.Controls.Add(Me.cmd_guardar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(646, 507)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(324, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 15)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Web Service Afip"
        '
        'cmd_help
        '
        Me.cmd_help.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_help.BackgroundImage = CType(resources.GetObject("cmd_help.BackgroundImage"), System.Drawing.Image)
        Me.cmd_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_help.FlatAppearance.BorderSize = 0
        Me.cmd_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_help.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_help.Location = New System.Drawing.Point(629, 13)
        Me.cmd_help.Name = "cmd_help"
        Me.cmd_help.Size = New System.Drawing.Size(16, 18)
        Me.cmd_help.TabIndex = 45
        Me.cmd_help.TabStop = False
        Me.cmd_help.UseVisualStyleBackColor = True
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
        Me.txt_interno.Location = New System.Drawing.Point(282, 10)
        Me.txt_interno.Name = "txt_interno"
        Me.txt_interno.Size = New System.Drawing.Size(24, 20)
        Me.txt_interno.TabIndex = 23
        Me.txt_interno.Visible = False
        '
        'cmd_eliminar
        '
        Me.cmd_eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_eliminar.BackColor = System.Drawing.Color.Black
        Me.cmd_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_eliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_eliminar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_eliminar.Location = New System.Drawing.Point(562, 456)
        Me.cmd_eliminar.Name = "cmd_eliminar"
        Me.cmd_eliminar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_eliminar.TabIndex = 26
        Me.cmd_eliminar.Text = "Borrar"
        Me.cmd_eliminar.UseVisualStyleBackColor = False
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(285, 458)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_actualizar.TabIndex = 25
        Me.cmd_actualizar.Text = "Actualizar"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'cmd_guardar
        '
        Me.cmd_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_guardar.BackColor = System.Drawing.Color.Black
        Me.cmd_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_guardar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_guardar.Location = New System.Drawing.Point(7, 456)
        Me.cmd_guardar.Name = "cmd_guardar"
        Me.cmd_guardar.Size = New System.Drawing.Size(78, 43)
        Me.cmd_guardar.TabIndex = 24
        Me.cmd_guardar.Text = "Guardar"
        Me.cmd_guardar.UseVisualStyleBackColor = False
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
        Me.GroupBox2.Controls.Add(Me.lbl_respuesta_afip)
        Me.GroupBox2.Controls.Add(Me.txt_int_debito_c)
        Me.GroupBox2.Controls.Add(Me.txt_debito_c)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.txt_int_nc_c)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txt_n_credito_c)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txt_int_debito_b)
        Me.GroupBox2.Controls.Add(Me.txt_int_debito_a)
        Me.GroupBox2.Controls.Add(Me.txt_debito_b)
        Me.GroupBox2.Controls.Add(Me.txt_debito_a)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txt_int_orden_pago)
        Me.GroupBox2.Controls.Add(Me.txt_orden_pago)
        Me.GroupBox2.Controls.Add(Me.Label27)
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
        Me.GroupBox2.Size = New System.Drawing.Size(633, 418)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_int_debito_c
        '
        Me.txt_int_debito_c.Location = New System.Drawing.Point(278, 391)
        Me.txt_int_debito_c.Name = "txt_int_debito_c"
        Me.txt_int_debito_c.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_debito_c.TabIndex = 50
        Me.txt_int_debito_c.Visible = False
        '
        'txt_debito_c
        '
        Me.txt_debito_c.Location = New System.Drawing.Point(173, 391)
        Me.txt_debito_c.Name = "txt_debito_c"
        Me.txt_debito_c.Size = New System.Drawing.Size(100, 20)
        Me.txt_debito_c.TabIndex = 49
        Me.txt_debito_c.Text = "0"
        Me.txt_debito_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(20, 395)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(109, 15)
        Me.Label31.TabIndex = 48
        Me.Label31.Text = "Nota de Debito ""C"""
        '
        'txt_int_nc_c
        '
        Me.txt_int_nc_c.Location = New System.Drawing.Point(278, 274)
        Me.txt_int_nc_c.Name = "txt_int_nc_c"
        Me.txt_int_nc_c.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_nc_c.TabIndex = 47
        Me.txt_int_nc_c.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.cmd_consulta_comprobante_autorizado)
        Me.GroupBox3.Controls.Add(Me.lbl_importe_cae)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.lbl_venc_cae)
        Me.GroupBox3.Controls.Add(Me.txt_venc_cae)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txt_vencimiento_cae)
        Me.GroupBox3.Controls.Add(Me.lbl_cae)
        Me.GroupBox3.Controls.Add(Me.txt_cae)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txt_numero_aut)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txt_pto_vta_aut)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txt_tipo_aut)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cmd_verifica_ultimo_numero)
        Me.GroupBox3.Controls.Add(Me.lbl_ultimo_comprobante)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txt_punto_venta_afip)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txt_tipo_comprobante_afip)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(321, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(318, 346)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(7, 266)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(145, 15)
        Me.Label28.TabIndex = 42
        Me.Label28.Text = "Grabar en caso falla afip"
        '
        'cmd_consulta_comprobante_autorizado
        '
        Me.cmd_consulta_comprobante_autorizado.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_consulta_comprobante_autorizado.BackColor = System.Drawing.Color.Black
        Me.cmd_consulta_comprobante_autorizado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_consulta_comprobante_autorizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_consulta_comprobante_autorizado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_consulta_comprobante_autorizado.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_consulta_comprobante_autorizado.Location = New System.Drawing.Point(232, 208)
        Me.cmd_consulta_comprobante_autorizado.Name = "cmd_consulta_comprobante_autorizado"
        Me.cmd_consulta_comprobante_autorizado.Size = New System.Drawing.Size(78, 43)
        Me.cmd_consulta_comprobante_autorizado.TabIndex = 41
        Me.cmd_consulta_comprobante_autorizado.Text = "Consultar"
        Me.cmd_consulta_comprobante_autorizado.UseVisualStyleBackColor = False
        '
        'lbl_importe_cae
        '
        Me.lbl_importe_cae.BackColor = System.Drawing.Color.Silver
        Me.lbl_importe_cae.Location = New System.Drawing.Point(85, 226)
        Me.lbl_importe_cae.Name = "lbl_importe_cae"
        Me.lbl_importe_cae.ReadOnly = True
        Me.lbl_importe_cae.Size = New System.Drawing.Size(141, 20)
        Me.lbl_importe_cae.TabIndex = 40
        Me.lbl_importe_cae.TabStop = False
        Me.lbl_importe_cae.Text = "0"
        Me.lbl_importe_cae.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 230)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 15)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "Importe:"
        '
        'lbl_venc_cae
        '
        Me.lbl_venc_cae.BackColor = System.Drawing.Color.Silver
        Me.lbl_venc_cae.Location = New System.Drawing.Point(85, 194)
        Me.lbl_venc_cae.Mask = "00/00/0000"
        Me.lbl_venc_cae.Name = "lbl_venc_cae"
        Me.lbl_venc_cae.ReadOnly = True
        Me.lbl_venc_cae.Size = New System.Drawing.Size(141, 20)
        Me.lbl_venc_cae.TabIndex = 38
        Me.lbl_venc_cae.TabStop = False
        Me.lbl_venc_cae.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lbl_venc_cae.ValidatingType = GetType(Date)
        '
        'txt_venc_cae
        '
        Me.txt_venc_cae.Location = New System.Drawing.Point(84, 310)
        Me.txt_venc_cae.Mask = "00/00/0000"
        Me.txt_venc_cae.Name = "txt_venc_cae"
        Me.txt_venc_cae.Size = New System.Drawing.Size(209, 20)
        Me.txt_venc_cae.TabIndex = 32
        Me.txt_venc_cae.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_venc_cae.ValidatingType = GetType(Date)
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 199)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 15)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "Venc. CAE:"
        '
        'txt_vencimiento_cae
        '
        Me.txt_vencimiento_cae.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_vencimiento_cae.AutoSize = True
        Me.txt_vencimiento_cae.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vencimiento_cae.Location = New System.Drawing.Point(10, 314)
        Me.txt_vencimiento_cae.Name = "txt_vencimiento_cae"
        Me.txt_vencimiento_cae.Size = New System.Drawing.Size(66, 15)
        Me.txt_vencimiento_cae.TabIndex = 32
        Me.txt_vencimiento_cae.Text = "Venc. CAE:"
        '
        'lbl_cae
        '
        Me.lbl_cae.BackColor = System.Drawing.Color.Silver
        Me.lbl_cae.Location = New System.Drawing.Point(85, 166)
        Me.lbl_cae.Name = "lbl_cae"
        Me.lbl_cae.ReadOnly = True
        Me.lbl_cae.Size = New System.Drawing.Size(141, 20)
        Me.lbl_cae.TabIndex = 36
        Me.lbl_cae.TabStop = False
        Me.lbl_cae.Text = "0"
        Me.lbl_cae.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cae
        '
        Me.txt_cae.Location = New System.Drawing.Point(85, 283)
        Me.txt_cae.MaxLength = 14
        Me.txt_cae.Name = "txt_cae"
        Me.txt_cae.Size = New System.Drawing.Size(208, 20)
        Me.txt_cae.TabIndex = 31
        Me.txt_cae.Text = "0"
        Me.txt_cae.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 289)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 15)
        Me.Label21.TabIndex = 30
        Me.Label21.Text = "CAE:"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(6, 170)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 15)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "CAE:"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(-1, 257)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(314, 1)
        Me.Label22.TabIndex = 34
        Me.Label22.Text = "Label22"
        '
        'txt_numero_aut
        '
        Me.txt_numero_aut.Location = New System.Drawing.Point(260, 135)
        Me.txt_numero_aut.Name = "txt_numero_aut"
        Me.txt_numero_aut.Size = New System.Drawing.Size(50, 20)
        Me.txt_numero_aut.TabIndex = 30
        Me.txt_numero_aut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(205, 140)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 15)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Numero:"
        '
        'txt_pto_vta_aut
        '
        Me.txt_pto_vta_aut.Location = New System.Drawing.Point(145, 135)
        Me.txt_pto_vta_aut.Name = "txt_pto_vta_aut"
        Me.txt_pto_vta_aut.Size = New System.Drawing.Size(45, 20)
        Me.txt_pto_vta_aut.TabIndex = 28
        Me.txt_pto_vta_aut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(82, 140)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 15)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Punto Vta:"
        '
        'txt_tipo_aut
        '
        Me.txt_tipo_aut.Location = New System.Drawing.Point(40, 135)
        Me.txt_tipo_aut.Name = "txt_tipo_aut"
        Me.txt_tipo_aut.Size = New System.Drawing.Size(32, 20)
        Me.txt_tipo_aut.TabIndex = 26
        Me.txt_tipo_aut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txt_tipo_aut, "1- Facturas A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3- Nota Credito A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6- Factura B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8- Nota Credito B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "11- Factura C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "13- Nota Credito C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 140)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 15)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Tipo:"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(209, 15)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Consultar Comprobante Autorizado:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(-1, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(314, 1)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Label16"
        '
        'cmd_verifica_ultimo_numero
        '
        Me.cmd_verifica_ultimo_numero.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmd_verifica_ultimo_numero.BackColor = System.Drawing.Color.Black
        Me.cmd_verifica_ultimo_numero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_verifica_ultimo_numero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_verifica_ultimo_numero.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_verifica_ultimo_numero.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_verifica_ultimo_numero.Location = New System.Drawing.Point(232, 12)
        Me.cmd_verifica_ultimo_numero.Name = "cmd_verifica_ultimo_numero"
        Me.cmd_verifica_ultimo_numero.Size = New System.Drawing.Size(78, 43)
        Me.cmd_verifica_ultimo_numero.TabIndex = 22
        Me.cmd_verifica_ultimo_numero.Text = "Verificar"
        Me.cmd_verifica_ultimo_numero.UseVisualStyleBackColor = False
        '
        'lbl_ultimo_comprobante
        '
        Me.lbl_ultimo_comprobante.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_ultimo_comprobante.BackColor = System.Drawing.Color.Silver
        Me.lbl_ultimo_comprobante.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ultimo_comprobante.Location = New System.Drawing.Point(137, 63)
        Me.lbl_ultimo_comprobante.Name = "lbl_ultimo_comprobante"
        Me.lbl_ultimo_comprobante.Size = New System.Drawing.Size(175, 15)
        Me.lbl_ultimo_comprobante.TabIndex = 9
        Me.lbl_ultimo_comprobante.Text = "00000000"
        Me.lbl_ultimo_comprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 15)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Ultimo Comprobante:"
        '
        'txt_punto_venta_afip
        '
        Me.txt_punto_venta_afip.Location = New System.Drawing.Point(171, 30)
        Me.txt_punto_venta_afip.Name = "txt_punto_venta_afip"
        Me.txt_punto_venta_afip.Size = New System.Drawing.Size(45, 20)
        Me.txt_punto_venta_afip.TabIndex = 7
        Me.txt_punto_venta_afip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(93, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 15)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Punto Venta:"
        '
        'txt_tipo_comprobante_afip
        '
        Me.txt_tipo_comprobante_afip.Location = New System.Drawing.Point(46, 30)
        Me.txt_tipo_comprobante_afip.Name = "txt_tipo_comprobante_afip"
        Me.txt_tipo_comprobante_afip.Size = New System.Drawing.Size(32, 20)
        Me.txt_tipo_comprobante_afip.TabIndex = 5
        Me.txt_tipo_comprobante_afip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txt_tipo_comprobante_afip, "1- Facturas A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2- Debito A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3- Nota Credito A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6- Factura B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7- Debito B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8- Nota" &
        " Credito B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "11- Factura C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "13- Nota Credito C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 15)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Tipo:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 15)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Consultar Ultimo Numero:"
        '
        'txt_n_credito_c
        '
        Me.txt_n_credito_c.Location = New System.Drawing.Point(173, 272)
        Me.txt_n_credito_c.Name = "txt_n_credito_c"
        Me.txt_n_credito_c.Size = New System.Drawing.Size(100, 20)
        Me.txt_n_credito_c.TabIndex = 20
        Me.txt_n_credito_c.Text = "0"
        Me.txt_n_credito_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(20, 276)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(130, 15)
        Me.Label30.TabIndex = 45
        Me.Label30.Text = "Numero N. Credito ""C"""
        '
        'txt_int_debito_b
        '
        Me.txt_int_debito_b.Location = New System.Drawing.Point(278, 362)
        Me.txt_int_debito_b.Name = "txt_int_debito_b"
        Me.txt_int_debito_b.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_debito_b.TabIndex = 44
        Me.txt_int_debito_b.Visible = False
        '
        'txt_int_debito_a
        '
        Me.txt_int_debito_a.Location = New System.Drawing.Point(278, 336)
        Me.txt_int_debito_a.Name = "txt_int_debito_a"
        Me.txt_int_debito_a.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_debito_a.TabIndex = 43
        Me.txt_int_debito_a.Visible = False
        '
        'txt_debito_b
        '
        Me.txt_debito_b.Location = New System.Drawing.Point(173, 361)
        Me.txt_debito_b.Name = "txt_debito_b"
        Me.txt_debito_b.Size = New System.Drawing.Size(100, 20)
        Me.txt_debito_b.TabIndex = 23
        Me.txt_debito_b.Text = "0"
        Me.txt_debito_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debito_a
        '
        Me.txt_debito_a.Location = New System.Drawing.Point(173, 331)
        Me.txt_debito_a.Name = "txt_debito_a"
        Me.txt_debito_a.Size = New System.Drawing.Size(100, 20)
        Me.txt_debito_a.TabIndex = 22
        Me.txt_debito_a.Text = "0"
        Me.txt_debito_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(20, 365)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 15)
        Me.Label29.TabIndex = 40
        Me.Label29.Text = "Nota de Debito ""B"""
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(18, 336)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 15)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "Nota de Debito ""A"""
        '
        'txt_int_orden_pago
        '
        Me.txt_int_orden_pago.Location = New System.Drawing.Point(278, 303)
        Me.txt_int_orden_pago.Name = "txt_int_orden_pago"
        Me.txt_int_orden_pago.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_orden_pago.TabIndex = 38
        Me.txt_int_orden_pago.Visible = False
        '
        'txt_orden_pago
        '
        Me.txt_orden_pago.Location = New System.Drawing.Point(173, 301)
        Me.txt_orden_pago.Name = "txt_orden_pago"
        Me.txt_orden_pago.Size = New System.Drawing.Size(100, 20)
        Me.txt_orden_pago.TabIndex = 21
        Me.txt_orden_pago.Text = "0"
        Me.txt_orden_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(19, 305)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(90, 15)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Orden de Pago"
        '
        'txt_punto_venta
        '
        Me.txt_punto_venta.Location = New System.Drawing.Point(173, 12)
        Me.txt_punto_venta.Name = "txt_punto_venta"
        Me.txt_punto_venta.Size = New System.Drawing.Size(100, 20)
        Me.txt_punto_venta.TabIndex = 29
        Me.txt_punto_venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_int_nc_b
        '
        Me.txt_int_nc_b.Location = New System.Drawing.Point(278, 245)
        Me.txt_int_nc_b.Name = "txt_int_nc_b"
        Me.txt_int_nc_b.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_nc_b.TabIndex = 28
        Me.txt_int_nc_b.Visible = False
        '
        'txt_int_nc_a
        '
        Me.txt_int_nc_a.Location = New System.Drawing.Point(278, 216)
        Me.txt_int_nc_a.Name = "txt_int_nc_a"
        Me.txt_int_nc_a.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_nc_a.TabIndex = 27
        Me.txt_int_nc_a.Visible = False
        '
        'txt_int_pedido
        '
        Me.txt_int_pedido.Location = New System.Drawing.Point(278, 190)
        Me.txt_int_pedido.Name = "txt_int_pedido"
        Me.txt_int_pedido.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_pedido.TabIndex = 26
        Me.txt_int_pedido.Visible = False
        '
        'txt_int_remito
        '
        Me.txt_int_remito.Location = New System.Drawing.Point(278, 161)
        Me.txt_int_remito.Name = "txt_int_remito"
        Me.txt_int_remito.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_remito.TabIndex = 25
        Me.txt_int_remito.Visible = False
        '
        'txt_int_recibo
        '
        Me.txt_int_recibo.Location = New System.Drawing.Point(278, 134)
        Me.txt_int_recibo.Name = "txt_int_recibo"
        Me.txt_int_recibo.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_recibo.TabIndex = 24
        Me.txt_int_recibo.Visible = False
        '
        'txt_int_factc
        '
        Me.txt_int_factc.Location = New System.Drawing.Point(278, 101)
        Me.txt_int_factc.Name = "txt_int_factc"
        Me.txt_int_factc.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_factc.TabIndex = 23
        Me.txt_int_factc.Visible = False
        '
        'txt_int_factb
        '
        Me.txt_int_factb.Location = New System.Drawing.Point(278, 71)
        Me.txt_int_factb.Name = "txt_int_factb"
        Me.txt_int_factb.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_factb.TabIndex = 22
        Me.txt_int_factb.Visible = False
        '
        'txt_int_facta
        '
        Me.txt_int_facta.Location = New System.Drawing.Point(278, 42)
        Me.txt_int_facta.Name = "txt_int_facta"
        Me.txt_int_facta.Size = New System.Drawing.Size(24, 20)
        Me.txt_int_facta.TabIndex = 21
        Me.txt_int_facta.Visible = False
        '
        'txt_int_p_vta
        '
        Me.txt_int_p_vta.Location = New System.Drawing.Point(278, 12)
        Me.txt_int_p_vta.Name = "txt_int_p_vta"
        Me.txt_int_p_vta.Size = New System.Drawing.Size(24, 20)
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
        Me.txt_n_credito_a.Location = New System.Drawing.Point(173, 216)
        Me.txt_n_credito_a.Name = "txt_n_credito_a"
        Me.txt_n_credito_a.Size = New System.Drawing.Size(100, 20)
        Me.txt_n_credito_a.TabIndex = 18
        Me.txt_n_credito_a.Text = "0"
        Me.txt_n_credito_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(173, 188)
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(100, 20)
        Me.txt_pedido.TabIndex = 17
        Me.txt_pedido.Text = "0"
        Me.txt_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_remito
        '
        Me.txt_remito.Location = New System.Drawing.Point(173, 159)
        Me.txt_remito.Name = "txt_remito"
        Me.txt_remito.Size = New System.Drawing.Size(100, 20)
        Me.txt_remito.TabIndex = 16
        Me.txt_remito.Text = "0"
        Me.txt_remito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_recibo
        '
        Me.txt_recibo.Location = New System.Drawing.Point(173, 127)
        Me.txt_recibo.Name = "txt_recibo"
        Me.txt_recibo.Size = New System.Drawing.Size(100, 20)
        Me.txt_recibo.TabIndex = 15
        Me.txt_recibo.Text = "0"
        Me.txt_recibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_c
        '
        Me.txt_fact_c.Location = New System.Drawing.Point(173, 98)
        Me.txt_fact_c.Name = "txt_fact_c"
        Me.txt_fact_c.Size = New System.Drawing.Size(100, 20)
        Me.txt_fact_c.TabIndex = 14
        Me.txt_fact_c.Text = "0"
        Me.txt_fact_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_b
        '
        Me.txt_fact_b.Location = New System.Drawing.Point(173, 68)
        Me.txt_fact_b.Name = "txt_fact_b"
        Me.txt_fact_b.Size = New System.Drawing.Size(100, 20)
        Me.txt_fact_b.TabIndex = 13
        Me.txt_fact_b.Text = "0"
        Me.txt_fact_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_fact_a
        '
        Me.txt_fact_a.Location = New System.Drawing.Point(173, 39)
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
        Me.Label10.Location = New System.Drawing.Point(19, 247)
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
        Me.Label9.Location = New System.Drawing.Point(19, 222)
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
        Me.Label8.Location = New System.Drawing.Point(19, 195)
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
        Me.Label7.Location = New System.Drawing.Point(18, 166)
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
        Me.Label6.Location = New System.Drawing.Point(18, 136)
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
        Me.Label5.Location = New System.Drawing.Point(18, 103)
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
        Me.Label4.Location = New System.Drawing.Point(18, 71)
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
        Me.Label3.Location = New System.Drawing.Point(18, 41)
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
        Me.Label2.Location = New System.Drawing.Point(18, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numero Punto Venta"
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'lbl_respuesta_afip
        '
        Me.lbl_respuesta_afip.ForeColor = System.Drawing.Color.Red
        Me.lbl_respuesta_afip.Location = New System.Drawing.Point(323, 371)
        Me.lbl_respuesta_afip.Name = "lbl_respuesta_afip"
        Me.lbl_respuesta_afip.Size = New System.Drawing.Size(304, 39)
        Me.lbl_respuesta_afip.TabIndex = 51
        '
        'Form_numerador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(661, 514)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_numerador"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numeradores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmd_help As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents lbl_ultimo_comprobante As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_punto_venta_afip As mitextbox1.texto_solonum
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_comprobante_afip As mitextbox1.texto_solonum
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmd_verifica_ultimo_numero As System.Windows.Forms.Button
    Friend WithEvents txt_numero_aut As mitextbox1.texto_solonum
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_pto_vta_aut As mitextbox1.texto_solonum
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_aut As mitextbox1.texto_solonum
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_vencimiento_cae As System.Windows.Forms.Label
    Friend WithEvents txt_cae As text_solo_num.solo_numeros
    Friend WithEvents txt_venc_cae As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbl_importe_cae As text_solo_num.solo_numeros
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lbl_venc_cae As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbl_cae As text_solo_num.solo_numeros
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmd_consulta_comprobante_autorizado As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txt_int_orden_pago As System.Windows.Forms.TextBox
    Friend WithEvents txt_orden_pago As text_solo_num.solo_numeros
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_debito_b As text_solo_num.solo_numeros
    Friend WithEvents txt_debito_a As text_solo_num.solo_numeros
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_int_debito_b As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_debito_a As System.Windows.Forms.TextBox
    Friend WithEvents txt_int_nc_c As System.Windows.Forms.TextBox
    Friend WithEvents txt_n_credito_c As text_solo_num.solo_numeros
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_int_debito_c As System.Windows.Forms.TextBox
    Friend WithEvents txt_debito_c As text_solo_num.solo_numeros
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lbl_respuesta_afip As Label
End Class
