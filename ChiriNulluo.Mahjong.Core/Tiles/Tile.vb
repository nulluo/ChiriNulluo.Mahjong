Namespace Tiles

    Public MustInherit Class Tile
        Implements IComparable

        Public Sub New()

        End Sub

        Property ID As String
        Property Name As String

        ''' <summary>
        ''' ポンまたはチーによって副露されているかどうかを設定または取得します。
        ''' </summary>
        ''' <returns>ポンまたはチーによって副露されているかどうか。</returns>
        Property IsRevealedForPongOrChow As Boolean = False

        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            If obj Is Nothing Then
                Return 1
            End If

            '違う型とは比較できない
            If Not Me.GetType() Is obj.GetType() Then
                Throw New ArgumentException("Cannot compare to different type object.", "obj")
            End If

            Return CInt(Me.ID) - CInt(DirectCast(obj, Tile).ID)
        End Function

        Public MustOverride Function IsSameColorWith(tile As Tile) As Boolean

    End Class

End Namespace
