Imports System.IO
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.Precure.HandChecker
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Players.COM
Imports System.Threading
Imports ChiriNulluo.Mahjong.WinFormApplication.Logging


'UNIMPLEMENTED：捨て牌が見分けにくいので上下のマージンを取るか？要検討
Public Class RoundForm

#Region "Property"

    'UNIMPLEMENTED: COM側のDrawCountも管理する（COMがポン・チーしたときのため）

    Private ReadOnly Property HumanPlayer As Core.Players.HumanPlayer
        Get
            Return Me.Facade.HumanPlayer
        End Get
    End Property

    Private ReadOnly Property COMPlayer As Core.Players.COM.COMPlayer
        Get
            Return Me.Facade.COMPlayer
        End Get
    End Property

    Private Property HumanRevealedHandPanelList As New List(Of HorizontalRevealedHandPanel)

    Public Property Facade As RoundFacade

    'UNIMPLEMENTED: 勝敗結果Resultはフォームのプロパティとしてではなく、RoundManagerのプロパティとして持たせるべきである。そうすれば、PointDisplayFormでも、MatchManagerController経由で参照できるようになる
    Public ReadOnly Property Result As RoundState
        Get
            Return Me.Facade.Result
        End Get
    End Property

    ''' <summary>
    ''' デバッグモードであるかどうか
    ''' </summary>
    ''' <returns></returns>
    Public Property DebugMode As Boolean

    Private mediaPlayer As New WMPLib.WindowsMediaPlayer()

    ''' <summary>
    ''' リーチボタン押下済みかどうか。
    ''' </summary>
    ''' <remarks>「リーチボタン押下」と「リーチの実行(リーチ宣言後に牌を捨てる」の間にタイムラグがあるため、Player.RiichiDoneとは別にこのプロパティが必要である</remarks>
    'Private RiichiButtonPushed As Boolean = False

#End Region

    Private WallPileForm As WallPIleForm

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="humanHand">HUMANの手牌</param>
    ''' <param name="comHand">COMの手牌</param>
    ''' <param name="wallPile">山牌</param>
    Public Sub New(humanHand As Hand, comHand As Hand, wallPile As WallPile,
                   revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))
        'UNIMPLEMENTED：この呼び出しいるの？
        MyBase.New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ファサードクラス生成
        Facade = New RoundFacade(humanHand, comHand, wallPile, Me, revealedBonusTiles, unrevealedBonusTiles)

#If DEBUG Then
        Me.allTilesOpenField.Visible = True
        Me.endRoundButton.Visible = True
        Me.TestShantenButton1.Visible = True
#End If

        '手牌UIにモデルをバインド
        Me.humanPlayerHandPanel.DataSource = Me.HumanPlayer.Hand.MainTiles
        Me.comPlayerHandPanel.DataSource = Me.COMPlayer.Hand.MainTiles

        '捨て牌UIにモデルをバインド
        Me.comPlayerDiscardedPilePanel.DataSource = Me.COMPlayer.DiscardedPile
        Me.humanPlayerDiscardedPilePanel.DataSource = Me.HumanPlayer.DiscardedPile

        '山牌表示フォームを生成(この処理はRoundFacade生成後に実行しないと、WallPileFormの山牌の内容が不正になるので注意)
        Me.WallPileForm = New WallPIleForm

        '副露牌表示コントロールのリストを初期化
        'HUMAN用副露牌表示コントロール
        For i As Integer = 0 To 4 - 1
            Dim _revealedHandPanel As HorizontalRevealedHandPanel = DirectCast(Me.Controls.Find("horizontalRevealedHandPanel" & i, True)(0), HorizontalRevealedHandPanel)
            _revealedHandPanel.Tag = i
            Me.HumanRevealedHandPanelList.Add(_revealedHandPanel)
        Next

        '対戦相手表示
        Me.OpponentLabel.Text = MatchManagerController.GetInstance.OpponentManager.GetDisplayName

        '点数表示
        Me.comPointField.Text = Me.COMPlayer.Score.ToString
        Me.humanPointField.Text = Me.HumanPlayer.Score.ToString
        '現在の局数表示
        Me.restRoundsField.Text = (MatchManagerController.GetInstance.MatchManager.RoundsCount + 1).ToString &
                                                             "/" & Constants.MaxRounds2PlayersMatch

        'UNIMPLEMENTED: COM用副露牌表示コントロール

        Me.endRoundButton.Enabled = True
        Me.HumanPlayer.RestDrawCount = Constants.MaxDrawTimes2PlayersMatch
        Me.COMPlayer.RestDrawCount = Constants.MaxDrawTimes2PlayersMatch

        If Not Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
            Me.AddUIHandlers()
        End If
    End Sub

