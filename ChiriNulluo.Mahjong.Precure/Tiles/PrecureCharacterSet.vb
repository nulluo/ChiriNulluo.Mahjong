Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace Tiles

    Public NotInheritable Class PrecureCharacterSet
        Implements TileSet(Of PreCureCharacterTile)

        ' シングルトン インスタンス
        Private Shared _instance As PrecureCharacterSet

        Public Shared Function GetInstance() As PrecureCharacterSet
            If _instance Is Nothing Then
                _instance = New PrecureCharacterSet
            End If
            Return _instance
        End Function

        Private Sub New()
            Dim _dataAccess As DataAccess.PrecureXMLAccess = DataAccess.PrecureXMLAccess.GetInstance()

            _regularPrecureTilesList = _dataAccess.GetRegularPrecureDataFromXML(Nothing, Nothing, Nothing, Nothing)
            _specialCharacterTilesList = _dataAccess.GetSpecialCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing)

            Me._allCharacterTilesList = _dataAccess.GetCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing, True)
            Me.AllCharacterTilesIDList.ForEach(Sub(x) TileImages.Add(x,
                   DirectCast(My.Resources.ResourceManager.GetObject(String.Format("Precure{0:0000}", x)),
                   System.Drawing.Bitmap)))

            Me.InitializeTileListForNewRound()

            _tileSuitsCount = _dataAccess.GetTileSuitsCount()

        End Sub

        ''' <summary>
        ''' 牌リストを初期化する。
        ''' </summary>
        ''' <returns>初期化された牌リスト</returns>
        ''' <remarks>1局終了するごとにこのメソッドで初期化をしておかないと、前局の「副露」状態や牌変更能力の結果を引き継いでしまう。</remarks>
        Public Function InitializeTileListForNewRound() As List(Of PreCureCharacterTile)
            Dim _dataAccess As DataAccess.PrecureXMLAccess = DataAccess.PrecureXMLAccess.GetInstance()

            Me._currentRoundTotalTilesList = New List(Of PreCureCharacterTile)
            Me._currentRoundSpecialCharacterTilesList = New List(Of PreCureCharacterTile)

            '牌1種ごとに4枚の牌を追加する
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)


            Dim _random As New System.Random()
            'ボーナス牌は局ごとに、特殊キャラ牌からランダムでN枚選んで追加する

            Dim i As Integer = 1

            While i <= Constants.Constants.BonusTileNumber
                Dim _index = _random.Next(_specialCharacterTilesList.Count)
                Dim _item = _specialCharacterTilesList(_index)

                If Not Me.CurrentRoundTotalTilesIDList.Contains(_item.ID) Then
                    i += 1
                    Dim _item0 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName)
                    Dim _item1 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName)
                    Dim _item2 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName)
                    Dim _item3 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName)

                    With _currentRoundTotalTilesList
                        .Add(_item0)
                        .Add(_item1)
                        .Add(_item2)
                        .Add(_item3)
                    End With

                    With _currentRoundSpecialCharacterTilesList
                        .Add(_item0)
                        .Add(_item1)
                        .Add(_item2)
                        .Add(_item3)
                    End With
                End If

            End While

            Return Me._currentRoundTotalTilesList
        End Function

#Region "Property"

        Private _currentRoundTotalTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property CurrentRoundTotalTilesList As List(Of PreCureCharacterTile) Implements TileSet(Of PreCureCharacterTile).CurrentRoundTotalTilesList
            Get
                Return _currentRoundTotalTilesList
            End Get
        End Property

        Public ReadOnly Property CurrentRoundTotalTilesIDList As List(Of String) Implements TileSet(Of PreCureCharacterTile).CurrentRoundTotalTilesIDList
            Get
                Return _currentRoundTotalTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        Private _currentRoundSpecialCharacterTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property CurrentRoundSpecialCharacterTilesList As List(Of PreCureCharacterTile)
            Get
                Return _currentRoundSpecialCharacterTilesList
            End Get
        End Property

        Public ReadOnly Property CurrentRoundSpecialCharacterTilesIDList As List(Of String)
            Get
                Return _currentRoundSpecialCharacterTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        Private _allCharacterTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property AllCharacterTilesList As List(Of PreCureCharacterTile)
            Get
                Return _allCharacterTilesList
            End Get
        End Property

        Public ReadOnly Property AllCharacterTilesIDList As List(Of String)
            Get
                Return _allCharacterTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        Private _regularPrecureTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property RegularPrecureTilesList As List(Of PreCureCharacterTile)
            Get
                Return _regularPrecureTilesList
            End Get
        End Property

        Public ReadOnly Property RegularPrecureTilesIDList As List(Of String)
            Get
                Return _regularPrecureTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        Private _specialCharacterTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property SpecialCharacterTilesList As List(Of PreCureCharacterTile)
            Get
                Return _specialCharacterTilesList
            End Get
        End Property

        Public ReadOnly Property SpecialTilesIDList As List(Of String)
            Get
                Return _specialCharacterTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        Private _tileSuitsCount As Integer
        Public ReadOnly Property TileSuitsCount As Integer
            Get
                Return _tileSuitsCount
            End Get
        End Property


        'UNIMPLEMENTED: PrecureCharacterTile.Imageはこのプロパティを使えば実装できるはずだが、手牌表示コントロールで使うとエラーで落ちるようになったので、統一感は無いが別方針で実装している。
        Public Property TileImages As New Dictionary(Of String, System.Drawing.Bitmap)

#End Region

        ''' <summary>
        ''' 指定したIDの牌の定義情報を取得します。
        ''' </summary>
        ''' <param name="id">牌ID</param>
        ''' <returns></returns>
        Public Function GetTileDefinition(id As String) As PreCureCharacterTile
            Dim _dataAccess As DataAccess.PrecureXMLAccess = DataAccess.PrecureXMLAccess.GetInstance()
            Dim _precures As List(Of PreCureCharacterTile) = _dataAccess.GetCharacterDataFromXML(Left(id, 2), Right(id, 2), Nothing, Nothing, True)

            If _precures.Count > 0 Then
                Return _precures(0)
            Else
                Return Nothing
            End If

        End Function


    End Class

End Namespace