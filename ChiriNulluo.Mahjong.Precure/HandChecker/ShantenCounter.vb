Imports System
Imports System.Collections.Generic
Imports System.Text
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace HandChecker

    'UNIMPLEMENTED: PrecureHandCheckerクラスから独立させてる意味はあまりない？集約させる事を検討せよ
    Public Class ShantenCounter

        'Private Shared TileArray(TileMax - 1) As String

        'UNIMPLEMENTED: もっといいなまえを考案
        'Private Shared IndexDictionary As New Dictionary(Of String, Integer)


        'Private Shared Property NumsPerPrecureList As New SortedList(Of String, Integer)

        Public Const TileMax As Integer = 68 - 13 + 6


        ''' <summary>
        ''' 現在の牌リスト(プリキュア牌＋現在の局のボーナス牌）をリセットする
        ''' </summary>
        'Public Shared Sub InitializeCurrentRoundTiles()
        '    NumsPerPrecureList.Clear()
        '    PrecureCharacterSet.GetInstance.CurrentRoundTotalTilesIDList.Distinct.ToList.ForEach(
        '                                                                              Sub(x) NumsPerPrecureList.Add(x, 0))
        'End Sub

        ''' <summary>
        ''' スタティックコンストラクタ：牌種IDを牌を表す全角文字に変換する配列を生成
        ''' </summary>
        Shared Sub New()

            'UNIMPLEMENTED: べタ書きしてしまっているが本当はXMLファイルから読み込んで生成しないとNG


            'TileArray(0) = "0000"
            'TileArray(1) = "0101"
            'TileArray(2) = "0102"
            'TileArray(3) = "0103"
            'TileArray(4) = "0200"
            'TileArray(5) = "0201"
            'TileArray(6) = "0202"
            'TileArray(7) = "0203"
            'TileArray(8) = "0300"
            'TileArray(9) = "0301"
            'TileArray(10) = "0302"
            'TileArray(11) = "0303"
            'TileArray(12) = "0304"
            'TileArray(13) = "0305"
            'TileArray(14) = "0306"
            'TileArray(15) = "0400"
            'TileArray(16) = "0401"
            'TileArray(17) = "0402"
            'TileArray(18) = "0403"
            'TileArray(19) = "0404"
            'TileArray(20) = "0500"
            'TileArray(21) = "0501"
            'TileArray(22) = "0502"
            'TileArray(23) = "0503"
            'TileArray(24) = "0504"
            'TileArray(25) = "0600"
            'TileArray(26) = "0601"
            'TileArray(27) = "0602"
            'TileArray(28) = "0603"
            'TileArray(29) = "0604"
            'TileArray(30) = "0605"
            'TileArray(31) = "0700"
            'TileArray(32) = "0701"
            'TileArray(33) = "0702"
            'TileArray(34) = "0703"
            'TileArray(35) = "0704"
            'TileArray(36) = "0705"
            'TileArray(37) = "0706"
            'TileArray(38) = "0800"
            'TileArray(39) = "0801"
            'TileArray(40) = "0802"
            'TileArray(41) = "0803"
            'TileArray(42) = "0804"
            'TileArray(43) = "0805"
            'TileArray(44) = "0900"
            'TileArray(45) = "0901"
            'TileArray(46) = "0902"
            'TileArray(47) = "0903"
            'TileArray(48) = "0904"
            'TileArray(49) = "1001"
            'TileArray(50) = "1002"
            'TileArray(51) = "1003"
            'TileArray(52) = "1004"
            'TileArray(53) = "1101"
            'TileArray(54) = "1102"
            'TileArray(55) = "1103"
            'TileArray(56) = "1201"
            'TileArray(57) = "1202"
            'TileArray(58) = "1203"
            'TileArray(59) = "1204"
            'TileArray(60) = "1205"
            'TileArray(61) = "1206"
            'TileArray(62) = "1301"
            'TileArray(63) = "1302"
            'TileArray(64) = "1303"

            ''UNIMPLEMENTED: 辞書型と配列、両方無いと実装できないのか？？

            'IndexDictionary.Add("0000", 0)
            'IndexDictionary.Add("0101", 1)
            'IndexDictionary.Add("0102", 2)
            'IndexDictionary.Add("0103", 3)
            'IndexDictionary.Add("0200", 4)
            'IndexDictionary.Add("0201", 5)
            'IndexDictionary.Add("0202", 6)
            'IndexDictionary.Add("0203", 7)
            'IndexDictionary.Add("0300", 8)
            'IndexDictionary.Add("0301", 9)
            'IndexDictionary.Add("0302", 10)
            'IndexDictionary.Add("0303", 11)
            'IndexDictionary.Add("0304", 12)
            'IndexDictionary.Add("0305", 13)
            'IndexDictionary.Add("0306", 14)
            'IndexDictionary.Add("0400", 15)
            'IndexDictionary.Add("0401", 16)
            'IndexDictionary.Add("0402", 17)
            'IndexDictionary.Add("0403", 18)
            'IndexDictionary.Add("0404", 19)
            'IndexDictionary.Add("0500", 20)
            'IndexDictionary.Add("0501", 21)
            'IndexDictionary.Add("0502", 22)
            'IndexDictionary.Add("0503", 23)
            'IndexDictionary.Add("0504", 24)
            'IndexDictionary.Add("0600", 25)
            'IndexDictionary.Add("0601", 26)
            'IndexDictionary.Add("0602", 27)
            'IndexDictionary.Add("0603", 28)
            'IndexDictionary.Add("0604", 29)
            'IndexDictionary.Add("0605", 30)
            'IndexDictionary.Add("0700", 31)
            'IndexDictionary.Add("0701", 32)
            'IndexDictionary.Add("0702", 33)
            'IndexDictionary.Add("0703", 34)
            'IndexDictionary.Add("0704", 35)
            'IndexDictionary.Add("0705", 36)
            'IndexDictionary.Add("0706", 37)
            'IndexDictionary.Add("0800", 38)
            'IndexDictionary.Add("0801", 39)
            'IndexDictionary.Add("0802", 40)
            'IndexDictionary.Add("0803", 41)
            'IndexDictionary.Add("0804", 42)
            'IndexDictionary.Add("0805", 43)
            'IndexDictionary.Add("0900", 44)
            'IndexDictionary.Add("0901", 45)
            'IndexDictionary.Add("0902", 46)
            'IndexDictionary.Add("0903", 47)
            'IndexDictionary.Add("0904", 48)
            'IndexDictionary.Add("1001", 49)
            'IndexDictionary.Add("1002", 50)
            'IndexDictionary.Add("1003", 51)
            'IndexDictionary.Add("1004", 52)
            'IndexDictionary.Add("1101", 53)
            'IndexDictionary.Add("1102", 54)
            'IndexDictionary.Add("1103", 55)
            'IndexDictionary.Add("1201", 56)
            'IndexDictionary.Add("1202", 57)
            'IndexDictionary.Add("1203", 58)
            'IndexDictionary.Add("1204", 59)
            'IndexDictionary.Add("1205", 60)
            'IndexDictionary.Add("1206", 61)
            'IndexDictionary.Add("1301", 62)
            'IndexDictionary.Add("1302", 63)
            'IndexDictionary.Add("1303", 64)

        End Sub

        ''' <summary>
        ''' 手牌情報を牌種IDをキー、持ち枚数を値にもつDictionary型に変換する。
        ''' </summary>
        ''' <param name="tehai">手牌情報を牌種IDのリストで保持したList</param>
        ''' <returns>手牌情報を牌種IDをキー、持ち枚数を値にもつDictionary型に変換したもの</returns>
        Public Shared Function GetNumsPerTileIndexList(tehai As List(Of Integer)) As Integer()
            Dim _numsPerTileIDs(TileMax - 1) As Integer
            'UNIMPLEMENTED: 初期値は明示的に初期化しなければ0で初期化されると思うのでたぶんこのコードはいらない
            _numsPerTileIDs.Select(Function(x) 0).ToArray()
            tehai.ForEach(Sub(x) _numsPerTileIDs(x) += 1)

            Return _numsPerTileIDs
        End Function


        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="handInfo">手牌を表す 牌IDのリスト</param>
        ''' <returns></returns>
        Public Shared Function CalculateShanten(handInfo As List(Of String)) As ShantenCountProgress

            'Dim _indexList As New List(Of Integer)
            ''UNIMPLEMENTED: もっといいLINQの書き方あるはず
            'handInfo.ForEach(Sub(x) _indexList.Add(IndexDictionary(x)))

            Dim _indexList As List(Of Integer) = handInfo.Select(Function(x) PrecureCharacterSet.GetInstance.SortedCurrentRoundDistinctTotalIDSet.ToList.IndexOf(x)).ToList

            Return CalculateShanten(_indexList)

        End Function


        ''' <summary>
        ''' 向聴数を求める
        ''' </summary>
        ''' <param name="handInfo">手牌を表すinteger型のリスト</param>
        ''' <returns></returns>
        Public Shared Function CalculateShanten(handInfo As List(Of Integer)) As ShantenCountProgress
            Dim NumsPerTileIndexList() As Integer = GetNumsPerTileIndexList(handInfo)

            Dim _results = New List(Of ShantenCountProgress)
            Dim returnValue As ShantenCountProgress = Nothing

            ''2個以上持っているすべての牌について、各々をアタマと仮定した場合の向聴数を求める
            For _tileIndex As Integer = 0 To NumsPerTileIndexList.Length - 1
                Dim _num As Integer = NumsPerTileIndexList(_tileIndex)
                If _num >= 2 Then

                    Dim _temp(NumsPerTileIndexList.Length - 1) As Integer
                    Array.Copy(NumsPerTileIndexList, _temp, NumsPerTileIndexList.Length)
                    _temp(_tileIndex) -= 2

                    Dim _progressWithHead As ShantenCountProgress = New ShantenCountProgress()
                    _progressWithHead.HasHead = True
                    Dim _subResultWithHead As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, 0, _progressWithHead)
                    ''計算した向聴数および面子分解パターンをresultsに追加
                    _results.Add(_subResultWithHead)

                End If

            Next

            ''アタマなしと仮定した場合の向聴数を求める
            Dim _progressWithoutHead As ShantenCountProgress = New ShantenCountProgress()
            _progressWithoutHead.HasHead = False
            Dim _subResultWithoutHead As ShantenCountProgress = CountMentsuAndMentsCandidate(NumsPerTileIndexList, 0, _progressWithoutHead)
            _results.Add(_subResultWithoutHead)

            'UNIMPLEMENTED: ＋１　必要ないのでは？
            ''上記で計算した暫定最小向聴数のうち、最小値が求めたい向聴数となる
            Dim _minShantenCount As Integer = Constants.ShantenCountMax + 1

            'UNIMPLEMENTED: LINQで最小値は計算できるはず
            _results.ForEach(Sub(x)
                                 If _minShantenCount > x.ShantenCount Then
                                     _minShantenCount = x.ShantenCount
                                     returnValue = x
                                 End If
                             End Sub)

            Return returnValue
        End Function



        '''UNIMPLEMENTED: levelは再帰呼びだしの深さを表しているようだが、この変数どこにも使ってないのでは？　デバッグ用変数か？
        ''' <summary>
        ''' 面子と面子候補の数を数える。
        ''' </summary>
        ''' <param name="handInfo">手牌情報(牌種IDをキー、持ち枚数を値にもつDictionary型）</param>
        ''' <param name="level">このメソッドの再帰呼びだしの深さ</param>
        ''' <param name="progress">計算中の向聴数情報</param>
        ''' <returns>向聴数計算の結果</returns>
        Public Shared Function CountMentsuAndMentsCandidate(handInfo As Integer(), level As Integer, progress As ShantenCountProgress) As ShantenCountProgress

            '' このメソッドの中で、stateのメンバを変更しないこと！
            Dim result As ShantenCountProgress = progress
            ''計算済みのパターンにおける暫定最小向聴数
            Dim minShanten As Integer = progress.ShantenCount()

            For j As Integer = 0 To TileMax - 1
                If handInfo(j) = 0 Then
                    Continue For
                End If

                ''牌jの刻子がとれるかチェック
                If (handInfo(j) >= 3) Then
                    Dim _temp(TileMax - 1) As Integer
                    Array.Copy(handInfo, _temp, handInfo.Length - 1)

                    _temp(j) -= 3

                    Dim _division As String = String.Format("{0} {1} {2} /", j, j, j)

                    Dim _progress As ShantenCountProgress = progress.Clone()
                    _progress.MentsuCount += 1
                    _progress.Division += _division

                    '' 牌jの刻子をとった残りの手牌を再帰的に計算
                    Dim subResult As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, level + 1, _progress)

                    If (subResult.ShantenCount() < minShanten) Then
                        minShanten = subResult.ShantenCount()
                        result = subResult
                    End If

                End If


                '' j～j+2の順子がとれるかチェック
                If (j <= TileMax - 1 - 2 AndAlso handInfo(j) >= 1 AndAlso handInfo(j + 1) >= 1 AndAlso handInfo(j + 2) >= 1 AndAlso CanBeStartOfShunts(j)) Then

                    Dim _temp(TileMax - 1) As Integer
                    Array.Copy(handInfo, _temp, handInfo.Length - 1)
                    _temp(j) -= 1
                    _temp(j + 1) -= 1
                    _temp(j + 2) -= 1

                    Dim _division As String = String.Format("{0} {1} {2} /", j, j + 1, j + 2)

                    Dim _progress As ShantenCountProgress = progress.Clone()
                    _progress.MentsuCount += 1
                    _progress.Division += _division

                    '' j～j+2の順子をとった残りの手牌を再帰的に計算
                    Dim subResult As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, level + 1, _progress)

                    If (subResult.ShantenCount < minShanten) Then
                        minShanten = subResult.ShantenCount
                        result = subResult
                    End If

                End If

                '' 刻子候補があればとる
                If (handInfo(j) >= 2) Then
                    Dim _temp(TileMax - 1) As Integer
                    Array.Copy(handInfo, _temp, handInfo.Length - 1)
                    _temp(j) -= 2

                    Dim _division As String = String.Format("{0} {1} /", j, j)

                    Dim _progress As ShantenCountProgress = progress.Clone()
                    _progress.MentsuCandidateCount += 1
                    _progress.Division += _division

                    '' 刻子候補をとった残りの手牌を再帰的に計算
                    Dim subResult As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, level + 1, _progress)

                    If (subResult.ShantenCount < minShanten) Then
                        minShanten = subResult.ShantenCount
                        result = subResult
                    End If

                End If

                '' 順子候補があればとる（ペンチャンorリャンメン）
                If (j <= TileMax - 1 - 1 AndAlso handInfo(j) >= 1 AndAlso handInfo(j + 1) >= 1 AndAlso CanBeStartOfPenchanOrRyanmenTatsu(j)) Then
                    Dim _temp(TileMax - 1) As Integer
                    Array.Copy(handInfo, _temp, handInfo.Length - 1)
                    _temp(j) -= 1
                    _temp(j + 1) -= 1

                    Dim _division As String = String.Format("{0} {1} /", j, j + 1)

                    Dim _progress As ShantenCountProgress = progress.Clone()
                    _progress.MentsuCandidateCount += 1
                    _progress.Division += _division

                    '' 順子候補（ペンチャンorリャンメン）をとった残りの手牌を再帰的に計算
                    Dim subResult As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, level + 1, _progress)

                    If (subResult.ShantenCount < minShanten) Then
                        minShanten = subResult.ShantenCount
                        result = subResult
                    End If

                End If

                '' 順子候補があればとる（カンチャン）
                '' 作品ＩＤをまたいだ牌（例：ナージャ＋ほのか）をカンチャンとしてカウントしないように検証
                If (j <= TileMax - 1 - 2 AndAlso handInfo(j) >= 1 AndAlso handInfo(j + 2) >= 1 AndAlso CanBeStartOfShunts(j)) Then
                    Dim _temp(TileMax - 1) As Integer
                    Array.Copy(handInfo, _temp, handInfo.Length - 1)
                    _temp(j) -= 1
                    _temp(j + 2) -= 1

                    Dim _division As String = String.Format("{0} {1} /", j, j + 2)

                    Dim _progress As ShantenCountProgress = progress.Clone()
                    _progress.MentsuCandidateCount += 1
                    _progress.Division += _division

                    '' 順子候補(カンチャン)をとった残りの手牌を再帰的に計算
                    Dim subResult As ShantenCountProgress = CountMentsuAndMentsCandidate(_temp, level + 1, _progress)

                    If (subResult.ShantenCount < minShanten) Then
                        minShanten = subResult.ShantenCount
                        result = subResult
                    End If
                End If
            Next

            Return result

        End Function

        ''' <summary>
        ''' 牌インデックスindex,index+1,index+2が順子になり得るかをチェックする
        ''' </summary>
        ''' <param name="index">チェック対象の牌インデックス</param>
        ''' <returns></returns>
        Private Shared Function CanBeStartOfShunts(index As Integer) As Boolean
            Return IsSameSuit(index, index + 2)
        End Function

        ''' <summary>
        ''' 牌インデックスindex,index+1がペンチャンorリャンメン塔子になり得るかをチェックする
        ''' </summary>
        ''' <param name="index">チェック対象の牌インデックス</param>
        ''' <returns></returns>
        Private Shared Function CanBeStartOfPenchanOrRyanmenTatsu(index As Integer) As Boolean
            Return IsSameSuit(index, index + 2) OrElse IsSameSuit(index - 1, index + 1)
        End Function

        'UNIMPLEMENTED: PrecureHandCheckerクラスにほぼ同じメソッドがある。統合を検討する
        'UNIMPLEMENTED: よくかんがえたらメソッド名は「両者が同じ色であるか」なのに実際に判定しているのは「両者が同じ色であり、さらに一つ上or下の牌も同じ色であるか」という内容になっており、メソッド名が実際のふるまいを正確に表現していない
        ''' <summary>
        ''' 2枚の牌インデックスが全て同じ作品IDに属するかどうかを判定する。無効な牌インデックス(範囲外)が指定された場合はFalseを返す。
        ''' </summary>
        Private Shared Function IsSameSuit(index0 As Integer, index1 As Integer) As Boolean
            'このチェックは、満、薫が存在しないときに咲＋舞が塔子判定されないようにするために必要
            If index0 <= -1 OrElse PrecureCharacterSet.GetInstance.SortedCurrentRoundDistinctTotalIDSet.Count <= index1 Then
                Return False
            End If

            Dim _suit0 As String = PrecureCharacterSet.GetInstance.SortedCurrentRoundDistinctTotalIDSet(index0).Substring(0, 2)
            Dim _suit1 As String = PrecureCharacterSet.GetInstance.SortedCurrentRoundDistinctTotalIDSet(index1).Substring(0, 2)

            Return _suit0 = _suit1

        End Function

        ''' <summary>
        ''' 再帰的な向聴数の計算過程を表すクラス
        ''' </summary>
        Public Class ShantenCountProgress

            ''' <summary>
            ''' 面子の数
            ''' </summary>
            ''' <returns>面子の数</returns>
            Public Property MentsuCount As Integer = 0

            ''' <summary>
            ''' 面子候補(対子＋塔子)の数
            ''' </summary>
            ''' <returns>面子候補(対子＋塔子)の数</returns>
            Public Property MentsuCandidateCount As Integer = 0

            ''' <summary>
            ''' 雀頭があるかどうか
            ''' </summary>
            ''' <returns>雀頭があるかどうか</returns>
            Public Property HasHead As Boolean = False

            ''' <summary>
            '''　手牌の分割パターンを表す文字列
            ''' </summary>
            ''' <returns>手牌の分割パターンを表す文字列</returns>
            Public Property Division As String = ""



            ''' <summary>
            ''' 面子数と面子候補の数、雀頭の有無から向聴数を求める。
            ''' </summary>
            ''' <returns>向聴数</returns>
            Public ReadOnly Property ShantenCount As Integer
                Get
                    Dim _mentsu As Integer = Me.MentsuCount
                    Dim _candidate As Integer = Me.MentsuCandidateCount

                    If _mentsu + _candidate > 4 Then
                        _candidate = 4 - _mentsu
                    End If

                    Dim _shantenCount As Integer = Constants.ShantenCountMax - 2 * Me.MentsuCount - _candidate

                    If (Me.HasHead) Then
                        _shantenCount -= 1
                    End If

                    Return _shantenCount
                End Get
            End Property


            ''' <summary>
            ''' 自分自身のシャローコピーを作成する。
            ''' </summary>
            ''' <returns>このオブジェクトのシャローコピー</returns>
            Public Function Clone() As ShantenCountProgress
                Return DirectCast(Me.MemberwiseClone(), ShantenCountProgress)
            End Function

        End Class



    End Class
End Namespace
