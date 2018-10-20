Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RoundForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RoundForm))
            Me.comPointField = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.humanPointField = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.OpponentLabel = New System.Windows.Forms.Label()
            Me.endRoundButton = New System.Windows.Forms.Button()
            Me.allTilesOpenField = New System.Windows.Forms.CheckBox()
            Me.restDrawCountField = New System.Windows.Forms.Label()
            Me.restRoundsField = New System.Windows.Forms.Label()
            Me.RiichiAutoDrawTimer = New System.Windows.Forms.Timer(Me.components)
            Me.BonusTIlePicture0 = New System.Windows.Forms.PictureBox()
            Me.BonusTIlePicture1 = New System.Windows.Forms.PictureBox()
            Me.BonusTIlePicture2 = New System.Windows.Forms.PictureBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.riichiImageHuman = New System.Windows.Forms.PictureBox()
            Me.riichiImageCOM = New System.Windows.Forms.PictureBox()
            Me.TestShantenButton1 = New System.Windows.Forms.Button()
            Me.BonusTIlePicture3 = New System.Windows.Forms.PictureBox()
            Me.BonusTIlePicture4 = New System.Windows.Forms.PictureBox()
            Me.BonusTIlePicture5 = New System.Windows.Forms.PictureBox()
            Me.openRuleFormButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            Me.RiichiButton = New ChiriNulluo.Mahjong.WinFormApplication.View.RichButton()
            Me.humanPlayerDiscardedPilePanel = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalDiscardedPilePanel()
            Me.comPlayerDiscardedPilePanel = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalDiscardedPilePanel()
            Me.comPlayerHandPanel = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalHandPanel()
            Me.horizontalRevealedHandPanel3 = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalRevealedHandPanel()
            Me.humanPlayerHandPanel = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalHandPanel()
            Me.horizontalRevealedHandPanel2 = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalRevealedHandPanel()
            Me.horizontalRevealedHandPanel1 = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalRevealedHandPanel()
            Me.horizontalRevealedHandPanel0 = New ChiriNulluo.Mahjong.WinFormApplication.View.HorizontalRevealedHandPanel()
            Me.TileDetailInfoPanel1 = New ChiriNulluo.Mahjong.WinFormApplication.View.TileDetailInfoPanel()
            CType(Me.BonusTIlePicture0, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BonusTIlePicture1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BonusTIlePicture2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.riichiImageHuman, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.riichiImageCOM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BonusTIlePicture3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BonusTIlePicture4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BonusTIlePicture5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.openRuleFormButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RiichiButton, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'comPointField
            '
            resources.ApplyResources(Me.comPointField, "comPointField")
            Me.comPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.comPointField.ForeColor = System.Drawing.Color.White
            Me.comPointField.Name = "comPointField"
            '
            'Label4
            '
            resources.ApplyResources(Me.Label4, "Label4")
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Name = "Label4"
            '
            'humanPointField
            '
            resources.ApplyResources(Me.humanPointField, "humanPointField")
            Me.humanPointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.humanPointField.ForeColor = System.Drawing.Color.White
            Me.humanPointField.Name = "humanPointField"
            '
            'Label9
            '
            resources.ApplyResources(Me.Label9, "Label9")
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Name = "Label9"
            '
            'Label10
            '
            resources.ApplyResources(Me.Label10, "Label10")
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Name = "Label10"
            '
            'OpponentLabel
            '
            resources.ApplyResources(Me.OpponentLabel, "OpponentLabel")
            Me.OpponentLabel.ForeColor = System.Drawing.Color.White
            Me.OpponentLabel.Name = "OpponentLabel"
            '
            'endRoundButton
            '
            resources.ApplyResources(Me.endRoundButton, "endRoundButton")
            Me.endRoundButton.Name = "endRoundButton"
            Me.endRoundButton.UseVisualStyleBackColor = True
            '
            'allTilesOpenField
            '
            resources.ApplyResources(Me.allTilesOpenField, "allTilesOpenField")
            Me.allTilesOpenField.BackColor = System.Drawing.Color.YellowGreen
            Me.allTilesOpenField.Name = "allTilesOpenField"
            Me.allTilesOpenField.UseVisualStyleBackColor = False
            '
            'restDrawCountField
            '
            resources.ApplyResources(Me.restDrawCountField, "restDrawCountField")
            Me.restDrawCountField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.restDrawCountField.ForeColor = System.Drawing.Color.White
            Me.restDrawCountField.Name = "restDrawCountField"
            '
            'restRoundsField
            '
            resources.ApplyResources(Me.restRoundsField, "restRoundsField")
            Me.restRoundsField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.restRoundsField.ForeColor = System.Drawing.Color.White
            Me.restRoundsField.Name = "restRoundsField"
            '
            'RiichiAutoDrawTimer
            '
            '
            'BonusTIlePicture0
            '
            Me.BonusTIlePicture0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture0, "BonusTIlePicture0")
            Me.BonusTIlePicture0.Name = "BonusTIlePicture0"
            Me.BonusTIlePicture0.TabStop = False
            '
            'BonusTIlePicture1
            '
            Me.BonusTIlePicture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture1, "BonusTIlePicture1")
            Me.BonusTIlePicture1.Name = "BonusTIlePicture1"
            Me.BonusTIlePicture1.TabStop = False
            '
            'BonusTIlePicture2
            '
            Me.BonusTIlePicture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture2, "BonusTIlePicture2")
            Me.BonusTIlePicture2.Name = "BonusTIlePicture2"
            Me.BonusTIlePicture2.TabStop = False
            '
            'Label7
            '
            resources.ApplyResources(Me.Label7, "Label7")
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.ForeColor = System.Drawing.Color.Honeydew
            Me.Label7.Name = "Label7"
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Frame0
            resources.ApplyResources(Me.PictureBox1, "PictureBox1")
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.TabStop = False
            '
            'Label1
            '
            resources.ApplyResources(Me.Label1, "Label1")
            Me.Label1.ForeColor = System.Drawing.Color.Red
            Me.Label1.Name = "Label1"
            '
            'Label11
            '
            resources.ApplyResources(Me.Label11, "Label11")
            Me.Label11.ForeColor = System.Drawing.Color.Red
            Me.Label11.Name = "Label11"
            '
            'Label12
            '
            resources.ApplyResources(Me.Label12, "Label12")
            Me.Label12.ForeColor = System.Drawing.Color.Red
            Me.Label12.Name = "Label12"
            '
            'riichiImageHuman
            '
            resources.ApplyResources(Me.riichiImageHuman, "riichiImageHuman")
            Me.riichiImageHuman.Name = "riichiImageHuman"
            Me.riichiImageHuman.TabStop = False
            '
            'riichiImageCOM
            '
            resources.ApplyResources(Me.riichiImageCOM, "riichiImageCOM")
            Me.riichiImageCOM.Name = "riichiImageCOM"
            Me.riichiImageCOM.TabStop = False
            '
            'TestShantenButton1
            '
            resources.ApplyResources(Me.TestShantenButton1, "TestShantenButton1")
            Me.TestShantenButton1.Name = "TestShantenButton1"
            Me.TestShantenButton1.UseVisualStyleBackColor = True
            '
            'BonusTIlePicture3
            '
            Me.BonusTIlePicture3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture3, "BonusTIlePicture3")
            Me.BonusTIlePicture3.Name = "BonusTIlePicture3"
            Me.BonusTIlePicture3.TabStop = False
            '
            'BonusTIlePicture4
            '
            Me.BonusTIlePicture4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture4, "BonusTIlePicture4")
            Me.BonusTIlePicture4.Name = "BonusTIlePicture4"
            Me.BonusTIlePicture4.TabStop = False
            '
            'BonusTIlePicture5
            '
            Me.BonusTIlePicture5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            resources.ApplyResources(Me.BonusTIlePicture5, "BonusTIlePicture5")
            Me.BonusTIlePicture5.Name = "BonusTIlePicture5"
            Me.BonusTIlePicture5.TabStop = False
            '
            'openRuleFormButton
            '
            Me.openRuleFormButton.HoverImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton1
            Me.openRuleFormButton.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton0
            resources.ApplyResources(Me.openRuleFormButton, "openRuleFormButton")
            Me.openRuleFormButton.Name = "openRuleFormButton"
            Me.openRuleFormButton.PushedImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RuleButton2
            Me.openRuleFormButton.TabStop = False
            '
            'RiichiButton
            '
            Me.RiichiButton.HoverImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RiichiButton1
            Me.RiichiButton.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RiichiButton0
            resources.ApplyResources(Me.RiichiButton, "RiichiButton")
            Me.RiichiButton.Name = "RiichiButton"
            Me.RiichiButton.PushedImage = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.RiichiButton2
            Me.RiichiButton.TabStop = False
            '
            'humanPlayerDiscardedPilePanel
            '
            Me.humanPlayerDiscardedPilePanel.DataSource = Nothing
            resources.ApplyResources(Me.humanPlayerDiscardedPilePanel, "humanPlayerDiscardedPilePanel")
            Me.humanPlayerDiscardedPilePanel.Name = "humanPlayerDiscardedPilePanel"
            '
            'comPlayerDiscardedPilePanel
            '
            Me.comPlayerDiscardedPilePanel.DataSource = Nothing
            resources.ApplyResources(Me.comPlayerDiscardedPilePanel, "comPlayerDiscardedPilePanel")
            Me.comPlayerDiscardedPilePanel.Name = "comPlayerDiscardedPilePanel"
            '
            'comPlayerHandPanel
            '
            Me.comPlayerHandPanel.DataSource = Nothing
            Me.comPlayerHandPanel.DisplayStyle = ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle.HiddenFromHuman
            resources.ApplyResources(Me.comPlayerHandPanel, "comPlayerHandPanel")
            Me.comPlayerHandPanel.Name = "comPlayerHandPanel"
            '
            'horizontalRevealedHandPanel3
            '
            Me.horizontalRevealedHandPanel3.DataSource = Nothing
            resources.ApplyResources(Me.horizontalRevealedHandPanel3, "horizontalRevealedHandPanel3")
            Me.horizontalRevealedHandPanel3.Name = "horizontalRevealedHandPanel3"
            '
            'humanPlayerHandPanel
            '
            Me.humanPlayerHandPanel.DataSource = Nothing
            Me.humanPlayerHandPanel.DisplayStyle = ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle.ShownToHumanStood
            resources.ApplyResources(Me.humanPlayerHandPanel, "humanPlayerHandPanel")
            Me.humanPlayerHandPanel.Name = "humanPlayerHandPanel"
            '
            'horizontalRevealedHandPanel2
            '
            Me.horizontalRevealedHandPanel2.DataSource = Nothing
            resources.ApplyResources(Me.horizontalRevealedHandPanel2, "horizontalRevealedHandPanel2")
            Me.horizontalRevealedHandPanel2.Name = "horizontalRevealedHandPanel2"
            '
            'horizontalRevealedHandPanel1
            '
            Me.horizontalRevealedHandPanel1.DataSource = Nothing
            resources.ApplyResources(Me.horizontalRevealedHandPanel1, "horizontalRevealedHandPanel1")
            Me.horizontalRevealedHandPanel1.Name = "horizontalRevealedHandPanel1"
            '
            'horizontalRevealedHandPanel0
            '
            Me.horizontalRevealedHandPanel0.DataSource = Nothing
            resources.ApplyResources(Me.horizontalRevealedHandPanel0, "horizontalRevealedHandPanel0")
            Me.horizontalRevealedHandPanel0.Name = "horizontalRevealedHandPanel0"
            '
            'TileDetailInfoPanel1
            '
            Me.TileDetailInfoPanel1.BackColor = System.Drawing.Color.PaleTurquoise
            resources.ApplyResources(Me.TileDetailInfoPanel1, "TileDetailInfoPanel1")
            Me.TileDetailInfoPanel1.Name = "TileDetailInfoPanel1"
            Me.TileDetailInfoPanel1.TargetTile = Nothing
            Me.TileDetailInfoPanel1.TargetTileIndex = 0
            '
            'RoundForm
            '
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Green
            Me.Controls.Add(Me.horizontalRevealedHandPanel0)
            Me.Controls.Add(Me.horizontalRevealedHandPanel1)
            Me.Controls.Add(Me.horizontalRevealedHandPanel2)
            Me.Controls.Add(Me.horizontalRevealedHandPanel3)
            Me.Controls.Add(Me.TestShantenButton1)
            Me.Controls.Add(Me.openRuleFormButton)
            Me.Controls.Add(Me.RiichiButton)
            Me.Controls.Add(Me.riichiImageCOM)
            Me.Controls.Add(Me.riichiImageHuman)
            Me.Controls.Add(Me.restDrawCountField)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.humanPointField)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.restRoundsField)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.comPointField)
            Me.Controls.Add(Me.BonusTIlePicture5)
            Me.Controls.Add(Me.BonusTIlePicture4)
            Me.Controls.Add(Me.BonusTIlePicture3)
            Me.Controls.Add(Me.BonusTIlePicture2)
            Me.Controls.Add(Me.allTilesOpenField)
            Me.Controls.Add(Me.BonusTIlePicture1)
            Me.Controls.Add(Me.endRoundButton)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.BonusTIlePicture0)
            Me.Controls.Add(Me.humanPlayerDiscardedPilePanel)
            Me.Controls.Add(Me.OpponentLabel)
            Me.Controls.Add(Me.comPlayerDiscardedPilePanel)
            Me.Controls.Add(Me.comPlayerHandPanel)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.TileDetailInfoPanel1)
            Me.Controls.Add(Me.humanPlayerHandPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "RoundForm"
            CType(Me.BonusTIlePicture0, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BonusTIlePicture1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BonusTIlePicture2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.riichiImageHuman, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.riichiImageCOM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BonusTIlePicture3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BonusTIlePicture4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BonusTIlePicture5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.openRuleFormButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RiichiButton, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents humanPlayerHandPanel As HorizontalHandPanel
        Friend WithEvents endRoundButton As Button
        Friend WithEvents allTilesOpenField As CheckBox
        Friend WithEvents comPlayerHandPanel As HorizontalHandPanel
        Friend WithEvents restDrawCountField As Label
        Friend WithEvents comPlayerDiscardedPilePanel As HorizontalDiscardedPilePanel
        Friend WithEvents humanPlayerDiscardedPilePanel As HorizontalDiscardedPilePanel
        Friend WithEvents horizontalRevealedHandPanel0 As HorizontalRevealedHandPanel
        Friend WithEvents horizontalRevealedHandPanel1 As HorizontalRevealedHandPanel
        Friend WithEvents horizontalRevealedHandPanel2 As HorizontalRevealedHandPanel
        Friend WithEvents horizontalRevealedHandPanel3 As HorizontalRevealedHandPanel
        Friend WithEvents comPointField As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents humanPointField As Label
        Friend WithEvents OpponentLabel As Label
        Friend WithEvents restRoundsField As Label
        Friend WithEvents RiichiAutoDrawTimer As Timer
        Friend WithEvents TileDetailInfoPanel1 As TileDetailInfoPanel
        Friend WithEvents BonusTIlePicture0 As PictureBox
        Friend WithEvents BonusTIlePicture1 As PictureBox
        Friend WithEvents BonusTIlePicture2 As PictureBox
        Friend WithEvents Label7 As Label
        Friend WithEvents Label9 As Label
        Friend WithEvents Label10 As Label
        Friend WithEvents PictureBox1 As PictureBox
        Friend WithEvents Label1 As Label
        Friend WithEvents Label11 As Label
        Friend WithEvents Label12 As Label
        Friend WithEvents riichiImageHuman As PictureBox
        Friend WithEvents riichiImageCOM As PictureBox
        Friend WithEvents RiichiButton As RichButton
        Friend WithEvents openRuleFormButton As RichButton
        Friend WithEvents TestShantenButton1 As Button
        Friend WithEvents BonusTIlePicture3 As PictureBox
        Friend WithEvents BonusTIlePicture4 As PictureBox
        Friend WithEvents BonusTIlePicture5 As PictureBox
    End Class
End Namespace