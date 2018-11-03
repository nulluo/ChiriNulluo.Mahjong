Imports ChiriNulluo.Mahjong.WinFormApplication
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace View

    Public Class DisplayTilesForm

        Private Property TilesList As New List(Of PreCureCharacterTile)
        Private Const TileWidth = 48
        Private Const TileHeight = 80
        Private Const FirstTileLocationX = 10
        Private Const FirstTileLocationY = 10


        Public Sub New(tilesList As List(Of PreCureCharacterTile))

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            Me.TilesList = tilesList
        End Sub

        Private Sub DisplayTilesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim i As Integer = 0

            Dim _stringArrayText As String = ""

            For Each _tile As PreCureCharacterTile In Me.TilesList
                Dim _pictureBox = New PictureBox()
                With _pictureBox
                    .Location = New Point(FirstTileLocationX + TileWidth * i, FirstTileLocationY)
                    '.BackColor = Color.Red
                    .Size = New System.Drawing.Size(48, 80)
                    .BorderStyle = BorderStyle.None
                    .BackgroundImage = _tile.StoodTileImage
                End With

                _stringArrayText &= """,""" & _tile.ID
                Me.Controls.Add(_pictureBox)
                i += 1
            Next

            Me.TextBox1.Text = _stringArrayText
        End Sub
    End Class
End Namespace