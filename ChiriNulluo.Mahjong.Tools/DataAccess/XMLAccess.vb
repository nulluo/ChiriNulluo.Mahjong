Imports System.IO
Imports System.Xml

Namespace DataAccess
    Public Class XMLAccess

        Public XMLDocument As XmlDocument

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="xmlfilePath">読込むXMLファイルのパス</param>
        Public Sub New(xmlfilePath As String)
            XMLDocument = New XmlDocument()
            XMLDocument.Load(xmlfilePath)
        End Sub

        ''' <summary>
        ''' 指定したXPathに対して見つかった最初のノードのInnerTextの値を設定する。
        ''' </summary>
        ''' <param name="xpath"> XPath式。</param>
        ''' <param name="value">設定値。</param>
        Public Sub SetNodeText(xpath As String, value As String)

            ' 通常
            Dim _node = Me.XMLDocument.SelectSingleNode(xpath)
            _node.InnerText = value

        End Sub

        ''' <summary>
        ''' 指定したXPathに対して見つかった最初のノードの指定した属性に値を設定する。
        ''' </summary>
        ''' <param name="xpath"> XPath式。</param>
        ''' <param name="attributeName">属性名</param>
        ''' <param name="value">設定値。</param>
        Public Sub SetNodeAttributeValue(xpath As String, attributeName As String, value As String)

            ' 通常
            Dim _node = Me.XMLDocument.SelectSingleNode(xpath)
            _node.Attributes(attributeName).Value = value

        End Sub

        ''' <summary>
        ''' XPath式と一致するノードのリストを選択する。
        ''' </summary>
        ''' <param name="xpath"></param>
        Public Function GetNodes(ByVal xpath As String) As XmlNodeList
            Return XMLDocument.SelectNodes(xpath)
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

        Public Sub Save(fileName As String)
            Me.XMLDocument.Save(fileName)
        End Sub

    End Class

End Namespace