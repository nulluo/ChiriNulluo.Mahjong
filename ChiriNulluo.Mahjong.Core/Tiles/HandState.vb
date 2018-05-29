Namespace Tiles

    ''' <summary>
    ''' 手牌の状態を表す列挙体。
    ''' </summary>
    Public Enum HandState

        'UNIMPLEMENTED：この状態は今牌が13枚なのか14枚なのかも考慮する必要あるのでは？

        ''' <summary>
        ''' 役が成立しており、上がれる状態を表す。
        ''' </summary>
        Completed

        ''' <summary>
        ''' あと1枚で上がれる状態を表す。
        ''' </summary>
        Ready

        ''' <summary>
        ''' その他の状態を表す。
        ''' </summary>
        OtherWise

    End Enum

End Namespace
