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
#Else
            Me.DebugToolStripMenuItem.Visible = False
#End If

            Me.PlaysBGMMenuItem.Checked = Sounds.SoundManager.PlaysBGM
            Me.PlaysSEMenuItem.Checked = Sounds.SoundManager.PlaysSE
            Me.GameStartButton.Parent = Me
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
            System.Diagnostics.Process.Start("http://twitter.com/share?url=http://www.geocities.jp/nero021/programming/CureJong/CureJong.htm&text=%e3%81%93%e3%81%ae%e3%82%b2%e3%83%bc%e3%83%a0%e3%82%81%e3%81%a3%e3%81%a1%e3%82%83%e9%9d%a2%e7%99%bd%e3%81%84%e3%81%a7%ef%bc%81%e3%81%bf%e3%82%93%e3%81%aa%e3%82%82%e3%82%84%e3%82%8d%e3%81%86%ef%bc%81")

        End Sub



        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim _form As New TwitterShareForm(Me, IO.Path.Combine(My.Application.Info.DirectoryPath, "logs", "ScreenShot.gif"))
            _form.Show()
        End Sub
    End Class
End Namespace