#Region "ゲーム内部ロジック"

    ''' <summary>
    ''' 流局にする
    ''' </summary>
    Public Sub MakeGameDraw()
        Me.OpenDrawnGameForm()
        Me.EndRound(False)
        Me.Close()
    End Sub

    ''' <summary>
    ''' HUMANプレイヤーが牌を1枚ツモる
    ''' </summary>
    Private Sub DrawHumanPlayersTile()
        Dim _nextDraw = Me.Facade.DrawHumanPlayersTile()
        Me.humanPlayerHandPanel.KeepDrawnTileAtDistance()
        'UNIMPLEMENTED: できればrestDrawCountFieldもデータバインドで、自動で残りツモ数が反映されるようにしたいが面倒くさいな…
        Me.restDrawCountField.Text = Me.HumanPlayer.RestDrawCount.ToString
    End Sub

    ''' <summary>
    ''' COMプレイヤーが牌を1枚ツモる
    ''' </summary>
    Private Sub DrawCOMPlayersTile()
        Me.Facade.DrawCOMPlayersTile()
        If Me.Facade.Result = RoundState.PlayerLoseByTileDrawnByCOM Then
            Me.EndRound(True)
        End If
    End Sub

    ''' <summary>
    ''' HUMANプレイヤーが牌を一枚捨てる。
    ''' </summary>
    ''' <param name="tileIndex">捨てる牌のインデックス</param>
    Friend Sub DiscardHumanTile(tileIndex As Integer)
        '牌を切る主処理
        Dim _tileToDiscard As Tile = Me.Facade.DiscardHumanTile(tileIndex)
        If _tileToDiscard Is Nothing Then
            'UNIMPLEMENTED: 何もない場所をクリックしてもイベント発火しないようにしたので、このチェックは不要になったはずだと思われる
            'DiscardHumanTileの実行結果がNothingの場合は、副露のせいで無くなった牌の場所をクリックした
            'という事なので、何もしない。
            Return
        End If

        '牌詳細表示パネルを消去
        Me.TileDetailInfoPanel1.Erase()

        'COMがロン可能な牌をHUMANが捨てた場合
        If Me.Facade.Result = RoundState.PlayerLoseByTileDiscardedByPlayer Then
            'UNIMPLEMENTED：負けた時の音楽を鳴らす
            Me.EndRound(True, _tileToDiscard)
            Return
        End If

        'COMのツモ
        Me.DrawCOMPlayersTile()
        'COMがツモアガリした場合、処理を中断する
        If Me.Result = RoundState.PlayerLoseByTileDrawnByCOM Then
            Return
        End If

        'COMが牌を1枚捨てる
        Dim _tileDiscardedByCOM = Me.Facade.DiscardCOMPlayersTile()
        If Me.Facade.Result.HasFlag(RoundState.COMDeclaredRiichi) Then
            Me.Facade.RiichiCOM()
            Me.OpenCOMRiichiForm()
            Me.Facade.Result = RoundState.Undetermined
            Me.riichiImageCOM.Visible = True
        End If


        Dim _choiceMessages As New List(Of String)

        'COMの捨て牌で人間がロンできるか？
        If Me.Facade.Result.HasFlag(RoundState.PlayerCanRonTileDiscardedByCOM) Then
            _choiceMessages.Add(My.Resources.LabelRon)
        End If

        'COMの捨て牌で人間がポンできるか？
        If Not Me.HumanPlayer.RiichiDone AndAlso Me.Facade.Result.HasFlag(RoundState.PlayerCanPongTileDiscardedByCOM) Then
            _choiceMessages.Add(My.Resources.LabelPong)
        End If

        'COMの捨て牌で人間がチーできるか？
        If Not Me.HumanPlayer.RiichiDone AndAlso Me.Facade.Result.HasFlag(RoundState.PlayerCanChowTileDiscardedByCOM) Then
            _choiceMessages.Add(My.Resources.LabelChow)
        End If

        If _choiceMessages.Count > 0 Then
            _choiceMessages.Add(My.Resources.LabelPass)

            Me.RiichiAutoDrawTimer.Enabled = False

            'ロン、ポン、チーを実行するかユーザーに確認する
            Select Case MessageWindowForm.ShowWindow(String.Empty, Me, _choiceMessages.ToArray)
                Case My.Resources.LabelRon
                    'ロンする場合

                    'UNIMPLEMENTED: 本来はFacadeクラスにロンを実行するメソッドを定義して、そこにこのコードを書くべきである↓
                    Me.HumanPlayer.Hand.PongOrChowOrRonDone = True
                    Me.Facade.Result = RoundState.PlayerWinByTileDiscardedByCOM

                    If Sounds.SoundManager.PlaysSE Then
                        Dim _mediaPlayer = New System.Media.SoundPlayer(Path.Combine(My.Application.Info.DirectoryPath, Constants.SoundFolder, "GameClear.wav"))
                        _mediaPlayer.Play()
                    End If

                    Me.EndRound(True, _tileDiscardedByCOM)
                    '人間がロン上がりした場合、処理を中断する

                    Return

                Case My.Resources.LabelPong
                    'ポンする場合

                    Me.COMPlayer.DiscardedPile.Remove(_tileDiscardedByCOM)
                    'UNIMPLEMENTED：↑相手の捨て牌から、_tileDiscardedByCOMを取り除く処理はPongメソッドに組み込めないのがスマートじゃないなあ↓
                    Me.HumanPlayer.Pong(_tileDiscardedByCOM)
                    Me.BindRevealedTilesToPanel(Me.HumanPlayer)
                    Me.RiichiButton.Visible = False
                    Return

                Case My.Resources.LabelChow
                    'チーする場合

                    Dim _choicePiles = Me.Facade.GetPossibleHumanChowCombination()

                    Dim _myTile0 As Tile
                    Dim _myTile1 As Tile
                    If _choicePiles.Count > 1 Then
                        Dim _choicedChow = TileSelectWindowForm.ShowWindow("どれでチーするか選んでOKを押すモフ！", Me, _choicePiles)
                        _myTile0 = _choicedChow.MyTile0
                        _myTile1 = _choicedChow.MyTile1
                    Else
                        _myTile0 = _choicePiles(0).MyTile0
                        _myTile1 = _choicePiles(0).MyTile1
                    End If

                    'チーを実行する
                    Me.COMPlayer.DiscardedPile.Remove(_tileDiscardedByCOM)
                    Me.Facade.Chow(Me.HumanPlayer, _myTile0, _myTile1, _tileDiscardedByCOM)
                    Me.BindRevealedTilesToPanel(Me.HumanPlayer)
                    Me.RiichiButton.Visible = False
                    Return

                Case My.Resources.LabelPass
                    'パスの場合は何もしない

            End Select
        End If


        'リーチ実行済みの場合はオートツモを有効にする。(ただし、リプレイモードの場合はオートツモしない)
        If Me.HumanPlayer.RiichiDone AndAlso
            Not Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then

            Me.RiichiAutoDrawTimer.Enabled = True
        End If

        'UNIMPLEMENTED: デバッグ用のコードなので削除する
        'Me.ShowMyAtariHai()

        'ロンしない、鳴かない場合はツモる
        Me.DrawHumanPlayersTile()
        If Sounds.SoundManager.PlaysSE Then
            Dim _player = New System.Media.SoundPlayer(Path.Combine(My.Application.Info.DirectoryPath,
                                                                    Constants.SoundFolder, "DiscardTile.wav"))
            _player.Play()
        End If

    End Sub

    ''' <summary>
    ''' この局を終了し、本画面を閉じる。
    ''' </summary>
    ''' <param name="showsPointForm"><c>PointDisplayForm</c>を表示するかどうか。</param>
    Public Sub EndRound(showsPointForm As Boolean, Optional discardedTile As Tile = Nothing)

        Select Case Me.Result
            Case RoundState.PlayerWinByTileDrawnByPlayer, RoundState.PlayerWinByTileDiscardedByCOM
                Me.SetHumanPlayersHandFallen()

            Case RoundState.PlayerLoseByTileDrawnByCOM, RoundState.PlayerLoseByTileDiscardedByPlayer
                Me.SetCOMPlayersHandVisible(True)

            Case RoundState.Draw
                'UNIMPLEMENTED: ノーテンの場合は牌を表示しない
                Me.SetHumanPlayersHandFallen()
                Me.SetCOMPlayersHandVisible(True)

        End Select
        'オートツモモードをオフにする
        If Me.HumanPlayer.RiichiDone Then
            Me.RiichiAutoDrawTimer.Enabled = False
        End If

        Me.DisplayUnRevealedBonusTIlePictures(True)
        Me.CaptureFormImageIfNonReplayMode()

        Me.OpenRoundEndTalkingWindowForm(discardedTile)
        Me.Hide()
        Me.WallPileForm.Close()

        '局を終了する
        Me.Facade.EndRound(discardedTile)

        'BGMの終了
        If True Then
            Me.mediaPlayer.controls.stop()
        End If

        If showsPointForm Then
            Me.OpenPointDisplayForm()
        Else
            If MatchManagerController.GetInstance.MatchManager.RoundsCount >= Constants.MaxRounds2PlayersMatch Then
                Me.OpenMatchResultForm()
            Else
                If Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
                    Me.ReplayOpeningNextRoundForm()
                Else
                    Me.OpenNextRoundForm(Nothing, Nothing, Nothing, Nothing, Nothing)
                End If
            End If
        End If
        Me.Close()

    End Sub

    ''' <summary>
    ''' リーチする。
    ''' </summary>
    ''' <param name="isHuman">リーチしたのがHUMANかどうか。</param>
    Friend Sub Riichi(isHuman As Boolean)
        Dim _riichiPlayer As String
        If isHuman Then
            _riichiPlayer = My.Resources.IDPlayerHuman
            Me.riichiImageHuman.Visible = True
            'Me.RiichiButtonPushed = True
            Me.RiichiButton.Visible = False
            Me.Facade.RiichiHuman()
        Else
            _riichiPlayer = My.Resources.IDPlayerCOM
        End If

        LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA, My.Resources.IDProcessRiichi,
                   _riichiPlayer, String.Empty, String.Empty)

    End Sub
#End Region

#Region "Event Handler"

    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    Private Sub RoundForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BGM再生
        If Sounds.SoundManager.PlaysBGM Then
            Me.mediaPlayer.URL = Path.Combine(My.Application.Info.DirectoryPath,
                                              Constants.SoundFolder, "BGM\Memory.mp3")
            Me.mediaPlayer.controls.play()
            Me.mediaPlayer.settings.volume = 10
        End If

        Me.DisplayRevealedBonusTIlePictures()

    End Sub

    ''' <summary>
    ''' フォームが最初に表示されるときの処理。
    ''' </summary>
    ''' <remarks>Loadイベントに記述すると、ゲーム画面が表示される前に<c>TalkingCharaWindowForm</c>が表示されてしまうので、ここに記述している</remarks>
    Private Sub RoundForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.OpenStartRoundForm()
        '親が1枚引く
        Me.DrawHumanPlayersTile()
    End Sub

    ''' <summary>
    ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
    ''' </summary>
    Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormTransition.ConfirmFormClosing(e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles RiichiAutoDrawTimer.Tick
        'リーチ宣言のメッセージが出ている間はオートツモを停止する
        If Not Me.Facade.Result.HasFlag(RoundState.COMDeclaredRiichi) Then
            Me.Facade.DiscardIfHumanRiichiDone()
        End If
    End Sub

#Region "User Operation Event"

    ''' <summary>
    ''' 降参ボタン押下時処理
    ''' </summary>
    Private Sub endRoundButton_Click(sender As Object, e As EventArgs)
        If MessageBox.Show(My.Resources.SystemScriptConfirmConcede, My.Resources.LabelGameTitle, MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Me.Facade.Result = RoundState.PlayerLoseByTileDrawnByCOM
            Me.EndRound(False)
            'Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 「全ての牌をオープン」のチェック切り替え時処理
    ''' </summary>
    Private Sub allTilesOpenField_CheckedChanged(sender As Object, e As EventArgs)
        Dim _open As Boolean = allTilesOpenField.Checked

        Me.SetCOMPlayersHandVisible(_open)
        If _open Then
            Me.WallPileForm.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
            Me.WallPileForm.Show()
        Else
            Me.WallPileForm.Hide()
        End If

        Me.DisplayUnRevealedBonusTIlePictures(_open)
    End Sub

    ''' <summary>
    ''' 手牌クリック時処理
    ''' </summary>
    Private Sub HumanPlayerHandPanel_TilePictureClick(sender As Object, e As TilePictureClickEventArgs)
        Dim _index As Integer = e.Index
        Dim _clickedTile = DirectCast(Me.HumanPlayer.Hand.MainTiles(e.Index), PreCureCharacterTile)
        Me.DiscardHumanTile(_index)
    End Sub

    Private Sub HumanPlayerHandPanel_TilePictureMouseEnter(sender As Object, e As TilePictureMouseEnterEventArgs)
        Dim _index As Integer = e.Index
        Dim _clickedTile As Tile = Me.HumanPlayer.Hand.MainTiles(_index)
        Me.TileDetailInfoPanel1.Draw(DirectCast(_clickedTile, PreCureCharacterTile), _index)

    End Sub

    Private Sub HumanPlayerHandPanel_TilePictureMouseLeave(sender As Object, e As TilePictureMouseLeaveEventArgs)
        Dim _index As Integer = e.Index
        Me.TileDetailInfoPanel1.Erase()
    End Sub

    Private Sub HumanPlayerDiscardedPilePanel_TilePictureMouseEnter(sender As Object, e As TilePictureMouseEnterEventArgs)
        Dim _index As Integer = e.Index
        Dim _clickedTile = DirectCast(Me.humanPlayerDiscardedPilePanel.DataSource(_index), PreCureCharacterTile)
        Me.TileDetailInfoPanel1.Draw(_clickedTile, _index)
    End Sub

    Private Sub HumanPlayerDiscardedPilePanel_TilePictureMouseLeave(sender As Object, e As TilePictureMouseLeaveEventArgs)
        Dim _index As Integer = e.Index
        Me.TileDetailInfoPanel1.Erase()
    End Sub

    Private Sub ComPlayerDiscardedPilePanel_TilePictureMouseEnter(sender As Object, e As TilePictureMouseEnterEventArgs)
        Dim _index As Integer = e.Index
        Dim _clickedTile = DirectCast(Me.comPlayerDiscardedPilePanel.DataSource(_index), PreCureCharacterTile)
        Me.TileDetailInfoPanel1.Draw(_clickedTile, _index)
    End Sub

    Private Sub ComPlayerDiscardedPilePanel_TilePictureMouseLeave(sender As Object, e As TilePictureMouseLeaveEventArgs)
        Dim _index As Integer = e.Index
        Me.TileDetailInfoPanel1.Erase()
    End Sub

    Private Sub openRuleFormButton_Click(sender As Object, e As EventArgs)
        Me.OpenRuleForm()
    End Sub

    Private Sub RiichiButton_Click(sender As Object, e As EventArgs)
        Me.Riichi(True)
    End Sub

#End Region


    ''' <summary>
    ''' 画面上のUI操作に関するイベントハンドラーとイベントの紐づけを実行する。
    ''' </summary>
    ''' <remarks>リプレイモードがONの時はUI操作を受け付けないためにこのメソッドを実装した</remarks>
    Friend Sub AddUIHandlers()

        'クリック
        AddHandler endRoundButton.Click, AddressOf Me.endRoundButton_Click
        AddHandler allTilesOpenField.CheckedChanged, AddressOf Me.allTilesOpenField_CheckedChanged
        AddHandler humanPlayerHandPanel.TilePictureClick, AddressOf Me.HumanPlayerHandPanel_TilePictureClick
        AddHandler openRuleFormButton.Click, AddressOf Me.openRuleFormButton_Click
        AddHandler RiichiButton.Click, AddressOf Me.RiichiButton_Click

        'マウスエンター/リーブ
        AddHandler humanPlayerHandPanel.TilePictureMouseEnter, AddressOf Me.HumanPlayerHandPanel_TilePictureMouseEnter
        AddHandler humanPlayerHandPanel.TilePictureMouseLeave, AddressOf Me.HumanPlayerHandPanel_TilePictureMouseLeave
        AddHandler humanPlayerDiscardedPilePanel.TilePictureMouseEnter, AddressOf Me.HumanPlayerDiscardedPilePanel_TilePictureMouseEnter
        AddHandler humanPlayerDiscardedPilePanel.TilePictureMouseLeave, AddressOf Me.HumanPlayerDiscardedPilePanel_TilePictureMouseLeave
        AddHandler comPlayerDiscardedPilePanel.TilePictureMouseEnter, AddressOf Me.ComPlayerDiscardedPilePanel_TilePictureMouseEnter
        AddHandler comPlayerDiscardedPilePanel.TilePictureMouseLeave, AddressOf Me.ComPlayerDiscardedPilePanel_TilePictureMouseLeave

    End Sub

#End Region

#Region "Form Transition"

    ''' <summary>
    ''' アガリ確認ダイアログを表示し、ユーザーの選択結果を返す。
    ''' </summary>
    ''' <returns>ユーザーが選んだ選択肢。(はい/いいえ)</returns>
    Public Function ConfirmFinish() As String
        Dim _result As String
        Me.RiichiAutoDrawTimer.Enabled = False
        _result = MessageWindowForm.ShowWindow(My.Resources.SystemScriptConfirmFinish, Me, My.Resources.LabelYes, My.Resources.LabelNo)
        If _result = My.Resources.LabelYes Then
            If Sounds.SoundManager.PlaysSE Then
                Dim _player = New System.Media.SoundPlayer(Path.Combine(My.Application.Info.DirectoryPath, Constants.SoundFolder, "GameClear.wav"))
                _player.Play()
            End If
        Else
            If Me.HumanPlayer.RiichiDone AndAlso
               Not Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
                'リーチ済みの場合はオートツモタイマーを再開
                Me.RiichiAutoDrawTimer.Enabled = True
            End If
        End If

        Return _result
    End Function

    Private Sub OpenStartRoundForm()
        Dim _dialog As New TalkingCharaWindowForm()
        _dialog.Left = Me.Left + (Me.Width - _dialog.Width) \ 2
        _dialog.Top = Me.Top + (Me.Height - _dialog.Height) \ 2
        _dialog.Owner = Me
        _dialog.Words = MatchManagerController.GetInstance.OpponentManager.GetScriptGameStart
        _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetNormalImage
        _dialog.ShowDialog()
    End Sub

    Private Sub OpenCOMRiichiForm()
        Dim _dialog As New TalkingCharaWindowForm()
        _dialog.Left = Me.Left + (Me.Width - _dialog.Width) \ 2
        _dialog.Top = Me.Top + (Me.Height - _dialog.Height) \ 2
        _dialog.Owner = Me
        _dialog.Words = My.Resources.CharacterScriptRiichi
        _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetNormalImage
        _dialog.ShowDialog()
    End Sub

    Private Sub OpenRoundEndTalkingWindowForm(Optional discardedTile As Tile = Nothing)
        Dim _dialog As New TalkingCharaWindowForm()

        Dim _message As String
        Select Case Me.Result
            Case RoundState.PlayerWinByTileDrawnByPlayer
                _message = MatchManagerController.GetInstance.OpponentManager.GetScriptLose
                _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetLossImage

            Case RoundState.PlayerWinByTileDiscardedByCOM
                _message = MatchManagerController.GetInstance.OpponentManager.GetScriptLose
                _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetLossImage

            Case RoundState.PlayerLoseByTileDrawnByCOM
                _message = MatchManagerController.GetInstance.OpponentManager.GetScriptWinDraw
                _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetWinningImage

            Case RoundState.PlayerLoseByTileDiscardedByPlayer
                _message = MatchManagerController.GetInstance.OpponentManager.GetScriptWinRon
                _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetWinningImage

            Case RoundState.Draw
                _message = MatchManagerController.GetInstance.OpponentManager.GetScriptDraw
                _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetNormalImage

        End Select

        _dialog.Left = Me.Left + (Me.Width - _dialog.Width) \ 2
        _dialog.Top = Me.Top + (Me.Height - _dialog.Height) \ 2
        _dialog.Owner = Me
        _dialog.Words = _message
        _dialog.ShowDialog()

    End Sub

    Private Sub OpenPointDisplayForm()
        Dim _pointDisplayDialog As PointForm
        If Me.Result = RoundState.PlayerWinByTileDrawnByPlayer Then
            _pointDisplayDialog = New PointForm(Me.HumanPlayer, Me.COMPlayer)
        ElseIf Me.Result = RoundState.PlayerWinByTileDiscardedByCOM Then
            _pointDisplayDialog = New PointForm(Me.HumanPlayer, Me.COMPlayer)
        ElseIf Me.Result = RoundState.PlayerLoseByTileDrawnByCOM
            _pointDisplayDialog = New PointForm(Me.COMPlayer, Me.HumanPlayer)
        ElseIf Me.Result = RoundState.PlayerLoseByTileDiscardedByPlayer
            _pointDisplayDialog = New PointForm(Me.COMPlayer, Me.HumanPlayer)
        Else
            Return
        End If

        FormTransition.Transit(Me, _pointDisplayDialog)
    End Sub

    Private Sub OpenNextRoundForm(comHand As Hand, humanHand As Hand, wallPile As WallPile,
                   revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))
        Dim _roundForm As New RoundForm(humanHand, comHand, wallPile, revealedBonusTiles, unrevealedBonusTiles)
        FormTransition.Transit(Me, _roundForm)
    End Sub

    Private Sub OpenMatchResultForm()
        Dim _matchResultForm As New MatchResultForm()
        FormTransition.Transit(Me, _matchResultForm)
    End Sub

    Private Sub OpenRuleForm()
        Dim _nextForm As New RuleForm
        Me.Hide()
        _nextForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub OpenDrawnGameForm()
        Me.RiichiAutoDrawTimer.Enabled = False
        MessageWindowForm.ShowWindow(My.Resources.SystemScriptDrawnGame, Me, My.Resources.LabelOK)
    End Sub


