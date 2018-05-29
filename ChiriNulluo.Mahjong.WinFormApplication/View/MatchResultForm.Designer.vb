<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatchResultForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.talkWindowPictureBox = New System.Windows.Forms.PictureBox()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.humanPointField = New System.Windows.Forms.Label()
        Me.comPointField = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
        Me.PictureBox1.Location = New System.Drawing.Point(42, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(179, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 89)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'talkWindowPictureBox
        '
        Me.talkWindowPictureBox.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
        Me.talkWindowPictureBox.Location = New System.Drawing.Point(167, 53)
        Me.talkWindowPictureBox.Name = "talkWindowPictureBox"
        Me.talkWindowPictureBox.Size = New System.Drawing.Size(420, 119)
        Me.talkWindowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.talkWindowPictureBox.TabIndex = 5
        Me.talkWindowPictureBox.TabStop = False
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(469, 333)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(178, 49)
        Me.exitButton.TabIndex = 7
        Me.exitButton.Text = "Return to Title"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.humanPointField)
        Me.GroupBox2.Controls.Add(Me.comPointField)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(42, 192)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 135)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Score"
        '
        'humanPointField
        '
        Me.humanPointField.AutoSize = True
        Me.humanPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.humanPointField.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.humanPointField.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.humanPointField.Location = New System.Drawing.Point(250, 74)
        Me.humanPointField.Name = "humanPointField"
        Me.humanPointField.Size = New System.Drawing.Size(114, 39)
        Me.humanPointField.TabIndex = 10
        Me.humanPointField.Text = "*****"
        '
        'comPointField
        '
        Me.comPointField.AutoSize = True
        Me.comPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.comPointField.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.comPointField.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.comPointField.Location = New System.Drawing.Point(250, 25)
        Me.comPointField.Name = "comPointField"
        Me.comPointField.Size = New System.Drawing.Size(114, 39)
        Me.comPointField.TabIndex = 10
        Me.comPointField.Text = "*****"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(118, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 37)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "YOU"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(118, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 37)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "COM"
        '
        'MatchResultForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 394)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.talkWindowPictureBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MatchResultForm"
        Me.Text = "DisplayMatchResultForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents talkWindowPictureBox As PictureBox
    Friend WithEvents exitButton As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents humanPointField As Label
    Friend WithEvents comPointField As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
