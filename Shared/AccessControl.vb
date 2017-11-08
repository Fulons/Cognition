Imports System.Data.OleDb
'Handles an access database
Public Class AccessControl : Inherits DBControl
    Private connection As New OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data source = ")
    Private command As New OleDbCommand

    Public dataAdapter As OleDbDataAdapter

    Public params As New List(Of OleDbParameter)

    Public recordCount As Integer
    Public exception As String

    Public Sub New()
    End Sub

    Public Sub New(connection As String)
        Me.connection = New OleDbConnection(connection)
    End Sub

    'Verifies the connection string
    Public Overrides Function VerifyConnection() As Boolean
        Try
            Me.connection.Open()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "DB Connection error")
            Return False
        Finally
            Me.connection.Close()
        End Try
        If Me.connection.State.HasFlag(ConnectionState.Broken) Then
            Return False
        Else
            Return True
        End If
    End Function

    'Execute a query
    Public Overrides Sub ExecuteQuery(query As String)
        recordCount = 0
        exception = ""
        Try
            connection.Open()

            command = New OleDbCommand(query, connection)
            params.ForEach(Sub(p) command.Parameters.Add(p))

            params.Clear()

            dataTable = New DataTable
            dataAdapter = New OleDbDataAdapter(command)
            recordCount = dataAdapter.Fill(dataTable)
        Catch ex As Exception
            exception = ex.Message
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    'Adds a parameter to be used for the next query
    Public Overrides Sub AddParam(name As String, value As Object)
        Dim newParam As New OleDbParameter(name, value)
        params.Add(newParam)
    End Sub

    'Check if query returned any exceptions
    Public Overrides Function HasException(Optional Report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(exception) = False Then
            If Report = True Then
                MsgBox(exception, MsgBoxStyle.Critical, "Exception:")
            End If
            Return True
        End If
        Return False
    End Function
End Class