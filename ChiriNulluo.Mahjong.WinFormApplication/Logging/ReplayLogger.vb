Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.Core

Namespace Logging

    Public Class ReplayLogger

#Region "Property"
        Private Property ReplayLogger As NLog.Logger = Global.NLog.LogManager.GetLogger("Replay")

#End Region

        Public Sub Write(processTypeID As String, processID As String, player As String, remark As String, ParamArray parameters() As String)
#If DEBUG Then
            If Replay.ReplayDataManager.CurrentState = ReplayModeState.NormalModeSinceMatchStarted Then
                Dim _logMessage As String
                _logMessage = MatchManager.MatchID & ","
                _logMessage &= (MatchManager.LogNoInMatch Mod 1000).ToString("000") & ","
                _logMessage &= processTypeID & ","
                _logMessage &= processID & ","
                _logMessage &= player & ","
                _logMessage &= remark & ","""
                _logMessage &= String.Join(",", parameters)
                _logMessage &= """"

                ReplayLogger.Trace(_logMessage)

                'マッチ内ログNoカウントアップ
                MatchManager.LogNoInMatch += 1
            End If
#End If
        End Sub
    End Class

End Namespace