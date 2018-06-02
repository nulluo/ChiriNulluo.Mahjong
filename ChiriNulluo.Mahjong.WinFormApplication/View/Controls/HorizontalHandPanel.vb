Imports System.ComponentModel
Imports ChiriNulluo.Mahjong.Core.Tiles

'UNIMPLEMENTED：もっと抽象化すればこのクラスは、Coreに入れられるはず
<System.ComponentModel.ComplexBindingProperties("DataSource")>
Public Class HorizontalHandPanel
#Region "Property"

    Private _displayStyle As ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle = Constants.HandPanelDisplayStyle.HiddenFromHuman
    Public Property DisplayStyle As ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle
        Get
            Return _displayStyle
        End Get
        Set(value As ChiriNulluo.Mahjong.WinFormApplication.Constants.HandPanelDisplayStyle)
            _displayStyle = value
            Me.DisplayAllTilesAccordingToDisplayStyle()

        End Set
    End Property


    Private WithEvents _dataSource As HiddenTiles
    Public Property DataSource As HiddenTiles
        Get
            Return _dataSource
        End Get
        Set(value As HiddenTiles)
            _dataSource = value
            Me.DisplayAllTilesAccordingToDisplayStyle()
        End Set
    End Property

    Private Property TilePictureList As New List(Of PictureBox)

#End Region

#Region "Event"

    Public Event TilePictureClick As EventHandler(Of TilePictureClickEventArgs)
    Private Sub ClickTilePicture(sender As Object, e As EventArgs)
        Dim _index As Integer = CInt(DirectCast(sender, PictureBox).Tag)
        If _index <= Me.DataSource.Count - 1 Then
            RaiseEvent TilePictureClick(Me, New TilePictureClickEventArgs(_index))
        End If
    End Sub

    Public Event TilePictureMouseEnter As EventHandler(Of TilePictureMouseEnterEventArgs)
    Private Sub MouseEnterTilePicture(sender As Object, e As EventArgs)
        Dim _index As Integer = CInt(DirectCast(sender, PictureBox).Tag)
        If _index <= Me.DataSource.Count - 1 Then
            RaiseEvent TilePictureMouseEnter(sender, New TilePictureMouseEnterEventArgs(_index))
        End If
    End Sub

    Public Event TilePictureMouseLeave As EventHandler(Of TilePictureMouseLeaveEventArgs)
    Private Sub MouseLeaveTilePicture(sender As Object, e As EventArgs)
        Dim _index As Integer = CInt(DirectCast(sender, PictureBox).Tag)
        If _index <= Me.DataSource.Count - 1 Then
            RaiseEvent TilePictureMouseLeave(sender, New TilePictureMouseLeaveEventArgs(_index))
        End If
    End Sub

