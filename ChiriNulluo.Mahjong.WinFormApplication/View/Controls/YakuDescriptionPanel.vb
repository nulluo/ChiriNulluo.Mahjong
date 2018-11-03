Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace View
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
                _pictureBox.Image = DirectCast(_tile, PreCureCharacterTile).FallenTileImage
                i += 1
            Next

            For j As Integer = i To MaxTileNum - 1
                Dim _pictureBox As PictureBox = DirectCast(Me.Controls.Find("tilePicture" & j, True)(0), PictureBox)
                _pictureBox.Image = Nothing
            Next

        End Sub


    End Class
End Namespace