Public Class frmMacroLevels
    Dim i As Integer
    Dim Button As Button
    Private Sub frmMicroLevels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For n = 5 To 9
            Button = grpLevels.Controls("btnLvl" & (n) & "Select")
            If AccountPoints <= n * 10 Then 'checks to see which levels this user should be able to view 
                Button.Enabled = False
            Else
                Button.Enabled = True
            End If
        Next
    End Sub

    Private Sub btns_Click(sender As Object, e As EventArgs) Handles btnLvl5Select.Click, btnLvl6Select.Click, btnLvl7Select.Click, btnLvl8Select.Click, btnLvl9Select.Click
        Dim myButton = DirectCast(sender, Button)
        For n = 5 To 9
            If myButton.Name.Contains(n) Then
                Macro = True
                CurrentLevel = n    'sets the current level the user has selected and the form they came from (in this case the macro form) to be used in the level form 
            End If
        Next
        frmLevel.Show() 'after level is completed resets the variables to false
        Macro = False
        Micro = False
        Me.Close()
    End Sub
End Class