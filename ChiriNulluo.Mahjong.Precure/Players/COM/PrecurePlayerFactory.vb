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
                    _opponentCharacter = New PrecurePlayer("Regina", "レジーナ", GetStrategyOfRegina())
                Case "Mirai"
                    _opponentCharacter = New PrecurePlayer("Mirai", "朝比奈みらい")
                Case "Riko"
                    _opponentCharacter = New PrecurePlayer("Riko", "十六夜リコ", GetStrategyOfRiko())
                Case "Kotoha"
                    _opponentCharacter = New PrecurePlayer("Kotoha", "花海ことは", GetStrategyOfKotoha())
                Case "Ruru"
                    _opponentCharacter = New PrecurePlayer("Ruru", "ルールー", GetStrategyOfRuru())
                Case Else
                    _opponentCharacter = Nothing
            End Select

            Return _opponentCharacter
        End Function

#Region "花海ことは"
        'キャラ特徴：45%以上の確率で配牌時テンパイする。固定のテンパイ配牌する確率も高い(20%).テンパイしたら必ずリーチするのでチョンボはしない。

        Private Shared Function GetStrategyOfKotoha() As COMStrategy
            Dim _haipaiTilesList As New List(Of COMHaipaiTiles)
            With _haipaiTilesList
                .Add(New COMHaipaiTiles(5, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801"))
                .Add(New COMHaipaiTiles(5, "0301", "0301", "0301", "0302", "0302", "0303", "0303", "0304", "0304", "0305", "0305", "0306", "0306"))
                .Add(New COMHaipaiTiles(5, "0301", "0302", "0303", "0304", "0305", "0306", "0701", "0702", "0703", "0703", "0704", "0705", "1102"))
                .Add(New COMHaipaiTiles(1, "0102", "0103", "0201", "0202", "0301", "0302", "0303", "0304", "0305", "0306", "0401", "0402", "0403"))
                .Add(New COMHaipaiTiles(5, "0402", "0403", "0404", "0502", "0503", "0504", "1101", "1101", "1102", "1102", "1103", "1103", "1303"))　'まほプリ全員集合

            End With

            Dim _haipaiStrategy As COMHaipaiStrategy
            _haipaiStrategy = New COMHaipaiStrategy(_haipaiTilesList, 60, 30)

            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount,
                                            _haipaiStrategy, riichiRate:=100)

            Return _strategy

        End Function


#End Region

#Region "十六夜リコ"
        'キャラ特徴：配牌は完全ランダム。テンパイ時リーチ確率は5%しかないため、高確率でチョンボをする

        Private Shared Function GetStrategyOfRiko() As COMStrategy
            Dim _haipaiStrategy As New COMHaipaiStrategy
            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount, _haipaiStrategy, 5)

            Return _strategy
        End Function
#End Region

#Region "レジーナ"
        'キャラ特徴：マナを使う手(オールドキドキ、オールピンクキュア、ドキプリ全員集合)を好む。ただし、初手でそれらの役をテンパイする確率はそれほど高くない。

        Private Shared Function GetStrategyOfRegina() As COMStrategy
            Dim _haipaiTilesList As New List(Of COMHaipaiTiles)
            With _haipaiTilesList
                .Add(New COMHaipaiTiles(5, "0101", "0101", "0101", "0301", "0301", "0301", "0801", "0801", "0801", "0901", "0901", "1301", "1301")) 'オールピンクキュア
                .Add(New COMHaipaiTiles(10, "0801", "0801", "0801", "0801", "0802", "0802", "0802", "0802", "0803", "0803", "0804", "0804", "0805")) 'ドキプリ全員集合＆オールドキプリ
                .Add(New COMHaipaiTiles(10, "0101", "0201", "0801", "0801", "0802", "0802", "0803", "0803", "0804", "0805", "0805", "1102", "1206")) 'ドキプリ全員集合
                .Add(New COMHaipaiTiles(30, "0401", "0401", "0801", "0801", "0801", "1203", "0705", "0602", "0702", "0404", "0301", "0302", "0501")) 'マナの暗刻が入った非テンパイ手①
                .Add(New COMHaipaiTiles(30, "0302", "0303", "0602", "0603", "0801", "0801", "0801", "0801", "0904", "1001", "1101", "1203", "1206")) 'マナの暗刻が入った非テンパイ手②


            End With

            Dim _haipaiStrategy As COMHaipaiStrategy
            _haipaiStrategy = New COMHaipaiStrategy(_haipaiTilesList, 50, 10)

            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount,
                                            _haipaiStrategy, riichiRate:=100)

            Return _strategy
        End Function
#End Region


#Region "ルールー"
        'キャラ特徴：ランダムなイーシャンテン手が必ず初手にくる。それ以外の固定的な積み込み要素は一切なし。

        Private Shared Function GetStrategyOfRuru() As COMStrategy
            Dim _haipaiTilesList As New List(Of COMHaipaiTiles)

            Dim _haipaiStrategy As COMHaipaiStrategy
            _haipaiStrategy = New COMHaipaiStrategy(_haipaiTilesList, 0, 0, 10)

            Dim _strategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount,
                                            _haipaiStrategy, riichiRate:=100)

            Return _strategy
        End Function
#End Region


    End Class
End Namespace