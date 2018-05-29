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
        ''' Wait for Http page to load
        ''' </summary>
        Private Property IsFinishedHttpLoading As Boolean

        ''' <summary>
        ''' Retry to load failed connection
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
        Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
            IsCanceled = True
        End Sub

        ''' <summary>
        ''' リトライボタン押下時の処理
        ''' </summary>
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


        Private Sub StartUpdate()
            Dim Updaterfile As String
            Dim Serverfile As String
            Dim TotalUpdates As String
            'Dim LastUpdate As String
            '        Dim CurrentUdate As Integer
            Dim FileList As List(Of XMLFunc.XmlFunctions.FileDetails)

            RetryButton.Enabled = False
            DoneButton.Enabled = False
            Me.Show()
            LabelMessage.Text = "Connecting to Remote Server" & vbCrLf & " Please ensure that your internet connection is active"
            Me.Refresh()
            WBData.Url = New System.Uri(Path.Combine("http://", UpdateSite, "default.html"))
            IsFinishedHttpLoading = False
            TimeDelay = TimeOutlen
            Timer = New Timer
            Timer.Interval = 1000
            Timer.Enabled = True
            While Not (IsFinishedHttpLoading Or IsTimeOut Or IsCanceled)

                System.Windows.Forms.Application.DoEvents()

                If IsTimeOut Then
                    LabelMessage.Text = "Connection to Remote Server Failed" & vbCrLf & "Application will continue in 10 seconds"
                    RetryButton.Enabled = True
                    IsTimeOut = False
                    TimeDelay = 10
                    Timer.Interval = 1000
                    Timer.Enabled = True
                    Retry = False
                    TimeDelay = 30
                    While Not (IsTimeOut Or Retry Or IsCanceled)
                        System.Windows.Forms.Application.DoEvents()
                    End While
                    If Retry Then
                        LabelMessage.Text = "Reconnecting to Remote Server" & vbCrLf & " Please ensure that your internet connection is active"
                        RetryButton.Enabled = False
                        IsTimeOut = False
                        IsFinishedHttpLoading = False
                        TimeDelay = TimeOutlen
                        Timer.Interval = 1000
                        Timer.Enabled = True
                    Else
                        LoadApp()
                        Exit Sub
                    End If
                End If
            End While
            If Not IsCanceled Then
                LabelMessage.Text = "Connection to Remote Server completed" & vbCrLf & " Please wait while checking for new updates"
                GroupBoxMessage.Refresh()
                Updaterfile = Path.Combine(AppPath, "UpdateLog.xml")
                Serverfile = Path.Combine("http://", UpdateSite, UpdateID & ".xml")
                Try
                    If File.Exists(Updaterfile) Then
                        File.Delete(Updaterfile)
                    End If
                    My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                    XMLFunction.OpenXMLDoc(Updaterfile)
                    XMLFunction.XMLSNode("/updates")
                    TotalUpdates = XMLFunction.GetNodeVal("total")
                If LastUpdate.LessThan(TotalUpdates) Then
                    FileList = XMLFunction.GetFiles
                    For Each ThisFile As XMLFunc.XmlFunctions.FileDetails In FileList
                        If LastUpdate.LessThan(ThisFile.Update) Then
                            Updated = True
                            Updaterfile = Path.Combine(AppPath, ThisFile.Local)
                            Serverfile = Path.Combine("http://", UpdateSite, ThisFile.Server)
                            LabelMessage.Text = "Downloading " & ThisFile.File & " from server" & vbCrLf & " Please wait for update to complete"
                            GroupBoxMessage.Refresh()
                            If File.Exists(Updaterfile) Then File.Delete(Updaterfile)
                            My.Computer.Network.DownloadFile(Serverfile, Updaterfile)
                        End If
                    Next
                End If
                If Updated Then
                        LabelMessage.Text = "Update succesfully installed." & vbCrLf & "Application will Exit in a few seconds"
                        LastUpdate = TotalUpdates
                        My.Settings.LastUpdate = LastUpdate
                    Else
                        LabelMessage.Text = "No Updates to load." & vbCrLf & "Application will Exit in a few seconds"
                    End If
                Catch ex As Exception
                    LabelMessage.Text = "Error during download" & vbCrLf & "Application will Exit in a few seconds"
                End Try
                IsTimeOut = False
                TimeDelay = 10
                Timer.Interval = 1000
                Timer.Enabled = True
                Retry = False
                CancelButton.Enabled = False
                DoneButton.Enabled = True
                While Not (IsTimeOut Or IsCanceled)
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            LoadApp()
        End Sub

End Class