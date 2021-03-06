﻿Imports ChiriNulluo.Mahjong.Core.Tiles
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
                    For Each _tileID As String In .TileSet
                        Dim _seriesID As String = _tileID.Substring(0, 2)
                        Dim _number As String = _tileID.Substring(2, 2)
                        Dim _tile As PreCureCharacterTile = _xmlAccess.GetCharacterDataFromXML(_seriesID, _number, Nothing, Nothing, True)(0)

                        _tiles.Add(_tile)
                    Next

                    'UNIMPLEMENTED: 説明文の多言語化
                    Dim _description As String

                    If .Type.HasFlag(YakuType.SpecificTileSetIsSubSetOfHand) Then
                        _description = "手牌に以下の全ての牌が含まれている"
                    ElseIf .Type.HasFlag(YakuType.HandIsSubSetOfSpecificTileSet) Then
                        _description = "手牌全てが以下の牌のどれかである"
                    ElseIf .Type.HasFlag(YakuType.BonusTile) Then
                        _description = "手牌に以下のどれかの牌が含まれている。(1枚につき300点加算される)"
                    End If

                    If .Type.HasFlag(YakuType.CannotOverlapWithOtherYaku) Then
                        _description &= vbCrLf & "他の役とは重複しません。"
                    End If

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
            System.Diagnostics.Process.Start("https://nulluo.github.io/ChiriNulluo.Game.WebSite/CureJong/")
        End Sub

        Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click
            Me.Close()
        End Sub
    End Class
End Namespace