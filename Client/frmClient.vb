Public Class frmClient
    Public WithEvents client As New [Shared].Client     'Handles network communication
    Public userName As String = ""

    'Helper function to send message in the public room
    Private Sub SendPublicMessage()
        If Not String.IsNullOrEmpty(txtMessageInput.Text) Then
            client.SendPublicMessage(txtMessageInput.Text)
        End If
    End Sub

    'Sends test results to the server to be saved to the database
    Public Sub SendTestResult(result As [Shared].TestResult)
        client.SendResult(result)
    End Sub

    'Adds a global message to the main window
    'Delegate invokation makes sure it is invoked on the right thread
    Delegate Sub AddChatMessageDelegate(user As String, msg As String)
    Private Sub AddChatMessage(user As String, msg As String)
        If rtxtChat.InvokeRequired Then
            rtxtChat.Invoke(New AddChatMessageDelegate(AddressOf AddChatMessage), New Object() {user, msg})
            Return
        End If
        rtxtChat.SelectionColor = Color.DarkBlue
        rtxtChat.AppendText(user + ": ")
        rtxtChat.SelectionColor = Color.Black
        rtxtChat.AppendText(msg + vbNewLine)
    End Sub

    'Adds a private message to the session window
    'Delegate invokation makes sure it is invoked on the right thread
    Delegate Sub AddPrivateChatMessageDelegate(msg As String)
    Private Sub AddPrivateChatMessage(msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddPrivateChatMessageDelegate(AddressOf AddPrivateChatMessage), New Object() {msg})
            Return
        End If
        frmSession.AddChatMessage(frmSession.Text, msg)
    End Sub

    'Opens the session window
    'Delegate invokation makes sure that session window is stared on the window handling thread
    Delegate Sub OpenSessionWindowDelegate(name As String)
    Private Sub OpenSessionWindow(name As String)
        If Me.InvokeRequired Then
            Me.Invoke(New OpenSessionWindowDelegate(AddressOf OpenSessionWindow), New Object() {name})
            Return
        End If
        frmSession.Show()
        frmSession.btnSend.Enabled = True
        frmSession.Text = name
    End Sub

    'Ends the session
    'Delegate invokation makes sure that session window is shut down on the window handling thread
    Delegate Sub EndSessionDelegate()
    Private Sub EndSession()
        If Me.InvokeRequired Then
            Me.Invoke(New EndSessionDelegate(AddressOf EndSession))
            Return
        End If
        MessageBox.Show("Private session was ended by " + frmSession.Text, "Session ended")
        frmSession.btnSend.Enabled = False
        AddChatMessage(frmSession.Text, "private session ended")
    End Sub

    'Updates the list box of users
    'Delegate invokation makes sure that it is handled by the right thread
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

#Region "Client event handlers"

    'Handling a request for a private session
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
        AddPrivateChatMessage(str)
    End Sub

    'Private session was ended by remote client
    Private Sub SessionEndedByTheRemoteClient(client As [Shared].Client) Handles client.SessionEndedByTheRemoteClient
        EndSession()
    End Sub

    'Private session remote client disconnected (Not currently sent by the server, SessionEndedByTheRemoteClient is sent instead)
    Private Sub SessionClientDisconnected(client As [Shared].Client) Handles client.SessionClientDisconnected
        EndSession()
    End Sub

    'Not used
    Private Sub FileUploadRequest(client As [Shared].Client, args As [Shared].FileUploadRequestEventArguments) Handles client.FileUploadRequest

    End Sub

    'Not used
    Private Sub FileUploadProgress(client As [Shared].Client, args As [Shared].FileUploadProgressEventArguments) Handles client.FileUploadProgress

    End Sub

    'Not used
    Private Sub ClientDisconnected(client As [Shared].Client) Handles client.ClientDisconnected

    End Sub

    'Not used
    Private Sub GenericRequestReceived(client As [Shared].Client, request As [Shared].GenericRequest) Handles client.GenericRequestReceived

    End Sub

    'Event raised by client when a global message is received
    Private Sub PublicMessageReceived(client As [Shared].Client, request As [Shared].PublicMessageRequest) Handles client.PublicMessageReceived
        AddChatMessage(request.username, request.message)
    End Sub

    'Event raised by client when the user list has been changed
    Private Sub UserListUpdated(client As [Shared].Client, str() As String) Handles client.UserListUpdated
        UpdateUserList(lbUsers, str)
    End Sub
#End Region

#Region "Form event handlers"
    'Initialise menus to disconnected satus
    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mnuTest1.Enabled = False
        mnuLogout.Enabled = False
        mnuChatLog.Enabled = False
    End Sub

    'Shows login screen on startup
    Private Sub frmClient_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If client.status = [Shared].StatusEnum.Disconnected Then
            frmClientLogin.ShowDialog()
        End If
    End Sub

    'Login connection tiemout timer
    Private Sub tmrConnectionTimeout_Tick(sender As Object, e As EventArgs) Handles tmrConnectionTimeout.Tick
        tmrConnectionTimeout.Stop()
        If client.status = [Shared].StatusEnum.Connected Then
            Return
        End If
        MessageBox.Show("Connection timeout while trying to log in. Please check your internet connection and try again.", "Connection Timeout")
        frmClientLogin.ShowDialog()

    End Sub

    'Displays menu when right clicking in user list
    Private Sub lbUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles lbUsers.MouseDown
        If e.Button = MouseButtons.Right Then
            mnuRightClick.Show(Cursor.Position)
        End If
    End Sub

    'User list box right click menu. Sends request for private session to selected user
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

    'Sends public message if eneter is pressed in message input field
    Private Sub txtMessageInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessageInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendPublicMessage()
            e.Handled = True
        End If
    End Sub

    'Sends public message upon clicking the send button
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        SendPublicMessage()
    End Sub

    'Starts test1 from the test menu
    Private Sub mnuTest1_Click(sender As Object, e As EventArgs) Handles mnuTest1.Click
        frmTest.ShowDialog()
        MessageBox.Show(Me, "", "Test info", MessageBoxButtons.OK)

    End Sub

    'Opens the login window
    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        frmClientLogin.Show()
    End Sub

    'Disconnects from the server, and correctly sets menu status to disallow functions that is only available when conected
    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        mnuTest1.Enabled = False
        mnuLogout.Enabled = False
        mnuLogin.Enabled = True
        mnuChatLog.Enabled = False
        client.Disconnect()
    End Sub
#End Region
End Class