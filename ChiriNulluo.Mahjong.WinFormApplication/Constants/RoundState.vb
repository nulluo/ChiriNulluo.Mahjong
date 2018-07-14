Namespace Constants
    <Flags()>
    Public Enum RoundState

        ''' <summary>
        ''' 不特定
        ''' </summary>
        Undetermined = &H0

        ''' <summary>
        ''' HUMANが自分で引いた牌で上がった
        ''' </summary>
        PlayerWinByTileDrawnByPlayer = &H1

        ''' <summary>
        ''' HUMANがCOMが捨てた牌でロン上がりした
        ''' </summary>
        PlayerWinByTileDiscardedByCOM = &H2

        ''' <summary>
        ''' COMが自分で引いた牌で上がった
        ''' </summary>
        PlayerLoseByTileDrawnByCOM = &H4

        ''' <summary>
        ''' COMがHUMANが捨てた牌でロン上がりした
        ''' </summary>
        PlayerLoseByTileDiscardedByPlayer = &H8

        ''' <summary>
        ''' 引き分けになった
        ''' </summary>
        Draw = &H10

        'UNIMPLEMENTED: 「HUMANがロン可能な牌をCOMが捨てた」場合もこのフラグはONにならない。それでもバグらないのはこのフラグは参照しておらず、代わりに「HUMANがCOMが捨てた牌でロン上がりした」があるからこのフラグが必要なくなっているため。動作としては問題ないがバグの素になりそうなので、これは是正すべきだし、他にも切り替えるべきタイミングで変更されないフラグがないか要確認
        ''' <summary>
        ''' HUMANがロン可能な牌をCOMが捨てた
        ''' </summary>
        PlayerCanRonTileDiscardedByCOM = &H20

        ''' <summary>
        ''' HUMANがポン可能な牌をCOMが捨てた
        ''' </summary>
        PlayerCanPongTileDiscardedByCOM = &H40

        ''' <summary>
        ''' HUMANがチー可能な牌をCOMが捨てた
        ''' </summary>
        PlayerCanChowTileDiscardedByCOM = &H80

        ''' <summary>
        ''' HUMANがロン可能な牌をCOMが捨てた
        ''' </summary>
        COMCanRonTileDiscardedByPlayer = &H100

        ''' <summary>
        ''' HUMANがポン可能な牌をCOMが捨てた
        ''' </summary>
        COMCanPongTileDiscardedByPlayer = &H200

        ''' <summary>
        ''' HUMANがチー可能な牌をCOMが捨てた
        ''' </summary>
        COMCanChowTileDiscardedByPlayer = &H400

        ''' <summary>
        ''' COMがリーチを宣言した
        ''' </summary>
        COMDeclaredRiichi = &H800

        ''' <summary>
        ''' HUMANはフリテン状態である
        ''' </summary>
        PlayerIsFriten = &H1000

        ''' <summary>
        ''' HUMANはフリテン状態である
        ''' </summary>
        COMIsFriten = &H2000


    End Enum
End Namespace