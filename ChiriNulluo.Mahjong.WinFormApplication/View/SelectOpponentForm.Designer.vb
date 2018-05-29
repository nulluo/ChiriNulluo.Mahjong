<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectOpponentForm
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
        Me.LabelEas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonRiko = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelRegina = New System.Windows.Forms.Label()
        Me.ButtonEas = New System.Windows.Forms.Button()
        Me.ButtonRegina = New System.Windows.Forms.Button()
        Me.ManualModeField = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelEas
        '
        Me.LabelEas.AutoSize = True
        Me.LabelEas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelEas.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
        Me.LabelEas.ForeColor = System.Drawing.Color.Snow
        Me.LabelEas.Location = New System.Drawing.Point(6, 106)
        Me.LabelEas.Name = "LabelEas"
        Me.LabelEas.Size = New System.Drawing.Size(94, 20)
        Me.LabelEas.TabIndex = 2
        Me.LabelEas.Text = "イース"
        Me.LabelEas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Snow
        Me.Label2.Location = New System.Drawing.Point(212, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 100)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "？"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRiko, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelEas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelRegina, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEas, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRegina, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 260)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Snow
        Me.Label6.Location = New System.Drawing.Point(6, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 25)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "リコ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonRiko
        '
        Me.ButtonRiko.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRiko.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Riko01
        Me.ButtonRiko.Location = New System.Drawing.Point(6, 132)
        Me.ButtonRiko.Name = "ButtonRiko"
        Me.ButtonRiko.Size = New System.Drawing.Size(94, 94)
        Me.ButtonRiko.TabIndex = 28
        Me.ButtonRiko.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Snow
        Me.Label9.Location = New System.Drawing.Point(315, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 100)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "?"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Snow
        Me.Label8.Location = New System.Drawing.Point(212, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 100)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "?"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Snow
        Me.Label7.Location = New System.Drawing.Point(109, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 100)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "?"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Snow
        Me.Label5.Location = New System.Drawing.Point(315, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "?"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Snow
        Me.Label4.Location = New System.Drawing.Point(212, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 20)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "?"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(315, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 100)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Snow
        Me.Label3.Location = New System.Drawing.Point(212, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 100)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "?"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelRegina
        '
        Me.LabelRegina.AutoSize = True
        Me.LabelRegina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRegina.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.0!)
        Me.LabelRegina.ForeColor = System.Drawing.Color.Snow
        Me.LabelRegina.Location = New System.Drawing.Point(109, 106)
        Me.LabelRegina.Name = "LabelRegina"
        Me.LabelRegina.Size = New System.Drawing.Size(94, 20)
        Me.LabelRegina.TabIndex = 1
        Me.LabelRegina.Text = "レジーナ"
        Me.LabelRegina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonEas
        '
        Me.ButtonEas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEas.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Eas01
        Me.ButtonEas.Location = New System.Drawing.Point(6, 6)
        Me.ButtonEas.Name = "ButtonEas"
        Me.ButtonEas.Size = New System.Drawing.Size(94, 94)
        Me.ButtonEas.TabIndex = 2
        Me.ButtonEas.UseVisualStyleBackColor = True
        '
        'ButtonRegina
        '
        Me.ButtonRegina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRegina.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.Face_Regina01
        Me.ButtonRegina.Location = New System.Drawing.Point(109, 6)
        Me.ButtonRegina.Name = "ButtonRegina"
        Me.ButtonRegina.Size = New System.Drawing.Size(94, 94)
        Me.ButtonRegina.TabIndex = 17
        Me.ButtonRegina.UseVisualStyleBackColor = True
        '
        'ManualModeField
        '
        Me.ManualModeField.AutoSize = True
        Me.ManualModeField.Location = New System.Drawing.Point(26, 293)
        Me.ManualModeField.Name = "ManualModeField"
        Me.ManualModeField.Size = New System.Drawing.Size(167, 16)
        Me.ManualModeField.TabIndex = 1
        Me.ManualModeField.Text = "Set all parameters manually"
        Me.ManualModeField.UseVisualStyleBackColor = True
        Me.ManualModeField.Visible = False
        '
        'SelectOpponentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GrayText
        Me.ClientSize = New System.Drawing.Size(435, 333)
        Me.Controls.Add(Me.ManualModeField)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "SelectOpponentForm"
        Me.Text = "対戦相手選択"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents Label2 As Label
    Friend WithEvents LabelEas As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelRegina As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonRegina As Button
    Friend WithEvents ManualModeField As CheckBox
    Public WithEvents ButtonEas As Button
    Friend WithEvents ButtonRiko As Button
    Friend WithEvents Label6 As Label
End Class
