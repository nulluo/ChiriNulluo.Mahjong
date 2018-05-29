Namespace Players.COM
    Public Interface COMPlayerAlgorithm

        ''' <summary>
        ''' 戦略タイプを決定する
        ''' </summary>
        Function ChooseStrategy() As COMStrategy

        ''' <summary>
        ''' 初期手牌を山から手牌に配る。
        ''' </summary>
        Sub DealInitialHand(wallPile As Tiles.WallPile)

        ''' <summary>
        ''' 切る牌を決定する
        ''' </summary>
        Function ChooseDiscardTile() As Tiles.Tile

    End Interface
End Namespace