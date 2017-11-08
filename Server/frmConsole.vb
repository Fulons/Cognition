Public Class frmConsole
    Public WithEvents server As [Shared].Server     'Handles network communication
    Private userDB As [Shared].UserDB               'Handles database communication

#Region "Form control manipulation functions"
    'Thread safe method to add info line to the console
    Delegate Sub AddConsoleInfoDelegate(str As String)
    Private Sub AddConsoleInfo(str As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddConsoleInfoDelegate(AddressOf AddConsoleInfo), New Object() {str})
            Return
        End If
        rtxtConsole.SelectionColor = Color.DarkRed
        rtxtConsole.AppendText("INFO: ")
        rtxtConsole.SelectionColor = Color.Black
        rtxtConsole.AppendText(str + vbNewLine)
    End Sub

    'Thread safe method to add user inffo to the console
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

    'Thread safe method to update the list box of users
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
#End Region

#Region "Server event handlers"

    'Thread safe function to add test test results to database
    Private Sub ClientDidTest(r As [Shared].Receiver, results As [Shared].TestResult) Handles server.ClientDidTest
        SyncLock userDB
            userDB.InsertTestResults(results, r.username)
        End SyncLock
    End Sub

    'Not currently used
    Private Sub ClientConnected(r As [Shared].Receiver) Handles server.ClientConnected

    End Sub

    'Validates the user and sends reply back to client
    Private Sub ClientVaildating(args As [Shared].ClientValidatingEventArgs) Handles server.ClientVaildating
        If userDB.ValidateUser(args.request.username, args.request.password) Then
            args.confirmAction()
            AddConsoleUserInfo(args.request.username, "connected!")
        Else
            args.refuseAction()
            AddConsoleUserInfo(args.request.username, "failed to connect!")
        End If
    End Sub

    'Put message in console when a client has been validated
    Private Sub ClientValidatedSuccess(r As [Shared].Receiver) Handles server.ClientValidatedSuccess
        AddConsoleUserInfo(r.username, "validated!")
        UpdateClientList()
    End Sub

    'Put message in console when a client has failed validation
    Private Sub ClientValidatedFail(r As [Shared].Receiver) Handles server.ClientValidatedFail
        AddConsoleUserInfo(r.username, "validation success!")
    End Sub

    'Put message in console when a client disconects
    Private Sub ClientDisconnected(r As [Shared].Receiver) Handles server.ClientDisconnected
        AddConsoleUserInfo(r.username, "disconnected!")
        UpdateClientList()
    End Sub
#End Region

#Region "Form event handlers"

    'Displays server settings on startup
    Private Sub frmConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        frmServerSettings.ShowDialog()
    End Sub

    'Initiliase mnu items on startup
    Private Sub frmConsole_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        mnuDisconnect.Enabled = False
    End Sub

    'Starts the server to begin listening fo clients
    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuConnect.Click
        'Starts the server
        server = New [Shared].Server(frmServerSettings.txtPort.Text)
        server.Start()
        mnuConnect.Enabled = False

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
            mnuConnect.Enabled = True
        Else
            mnuDisconnect.Enabled = True
        End If
    End Sub

    Private Sub mnuDisconnect_Click(sender As Object, e As EventArgs) Handles mnuDisconnect.Click
        server.Shutdown()
        mnuConnect.Enabled = True
        mnuDisconnect.Enabled = False
    End Sub
#End Region
End Class