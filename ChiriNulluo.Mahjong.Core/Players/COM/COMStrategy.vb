﻿Namespace Players.COM
    Public Class COMStrategy

        ''' <summary>
        ''' コンストラクタ(テンパイ時リーチ確率は100%, 配牌は完全ランダム)
        ''' </summary>
        ''' <param name="comDiscardTileStrategy"></param>
        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.COMHaipaiStrategy = New COMHaipaiStrategy()
            Me.RiichiRate = 100
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="comDiscardTileStrategy"></param>
        ''' <param name="comHaipaiStrategy"></param>
        ''' <param name="riichiRate">テンパイした時に立直をかける確率(単位:%)</param>
        Public Sub New(comDiscardTileStrategy As COMDiscardTileStrategy, comHaipaiStrategy As COMHaipaiStrategy, riichiRate As Integer)
            Me.COMDiscardTileStrategy = comDiscardTileStrategy
            Me.COMHaipaiStrategy = comHaipaiStrategy
            Me.RiichiRate = riichiRate
        End Sub

        'このようなプロパティを実装しなくてもRiichiRateを0%近くの値に設定してやればちゃんと「よくチョンボする」COMは表現できる。（今のCOMは「役がついたかどうか」を判断して上がるかどうか決めていない）

        '''' <summary>
        '''' 役なしによるチョンボになるかどうか計算して、役なしの場合はアガリ宣言しない場合はTrue,そうでない場合はFalse
        '''' </summary>
        '''' <remarks>マヌケキャラを演出したい場合、この値をFalseにする。</remarks>
        '''' <returns></returns>
        'Public Property AvoidNoYakusChombo As Boolean = True


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