Imports System.Net.Http

''' <summary>
''' HttpClientを静的メンバとして使いまわす。
''' </summary>
Public NotInheritable Class HttpClientFactory

    ''' <summary>
    ''' 静的メンバしか含まれないクラスのため、コンストラクタを隠蔽
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' HttpClientの取得
    ''' </summary>
    ''' <returns>HttpClient</returns>
    Public Shared ReadOnly Property Client As New HttpClient()

End Class
