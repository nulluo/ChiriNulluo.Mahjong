Namespace Players.COM
    Public Enum COMDiscardTileStrategy

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

        ''' <summary>
        ''' 向聴数が減少する場合、牌を捨ててアガリを目指す
        ''' </summary>
        ToDecreaseShantenCount

        'UNIMPLEMENTED: デバッグ用のモードなのでリリースコードに残すべきかは要検討
        ''' <summary>
        ''' アガリ牌が出たり、ツモったりしても一度目は見逃して、わざとフリテンになる。
        ''' それ以外は<c>ToDecreaseShantenCount</c>と同じ挙動をする。(COMのフリテンテスト専用)
        ''' </summary>
        ToBeFritenForTest

    End Enum

End Namespace