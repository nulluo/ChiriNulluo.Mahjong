Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Precure.DataAccess
Imports ChiriNulluo.Mahjong.Core.Yaku

'UNIMPLEMENTED：''' 本来は牌種によらない部分を抽象化すれば一部Core側で実装可能なはずだが、とりあえずはこのバイナリ内で実装しておく
Namespace HandChecker

    ''' <summary>
    ''' PrecureCharacter型の牌で構成された手牌のアガリ、役判定などを行う。
    ''' </summary>
    Public Class PrecureHandChecker

        'UNIMPLEMENTED: とりあえず仮にここにベタがきするが、本来はPrecureXMLDataAccessクラスでXMLから取得しないとだめです
        Private CharacterNumPerSeries() As Integer = {1, 3, 4, 7, 5, 5, 6, 7, 6, 5, 4, 3, 6, 3}

        'UNIMPLEMENTED：深く考えずにコンストラクタ実装してしまったが、静的メソッドしかもたないNotInheritableなクラスでいい気がする
        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="hand">手牌</param>
        Public Sub New(hand As Hand)
            Me.NumsPerPrecureList = Me.GetPrecureTileCountDictionary()
            For Each tile In hand.MainTiles
                Me.NumsPerPrecureList(tile.ID) += 1
            Next
            Me.Hand = hand
        End Sub

        Public Sub New(numsPerPrecureList As SortedList(Of String, Integer))
            Me.NumsPerPrecureList = numsPerPrecureList
            Me.Hand = New Hand()
            With Me.NumsPerPrecureList
                For Each _id As String In .Keys
                    For i As Integer = 0 To .Item(_id) - 1
                        Dim _tile As New PreCureCharacterTile(_id, String.Empty, String.Empty)
                        Me.Hand.DrawTile(_tile)
                    Next
                Next
            End With
        End Sub

        ''' <summary>
        ''' 4面子1雀頭の形は成立しているが、役なしのためツモ以外では上がれない状態であるかどうか。
        ''' </summary>
        ''' <returns>4面子1雀頭の形は成立しているが、役なしのためツモ以外では上がれない状態である場合はTrue,そうでない場合はFalse。</returns>
        Public Property IsSetCompleteButNoYakus As Boolean = False

        Private Property NumsPerPrecureList As SortedList(Of String, Integer)
        Private Property Hand As Hand

        ''' <summary>
        ''' メンツが揃っていて上がれる状態になっている場合にTrue,そうでない場合はFalseを返す。
        ''' </summary>
        ''' <returns>メンツが揃っていて上がれる状態になっている場合にTrue,そうでない場合はFalse</returns>
        Public Function IsCompleted() As Boolean

            With NumsPerPrecureList

                If Me.DeterminedByHandIrregularYakuAccomplished() Then
                    Return True
                End If

                Dim r As Integer = 0
                Dim a As Integer = .Values(0)
                Dim b As Integer = .Values(1)

                '雀頭候補
                Dim _headSeries As Integer = Me.GetHeadCandidateSuit(NumsPerPrecureList)
                If _headSeries = -1 Then
                    Return False
                End If


                Dim _seriesStartChara As Integer
                Dim _seriesEndChara As Integer
                For i As Integer = 0 To _headSeries - 1
                    _seriesStartChara += CharacterNumPerSeries(i)
                Next
                _seriesEndChara += _seriesStartChara + CharacterNumPerSeries(_headSeries) - 1

                For _charaIndex As Integer = _seriesStartChara To _seriesEndChara
                    .Item(.Keys(_charaIndex)) -= 2
                    If .Values(_charaIndex) >= 0 Then
                        If Me.IsDividableIntoFourMents(NumsPerPrecureList) Then
                            Return True
                        End If
                    End If
                    .Item(.Keys(_charaIndex)) += 2
                Next

                Return False
            End With

        End Function

        ''' <summary>
        ''' 12枚の牌をチェックして４面子に完全に分解可能か判定する。
        ''' </summary>
        ''' <returns></returns>
        Private Function IsDividableIntoFourMents(numsPerPrecureList As SortedList(Of String, Integer)) As Boolean

            With numsPerPrecureList
                Dim r As Integer = 0
                Dim a = .Values(0)
                Dim b = .Values(1)

                For i As Integer = 0 To .Count - 3
                    r = a Mod 3
                    If r = 0 Then
                        a = b - r
                        b = .Values(i + 2) - r

                        Continue For
                    End If

                    If b >= r AndAlso .Values(i + 2) >= r AndAlso
                        .Keys(i).Substring(0, 2) = .Keys(i + 2).Substring(0, 2) Then

                        'UNIMPLEMENTED: 上と同じ計算をしているので改善の余地がありそう
                        a = b - r
                        b = .Values(i + 2) - r

                    Else
                        Return False
                    End If
                Next

                If a Mod 3 = 0 AndAlso b Mod 3 = 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        End Function

        ''' <summary>
        ''' 与えられた手牌がアガリ形になっている可能性がある場合、雀頭になる牌の候補の含まれるSuitを作品IDで返します。
        ''' 与えられた手牌がアガリ形ではあり得ないと判断した場合、-1を返します。
        ''' </summary>
        ''' <returns></returns>
        Private Function GetHeadCandidateSuit(numsPerPrecureList As SortedList(Of String, Integer)) As Integer
            Dim _head As Integer = -1
            Dim _seriesBorder As Integer = 0
            For _seriesIndex As Integer = 0 To CharacterNumPerSeries.Length - 1
                Dim _sumPerTeam As Integer = 0

                Dim _charaNum As Integer = CharacterNumPerSeries(_seriesIndex)

                '1つのSuit内の牌の枚数の総数を計算
                For _charaIndex As Integer = _seriesBorder To _seriesBorder + _charaNum - 1
                    _sumPerTeam += numsPerPrecureList.Values(_charaIndex)
                Next
                Select Case _sumPerTeam Mod 3
                    Case 1
                        '総数を3で割った余りが1の場合、アガリ形ではあり得ない
                        Return -1
                    Case 2
                        '総数を3で割った余りが2の場合、そのSuit内に雀頭候補がある可能性がある
                        If _head = -1 Then
                            _head = _seriesIndex
                        Else
                            '雀頭候補のあるSuitが複数出てきたら、アガリ形ではない
                            Return -1
                        End If
                End Select

                _seriesBorder += _charaNum
            Next

            Return _head

        End Function

        ''' <summary>
        ''' 手牌依存型非定型役のいずれかが成立しているかどうかを判定する。
        ''' </summary>
        ''' <returns></returns>
        Private Function DeterminedByHandIrregularYakuAccomplished() As Boolean

            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Dim _yakuList As List(Of Core.Yaku.Yaku) = _xmlAccess.GetYakuDataFromXML()

            'UNIMPLEMENTED: LINQでさらに短く書けるはず(どう書くんだっけ？）
            For Each _yaku As Core.Yaku.Yaku In _yakuList.Where(Function(x) x.Type.HasFlag(YakuType.DeterminedByHandIrregular))
                If _yaku.IsAccomplished(Me.Hand) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Function GetPrecureTileCountDictionary() As SortedList(Of String, Integer)
            Dim _precureTileDictionary As New SortedList(Of String, Integer)
            With _precureTileDictionary
                For Each _id As String In PrecureCharacterSet.GetInstance().AllCharacterTilesIDList
                    .Add(_id, 0)
                Next
            End With
            Return _precureTileDictionary
        End Function

        'UNIMPLEMENTED：Dictionary型のディープコピーのやり方が分かれば、ここで
        'わざわざメソッドを定義する必要はなくなるのだが・・・
        'いや、これは正確にはDeepCopyというか…要素が値型だからたまたまDeepになってるけど実際にはシャローコピー？
        Private Function GetDeepCopy(precureCountDictionary As SortedList(Of String, Integer)) As SortedList(Of String, Integer)
            Dim _newDictionary As New SortedList(Of String, Integer)

            With precureCountDictionary
                For i As Integer = 0 To .Count - 1
                    _newDictionary.Add(.Keys(i), .Values(i))
                Next
            End With

            Return _newDictionary

        End Function

        'UNIMPLEMENTED：牌IDと同じIDの牌は各1枚ずつ牌ID順に並べた時に何番目の牌になるかという概念が混ざっていてわかりにくい

        ''' <summary>
        ''' アガリではなく、かつあと1枚で上がれる状態になっている場合にTrue,そうでない場合はFalseを返す。牌が13枚の時のみ正しい判定結果を返す。
        ''' </summary>
        ''' <returns>メンツが揃っていて上がれる状態になっている場合にTrue,そうでない場合はFalse</returns>
        ''' <remarks>（正確にはカンがあるかもしれないので13枚というより、牌を引いて捨てた状態でのみ有効に動作するというべき)</remarks>
        Public Function IsReady() As Boolean
            'UNIMPLEMENTED：まだ牌を引いて切ってない状態の場合（＝多くの場合は手牌に14枚あるとき）はFalseを返すべきか？

            Dim _tempDictionary = Me.GetDeepCopy(Me.NumsPerPrecureList)

            '総当たり方式で1牌ずつ手牌に足してみて、上がりになるか検証
            'UNIMPLEMENTED：これひょっとして、上がり牌が捨て牌または敵手牌の中にしかない場合、テンパイとして判定されないのでは？山牌しかみてないから
            For Each _precureIDWall As String In PrecureCharacterSet.GetInstance.CurrentRoundTotalTilesIDList
                _tempDictionary(_precureIDWall) += 1

                Dim _newHandChecker As New PrecureHandChecker(_tempDictionary)
                If _newHandChecker.IsCompleted() Then
                    Return True
                Else
                    _tempDictionary(_precureIDWall) -= 1
                End If
            Next

            Return False
        End Function

        'UNIMPLEMENTED：テンパイかどうかを判定していない
        ''' <summary>
        ''' テンパイではなく、あと２枚で上がれる状態になっている場合にTrue,そうでない場合はFalseを返す。牌が13枚の時のみ正しい判定結果を返す。
        ''' </summary>
        ''' <returns>テンパイではなく、あと２枚で上がれる状態になっている場合にTrue,そうでない場合はFalse</returns>
        ''' <remarks>麻雀用語でいうとイーシャンテンの判定をする関数。（正確にはカンがあるかもしれないので13枚というより、牌を引いて捨てた状態でのみ有効に動作するというべき)</remarks>
        Public Function IsOneStepAwayFromReady() As Boolean
            'UNIMPLEMENTED：まだ牌を引いて切ってない状態の場合（＝多くの場合は手牌に14枚あるとき）はFalseを返すべきか？
            'UNIMPLEMENTED：IsReadyIfTargetTileExchangedメソッドとコードが重複。全牌をループさせて、IsReadyIfTargetTileExchangedメソッドを呼ぶことでコードを1つにまとめる事が可能なはずである。

            'UNIMPLEMENTED：このメソッドの中で何度もSortedListの生成をループで繰り返しているのが、動作が重くなる原因では？
            '総当たり方式で1牌ずつ交換し、上がれる状態になるか検証
            Dim _tempDictionary = Me.GetDeepCopy(Me.NumsPerPrecureList)
            For Each _precureIDHand As String In NumsPerPrecureList.Keys

                '_precureIDHandを1枚捨てる
                If _tempDictionary(_precureIDHand) > 0 Then
                    _tempDictionary(_precureIDHand) -= 1
                Else
                    Continue For
                End If

                '各牌を加えて、テンパイになるか確認する
                With Me.GetPrecureTileCountDictionary
                    For Each _precureIDWall As String In .Keys
                        _tempDictionary(_precureIDWall) += 1
                        Dim _newHandChecker As New PrecureHandChecker(_tempDictionary)
                        If _newHandChecker.IsReady() Then
                            Return True
                        Else
                            _tempDictionary(_precureIDWall) -= 1
                        End If
                    Next
                End With

                'どの牌を加えても、テンパイにならなかったので捨てた牌が間違いである。よって、捨てた牌を手に戻す
                _tempDictionary(_precureIDHand) += 1
            Next

            Return False
        End Function

        ''' <summary>
        ''' 対象の牌を手牌に加えるとアガリになるかどうか判定する。このメソッドは手牌が13枚のときに有効に機能する。
        ''' </summary>
        ''' <param name="tile"></param>
        ''' <returns>対象の牌を手牌に加えるとアガリになるかどうか</returns>
        Public Function IsCompletedIfTargetTileAdded(tile As Tile) As Boolean

            Dim _tempDictionary = Me.GetDeepCopy(Me.NumsPerPrecureList)
            _tempDictionary(tile.ID) += 1

            Dim _newHandChecker As New PrecureHandChecker(_tempDictionary)

            Return _newHandChecker.IsCompleted()

        End Function

        ''' <summary>
        ''' 対象の牌を手牌に加えると4雀頭1面子が成立し、かつ役がつくかどうか判定する。このメソッドは手牌が13枚のときに有効に機能する。
        ''' </summary>
        ''' <param name="tile"></param>
        ''' <returns>対象の牌を手牌に加えるとアガリになるかどうか</returns>
        Public Function IsSetCompletedAndYakuAccomplishedIfTargetTileAdded(tile As Tile, riichiDone As Boolean) As Boolean

            Dim _tempDictionary = Me.GetDeepCopy(Me.NumsPerPrecureList)
            _tempDictionary(tile.ID) += 1

            Dim _newHandChecker As New PrecureHandChecker(_tempDictionary)

            If _newHandChecker.IsCompleted() Then
                _newHandChecker.GetYakuInfo(riichiDone)
                Return Not _newHandChecker.IsSetCompleteButNoYakus
            Else
                Return False
            End If

        End Function


        ''' <summary>
        ''' ツモッた後、手牌の中から捨てるとテンパイになる牌を取得する。どう切ってもテンパイ手が作れない場合はNothingを返す。このメソッドは手牌が14枚のとき(ツモった直後)に有効に機能する。
        ''' </summary>
        ''' <returns>手牌にある牌のうち、対象の牌と交換するとテンパイ手ができる牌。どう交換してもテンパイ手が作れない場合はNothingを返す。</returns>
        ''' <remarks>ツモった直後（このときツモ牌はHandに含まれる）で判定しないと正しく動作しないので注意。</remarks>
        Public Function GetTileToDiscardToMakeReadyHand() As Tile
            Dim _tempDictionary = Me.GetDeepCopy(Me.NumsPerPrecureList)

            For Each _precureIDHand As String In NumsPerPrecureList.Keys

                '_precureIDHandを1枚捨てる
                If _tempDictionary(_precureIDHand) > 0 Then
                    _tempDictionary(_precureIDHand) -= 1
                Else
                    Continue For
                End If

                'テンパイになるか確認する
                Dim _newHandChecker As New PrecureHandChecker(_tempDictionary)
                If _newHandChecker.IsReady() Then
                    Return Me.Hand.TotalTiles.SearchTile(_precureIDHand)
                End If

                '牌を加えても、テンパイにならなかったので捨てた牌が間違いである。よって、捨てた牌を手に戻す
                _tempDictionary(_precureIDHand) += 1

            Next

            Return Nothing
        End Function


        ''' <summary>
        ''' ポン可能かどうかの判定（対象の牌を手牌に加えると刻子ができるかどうか判定する。）
        ''' </summary>
        ''' <param name="tile"></param>
        ''' <returns>対象の牌をポン可能かどうか</returns>
        Public Function CanMakeTripletIfTargetTileAdded(tile As Tile) As Boolean
            Return (Me.NumsPerPrecureList(tile.ID) >= 2)
        End Function

        ''' <summary>
        ''' 手牌に含まれる、対象の捨て牌をチーして順子を構成する事が可能な塔子のリストを取得する。
        ''' </summary>
        ''' <param name="tile">対象の捨て牌</param>
        ''' <returns>手牌にある、チーが可能な塔子の牌IDリスト</returns>
        Public Function GetPossibleTatsuListWhichCanMakeChowIfTargetTileAdded(tile As Tile) As List(Of List(Of String))
            'UNIMPLEMENTED：関数名が長すぎる。

            '相手が捨てた牌の情報
            Dim _id As String = tile.ID
            Dim _idInt As Integer = Integer.Parse(_id)

            'チーで順子を構成する牌の情報
            Dim _idHand0 As String
            Dim _idHand1 As String

            '1) 塔子の左の牌を鳴けるか？
            _idHand0 = (_idInt + 1).ToString("0000")
            _idHand1 = (_idInt + 2).ToString("0000")

            Dim _returnList As New List(Of List(Of String))
            If IsAllTileSameSuit(_id, _idHand0, _idHand1) Then
                If Me.NumsPerPrecureList.ContainsKey(_idHand0) AndAlso Me.NumsPerPrecureList.ContainsKey(_idHand1) AndAlso
                    Me.NumsPerPrecureList(_idHand0) >= 1 AndAlso Me.NumsPerPrecureList(_idHand1) >= 1 Then
                    _returnList.Add(New List(Of String) From {_idHand0, _idHand1})
                End If
            End If

            '2) 塔子の間の牌を鳴けるか？(嵌張待ち)
            _idHand0 = (_idInt - 1).ToString("0000")
            _idHand1 = (_idInt + 1).ToString("0000")

            If IsAllTileSameSuit(_id, _idHand0, _idHand1) Then
                If Me.NumsPerPrecureList.ContainsKey(_idHand0) AndAlso Me.NumsPerPrecureList.ContainsKey(_idHand1) AndAlso
                    Me.NumsPerPrecureList(_idHand0) >= 1 AndAlso Me.NumsPerPrecureList(_idHand1) >= 1 Then
                    _returnList.Add(New List(Of String) From {_idHand0, _idHand1})
                End If
            End If

            '3) 塔子の右の牌を鳴けるか？
            _idHand0 = (_idInt - 2).ToString("0000")
            _idHand1 = (_idInt - 1).ToString("0000")

            If IsAllTileSameSuit(_id, _idHand0, _idHand1) Then
                If Me.NumsPerPrecureList.ContainsKey(_idHand0) AndAlso Me.NumsPerPrecureList.ContainsKey(_idHand1) AndAlso
                    Me.NumsPerPrecureList(_idHand0) >= 1 AndAlso Me.NumsPerPrecureList(_idHand1) >= 1 Then
                    _returnList.Add(New List(Of String) From {_idHand0, _idHand1})
                End If
            End If

            Return _returnList

            'UNIMPLEMENTED：1)～3)がほぼ同じ構造を繰り返しているので、うまくメソッドとして抽出できるのでは？
        End Function


        ''' <summary>
        ''' 3枚の牌IDが全て同じ作品IDに属するかどうかを判定する
        ''' </summary>
        ''' <param name="id0"></param>
        ''' <param name="id1"></param>
        ''' <param name="id2"></param>
        ''' <returns></returns>
        Private Function IsAllTileSameSuit(id0 As String, id1 As String, id2 As String) As Boolean
            Dim _suit0 As String = id0.Substring(0, 2)
            Dim _suit1 As String = id1.Substring(0, 2)
            Dim _suit2 As String = id2.Substring(0, 2)

            Return _suit0 = _suit1 AndAlso _suit1 = _suit2 AndAlso _suit2 = _suit0

        End Function


