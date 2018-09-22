Imports System.Xml
Imports System.Text

Public Class SaveData

    ''' <summary>
    ''' シングルトン化のためのダミーコンストラクタ
    ''' </summary>
    Private Sub New()

    End Sub

    Private Const FileName As String = "SaveData.xml"
    Private Const TrueString As String = "TRUE"
    Private Const FalseString As String = "FALSE"

    Private Property XmlDocument As New XmlDocument

    Private Shared _instance As SaveData

    Public Shared Function GetInstance() As SaveData
        If _instance Is Nothing Then
            _instance = New SaveData()
        End If
        Return _instance
    End Function

    ''' <summary>
    ''' セーブデータファイルを初期化する。実行環境にセーブデータファイルが存在しなければ新規作成する。
    ''' </summary>
    Public Sub InitializeSaveDataFile()
        If Not System.IO.File.Exists(FileName) Then
            Me.CreateNewSaveDataFile()
        End If

        If Me.IsNewerVersionSaveDataReleased Then
            Debug.WriteLine("IsNewerVersionSaveDataReleased:True")
        Else
            Debug.WriteLine("IsNewerVersionSaveDataReleased:False")
        End If

    End Sub


    Private Sub CreateNewSaveDataFile()
        Dim _document As New XmlDocument()

        Dim _declaration As XmlDeclaration = _document.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
        _document.AppendChild(_declaration)

        Dim _root As XmlElement = _document.CreateElement("saveData")
        _document.AppendChild(_root)

        Dim _fileVersion As XmlElement = _document.CreateElement("fileVersion")
        _root.AppendChild(_fileVersion)
        _fileVersion.InnerText = Me.GetMyFileVersion


        Dim _versionAttribute As XmlAttribute = _document.CreateAttribute("version")
        Dim _data As XmlElement = _document.CreateElement("data")
        _data.Attributes.Append(_versionAttribute)
        _root.InsertAfter(_data, _fileVersion)

        _document.Save(FileName)

    End Sub

    ''' <summary>
    ''' 存在しているセーブデータファイルのバージョンよりも、バイナリのバージョンが新しい場合はTrue,そうでなければFalseを返す。。
    ''' </summary>
    ''' <returns>存在しているセーブデータファイルのバージョンよりも、バイナリのバージョンが新しい場合はTrue,そうでなければFalse</returns>
    Private Function IsNewerVersionSaveDataReleased() As Boolean

        XmlDocument.Load(FileName)
        Dim _saveDataVersion As String = Me.GetNodes("saveData/fileVersion")(0).InnerText
        Dim _fileVersion As String = Me.GetMyFileVersion

        Dim _saveDataVersionArray As List(Of Integer) = _saveDataVersion.Split("."c).Select(Function(x) CInt(x)).ToList
        Dim _fileVersionArray As List(Of Integer) = _fileVersion.Split("."c).Select(Function(x) CInt(x)).ToList

        For i As Integer = 0 To 3

            Dim _versionNumberSaveData As Integer = _saveDataVersionArray(i)
            Dim _versionNumberFileVersion As Integer = _fileVersionArray(i)

            If _versionNumberSaveData < _versionNumberFileVersion Then
                Return True
            ElseIf _versionNumberSaveData > _versionNumberFileVersion Then
                Return False
            End If

        Next

        Return False

    End Function

    ''' <summary>
    ''' 指定したXPathで特定される、ノードの集合を取得します。
    ''' </summary>
    ''' <param name="xpath">ノードを特定するための XPath 式。</param>
    ''' <returns>XPathで特定される全てのノードを含む <see cref="XmlNodeList" /> 。見つからない場合は空の <see cref="XmlNodeList" /> を返します。</returns>
    Private Function GetNodes(xpath As String) As XmlNodeList

        Try
            Dim _nodes = Me.XmlDocument.SelectNodes(xpath)
            If _nodes IsNot Nothing Then
                Return _nodes
            Else
                Return Nothing
            End If

        Catch ex As XmlException
            ' 不正なXPathは、見つからなかったものとして扱う
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' このexe自身のファイルバージョンを取得する。
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMyFileVersion() As String
        Return System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion
    End Function

    ''' <summary>
    ''' XPathに従って、最初に見つかったノードのInnerTextを <see cref="Boolean"/>型で取得する。
    ''' </summary>
    ''' <param name="xpath">ノードの位置を表すXPath 式。</param>
    ''' <param name="defaultValue">値が取得できない場合に返す値。</param>
    ''' <returns>XPathに従って、最初に見つかったノードのInnerTextの値。XPathが不正の場合は、<paramref name="defaultValue" /> を返す。</returns>
    ''' <exception cref="XmlFileNotLoadedException">XMLファイルが読込まれていません。</exception>
    Private Function GetNodeByBoolean(xpath As String, Optional defaultValue As Boolean = False) As Boolean
        Dim _xmlNode As XmlNodeList = Me.GetNodes(xpath)

        If _xmlNode.Count = 0 Then
            Return defaultValue
        End If

        Dim _value = Me.GetNodes(xpath)(0).InnerText
        If _value.ToUpperInvariant = "TRUE" Then
            Return True
        Else
            Return defaultValue
        End If
    End Function




End Class
