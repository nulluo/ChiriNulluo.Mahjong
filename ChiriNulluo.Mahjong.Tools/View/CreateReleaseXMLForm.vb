Imports System.Xml
Imports System.IO

Namespace View

    ''' <summary>
    ''' リリース情報定義XMLファイルを作成する画面
    ''' </summary>
    Public Class CreateReleaseXMLForm

        Private _baseDirectory As String
        Private Const TamplateFileName As String = "UpdateIDTemplate.xml"
        Private _xmlAccess As DataAccess.XMLAccess

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
                Dim _saveFilePath As String = Me.SaveFileDialog1.FileName
                'If File.Exists(_saveFilePath) Then
                '    If MessageBox.Show("同名のファイルが存在します。上書きしますか？", "警告", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                '        Return
                '    End If
                'End If
                File.Copy(Path.Combine(My.Application.Info.DirectoryPath, TamplateFileName), _saveFilePath, True)
                Me.LoadXML(_saveFilePath)
                Me.CreateXMLOfReleaseFilesConstruction(_saveFilePath, Me.TargetFolderField.Text, "")

                System.Diagnostics.Process.Start(_saveFilePath)
            End If

        End Sub

        Private Sub LoadXML(loadXMLFilePath As String)
            Me._xmlAccess = New DataAccess.XMLAccess(loadXMLFilePath)
        End Sub

        ''' <summary>
        ''' 指定したフォルダのファイル・フォルダ構成からリリース定義XMLを作成する。
        ''' rootDirectoryPathにdirectoryPathFromRootを追加したパスで指定されるフォルダの中のフォルダ・ファイル情報を再帰的にXMLファイルに書き込む
        ''' </summary>
        ''' <param name="xmlFilePath">作成するXMLファイルのフルパス</param>
        ''' <param name="rootDirectoryPath">リリースファイルが保存されているフォルダ(ルート)</param>
        ''' <param name="directoryPathFromRoot">ルートからの相対パス</param>
        Private Sub CreateXMLOfReleaseFilesConstruction(xmlFilePath As String, rootDirectoryPath As String, directoryPathFromRoot As String)
            With Me._xmlAccess
                .SetNodeAttributeValue("updates", "total", Me.VersionField.Text)

                Dim _foldersNode As XmlNode = .GetNode("updates/folders")
                Dim _folderElement As XmlElement = .XMLDocument.CreateElement("folder")
                Dim _nameAttribute As XmlAttribute = .XMLDocument.CreateAttribute("name")
                _nameAttribute.Value = directoryPathFromRoot
                _folderElement.Attributes.Append(_nameAttribute)
                _foldersNode.AppendChild(_folderElement)
                Dim _filesElement As XmlElement = .XMLDocument.CreateElement("files")
                _folderElement.AppendChild(_filesElement)


                ' このディレクトリ内のすべてのファイルを検索する
                For Each _filePath As String In System.IO.Directory.GetFiles(rootDirectoryPath)
                    Dim _fileElement As XmlElement = .XMLDocument.CreateElement("file")
                    _fileElement.InnerText = CutRootDiretoryPath(_filePath)
                    _filesElement.AppendChild(_fileElement)
                Next _filePath

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

                .Save(xmlFilePath)

            End With
        End Sub

        Private Sub selectFolderButton_Click(sender As Object, e As EventArgs) Handles selectFolderButton.Click
            If Me.FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
                _baseDirectory = Me.FolderBrowserDialog1.SelectedPath
            End If

        End Sub

        ''' <summary>
        ''' リリースファイル全てが保存されたフォルダをルートとし、
        ''' ルートフォルダ内にあるフォルダ、ファイルのフルパスを、ルートを起点とする相対パスに変換します。
        ''' </summary>
        ''' <param name="fullPathFileName">フルパスで表したファイル名、フォルダ名</param>
        ''' <returns>ルートからの相対パス</returns>
        Private Function CutRootDiretoryPath(fullPathFileName As String) As String
            Return fullPathFileName.Substring(_baseDirectory.Length)
        End Function

        Private Sub TargetFolderField_TextChanged(sender As Object, e As EventArgs) Handles TargetFolderField.TextChanged
            Me._baseDirectory = DirectCast(sender, TextBox).Text
        End Sub
    End Class
End Namespace