Public NotInheritable Class FormTransition

    Private Shared _transiting As Boolean = False
    ''' <summary>
    ''' 画面遷移の最中である場合はTrue。そうでない場合はFalse。
    ''' </summary>
    ''' <returns>画面が閉じた時の理由判定(ユーザーが×ボタン等で閉じたのか、コードでCloseを呼んだのか)に用いるプロパティ。</returns>
    Public Shared Property Transiting As Boolean
        Get
            Return _transiting
        End Get
        Private Set(value As Boolean)
            _transiting = value
        End Set
    End Property

    ''' <summary>
    ''' 現在の画面を閉じて、次画面へ遷移する。MainFormが閉じてアプリ終了することがないように、次画面をMainFormに設定する。
    ''' </summary>
    ''' <param name="currentForm"></param>
    ''' <param name="nextForm"></param>
    Public Shared Sub Transit(currentForm As Form, nextForm As Form)
        FormTransition.Transiting = True
        My.Application.ApplicationContext.MainForm = nextForm
        currentForm.Close()
        nextForm.Show()
        FormTransition.Transiting = False
    End Sub

    ''' <summary>
    ''' ユーザーによって画面が閉じられる場合、ゲームが終了するが本当に閉じてよいか？と確認メッセージを出すてユーザーの意志を確認する。
    ''' <c>FormTransition.Transit</c>メソッドによって画面が閉じる場合、確認処理は実行されない。
    ''' </summary>
    ''' <param name="e">FormClosingイベントのデータ</param>
    ''' <remarks>FormClosingイベントのハンドラ内で使用する</remarks>
    Public Shared Sub ConfirmFormClosing(e As FormClosingEventArgs)
        If Not FormTransition.Transiting AndAlso e.CloseReason = CloseReason.UserClosing Then
            If MessageBox.Show(My.Resources.SystemScriptExitConfirmation, My.Resources.LabelGameTitle,
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
