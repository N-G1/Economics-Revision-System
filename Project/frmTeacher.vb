
Imports MySql.Data.MySqlClient
Public Class frmTeachervb
    Dim Table As New DataTable
    Dim mySource As New BindingSource
    Dim myAdapt As New MySqlDataAdapter
    Dim myConn As New MySqlConnection
    Dim Choice As String
    Dim myCmd As New MySqlCommand

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Me.TableClear()
        Me.TableSelect()
        If cmbTableSelect.Text = "Members" Then     'checks to see which table the user wishes to view/update/delete and ensures that it is not a table where deleting or updating information could 
            grpDelete.Enabled = True                'break the system, if it is then dont allow the user to carry out these actions on the information displayed 
            grpUpdate.Enabled = True
        ElseIf cmbTableSelect.Text = "Questions" Then
            grpDelete.Enabled = True
            grpUpdate.Enabled = True
        Else
            grpDelete.Enabled = False
            grpUpdate.Enabled = False
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim Username As String = txtFilter.Text
        Try
            Me.TableClear()
            myAdapt = New MySqlDataAdapter("SELECT * FROM Members WHERE UserID = @Username", myConn) 'displays the information corresponding to the primary key the user wishes to view 
            myAdapt.SelectCommand.Parameters.AddWithValue("@Username", Username)
            myAdapt.Fill(Table)
            mySource.DataSource = Table
            DVGDisplay.DataSource = mySource
            myAdapt.Update(Table)
            myConn.Close()

            If Username = "" Then  'if the box is empty all information is displayed as user may assume that clearing the box clears the filtering 
                Me.TableSelect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Username As String = txtDelete.Text
        Try
            myAdapt = New MySqlDataAdapter("DELETE FROM Members WHERE UserID = @Username", myConn)
            myAdapt.SelectCommand.Parameters.AddWithValue("@Username", Username)
            myAdapt.Fill(Table)
            mySource.DataSource = Table
            DVGDisplay.DataSource = mySource    'deletes a specific row in selected table 
            myAdapt.Update(Table)
            myConn.Close()

            If Username = "" Then
                MsgBox("Please enter a valid Primary Key", Title:="Delete a record")
            Else
                MsgBox("Successfully deleted record!")
            End If
            Me.TableClear()
            Me.TableSelect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        Me.TableClear()
        Me.TableSelect()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim UserID As String = txtUpdateKey.Text
        Dim SelectUpdate As String = txtUpdateValue.Text
        Dim NewValue As String = txtUpdateNew.Text
        Choice = cmbTableSelect.Text
        Try
            If Choice = "Members" Then
                myAdapt = New MySqlDataAdapter("UPDATE " & Choice & " SET " & SelectUpdate & " = @NewValue WHERE UserID = @UserID", myConn)  'updates a specific value depending on what the user selected
                myAdapt.SelectCommand.Parameters.AddWithValue("@NewValue", NewValue)
                myAdapt.SelectCommand.Parameters.AddWithValue("@UserID", UserID)
            ElseIf Choice = "Questions" Then
                myAdapt = New MySqlDataAdapter("UPDATE " & Choice & " SET " & SelectUpdate & " = @NewValue WHERE QuestionNo = @UserID", myConn)
                myAdapt.SelectCommand.Parameters.AddWithValue("@NewValue", NewValue)
                myAdapt.SelectCommand.Parameters.AddWithValue("@UserID", UserID)
            End If
            myAdapt.Fill(Table)
            mySource.DataSource = Table
            DVGDisplay.DataSource = mySource
            myAdapt.Update(Table)
            myConn.Close()

            If UserID = "" Or SelectUpdate = "" Or NewValue = "" Then
                MsgBox("Please do not leave any boxes blank.", Title:="Update a record")
            Else
                MsgBox("Successfully updated record!")
            End If
            Me.TableClear()
            Me.TableSelect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.TableClear()
    End Sub
    Public Function TableClear()  'clear the tables previous information 
        Table.Rows.Clear()
        Table.Columns.Clear()
        Return Table
    End Function
    Function TableSelect()
        Try
            myConn = classConnection.SQLConn
            Choice = cmbTableSelect.Text
            myCmd = New MySqlCommand("SELECT * FROM " & Choice, myConn)    'displays selected table and used to refresh after a function is completed 
            myAdapt = New MySqlDataAdapter(myCmd)
            myAdapt.Fill(Table)
            mySource.DataSource = Table
            DVGDisplay.DataSource = mySource
            myAdapt.Update(Table)
            myConn.Close()
            Return DVGDisplay

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        frmCreateQuestion.Show()
    End Sub
    Private Sub btnStats_Click(sender As Object, e As EventArgs) Handles btnStats.Click
        frmUserStats.Show()
    End Sub

    Private Sub frmTeachervb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
