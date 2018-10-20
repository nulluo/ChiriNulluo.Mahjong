Imports ChiriNulluo.Mahjong.Precure.Tiles
Imports ChiriNulluo.Mahjong.Core.Tiles

Namespace View
    Public Class SelectTilesForm

        Private Property PrecureXMLAccess As Precure.DataAccess.PrecureXMLAccess = Precure.DataAccess.PrecureXMLAccess.GetInstance

        Private Sub SelectTilesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            Dim precureList As List(Of PreCureCharacterTile) = Me.PrecureXMLAccess.GetCharacterDataFromXML(Nothing, Nothing, Nothing, Nothing, True)

            Dim query = precureList.OrderBy(Function(x) x.ID).Select(
                            Function(x) New With {.Value = x, .Display = x.ID & " : " & x.Name})

            With Me.PrecuresComboBox
                .DataSource = query.ToList
                .ValueMember = "Value"
                .DisplayMember = "Display"
            End With

            Me.ListBox1.DisplayMember = "Name"
        End Sub

        Private Sub AddTIleButton_Click(sender As Object, e As EventArgs) Handles AddTIleButton.Click
            Me.ListBox1.Items.Add(Me.PrecuresComboBox.SelectedValue)
        End Sub

        Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
            Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim _nextForm As New DisplayTilesForm(Me.ListBox1.Items.Cast(Of PreCureCharacterTile).ToList)
            _nextForm.Show()
            Me.Close()
        End Sub

        Private Sub SpecialTileField_CheckedChanged(sender As Object, e As EventArgs) Handles IncluedesSpecialTileField.CheckedChanged, NotIncluedesSpecialTileField.CheckedChanged

        End Sub



    End Class
End Namespace