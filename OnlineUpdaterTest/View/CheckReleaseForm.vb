Imports System.IO
Imports System.Net.Http

Namespace View

    ''' <summary>
    ''' 最新バージョンの存在を確認しにサーバへ接続する間にユーザに表示する待機画面
    ''' </summary>
    Public Class CheckReleaseForm

        Private XMLFunction As New XMLFunc.XmlFunctions

        ''' <summary>
        ''' 画面ロード時処理
        ''' </summary>
        Private Sub InitialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim _targetPath As String = Path.Combine(My.Application.Info.DirectoryPath, "UpdateLog.xml")
            Dim _sourcePath As String = Path.Combine("http://", UpdateSite, UpdateID & ".xml")

            CheckIfNewVersionExistsAsync(_sourcePath, _targetPath)

        End Sub

        ''' <summary>
        ''' 最新バージョンが存在するか、サーバに接続して確認する。
        ''' </summary>
        ''' <param name="uri">最新バージョンが記載されたxmlファイルのURL</param>
        ''' <param name="outputPath">xmlファイルをローカル保存するときのパス</param>
        Private Async Sub CheckIfNewVersionExistsAsync(uri As String, outputPath As String)
            Dim _client As New HttpClient()
            Dim _response As HttpResponseMessage = Await _client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead)

            'Webからファイルダウンロード実行
            If Await DownLoader.DownloadFileAsync(uri, outputPath) Then

                'バージョンが最新かどうか確認
                'UpdateID.xmlの中から最新バージョン番号を取り出す。
                XMLFunction.OpenXMLDoc(outputPath)
                XMLFunction.XMLSNode("/updates")

                Dim totalUpdates As String
                totalUpdates = XMLFunction.GetNodeVal("total")

                '前回アップデートのバージョン番号とサーバ側の最新バージョン番号を比較
                If LastUpdate.LessThan(totalUpdates) Then

                    If MessageBox.Show("新しいバージョンがあります。ダウンロードしますか？", "アップデート",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        '最新バージョンダウンロード画面へ進む
                        Dim _nextForm As New DownloadForm()
                        Me.Hide()
                        _nextForm.Show()
                    Else
                        Launcher.Execute()
                    End If
                Else
                    Launcher.Execute()
                End If
            Else
                Launcher.Execute()
            End If



        End Sub

    End Class

End Namespace