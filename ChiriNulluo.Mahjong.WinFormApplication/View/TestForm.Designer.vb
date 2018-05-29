<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MessageWindowFormButton = New System.Windows.Forms.Button()
        Me.openTileSelectWindowFormButton = New System.Windows.Forms.Button()
        Me.openGameTasteWindowTestForm1Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MessageWindowFormButton
        '
        Me.MessageWindowFormButton.Location = New System.Drawing.Point(13, 13)
        Me.MessageWindowFormButton.Name = "MessageWindowFormButton"
        Me.MessageWindowFormButton.Size = New System.Drawing.Size(229, 52)
        Me.MessageWindowFormButton.TabIndex = 0
        Me.MessageWindowFormButton.Text = "MessageWindowForm"
        Me.MessageWindowFormButton.UseVisualStyleBackColor = True
        '
        'openTileSelectWindowFormButton
        '
        Me.openTileSelectWindowFormButton.Location = New System.Drawing.Point(13, 71)
        Me.openTileSelectWindowFormButton.Name = "openTileSelectWindowFormButton"
        Me.openTileSelectWindowFormButton.Size = New System.Drawing.Size(229, 63)
        Me.openTileSelectWindowFormButton.TabIndex = 1
        Me.openTileSelectWindowFormButton.Text = "TileSelectWindowForm"
        Me.openTileSelectWindowFormButton.UseVisualStyleBackColor = True
        '
        'openGameTasteWindowTestForm1Button
        '
        Me.openGameTasteWindowTestForm1Button.Location = New System.Drawing.Point(13, 141)
        Me.openGameTasteWindowTestForm1Button.Name = "openGameTasteWindowTestForm1Button"
        Me.openGameTasteWindowTestForm1Button.Size = New System.Drawing.Size(229, 60)
        Me.openGameTasteWindowTestForm1Button.TabIndex = 2
        Me.openGameTasteWindowTestForm1Button.Text = "GameTasteWindowTestForm1"
        Me.openGameTasteWindowTestForm1Button.UseVisualStyleBackColor = True
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.openGameTasteWindowTestForm1Button)
        Me.Controls.Add(Me.openTileSelectWindowFormButton)
        Me.Controls.Add(Me.MessageWindowFormButton)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MessageWindowFormButton As Button
    Friend WithEvents openTileSelectWindowFormButton As Button
    Friend WithEvents openGameTasteWindowTestForm1Button As Button
End Class
