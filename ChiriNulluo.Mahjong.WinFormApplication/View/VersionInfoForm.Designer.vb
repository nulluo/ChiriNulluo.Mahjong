Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VersionInfoForm
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
            Me.VersionField = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label3 = New System.Windows.Forms.Label()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'okButton
            '
            Me.okButton.Location = New System.Drawing.Point(356, 159)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(77, 27)
            Me.okButton.TabIndex = 0
            Me.okButton.Text = "OK(&O)"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 80)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(50, 12)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "バージョン"
            '
            'VersionField
            '
            Me.VersionField.AutoSize = True
            Me.VersionField.Location = New System.Drawing.Point(88, 80)
            Me.VersionField.Name = "VersionField"
            Me.VersionField.Size = New System.Drawing.Size(35, 12)
            Me.VersionField.TabIndex = 1
            Me.VersionField.Text = "0.0.0.0"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(12, 117)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(70, 12)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "サポートサイト"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.Location = New System.Drawing.Point(88, 117)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(316, 12)
            Me.LinkLabel1.TabIndex = 2
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "https://nulluo.github.io/ChiriNulluo.Game.WebSite/CureJong/"
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TileStood0101
            Me.PictureBox1.Location = New System.Drawing.Point(385, 12)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(48, 80)
            Me.PictureBox1.TabIndex = 3
            Me.PictureBox1.TabStop = False
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(11, 22)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 12)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "キュア☆ジャン"
            '
            'VersionInfoForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(449, 206)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.VersionField)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.okButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximumSize = New System.Drawing.Size(465, 245)
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(465, 245)
            Me.Name = "VersionInfoForm"
            Me.Text = "バージョン情報"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents okButton As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents VersionField As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents LinkLabel1 As LinkLabel
        Friend WithEvents PictureBox1 As PictureBox
        Friend WithEvents Label3 As Label
    End Class
End Namespace