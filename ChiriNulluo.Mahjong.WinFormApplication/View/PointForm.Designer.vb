<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PointForm
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NextRoundButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pointField = New System.Windows.Forms.Label()
        Me.ManualModeField = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.playerNameField = New System.Windows.Forms.Label()
        Me.HorizontalRevealedHandPanel3 = New ChiriNulluo.Mahjong.WinFormApplication.HorizontalRevealedHandPanel()
        Me.HorizontalRevealedHandPanel2 = New ChiriNulluo.Mahjong.WinFormApplication.HorizontalRevealedHandPanel()
        Me.HorizontalRevealedHandPanel1 = New ChiriNulluo.Mahjong.WinFormApplication.HorizontalRevealedHandPanel()
        Me.HorizontalRevealedHandPanel0 = New ChiriNulluo.Mahjong.WinFormApplication.HorizontalRevealedHandPanel()
        Me.HorizontalHandPanel1 = New ChiriNulluo.Mahjong.WinFormApplication.HorizontalHandPanel()
        Me.YakuNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YakuPointColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "対戦結果表示"
        '
        'NextRoundButton
        '
        Me.NextRoundButton.Location = New System.Drawing.Point(671, 436)
        Me.NextRoundButton.Name = "NextRoundButton"
        Me.NextRoundButton.Size = New System.Drawing.Size(115, 35)
        Me.NextRoundButton.TabIndex = 2
        Me.NextRoundButton.Text = "OK"
        Me.NextRoundButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.YakuNameColumn, Me.YakuPointColumn})
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(15, 150)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(426, 321)
        Me.DataGridView1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(579, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Point"
        '
        'pointField
        '
        Me.pointField.AutoSize = True
        Me.pointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pointField.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Bold)
        Me.pointField.ForeColor = System.Drawing.Color.Red
        Me.pointField.Location = New System.Drawing.Point(619, 240)
        Me.pointField.Name = "pointField"
        Me.pointField.Size = New System.Drawing.Size(92, 23)
        Me.pointField.TabIndex = 7
        Me.pointField.Text = "Label1"
        '
        'ManualModeField
        '
        Me.ManualModeField.AutoSize = True
        Me.ManualModeField.Enabled = False
        Me.ManualModeField.Location = New System.Drawing.Point(619, 391)
        Me.ManualModeField.Name = "ManualModeField"
        Me.ManualModeField.Size = New System.Drawing.Size(167, 16)
        Me.ManualModeField.TabIndex = 8
        Me.ManualModeField.Text = "Set all parameters manually"
        Me.ManualModeField.UseVisualStyleBackColor = True
        Me.ManualModeField.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
        Me.PictureBox1.Location = New System.Drawing.Point(447, 150)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(579, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "PLAYER"
        '
        'playerNameField
        '
        Me.playerNameField.AutoSize = True
        Me.playerNameField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.playerNameField.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Bold)
        Me.playerNameField.ForeColor = System.Drawing.Color.Red
        Me.playerNameField.Location = New System.Drawing.Point(619, 173)
        Me.playerNameField.Name = "playerNameField"
        Me.playerNameField.Size = New System.Drawing.Size(92, 23)
        Me.playerNameField.TabIndex = 7
        Me.playerNameField.Text = "Label1"
        '
        'HorizontalRevealedHandPanel3
        '
        Me.HorizontalRevealedHandPanel3.DataSource = Nothing
        Me.HorizontalRevealedHandPanel3.Location = New System.Drawing.Point(185, 30)
        Me.HorizontalRevealedHandPanel3.Name = "HorizontalRevealedHandPanel3"
        Me.HorizontalRevealedHandPanel3.Size = New System.Drawing.Size(144, 80)
        Me.HorizontalRevealedHandPanel3.TabIndex = 5
        '
        'HorizontalRevealedHandPanel2
        '
        Me.HorizontalRevealedHandPanel2.DataSource = Nothing
        Me.HorizontalRevealedHandPanel2.Location = New System.Drawing.Point(335, 30)
        Me.HorizontalRevealedHandPanel2.Name = "HorizontalRevealedHandPanel2"
        Me.HorizontalRevealedHandPanel2.Size = New System.Drawing.Size(144, 80)
        Me.HorizontalRevealedHandPanel2.TabIndex = 5
        '
        'HorizontalRevealedHandPanel1
        '
        Me.HorizontalRevealedHandPanel1.DataSource = Nothing
        Me.HorizontalRevealedHandPanel1.Location = New System.Drawing.Point(485, 30)
        Me.HorizontalRevealedHandPanel1.Name = "HorizontalRevealedHandPanel1"
        Me.HorizontalRevealedHandPanel1.Size = New System.Drawing.Size(144, 80)
        Me.HorizontalRevealedHandPanel1.TabIndex = 5
        '
        'HorizontalRevealedHandPanel0
        '
        Me.HorizontalRevealedHandPanel0.DataSource = Nothing
        Me.HorizontalRevealedHandPanel0.Location = New System.Drawing.Point(635, 30)
        Me.HorizontalRevealedHandPanel0.Name = "HorizontalRevealedHandPanel0"
        Me.HorizontalRevealedHandPanel0.Size = New System.Drawing.Size(144, 80)
        Me.HorizontalRevealedHandPanel0.TabIndex = 5
        '
        'HorizontalHandPanel1
        '
        Me.HorizontalHandPanel1.DataSource = Nothing
        Me.HorizontalHandPanel1.DisplayStyle = ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle.ShownToHumanStood
        Me.HorizontalHandPanel1.Location = New System.Drawing.Point(3, 30)
        Me.HorizontalHandPanel1.MaximumSize = New System.Drawing.Size(720, 80)
        Me.HorizontalHandPanel1.MinimumSize = New System.Drawing.Size(720, 80)
        Me.HorizontalHandPanel1.Name = "HorizontalHandPanel1"
        Me.HorizontalHandPanel1.Size = New System.Drawing.Size(720, 80)
        Me.HorizontalHandPanel1.TabIndex = 3
        '
        'YakuNameColumn
        '
        Me.YakuNameColumn.DataPropertyName = "YakuName"
        Me.YakuNameColumn.HeaderText = "Yaku Name"
        Me.YakuNameColumn.Name = "YakuNameColumn"
        Me.YakuNameColumn.ReadOnly = True
        Me.YakuNameColumn.Width = 88
        '
        'YakuPointColumn
        '
        Me.YakuPointColumn.DataPropertyName = "Point"
        Me.YakuPointColumn.HeaderText = "Point"
        Me.YakuPointColumn.Name = "YakuPointColumn"
        Me.YakuPointColumn.ReadOnly = True
        Me.YakuPointColumn.Width = 56
        '
        'PointForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ClientSize = New System.Drawing.Size(798, 483)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ManualModeField)
        Me.Controls.Add(Me.playerNameField)
        Me.Controls.Add(Me.pointField)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.NextRoundButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HorizontalRevealedHandPanel3)
        Me.Controls.Add(Me.HorizontalRevealedHandPanel2)
        Me.Controls.Add(Me.HorizontalRevealedHandPanel1)
        Me.Controls.Add(Me.HorizontalRevealedHandPanel0)
        Me.Controls.Add(Me.HorizontalHandPanel1)
        Me.Name = "PointForm"
        Me.Text = "PointDisplayForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents NextRoundButton As Button
    Friend WithEvents HorizontalHandPanel1 As HorizontalHandPanel
    Friend WithEvents HorizontalRevealedHandPanel0 As HorizontalRevealedHandPanel
    Friend WithEvents HorizontalRevealedHandPanel1 As HorizontalRevealedHandPanel
    Friend WithEvents HorizontalRevealedHandPanel2 As HorizontalRevealedHandPanel
    Friend WithEvents HorizontalRevealedHandPanel3 As HorizontalRevealedHandPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pointField As Label
    Friend WithEvents ManualModeField As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents playerNameField As Label
    Friend WithEvents YakuNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents YakuPointColumn As DataGridViewTextBoxColumn
End Class
