
Namespace View
    'UNIMPLEMENTED: デバッグ用クラスにつきリリースバージョンからは削除
    Public Class DebugForm
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            My.Settings.LastUpdate = "0.0.0.0"
        End Sub

        Private Sub StartUpdaterButton_Click(sender As Object, e As EventArgs) Handles StartUpdaterButton.Click
            '最新バージョンダウンロード画面へ進む
            Dim _nextForm As New CheckReleaseForm()
            Me.Hide()
            _nextForm.Show()
        End Sub
    End Class
End Namespace