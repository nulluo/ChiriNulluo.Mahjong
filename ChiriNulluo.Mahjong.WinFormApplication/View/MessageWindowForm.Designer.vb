Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MessageWindowForm
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
            Me.CharaPicture = New System.Windows.Forms.PictureBox()
            Me.CursorLabel3 = New System.Windows.Forms.Label()
            Me.CursorLabel0 = New System.Windows.Forms.Label()
            Me.CursorLabel2 = New System.Windows.Forms.Label()
            Me.CursorLabel1 = New System.Windows.Forms.Label()
            Me.ChoiceLabel3 = New System.Windows.Forms.Label()
            Me.ChoiceLabel0 = New System.Windows.Forms.Label()
            Me.MainMessageLabel = New System.Windows.Forms.Label()
            Me.ChoiceLabel2 = New System.Windows.Forms.Label()
            Me.ChoiceLabel1 = New System.Windows.Forms.Label()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.CharaPicture, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.SplitContainer1.Panel1.Controls.Add(Me.CharaPicture)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.BackgroundImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.SplitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.SplitContainer1.Panel2.Controls.Add(Me.CursorLabel3)
            Me.SplitContainer1.Panel2.Controls.Add(Me.CursorLabel0)
            Me.SplitContainer1.Panel2.Controls.Add(Me.CursorLabel2)
            Me.SplitContainer1.Panel2.Controls.Add(Me.CursorLabel1)
            Me.SplitContainer1.Panel2.Controls.Add(Me.ChoiceLabel3)
            Me.SplitContainer1.Panel2.Controls.Add(Me.ChoiceLabel0)
            Me.SplitContainer1.Panel2.Controls.Add(Me.MainMessageLabel)
            Me.SplitContainer1.Panel2.Controls.Add(Me.ChoiceLabel2)
            Me.SplitContainer1.Panel2.Controls.Add(Me.ChoiceLabel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(428, 165)
            Me.SplitContainer1.SplitterDistance = 129
            Me.SplitContainer1.TabIndex = 8
            '
            'CharaPicture
            '
            Me.CharaPicture.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.CharaPicture.Location = New System.Drawing.Point(3, 25)
            Me.CharaPicture.Name = "CharaPicture"
            Me.CharaPicture.Size = New System.Drawing.Size(120, 120)
            Me.CharaPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.CharaPicture.TabIndex = 7
            Me.CharaPicture.TabStop = False
            '
            'CursorLabel3
            '
            Me.CursorLabel3.AutoSize = True
            Me.CursorLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CursorLabel3.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.CursorLabel3.ForeColor = System.Drawing.Color.White
            Me.CursorLabel3.Location = New System.Drawing.Point(7, 133)
            Me.CursorLabel3.Name = "CursorLabel3"
            Me.CursorLabel3.Size = New System.Drawing.Size(29, 19)
            Me.CursorLabel3.TabIndex = 2
            Me.CursorLabel3.Text = "⇒"
            '
            'CursorLabel0
            '
            Me.CursorLabel0.AutoSize = True
            Me.CursorLabel0.BackColor = System.Drawing.Color.Transparent
            Me.CursorLabel0.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.CursorLabel0.ForeColor = System.Drawing.Color.White
            Me.CursorLabel0.Location = New System.Drawing.Point(7, 56)
            Me.CursorLabel0.Name = "CursorLabel0"
            Me.CursorLabel0.Size = New System.Drawing.Size(29, 19)
            Me.CursorLabel0.TabIndex = 3
            Me.CursorLabel0.Text = "⇒"
            '
            'CursorLabel2
            '
            Me.CursorLabel2.AutoSize = True
            Me.CursorLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CursorLabel2.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.CursorLabel2.ForeColor = System.Drawing.Color.White
            Me.CursorLabel2.Location = New System.Drawing.Point(7, 106)
            Me.CursorLabel2.Name = "CursorLabel2"
            Me.CursorLabel2.Size = New System.Drawing.Size(29, 19)
            Me.CursorLabel2.TabIndex = 4
            Me.CursorLabel2.Text = "⇒"
            '
            'CursorLabel1
            '
            Me.CursorLabel1.AutoSize = True
            Me.CursorLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CursorLabel1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.CursorLabel1.ForeColor = System.Drawing.Color.White
            Me.CursorLabel1.Location = New System.Drawing.Point(7, 81)
            Me.CursorLabel1.Name = "CursorLabel1"
            Me.CursorLabel1.Size = New System.Drawing.Size(29, 19)
            Me.CursorLabel1.TabIndex = 5
            Me.CursorLabel1.Text = "⇒"
            '
            'ChoiceLabel3
            '
            Me.ChoiceLabel3.AutoSize = True
            Me.ChoiceLabel3.BackColor = System.Drawing.Color.Transparent
            Me.ChoiceLabel3.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.ChoiceLabel3.ForeColor = System.Drawing.Color.White
            Me.ChoiceLabel3.Location = New System.Drawing.Point(35, 133)
            Me.ChoiceLabel3.Name = "ChoiceLabel3"
            Me.ChoiceLabel3.Size = New System.Drawing.Size(81, 19)
            Me.ChoiceLabel3.TabIndex = 1
            Me.ChoiceLabel3.Text = "Label2"
            '
            'ChoiceLabel0
            '
            Me.ChoiceLabel0.AutoSize = True
            Me.ChoiceLabel0.BackColor = System.Drawing.Color.Transparent
            Me.ChoiceLabel0.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.ChoiceLabel0.ForeColor = System.Drawing.Color.White
            Me.ChoiceLabel0.Location = New System.Drawing.Point(35, 56)
            Me.ChoiceLabel0.Name = "ChoiceLabel0"
            Me.ChoiceLabel0.Size = New System.Drawing.Size(81, 19)
            Me.ChoiceLabel0.TabIndex = 1
            Me.ChoiceLabel0.Text = "Label2"
            '
            'MainMessageLabel
            '
            Me.MainMessageLabel.AutoSize = True
            Me.MainMessageLabel.BackColor = System.Drawing.Color.Transparent
            Me.MainMessageLabel.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.MainMessageLabel.ForeColor = System.Drawing.Color.White
            Me.MainMessageLabel.Location = New System.Drawing.Point(16, 9)
            Me.MainMessageLabel.Name = "MainMessageLabel"
            Me.MainMessageLabel.Size = New System.Drawing.Size(81, 19)
            Me.MainMessageLabel.TabIndex = 0
            Me.MainMessageLabel.Text = "Label2"
            '
            'ChoiceLabel2
            '
            Me.ChoiceLabel2.AutoSize = True
            Me.ChoiceLabel2.BackColor = System.Drawing.Color.Transparent
            Me.ChoiceLabel2.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.ChoiceLabel2.ForeColor = System.Drawing.Color.White
            Me.ChoiceLabel2.Location = New System.Drawing.Point(35, 106)
            Me.ChoiceLabel2.Name = "ChoiceLabel2"
            Me.ChoiceLabel2.Size = New System.Drawing.Size(81, 19)
            Me.ChoiceLabel2.TabIndex = 1
            Me.ChoiceLabel2.Text = "Label2"
            '
            'ChoiceLabel1
            '
            Me.ChoiceLabel1.AutoSize = True
            Me.ChoiceLabel1.BackColor = System.Drawing.Color.Transparent
            Me.ChoiceLabel1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.ChoiceLabel1.ForeColor = System.Drawing.Color.White
            Me.ChoiceLabel1.Location = New System.Drawing.Point(35, 81)
            Me.ChoiceLabel1.Name = "ChoiceLabel1"
            Me.ChoiceLabel1.Size = New System.Drawing.Size(81, 19)
            Me.ChoiceLabel1.TabIndex = 1
            Me.ChoiceLabel1.Text = "Label2"
            '
            'MessageWindowForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(428, 165)
            Me.Controls.Add(Me.SplitContainer1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "MessageWindowForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "MessageWindowForm"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.Panel2.PerformLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.CharaPicture, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents CharaPicture As PictureBox
        Friend WithEvents ChoiceLabel3 As Label
        Friend WithEvents ChoiceLabel2 As Label
        Friend WithEvents ChoiceLabel1 As Label
        Friend WithEvents MainMessageLabel As Label
        Friend WithEvents ChoiceLabel0 As Label
        Friend WithEvents CursorLabel3 As Label
        Friend WithEvents CursorLabel0 As Label
        Friend WithEvents CursorLabel2 As Label
        Friend WithEvents CursorLabel1 As Label
    End Class
End Namespace