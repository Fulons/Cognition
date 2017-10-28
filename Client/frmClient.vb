Public Class frmClient
    Public WithEvents client As New [Shared].Client

    Private Sub AddChatMessage(user As String, msg As String)
        rtxtChat.SelectionColor = Color.DarkBlue
        rtxtChat.AppendText(user + ": ")
        rtxtChat.SelectionColor = Color.Black
        rtxtChat.AppendText(msg)
    End Sub

#Region "Client event handlers"
    Private Sub SessionRequest(client As [Shared].Client, args As [Shared].SessionRequestEventArguments) Handles client.SessionRequest

    End Sub
    Private Sub TextMessageReceived(client As [Shared].Client, str As String) Handles client.TextMessageReceived

    End Sub
    Private Sub FileUploadRequest(client As [Shared].Client, args As [Shared].FileUploadRequestEventArguments) Handles client.FileUploadRequest

    End Sub
    Private Sub FileUploadProgress(client As [Shared].Client, args As [Shared].FileUploadProgressEventArguments) Handles client.FileUploadProgress

    End Sub
    Private Sub ClientDisconnected(client As [Shared].Client) Handles client.ClientDisconnected

    End Sub
    Private Sub SessionClientDisconnected(client As [Shared].Client) Handles client.SessionClientDisconnected

    End Sub
    Private Sub GenericRequestReceived(client As [Shared].Client, request As [Shared].GenericRequest) Handles client.GenericRequestReceived

    End Sub
    Private Sub SessionEndedByTheRemoteClient(client As [Shared].Client) Handles client.SessionEndedByTheRemoteClient

    End Sub

    Delegate Sub UpdateUserListDelegate(lb As ListBox, str() As String)
    Private Sub UpdateUserList(lb As ListBox, str() As String)
        If lb.InvokeRequired Then
            lb.Invoke(New UpdateUserListDelegate(AddressOf UpdateUserList), New Object() {lb, str})
            Return
        End If
        lb.Items.Clear()
        For Each user In str
            If user IsNot Nothing Then
                lb.Items.Add(user)
            End If
        Next
    End Sub

    Private Sub PublicMessageReceived(client As [Shared].Client, request As [Shared].PublicMessageRequest) Handles client.PublicMessageReceived
        AddChatMessage(request.username, request.message)
    End Sub
    Private Sub UserListUpdated(client As [Shared].Client, str() As String) Handles client.UserListUpdated
        UpdateUserList(lbUsers, str)
    End Sub
#End Region

    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If client.status = [Shared].StatusEnum.Disconnected Then
            frmClientLogin.ShowDialog()
        End If
    End Sub

    Private Sub tmrConnectionTimeout_Tick(sender As Object, e As EventArgs) Handles tmrConnectionTimeout.Tick
        tmrConnectionTimeout.Stop()
        MessageBox.Show("Connection timeout while trying to log in. Please check your internet connection and try again.", "Connection Timeout")
        frmClientLogin.ShowDialog()
    End Sub
End Class