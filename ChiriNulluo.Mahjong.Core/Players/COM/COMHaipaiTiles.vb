Namespace Players.COM

    Public Class COMHaipaiTiles

        ''' <summary>
        ''' 配牌する牌の組み合わせ
        ''' </summary>
        ''' <returns></returns>
        Public Property TileIDs As New List(Of String)

        ''' <summary>
        ''' 役の出現確率(この値に比例した頻度で役が出現する)
        ''' </summary>
        ''' <returns></returns>
        Public Property AppearanceRate As Integer

    End Class

End Namespace