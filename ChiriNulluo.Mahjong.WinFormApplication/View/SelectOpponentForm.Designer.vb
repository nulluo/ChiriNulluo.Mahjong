Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SelectOpponentForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectOpponentForm))
            Me.LabelEas = New System.Windows.Forms.Label()
            Me.LabelRiko = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.ButtonEas = New System.Windows.Forms.Button()
            Me.ButtonRegina = New System.Windows.Forms.Button()
            Me.ButtonRuru = New System.Windows.Forms.Button()
            Me.LabelRegina = New System.Windows.Forms.Label()
            Me.LabelRuru = New System.Windows.Forms.Label()
            Me.ButtonRiko = New System.Windows.Forms.Button()
            Me.ButtonMirai = New System.Windows.Forms.Button()
            Me.ButtonKotoha = New System.Windows.Forms.Button()
            Me.LabelMirai = New System.Windows.Forms.Label()
            Me.LabelKotoha = New System.Windows.Forms.Label()
            Me.ManualModeField = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'LabelEas
            '
            Me.LabelEas.AutoSize = True
            Me.LabelEas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelEas.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
            Me.LabelEas.ForeColor = System.Drawing.Color.Snow
            Me.LabelEas.Location = New System.Drawing.Point(114, 106)
            Me.LabelEas.Name = "LabelEas"
            Me.LabelEas.Size = New System.Drawing.Size(99, 20)
            Me.LabelEas.TabIndex = 2
            Me.LabelEas.Text = "イース(普通)"
            Me.LabelEas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'LabelRiko
            '
            Me.LabelRiko.AutoSize = True
            Me.LabelRiko.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelRiko.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
            Me.LabelRiko.ForeColor = System.Drawing.Color.Snow
            Me.LabelRiko.Location = New System.Drawing.Point(6, 232)
            Me.LabelRiko.Name = "LabelRiko"
            Me.LabelRiko.Size = New System.Drawing.Size(99, 25)
            Me.LabelRiko.TabIndex = 2
            Me.LabelRiko.Text = "リコ(弱い)"
            Me.LabelRiko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonEas, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonRegina, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonRuru, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelEas, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelRegina, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelRuru, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonRiko, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonMirai, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.ButtonKotoha, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelRiko, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelMirai, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelKotoha, 2, 3)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(74, 50)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(329, 260)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'ButtonEas
            '
            Me.ButtonEas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonEas.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Eas01
            Me.ButtonEas.Location = New System.Drawing.Point(6, 6)
            Me.ButtonEas.Name = "ButtonEas"
            Me.ButtonEas.Size = New System.Drawing.Size(99, 94)
            Me.ButtonEas.TabIndex = 2
            Me.ButtonEas.UseVisualStyleBackColor = True
            '
            'ButtonRegina
            '
            Me.ButtonRegina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonRegina.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Regina01
            Me.ButtonRegina.Location = New System.Drawing.Point(114, 6)
            Me.ButtonRegina.Name = "ButtonRegina"
            Me.ButtonRegina.Size = New System.Drawing.Size(99, 94)
            Me.ButtonRegina.TabIndex = 17
            Me.ButtonRegina.UseVisualStyleBackColor = True
            '
            'ButtonRuru
            '
            Me.ButtonRuru.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonRuru.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Ruru01
            Me.ButtonRuru.Location = New System.Drawing.Point(6, 109)
            Me.ButtonRuru.Name = "ButtonRuru"
            Me.ButtonRuru.Size = New System.Drawing.Size(99, 14)
            Me.ButtonRuru.TabIndex = 33
            Me.ButtonRuru.UseVisualStyleBackColor = True
            '
            'LabelRegina
            '
            Me.LabelRegina.AutoSize = True
            Me.LabelRegina.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelRegina.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.LabelRegina.ForeColor = System.Drawing.Color.Snow
            Me.LabelRegina.Location = New System.Drawing.Point(222, 106)
            Me.LabelRegina.Name = "LabelRegina"
            Me.LabelRegina.Size = New System.Drawing.Size(101, 20)
            Me.LabelRegina.TabIndex = 1
            Me.LabelRegina.Text = "レジーナ(強い)"
            Me.LabelRegina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'LabelRuru
            '
            Me.LabelRuru.AutoSize = True
            Me.LabelRuru.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelRuru.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!)
            Me.LabelRuru.ForeColor = System.Drawing.Color.Snow
            Me.LabelRuru.Location = New System.Drawing.Point(222, 3)
            Me.LabelRuru.Name = "LabelRuru"
            Me.LabelRuru.Size = New System.Drawing.Size(101, 100)
            Me.LabelRuru.TabIndex = 21
            Me.LabelRuru.Text = "ルールー(強い)"
            Me.LabelRuru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ButtonRiko
            '
            Me.ButtonRiko.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonRiko.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Riko01
            Me.ButtonRiko.Location = New System.Drawing.Point(6, 132)
            Me.ButtonRiko.Name = "ButtonRiko"
            Me.ButtonRiko.Size = New System.Drawing.Size(99, 94)
            Me.ButtonRiko.TabIndex = 28
            Me.ButtonRiko.UseVisualStyleBackColor = True
            '
            'ButtonMirai
            '
            Me.ButtonMirai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ButtonMirai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonMirai.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Mirai01
            Me.ButtonMirai.Location = New System.Drawing.Point(114, 132)
            Me.ButtonMirai.Name = "ButtonMirai"
            Me.ButtonMirai.Size = New System.Drawing.Size(99, 94)
            Me.ButtonMirai.TabIndex = 31
            Me.ButtonMirai.UseVisualStyleBackColor = True
            '
            'ButtonKotoha
            '
            Me.ButtonKotoha.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ButtonKotoha.Image = CType(resources.GetObject("ButtonKotoha.Image"), System.Drawing.Image)
            Me.ButtonKotoha.Location = New System.Drawing.Point(222, 132)
            Me.ButtonKotoha.Name = "ButtonKotoha"
            Me.ButtonKotoha.Size = New System.Drawing.Size(101, 94)
            Me.ButtonKotoha.TabIndex = 30
            Me.ButtonKotoha.UseVisualStyleBackColor = True
            '
            'LabelMirai
            '
            Me.LabelMirai.AutoSize = True
            Me.LabelMirai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelMirai.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
            Me.LabelMirai.ForeColor = System.Drawing.Color.Snow
            Me.LabelMirai.Location = New System.Drawing.Point(114, 232)
            Me.LabelMirai.Name = "LabelMirai"
            Me.LabelMirai.Size = New System.Drawing.Size(99, 25)
            Me.LabelMirai.TabIndex = 32
            Me.LabelMirai.Text = "みらい(普通)"
            Me.LabelMirai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'LabelKotoha
            '
            Me.LabelKotoha.AutoSize = True
            Me.LabelKotoha.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LabelKotoha.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
            Me.LabelKotoha.ForeColor = System.Drawing.Color.Snow
            Me.LabelKotoha.Location = New System.Drawing.Point(222, 232)
            Me.LabelKotoha.Name = "LabelKotoha"
            Me.LabelKotoha.Size = New System.Drawing.Size(101, 25)
            Me.LabelKotoha.TabIndex = 29
            Me.LabelKotoha.Text = "ことは(強い)"
            Me.LabelKotoha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ManualModeField
            '
            Me.ManualModeField.AutoSize = True
            Me.ManualModeField.Location = New System.Drawing.Point(302, 316)
            Me.ManualModeField.Name = "ManualModeField"
            Me.ManualModeField.Size = New System.Drawing.Size(167, 16)
            Me.ManualModeField.TabIndex = 1
            Me.ManualModeField.Text = "Set all parameters manually"
            Me.ManualModeField.UseVisualStyleBackColor = True
            Me.ManualModeField.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.0!)
            Me.Label1.ForeColor = System.Drawing.Color.Snow
            Me.Label1.Location = New System.Drawing.Point(168, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(129, 20)
            Me.Label1.TabIndex = 22
            Me.Label1.Text = "対戦相手選択"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SelectOpponentForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.GrayText
            Me.ClientSize = New System.Drawing.Size(470, 333)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ManualModeField)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "SelectOpponentForm"
            Me.Text = "対戦相手選択"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents LabelRiko As Label
        Friend WithEvents LabelEas As Label
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents LabelRegina As Label
        Friend WithEvents ButtonRegina As Button
        Friend WithEvents ManualModeField As CheckBox
        Public WithEvents ButtonEas As Button
        Friend WithEvents ButtonRiko As Button
        Friend WithEvents LabelKotoha As Label
        Friend WithEvents ButtonKotoha As Button
        Friend WithEvents ButtonMirai As Button
        Friend WithEvents LabelMirai As Label
        Friend WithEvents LabelRuru As Label
        Friend WithEvents ButtonRuru As Button
        Friend WithEvents Label1 As Label
    End Class
End Namespace