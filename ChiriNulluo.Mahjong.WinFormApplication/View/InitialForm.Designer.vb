<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InitialForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.replayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaysBGMMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaysSEMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.InitialForm_Back
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugToolStripMenuItem, Me.設定ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(300, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
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
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        'PlaysBGMMenuItem
        '
        Me.PlaysBGMMenuItem.CheckOnClick = True
        Me.PlaysBGMMenuItem.Name = "PlaysBGMMenuItem"
        Me.PlaysBGMMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PlaysBGMMenuItem.Text = "BGMを鳴らす"
        '
        'PlaysSEMenuItem
        '
        Me.PlaysSEMenuItem.CheckOnClick = True
        Me.PlaysSEMenuItem.Name = "PlaysSEMenuItem"
        Me.PlaysSEMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PlaysSEMenuItem.Text = "SEを鳴らす"
        '
        'InitialForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 324)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(316, 363)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(316, 363)
        Me.Name = "InitialForm"
        Me.Text = "キュア☆ジャン(プロトタイプ版)"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DebugToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents replayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaysBGMMenuItem As ToolStripMenuItem
    Friend WithEvents PlaysSEMenuItem As ToolStripMenuItem
End Class
