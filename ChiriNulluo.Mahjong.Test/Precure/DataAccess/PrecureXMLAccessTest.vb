Imports System.IO
Imports ChiriNulluo.Mahjong.Core.Yaku
Imports ChiriNulluo.Mahjong.Precure.DataAccess
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace Precure.DataAccess

    <TestFixture>
    Public Class PrecureXMLAccessTest
        <Test()>
        Public Sub TestGetYakuDataFromXML()
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance(Path.Combine(My.Application.Info.DirectoryPath, "TestPrejongConfigSimple.xml"))
            Dim _yakuList As List(Of Yaku) = _xmlAccess.GetYakuDataFromXML()

            Assert.AreEqual(2, _yakuList.Count)
            Assert.AreEqual("MaxHeart全員集合！", _yakuList(0).Name)
            Assert.AreEqual(YakuType.SpecificTileSetIsSubSetOfHand, _yakuList(0).Type)
            Assert.AreEqual(1000, _yakuList(0).Point)
            Assert.AreEqual("0101", _yakuList(0).TileSet(0))
            Assert.AreEqual("0102", _yakuList(0).TileSet(1))
            Assert.AreEqual("0103", _yakuList(0).TileSet(2))

            Assert.AreEqual("オールプリアラ", _yakuList(1).Name)
            Assert.AreEqual(YakuType.HandIsSubSetOfSpecificTileSet, _yakuList(1).Type)
            Assert.AreEqual(1000, _yakuList(1).Point)
            Assert.AreEqual("1201", _yakuList(1).TileSet(0))
            Assert.AreEqual("1202", _yakuList(1).TileSet(1))
            Assert.AreEqual("1203", _yakuList(1).TileSet(2))
            Assert.AreEqual("1204", _yakuList(1).TileSet(3))
            Assert.AreEqual("1205", _yakuList(1).TileSet(4))
            Assert.AreEqual("1206", _yakuList(1).TileSet(5))

        End Sub

        <Test()>
        Public Sub TestGetTileSuitsCount()
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance(Path.Combine(My.Application.Info.DirectoryPath, "TestPrejongConfigSimple.xml"))
            Assert.AreEqual(2, _xmlAccess.GetTileSuitsCount)
        End Sub

        <TestCase("ふたりはプリキュアMaxHeart", 3, "01")>
        Public Sub TestGetTileSuit(expectedName As String, expectedCount As Integer, suitID As String)
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Assert.AreEqual(expectedName, _xmlAccess.GetTileSuit(suitID).Name)
            Assert.AreEqual(expectedCount, _xmlAccess.GetTileSuit(suitID).TotalTilesCount)
        End Sub

