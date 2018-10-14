Namespace Players.COM
    Public Class COMStrategy

        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.COMHaipaiStrategy = New COMHaipaiStrategy()
            Me.RiichiRate = 20
        End Sub

        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy, comHaipaiStrategy As COMHaipaiStrategy, riichiRate As Integer)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.COMHaipaiStrategy = comHaipaiStrategy
            Me.RiichiRate = riichiRate
        End Sub

        ''' <summary>
        ''' COMが牌を捨てる時のロジック
        ''' </summary>
        ''' <returns></returns>
        Public Property COMDiscardTileStrategy As COMDiscardTileStrategy

        ''' <summary>
        ''' COMに配牌するときのロジック
        ''' </summary>
        ''' <returns></returns>
        Public Property COMHaipaiStrategy As COMHaipaiStrategy

        ''' <summary>
        ''' テンパイした時に立直をかける確率(単位:%)
        ''' </summary>
        ''' <returns>テンパイした時に立直をかける確率(単位:%)</returns>
        Public Property RiichiRate As Integer

    End Class
End Namespace