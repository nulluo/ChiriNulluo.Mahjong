Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices

Namespace View

    Friend Module ControlExtension

        <DllImport("user32.dll")>
        Private Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        End Function
        Private Const WM_SETREDRAW As Integer = &HB

        ''' <summary>
        ''' コントロールの再描画を停止させる
        ''' </summary>
        ''' <param name="control">対象のコントロール</param>
        <Extension()>
        Public Sub BeginUpdate(control As Control)
            SendMessage(New HandleRef(control, control.Handle), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
        End Sub

        ''' <summary>
        ''' コントロールの再描画を再開させる
        ''' </summary>
        ''' <param name="control">対象のコントロール</param>
        <Extension()>
        Public Sub EndUpdate(control As Control)
            SendMessage(New HandleRef(control, control.Handle), WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
            control.Invalidate()
        End Sub

    End Module
End Namespace