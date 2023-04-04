Imports MySql.Data.MySqlClient
Public Class frmCreateQuestion
    Dim myCmd As New MySqlCommand
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim myConn As New MySqlConnection
        myConn = classConnection.SQLConn
        Dim myReader As MySqlDataReader

        Try
            myCmd = New MySqlCommand("SELECT * FROM Questions WHERE QuestionNo = @QuestionNo", myConn)
            myCmd.Parameters.AddWithValue("@QuestionNo", txtQuestionNo.Text)  'checks to see if the question number is already being used 
            myReader = myCmd.ExecuteReader

            If myReader.HasRows Then
                MsgBox("This question already exists")
                myConn.Close()

            Else
                myConn.Close()
                myConn.Open()

                myCmd = New MySqlCommand("INSERT INTO Questions 
                 VALUES (@QuestionNo, @TOQ, @Question, @Ans1, @Ans2, @Ans3, @Ans4, @Ans5, @CAns, @Diff, @Desc)", myConn)
                myCmd.Parameters.AddWithValue("@QuestionNo", txtQuestionNo.Text)
                myCmd.Parameters.AddWithValue("@TOQ", txtTOQ.Text)
                myCmd.Parameters.AddWithValue("@Question", txtQuestion.Text)
                myCmd.Parameters.AddWithValue("@Ans1", txtAns1.Text)
                myCmd.Parameters.AddWithValue("@Ans2", txtAns2.Text)
                myCmd.Parameters.AddWithValue("@Ans3", txtAns3.Text)         'allows the teacher to create a new question 
                myCmd.Parameters.AddWithValue("@Ans4", txnAns4.Text)
                myCmd.Parameters.AddWithValue("@Ans5", txtAns5.Text)
                myCmd.Parameters.AddWithValue("@CAns", txtCorrectAns.Text)
                myCmd.Parameters.AddWithValue("@Diff", txtDiff.Text)
                myCmd.Parameters.AddWithValue("@Desc", txtDesc.Text)

                myCmd.ExecuteNonQuery()
                MsgBox("Successfully added question")
                frmTeachervb.Show()
                Me.Close()
                myConn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmTeachervb.Show()
        Me.Close()
    End Sub

    Private Sub frmCreateQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class