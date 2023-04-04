
Imports MySql.Data.MySqlClient
Public Class frmRegister
    Dim UserID, Password, Email, Area, Firstname, Lastname As String

    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim Blank As Integer
    Dim txtbx As TextBox

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmLogin.Show()
        Me.Close()
    End Sub

    Dim Placement, Teacher As Integer
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        Dim myConn As New MySqlConnection
        myConn = classConnection.SQLConn
        Dim myReader As MySqlDataReader
        UserID = txtUser.Text
        Password = txtPassword.Text
        Email = txtEmail.Text
        Area = txtCountry.Text
        Firstname = txtFName.Text
        Lastname = txtLName.Text

        If chkPlacement.Checked = True Then 'checks to see if the user wishes to completed the placement test
            Placement = "1"
            PlacementTestCompleted = "0"
        Else
            Placement = "0"
            PlacementTestCompleted = "1"
        End If

        If chkTeacher.Checked = True Then  'checks to see if this paticular user is a teacher account and stores a high ammount of points to allow them access to the entire system 
            Teacher = "1"
        Else
            Teacher = "0"
        End If


        Try
            Dim NewCmd As New MySqlCommand("SELECT * FROM Members WHERE UserID = @UserID", myConn)  'checks to see if this username is already taken 
            NewCmd.Parameters.AddWithValue("@UserId", UserID)
            myReader = NewCmd.ExecuteReader

            If myReader.HasRows Then
                MsgBox("This username has already been registered") 'informs the user
                myConn.Close()

            Else
                myConn.Close()
                If txtUser.Text = "" Or txtPassword.Text = "" Or txtCPassword.Text = "" Or txtEmail.Text = "" Or txtCountry.Text = "" Or txtFName.Text = "" Or txtLName.Text = "" Then
                    MsgBox("Please enter all information")   'checks to see if the user has not input information in any of the boxes
                ElseIf txtCPassword.Text <> txtPassword.Text Then
                    MsgBox("Confirm password is incorrect")   'checks to see if the password and confirm password box is the same 
                Else
                    myConn.Close()
                    myConn.Open()

                    NewCmd = New MySqlCommand("INSERT INTO Members (UserID, Password, Email, Area, Firstname, Lastname, Points, Placement, Teacher, PlacementTestCompleted, CorrectAnswers, QuestionsAnswered, QuizzesCompleted, MinigamesCompleted) 
                VALUES (@UserID, @Password, @Email, @Area, @Firstname, @Lastname, @Points, @Placement, @Teacher, @PlacementTestCompleted, @CorrectAnswers, @QuestionsAnswered, @QuizzesCompleted, @MinigamesCompleted)", myConn)
                    NewCmd.Parameters.AddWithValue("@UserId", UserID)
                    NewCmd.Parameters.AddWithValue("@Password", Password)
                    NewCmd.Parameters.AddWithValue("@Firstname", Firstname)
                    NewCmd.Parameters.AddWithValue("@Lastname", Lastname)
                    NewCmd.Parameters.AddWithValue("@Email", Email)
                    NewCmd.Parameters.AddWithValue("@Area", Area)
                    NewCmd.Parameters.AddWithValue("@Placement", Placement) 'inputs information 
                    NewCmd.Parameters.AddWithValue("@Teacher", Teacher)
                    NewCmd.Parameters.AddWithValue("@Points", 0)
                    NewCmd.Parameters.AddWithValue("@PlacementTestCompleted", PlacementTestCompleted)
                    NewCmd.Parameters.AddWithValue("@CorrectAnswers", 0)
                    NewCmd.Parameters.AddWithValue("@QuestionsAnswered", 0)
                    NewCmd.Parameters.AddWithValue("@QuizzesCompleted", 0)
                    NewCmd.Parameters.AddWithValue("@MinigamesCompleted", 0)
                    NewCmd.ExecuteNonQuery()
                    MsgBox("Successfully registered!")
                    frmLogin.Show()
                    Me.Close()
                    myConn.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class