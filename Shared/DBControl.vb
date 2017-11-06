Public MustInherit Class DBControl

    Public dataTable As DataTable

    Public MustOverride Function VerifyConnection() As Boolean
    Public MustOverride Sub ExecuteQuery(query As String)
    Public MustOverride Sub AddParam(name As String, value As Object)
    Public MustOverride Function HasException(Optional Report As Boolean = False) As Boolean
End Class
