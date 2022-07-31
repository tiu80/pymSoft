<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_recibos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_recibos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_vendedor = New text_solo_num.solo_numeros
        Me.txt_nom_vendedor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_dif_cobro = New System.Windows.Forms.TextBox
        Me.txt_controla_numerador = New System.Windows.Forms.TextBox
        Me.txt_numerador_respaldo = New System.Windows.Forms.TextBox
        Me.txt_codigo = New mitextbox1.texto_solonum
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_modifica_efectivo = New System.Windows.Forms.TextBox
        Me.txt_importe_cobro = New System.Windows.Forms.TextBox
        Me.txt_total_cobro = New System.Windows.Forms.TextBox
        Me.txt_p_venta = New System.Windows.Forms.TextBox
        Me.txt_talonario_pred = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.txt_fila = New System.Windows.Forms.TextBox
        Me.txt_cierra_form = New System.Windows.Forms.TextBox
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.dt_fec_vto = New System.Windows.Forms.DateTimePicker
        Me.dt_fec_emision = New System.Windows.Forms.DateTimePicker
        Me.lbl_vto = New System.Windows.Forms.Label
        Me.lbl_fec_emision = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_prefijo = New System.Windows.Forms.TextBox
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_saldo_ant = New System.Windows.Forms.TextBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_pre = New System.Windows.Forms.TextBox
        Me.txt_total_general = New System.Windows.Forms.TextBox
        Me.txt_entrega = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmd_busca = New System.Windows.Forms.Button
        Me.txt_num = New System.Windows.Forms.TextBox
        Me.txt_letra1 = New System.Windows.Forms.TextBox
        Me.txt_comprobante = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.saldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmd_help = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.txt_nom_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_dif_cobro)
        Me.GroupBox1.Controls.Add(Me.txt_controla_numerador)
        Me.GroupBox1.Controls.Add(Me.txt_numerador_respaldo)
        Me.GroupBox1.Controls.Add(Me.txt_codigo)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_saldo_ant)
        Me.GroupBox1.Controls.Add(Me.txt_iva)
        Me.GroupBox1.Controls.Add(Me.txt_direccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(10, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(770, 140)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Enabled = False
        Me.txt_vendedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(77, 107)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(31, 21)
        Me.txt_vendedor.TabIndex = 17
        Me.txt_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_nom_vendedor
        '
        Me.txt_nom_vendedor.BackColor = System.Drawing.Color.White
        Me.txt_nom_vendedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nom_vendedor.ForeColor = System.Drawing.Color.Black
        Me.txt_nom_vendedor.Location = New System.Drawing.Point(114, 107)
        Me.txt_nom_vendedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_nom_vendedor.Name = "txt_nom_vendedor"
        Me.txt_nom_vendedor.Size = New System.Drawing.Size(189, 21)
        Me.txt_nom_vendedor.TabIndex = 16
        Me.txt_nom_vendedor.TabStop = False
        Me.txt_nom_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Vendedor"
        '
        'txt_dif_cobro
        '
        Me.txt_dif_cobro.Location = New System.Drawing.Point(392, 1)
        Me.txt_dif_cobro.Name = "txt_dif_cobro"
        Me.txt_dif_cobro.Size = New System.Drawing.Size(62, 20)
        Me.txt_dif_cobro.TabIndex = 13
        Me.txt_dif_cobro.Visible = False
        '
        'txt_controla_numerador
        '
        Me.txt_controla_numerador.Location = New System.Drawing.Point(298, 1)
        Me.txt_controla_numerador.Name = "txt_controla_numerador"
        Me.txt_controla_numerador.Size = New System.Drawing.Size(76, 20)
        Me.txt_controla_numerador.TabIndex = 12
        Me.txt_controla_numerador.Text = "0"
        Me.txt_controla_numerador.Visible = False
        '
        'txt_numerador_respaldo
        '
        Me.txt_numerador_respaldo.Location = New System.Drawing.Point(181, 1)
        Me.txt_numerador_respaldo.Name = "txt_numerador_respaldo"
        Me.txt_numerador_respaldo.Size = New System.Drawing.Size(100, 20)
        Me.txt_numerador_respaldo.TabIndex = 11
        Me.txt_numerador_respaldo.Visible = False
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(77, 22)
        Me.txt_codigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_codigo.MaxLength = 9
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(67, 21)
        Me.txt_codigo.TabIndex = 0
        Me.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.txt_modifica_efectivo)
        Me.GroupBox2.Controls.Add(Me.txt_importe_cobro)
        Me.GroupBox2.Controls.Add(Me.txt_total_cobro)
        Me.GroupBox2.Controls.Add(Me.txt_p_venta)
        Me.GroupBox2.Controls.Add(Me.txt_talonario_pred)
        Me.GroupBox2.Controls.Add(Me.txt_tipo)
        Me.GroupBox2.Controls.Add(Me.txt_fila)
        Me.GroupBox2.Controls.Add(Me.txt_cierra_form)
        Me.GroupBox2.Controls.Add(Me.txt_estado_form)
        Me.GroupBox2.Controls.Add(Me.dt_fec_vto)
        Me.GroupBox2.Controls.Add(Me.dt_fec_emision)
        Me.GroupBox2.Controls.Add(Me.lbl_vto)
        Me.GroupBox2.Controls.Add(Me.lbl_fec_emision)
        Me.GroupBox2.Controls.Add(Me.txt_numero)
        Me.GroupBox2.Controls.Add(Me.txt_prefijo)
        Me.GroupBox2.Controls.Add(Me.txt_letra)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(461, 9)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(316, 131)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txt_modifica_efectivo
        '
        Me.txt_modifica_efectivo.Location = New System.Drawing.Point(218, 0)
        Me.txt_modifica_efectivo.Name = "txt_modifica_efectivo"
        Me.txt_modifica_efectivo.Size = New System.Drawing.Size(70, 20)
        Me.txt_modifica_efectivo.TabIndex = 22
        Me.txt_modifica_efectivo.Text = "0"
        Me.txt_modifica_efectivo.Visible = False
        '
        'txt_importe_cobro
        '
        Me.txt_importe_cobro.Location = New System.Drawing.Point(115, 0)
        Me.txt_importe_cobro.Name = "txt_importe_cobro"
        Me.txt_importe_cobro.Size = New System.Drawing.Size(100, 20)
        Me.txt_importe_cobro.TabIndex = 21
        Me.txt_importe_cobro.Visible = False
        '
        'txt_total_cobro
        '
        Me.txt_total_cobro.Location = New System.Drawing.Point(9, -1)
        Me.txt_total_cobro.Name = "txt_total_cobro"
        Me.txt_total_cobro.Size = New System.Drawing.Size(100, 20)
        Me.txt_total_cobro.TabIndex = 14
        Me.txt_total_cobro.Text = "0"
        Me.txt_total_cobro.Visible = False
        '
        'txt_p_venta
        '
        Me.txt_p_venta.Location = New System.Drawing.Point(284, 49)
        Me.txt_p_venta.Name = "txt_p_venta"
        Me.txt_p_venta.Size = New System.Drawing.Size(29, 20)
        Me.txt_p_venta.TabIndex = 20
        Me.txt_p_venta.Visible = False
        '
        'txt_talonario_pred
        '
        Me.txt_talonario_pred.Location = New System.Drawing.Point(228, 51)
        Me.txt_talonario_pred.Name = "txt_talonario_pred"
        Me.txt_talonario_pred.Size = New System.Drawing.Size(50, 20)
        Me.txt_talonario_pred.TabIndex = 19
        Me.txt_talonario_pred.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Location = New System.Drawing.Point(109, 104)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(100, 20)
        Me.txt_tipo.TabIndex = 18
        Me.txt_tipo.Visible = False
        '
        'txt_fila
        '
        Me.txt_fila.Location = New System.Drawing.Point(9, 104)
        Me.txt_fila.Name = "txt_fila"
        Me.txt_fila.Size = New System.Drawing.Size(94, 20)
        Me.txt_fila.TabIndex = 17
        Me.txt_fila.Text = "0"
        Me.txt_fila.Visible = False
        '
        'txt_cierra_form
        '
        Me.txt_cierra_form.Location = New System.Drawing.Point(228, 102)
        Me.txt_cierra_form.Name = "txt_cierra_form"
        Me.txt_cierra_form.Size = New System.Drawing.Size(56, 20)
        Me.txt_cierra_form.TabIndex = 16
        Me.txt_cierra_form.Text = "1"
        Me.txt_cierra_form.Visible = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(228, 75)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(56, 20)
        Me.txt_estado_form.TabIndex = 15
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'dt_fec_vto
        '
        Me.dt_fec_vto.Enabled = False
        Me.dt_fec_vto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_vto.Location = New System.Drawing.Point(103, 75)
        Me.dt_fec_vto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dt_fec_vto.Name = "dt_fec_vto"
        Me.dt_fec_vto.Size = New System.Drawing.Size(99, 20)
        Me.dt_fec_vto.TabIndex = 3
        Me.dt_fec_vto.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'dt_fec_emision
        '
        Me.dt_fec_emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_fec_emision.Location = New System.Drawing.Point(103, 43)
        Me.dt_fec_emision.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dt_fec_emision.Name = "dt_fec_emision"
        Me.dt_fec_emision.Size = New System.Drawing.Size(99, 20)
        Me.dt_fec_emision.TabIndex = 2
        Me.dt_fec_emision.TabStop = False
        Me.dt_fec_emision.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'lbl_vto
        '
        Me.lbl_vto.AutoSize = True
        Me.lbl_vto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vto.Location = New System.Drawing.Point(6, 80)
        Me.lbl_vto.Name = "lbl_vto"
        Me.lbl_vto.Size = New System.Drawing.Size(61, 15)
        Me.lbl_vto.TabIndex = 14
        Me.lbl_vto.Text = "Fecha Vto"
        '
        'lbl_fec_emision
        '
        Me.lbl_fec_emision.AutoSize = True
        Me.lbl_fec_emision.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fec_emision.Location = New System.Drawing.Point(6, 48)
        Me.lbl_fec_emision.Name = "lbl_fec_emision"
        Me.lbl_fec_emision.Size = New System.Drawing.Size(97, 15)
        Me.lbl_fec_emision.TabIndex = 13
        Me.lbl_fec_emision.Text = "Fecha Emisison"
        '
        'txt_numero
        '
        Me.txt_numero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_numero.Enabled = False
        Me.txt_numero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(193, 13)
        Me.txt_numero.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(91, 22)
        Me.txt_numero.TabIndex = 1
        Me.txt_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_prefijo
        '
        Me.txt_prefijo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_prefijo.Enabled = False
        Me.txt_prefijo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_prefijo.Location = New System.Drawing.Point(145, 13)
        Me.txt_prefijo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_prefijo.Name = "txt_prefijo"
        Me.txt_prefijo.Size = New System.Drawing.Size(42, 22)
        Me.txt_prefijo.TabIndex = 0
        Me.txt_prefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_letra
        '
        Me.txt_letra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_letra.Enabled = False
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_letra.Location = New System.Drawing.Point(103, 13)
        Me.txt_letra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(35, 22)
        Me.txt_letra.TabIndex = 10
        Me.txt_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Numero"
        '
        'txt_cliente
        '
        Me.txt_cliente.BackColor = System.Drawing.Color.White
        Me.txt_cliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_cliente.Location = New System.Drawing.Point(150, 21)
        Me.txt_cliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(297, 22)
        Me.txt_cliente.TabIndex = 10
        Me.txt_cliente.TabStop = False
        Me.txt_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(309, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 31)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Saldo Anterior"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 81)
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
        'txt_saldo_ant
        '
        Me.txt_saldo_ant.BackColor = System.Drawing.Color.Gray
        Me.txt_saldo_ant.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_saldo_ant.ForeColor = System.Drawing.Color.White
        Me.txt_saldo_ant.Location = New System.Drawing.Point(355, 106)
        Me.txt_saldo_ant.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_saldo_ant.Name = "txt_saldo_ant"
        Me.txt_saldo_ant.Size = New System.Drawing.Size(92, 21)
        Me.txt_saldo_ant.TabIndex = 4
        Me.txt_saldo_ant.TabStop = False
        Me.txt_saldo_ant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_iva
        '
        Me.txt_iva.BackColor = System.Drawing.Color.White
        Me.txt_iva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.ForeColor = System.Drawing.Color.Black
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
        Me.txt_direccion.BackColor = System.Drawing.Color.White
        Me.txt_direccion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.ForeColor = System.Drawing.Color.Black
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
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.txt_pre)
        Me.GroupBox3.Controls.Add(Me.txt_total_general)
        Me.GroupBox3.Controls.Add(Me.txt_entrega)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txt_total)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmd_busca)
        Me.GroupBox3.Controls.Add(Me.txt_num)
        Me.GroupBox3.Controls.Add(Me.txt_letra1)
        Me.GroupBox3.Controls.Add(Me.txt_comprobante)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Location = New System.Drawing.Point(-3, 145)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(798, 383)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'txt_pre
        '
        Me.txt_pre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_pre.BackColor = System.Drawing.Color.White
        Me.txt_pre.Enabled = False
        Me.txt_pre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pre.Location = New System.Drawing.Point(199, 341)
        Me.txt_pre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_pre.Name = "txt_pre"
        Me.txt_pre.ReadOnly = True
        Me.txt_pre.Size = New System.Drawing.Size(42, 22)
        Me.txt_pre.TabIndex = 28
        Me.txt_pre.TabStop = False
        Me.txt_pre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total_general
        '
        Me.txt_total_general.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_general.Enabled = False
        Me.txt_total_general.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_general.Location = New System.Drawing.Point(668, 337)
        Me.txt_total_general.Name = "txt_total_general"
        Me.txt_total_general.Size = New System.Drawing.Size(100, 25)
        Me.txt_total_general.TabIndex = 27
        Me.txt_total_general.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_entrega
        '
        Me.txt_entrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_entrega.Location = New System.Drawing.Point(543, 316)
        Me.txt_entrega.Name = "txt_entrega"
        Me.txt_entrega.Size = New System.Drawing.Size(75, 20)
        Me.txt_entrega.TabIndex = 26
        Me.txt_entrega.Text = "0"
        Me.txt_entrega.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(610, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 15)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Importe"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 294)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(656, 20)
        Me.Label10.TabIndex = 23
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_total
        '
        Me.txt_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(665, 294)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(122, 20)
        Me.txt_total.TabIndex = 22
        Me.txt_total.TabStop = False
        Me.txt_total.Text = "0.00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(665, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 23)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.DarkGray
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(656, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "TOTAL CANCELADO ----------------------->"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_busca
        '
        Me.cmd_busca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_busca.Location = New System.Drawing.Point(416, 341)
        Me.cmd_busca.Name = "cmd_busca"
        Me.cmd_busca.Size = New System.Drawing.Size(58, 22)
        Me.cmd_busca.TabIndex = 17
        Me.cmd_busca.Text = "............"
        Me.cmd_busca.UseVisualStyleBackColor = True
        '
        'txt_num
        '
        Me.txt_num.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_num.BackColor = System.Drawing.Color.White
        Me.txt_num.Enabled = False
        Me.txt_num.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_num.Location = New System.Drawing.Point(247, 341)
        Me.txt_num.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_num.Name = "txt_num"
        Me.txt_num.ReadOnly = True
        Me.txt_num.Size = New System.Drawing.Size(164, 22)
        Me.txt_num.TabIndex = 16
        Me.txt_num.TabStop = False
        Me.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_letra1
        '
        Me.txt_letra1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_letra1.BackColor = System.Drawing.Color.White
        Me.txt_letra1.Enabled = False
        Me.txt_letra1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_letra1.Location = New System.Drawing.Point(151, 341)
        Me.txt_letra1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_letra1.Name = "txt_letra1"
        Me.txt_letra1.ReadOnly = True
        Me.txt_letra1.Size = New System.Drawing.Size(42, 22)
        Me.txt_letra1.TabIndex = 15
        Me.txt_letra1.TabStop = False
        Me.txt_letra1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_comprobante
        '
        Me.txt_comprobante.AcceptsReturn = True
        Me.txt_comprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comprobante.BackColor = System.Drawing.Color.White
        Me.txt_comprobante.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comprobante.Location = New System.Drawing.Point(109, 341)
        Me.txt_comprobante.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.Size = New System.Drawing.Size(35, 22)
        Me.txt_comprobante.TabIndex = 14
        Me.txt_comprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Comprobante"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 22
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column7, Me.Column8, Me.Column6, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.saldo})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(0, 14)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(798, 257)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Tipo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.Frozen = True
        Me.Column7.HeaderText = "Letra"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.Frozen = True
        Me.Column8.HeaderText = "Prefijo"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "Numero"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Descripcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Fecha"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "Cancelado"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.Frozen = True
        Me.Column5.HeaderText = "total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'saldo
        '
        Me.saldo.Frozen = True
        Me.saldo.HeaderText = "saldo"
        Me.saldo.Name = "saldo"
        Me.saldo.ReadOnly = True
        '
        'cmd_help
        '
        Me.cmd_help.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_help.BackgroundImage = CType(resources.GetObject("cmd_help.BackgroundImage"), System.Drawing.Image)
        Me.cmd_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmd_help.FlatAppearance.BorderSize = 0
        Me.cmd_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_help.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_help.Location = New System.Drawing.Point(762, 24)
        Me.cmd_help.Name = "cmd_help"
        Me.cmd_help.Size = New System.Drawing.Size(16, 18)
        Me.cmd_help.TabIndex = 45
        Me.cmd_help.TabStop = False
        Me.cmd_help.UseVisualStyleBackColor = True
        '
        'Form_recibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 536)
        Me.Controls.Add(Me.cmd_help)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_recibos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Recibos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo As mitextbox1.texto_solonum
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dt_fec_vto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_fec_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_vto As System.Windows.Forms.Label
    Friend WithEvents lbl_fec_emision As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_prefijo As System.Windows.Forms.TextBox
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_saldo_ant As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_num As System.Windows.Forms.TextBox
    Friend WithEvents txt_letra1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmd_busca As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents txt_cierra_form As System.Windows.Forms.TextBox
    Friend WithEvents txt_fila As System.Windows.Forms.TextBox
    Friend WithEvents txt_entrega As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_general As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_talonario_pred As System.Windows.Forms.TextBox
    Friend WithEvents txt_p_venta As System.Windows.Forms.TextBox
    Friend WithEvents txt_pre As System.Windows.Forms.TextBox
    Friend WithEvents txt_numerador_respaldo As System.Windows.Forms.TextBox
    Friend WithEvents txt_controla_numerador As System.Windows.Forms.TextBox
    Friend WithEvents txt_dif_cobro As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_cobro As System.Windows.Forms.TextBox
    Friend WithEvents txt_importe_cobro As System.Windows.Forms.TextBox
    Friend WithEvents txt_modifica_efectivo As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_vendedor As text_solo_num.solo_numeros
    Friend WithEvents txt_nom_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmd_help As System.Windows.Forms.Button
End Class
