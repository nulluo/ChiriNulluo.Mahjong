Imports ChiriNulluo.Mahjong.Core.Players.COM

Namespace Players
    Public NotInheritable Class PrecurePlayerFactory

        Public Shared Function GetCOMPlayer(opponentID As String) As PrecurePlayer

            'UNIMPLEMENTED: 対戦相手の生成手順としてこれが最善じゃない気がする
            Dim _opponentCharacter As PrecurePlayer
            Select Case opponentID
                Case "Eas"
                    _opponentCharacter = New PrecurePlayer("Eas", "イース")
                Case "Regina"
                    _opponentCharacter = New PrecurePlayer("Regina", "レジーナ")
                Case "Mirai"
                    _opponentCharacter = New PrecurePlayer("Mirai", "朝比奈みらい")
                Case "Riko"
                    _opponentCharacter = New PrecurePlayer("Riko", "十六夜リコ", GetStrategyOfRiko())
                Case "Kotoha"
                    _opponentCharacter = New PrecurePlayer("Kotoha", "花海ことは", GetStrategyOfKotoha())
                Case Else
                    _opponentCharacter = Nothing
            End Select

            Return _opponentCharacter
        End Function

#Region "花海ことは"

        Private Shared Function GetStrategyOfKotoha() As COMStrategy
            Dim _haipaiTilesList As New List(Of COMHaipaiTiles)
            With _haipaiTilesList
                .Add(New COMHaipaiTiles(10, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801"))
                .Add(New COMHaipaiTiles(10, "0301", "0301", "0301", "0302", "0302", "0303", "0303", "0304", "0304", "0305", "0305", "0306", "0306"))
                .Add(New COMHaipaiTiles(10, "0301", "0302", "0303", "0304", "0305", "0306", "0701", "0702", "0703", "0703", "0704", "0705", "1102"))
                .Add(New COMHaipaiTiles(1, "0102", "0103", "0201", "0202", "0301", "0302", "0303", "0304", "0305", "0306", "0401", "0402", "0403"))


            End With

            Dim _haipaiStrategy As COMHaipaiStrategy
            _haipaiStrategy = New COMHaipaiStrategy(1, _haipaiTilesList)

            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount,
                                            _haipaiStrategy, riichiRate:=100)

            Return _strategy

        End Function


#End Region

#Region "十六夜リコ"
        Private Shared Function GetStrategyOfRiko() As COMStrategy
            Dim _haipaiStrategy As New COMHaipaiStrategy
            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount, _haipaiStrategy, 0)

            Return _strategy
        End Function
#End Region

    End Class
End Namespace