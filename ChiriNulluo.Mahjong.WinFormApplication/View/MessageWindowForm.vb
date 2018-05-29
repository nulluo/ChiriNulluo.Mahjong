Imports ChiriNulluo.Mahjong.WinFormApplication.Constants
Imports ChiriNulluo.Mahjong.WinFormApplication.Logging

Public Class MessageWindowForm
#Region "Property"

    Private Property ChoiceLabelsList As List(Of Label)
    Private Property CursorLabelList As List(Of Label)

    Public Property MainMessage As String
        Get
            Return Me.MainMessageLabel.Text
        End Get
        Set(value As String)
            Me.MainMessageLabel.Text = value
        End Set
    End Property

    Private Property ChoicedText As String

#End Region

    Private _choiceMessages As New List(Of String)
    ''' <summary>
    ''' 選択肢テキストを追加する
    ''' </summary>
    ''' <param name="choiceMessage"></param>
    Public Sub AddChoiceMessage(choiceMessage As String)
        If Me._choiceMessages.Count > 4 Then
            Return
        End If

        Me._choiceMessages.Add(choiceMessage)
        Dim i As Integer = Me._choiceMessages.Count - 1
        Me.ChoiceLabelsList(i).Text = Me._choiceMessages(i)
    End Sub

    ''' <summary>
    ''' 選択肢テキストを全て消去する
    ''' </summary>
    Public Sub ClearChoiceMessages()
        For Each label As Label In Me.ChoiceLabelsList
            label.ResetText()
        Next
    End Sub

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.ChoiceLabelsList = New List(Of Label) From {ChoiceLabel0, ChoiceLabel1, ChoiceLabel2, ChoiceLabel3}
        Me.CursorLabelList = New List(Of Label) From {CursorLabel0, CursorLabel1, CursorLabel2, CursorLabel3}

        Me.MainMessageLabel.ResetText()
        Me.ClearChoiceMessages()
        Me.CursorLabelList.ForEach(Sub(label) label.ResetText())

        Me.ChoiceLabelsList.ForEach(Sub(label)
                                        AddHandler label.Click, AddressOf Me.ChoiceLabel_Click
                                        AddHandler label.MouseEnter, AddressOf Me.ChoiceLabel_MouseEnter
                                        AddHandler label.MouseLeave, AddressOf Me.ChoiceLabel_MouseLeave
                                    End Sub)

    End Sub

    Private Sub ChoiceLabel_Click(sender As Object, e As EventArgs)
        Me.ChoicedText = sender.text
        Me.Close()
    End Sub

    ''' <summary>
    ''' MessageWindowFormを表示する。
    ''' </summary>
    ''' <param name="mainMessage"></param>
    ''' <param name="choiceMessage"></param>
    ''' <returns></returns>
    Public Shared Function ShowWindow(mainMessage As String, owner As Form, ParamArray choiceMessage() As String) As String
        Dim _form As New MessageWindowForm
        _form.MainMessage = mainMessage
        For Each message As String In choiceMessage
            _form.AddChoiceMessage(message)
        Next
        _form.Left = owner.Left + (owner.Width - _form.Width) / 2
        _form.Top = owner.Top + (owner.Height - _form.Height) / 2

        _form.ShowDialog()
        Dim _receiveValue As String = _form.ChoicedText
        _form.Dispose()

        LogFactory.GetReplayLogger.Write(My.Resources.IDProcessTypeUA, My.Resources.IDProcessMeesageWindowChoice,
                   My.Resources.IDPlayerHuman, String.Empty, _receiveValue)

        Return _receiveValue
    End Function

    Private Sub ChoiceLabel_MouseEnter(sender As Object, e As EventArgs) Handles ChoiceLabel0.MouseEnter
        Dim _index As Integer = Integer.Parse(sender.name.subString(11))
        Me.CursorLabelList(_index).Text = "⇒"

    End Sub

    Private Sub ChoiceLabel_MouseLeave(sender As Object, e As EventArgs) Handles ChoiceLabel0.MouseLeave
        Dim _index As Integer = Integer.Parse(sender.name.subString(11))
        Me.CursorLabelList(_index).ResetText()

    End Sub

    Private Sub MessageWindowForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Replay.ReplayDataManager.CurrentState = ReplayModeState.Running Then
            Replay.ReplayDataManager.GoForward()
            Me.ChoicedText = Replay.ReplayDataManager.CurrentData.Parameters(0)
            Me.Close()
        End If
    End Sub
End Class