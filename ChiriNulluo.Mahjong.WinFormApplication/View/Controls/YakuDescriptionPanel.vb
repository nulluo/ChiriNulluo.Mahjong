Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

Public Class YakuDescriptionPanel

    Private Const MaxTileNum As Integer = 14

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Public Sub New(name As String, point As Integer, description As String, tiles As Pile)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.YakuNameField.Text = name
        Me.PointField.Text = point & My.Resources.LabelPoint
        Me.ConditionField.Text = My.Resources.LabelYakuCondition
        Me.DescriptionField.Text = description

        Dim i As Integer = 0
        For Each _tile As Tile In tiles
            Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & i, True)(0), PictureBox)
            _pictureBox.Image = Me.GetTileImage(_tile)
            i += 1
        Next

        For j As Integer = i To MaxTileNum - 1
            Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & j, True)(0), PictureBox)
            _pictureBox.Image = Nothing
        Next

    End Sub


    Private Function GetTileImage(tile As Tile) As Image
        'ベースとなる白牌のImageオブジェクト取得
        Dim _baseImage As Image = My.Resources.StoodTileBase
        Dim _g As Graphics = Graphics.FromImage(_baseImage)

        '白牌にキャラ絵・テキストを描画

        'こう書くと、↓g.DrawImageする時にエラーになる
        'Dim _diffImage As Bitmap = Precure.Tiles.PrecureCharacterSet.GetInstance.TileImages(tile.ID)

        '↓プロジェクト内のリソースを使うとエラーなしに動く
        'Dim _diffImage As Bitmap = My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", tile.ID))

        '↓PreCureCharacterTile.ImageはPrecureCharacterSet.TileImagesと内部実装が異なるのでこれなら動く
        Dim _diffImage As Bitmap = DirectCast(tile, Precure.Tiles.PreCureCharacterTile).Image

        _g.DrawImage(_diffImage, 0, 23, 48, 53)

        'リソース解放
        _diffImage.Dispose()
        _g.Dispose()
        Return _baseImage

    End Function

End Class
