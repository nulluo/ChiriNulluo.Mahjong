Imports System.IO
Imports System.Xml
Public Class XmlReader
    Private xmldoc As XmlDocument

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="xmlfilePath">読込むXMLファイルのパス</param>
    Public Sub New(xmlfilePath As String)
        xmldoc = New XmlDocument()
        xmldoc.Load(xmlfilePath)
    End Sub

    ''' <summary>
    ''' XPath式と一致するノードのリストを選択する。
    ''' </summary>
    ''' <param name="xpath"></param>
    Public Function GetNodes(ByVal xpath As String) As XmlNodeList
        Return xmldoc.SelectNodes(xpath)
    End Function

    ''' <summary>
    ''' xpathで指定したNodeListに含まれるノードから、atributeNameで指定した属性の値を取得する。
    ''' </summary>
    ''' <param name="xpath">ノードを指定するXPath</param>
    ''' <param name="atributeName">属性名</param>
    ''' <returns>pathで指定したNodeListに含まれるノードから、atributeNameで指定した属性の値</returns>
    Public Function GetAttributeValue(xpath As String, ByVal atributeName As String) As String
        Dim tmpstr As String
        tmpstr = ""
        For Each nodeitem As XmlNode In Me.GetNodes(xpath)
            tmpstr = nodeitem.Attributes.GetNamedItem(atributeName).Value
        Next
        Return tmpstr
    End Function

    ''' <summary>
    ''' アップデートログファイルからリリースするフォルダ、ファイルの情報をReleasedFolder型のリストで取得する。
    ''' </summary>
    ''' <returns>アップデートログファイルから取得したリリースするフォルダ、ファイルの情報</returns>
    Public Function GetReleasedFolders() As List(Of ReleasedFolder)
        Dim _folders = New List(Of ReleasedFolder)

        For Each _folderNode As XmlNode In Me.GetNodes("updates/folders/folder")
            Dim _thisFolder As New ReleasedFolder
            _thisFolder.Path = _folderNode.Attributes.GetNamedItem("path").Value

            For Each _fileNode As XmlNode In _folderNode.SelectNodes("files/file")
                Dim _releasedFile As New ReleasedFile
                _releasedFile.Name = _fileNode.Attributes("name").Value
                _releasedFile.ServerFilePath = _fileNode.SelectSingleNode("server").InnerText
                _releasedFile.LocalFilePath = _fileNode.SelectSingleNode("local").InnerText

                _thisFolder.AddFile(_releasedFile)
            Next

            _folders.Add(_thisFolder)
        Next
        Return _folders
    End Function

End Class
