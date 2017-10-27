

Public Class SessionRequestEventArguments
    Public Property request As SessionRequest
    Private confirmAction As Action
    Private refuseAction As Action

    Public Sub New(confirmAction As Action, refuseAction As Action)
        Me.confirmAction = confirmAction
        Me.refuseAction = refuseAction
    End Sub

    Public Sub Confirm()
        confirmAction()
    End Sub

    Public Sub Refuse()
        refuseAction()
    End Sub

End Class