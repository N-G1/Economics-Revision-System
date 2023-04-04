Imports MySql.Data.MySqlClient
Public Class frmSmartQuiz
    Dim myConn As New MySqlConnection
    Dim myCmd As New MySqlCommand
    Dim myReader As MySqlDataReader

    Dim UserPercentage As String

    Dim Answers() As String
    Dim Questions(9) As String
    Dim CorrectAnswerDesc(9, 1) As String
    Dim UserAnswers(9) As String
    Dim PreviousQuestion As String

    Dim Difficulty As Integer
    Dim Difficulty2 As Integer
    Dim RadioAns As RadioButton
    Dim CurrentQuestion As Integer = 1
    Dim DifficultyBand As Integer
    Private Sub CalculateCorrect()
        Dim Correct As Integer
        Dim QuestionAmount As Integer = 10
        Try
            For i = 0 To 9
                If UserAnswers(i) = CorrectAnswerDesc(i, 0) Then
                    Correct += 1
                End If
            Next
            txtQuestionDisplay.Text = ("You got " & Correct & " Answers correct out of 10! Check your levels to see how you have progressed")     'displays the amount of answers the user got correct 
            btnShowAns.Show()
            frmLevel.SetUserSpecificInformation(Correct, QuestionAmount) 'makes use of the set users specific information sub in the level form to update the database for thsi paticuarl user 
            Me.SetSmartQuizInformation(Correct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SetSmartQuizInformation(ByRef Correct As Integer)
        Dim PrevSmartQuiz, Incorrect As Integer
        Try
            Incorrect = 10 - Correct
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("SELECT MAX(SmartQuizNo) FROM SmartQuiz", myConn)   'selects the number of the last completed smart quiz 
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            If IsDBNull(myCmd.ExecuteScalar) = True Then  'exception handling for if this is the first smart quiz to be completed 
                PrevSmartQuiz = "0"
            Else
                PrevSmartQuiz = myCmd.ExecuteScalar
            End If
            myConn.Close()

            myConn.Open()
            myCmd = New MySqlCommand("INSERT INTO SmartQuiz VALUES (@SmartQuizNo, @UserID, @DifficultyBandAssigned, @CorrectAnswers, @IncorrectAnswers)", myConn)
            myCmd.Parameters.AddWithValue("@SmartQuizNo", PrevSmartQuiz + 1)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.Parameters.AddWithValue("@DifficultyBandAssigned", DifficultyBand)    'inserts information to the smart quiz table
            myCmd.Parameters.AddWithValue("@CorrectAnswers", Correct)
            myCmd.Parameters.AddWithValue("@IncorrectAnswers", Incorrect)
            myCmd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Private Sub frmSmartQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim ctrl As String
            For Each control In Me.Controls
                ctrl = control.Name
                If ctrl <> "btnBeginLevel" Then     'hides all controls in the form except the begin level button 
                    control.Hide
                End If
            Next
            Me.CalculateOverallPercentage()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function CalculateOverallPercentage()
        Dim CorrectMemberAnswer As Integer
        Dim MemberAnswers As Integer
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("SELECT CorrectAnswers, QuestionsAnswered FROM Members WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            Using myReader = myCmd.ExecuteReader()
                While (myReader.Read())
                    For count As Integer = 0 To 1
                        If count = 0 Then
                            CorrectMemberAnswer = myReader.GetString(count)
                        Else
                            MemberAnswers = myReader.GetString(count)
                        End If
                    Next
                End While
            End Using
            myConn.Close()
            UserPercentage = Math.Round(CorrectMemberAnswer / MemberAnswers * 100)    'calculates the percentage of questions this paticular user has correctly answered 
            Return UserPercentage
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Sub AnswerAssign()
        Randomize()
        Dim Rand As New Random
        Dim Num As Integer
        Dim QuestionCheck As Boolean = True
        Try
            'Do
            Num = Rand.Next(1, 1000)
                myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("SELECT Answer1, Answer2, Answer3, Answer4, Answer5, Question, CorrectAnswer, Description FROM Questions WHERE TypeOfQuestion = 'M' AND Difficulty = @Difficulty ORDER BY RAND(@number) LIMIT 1", myConn)
            myCmd.Parameters.AddWithValue("@Difficulty", Difficulty)
                myCmd.Parameters.AddWithValue("@number", Num)   'selects information from the database needed to answer each question and randomly orders them to ensure no smart quizzes are the same 
                myCmd.ExecuteScalar()                           'the RAND() function is seeded the with the "num" random value to ensure it does not constantly produce the same question over and over again

                Using myReader = myCmd.ExecuteReader()
                    Dim z As Integer
                    While (myReader.Read())
                        'For Count = 0 To CurrentQuestion - 1
                        '    If Questions(Count) = myReader.GetString(5) Then  'checks to make sure this question hasnt already been asking in the quiz
                        '        QuestionCheck = False
                        '    Else
                        '    End If
                        'Next
                        For count As Integer = 0 To 4
                            If myReader.GetString(count) = "_" Then
                                z += 1   'checks to see if one or more of the answers for this question are blank  and decreases the size of the array if it is 
                            End If
                        Next
                        Questions(CurrentQuestion - 1) = myReader.GetString(5)
                        CorrectAnswerDesc(CurrentQuestion - 1, 0) = myReader.GetString(6)   'assigns the description, correct answer and question for this paticular question 
                        CorrectAnswerDesc(CurrentQuestion - 1, 1) = myReader.GetString(7)
                        ReDim Answers(4 - z)
                        For count = 0 To Answers.Length - 1
                            Answers(count) = myReader.GetString(count)  'assigns the answers to the answers variable 
                        Next
                    End While
                End Using
                'Loop Until QuestionCheck = True
                myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Sub DifficultyAAssign()   'same as sub above but used for a different difficulty band as this one includes two difficulties 
        Randomize()
        Dim Rand As New Random
        Dim Num As Integer
        Dim QuestionCheck As Boolean = True
        Try
            '   Do 
            myConn = classConnection.SQLConn
                Num = Rand.Next(1, 1000)
                myCmd = New MySqlCommand("SELECT Answer1, Answer2, Answer3, Answer4, Answer5, Question, CorrectAnswer, Description FROM Questions WHERE TypeOfQuestion = 'M' AND Difficulty = @Difficulty OR Difficulty = @Difficulty2 ORDER BY RAND(@number) LIMIT 1", myConn)
                myCmd.Parameters.AddWithValue("@Difficulty", Difficulty)
                myCmd.Parameters.AddWithValue("@Difficulty2", Difficulty2)
                myCmd.Parameters.AddWithValue("@number", Num)
                myCmd.ExecuteScalar()
                Using myReader = myCmd.ExecuteReader()
                    Dim z As Integer
                    While (myReader.Read())
                    'For Count = 0 To CurrentQuestion - 1
                    '    If Questions(Count) = myReader.GetString(5) Then
                    '        QuestionCheck = False
                    '    Else
                    '    End If
                    'Next
                    For count As Integer = 0 To 4
                            If myReader.GetString(count) = "_" Then
                                z += 1
                            End If
                        Next
                        Questions(CurrentQuestion - 1) = myReader.GetString(5)
                        CorrectAnswerDesc(CurrentQuestion - 1, 0) = myReader.GetString(6)
                        CorrectAnswerDesc(CurrentQuestion - 1, 1) = myReader.GetString(7)
                        ReDim Answers(4 - z)
                        For count = 0 To Answers.Length - 1
                            Answers(count) = myReader.GetString(count)
                        Next
                    End While
                End Using
            ' Loop Until QuestionCheck = True
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim Blank As Integer
        Try
            If CurrentQuestion < 10 Then
                For n = 1 To Answers.Length - 1
                    RadioAns = grpAnswers.Controls("RadioAns" & (n))
                    If RadioAns.Checked Then
                        UserAnswers(CurrentQuestion - 1) = RadioAns.Text                        'works almost the same as the level form next button but as only multiple choice questions are used 
                    Else                                                                        'does not have to check or function differently for long answer questions 
                        Blank += 1
                        If Blank = Answers.Length - 1 Then
                            MsgBox("Please enter atleast one answer before proceeding")
                            CurrentQuestion -= 1
                        End If
                    End If
                Next
                CurrentQuestion += 1
                If DifficultyBand > 1 And DifficultyBand < 5 Then   'checks the difficulty band this paticular user was assigned and sends them to the correct sub
                    DifficultyAAssign()
                    QuestionAssign()
                Else
                    AnswerAssign()
                    QuestionAssign()
                End If
            Else
                CurrentQuestion += 1   'sends the user to the question assign form if they have reacted the end of the quiz as the check to see if it is completed is performed here
                QuestionAssign()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub QuestionAssign()
        Try
            If CurrentQuestion <= 10 Then
                For n = 1 To 5
                    RadioAns = grpAnswers.Controls("RadioAns" & (n))
                    RadioAns.Show()                      'assigns the questions to the radio buttons 
                    If n <= Answers.Length Then
                        RadioAns.Text = Answers(n - 1)
                    Else
                        RadioAns.Hide()
                    End If

                Next
                txtQuestionDisplay.Text = Questions(CurrentQuestion - 1)  'displays the question number and question 
                txtQuestionNo.Text = ("Question No. " & CurrentQuestion)
            End If

            If CurrentQuestion > 10 Then
                txtQuestionNo.Text = "Congratulations on finishing "   'sends the user to the correct form if they have completed the quiz 
                btnNext.Enabled = False
                btnBack.Show()
                CalculateCorrect()
                txtAnswerDisplay.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBeginLevel.Click
        Try
            Dim ctrl As String
            For Each control In Me.Controls
                ctrl = control.name
                control.show
            Next                      'hides and shows the neccessary controls 

            txtAnswerDisplay.Hide()
            btnBack.Hide()
            btnBeginLevel.Hide()
            btnShowAns.Hide()
            txtQuestionDisplay.ReadOnly = True
            txtQuestionNo.ReadOnly = True
            btnNext.Show()

            If UserPercentage >= 80 Then     'calculates the users difficulty band that they have been assigned based off there percentage of correct answers in other levels 
                Difficulty = 3
                DifficultyBand = 5
                Me.AnswerAssign()
                QuestionAssign()

            ElseIf UserPercentage >= 60 And UserPercentage <= 80 Then
                Difficulty = 3
                Difficulty2 = 2
                DifficultyBand = 4
                Me.DifficultyAAssign()
                QuestionAssign()

            ElseIf UserPercentage >= 40 And UserPercentage <= 60 Then
                Difficulty = 2
                DifficultyBand = 3
                Me.DifficultyAAssign()
                QuestionAssign()

            ElseIf UserPercentage >= 20 And UserPercentage <= 40 Then
                Difficulty = 2
                Difficulty2 = 1
                DifficultyBand = 2
                Me.DifficultyAAssign()
                QuestionAssign()

            Else
                Difficulty = 1
                DifficultyBand = 1
                Me.AnswerAssign()
                QuestionAssign()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnShowAns_Click(sender As Object, e As EventArgs) Handles btnShowAns.Click
        btnShowAns.Text = "Next"
        Dim AnsCount As Integer = 0
        txtAnswerDisplay.Show()
        Try
            If AnsCount < 10 Then
                If CorrectAnswerDesc(AnsCount, 0) <> "Correct" Then
                    txtQuestionDisplay.Text = ("The correct answer was: " & CorrectAnswerDesc(AnsCount, 0))
                Else
                    txtQuestionDisplay.Text = ("Long answer questions do not have set answers")
                End If
                txtAnswerDisplay.Text = ("The given description for this question is: " & CorrectAnswerDesc(AnsCount, 1))      'shows the user the correct answer and correct answer descriptions 
                AnsCount += 1
            Else
                txtAnswerDisplay.Hide()
                grpAnswers.Hide()
                txtQuestionNo.Hide()
                btnShowAns.Enabled = False
                txtQuestionDisplay.Text = ("You have reached the end of the corrections, thank you for participating")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmSelect.Show()
        Me.Close()
    End Sub
End Class