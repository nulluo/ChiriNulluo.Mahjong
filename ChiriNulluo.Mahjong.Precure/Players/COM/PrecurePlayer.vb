Imports ChiriNulluo.Mahjong.Core.Players.COM

Namespace Players

    ''' <summary>
    ''' キャラクターの顔グラフィック、リアクション台詞、戦略などの個性を表現するクラス
    ''' </summary>
    Public Class PrecurePlayer

        Public Sub New(id As String, displayName As String)
            Me.ID = id
            Me.DisplayName = displayName

            Me.COMStrategy = New COMStrategy(COMDiscardTileStrategy.ToDecreaseShantenCount, COMDiscardTileStrategy.ToDecreaseShantenCount, 20)
        End Sub

        Public Sub New(id As String, displayName As String, comstrategy As COMStrategy)
            Me.ID = id
            Me.DisplayName = displayName

            Me.COMStrategy = comstrategy
        End Sub


        ''' <summary>
        ''' ファイル名・リソース名等に使用する英字のID。キャラクタ名を表すDisplayNameとは異なるので注意
        ''' </summary>
        ''' <returns></returns>
        Public Property ID As String

        ''' <summary>
        ''' キャラクタ名を表す。ファイル名・リソース名等に使用するIDとは異なるので注意
        ''' </summary>
        ''' <returns></returns>
        Public Property DisplayName As String

        ''' <summary>
        ''' キャラクタの個性を表現する戦略
        ''' </summary>
        ''' <returns></returns>
        Public Property COMStrategy As COMStrategy

    End Class

End Namespace
