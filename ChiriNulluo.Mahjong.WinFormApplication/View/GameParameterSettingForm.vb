
Imports System.IO
Imports System.Resources
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles

''' <summary>
''' 各種ゲームパラメタ設定画面(デバッグ用)
''' </summary>
Public Class GameParameterSettingForm

    Private Property HumanHand As New Hand
    Private Property COMHand As New Hand
    Private Property WallPile As New WallPile

    Private Property WallImageColumn As New DataGridViewTileImageColumn()
    Private Property HumanHandImageColumn As New DataGridViewTileImageColumn()
    Private Property COMHandImageColumn As New DataGridViewTileImageColumn()

    Private Property RevealedBonusTiles As List(Of String)
    Private Property UnrevealedBonusTiles As List(Of String)

    Private Shared logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()

    Public Sub New(revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.RevealedBonusTiles = revealedBonusTiles
        Me.UnrevealedBonusTiles = unrevealedBonusTiles

    End Sub

#Region "Event Handler"

    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        'Me.MakeFixHandAndWall()

        If Me.HumanHand.MainTiles.Count <> 13 Then
            MessageBox.Show("HUMANの手牌は13枚でなければなりません。")
            Return
        End If

        If Me.COMHand.MainTiles.Count <> 13 Then
            MessageBox.Show("COMの手牌は13枚でなければなりません。")
            Return
        End If

        Dim _roundForm As New RoundForm(Me.HumanHand, Me.COMHand, Me.WallPile, Me.RevealedBonusTiles, Me.UnrevealedBonusTiles)
        FormTransition.Transit(Me, _roundForm)

    End Sub

    Private Sub loadHandPatternButton_Click(sender As Object, e As EventArgs) Handles loadHandPatternButton.Click
        If MessageBox.Show("編集中の山牌、HUMAN手牌、COM手牌データは破棄されますがよろしいですか？", "警告",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Dim _handSelectForm As New HandSelectForm
            _handSelectForm.ShowDialog()
        End If

    End Sub

    ''' <summary>
    ''' 牌を移動するボタンの押下時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub moveButton_Click(sender As Object, e As EventArgs) Handles moveToHumanHandFromWallButton.Click, moveToCOMHandFromWallButton.Click,
                                                                            moveToWallFromHumanHandButton.Click, moveToComHandFromHumanHandButton.Click,
                                                                             moveToWallFromCOMHandButton.Click, moveToHumanHandFromCOMHandButton.Click

        'Dim _startTime = DateTime.Now()

        Dim _senderGrid As String = DirectCast(sender, Button).Name
        logger.Trace(" Move button clicked.[Button:" & _senderGrid & "]")

        Dim _fromGrid As DataGridView
        Dim _toGrid As DataGridView
        Dim _toPile As Pile

        Select Case _senderGrid
            Case Me.moveToHumanHandFromWallButton.Name
                _fromGrid = Me.wallPileGrid
                _toGrid = Me.humanHandGrid
                _toPile = Me.HumanHand.MainTiles

            Case Me.moveToCOMHandFromWallButton.Name
                _fromGrid = Me.wallPileGrid
                _toGrid = Me.comHandGrid
                _toPile = Me.COMHand.MainTiles

            Case Me.moveToWallFromHumanHandButton.Name
                _fromGrid = Me.humanHandGrid
                _toGrid = Me.wallPileGrid
                _toPile = Me.WallPile

            Case Me.moveToComHandFromHumanHandButton.Name
                _fromGrid = Me.humanHandGrid
                _toGrid = Me.comHandGrid
                _toPile = Me.COMHand.MainTiles

            Case Me.moveToWallFromCOMHandButton.Name
                _fromGrid = Me.comHandGrid
                _toGrid = Me.wallPileGrid
                _toPile = Me.WallPile

            Case Me.moveToHumanHandFromCOMHandButton.Name
                _fromGrid = Me.comHandGrid
                _toGrid = Me.humanHandGrid
                _toPile = Me.HumanHand.MainTiles

        End Select
        _fromGrid.BeginUpdate()
        _toGrid.BeginUpdate

        For Each _gridRow As DataGridViewRow In _fromGrid.SelectedRows
            Dim _selectedTile = DirectCast(_gridRow.DataBoundItem, Tile)

            'UNIMPLEMENTED: とりあえず実装できているのだが、WallPileやHandが保有するList(Of Tile)のAddやRemoveを直に触っているのが密結合すぎな気がする
            DirectCast(_fromGrid.DataSource, Pile).Remove(_selectedTile)
            _toPile.Add(_selectedTile)
        Next

        _fromGrid.EndUpdate()
        _toGrid.EndUpdate()

        'Dim _endTime = DateTime.Now()
        'Debug.WriteLine(_endTime.Subtract(_startTime))

    End Sub

    'UNIMPLEMENTED：  未実装
    Private Sub comStrategyField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comStrategyField.SelectedIndexChanged
        Throw New NotImplementedException
    End Sub

    ''' <summary>
    ''' ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾋﾞｭｰ行番号描写
    ''' </summary>
    ''' <remarks>ﾃﾞｰﾀｸﾞﾘｯﾄﾞﾋﾞｭｰ｢ユーザ情報テーブル｣の行ﾍｯﾀﾞｰに番号を描写します。</remarks>
    Private Sub Grid_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles wallPileGrid.CellPainting,
                                                                humanHandGrid.CellPainting, comHandGrid.CellPainting

        '列ﾍｯﾀﾞｰかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then

            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            Dim indexRect As Rectangle = e.CellBounds

            '行番号を描画する
            indexRect.Inflate(-2, -2)
            TextRenderer.DrawText(e.Graphics,
                                      (e.RowIndex + 1).ToString(),
                                      e.CellStyle.Font,
                                      indexRect,
                                      e.CellStyle.ForeColor,
                                      TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画が完了したことを知らせる      
            e.Handled = True

        End If

    End Sub


    ''' <summary>
    ''' ボタン上下移動ボタンが押下されたときの処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub moveUpOrDownButtonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveUpButton.Click, moveDownButton.Click
        Dim _senderGrid As String = DirectCast(sender, Button).Name
        logger.Trace(" Move up/down button clicked.[Button:" & _senderGrid & "]")


        Dim _direction As Integer
        If sender Is Me.moveUpButton Then
            _direction = -1
        Else
            _direction = 1
        End If

        Dim _selectedGridRowIndex As Integer
        With Me.wallPileGrid
            If .Rows.Count = 0 Then
                '牌が0個の場合は抜ける
                Return
            ElseIf .SelectedRows.Count > 1 Then
                '複数のボタンを一度に移動することはできない
                MessageBox.Show(”同時に複数の牌の順序変更はできません。”, "キュア☆ジャン",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            _selectedGridRowIndex = .CurrentRow.Index
            If _selectedGridRowIndex + _direction < 0 OrElse .Rows.Count <= _selectedGridRowIndex + _direction Then
                '一番端まで来たらそれ以上移動できないので抜ける
                Return
            End If

        End With


        With Me.WallPile

            Dim _currentTile = DirectCast(Me.wallPileGrid.CurrentRow.DataBoundItem, Tile)
            'Dim _currentButtonID As String = DirectCast(_currentDataRow("ButtonID"), String)

            Dim _currentTileIndex As Integer = .IndexOf(_currentTile)

            '選択行を複製した行を挿入した後、元の行を削除
            'Dim _currentTileClone As New PreCureCharacterTile(_currentTile.ID, _currentTile.Name)

            .Remove(_currentTile)
            .Insert(_currentTileIndex + _direction, _currentTile)

        End With

        With Me.wallPileGrid
            .ClearSelection()
            .Rows(_selectedGridRowIndex + _direction).Selected = True
            .CurrentCell = .Item(1, _selectedGridRowIndex + _direction)

        End With

    End Sub

    'Private Sub DatagridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles wallPileGrid.CellFormatting,
    '                                                                                            humanHandGrid.CellFormatting, comHandGrid.CellFormatting

    '    If e.RowIndex >= 0 Then

    '        Dim _precureTile As PreCureCharacterTile
    '        _precureTile = DirectCast(DirectCast(sender, DataGridView).Rows(e.RowIndex).DataBoundItem, PreCureCharacterTile)

    '        'IDの値によって表示する画像やSeriesID,Numberを決定する
    '        Dim _precureID = _precureTile.ID

    '        Select Case DirectCast(sender, DataGridView).Columns(e.ColumnIndex).Name
    '            Case "WallImageColumn_", "HumanHandImageColumn", "COMHandImageColumn"
    '                Dim _image As Image = DirectCast(My.Resources.ResourceManager.GetObject(String.Format("TileStood{0:0000}", _precureID)), System.Drawing.Bitmap)
    '                e.Value = _image

    '            Case "WallSeriesIDColumn", "HumanHandSeriesIDColumn", "COMHandSeriesIDColumn"
    '                e.Value = _precureTile.SuitID

    '            Case "WallNumberColumn", "HumanHandNumberColumn", "COMHandNumberColumn"
    '                e.Value = _precureTile.Number.ToString("00")

    '        End Select

    '        e.FormattingApplied = True
    '    End If
    'End Sub

    Private Sub HandWallSettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.WallImageColumn.DataPropertyName = "ID"
        Me.wallPileGrid.Columns.Insert(1, WallImageColumn)

        Me.HumanHandImageColumn.DataPropertyName = "ID"
        Me.humanHandGrid.Columns.Insert(1, HumanHandImageColumn)

        Me.COMHandImageColumn.DataPropertyName = "ID"
        Me.COMHandGrid.Columns.Insert(1,COMHandImageColumn)


        Dim _precureList = PrecureCharacterSet.GetInstance.InitializeTileListForNewRound(revealedBonusTiles, unrevealedBonusTiles)

        For Each _precure As PreCureCharacterTile In _precureList
            Me.WallPile.Add(_precure)
        Next


        'UNIMPLEMENTED：Pileを直接バインドするテスト
        With Me.wallPileGrid
            Me.WallPile.AllowNew = True
            .AutoGenerateColumns = False
            .DataSource = Me.WallPile
        End With

        With Me.humanHandGrid
            Me.HumanHand.MainTiles.AllowNew = True
            .AutoGenerateColumns = False
            .DataSource = Me.HumanHand.MainTiles
        End With

        With Me.comHandGrid
            Me.COMHand.MainTiles.AllowNew = True
            .AutoGenerateColumns = False
            .DataSource = Me.COMHand.MainTiles
        End With

    End Sub


    ''' <summary>
    ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
    ''' </summary>
    Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormTransition.ConfirmFormClosing(e)
    End Sub


#Region "操作内容ログ出力"

    Private Sub Grid_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles wallPileGrid.ColumnHeaderMouseClick,
                                                                            humanHandGrid.ColumnHeaderMouseClick, comHandGrid.ColumnHeaderMouseClick
        Dim _senderGrid As String = DirectCast(sender, DataGridView).Name
        Dim _clickedColumn As DataGridViewColumn = DirectCast(sender, DataGridView).Columns(e.ColumnIndex)
        logger.Trace(" Column header clicked.[DataGridView:" & _senderGrid & ", Column:" & _clickedColumn.Name & "]")

    End Sub

    Private Sub Grid_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles wallPileGrid.RowHeaderMouseClick,
                                                                            humanHandGrid.RowHeaderMouseClick, comHandGrid.RowHeaderMouseClick
        Dim _senderGrid As String = DirectCast(sender, DataGridView).Name

        Dim _message As String = " Row header clicked.[DataGridView:" & _senderGrid & ", Row:" & e.RowIndex.ToString("00")

        '修飾子キー(Shift、Ctrl)が押されているか
        If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            _message &= ",Shift: ON"
        Else
            _message &= ",Shift:OFF"
        End If
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            _message &= ",Ctrl: ON"
        Else
            _message &= ",Ctrl:OFF"
        End If

        logger.Trace(_message & "]")

    End Sub

#End Region

#End Region

    'UNIMPLEMENTED: テスト用のドライバなのでリリース晩では削除する
    ''' <summary>
    ''' 固定した構成の手牌(HUMAN,COM),山牌を生成する。この画面からRoundFormを呼んで、ちゃんとここで確定した構成でゲームがスタートするか調べるためのドライバである。
    ''' </summary>
    Private Sub MakeFixHandAndWall()
        For i As Integer = 0 To 200 - 13 - 13 - 1
            Dim _precure As New PreCureCharacterTile("01", "01", "美墨なぎさ", "キュアブラック")
            Me.WallPile.Add(_precure)
        Next

        For i As Integer = 0 To 13 - 1
            Dim _precure As New PreCureCharacterTile("01", "02", "雪城ほのか", "キュアホワイト")
            Me.HumanHand.DrawTile(_precure)
        Next

        For i As Integer = 0 To 13 - 1
            Dim _precure As New PreCureCharacterTile("01", "03", "九条ひかり", "シャイニールミナス")
            Me.COMHand.DrawTile(_precure)
        Next
    End Sub


End Class