Imports System.Xml
Imports System.Xml.XPath
Imports System.IO
Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Yaku
Imports ChiriNulluo.Mahjong.Precure.Suits

Namespace DataAccess
    Public NotInheritable Class PrecureXMLAccess

        Private Property XmlDocument As XmlDocument
        'シングルトン　インスタンス
        Private Shared _instance As PrecureXMLAccess
        Private _xmlFilePath As String

        Public Shared Function GetInstance(Optional xmlFilePath As String = "") As PrecureXMLAccess

            'XMLファイルパスが指定されない場合は、既定の場所から探す
            If xmlFilePath = String.Empty Then
                xmlFilePath = Path.Combine(My.Application.Info.DirectoryPath, "PreJongConfig.xml")
            End If

            'シングルトンインスタンスが未生成の場合は新規作成する。
            'インスタンスが作成済みであっても、XMLファイルのパスが変更された場合には、ファイル読み込み先の切替のために作成し直す
            If _instance Is Nothing OrElse xmlFilePath <> _instance._xmlFilePath Then
                _instance = New PrecureXMLAccess(xmlFilePath)
            End If
            Return _instance
        End Function


        Private Sub New(xmlFilePath As String)
            Me._xmlFilePath = xmlFilePath
            Me.XmlDocument = New XmlDocument()
            Me.XmlDocument.Load(xmlFilePath)
        End Sub

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

