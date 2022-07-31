<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_consulta_art_sinstock
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.lbl_articulo = New System.Windows.Forms.Label
        Me.lbl_id_art = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tool_imprime = New System.Windows.Forms.ToolStripButton
        Me.tool_exporta = New System.Windows.Forms.ToolStripButton
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-1, -1)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(788, 209)
        Me.DataGridView1.TabIndex = 8
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(-1, 251)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(788, 282)
        Me.DataGridView2.TabIndex = 13
        '
        'lbl_articulo
        '
        Me.lbl_articulo.AutoSize = True
        Me.lbl_articulo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_articulo.ForeColor = System.Drawing.Color.Red
        Me.lbl_articulo.Location = New System.Drawing.Point(227, 220)
        Me.lbl_articulo.Name = "lbl_articulo"
        Me.lbl_articulo.Size = New System.Drawing.Size(0, 19)
        Me.lbl_articulo.TabIndex = 14
        '
        'lbl_id_art
        '
        Me.lbl_id_art.AutoSize = True
        Me.lbl_id_art.Location = New System.Drawing.Point(98, 224)
        Me.lbl_id_art.Name = "lbl_id_art"
        Me.lbl_id_art.Size = New System.Drawing.Size(0, 13)
        Me.lbl_id_art.TabIndex = 15
        Me.lbl_id_art.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(706, 215)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(48, 24)
        Me.Panel1.TabIndex = 16
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_imprime, Me.tool_exporta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(48, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tool_imprime
        '
        Me.tool_imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_imprime.Image = Global.pym.My.Resources.Resources.printer
        Me.tool_imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_imprime.Name = "tool_imprime"
        Me.tool_imprime.Size = New System.Drawing.Size(23, 22)
        Me.tool_imprime.Text = "Imprimir"
        '
        'tool_exporta
        '
        Me.tool_exporta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_exporta.Image = Global.pym.My.Resources.Resources.page_excel
        Me.tool_exporta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_exporta.Name = "tool_exporta"
        Me.tool_exporta.Size = New System.Drawing.Size(23, 22)
        Me.tool_exporta.Text = "Exportar"
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(13, 220)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(19, 20)
        Me.txt_estado_form.TabIndex = 17
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Form_consulta_art_sinstock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_id_art)
        Me.Controls.Add(Me.lbl_articulo)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_consulta_art_sinstock"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ARTICULOS SIN STOCK"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_articulo As System.Windows.Forms.Label
    Friend WithEvents lbl_id_art As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tool_imprime As System.Windows.Forms.ToolStripButton
    Friend WithEvents tool_exporta As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
End Class
