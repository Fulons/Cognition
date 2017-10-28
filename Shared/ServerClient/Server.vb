
Imports System.Net
Imports System.Net.Sockets

Public Class Server

#Region "Variables"
    Public Property listener As TcpListener
    Public port As Integer
    Public isStarted As Boolean = False
    Public receivers As List(Of Receiver)
#End Region

#Region "Events"
    Public Event ClientConnected(r As Receiver)
    Public Event ClientVaildating(args As ClientValidatingEventArgs)
    Public Event ClientValidatedSuccess(r As Receiver)
    Public Event ClientValidatedFail(r As Receiver)
    Public Event ClientDisconnected(r As Receiver)
#End Region

#Region "Constructors"
    Public Sub New(port As Integer)
        Me.receivers = New List(Of Receiver)
        Me.port = port
    End Sub
#End Region

#Region "Public Methods"
    'Start listening for incomming connections
    Public Sub Start()
        If isStarted = False Then
            listener = New TcpListener(IPAddress.Any, port)
            listener.Start()            '1 Start Listener
            isStarted = True

            WaitForConnection()
        End If
    End Sub

    'Gracefully shutdown the server
    Public Sub Shutdown()
        If isStarted Then
            listener.Stop()
            isStarted = False

            Debug.WriteLine("Server stoped!")
        End If
    End Sub

    Public Sub SendToAllReceivers(msg As MessageBase)
        For Each receiver In receivers
            receiver.SendMessage(msg)
        Next
    End Sub
#End Region

#Region "Incomming connections method"
    Private Sub WaitForConnection()     '2. Wait for incomming connection
        listener.BeginAcceptTcpClient(New AsyncCallback(AddressOf ConnectionHandler), Nothing)
    End Sub

    'Async callback to initiate new client
    Private Sub ConnectionHandler(ar As IAsyncResult)
        SyncLock receivers
            Dim newClient As New Receiver(listener.EndAcceptTcpClient(ar), Me)  '3. Acept Connection
            newClient.Start()           '4. Starts reaciever threads
            receivers.Add(newClient)
            RaiseEvent ClientConnected(newClient)
        End SyncLock
        WaitForConnection()             '5. Goto stage 2
    End Sub
#End Region

#Region "Raise event access functions for Receiver class"
    Public Sub OnClientValidating(args As ClientValidatingEventArgs)
        RaiseEvent ClientVaildating(args)
    End Sub

    Public Sub OnClientValidatedSuccess(r As Receiver)
        RaiseEvent ClientValidatedSuccess(r)
    End Sub

    Public Sub OnClientValidateadFail(r As Receiver)
        RaiseEvent ClientValidatedFail(r)
    End Sub

    Public Sub OnClientDisconnect(r As Receiver)
        receivers.Remove(r)
        RaiseEvent ClientDisconnected(r)
    End Sub

#End Region

End Class