Imports ChiriNulluo.Mahjong.Precure.HandChecker
Imports ChiriNulluo.Mahjong.Precure
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication
Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Precure.HandChecker


    <TestFixture>
    Public Class PrecureHandCheckerTest

        'UNIMPLEMENTED：本来、MatchManagerControllerクラスはControllerプロジェクトに存在すべき
        Private _roundManager As RoundManager

        <SetUp()>
        Public Sub Initialize()
            _roundManager = MatchManagerController.GetInstance.MatchManager.RoundManager
        End Sub

        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801")>'あがり：普通の役
        <TestCase(False, "0101", "0101", "0202", "0202", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803", "0803")> 'ブタ：七対子は撤廃
        <TestCase(False, "0101", "0101", "0101", "0101", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803", "0803")> 'ブタ：同牌4個を含むため七対子が成立しない
        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0103", "0103", "0103", "0902", "0902", "0902", "0801", "0801")> '0103が5枚あるアガリ(特殊能力によって発生し得る)
        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801")>
        <TestCase(True, "0301", "0301", "0301", "0302", "0302", "0303", "0303", "0304", "0304", "0305", "0305", "0306", "0306", "0306")>'染め手：解析に時間かかりそう
        <TestCase(False, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0802")>
        Public Sub TestIsCompleted(expectedValue As Boolean, ParamArray precureIDs As String())
            Me.MakeHand(precureIDs)
            Assert.AreEqual(expectedValue, New PrecureHandChecker(Me._roundManager.PlayersList(0).Hand).IsCompleted)
        End Sub

        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0103", "0103", "0902", "0902", "0902", "0801", "0801")> 'テンパイだけど特殊能力なしでは上がれない
        <TestCase(False, "0101", "0101", "0202", "0202", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803")> 'NG：七対子は撤廃
        <TestCase(True, "0801", "0101", "0103", "0902", "0902", "0902", "0801", "0103", "0103", "0101", "0102", "0102", "0103")> '理牌されてなくても正常に動作するよね？①
        <TestCase(False, "0202", "0802", "0202", "0301", "0301", "0902", "0902", "0101", "0101", "0802", "0303", "0303", "0803")> '理牌されてなくても正常に動作するよね？②NG：七対子は撤廃
        <TestCase(True, "0301", "0301", "0301", "0302", "0302", "0303", "0303", "0304", "0304", "0305", "0305", "0306", "0306")>'染め手：解析に時間かかりそう
        Public Sub TestIsReady(expectedValue As Boolean, ParamArray precureIDs As String())
            Me.MakeHand(precureIDs)
            Assert.AreEqual(expectedValue, New PrecureHandChecker(Me._roundManager.PlayersList(0).Hand).IsReady)
        End Sub

        '<TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0802")>'イーシャンテン：普通の役
        '<TestCase(True, "0101", "0101", "0202", "0202", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0803", "1001")> '七対子イーシャンテン
        '<TestCase(False, "0101", "0201", "0202", "0301", "0303", "0401", "0403", "0501", "0502", "0601", "0603", "1001", "1102")>'ブタ
        'Public Sub TestIsOneStepAwayFromReady(expectedValue As Boolean, ParamArray precureIDs As String())
        '    Me.MakeHand(precureIDs)
        '    Assert.AreEqual(expectedValue, New PrecureHandChecker(Me._roundManager.PlayersList(0).Hand).IsOneStepAwayFromReady)
        'End Sub

        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801")>'あがり：普通の役
        <TestCase(False, "0101", "0101", "0202", "0202", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803", "0803")> 'ブタ：七対子は撤廃
        <TestCase(False, "0101", "0101", "0101", "0101", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803", "0803")> 'ブタ：同牌4個を含むため七対子が成立しない
        <TestCase(True, "0101", "0101", "0102", "0102", "0103", "0103", "0103", "0103", "0103", "0902", "0902", "0902", "0801", "0801")> '0103が5枚あるアガリ(特殊能力によって発生し得る)
        Public Sub TestIsCompletedIfTargetTileAdded(expectedValue As Boolean, targetTileID As String, ParamArray precureIDs As String())
            Me.MakeHand(precureIDs)
            Dim _targetTile As New PreCureCharacterTile(targetTileID, String.Empty, String.Empty)
            Assert.AreEqual(expectedValue, New PrecureHandChecker(Me._roundManager.PlayersList(0).Hand).IsCompletedIfTargetTileAdded(_targetTile))
        End Sub

        <TestCase(New String() {"0101"}, "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801")>
        <TestCase(New String() {}, "0101", "0101", "0202", "0202", "0301", "0301", "0303", "0303", "0902", "0902", "0802", "0802", "0803")>
        <TestCase(New String() {"0300", "0301", "0302", "0303", "0304", "0305", "0306"}, "0301", "0301", "0302", "0302", "0303", "0303", "0304", "0304", "0305", "0305", "0306", "0306", "0306")>'染め手：解析に時間かかりそう
        Public Sub TestTilesToCompleteHand(expectedValue As String(), ParamArray precureIDs As String())
            Me.MakeHand(precureIDs)
            Assert.AreEqual(expectedValue.ToList, New PrecureHandChecker(Me._roundManager.PlayersList(0).Hand).TilesToCompleteHand)

        End Sub

#Region "テスト用補助メソッド"

        ''' <summary>
        ''' 牌IDのリストによって指定された通りに手牌を作成する
        ''' </summary>
        ''' <param name="precureIDList"></param>
        Private Sub MakeHand(precureIDList As String())
            _roundManager.PlayersList(0).Hand.MainTiles.Clear()

            For Each _precureID As String In precureIDList
                Me.AddTileToMyHand(_precureID)
            Next
        End Sub

        ''' <summary>
        ''' 山から指定したIDの牌を手牌に加える
        ''' </summary>
        ''' <param name="id">牌ID</param>
        Private Sub AddTileToMyHand(id As String)
            Dim _pickedTile As Tile
            Dim _playersHand As Hand = _roundManager.PlayersList(0).Hand
            With _roundManager
                _pickedTile = .PickOutTileFromWall(id)

                'もし指定したIDの牌が山に残っていなければ、強制的に牌のモチーフを上書きして取得する。
                If _pickedTile Is Nothing Then
                    _pickedTile = .WallPile.PopNextDraw()
                    _pickedTile = New PreCureCharacterTile(id, String.Empty, String.Empty)
                End If

                .AddTile(_pickedTile, _playersHand.MainTiles)
            End With
        End Sub
#End Region

    End Class
End Namespace
