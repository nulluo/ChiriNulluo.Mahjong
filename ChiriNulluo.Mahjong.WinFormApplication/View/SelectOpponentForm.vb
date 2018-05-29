﻿Imports ChiriNulluo.Mahjong.Precure.Players

Public Class SelectOpponentForm

#Region "Property"
    Public Property Facade As New SetOpponentFacade(Me)
#End Region

#Region "Event Handler"

    Private Sub SelectOpponentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        Me.ManualModeField.Visible = True
#Else
        Me.ManualModeField.Visible = False
#End If

    End Sub

    Private Function OpponentButton_Click(sender As Object, e As EventArgs) As Form Handles ButtonRegina.Click, ButtonEas.Click, ButtonRiko.Click
        Me.Facade.SetOpponent(sender.name.replace("Button", String.Empty))

        Dim _nextForm As Form = Me.Facade.GoToNextForm(Me.ManualModeField.Checked)
        Return Me.GoToNextForm(_nextForm)
    End Function


    ''' <summary>
    ''' ユーザーがフォーム閉じようとした時のゲーム終了確認。
    ''' </summary>
    Private Sub RoundForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormTransition.ConfirmFormClosing(e)
    End Sub

    Friend Function GoToNextForm(nextForm As Form) As Form
        FormTransition.Transit(Me, nextForm)
        Return nextForm
    End Function

#End Region

End Class