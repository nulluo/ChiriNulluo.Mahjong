Imports ChiriNulluo.Mahjong.Core.Tiles
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Constants

Public Class SelectBonusTileFacade
#Region "Property"

    Private Property View As SelectBonusTileForm

#End Region

    Public Sub New(view As SelectBonusTileForm)
        Me.View = view
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="revealedBonusTiles"></param>
    ''' <param name="unrevealedBonusTiles"></param>
    ''' <returns></returns>
    Public Function GoToNextForm(revealedBonusTiles As List(Of String), unrevealedBonusTiles As List(Of String)) As Form
        Dim _nextForm As Form

        _nextForm = New GameParameterSettingForm(revealedBonusTiles, unrevealedBonusTiles)
        Return Me.View.GoToNextForm(_nextForm)
    End Function

End Class
