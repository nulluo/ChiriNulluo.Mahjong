Imports System.IO
Imports ChiriNulluo.Mahjong.Core.Players
Imports ChiriNulluo.Mahjong.Core.Players.COM
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.HandChecker
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.WinFormApplication.Logging
Imports ChiriNulluo.Mahjong.WinFormApplication.View

Namespace Facade
    Public Class RoundFacade
#Region "Property"
        Public Property HumanPlayer As Core.Players.HumanPlayer

        Public Property COMPlayer As Core.Players.COM.COMPlayer

        Public Property Result As RoundState = Constants.RoundState.Undetermined

        Private Property View As RoundForm


#End Region

        Public Sub New(humanHand As Hand, comHand As Hand, wallPile As WallPile, View As RoundForm,
                   revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))
#If DEBUG Then

            '手動で手牌を決定済みの場合はその通りに配牌する
            If humanHand IsNot Nothing AndAlso comHand IsNot Nothing AndAlso
                                                 wallPile IsNot Nothing Then
                MatchManagerController.GetInstance.InitializeRound(humanHand, comHand, wallPile, revealedBonusTiles, unrevealedBonusTiles)
            Else
                'MatchManagerController.GetInstance.InitializeRound(COMStrategy.ToCompleteDealtReadyHand)
                MatchManagerController.GetInstance.InitializeRound(COMStrategy.ToDecreaseShantenCount)
                'MatchManagerController.GetInstance.InitializeRound(COMStrategy.ToBeFritenForTest)
                MatchManagerController.GetInstance.MatchManager.RoundManager.ShuffleWall()
            End If
#Else
        MatchManagerController.GetInstance.InitializeRound(COMStrategy.ToCompleteDealtReadyHand)
        MatchManagerController.GetInstance.MatchManager.RoundManager.ShuffleWall()
#End If
            For Each _player As Core.Players.Player In MatchManagerController.GetInstance.PlayersList
                If TypeOf _player Is Core.Players.HumanPlayer Then
                    HumanPlayer = DirectCast(_player, Core.Players.HumanPlayer)
                Else
                    COMPlayer = DirectCast(_player, Core.Players.COM.COMPlayer)
                End If
            Next

#If DEBUG Then

            '手動で手牌を決定済みでない場合はここで配牌する
            If humanHand Is Nothing OrElse comHand Is Nothing OrElse
                                                 wallPile Is Nothing Then
                Me.Haipai()
            End If
#Else
        Me.Haipai()
