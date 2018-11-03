Imports System.ComponentModel
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace View
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
            If IsStood Then
                Me.TilePictureList(pictureBoxID).Image = DirectCast(tile, PreCureCharacterTile).StoodTileImage
            Else
                Me.TilePictureList(pictureBoxID).Image = DirectCast(tile, PreCureCharacterTile).FallenTileImage
            End If

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
        ''' モデルであるHandの内容が変化したイベントを捕捉して牌の画像を更新する
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub DataSource_ListChanged(sender As Object, e As PropertyChangedEventArgs) Handles _dataSource.PropertyChanged
            Me.DisplayAllTilesAccordingToDisplayStyle()
        End Sub

    End Class
End Namespace