Imports ChiriNulluo.Mahjong.Core.Players.COM
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Precure.HandChecker

Namespace Players.COM

    Public Class PrecureCOMPlayerAlgorithm
        Implements COMPlayerAlgorithm

        Private _strategy As COMStrategy
        Private _comPlayer As COMPlayer
        Private _roundManager As RoundManager

        Public Sub New(comPlayer As COMPlayer, roundManager As RoundManager, Optional strategy As COMStrategy = COMStrategy.Random)
            _strategy = strategy
            _comPlayer = comPlayer
            _roundManager = roundManager
        End Sub

        Public Function ChooseDiscardTile() As Tile Implements COMPlayerAlgorithm.ChooseDiscardTile

            Select Case _strategy
                Case COMStrategy.Random
                    '常に末尾の牌を切る
                    Return _comPlayer.Hand.MainTiles.Last
                Case COMStrategy.ToCompleteDealtReadyHand
                    Return _comPlayer.Hand.TileDrawnBefore
                Case COMStrategy.ToCompleteDealtHandOneStepAwayFromReady
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

            End Select

        End Function

        Public Function ChooseStrategy() As COMStrategy Implements COMPlayerAlgorithm.ChooseStrategy
            Throw New NotImplementedException()
        End Function

        Public Sub DealInitialHand(wallPile As WallPile) Implements COMPlayerAlgorithm.DealInitialHand
            Select Case _strategy
                Case COMStrategy.Random
                    'UNIMPLEMENTED：このモードは無限ループで処理オチを起こす。今はCOMStrategy.Randomという値が入ってくる箇所がないからバグが顕在化してないだけ
                    Me._roundManager.DealInitialHand(Me._comPlayer)

                Case COMStrategy.ToCompleteDealtReadyHand
                    Dim _comHandFactory As New PrecureCOMHandFactory(Me._roundManager)
                    _comHandFactory.DealReadyHand(Me._comPlayer)

                Case COMStrategy.ToCompleteDealtHandOneStepAwayFromReady
                    Dim _comHandFactory As New PrecureCOMHandFactory(Me._roundManager)
                    _comHandFactory.DealHandNeedingTwoTIlesToComplete(Me._comPlayer)

            End Select
        End Sub
    End Class

End Namespace