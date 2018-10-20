Imports ChiriNulluo.Mahjong.Core.Players.COM
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Precure.HandChecker

Namespace Players.COM

    Public Class PrecureCOMPlayerAlgorithm
        Implements COMPlayerAlgorithm

        Public Property strategy As COMStrategy
        Private _comPlayer As COMPlayer
        Private _roundManager As RoundManager

        Public Sub New(comPlayer As COMPlayer, roundManager As RoundManager, Optional strategy As COMStrategy = Nothing)
            If strategy Is Nothing Then
                strategy = New COMStrategy(COMDiscardTileStrategy.Random)
            End If
            _strategy = strategy
            _comPlayer = comPlayer
            _roundManager = roundManager
        End Sub

        Public Function ChooseDiscardTile() As Tile Implements COMPlayerAlgorithm.ChooseDiscardTile

            Select Case _strategy.COMDiscardTileStrategy
                Case COMDiscardTileStrategy.Random
                    '常に末尾の牌を切る
                    Return _comPlayer.Hand.MainTiles.Last
                Case COMDiscardTileStrategy.ToCompleteDealtReadyHand
                    Return _comPlayer.Hand.TileDrawnBefore
                Case COMDiscardTileStrategy.ToCompleteDealtHandOneStepAwayFromReady
                    Dim _handChecker As New PrecureHandChecker(_comPlayer.Hand)

                    'テンパイになっている時はツモギリ
                    If _handChecker.IsReady Then
                        Return _comPlayer.Hand.TileDrawnBefore

                    Else
                        'イーシャンテンの場合、引いた牌を手に入れるべきかチェックする
                        Dim _tileToDiscard = _handChecker.GetTileToDiscardToMakeReadyHand()

                        If _tileToDiscard Is Nothing Then
                            Return _comPlayer.Hand.TileDrawnBefore
                        Else
                            Return _tileToDiscard
                        End If
                    End If

                Case COMDiscardTileStrategy.ToDecreaseShantenCount, COMDiscardTileStrategy.ToBeFritenForTest
                    'テンパイになっている時はツモギリ
                    Dim _handChecker As New PrecureHandChecker(_comPlayer.Hand)
                    If _handChecker.IsReady Then
                        Return _comPlayer.Hand.TileDrawnBefore
                    End If

                    Dim _newShanten As Integer

                    Dim _handTileIDList As List(Of String) = _comPlayer.Hand.MainTiles.Select(Function(x) x.ID).ToList

                    'UNIMPLEMENTED: これだと、向聴数が少なる牌のうち、常に最小のIDの牌を捨てるアルゴリズムになっているため、COMの手牌がじゃっかんID上の方に偏る傾向が出てしまう。IDと向聴数のDictionaryを用意して、最小向聴数を満たす捨て牌候補からランダムで捨て牌を確定する仕組みが必要
                    '捨てる牌。まずはツモった牌を候補とし、それ以外に向聴数が小さくなる牌が見つかればそれを捨てる
                    Dim _idToDiscard As String = _handTileIDList.Last
                    For i As Integer = 0 To _handTileIDList.Count - 1
                        Dim _id As String = _handTileIDList(i)
                        _handTileIDList.RemoveAt(i)
                        _newShanten = ShantenCounter.CalculateShanten(_handTileIDList).ShantenCount
                        _handTileIDList.Insert(i, _id)

                        If _newShanten < _comPlayer.PreviousShantenCount Then
                            _comPlayer.PreviousShantenCount = _newShanten
                            _idToDiscard = _id
                        End If
                    Next
                    Return _comPlayer.Hand.MainTiles.SearchTile(_idToDiscard)

            End Select

        End Function

        Public Function ChooseStrategy() As COMStrategy Implements COMPlayerAlgorithm.ChooseStrategy
            Throw New NotImplementedException()
        End Function

        Public Sub DealInitialHand(wallPile As WallPile) Implements COMPlayerAlgorithm.DealInitialHand
            Dim _comHandFactory As New PrecureCOMHandFactory(Me._roundManager)
            _comHandFactory.DealInitialHand(Me._comPlayer)
        End Sub
    End Class

End Namespace