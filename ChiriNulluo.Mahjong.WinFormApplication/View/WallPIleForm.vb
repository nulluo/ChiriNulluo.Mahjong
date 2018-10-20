Imports ChiriNulluo.Mahjong.Core.Tiles

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


        ''' <summary>
        ''' ボタン上下移動ボタンが押下されたときの処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub moveUpDownButton_Click(sender As Object, e As EventArgs) Handles moveUpButton.Click, moveDownButton.Click
            Dim _senderButton As String = DirectCast(sender, Button).Name


            Dim _direction As Integer
            If sender Is Me.moveUpButton Then
                _direction = -1
            Else
                _direction = 1
            End If

            Dim _selectedGridRowIndex As Integer
            With Me.WallPileDataGridView
                If .Rows.Count = 0 Then
                    '牌が0個の場合は抜ける
                    Return
                ElseIf .SelectedRows.Count > 1 Then
                    '複数のボタンを一度に移動することはできない
                    MessageBox.Show(”同時に複数の牌の順序変更はできません。”, "キュア☆ジャン",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                _selectedGridRowIndex = .CurrentRow.Index
                If _selectedGridRowIndex + _direction < 0 OrElse .Rows.Count <= _selectedGridRowIndex + _direction Then
                    '一番端まで来たらそれ以上移動できないので抜ける
                    Return
                End If

            End With


            With MatchManagerController.GetInstance.MatchManager.RoundManager.WallPile


                Dim _currentTile = DirectCast(Me.WallPileDataGridView.CurrentRow.DataBoundItem, Tile)
                'Dim _currentButtonID As String = DirectCast(_currentDataRow("ButtonID"), String)

                Dim _currentTileIndex As Integer = .IndexOf(_currentTile)

                '選択行を複製した行を挿入した後、元の行を削除
                'Dim _currentTileClone As New PreCureCharacterTile(_currentTile.ID, _currentTile.Name)

                .Remove(_currentTile)
                .Insert(_currentTileIndex + _direction, _currentTile)

            End With

            With Me.WallPileDataGridView
                .ClearSelection()
                .Rows(_selectedGridRowIndex + _direction).Selected = True
                .CurrentCell = .Item(0, _selectedGridRowIndex + _direction)

            End With

        End Sub


        ''' <summary>
        ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾋﾞｭｰ行番号描写
        ''' </summary>
        ''' <remarks>ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾋﾞｭｰ｢ユーザ情報テーブル｣の行ﾍｯﾀﾞｰに番号を描写します。</remarks>
        Private Sub Grid_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles WallPileDataGridView.CellPainting


            '列ﾍｯﾀﾞｰかどうか調べる
            If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then

                'セルを描画する
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

                '行番号を描画する範囲を決定する
                Dim indexRect As Rectangle = e.CellBounds

                '行番号を描画する
                indexRect.Inflate(-2, -2)
                TextRenderer.DrawText(e.Graphics,
                                      (e.RowIndex + 1).ToString(),
                                      e.CellStyle.Font,
                                      indexRect,
                                      e.CellStyle.ForeColor,
                                      TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

                '描画が完了したことを知らせる      
                e.Handled = True

            End If

        End Sub

    End Class
End Namespace