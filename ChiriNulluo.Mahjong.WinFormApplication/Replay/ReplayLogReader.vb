Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Namespace Replay
    Public NotInheritable Class ReplayLogReader

        Private Sub New()
        End Sub

        ''' <summary>
        ''' 指定したMatchIDに一致するリプレイログをReplayDataManagerに読み込む
        ''' </summary>
        ''' <param name="matchIDCondition">指定するMatchID</param>
        Public Shared Sub Read(matchIDCondition As String)
            Using parser As New TextFieldParser(IO.Path.Combine(My.Application.Info.DirectoryPath, "logs/ReplayLog.log"), Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")

                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False

                ' ファイルの終端までループ
                While Not parser.EndOfData
                    ' フィールドを読込
                    Dim row As String() = parser.ReadFields()
                    Dim _replayData As New ReplayData
                    With _replayData
                        If row(0) = matchIDCondition Then
                            .MatchID = row(0)
                            .LogNoInMatch = row(1)
                            .ProcessTypeID = row(2)
                            .ProcessID = row(3)
                            .Player = row(4)
                            .Remark = row(5)
                            .Parameters = New List(Of String)(row(6).Split(","c))
                            .JoinedParameters = row(6)
                            Replay.ReplayDataManager.AddData(_replayData)
                        End If
                    End With
                End While
            End Using
        End Sub

        ''' <summary>
        ''' ReplayLog.logに記載されているマッチIDを全て取得する（重複は排除）
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetMatchIDs() As List(Of String)
            Dim _returnValue As New List(Of String)
            Using parser As New TextFieldParser(IO.Path.Combine(My.Application.Info.DirectoryPath, "logs/ReplayLog.log"), Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")

                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False

                Dim _previousMatchID As String = String.Empty
                Dim _currentMatchID As String
                ' ファイルの終端までループ
                While Not parser.EndOfData
                    ' フィールドを読込
                    Dim row As String() = parser.ReadFields()
                    _currentMatchID = row(0)

                    If _previousMatchID <> _currentMatchID Then
                        _returnValue.Add(_currentMatchID)
                        _previousMatchID = _currentMatchID
                    End If
                End While
            End Using

            Return _returnValue
        End Function
    End Class
End Namespace
