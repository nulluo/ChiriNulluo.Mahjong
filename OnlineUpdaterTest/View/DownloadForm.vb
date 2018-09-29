Imports System.IO
Imports System.Net.Http

Namespace View

    ''' <summary>
    ''' 初期画面(最新バージョンの存在を確認しにサーバへ接続する間にユーザに表示する待機画面)
    ''' </summary>
    Public Class DownloadForm

        Private Property LocalUpdateXML As String
        Private Property Release As Release = Release.Instance

        Private Async Sub DownloadNewVersionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Await DownLoadFiles()
        End Sub

        Private Async Function DownLoadFiles() As Task

            Dim _isDownloadSuccess As Boolean = Await Release.Download()
            Launcher.Execute()

        End Function

    End Class

End Namespace