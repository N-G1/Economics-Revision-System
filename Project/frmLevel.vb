Imports MySql.Data.MySqlClient
Public Class frmLevel
    Dim UserAnswers(), CorrectAnswers(), Answers(4), Description() As String
    Dim StartQuestion, EndQuestion, QuestionAmount, CurrentQuestion, NoTimesRepeated, QuizzesCompleted As Integer
    Dim TypeOfQuestion, LevelDesc As String
    Dim CurrentlyDisplayedQuestion As Integer = 1
    Dim AnsCount As Integer = 0
    Dim PrevCompleted As Boolean

    Dim myConn As New MySqlConnection
    Dim myCmd As New MySqlCommand
    Dim myReader As MySqlDataReader

    Dim RadioAns As RadioButton
    Dim TextAns As TextBox
    Private Sub MarkPlacementTest()
        Dim Correct, Incorrect, QuestionAmount As Integer
        For i = 0 To QuestionAmount - 1
            If UserAnswers(i) = CorrectAnswers(i) Then  'Compares all the users answers to the correct answers stored and increments the correct variable when they match
                Correct += 1
            End If
        Next
        txtQuestionDisplay.Text = ("You got " & Correct & " Answers correct out of " & QuestionAmount & " Check your levels to see how you have progressed")  'displays the amount the user got correct
        NoTimesRepeated += 1                                                                                                                                  'along with the length of the quiz
        Incorrect = QuestionAmount - Correct        'Calculates incorrect answers from this specific user
        SetUserSpecificInformation(Correct, QuestionAmount)         'updates information in the user table 
        If PrevCompleted = True And Micro = True Or Macro = True Then
            SetLevelSpecificInformation(Correct, Incorrect)  'set information specific to this user if they have previously completed the quiz 
        ElseIf PrevCompleted = False And Micro = True Or Macro = True Then
            FirstSetLevelSpecificInformation(Correct, Incorrect) 'set information specific to this level (only done upon first completion so user cannot inflate score
        End If
        DistributePoints(Correct)
        btnShowAns.Show()
    End Sub
    Private Sub FirstSetLevelSpecificInformation(ByRef Correct As Integer, ByRef Incorrect As Integer)
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("INSERT INTO LevelUser (LevelNo, UserID, NoTimesRepeated, CorrectAnsLevel, IncorrectAnsLevel) 
                                    VALUES (@CurrentLevel, @UserID, @NoTimesRepeated, @CorrectAns, @IncorrectAns)", myConn)
            myCmd.Parameters.AddWithValue("@NoTimesRepeated", NoTimesRepeated)
            myCmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel)
            myCmd.Parameters.AddWithValue("@UserID", UserID)                'insert all information to the database
            myCmd.Parameters.AddWithValue("@CorrectAns", Correct)
            myCmd.Parameters.AddWithValue("@IncorrectAns", Incorrect)
            myCmd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Private Sub SetLevelSpecificInformation(ByRef Correct As Integer, ByRef Incorrect As Integer)
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE LevelUser SET NoTimesRepeated = @NoTimesRepeated WHERE LevelNo = @CurrentLevel AND UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@NoTimesRepeated", NoTimesRepeated)
            myCmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel)        'update and store number of times this user has completed this level 
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteNonQuery()
            myConn.Close()

            myConn.Open()
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE LevelUser SET CorrectAnsLevel = @Correct WHERE LevelNo = @CurrentLevel AND UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@Correct", Correct)
            myCmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel)        'update and store the number of correct answers this user has for this level
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteNonQuery()
            myConn.Close()

            myConn.Open()
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE LevelUser SET IncorrectAnsLevel = @Incorrect WHERE LevelNo = @CurrentLevel AND UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@Incorrect", Incorrect)
            myCmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel)        'update and store the number of incorrect answers this user has for this level
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Public Sub SetUserSpecificInformation(ByRef Correct As Integer, ByRef QuestionAmount As Integer)
        Dim UserCorrect As Integer
        Dim UserAmountAnswered As Integer
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("SELECT CorrectAnswers, QuestionsAnswered, QuizzesCompleted FROM Members WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            Using myReader = myCmd.ExecuteReader()
                While (myReader.Read())
                    For count As Integer = 0 To 2
                        If count = 0 Then
                            UserCorrect = myReader.GetString(count)
                        ElseIf count = 1 Then
                            UserAmountAnswered = myReader.GetString(count)    'assigns the amount of answers the user has already answered and got correct to add it 
                        Else                                                  'to this new set of questions the user has completed 
                            QuizzesCompleted = myReader.GetString(count)
                            If QuizzesCompleted = Nothing Then      'exception handling in the event this is the users first quiz as a null value cannot be converted to an integer
                                QuizzesCompleted = 0
                            End If
                        End If
                    Next
                End While
            End Using
            myConn.Close()

            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE Members SET CorrectAnswers = @UserCorrect WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserCorrect", UserCorrect + Correct)  'adds the correct answers the user got in this paticular quiz to the already stored value and stores it in the database
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteNonQuery()
            myConn.Close()

            myConn.Open()
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE Members SET QuestionsAnswered = @AmountAnswered WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.Parameters.AddWithValue("@AmountAnswered", UserAmountAnswered + QuestionAmount)  'adds the amount of questions the user answered to the already stored value and stores it in the database
            myCmd.ExecuteNonQuery()
            myConn.Close()

            myConn.Open()
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE Members SET QuizzesCompleted = @QuizzesCompleted WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.Parameters.AddWithValue("@QuizzesCompleted", QuizzesCompleted + 1)  'updates the amount of quizzes this user has completed 
            myCmd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Private Sub DistributePoints(ByRef Correct As Integer)
        AccountPoints += (Math.Round(Correct / 20 * 60 / NoTimesRepeated))  'Calculation to work out the amount of points the user has earned
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE Members SET Points = @AccountPoints WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@AccountPoints", AccountPoints)  'adds this new amount of points to the database
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteNonQuery()
            myConn.Close()
            If Macro = False And Micro = False Then
                CompleteTest()   'if this is the placement test then send to this sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Private Sub CompleteTest()
        Try
            myConn = classConnection.SQLConn
            myCmd = New MySqlCommand("UPDATE Members SET PlacementTestCompleted = 1 WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)  'in the event the user is completed the placement test set the value to 1 in the database upon completion so the user is not sent to this 
            myCmd.ExecuteNonQuery()                           'quiz again
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try

    End Sub
    Private Sub frmLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl As String
        For Each control In Me.Controls
            ctrl = control.Name
            If ctrl <> "btnBeginLevel" Then  ' hide all controls on the form except the begin level button 
                control.Hide
            End If
        Next
        If Micro = True Then
            btnBeginLevel.Text = "Begin Microeconomics level " & CurrentLevel  'change the text of the begin level button depending on the previous form the user came from 
        ElseIf Macro = True Then
            btnBeginLevel.Text = "Begin Macroeconomics level " & CurrentLevel
        Else
            btnBeginLevel.Text = "Begin Placement Test"
        End If
        If Macro = True Then
            btnBack.Text = "Back to Macro level select"
        ElseIf Micro = True Then
            btnBack.Text = "Back to Micro level select"
        Else
            btnBack.Text = "Back to Login page"
        End If
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If Micro = True Then
            frmMicroLevels.Show()   'ensure the user is sent back to the correct form depending on what form they're coming from
        ElseIf Macro = True Then
            frmMacroLevels.Show()
        Else
            frmLogin.Show()
        End If
        Me.Close()
    End Sub
    Private Sub btnBeginLevel_Click(sender As Object, e As EventArgs) Handles btnBeginLevel.Click
        Dim ctrl As String
        For Each control In Me.Controls
            ctrl = control.name
            If ctrl <> "txtLongAnswer" Then   'show all controls except the textbox to answer the long answer questions as this is only shown when needed as it overlaps the radio buttons
                control.show
            End If
        Next
        btnBeginLevel.Hide()
        btnShowAns.Hide()

        Me.StartEndQuestion()  'get the start and end question for this paticular quiz
        Me.ReDimArrays()     'redim all arrays used to the appropriate size depending on the amount of questions
        Me.AnswerAssign()
        Me.LevelLabelAndRepeated() 'gets the level description and the number of times the user has completed this paticular level
        Me.TypeQuestion()   'get the type of question the current question is to allow for the system to decide to show radio buttons or long answer text box 
        QuestionAssign()    'assign the answers to the radio buttons (depending on if this is needed)

        btnBack.Hide()   'hide the back button so the user cannot back otu in the middle of a level
        btnBeginLevel.Hide()   'hide teh begin button
        txtQuestionDisplay.ReadOnly = True   'stop the user from typing in the question display and the question number display
        txtQuestionNo.ReadOnly = True
        btnNext.Show()
        If Macro = True And Micro = True Then  'display the level description if it is not the placement test
            Label1.Text = ("Level: " & CurrentLevel & ": " & LevelDesc)
        Else
            Label1.Text = "Placement Test"
        End If
    End Sub
    Function LevelLabelAndRepeated()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT LevelTopic, NoTimesRepeated FROM Levels, LevelUser WHERE Levels.LevelNo = @LevelNo AND LevelUser.UserID = @UserID AND Levels.LevelNo = LevelUser.LevelNo", myConn)
            myCmd.Parameters.AddWithValue("@LevelNo", CurrentLevel)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myCmd.ExecuteScalar()
            Using myReader = myCmd.ExecuteReader
                While (myReader.Read())
                    For Count = 0 To 1
                        If Count = 0 Then
                            LevelDesc = myReader.GetString(Count)
                        Else
                            NoTimesRepeated = myReader.GetString(Count)   'select both level topic and number of times repeated and assign them to their correct variabes
                            If NoTimesRepeated = Nothing Then
                                NoTimesRepeated = 1  'exception handling for if the user has never completed this paticular level
                                PrevCompleted = False
                            Else
                                PrevCompleted = True
                            End If
                        End If
                    Next
                End While
            End Using
            Return LevelDesc
            Return NoTimesRepeated
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Function StartEndQuestion()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT StartQNo, EndQNo FROM Levels WHERE LevelNo = @LevelNo", myConn)
            myCmd.Parameters.AddWithValue("@LevelNo", CurrentLevel)

            Using myReader = myCmd.ExecuteReader()
                While (myReader.Read())
                    For count As Integer = 0 To 1
                        If count = 0 Then
                            StartQuestion = myReader.GetString(count)  'get the start question and end question for this quiz from the database and assign them to their variables
                        Else
                            EndQuestion = myReader.GetString(count)
                        End If
                    Next
                End While
            End Using
            myConn.Close()

            Return StartQuestion
            Return EndQuestion

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Function ReDimArrays()
        Try
            QuestionAmount = EndQuestion - (StartQuestion - 1)
            ReDim UserAnswers(QuestionAmount - 1), CorrectAnswers(QuestionAmount - 1), Description(QuestionAmount - 1)
            CurrentQuestion = StartQuestion  'redim the arrays used so there is no it is not overly large or small
            Return Answers
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Function AnswerAssign()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT Answer1, Answer2, Answer3, Answer4, Answer5 FROM Questions WHERE QuestionNo = @QuestionNum", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNum", CurrentQuestion)
            myCmd.ExecuteNonQuery()

            Dim n, z As Integer
            Using myReader = myCmd.ExecuteReader()
                While (myReader.Read())
                    For count As Integer = 0 To 4
                        If myReader.GetString(count) = "_" Then  'if the answer is blank in the database (as not all questions have 5 answers thats just the maximum they can have)
                            z += 1                               'then increment the variable that will be used to determine the neccessary size of the answer array for this paticualr question 
                        End If
                    Next
                    ReDim Answers(4 - z)     'redeclare here
                    For count = 0 To Answers.Length - 1
                        Answers(n) = myReader.GetString(count) 'assign the answers that were not blank to the array
                        n += 1
                    Next
                End While

            End Using
            myConn.Close()
            Return Answers
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function

    Function CorrectAnswerArray()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT CorrectAnswer FROM Questions WHERE QuestionNo = @QuestionNum", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNum", CurrentQuestion)
            myCmd.ExecuteScalar()
            CorrectAnswers(CurrentlyDisplayedQuestion - 1) = Convert.ToString(myCmd.ExecuteScalar()) 'get and store the correct answer for this paticular question 
            myConn.Close()
            Return CorrectAnswers
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim Blank As Integer
        Dim Keywords As Integer
        Try
            If TypeOfQuestion = "M" Then  'checks to see if the question is multiple choice 
                txtLongAnswer.Hide()
                For n = 1 To Answers.Length - 1
                    RadioAns = grpAnswers.Controls("RadioAns" & (n))
                    If RadioAns.Checked Then 'assigns the answer the user gave for this question before pressing next to the array
                        UserAnswers(CurrentlyDisplayedQuestion - 1) = RadioAns.Text
                        Me.CorrectAnswerArray() ' store the correct answer for this question 
                        Me.AnswerDescription()  ' get the description of this paticular question 
                    Else
                        Blank += 1
                        If Blank = Answers.Length - 1 Then
                            MsgBox("Please enter atleast one answer before proceeding")
                            CurrentQuestion -= 1   'exception handling for if the user does not enter an answer and ensures the next question is not loaded
                            CurrentlyDisplayedQuestion -= 1
                        End If
                    End If
                Next
            Else ' if the question is long answer and not multiple choice
                txtLongAnswer.Show()
                txtLongAnswer.Clear() 'clears the users previous answer (if there was one)
                Me.CorrectAnswerArray()
                Me.AnswerDescription()
                For n = 0 To 4  'checks if the users answer contains any of the keywords stored for this question 
                    If txtLongAnswer.Text.Contains(AnswerAssign(n)) Then
                        Keywords += 1
                    End If
                Next
                If Keywords >= 3 Then ' if the user got 3 or more keywords then it is deemed a correct answer 
                    UserAnswers(CurrentlyDisplayedQuestion - 1) = "Correct"
                Else
                    UserAnswers(CurrentlyDisplayedQuestion - 1) = "Incorrect"
                End If
            End If
            CurrentQuestion += 1 'increments the question number used to get the questions from the database and the question number displayed for the user (as the user will always start on   
            CurrentlyDisplayedQuestion += 1                                                                                                                   'question one but the database will not)
            Me.TypeQuestion()
            Answers = Me.AnswerAssign
            QuestionAssign()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function AnswerDescription()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT Description FROM Questions WHERE QuestionNo = @QuestionNum", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNum", CurrentQuestion)  'gets the description for the current question 
            myCmd.ExecuteScalar()
            Description(CurrentlyDisplayedQuestion - 1) = Convert.ToString(myCmd.ExecuteScalar())
            myConn.Close()
            Return Description
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Private Sub btnShowAns_Click(sender As Object, e As EventArgs) Handles btnShowAns.Click
        txtLongAnswer.Show()
        txtLongAnswer.ReadOnly = True
        btnShowAns.Text = "Next"
        Try
            If AnsCount = 0 < QuestionAmount - 1 Then   'runs through each question and displays the user the correct answer and the description for this answer
                If CorrectAnswers(AnsCount) <> "Correct" Then
                    txtQuestionDisplay.Text = ("The correct answer was: " & CorrectAnswers(AnsCount))
                Else
                    txtQuestionDisplay.Text = ("Long answer questions do not have set answers")  'does not display a set answer in the event the question was long answer and instead just gives a 
                End If                                                                           'description
                txtLongAnswer.Text = ("The given description for this question is: " & Description(AnsCount))
                AnsCount += 1
            Else
                txtLongAnswer.Hide()
                grpAnswers.Hide()
                txtQuestionNo.Hide()
                btnShowAns.Enabled = False
                txtQuestionDisplay.Text = ("You have reached the end of the corrections, check your levels to see how you have progressed")  'lets the user know they have reached the end of the answer
                txtLongAnswer.Text = ("")                                                                                                    'checking
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function TypeQuestion()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT TypeOfQuestion FROM Questions WHERE QuestionNo = @QuestionNum", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNum", CurrentQuestion)  'gets the type of question the current question is 
            myCmd.ExecuteScalar()
            TypeOfQuestion = myCmd.ExecuteScalar()
            myConn.Close()
            Return TypeOfQuestion
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Function QuestionDisplay()
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT Question FROM Questions WHERE QuestionNo = @QuestionNum", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNum", CurrentQuestion) 'gets the current question being used 
            myCmd.ExecuteScalar()
            Dim Question As String = Convert.ToString(myCmd.ExecuteScalar())
            myConn.Close()
            Return Question
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Sub QuestionAssign()
        Try
            If CurrentlyDisplayedQuestion <= QuestionAmount And TypeOfQuestion = "M" Then 'if the question is not the last question and is multiple choice
                txtLongAnswer.Hide()
                For n = 1 To 5
                    RadioAns = grpAnswers.Controls("RadioAns" & (n)) 'assigns each radio button to the radioans variable and then assigns the radio buttons the information stored in the answer array
                    RadioAns.Show()
                    If n <= Answers.Length Then
                        RadioAns.Text = Answers(n - 1)
                    Else
                        RadioAns.Hide()
                    End If

                Next
            Else  'else just display the long answer textbox 
                txtLongAnswer.Show()
            End If

            txtQuestionDisplay.Text = Me.QuestionDisplay
            txtQuestionNo.Text = ("Question No. " & CurrentlyDisplayedQuestion)  'display the current question number and the question 

            If CurrentQuestion > EndQuestion Then 'if the question number is greater than the end question stored for this quiz 
                txtQuestionNo.Text = "Congratulations on finishing "
                btnNext.Enabled = False
                btnBack.Show()
                MarkPlacementTest() 'send to the mark quiz form 

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class