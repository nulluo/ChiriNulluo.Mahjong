Imports System.IO
Imports System.Xml

Namespace DataAccess
    Public Class XMLAccess

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

        End Class

End Namespace