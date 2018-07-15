Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TileSelectWindowForm
        Inherits System.Windows.Forms.Form

        'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.okButton = New System.Windows.Forms.Button()
            Me.HorizontalRevealedHandPanel1 = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalRevealedHandPanel()
            Me.rightButton = New System.Windows.Forms.Button()
            Me.leftButton = New System.Windows.Forms.Button()
            Me.MainMessageLabel = New System.Windows.Forms.Label()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.okButton)
            Me.SplitContainer1.Panel2.Controls.Add(Me.HorizontalRevealedHandPanel1)
            Me.SplitContainer1.Panel2.Controls.Add(Me.rightButton)
            Me.SplitContainer1.Panel2.Controls.Add(Me.leftButton)
            Me.SplitContainer1.Panel2.Controls.Add(Me.MainMessageLabel)
            Me.SplitContainer1.Size = New System.Drawing.Size(573, 165)
            Me.SplitContainer1.SplitterDistance = 138
            Me.SplitContainer1.TabIndex = 0
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(120, 120)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 8
            Me.PictureBox1.TabStop = False
            '
            'okButton
            '
            Me.okButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.okButton.Location = New System.Drawing.Point(328, 79)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(91, 63)
            Me.okButton.TabIndex = 13
            Me.okButton.Text = "OK"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'HorizontalRevealedHandPanel1
            '
            Me.HorizontalRevealedHandPanel1.DataSource = Nothing
            Me.HorizontalRevealedHandPanel1.Location = New System.Drawing.Point(69, 70)
            Me.HorizontalRevealedHandPanel1.Name = "HorizontalRevealedHandPanel1"
            Me.HorizontalRevealedHandPanel1.Size = New System.Drawing.Size(144, 80)
            Me.HorizontalRevealedHandPanel1.TabIndex = 10
            '
            'rightButton
            '
            Me.rightButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.rightButton.Location = New System.Drawing.Point(212, 79)
            Me.rightButton.Name = "rightButton"
            Me.rightButton.Size = New System.Drawing.Size(58, 63)
            Me.rightButton.TabIndex = 12
            Me.rightButton.Text = "|>"
            Me.rightButton.UseVisualStyleBackColor = True
            '
            'leftButton
            '
            Me.leftButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.leftButton.Location = New System.Drawing.Point(10, 79)
            Me.leftButton.Name = "leftButton"
            Me.leftButton.Size = New System.Drawing.Size(58, 63)
            Me.leftButton.TabIndex = 12
            Me.leftButton.Text = "<|"
            Me.leftButton.UseVisualStyleBackColor = True
            '
            'MainMessageLabel
            '
            Me.MainMessageLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MainMessageLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12.25!, System.Drawing.FontStyle.Bold)
            Me.MainMessageLabel.ForeColor = System.Drawing.Color.White
            Me.MainMessageLabel.Location = New System.Drawing.Point(10, 9)
            Me.MainMessageLabel.Name = "MainMessageLabel"
            Me.MainMessageLabel.Size = New System.Drawing.Size(409, 67)
            Me.MainMessageLabel.TabIndex = 11
            Me.MainMessageLabel.Text = "Label2"
            '
            'TileSelectWindowForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(573, 165)
            Me.Controls.Add(Me.SplitContainer1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "TileSelectWindowForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "TileSelectWindowForm"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents PictureBox1 As PictureBox
        Friend WithEvents HorizontalRevealedHandPanel1 As HorizontalRevealedHandPanel
        Friend WithEvents MainMessageLabel As Label
        Friend WithEvents rightButton As Button
        Friend WithEvents leftButton As Button
        Friend WithEvents okButton As Button
    End Class
End Namespace