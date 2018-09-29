
Imports System.IO
''' <summary>
''' メインアプリケーションを起動する
''' </summary>
Public Class Launcher

    ''' <summary>
    ''' 起動する。
    ''' </summary>
    Public Shared Sub Execute()
        Shell(Path.Combine(Release.ApplicationPath, My.Settings.ExeFileWithExtension), AppWinStyle.NormalFocus)
        Application.Exit()
    End Sub

End Class
