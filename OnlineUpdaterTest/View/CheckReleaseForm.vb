
Namespace View

    ''' <summary>
    ''' 最新バージョンの存在を確認しにサーバへ接続する間にユーザに表示する待機画面
    ''' </summary>
    Public Class CheckReleaseForm

        Private Property Release As Release = Release.Instance

        ''' <summary>
        ''' 画面ロード時処理
        ''' </summary>
        Private Async Sub InitialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            Await CheckIfNewVersionExistsAsync()

        End Sub

        ''' <summary>
        ''' 最新バージョンが存在するか、サーバに接続して確認する。
        ''' </summary>
        Private Async Function CheckIfNewVersionExistsAsync() As Task
            Try

                Dim _latestReleaseExists As Boolean = Await Release.IsNewerThanLocalFile()
                If _latestReleaseExists Then

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
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End Function

    End Class

End Namespace