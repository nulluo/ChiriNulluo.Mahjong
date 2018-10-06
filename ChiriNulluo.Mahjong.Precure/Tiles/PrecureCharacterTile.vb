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

        Public ReadOnly Property Image As System.Drawing.Bitmap
            Get
                Return New Bitmap(Path.Combine(Constants.IconDiffImageDir, String.Format("Precure{0:0000}.png", Me.ID)))
            End Get
        End Property

        Public ReadOnly Property EnlargedImage As System.Drawing.Bitmap
            Get
                Return New Bitmap(Path.Combine(Constants.IconEnlargedImageDir, String.Format("TileEnlarged{0:0000}.png", Me.ID)))
            End Get
        End Property


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


    End Class

End Namespace