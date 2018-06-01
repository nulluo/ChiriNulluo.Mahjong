Imports System.Globalization
Imports System.Threading

Public Class InitialForm

    Private Sub replayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles replayToolStripMenuItem.Click
        Dim _nextForm As New SelectReplayDataForm()
        FormTransition.Transit(Me, _nextForm)
    End Sub

    Private Sub InitialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
        Me.MainMenuStrip.Visible = True
#Else
        Me.MainMenuStrip.Visible = False
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
End Class