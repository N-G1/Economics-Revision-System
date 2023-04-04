Public Class frmSelect
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If AccountPoints < 100 Then
            btnMacro.Enabled = False
            'directs the user to the selected form
        End If
    End Sub

    Private Sub btnMacro_Click(sender As Object, e As EventArgs) Handles btnMacro.Click

    End Sub

    Private Sub btnMicro_Click(sender As Object, e As EventArgs) Handles btnMicro.Click
        frmMicroLevels.Show()
        Me.Close()
    End Sub
    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        MsgBox("Goodbye")
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub btnLeaderboard_Click(sender As Object, e As EventArgs) Handles btnLeaderboard.Click
        frmLeaderboard.Show()
    End Sub

    Private Sub btnSmart_Click(sender As Object, e As EventArgs) Handles btnSmart.Click
        frmSmartQuiz.Show()
    End Sub
End Class