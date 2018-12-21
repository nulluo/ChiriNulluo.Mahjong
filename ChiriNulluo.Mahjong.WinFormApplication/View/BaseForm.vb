Namespace View
    ''' <summary>
    ''' 全てのフォームの基底フォーム
    ''' </summary>
    Public Class BaseForm
        Private Sub FormBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Text = "キュアジャン Ver." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
        End Sub
    End Class

End Namespace