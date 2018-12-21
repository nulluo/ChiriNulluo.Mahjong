Imports ChiriNulluo.Mahjong.WinFormApplication

Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReplayForm
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
            Me.endReplayButton = New System.Windows.Forms.Button()
            Me.forwardButton = New System.Windows.Forms.Button()
            Me.backwardButton = New System.Windows.Forms.Button()
            Me.fastForwardButton = New System.Windows.Forms.Button()
            Me.fastBackwardButton = New System.Windows.Forms.Button()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.MatchIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.LogNoInMatchColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ProcessTypeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ProcessIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PlayerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RemarkColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.JoinedParametersColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'endReplayButton
            '
            Me.endReplayButton.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
            Me.endReplayButton.Location = New System.Drawing.Point(346, 19)
            Me.endReplayButton.Name = "endReplayButton"
            Me.endReplayButton.Size = New System.Drawing.Size(107, 55)
            Me.endReplayButton.TabIndex = 16
            Me.endReplayButton.Text = "リプレイ終了"
            Me.endReplayButton.UseVisualStyleBackColor = True
            '
            'forwardButton
            '
            Me.forwardButton.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.forwardButton.Location = New System.Drawing.Point(193, 19)
            Me.forwardButton.Name = "forwardButton"
            Me.forwardButton.Size = New System.Drawing.Size(65, 55)
            Me.forwardButton.TabIndex = 14
            Me.forwardButton.Text = "|>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(&N)"
            Me.forwardButton.UseVisualStyleBackColor = True
            '
            'backwardButton
            '
            Me.backwardButton.Enabled = False
            Me.backwardButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.backwardButton.Location = New System.Drawing.Point(103, 19)
            Me.backwardButton.Name = "backwardButton"
            Me.backwardButton.Size = New System.Drawing.Size(65, 55)
            Me.backwardButton.TabIndex = 15
            Me.backwardButton.Text = "<|"
            Me.backwardButton.UseVisualStyleBackColor = True
            '
            'fastForwardButton
            '
            Me.fastForwardButton.Enabled = False
            Me.fastForwardButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.fastForwardButton.Location = New System.Drawing.Point(275, 19)
            Me.fastForwardButton.Name = "fastForwardButton"
            Me.fastForwardButton.Size = New System.Drawing.Size(65, 55)
            Me.fastForwardButton.TabIndex = 17
            Me.fastForwardButton.Text = "|>|>"
            Me.fastForwardButton.UseVisualStyleBackColor = True
            '
            'fastBackwardButton
            '
            Me.fastBackwardButton.Enabled = False
            Me.fastBackwardButton.Font = New System.Drawing.Font("MS UI Gothic", 19.0!)
            Me.fastBackwardButton.Location = New System.Drawing.Point(22, 19)
            Me.fastBackwardButton.Name = "fastBackwardButton"
            Me.fastBackwardButton.Size = New System.Drawing.Size(65, 55)
            Me.fastBackwardButton.TabIndex = 18
            Me.fastBackwardButton.Text = "<|<|"
            Me.fastBackwardButton.UseVisualStyleBackColor = True
            '
            'DataGridView1
            '
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False
            Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MatchIDColumn, Me.LogNoInMatchColumn, Me.ProcessTypeIDColumn, Me.ProcessIDColumn, Me.PlayerColumn, Me.RemarkColumn, Me.JoinedParametersColumn})
            Me.DataGridView1.Location = New System.Drawing.Point(12, 80)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.RowTemplate.Height = 21
            Me.DataGridView1.Size = New System.Drawing.Size(849, 128)
            Me.DataGridView1.TabIndex = 20
            '
            'MatchIDColumn
            '
            Me.MatchIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.MatchIDColumn.DataPropertyName = "MatchID"
            Me.MatchIDColumn.FillWeight = 69.37252!
            Me.MatchIDColumn.HeaderText = "Match"
            Me.MatchIDColumn.Name = "MatchIDColumn"
            Me.MatchIDColumn.ReadOnly = True
            Me.MatchIDColumn.Width = 61
            '
            'LogNoInMatchColumn
            '
            Me.LogNoInMatchColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.LogNoInMatchColumn.DataPropertyName = "LogNoInMatch"
            Me.LogNoInMatchColumn.FillWeight = 65.9039!
            Me.LogNoInMatchColumn.HeaderText = "LogNoInMatch"
            Me.LogNoInMatchColumn.Name = "LogNoInMatchColumn"
            Me.LogNoInMatchColumn.ReadOnly = True
            Me.LogNoInMatchColumn.Width = 102
            '
            'ProcessTypeIDColumn
            '
            Me.ProcessTypeIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ProcessTypeIDColumn.DataPropertyName = "ProcessTypeID"
            Me.ProcessTypeIDColumn.HeaderText = "ProcessType"
            Me.ProcessTypeIDColumn.Name = "ProcessTypeIDColumn"
            Me.ProcessTypeIDColumn.ReadOnly = True
            Me.ProcessTypeIDColumn.Width = 96
            '
            'ProcessIDColumn
            '
            Me.ProcessIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ProcessIDColumn.DataPropertyName = "ProcessID"
            Me.ProcessIDColumn.FillWeight = 69.37252!
            Me.ProcessIDColumn.HeaderText = "Process"
            Me.ProcessIDColumn.Name = "ProcessIDColumn"
            Me.ProcessIDColumn.ReadOnly = True
            Me.ProcessIDColumn.Width = 71
            '
            'PlayerColumn
            '
            Me.PlayerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PlayerColumn.DataPropertyName = "Player"
            Me.PlayerColumn.FillWeight = 69.37252!
            Me.PlayerColumn.HeaderText = "Player"
            Me.PlayerColumn.Name = "PlayerColumn"
            Me.PlayerColumn.ReadOnly = True
            Me.PlayerColumn.Width = 62
            '
            'RemarkColumn
            '
            Me.RemarkColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.RemarkColumn.DataPropertyName = "Remark"
            Me.RemarkColumn.FillWeight = 69.37252!
            Me.RemarkColumn.HeaderText = "Remark"
            Me.RemarkColumn.Name = "RemarkColumn"
            Me.RemarkColumn.ReadOnly = True
            Me.RemarkColumn.Width = 69
            '
            'JoinedParametersColumn
            '
            Me.JoinedParametersColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.JoinedParametersColumn.DataPropertyName = "JoinedParameters"
            Me.JoinedParametersColumn.FillWeight = 69.37252!
            Me.JoinedParametersColumn.HeaderText = "JoinedParameters"
            Me.JoinedParametersColumn.Name = "JoinedParametersColumn"
            Me.JoinedParametersColumn.ReadOnly = True
            '
            'ReplayForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(873, 213)
            Me.Controls.Add(Me.DataGridView1)
            Me.Controls.Add(Me.fastBackwardButton)
            Me.Controls.Add(Me.fastForwardButton)
            Me.Controls.Add(Me.endReplayButton)
            Me.Controls.Add(Me.forwardButton)
            Me.Controls.Add(Me.backwardButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ReplayForm"
            Me.Text = "ReplayForm"
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents endReplayButton As Button
        Friend WithEvents forwardButton As Button
        Friend WithEvents backwardButton As Button
        Friend WithEvents fastForwardButton As Button
        Friend WithEvents fastBackwardButton As Button
        Friend WithEvents DataGridView1 As DataGridView
        Friend WithEvents MatchIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents LogNoInMatchColumn As DataGridViewTextBoxColumn
        Friend WithEvents ProcessTypeIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents ProcessIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents PlayerColumn As DataGridViewTextBoxColumn
        Friend WithEvents RemarkColumn As DataGridViewTextBoxColumn
        Friend WithEvents JoinedParametersColumn As DataGridViewTextBoxColumn
    End Class
End Namespace