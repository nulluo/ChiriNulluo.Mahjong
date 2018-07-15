Imports System.ComponentModel

Namespace View
    Public Class RichButton

        <Category("表示")>
        <Description("マウスカーソルがボタン上にある時に表示するイメージです。")>
        Public Property HoverImage As Image

        <Category("表示")>
        <Description("マウス押下時に表示するイメージです。")>
        Public Property PushedImage As Image

        Private Property NormalImage As Image


        Private Const MoveDeltaX As Integer = 2
        Private Const MoveDeltaY As Integer = 2

        Protected OriginalLocation As Point

        Protected Overrides Sub InitLayout()
            MyBase.InitLayout()

            Me.OriginalLocation = Me.Location
            Me.NormalImage = Me.Image

        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            Dim newLocation As Point = Me.Location
            newLocation.X += MoveDeltaX
            newLocation.Y += MoveDeltaY
            Me.Location = newLocation

            Me.Image = PushedImage
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            Me.Location = OriginalLocation
            Me.Image = Me.NormalImage
            MyBase.OnMouseUp(e)
        End Sub

        Private Sub RichButton_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
            Me.Image = Me.HoverImage
        End Sub

        Private Sub RichButton_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
            Me.Image = Me.NormalImage
        End Sub
    End Class
End Namespace