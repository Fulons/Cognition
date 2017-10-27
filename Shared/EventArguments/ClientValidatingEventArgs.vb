

Public Class ClientValidatingEventArgs
    Public receiver As Receiver
    Public request As ValidationRequest
    Public confirmAction As Action
    Public refuseAction As Action
    Public Sub New(confirmAction As Action, refuseAction As Action)
        Me.confirmAction = confirmAction
        Me.refuseAction = refuseAction
    End Sub
End Class