
Imports MySql.Data.MySqlClient
Public Class frmLeaderboard
    Dim myConn As New MySqlConnection
    Dim myCmd As New MySqlCommand
    Dim Table As New DataTable
    Dim mySource As New BindingSource
    Dim myAdapt As New MySqlDataAdapter

    Dim UserIDPoints(,) As String
    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim NoOfUsers As Integer = 0
        Dim CA, QA As Integer

        myConn = classConnection.SQLConn
        Try

            myCmd = New MySqlCommand("SELECT UserID, Points, CorrectAnswers, QuestionsAnswered FROM Members", myConn)
            myAdapt = New MySqlDataAdapter(myCmd)
            myAdapt.Fill(Table)
            mySource.DataSource = Table

            NoOfUsers = Table.Rows.Count - 1
            ReDim UserIDPoints(NoOfUsers, 2)     'gets needed information from the database and inserts it into the array used 
            For Count As Integer = 0 To NoOfUsers
                UserIDPoints(Count, 0) = Table.Rows(Count)(0)
                UserIDPoints(Count, 1) = Table.Rows(Count)(1)
                CA = Table.Rows(Count)(2)
                QA = Table.Rows(Count)(3)
                If CA = 0 Or QA = 0 Then
                    UserIDPoints(Count, 2) = "0%"
                Else
                    UserIDPoints(Count, 2) = (Math.Round(CA / QA * 100) & "%")
                End If
            Next
            BubbleSort()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try
    End Sub
    Public Sub BubbleSort()
        Dim Temp As Integer
        Dim Temp2 As String
        Dim Temp3 As String
        Dim Count As Integer
        Dim MaxElement = UserIDPoints.Length / 3 - 2
        Dim Sorted As Boolean = False

        Try
            Do
                Sorted = True
                For Count = 0 To MaxElement
                    If (UserIDPoints(Count, 1) < UserIDPoints(Count + 1, 1)) Then
                        Sorted = False

                        Temp = UserIDPoints(Count, 1)
                        Temp2 = UserIDPoints(Count, 0)
                        Temp3 = UserIDPoints(Count, 2)

                        UserIDPoints(Count, 2) = UserIDPoints(Count + 1, 2)
                        UserIDPoints(Count, 1) = UserIDPoints(Count + 1, 1)        'bubble sort to sort the arrays from highest to value to lowest 
                        UserIDPoints(Count, 0) = UserIDPoints(Count + 1, 0)

                        UserIDPoints(Count + 1, 1) = Temp
                        UserIDPoints(Count + 1, 0) = Temp2
                        UserIDPoints(Count + 1, 2) = Temp3
                    End If
                Next
                MaxElement -= 1
            Loop Until Sorted

            MaxElement = UserIDPoints.Length / 3 - 2
            For Count = 0 To MaxElement + 1
                DGVLeaderboard.Rows.Add(UserIDPoints(Count, 0), UserIDPoints(Count, 1), UserIDPoints(Count, 2))      'displays this information in the datagrid view
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class