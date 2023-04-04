Imports MySql.Data.MySqlClient
Public Class frmResetPassword
    Dim UserID, Password, Email, ECheck As String

    Private Sub frmResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            UserID = txtUserID.Text
            Email = txtEmail.Text
            Password = txtPassword.Text
            Dim myReader As MySqlDataReader
            Dim myConn As MySqlConnection
            myConn = classConnection.SQLConn

            Dim myCmd As New MySqlCommand("SELECT Password FROM Members WHERE Password = @Password AND UserID = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserId", UserID)
            myCmd.Parameters.AddWithValue("@Password", Password)
            myReader = myCmd.ExecuteReader

            myConn.Close()
            myConn.Open()

            myCmd = New MySqlCommand("SELECT Email FROM Members WHERE Password = @UserID", myConn)
            myCmd.Parameters.AddWithValue("@UserId", UserID)
            ECheck = Convert.ToString(myCmd.ExecuteReader)

            If myReader.HasRows Then
                MsgBox("This password matches the current password corresponding to this account") 'checks to see if the user input the password already stored for this account
                myConn.Close()
            ElseIf txtUserID.Text = "" Or txtPassword.Text = "" Or txtEmail.Text = "" Then  'checks to see if the user did not input any information 
                MsgBox("Please enter information into all boxes")
            ElseIf ECheck <> Email Then
                MsgBox("Email input does not match this users email stored") 'checks to see if the user input the correct email 
            Else
                myConn.Close()
                myConn.Open()

                myCmd = New MySqlCommand("UPDATE Members SET Password = @Password WHERE UserID = @UserID")
                myCmd.Parameters.AddWithValue("@UserId", UserID)   'if all criteria is met update the password for the selected account 
                myCmd.Parameters.AddWithValue("@Password", Password)

                myCmd.ExecuteNonQuery()
                MsgBox("Password successfully updated!") 'inform the user the password has updated
                myConn.Close()
                Me.Close()
                frmLogin.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class