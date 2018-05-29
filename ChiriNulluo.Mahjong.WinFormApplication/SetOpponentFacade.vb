Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Precure.Players
Imports ChiriNulluo.Mahjong.WinFormApplication.Logging
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants

Public Class SetOpponentFacade
#Region "Property"

    Private Property View As SelectOpponentForm

#End Region

    Public Sub New(view As SelectOpponentForm)
        Me.View = view
    End Sub


    Public Sub SetOpponent(precurePlayerID As String)

        'UNIMPLEMENTED: 対戦相手の生成手順としてこれが最善じゃない気がする
        Dim _opponentCharacter As PrecurePlayer
        Select Case precurePlayerID
            Case "Eas"
                _opponentCharacter = New PrecurePlayer("Eas", "イース")
            Case "Regina"
                _opponentCharacter = New PrecurePlayer("Regina", "レジーナ")
            Case "Mirai"
                _opponentCharacter = New PrecurePlayer("Mirai", "朝比奈みらい")
            Case "Riko"
                _opponentCharacter = New PrecurePlayer("Riko", "十六夜リコ")
            Case "Kotoha"
                _opponentCharacter = New PrecurePlayer("Kotoha", "花海ことは")
            Case Else
                _opponentCharacter = Nothing
        End Select
        MatchManagerController.InitializeMatch()
        MatchManagerController.GetInstance.OpponentManager.SetOpponent(_opponentCharacter)
        LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA, My.Resources.IDProcessSelectOpponent,
                   String.Empty, String.Empty, precurePlayerID)
    End Sub

    Public Function GoToNextForm(isManualMode As Boolean, Optional humanHandIDList As List(Of String) = Nothing,
                                Optional comHandIDList As List(Of String) = Nothing, Optional wallPileIDList As List(Of String) = Nothing) As Form
        Dim _nextForm As Form

        If isManualMode Then
            _nextForm = New GameParameterSettingForm
        Else
            If Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
                Dim _humanHand As New Hand
                Dim _comHand As New Hand
                Dim _wallPile As New WallPile

                humanHandIDList.ForEach(Sub(id) _humanHand.MainTiles.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))
                comHandIDList.ForEach(Sub(id) _comHand.MainTiles.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))
                wallPileIDList.ForEach(Sub(id) _wallPile.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))

                _nextForm = New RoundForm(_humanHand, _comHand, _wallPile)
            Else
                _nextForm = New RoundForm(Nothing, Nothing, Nothing)
            End If
        End If
        Return Me.View.GoToNextForm(_nextForm)
    End Function

End Class
