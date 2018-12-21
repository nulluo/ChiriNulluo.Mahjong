Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SelectReplayDataForm
        Inherits BaseForm

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
            Me.ReplayDataField = New System.Windows.Forms.ListBox()
            Me.OKButton = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'ReplayDataField
            '
            Me.ReplayDataField.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ReplayDataField.FormattingEnabled = True
            Me.ReplayDataField.ItemHeight = 12
            Me.ReplayDataField.Location = New System.Drawing.Point(12, 48)
            Me.ReplayDataField.Name = "ReplayDataField"
            Me.ReplayDataField.Size = New System.Drawing.Size(229, 196)
            Me.ReplayDataField.TabIndex = 0
            '
            'OKButton
            '
            Me.OKButton.Location = New System.Drawing.Point(261, 205)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New System.Drawing.Size(87, 35)
            Me.OKButton.TabIndex = 1
            Me.OKButton.Text = "OK"
            Me.OKButton.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(13, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(238, 12)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "再生するリプレイログを選択してOKを押してください"
            '
            'SelectReplayDataForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(374, 252)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.OKButton)
            Me.Controls.Add(Me.ReplayDataField)
            Me.Name = "SelectReplayDataForm"
            Me.Text = "SelectReplayDataForm"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents ReplayDataField As ListBox
        Friend WithEvents OKButton As Button
        Friend WithEvents Label1 As Label
    End Class

End Namespace