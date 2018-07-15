Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TalkingCharaWindowForm
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
            Me.okButton = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.talkWindowPictureBox = New System.Windows.Forms.PictureBox()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'okButton
            '
            Me.okButton.Location = New System.Drawing.Point(329, 130)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(90, 29)
            Me.okButton.TabIndex = 0
            Me.okButton.Text = "OK"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(152, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(256, 89)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Label1"
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Regina01
            Me.PictureBox1.Location = New System.Drawing.Point(7, 5)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(120, 120)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 3
            Me.PictureBox1.TabStop = False
            '
            'talkWindowPictureBox
            '
            Me.talkWindowPictureBox.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.talkWindowPictureBox.Location = New System.Drawing.Point(133, 5)
            Me.talkWindowPictureBox.Name = "talkWindowPictureBox"
            Me.talkWindowPictureBox.Size = New System.Drawing.Size(286, 119)
            Me.talkWindowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.talkWindowPictureBox.TabIndex = 1
            Me.talkWindowPictureBox.TabStop = False
            '
            'TalkingCharaWindowForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(428, 165)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.talkWindowPictureBox)
            Me.Controls.Add(Me.okButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "TalkingCharaWindowForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "TalkingCharaWindowForm"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents okButton As Button
        Friend WithEvents talkWindowPictureBox As PictureBox
        Friend WithEvents Label1 As Label
        Friend WithEvents PictureBox1 As PictureBox
    End Class
End Namespace