Imports System.IO

Module Defaults
    'Alter the Defaults in this module to fit with each project that uses this updater.

    'Project name
    Public Const AppName As String = "TestProgram"

    ' Unique Project ID --
    Public Const UpdateID As String = "UpdateID"

    ' The Applications Root Path "C:\Dir1\Dir2" (No trailing backslash)
    Public AppPath As String = Path.Combine(My.Application.Info.DirectoryPath, "\..\..\..\testprogram\bin\Debug")

    ' The Applications Exe "Dir3\Prog.exe" (from the root path. No leading Backslash)
    Public Const AppEXE As String = "TestProgram.exe"

    ' Other startup defaults.
    Public LastUpdate As String = My.Settings.LastUpdate ' Last update loaded..
    Public Const TimeOutlen As Integer = 60 ' Wait time to connect to Update Site in seconds
    Public Const UpdateSite As String = "nulluo.x.fc2.com/AutoUpdate" ' Default site to download updates from.
End Module
