Namespace View
    Public Class TilePictureClickEventArgs
        Inherits EventArgs
        Private _Index As Integer
        Friend Sub New(ByVal index As Integer)
            _Index = index
        End Sub
        Public ReadOnly Property Index() As Integer
            Get
                Return _Index
            End Get
        End Property
    End Class
End Namespace