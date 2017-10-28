Public Class UserDB

    Private type As DBType              'The type of database being utilised
    Private sqlControl As SQLControl    'Handles a SQL database

    'Validates the user
    Public Function ValidateUser(username As String, password As String) As Boolean
        Select Case type
            Case DBType.MSSQL
                Return ValidateUserSQL(username, password)
            Case DBType.MSAccess
            Case DBType.XML
        End Select
        Return False
    End Function

    'Validates a user from an MSSQL server
    Public Function ValidateUserSQL(username As String, password As String) As Boolean
        sqlControl.AddParam("@un", username)
        sqlControl.ExecuteQuery("SELECT Password FROM [User] WHERE Username = @un")
        Dim pw As String = RTrim(CType(sqlControl.dataTable.Rows(0).Item(0), String))   'Retrieves and trims the whitespace from the password string
        If pw = password Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub New(connectionString As String, type As DBType)
        Me.type = type
        Select Case type
            Case DBType.MSSQL
                sqlControl = New SQLControl(connectionString)
            Case DBType.MSAccess
            Case DBType.XML
        End Select
    End Sub

    Public Function VerifyDataBase() As Boolean
        Select Case type
            Case DBType.MSSQL
                Return sqlControl.VerifyConnection()
            Case DBType.MSAccess
            Case DBType.XML
        End Select
        Return False
    End Function

End Class

'The different types of databases that can be used to look up user data
Public Enum DBType
    MSSQL
    MSAccess
    XML
End Enum