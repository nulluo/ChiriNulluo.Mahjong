Imports ChiriNulluo.Mahjong.Precure.DataAccess

Namespace View
    'UNIMPLEMENTED: デバッグ用なのでこのクラスは後で消す
    Public Class CharacterIDTestForm

        Private Shared Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()

        Private Sub CharacterIDTestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim _xmlAccess As PrecureXMLAccess = PrecureXMLAccess.GetInstance()
            Dim tiles = _xmlAccess.GetCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing, True)

            tiles.ForEach(Sub(x) Logger.Info(x.ID))

            MessageBox.Show("finished")
        End Sub
    End Class
End Namespace