<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bienvenida
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(bienvenida))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbl_menu = New System.Windows.Forms.Label
        Me.lbl_version = New System.Windows.Forms.Label
        Me.lbl_version1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_version3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_copy = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 133)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(403, 137)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lbl_menu
        '
        Me.lbl_menu.BackColor = System.Drawing.Color.Transparent
        Me.lbl_menu.Location = New System.Drawing.Point(195, 247)
        Me.lbl_menu.Name = "lbl_menu"
        Me.lbl_menu.Size = New System.Drawing.Size(197, 23)
        Me.lbl_menu.TabIndex = 1
        '
        'lbl_version
        '
        Me.lbl_version.BackColor = System.Drawing.Color.White
        Me.lbl_version.Location = New System.Drawing.Point(82, 4)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(28, 20)
        Me.lbl_version.TabIndex = 2
        Me.lbl_version.Text = "0"
        '
        'lbl_version1
        '
        Me.lbl_version1.BackColor = System.Drawing.Color.White
        Me.lbl_version1.Location = New System.Drawing.Point(57, 4)
        Me.lbl_version1.Name = "lbl_version1"
        Me.lbl_version1.Size = New System.Drawing.Size(28, 20)
        Me.lbl_version1.TabIndex = 3
        Me.lbl_version1.Text = "0"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Version:"
        '
        'lbl_version3
        '
        Me.lbl_version3.BackColor = System.Drawing.Color.White
        Me.lbl_version3.Location = New System.Drawing.Point(108, 4)
        Me.lbl_version3.Name = "lbl_version3"
        Me.lbl_version3.Size = New System.Drawing.Size(27, 20)
        Me.lbl_version3.TabIndex = 5
        Me.lbl_version3.Text = "0"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Copyright:"
        '
        'lbl_copy
        '
        Me.lbl_copy.BackColor = System.Drawing.Color.White
        Me.lbl_copy.Location = New System.Drawing.Point(60, 19)
        Me.lbl_copy.Name = "lbl_copy"
        Me.lbl_copy.Size = New System.Drawing.Size(46, 20)
        Me.lbl_copy.TabIndex = 7
        Me.lbl_copy.Text = "Ver"
        '
        'bienvenida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(404, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_copy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_version3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_version1)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_menu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "bienvenida"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_menu As System.Windows.Forms.Label
    Friend WithEvents lbl_version As System.Windows.Forms.Label
    Friend WithEvents lbl_version1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_version3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_copy As System.Windows.Forms.Label

End Class
