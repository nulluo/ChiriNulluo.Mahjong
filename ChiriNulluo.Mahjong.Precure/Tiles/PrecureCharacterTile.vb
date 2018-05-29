Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Tiles

    Public Class PreCureCharacterTile
        Inherits Tile

        Public Sub New(precureID As String, name As String)
            Me.ID = precureID
            Me.Name = name
            Me.SuitID = Left(precureID, 2)
            Me.Number = CInt(Right(precureID, 2))
        End Sub

        Public Sub New(suitID As String, number As String, name As String)
            Me.ID = suitID & number
            Me.Name = name
            Me.SuitID = suitID
            Me.Number = CInt(number)
        End Sub

        'UNIMPLEMENTED：この実装には問題がある。今はプリキュアしか牌がないからよいが、他のタイプの牌が混ざると、
        'プリキュア牌とバットマン牌が比較可能になってしまう。しかし、引数をTileMotif型から具体的なPrecureCharacterに変えてしまうと
        'Implementsにならなくなってしまうのでひとまずこのままにしてある
        Public Overrides Function IsSameColorWith(targetPrecure As Tile) As Boolean
            Return Me.SuitID = DirectCast(targetPrecure, PreCureCharacterTile).SuitID
        End Function

        Public Property SuitID As String
        Public Property Number As Integer

        Public ReadOnly Property Image As System.Drawing.Bitmap
            Get
                Return My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", Me.ID))
            End Get
        End Property

        Public ReadOnly Property EnlargedImage As System.Drawing.Bitmap
            Get
                Return My.Resources.ResourceManager.GetObject(String.Format("TileEnlarged{0:0000}", Me.ID))
            End Get
        End Property

    End Class

End Namespace