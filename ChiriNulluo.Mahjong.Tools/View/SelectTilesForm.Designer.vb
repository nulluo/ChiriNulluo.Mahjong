Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SelectTilesForm
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
            Me.ListBox1 = New System.Windows.Forms.ListBox()
            Me.PrecuresComboBox = New System.Windows.Forms.ComboBox()
            Me.AddTIleButton = New System.Windows.Forms.Button()
            Me.RemoveButton = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'ListBox1
            '
            Me.ListBox1.FormattingEnabled = True
            Me.ListBox1.ItemHeight = 12
            Me.ListBox1.Location = New System.Drawing.Point(12, 77)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(260, 148)
            Me.ListBox1.TabIndex = 0
            '
            'PrecuresComboBox
            '
            Me.PrecuresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PrecuresComboBox.FormattingEnabled = True
            Me.PrecuresComboBox.Location = New System.Drawing.Point(13, 13)
            Me.PrecuresComboBox.Name = "PrecuresComboBox"
            Me.PrecuresComboBox.Size = New System.Drawing.Size(259, 20)
            Me.PrecuresComboBox.TabIndex = 1
            '
            'AddTIleButton
            '
            Me.AddTIleButton.Location = New System.Drawing.Point(13, 39)
            Me.AddTIleButton.Name = "AddTIleButton"
            Me.AddTIleButton.Size = New System.Drawing.Size(75, 23)
            Me.AddTIleButton.TabIndex = 2
            Me.AddTIleButton.Text = "↓Add"
            Me.AddTIleButton.UseVisualStyleBackColor = True
            '
            'RemoveButton
            '
            Me.RemoveButton.Location = New System.Drawing.Point(169, 39)
            Me.RemoveButton.Name = "RemoveButton"
            Me.RemoveButton.Size = New System.Drawing.Size(103, 23)
            Me.RemoveButton.TabIndex = 2
            Me.RemoveButton.Text = "Remove┌→"
            Me.RemoveButton.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(12, 231)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 23)
            Me.Button1.TabIndex = 3
            Me.Button1.Text = "OK"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'SelectTilesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(298, 261)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.RemoveButton)
            Me.Controls.Add(Me.AddTIleButton)
            Me.Controls.Add(Me.PrecuresComboBox)
            Me.Controls.Add(Me.ListBox1)
            Me.Name = "SelectTilesForm"
            Me.Text = "並べて表示する牌を選んで"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents ListBox1 As ListBox
        Friend WithEvents PrecuresComboBox As ComboBox
        Friend WithEvents AddTIleButton As Button
        Friend WithEvents RemoveButton As Button
        Friend WithEvents Button1 As Button
    End Class
End Namespace