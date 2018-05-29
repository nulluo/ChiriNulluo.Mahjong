Imports System.Globalization
Imports System.Threading

Public Class InitialForm
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim _nextForm As New SelectOpponentForm
        FormTransition.Transit(Me, _nextForm)
    End Sub

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
End Class