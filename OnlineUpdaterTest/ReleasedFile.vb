''' <summary>
''' アップデートで配信するファイル1個分の情報
''' </summary>
Public Class FileDetails

    ''' <summary>
    ''' ファイル名
    ''' </summary>
    Public Property Name() As String

    ''' <summary>
    ''' サーバ上のファイルパス
    ''' </summary>
    Public Property ServerFilePath() As String

    ''' <summary>
    ''' ローカルのファイルパス
    ''' </summary>
    Public Property LocalFilePath As String

End Class