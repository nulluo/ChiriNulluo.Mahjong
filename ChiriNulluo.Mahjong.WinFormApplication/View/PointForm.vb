Imports ChiriNulluo.Mahjong.Core.Yaku
Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.DataAccess
Imports ChiriNulluo.Mahjong.Core.Players
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.Precure.Yaku

Namespace View

    ''' <summary>
    ''' 対局終了後の点数表示画面
    ''' </summary>
    Public Class PointForm

        'UNIMPLEMENTED: 本来はこのコンストラクタは不要である。※RoundForm.Resultを
        Public Sub New(winningPlayer As Player, losingPlayer As Player)

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            Me.WinningPlayer = winningPlayer
            Me.LosingPlayer = losingPlayer
        End Sub

        Private Property WinningPlayer As Player

        Private Property LosingPlayer As Player

        Private Property SeriesPrecureList As New List(Of List(Of String))

        Private Property GainedScore As Integer

#Region "Form Transition"
        'UNIMPLEMENTED: COMHAND、HUMANHAND、WALLPILEの順序が一定していないのが気になる（Human->COMの順序が良いだろうと思っていたが、積み込む順番の関係上、先に配牌するのがHumanでなくCOMになったため）
        Private Sub OpenNextForm(comHand As Hand, humanHand As Hand, wallPile As WallPile,
                   revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String))
            Dim _nextForm As Form

            If MatchManagerController.GetInstance.MatchManager.RoundsCount = Constants.MaxRounds2PlayersMatch Then
                _nextForm = New MatchResultForm()
            ElseIf Me.ManualModeField.Checked Then
                _nextForm = New SelectBonusTileForm
            Else
                _nextForm = New RoundForm(humanHand, comHand, wallPile, revealedBonusTiles, unrevealedBonusTiles)
            End If
            FormTransition.Transit(Me, _nextForm)
        End Sub


#End Region

#Region "Event Handler"

        Private Sub DebugYakuEvaluatorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
            Me.ManualModeField.Visible = True
#Else
        Me.ManualModeField.Visible = False
#End If

            '役判定
            Dim _handChecker As New Precure.HandChecker.PrecureHandChecker(WinningPlayer.Hand)
            Dim _table = _handChecker.GetYakuInfo(WinningPlayer.RiichiDone)

            If _handChecker.IsSetCompleteButNoYakus Then
                Me.DataGridView1.Columns(1).DefaultCellStyle.ForeColor = Color.Red
            End If
            Me.DataGridView1.DataSource = _table


            '合計点を表示
            Dim _query = From el In _table.AsEnumerable
            GainedScore = (_query.Sum(Function(el) CInt(el("Point"))))

            Me.pointField.Text = GainedScore.ToString

            '敗者のスコアから勝者のスコアへ点数分移動
            WinningPlayer.Score += GainedScore
            LosingPlayer.Score -= GainedScore

            'UNIMPLEMENTED: 副露牌があった場合も表示できるようにする
            Me.WinningPlayer.Hand.MainTiles.Sort()
            Me.HorizontalHandPanel1.DataSource = Me.WinningPlayer.Hand.MainTiles

            '副露牌表示コントロールの読み込み
            Dim _count As Integer = Me.WinningPlayer.Hand.RevealedCount
            For i As Integer = 0 To _count - 1
                Dim _revealedHandPanel As HorizontalRevealedHandPanel = DirectCast(Me.Controls.Find("horizontalRevealedHandPanel" & i, True)(0), HorizontalRevealedHandPanel)
                _revealedHandPanel.DataSource = Me.WinningPlayer.Hand.RevealedTilesList(i)
            Next

            '上がったプレイヤーの情報表示
            If Me.WinningPlayer Is MatchManagerController.GetInstance.HumanPlayer Then
                Me.playerNameField.Text = My.Resources.LabelYou
                Me.PictureBox1.Image = My.Resources.SystemWindow02
            Else
                Me.playerNameField.Text = MatchManagerController.GetInstance.OpponentManager.GetDisplayName
                Me.PictureBox1.Image = MatchManagerController.GetInstance.OpponentManager.GetWinningImage
            End If

            If Not Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
                Me.AddUIHandlers()
            End If

            Me.DataGridView1.ColumnHeadersVisible = False

            'UNIMPLEMENTED: DataGridViewにフォントを設定していても適用されない。なぜ?
            Me.DataGridView1.RowsDefaultCellStyle.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))

        End Sub

        Private Sub NextRoundButton_Click(sender As Object, e As EventArgs)
            Logging.LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA,
                            My.Resources.IDProcessNextRoundButton, My.Resources.IDPlayerHuman, String.Empty, DirectCast(sender, Button).Name)
            Me.OpenNextForm(Nothing, Nothing, Nothing, Nothing, Nothing)
        End Sub

        ''' <summary>
        ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
        ''' </summary>
        Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            FormTransition.ConfirmFormClosing(e)
        End Sub

        ''' <summary>
        ''' フォームが表示された時にグリッドビューのセルが選択されないようにする
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub PointForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Me.DataGridView1.CurrentCell = Nothing

            'チョンボしていた場合は警告を表意jする
            If GainedScore = -3000 Then
                Me.ShowMessageWindows(My.Resources.SystemScriptChomboWarning)
            End If
        End Sub

#End Region

#Region "リプレイ画面からの操作用メソッド"

        Friend Sub ReplayOpeningNextForm()
            If MatchManagerController.GetInstance.MatchManager.RoundsCount = Constants.MaxRounds2PlayersMatch Then
                Me.OpenNextForm(Nothing, Nothing, Nothing, Nothing, Nothing)
            Else
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

                Me.OpenNextForm(_comHand, _humanHand, _wallPile, _revealedBonusTiles, _unrevealedBonusTiles)

            End If
        End Sub
#End Region


        ''' <summary>
        ''' 画面上のUI操作に関するイベントハンドラーとイベントの紐づけを実行する。
        ''' </summary>
        ''' <remarks>リプレイモードがONの時はUI操作を受け付けないためにこのメソッドを実装した</remarks>
        Friend Sub AddUIHandlers()
            AddHandler NextRoundButton.Click, AddressOf Me.NextRoundButton_Click
            Me.ManualModeField.Enabled = True
        End Sub

        Private Sub ShowMessageWindows(words As String)
            Dim _dialog As New TalkingCharaWindowForm()
            _dialog.Left = Me.Left + (Me.Width - _dialog.Width) \ 2
            _dialog.Top = Me.Top + (Me.Height - _dialog.Height) \ 2
            _dialog.Owner = Me
            _dialog.Words = words
            _dialog.CharacterImage = MatchManagerController.GetInstance.OpponentManager.GetNormalImage
            _dialog.ShowDialog()
        End Sub

        Private Sub TwitterShareButton_Click(sender As Object, e As EventArgs) Handles TwitterShareButton.Click
            'コントロールの外観を描画するBitmapの作成
            Dim bmp As New Bitmap(Me.Width, Me.Height)
            'キャプチャする
            Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))
            'ファイルに保存する
            bmp.Save(IO.Path.Combine(My.Application.Info.DirectoryPath, "logs\Image" & DateTime.Now.ToString("yyyyMMddhhmmnnss") & ".png"))
            '後始末
            bmp.Dispose()

            Dim _form As New TwitterShareForm(Me, IO.Path.Combine(My.Application.Info.DirectoryPath, "logs\", "ScreenShot.gif"))
            _form.Show()
        End Sub
    End Class
End Namespace