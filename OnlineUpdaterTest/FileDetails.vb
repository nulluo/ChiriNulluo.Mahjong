''' <summary>
''' アップデートで配信するファイル1個分の情報
''' </summary>
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