#Region "牌情報取得系メソッド"

        <Test()>
        Public Sub TestGetCharacterDataFromXML()
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance(Path.Combine(My.Application.Info.DirectoryPath, "TestPrejongConfigSimple.xml"))
            Dim _precureList As List(Of PreCureCharacterTile) = _xmlAccess.GetCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing, True)

            Assert.AreEqual(4, _precureList.Count)

            Assert.AreEqual("0202", _precureList(0).ID)
            Assert.AreEqual("02", _precureList(0).SuitID)
            Assert.AreEqual(2, _precureList(0).Number)
            Assert.AreEqual("美翔舞", _precureList(0).Name)

            Assert.AreEqual("1206", _precureList(1).ID)
            Assert.AreEqual("12", _precureList(1).SuitID)
            Assert.AreEqual(6, _precureList(1).Number)
            Assert.AreEqual("キラ星シエル", _precureList(1).Name)

            Assert.AreEqual("0200", _precureList(2).ID)
            Assert.AreEqual("02", _precureList(2).SuitID)
            Assert.AreEqual(0, _precureList(2).Number)
            Assert.AreEqual("霧生満", _precureList(2).Name)

            Assert.AreEqual("0203", _precureList(3).ID)
            Assert.AreEqual("02", _precureList(3).SuitID)
            Assert.AreEqual(3, _precureList(3).Number)
            Assert.AreEqual("霧生薫", _precureList(3).Name)

            _precureList = _xmlAccess.GetCharacterDataFromXML("02", Nothing, Nothing, Nothing, True)

            Assert.AreEqual(3, _precureList.Count)

            Assert.AreEqual("0202", _precureList(0).ID)
            Assert.AreEqual("02", _precureList(0).SuitID)
            Assert.AreEqual(2, _precureList(0).Number)
            Assert.AreEqual("美翔舞", _precureList(0).Name)

            Assert.AreEqual("0200", _precureList(1).ID)
            Assert.AreEqual("02", _precureList(1).SuitID)
            Assert.AreEqual(0, _precureList(1).Number)
            Assert.AreEqual("霧生満", _precureList(1).Name)

            Assert.AreEqual("0203", _precureList(2).ID)
            Assert.AreEqual("02", _precureList(2).SuitID)
            Assert.AreEqual(3, _precureList(2).Number)
            Assert.AreEqual("霧生薫", _precureList(2).Name)

            _precureList = _xmlAccess.GetCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing)

            Assert.AreEqual(2, _precureList.Count)

            Assert.AreEqual("0202", _precureList(0).ID)
            Assert.AreEqual("02", _precureList(0).SuitID)
            Assert.AreEqual(2, _precureList(0).Number)
            Assert.AreEqual("美翔舞", _precureList(0).Name)

            Assert.AreEqual("1206", _precureList(1).ID)
            Assert.AreEqual("12", _precureList(1).SuitID)
            Assert.AreEqual(6, _precureList(1).Number)
            Assert.AreEqual("キラ星シエル", _precureList(1).Name)

        End Sub

        <Test()>
        Public Sub TestGetRegularPrecureDataFromXML()
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance(Path.Combine(My.Application.Info.DirectoryPath, "TestPrejongConfigSimple.xml"))
            Dim _precureList As List(Of PreCureCharacterTile) = _xmlAccess.GetRegularPrecureDataFromXML(Nothing, Nothing, Nothing, Nothing)

            Assert.AreEqual(2, _precureList.Count)

            Assert.AreEqual("0202", _precureList(0).ID)
            Assert.AreEqual("02", _precureList(0).SuitID)
            Assert.AreEqual(2, _precureList(0).Number)
            Assert.AreEqual("美翔舞", _precureList(0).Name)

            Assert.AreEqual("1206", _precureList(1).ID)
            Assert.AreEqual("12", _precureList(1).SuitID)
            Assert.AreEqual(6, _precureList(1).Number)
            Assert.AreEqual("キラ星シエル", _precureList(1).Name)

            _precureList = _xmlAccess.GetRegularPrecureDataFromXML("02", Nothing, Nothing, Nothing)

            _precureList.ForEach(Sub(x) Assert.AreEqual("美翔舞", x.Name))

            'UNIMPLEMENTED：GetPrecureDataFromXMLメソドで引数Nothingにしない場合のテスト（必要かどうかは要判断）

        End Sub

        <Test()>
        Public Sub TestGetSpecialCharacterDataFromXML()
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance(Path.Combine(My.Application.Info.DirectoryPath, "TestPrejongConfigSimple.xml"))
            Dim _precureList As List(Of PreCureCharacterTile) = _xmlAccess.GetSpecialCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing)

            Assert.AreEqual(2, _precureList.Count)

            Assert.AreEqual("0200", _precureList(0).ID)
            Assert.AreEqual("02", _precureList(0).SuitID)
            Assert.AreEqual(0, _precureList(0).Number)
            Assert.AreEqual("霧生満", _precureList(0).Name)

            Assert.AreEqual("0203", _precureList(1).ID)
            Assert.AreEqual("02", _precureList(1).SuitID)
            Assert.AreEqual(3, _precureList(1).Number)
            Assert.AreEqual("霧生薫", _precureList(1).Name)

            _precureList = _xmlAccess.GetSpecialCharacterDataFromXML(Nothing, "03", Nothing, Nothing)
            _precureList.ForEach(Sub(x) Assert.AreEqual("霧生薫", x.Name))

        End Sub


#End Region

    End Class
End Namespace
