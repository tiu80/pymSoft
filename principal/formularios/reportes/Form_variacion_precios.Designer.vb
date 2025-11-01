<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_variacion_precios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_variacion_precios))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Tool_imprime = New System.Windows.Forms.ToolStripButton
        Me.Tool_exporta = New System.Windows.Forms.ToolStripButton
        Me.Tool_vista = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Tool_imprime1 = New System.Windows.Forms.ToolStripButton
        Me.Tool_exporta1 = New System.Windows.Forms.ToolStripButton
        Me.tool_vista1 = New System.Windows.Forms.ToolStripButton
        Me.Tool_borra = New System.Windows.Forms.ToolStripButton
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.lbl_total = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(526, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 70)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(643, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 70)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Variacion precios"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 96)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(789, 413)
        Me.DataGridView1.TabIndex = 18
        '
        'Tool_imprime
        '
        Me.Tool_imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_imprime.Image = Global.pym.My.Resources.Resources.printer
        Me.Tool_imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_imprime.Name = "Tool_imprime"
        Me.Tool_imprime.Size = New System.Drawing.Size(23, 22)
        Me.Tool_imprime.Text = "ToolStripButton1"
        '
        'Tool_exporta
        '
        Me.Tool_exporta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_exporta.Image = Global.pym.My.Resources.Resources.page_excel
        Me.Tool_exporta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_exporta.Name = "Tool_exporta"
        Me.Tool_exporta.Size = New System.Drawing.Size(23, 22)
        Me.Tool_exporta.Text = "ToolStripButton2"
        '
        'Tool_vista
        '
        Me.Tool_vista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_vista.Image = Global.pym.My.Resources.Resources.application_form_magnify
        Me.Tool_vista.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_vista.Name = "Tool_vista"
        Me.Tool_vista.Size = New System.Drawing.Size(23, 22)
        Me.Tool_vista.Text = "ToolStripButton3"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 25)
        Me.Panel1.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tool_imprime1, Me.Tool_exporta1, Me.tool_vista1, Me.Tool_borra})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(786, 25)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Tool_imprime1
        '
        Me.Tool_imprime1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_imprime1.Image = Global.pym.My.Resources.Resources.printer
        Me.Tool_imprime1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_imprime1.Name = "Tool_imprime1"
        Me.Tool_imprime1.Size = New System.Drawing.Size(23, 22)
        Me.Tool_imprime1.Text = "Imprimir"
        '
        'Tool_exporta1
        '
        Me.Tool_exporta1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_exporta1.Image = Global.pym.My.Resources.Resources.page_excel
        Me.Tool_exporta1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_exporta1.Name = "Tool_exporta1"
        Me.Tool_exporta1.Size = New System.Drawing.Size(23, 22)
        Me.Tool_exporta1.Text = "Exportar"
        '
        'tool_vista1
        '
        Me.tool_vista1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_vista1.Image = Global.pym.My.Resources.Resources.page_find
        Me.tool_vista1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_vista1.Name = "tool_vista1"
        Me.tool_vista1.Size = New System.Drawing.Size(23, 22)
        Me.tool_vista1.Text = "Vista previa"
        '
        'Tool_borra
        '
        Me.Tool_borra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_borra.Image = CType(resources.GetObject("Tool_borra.Image"), System.Drawing.Image)
        Me.Tool_borra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_borra.Name = "Tool_borra"
        Me.Tool_borra.Size = New System.Drawing.Size(23, 22)
        Me.Tool_borra.Text = "Borrar lista"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(336, 13)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(52, 20)
        Me.txt_estado_form.TabIndex = 21
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'lbl_total
        '
        Me.lbl_total.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(706, 511)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(77, 23)
        Me.lbl_total.TabIndex = 22
        Me.lbl_total.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(599, 514)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Promedio Variacion:"
        '
        'Form_variacion_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form_variacion_precios"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTES VARIACION COSTOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Tool_imprime As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_exporta As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_vista As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Tool_imprime1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_exporta1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tool_vista1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents Tool_borra As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
