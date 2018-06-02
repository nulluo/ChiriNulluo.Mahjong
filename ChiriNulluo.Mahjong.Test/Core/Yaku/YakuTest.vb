Imports ChiriNulluo.Mahjong.Core.Yaku
Imports ChiriNulluo.Mahjong.WinFormApplication
Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.DataAccess
Imports ChiriNulluo.Mahjong.Precure.Tiles


Namespace Core.Yaku

    <TestFixture>
    Public Class YakuTest
        'UNIMPLEMENTED：本来、MatchManagerTestクラスはControllerプロジェクトに存在すべき
        Private _roundManager As RoundManager

        Private _yakuList As List(Of ChiriNulluo.Mahjong.Core.Yaku.Yaku)

        <SetUp()>
        Public Sub Initialize()
            _roundManager = MatchManagerController.GetInstance.MatchManager.RoundManager
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            _yakuList = _xmlAccess.GetYakuDataFromXML()
        End Sub

        <TestCase(True, "MaxHeart全員集合！",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801"})>
        <TestCase(False, "SplashStar全員集合！",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0201", "0902", "0902", "0902", "0801", "0801", "0801"})>
        <TestCase(True, "MaxHeart全員集合！",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0202", "0902", "0902", "0902", "0801", "0801", "0801"})>
        <TestCase(True, "SplashStar全員集合！",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0202", "0902", "0902", "0902", "0801", "0801", "0801"})>
        <TestCase(True, "オール5gogo!",
               {"0301", "0301", "0301", "0302", "0303", "0304", "0305", "0306", "0301", "0302", "0303", "0304", "0305", "0306"})>
        <TestCase(False, "オール5gogo!",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0202", "0902", "0902", "0902", "0801", "0801", "0801"})>
        <TestCase(True, "プリキュアオールスターズDX",
               {"0101", "0102", "0103", "0201", "0202", "0301", "0302", "0303", "0304", "0305", "0306", "0401", "0402", "0403"})>
        <TestCase(False, "プリキュアオールスターズDX",
               {"0101", "0101", "0102", "0102", "0103", "0103", "0201", "0202", "0902", "0902", "0902", "0801", "0801", "0801"})>
        Public Sub TestIsAccomplished(expectedValue As Boolean, yakuName As String, handIdArray As String())
            Me.MakeHand(handIdArray)
            Dim _hand As Hand = Me._roundManager.PlayersList(0).Hand
            Dim _tileSet As New List(Of String)
            Assert.AreEqual(expectedValue, GetYaku(yakuName).IsAccomplished(_hand))
        End Sub

        '<TestCase(True, {"0301", "0301", "0301", "0302", "0302", "0302", "0303", "0303", "0303", "0305", "0305", "0305", "0306", "0306"}, {"0301", "0302", "0303", "0304", "0305", "0306"})>
        '<TestCase(False, {"0301", "0301", "0301", "0302", "0302", "0302", "0303", "0303", "0303", "0305", "0305", "0305", "0101", "0101"}, {"0301", "0302", "0303", "0304", "0305", "0306"})>
        'Public Sub TestIsEveryTileIncludedOfTileSet(expectedValue As Boolean, handIdArray As String(), tileSetIdArray As String())
        '    Me.MakeHand(handIdArray)
        '    Dim _hand As Hand = Me._roundManager.PlayersList(0).Hand
        '    Dim _tileSet As New List(Of String)
        '    _tileSet.AddRange(tileSetIdArray)
        '    Assert.AreEqual(expectedValue, YakuEvaluator.IsEveryTileIncludedOfTileSet(_hand, _tileSet))
        'End Sub

#Region "テスト用補助メソッド"

        'UNIMPLEMENTED： PrecureHandCheckerに実装したメソッドのコピペしたため、コード重複している
        ''' <summary>
        ''' 牌IDのリストによって指定された通りに手牌を作成する
        ''' </summary>
        ''' <param name="precureIDList"></param>
        Private Sub MakeHand(precureIDList As String())
            For Each _precureID As String In precureIDList
                Me.AddTileToMyHand(_precureID)
            Next
        End Sub

        'UNIMPLEMENTED： PrecureHandCheckerに実装したメソッドのコピペしたため、コード重複している
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

        ''' <summary>
        ''' 役名を指定してYakuオブジェクトを取得する
        ''' </summary>
        ''' <returns></returns>
        Private Function GetYaku(yakuName) As ChiriNulluo.Mahjong.Core.Yaku.Yaku
            Return Me._yakuList.Where(Function(x) x.Name = yakuName)(0)
        End Function

#End Region
    End Class
End Namespace
