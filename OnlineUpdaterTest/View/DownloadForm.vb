Imports System.IO
Imports System.Net.Http

Namespace View

    ''' <summary>
    ''' 初期画面(最新バージョンの存在を確認しにサーバへ接続する間にユーザに表示する待機画面)
    ''' </summary>
    Public Class DownloadForm

        Public Property LocalUpdateXML As String


        Private Sub DownloadNewVersionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DownLoadFiles()
        End Sub

        Private Async Sub DownLoadFiles()

            Dim _fileList As List(Of ReleasedFile)

            Dim xmlFunction As New XMLFunc.XmlFunctions(UpdateID & ".xml")
            _fileList = xmlFunction.GetFiles
            For Each ThisFile As ReleasedFile In _fileList
                'UNIMPLEMENTED: バージョンアップによって不要になったファイルがある可能性があるので、ローカルのファイルをフォルダから全削除
                'UNIMPLEMENTED: SaveData.xmlなど、削除してはいけないファイルは削除しない。

                Dim Updaterfile As String
                Updaterfile = Path.Combine(AppPath, ThisFile.LocalFilePath)

                Dim Serverfile As String
                Serverfile = Path.Combine("http://", UpdateSite, ThisFile.ServerFilePath)

                'UNIMPLEMENTED: できればダウンロード中のファイル名を表示したい。UIスレッドにアクセスする必要がある
                'Label1.Text = ThisFile.Name & "をサーバーからダウンロードしています。" & vbCrLf & "完了までお待ちください。"

                If File.Exists(Updaterfile) Then
                    File.Delete(Updaterfile)
                End If

                Await DownLoader.DownloadFileAsync(Serverfile, Updaterfile)
            Next

            Launcher.Execute()

        End Sub

    End Class

End Namespace