Namespace View
    Public Class VersionInfoForm
        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

            'リンク先に移動したことにする
            LinkLabel1.LinkVisited = True
            'ブラウザで開く
            System.Diagnostics.Process.Start("https://nulluo.github.io/ChiriNulluo.Game.WebSite/CureJong/")

        End Sub

        Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
            Me.Close()
        End Sub

        Private Sub VersionInfoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.VersionField.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        End Sub
    End Class
End Namespace