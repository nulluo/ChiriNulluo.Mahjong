Namespace View
    Public Class SelectReplayDataForm
        Private Sub SelectReplayDataForm_Load(sender As Object, e As EventArgs) Handles Me.Load

            Me.ReplayDataField.DataSource = Replay.ReplayLogReader.GetMatchIDs


        End Sub

        Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
            Replay.ReplayLogReader.Read(Me.ReplayDataField.SelectedValue.ToString)
            Dim _nextForm = New ReplayForm()
            FormTransition.Transit(Me, _nextForm)
        End Sub
    End Class
End Namespace