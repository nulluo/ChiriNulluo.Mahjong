Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Precure.Suits
Imports ChiriNulluo.Mahjong.Precure.DataAccess

Namespace View
    ''' <summary>
    ''' 牌詳細情報表示パネル
    ''' </summary>
    Public Class TileDetailInfoPanel

        Public Property TargetTile As PreCureCharacterTile

        Public Property TargetTileIndex As Integer

        ''' <summary>
        ''' パネルを描画する。
        ''' </summary>
        ''' <param name="tile">表示する牌</param>
        ''' <param name="index">Pile内での牌のインデックス</param>
        Public Sub Draw(tile As PreCureCharacterTile, index As Integer)

            Me.TargetTile = tile
            Me.TargetTileIndex = index

            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()

            Dim _suit As PrecureSuit = _xmlAccess.GetTileSuit(tile.SuitID)

            Me.NameLabel.Text = tile.Name
            Me.CureNameLabel.Text = tile.CureName
            Me.SuitNameLabel.Text = _suit.Name
            Me.NumberLabel.Text = tile.Number & "/" & _suit.TotalTilesCount

            Me.EnlargedImage.Image = tile.EnlargedImage

            Me.Visible = True

        End Sub

        ''' <summary>
        ''' パネルを消去する。
        ''' </summary>
        Public Sub [Erase]()
            Me.NameLabel.Text = String.Empty
            Me.SuitNameLabel.Text = String.Empty
            Me.NumberLabel.Text = String.Empty
            Me.EnlargedImage.Image = Nothing

            Me.Visible = False
        End Sub

    End Class
End Namespace