Public Class ctrlSQLDBConnection

    Public Function GetConnectionString() As String
        'Server=myServerAddress; Database=myDataBase; User Id=myUsername; Password = myPassword;
        Dim ret As String = "Server="
        ret = ret + ccIP.GetIPString() + "," + ccIP.GetPort().ToString() + ";Database=" + txtDatabase.Text + ";User Id=" + txtUsername.Text + ";Password=" + txtPassword.Text + ";"
        Return ret
    End Function

End Class
