Imports System.Xml
Imports System.Text

Public Class SaveData

    ''' <summary>
    ''' シングルトン化のためのダミーコンストラクタ
    ''' </summary>
    Private Sub New()

    End Sub

    Private Const FileName As String = "SaveData.xml"
    Private Const TemplateFileName As String = "SaveDataTemplate.xml"
    Private Const TrueString As String = "TRUE"
    Private Const FalseString As String = "FALSE"


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
            Me.AppendDiffData()
        End If

    End Sub

    ''' <summary>
    ''' 新バージョンによって、セーブデータファイルに追加された項目を、SaveData.xmlに追加します。
    ''' </summary>
    Private Sub AppendDiffData()

        Dim _xmlDocumentTemplate As New XmlDocument()
        _xmlDocumentTemplate.Load(TemplateFileName)

        Dim _xmlDocumentReal As New XmlDocument()
        _xmlDocumentReal.Load(FileName)

        Dim _saveDataNodeReal = Me.GetNodes(_xmlDocumentReal, "saveData")(0)
        Dim _fileVersionNodeReal = Me.GetNodes(_xmlDocumentReal, "saveData/latestVersion")(0)

        Dim _fileVersionReal As String = _fileVersionNodeReal.InnerText
        For Each _saveTemplate As XmlNode In Me.GetNodes(_xmlDocumentTemplate, "saveData/saves/save")

            Dim _saveVersionTemplate = DirectCast(_saveTemplate, XmlElement).GetAttribute("version")

            If CompareVersionString(_saveVersionTemplate, _fileVersionReal) > 0 Then
                Dim _saveNodeImported = _xmlDocumentReal.ImportNode(_saveTemplate, True)
                _saveDataNodeReal.InsertBefore(_saveNodeImported, _fileVersionNodeReal)
            End If

        Next
        _fileVersionNodeReal.InnerText = Me.GetTemplateFileVersion

        _xmlDocumentReal.Save(FileName)
    End Sub

    Private Sub CreateNewSaveDataFile()
        System.IO.File.Copy(TemplateFileName, FileName)
    End Sub

    ''' <summary>
    ''' 存在しているセーブデータファイルのバージョンよりも、最新セーブデータファイルのバージョンが新しい場合はTrue,そうでなければFalseを返す。。
    ''' </summary>
    ''' <returns>存在しているセーブデータファイルのバージョンよりも、最新セーブデータファイルのバージョンが新しい場合はTrue,そうでなければFalse</returns>
    Private Function IsNewerVersionSaveDataReleased() As Boolean
        Dim _xmlDocument As New XmlDocument()
        _xmlDocument.Load(FileName)

        Dim _nodesList As XmlNodeList = Me.GetNodes(_xmlDocument, "saveData/latestVersion")

        Dim _node As XmlNode = _nodesList(0)

        Dim _saveDataVersion As String = _node.InnerText
        Dim _templateFileVersion As String = Me.GetTemplateFileVersion

        If CompareVersionString(_saveDataVersion, _templateFileVersion) < 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' <para>#.#.#.# (#は整数値)の形のバージョン文字列の大小を比較する。</para>
    ''' <para>versionString1が、versionString2 より小さい(古い)場合：-1</para>
    ''' <para>versionString1とversionString2が一致する場合：0 </para>
    ''' <para>versionString1が、versionString2 より大きい(新しい)場合：1</para>
    ''' <para>を返す。</para>
    ''' </summary>
    ''' <param name="versionString1">バージョン文字列1</param>
    ''' <param name="versionString2">バージョン文字列2</param>
    ''' <remarks>#.#.#(桁数が足りない),#.#.#.#.#(桁数が多すぎる)など、不正なバージョン形式の場合は正しく判定できない。</remarks>
    ''' <returns>
    ''' <para>versionString1が、versionString2 より小さい(古い)場合：-1</para>
    ''' <para>versionString1とversionString2が一致する場合：0 </para>
    ''' <para>versionString1が、versionString2 より大きい(新しい)場合：1</para>
    ''' </returns>
    Private Function CompareVersionString(versionString1 As String, versionString2 As String) As Integer

        Dim _versionString1Array As List(Of Integer) = versionString1.Split("."c).Select(Function(x) CInt(x)).ToList
        Dim _versionString2Array As List(Of Integer) = versionString2.Split("."c).Select(Function(x) CInt(x)).ToList

        For i As Integer = 0 To 3

            Dim _versionNumber1 As Integer = _versionString1Array(i)
            Dim _versionNumber2 As Integer = _versionString2Array(i)

            If _versionNumber1 < _versionNumber2 Then
                Return -1
            ElseIf _versionNumber1 > _versionNumber2 Then
                Return 1
            End If

        Next

        Return 0
    End Function


    ''' <summary>
    ''' 指定したXPathで特定される、ノードの集合を取得します。
    ''' </summary>
    ''' <param name="xmlDocument">XMLドキュメント</param>
    ''' <param name="xpath">ノードを特定するための XPath 式。</param>
    ''' <returns>XPathで特定される全てのノードを含む <see cref="XmlNodeList" /> 。見つからない場合は空の <see cref="XmlNodeList" /> を返します。</returns>
    Private Function GetNodes(xmlDocument As XmlDocument, xpath As String) As XmlNodeList

        Try
            Dim _nodes = xmlDocument.SelectNodes(xpath)
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
    ''' 現在の最新セーブデータファイルのバージョンを取得する。
    ''' </summary>
    ''' <returns></returns>
    Private Function GetTemplateFileVersion() As String

        Dim _xmlDocumentTemplate As New XmlDocument()
        _xmlDocumentTemplate.Load(TemplateFileName)
        Return Me.GetNodes(_xmlDocumentTemplate, "saveData/latestVersion")(0).InnerText

    End Function

    ''' <summary>
    ''' XPathに従って、最初に見つかったノードのInnerTextを <see cref="Boolean"/>型で取得する。
    ''' </summary>
    ''' <param name="xpath">ノードの位置を表すXPath 式。</param>
    ''' <param name="defaultValue">値が取得できない場合に返す値。</param>
    ''' <returns>XPathに従って、最初に見つかったノードのInnerTextの値。XPathが不正の場合は、<paramref name="defaultValue" /> を返す。</returns>
    ''' <exception cref="XmlFileNotLoadedException">XMLファイルが読込まれていません。</exception>
    Private Function GetNodeByBoolean(xmlDocument As XmlDocument, xpath As String, Optional defaultValue As Boolean = False) As Boolean

        Dim _xmlNodeList As XmlNodeList = Me.GetNodes(xmlDocument, xpath)

        If _xmlNodeList.Count = 0 Then
            Return defaultValue
        End If

        Dim _value = _xmlNodeList(0).InnerText
        If _value.ToUpperInvariant = "TRUE" Then
            Return True
        Else
            Return defaultValue
        End If
    End Function




End Class
