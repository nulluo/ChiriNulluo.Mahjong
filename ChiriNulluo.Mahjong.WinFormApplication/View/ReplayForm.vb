Imports System.Text
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.WinFormApplication.Replay

Public Class ReplayForm

#Region "Property"

    Private Property TargetForm As Form

#End Region

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Replay.ReplayDataManager.CurrentState = ReplayModeState.Running

    End Sub

#Region "Event Handler"

    Private Sub ReplayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LoadReplayDataToGrid()
    End Sub

    Private Sub forwardButton_Click(sender As Object, e As EventArgs) Handles forwardButton.Click
        Dim _data = Replay.ReplayDataManager.GoForward
        If _data Is Nothing Then
            Me.forwardButton.Enabled = False
            Return
        End If

        With _data
            Select Case .ProcessID
                Case My.Resources.IDProcessSelectOpponent
                    Me.SelectOpponent(.Parameters(0))

                Case My.Resources.IDProcessDiscardTile
                    Me.DiscardTile(CInt(Replay.ReplayDataManager.CurrentData.Parameters(0)))

                Case My.Resources.IDProcessNextRoundButton
                    Me.ClickNextRoundButton()

                Case My.Resources.IDProcessRiichi
                    Me.Riichi()

            End Select
            Me.MoveCurrentRowOfDataGridView(Replay.ReplayDataManager.CurrentData.LogNoInMatch)
        End With

    End Sub

    Private Sub endReplayButton_Click(sender As Object, e As EventArgs) Handles endReplayButton.Click
        Replay.ReplayDataManager.CurrentState = ReplayModeState.NormalModeSinceReplayModeEnded
        Dim _form = My.Application.ApplicationContext.MainForm
        If TypeOf (_form) Is RoundForm Then
            DirectCast(_form, RoundForm).AddUIHandlers()
        ElseIf TypeOf (_form) Is PointForm Then
            DirectCast(_form, PointForm).AddUIHandlers()
        End If
        Me.Close()
    End Sub

#End Region

