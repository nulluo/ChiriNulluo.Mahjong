<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WallPIleForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WallPileDataGridView = New System.Windows.Forms.DataGridView()
        Me.seriesIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.WallPileDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WallPileDataGridView
        '
        Me.WallPileDataGridView.AllowUserToAddRows = False
        Me.WallPileDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Red
        Me.WallPileDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.WallPileDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WallPileDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.WallPileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WallPileDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seriesIDColumn, Me.numberColumn, Me.nameColumn, Me.idColumn})
        Me.WallPileDataGridView.Location = New System.Drawing.Point(13, 10)
        Me.WallPileDataGridView.Name = "WallPileDataGridView"
        Me.WallPileDataGridView.ReadOnly = True
        Me.WallPileDataGridView.RowHeadersVisible = False
        Me.WallPileDataGridView.RowTemplate.Height = 80
        Me.WallPileDataGridView.ShowCellToolTips = False
        Me.WallPileDataGridView.Size = New System.Drawing.Size(94, 403)
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
        'WallPIleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.WallPileDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
End Class