#Region "牌取得メソッド"

        ''' <summary>
        ''' 全キャラクター牌情報(正式プリキュア牌、特殊キャラ牌両方を含む)から条件に一致する牌情報を取得し、Listに追加するメソッドを定義します。
        ''' </summary>
        Public Sub FillCharacterDataFromXML(characterList As List(Of PreCureCharacterTile),
                                           seriesID As String, number As String, name As String, cureName As String, Optional includesSpecialCharacter As Boolean = False)

            Me.GetCharacterDataFromXML(seriesID, number, name, cureName, includesSpecialCharacter).ForEach(Sub(x) characterList.Add(x))
        End Sub

        ''' <summary>
        ''' 全キャラクター牌情報(正式プリキュア牌、特殊キャラ牌両方を含む)から条件に一致する牌を取得する メソッドを定義します。
        ''' </summary>
        ''' <returns>取得した <see cref="DataTable"/> 。</returns>
        Public Function GetCharacterDataFromXML(seriesID As String, number As String, name As String, cureName As String, Optional includesSpecialCharacter As Boolean = False) As List(Of PreCureCharacterTile)
            Dim _precureList As New List(Of PreCureCharacterTile)

            Me.FillRegularPrecureDataFromXML(_precureList, seriesID, number, name, cureName)

            If includesSpecialCharacter Then
                Me.FillSpecialCharacterDataFromXML(_precureList, seriesID, number, name, cureName)
            End If

            Return _precureList
        End Function


        ''' <summary>
        ''' 条件に一致する正式プリキュア牌情報を全て取得し、Listに追加するメソッドを定義します。
        ''' </summary>
        ''' <param name="seriesID"></param>
        ''' <param name="number"></param>
        ''' <param name="name"></param>
        Public Sub FillRegularPrecureDataFromXML(tileList As List(Of PreCureCharacterTile),
                           seriesID As String, number As String, name As String, cureName As String)
            Me.GetRegularPrecureDataFromXML(seriesID, number, name, cureName).ForEach(Sub(x) tileList.Add(x))
        End Sub

        ''' <summary>
        ''' 条件に一致する正式プリキュア牌情報を全て取得する メソッドを定義します。
        ''' </summary>
        ''' <param name="seriesID"></param>
        ''' <param name="number"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function GetRegularPrecureDataFromXML(seriesID As String, number As String, name As String, cureName As String) As List(Of PreCureCharacterTile)
            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/Precures/Precure")
            Dim _precureList As New List(Of PreCureCharacterTile)

            For Each _node As XmlNode In _nodesList

                'UNIMPLEMENTED：↓この機能いるか？
                '引数で値が指定された場合は、その値と一致するデータのみを検索する。

                Dim _seriesIDText As String = _node.SelectSingleNode("TileSuitID").InnerText
                If Not seriesID Is Nothing AndAlso seriesID <> _seriesIDText Then
                    Continue For
                End If

                Dim _numberText As String = _node.SelectSingleNode("Number").InnerText
                If Not number Is Nothing AndAlso number <> _numberText Then
                    Continue For
                End If

                Dim _nameText As String = _node.SelectSingleNode("Name").InnerText
                If Not name Is Nothing AndAlso name <> _nameText Then
                    Continue For
                End If

                Dim _cureNameText As String = _node.SelectSingleNode("CureName").InnerText
                If Not cureName Is Nothing AndAlso cureName <> _cureNameText Then
                    Continue For
                End If

                _precureList.Add(New PreCureCharacterTile(_seriesIDText, _numberText, _nameText, _cureNameText))

            Next

            Return _precureList
        End Function

        ''' <summary>
        ''' 条件に一致する特殊キャラ牌情報を全て取得し、Listに追加するメソッドを定義します。
        ''' </summary>
        Public Sub FillSpecialCharacterDataFromXML(tileList As List(Of PreCureCharacterTile), seriesID As String, number As String, name As String, cureName As String)
            Me.GetSpecialCharacterDataFromXML(seriesID, number, name, cureName).ForEach(Sub(x) tileList.Add(x))
        End Sub
        ''' <summary>
        ''' 条件に一致する特殊キャラ牌情報を全て取得する メソッドを定義します。
        ''' </summary>
        ''' <returns>取得した <see cref="DataTable"/> 。</returns>
        Public Function GetSpecialCharacterDataFromXML(seriesID As String, number As String, name As String, cureName As String) As List(Of PreCureCharacterTile)


            '特殊キャラはプリキュア名を持たないので、cureNameが指定されている場合、検索せずに空のリストを返す。
            Dim _characterList As New List(Of PreCureCharacterTile)
            If Not String.IsNullOrEmpty(cureName) Then
                Return _characterList
            End If

            Dim _nodesList As XmlNodeList
            _nodesList = Me.GetNodes("PreJongSettings/SpecialCharacters/SpecialCharacter")

            For Each _node As XmlNode In _nodesList

                'UNIMPLEMENTED：↓この機能いるか？
                '引数で値が指定された場合は、その値と一致するデータのみを検索する。

                Dim _seriesIDText As String = _node.SelectSingleNode("TileSuitID").InnerText
                If Not seriesID Is Nothing AndAlso seriesID <> _seriesIDText Then
                    Continue For
                End If

                Dim _numberText As String = _node.SelectSingleNode("Number").InnerText
                If Not number Is Nothing AndAlso number <> _numberText Then
                    Continue For
                End If

                Dim _nameText As String = _node.SelectSingleNode("Name").InnerText
                If Not name Is Nothing AndAlso name <> _nameText Then
                    Continue For
                End If

                _characterList.Add(New PreCureCharacterTile(_seriesIDText, _numberText, _nameText, Nothing))

            Next

            Return _characterList
        End Function

#End Region

        ''' <summary>
        ''' プリキュア役から、手牌依存型役のデータを全て取得する
        ''' </summary>
        ''' <returns>取得した役の <see cref="List"/> 。</returns>
        Public Function GetYakuDataFromXML() As List(Of Core.Yaku.Yaku)

            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/Yakus/Yaku")
            Dim _yakuList As New List(Of Core.Yaku.Yaku)

            For Each _node As XmlNode In _nodesList
                Dim _name As String = _node.SelectSingleNode("Name").InnerText
                Dim _type As Integer = Integer.Parse(_node.SelectSingleNode("Type").InnerText)
                Dim _point As Integer = Integer.Parse(_node.SelectSingleNode("Point").InnerText)
                Dim _idsNodeList As XmlNodeList = _node.SelectNodes("TileSet/ID")
                Dim _tileSet As New List(Of String)
                For Each _idTag As XmlNode In _idsNodeList
                    _tileSet.Add(_idTag.InnerText)
                Next

                _yakuList.Add(New Core.Yaku.Yaku(_name, DirectCast(_type, YakuType), _point, _tileSet))
            Next

            Return _yakuList
        End Function

        ''' <summary>
        ''' プリキュア役のうち、手牌以外要素依存役のデータを全て取得する
        ''' </summary>
        ''' <returns></returns>
        Public Function GetIrregularYakuDataFromXML() As List(Of Core.Yaku.Yaku)
            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/Yakus/DependingOnNonHandConditionYaku")
            Dim _yakuList As New List(Of Core.Yaku.Yaku)

            For Each _node As XmlNode In _nodesList
                Dim _name As String = _node.SelectSingleNode("Name").InnerText
                Dim _type As Integer = Integer.Parse(_node.SelectSingleNode("Type").InnerText)
                Dim _point As Integer = Integer.Parse(_node.SelectSingleNode("Point").InnerText)
                'Dim _idsNodeList As XmlNodeList = _node.SelectNodes("TileSet/ID")
                'Dim _tileSet As New List(Of String)
                'For Each _idTag As XmlNode In _idsNodeList
                '    _tileSet.Add(_idTag.InnerText)
                'Next

                _yakuList.Add(New Core.Yaku.Yaku(_name, DirectCast(_type, YakuType), _point, Nothing))
            Next

            Return _yakuList
        End Function

        ''' <summary>
        ''' プリキュア役のうち、ボーナス牌役のデータを取得する
        ''' </summary>
        ''' <returns></returns>
        Public Function GetBonusYakuDataFromXML() As Core.Yaku.Yaku
            'UNIMPLEMENTED: XPATHでもっとかんたんに書けそうなきがする・・・
            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/Yakus/Yaku")
            Dim _yakuList As New List(Of Core.Yaku.Yaku)

            For Each _node As XmlNode In _nodesList
                Dim _name As String = _node.SelectSingleNode("Name").InnerText

                'UNIMPLEMENTED: [ボーナス牌」文字列のリソース化
                If _name = "ボーナス牌" Then
                    Dim _type As Integer = Integer.Parse(_node.SelectSingleNode("Type").InnerText)
                    Dim _point As Integer = Integer.Parse(_node.SelectSingleNode("Point").InnerText)
                    Dim _idsNodeList As XmlNodeList = _node.SelectNodes("TileSet/ID")
                    Dim _tileSet As New List(Of String)
                    For Each _idTag As XmlNode In _idsNodeList
                        _tileSet.Add(_idTag.InnerText)
                    Next

                    Return New Core.Yaku.Yaku(_name, DirectCast(_type, YakuType), _point, _tileSet)
                End If

            Next

            Return Nothing
        End Function



        ''' <summary>
        ''' 作品IDの最大数を取得する。
        ''' </summary>
        ''' <returns></returns>
        Public Function GetTileSuitsCount() As Integer
            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/TileSuits/TileSuit")
            Return _nodesList.Count
        End Function


        ''' <summary>
        ''' 指定したIDの作品情報を取得する。指定した作品IDが存在しない場合はNothingを返す。
        ''' </summary>
        ''' <param name="suitID">対象の作品ID</param>
        ''' <returns>作品情報(suit)オブジェクト。指定した作品IDが存在しない場合はNothingを返す。</returns>
        Public Function GetTileSuit(suitID As String) As PrecureSuit
            Dim _suit As New PrecureSuit
            Dim _nodesList As XmlNodeList = Me.GetNodes("PreJongSettings/TileSuits/TileSuit")
            For Each _node As XmlNode In _nodesList
                With _node
                    If .SelectSingleNode("TileSuitID").InnerText = suitID Then
                        _suit.ID = suitID
                        _suit.Name = .SelectSingleNode("TileSuitName").InnerText
                        _suit.TotalTilesCount = CInt(.SelectSingleNode("TotalTilesCount").InnerText)
                        Return _suit
                    End If
                End With
            Next

            Return Nothing
        End Function


    End Class
End Namespace