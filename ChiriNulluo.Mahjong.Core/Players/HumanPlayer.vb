Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Players

    Public Class HumanPlayer
        Inherits Player

        Public Overrides Sub DeallInitialHand(wallPile As WallPile)

            For i As Integer = 0 To 13 - 1
                Dim _tile As Tile = wallPile.Last
                Me.DrawTile(_tile)
                wallPile.Remove(_tile)
            Next

        End Sub
    End Class

End Namespace