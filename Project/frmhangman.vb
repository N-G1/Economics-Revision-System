Imports MySql.Data.MySqlClient
Public Class frmhangman
    Dim myConn As New MySqlConnection
    Dim myCmd As New MySqlCommand
    Dim myReader As MySqlDataReader

    Dim Word As String
    Dim Letters() As String
    Dim GuessedLetters(25) As String
    Dim AvailableValues As String = "abcdefghijklmnopqrstuvwxyz"
    Dim PreviouslyGuessed(25) As String
    Dim CurrentLife As String = 0
    Dim ctrl As String
    Private Sub frmhangman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each control In Me.Controls
                ctrl = control.Name
                If ctrl.Contains("START") Then
                    control.Show()
                Else
                    control.Hide()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBeginSTART_Click(sender As Object, e As EventArgs) Handles btnBeginSTART.Click
        Dim Rand As New Random
        Dim Num As Integer
        Try
            For Each control In Me.Controls
                ctrl = control.Name
                If ctrl.Contains("START") = False Then
                    control.Show()
                Else
                    control.Hide()
                End If
            Next

            Num = Rand.Next(1, 1000)
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("SELECT Answer1 FROM Questions WHERE TypeOfQuestion = 'L' ORDER BY RAND(@number) LIMIT 1", myConn)
            myCmd.Parameters.AddWithValue("@number", Num)
            Word = Convert.ToString(myCmd.ExecuteScalar)
            myConn.Close()

            ReDim Letters(Word.Length - 1)
            For count = 0 To Word.Length
                lblWord.Text.Insert(count, "_")
            Next
            For Count = 0 To Word.Length - 1
                Letters(Count) = Word.Substring(Count)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        frmSelect.Show()
        Me.Close()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim CorrectGuess As Integer = 0
        Dim Guessed As Boolean = True
        Dim Won As Boolean = False
        Dim Lost As Boolean = False

        Try
            If txtGuess.Text.ToLower.Length > 1 Then ' not accepted
                MsgBox("Please enter only 1 letter at a time")
            ElseIf AvailableValues.Contains(txtGuess.Text.ToLower) = False Then ' not accepted
                MsgBox("Please enter a letter")
            ElseIf Letters.Contains(txtGuess.Text.ToLower) Then
                For Count = 0 To PreviouslyGuessed.Length
                    If txtGuess.Text.ToLower = PreviouslyGuessed(Count) Then 'if the letter was previously guessed
                        MsgBox("Please enter another letter")
                        Guessed = False
                    End If
                Next
                If Guessed = True Then 'if it is a new letter
                    For Count = 0 To CorrectGuess
                        PreviouslyGuessed(Count) = txtGuess.Text
                    Next
                    lstGuessedLetters.Items.Add(txtGuess.Text.ToLower)
                    CorrectGuess += 1
                    For Position = 0 To Letters.Length
                        If Letters(Position) = txtGuess.Text.ToLower Then
                            lblWord.Text = lblWord.Text.Remove(Position, 1)
                            lblWord.Text = lblWord.Text.Insert(Position, txtGuess.Text.ToUpper)
                        End If
                    Next
                    If CorrectGuess = Word.Length Then
                        MsgBox("Congratulations you won!")
                        Won = True
                        CompleteGame(Won, Lost)
                    End If
                End If
                Guessed = True
            ElseIf Letters.Contains(txtGuess.Text) = False Then
                lstGuessedLetters.Items.Add(txtGuess.Text.ToLower)
                CurrentLife += 1
                picHangman.Show()
                picHangman.Image = ImgListHangman.Images(CurrentLife)
                If CurrentLife > 7 Then
                    MsgBox("You ran out of lives! Try again next time to see if you can win")
                    Lost = True
                    CompleteGame(Won, Lost)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CompleteGame(ByRef Won As Boolean, ByRef Lost As Boolean)
        Dim MComp As Integer
        Try
            If Won = True Then
                myConn = classConnection.SQLConn
                myCmd = New MySqlCommand("SELECT MinigamesCompleted FROM Members WHERE UserID = @UserID", myConn)
                myCmd.Parameters.AddWithValue("@UserID", UserID)
                MComp = myCmd.ExecuteScalar
                If MComp = Nothing Then
                    MComp = 0
                End If
                myConn.Close()
                myConn.Open()
                myConn = classConnection.SQLConn
                myCmd = New MySqlCommand("UPDATE Members SET MinigamesCompleted = @MCompleted WHERE UserID = @UserID", myConn)
                myCmd.Parameters.AddWithValue("@MCompleted", MComp + 1)
                myCmd.Parameters.AddWithValue("@UserID", UserID)
                myCmd.ExecuteNonQuery()
                myConn.Close()

                frmSelect.Show()
                Me.Close()

            ElseIf Lost = True Then
                frmSelect.Show()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
End Class