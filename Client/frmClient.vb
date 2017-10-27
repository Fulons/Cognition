Public Class frmClient
    Public client As New [Shared].Client

    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If client.status = [Shared].StatusEnum.Disconnected Then
            frmClientLogin.Show()
        End If
    End Sub
End Class