#End If
            If Replay.ReplayDataManager.CurrentState = ReplayModeState.NormalModeSinceMatchStarted Then
                Me.WriteHaipaiDataToReplayLog()
            End If
            Me.View = View
        End Sub


        Public Sub Haipai()
            'COMはイカサマしてテンパイ手を積み込むので人間よりも先に配牌する（必要な牌が山にあると困るから）
            MatchManagerController.GetInstance.MatchManager.DealInitialHand(Me.COMPlayer)
            MatchManagerController.GetInstance.MatchManager.DealInitialHandForPlayer0()
            Me.HumanPlayer.Hand.MainTiles.Sort()
            Me.COMPlayer.Hand.MainTiles.Sort()
        End Sub


        ''' <summary>
        ''' HUMANプレイヤーが1枚ツモする
        ''' </summary>
        Public Function DrawHumanPlayersTile() As Tile
            Dim _nextDraw As Tile = MatchManagerController.GetInstance.MatchManager.RoundManager.WallPile.Last
            MatchManagerController.GetInstance.MatchManager.DrawTileForPlayer0()

            'アガリ判定
            Dim _handChecker As New PrecureHandChecker(Me.HumanPlayer.Hand)
            If _handChecker.IsCompleted() Then
                If Me.View.ConfirmFinish = My.Resources.LabelYes Then
                    Me.Result = RoundState.PlayerWinByTileDrawnByPlayer
                    Me.View.EndRound(True)
                End If
            ElseIf Me.HumanPlayer.RestDrawCount <= 0 Then
                '流局判定
                Me.Result = RoundState.Draw
                Me.View.MakeGameDraw()
            End If
            Return _nextDraw

        End Function

        ''' <summary>
        ''' COMプレイヤーが牌を1枚ツモる。
        ''' </summary>
        Public Sub DrawCOMPlayersTile()

            Dim _nextDraw As Tile = MatchManagerController.GetInstance.MatchManager.RoundManager.WallPile.Last
            MatchManagerController.GetInstance.MatchManager.DrawTile(Me.COMPlayer)
            'アガリ判定
            Dim _handChecker As New PrecureHandChecker(Me.COMPlayer.Hand)
            If _handChecker.IsCompleted() Then
                If DirectCast(Me.COMPlayer.Algorithm, Precure.Players.COM.PrecureCOMPlayerAlgorithm).strategy = COMStrategy.ToBeFritenForTest Then
                    'フリテンテスト用Strategyを採用している場合
                    If Me.COMPlayer.IgnoredWinningTileCount = 0 Then
                        Me.COMPlayer.IgnoredWinningTileCount += 1
                    Else
                        Me.Result = RoundState.PlayerLoseByTileDrawnByCOM
                    End If

                Else
                    Me.Result = RoundState.PlayerLoseByTileDrawnByCOM

                End If

            Else
                Me.Result = RoundState.Undetermined
            End If
        End Sub

        ''' <summary>
        ''' COMプレイヤーが牌を1枚切る。聴牌した場合、リーチするかどうかCOMが判断して決めて実行する。
        ''' </summary>
        ''' <returns>捨てた牌</returns>
        Public Function DiscardCOMPlayersTile() As Tile
            Dim _result As RoundState = RoundState.Undetermined

            Dim _discardedTile As Tile = Me.COMPlayer.ChooseDiscardTile()
            Me.COMPlayer.DiscardTile(_discardedTile)

            'テンパイ判定
            Dim _handCheckerCOM As New PrecureHandChecker(Me.COMPlayer.Hand)
            If Not Me.COMPlayer.RiichiDone AndAlso _handCheckerCOM.IsReady Then
                If Me.DecidesToRiichi() Then
                    _result = _result Or RoundState.COMDeclaredRiichi
                End If
            End If

            'COMの捨て牌をプレイヤーがロン可能か？
            Dim _handCheckerPlayer As New PrecureHandChecker(Me.HumanPlayer.Hand)
            If _handCheckerPlayer.IsCompletedIfTargetTileAdded(_discardedTile) Then
                _result = _result Or RoundState.PlayerCanRonTileDiscardedByCOM
                If Me.IsFriten(Me.HumanPlayer, Me.COMPlayer) Then
                    _result = _result Or RoundState.PlayerIsFriten
                End If
            End If

            'COMの捨て牌をプレイヤーがポン可能か？(残りのツモ数が1以下の場合、鳴いても捨て牌する場所がないので鳴けない事に注意)
            If Me.HumanPlayer.RestDrawCount > 1 Then
                If _handCheckerPlayer.CanMakeTripletIfTargetTileAdded(_discardedTile) Then
                    _result = _result Or RoundState.PlayerCanPongTileDiscardedByCOM
                End If
            End If

            'COMの捨て牌をプレイヤーがチー可能か？(残りのツモ数が1以下の場合、鳴いても捨て牌する場所がないので鳴けない事に注意)
            If Me.HumanPlayer.RestDrawCount > 1 Then
                With MatchManagerController.GetInstance.MatchManager.RoundManager
                    .PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded =
                _handCheckerPlayer.GetPossibleTatsuListWhichCanMakeChowIfTargetTileAdded(_discardedTile)
                    If .PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded.Count > 0 Then
                        _result = _result Or RoundState.PlayerCanChowTileDiscardedByCOM
                    End If
                End With
            End If

            Me.Result = _result

            Return _discardedTile
        End Function

        ''' <summary>
        ''' HUMANプレイヤーが牌を一枚捨てる。
        ''' </summary>
        ''' <param name="tileIndex">捨てる牌の<c>Hand.MainTiles</c>内のインデックス</param>
        Public Function DiscardHumanTile(tileIndex As Integer) As Tile
            If Me.HumanPlayer.Hand.MainTiles.Count <= tileIndex Then
                '副露している牌は切れないので何もしない
                Return Nothing
            End If

            Dim _tileToDiscard As Tile = Me.HumanPlayer.Hand.MainTiles(tileIndex)
            MatchManagerController.GetInstance.MatchManager.DiscardTileForPlayer0(_tileToDiscard)
            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA, My.Resources.IDProcessDiscardTile,
                           My.Resources.IDPlayerHuman, "捨て牌情報--ID:" & _tileToDiscard.ID & " Name:" & _tileToDiscard.Name, tileIndex.ToString)

            'プレイヤーの捨て牌をCOMがロン可能か？
            Dim _handCheckerCOM As New PrecureHandChecker(Me.COMPlayer.Hand)
            If _handCheckerCOM.IsSetCompletedAndYakuAccomplishedIfTargetTileAdded(_tileToDiscard, COMPlayer.RiichiDone) Then
                If Me.IsFriten(Me.COMPlayer, Me.HumanPlayer) Then
                    'COMがフリテンしている場合
                    Me.Result = RoundState.COMIsFriten
                Else
                    Me.COMPlayer.Hand.PongOrChowOrRonDone = True
                    'UNIMPLEMENTED：状況に応じてロンするかどうかＣＯＭに思考させる
                    Me.Result = RoundState.PlayerLoseByTileDiscardedByPlayer

                    'ElseIf [COMが鳴くかどうかの判定処理]
                    'UNIMPLEMENTED： 「プレイヤーの捨て牌をCOMが鳴けるか判定し、鳴いた方が有利と判断した場合に鳴く」処理をここに書く
                    'UNIMPLEMENTED: COMのポン・チー機能を実装した場合、COM側のDrawCountを1増やす事を忘れないようにする

                End If

            Else
                Me.Result = RoundState.Undetermined
            End If
            Return _tileToDiscard
        End Function

        ''' <summary>
        ''' 今捨てられた牌でHUMANがチーをする場合に、可能なチーの組合せを取得する
        ''' </summary>
        ''' <returns>チー可能な牌の組み合わせ全て</returns>
        Public Function GetPossibleHumanChowCombination() As RevealedTiles()
            With MatchManagerController.GetInstance.MatchManager.RoundManager

                If .PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded Is Nothing Then
                    Throw New Exception("Cannot Chow Now.")
                End If

                Dim _choiceCount As Integer = .PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded.Count

                Dim _choicePiles(_choiceCount - 1) As RevealedTiles
                Dim i As Integer = 0
                For Each _tatsu As List(Of String) In .PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded
                    With Me.HumanPlayer.Hand.MainTiles
                        Dim _myTile0 = .SearchTile(_tatsu(0))
                        Dim _myTile1 = .SearchTile(_tatsu(1))
                        _choicePiles(i) = New RevealedTiles(False, _myTile0, _myTile1, Me.COMPlayer.DiscardedPile.Last)
                    End With
                    i += 1
                Next

                Return _choicePiles

            End With

        End Function

        Public Sub Chow(player As Player, mytile1 As Tile, mytile2 As Tile, opponentsTile As Tile)
            player.Chow(mytile1, mytile2, opponentsTile)
            MatchManagerController.GetInstance.MatchManager.RoundManager.PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded = Nothing
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="showsPointForm"><c>PointDisplayForm</c>を表示するかどうか。</param>
        Public Sub EndRound(Optional discardedTile As Tile = Nothing)
            'UNIMPLEMENTED：List(Of Tile)のAdd,Removeメソッドを直に触るなんて結合度密すぎぃ！
            'ロン上がりの場合は、捨て牌を手に加えてから得点表示開始
            If discardedTile IsNot Nothing Then
                If Me.Result = RoundState.PlayerLoseByTileDiscardedByPlayer Then
                    Me.HumanPlayer.DiscardedPile.Remove(discardedTile)
                    Me.COMPlayer.Hand.DrawTile(discardedTile)
                ElseIf Me.Result = RoundState.PlayerWinByTileDiscardedByCOM Then
                    Me.COMPlayer.DiscardedPile.Remove(discardedTile)
                    Me.HumanPlayer.Hand.DrawTile(discardedTile)
                End If
            End If

            'どちらも上がらなかった場合は局数カウントアップしない
            If Me.Result <> RoundState.Draw Then
                MatchManagerController.GetInstance.MatchManager.RoundsCount += 1
            End If


        End Sub

        Friend Sub DiscardIfHumanRiichiDone()
            If Me.HumanPlayer.RiichiDone Then
                Me.View.DiscardHumanTile(Me.HumanPlayer.Hand.MainTiles.Count - 1)
            End If
        End Sub

        Friend Sub RiichiHuman()
            Me.HumanPlayer.RiichiDone = True
        End Sub

        Friend Sub RiichiCOM()
            Me.COMPlayer.RiichiDone = True
        End Sub


        ''' <summary>
        ''' アガリ牌を見逃したプレイヤーが、もしリーチを宣言済みである場合、そのプレイヤーをフリテン状態にする。
        ''' アガリ牌が他プレイヤーから捨てられたのを見逃した時に実行する。
        ''' </summary>
        ''' <param name="missedWinningTilePlayer">アガリ牌をロンしなかったプレイヤー</param>
        Friend Sub MakeFritenIfRiichiDone(missedWinningTilePlayer As Player)

            If missedWinningTilePlayer.RiichiDone Then
                missedWinningTilePlayer.IgnoredWinningTileFromAnotherAfterRiichi = True
            End If

        End Sub

        ''' <summary>
        ''' 対象のテンパイ済みプレイヤーがフリテン状態かどうかチェックする。
        ''' </summary>
        ''' <param name="readyPlayer">フリテン状態かどうかチェックするプレイヤー。テンパイ済みである事は前提とする。</param>
        ''' <returns>対象のプレイヤーがフリテンしている場合はTrue,そうでない場合はFalse。</returns>
        ''' <remarks>readyPlayerがテンパイしている状態でこのメソッドを呼び出すことを前提とする。</remarks>
        Private Function IsFriten(readyPlayer As Player, tileDiscardPlayer As Player) As Boolean

            If readyPlayer.IgnoredWinningTileFromAnotherAfterRiichi Then
                'リーチ後に アガリ牌が他プレイヤーから捨てられたのを見逃している場合
                Return True
            Else
                'そのプレイヤーのアタリ牌を取得
                Dim _handCheckerPlayer As New PrecureHandChecker(readyPlayer.Hand)
                Dim _tilesToCompleteHand As List(Of String) = _handCheckerPlayer.TilesToCompleteHand()

                For Each _id As String In _tilesToCompleteHand
                    If readyPlayer.DiscardedPile.SearchTile(_id) IsNot Nothing Then
                        'アタリ牌が自身の捨て牌にある場合
                        Return True

                    Else
                        'UNIMPLEMENTED: アタリ牌がポン・チーで食われた牌の中にある場合
                        For Each _tiles As RevealedTiles In tileDiscardPlayer.Hand.RevealedTilesList
                            If _tiles.OpponentsTile.ID = _id Then
                                Return True
                            End If
                        Next
                    End If
                Next

                Return False
            End If

        End Function

        ''' <summary>
        ''' リーチするかどうかを決定する
        ''' </summary>
        Private Function DecidesToRiichi() As Boolean

            Dim _random As New System.Random()
            'UNIMPLEMENTED: 本来はCOMPlayerの戦略ごとに異なるロジックで決定する。取り合えず一律で1/5の確率でリーチさせてる
            Return (_random.Next(5) = 0)

        End Function

        ''' <summary>
        ''' Round開始時の山牌、手牌の状態をリプレイログに書きだす
        ''' </summary>
        Private Sub WriteHaipaiDataToReplayLog()
            'UNIMPLEMENTED: 正確にはランダムとも限らない。（マニュアルモードがあるから）

            'Dim _parameters As New List(Of String)
            'For Each _tile As Tile In Me.COMPlayer.Hand.MainTiles
            '    _parameters.Add(_tile.ID)
            'Next


            '_parameters = Me.COMPlayer.Hand.MainTiles.Select(Function(x) x.ID)

            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeRD,
                                         My.Resources.IDProcessHaipai_P0, My.Resources.IDPlayerCOM, String.Empty,
                                         Me.COMPlayer.Hand.MainTiles.Select(Function(x) x.ID).ToArray)

            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeRD,
                                         My.Resources.IDProcessHaipai_P1, My.Resources.IDPlayerHuman, String.Empty,
                                         Me.HumanPlayer.Hand.MainTiles.Select(Function(x) x.ID).ToArray)

            Dim _wallPile As WallPile = MatchManagerController.GetInstance.MatchManager.RoundManager.WallPile
            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeRD,
                                         My.Resources.IDProcessHaipai_P1, String.Empty, String.Empty,
                                         _wallPile.Select(Function(x) x.ID).ToArray)

            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeRD,
                                 My.Resources.IDProcessHaipai_BonusRevealed, String.Empty, String.Empty,
                                        PrecureCharacterSet.GetInstance.CurrentRoundRevealedBonusTilesIDList.Distinct.ToArray)

            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeRD,
                                 My.Resources.IDProcessHaipai_BonusUnrevealed, String.Empty, String.Empty,
                                        PrecureCharacterSet.GetInstance.CurrentRoundUnrevealedBonusTilesIDList.Distinct.ToArray)
        End Sub
    End Class
End Namespace