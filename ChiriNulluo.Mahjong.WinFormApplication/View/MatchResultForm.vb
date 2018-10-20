Imports System.Web

Namespace View

    Public Class MatchResultForm
        Private Property TweetMessage As String

        Private Sub DisplayMatchResultForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.talkWindowPictureBox.Controls.Add(Label1)
            Me.Label1.Location = New Point(5, 5)

            Dim _humanScore As Integer = MatchManagerController.GetInstance.HumanPlayer.Score
            Dim _comScore As Integer = MatchManagerController.GetInstance.COMPlayer.Score

            Me.humanPointField.Text = _humanScore.ToString
            Me.comPointField.Text = _comScore.ToString
            Dim _opponentName As String = MatchManagerController.GetInstance.OpponentManager.GetDisplayName
            Dim _resultMessage As String

            If _comScore < _humanScore Then
                'UNIMPLEMENTED:ちゃんとした対戦相手ごとのメッセージを表示する 
                Label1.Text = "あなたの勝ちです![TEST]"
                PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetLossImage
                _resultMessage = "勝利しました！！"
            ElseIf _humanScore < _comScore Then
                Label1.Text = "あなたの負けです[TEST]"
                PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetWinningImage
                _resultMessage = "負けました…"
            Else
                Label1.Text = "引き分けです！[TEST]"
                PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetNormalImage
                _resultMessage = "引き分けしました。"
            End If
            TweetMessage = String.Format("キュアジャンで{0}に{1} #キュアジャン", _opponentName, _resultMessage)

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

        Private Sub TwitterShareButton_Click(sender As Object, e As EventArgs) Handles TwitterShareButton.Click
            Dim _encodedMessage As String
            _encodedMessage = HttpUtility.UrlEncode(Me.TweetMessage)

            'ブラウザで開く
            System.Diagnostics.Process.Start("http://twitter.com/share?url=https://nulluo.github.io/ChiriNulluo.Game.WebSite/CureJong/index.html&text=" & _encodedMessage)

        End Sub
    End Class

End Namespace