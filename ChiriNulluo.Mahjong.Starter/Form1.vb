Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Shell(Path.Combine(My.Application.Info.DirectoryPath, "Game\CureJongMain.exe"), AppWinStyle.NormalFocus)
        Application.Exit()
    End Sub
End Class
