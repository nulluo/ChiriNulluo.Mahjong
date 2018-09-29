Imports System.IO
Imports System.Net.Http

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


    'UNIMPLEMENTED: Publicはまずくないか
    ''' <summary>
    ''' リリースに含まれるファイルのリスト
    ''' </summary>
    ''' <returns>リリースに含まれるファイルのリスト</returns>
    Public Property Files As List(Of ReleasedFile)

    ''' <summary>
    ''' バージョン番号
    ''' </summary>
    ''' <returns>バージョン番号</returns>
    Public Property Version As String


#End Region


#Region "Method"
    ''' <summary>
    ''' ローカルファイルよりもバージョンが新しい場合にTrue,そうでない場合はFalse。
    ''' </summary>
    ''' <returns>ローカルファイルよりもバージョンが新しい場合にTrue,そうでない場合はFalse。</returns>
    Public Async Function IsNewerThanLocalFile（） As Task(Of Boolean)

        Try

            '最新バージョンが記載されたxmlファイルのURL
            Dim _targetPath As String = Path.Combine(My.Application.Info.DirectoryPath, "UpdateLog.xml")

            'UNIMPLEMENTED: 強引なパス結合
            'xmlファイルをローカル保存するときのパス
            Dim _sourcePath As String = Path.Combine("http://", UpdateSite & "/" & UpdateID & ".xml")

            'UNIMPLEMENTED: HttpClientは何個もNewしない
            Dim _client As New HttpClient()
            Dim _response As HttpResponseMessage = Await _client.GetAsync(_sourcePath, HttpCompletionOption.ResponseHeadersRead)

            'Webからファイルダウンロード実行
            Dim _isDownloadSuccess As Boolean
            _isDownloadSuccess = Await DownLoader.DownloadFileAsync(_targetPath, _sourcePath)

            If _isDownloadSuccess Then

                Dim _xmlReader As New XmlReader(UpdateID & ".xml")


                'バージョンが最新かどうか確認
                'UpdateID.xmlの中から最新バージョン番号を取り出す。
                Dim totalUpdates As String
                totalUpdates = _xmlReader.GetAttributeValue("/updates", "total")

                '前回アップデートのバージョン番号とサーバ側の最新バージョン番号を比較
                If LastUpdate.LessThan(totalUpdates) Then
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
    Public Sub Download()

    End Sub


#End Region

End Class
