Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.WinFormApplication.Logging

Public Class TileSelectWindowForm
#Region "Property"

    Public Property MainMessage As String
        Get
            Return Me.MainMessageLabel.Text
        End Get
        Set(value As String)
            Me.MainMessageLabel.Text = value
        End Set
    End Property

    Public ReadOnly Property ChoicedPile As RevealedTiles
        Get
            Return Me._choicePileList(Me.SelectedIndex)
        End Get
    End Property

    Private _selectedIndex As Integer = 0
    Private Property SelectedIndex As Integer
        Get
            Return _selectedIndex
        End Get
        Set(value As Integer)
            _selectedIndex = value

            If Me._choicePileList.Count > 0 Then
                Me.HorizontalRevealedHandPanel1.DataSource = Me._choicePileList(value)
            End If
        End Set
    End Property

#End Region

    Private _choicePileList As New List(Of RevealedTiles)
    ''' <summary>
    ''' 選択肢となる副露牌を追加する
    ''' </summary>
    ''' <param name="choicePile"></param>
    Public Sub AddChoicePile(choicePile As RevealedTiles)
        If Me._choicePileList.Count > 4 Then
            Return
        End If

        Me._choicePileList.Insert(0, choicePile)
    End Sub

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.MainMessageLabel.ResetText()

    End Sub


    ''' <summary>
    ''' MessageWindowFormを表示する。
    ''' </summary>
    ''' <param name="mainMessage"></param>
    ''' <param name="choiceMessage"></param>
    ''' <returns></returns>
    Public Shared Function ShowWindow(mainMessage As String, owner As Form, ParamArray choicePile() As RevealedTiles) As RevealedTiles
        Dim _form As New TileSelectWindowForm
        _form.MainMessage = mainMessage


        For Each _pile As RevealedTiles In choicePile
            _form.AddChoicePile(_pile)
        Next
        _form.SelectedIndex = 0
        _form.Left = owner.Left + (owner.Width - _form.Width) \ 2
        _form.Top = owner.Top + (owner.Height - _form.Height) \ 2
        If Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
            Replay.ReplayDataManager.GoForward()
            _form.SelectedIndex = CInt(Replay.ReplayDataManager.CurrentData.Parameters(0))
        Else
            _form.ShowDialog()
            'UNIMPLEMENTED: 可能なら、ここでチーした牌の情報をパラメータremarkにセットする
            LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA, My.Resources.IDProcessChow,
                           My.Resources.IDPlayerHuman, String.Empty, _form.SelectedIndex)
        End If
        Dim _receiveValue As RevealedTiles = _form.ChoicedPile
        _form.Dispose()
        Return _receiveValue
    End Function

    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        Me.Close()
    End Sub

    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        If Me.SelectedIndex = 0 Then
            Me.SelectedIndex = Me._choicePileList.Count - 1
        Else
            Me.SelectedIndex -= 1
        End If
    End Sub

    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        If Me.SelectedIndex = Me._choicePileList.Count - 1 Then
            Me.SelectedIndex = 0
        Else
            Me.SelectedIndex += 1
        End If
    End Sub

End Class