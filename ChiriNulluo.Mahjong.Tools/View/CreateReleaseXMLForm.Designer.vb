Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CreateReleaseXMLForm
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
            Me.ExecuteButton = New System.Windows.Forms.Button()
            Me.VersionField = New System.Windows.Forms.MaskedTextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
            Me.TargetFolderField = New System.Windows.Forms.TextBox()
            Me.selectFolderButton = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.SuspendLayout()
            '
            'ExecuteButton
            '
            Me.ExecuteButton.Location = New System.Drawing.Point(369, 232)
            Me.ExecuteButton.Name = "ExecuteButton"
            Me.ExecuteButton.Size = New System.Drawing.Size(75, 23)
            Me.ExecuteButton.TabIndex = 0
            Me.ExecuteButton.Text = "作成"
            Me.ExecuteButton.UseVisualStyleBackColor = True
            '
            'VersionField
            '
            Me.VersionField.Location = New System.Drawing.Point(86, 86)
            Me.VersionField.Mask = "0.0.0.0"
            Me.VersionField.Name = "VersionField"
            Me.VersionField.Size = New System.Drawing.Size(100, 19)
            Me.VersionField.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(28, 73)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(42, 12)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "version"
            '
            'FolderBrowserDialog1
            '
            Me.FolderBrowserDialog1.Description = "リリースファイルが保存されいてるフォルダを指定してください。"
            '
            'TargetFolderField
            '
            Me.TargetFolderField.Location = New System.Drawing.Point(86, 160)
            Me.TargetFolderField.Name = "TargetFolderField"
            Me.TargetFolderField.Size = New System.Drawing.Size(282, 19)
            Me.TargetFolderField.TabIndex = 3
            '
            'selectFolderButton
            '
            Me.selectFolderButton.Location = New System.Drawing.Point(368, 157)
            Me.selectFolderButton.Name = "selectFolderButton"
            Me.selectFolderButton.Size = New System.Drawing.Size(75, 23)
            Me.selectFolderButton.TabIndex = 0
            Me.selectFolderButton.Text = "参照"
            Me.selectFolderButton.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(28, 142)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(179, 12)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "実行ファイルが保管されているフォルダ"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(28, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(416, 12)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "指定したフォルダ以下のサブフォルダおよびファイルをXMLのリリース情報定義に変換します"
            '
            'CreateReleaseXMLForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(582, 313)
            Me.Controls.Add(Me.TargetFolderField)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.selectFolderButton)
            Me.Controls.Add(Me.VersionField)
            Me.Controls.Add(Me.ExecuteButton)
            Me.Name = "CreateReleaseXMLForm"
            Me.Text = "CreateReleaseXMLForm"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents ExecuteButton As Button
        Friend WithEvents VersionField As MaskedTextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
        Friend WithEvents TargetFolderField As TextBox
        Friend WithEvents selectFolderButton As Button
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents SaveFileDialog1 As SaveFileDialog
    End Class
End Namespace