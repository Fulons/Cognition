Public Class frmConsole
    Public WithEvents server As [Shared].Server
    Private userDB As [Shared].UserDB

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
        rtxtConsole.AppendText(str)
    End Sub

#Region "Server event handlers"
    Private Sub ClientConnected(r As [Shared].Receiver) Handles server.ClientConnected

    End Sub

    Private Sub ClientVaildating(args As [Shared].ClientValidatingEventArgs) Handles server.ClientVaildating
        If userDB.ValidateUser(args.request.username, args.request.password) Then
            args.confirmAction()
            AddConsoleUserInfo(args.request.username, "connected!")
        Else
            args.refuseAction()
        End If
    End Sub

    Private Sub ClientValidatedSuccess(r As [Shared].Receiver) Handles server.ClientValidatedSuccess

    End Sub

    Private Sub ClientValidatedFail(r As [Shared].Receiver) Handles server.ClientValidatedFail

    End Sub

    Private Sub ClientDisconnected(r As [Shared].Receiver) Handles server.ClientDisconnected

    End Sub
#End Region

#Region "Form event handlers"
    Private Sub frmConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmServerSettings.Show()
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        server = New [Shared].Server(frmServerSettings.txtPort.Text)
        server.Start()
        userDB = New [Shared].UserDB
    End Sub
#End Region

End Class