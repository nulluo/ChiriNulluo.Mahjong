Imports System.Xml
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Dialogs

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
                Me.AddVersionNoToXML()
                Me.CreateXMLOfReleaseFilesConstruction(Me.TargetFolderField.Text)
                Me._xmlAccess.XMLDocument.Save(_saveFilePath)
                System.Diagnostics.Process.Start(_saveFilePath)
            End If

        End Sub

        Private Sub LoadXML(loadXMLFilePath As String)
            Me._xmlAccess = New DataAccess.XMLAccess(loadXMLFilePath)
        End Sub

        Private Sub AddVersionNoToXML()
            Me._xmlAccess.SetNodeAttributeValue("updates", "total", Me.VersionField.Text)
        End Sub

        ''' <summary>
        ''' 指定したフォルダのファイル・フォルダ構成からリリース定義XMLを作成する。
        ''' targetDirectoryPathで指定されるフォルダの中のフォルダ・ファイル情報を再帰的にXMLファイルに書き込む
        ''' </summary>
        ''' <param name="targetDirectoryPath">リリースファイルが保存されているフォルダのフルパス</param>
        Private Sub CreateXMLOfReleaseFilesConstruction(targetDirectoryPath As String)
            With Me._xmlAccess

                Dim _foldersNode As XmlNode = .GetNode("updates/folders")
                Dim _folderElement As XmlElement = .XMLDocument.CreateElement("folder")
                Dim _pathAttribute As XmlAttribute = .XMLDocument.CreateAttribute("path")
                Dim _directoryPathFromRoot As String = Me.CutRootDiretoryPath(targetDirectoryPath)
                _pathAttribute.Value = _directoryPathFromRoot
                _folderElement.Attributes.Append(_pathAttribute)
                _foldersNode.AppendChild(_folderElement)
                Dim _filesElement As XmlElement = .XMLDocument.CreateElement("files")
                _folderElement.AppendChild(_filesElement)


                ' このディレクトリ内のすべてのファイルを検索する
                For Each _filePath As String In System.IO.Directory.GetFiles(targetDirectoryPath)
                    Dim _fileElement As XmlElement = .XMLDocument.CreateElement("file")
                    Dim _nameAttribute As XmlAttribute = .XMLDocument.CreateAttribute("name")
                    Dim _cutFilePath As String = CutRootDiretoryPath(_filePath)
                    _nameAttribute.Value = Path.GetFileName(_filePath)
                    _fileElement.Attributes.Append(_nameAttribute)

                    Dim _serverElement As XmlElement = .XMLDocument.CreateElement("server")
                    _serverElement.InnerText = Path.Combine(Me.VersionField.Text.Replace("."c, "_"c), _cutFilePath)
                    _fileElement.AppendChild(_serverElement)

                    Dim _localElement As XmlElement = .XMLDocument.CreateElement("local")
                    _localElement.InnerText = _cutFilePath
                    _fileElement.AppendChild(_localElement)

                    _filesElement.AppendChild(_fileElement)
                Next _filePath

                ' このディレクトリ内のすべてのサブディレクトリを検索する (再帰)
                For Each _directoryPath As String In System.IO.Directory.GetDirectories(targetDirectoryPath)
                    Me.CreateXMLOfReleaseFilesConstruction(_directoryPath)
                Next _directoryPath

            End With
        End Sub

        Private Sub selectFolderButton_Click(sender As Object, e As EventArgs) Handles selectFolderButton.Click
            Dim _dialog = New CommonOpenFileDialog("フォルダ選択")
            _dialog.IsFolderPicker = True

            If _dialog.ShowDialog() = CommonFileDialogResult.Ok Then
                Me.TargetFolderField.Text = _dialog.FileName

            End If

        End Sub

        ''' <summary>
        ''' リリースファイル全てが保存されたフォルダをルートとし、
        ''' ルートフォルダ内にあるフォルダ、ファイルのフルパスを、ルートを起点とする相対パスに変換します。
        ''' </summary>
        ''' <param name="fullPath">フルパスで表したファイル名、フォルダ名</param>
        ''' <returns>ルートからの相対パス</returns>
        Private Function CutRootDiretoryPath(fullPath As String) As String
            If fullPath = Me._baseDirectory Then
                Return String.Empty
            Else
                Return fullPath.Substring(_baseDirectory.Length + 1)
            End If
        End Function

        Private Sub TargetFolderField_TextChanged(sender As Object, e As EventArgs) Handles TargetFolderField.TextChanged
            Me._baseDirectory = DirectCast(sender, TextBox).Text
        End Sub
    End Class
End Namespace