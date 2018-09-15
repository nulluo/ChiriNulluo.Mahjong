Namespace View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RuleForm
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.returnButton = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 18.0!)
            Me.Label1.Location = New System.Drawing.Point(2, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(220, 24)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "ルール説明(簡易版)"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!)
            Me.Label2.Location = New System.Drawing.Point(49, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(506, 48)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "・ツモだけ（自分で引いた牌だけ）で上がると1000点もらえます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "・リーチをして上がると1000点もらえます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "・その他の役は後述の役一覧を参照してください。" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "・レギュラープリキュア以外のキャラはボーナス牌として毎局ランダムに6種だけ出現します"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!)
            Me.Label3.Location = New System.Drawing.Point(49, 141)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(545, 36)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "・フリテン・カンはありません" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "・ピンフとかイーペーコーといった普通の麻雀の役はありません。ここに書かれている役が全てです" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "・天和、地和、人和、嶺上開花、ドラは" &
    "ありません"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75!, System.Drawing.FontStyle.Bold)
            Me.LinkLabel1.Location = New System.Drawing.Point(353, 18)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(340, 21)
            Me.LinkLabel1.TabIndex = 2
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "もっと詳しく知りたい人はこちら"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 18.0!)
            Me.Label4.Location = New System.Drawing.Point(2, 108)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(322, 24)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "麻雀を知ってる人向けの補足"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 18.0!)
            Me.Label5.Location = New System.Drawing.Point(9, 216)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(178, 24)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "★★役一覧★★"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.Bisque
            Me.GroupBox1.Controls.Add(Me.returnButton)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.LinkLabel1)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(707, 196)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            '
            'returnButton
            '
            Me.returnButton.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.0!)
            Me.returnButton.Location = New System.Drawing.Point(538, 104)
            Me.returnButton.Name = "returnButton"
            Me.returnButton.Size = New System.Drawing.Size(136, 42)
            Me.returnButton.TabIndex = 3
            Me.returnButton.Text = "ゲームに戻る"
            Me.returnButton.UseVisualStyleBackColor = True
            '
            'RuleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(726, 552)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Label5)
            Me.Name = "RuleForm"
            Me.Text = "ルール説明"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents LinkLabel1 As LinkLabel
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents returnButton As Button
    End Class
End Namespace