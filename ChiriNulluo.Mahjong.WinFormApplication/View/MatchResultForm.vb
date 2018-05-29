Public Class MatchResultForm
    Private Sub DisplayMatchResultForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.talkWindowPictureBox.Controls.Add(Label1)
        Me.Label1.Location = New Point(5, 5)

        Dim _humanScore As Integer = MatchManagerController.GetInstance.HumanPlayer.Score
        Dim _comScore As Integer = MatchManagerController.GetInstance.COMPlayer.Score

        Me.humanPointField.Text = _humanScore
        Me.comPointField.Text = _comScore

        If _comScore < _humanScore Then
            'UNIMPLEMENTED:ちゃんとした対戦相手ごとのメッセージを表示する 
            Label1.Text = "あなたの勝ちです![TEST]"
            PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetLossImage
        ElseIf _humanScore < _comScore
            Label1.Text = "あなたの負けです[TEST]"
            PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetWinningImage
        Else
            Label1.Text = "引き分けです！[TEST]"
            PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetNormalImage
        End If

    End Sub

    ''' <summary>
    ''' タイトル画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Dim _nextForm = New InitialForm
        FormTransition.Transit(Me, _nextForm)
    End Sub

    ''' <summary>
    ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
    ''' </summary>
    Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormTransition.ConfirmFormClosing(e)
    End Sub

End Class