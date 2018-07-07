Imports ChiriNulluo.Mahjong.Precure.Tiles

Public Class SelectBonusTileForm


    Private Sub SelectBonusTileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.specialTileGrid.AutoGenerateColumns = False

        Me.specialTileGrid.DataSource = PrecureCharacterSet.GetInstance.SpecialCharacterTilesList
        With Me.SelectCheckColumn
            .TrueValue = True
            .IndeterminateValue = False
            .FalseValue = False
        End With
    End Sub

    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        If ValidateCheckBoxColumn() Then
        Else
            MessageBox.Show("ボーナス牌の数が不正です")
        End If
    End Sub

    Private Function ValidateCheckBoxColumn() As Boolean
        Dim _checkCount As Integer = 0

        With Me.specialTileGrid
            For Each _row As DataGridViewRow In .Rows
                If _row.Cells("SelectCheckColumn").Value IsNot Nothing AndAlso
                    DirectCast(_row.Cells("SelectCheckColumn").Value, Boolean) = True Then
                    _checkCount += 1
                End If
            Next

        End With

        Return _checkCount = 6

    End Function

End Class