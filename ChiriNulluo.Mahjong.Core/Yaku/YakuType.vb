'UNIMPLEMENTED: 一応Flags属性つけてビット演算可能にしたが、不要かも

Namespace Yaku
    ''' <summary>
    ''' 役<c>Yaku</c>のタイプを表す列挙型
    ''' </summary>
    <Flags>
    Public Enum YakuType

        ''' <summary>
        ''' 手牌に、特定の牌のセットに属する全ての牌が含まれている
        ''' </summary>
        SpecificTileSetIsSubSetOfHand = &H1

        ''' <summary>
        ''' 手牌の全ての牌が、特定の牌のセットに属するいずれかの牌である
        ''' </summary>
        HandIsSubSetOfSpecificTileSet = &H2

        ''' <summary>
        ''' ４面子＋１雀頭で構成されない、非定型役。手牌の構成のみによって確定する。
        ''' </summary>
        DeterminedByHandIrregular = &H4

        ''' <summary>
        ''' 手牌以外要素依存役(手牌以外の要素によって判定される、特殊役)
        ''' </summary>
        DependingOnNonHandCondition = &H8

        ''' <summary>
        ''' 得点には加算されるが、このタイプの役以外が成立しないと上がれない(チョンボになる)役(アガリ＋ボーナス牌)
        ''' </summary>
        NeedsOtherYakuTypeToFinish = &H10

        ''' <summary>
        ''' ボーナス牌
        ''' </summary>
        BonusTile = &H20

    End Enum

End Namespace