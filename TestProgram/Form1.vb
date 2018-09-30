Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _localExeFilepath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Me.LabelVersion.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(_localExeFilepath).FileVersion
    End Sub
End Class
