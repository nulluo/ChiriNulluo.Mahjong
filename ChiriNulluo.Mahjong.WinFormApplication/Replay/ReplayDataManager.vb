Namespace Replay

    ''' <summary>
    ''' リプレイデータを管理するクラス
    ''' </summary>
    Public NotInheritable Class ReplayDataManager

#Region "Property"
        ''' <summary>
        ''' ゲームが現在リプレイモードであるかどうか。
        ''' </summary>
        ''' <returns></returns>
        Public Shared Property CurrentState As Constants.ReplayModeState = Constants.ReplayModeState.NormalModeSinceMatchStarted

        Private Shared _current As Integer = -1
        Private Shared Property Current As Integer
            Get
                Return _current
            End Get
            Set(value As Integer)
                _current = value
            End Set
        End Property

        ''' <summary>
        ''' リプレイデータのリスト
        ''' </summary>
        ''' <returns></returns>
        Friend Shared ReadOnly Property DataList As New List(Of ReplayData)

        ''' <summary>
        ''' リプレイデータのうち、現在参照中のものを返す。
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property CurrentData As ReplayData
            Get
                Return DataList(Current)
            End Get
        End Property

#End Region

        ''' <summary>
        ''' リプレイデータを１手進める
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GoForward() As ReplayData
            If Current < DataList.Count - 1 Then
                Current += 1
                Return DataList(Current)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' リプレイデータを１手戻す
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GoBackward() As ReplayData
            Current -= 1
            Return DataList(Current)
        End Function

        ''' <summary>
        ''' <c>ReplayData</c>を追加します。
        ''' </summary>
        Public Shared Sub AddData(value As ReplayData)
            DataList.Add(value)
        End Sub

    End Class

End Namespace