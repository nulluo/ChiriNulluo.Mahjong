Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Core.Players.COM

Namespace Players.COM

    Public Class PrecureCOMHandFactory

        Private Property RoundManager As RoundManager
        Private Shared logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()

#Region "確率パラメタ"

        ''' <summary>
        ''' 配牌時大技（青キュア一色）が入っている確率
        ''' </summary>
        Private Const AllBlueCureRate As Integer = 2

        ''' <summary>
        ''' 配牌時、テンパイ手が入っている確率
        ''' </summary>
        Private Const ReadyHandStartRate As Integer = 20


#End Region

        Public Sub New(roundManager As RoundManager)
            Me.RoundManager = roundManager
        End Sub

        ''' <summary>
        ''' テンパイの手を配牌します。
        ''' </summary>
        ''' <param name="comPlayer">COMプレイヤー</param>
        Public Sub DealReadyHand(comPlayer As COMPlayer)

            Dim _readyHand As List(Of String) = Me.GetReadyHandAtRandom()

            If _readyHand Is Nothing Then
                For i As Integer = 0 To 13 - 1
                    Me.RoundManager.DrawTile(comPlayer)
                Next
            Else
                For Each _id As String In _readyHand
                    '山から手牌に牌を加える
                    Dim _pickedTile As Tile = Me.RoundManager.PickOutTileFromPile(_id, RoundManager.WallPile)
                    If _pickedTile Is Nothing Then
                        '牌を引くのに失敗した（現在山に存在しない牌IDを指定した）場合、ログにエラー情報を吐く
                        logger.Error(" MoveTile Failed.[ID:" & _id & "] WallPile -> COM Hand")
                    Else
                        comPlayer.Hand.DrawTile(_pickedTile)
                    End If

                Next
            End If
        End Sub

        ''' <summary>
        ''' テンパイした状態の手牌のプリキュアIDのリストをランダムに生成して返します。
        ''' </summary>
        ''' <returns>テンパイした状態の手牌のプリキュアIDのリスト</returns>
        Private Function GetReadyHandAtRandom() As List(Of String)
            Dim _randomNumber As Integer = (New Random()).Next(100)

            Select Case _randomNumber
                Case 0 To AllBlueCureRate
                    Return Me.GetAllBlueCures()
                Case AllBlueCureRate + 1 To AllBlueCureRate + ReadyHandStartRate
                    Return Me.GetOrthodoxReadyHandAtRandom
                Case Else
                    Return Nothing
            End Select

        End Function

        Private Function GetAllBlueCures() As List(Of String)
            Dim _idList As New List(Of String)
            With _idList
                .Add("0305")
                .Add("0305")
                .Add("0305")
                .Add("0502")
                .Add("0502")
                .Add("0502")
                .Add("0705")
                .Add("0705")
                .Add("0705")
                .Add("0902")
                .Add("0902")
                .Add("1302")
                .Add("1302")
            End With
            Return _idList

        End Function


        'UNIMPLEMENTED：プリキュア牌固有のアルゴリズムになっているが、本来はもっと汎用的な処理として実装可能してCoreに入れるべき機能である
        ''' <summary>
        ''' ランダムかつオーソドックスなテンパイ手(順子ｘ３＋雀頭)のリストを生成して返します。
        ''' </summary>
        ''' <returns></returns>
        Private Function GetOrthodoxReadyHandAtRandom() As List(Of String)
            Dim _idList As New List(Of String)

            Dim _chowCount As Integer = 0
            Dim _choiceOfChow As Integer
            '順子4個をランダムに作成
            Dim _rand = New Random()
            While _chowCount <= 3

                'UNIMPLEMENTED：１１という数値をリテラルで与えるのではなく、PrecureConfig.xmlから取得した、最大作品IDをセットする仕組みを実装すべきである。（作品ID:12 はj9さんがキラプリ絵を仕上げるまで未使用のため作品IDのMAXは１１、そもそも将来のプリキュア作品増加に備えてここは１２決め打ちでなく、現在の作品IDのMAXを計算して渡すべきである）
                Dim _tileSuitsCount As Integer = Tiles.PrecureCharacterSet.GetInstance.TileSuitsCount
                Dim _suitID As Integer = _rand.Next(_tileSuitsCount)

                Select Case _suitID
                    Case 1, 11, 13
                        _choiceOfChow = 1
                    Case 4, 5, 6, 9, 10
                        _choiceOfChow = 2
                    Case 7, 8
                        _choiceOfChow = 3
                    Case 3, 12
                        _choiceOfChow = 4
                    Case 0, 2
                        'ナージャ、S☆Sは順子ができない
                        Continue While

                End Select
                Dim _branchNum As Integer

                If _choiceOfChow = 1 Then
                    _branchNum = 1
                Else
                    _branchNum = (New Random()).Next(_choiceOfChow) + 1
                End If

                With _idList
                    .Add(_suitID.ToString("00") & (_branchNum + 0).ToString("00"))
                    .Add(_suitID.ToString("00") & (_branchNum + 1).ToString("00"))
                    .Add(_suitID.ToString("00") & (_branchNum + 2).ToString("00"))
                End With

                _chowCount += 1

            End While

            '13枚になるように、先頭の1枚を除去
            _idList.RemoveAt(0)

            '雀頭は常に咲
            _idList.Add("0201")
            _idList.Add("0201")

            Return _idList
        End Function

        ''' <summary>
        ''' イーシャンテンの手を配牌します。
        ''' </summary>
        Public Sub DealHandNeedingTwoTIlesToComplete(comPlayer As COMPlayer)
            Dim _handNeedingTwoTIlesToComplete As List(Of String) = Me.GetReadyHandAtRandom()

            With _handNeedingTwoTIlesToComplete
                If _handNeedingTwoTIlesToComplete Is Nothing Then
                    For i As Integer = 0 To 13 - 1
                        Me.RoundManager.DrawTile(comPlayer)
                    Next
                Else
                    'イーシャンテンなのでテンパイ手から一個除外する
                    .Remove(.Last)
                    For Each _id As String In _handNeedingTwoTIlesToComplete

                        'Me.RoundManager.TryMoveTile(_id, RoundManager.WallPile, comPlayer.Hand)

                        '山から手牌に牌を加える
                        Dim _pickedTile As Tile = Me.RoundManager.PickOutTileFromPile(_id, RoundManager.WallPile)
                        If _pickedTile Is Nothing Then
                            '牌を引くのに失敗した（現在山に存在しない牌IDを指定した）場合、ログにエラー情報を吐く
                            logger.Error(" MoveTile Failed.[ID:" & _id & "] WallPile -> COM Hand")
                        Else
                            comPlayer.Hand.DrawTile(_pickedTile)
                        End If

                    Next
                    '1個除外した分、もう一枚引いておく
                    Me.RoundManager.DrawTile(comPlayer)
                End If
            End With

        End Sub
    End Class
End Namespace