#End Region

#Region "ビューの外観変更"

    ''' <summary>
    ''' COMプレイヤーの手牌の表示/非表示を切り替える
    ''' </summary>
    ''' <param name="showsHand"></param>
    Private Sub SetCOMPlayersHandVisible(visible As Boolean)

        If visible Then
            Me.comPlayerHandPanel.DisplayStyle = HandPanelDisplayStyle.ShownToHumanFallen
        Else
            Me.comPlayerHandPanel.DisplayStyle = HandPanelDisplayStyle.HiddenFromHuman
        End If

    End Sub

    ''' <summary>
    ''' HUMANプレイヤーの手牌を倒す。
    ''' </summary>
    ''' <param name="showsHand"></param>
    Private Sub SetHumanPlayersHandFallen()

        Me.humanPlayerHandPanel.DisplayStyle = HandPanelDisplayStyle.ShownToHumanFallen

    End Sub

    ''' <summary>
    ''' ポンやチーを実行した後、現在のポン・チー回数に応じてHorizontalRevealedHandPanelにRevealedTilesobjectをバインドします。
    ''' </summary>
    Private Sub BindRevealedTilesToPanel(player As Core.Players.Player)
        Dim _count As Integer = player.Hand.RevealedCount

        If player Is Me.HumanPlayer Then
            HumanRevealedHandPanelList(_count - 1).DataSource = player.Hand.RevealedTilesList(_count - 1)
        Else
            'UNIMPLEMENTED: COMの場合の処理
        End If

    End Sub

    ''' <summary>
    ''' 表ボーナス牌を表示する
    ''' </summary>
    Private Sub DisplayRevealedBonusTIlePictures()
        'UNIMPLEMENTED: 0,4,8というインデックスを知っているのは内部を知り過ぎている感じ
        Me.BonusTIlePicture0.Image = PrecureCharacterSet.GetInstance.CurrentRoundRevealedBonusTilesList(0).Image
        Me.BonusTIlePicture1.Image = PrecureCharacterSet.GetInstance.CurrentRoundRevealedBonusTilesList(4).Image
        Me.BonusTIlePicture2.Image = PrecureCharacterSet.GetInstance.CurrentRoundRevealedBonusTilesList(8).Image
    End Sub

    ''' <summary>
    ''' 裏ボーナス牌を表示する
    ''' </summary>
    Private Sub DisplayUnRevealedBonusTIlePictures(visible As Boolean)

        If visible Then
            'UNIMPLEMENTED: 12,16,20というインデックスを知っているのは内部を知り過ぎている感じ
            Me.BonusTIlePicture3.Image = PrecureCharacterSet.GetInstance.CurrentRoundUnrevealedBonusTilesList(0).Image
            Me.BonusTIlePicture4.Image = PrecureCharacterSet.GetInstance.CurrentRoundUnrevealedBonusTilesList(4).Image
            Me.BonusTIlePicture5.Image = PrecureCharacterSet.GetInstance.CurrentRoundUnrevealedBonusTilesList(8).Image
        Else
            Me.BonusTIlePicture3.Image = Nothing
            Me.BonusTIlePicture4.Image = Nothing
            Me.BonusTIlePicture5.Image = Nothing
        End If

    End Sub
#End Region

    ''' <summary>
    ''' フォームの外観を画像として保存する。マッチ開始時点からリプレイモードではなく通常起動していた場合に限り、動作する。(デバッグ用機能)
    ''' </summary>
    Private Sub CaptureFormImageIfNonReplayMode()
