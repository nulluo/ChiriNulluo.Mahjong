Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GameTasteWindowTestForm1
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
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PictureBox1
            '
            Me.PictureBox1.BackgroundImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(553, 341)
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(48, 51)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(117, 60)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "あいうえお" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "アイカツカフェ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "魔女集会で会いましょう" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "プリキュアオールスターズ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "百花繚乱"
            '
            'RichTextBox1
            '
            Me.RichTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
            Me.RichTextBox1.BulletIndent = 10
            Me.RichTextBox1.Location = New System.Drawing.Point(50, 266)
            Me.RichTextBox1.Name = "RichTextBox1"
            Me.RichTextBox1.Size = New System.Drawing.Size(438, 39)
            Me.RichTextBox1.TabIndex = 2
            Me.RichTextBox1.Text = "あいうえお" & Global.Microsoft.VisualBasic.ChrW(10) & "アイカツカフェ" & Global.Microsoft.VisualBasic.ChrW(10) & "魔女集会で会いましょう" & Global.Microsoft.VisualBasic.ChrW(10) & "プリキュアオールスターズ" & Global.Microsoft.VisualBasic.ChrW(10) & "百花繚乱" & Global.Microsoft.VisualBasic.ChrW(10)
            '
            'GameTasteWindowTestForm1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(578, 407)
            Me.Controls.Add(Me.RichTextBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.PictureBox1)
            Me.Name = "GameTasteWindowTestForm1"
            Me.Text = "GameTasteWindowTestForm1"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents PictureBox1 As PictureBox
        Friend WithEvents Label1 As Label
        Friend WithEvents RichTextBox1 As RichTextBox
    End Class
End Namespace