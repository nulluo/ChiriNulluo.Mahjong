'UNIMPLEMENTED: デバッグ用クラスにつきリリースバージョンからは削除
Public Class UpdateIDResetForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.LastUpdate = "0.0.0.0"
    End Sub
End Class