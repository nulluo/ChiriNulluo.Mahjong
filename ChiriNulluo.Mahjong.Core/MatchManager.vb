Imports ChiriNulluo.Mahjong.Core.Players
Imports ChiriNulluo.Mahjong.Core.Tiles

Public Class MatchManager

    'Public Sub New(humanPlayersNumber As Integer, cOMPlayersNumber As Integer, tiles As List(Of Tile), comPlayerAlogorithme As Players.COM.COMPlayerAlgorithm)
    Public Sub New(humanPlayersNumber As Integer, cOMPlayersNumber As Integer)

        Me.HumanPlayersNumber = humanPlayersNumber
        Me.PlayersList.AddRange(Enumerable.Range(0, Me.HumanPlayersNumber).Select(Function(index) New HumanPlayer).ToArray)

        Me.COMPlayersNumber = cOMPlayersNumber
        Me.PlayersList.AddRange(Enumerable.Range(0, Me.COMPlayersNumber).Select(Function(index) New COM.COMPlayer()).ToArray)

        Dim _humanPlayerIndexes(Me.HumanPlayersNumber - 1) As Integer
        For i As Integer = 0 To Me.HumanPlayersNumber - 1
            _humanPlayerIndexes(i) = i
        Next

        Me.RoundManager = New RoundManager(Me.PlayersList, _humanPlayerIndexes)

        MatchID = DateTime.Now.ToString("yyyy/MM/dd_hh:mm:ss_") & MatchIDSerialNumber.ToString("00")
        LogNoInMatch = 0
    End Sub

    Private Shared MatchIDSerialNumber As Integer = 0
    ''' <summary>
    ''' リプレイログ書き出し用のマッチID
    ''' </summary>
    Public Shared MatchID As String

    ''' <summary>
    ''' リプレイログ内でマッチ内のログを区別するためのID
    ''' </summary>
    Public Shared LogNoInMatch As Integer

    Public Property RoundManager As RoundManager

    Public Property PlayersList As New List(Of Player)

    Private Property COMPlayersNumber As Integer

    Private Property HumanPlayersNumber As Integer

    Public Property RoundsCount As Integer = 0

    'Private Property WallPile As WallPile

    Public Sub DrawTile(player As Player)
        Me.RoundManager.DrawTile(player)
    End Sub

    ''' <summary>
    ''' DrawTileの動作確認用のテストメソッド。牌を引くプレイヤーはPlayersList(0)固定
    ''' </summary>
    Public Sub DrawTileForPlayer0()
        Me.DrawTile(Me.PlayersList(0))
    End Sub

    Public Sub DiscardTile(player As Player, discardedTile As Tile)
        Me.RoundManager.DiscardTile(player, discardedTile)
    End Sub

    ''' <summary>
    ''' DiscardTileの動作確認用のテストメソッド。牌を捨てるプレイヤーはPlayersList(0)固定
    ''' </summary>
    Public Sub DiscardTileForPlayer0(discardedTile As Tile)
        Me.RoundManager.DiscardTile(Me.PlayersList(0), discardedTile)
    End Sub

    ''' <summary>
    ''' 初期手牌を配る（配牌）
    ''' </summary>
    ''' <param name="player">手牌を配る対象のプレイヤー</param>
    Public Sub DealInitialHand(player As Player)
        Me.RoundManager.DealInitialHand(player)
    End Sub

    ''' <summary>
    ''' DealInitialHand の動作確認用のテストメソッド。プレイヤーはPlayersList(0)固定.親固定
    ''' </summary>
    Public Sub DealInitialHandForPlayer0()
        Me.RoundManager.DealInitialHand(Me.PlayersList(0))
    End Sub

    'UNIMPLEMENTED: PlayersListを外部に公開するのはバッドノウハウだと思ってこうしたけど、GetterとSetter両方用意するってむしろクソコード感増してない？
    ''' <summary>
    ''' <c>index</c>番目のプレイヤーの点数を取得する。
    ''' </summary>
    ''' <param name="index">プレイヤーのインデックス</param>
    ''' <returns><c>index</c>番目のプレイヤーの点数</returns>
    Public Function GetPlayerScore(index As Integer) As Integer
        Return Me.PlayersList(index).Score
    End Function


    'UNIMPLEMENTED: PlayersListを外部に公開するのはバッドノウハウだと思ってこうしたけど、GetterとSetter両方用意するってむしろクソコード感増してない？
    ''' <summary>
    ''' <c>index</c>番目のプレイヤーの点数を設定する。
    ''' </summary>
    ''' <param name="index">プレイヤーのインデックス</param>
    ''' <param name="value"><c>index</c>番目のプレイヤーの点数</param>
    Public Sub SetPlayerScore(index As Integer, value As Integer)
        Me.PlayersList(index).Score = value
    End Sub

End Class
