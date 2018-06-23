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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PointForm))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NextRoundButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.YakuNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YakuPointColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TwitterShareButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'NextRoundButton
        '
        resources.ApplyResources(Me.NextRoundButton, "NextRoundButton")
        Me.NextRoundButton.Name = "NextRoundButton"
        Me.NextRoundButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.YakuNameColumn, Me.YakuPointColumn})
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridView1.RowTemplate.Height = 30
        '
        'YakuNameColumn
        '
        Me.YakuNameColumn.DataPropertyName = "YakuName"
        resources.ApplyResources(Me.YakuNameColumn, "YakuNameColumn")
        Me.YakuNameColumn.Name = "YakuNameColumn"
        Me.YakuNameColumn.ReadOnly = True
        '
        'YakuPointColumn
        '
        Me.YakuPointColumn.DataPropertyName = "Point"
        resources.ApplyResources(Me.YakuPointColumn, "YakuPointColumn")
        Me.YakuPointColumn.Name = "YakuPointColumn"
        Me.YakuPointColumn.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'pointField
        '
        resources.ApplyResources(Me.pointField, "pointField")
        Me.pointField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pointField.ForeColor = System.Drawing.Color.Red
        Me.pointField.Name = "pointField"
        '
        'ManualModeField
        '
        resources.ApplyResources(Me.ManualModeField, "ManualModeField")
        Me.ManualModeField.Name = "ManualModeField"
        Me.ManualModeField.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.ChiriNulluo.Mahjong.WinFormApplication.My.Resources.Resources.SystemWindow02
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'playerNameField
        '
        resources.ApplyResources(Me.playerNameField, "playerNameField")
        Me.playerNameField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.playerNameField.ForeColor = System.Drawing.Color.Red
        Me.playerNameField.Name = "playerNameField"
        '
        'HorizontalRevealedHandPanel3
        '
        resources.ApplyResources(Me.HorizontalRevealedHandPanel3, "HorizontalRevealedHandPanel3")
        Me.HorizontalRevealedHandPanel3.DataSource = Nothing
        Me.HorizontalRevealedHandPanel3.Name = "HorizontalRevealedHandPanel3"
        '
        'HorizontalRevealedHandPanel2
        '
        resources.ApplyResources(Me.HorizontalRevealedHandPanel2, "HorizontalRevealedHandPanel2")
        Me.HorizontalRevealedHandPanel2.DataSource = Nothing
        Me.HorizontalRevealedHandPanel2.Name = "HorizontalRevealedHandPanel2"
        '
        'HorizontalRevealedHandPanel1
        '
        resources.ApplyResources(Me.HorizontalRevealedHandPanel1, "HorizontalRevealedHandPanel1")
        Me.HorizontalRevealedHandPanel1.DataSource = Nothing
        Me.HorizontalRevealedHandPanel1.Name = "HorizontalRevealedHandPanel1"
        '
        'HorizontalRevealedHandPanel0
        '
        resources.ApplyResources(Me.HorizontalRevealedHandPanel0, "HorizontalRevealedHandPanel0")
        Me.HorizontalRevealedHandPanel0.DataSource = Nothing
        Me.HorizontalRevealedHandPanel0.Name = "HorizontalRevealedHandPanel0"
        '
        'HorizontalHandPanel1
        '
        resources.ApplyResources(Me.HorizontalHandPanel1, "HorizontalHandPanel1")
        Me.HorizontalHandPanel1.DataSource = Nothing
        Me.HorizontalHandPanel1.DisplayStyle = ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle.ShownToHumanStood
        Me.HorizontalHandPanel1.Name = "HorizontalHandPanel1"
        '
        'TwitterShareButton
        '
        resources.ApplyResources(Me.TwitterShareButton, "TwitterShareButton")
        Me.TwitterShareButton.Name = "TwitterShareButton"
        Me.TwitterShareButton.UseVisualStyleBackColor = True
        '
        'PointForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Controls.Add(Me.TwitterShareButton)
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
    Friend WithEvents TwitterShareButton As Button
End Class
