Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Core.Players.COM
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Players.COM
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Precure.Players

'UNIMPLEMENTED: MatchManagerControllerはあちこちのフォームでコンストラクタの引数に渡しているが、よく考えたらアプリケーション内で複数のMatchManagerControllerが作成されることはないのでシングルトン化してグローバルに触れるようにしていいはず
Public NotInheritable Class MatchManagerController
    Private Shared _instance As MatchManagerController

    Private Sub New()
        'Me.MatchManager = New MatchManager(1, 1)
        'Me.InnerInitializeMatch(COMStrategy.ToCompleteDealtReadyHand)

        Me.InnerInitializeMatch(New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount))

        'Me.InnerInitializeMatch(COMStrategy.ToBeFritenForTest)
    End Sub

    Private Sub New(comStrategy As COMStrategy)
        'Me.MatchManager = New MatchManager(1, 1)
        If comStrategy.COMDiscardTileStrategy = COMDiscardTileStrategy.ToCompleteDealtHandOneStepAwayFromReady Then
            Me.InnerInitializeMatch(New COMStrategy(COMDiscardTileStrategy.ToCompleteDealtHandOneStepAwayFromReady))
        ElseIf comStrategy.COMDiscardTileStrategy = COMDiscardTileStrategy.ToDecreaseShantenCount Then
            Me.InnerInitializeMatch(New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount))
            'Me.InnerInitializeMatch(COMStrategy.ToBeFritenForTest)

        Else
            'UNIMPLEMENTED：COMStrategy.Randomの場合も向聴数減少型のアルゴリズムになる事に注意（COMStrategy.Randomの場合の挙動が現在バグっているため）
            Me.InnerInitializeMatch(New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount))
        End If

    End Sub

    ''' <summary>
    ''' マッチを初期化する。(マッチ終了後、ゲーム初期画面から次のマッチを開始するときのために初期化が必要)
    ''' </summary>
    Public Shared Sub InitializeMatch()
        _instance = New MatchManagerController()
    End Sub

    Public Shared Function GetInstance（） As MatchManagerController
        If _instance Is Nothing Then
            _instance = New MatchManagerController()
        End If

        Return _instance
    End Function

    Friend Property OpponentManager As New OpponentManager

    Public Property MatchManager As MatchManager

    Public Property WallPile As New WallPile

    Public ReadOnly Property PlayersList As List(Of Players.Player)
        Get
            Return MatchManager.PlayersList
        End Get
    End Property

    Private Property PrecureSet As PrecureCharacterSet = PrecureCharacterSet.GetInstance()
    Private Shared logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()

#Region "Viewへ公開するメンバ"

    ''' <summary>
    ''' HUMAN手牌、COM手牌、山牌の構成を設定する
    ''' </summary>
    ''' <param name="humanHand"></param>
    ''' <param name="comHand"></param>
    ''' <param name="wallPile"></param>
    Public Sub InitializeRound(humanHand As Hand, comHand As Hand, wallPile As WallPile, revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))
        'Me.InitializeRound(COMStrategy.ToCompleteDealtReadyHand)

        Me.MatchManager.RoundManager = New RoundManager(Me.PlayersList, 0)

        'UNIMPLEMENTED：1番目のプレイヤーがCOMであることをこのクラスが知っていてそれを利用するというのは結合度が強すぎでは？
        Dim _com = DirectCast(Me.MatchManager.RoundManager.PlayersList(1), Players.COM.COMPlayer)

        '_com.Algorithm = New PrecureCOMPlayerAlgorithm(_com, Me.MatchManager.RoundManager, COMStrategy.ToBeFritenForTest)
        _com.Algorithm = New PrecureCOMPlayerAlgorithm(_com, Me.MatchManager.RoundManager, New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount))
        _com.PreviousShantenCount = 8
        'UNIMPLEMENTED: ここで  chirnulluo.mahjong.precure.ShantenCountMaxにアクセスしたいのだがうまくいかない
        'UNIMPLEMENTED: 仮に初期のPreviousShantenCountを8にしているが、配牌時の向聴数を計算してPreviousShantenCountプロパティを初期化するようにしないと、最初のツモで必ず牌を手から出して捨ててしまう

        PrecureCharacterSet.GetInstance.InitializeTileListForNewRound(revealedBonusTiles, unrevealedBonusTiles)
        'Me.MatchManager.RoundManager.WallPile.Clear()

        'HUMAN手牌構成
        Me.MatchManager.RoundManager.PlayersList(0).Hand = humanHand
        'Me.MatchManager.RoundManager.PlayersList(0).Hand.MainTiles.Sort()

        'COM手牌構成
        Me.MatchManager.RoundManager.PlayersList(1).Hand = comHand
        'Me.MatchManager.RoundManager.PlayersList(1).Hand.MainTiles.Sort()

        '山牌構成
        Me.MatchManager.RoundManager.WallPile = wallPile

    End Sub


    ''' <summary>
    ''' MatchManagerを初期化し、マッチを開始する。(クラス内部用メソッド)
    ''' </summary>
    ''' <remarks>本来はMatchManagerの呼び出しはCoreに持たせるべき機能である。</remarks>
    Private Sub InnerInitializeMatch(comStrategy As COMStrategy)

        Me.MatchManager = New MatchManager(1, 1)
        Me.MatchManager.PlayersList(0).Score = Constants.InitialScore
        Me.MatchManager.PlayersList(1).Score = Constants.InitialScore
        'Me.InitializeRound(comStrategy)
    End Sub



    Public Function InitializeRound(comStrategy As COMStrategy) As RoundManager

        Me.MatchManager.RoundManager = New RoundManager(Me.PlayersList, 0)

        'UNIMPLEMENTED: ここでWallPileくりあーしてから全プリキュア牌の取得するのはどうも違和感がある。New RoundManagerの中で、WallPileも初期化すべきでは・・・
        Me.WallPile.Clear()
        '全プリキュア牌の取得
        Try
            ' データを取得します。
            PrecureSet.InitializeTileListForNewRound()
            Dim _precureList = PrecureSet.CurrentRoundTotalTilesList
            For Each _precure As PreCureCharacterTile In _precureList
                '1種につき4枚用意する
                Me.WallPile.Add(_precure)
            Next

            'UNIMPLEMENTED：DBつかわなくなったからDBExceptionのキャッチ不要。むしろXMLのバグをはく
        Catch ex As System.Data.Common.DbException
            'UNIMPLEMENTED：なんらかのほうほうでろぐをはく
            logger.Error(ex)
        End Try
        Me.MatchManager.RoundManager.WallPile = Me.WallPile

        'UNIMPLEMENTED：1番目のプレイヤーがCOMであることをこのクラスが知っていてそれを利用するというのは結合度が強すぎでは？
        Dim _com = DirectCast(Me.MatchManager.RoundManager.PlayersList(1), Players.COM.COMPlayer)
        _com.Algorithm = New PrecureCOMPlayerAlgorithm(_com, Me.MatchManager.RoundManager, comStrategy)
        _com.PreviousShantenCount = 8
        'UNIMPLEMENTED: ここで  chirnulluo.mahjong.precure.ShantenCountMaxにアクセスしたいのだがうまくいかない
        'UNIMPLEMENTED: 仮に初期のPreviousShantenCountを8にしているが、配牌時の向聴数を計算してPreviousShantenCountプロパティを初期化するようにしないと、最初のツモで必ず牌を手から出して捨ててしまう

        Return Me.MatchManager.RoundManager
    End Function

    Public ReadOnly Property PrecureTileIDList As List(Of String)
        Get
            Return Me.PrecureSet.CurrentRoundTotalTilesIDList
        End Get
    End Property

    Public ReadOnly Property HumanPlayer As Players.HumanPlayer
        Get
            Return DirectCast(Me.MatchManager.PlayersList(0), Players.HumanPlayer)
        End Get
    End Property

    Public ReadOnly Property COMPlayer As Players.COM.COMPlayer
        Get
            Return DirectCast(Me.MatchManager.PlayersList(1), Players.COM.COMPlayer)
        End Get
    End Property
#End Region

End Class
