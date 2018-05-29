Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Precure.Tiles

    <TestFixture>
    Public Class Pile2Test

        Public Sub SortTest()

        End Sub



        'UNIMPLEMENTED：PrecureHandCheckerTestクラスにある同名メソッドと二重実装になっている？
#Region "テスト用補助メソッド"

        ''' <summary>
        ''' 牌IDのリストによって指定された通りに手牌を作成する
        ''' </summary>
        ''' <param name="precureIDList"></param>
        Private Sub MakeHand(precureIDList As String())
            For Each _precureID As String In precureIDList
                Me.AddTileToMyHand(_precureID)
            Next
        End Sub

        ''' <summary>
        ''' 山から指定したIDの牌を手牌に加える
        ''' </summary>
        ''' <param name="id">牌ID</param>
        Private Sub AddTileToMyHand(id As String)
            'Dim _pickedTile As Tile
            'Dim _playersHand As Hand = _roundManager.PlayersList(0).Hand
            'With _roundManager
            '    _pickedTile = .PickOutTileFromWall(id)

            '    'もし指定したIDの牌が山に残っていなければ、強制的に牌のモチーフを上書きして取得する。
            '    If _pickedTile Is Nothing Then
            '        _pickedTile = .WallPile.PopNextDraw()
            '        .ChangeTileMotif(_pickedTile, New PreCureCharacter(id, ""))
            '    End If

            '    .AddTile(_pickedTile, _playersHand)
            'End With
        End Sub
#End Region

    End Class
End Namespace
