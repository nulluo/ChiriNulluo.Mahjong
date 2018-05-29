Imports System.Linq

Namespace Tiles

    Public Class Hand

        ''' <summary>
        ''' ポン・チー・ロンをしているかどうか。
        ''' </summary>
        Public Property PongOrChowOrRonDone As Boolean = False

        ''' <summary>
        ''' 鳴いた牌が何セットあるかを返す。(ポンもしくはチー1回分の牌3個を1セットとカウントする)
        ''' </summary>
        Public ReadOnly Property RevealedCount As Integer
            Get
                Return Me.RevealedTilesList.Count
            End Get
        End Property

        Public Property MainTiles As New HiddenTiles

        Public Property RevealedTilesList As New List(Of RevealedTiles)

        Public ReadOnly Property TotalTiles As Pile
            Get
                Dim _totalTiles As New Pile
                _totalTiles.AddRange(Me.MainTiles.Select(Function(tile) tile).ToArray())

                _totalTiles.AddRange(Me.RevealedTilesList.SelectMany(Function(tiles) tiles).ToArray())
                Return _totalTiles
            End Get
        End Property

        Public ReadOnly Property TotalCount As Integer
            Get
                Dim _count = Me.MainTiles.Count + Me.RevealedTilesList.Sum(Function(tile) tile.Count)
                Return _count
            End Get
        End Property

        Public Property GetScore As Integer

        Public Property State As HandState

        ''' <summary>
        ''' 直前にツモった牌
        ''' </summary>
        ''' <returns></returns>
        Property TileDrawnBefore As Tile = Nothing

        'Public Sub AddToMainTiles(item As Tile)
        '    Me.MainTiles.Add(item)
        '    Me.TileDrawnBefore = item
        'End Sub

        'UNIMPLEMENTED：DrawTileとAddToMainTilesメソッドの使い分けで混乱している。AddToMainTilesだけに統一できるんじゃないか？
        Public Sub DrawTile(drawnTile As Tile)
            'AddToMainTiles(drawnTile)
            Me.MainTiles.Add(drawnTile)
            Me.TileDrawnBefore = drawnTile
            'Me.MainTiles.Sort()
        End Sub

        Public Sub RemoveFromHiddenTiles(discardedTile As Tile)
            Me.MainTiles.Remove(discardedTile)
            Me.MainTiles.Sort()
        End Sub

        'UNIMPLEMENTED：oppponentsTileがポン可能かどうかは、ここで判定した方がいいのでは？ポン不可能な牌だったら例外投げるとかFalse返すとか…でもそうなるとHandCheckerの存在意義が…という問題もあるが
        ''' <summary>
        ''' ポンを実行する。
        ''' </summary>
        ''' <remarks>とりあえず、ポンできる牌が来た前提で実行する仕様にしている</remarks>
        ''' <param name="opponentsTile">ポンする対象の牌</param>
        Public Sub Pong(opponentsTile As Tile)

            Dim _pongTiles = Me.MainTiles.Where(Function(tile) tile.ID = opponentsTile.ID)
            Dim _myTile1 = _pongTiles.First()
            Dim _myTile2 = _pongTiles.Last()

            Dim _pong As New RevealedTiles(True, _myTile1, _myTile2, opponentsTile)
            Me.RevealedTilesList.Add(_pong)
            _myTile1.IsRevealedForPongOrChow = True
            _myTile2.IsRevealedForPongOrChow = True
            opponentsTile.IsRevealedForPongOrChow = True

            Me.MainTiles.Remove(_myTile1)
            Me.MainTiles.Remove(_myTile2)
            Me.MainTiles.Sort()
            Me.PongOrChowOrRonDone = True
        End Sub

        ''' <summary>
        ''' チーを実行する。
        ''' </summary>
        ''' <param name="mytile1"></param>
        ''' <param name="mytile2"></param>
        ''' <param name="opponentsTile"></param>
        Public Sub Chow(mytile1 As Tile, mytile2 As Tile, opponentsTile As Tile)
            Dim _chow As New RevealedTiles(False, mytile1, mytile2, opponentsTile)
            Me.RevealedTilesList.Add(_chow)
            mytile1.IsRevealedForPongOrChow = True
            mytile2.IsRevealedForPongOrChow = True
            opponentsTile.IsRevealedForPongOrChow = True

            Me.MainTiles.Remove(mytile1)
            Me.MainTiles.Remove(mytile2)
            Me.MainTiles.Sort()
            Me.PongOrChowOrRonDone = True
        End Sub

        ''' <summary>
        ''' 副露していない手牌のうち、指定したIDに一致する牌を先頭から検索し、最初に見つかった牌の参照を返す。
        ''' </summary>
        ''' <param name="id">検索する牌のID</param>
        ''' <returns>見つかった牌の参照。一致する牌が存在しない場合、Nothingを返す。</returns>
        Public Function SearchUnRevealedTile(id As String) As Tile
            Dim _foundTile = Me.MainTiles.FirstOrDefault(Function(_tile) _tile.ID = id AndAlso Not _tile.IsRevealedForPongOrChow)
            Return _foundTile
        End Function
    End Class

End Namespace