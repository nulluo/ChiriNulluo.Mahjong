Imports ChiriNulluo.Mahjong.Precure.Players

Friend Class OpponentManager

    Private Property Opponent As PrecurePlayer

    'UNIMPLEMENTED: Opponentプロパティ設定してする前にGetNormalFaceImageなどを呼び出すとエラーになるのが気にかかる・・・PrecureXMLAccessの実装を観て研究した方がいいかも
    Public Function GetNormalImage() As Image
        Return My.Resources.ResourceManager.GetObject(String.Format("Face_{0}01", Me.Opponent.ID))
    End Function

    Public Function GetLossImage() As Image
        Return My.Resources.ResourceManager.GetObject(String.Format("Face_{0}02", Me.Opponent.ID))
    End Function

    Public Function GetWinningImage() As Image
        Return My.Resources.ResourceManager.GetObject(String.Format("Face_{0}03", Me.Opponent.ID))
    End Function

    Public Sub SetOpponent(precurePlayer As PrecurePlayer)
        Me.Opponent = precurePlayer
    End Sub


    Public ReadOnly Property GetScriptLose() As String
        Get
            Return My.Resources.ResourceManager.GetObject(String.Format("CharacterScript{0}Lose", Me.Opponent.ID))
        End Get
    End Property

    Public ReadOnly Property GetScriptWinDraw() As String
        Get
            Return My.Resources.ResourceManager.GetObject(String.Format("CharacterScript{0}WinDraw", Me.Opponent.ID))
        End Get
    End Property

    Public ReadOnly Property GetScriptWinRon() As String
        Get
            Return My.Resources.ResourceManager.GetObject(String.Format("CharacterScript{0}WinRon", Me.Opponent.ID))
        End Get
    End Property

    Public ReadOnly Property GetScriptGameStart() As String
        Get
            Return My.Resources.ResourceManager.GetObject(String.Format("CharacterScript{0}GameStart", Me.Opponent.ID))
        End Get
    End Property

    Public ReadOnly Property GetScriptDraw() As String
        Get
            Return My.Resources.ResourceManager.GetObject(String.Format("CharacterScript{0}Draw", Me.Opponent.ID))
        End Get
    End Property

    Public ReadOnly Property GetDisplayName As String
        Get
            Return Me.Opponent.DisplayName
        End Get
    End Property
End Class
