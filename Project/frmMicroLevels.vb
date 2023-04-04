Public Class frmMicroLevels
    Dim i As Integer
    Dim Button As Button
    Private Sub frmMicroLevels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For n = 1 To 4
            Button = grpLevels.Controls("btnLvl" & (n) & "Select")
            If AccountPoints <= n * 10 Then 'checks to see which levels this user should be able to view 
                Button.Enabled = False
            Else
                Button.Enabled = True
            End If
        Next
    End Sub

    Private Sub btns_Click(sender As Object, e As EventArgs) Handles btnLvl0Select.Click, btnLvl1Select.Click, btnLvl2Select.Click, btnLvl3Select.Click, btnLvl4Select.Click
        Dim myButton = DirectCast(sender, Button)
        For n = 0 To 4
            If myButton.Name.Contains(n) Then
                Micro = True
                CurrentLevel = n + 1             'sets the current level the user has selected and the form they came from (in this case the macro form) to be used in the level form 
            End If
        Next
        frmLevel.Show()
        Macro = False  'resets the variables to false after the level is completed 
        Micro = False
        Me.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmSelect.Show()
        Me.Close()
    End Sub
End Class