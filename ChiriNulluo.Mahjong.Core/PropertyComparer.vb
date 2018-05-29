Imports System.ComponentModel

'UNIMPLEMENTED: おそらく不要になったクラス
Public Class PropertyComparer(Of T)
    Implements IComparer(Of T)

    Private Property PropertyDescriptor As PropertyDescriptor

    Private Property ListSortDirection As ListSortDirection

    Public Sub New([property] As PropertyDescriptor, direction As ListSortDirection)
        Me.PropertyDescriptor = [property]
        Me.ListSortDirection = direction
    End Sub


    Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare


    End Function
End Class
