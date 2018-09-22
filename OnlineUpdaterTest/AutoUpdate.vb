Imports System.IO
Imports System.Net
Imports System.Text

Public Class AutoUpdate

    Private XMLFunction As New XMLFunc.XmlFunctions

    Private Connection As System.Net.HttpWebRequest
    Private WithEvents Timer As Timer

    ''' <summary>
    ''' タイムアウト(秒)
    ''' </summary>
    Private Property TimeDelay As Integer

    ''' <summary>
    ''' Webページの読み込みが完了したかどうか。
    ''' </summary>
    Private Property IsFinishedHttpLoading As Boolean

    ''' <summary>
    ''' 失敗した接続を再度読込みし直すボタンが押されたかどうか。
    ''' </summary>
    Private Property Retry As Boolean

    ''' <summary>
    ''' 読込がタイムアウトしたかどうか。
    ''' </summary>
    Private Property IsTimeOut As Boolean

    ''' <summary>
    ''' キャンセルボタンがクリックされたかどうか。
    ''' </summary>
    Private Property IsCanceled As Boolean

    ''' <summary>
    ''' Setup options menu.
    ''' </summary>
    Private Property Setup As Boolean

    ''' <summary>
    ''' Close the form.
    ''' </summary>
    Private Property Closeme As Boolean

    ''' <summary>
    ''' Files were updated
    ''' </summary>
    Private Property Updated As Boolean

    ''' <summary>
    ''' autoupdate
    ''' </summary>
    Private Property AutoUpdate As Boolean

#Region "理解済みのコード"

#Region "Event Handler"

    ''' <summary>
    ''' アプリケーションの起動が完了するまでは、画面が閉じないようにする。
    ''' </summary>
    Private Sub AutoUpdater_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Closeme Then
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' 画面ロード時の処理
    ''' </summary>
    Private Sub AutoUpdater_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Defaults.AppName
        StartUpdate()
    End Sub

    ''' <summary>
    ''' WebBrowserのドキュメント読込が完了した時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WBData.DocumentCompleted
        IsFinishedHttpLoading = True
        If WBData.DocumentTitle.ToUpper <> "SYNCRONY" Then
            IsTimeOut = True
        End If
    End Sub

    ''' <summary>
    ''' タイマーチック時の処理
    ''' </summary>
    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If TimeDelay = 0 Or IsCanceled Then
            'タイムアウトになったか、キャンセルボタンが押された場合

            IsTimeOut = True
            Timer.Enabled = False
        Else
            '残り待ち時間カウントダウン
            TimeDelay -= 1
        End If
    End Sub

    ''' <summary>
    ''' キャンセルボタン押下時の処理
    ''' </summary>
    ''' <remarks>サーバへの接続を途中でキャンセルして、アップデートを確認せずにexeを起動するためのボタン</remarks>
    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        IsCanceled = True
    End Sub

    ''' <summary>
    ''' リトライボタン押下時の処理
    ''' </summary>
    ''' <remarks>サーバへの接続が失敗した場合に、再度接続を行うためのボタン</remarks>
    Private Sub RetryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetryButton.Click
        Retry = True
    End Sub

    ''' <summary>
    ''' Doneボタン押下時の処理
    ''' </summary>
    Private Sub DoneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoneButton.Click
        TimeDelay = 0
    End Sub

#End Region

    ''' <summary>
    ''' アプリケーションを起動する。
    ''' </summary>
    Private Sub LoadApp()
        Shell(Path.Combine(AppPath, AppEXE), AppWinStyle.NormalFocus)
        Closeme = True
        Me.Close()
    End Sub

