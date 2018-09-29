﻿Imports System.IO
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

    ''' <summary>
    ''' バージョン番号
    ''' </summary>
    ''' <returns>バージョン番号</returns>
    Private Property Version As String


    'UNIMPLEMENTED: Publicはまずくないか
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
                Me.Version = _xmlReader.GetAttributeValue("/updates", "total")

                '前回アップデートのバージョン番号とサーバ側の最新バージョン番号を比較
                If LastUpdate.LessThan(Me.Version) Then
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

        Try

            Dim xmlFunction As New XmlReader(UpdateID & ".xml")
            Me.Files = xmlFunction.GetFiles
            For Each ThisFile As ReleasedFile In Me.Files
                'UNIMPLEMENTED: バージョンアップによって不要になったファイルがある可能性があるので、ローカルのファイルをフォルダから全削除
                'UNIMPLEMENTED: SaveData.xmlなど、削除してはいけないファイルは削除しない。

                Dim Updaterfile As String
                Updaterfile = Path.Combine(AppPath, ThisFile.LocalFilePath)

                Dim Serverfile As String
                Serverfile = Path.Combine("http://", UpdateSite, ThisFile.ServerFilePath)

                'UNIMPLEMENTED: できればダウンロード中のファイル名を表示したい。UIスレッドにアクセスする必要がある
                'Label1.Text = ThisFile.Name & "をサーバーからダウンロードしています。" & vbCrLf & "完了までお待ちください。"
                'UNIMPLEMENTED: 途中でネットワーク切断された時のために、ファイルはいったん別のフォルダにダウンロードしておいて、全ファイル落とせた時点で元ファイルと総入れ替えする方がよさそう
                If File.Exists(Updaterfile) Then
                    File.Delete(Updaterfile)
                End If

                Await DownLoader.DownloadFileAsync(Serverfile, Updaterfile)
            Next
            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function


#End Region

End Class
