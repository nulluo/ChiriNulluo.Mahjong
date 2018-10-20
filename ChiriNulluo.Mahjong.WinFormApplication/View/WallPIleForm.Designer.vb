Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class WallPIleForm
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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.WallPileDataGridView = New System.Windows.Forms.DataGridView()
            Me.seriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.numberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.moveUpButton = New System.Windows.Forms.Button()
            Me.moveDownButton = New System.Windows.Forms.Button()
            CType(Me.WallPileDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'WallPileDataGridView
            '
            Me.WallPileDataGridView.AllowUserToAddRows = False
            Me.WallPileDataGridView.AllowUserToDeleteRows = False
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.Red
            Me.WallPileDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
            Me.WallPileDataGridView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.WallPileDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.WallPileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.WallPileDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seriesIDColumn, Me.numberColumn, Me.nameColumn, Me.idColumn})
            Me.WallPileDataGridView.Location = New System.Drawing.Point(12, 40)
            Me.WallPileDataGridView.Name = "WallPileDataGridView"
            Me.WallPileDataGridView.ReadOnly = True
            Me.WallPileDataGridView.RowHeadersWidth = 24
            Me.WallPileDataGridView.RowTemplate.Height = 80
            Me.WallPileDataGridView.ShowCellToolTips = False
            Me.WallPileDataGridView.Size = New System.Drawing.Size(118, 373)
            Me.WallPileDataGridView.TabIndex = 33
            '
            'seriesIDColumn
            '
            Me.seriesIDColumn.DataPropertyName = "SeriesID"
            Me.seriesIDColumn.HeaderText = "SeriesID"
            Me.seriesIDColumn.Name = "seriesIDColumn"
            Me.seriesIDColumn.ReadOnly = True
            Me.seriesIDColumn.Visible = False
            '
            'numberColumn
            '
            Me.numberColumn.DataPropertyName = "Number"
            Me.numberColumn.HeaderText = "Number"
            Me.numberColumn.Name = "numberColumn"
            Me.numberColumn.ReadOnly = True
            Me.numberColumn.Visible = False
            '
            'nameColumn
            '
            Me.nameColumn.DataPropertyName = "Name"
            Me.nameColumn.HeaderText = "Name"
            Me.nameColumn.Name = "nameColumn"
            Me.nameColumn.ReadOnly = True
            Me.nameColumn.Visible = False
            '
            'idColumn
            '
            Me.idColumn.DataPropertyName = "ID"
            Me.idColumn.HeaderText = "ID"
            Me.idColumn.Name = "idColumn"
            Me.idColumn.ReadOnly = True
            Me.idColumn.Visible = False
            '
            'moveUpButton
            '
            Me.moveUpButton.Location = New System.Drawing.Point(16, 13)
            Me.moveUpButton.Name = "moveUpButton"
            Me.moveUpButton.Size = New System.Drawing.Size(55, 23)
            Me.moveUpButton.TabIndex = 34
            Me.moveUpButton.Text = "↑(&U)"
            Me.moveUpButton.UseVisualStyleBackColor = True
            '
            'moveDownButton
            '
            Me.moveDownButton.Location = New System.Drawing.Point(85, 13)
            Me.moveDownButton.Name = "moveDownButton"
            Me.moveDownButton.Size = New System.Drawing.Size(45, 23)
            Me.moveDownButton.TabIndex = 35
            Me.moveDownButton.Text = "↓(&D)"
            Me.moveDownButton.UseVisualStyleBackColor = True
            '
            'WallPIleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(142, 422)
            Me.ControlBox = False
            Me.Controls.Add(Me.moveDownButton)
            Me.Controls.Add(Me.moveUpButton)
            Me.Controls.Add(Me.WallPileDataGridView)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "WallPIleForm"
            Me.Text = "WallPIleForm"
            CType(Me.WallPileDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents WallPileDataGridView As DataGridView
        Friend WithEvents seriesIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents numberColumn As DataGridViewTextBoxColumn
        Friend WithEvents nameColumn As DataGridViewTextBoxColumn
        Friend WithEvents idColumn As DataGridViewTextBoxColumn
        Friend WithEvents moveUpButton As Button
        Friend WithEvents moveDownButton As Button
    End Class

End Namespace