Namespace Sounds
    Public Class SoundManager

        Public Shared Property PlaysBGM As Boolean
            Get
                Return My.Settings.PlaysBGM
            End Get
            Set(value As Boolean)
                My.Settings.PlaysBGM = value
            End Set
        End Property


        Public Shared Property PlaysSE As Boolean
            Get
                Return My.Settings.PlaysSE
            End Get
            Set(value As Boolean)
                My.Settings.PlaysSE = value
            End Set
        End Property
    End Class

End Namespace
