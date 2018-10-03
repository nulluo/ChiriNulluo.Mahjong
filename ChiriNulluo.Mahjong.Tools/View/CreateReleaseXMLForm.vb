Imports System.IO

Namespace View

    ''' <summary>
    ''' リリース情報定義XMLファイルを作成する画面
    ''' </summary>
    Public Class CreateReleaseXMLForm

        Private _baseDirectory As String
        Private Const TamplateFileName As String = "UpdateIDTemplate.xml"

        ''' <summary>
        ''' 指定したバージョン番号と実行ファイルの置かれたフォルダを使用して、リリース情報定義ファイルを作成する。
        ''' </summary>
        Private Sub ExecuteButton_Click(sender As Object, e As EventArgs) Handles ExecuteButton.Click
            Dim _directoryPath As String

            _directoryPath = _baseDirectory
            'Me.CreateXMLOfReleaseFilesConstruction(_directoryPath)

            With Me.SaveFileDialog1
                .Filter = "XMLファイル(*.xml)|"
                .Title = "保存先のファイルを選択してください"
            End With

            If Me.SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                File.Copy(Path.Combine(My.Application.Info.DirectoryPath, TamplateFileName), Me.SaveFileDialog1.FileName)
            End If

        End Sub

        ''' <summary>
        ''' 指定したフォルダのファイル・フォルダ構成からリリース定義XMLを作成する
        ''' </summary>
        Private Sub CreateXMLOfReleaseFilesConstruction(rootDirectoryPath As String)


            ' このディレクトリ内のすべてのファイルを検索する
            For Each stFilePath As String In System.IO.Directory.GetFiles(rootDirectoryPath)
                'hStringCollection.Add(stFilePath)
            Next stFilePath

            ' このディレクトリ内のすべてのサブディレクトリを検索する (再帰)
            'For Each stDirPath As String In System.IO.Directory.GetDirectories(stRootPath)
            'Dim stFilePathes As String() = GetFilesMostDeep(stDirPath, stPattern)

            ' 条件に合致したファイルがあった場合は、ArrayList に加える
            'If Not stFilePathes Is Nothing Then
            'hStringCollection.AddRange(stFilePathes)
            'End If
            'Next stDirPath

            ' StringCollection を 1 次元の String 配列にして返す
            'Dim stReturns As String() = New String(hStringCollection.Count - 1) {}
            'hStringCollection.CopyTo(stReturns, 0)

            'Return stReturns
        End Sub

        Private Sub selectFolderButton_Click(sender As Object, e As EventArgs) Handles selectFolderButton.Click
            If Me.FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
                _baseDirectory = Me.FolderBrowserDialog1.SelectedPath
            End If

        End Sub
    End Class
End Namespace