﻿Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InitialForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InitialForm))
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
            Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.replayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.PlaysBGMMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.PlaysSEMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ヘルプHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.VersionInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.LogTestButton = New System.Windows.Forms.Button()
            Me.TwitterShareButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            Me.openRuleFormButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            Me.GameStartButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            Me.MenuStrip1.SuspendLayout()
            CType(Me.TwitterShareButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.openRuleFormButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GameStartButton, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'MenuStrip1
            '
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugToolStripMenuItem, Me.設定ToolStripMenuItem, Me.ヘルプHToolStripMenuItem})
            Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(296, 24)
            Me.MenuStrip1.TabIndex = 1
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'DebugToolStripMenuItem
            '
            Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.replayToolStripMenuItem})
            Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
            Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
            Me.DebugToolStripMenuItem.Text = "デバッグ(&D)"
            '
            'replayToolStripMenuItem
            '
            Me.replayToolStripMenuItem.Name = "replayToolStripMenuItem"
            Me.replayToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
            Me.replayToolStripMenuItem.Text = "以前のゲームをリプレイ(実装中)"
            '
            '設定ToolStripMenuItem
            '
            Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlaysBGMMenuItem, Me.PlaysSEMenuItem})
            Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
            Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
            Me.設定ToolStripMenuItem.Text = "設定(&O)"
            '
            'PlaysBGMMenuItem
            '
            Me.PlaysBGMMenuItem.CheckOnClick = True
            Me.PlaysBGMMenuItem.Name = "PlaysBGMMenuItem"
            Me.PlaysBGMMenuItem.Size = New System.Drawing.Size(140, 22)
            Me.PlaysBGMMenuItem.Text = "BGMを鳴らす"
            '
            'PlaysSEMenuItem
            '
            Me.PlaysSEMenuItem.CheckOnClick = True
            Me.PlaysSEMenuItem.Name = "PlaysSEMenuItem"
            Me.PlaysSEMenuItem.Size = New System.Drawing.Size(140, 22)
            Me.PlaysSEMenuItem.Text = "SEを鳴らす"
            '
            'ヘルプHToolStripMenuItem
            '
            Me.ヘルプHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VersionInfoToolStripMenuItem})
            Me.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem"
            Me.ヘルプHToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
            Me.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)"
            '
            'VersionInfoToolStripMenuItem
            '
            Me.VersionInfoToolStripMenuItem.Name = "VersionInfoToolStripMenuItem"
            Me.VersionInfoToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
            Me.VersionInfoToolStripMenuItem.Text = "バージョン情報"
            '
            'LogTestButton
            '
            Me.LogTestButton.Location = New System.Drawing.Point(222, 141)
            Me.LogTestButton.Name = "LogTestButton"
            Me.LogTestButton.Size = New System.Drawing.Size(75, 23)
            Me.LogTestButton.TabIndex = 44
            Me.LogTestButton.Text = "LogTest"
            Me.LogTestButton.UseVisualStyleBackColor = True
            Me.LogTestButton.Visible = False
            '
            'TwitterShareButton
            '
            Me.TwitterShareButton.HoverImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.TwitterShareButton.Location = New System.Drawing.Point(5, 251)
            Me.TwitterShareButton.Name = "TwitterShareButton"
            Me.TwitterShareButton.PushedImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.TwitterShare
            Me.TwitterShareButton.Size = New System.Drawing.Size(121, 35)
            Me.TwitterShareButton.TabIndex = 41
            Me.TwitterShareButton.TabStop = False
            '
            'openRuleFormButton
            '
            Me.openRuleFormButton.HoverImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton1
            Me.openRuleFormButton.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton0
            Me.openRuleFormButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.openRuleFormButton.Location = New System.Drawing.Point(89, 193)
            Me.openRuleFormButton.Name = "openRuleFormButton"
            Me.openRuleFormButton.PushedImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton2
            Me.openRuleFormButton.Size = New System.Drawing.Size(121, 50)
            Me.openRuleFormButton.TabIndex = 41
            Me.openRuleFormButton.TabStop = False
            '
            'GameStartButton
            '
            Me.GameStartButton.BackColor = System.Drawing.Color.Transparent
            Me.GameStartButton.HoverImage = CType(resources.GetObject("GameStartButton.HoverImage"), System.Drawing.Image)
            Me.GameStartButton.Image = CType(resources.GetObject("GameStartButton.Image"), System.Drawing.Image)
            Me.GameStartButton.Location = New System.Drawing.Point(89, 127)
            Me.GameStartButton.Name = "GameStartButton"
            Me.GameStartButton.PushedImage = CType(resources.GetObject("GameStartButton.PushedImage"), System.Drawing.Image)
            Me.GameStartButton.Size = New System.Drawing.Size(127, 50)
            Me.GameStartButton.TabIndex = 2
            Me.GameStartButton.TabStop = False
            '
            'InitialForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ClientSize = New System.Drawing.Size(296, 320)
            Me.Controls.Add(Me.LogTestButton)
            Me.Controls.Add(Me.TwitterShareButton)
            Me.Controls.Add(Me.openRuleFormButton)
            Me.Controls.Add(Me.GameStartButton)
            Me.Controls.Add(Me.MenuStrip1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MainMenuStrip = Me.MenuStrip1
            Me.MaximizeBox = False
            Me.MaximumSize = New System.Drawing.Size(316, 363)
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(316, 363)
            Me.Name = "InitialForm"
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            CType(Me.TwitterShareButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.openRuleFormButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GameStartButton, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents MenuStrip1 As MenuStrip
        Friend WithEvents DebugToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents replayToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents PlaysBGMMenuItem As ToolStripMenuItem
        Friend WithEvents PlaysSEMenuItem As ToolStripMenuItem
        Friend WithEvents GameStartButton As RichButton
        Friend WithEvents openRuleFormButton As RichButton
        Friend WithEvents ヘルプHToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents VersionInfoToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents LogTestButton As Button
        Friend WithEvents TwitterShareButton As RichButton
    End Class
End Namespace