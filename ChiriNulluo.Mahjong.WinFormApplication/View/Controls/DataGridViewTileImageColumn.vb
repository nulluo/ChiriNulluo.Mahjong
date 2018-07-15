Namespace View
    ''' <summary>
    ''' セルに指定されたIDに従って、牌アイコンを表示する
    ''' </summary>
    Public Class DataGridViewTileImageColumn
        Inherits DataGridViewImageColumn

        Public Sub New()
            Me.CellTemplate = New DataGridViewTileImageCell()
            Me.ValueType = Me.CellTemplate.ValueType
        End Sub

    End Class
End Namespace