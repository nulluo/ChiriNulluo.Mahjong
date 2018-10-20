Imports System.Globalization
Imports System.Threading

Namespace View

    Public Class InitialForm

        Private Sub replayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles replayToolStripMenuItem.Click
            Dim _nextForm As New SelectReplayDataForm()
            FormTransition.Transit(Me, _nextForm)
        End Sub

        Private Sub InitialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            'セーブデータファイル初期化
            SaveData.GetInstance.InitializeSaveDataFile()


#If DEBUG Then
            Me.DebugToolStripMenuItem.Visible = True
            me.LogTestButton.Visible=True
#Else
            Me.DebugToolStripMenuItem.Visible = False
            Me.LogTestButton.Visible = False
#End If

            Me.PlaysBGMMenuItem.Checked = Sounds.SoundManager.PlaysBGM
            Me.PlaysSEMenuItem.Checked = Sounds.SoundManager.PlaysSE
            Me.GameStartButton.Parent = Me


            Me.Text = "キュアジャン Ver." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        End Sub

        ''' <summary>
        ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
        ''' </summary>
        Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            FormTransition.ConfirmFormClosing(e)
        End Sub

        Private Sub PlaysBGMMenuItem_Click(sender As Object, e As EventArgs) Handles PlaysBGMMenuItem.Click
            Sounds.SoundManager.PlaysBGM = PlaysBGMMenuItem.Checked
        End Sub

        Private Sub PlaysSEMenuItem_Click(sender As Object, e As EventArgs) Handles PlaysSEMenuItem.Click
            Sounds.SoundManager.PlaysSE = PlaysSEMenuItem.Checked
        End Sub

        Private Sub GameStartButton_Click(sender As Object, e As EventArgs) Handles GameStartButton.Click
            Dim _nextForm As New SelectOpponentForm
            FormTransition.Transit(Me, _nextForm)
        End Sub

        Private Sub openRuleFormButton_Click(sender As Object, e As EventArgs) Handles openRuleFormButton.Click
            Dim _nextForm As New RuleForm
            Me.Hide()
            _nextForm.ShowDialog()
            Me.Show()
        End Sub

        Private Sub TwitterShareButton_Click(sender As Object, e As EventArgs) Handles TwitterShareButton.Click
            'ブラウザで開く
            System.Diagnostics.Process.Start("http://twitter.com/share?url=https://nulluo.github.io/ChiriNulluo.Game.WebSite/CureJong/index.html&text=%e5%90%8c%e4%ba%ba%e3%82%b2%e3%83%bc%e3%83%a0%e3%81%af%e3%81%93%e3%82%8c%e3%82%92%e3%82%84%e3%81%a3%e3%81%a6%e3%82%8b%e3%82%88%ef%bc%81%e4%bb%8a%e5%ba%a6%e3%81%ae%e3%83%97%e3%83%aa%e3%82%ad%e3%83%a5%e3%82%a2%e3%82%b2%e3%83%bc%e3%81%af%e3%83%9e%e3%83%bc%e3%82%b8%e3%83%a3%e3%83%b3%ef%bc%81%20%23%e3%82%ad%e3%83%a5%e3%82%a2%e3%82%b8%e3%83%a3%e3%83%b3")

        End Sub


        Private Sub VersionInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionInfoToolStripMenuItem.Click
            Dim _nextForm As New View.VersionInfoForm()
            _nextForm.ShowDialog()

        End Sub

        Private Sub LogTestButton_Click(sender As Object, e As EventArgs) Handles LogTestButton.Click
            Dim logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
            logger.Trace("test")
        End Sub
    End Class
End Namespace