Public Class frmConsole
    Public WithEvents server As [Shared].Server
    Private userDB As [Shared].UserDB

#Region "Console text functions"
    Delegate Sub AddConsoleInfoDelegate(str As String)
    Private Sub AddConsoleInfo(str As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddConsoleInfoDelegate(AddressOf AddConsoleInfo), New Object() {str})
            Return
        End If
        rtxtConsole.SelectionColor = Color.DarkRed
        rtxtConsole.AppendText("INFO: ")
        rtxtConsole.SelectionColor = Color.Black
        rtxtConsole.AppendText(str)
    End Sub

    Delegate Sub AddConsoleUserInfoDelegate(user As String, str As String)
    Private Sub AddConsoleUserInfo(user As String, str As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddConsoleUserInfoDelegate(AddressOf AddConsoleUserInfo), New Object() {user, str})
            Return
        End If
        rtxtConsole.SelectionColor = Color.DarkRed
        rtxtConsole.AppendText("INFO: ")
        rtxtConsole.SelectionColor = Color.DarkBlue
        rtxtConsole.AppendText(user + " ")
        rtxtConsole.SelectionColor = Color.Black
        rtxtConsole.AppendText(str + vbNewLine)
    End Sub
#End Region

#Region "Server event handlers"
    Private Sub ClientConnected(r As [Shared].Receiver) Handles server.ClientConnected
        'UpdateClientList()
    End Sub

    Private Sub ClientVaildating(args As [Shared].ClientValidatingEventArgs) Handles server.ClientVaildating
        If userDB.ValidateUser(args.request.username, args.request.password) Then
            args.confirmAction()
            AddConsoleUserInfo(args.request.username, "connected!")
        Else
            args.refuseAction()
            AddConsoleUserInfo(args.request.username, "failed to connect!")
        End If
    End Sub

    Private Delegate Sub UpdateClientListDelegate()
    Private Sub UpdateClientList()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateClientListDelegate(AddressOf UpdateClientList))
            Return
        End If

        'Update client list on the server form
        lbUsers.Items.Clear()
        For Each receiver In server.receivers
            lbUsers.Items.Add(receiver.username)
        Next

        'Send updated client list to all clients
        Dim users(server.receivers.Count) As String
        For i As Integer = 0 To server.receivers.Count - 1
            users(i) = server.receivers(i).username
        Next
        Dim request As New [Shared].UserListUpdatedRequest
        request.list = users
        server.SendToAllReceivers(request)
    End Sub

    Private Sub ClientValidatedSuccess(r As [Shared].Receiver) Handles server.ClientValidatedSuccess
        AddConsoleUserInfo(r.username, "validated!")
        UpdateClientList()
    End Sub

    Private Sub ClientValidatedFail(r As [Shared].Receiver) Handles server.ClientValidatedFail
        AddConsoleUserInfo(r.username, "validation success!")
        UpdateClientList()
    End Sub

    Private Sub ClientDisconnected(r As [Shared].Receiver) Handles server.ClientDisconnected
        AddConsoleUserInfo(r.username, "disconnected!")
        UpdateClientList()
    End Sub
#End Region

#Region "Form event handlers"
    Private Sub frmConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        frmServerSettings.ShowDialog()
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        'Starts the server
        server = New [Shared].Server(frmServerSettings.txtPort.Text)
        server.Start()

        'Initialises user database
        Select Case frmServerSettings.cbDBType.Text
            Case "MS SQL"
                userDB = New [Shared].UserDB(frmServerSettings.ccSQLDBConnection.GetConnectionString(), [Shared].DBType.MSSQL)
            Case "MS Access"
                userDB = New [Shared].UserDB(frmServerSettings.ccAccessDBConnection.GetConnectionString(), [Shared].DBType.MSAccess)
            Case "XML"
                userDB = New [Shared].UserDB(frmServerSettings.ccXMLDBConnection.GetConnectionString(), [Shared].DBType.XML)
        End Select

        'Verifies the user database connection
        If userDB.VerifyDataBase() = False Then
            MessageBox.Show("Database connection string error", "Error")
            frmServerSettings.ShowDialog()
        End If
    End Sub
#End Region

End Class