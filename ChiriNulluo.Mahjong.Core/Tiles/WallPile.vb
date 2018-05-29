Namespace Tiles

    Public Class WallPile
        Inherits Pile

        Public Function PopNextDraw() As Tile

            Dim _nextDraw As Tile = MyBase.Last
            MyBase.Remove(_nextDraw)
            Return _nextDraw

        End Function

    End Class

End Namespace