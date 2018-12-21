Namespace View

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class HandSelectForm
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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.comInitialHandField = New System.Windows.Forms.ComboBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.humanInitialHandField = New System.Windows.Forms.ComboBox()
            Me.okButton = New System.Windows.Forms.Button()
            Me.cancelButton = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.comInitialHandField)
            Me.GroupBox1.Location = New System.Drawing.Point(26, 81)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(295, 67)
            Me.GroupBox1.TabIndex = 15
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "COMの配牌"
            '
            'comInitialHandField
            '
            Me.comInitialHandField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.comInitialHandField.FormattingEnabled = True
            Me.comInitialHandField.Items.AddRange(New Object() {"テンパイ", "イーシャンテン"})
            Me.comInitialHandField.Location = New System.Drawing.Point(6, 28)
            Me.comInitialHandField.Name = "comInitialHandField"
            Me.comInitialHandField.Size = New System.Drawing.Size(198, 20)
            Me.comInitialHandField.TabIndex = 15
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.humanInitialHandField)
            Me.GroupBox2.Location = New System.Drawing.Point(26, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(295, 63)
            Me.GroupBox2.TabIndex = 16
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "プレイヤー配牌"
            '
            'humanInitialHandField
            '
            Me.humanInitialHandField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.humanInitialHandField.FormattingEnabled = True
            Me.humanInitialHandField.Items.AddRange(New Object() {"テンパイ", "イーシャンテン"})
            Me.humanInitialHandField.Location = New System.Drawing.Point(6, 27)
            Me.humanInitialHandField.Name = "humanInitialHandField"
            Me.humanInitialHandField.Size = New System.Drawing.Size(198, 20)
            Me.humanInitialHandField.TabIndex = 14
            '
            'okButton
            '
            Me.okButton.Location = New System.Drawing.Point(51, 181)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(75, 23)
            Me.okButton.TabIndex = 17
            Me.okButton.Text = "OK"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'cancelButton
            '
            Me.cancelButton.Location = New System.Drawing.Point(206, 181)
            Me.cancelButton.Name = "cancelButton"
            Me.cancelButton.Size = New System.Drawing.Size(75, 23)
            Me.cancelButton.TabIndex = 17
            Me.cancelButton.Text = "Cancel"
            Me.cancelButton.UseVisualStyleBackColor = True
            '
            'HandSelectForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(333, 216)
            Me.Controls.Add(Me.cancelButton)
            Me.Controls.Add(Me.okButton)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "HandSelectForm"
            Me.Text = "HandSelectForm"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents comInitialHandField As ComboBox
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents humanInitialHandField As ComboBox
        Friend WithEvents okButton As Button
        Friend WithEvents cancelButton As Button
    End Class

End Namespace