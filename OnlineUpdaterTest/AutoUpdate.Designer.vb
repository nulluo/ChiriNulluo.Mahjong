<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoUpdate
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
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.RetryButton = New System.Windows.Forms.Button()
        Me.GBUpdate = New System.Windows.Forms.GroupBox()
        Me.GroupBoxMessage = New System.Windows.Forms.GroupBox()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.WBData = New System.Windows.Forms.WebBrowser()
        Me.GBUpdate.SuspendLayout()
        Me.GroupBoxMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'DoneButton
        '
        Me.DoneButton.Location = New System.Drawing.Point(390, 114)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(75, 21)
        Me.DoneButton.TabIndex = 11
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(471, 115)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 21)
        Me.CancelButton.TabIndex = 9
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'RetryButton
        '
        Me.RetryButton.Location = New System.Drawing.Point(18, 115)
        Me.RetryButton.Name = "RetryButton"
        Me.RetryButton.Size = New System.Drawing.Size(75, 21)
        Me.RetryButton.TabIndex = 8
        Me.RetryButton.Text = "Retry"
        Me.RetryButton.UseVisualStyleBackColor = True
        '
        'GBUpdate
        '
        Me.GBUpdate.Controls.Add(Me.GroupBoxMessage)
        Me.GBUpdate.Controls.Add(Me.WBData)
        Me.GBUpdate.Location = New System.Drawing.Point(12, 12)
        Me.GBUpdate.Name = "GBUpdate"
        Me.GBUpdate.Size = New System.Drawing.Size(534, 97)
        Me.GBUpdate.TabIndex = 10
        Me.GBUpdate.TabStop = False
        Me.GBUpdate.Text = "Updater In Progress"
        '
        'GroupBoxMessage
        '
        Me.GroupBoxMessage.Controls.Add(Me.LabelMessage)
        Me.GroupBoxMessage.Location = New System.Drawing.Point(6, 12)
        Me.GroupBoxMessage.Name = "GroupBoxMessage"
        Me.GroupBoxMessage.Size = New System.Drawing.Size(522, 53)
        Me.GroupBoxMessage.TabIndex = 5
        Me.GroupBoxMessage.TabStop = False
        '
        'LabelMessage
        '
        Me.LabelMessage.AutoSize = True
        Me.LabelMessage.Location = New System.Drawing.Point(6, 6)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(38, 12)
        Me.LabelMessage.TabIndex = 3
        Me.LabelMessage.Text = "Label1"
        '
        'WBData
        '
        Me.WBData.Location = New System.Drawing.Point(6, 64)
        Me.WBData.MinimumSize = New System.Drawing.Size(20, 18)
        Me.WBData.Name = "WBData"
        Me.WBData.Size = New System.Drawing.Size(522, 18)
        Me.WBData.TabIndex = 4
        Me.WBData.Visible = False
        '
        'AutoUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 141)
        Me.Controls.Add(Me.DoneButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.RetryButton)
        Me.Controls.Add(Me.GBUpdate)
        Me.Name = "AutoUpdate"
        Me.Text = "AutoUpdate"
        Me.GBUpdate.ResumeLayout(False)
        Me.GroupBoxMessage.ResumeLayout(False)
        Me.GroupBoxMessage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DoneButton As Button
    Friend WithEvents CancelButton As Button
    Friend WithEvents RetryButton As Button
    Friend WithEvents GBUpdate As GroupBox
    Friend WithEvents GroupBoxMessage As GroupBox
    Friend WithEvents LabelMessage As Label
    Friend WithEvents WBData As WebBrowser
End Class
