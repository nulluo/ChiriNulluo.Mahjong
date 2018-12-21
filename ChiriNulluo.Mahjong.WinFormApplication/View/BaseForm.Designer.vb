Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BaseForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm))
            Me.SuspendLayout()
            '
            'BaseForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.ChiriNulluo.Mahjong.WinFormApplication.My.MySettings.Default, "BaseFormLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Location = Global.ChiriNulluo.Mahjong.WinFormApplication.My.MySettings.Default.BaseFormLocation
            Me.Name = "BaseForm"
            Me.Text = "キュア☆ジャン"
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace