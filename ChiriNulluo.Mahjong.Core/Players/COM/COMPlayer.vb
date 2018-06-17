Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Players.COM

    Public Class COMPlayer
        Inherits Player


        Public Property Algorithm As COMPlayerAlgorithm

        'UNIMPLEMENTED：設計は再検討を要する：ほとんどのメソッドがCOMPlayerAlgorithmに移譲されている。このクラスとCOMPlayerAlgorithmを分ける意味はあったのか？

        ''' <summary>
        ''' 戦略タイプを決定する
        ''' </summary>
        Public Function ChooseStrategy() As COMStrategy
            Algorithm.ChooseStrategy()
        End Function

        ''' <summary>
        ''' 初期手牌を山から手牌に配る。
        ''' </summary>
        Public Overrides Sub DeallInitialHand(wallPile As Tiles.WallPile)
            Algorithm.DealInitialHand(wallPile)
        End Sub


        ''' <summary>
        ''' 切る牌を決定する
        ''' </summary>
        Public Function ChooseDiscardTile() As Tiles.Tile
            Return Algorithm.ChooseDiscardTile()
        End Function


        ''' <summary>
        ''' 1巡前の向聴数
        ''' </summary>
        ''' <returns>1巡前の向聴数</returns>
        Public Property PreviousShantenCount As Integer

    End Class

End Namespace