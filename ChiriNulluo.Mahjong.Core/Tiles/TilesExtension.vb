Imports System.ComponentModel

Namespace Tiles
    Module TilesExtension

        <System.Runtime.CompilerServices.Extension()>
        Public Sub AddRange(Of T)(list As BindingList(Of T), data As IEnumerable(Of T))

            If list Is Nothing OrElse data Is Nothing Then
                Return
            End If

            For Each _item As T In data
                list.Add(_item)
            Next
        End Sub

    End Module

End Namespace