#End Region

    Protected Overrides Sub InitLayout()
        MyBase.InitLayout()
        'ここに初期化処理を記述する

        'UNIMPLEMENTED：クリックの仕様検討する（シングルクリック/ダブルクリック どちらで牌を切るか？)
        'UNIMPLEMENTED：↑決めきれなかったらオプション化してユーザーに決めさせる
        For i As Integer = 0 To 14 - 1
            Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & i, True)(0), PictureBox)
            _pictureBox.Tag = i
            Me.TilePictureList.Add(_pictureBox)
            AddHandler _pictureBox.Click, AddressOf Me.ClickTilePicture
            AddHandler _pictureBox.MouseEnter, AddressOf Me.MouseEnterTilePicture
            AddHandler _pictureBox.MouseLeave, AddressOf Me.MouseLeaveTilePicture
        Next

    End Sub

    ''' <summary>
    ''' DisplayStyleプロパティの値に従って全牌の描画を実施する。。
    ''' </summary>
    Private Sub DisplayAllTilesAccordingToDisplayStyle()
        Select Case _displayStyle
            Case Constants.HandPanelDisplayStyle.ShownToHumanStood
                Me.SetAllTileImages()
            Case Constants.HandPanelDisplayStyle.ShownToHumanFallen
                Me.SetAllTileImages(False)
            Case Constants.HandPanelDisplayStyle.HiddenFromHuman
                Me.ShowBackOfAllTiles()
        End Select

    End Sub


    ''' <summary>
    ''' 牌を指定して画像を描画する
    ''' </summary>
    ''' <param name="tileID">描画するTileのイメージ</param>
    ''' <param name="pictureBoxID">描画対象のPictureBoxのインデックス</param>
    ''' <param name="IsStood">牌が立っている場合はTrue,牌を倒している場合はFalse</param>
    Private Sub SetTileImage(tile As Tile, pictureBoxID As Integer, Optional IsStood As Boolean = True)
        'PictureBox1に表示
        Me.TilePictureList(pictureBoxID).Image = Me.GetTileImage(tile, IsStood)

    End Sub

    ''' <summary>
    ''' ツモ牌を手牌から牌の幅ｘ0.5枚分だけ他の手牌から離して表示する
    ''' </summary>
    Public Sub KeepDrawnTileAtDistance()
        With Me.TilePictureList(_dataSource.Count - 1)
            If .Location.X = 48 * (_dataSource.Count - 1) Then
                .Location = New Point(.Location.X + 24, .Location.Y)
                .BringToFront()
            End If
        End With
    End Sub

    ''' <summary>
    ''' 全牌の表示を更新する。
    ''' </summary>
    ''' <param name="IsStood">牌が立っている場合はTrue,牌を倒している場合はFalse</param>
    Private Sub SetAllTileImages(Optional IsStood As Boolean = True)
        If Not _dataSource Is Nothing Then
            For i As Integer = 0 To _dataSource.Count - 1
                Dim _tile = _dataSource(i)
                Me.SetTileImage(_tile, i, IsStood)
            Next

            '牌の数が変わった場合の対応
            For i As Integer = _dataSource.Count To Me.TilePictureList.Count - 1
                Me.TilePictureList(i).Image = Nothing
            Next

        End If
    End Sub

    ''' <param name="IsStood">牌が立っている場合はTrue,牌を倒している場合はFalse</param>
    Private Function GetTileImage(tile As Tile, Optional IsStood As Boolean = True) As Image
        'ベースとなる白牌のImageオブジェクト取得
        Dim _baseImage As Image
        Dim _g As Graphics

        'こう書くと、↓g.DrawImageする時にエラーになる
        'Dim _diffImage As Bitmap = Precure.Tiles.PrecureCharacterSet.GetInstance.TileImages(tile.ID)

        '↓プロジェクト内のリソースを使うとエラーなしに動く
        'Dim _diffImage As Bitmap = My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", tile.ID))

        '↓PreCureCharacterTile.ImageはPrecureCharacterSet.TileImagesと内部実装が異なるのでこれなら動く
        Dim _diffImage As Bitmap = DirectCast(tile, Precure.Tiles.PreCureCharacterTile).Image

        '白牌にキャラ絵・テキストを描画

        If IsStood Then
            _baseImage = My.Resources.StoodTileBase
            _g = Graphics.FromImage(_baseImage)
            _g.DrawImage(_diffImage, 0, 23, 48, 53)
        Else
            _baseImage = My.Resources.FallenTileBase
            _g = Graphics.FromImage(_baseImage)
            _g.DrawImage(_diffImage, 0, 3)
        End If

        'リソース解放
        _diffImage.Dispose()
        _g.Dispose()

        Return _baseImage
    End Function

    ''' <summary>
    ''' 牌を強調表示するかどうかを設定する。
    ''' </summary>
    ''' <param name="tileID"></param>
    ''' <remarks>ツモってきた牌のマークなどに使用する</remarks>
    Public Sub SetTileMarked(marked As Boolean, targetTile As Tile)
        If Me.DataSource IsNot Nothing Then

            Dim _tileFound As Boolean = False
            Dim _pictureBoxID As Integer = 0
            For Each _tile As Tile In Me.DataSource
                If _tile Is targetTile Then
                    _tileFound = True
                    Exit For
                End If
                _pictureBoxID += 1
            Next

            If _tileFound Then

                Dim _bmp As Image = GetTileImage(targetTile)
                Dim _newBmp As Image
                If marked Then
                    _newBmp = CreateColorCorrectedImage(_bmp, 0.6, 1.4, 0.6, 0, 0, 0)
                    _bmp.Dispose()
                Else
                    _newBmp = _bmp
                End If

                With Me.TilePictureList(_pictureBoxID)
                    If .Image IsNot Nothing Then
                        .Image.Dispose()
                    End If
                    .Image = _newBmp
                End With

            End If

        End If


    End Sub

    ''' <summary>
    ''' 牌の裏面を表示する
    ''' </summary>
    ''' <param name="pictureBoxID"></param>
    Private Sub ShowBackOfTile(pictureBoxID As Integer)
        Dim _bmp As Image = DirectCast(My.Resources.ResourceManager.GetObject("TileStoodBack"), Image)
        Me.TilePictureList(pictureBoxID).Image = _bmp
    End Sub

    Public Sub ShowBackOfAllTiles()

        '最初に牌を表示する際にヌル参照エラーになるのを防止
        If _dataSource Is Nothing Then
            Return
        End If

        For i As Integer = 0 To _dataSource.Count - 1
            ShowBackOfTile(i)
        Next

        '牌の数が変わった場合の対応
        For i As Integer = _dataSource.Count To Me.TilePictureList.Count - 1
            Me.TilePictureList(i).Image = Nothing
        Next

    End Sub

    ''' <summary>
    ''' 指定した画像の色を補正した画像を取得する
    ''' </summary>
    ''' <param name="img">色の補正をする画像</param>
    ''' <param name="rScale">赤に掛ける倍率</param>
    ''' <param name="gScale">緑に掛ける倍率</param>
    ''' <param name="bScale">青に掛ける倍率</param>
    ''' <param name="rAdd">赤に対する加算</param>
    ''' <param name="gAdd">緑に対する加算</param>
    ''' <param name="bAdd">青に対する加算</param>
    ''' <returns></returns>
    Private Shared Function CreateColorCorrectedImage(
            ByVal img As Image, ByVal rScale As Single,
            ByVal gScale As Single, ByVal bScale As Single,
            ByVal rAdd As Single, gAdd As Single, bAdd As Single) As Image

        '補正された画像の描画先となるImageオブジェクトを作成
        Dim newImg As New Bitmap(img.Width, img.Height)
        'newImgのGraphicsオブジェクトを取得
        Using g = Graphics.FromImage(newImg)
            'ColorMatrixオブジェクトの作成
            '指定された倍率を掛けるための行列を指定する
            Dim cm As New System.Drawing.Imaging.ColorMatrix(New Single()() _
                {New Single() {rScale, 0, 0, 0, 0},
                 New Single() {0, gScale, 0, 0, 0},
                 New Single() {0, 0, bScale, 0, 0},
                 New Single() {0, 0, 0, 1, 0},
                 New Single() {rAdd, gAdd, bAdd, 0, 1}})

            'ImageAttributesオブジェクトの作成
            Dim ia As New System.Drawing.Imaging.ImageAttributes()
            'ColorMatrixを設定する
            ia.SetColorMatrix(cm)

            'ImageAttributesを使用して描画
            g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height),
                        0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
        End Using
        Return newImg
    End Function


    ''' <summary>
    ''' モデルであるHandの内容が変化したイベントを捕捉して牌の画像を更新する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataSource_ListChanged(sender As Object, e As PropertyChangedEventArgs) Handles _dataSource.PropertyChanged
        Me.DisplayAllTilesAccordingToDisplayStyle()
    End Sub

End Class
