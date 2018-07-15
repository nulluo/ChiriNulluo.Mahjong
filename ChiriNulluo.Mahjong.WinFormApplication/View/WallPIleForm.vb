Namespace View
    Public Class WallPIleForm
        Private Property WallTileImageColumn As New DataGridViewTileImageColumn

        Public Sub New()

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            '山牌グリッドの初期化
            Me.WallPileDataGridView.AutoGenerateColumns = False
            Me.WallTileImageColumn.DataPropertyName = "ID"
            Me.WallTileImageColumn.HeaderText = My.Resources.TileToNextDraw
            Me.WallPileDataGridView.Columns.Insert(0, Me.WallTileImageColumn)

            Me.WallPileDataGridView.DataSource = MatchManagerController.GetInstance.MatchManager.RoundManager.WallPile


        End Sub

        Private Sub WallPIleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            With Me.WallPileDataGridView
                .CurrentCell = .Item(0, .Rows.Count - 1)
            End With
        End Sub
    End Class
End Namespace