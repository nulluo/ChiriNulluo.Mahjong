
''' <summary>
''' アップデートで配信するフォルダの情報
''' </summary>
Public Class ReleasedFolder


    ''' <summary>
    ''' フォルダパス(ルートからの相対パス)
    ''' </summary>
    Public Property Path As String

    ''' <summary>
    ''' このフォルダ直下に配置されるファイルのリスト
    ''' </summary>
    ''' <returns>このフォルダ直下に配置されるファイルのリスト</returns>
    Public ReadOnly Property Files As New List(Of ReleasedFile)


    Public Sub AddFile(item As ReleasedFile)
        Me.Files.Add(item)
    End Sub

    Public Sub RemoveFile(item As ReleasedFile)
        Me.Files.Remove(item)
    End Sub
End Class
