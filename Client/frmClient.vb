Public Class frmClient
    Public WithEvents client As New [Shared].Client
    Public userName As String = ""

    Delegate Sub AddChatMessageDelegate(user As String, msg As String)
    Private Sub AddChatMessage(user As String, msg As String)
        If rtxtChat.InvokeRequired Then
            rtxtChat.Invoke(New AddChatMessageDelegate(AddressOf AddChatMessage), New Object() {user, msg})
            Return
        End If
        rtxtChat.SelectionColor = Color.DarkBlue
        rtxtChat.AppendText(user + ": ")
        rtxtChat.SelectionColor = Color.Black
        rtxtChat.AppendText(msg)
    End Sub

#Region "Client event handlers"
    'Make sure that session window is stared on the window handling thread
    Delegate Sub OpenSessionWindowDelegate(name As String)
    Private Sub OpenSessionWindow(name As String)
        If Me.InvokeRequired Then
            Me.Invoke(New OpenSessionWindowDelegate(AddressOf OpenSessionWindow), New Object() {name})
            Return
        End If
        frmSession.Text = name
        frmSession.btnSend.Enabled = True
        frmSession.Show()
    End Sub

    'A request for a private session
    Private Sub SessionRequest(client As [Shared].Client, args As [Shared].SessionRequestEventArguments) Handles client.SessionRequest
        Dim result As Integer = MessageBox.Show(args.request.username + " requests a private session, do you wish to accept?", "Session request", MessageBoxButtons.YesNo)
        AddChatMessage(args.request.username, "requested a private session")
        If result = DialogResult.Yes Then
            OpenSessionWindow(args.request.username)
            args.Confirm()
            AddChatMessage(frmSession.Text, "private session started")
        Else
            args.Refuse()
        End If
    End Sub

    'A private session message
    Private Sub TextMessageReceived(client As [Shared].Client, str As String) Handles client.TextMessageReceived
        frmSession.AddChatMessage(frmSession.Text, str)
    End Sub

    'Private session was ended by remote client
    Private Sub SessionEndedByTheRemoteClient(client As [Shared].Client) Handles client.SessionEndedByTheRemoteClient
        MessageBox.Show("Private session was ended by " + frmSession.Text, "Session ended")
        frmSession.btnSend.Enabled = False
        AddChatMessage(frmSession.Text, "private session ended")
    End Sub

    Private Sub SessionClientDisconnected(client As [Shared].Client) Handles client.SessionClientDisconnected

    End Sub

    Private Sub FileUploadRequest(client As [Shared].Client, args As [Shared].FileUploadRequestEventArguments) Handles client.FileUploadRequest

    End Sub

    Private Sub FileUploadProgress(client As [Shared].Client, args As [Shared].FileUploadProgressEventArguments) Handles client.FileUploadProgress

    End Sub

    Private Sub ClientDisconnected(client As [Shared].Client) Handles client.ClientDisconnected

    End Sub

    Private Sub GenericRequestReceived(client As [Shared].Client, request As [Shared].GenericRequest) Handles client.GenericRequestReceived

    End Sub

    Delegate Sub UpdateUserListDelegate(lb As ListBox, str() As String)
    Private Sub UpdateUserList(lb As ListBox, str() As String)
        If lb.InvokeRequired Then
            lb.Invoke(New UpdateUserListDelegate(AddressOf UpdateUserList), New Object() {lb, str})
            Return
        End If
        lb.Items.Clear()
        For Each user In str
            If user IsNot Nothing And user <> userName Then
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
        If client.status = [Shared].StatusEnum.Connected Then
            Return
        End If
        MessageBox.Show("Connection timeout while trying to log in. Please check your internet connection and try again.", "Connection Timeout")
        frmClientLogin.ShowDialog()
    End Sub

    Private Sub lbUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles lbUsers.MouseDown
        If e.Button = MouseButtons.Right Then
            mnuRightClick.Show(Cursor.Position)
        End If
    End Sub

    Private Sub StartPrivateSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuStartSession.Click
        Dim u As String = lbUsers.SelectedItem.ToString()
        If String.IsNullOrEmpty(u) Then Return
        client.SendSessionRequest(u,
                                  Sub(senderClient, response)
                                      If response.isConfirmed Then
                                          OpenSessionWindow(u)
                                      Else
                                          MessageBox.Show(response.exception.Message, "Error")
                                      End If
                                  End Sub)
    End Sub

    Private Sub SendPublicMessage()
        If Not String.IsNullOrEmpty(txtMessageInput.Text) Then
            client.SendPublicMessage(txtMessageInput.Text)
        End If
    End Sub

    Private Sub txtMessageInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessageInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendPublicMessage()
            e.Handled = True
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        SendPublicMessage()
    End Sub
End Class