#End Region

    ''' <summary>
    ''' アップデート処理を開始する。
    ''' </summary>
    Private Sub StartUpdate()
        Dim Updaterfile As String
        Dim Serverfile As String
        Dim TotalUpdates As String
        'Dim LastUpdate As String
        '        Dim CurrentUdate As Integer
        Dim FileList As List(Of FileDetails)

        RetryButton.Enabled = False
        DoneButton.Enabled = False
        Me.Show()
        LabelMessage.Text = "最新バージョンがリリースされているかどうか確認するため、サーバに接続します。" & vbCrLf & "インターネット接続が有効になっていることを確認してください。"
        Me.Refresh()
        WBData.Url = New System.Uri(Path.Combine("http://", UpdateSite, "default.html"))
        IsFinishedHttpLoading = False
        TimeDelay = TimeOutlen
        Timer = New Timer
        Timer.Interval = 1000
        Timer.Enabled = True
        While Not (IsFinishedHttpLoading Or IsTimeOut Or IsCanceled)

            'キューにたまっているWindowsメッセージを処理する。
            'Windowsメッセージの説明はここのページを参照。http://chokuto.ifdef.jp/advanced/windowmessage.html
            '簡単に言うと、Webページ読込中に行われたユーザーの操作(キャンセルボタン押下)や発生したタイマーイベントを処理するという事…だと思う、たぶん
            System.Windows.Forms.Application.DoEvents()

            If IsTimeOut Then
                LabelMessage.Text = "サーバに接続できませんでした。" & vbCrLf & "10秒以内にゲームを起動します。"
                RetryButton.Enabled = True
                IsTimeOut = False
                TimeDelay = 10
                Timer.Interval = 1000
                Timer.Enabled = True
                Retry = False
                While Not (IsTimeOut Or Retry Or IsCanceled)
                    '接続失敗後、ユーザーからリアクションがあるまで10秒間待機をしているところ

                    'ここでもWindowsメッセージを処理する。
                    '別スレッドで「10秒経過」、「リトライの押下」、「キャンセルの押下」などが発生していたら、ここで処理する。
                    System.Windows.Forms.Application.DoEvents()
                End While
                If Retry Then
                    LabelMessage.Text = "サーバへ再接続します。" & vbCrLf & "インターネット接続が有効になっていることを確認してください。"
                    RetryButton.Enabled = False
                    IsTimeOut = False
                    IsFinishedHttpLoading = False
                    TimeDelay = TimeOutlen
                    Timer.Interval = 1000
                    Timer.Enabled = True
                Else
                    '10秒経過したか、ユーザーがキャンセルボタンを押下した場合は、アップデートせずに現在のexeを起動する。
                    LoadApp()
                    Exit Sub
                End If
            End If
        End While

        'Webページ読込が完了した場合、アップデートの存在をチェックする。
        If Not IsCanceled Then
            LabelMessage.Text = "サーバーへの接続に成功しました。" & vbCrLf & "アップデートがあるかどうか確認します。"
            GroupBoxMessage.Refresh()

            'サーバからアップデートログファイル(UpdateID.xml)をダウンロードする。
            Updaterfile = Path.Combine(AppPath, "UpdateLog.xml")
            Serverfile = Path.Combine("http://", UpdateSite, UpdateID & ".xml")
            Try
                If File.Exists(Updaterfile) Then
                    File.Delete(Updaterfile)
                End If

                'UpdateID.xmlの中から最新バージョン番号を取り出す。
                My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                XMLFunction.OpenXMLDoc(Updaterfile)
                XMLFunction.XMLSNode("/updates")
                TotalUpdates = XMLFunction.GetNodeVal("total")

                '前回アップデートのバージョン番号とサーバ側の最新バージョン番号を比較
                If LastUpdate.LessThan(TotalUpdates) Then
                    'If MessageBox.Show("新しいバージョンがあります。ダウンロードしますか？", "アップデート",
                    'MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    'End If

                    'UNIMPLEMENTED: アップデートの意志をユーザーに確認する

                    FileList = XMLFunction.GetFiles
                        For Each ThisFile As FileDetails In FileList
                        'UNIMPLEMENTED: ローカルのファイルを全削除する
                        'UNIMPLEMENTED: SaveData.xmlなど、削除してはいけないファイルは削除しない。
                        Updated = True
                            Updaterfile = Path.Combine(AppPath, ThisFile.LocalFilePath)
                            Serverfile = Path.Combine("http://", UpdateSite, ThisFile.ServerFilePath)
                            LabelMessage.Text = ThisFile.Name & "をサーバーからダウンロードしています。" & vbCrLf & "完了までお待ちください。"
                            GroupBoxMessage.Refresh()
                            If File.Exists(Updaterfile) Then File.Delete(Updaterfile)
                            My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                        Next

                    FileList = XMLFunction.GetFiles
                    For Each ThisFile As FileDetails In FileList
                        'UNIMPLEMENTED: ローカルのファイルを全削除する
                        'UNIMPLEMENTED: SaveData.xmlなど、削除してはいけないファイルは削除しない。
                        Updated = True
                        Updaterfile = Path.Combine(AppPath, ThisFile.LocalFilePath)
                        Serverfile = Path.Combine("http://", UpdateSite, ThisFile.ServerFilePath)
                        LabelMessage.Text = ThisFile.Name & "をサーバーからダウンロードしています。" & vbCrLf & "完了までお待ちください。"
                        GroupBoxMessage.Refresh()
                        If File.Exists(Updaterfile) Then File.Delete(Updaterfile)
                        My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                    Next
                End If

                'アップデートに成功した場合
                If Updated Then
                    LabelMessage.Text = "ゲームは最新バージョンにアップデートされました！" & vbCrLf & "すぐにゲームを起動します。"
                    LastUpdate = TotalUpdates
                    My.Settings.LastUpdate = LastUpdate
                Else
                    LabelMessage.Text = "ゲームは既に最新の状態です。" & vbCrLf & "すぐにゲームを起動します。”
                End If
            Catch ex As Exception
                LabelMessage.Text = "アップデートに失敗しました。" & vbCrLf & "すぐにゲームを起動します。"
            End Try
            IsTimeOut = False
            TimeDelay = 10
            Timer.Interval = 1000
            Timer.Enabled = True
            Retry = False
            CancelButton.Enabled = False
            DoneButton.Enabled = True
            While Not (IsTimeOut Or IsCanceled)
                'ユーザーにメッセージ表示後、10秒経過するか、(せっかちな)ユーザーがキャンセルボタンを押すかするのを待つ
                System.Windows.Forms.Application.DoEvents()
            End While
        End If

        'アプリケーションを起動する。
        LoadApp()
    End Sub


    ''' <summary>
    ''' 指定したファイルがアップデートによって上書きしてよいファイルの場合はTrue,上書き禁止のファイルの場合はFalseを返す。
    ''' </summary>
    ''' <param name="filePath">ファイルパス(ローカルのファイルパスで記述)</param>
    ''' <return>指定したファイルがアップデートによって上書きしてよいファイルの場合はTrue,上書き禁止のファイルの場合はFalseを返す。</return>
    Private Function IsOverwritable(filePath As String) As Boolean

        '今の所、SaveData.xmlだけが上書き禁止ファイルに該当する
        If filePath = "SaveData.xml" Then
            Return False
        Else
            Return True
        End If

    End Function

End Class