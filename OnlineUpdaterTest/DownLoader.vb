Imports System.IO
Imports System.Net.Http
''' <summary>
''' サーバからファイルをダウンロードする(非同期処理対応)
''' </summary>
Public Class DownLoader

    ''' <summary>
    ''' 非同期的にサーバからファイルをダウンロードする
    ''' </summary>
    ''' <param name="serverPath">サーバ上のファイルURL</param>
    ''' <param name="localPath">ローカルのファイルパス</param>
    '''<return>ダウンロードに成功した場合はTrue、そうでない場合、False。</return>
    Public Shared Async Function DownloadFileAsync(serverPath As String, localPath As String) As Task(Of Boolean)
        Try
            Dim _client As New HttpClient()
            Dim _response As HttpResponseMessage = Await _client.GetAsync(serverPath, HttpCompletionOption.ResponseHeadersRead)

            If _response.IsSuccessStatusCode Then
                'Webからファイル読込成功した場合

                'ローカルにファイルを保存
                Using _fileStream = File.Create(localPath)
                    Using _httpStream = Await _response.Content.ReadAsStreamAsync()
                        _httpStream.CopyTo(_fileStream)
                        _fileStream.Flush()
                    End Using
                End Using
                Return True
            Else
                'Webからファイル読込失敗した場合

                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
