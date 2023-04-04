Imports MySql.Data.MySqlClient
Public Class frmUserStats
    Dim myConn As New MySqlConnection
    Dim myCmd As New MySqlCommand
    Dim myReader As MySqlDataReader

    Dim CorrectLevelAnswer As Integer
    Dim IncorrectLevelAnswer As Integer
    Dim LevelNumber As Integer

    Dim Information(12) As String
    Dim LevelsCompleted As Integer
    Dim MemberPercentage As Integer

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim UserID As String = txtUserID.Text
        myConn = classConnection.SQLConn
        Try
            myCmd = New MySqlCommand("SELECT * FROM Members WHERE UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserID", UserID)
            myReader = myCmd.ExecuteReader

            If UserID <> "" And myReader.HasRows = True Then
                myConn.Close()
                myConn.Open()
                myCmd = New MySqlCommand("SELECT LevelNo FROM LevelUser WHERE UserID = @UserID", myConn)
                myCmd.Parameters.AddWithValue("@UserID", UserID)
                Using myReader = myCmd.ExecuteReader()
                    While (myReader.Read())
                        LevelsCompleted += 1   'calculates the amount of levels this user has completed and assigns them to the first value in the information array 
                    End While
                End Using
                Information(0) = LevelsCompleted
                myConn.Close()
                myConn.Open()
                Me.MemberAns(UserID)
                Level(UserID)
            ElseIf UserID = "" Then
                myConn.Close()
                myConn.Open()
                MsgBox("Please enter a username")
            ElseIf myReader.HasRows = False Then
                myConn.Close()
                myConn.Open()
                MsgBox("This User was not found")
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub
    Function MemberAns(ByRef UserID As String)
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
            MemberPercentage = Math.Round(CorrectMemberAnswer / MemberAnswers * 100)  'calculates the amount of correct answers this user has and assigns them to the second value of the array

            Return MemberPercentage
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            myConn.Dispose()
        End Try
    End Function
    Sub Level(ByRef UserID As String)
        Information(1) = MemberPercentage
        Information(2) = "0"
        Try
            For LevelNumber = 1 To 10
                myConn.Open()
                myCmd = New MySqlCommand("SELECT CorrectAnsLevel, IncorrectAnsLevel FROM LevelUser WHERE UserID = @UserID AND LevelNo = @LevelNo", myConn)
                myCmd.Parameters.AddWithValue("@UserID", UserID)
                myCmd.Parameters.AddWithValue("@LevelNo", LevelNumber)
                Using myReader = myCmd.ExecuteReader()
                    While (myReader.Read())
                        For Count = 0 To 1
                            If Count = 0 Then
                                If IsDBNull(myReader.GetString(Count)) = True Then
                                    CorrectLevelAnswer = "0"
                                Else
                                    CorrectLevelAnswer = myReader.GetString(Count)    'runs through each level in the system and calculates the percentage correct the user got on that paticular level
                                End If                                                'and assigns them to the different value within the rest of the array
                            Else
                                If IsDBNull(myReader.GetString(Count)) = True Then
                                    IncorrectLevelAnswer = "0"
                                Else
                                    IncorrectLevelAnswer = myReader.GetString(Count)
                                End If

                            End If
                        Next
                        Information(LevelNumber + 2) = Math.Round(CorrectLevelAnswer / (CorrectLevelAnswer + IncorrectLevelAnswer) * 100)
                    End While
                End Using
                myConn.Close()
            Next

            For i = 0 To Information.Length - 1
                If i = 1 Or i > 2 Then
                    If Information(i) = Nothing Then
                        DGVDisplay(i, 0).Value = "Incomplete"  'if the level is not completed then displays "incomplete" in the box
                    Else
                        DGVDisplay(i, 0).Value = (Information(i) & "%")
                    End If
                Else
                    DGVDisplay(i, 0).Value = Information(i)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmUserStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class