﻿Imports System.IO
Imports System.Xml
Namespace XMLFunc
    Public Class XmlFunctions
        Private xmldoc As XmlDocument
        Private nodelist As XmlNodeList

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
        ''' <param name="NodeName"></param>
        Public Sub XMLSNode(ByVal NodeName As String)
            nodelist = xmldoc.SelectNodes(NodeName)
        End Sub

        ''' <summary>
        ''' 現在選択しているNodeListに含まれるノードから、Keynameで指定した属性の値を取得する。
        ''' </summary>
        ''' <param name="Keyname"></param>
        ''' <returns></returns>
        Public Function GetNodeVal(ByVal Keyname As String) As String
            Dim tmpstr As String
            tmpstr = ""
            For Each nodeitem As XmlNode In nodelist
                tmpstr = nodeitem.Attributes.GetNamedItem(Keyname).Value
            Next
            Return tmpstr
        End Function

        ''' <summary>
        ''' アップデートログファイルからfile要素の情報をFileDetails型のリストで取得する。
        ''' </summary>
        ''' <returns>アップデートログファイルから取得したfile要素の情報</returns>
        Public Function GetFiles() As List(Of ReleasedFile)
            Dim _files = New List(Of ReleasedFile)


            XMLSNode("updates/file")
            For Each Fileitem As XmlNode In nodelist
                Dim ThisFile As New ReleasedFile
                ThisFile.Name = Fileitem.Attributes.GetNamedItem("name").Value
                ThisFile.ServerFilePath = Fileitem.ChildNodes.Item(0).InnerText
                ThisFile.LocalFilePath = Fileitem.ChildNodes.Item(1).InnerText
                _files.Add(ThisFile)
            Next
            Return _files
        End Function

    End Class
End Namespace
