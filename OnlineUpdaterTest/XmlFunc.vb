Imports System.IO
Imports System.Xml
Namespace XMLFunc
    Public Class XmlFunctions
        Private xmldoc As XmlDocument
        Private nodelist As XmlNodeList

        Public Sub OpenXMLDoc(ByVal FileName As String)
            xmldoc = New XmlDocument()
            xmldoc.Load(FileName)
        End Sub

        Public Sub XMLSNode(ByVal NodeName As String)
            nodelist = xmldoc.SelectNodes(NodeName)
        End Sub

        Public Function GetNodeVal(ByVal Keyname As String) As String
            Dim tmpstr As String
            tmpstr = ""
            For Each nodeitem As XmlNode In nodelist
                tmpstr = nodeitem.Attributes.GetNamedItem(Keyname).Value
            Next
            Return tmpstr
        End Function

        Public Function GetFiles() As List(Of FileDetails)
            GetFiles = New List(Of FileDetails)
            XMLSNode("updates/file")
            For Each Fileitem As XmlNode In nodelist
                Dim ThisFile As New FileDetails
                ThisFile.File = Fileitem.Attributes.GetNamedItem("name").Value
                ThisFile.Server = Fileitem.ChildNodes.Item(0).InnerText
                ThisFile.Local = Fileitem.ChildNodes.Item(1).InnerText
                ThisFile.Update = Fileitem.ChildNodes.Item(2).InnerText
                GetFiles.Add(ThisFile)
            Next


        End Function

        Public Class FileDetails
            Private _File As String
            Private _Server As String
            Private _Local As String
            Private _Update As String

            Public Property File() As String
                Get
                    Return _File
                End Get
                Set(ByVal value As String)
                    _File = value
                End Set
            End Property

            Public Property Server() As String
                Get
                    Return _Server
                End Get
                Set(ByVal value As String)
                    _Server = value
                End Set
            End Property

            Public Property Local() As String
                Get
                    Return _Local
                End Get
                Set(ByVal value As String)
                    _Local = value
                End Set
            End Property

            Public Property Update() As String
                Get
                    Return _Update
                End Get
                Set(ByVal value As String)
                    _Update = value
                End Set
            End Property

        End Class

    End Class
End Namespace
