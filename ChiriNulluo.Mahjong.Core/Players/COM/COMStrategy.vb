Namespace Players.COM
    Public Enum COMStrategy

        'UNIMPLEMENTED：ふるまいは「毎回ツモギリする」になっているので「Random」という名称は不適切では？
        ''' <summary>
        ''' 完全にランダムに牌を切る
        ''' </summary>
        Random

        ''' <summary>
        ''' テンパイで配牌された後、残りの1枚を引くことを目指す
        ''' </summary>
        ToCompleteDealtReadyHand

        ''' <summary>
        ''' イーシャンテンで配牌された後、残りの2枚を引くことを目指す
        ''' </summary>
        ToCompleteDealtHandOneStepAwayFromReady

    End Enum
End Namespace