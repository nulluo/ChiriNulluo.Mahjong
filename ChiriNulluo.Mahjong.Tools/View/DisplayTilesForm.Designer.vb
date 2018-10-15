Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DisplayTilesForm
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
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.SuspendLayout()
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(40, 204)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(452, 77)
            Me.TextBox1.TabIndex = 0
            '
            'DisplayTilesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Green
            Me.ClientSize = New System.Drawing.Size(991, 293)
            Me.Controls.Add(Me.TextBox1)
            Me.Name = "DisplayTilesForm"
            Me.Text = "DisplayTilesForm"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TextBox1 As TextBox
    End Class
End Namespace