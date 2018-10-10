Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Form1
        Inherits System.Windows.Forms.Form

        'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.OpenCreateReleaseXMLButton = New System.Windows.Forms.Button()
            Me.OpenSelectTilesButton = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'OpenCreateReleaseXMLButton
            '
            Me.OpenCreateReleaseXMLButton.Location = New System.Drawing.Point(69, 40)
            Me.OpenCreateReleaseXMLButton.Name = "OpenCreateReleaseXMLButton"
            Me.OpenCreateReleaseXMLButton.Size = New System.Drawing.Size(125, 34)
            Me.OpenCreateReleaseXMLButton.TabIndex = 0
            Me.OpenCreateReleaseXMLButton.Text = "CreateReleaseXML"
            Me.OpenCreateReleaseXMLButton.UseVisualStyleBackColor = True
            '
            'OpenSelectTilesButton
            '
            Me.OpenSelectTilesButton.Location = New System.Drawing.Point(69, 95)
            Me.OpenSelectTilesButton.Name = "OpenSelectTilesButton"
            Me.OpenSelectTilesButton.Size = New System.Drawing.Size(125, 35)
            Me.OpenSelectTilesButton.TabIndex = 1
            Me.OpenSelectTilesButton.Text = "DisplayTilesButton"
            Me.OpenSelectTilesButton.UseVisualStyleBackColor = True
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Controls.Add(Me.OpenSelectTilesButton)
            Me.Controls.Add(Me.OpenCreateReleaseXMLButton)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents OpenCreateReleaseXMLButton As Button
        Friend WithEvents OpenSelectTilesButton As Button
    End Class
End Namespace