#If DEBUG Then
        If Replay.ReplayDataManager.CurrentState = ReplayModeState.NormalModeSinceMatchStarted Then
            'コントロールの外観を描画するBitmapの作成
            Dim bmp As New Bitmap(Me.Width, Me.Height)
            'キャプチャする
            Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))
            'ファイルに保存する
            bmp.Save(IO.Path.Combine(My.Application.Info.DirectoryPath, "logs\Image" & DateTime.Now.ToString("yyyyMMddhhmmnnss") & ".png"))
            '後始末
            bmp.Dispose()
        End If
#End If
    End Sub
#Region "リプレイ画面からの操作する時のメソッド"

    'UNIMPLEMENTED: 画面によってリプレイ画面からの操作する時のコードの書き方が統一されていない。ここでは、ReplayDataManagerのIsReplayModeプロパティで判断して「リプレイ用/非リプレイ用」のメソッド呼び出しを振り分けしているが、PointFormではReplayFormから「リプレイ用メソッド」を呼び出す形にしている
    Private Sub ReplayOpeningNextRoundForm()

        Dim _comHandIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _humanHandIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _wallPileIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _revealedBonusTiles As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _unrevealedBonusTiles As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters


        Dim _humanHand As New Hand
        Dim _comHand As New Hand
        Dim _wallPile As New WallPile

        _comHandIDList.ForEach(Sub(id) _comHand.MainTiles.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))
        _humanHandIDList.ForEach(Sub(id) _humanHand.MainTiles.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))
        _wallPileIDList.ForEach(Sub(id) _wallPile.Add(PrecureCharacterSet.GetInstance.GetTileDefinition(id)))

        Me.OpenNextRoundForm(_comHand, _humanHand, _wallPile, _revealedBonusTiles, _unrevealedBonusTiles)
    End Sub

    Private Sub TestShantenButton1_Click(sender As Object, e As EventArgs) Handles TestShantenButton1.Click
        Dim _shanten = ShantenCounter.CalculateShanten(Me.HumanPlayer.Hand.TotalTiles.Select(Function(x) x.ID).ToList)

        MessageBox.Show("Shanten:" & _shanten.ShantenCount)

    End Sub




#End Region
End Class
