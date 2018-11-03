Imports ChiriNulluo.Mahjong.Core.Tiles
Imports System.Drawing
Imports System.IO

Namespace Tiles

    Public Class PreCureCharacterTile
        Inherits Tile

        ''' <summary>
        ''' 特殊キャラ牌であるかどうか。
        ''' </summary>
        Public IsSpecial As Boolean? = False

        Public Sub New(precureID As String, name As String, cureName As String, isSpecial As Boolean)
            Me.ID = precureID
            Me.Name = name
            Me.SuitID = Left(precureID, 2)
            Me.Number = CInt(Right(precureID, 2))
            Me.CureName = cureName
            Me.IsSpecial = isSpecial
        End Sub

        Public Sub New(suitID As String, number As String, name As String, cureName As String, isSpecial As Boolean)
            Me.ID = suitID & number
            Me.Name = name
            Me.SuitID = suitID
            Me.Number = CInt(number)
            Me.CureName = cureName
            Me.IsSpecial = isSpecial
        End Sub

        'UNIMPLEMENTED：この実装には問題がある。今はプリキュアしか牌がないからよいが、他のタイプの牌が混ざると、
        'プリキュア牌とバットマン牌が比較可能になってしまう。しかし、引数をTileMotif型から具体的なPrecureCharacterに変えてしまうと
        'Implementsにならなくなってしまうのでひとまずこのままにしてある
        Public Overrides Function IsSameColorWith(targetPrecure As Tile) As Boolean
            Return Me.SuitID = DirectCast(targetPrecure, PreCureCharacterTile).SuitID
        End Function

        Public Property SuitID As String
        Public Property Number As Integer
        Public Property CureName As String



        ''' <summary>
        ''' ある牌の隣の牌(同じSuitに属するものに限る)を返す。隣の牌が存在しない場合は空のListを返す。
        ''' </summary>
        ''' <returns></returns>
        Public Function NeighbourTileIDs() As List(Of String)

            Dim _neighbours As New List(Of String)

            If Me.Number > 0 Then
                Dim _numberLeft As String
                _numberLeft = String.Format("{0:00}", (Me.Number - 1))
                Dim _tileIDLeft As String
                _tileIDLeft = Me.SuitID & _numberLeft

                If PrecureCharacterSet.GetInstance.AllCharacterTilesIDList.Contains(_tileIDLeft) Then
                    _neighbours.Add(_tileIDLeft)
                End If
            End If

            Dim _numberRight As String
            _numberRight = String.Format("{0:00}", (Me.Number + 1))
            Dim _tileIDRight As String
            _tileIDRight = Me.SuitID & _numberRight

            If PrecureCharacterSet.GetInstance.AllCharacterTilesIDList.Contains(_tileIDRight) Then
                _neighbours.Add(_tileIDRight)
            End If

            Return _neighbours
        End Function

#Region "牌画像・アイコン画像の取得"

        ''' <summary>
        ''' キャラクターアイコンの画像を取得する。(牌の形ではなくキャラクターの画像のみを取得する。)
        ''' </summary>
        ''' <returns>キャラクターアイコンの画像を取得する。(牌の形ではなくキャラクターの画像のみを取得する。)</returns>
        Public ReadOnly Property IconImage As System.Drawing.Bitmap
            Get
                '※ 牌アイコンはリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Dim _path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconDiffImageDir, String.Format("Precure{0:0000}.png", Me.ID))
                Return New Bitmap(_path)
            End Get
        End Property


        ''' <summary>
        ''' キャラクター牌(立った状態)の画像を取得する。(牌の形で取得する。)
        ''' </summary>
        ''' <returns>キャラクター牌(立った状態)の画像を取得する。(牌の形で取得する。)</returns>
        Public ReadOnly Property StoodTileImage As Image
            Get
                'ベースとなる白牌のImageオブジェクト取得
                Dim _baseImage As Image
                Dim _g As Graphics

                'こう書くと、↓g.DrawImageする時にエラーになる
                'Dim _diffImage As Bitmap = Precure.Tiles.PrecureCharacterSet.GetInstance.TileImages(tile.ID)

                '↓プロジェクト内のリソースを使うとエラーなしに動く
                'Dim _diffImage As Bitmap = My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", tile.ID))

                '↓PreCureCharacterTile.IconImageはPrecureCharacterSet.TileImagesと内部実装が異なるのでこれなら動く
                Dim _diffImage As Bitmap = Me.IconImage

                '白牌にキャラ絵・テキストを描画

                If Me.IsSpecial Then
                    _baseImage = PreCureCharacterTile.StoodTileBaseSpecialImage
                Else
                    _baseImage = PreCureCharacterTile.StoodTileBaseImage
                End If

                _g = Graphics.FromImage(_baseImage)
                _g.DrawImage(_diffImage, 0, 23, 48, 53)


                'リソース解放
                _diffImage.Dispose()
                _g.Dispose()

                Return _baseImage
            End Get
        End Property


        ''' <summary>
        ''' キャラクター牌(倒した状態)の画像を取得する。(牌の形で取得する。)
        ''' </summary>
        ''' <returns>キャラクター牌(倒した状態)の画像を取得する。(牌の形で取得する。)</returns>
        Public ReadOnly Property FallenTileImage As Image
            Get
                'ベースとなる白牌のImageオブジェクト取得
                Dim _baseImage As Image


                If Me.IsSpecial Then
                    _baseImage = PreCureCharacterTile.FallenTileBaseSpecialImage
                Else
                    _baseImage = PreCureCharacterTile.FallentileBaseImage
                End If

                '立直宣言後の牌の場合は強調表示をする
                If Me.IsTileAfterRiichi Then
                    _baseImage = PreCureCharacterTile.CreateColorCorrectedImage(_baseImage, 1.1, 0.6, 0.6, 0, 0, 0)
                End If

                Dim _g As Graphics = Graphics.FromImage(_baseImage)

                '白牌にキャラ絵・テキストを描画
                Dim _diffImage As Bitmap = Me.IconImage

                'Dim _diffImage As Image = My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", tileID))
                _g.DrawImage(_diffImage, 0, 0, 48, 53)

                'リソース解放
                _diffImage.Dispose()
                _g.Dispose()

                Return _baseImage
            End Get
        End Property

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
                'g.DrawImage(img, New Rectangle(0, 0, img.Width, 53),
                g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height),
                    0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)
            End Using
            Return newImg
        End Function


        ''' 
        ''' <summary>
        ''' 拡大キャラクターアイコンの画像を取得する。(牌の形ではなくキャラクターの画像のみを取得する。)
        ''' </summary>
        ''' <returns>拡大キャラクターアイコンの画像を取得する。(牌の形ではなくキャラクターの画像のみを取得する。)</returns>
        Public ReadOnly Property EnlargedImage As System.Drawing.Bitmap
            Get
                '※ 牌アイコンはリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Return New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconEnlargedImageDir, String.Format("TileEnlarged{0:0000}.png", Me.ID)))
            End Get
        End Property


        ''' <summary>
        ''' 立った状態の無地の通常牌の画像を取得する。(表面表示)
        ''' </summary>
        ''' <returns>立った状態の無地の通常牌の画像を取得する。(表面表示)</returns>
        Private Shared ReadOnly Property StoodTileBaseImage As Bitmap
            Get
                '※ 画像はリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Return New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconTilePartsDir, "StoodTileBase.png"))

            End Get
        End Property

        ''' <summary>
        ''' 立った状態の無地のボーナス牌の画像を取得する。(表面表示)
        ''' </summary>
        ''' <returns>立った状態の無地のボーナス牌の画像を取得する。(表面表示)</returns>
        Private Shared ReadOnly Property StoodTileBaseSpecialImage As Bitmap
            Get
                '※ 画像はリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Return New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconTilePartsDir, "StoodTileBaseSpecial.png"))

            End Get
        End Property

        ''' <summary>
        ''' 倒した状態の無地の通常牌の画像を取得する。(表面表示)
        ''' </summary>
        ''' <returns>倒した状態の無地の通常牌の画像を取得する。(表面表示)</returns>
        Private Shared ReadOnly Property FallentileBaseImage As Bitmap
            Get
                '※ 画像はリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Return New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconTilePartsDir, "FallenTileBase.png"))

            End Get
        End Property

        ''' <summary>
        ''' 倒した状態の無地のボーナス牌の画像を取得する。(表面表示)
        ''' </summary>
        ''' <returns>倒した状態の無地のボーナス牌の画像を取得する。(表面表示)</returns>
        Private Shared ReadOnly Property FallenTileBaseSpecialImage As Bitmap
            Get
                '※ 画像はリソースには含めない。(dllのサイズ肥大化を防ぐため)
                Return New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                               Constants.IconTilePartsDir, "FallenTileBaseSpecial.png"))

            End Get
        End Property

#End Region
    End Class

End Namespace