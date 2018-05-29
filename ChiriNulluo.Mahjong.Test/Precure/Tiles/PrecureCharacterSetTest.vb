Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Precure.Tiles

    <TestFixture>
    Public Class PrecureCharacterSetTest

        <SetUp()>
        Public Sub Initialize()
            PrecureCharacterSet.GetInstance.InitializeTileListForNewRound()
        End Sub

        <Test()>
        Public Sub TestCurrentRoundTotalTilesList()
            With PrecureCharacterSet.GetInstance.CurrentRoundTotalTilesIDList

                Assert.AreEqual((44 + 3) * 4, .Count)
                Assert.AreEqual("0101", .Item(0))
                Assert.AreEqual("1103", .Item(43)）
                Assert.AreEqual("1103", .Item(44 * 4 - 1）)

            End With
        End Sub

        <TestCase("九条ひかり", "0103")>
        <TestCase("美々野くるみ", "0306")>
        <TestCase("調辺アコ", "0604")>
        <TestCase("来海えりか", "0502")>
        <TestCase("白雪ひめ", "0902")>
        <TestCase("霧生満", "0200")>
        <TestCase("東山聖歌", "0605")>
        Public Sub TestGetTileDefinition(expectedValue As String, precureID As String)
            Dim _precureTile = PrecureCharacterSet.GetInstance.GetTileDefinition(precureID)

            Assert.AreEqual(expectedValue, _precureTile.Name)
        End Sub

    End Class

End Namespace