Imports System.IO

Module EntryPoint
    Public Sub Main()
        Shell(Path.Combine(My.Application.Info.DirectoryPath, "Game\CureJongMain.exe"), AppWinStyle.NormalFocus)
        Application.Exit()
    End Sub
End Module
