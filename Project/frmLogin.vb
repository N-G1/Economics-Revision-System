Imports MySql.Data.MySqlClient
Public Class frmLogin
    Dim myReader As MySqlDataReader
    Dim myCmd As New MySqlCommand
    Dim myConn As New MySqlConnection

    Dim Attempts As Integer = 2
    Dim Password As String


    Private Sub lblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        frmRegister.Show()
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        myConn = classConnection.SQLConn
        UserID = txtUserID.Text
        Password = txtPassword.Text

        Try
            If txtUserID.Text = "" And txtPassword.Text = "" Then
                MsgBox("Please enter a username or password") 'exception handling for if the user does not input information 
            ElseIf txtUserID.Text = "" Then
                MsgBox("Please enter a username")
            ElseIf txtPassword.Text = "" Then
                MsgBox("Please enter a password")
            Else

                myCmd = New MySqlCommand("SELECT * FROM Members WHERE UserID = @UserID AND Password = @Password", myConn) 'check to see if the username typed is present in the database
                myCmd.Parameters.AddWithValue("@UserId", UserID)
                myCmd.Parameters.AddWithValue("@Password", Password)
                myReader = myCmd.ExecuteReader

                If myReader.HasRows Then
                    myConn.Close()
                    myConn.Open()
                    myCmd = New MySqlCommand("SELECT Teacher FROM Members WHERE UserID = @UserID AND Password = @Password", myConn)
                    myCmd.Parameters.AddWithValue("@UserID", UserID)
                    myCmd.Parameters.AddWithValue("@Password", Password)
                    Teacher = Convert.ToString(myCmd.ExecuteScalar)   'checks to see if the account is a user account and stores it 

                    myConn.Close()
                    myConn.Open()
                    myCmd = New MySqlCommand("SELECT Points FROM Members WHERE UserID = @UserID AND Password = @Password", myConn)
                    myCmd.Parameters.AddWithValue("@UserID", UserID)
                    myCmd.Parameters.AddWithValue("@Password", Password)
                    AccountPoints = Convert.ToInt32(myCmd.ExecuteScalar)   'stores the number of points the user has (to be used in level form)

                    myConn.Close()
                    myConn.Open()
                    myCmd = New MySqlCommand("SELECT PlacementTestCompleted FROM Members WHERE UserID = @UserID AND Password = @Password", myConn)
                    myCmd.Parameters.AddWithValue("@UserID", UserID)
                    myCmd.Parameters.AddWithValue("@Password", Password)
                    PlacementTestCompleted = Convert.ToInt32(myCmd.ExecuteScalar)   'checks to see if the user has completed the placement test to send them to the correct form

                    If Teacher = "True" Then   'sends the user to the correct form depending on what type of account it is 
                        MsgBox("Login Successful, Teacher")
                        frmTeachervb.Show()
                        Me.Close()
                        myConn.Close()
                    ElseIf Teacher = "False" Then
                        If PlacementTestCompleted = 0 Then
                            MsgBox("Login Successful, Student")
                            frmLevel.Show()
                            Me.Close()
                            myConn.Close()
                        Else
                            MsgBox("Login Successful, Student")
                            frmSelect.Show()
                            Me.Close()
                            myConn.Close()
                        End If
                    End If
                Else
                    myConn.Close()
                    If Attempts >= 1 Then
                        MsgBox("Incorrect username or password, after 3 attempts the option to reset password will become available") 'after 3 attemps displays the reset password button 
                        Attempts -= 1

                    Else
                        MsgBox("Login Failed")
                        btnReset.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        frmResetPassword.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnReset.Hide()
    End Sub
End Class
