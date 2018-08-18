Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Core.Yaku
Imports ChiriNulluo.Mahjong.Precure.DataAccess
Imports ChiriNulluo.Mahjong.Precure.Tiles

Namespace View
    Public Class RuleForm

        Private Const PanelHeight As Integer = 220
        Private Const HeaderHeight As Integer = 250
        Private Const PanelMargin As Integer = 10

        Private Sub RuleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SuspendLayout()

            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Dim _yakuList As List(Of Yaku) = _xmlAccess.GetYakuDataFromXML()

            Dim _index As Integer = 0
            For Each _yaku As Yaku In _yakuList
                With _yaku

                    Dim _tiles As New Pile
                    For Each _tile As String In .TileSet
                        _tiles.Add(New PreCureCharacterTile(_tile, String.Empty, String.Empty, Nothing))
                    Next

                    'UNIMPLEMENTED: 説明文の多言語化
                    Dim _description As String

                    Select Case .Type
                        Case YakuType.SpecificTileSetIsSubSetOfHand
                            _description = "手牌に以下の全ての牌が含まれている"

                        Case YakuType.HandIsSubSetOfSpecificTileSet
                            _description = "手牌全てが以下の牌のどれかである"

                    End Select

                    Dim _panel As New YakuDescriptionPanel(.Name, .Point, _description, _tiles)
                    _panel.Location = New Point(PanelMargin, HeaderHeight + (PanelMargin + PanelHeight) * _index)
                    Me.Controls.Add(_panel)
                End With

                _index += 1
            Next

            Me.ResumeLayout()

        End Sub

        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

            'リンク先に移動したことにする
            LinkLabel1.LinkVisited = True
            'ブラウザで開く
            System.Diagnostics.Process.Start("http://www.geocities.jp/nero021/programming/CureJong/CureJong.htm")
        End Sub

        Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click
            Me.Close()
        End Sub
    End Class
End Namespace