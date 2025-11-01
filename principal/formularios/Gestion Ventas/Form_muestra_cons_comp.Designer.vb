<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_muestra_cons_comp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_muestra_cons_comp))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_comentario = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lbl_total = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.ColumnasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Tool_imprime = New System.Windows.Forms.ToolStripButton
        Me.exportar = New System.Windows.Forms.ToolStripButton
        Me.fact_contado = New System.Windows.Forms.ToolStripButton
        Me.fact_cta_cte = New System.Windows.Forms.ToolStripButton
        Me.factura_totales = New System.Windows.Forms.ToolStripButton
        Me.tool_art_sin_stock = New System.Windows.Forms.ToolStripButton
        Me.Tool_reemplaza_art = New System.Windows.Forms.ToolStripButton
        Me.txt_cierra_form = New System.Windows.Forms.TextBox
        Me.txt_estado_form = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.txt_n_carga = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(615, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 52)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Comprobantes x Clientes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_comentario
        '
        Me.txt_comentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_comentario.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_comentario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comentario.Location = New System.Drawing.Point(-2, 38)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ReadOnly = True
        Me.txt_comentario.Size = New System.Drawing.Size(616, 106)
        Me.txt_comentario.TabIndex = 45
        Me.txt_comentario.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 174)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(794, 325)
        Me.DataGridView1.TabIndex = 0
        '
        'lbl_total
        '
        Me.lbl_total.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_total.BackColor = System.Drawing.Color.White
        Me.lbl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_total.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(662, 499)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(131, 37)
        Me.lbl_total.TabIndex = 48
        Me.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(1, 146)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 29)
        Me.Panel1.TabIndex = 49
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.ToolStripSeparator1, Me.Tool_imprime, Me.exportar, Me.fact_contado, Me.fact_cta_cte, Me.factura_totales, Me.tool_art_sin_stock, Me.Tool_reemplaza_art})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(211, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnasToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "Columnas"
        '
        'ColumnasToolStripMenuItem
        '
        Me.ColumnasToolStripMenuItem.Name = "ColumnasToolStripMenuItem"
        Me.ColumnasToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ColumnasToolStripMenuItem.Text = "Columnas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Tool_imprime
        '
        Me.Tool_imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_imprime.Image = CType(resources.GetObject("Tool_imprime.Image"), System.Drawing.Image)
        Me.Tool_imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_imprime.Name = "Tool_imprime"
        Me.Tool_imprime.Size = New System.Drawing.Size(23, 22)
        Me.Tool_imprime.Text = "Imprimir"
        '
        'exportar
        '
        Me.exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.exportar.Image = CType(resources.GetObject("exportar.Image"), System.Drawing.Image)
        Me.exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exportar.Name = "exportar"
        Me.exportar.Size = New System.Drawing.Size(23, 22)
        Me.exportar.Text = "Exportar"
        '
        'fact_contado
        '
        Me.fact_contado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.fact_contado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.fact_contado.Image = Global.pym.My.Resources.Resources.page_find
        Me.fact_contado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fact_contado.Name = "fact_contado"
        Me.fact_contado.Size = New System.Drawing.Size(23, 22)
        Me.fact_contado.Text = "factura contado"
        '
        'fact_cta_cte
        '
        Me.fact_cta_cte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.fact_cta_cte.Image = Global.pym.My.Resources.Resources.page_find
        Me.fact_cta_cte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fact_cta_cte.Name = "fact_cta_cte"
        Me.fact_cta_cte.Size = New System.Drawing.Size(23, 22)
        Me.fact_cta_cte.Text = "factura cta cte"
        '
        'factura_totales
        '
        Me.factura_totales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.factura_totales.Image = CType(resources.GetObject("factura_totales.Image"), System.Drawing.Image)
        Me.factura_totales.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.factura_totales.Name = "factura_totales"
        Me.factura_totales.Size = New System.Drawing.Size(23, 22)
        Me.factura_totales.Text = "Total Facturas"
        '
        'tool_art_sin_stock
        '
        Me.tool_art_sin_stock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_art_sin_stock.Image = CType(resources.GetObject("tool_art_sin_stock.Image"), System.Drawing.Image)
        Me.tool_art_sin_stock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_art_sin_stock.Name = "tool_art_sin_stock"
        Me.tool_art_sin_stock.Size = New System.Drawing.Size(23, 22)
        Me.tool_art_sin_stock.Text = "Busqueda articulos sin stock"
        '
        'Tool_reemplaza_art
        '
        Me.Tool_reemplaza_art.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_reemplaza_art.Image = CType(resources.GetObject("Tool_reemplaza_art.Image"), System.Drawing.Image)
        Me.Tool_reemplaza_art.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_reemplaza_art.Name = "Tool_reemplaza_art"
        Me.Tool_reemplaza_art.Size = New System.Drawing.Size(23, 22)
        Me.Tool_reemplaza_art.Text = "Reemplaza Articulo"
        '
        'txt_cierra_form
        '
        Me.txt_cierra_form.AcceptsReturn = True
        Me.txt_cierra_form.Location = New System.Drawing.Point(12, 12)
        Me.txt_cierra_form.Name = "txt_cierra_form"
        Me.txt_cierra_form.Size = New System.Drawing.Size(43, 20)
        Me.txt_cierra_form.TabIndex = 50
        Me.txt_cierra_form.Text = "1"
        Me.txt_cierra_form.Visible = False
        '
        'txt_estado_form
        '
        Me.txt_estado_form.Location = New System.Drawing.Point(74, 12)
        Me.txt_estado_form.Name = "txt_estado_form"
        Me.txt_estado_form.Size = New System.Drawing.Size(100, 20)
        Me.txt_estado_form.TabIndex = 51
        Me.txt_estado_form.Text = "0"
        Me.txt_estado_form.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LightGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(19, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 23)
        Me.Label4.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(692, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Anulados"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(19, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 23)
        Me.Label6.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(693, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Activos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(617, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 87)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(389, 12)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(166, 20)
        Me.DataGridView2.TabIndex = 57
        Me.DataGridView2.Visible = False
        '
        'txt_n_carga
        '
        Me.txt_n_carga.Location = New System.Drawing.Point(201, 12)
        Me.txt_n_carga.Name = "txt_n_carga"
        Me.txt_n_carga.Size = New System.Drawing.Size(100, 20)
        Me.txt_n_carga.TabIndex = 58
        Me.txt_n_carga.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-2, 500)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(664, 37)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Total:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form_muestra_cons_comp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 536)
        Me.Controls.Add(Me.txt_n_carga)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_estado_form)
        Me.Controls.Add(Me.txt_cierra_form)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txt_comentario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_muestra_cons_comp"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobantes Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ColumnasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tool_imprime As System.Windows.Forms.ToolStripButton
    Friend WithEvents exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_cierra_form As System.Windows.Forms.TextBox
    Friend WithEvents fact_contado As System.Windows.Forms.ToolStripButton
    Friend WithEvents fact_cta_cte As System.Windows.Forms.ToolStripButton
    Friend WithEvents factura_totales As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_estado_form As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents tool_art_sin_stock As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_reemplaza_art As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_n_carga As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
