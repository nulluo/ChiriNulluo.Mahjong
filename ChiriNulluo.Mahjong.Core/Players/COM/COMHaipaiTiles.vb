Namespace Players.COM

    Public Class COMHaipaiTiles

        Public Sub New(appearanceRate As Integer, tile01 As String, tile02 As String,
                       tile03 As String, tile04 As String, tile05 As String, tile06 As String,
                       tile07 As String, tile08 As String, tile09 As String, tile10 As String,
                       tile11 As String, tile12 As String, tile13 As String)

            Me.AppearanceRate = appearanceRate
            With TileIDs
                .Add(tile01)
                .Add(tile02)
                .Add(tile03)
                .Add(tile04)
                .Add(tile05)
                .Add(tile06)
                .Add(tile07)
                .Add(tile08)
                .Add(tile09)
                .Add(tile10)
                .Add(tile11)
                .Add(tile12)
                .Add(tile13)
            End With
        End Sub
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