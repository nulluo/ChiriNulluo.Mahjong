Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Core.Tiles

    <TestFixture>
    Public Class RevealedTilesTest
        <TestCase(True, "MyTile1 and myTile2 and opponentsTile are not Triplet.", True, "0101", "0102", "0101")>
        <TestCase(True, "MyTile1 and myTile2 and opponentsTile are not Chow.", False, "0101", "0102", "0104")>
        <TestCase(True, "MyTile1 and myTile2 and opponentsTile are not Chow.", False, "0101", "0101", "0101")>
        <TestCase(True, "MyTile1 and myTile2 and opponentsTile are not Triplet.", True, "0104", "0102", "0103")>
        <TestCase(False, "", True, "0101", "0101", "0101")>
        <TestCase(False, "", False, "0104", "0102", "0103")>
        Public Sub TestNew(exceptionOccurs As Boolean, expectedErrorMessage As String, isTriplet As Boolean, myTile1ID As String, myTile2ID As String, opponentsTileID As String)
            Dim _myTile1 As New PreCureCharacterTile(myTile1ID, String.Empty, String.Empty)
            Dim _myTile2 As New PreCureCharacterTile(myTile2ID, String.Empty, String.Empty)
            Dim _opponentsTile As New PreCureCharacterTile(opponentsTileID, String.Empty, String.Empty)

            Try
                Dim _revealedTiles = New RevealedTiles(isTriplet, _myTile1, _myTile2, _opponentsTile)
                Assert.That(Not exceptionOccurs)
                Assert.That(_opponentsTile Is _revealedTiles.OpponentsTile)

            Catch ex As ArgumentException
                Assert.That(exceptionOccurs)
                Assert.That(ex.Message = expectedErrorMessage)
            End Try

        End Sub
    End Class


End Namespace
