Imports System.ComponentModel
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace View
    'UNIMPLEMENTED：もっと抽象化すればこのクラスは、Coreに入れられるはず
    <System.ComponentModel.ComplexBindingProperties("DataSource")>
    Public Class HorizontalDiscardedPilePanel
#Region "Property"

        Private WithEvents _dataSource As DiscardPile
        Public Property DataSource As DiscardPile
            Get
                Return _dataSource
            End Get
            Set(value As DiscardPile)
                _dataSource = value
                Me.SetAllTileImages()
            End Set
        End Property

        Private Property TilePictureList As New List(Of PictureBox)

#End Region

#Region "Event"

        Public Event TilePicture_Click As EventHandler(Of TilePictureClickEventArgs)

        Private Sub ClickTilePicture(sender As Object, e As EventArgs)
            Dim _index As Integer = CInt(DirectCast(sender, PictureBox).Tag)
            If _index <= Me.DataSource.Count - 1 Then
                RaiseEvent TilePicture_Click(Me, New TilePictureClickEventArgs(_index))
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

            '最後のツモをする人は牌を捨てないので、(最大ツモ数-1)-1が、捨て牌の末尾インデックスになる
            For i As Integer = 0 To Constants.MaxDrawTimes2PlayersMatch - 2
                Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & i, True)(0), PictureBox)
                _pictureBox.Tag = i
                If Not Me.DesignMode Then
                    _pictureBox.Image = Nothing
                End If
                Me.TilePictureList.Add(_pictureBox)
                AddHandler _pictureBox.Click, AddressOf Me.ClickTilePicture
                AddHandler _pictureBox.MouseEnter, AddressOf Me.MouseEnterTilePicture
                AddHandler _pictureBox.MouseLeave, AddressOf Me.MouseLeaveTilePicture
            Next

        End Sub

        ''' <summary>
        ''' 牌を指定して画像を描画する
        ''' </summary>
        ''' <param name="tile">描画するTile</param>
        ''' <param name="pictureBoxID">描画対象のPictureBoxのインデックス</param>
        Private Sub SetTileImage(tile As Tile, pictureBoxID As Integer)

            'ベースとなる白牌のImageオブジェクト取得
            Dim _baseImage As Image = My.Resources.FallenTileBase
            Dim _g As Graphics = Graphics.FromImage(_baseImage)

            '白牌にキャラ絵・テキストを描画
            Dim _diffImage As Bitmap = DirectCast(tile, Precure.Tiles.PreCureCharacterTile).Image

            'Dim _diffImage As Image = My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", tileID))
            _g.DrawImage(_diffImage, 0, 3)

            'リソース解放
            _diffImage.Dispose()
            _g.Dispose()

            'PictureBoxに表示
            Me.TilePictureList(pictureBoxID).Image = _baseImage
            Me.TilePictureList(pictureBoxID).BringToFront()
        End Sub

        ''' <summary>
        ''' 全捨て牌の表示を更新する。
        ''' </summary>
        Private Sub SetAllTileImages()

            If Not _dataSource Is Nothing Then
                For i As Integer = 0 To _dataSource.Count - 1
                    Dim _tile = _dataSource(i)
                    Me.SetTileImage(_tile, i)
                Next

                '牌の数が変わった場合の対応
                For i As Integer = _dataSource.Count To Me.TilePictureList.Count - 1
                    Me.TilePictureList(i).Image = Nothing
                Next

            End If
        End Sub

        ''' <summary>
        ''' モデルであるDiscardPileの内容が変化したイベントを捕捉して牌の画像を更新する
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub DataSource_ListChanged(sender As Object, e As PropertyChangedEventArgs) Handles _dataSource.PropertyChanged
            Me.SetAllTileImages()
        End Sub

    End Class
End Namespace