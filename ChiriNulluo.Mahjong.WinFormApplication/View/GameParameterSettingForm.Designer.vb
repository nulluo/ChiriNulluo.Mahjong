Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GameParameterSettingForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameParameterSettingForm))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.moveDownButton = New System.Windows.Forms.Button()
            Me.moveUpButton = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.wallPileGrid = New System.Windows.Forms.DataGridView()
            Me.wallIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallSeriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.humanHandGrid = New System.Windows.Forms.DataGridView()
            Me.HumanHandIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.HumanHandNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.HumanHandSeriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.HumanHandNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.comHandGrid = New System.Windows.Forms.DataGridView()
            Me.COMHandIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.COMHandNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.COMHandSeriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.COMHandNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.moveToWallFromHumanHandButton = New System.Windows.Forms.Button()
            Me.moveToWallFromCOMHandButton = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.moveToCOMHandFromWallButton = New System.Windows.Forms.Button()
            Me.moveToHumanHandFromWallButton = New System.Windows.Forms.Button()
            Me.okButton = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.comStrategyField = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.loadHandPatternButton = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.moveToComHandFromHumanHandButton = New System.Windows.Forms.Button()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.moveToHumanHandFromCOMHandButton = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
            Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
            Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.wallPileGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.humanHandGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.comHandGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.moveDownButton)
            Me.Panel1.Controls.Add(Me.moveUpButton)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.wallPileGrid)
            Me.Panel1.Location = New System.Drawing.Point(12, 12)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(245, 487)
            Me.Panel1.TabIndex = 0
            '
            'moveDownButton
            '
            Me.moveDownButton.Location = New System.Drawing.Point(202, 3)
            Me.moveDownButton.Name = "moveDownButton"
            Me.moveDownButton.Size = New System.Drawing.Size(37, 23)
            Me.moveDownButton.TabIndex = 9
            Me.moveDownButton.Text = "↓"
            Me.moveDownButton.UseVisualStyleBackColor = True
            '
            'moveUpButton
            '
            Me.moveUpButton.Location = New System.Drawing.Point(159, 3)
            Me.moveUpButton.Name = "moveUpButton"
            Me.moveUpButton.Size = New System.Drawing.Size(37, 23)
            Me.moveUpButton.TabIndex = 9
            Me.moveUpButton.Text = "↑"
            Me.moveUpButton.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(100, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(53, 12)
            Me.Label7.TabIndex = 8
            Me.Label7.Text = "順序変更"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.Label1.Location = New System.Drawing.Point(3, 11)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(42, 16)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "山牌"
            '
            'wallPileGrid
            '
            Me.wallPileGrid.AllowUserToAddRows = False
            Me.wallPileGrid.AllowUserToDeleteRows = False
            Me.wallPileGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.wallPileGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.wallPileGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wallIDColumn, Me.WallNameColumn, Me.WallSeriesIDColumn, Me.WallNumberColumn})
            Me.wallPileGrid.Location = New System.Drawing.Point(3, 30)
            Me.wallPileGrid.Name = "wallPileGrid"
            Me.wallPileGrid.ReadOnly = True
            Me.wallPileGrid.RowHeadersWidth = 16
            Me.wallPileGrid.RowTemplate.Height = 32
            Me.wallPileGrid.Size = New System.Drawing.Size(242, 454)
            Me.wallPileGrid.TabIndex = 7
            '
            'wallIDColumn
            '
            Me.wallIDColumn.DataPropertyName = "ID"
            Me.wallIDColumn.HeaderText = "ID"
            Me.wallIDColumn.Name = "wallIDColumn"
            Me.wallIDColumn.ReadOnly = True
            Me.wallIDColumn.Width = 41
            '
            'WallNameColumn
            '
            Me.WallNameColumn.DataPropertyName = "Name"
            Me.WallNameColumn.HeaderText = "Name"
            Me.WallNameColumn.Name = "WallNameColumn"
            Me.WallNameColumn.ReadOnly = True
            Me.WallNameColumn.Width = 59
            '
            'WallSeriesIDColumn
            '
            Me.WallSeriesIDColumn.HeaderText = "SeriesID"
            Me.WallSeriesIDColumn.Name = "WallSeriesIDColumn"
            Me.WallSeriesIDColumn.ReadOnly = True
            Me.WallSeriesIDColumn.Width = 73
            '
            'WallNumberColumn
            '
            Me.WallNumberColumn.HeaderText = "Number"
            Me.WallNumberColumn.Name = "WallNumberColumn"
            Me.WallNumberColumn.ReadOnly = True
            Me.WallNumberColumn.Width = 69
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.humanHandGrid)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Location = New System.Drawing.Point(263, 12)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(259, 487)
            Me.Panel2.TabIndex = 0
            '
            'humanHandGrid
            '
            Me.humanHandGrid.AllowUserToAddRows = False
            Me.humanHandGrid.AllowUserToDeleteRows = False
            Me.humanHandGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.humanHandGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.humanHandGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HumanHandIDColumn, Me.HumanHandNameColumn, Me.HumanHandSeriesIDColumn, Me.HumanHandNumberColumn})
            Me.humanHandGrid.Location = New System.Drawing.Point(3, 30)
            Me.humanHandGrid.Name = "humanHandGrid"
            Me.humanHandGrid.ReadOnly = True
            Me.humanHandGrid.RowHeadersWidth = 16
            Me.humanHandGrid.RowTemplate.Height = 21
            Me.humanHandGrid.Size = New System.Drawing.Size(253, 454)
            Me.humanHandGrid.TabIndex = 9
            '
            'HumanHandIDColumn
            '
            Me.HumanHandIDColumn.DataPropertyName = "ID"
            Me.HumanHandIDColumn.HeaderText = "ID"
            Me.HumanHandIDColumn.Name = "HumanHandIDColumn"
            Me.HumanHandIDColumn.ReadOnly = True
            Me.HumanHandIDColumn.Width = 41
            '
            'HumanHandNameColumn
            '
            Me.HumanHandNameColumn.DataPropertyName = "Name"
            Me.HumanHandNameColumn.HeaderText = "Name"
            Me.HumanHandNameColumn.Name = "HumanHandNameColumn"
            Me.HumanHandNameColumn.ReadOnly = True
            Me.HumanHandNameColumn.Width = 59
            '
            'HumanHandSeriesIDColumn
            '
            Me.HumanHandSeriesIDColumn.HeaderText = "SeriesID"
            Me.HumanHandSeriesIDColumn.Name = "HumanHandSeriesIDColumn"
            Me.HumanHandSeriesIDColumn.ReadOnly = True
            Me.HumanHandSeriesIDColumn.Width = 73
            '
            'HumanHandNumberColumn
            '
            Me.HumanHandNumberColumn.HeaderText = "Number"
            Me.HumanHandNumberColumn.Name = "HumanHandNumberColumn"
            Me.HumanHandNumberColumn.ReadOnly = True
            Me.HumanHandNumberColumn.Width = 69
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.Label2.Location = New System.Drawing.Point(3, 11)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(99, 16)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "HUMAN配牌"
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.comHandGrid)
            Me.Panel3.Controls.Add(Me.Label3)
            Me.Panel3.Location = New System.Drawing.Point(528, 12)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(238, 487)
            Me.Panel3.TabIndex = 0
            '
            'comHandGrid
            '
            Me.comHandGrid.AllowUserToAddRows = False
            Me.comHandGrid.AllowUserToDeleteRows = False
            Me.comHandGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.comHandGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.comHandGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COMHandIDColumn, Me.COMHandNameColumn, Me.COMHandSeriesIDColumn, Me.COMHandNumberColumn})
            Me.comHandGrid.Location = New System.Drawing.Point(3, 30)
            Me.comHandGrid.Name = "comHandGrid"
            Me.comHandGrid.ReadOnly = True
            Me.comHandGrid.RowHeadersWidth = 16
            Me.comHandGrid.RowTemplate.Height = 21
            Me.comHandGrid.Size = New System.Drawing.Size(232, 454)
            Me.comHandGrid.TabIndex = 9
            '
            'COMHandIDColumn
            '
            Me.COMHandIDColumn.DataPropertyName = "ID"
            Me.COMHandIDColumn.HeaderText = "ID"
            Me.COMHandIDColumn.Name = "COMHandIDColumn"
            Me.COMHandIDColumn.ReadOnly = True
            Me.COMHandIDColumn.Width = 41
            '
            'COMHandNameColumn
            '
            Me.COMHandNameColumn.DataPropertyName = "Name"
            Me.COMHandNameColumn.HeaderText = "Name"
            Me.COMHandNameColumn.Name = "COMHandNameColumn"
            Me.COMHandNameColumn.ReadOnly = True
            Me.COMHandNameColumn.Width = 59
            '
            'COMHandSeriesIDColumn
            '
            Me.COMHandSeriesIDColumn.HeaderText = "SeriesID"
            Me.COMHandSeriesIDColumn.Name = "COMHandSeriesIDColumn"
            Me.COMHandSeriesIDColumn.ReadOnly = True
            Me.COMHandSeriesIDColumn.Width = 73
            '
            'COMHandNumberColumn
            '
            Me.COMHandNumberColumn.HeaderText = "Number"
            Me.COMHandNumberColumn.Name = "COMHandNumberColumn"
            Me.COMHandNumberColumn.ReadOnly = True
            Me.COMHandNumberColumn.Width = 69
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.Label3.Location = New System.Drawing.Point(3, 11)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(79, 16)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "COM配牌"
            '
            'moveToWallFromHumanHandButton
            '
            Me.moveToWallFromHumanHandButton.Location = New System.Drawing.Point(6, 35)
            Me.moveToWallFromHumanHandButton.Name = "moveToWallFromHumanHandButton"
            Me.moveToWallFromHumanHandButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToWallFromHumanHandButton.TabIndex = 1
            Me.moveToWallFromHumanHandButton.Text = "山牌"
            Me.moveToWallFromHumanHandButton.UseVisualStyleBackColor = True
            '
            'moveToWallFromCOMHandButton
            '
            Me.moveToWallFromCOMHandButton.Location = New System.Drawing.Point(6, 33)
            Me.moveToWallFromCOMHandButton.Name = "moveToWallFromCOMHandButton"
            Me.moveToWallFromCOMHandButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToWallFromCOMHandButton.TabIndex = 1
            Me.moveToWallFromCOMHandButton.Text = "山牌"
            Me.moveToWallFromCOMHandButton.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.moveToCOMHandFromWallButton)
            Me.GroupBox1.Controls.Add(Me.moveToHumanHandFromWallButton)
            Me.GroupBox1.Location = New System.Drawing.Point(15, 505)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(242, 68)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "牌の移動先"
            '
            'moveToCOMHandFromWallButton
            '
            Me.moveToCOMHandFromWallButton.Location = New System.Drawing.Point(146, 35)
            Me.moveToCOMHandFromWallButton.Name = "moveToCOMHandFromWallButton"
            Me.moveToCOMHandFromWallButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToCOMHandFromWallButton.TabIndex = 2
            Me.moveToCOMHandFromWallButton.Text = "COM手牌"
            Me.moveToCOMHandFromWallButton.UseVisualStyleBackColor = True
            '
            'moveToHumanHandFromWallButton
            '
            Me.moveToHumanHandFromWallButton.Location = New System.Drawing.Point(6, 33)
            Me.moveToHumanHandFromWallButton.Name = "moveToHumanHandFromWallButton"
            Me.moveToHumanHandFromWallButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToHumanHandFromWallButton.TabIndex = 3
            Me.moveToHumanHandFromWallButton.Text = "HUMAN手牌"
            Me.moveToHumanHandFromWallButton.UseVisualStyleBackColor = True
            '
            'okButton
            '
            Me.okButton.Location = New System.Drawing.Point(795, 522)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(98, 49)
            Me.okButton.TabIndex = 3
            Me.okButton.Text = "確定"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(786, 242)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(101, 12)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "COMの戦略パターン"
            '
            'comStrategyField
            '
            Me.comStrategyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.comStrategyField.FormattingEnabled = True
            Me.comStrategyField.Items.AddRange(New Object() {"自摸切り", "テンパイ状態から上がりを目指せる", "イーシャンテン状態から上がりを目指せる"})
            Me.comStrategyField.Location = New System.Drawing.Point(795, 271)
            Me.comStrategyField.Name = "comStrategyField"
            Me.comStrategyField.Size = New System.Drawing.Size(286, 20)
            Me.comStrategyField.TabIndex = 5
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.ForeColor = System.Drawing.Color.Red
            Me.Label5.Location = New System.Drawing.Point(793, 303)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(215, 72)
            Me.Label5.TabIndex = 17
            Me.Label5.Text = "※↑まだ実装されていません" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "※AIの思考能力が貧弱なため" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　イーシャンテンから上がりを目指すパターンで" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　実行するとかなり動作が重くなります" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　(改善" &
    "予定)"
            '
            'loadHandPatternButton
            '
            Me.loadHandPatternButton.Location = New System.Drawing.Point(795, 414)
            Me.loadHandPatternButton.Name = "loadHandPatternButton"
            Me.loadHandPatternButton.Size = New System.Drawing.Size(250, 46)
            Me.loadHandPatternButton.TabIndex = 18
            Me.loadHandPatternButton.Text = "手牌パターン読込"
            Me.loadHandPatternButton.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.moveToComHandFromHumanHandButton)
            Me.GroupBox2.Controls.Add(Me.moveToWallFromHumanHandButton)
            Me.GroupBox2.Location = New System.Drawing.Point(266, 505)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(242, 68)
            Me.GroupBox2.TabIndex = 19
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "牌の移動先"
            '
            'moveToComHandFromHumanHandButton
            '
            Me.moveToComHandFromHumanHandButton.Location = New System.Drawing.Point(146, 35)
            Me.moveToComHandFromHumanHandButton.Name = "moveToComHandFromHumanHandButton"
            Me.moveToComHandFromHumanHandButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToComHandFromHumanHandButton.TabIndex = 3
            Me.moveToComHandFromHumanHandButton.Text = "COM手牌"
            Me.moveToComHandFromHumanHandButton.UseVisualStyleBackColor = True
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.moveToHumanHandFromCOMHandButton)
            Me.GroupBox3.Controls.Add(Me.moveToWallFromCOMHandButton)
            Me.GroupBox3.Location = New System.Drawing.Point(528, 505)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(235, 68)
            Me.GroupBox3.TabIndex = 19
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "牌の移動先"
            '
            'moveToHumanHandFromCOMHandButton
            '
            Me.moveToHumanHandFromCOMHandButton.Location = New System.Drawing.Point(139, 33)
            Me.moveToHumanHandFromCOMHandButton.Name = "moveToHumanHandFromCOMHandButton"
            Me.moveToHumanHandFromCOMHandButton.Size = New System.Drawing.Size(90, 31)
            Me.moveToHumanHandFromCOMHandButton.TabIndex = 4
            Me.moveToHumanHandFromCOMHandButton.Text = "HUMAN手牌"
            Me.moveToHumanHandFromCOMHandButton.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.ForeColor = System.Drawing.Color.Red
            Me.Label6.Location = New System.Drawing.Point(772, 53)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(268, 36)
            Me.Label6.TabIndex = 17
            Me.Label6.Text = "←行ヘッダをクリックすると行を選択できます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　行を選択した状態で下の「牌の移動先」ボタンを押すと" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　牌を移動させることができます"
            '
            'DataGridViewImageColumn1
            '
            Me.DataGridViewImageColumn1.HeaderText = "Image"
            Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
            Me.DataGridViewImageColumn1.ReadOnly = True
            Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewImageColumn1.Width = 60
            '
            'DataGridViewImageColumn2
            '
            Me.DataGridViewImageColumn2.HeaderText = "Image"
            Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
            Me.DataGridViewImageColumn2.ReadOnly = True
            Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewImageColumn2.Width = 60
            '
            'DataGridViewImageColumn3
            '
            Me.DataGridViewImageColumn3.HeaderText = "Image"
            Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
            Me.DataGridViewImageColumn3.ReadOnly = True
            Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewImageColumn3.Width = 60
            '
            'GameParameterSettingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1362, 579)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.loadHandPatternButton)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.comStrategyField)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.okButton)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GameParameterSettingForm"
            Me.Text = "GameParameterSettingForm"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.wallPileGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.humanHandGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.comHandGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents Label1 As Label
        Friend WithEvents wallPileGrid As DataGridView
        Friend WithEvents Panel2 As Panel
        Friend WithEvents Label2 As Label
        Friend WithEvents Panel3 As Panel
        Friend WithEvents Label3 As Label
        Friend WithEvents moveToWallFromHumanHandButton As Button
        Friend WithEvents moveToWallFromCOMHandButton As Button
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents moveToCOMHandFromWallButton As Button
        Friend WithEvents moveToHumanHandFromWallButton As Button
        Friend WithEvents okButton As Button
        Friend WithEvents Label4 As Label
        Friend WithEvents comStrategyField As ComboBox
        Friend WithEvents Label5 As Label
        Friend WithEvents loadHandPatternButton As Button
        Friend WithEvents humanHandGrid As DataGridView
        Friend WithEvents comHandGrid As DataGridView
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents moveToComHandFromHumanHandButton As Button
        Friend WithEvents GroupBox3 As GroupBox
        Friend WithEvents moveToHumanHandFromCOMHandButton As Button
        Friend WithEvents Label6 As Label
        Friend WithEvents moveDownButton As Button
        Friend WithEvents moveUpButton As Button
        Friend WithEvents Label7 As Label
        Friend WithEvents HumanHandIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents HumanHandNameColumn As DataGridViewTextBoxColumn
        Friend WithEvents HumanHandSeriesIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents HumanHandNumberColumn As DataGridViewTextBoxColumn
        Friend WithEvents COMHandIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents COMHandNameColumn As DataGridViewTextBoxColumn
        Friend WithEvents COMHandSeriesIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents COMHandNumberColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
        Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
        Friend WithEvents DataGridViewImageColumn3 As DataGridViewImageColumn
        Friend WithEvents wallIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents WallNameColumn As DataGridViewTextBoxColumn
        Friend WithEvents WallSeriesIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents WallNumberColumn As DataGridViewTextBoxColumn
    End Class

End Namespace