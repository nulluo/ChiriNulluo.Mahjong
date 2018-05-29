Imports ChiriNulluo.Mahjong.Precure.Tiles

Public NotInheritable Class TileImageManager

    Private Shared _instance As TileImageManager

    Private Sub New()
        PrecureCharacterSet.GetInstance.TileIDList.ForEach(Sub(x) TileImages.Add(x,
           DirectCast(My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", x)),
           System.Drawing.Bitmap)))

    End Sub

    Public Shared Function GetInstance() As TileImageManager
        If _instance Is Nothing Then
            _instance = New TileImageManager()
        End If
        Return _instance
    End Function

    Public Property TileImages As New Dictionary(Of String, System.Drawing.Bitmap)

End Class
