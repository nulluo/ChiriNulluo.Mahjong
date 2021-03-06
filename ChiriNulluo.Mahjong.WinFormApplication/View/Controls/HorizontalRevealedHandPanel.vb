﻿Imports System.ComponentModel
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace View
    'UNIMPLEMENTED：もっと抽象化すればこのクラスは、Coreに入れられるはず
    <System.ComponentModel.ComplexBindingProperties("DataSource")>
    Public Class HorizontalRevealedHandPanel
#Region "Property"

        Private WithEvents _dataSource As RevealedTiles
        Public Property DataSource As RevealedTiles
            Get
                Return _dataSource
            End Get
            Set(value As RevealedTiles)
                If value Is Nothing Then
                    Me.Visible = False
                Else
                    Me.Visible = True
                    _dataSource = value
                    Me.SetAllTileImages()
                End If
            End Set
        End Property

        Private Property TilePictureList As New List(Of PictureBox)

#End Region

        Protected Overrides Sub InitLayout()
            MyBase.InitLayout()
            'ここに初期化処理を記述する

            For i As Integer = 0 To 3 - 1
                Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & i, True)(0), PictureBox)
                _pictureBox.Tag = i
                Me.TilePictureList.Add(_pictureBox)
            Next

            Me.Visible = False
        End Sub

        ''' <summary>
        ''' 牌を指定して画像を描画する
        ''' </summary>
        ''' <param name="tileID">描画するTileのイメージ</param>
        ''' <param name="pictureBoxID">描画対象のPictureBoxのインデックス</param>
        Private Sub SetTileImage(tile As Tile, pictureBoxID As Integer)
            'PictureBox1に表示
            Me.TilePictureList(pictureBoxID).Image = DirectCast(tile, PreCureCharacterTile).FallenTileImage
        End Sub

        ''' <summary>
        ''' 全牌の表示を更新する。
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
        ''' モデルであるHandの内容が変化したイベントを捕捉して牌の画像を更新する
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub DataSource_ListChanged(sender As Object, e As PropertyChangedEventArgs) Handles _dataSource.PropertyChanged
            Me.SetAllTileImages()
        End Sub

    End Class
End Namespace