Imports System.Linq
Imports ChiriNulluo.Mahjong.Core.Players
Imports ChiriNulluo.Mahjong.Core.Tiles

Public Class RoundManager

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="playersList">プレイヤーのリスト</param>
    ''' <param name="humanPlayerIndexes">プレイヤーのうち、HUMANであるもののインデックス</param>
    Public Sub New(playersList As List(Of Player), ParamArray humanPlayerIndexes() As Integer)

        playersList.ForEach(Sub(x)
                                x.InitializeHand()
                                x.DiscardedPile.Clear()
                                x.RiichiDone = False
                                x.IgnoredWinningTileFromAnotherAfterRiichi = False
                            End Sub)
        Me.PlayersList = playersList

        Me.HumanPlayersIndexes = humanPlayerIndexes

    End Sub

#Region "Property"

    Public ReadOnly Property HumanPlayers As List(Of Player)
        Get
            Dim _list As New List(Of Player)
            For _index As Integer = 0 To Me.PlayersList.Count - 1
                If Me.HumanPlayersIndexes.Contains(_index) Then
                    _list.Add(Me.PlayersList(_index))
                End If
            Next

            Return _list
        End Get
    End Property

    Public ReadOnly Property COMPlayers As List(Of Player)
        Get
            Dim _list As New List(Of Player)
            For _index As Integer = 0 To Me.PlayersList.Count - 1
                If Not Me.HumanPlayersIndexes.Contains(_index) Then
                    _list.Add(Me.PlayersList(_index))
                End If
            Next

            Return _list
        End Get
    End Property

    Public Property PlayersList As New List(Of Player)

    Public Property WallPile As WallPile

    Public Property TurnCount As Integer

    Public Property PossibleTatsuListWhichCanMakeChowIfDiscaredTileAdded As List(Of List(Of String)) = Nothing

    Private Property HumanPlayersIndexes As Integer()
#End Region

    ''' <summary>
    ''' 牌をシャッフルする。(洗牌)
    ''' </summary>
    Public Sub ShuffleWall()
        'UNIMPLEMENTED：よく考えたら牌交換を実装してるからここでそれを使えばいいのでは？
        'Fisher-Yatesアルゴリズムでシャッフルする 
        Dim _rand As New System.Random()

        Dim _length As Integer = Me.WallPile.Count

        With Me.WallPile
            While _length > 1
                _length -= 1
                Dim k As Integer = _rand.Next(_length + 1)
                Dim _temp As Tile = .Item(k)
                .Item(k) = .Item(_length)
                .Item(_length) = _temp
            End While
        End With
    End Sub

    ''' <summary>
    ''' 指定したIDに一致する牌を山の先頭から検索し、最初に見つかった牌の参照を返す。
    ''' </summary>
    ''' <param name="id">検索する牌のID</param>
    ''' <param name="pile">検索対象のPile</param>
    ''' <returns>見つかった牌の参照。一致する牌が存在しない場合、Nothingを返す。</returns>
    Public Function SearchTile(id As String, pile As Pile) As Tile
        Return pile.SearchTile(id)
    End Function

    ''' <summary>
    ''' 指定したIDに一致する牌を山の先頭から検索し、最初に見つかった牌を山から取り出す。
    ''' 末尾まで検索してもIDと一致する牌が見つからない場合はNothingを返す。
    ''' </summary>
    ''' <param name="id">牌ID</param>
    ''' <return>取り出された牌</return>
    ''' <remarks>山の末尾：次にツモられる牌,山の先頭：ツモ順で一番ラストになる牌よりさらに先のツモられない牌の末尾</remarks>
    Public Function PickOutTileFromWall(id As String) As Tile
        Return Me.PickOutTileFromPile(id, Me.WallPile)
    End Function

    ''' <summary>
    ''' 指定したIDに一致する牌をPileの先頭から検索し、最初に見つかった牌をPileから取り出す。
    ''' 末尾まで検索してもIDと一致する牌が見つからない場合はNothingを返す。
    ''' </summary>
    ''' <param name="id">牌ID</param>
    ''' <return>取り出された牌</return>
    Public Function PickOutTileFromPile(id As String, pile As Pile) As Tile
        Dim _foundTile As Tile
        _foundTile = Me.SearchTile(id, pile)
        pile.Remove(_foundTile)
        Return _foundTile
    End Function

    'UNIMPLEMENTED：牌の参照を渡して現在の山から取り出すメソッドは作れないの？
    'UNIMPLEMENTED：Tileは自信が所属するPileへの参照を持っていないので、全てのPileを対象にサーチかければ可能だが面倒くさい


    ''' <summary>
    ''' 牌をPileから取り出し、別のPileの末尾へ移動する。
    ''' </summary>
    ''' <param name="tileID">取り出す牌のID</param>
    ''' <param name="fromPile">移動元のPile</param>
    ''' <param name="toPile">移動先のPile</param>
    ''' <return>移動が完了した場合はTrue、該当のID牌がPileから取り出せない場合はFalse。</return>
    Public Function TryMoveTile(tileID As String, fromPile As Pile, toPile As Pile) As Boolean
        Dim _tile As Tile = Me.PickOutTileFromPile(tileID, fromPile)
        If _tile Is Nothing Then
            Return False
        Else
            Me.AddTile(_tile, toPile)
            Return True
        End If
    End Function

    Public Sub ExchangeTiles(pile1 As Pile, index1 As Integer, pile2 As Pile, index2 As Integer)
        Throw New NotImplementedException()
    End Sub

    Public Sub DrawTile(player As Player)
        'Me.AddTile(WallPile.PopNextDraw, player.Hand)
        player.DrawTile(WallPile.PopNextDraw)
    End Sub

    ''' <summary>
    ''' Pileの末尾にTileを追加する。
    ''' </summary>
    ''' <param name="tile">追加する牌</param>
    ''' <param name="pile">追加先のPile</param>
    Public Sub AddTile(tile As Tile, pile As Pile)
        pile.Add(tile)
    End Sub

    Friend Sub DiscardTile(player As Player, discardedTile As Tile)
        player.DiscardTile(discardedTile)
    End Sub


    ''' <summary>
    ''' 初期手牌を配る（配牌）
    ''' </summary>
    ''' <param name="player">手牌を配る対象のプレイヤー</param>
    Public Sub DealInitialHand(player As Player)
        player.DeallInitialHand(Me.WallPile)

    End Sub

End Class
