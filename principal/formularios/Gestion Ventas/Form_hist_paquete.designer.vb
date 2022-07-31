<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_hist_paquete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_hist_paquete))
        Me.cmb_nombre = New System.Windows.Forms.ComboBox
        Me.lbl_nombre = New System.Windows.Forms.Label
        Me.cmb_modalidad = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_aceptar = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.txtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAyuda = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_nombre
        '
        Me.cmb_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nombre.FormattingEnabled = True
        Me.cmb_nombre.Items.AddRange(New Object() {"Total", "Vendedor"})
        Me.cmb_nombre.Location = New System.Drawing.Point(86, 126)
        Me.cmb_nombre.Name = "cmb_nombre"
        Me.cmb_nombre.Size = New System.Drawing.Size(228, 21)
        Me.cmb_nombre.TabIndex = 137
        Me.cmb_nombre.Visible = False
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre.Location = New System.Drawing.Point(13, 130)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(54, 13)
        Me.lbl_nombre.TabIndex = 136
        Me.lbl_nombre.Text = "Nombre:"
        Me.lbl_nombre.Visible = False
        '
        'cmb_modalidad
        '
        Me.cmb_modalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_modalidad.FormattingEnabled = True
        Me.cmb_modalidad.Items.AddRange(New Object() {"Todos", "Paquetes"})
        Me.cmb_modalidad.Location = New System.Drawing.Point(86, 90)
        Me.cmb_modalidad.Name = "cmb_modalidad"
        Me.cmb_modalidad.Size = New System.Drawing.Size(228, 21)
        Me.cmb_modalidad.TabIndex = 135
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Modalidad:"
        '
        'cmd_aceptar
        '
        Me.cmd_aceptar.Location = New System.Drawing.Point(347, 85)
        Me.cmd_aceptar.Name = "cmd_aceptar"
        Me.cmd_aceptar.Size = New System.Drawing.Size(115, 67)
        Me.cmd_aceptar.TabIndex = 133
        Me.cmd_aceptar.Text = "Aceptar"
        Me.cmd_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFechaDesde)
        Me.GroupBox4.Controls.Add(Me.txtFechaHasta)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 27)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(323, 44)
        Me.GroupBox4.TabIndex = 132
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Periodo a calcular"
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaDesde.Location = New System.Drawing.Point(65, 19)
        Me.txtFechaDesde.MinDate = New Date(1820, 1, 1, 0, 0, 0, 0)
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(87, 20)
        Me.txtFechaDesde.TabIndex = 86
        Me.txtFechaDesde.Tag = "1"
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaHasta.Location = New System.Drawing.Point(220, 19)
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(87, 20)
        Me.txtFechaHasta.TabIndex = 85
        Me.txtFechaHasta.Tag = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Desde:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(170, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(456, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 26)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Historico por paquetes"
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(946, 21)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(22, 22)
        Me.btnAyuda.TabIndex = 130
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(882, 21)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(52, 52)
        Me.btnImprimir.TabIndex = 129
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(973, 21)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(22, 22)
        Me.btnCerrar.TabIndex = 128
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Form_hist_paquete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 594)
        Me.Controls.Add(Me.cmb_nombre)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Controls.Add(Me.cmb_modalidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmd_aceptar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAyuda)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 685)
        Me.Name = "Form_hist_paquete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_nombre As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents cmb_modalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmd_aceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
