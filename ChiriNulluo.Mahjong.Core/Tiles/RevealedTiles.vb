Namespace Tiles

    ''' <summary>
    ''' 敵に公開している組になる3枚の牌(副露、すなわちポンまたはチーした牌)を表すクラス。
    ''' </summary>
    Public Class RevealedTiles
        Inherits Pile

        'UNIMPLEMENTED：カンをありにするならこれはBoolean（二値）では対応できなくなる
        Public Property IsTriplet As Boolean = False

        Public Property TileDiscardedByOpponent As Tile

        Public ReadOnly Property MyTile0 As Tile

        Public ReadOnly Property MyTile1 As Tile

        Public ReadOnly Property OpponentsTile As Tile


        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="isTriplet">3枚の同一牌からなる組(刻子)であるかどうか。</param>
        ''' <param name="myTile0">自分の手牌から出した牌1</param>
        ''' <param name="myTile1">自分の手牌から出した牌2</param>
        ''' <param name="opponentsTile">対戦相手の捨て牌から拾った牌</param>
        Public Sub New(isTriplet As Boolean, myTile0 As Tile, myTile1 As Tile, opponentsTile As Tile)
            If isTriplet Then
                If myTile0.ID = myTile1.ID AndAlso myTile1.ID = opponentsTile.ID Then
                    Me.IsTriplet = True
                Else
                    Throw New ArgumentException("MyTile1 and myTile2 and opponentsTile are not Triplet.")
                End If
            Else
                Me.IsTriplet = False
            End If

            Me.Add(myTile0)
            Me.Add(myTile1)
            Me.Add(opponentsTile)

            Me._MyTile0 = myTile0
            Me._myTile1 = myTile1
            Me._opponentsTile = opponentsTile

            Me.TileDiscardedByOpponent = opponentsTile
            Me.Sort()

            If Not Me.IsTriplet Then
                Dim _firstTileID As Integer = CInt(Me.Item(0).ID)
                Dim _secondTileID As Integer = CInt(Me.Item(1).ID)
                Dim _thirdTileID As Integer = CInt(Me.Item(2).ID)

                'UNIMPLEMENTED：本来1099,1100みたいなケースもあるからこれで正しい順子判定になってないんだけど一色の中に99個も牌があることなんてないよね…？
                If Not (_firstTileID + 1 = _secondTileID AndAlso _secondTileID + 1 = _thirdTileID) Then
                    Throw New ArgumentException("MyTile1 and myTile2 and opponentsTile are not Chow.")
                End If

            End If


        End Sub
    End Class


End Namespace