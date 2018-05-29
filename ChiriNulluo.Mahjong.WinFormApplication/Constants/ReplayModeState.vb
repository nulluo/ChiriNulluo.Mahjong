Namespace Constants
    ''' <summary>
    ''' リプレイモードについての、現在のゲームの状態を表す
    ''' </summary>
    Public Enum ReplayModeState

        ''' <summary>
        ''' リプレイモードで実行中である。
        ''' </summary>
        Running

        ''' <summary>
        ''' マッチ開始時点から通常モード(非リプレイ)で実行中である
        ''' </summary>
        NormalModeSinceMatchStarted

        ''' <summary>
        ''' リプレイモードをマッチの途中で終了し、以降通常モード(非リプレイ)で実行中である
        ''' </summary>
        NormalModeSinceReplayModeEnded

    End Enum
End Namespace