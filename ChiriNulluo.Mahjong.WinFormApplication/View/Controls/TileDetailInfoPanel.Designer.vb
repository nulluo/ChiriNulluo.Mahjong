<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TileDetailInfoPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.EnlargedImage = New System.Windows.Forms.PictureBox()
        Me.PrecureNameLabel = New System.Windows.Forms.Label()
        Me.NumberLabel = New System.Windows.Forms.Label()
        Me.SuitNameLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.EnlargedImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EnlargedImage
        '
        Me.EnlargedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EnlargedImage.Location = New System.Drawing.Point(8, 8)
        Me.EnlargedImage.Name = "EnlargedImage"
        Me.EnlargedImage.Size = New System.Drawing.Size(140, 140)
        Me.EnlargedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.EnlargedImage.TabIndex = 0
        Me.EnlargedImage.TabStop = False
        '
        'PrecureNameLabel
        '
        Me.PrecureNameLabel.AutoSize = True
        Me.PrecureNameLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PrecureNameLabel.Location = New System.Drawing.Point(154, 43)
        Me.PrecureNameLabel.Name = "PrecureNameLabel"
        Me.PrecureNameLabel.Size = New System.Drawing.Size(84, 21)
        Me.PrecureNameLabel.TabIndex = 1
        Me.PrecureNameLabel.Text = "Label1"
        '
        'NumberLabel
        '
        Me.NumberLabel.AutoSize = True
        Me.NumberLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberLabel.Location = New System.Drawing.Point(369, 8)
        Me.NumberLabel.Name = "NumberLabel"
        Me.NumberLabel.Size = New System.Drawing.Size(26, 21)
        Me.NumberLabel.TabIndex = 1
        Me.NumberLabel.Text = "0"
        Me.NumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SuitNameLabel
        '
        Me.SuitNameLabel.AutoSize = True
        Me.SuitNameLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SuitNameLabel.Location = New System.Drawing.Point(154, 78)
        Me.SuitNameLabel.Name = "SuitNameLabel"
        Me.SuitNameLabel.Size = New System.Drawing.Size(64, 16)
        Me.SuitNameLabel.TabIndex = 1
        Me.SuitNameLabel.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'TileDetailInfoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Controls.Add(Me.NumberLabel)
        Me.Controls.Add(Me.SuitNameLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PrecureNameLabel)
        Me.Controls.Add(Me.EnlargedImage)
        Me.Name = "TileDetailInfoPanel"
        Me.Size = New System.Drawing.Size(430, 180)
        CType(Me.EnlargedImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EnlargedImage As PictureBox
    Friend WithEvents PrecureNameLabel As Label
    Friend WithEvents NumberLabel As Label
    Friend WithEvents SuitNameLabel As Label
    Friend WithEvents Label1 As Label
End Class
