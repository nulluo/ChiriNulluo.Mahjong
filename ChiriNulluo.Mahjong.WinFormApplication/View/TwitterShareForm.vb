Public Class TwitterShareForm

    Private Property PreviousForm As Form

    Private Property ImageFileName As String

    Public Sub New(previousForm As Form, imageFileName As String)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.PreviousForm = previousForm
        Me.ImageFileName = imageFileName

    End Sub


    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.WebBrowser1.Document.All.GetElementsByName("tweet")(0).InnerText =
                         "キュア雀で●●に勝利しました #キュアジャン https://bit.ly/2MhypHb"

        Me.WebBrowser1.Document.All.GetElementsByName("tweet")(0).Focus()

        '画像を作成する
        Dim bmp As New Bitmap(ImageFileName)

        '画像データをクリップボードにコピーする
        Clipboard.SetImage(bmp)
        SendKeys.Send("^v")
        '後片付け
        bmp.Dispose()

        Timer1.Enabled = False
    End Sub
End Class