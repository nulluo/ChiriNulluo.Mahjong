Imports ChiriNulluo.Mahjong.Core
Imports ChiriNulluo.Mahjong.WinFormApplication
Imports ChiriNulluo.Mahjong.Precure
Imports ChiriNulluo.Mahjong.Precure.Tiles
Namespace Core

    <TestFixture>
    Public Class RoundManagerTest

        Private _roundManager As RoundManager

        <SetUp()>
        Public Sub Initialize()
            _roundManager = MatchManagerController.GetInstance.MatchManager.RoundManager
        End Sub

        <TestCase>
        Public Sub TestSearchTilePrecure()
            '最初は、山牌の数は200
            Assert.AreEqual(200, _roundManager.WallPile.Count)

            Dim _precure = DirectCast(Me._roundManager.SearchTile("0301", _roundManager.WallPile), PreCureCharacterTile)
            Assert.AreEqual("0301", _precure.ID)
            Assert.AreEqual("03", _precure.SuitID)
            Assert.AreEqual(1, _precure.Number)
            Assert.AreEqual("夢原のぞみ", _precure.Name)

            '検索して見つかった牌の参照を取得するだけなので、山牌、手牌の数は変化しない
            Assert.AreEqual(0, _roundManager.PlayersList(0).Hand.TotalCount)
            Assert.AreEqual(200, _roundManager.WallPile.Count)
        End Sub

        <TestCase>
        Public Sub TestPickOutTileFromWallPrecure()
            '最初は、山牌の数は200
            Assert.AreEqual(200, _roundManager.WallPile.Count)

            Dim _tile = Me._roundManager.PickOutTileFromWall("0402")

            Assert.AreEqual("蒼乃美希", _tile.Name)
            '検索して見つかった牌を山牌から取り出すため、山牌は1個減る。手牌の数は変化しない
            Assert.AreEqual(0, _roundManager.PlayersList(0).Hand.TotalCount)
            Assert.AreEqual(199, _roundManager.WallPile.Count)
        End Sub

        <TestCase>
        Public Sub TestTryMoveTile()
            With Me._roundManager

                '最初は、山牌の数は200
                Assert.AreEqual(200, .WallPile.Count)

                '1) なぎさ1枚を山からHumanPlayerに移動
                Assert.IsTrue(.TryMoveTile("0101", .WallPile, .PlayersList(0).Hand.MainTiles))
                Assert.AreEqual(199, .WallPile.Count)
                Assert.AreEqual(1, .PlayersList(0).Hand.TotalCount)
                Assert.AreEqual("美墨なぎさ", .PlayersList(0).Hand.MainTiles(0).Name)

                '2) なぎさ1枚をHumanPlayerの手牌からCOMPlayerの手牌に移動
                Assert.IsTrue(.TryMoveTile("0101", .PlayersList(0).Hand.MainTiles, .PlayersList(1).Hand.MainTiles))
                Assert.AreEqual(0, .PlayersList(0).Hand.TotalCount)
                Assert.AreEqual(1, .PlayersList(1).Hand.TotalCount)
                Assert.AreEqual("美墨なぎさ", .PlayersList(1).Hand.MainTiles(0).Name)

            End With

        End Sub
    End Class
End Namespace