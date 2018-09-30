Imports System.IO
Imports System.Net.Http

'UNIMPLEMENTED: サーバ接続に一定時間以上経つと接続あきらめる設定が必要？

''' <summary>
''' 現在の最新リリースバージョンの情報
''' </summary>
Public Class Release

    Private Sub New()
        'シングルトン実現のため、コンストラクタを隠蔽
    End Sub

#Region "Property"

    Private Shared _instance As Release
    Public Shared ReadOnly Property Instance As Release
        Get
            If _instance Is Nothing Then
                _instance = New Release()
            End If
            Return _instance
        End Get
    End Property

    ''' <summary>
    ''' The Applications Root Path "C:\Dir1\Dir2" (No trailing backslash)
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property ApplicationPath As String = My.Application.Info.DirectoryPath

    ''' <summary>
    ''' バージョン番号
    ''' </summary>
    ''' <returns>バージョン番号</returns>
    Private Property Version As String


    ''' <summary>
    ''' リリースに含まれるファイルのリスト
    ''' </summary>
    ''' <returns>リリースに含まれるファイルのリスト</returns>
    Private Property Files As List(Of ReleasedFile)

#End Region


#Region "Method"
    ''' <summary>
    ''' ローカルファイルよりもバージョンが新しい場合にTrue,そうでない場合はFalse。
    ''' </summary>
    ''' <returns>ローカルファイルよりもバージョンが新しい場合にTrue,そうでない場合はFalse。</returns>
    Public Async Function IsNewerThanLocalFileAsync() As Task(Of Boolean)

        Try

            '最新バージョンが記載されたxmlファイルのURL
            Dim _targetPath As String = Path.Combine(My.Application.Info.DirectoryPath, My.Settings.LocalReleaseInfoXMLFIleWithExtension)

            'xmlファイルをローカル保存するときのパス
            Dim _sourcePath As String = Path.Combine(My.Settings.ReleaseSite, My.Settings.ServerReleaseInfoXMLFIleWithExtension)

            Dim _client As HttpClient = HttpClientFactory.Client
            Dim _response As HttpResponseMessage = Await _client.GetAsync(_sourcePath, HttpCompletionOption.ResponseHeadersRead)

            'Webからファイルダウンロード実行
            Dim _isDownloadSuccess As Boolean
            _isDownloadSuccess = Await DownLoader.DownloadFileAsync(_sourcePath, _targetPath)

            If _isDownloadSuccess Then

                Dim _xmlReader As New XmlReader(My.Settings.LocalReleaseInfoXMLFIleWithExtension)

                'バージョンが最新かどうか確認
                'UpdateID.xmlの中から最新バージョン番号を取り出す。
                Me.Version = _xmlReader.GetAttributeValue("/updates", "total")

                '前回アップデートのバージョン番号とサーバ側の最新バージョン番号を比較
                If My.Settings.LastUpdate.LessThan(Me.Version) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return False

        End Try

    End Function


    ''' <summary>
    ''' リリースファイル全てをダウンロードする。
    ''' </summary>
    ''' <return>リリースファイルの全てがダウンロード成功した場合にTrue、そうでない場合はFalse。</return>
    Public Async Function Download() As Task(Of Boolean)

        Dim _tempDirPath As String = Path.Combine(ApplicationPath, My.Settings.TempDir)
        Dim _mainProgramDirPath As String = Path.Combine(ApplicationPath, My.Settings.MainProgramDir)

        Try
            'ファイルダウンロード先のフォルダ「temp」を用意
            If Directory.Exists(_tempDirPath) Then
                Directory.Delete(_tempDirPath, True)
            End If
            Directory.CreateDirectory(_tempDirPath)

            Dim xmlFunction As New XmlReader(My.Settings.LocalReleaseInfoXMLFIleWithExtension)
            Me.Files = xmlFunction.GetReleaseFiles
            For Each ThisFile As ReleasedFile In Me.Files
                'UNIMPLEMENTED: SaveData.xmlなど、削除してはいけないファイルは削除しない。

                Dim LocalFile As String
                LocalFile = Path.Combine(ApplicationPath, My.Settings.TempDir, ThisFile.LocalFilePath)

                Dim Serverfile As String
                Serverfile = Path.Combine(My.Settings.ReleaseSite, ThisFile.ServerFilePath)

                'UNIMPLEMENTED: できればダウンロード中のファイル名を表示したい。UIスレッドにアクセスする必要がある
                'Label1.Text = ThisFile.Name & "をサーバーからダウンロードしています。" & vbCrLf & "完了までお待ちください。"

                Await DownLoader.DownloadFileAsync(Serverfile, LocalFile)
            Next

            'フォルダ「temp」内に全てのリリースファイルがダウンロード完了した時点で実ファイルの置き換えを開始する
            If Directory.Exists(_mainProgramDirPath) Then
                Directory.Delete(_mainProgramDirPath, True)
            End If

            If Directory.Exists(_tempDirPath) Then
                Directory.Move(_tempDirPath, _mainProgramDirPath)
            End If


            My.Settings.LastUpdate = Me.Version
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return False
        Finally
            If Directory.Exists(_tempDirpath) Then
                Directory.Delete(_tempDirPath, True)
            End If
        End Try

    End Function


#End Region

End Class
