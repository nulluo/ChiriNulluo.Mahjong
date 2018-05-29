Namespace Tiles

    ''' <summary>
    ''' 牌セットを表すクラス
    ''' </summary>
    ''' <remarks>例）プリキュア牌セット、バットマン牌セット等、特定のテーマに属する牌の集合</remarks>
    ''' <typeparam name="T"></typeparam>
    Public Interface TileSet(Of T As Tile)
        ReadOnly Property CurrentRoundTotalTilesList As List(Of T)
        ReadOnly Property CurrentRoundTotalTilesIDList() As List(Of String)
    End Interface

End Namespace
