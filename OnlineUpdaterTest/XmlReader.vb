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

    'UNIMPLEMENTED: XMLノードを選択してから
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
    ''' アップデートログファイルからfile要素の情報をFileDetails型のリストで取得する。
    ''' </summary>
    ''' <returns>アップデートログファイルから取得したfile要素の情報</returns>
    Public Function GetFiles() As List(Of ReleasedFile)
        Dim _files = New List(Of ReleasedFile)

        For Each Fileitem As XmlNode In Me.GetNodes("updates/file")
            Dim ThisFile As New ReleasedFile
            ThisFile.Name = Fileitem.Attributes.GetNamedItem("name").Value
            ThisFile.ServerFilePath = Fileitem.ChildNodes.Item(0).InnerText
            ThisFile.LocalFilePath = Fileitem.ChildNodes.Item(1).InnerText
            _files.Add(ThisFile)
        Next
        Return _files
    End Function

End Class
