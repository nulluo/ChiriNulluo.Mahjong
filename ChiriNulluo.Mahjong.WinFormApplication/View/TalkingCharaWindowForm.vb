Namespace View
    Public Class TalkingCharaWindowForm

#Region "Property"
        Public Property Words As String
            Get
                Return Me.Label1.Text
            End Get
            Set(value As String)
                Me.Label1.Text = value
            End Set
        End Property

        Public Property CharacterImage As Image
            Get
                Return Me.PictureBox1.Image
            End Get
            Set(value As Image)
                Me.PictureBox1.Image = value
            End Set
        End Property

#End Region

        Private Sub TalkingCharaWindowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Label1.Parent = talkWindowPictureBox
            Me.Label1.Location = New Point(5, 5)

            If Replay.ReplayDataManager.CurrentState = Constants.ReplayModeState.Running Then
                Me.okButton.PerformClick()
            End If
        End Sub

        Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
            Me.Close()
        End Sub

    End Class
End Namespace