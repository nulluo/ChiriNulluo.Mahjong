Imports System.ComponentModel

''' <summary>
''' セルに指定されたIDに従って、牌アイコンを表示する
''' </summary>
Public Class DataGridViewTileImageCell
    Inherits DataGridViewImageCell

    Public Sub New()
        Me.ValueType = GetType(String)
    End Sub

    Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle,
                                                   valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter,
                                                   context As DataGridViewDataErrorContexts) As Object
        Dim _image As Image = Precure.Tiles.PrecureCharacterSet.GetInstance.TileImages(value)
        Return _image

    End Function

    'Public Overrides ReadOnly Property DefaultNewRowValue() As Object
    '    Get
    '        Return String.Empty
    '    End Get
    'End Property
End Class
