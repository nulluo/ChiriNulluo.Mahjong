Imports System.Reflection
Imports ChiriNulluo.Mahjong.OnlineUpdater

Namespace OnlineUpdater

    <TestFixture>
    Public Class AutoUpdateTest

        <TestCase(+1, "0.0.0.0", "0.0.0.1")>
        <TestCase(+0, "0.0.0.1", "0.0.0.1")>
        <TestCase(-1, "0.0.0.1", "0.0.0.0")>
        <TestCase(+1, "0.0.0.3", "0.1.0.0")>
        <TestCase(-1, "0.0.1.0", "0.0.0.2")>
        <TestCase(-1, "1.0.0.0", "0.1.0.0")>
        <TestCase(-1, "0.0.0.10", "0.0.0.2")>
        <TestCase(+1, "0.0.3.0", "0.0.20.0")>
        Public Sub TestCompareVersion(expectedValue As Integer, version0 As String, version1 As String)
            Dim _returnValue As Integer = VersionComparer.Compare(version0, version1)
            Assert.AreEqual(expectedValue, _returnValue)
        End Sub

        <TestCase(True, "0.0.0.0", "0.0.0.1")>
        <TestCase(False, "0.0.0.1", "0.0.0.1")>
        <TestCase(False, "0.0.0.1", "0.0.0.0")>
        <TestCase(True, "0.0.0.3", "0.1.0.0")>
        <TestCase(False, "0.0.1.0", "0.0.0.2")>
        <TestCase(False, "1.0.0.0", "0.1.0.0")>
        <TestCase(False, "0.0.0.10", "0.0.0.2")>
        <TestCase(True, "0.0.3.0", "0.0.20.0")>
        Public Sub LessThanTest(expectedValue As Boolean, version0 As String, version1 As String)
            Assert.AreEqual(expectedValue, version0.LessThan(version1))
        End Sub

    End Class

End Namespace