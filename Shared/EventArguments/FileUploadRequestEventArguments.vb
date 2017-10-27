
Public Class FileUploadRequestEventArguments
    Public Property request As FileUploadRequest
    Private confirmAction As Action
    Private refuseAction As Action

    Public Sub New(confirmAction As Action, refuseAction As Action)
        Me.confirmAction = confirmAction
        Me.refuseAction = refuseAction
    End Sub

    Public Sub Confirm(filename As String)
        request.destinationFilePath = filename
        confirmAction()
    End Sub

    Public Sub Refuse()
        refuseAction()
    End Sub
End Class