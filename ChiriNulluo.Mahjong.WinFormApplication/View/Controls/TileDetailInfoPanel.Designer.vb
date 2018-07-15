Namespace View
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
            Me.NameLabel = New System.Windows.Forms.Label()
            Me.NumberLabel = New System.Windows.Forms.Label()
            Me.SuitNameLabel = New System.Windows.Forms.Label()
            Me.CureNameLabel = New System.Windows.Forms.Label()
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
            'NameLabel
            '
            Me.NameLabel.AutoSize = True
            Me.NameLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.NameLabel.Location = New System.Drawing.Point(154, 8)
            Me.NameLabel.Name = "NameLabel"
            Me.NameLabel.Size = New System.Drawing.Size(90, 21)
            Me.NameLabel.TabIndex = 1
            Me.NameLabel.Text = "Label1"
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
            'CureNameLabel
            '
            Me.CureNameLabel.AutoSize = True
            Me.CureNameLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.CureNameLabel.Location = New System.Drawing.Point(153, 41)
            Me.CureNameLabel.Name = "CureNameLabel"
            Me.CureNameLabel.Size = New System.Drawing.Size(84, 21)
            Me.CureNameLabel.TabIndex = 1
            Me.CureNameLabel.Text = "Label1"
            '
            'TileDetailInfoPanel
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.PaleTurquoise
            Me.Controls.Add(Me.NumberLabel)
            Me.Controls.Add(Me.SuitNameLabel)
            Me.Controls.Add(Me.CureNameLabel)
            Me.Controls.Add(Me.NameLabel)
            Me.Controls.Add(Me.EnlargedImage)
            Me.Name = "TileDetailInfoPanel"
            Me.Size = New System.Drawing.Size(430, 180)
            CType(Me.EnlargedImage, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents EnlargedImage As PictureBox
        Friend WithEvents NameLabel As Label
        Friend WithEvents NumberLabel As Label
        Friend WithEvents SuitNameLabel As Label
        Friend WithEvents CureNameLabel As Label
    End Class
End Namespace