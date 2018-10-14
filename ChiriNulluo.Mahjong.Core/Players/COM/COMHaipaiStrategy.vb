Namespace Players.COM
    Public Class COMHaipaiStrategy

        ''' <summary>
        ''' 純粋に完全ランダムに配牌する場合のコンストラクタ
        ''' </summary>
        Public Sub New()
            Me.IsRandom = True
        End Sub

        ''' <summary>
        ''' 一定確率で積み込み配牌する場合のコンストラクタ
        ''' </summary>
        ''' <param name="haipaiList"></param>
        Public Sub New(randomRate As Integer, haipaiList As List(Of COMHaipaiTiles))
            Me.IsRandom = False
            Me.HaipaiList = haipaiList
            Me.RandomRate = randomRate
        End Sub


        ''' <summary>
        ''' 完全にランダムに配牌する
        ''' </summary>
        Public Property IsRandom As Boolean

        ''' <summary>
        ''' HaipaiListからではなく、ランダム組み合わせの牌が配られる確率(0以上の整数値。この値に比例して出現確率が定まる)
        ''' </summary>
        ''' <returns></returns>
        Public Property RandomRate As Integer


        ''' <summary>
        ''' 出現確率に対応して、配牌を取得する。もしランダム配牌設定の場合はNothingを返す。
        ''' </summary>
        ''' <returns></returns>
        Public Function GetHaipaiTiles() As List(Of String)

            If IsRandom Then
                Return Nothing
            End If

            Dim r As New System.Random()
            Dim randomValue = r.Next(Me.SumAppearanceRate())
            Dim _subTotalAppearanceRate As Integer = 0

            For Each _haipai As COMHaipaiTiles In HaipaiList
                If randomValue < _haipai.AppearanceRate Then
                    Return _haipai.TileIDs
                Else
                    randomValue -= _haipai.AppearanceRate
                End If
            Next
            Return Nothing
        End Function

        Public Property HaipaiList As New List(Of COMHaipaiTiles)

        Private Function SumAppearanceRate() As Integer
            Return HaipaiList.Sum(Function(x) x.AppearanceRate) + Me.RandomRate
        End Function


    End Class

End Namespace