﻿Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MatchResultForm
        Inherits BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatchResultForm))
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.talkWindowPictureBox = New System.Windows.Forms.PictureBox()
            Me.exitButton = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.humanPointField = New System.Windows.Forms.Label()
            Me.comPointField = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TwitterShareButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.TwitterShareButton, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PictureBox1
            '
            resources.ApplyResources(Me.PictureBox1, "PictureBox1")
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.No
            Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.TabStop = False
            '
            'Label1
            '
            resources.ApplyResources(Me.Label1, "Label1")
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Name = "Label1"
            '
            'talkWindowPictureBox
            '
            resources.ApplyResources(Me.talkWindowPictureBox, "talkWindowPictureBox")
            Me.talkWindowPictureBox.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
            Me.talkWindowPictureBox.Name = "talkWindowPictureBox"
            Me.talkWindowPictureBox.TabStop = False
            '
            'exitButton
            '
            resources.ApplyResources(Me.exitButton, "exitButton")
            Me.exitButton.Name = "exitButton"
            Me.exitButton.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            resources.ApplyResources(Me.GroupBox2, "GroupBox2")
            Me.GroupBox2.Controls.Add(Me.humanPointField)
            Me.GroupBox2.Controls.Add(Me.comPointField)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.TabStop = False
            '
            'humanPointField
            '
            resources.ApplyResources(Me.humanPointField, "humanPointField")
            Me.humanPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.humanPointField.Name = "humanPointField"
            '
            'comPointField
            '
            resources.ApplyResources(Me.comPointField, "comPointField")
            Me.comPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.comPointField.Name = "comPointField"
            '
            'Label4
            '
            resources.ApplyResources(Me.Label4, "Label4")
            Me.Label4.Name = "Label4"
            '
            'Label3
            '
            resources.ApplyResources(Me.Label3, "Label3")
            Me.Label3.Name = "Label3"
            '
            'TwitterShareButton
            '
            resources.ApplyResources(Me.TwitterShareButton, "TwitterShareButton")
            Me.TwitterShareButton.HoverImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.Name = "TwitterShareButton"
            Me.TwitterShareButton.PushedImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.TabStop = False
            '
            'MatchResultForm
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Pink
            Me.Controls.Add(Me.TwitterShareButton)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.exitButton)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.talkWindowPictureBox)
            Me.Controls.Add(Me.PictureBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "MatchResultForm"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.talkWindowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            CType(Me.TwitterShareButton, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents TwitterShareButton As RichButton
    End Class
End Namespace