<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_edita_horario
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_unico = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_nombre = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dt_hora_inicio = New System.Windows.Forms.DateTimePicker
        Me.dt_hora_fin = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_difernecia_hora = New System.Windows.Forms.Label
        Me.cmd_actualizar = New System.Windows.Forms.Button
        Me.lbl_pos = New System.Windows.Forms.Label
        Me.lbl_cod_empleado = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(137, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'lbl_unico
        '
        Me.lbl_unico.AutoSize = True
        Me.lbl_unico.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unico.Location = New System.Drawing.Point(291, 32)
        Me.lbl_unico.Name = "lbl_unico"
        Me.lbl_unico.Size = New System.Drawing.Size(0, 24)
        Me.lbl_unico.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(137, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NOMBRE:"
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre.Location = New System.Drawing.Point(291, 99)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(0, 24)
        Me.lbl_nombre.TabIndex = 3
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Location = New System.Drawing.Point(291, 174)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(0, 24)
        Me.lbl_fecha.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(137, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "FECHA:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "HORA INGRESO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 339)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "HORA SALIDA:"
        '
        'dt_hora_inicio
        '
        Me.dt_hora_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_hora_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dt_hora_inicio.Location = New System.Drawing.Point(295, 245)
        Me.dt_hora_inicio.Name = "dt_hora_inicio"
        Me.dt_hora_inicio.Size = New System.Drawing.Size(124, 29)
        Me.dt_hora_inicio.TabIndex = 8
        '
        'dt_hora_fin
        '
        Me.dt_hora_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_hora_fin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dt_hora_fin.Location = New System.Drawing.Point(295, 332)
        Me.dt_hora_fin.Name = "dt_hora_fin"
        Me.dt_hora_fin.Size = New System.Drawing.Size(124, 29)
        Me.dt_hora_fin.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(137, 418)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "DIFERNECIA:"
        '
        'lbl_difernecia_hora
        '
        Me.lbl_difernecia_hora.AutoSize = True
        Me.lbl_difernecia_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_difernecia_hora.Location = New System.Drawing.Point(299, 418)
        Me.lbl_difernecia_hora.Name = "lbl_difernecia_hora"
        Me.lbl_difernecia_hora.Size = New System.Drawing.Size(0, 24)
        Me.lbl_difernecia_hora.TabIndex = 11
        '
        'cmd_actualizar
        '
        Me.cmd_actualizar.BackColor = System.Drawing.Color.Black
        Me.cmd_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_actualizar.ForeColor = System.Drawing.Color.Yellow
        Me.cmd_actualizar.Location = New System.Drawing.Point(164, 505)
        Me.cmd_actualizar.Name = "cmd_actualizar"
        Me.cmd_actualizar.Size = New System.Drawing.Size(327, 80)
        Me.cmd_actualizar.TabIndex = 12
        Me.cmd_actualizar.Text = "ACTUALIZAR"
        Me.cmd_actualizar.UseVisualStyleBackColor = False
        '
        'lbl_pos
        '
        Me.lbl_pos.AutoSize = True
        Me.lbl_pos.Location = New System.Drawing.Point(575, 531)
        Me.lbl_pos.Name = "lbl_pos"
        Me.lbl_pos.Size = New System.Drawing.Size(0, 13)
        Me.lbl_pos.TabIndex = 13
        Me.lbl_pos.Visible = False
        '
        'lbl_cod_empleado
        '
        Me.lbl_cod_empleado.AutoSize = True
        Me.lbl_cod_empleado.Location = New System.Drawing.Point(473, 49)
        Me.lbl_cod_empleado.Name = "lbl_cod_empleado"
        Me.lbl_cod_empleado.Size = New System.Drawing.Size(91, 13)
        Me.lbl_cod_empleado.TabIndex = 14
        Me.lbl_cod_empleado.Text = "codigo_empleado"
        Me.lbl_cod_empleado.Visible = False
        '
        'Form_edita_horario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(659, 597)
        Me.Controls.Add(Me.lbl_cod_empleado)
        Me.Controls.Add(Me.lbl_pos)
        Me.Controls.Add(Me.cmd_actualizar)
        Me.Controls.Add(Me.lbl_difernecia_hora)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dt_hora_fin)
        Me.Controls.Add(Me.dt_hora_inicio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_unico)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_edita_horario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Horario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_unico As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dt_hora_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_hora_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_difernecia_hora As System.Windows.Forms.Label
    Friend WithEvents cmd_actualizar As System.Windows.Forms.Button
    Friend WithEvents lbl_pos As System.Windows.Forms.Label
    Friend WithEvents lbl_cod_empleado As System.Windows.Forms.Label
End Class
