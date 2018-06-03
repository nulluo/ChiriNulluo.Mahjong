Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Yaku
    Public Class Yaku
        Public Property Name As String

        Public Property [Type] As YakuType

        Public Property Point As Integer

        Public Property TileSet As List(Of String)

        'ここで引数無しのコンストラクタを定義しておかないと継承先のPrecureYakuクラスでエラーが出るため、ダミーで定義しておく
        Public Sub New()
        End Sub

        Public Sub New(name As String, type As YakuType, point As Integer, tileSet As List(Of String))
            Me.Name = name
            Me.Type = type
            Me.Point = point
            Me.TileSet = tileSet
        End Sub
        ''' <summary>
        ''' 役の条件を満たしているかどうかを判定する。(手牌以外要素依存役は判定できない。アガリ形になっているかどうかは考慮していない)
        ''' </summary>
        ''' <param name="hand">判定対象の手牌</param>
        ''' <returns>役が成立している場合はTrue,そうでない場合はFalseを返す。牌が13枚以下の場合は必ずFalseを返す。手牌以外要素依存役は判定できないため、Nothingを返す。</returns>
        Public Function IsAccomplished(hand As Hand) As Boolean
            If hand.TotalCount <= 13 Then
                Return False
            End If

            If Me.Type.HasFlag(YakuType.SpecificTileSetIsSubSetOfHand) Then
                Return Me.IncludesWholeTileSet(hand)
            ElseIf Me.Type.HasFlag(YakuType.HandIsSubSetOfSpecificTileSet)
                Return Me.IsEveryTileIncludedOfTileSet(hand)
            Else
                Return Nothing
            End If

        End Function


        ''' <summary>
        ''' 手牌が特定の牌セット全てを含んでいるかどうかを判定する。
        ''' </summary>
        ''' <param name="hand">手牌</param>
        ''' <returns>手牌が特定の牌セット全てを含んでいるかどうか。</returns>
        Private Function IncludesWholeTileSet(hand As Hand) As Boolean
            Dim _exceptionFound As Boolean = False
            For Each _idInTileSet As String In TileSet
                If (From _tileInHand In hand.TotalTiles Where _idInTileSet = _tileInHand.ID).Count = 0 Then
                    _exceptionFound = True
                    Exit For
                End If
            Next
            Return Not _exceptionFound
        End Function

        ''' <summary>
        ''' 手牌の全ての牌が、特定の牌セットに含まれる牌であるかどうかを判定する。
        ''' </summary>
        ''' <param name="hand">手牌</param>
        ''' <returns>手牌の全ての牌が、特定のタイルのセットに含まれる牌であるかどうか</returns>
        Private Function IsEveryTileIncludedOfTileSet(hand As Hand) As Boolean
            Dim _exceptionFound As Boolean = False
            For Each _tileInHand As Tile In hand.TotalTiles
                If (From _idInTileSet In TileSet Where _tileInHand.ID = _idInTileSet).Count = 0 Then
                    _exceptionFound = True
                    Exit For
                End If
            Next
            Return Not _exceptionFound
        End Function

    End Class
End Namespace