'An interface class that defines the base function required for controlling a database
Public MustInherit Class DBControl
    Public dataTable As DataTable

    Public MustOverride Function VerifyConnection() As Boolean          'Should verify the conenction to the database
    Public MustOverride Sub ExecuteQuery(query As String)               'Executes a query with
    Public MustOverride Sub AddParam(name As String, value As Object)   'Add parameters that can be used in the next query
    Public MustOverride Function HasException(Optional Report As Boolean = False) As Boolean    'Check if an exception was caught while executing the query
End Class