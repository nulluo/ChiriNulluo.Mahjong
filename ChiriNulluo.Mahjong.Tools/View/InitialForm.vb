Namespace View
    Public Class Form1
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim _nextForm As New CreateReleaseXMLForm
            Me.Hide()
            _nextForm.ShowDialog(Me)
            Me.Show()
        End Sub
    End Class
End Namespace