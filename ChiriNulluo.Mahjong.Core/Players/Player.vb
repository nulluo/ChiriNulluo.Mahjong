Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Players

    Public MustInherit Class Player

        ''' <summary>
        ''' この局で引く牌の残り枚数
        ''' </summary>
        Property RestDrawCount As Integer

        Property Score As Integer

        Property DiscardedPile As New DiscardPile

        Property Hand As New Hand

        Property RiichiDone As Boolean = False

        Public Sub InitializeHand()
            Me.Hand = New Hand()
        End Sub

        'UNIMPLEMENTED：クラス図を修正せよ：元の設計では返り値として捨て牌を返すつもりだったが、それだとユーザーが思考するタイミングがないので戻り値なしに変更した。
        Public Sub DrawTile(drawnTile As Tile)
            Me.Hand.DrawTile(drawnTile)
            Me.RestDrawCount -= 1
        End Sub

        Public Sub DiscardTile(discardedTile As Tile)
            Me.Hand.RemoveFromHiddenTiles(discardedTile)
            Me.DiscardedPile.Add(discardedTile)
        End Sub

        ''' <summary>
        ''' 初期手牌を山から手牌に配る。
        ''' </summary>
        Public MustOverride Sub DeallInitialHand(wallPile As Tiles.WallPile)


        Public Sub Pong(targetTile As Tile)
            Me.Hand.Pong(targetTile)
            Me.RestDrawCount -= 1
        End Sub

        Public Sub Chow(mytile1 As Tile, mytile2 As Tile, opponentsTile As Tile)
            Me.Hand.Chow(mytile1, mytile2, opponentsTile)
            Me.RestDrawCount -= 1
        End Sub
    End Class

End Namespace