#Region "役判定処理"


        ''' <summary>
        ''' 成立している役を計算する。
        ''' </summary>
        ''' <param name="riichiDone">プレイヤーがリーチしているかどうか</param>
        Public Function GetYakuInfo(riichiDone As Boolean) As DataTable
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Dim _yakuList As List(Of Core.Yaku.Yaku) = _xmlAccess.GetYakuDataFromXML()

            Dim _table = Me.GetYakuTable()
            '特殊役の判定結果をDataTableに追加
            Me.FillAccomplishedIrregularYakus(riichiDone, _table)

            '通常役の判定結果をDataTableに追加
            For Each _yaku As Core.Yaku.Yaku In _yakuList
                If _yaku.IsAccomplished(Me.Hand) Then
                    Dim _row As DataRow = _table.NewRow()
                    _row("YakuName") = _yaku.Name
                    _row("Point") = _yaku.Point
                    _table.Rows.Add(_row)
                End If
            Next

            '「あがり」以外の役がついていない場合、チョンボ罰として3000ポイント支払う
            If _table.Rows.Count <= 1 Then
                _table.Rows.Clear()
                Dim _row As DataRow = _table.NewRow()
                _row("YakuName") = My.Resources.LabelNoYakus
                _row("Point") = -3000
                _table.Rows.Add(_row)

                Me.IsSetCompleteButNoYakus = True
            End If

            Return _table

        End Function


        ''' <summary>
        ''' 役を表すDataTableを取得する
        ''' </summary>
        ''' <returns></returns>
        Private Function GetYakuTable() As DataTable
            Dim _table As New DataTable

            _table.Columns.Add("YakuName", System.Type.GetType("System.String"))
            _table.Columns.Add("Point", System.Type.GetType("System.Int32"))

            Return _table
        End Function


        ''' <summary>
        ''' XMLで表現できない非定型役のうち、達成できたものを全て取得し、DataTableに追加する。
        ''' </summary>
        Private Sub FillAccomplishedIrregularYakus(riichiDone As Boolean, table As DataTable)
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Dim _yakuList As List(Of Core.Yaku.Yaku) = _xmlAccess.GetIrregularYakuDataFromXML()

            For Each _yaku As Core.Yaku.Yaku In _yakuList
                If IsAccomplishedIrregularYaku(riichiDone, _yaku.Name) Then
                    Dim _row As DataRow = table.NewRow()
                    _row("YakuName") = _yaku.Name
                    _row("Point") = _yaku.Point
                    table.Rows.Add(_row)
                End If
            Next
        End Sub

        ''' <summary>
        ''' 非正規の役が達成できているかどうか検証する。
        ''' </summary>
        ''' <param name="yakuName">役名</param>
        ''' <returns>役が達成できている場合はTrue,そうでない場合はFalse。</returns>
        Private Function IsAccomplishedIrregularYaku(riichiDone As Boolean, yakuName As String) As Boolean

            Select Case yakuName
                Case "あがり"
                    Return True
                Case "ツモ"
                    Return (Not Me.Hand.PongOrChowOrRonDone)
                Case "リーチ"
                    Return riichiDone
            End Select
        End Function

#End Region
    End Class
End Namespace
