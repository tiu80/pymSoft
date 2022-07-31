<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_compras
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_compras))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.imp_interno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva_insc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.des_cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.des_iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_cuenta = New System.Windows.Forms.Label
        Me.lbl_iva = New System.Windows.Forms.Label
        Me.Panel = New System.Windows.Forms.Panel
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_per_iva = New mitextbox1.texto_solonum
        Me.txt_per_ing_bruto = New mitextbox1.texto_solonum
        Me.txt_iva_inscripto = New mitextbox1.texto_solonum
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_exento1 = New mitextbox1.texto_solonum
        Me.txt_imp_interno = New mitextbox1.texto_solonum
        Me.txt_neto_gravado = New mitextbox1.texto_solonum
        Me.txt_credito = New mitextbox1.texto_solonum
        Me.txt_debito = New mitextbox1.texto_solonum
        Me.txt_cod_iva = New mitextbox1.texto_solonum
        Me.txt_cod_cta = New mitextbox1.texto_solonum
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_total_grilla = New System.Windows.Forms.TextBox
        Me.txt_imp_interno_grilla = New System.Windows.Forms.TextBox
        Me.txt_n_insc = New System.Windows.Forms.TextBox
        Me.txt_inscripto = New System.Windows.Forms.TextBox
        Me.txt_exento = New System.Windows.Forms.TextBox
        Me.txt_gravado = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_talonario_pred = New System.Windows.Forms.TextBox
        Me.txt_tipo_iva = New System.Windows.Forms.TextBox
        Me.cmb_forma_pago = New System.Windows.Forms.ComboBox
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.lbl_forma_pago = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_cuit = New System.Windows.Forms.TextBox
        Me.txt_tipo_fact = New System.Windows.Forms.TextBox
        Me.txt_numero = New mitextbox1.texto_solonum
        Me.txt_prefijo = New mitextbox1.texto_solonum
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.dt_fec_arqueo = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dt_fec_vto = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_emision = New System.Windows.Forms.DateTimePicker
        Me.lbl_vto = New System.Windows.Forms.Label
        Me.lbl_fec_emision = New System.Windows.Forms.Label
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.txt_lista = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 22
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column8, Me.imp_interno, Me.Column3, Me.Column4, Me.Column6, Me.iva_insc, Me.cod_cta, Me.des_cta, Me.cod_iva, Me.des_iva})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(9, 12)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(774, 228)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'Column1
        '
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 300
        '
        'Column5
        '
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "exento"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'imp_interno
        '
        Me.imp_interno.HeaderText = "impuesto inerno"
        Me.imp_interno.Name = "imp_interno"
        Me.imp_interno.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "neto gravado"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "per iva"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "per ib"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'iva_insc
        '
        Me.iva_insc.HeaderText = "Iva Insc"
        Me.iva_insc.Name = "iva_insc"
        Me.iva_insc.ReadOnly = True
        '
        'cod_cta
        '
        Me.cod_cta.HeaderText = "cta"
        Me.cod_cta.Name = "cod_cta"
        Me.cod_cta.ReadOnly = True
        '
        'des_cta
        '
        Me.des_cta.HeaderText = "des_cta"
        Me.des_cta.Name = "des_cta"
        Me.des_cta.ReadOnly = True
        '
        'cod_iva
        '
        Me.cod_iva.HeaderText = "cod_iva"
        Me.cod_iva.Name = "cod_iva"
        Me.cod_iva.ReadOnly = True
        '
        'des_iva
        '
        Me.des_iva.HeaderText = "des_iva"
        Me.des_iva.Name = "des_iva"
        Me.des_iva.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.txt_total_grilla)
        Me.GroupBox3.Controls.Add(Me.txt_imp_interno_grilla)
        Me.GroupBox3.Controls.Add(Me.txt_n_insc)
        Me.GroupBox3.Controls.Add(Me.txt_inscripto)
        Me.GroupBox3.Controls.Add(Me.txt_exento)
        Me.GroupBox3.Controls.Add(Me.txt_gravado)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Location = New System.Drawing.Point(-2, 143)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(794, 390)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.lbl_cuenta)
        Me.GroupBox4.Controls.Add(Me.lbl_iva)
        Me.GroupBox4.Controls.Add(Me.Panel)
        Me.GroupBox4.Controls.Add(Me.txt_credito)
        Me.GroupBox4.Controls.Add(Me.txt_debito)
        Me.GroupBox4.Controls.Add(Me.txt_cod_iva)
        Me.GroupBox4.Controls.Add(Me.txt_cod_cta)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 259)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(774, 126)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'lbl_cuenta
        '
        Me.lbl_cuenta.AutoSize = True
        Me.lbl_cuenta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cuenta.Location = New System.Drawing.Point(199, 16)
        Me.lbl_cuenta.Name = "lbl_cuenta"
        Me.lbl_cuenta.Size = New System.Drawing.Size(0, 15)
        Me.lbl_cuenta.TabIndex = 13
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(199, 47)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(0, 13)
        Me.lbl_iva.TabIndex = 12
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel.Controls.Add(Me.Label20)
        Me.Panel.Controls.Add(Me.Label21)
        Me.Panel.Controls.Add(Me.Label22)
        Me.Panel.Controls.Add(Me.txt_per_iva)
        Me.Panel.Controls.Add(Me.txt_per_ing_bruto)
        Me.Panel.Controls.Add(Me.txt_iva_inscripto)
        Me.Panel.Controls.Add(Me.Label13)
        Me.Panel.Controls.Add(Me.Label12)
        Me.Panel.Controls.Add(Me.Label11)
        Me.Panel.Controls.Add(Me.txt_exento1)
        Me.Panel.Controls.Add(Me.txt_imp_interno)
        Me.Panel.Controls.Add(Me.txt_neto_gravado)
        Me.Panel.Location = New System.Drawing.Point(318, 33)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(450, 93)
        Me.Panel.TabIndex = 11
        Me.Panel.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(272, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 15)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Per I.V.A:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(272, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 15)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Per. IB:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(235, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 15)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "I.V.A Inscripto:"
        '
        'txt_per_iva
        '
        Me.txt_per_iva.AcceptsTab = True
        Me.txt_per_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_per_iva.Location = New System.Drawing.Point(327, 63)
        Me.txt_per_iva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_per_iva.MaxLength = 9
        Me.txt_per_iva.Name = "txt_per_iva"
        Me.txt_per_iva.Size = New System.Drawing.Size(107, 21)
        Me.txt_per_iva.TabIndex = 16
        Me.txt_per_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_per_ing_bruto
        '
        Me.txt_per_ing_bruto.AcceptsReturn = True
        Me.txt_per_ing_bruto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_per_ing_bruto.Location = New System.Drawing.Point(327, 35)
        Me.txt_per_ing_bruto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_per_ing_bruto.MaxLength = 9
        Me.txt_per_ing_bruto.Name = "txt_per_ing_bruto"
        Me.txt_per_ing_bruto.Size = New System.Drawing.Size(107, 21)
        Me.txt_per_ing_bruto.TabIndex = 15
        Me.txt_per_ing_bruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_inscripto
        '
        Me.txt_iva_inscripto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva_inscripto.Location = New System.Drawing.Point(327, 7)
        Me.txt_iva_inscripto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_iva_inscripto.MaxLength = 9
        Me.txt_iva_inscripto.Name = "txt_iva_inscripto"
        Me.txt_iva_inscripto.Size = New System.Drawing.Size(107, 21)
        Me.txt_iva_inscripto.TabIndex = 14
        Me.txt_iva_inscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Exento:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Imp. Interno:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 15)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Neto Grabado:"
        '
        'txt_exento1
        '
        Me.txt_exento1.BackColor = System.Drawing.Color.White
        Me.txt_exento1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exento1.Location = New System.Drawing.Point(98, 64)
        Me.txt_exento1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_exento1.MaxLength = 9
        Me.txt_exento1.Name = "txt_exento1"
        Me.txt_exento1.Size = New System.Drawing.Size(98, 21)
        Me.txt_exento1.TabIndex = 10
        Me.txt_exento1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_imp_interno
        '
        Me.txt_imp_interno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_interno.Location = New System.Drawing.Point(98, 36)
        Me.txt_imp_interno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_imp_interno.MaxLength = 9
        Me.txt_imp_interno.Name = "txt_imp_interno"
        Me.txt_imp_interno.Size = New System.Drawing.Size(98, 21)
        Me.txt_imp_interno.TabIndex = 9
        Me.txt_imp_interno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_neto_gravado
        '
        Me.txt_neto_gravado.BackColor = System.Drawing.Color.White
        Me.txt_neto_gravado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto_gravado.Location = New System.Drawing.Point(98, 8)
        Me.txt_neto_gravado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_neto_gravado.MaxLength = 9
        Me.txt_neto_gravado.Name = "txt_neto_gravado"
        Me.txt_neto_gravado.ReadOnly = True
        Me.txt_neto_gravado.Size = New System.Drawing.Size(98, 21)
        Me.txt_neto_gravado.TabIndex = 8
        Me.txt_neto_gravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_credito
        '
        Me.txt_credito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_credito.Location = New System.Drawing.Point(125, 97)
        Me.txt_credito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_credito.MaxLength = 9
        Me.txt_credito.Name = "txt_credito"
        Me.txt_credito.Size = New System.Drawing.Size(67, 21)
        Me.txt_credito.TabIndex = 10
        Me.txt_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debito
        '
        Me.txt_debito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_debito.Location = New System.Drawing.Point(126, 68)
        Me.txt_debito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_debito.MaxLength = 9
        Me.txt_debito.Name = "txt_debito"
        Me.txt_debito.Size = New System.Drawing.Size(67, 21)
        Me.txt_debito.TabIndex = 9
        Me.txt_debito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_iva
        '
        Me.txt_cod_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_iva.Location = New System.Drawing.Point(125, 42)
        Me.txt_cod_iva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cod_iva.MaxLength = 9
        Me.txt_cod_iva.Name = "txt_cod_iva"
        Me.txt_cod_iva.Size = New System.Drawing.Size(67, 21)
        Me.txt_cod_iva.TabIndex = 8
        Me.txt_cod_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_cta
        '
        Me.txt_cod_cta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_cta.Location = New System.Drawing.Point(126, 13)
        Me.txt_cod_cta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cod_cta.MaxLength = 9
        Me.txt_cod_cta.Name = "txt_cod_cta"
        Me.txt_cod_cta.Size = New System.Drawing.Size(67, 21)
        Me.txt_cod_cta.TabIndex = 7
        Me.txt_cod_cta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(70, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 15)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Credito:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(75, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Debito:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 15)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Codigo de I.V.A:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Codigo de Cuenta:"
        '
        'txt_total_grilla
        '
        Me.txt_total_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_total_grilla.BackColor = System.Drawing.Color.Silver
        Me.txt_total_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_grilla.ForeColor = System.Drawing.Color.White
        Me.txt_total_grilla.Location = New System.Drawing.Point(640, 239)
        Me.txt_total_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_total_grilla.Name = "txt_total_grilla"
        Me.txt_total_grilla.ReadOnly = True
        Me.txt_total_grilla.Size = New System.Drawing.Size(142, 21)
        Me.txt_total_grilla.TabIndex = 32
        Me.txt_total_grilla.TabStop = False
        Me.txt_total_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_imp_interno_grilla
        '
        Me.txt_imp_interno_grilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_imp_interno_grilla.BackColor = System.Drawing.Color.Silver
        Me.txt_imp_interno_grilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_imp_interno_grilla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_interno_grilla.ForeColor = System.Drawing.Color.White
        Me.txt_imp_interno_grilla.Location = New System.Drawing.Point(514, 239)
        Me.txt_imp_interno_grilla.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_imp_interno_grilla.Name = "txt_imp_interno_grilla"
        Me.txt_imp_interno_grilla.ReadOnly = True
        Me.txt_imp_interno_grilla.Size = New System.Drawing.Size(127, 21)
        Me.txt_imp_interno_grilla.TabIndex = 31
        Me.txt_imp_interno_grilla.TabStop = False
        Me.txt_imp_interno_grilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_n_insc
        '
        Me.txt_n_insc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_n_insc.BackColor = System.Drawing.Color.Silver
        Me.txt_n_insc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_n_insc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_n_insc.ForeColor = System.Drawing.Color.White
        Me.txt_n_insc.Location = New System.Drawing.Point(383, 239)
        Me.txt_n_insc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_n_insc.Name = "txt_n_insc"
        Me.txt_n_insc.ReadOnly = True
        Me.txt_n_insc.Size = New System.Drawing.Size(132, 21)
        Me.txt_n_insc.TabIndex = 30
        Me.txt_n_insc.TabStop = False
        Me.txt_n_insc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_inscripto
        '
        Me.txt_inscripto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_inscripto.BackColor = System.Drawing.Color.Silver
        Me.txt_inscripto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_inscripto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inscripto.ForeColor = System.Drawing.Color.White
        Me.txt_inscripto.Location = New System.Drawing.Point(259, 239)
        Me.txt_inscripto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_inscripto.Name = "txt_inscripto"
        Me.txt_inscripto.ReadOnly = True
        Me.txt_inscripto.Size = New System.Drawing.Size(124, 21)
        Me.txt_inscripto.TabIndex = 29
        Me.txt_inscripto.TabStop = False
        Me.txt_inscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_exento
        '
        Me.txt_exento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_exento.BackColor = System.Drawing.Color.Silver
        Me.txt_exento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_exento.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exento.ForeColor = System.Drawing.Color.White
        Me.txt_exento.Location = New System.Drawing.Point(134, 239)
        Me.txt_exento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_exento.Name = "txt_exento"
        Me.txt_exento.ReadOnly = True
        Me.txt_exento.Size = New System.Drawing.Size(126, 21)
        Me.txt_exento.TabIndex = 28
        Me.txt_exento.TabStop = False
        Me.txt_exento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_gravado
        '
        Me.txt_gravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_gravado.BackColor = System.Drawing.Color.Silver
        Me.txt_gravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gravado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gravado.ForeColor = System.Drawing.Color.White
        Me.txt_gravado.Location = New System.Drawing.Point(9, 239)
        Me.txt_gravado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_gravado.Name = "txt_gravado"
        Me.txt_gravado.ReadOnly = True
        Me.txt_gravado.Size = New System.Drawing.Size(126, 21)
        Me.txt_gravado.TabIndex = 27
        Me.txt_gravado.TabStop = False
        Me.txt_gravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txt_talonario_pred)
        Me.GroupBox1.Controls.Add(Me.txt_tipo_iva)
        Me.GroupBox1.Controls.Add(Me.cmb_forma_pago)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.lbl_forma_pago)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.txt_lista)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_iva)
        Me.GroupBox1.Controls.Add(Me.txt_direccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(792, 140)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txt_talonario_pred
        '
        Me.txt_talonario_pred.Location = New System.Drawing.Point(351, 1)
        Me.txt_talonario_pred.Name = "txt_talonario_pred"
        Me.txt_talonario_pred.Size = New System.Drawing.Size(50, 20)
        Me.txt_talonario_pred.TabIndex = 21
        Me.txt_talonario_pred.Visible = False
        '
        'txt_tipo_iva
        '
        Me.txt_tipo_iva.Location = New System.Drawing.Point(245, 0)
        Me.txt_tipo_iva.Name = "txt_tipo_iva"
        Me.txt_tipo_iva.Size = New System.Drawing.Size(100, 20)
        Me.txt_tipo_iva.TabIndex = 20
        Me.txt_tipo_iva.Visible = False
        '
        'cmb_forma_pago
        '
        Me.cmb_forma_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_forma_pago.FormattingEnabled = True
        Me.cmb_forma_pago.Items.AddRange(New Object() {"Contado", "Cta Cte"})
        Me.cmb_forma_pago.Location = New System.Drawing.Point(77, 111)
        Me.cmb_forma_pago.Name = "cmb_forma_pago"
        Me.cmb_forma_pago.Size = New System.Drawing.Size(136, 21)
        Me.cmb_forma_pago.TabIndex = 4
        '
        'txt_codigo
        '
        Me.txt_codigo.BackColor = System.Drawing.Color.White
        Me.txt_codigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(77, 22)
        Me.txt_codigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_codigo.MaxLength = 9
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(67, 21)
        Me.txt_codigo.TabIndex = 0
        Me.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_forma_pago
        '
        Me.lbl_forma_pago.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_forma_pago.Location = New System.Drawing.Point(12, 102)
        Me.lbl_forma_pago.Name = "lbl_forma_pago"
        Me.lbl_forma_pago.Size = New System.Drawing.Size(59, 34)
        Me.lbl_forma_pago.TabIndex = 19
        Me.lbl_forma_pago.Text = "Forma de Pago"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.txt_cuit)
        Me.GroupBox2.Controls.Add(Me.txt_tipo_fact)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Controls.Add(Me.txt_prefijo)
        Me.GroupBox2.Controls.Add(Me.txt_estado_form)
        Me.GroupBox2.Controls.Add(Me.dt_fec_arqueo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dt_fec_vto)
        Me.GroupBox2.Controls.Add(Me.dt_fec_emision)
        Me.GroupBox2.Controls.Add(Me.lbl_vto)
        Me.GroupBox2.Controls.Add(Me.lbl_fec_emision)
        Me.GroupBox2.Controls.Add(Me.txt_letra)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(476, 1)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(318, 131)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_cuit
        '
        Me.txt_cuit.Location = New System.Drawing.Point(220, 102)
        Me.txt_cuit.Name = "txt_cuit"
        Me.txt_cuit.Size = New System.Drawing.Size(81, 20)
        Me.txt_cuit.TabIndex = 19
        Me.txt_cuit.Visible = False
        '
        'txt_tipo_fact
        '
        Me.txt_tipo_fact.Location = New System.Drawing.Point(210, 70)
        Me.txt_tipo_fact.Name = "txt_tipo_fact"
        Me.txt_tipo_fact.Size = New System.Drawing.Size(91, 20)
        Me.txt_tipo_fact.TabIndex = 18
        Me.txt_tipo_fact.Visible = False
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(210, 14)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(91, 20)
        Me.txt_numero.TabIndex = 3
        '
        'txt_prefijo
        '
        Me.txt_prefijo.AcceptsTab = True
        Me.txt_prefijo.Location = New System.Drawing.Point(145, 14)
        Me.txt_prefijo.Name = "txt_prefijo"
        Me.txt_prefijo.Size = New System.Drawing.Size(58, 20)
        Me.txt_prefijo.TabIndex = 2
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(209, 40)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(92, 20)
        Me.txt_estado_form.TabIndex = 17
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'dt_fec_arqueo
        '
        Me.dt_fec_arqueo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_arqueo.Location = New System.Drawing.Point(104, 105)
        Me.dt_fec_arqueo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dt_fec_arqueo.Name = "dt_fec_arqueo"
        Me.dt_fec_arqueo.Size = New System.Drawing.Size(99, 20)
        Me.dt_fec_arqueo.TabIndex = 6
        Me.dt_fec_arqueo.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Fecha Arqueo"
        '
        'dt_fec_vto
        '
        Me.dt_fec_vto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_vto.Location = New System.Drawing.Point(103, 70)
        Me.dt_fec_vto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dt_fec_vto.Name = "dt_fec_vto"
        Me.dt_fec_vto.Size = New System.Drawing.Size(99, 20)
        Me.dt_fec_vto.TabIndex = 5
        Me.dt_fec_vto.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'dt_fec_emision
        '
        Me.dt_fec_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_emision.Location = New System.Drawing.Point(103, 40)
        Me.dt_fec_emision.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dt_fec_emision.Name = "dt_fec_emision"
        Me.dt_fec_emision.Size = New System.Drawing.Size(99, 20)
        Me.dt_fec_emision.TabIndex = 4
        Me.dt_fec_emision.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'lbl_vto
        '
        Me.lbl_vto.AutoSize = True
        Me.lbl_vto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vto.Location = New System.Drawing.Point(8, 74)
        Me.lbl_vto.Name = "lbl_vto"
        Me.lbl_vto.Size = New System.Drawing.Size(61, 15)
        Me.lbl_vto.TabIndex = 14
        Me.lbl_vto.Text = "Fecha Vto"
        '
        'lbl_fec_emision
        '
        Me.lbl_fec_emision.AutoSize = True
        Me.lbl_fec_emision.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fec_emision.Location = New System.Drawing.Point(5, 43)
        Me.lbl_fec_emision.Name = "lbl_fec_emision"
        Me.lbl_fec_emision.Size = New System.Drawing.Size(97, 15)
        Me.lbl_fec_emision.TabIndex = 13
        Me.lbl_fec_emision.Text = "Fecha Emisison"
        '
        'txt_letra
        '
        Me.txt_letra.BackColor = System.Drawing.Color.White
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_letra.Location = New System.Drawing.Point(103, 13)
        Me.txt_letra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.ReadOnly = True
        Me.txt_letra.Size = New System.Drawing.Size(35, 22)
        Me.txt_letra.TabIndex = 1
        Me.txt_letra.TabStop = False
        Me.txt_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.SystemColors.Highlight
        Me.txt_cliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cliente.ForeColor = System.Drawing.Color.White
        Me.txt_cliente.Location = New System.Drawing.Point(150, 21)
        Me.txt_cliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(297, 22)
        Me.txt_cliente.TabIndex = 10
        Me.txt_cliente.TabStop = False
        Me.txt_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_lista
        '
        Me.txt_lista.BackColor = System.Drawing.Color.Gray
        Me.txt_lista.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lista.ForeColor = System.Drawing.Color.White
        Me.txt_lista.Location = New System.Drawing.Point(292, 110)
        Me.txt_lista.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_lista.Name = "txt_lista"
        Me.txt_lista.Size = New System.Drawing.Size(155, 21)
        Me.txt_lista.TabIndex = 9
        Me.txt_lista.TabStop = False
        Me.txt_lista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(250, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Lista"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo iva"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Direccion"
        '
        'txt_iva
        '
        Me.txt_iva.BackColor = System.Drawing.SystemColors.Highlight
        Me.txt_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.ForeColor = System.Drawing.Color.White
        Me.txt_iva.Location = New System.Drawing.Point(77, 77)
        Me.txt_iva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.Size = New System.Drawing.Size(370, 21)
        Me.txt_iva.TabIndex = 3
        Me.txt_iva.TabStop = False
        Me.txt_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_direccion
        '
        Me.txt_direccion.BackColor = System.Drawing.SystemColors.Highlight
        Me.txt_direccion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.ForeColor = System.Drawing.Color.White
        Me.txt_direccion.Location = New System.Drawing.Point(77, 49)
        Me.txt_direccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(370, 21)
        Me.txt_direccion.TabIndex = 2
        Me.txt_direccion.TabStop = False
        Me.txt_direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'Timer1
        '
        '
        'Form_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_compras"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Comprobantes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_imp_interno_grilla As System.Windows.Forms.TextBox
    Friend WithEvents txt_n_insc As System.Windows.Forms.TextBox
    Friend WithEvents txt_inscripto As System.Windows.Forms.TextBox
    Friend WithEvents txt_exento As System.Windows.Forms.TextBox
    Friend WithEvents txt_gravado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_forma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_forma_pago As System.Windows.Forms.Label
    Friend WithEvents dt_fec_vto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_vto As System.Windows.Forms.Label
    Friend WithEvents lbl_fec_emision As System.Windows.Forms.Label
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_lista As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dt_fec_arqueo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_credito As mitextbox1.texto_solonum
    Friend WithEvents txt_debito As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_iva As mitextbox1.texto_solonum
    Friend WithEvents txt_cod_cta As mitextbox1.texto_solonum
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_exento1 As mitextbox1.texto_solonum
    Friend WithEvents txt_imp_interno As mitextbox1.texto_solonum
    Friend WithEvents txt_neto_gravado As mitextbox1.texto_solonum
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_per_iva As mitextbox1.texto_solonum
    Friend WithEvents txt_per_ing_bruto As mitextbox1.texto_solonum
    Friend WithEvents txt_iva_inscripto As mitextbox1.texto_solonum
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
    Friend WithEvents lbl_cuenta As System.Windows.Forms.Label
    Friend WithEvents txt_numero As mitextbox1.texto_solonum
    Friend WithEvents txt_prefijo As mitextbox1.texto_solonum
    Friend WithEvents txt_tipo_fact As System.Windows.Forms.TextBox
    Friend WithEvents txt_cuit As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo_iva As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imp_interno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva_insc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents des_cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents des_iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_talonario_pred As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