#Region "他画面操作用メソッド"
    Private Sub SelectOpponent(precurePlayerID As String)
        '対戦相手選択
        Dim _selectOpponentForm As New SelectOpponentForm()
        _selectOpponentForm.Show(Me)
        _selectOpponentForm.Facade.SetOpponent(precurePlayerID)

        Dim _comHandIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _humanHandIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters
        Dim _wallPileIDList As List(Of String) = Replay.ReplayDataManager.GoForward.Parameters

        'Me.StartMatch(_humanHandIDList, _comHandIDList, _wallPileIDList)

        '次画面取得
        Me.TargetForm = _selectOpponentForm.Facade.GoToNextForm(False,
                                _humanHandIDList, _comHandIDList, _wallPileIDList)
        _selectOpponentForm.GoToNextForm(Me.TargetForm)
        Me.Activate()
    End Sub

    'Private Sub StartMatch(humanHandIDList As List(Of String), comHandIDList As List(Of String),
    '                       wallPileIDList As List(Of String))

    '    With humanHandIDList
    '        .Add("0101")
    '        .Add("0102")
    '        .Add("0102")
    '        .Add("0201")
    '        .Add("0202")
    '        .Add("0301")
    '        .Add("0302")
    '        .Add("1002")
    '        .Add("0304")
    '        .Add("0305")
    '        .Add("0306")
    '        .Add("0401")
    '        .Add("0402")
    '    End With

    '    With comHandIDList
    '        .Add("1102")
    '        .Add("0404")
    '        .Add("0501")
    '        .Add("0502")
    '        .Add("0503")
    '        .Add("0504")
    '        .Add("0601")
    '        .Add("0602")
    '        .Add("0603")
    '        .Add("0604")
    '        .Add("0701")
    '        .Add("0702")
    '        .Add("0703")
    '    End With


    '    With wallPileIDList
    '        .Add("0704")
    '        .Add("0705")
    '        .Add("0801")
    '        .Add("0802")
    '        .Add("0803")
    '        .Add("0804")
    '        .Add("0805")
    '        .Add("0901")
    '        .Add("0902")
    '        .Add("0903")
    '        .Add("0904")
    '        .Add("1001")
    '        .Add("1002")
    '        .Add("1003")
    '        .Add("1004")
    '        .Add("1101")
    '        .Add("1102")
    '        .Add("1103")
    '        .Add("0101")
    '        .Add("0102")
    '        .Add("0102")
    '        .Add("1004")
    '        .Add("0202")
    '        .Add("0301")
    '        .Add("0302")
    '        .Add("0303")
    '        .Add("0304")
    '        .Add("0305")
    '        .Add("0306")
    '        .Add("0401")
    '        .Add("0402")
    '        .Add("0403")
    '        .Add("0404")
    '        .Add("0501")
    '        .Add("0502")
    '        .Add("0503")
    '        .Add("0504")
    '        .Add("0601")
    '        .Add("0602")
    '        .Add("0603")
    '        .Add("0604")
    '        .Add("0701")
    '        .Add("0702")
    '        .Add("0703")
    '        .Add("0704")
    '        .Add("0705")
    '        .Add("0801")
    '        .Add("0802")
    '        .Add("0803")
    '        .Add("0804")
    '        .Add("0805")
    '        .Add("0901")
    '        .Add("0902")
    '        .Add("0903")
    '        .Add("0904")
    '        .Add("1001")
    '        .Add("1002")
    '        .Add("1003")
    '        .Add("1004")
    '        .Add("1101")
    '        .Add("1102")
    '        .Add("1103")
    '        .Add("0101")
    '        .Add("0102")
    '        .Add("0103")
    '        .Add("0201")
    '        .Add("0202")
    '        .Add("0301")
    '        .Add("0302")
    '        .Add("0303")
    '        .Add("0304")
    '        .Add("0305")
    '        .Add("0306")
    '        .Add("0401")
    '        .Add("0402")
    '        .Add("0403")
    '        .Add("0404")
    '        .Add("0501")
    '        .Add("0502")
    '        .Add("0503")
    '        .Add("0504")
    '        .Add("0601")
    '        .Add("0602")
    '        .Add("0603")
    '        .Add("0604")
    '        .Add("0701")
    '        .Add("0702")
    '        .Add("0703")
    '        .Add("0704")
    '        .Add("0705")
    '        .Add("0801")
    '        .Add("0802")
    '        .Add("0803")
    '        .Add("0804")
    '        .Add("0805")
    '        .Add("0901")
    '        .Add("0902")
    '        .Add("0903")
    '        .Add("0904")
    '        .Add("1001")
    '        .Add("1002")
    '        .Add("1003")
    '        .Add("1004")
    '        .Add("1101")
    '        .Add("1102")
    '        .Add("1103")
    '        .Add("0101")
    '        .Add("1101")
    '        .Add("0103")
    '        .Add("0201")
    '        .Add("0202")
    '        .Add("0301")
    '        .Add("0302")
    '        .Add("0303")
    '        .Add("0304")
    '        .Add("0305")
    '        .Add("0306")
    '        .Add("0401")
    '        .Add("0402")
    '        .Add("0403")
    '        .Add("0404")
    '        .Add("0501")
    '        .Add("0502")
    '        .Add("0503")
    '        .Add("0504")
    '        .Add("0601")
    '        .Add("0602")
    '        .Add("0603")
    '        .Add("0604")
    '        .Add("0701")
    '        .Add("0702")
    '        .Add("0703")
    '        .Add("0704")
    '        .Add("0705")
    '        .Add("0801")
    '        .Add("0802")
    '        .Add("0803")
    '        .Add("0804")
    '        .Add("0805")
    '        .Add("0901")
    '        .Add("0902")
    '        .Add("0903")
    '        .Add("0904")
    '        .Add("0201")
    '        .Add("1001")
    '        .Add("1003")
    '        .Add("0303")
    '        .Add("0102")
    '        .Add("0403")
    '        .Add("1103")
    '    End With

    'End Sub

    'Private Sub Haipai()

    'End Sub

    Private Sub DiscardTile(tileIndex As Integer)
        Dim _roundForm As RoundForm = DirectCast(My.Application.ApplicationContext.MainForm, RoundForm)
        _roundForm.DiscardHumanTile(tileIndex)
    End Sub

    Private Sub ClickNextRoundButton()
        Dim _mainForm = My.Application.ApplicationContext.MainForm
        DirectCast(_mainForm, PointForm).ReplayOpeningNextForm()
        Me.Activate()
    End Sub

    Private Sub Riichi()
        Dim _mainForm = My.Application.ApplicationContext.MainForm
        DirectCast(_mainForm, RoundForm).Riichi(Replay.ReplayDataManager.CurrentData.Player = My.Resources.IDPlayerHuman)
    End Sub

#End Region

    Private Sub LoadReplayDataToGrid()
        With Me.DataGridView1
            .DataSource = ReplayDataManager.DataList
            .CurrentCell = .Item(0, 0)
        End With
    End Sub

    ''' <summary>
    ''' 現在実行中のログまでカレント行を移動する
    ''' </summary>
    Private Sub MoveCurrentRowOfDataGridView(LogNoInMatch As String)
        With Me.DataGridView1
            For i As Integer = .CurrentRow.Index To .RowCount - 1
                If .Item("LogNoInMatchColumn", i).Value.ToString = LogNoInMatch Then
                    .CurrentCell = .Item(0, i)
                    Exit For
                End If
            Next
        End With
    End Sub

End Class