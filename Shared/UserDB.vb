Public Class UserDB

    Private type As DBType              'The type of database being utilised
    Private sqlControl As DBControl     'Handles a SQL database
    Private Const SQLTimeFormat As String = " yyyy-MM-dd hh:mm:ss"      'Time format in sql db for datetime types

    Public Sub InsertTestResults(results As TestResult, username As String)
        Select Case type
            Case DBType.MSSQL
                InsertTestResultSQL(results, username)
            Case DBType.MSAccess
                InsertTestResultSQL(results, username)
            Case DBType.XML
        End Select
    End Sub

    Public Function GetUserIDSQL(username As String) As Integer
        sqlControl.AddParam("@un", username)
        sqlControl.ExecuteQuery("SELECT Id FROM [User] WHERE Username = @un")
        Dim idStr As String = RTrim(CType(sqlControl.dataTable.Rows(0).Item(0), String))
        Dim idInt As Integer
        Try
            idInt = Convert.ToInt32(idStr)
        Catch ex As Exception
            Return -1
        End Try
        Return idInt
    End Function

    Public Function GetTestIDSQL(id As Integer, d As DateTime) As Integer
        sqlControl.AddParam("@id", id)
        If TypeOf sqlControl Is SQLControl Then
            sqlControl.AddParam("@d", d.ToString(SQLTimeFormat))
            sqlControl.ExecuteQuery("SELECT ID FROM [TestEntry] WHERE dDate = @d AND UserID = @id")
        ElseIf TypeOf sqlControl Is AccessControl Then
            sqlControl.ExecuteQuery("SELECT ID FROM [TestEntry] WHERE dDate = #" + d.ToString(SQLTimeFormat) + "# AND UserID = @id")
        End If

        Dim idStr As String = RTrim(CType(sqlControl.dataTable.Rows(0).Item(0), String))
            Dim idInt As Integer
        Try
            idInt = Convert.ToInt32(idStr)
        Catch ex As Exception
            Return -1
        End Try
        Return idInt
    End Function

    Public Sub InsertTestResultSQL(results As TestResult, username As String)
        Dim userid As Integer = GetUserIDSQL(username)
        If userid = -1 Then
            Throw New Exception("Could not retrieve userID")
        End If
        sqlControl.AddParam("@userID", userid)
        sqlControl.AddParam("@d", results.testDate.ToString(SQLTimeFormat))
        sqlControl.ExecuteQuery("INSERT INTO TestEntry (UserID, dDate)" + vbNewLine +
                                "VALUES(@userID, @d);")
        Dim testid As Integer = GetTestIDSQL(userid, results.testDate)
        If testid = -1 Then
            Throw New Exception("Could not retrieve testID")
        End If
        For Each task As TestResult.Task In results.tasks
            sqlControl.AddParam("@ti", testid)
            sqlControl.AddParam("@tn", task.taskNum)
            sqlControl.AddParam("@sc", task.score)
            sqlControl.ExecuteQuery("INSERT INTO TestPageResult (TestEntryID, TaskNum, Score)" + vbNewLine +
                                    "VALUES(@ti, @tn, @sc);")
        Next
    End Sub

    'Validates the user
    Public Function ValidateUser(username As String, password As String) As Boolean
        Select Case type
            Case DBType.MSSQL
                Return ValidateUserSQL(username, password)
            Case DBType.MSAccess
                Return ValidateUserSQL(username, password)
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
                sqlControl = New AccessControl(connectionString)
            Case DBType.XML
        End Select
    End Sub

    Public Function VerifyDataBase() As Boolean
        Select Case type
            Case DBType.MSSQL
                Return sqlControl.VerifyConnection()
            Case DBType.MSAccess
                Return sqlControl.VerifyConnection()
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