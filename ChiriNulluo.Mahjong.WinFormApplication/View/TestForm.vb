Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

Public Class TestForm
    Private Sub MessageWindowFormButton_Click(sender As Object, e As EventArgs) Handles MessageWindowFormButton.Click
        Dim _return = MessageWindowForm.ShowWindow("メッセージがここに入る", Me, "ロンする", "ポンをする", "チーをする", "キャンセル")
        Debug.WriteLine("返り値：" & _return)
    End Sub



    Private Sub openTileSelectWindowFormButton_Click(sender As Object, e As EventArgs) Handles openTileSelectWindowFormButton.Click
        Dim _pileList(1) As RevealedTiles
        Dim _tile0, _tile1, _tile2, _tile3 As Tile
        _tile0 = New PreCureCharacterTile("0301", "夢原のぞみ", "キュアドリーム")
        _tile1 = New PreCureCharacterTile("0302", "夏木りん", "キュアルージュ")
        _tile2 = New PreCureCharacterTile("0303", "春日野うらら", "キュアレモネード")
        _tile3 = New PreCureCharacterTile("0304", "秋元こまち", "キュアミント")

        Dim _pile As RevealedTiles
        _pile = New RevealedTiles(False, _tile0, _tile1, _tile2)
        _pileList(0) = (_pile)

        _pile = New RevealedTiles(False, _tile1, _tile2, _tile3)
        _pileList(1) = (_pile)

        TileSelectWindowForm.ShowWindow("どれでチーするモフ？", Me, _pileList)


    End Sub

    Private Sub openGameTasteWindowTestForm1Button_Click(sender As Object, e As EventArgs) Handles openGameTasteWindowTestForm1Button.Click
        GameTasteWindowTestForm1.Show()
    End Sub
End Class