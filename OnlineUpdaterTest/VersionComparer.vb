Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Public Module VersionComparer

    ''' <summary>
    ''' バイナリのバージョン番号を比較する。
    ''' </summary>
    ''' <param name="version0">バージョン番号0(0.0.0.0の形式)</param>
    ''' <param name="version1">バージョン番号1(0.0.0.0の形式)</param>
    ''' <returns>バージョン番号0がバージョン番号1と比較して、小さいときは-1、等しいときは0、大きいときは+1を返す。</returns>
    Public Function Compare(version0 As String, version1 As String) As Integer
        If Not version0.Contains(".") Then
            If Val(version0) < Val(version1) Then
                Return 1
            ElseIf Val(version1) < Val(version0) Then
                Return -1
            Else
                Return 0
            End If
        End If

        Dim _upVersion0, _upVersion1 As String
        Dim _regex As New Regex("(.+?)\.(.*)")

        _upVersion0 = _regex.Replace(version0, ”$1")
        _upVersion1 = _regex.Replace(version1, ”$1")

        Dim _topCompare = Compare(_upVersion0, _upVersion1)
        If _topCompare <> 0 Then
            '最上位のバージョン番号で比較結果が決まればその結果を返す。
            Return _topCompare
        Else
            '最上位のバージョン番号で比較結果が一致している場合は下位バージョン番号で比較する。

            Dim _lowVersion0, _lowVersion1 As String
            _regex = New Regex(".+?\.(.*)")
            _lowVersion0 = _regex.Replace(version0, "$1")
            _lowVersion1 = _regex.Replace(version1, "$1")

            Return Compare(_lowVersion0, _lowVersion1)
        End If

    End Function

    ''' <summary>
    ''' バイナリのバージョン番号を比較し1番目のバージョン番号が2番目のバージョン番号よりも小さいかどうか判定する。
    ''' </summary>
    ''' <param name="version0">バージョン番号0(0.0.0.0の形式)</param>
    ''' <param name="version1">バージョン番号1(0.0.0.0の形式)</param>
    ''' <returs>バージョン番号0よりバージョン番号1が大きい場合はTrue,そうでない場合はFalse。</returs>
    <Extension()>
    Public Function LessThan(version0 As String, version1 As String) As Boolean
        Return Compare(version0, version1) = 1
    End Function
End Module
