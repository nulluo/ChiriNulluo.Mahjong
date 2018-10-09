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
            Await DownLoadFilesAsync()
        End Sub

        Private Async Function DownLoadFilesAsync() As Task
            'UNIMPLEMENTED: 戻り値使って何かしないのかよ…
            Dim _isDownloadSuccess As Boolean = Await Release.DownloadAsync()
            Launcher.Execute()

        End Function

        Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
            Launcher.Execute()

        End Sub
    End Class

End Namespace