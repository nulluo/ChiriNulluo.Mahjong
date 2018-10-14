Namespace Players.COM
    Public Class COMStrategy

        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.HaipaiStrategy = comDiscardTileStrategy
            Me.RiichiRate = 20
        End Sub

        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy, haipaiStrategy As COMDiscardTileStrategy, riichiRate As Integer)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.HaipaiStrategy = haipaiStrategy
            Me.RiichiRate = riichiRate
        End Sub

        Public Property COMDiscardTileStrategy As COMDiscardTileStrategy

        Public Property HaipaiStrategy As COMDiscardTileStrategy

        ''' <summary>
        ''' テンパイした時に立直をかける確率(単位:%)
        ''' </summary>
        ''' <returns>テンパイした時に立直をかける確率(単位:%)</returns>
        Public Property RiichiRate As Integer

    End Class
End Namespace