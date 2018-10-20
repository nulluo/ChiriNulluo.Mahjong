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
        ''' <param name="haipaiList">一定の確率に従って配られる配牌の牌リスト</param>
        ''' <param name="perfectRandomRate">HaipaiListからではなく、完全にランダムな組み合わせの牌が配られる確率</param>
        ''' <remarks>～Rateの値はそれぞれ0以上の整数値をとる。この値に比例して出現確率が定まる</remarks>
        Public Sub New(haipaiList As List(Of COMHaipaiTiles), perfectRandomRate As Integer)
            Me.IsRandom = False
            Me.HaipaiList = haipaiList
            Me.PerfectRandomRate = perfectRandomRate
        End Sub

        ''' <summary>
        ''' 一定確率で積み込み配牌する場合のコンストラクタ
        ''' </summary>
        ''' <param name="haipaiList">一定の確率に従って配られる配牌の牌リスト</param>
        ''' <param name="perfectRandomRate">HaipaiListからではなく、完全にランダムな組み合わせの牌が配られる確率</param>
        ''' <param name="randomTenpaiRate">HaipaiListからではなく、ランダムな一向聴手の手牌が配られる確率</param>
        ''' <remarks>～Rateの値はそれぞれ0以上の整数値をとる。この値に比例して出現確率が定まる</remarks>
        Public Sub New(haipaiList As List(Of COMHaipaiTiles), perfectRandomRate As Integer, randomTenpaiRate As Integer, Optional randomIishantenRate As Integer = 0)
            Me.IsRandom = False
            Me.HaipaiList = haipaiList
            Me.PerfectRandomRate = perfectRandomRate
            Me.RandomTenpaiRate = randomTenpaiRate
            Me.RandomIishantenRate = randomIishantenRate
        End Sub


        ''' <summary>
        ''' 完全にランダムに配牌する
        ''' </summary>
        Public Property IsRandom As Boolean

        ''' <summary>
        ''' HaipaiListからではなく、完全にランダムな組み合わせの牌が配られる確率(0以上の整数値。この値に比例して出現確率が定まる)
        ''' </summary>
        ''' <returns></returns>
        Public Property PerfectRandomRate As Integer = 0

        ''' <summary>
        ''' HaipaiListからではなく、ランダムなテンパイ手の手牌が配られる確率(0以上の整数値。この値に比例して出現確率が定まる)
        ''' </summary>
        ''' <returns></returns>
        Public Property RandomTenpaiRate As Integer = 0


        '''' <summary>
        '''' HaipaiListからではなく、ランダムな一向聴手の手牌が配られる確率(0以上の整数値。この値に比例して出現確率が定まる)
        '''' </summary>
        '''' <returns></returns>
        Public Property RandomIishantenRate As Integer = 0



        Public Property HaipaiList As New List(Of COMHaipaiTiles)

        Public Function SumAppearanceRate() As Integer
            Return HaipaiList.Sum(Function(x) x.AppearanceRate) + Me.PerfectRandomRate + Me.RandomTenpaiRate
        End Function


    End Class

End Namespace