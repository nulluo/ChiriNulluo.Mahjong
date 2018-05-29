<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HorizontalRevealedHandPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HorizontalRevealedHandPanel))
        Me.tilePicture2 = New System.Windows.Forms.PictureBox()
        Me.tilePicture1 = New System.Windows.Forms.PictureBox()
        Me.tilePicture0 = New System.Windows.Forms.PictureBox()
        CType(Me.tilePicture2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tilePicture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tilePicture0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tilePicture2
        '
        Me.tilePicture2.Image = CType(resources.GetObject("tilePicture2.Image"), System.Drawing.Image)
        Me.tilePicture2.Location = New System.Drawing.Point(96, 0)
        Me.tilePicture2.MaximumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture2.MinimumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture2.Name = "tilePicture2"
        Me.tilePicture2.Size = New System.Drawing.Size(48, 80)
        Me.tilePicture2.TabIndex = 10
        Me.tilePicture2.TabStop = False
        Me.tilePicture2.Tag = "2"
        '
        'tilePicture1
        '
        Me.tilePicture1.Image = CType(resources.GetObject("tilePicture1.Image"), System.Drawing.Image)
        Me.tilePicture1.Location = New System.Drawing.Point(48, 0)
        Me.tilePicture1.MaximumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture1.MinimumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture1.Name = "tilePicture1"
        Me.tilePicture1.Size = New System.Drawing.Size(48, 80)
        Me.tilePicture1.TabIndex = 11
        Me.tilePicture1.TabStop = False
        Me.tilePicture1.Tag = "1"
        '
        'tilePicture0
        '
        Me.tilePicture0.Image = CType(resources.GetObject("tilePicture0.Image"), System.Drawing.Image)
        Me.tilePicture0.Location = New System.Drawing.Point(0, 0)
        Me.tilePicture0.MaximumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture0.MinimumSize = New System.Drawing.Size(48, 80)
        Me.tilePicture0.Name = "tilePicture0"
        Me.tilePicture0.Size = New System.Drawing.Size(48, 80)
        Me.tilePicture0.TabIndex = 12
        Me.tilePicture0.TabStop = False
        Me.tilePicture0.Tag = "0"
        '
        'HorizontalRevealedHandPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tilePicture2)
        Me.Controls.Add(Me.tilePicture1)
        Me.Controls.Add(Me.tilePicture0)
        Me.Name = "HorizontalRevealedHandPanel"
        Me.Size = New System.Drawing.Size(144, 80)
        CType(Me.tilePicture2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tilePicture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tilePicture0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tilePicture2 As PictureBox
    Friend WithEvents tilePicture1 As PictureBox
    Friend WithEvents tilePicture0 As PictureBox
End Class
