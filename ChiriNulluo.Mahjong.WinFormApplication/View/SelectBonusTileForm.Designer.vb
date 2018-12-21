Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SelectBonusTileForm
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
            Me.okButton = New System.Windows.Forms.Button()
            Me.specialTileGrid = New System.Windows.Forms.DataGridView()
            Me.SelectRevealedBonusTileColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.SelectUnrevealedBonusTileColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.bonusTileIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallSeriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WallNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
            Me.ImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
            CType(Me.specialTileGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'okButton
            '
            Me.okButton.Location = New System.Drawing.Point(415, 31)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(66, 35)
            Me.okButton.TabIndex = 0
            Me.okButton.Text = "OK"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'specialTileGrid
            '
            Me.specialTileGrid.AllowUserToAddRows = False
            Me.specialTileGrid.AllowUserToDeleteRows = False
            Me.specialTileGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.specialTileGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.specialTileGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.specialTileGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectRevealedBonusTileColumn, Me.SelectUnrevealedBonusTileColumn, Me.bonusTileIDColumn, Me.ImageColumn, Me.WallNameColumn, Me.WallSeriesIDColumn, Me.WallNumberColumn})
            Me.specialTileGrid.Location = New System.Drawing.Point(12, 31)
            Me.specialTileGrid.Name = "specialTileGrid"
            Me.specialTileGrid.RowHeadersWidth = 16
            Me.specialTileGrid.RowTemplate.Height = 60
            Me.specialTileGrid.Size = New System.Drawing.Size(356, 706)
            Me.specialTileGrid.TabIndex = 8
            '
            'SelectRevealedBonusTileColumn
            '
            Me.SelectRevealedBonusTileColumn.DataPropertyName = "SelectRevealedBonusTileColumn"
            Me.SelectRevealedBonusTileColumn.FalseValue = ""
            Me.SelectRevealedBonusTileColumn.HeaderText = "表ボーナス"
            Me.SelectRevealedBonusTileColumn.IndeterminateValue = ""
            Me.SelectRevealedBonusTileColumn.Name = "SelectRevealedBonusTileColumn"
            Me.SelectRevealedBonusTileColumn.TrueValue = ""
            Me.SelectRevealedBonusTileColumn.Width = 62
            '
            'SelectUnrevealedBonusTileColumn
            '
            Me.SelectUnrevealedBonusTileColumn.DataPropertyName = "SelectUnevealedBonusTileColumn"
            Me.SelectUnrevealedBonusTileColumn.HeaderText = "裏ボーナス"
            Me.SelectUnrevealedBonusTileColumn.Name = "SelectUnrevealedBonusTileColumn"
            Me.SelectUnrevealedBonusTileColumn.Width = 62
            '
            'bonusTileIDColumn
            '
            Me.bonusTileIDColumn.DataPropertyName = "ID"
            Me.bonusTileIDColumn.HeaderText = "ID"
            Me.bonusTileIDColumn.Name = "bonusTileIDColumn"
            Me.bonusTileIDColumn.ReadOnly = True
            Me.bonusTileIDColumn.Width = 41
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
            Me.WallSeriesIDColumn.Visible = False
            Me.WallSeriesIDColumn.Width = 73
            '
            'WallNumberColumn
            '
            Me.WallNumberColumn.HeaderText = "Number"
            Me.WallNumberColumn.Name = "WallNumberColumn"
            Me.WallNumberColumn.ReadOnly = True
            Me.WallNumberColumn.Visible = False
            Me.WallNumberColumn.Width = 69
            '
            'DataGridViewImageColumn1
            '
            Me.DataGridViewImageColumn1.DataPropertyName = "Image"
            Me.DataGridViewImageColumn1.HeaderText = "Image"
            Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
            Me.DataGridViewImageColumn1.ReadOnly = True
            Me.DataGridViewImageColumn1.Width = 41
            '
            'ImageColumn
            '
            Me.ImageColumn.DataPropertyName = "Image"
            Me.ImageColumn.HeaderText = "Image"
            Me.ImageColumn.Name = "ImageColumn"
            Me.ImageColumn.ReadOnly = True
            Me.ImageColumn.Width = 41
            '
            'SelectBonusTileForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(529, 749)
            Me.Controls.Add(Me.specialTileGrid)
            Me.Controls.Add(Me.okButton)
            Me.Name = "SelectBonusTileForm"
            Me.Text = "SelectBonusTileForm"
            CType(Me.specialTileGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents okButton As Button
        Friend WithEvents specialTileGrid As DataGridView
        Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
        Friend WithEvents SelectRevealedBonusTileColumn As DataGridViewCheckBoxColumn
        Friend WithEvents SelectUnrevealedBonusTileColumn As DataGridViewCheckBoxColumn
        Friend WithEvents bonusTileIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents ImageColumn As DataGridViewImageColumn
        Friend WithEvents WallNameColumn As DataGridViewTextBoxColumn
        Friend WithEvents WallSeriesIDColumn As DataGridViewTextBoxColumn
        Friend WithEvents WallNumberColumn As DataGridViewTextBoxColumn
    End Class
End Namespace