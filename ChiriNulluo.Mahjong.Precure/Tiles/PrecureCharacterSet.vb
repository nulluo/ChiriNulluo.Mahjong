Imports ChiriNulluo.Mahjong.Core.Tiles
Imports System.IO
Imports System.Drawing

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

            '※ 牌アイコンはリソースには含めない。(dllのサイズ肥大化を防ぐため)
            Me.AllCharacterTilesIDList.ForEach(Sub(x) TileImages.Add(x,
                       New Bitmap(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                         Constants.IconDiffImageDir, String.Format("Precure{0:0000}.png", 0)))))

            'Me.InitializeTileListForNewRound()

            _tileSuitsCount = _dataAccess.GetTileSuitsCount()

        End Sub

        ''' <summary>
        ''' 牌リストを初期化する。
        ''' </summary>
        ''' <returns>初期化された牌リスト</returns>
        ''' <remarks>1局終了するごとにこのメソッドで初期化をしておかないと、前局の「副露」状態や牌変更能力の結果を引き継いでしまう。</remarks>
        Public Function InitializeTileListForNewRound(Optional revealedTiles As List(Of String) = Nothing,
                                                      Optional unrevealedTiles As List(Of String) = Nothing) As List(Of PreCureCharacterTile)
            Dim _dataAccess As DataAccess.PrecureXMLAccess = DataAccess.PrecureXMLAccess.GetInstance()

            Me._currentRoundTotalTilesList = New List(Of PreCureCharacterTile)
            Me._currentRoundRevealedBonusTilesList = New List(Of PreCureCharacterTile)
            Me._currentRoundUnrevealedBonusTilesList = New List(Of PreCureCharacterTile)

            '牌1種ごとに4枚の牌を追加する
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)
            _dataAccess.FillRegularPrecureDataFromXML(Me._currentRoundTotalTilesList, Nothing, Nothing, Nothing, Nothing)

            Me._sortedCurrentRoundDistinctTotalIDSet.Clear()
            _dataAccess.GetRegularPrecureDataFromXML(Nothing, Nothing, Nothing, Nothing).Select(Of String)(Function(x) x.ID).Distinct.ToList.ForEach(Sub(y) Me._sortedCurrentRoundDistinctTotalIDSet.Add(y))


            Me.AddBonusTiles(revealedTiles, True)
            Me.AddBonusTiles(unrevealedTiles, False)


            Return Me._currentRoundTotalTilesList
        End Function

#Region "Property"


        ''' <summary>
        ''' 昇順に並んだ現在のラウンドの全牌ID(プリキュア牌＋特殊キャラ牌)のセット(重複は含まない)
        ''' </summary>
        Private _sortedCurrentRoundDistinctTotalIDSet As New SortedSet(Of String)
        ''' <summary>
        ''' 昇順に並んだ現在のラウンドの全牌ID(プリキュア牌＋特殊キャラ牌)のセット(重複は含まない)
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property SortedCurrentRoundDistinctTotalIDSet As SortedSet(Of String)
            Get
                Return _sortedCurrentRoundDistinctTotalIDSet
            End Get
        End Property


        ''' <summary>
        ''' 現在の局の全ての牌(Tile型)のリスト。(ボーナス牌を含む）
        ''' </summary>
        Private _currentRoundTotalTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property CurrentRoundTotalTilesList As List(Of PreCureCharacterTile) Implements TileSet(Of PreCureCharacterTile).CurrentRoundTotalTilesList
            Get
                Return _currentRoundTotalTilesList
            End Get
        End Property

        ''' <summary>
        ''' 現在の局の全ての牌ID(String型)のリスト。(ボーナス牌を含む）
        ''' </summary>
        Public ReadOnly Property CurrentRoundTotalTilesIDList As List(Of String) Implements TileSet(Of PreCureCharacterTile).CurrentRoundTotalTilesIDList
            Get
                Return _currentRoundTotalTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        ''' <summary>
        ''' 現在の局の全ての表ボーナス牌(Tile型)のリスト。
        ''' </summary>
        Private _currentRoundRevealedBonusTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property CurrentRoundRevealedBonusTilesList As List(Of PreCureCharacterTile)
            Get
                Return _currentRoundRevealedBonusTilesList
            End Get
        End Property

        ''' <summary>
        ''' 現在の局の全ての表ボーナス牌ID(String型)のリスト。
        ''' </summary>
        Public ReadOnly Property CurrentRoundRevealedBonusTilesIDList As List(Of String)
            Get
                Return _currentRoundRevealedBonusTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        ''' <summary>
        ''' 現在の局の全ての裏ボーナス牌(Tile型)のリスト。
        ''' </summary>
        Private _currentRoundUnrevealedBonusTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property CurrentRoundUnrevealedBonusTilesList As List(Of PreCureCharacterTile)
            Get
                Return _currentRoundUnrevealedBonusTilesList
            End Get
        End Property

        ''' <summary>
        ''' 現在の局の全ての裏ボーナス牌ID(String型)のリスト。
        ''' </summary>
        Public ReadOnly Property CurrentRoundUnrevealedBonusTilesIDList As List(Of String)
            Get
                Return _currentRoundUnrevealedBonusTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        ''' <summary>
        ''' ボーナス牌も含めたすべての牌(Tile型)のリスト。現在の局のボーナス牌とは無関係に全てのボーナス牌を含む。
        ''' </summary>
        Private _allCharacterTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property AllCharacterTilesList As List(Of PreCureCharacterTile)
            Get
                Return _allCharacterTilesList
            End Get
        End Property

        ''' <summary>
        ''' ボーナス牌も含めたすべての牌(Tile型)のリスト。現在の局のボーナス牌とは無関係に全てのボーナス牌を含む。
        ''' </summary>
        Public ReadOnly Property AllCharacterTilesIDList As List(Of String)
            Get
                Return _allCharacterTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        ''' <summary>
        ''' 正式プリキュア牌全ての牌(Tile型)のリスト。
        ''' </summary>
        Private _regularPrecureTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property RegularPrecureTilesList As List(Of PreCureCharacterTile)
            Get
                Return _regularPrecureTilesList
            End Get
        End Property

        ''' <summary>
        ''' 正式プリキュア牌全ての牌ID(String型)のリスト。
        ''' </summary>
        Public ReadOnly Property RegularPrecureTilesIDList As List(Of String)
            Get
                Return _regularPrecureTilesList.Select(Function(x) x.ID).ToList
            End Get
        End Property

        ''' <summary>
        ''' 特殊キャラ牌全ての牌(Tile型)のリスト。
        ''' </summary>
        Private _specialCharacterTilesList As List(Of PreCureCharacterTile)
        Public ReadOnly Property SpecialCharacterTilesList As List(Of PreCureCharacterTile)
            Get
                Return _specialCharacterTilesList
            End Get
        End Property

        ''' <summary>
        ''' 特殊キャラ牌全ての牌ID(String型)のリスト。
        ''' </summary>
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
        ''' ボーナス牌を山牌に追加する。
        ''' </summary>
        ''' <param name="tiles">表ボーナス牌または裏ボーナス牌の牌IDリスト</param>
        ''' <param name="isRevealedTiles">追加するのが表ボーナス牌の場合はTrue、裏ボーナス牌の場合はFalse。</param>
        Private Sub AddBonusTiles(tiles As List(Of String), isRevealedTiles As Boolean)
            Dim _random As New System.Random()
            'ボーナス牌は、引数で与えられた場合はその牌を追加する。
            '引数で指定されなかった場合、各局ごとに、特殊キャラ牌からランダムでN枚選んで追加する

            Dim _maxTiles As Integer
            Dim _currentRoundSpecialTilesList As List(Of PreCureCharacterTile)

            If isRevealedTiles Then
                _maxTiles = Constants.Constants.RevealedBonusTileNumber
                _currentRoundSpecialTilesList = _currentRoundRevealedBonusTilesList
            Else
                _maxTiles = Constants.Constants.UnrevealedBonusTileNumber
                _currentRoundSpecialTilesList = _currentRoundUnrevealedBonusTilesList
            End If

            Dim i As Integer = 0
            While i < _maxTiles
                Dim _item As PreCureCharacterTile

                If tiles Is Nothing Then
                    Dim _index = _random.Next(_specialCharacterTilesList.Count)
                    _item = _specialCharacterTilesList(_index)
                Else
                    _item = Me.GetTileDefinition(tiles(i))
                End If

                'ランダムでボーナス牌を選んでいるので、前に追加したボーナス牌と重複していないかチェックする
                If Not Me.CurrentRoundTotalTilesIDList.Contains(_item.ID) Then

                    '以前に追加していないボーナス牌の場合だけカウントアップし、牌を追加する
                    i += 1
                    Dim _item0 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName, True)
                    Dim _item1 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName, True)
                    Dim _item2 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName, True)
                    Dim _item3 = New PreCureCharacterTile(_item.ID, _item.Name, _item.CureName, True)

                    With _currentRoundTotalTilesList
                        .Add(_item0)
                        .Add(_item1)
                        .Add(_item2)
                        .Add(_item3)
                    End With

                    With _currentRoundSpecialTilesList
                        .Add(_item0)
                        .Add(_item1)
                        .Add(_item2)
                        .Add(_item3)
                    End With

                    Me._sortedCurrentRoundDistinctTotalIDSet.Add(_item.ID)
                End If

            End While
        End Sub

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