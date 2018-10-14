Namespace Players.COM
    Public Class COMHaipaiStrategy


        Public Sub New()
            Me.IsRandom = True
        End Sub

        ''' <summary>
        ''' 完全にランダムに配牌する
        ''' </summary>
        Public Property IsRandom As Boolean

        ''' <summary>
        ''' 出現確率に対応して、配牌を取得する。もしランダム配牌設定の場合はNothingを返す。
        ''' </summary>
        ''' <returns></returns>
        Public Function GetHaipaiTiles() As List(Of String)

            If IsRandom Then
                Return Nothing
            End If

            Dim r As New System.Random(Me.AppearanceRate())
            Dim randomValue = r.Next
            Dim _subTotalAppearanceRate As Integer = 0

            For Each _haipai As COMHaipaiTiles In HaipaiList
                If randomValue < _haipai.AppearanceRate Then
                    Return _haipai.TileIDs
                Else
                    randomValue -= _haipai.AppearanceRate
                End If
            Next
            Return HaipaiList.Last.TileIDs
        End Function

        Public Property HaipaiList As New List(Of COMHaipaiTiles)

        Private Function AppearanceRate() As Integer
            Return HaipaiList.Sum(Function(x) x.AppearanceRate)
        End Function


    End Class

End Namespace