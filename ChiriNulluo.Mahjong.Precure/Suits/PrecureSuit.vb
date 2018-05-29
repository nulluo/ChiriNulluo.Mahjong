Imports ChiriNulluo.Mahjong.Precure.DataAccess

Namespace Suits

    ''' <summary>
    ''' プリキュア牌のスート(作品を表す)
    ''' </summary>
    Public Class PrecureSuit


        ''' <summary>
        ''' 作品ID
        ''' </summary>
        ''' <returns>作品ID</returns>
        Public Property ID As String


        ''' <summary>
        ''' 作品名称
        ''' </summary>
        ''' <returns>作品名称</returns>
        Public Property Name As String

        ''' <summary>
        ''' 作品中に含まれる牌の総数
        ''' </summary>
        ''' <returns>作品中に含まれる牌の総数</returns>
        Public Property TotalTilesCount As Integer

    End Class

End Namespace