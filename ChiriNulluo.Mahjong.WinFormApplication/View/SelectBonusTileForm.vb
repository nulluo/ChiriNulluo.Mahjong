Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.WinFormApplication.Facade

Namespace View
    Public Class SelectBonusTileForm

#Region "Property"
        Public Property Facade As New SelectBonusTileFacade(Me)

#End Region

        Private Sub SelectBonusTileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.specialTileGrid.AutoGenerateColumns = False

            Me.specialTileGrid.DataSource = PrecureCharacterSet.GetInstance.SpecialCharacterTilesList
            With Me.SelectRevealedBonusTileColumn
                .TrueValue = True
                .IndeterminateValue = False
                .FalseValue = False
            End With
            With Me.SelectUnrevealedBonusTileColumn
                .TrueValue = True
                .IndeterminateValue = False
                .FalseValue = False
            End With

            AddHandler specialTileGrid.CurrentCellDirtyStateChanged, AddressOf Me.specialTileGrid_CurrentCellDirtyStateChanged
        End Sub

        Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
            Me.DecideBonusTiles()
        End Sub


        ''' <summary>
        ''' ボーナス牌の選択を確定する。
        ''' </summary>
        ''' <returns></returns>
        Private Sub DecideBonusTiles()

            Dim _revealedBonusTilesList As New List(Of String)
            Dim _unrevealedBonusTilesList As New List(Of String)

            With Me.specialTileGrid
                For Each _row As DataGridViewRow In .Rows
                    If _row.Cells("SelectRevealedBonusTileColumn").Value IsNot Nothing AndAlso
                    DirectCast(_row.Cells("SelectRevealedBonusTileColumn").Value, Boolean) = True Then
                        _revealedBonusTilesList.Add(_row.Cells("bonusTileIDColumn").Value.ToString)
                    ElseIf _row.Cells("SelectUnrevealedBonusTileColumn").Value IsNot Nothing AndAlso
                        DirectCast(_row.Cells("SelectUnrevealedBonusTileColumn").Value, Boolean) = True Then
                        _unrevealedBonusTilesList.Add(_row.Cells("bonusTileIDColumn").Value.ToString)
                    End If
                Next

            End With

            If _revealedBonusTilesList.Count = 3 AndAlso _unrevealedBonusTilesList.Count = 3 Then
                Me.Facade.GoToNextForm(_revealedBonusTilesList, _unrevealedBonusTilesList)
            Else
                MessageBox.Show("選択されたボーナス牌の枚数が不正です。表ボーナス牌/裏ボーナス牌の枚数はそれぞれ３枚ずつです。")
            End If

        End Sub

        ''' <summary>
        ''' 通常、CellValueChangedイベントは、チェックボックスがチェックされた後に別のセルにフォーカスを移すなどして
        ''' 値がコミットされてからでないと発生しないため、チェックボックスがチェックされた直後にCellValueChangedイベントが発生するようにする
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub specialTileGrid_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
            With Me.specialTileGrid
                If (.CurrentCell.OwningColumn Is Me.SelectRevealedBonusTileColumn OrElse
                .CurrentCell.OwningColumn Is Me.SelectUnrevealedBonusTileColumn) AndAlso
                .IsCurrentCellDirty Then
                    'コミットする
                    .CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            End With
        End Sub

        ''' <summary>
        ''' グリッドのチェックボックス列がチェックされた時の処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub specialTileGrid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles specialTileGrid.CellValueChanged
            With Me.specialTileGrid
                If (e.ColumnIndex = 0 OrElse e.ColumnIndex = 1) AndAlso 0 <= e.RowIndex AndAlso
                .Item(e.ColumnIndex, e.RowIndex).Value IsNot Nothing AndAlso
                DirectCast(.Item(e.ColumnIndex, e.RowIndex).Value, Boolean) = True Then

                    Dim _targeteColumnIndex = 1 - e.ColumnIndex
                    .Item(_targeteColumnIndex, e.RowIndex).Value = False

                End If
            End With
        End Sub

        Friend Function GoToNextForm(nextForm As Form) As Form
            FormTransition.Transit(Me, nextForm)
            Return nextForm
        End Function

    End Class
End Namespace