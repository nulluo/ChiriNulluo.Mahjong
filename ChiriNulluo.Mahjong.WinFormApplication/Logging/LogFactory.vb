Namespace Logging

    Public NotInheritable Class LogFactory
        Private Shared _replayLogger As New ReplayLogger

        Private Sub New()
        End Sub

        ''' <summary>
        ''' リプレイ用ログを出力するロガーを取得します。
        ''' </summary>
        ''' <returns>リプレイログを出力する <see cref="ReplayLogger" /> </returns>
        Public Shared Function GetReplayLogger() As ReplayLogger
            Return _replayLogger
        End Function

    End Class

End Namespace