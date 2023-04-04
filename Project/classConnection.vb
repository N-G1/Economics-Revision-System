Imports MySql.Data.MySqlClient
Public Class classConnection
    Public Shared Function SQLConn() As MySqlConnection
        Dim myConnString As String = ("server=apache-server;userid=c0675;password=TKGTBG@1;database=EconomicsC0675;")
        Dim myConn As New MySqlConnection(myConnString)
        Try
            myConn.Open()
            Return myConn
        Catch ex As Exception
            MsgBox(ex.Message)
            myConn.Close()
            Return Nothing
        End Try
    End Function
End Class
