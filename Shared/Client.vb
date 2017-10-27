Imports System.Net.Sockets

Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary



Public Class Client
#Region "Private variables"
    Private receivingThread As Thread
    Private sendingThread As Thread
    Private callBacks As List(Of ResponseCallbackObject)
#End Region

#Region "Properties"
    Public Property tcpClient As TcpClient
    Public Property adress As String
    Public Property port As Integer
    Public Property status As StatusEnum
    Public Property messageQueue As Queue(Of MessageBase)
#End Region

#Region "Events"
    Public Event SessionRequest(client As Client, args As SessionRequestEventArguments)
    Public Event TextMessageReceived(client As Client, str As String)
    Public Event FileUploadRequest(client As Client, args As FileUploadRequestEventArguments)
    Public Event FileUploadProgress(client As Client, args As FileUploadProgressEventArguments)
    Public Event ClientDisconnected(client As Client)
    Public Event SessionClientDisconnected(client As Client)
    Public Event GenericRequestReceived(client As Client, request As GenericRequest)
    Public Event SessionEndedByTheRemoteClient(client As Client)
    Public Event PublicMessageReceived(client As Client, request As PublicMessageRequest)
    Public Event UserListUpdated(client As Client, str() As String)
#End Region

#Region "Constructors"
    Public Sub New()
        callBacks = New List(Of ResponseCallbackObject)
        messageQueue = New Queue(Of MessageBase)
        status = StatusEnum.Disconnected
    End Sub
#End Region

#Region "Methods"

    'Tries to connect to server returns True on success
    'Starts threads for sending and receiving data
    Public Function Connect(adress As String, port As Integer) As Boolean
        Me.adress = adress
        Me.port = port
        tcpClient = New TcpClient()
        Try
            tcpClient.Connect(Me.adress, Me.port)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error")
            Return False
        End Try
        status = StatusEnum.Connected
        tcpClient.ReceiveBufferSize = 1024
        tcpClient.SendBufferSize = 1024

        receivingThread = New Thread(AddressOf ReceivingMethod)
        receivingThread.IsBackground = True
        receivingThread.Start()

        sendingThread = New Thread(AddressOf SendingMethod)
        sendingThread.IsBackground = True
        sendingThread.Start()
        Return True
    End Function

    'Attemps to gracefully disconnect from the server
    'EVENT: ClientDisconnected
    'SEND: DisconnectRequest
    Public Sub Disconnect()
        messageQueue.Clear()
        callBacks.Clear()
        If status <> StatusEnum.Disconnected Then
            Try
                SendMessage(New DisconnectRequest())
            Catch ex As Exception

            End Try
            Thread.Sleep(1000)
            status = StatusEnum.Disconnected
            tcpClient.Client.Disconnect(False)
            tcpClient.Close()
            RaiseEvent ClientDisconnected(Me)
        End If
    End Sub

    'Attemps to log in to server
    'ADD CALLBACK
    'SEND: ValidationRequest
    Public Sub Login(username As String, password As String, callback As Action(Of Client, ValidationResponse))
        Dim request As New ValidationRequest()
        request.username = username
        request.password = password
        AddCallback(callback, request)
        SendMessage(request)
    End Sub

    'Request a session with another user
    'ADD CALLBACK
    'SEND: SessionRequest
    Public Sub RequestSession(username As String, callback As Action(Of Client, SessionResponse))
        Dim request As New SessionRequest
        request.username = username
        AddCallback(callback, request)
        SendMessage(request)
    End Sub

    'Request a termination of curent session
    'ADD CALLBACK
    'SEND: EndSessionRequest
    Public Sub EndCurrentSession(callback As Action(Of Client, EndSessionResponse))
        Dim request As New EndSessionRequest
        AddCallback(callback, request)
        SendMessage(request)
    End Sub

    'Sends a message
    'SEND: TextMessageRequest
    Public Sub SendTextMessage(message As String)
        Dim request As New TextMessageRequest
        request.message = message
        SendMessage(request)
    End Sub

    'Sends a message that is broadcasted to every client connected to the server
    'SEND: PublicMessageRequest
    Public Sub SendPublicMessage(message As String)
        Dim request As New PublicMessageRequest
        request.message = message
        SendMessage(request)
    End Sub

    Public Sub SendSessionRequest(user As String, callback As Action(Of Client, SessionResponse))
        Dim request As New SessionRequest
        request.username = user
        AddCallback(callback, request)
        SendMessage(request)
    End Sub

    'Adds message to the message queue
    Private Sub SendMessage(message As MessageBase)
        messageQueue.Enqueue(message)
    End Sub

    'UploadFile
    'RequestDesktop
    'SendGenericRequest
    'SendGenericResponse
#End Region

#Region "Threads methods"
    'Sending thread method
    'Takes messages of the message queue and sends them to the sever
    Private Sub SendingMethod()
        While (status <> StatusEnum.Disconnected)
            If messageQueue.Count > 0 Then
                Dim m As MessageBase = messageQueue.Peek()
                Dim f As New BinaryFormatter
                Try
                    f.Serialize(tcpClient.GetStream(), m)
                Catch ex As Exception
                    Disconnect()
                End Try
                messageQueue.Dequeue()
            End If
            Thread.Sleep(30)
        End While
    End Sub

    'Receiving thread method
    'Deserialize incomming messages and send them to OnMessageReceived
    Private Sub ReceivingMethod()
        While status <> StatusEnum.Disconnected
            If tcpClient.Available > 0 Then
                Dim f As New BinaryFormatter
                f.Binder = New AllowAllAssemblyVersionsDeserializationBinder()
                Dim msg As MessageBase = f.Deserialize(tcpClient.GetStream())
                OnMessageReceived(msg)
            End If
            Thread.Sleep(30)
        End While
    End Sub
#End Region

#Region "Message handlers"
    'Determines what type of message is received and sends it to the correct method
    Public Sub OnMessageReceived(msg As MessageBase)
        Dim type As Type = msg.GetType()
        If TypeOf msg Is ResponseMessageBase Then
            'GenericResponse
            InvokeMessageCallBack(msg, CType(msg, ResponseMessageBase).DeleteCallBackAfterInvoke)   'Handles login

            'RemoteDesktopResponse
            If TypeOf msg Is FileUploadResponse Then
                FileUploadResponseHandler(msg)
            End If

        Else    'Request message
            If TypeOf msg Is SessionRequest Then
                SessionRequestHandler(msg)
            ElseIf TypeOf msg Is EndSessionRequest Then
                RaiseEvent SessionEndedByTheRemoteClient(Me)
            ElseIf TypeOf msg Is FileUploadRequest Then
                FileUploadRequestHandler(msg)
            ElseIf TypeOf msg Is TextMessageRequest Then
                TextMessageRequestHandler(msg)
            ElseIf TypeOf msg Is DisconnectRequest Then
                RaiseEvent SessionClientDisconnected(Me)
            ElseIf TypeOf msg Is UserListUpdatedRequest Then
                RaiseEvent UserListUpdated(Me, CType(msg, UserListUpdatedRequest).list)
            ElseIf TypeOf msg Is PublicMessageRequest Then
                RaiseEvent PublicMessageReceived(Me, msg)
                'RemoteDesktopRequest
                'GenericRequest
            End If
        End If
    End Sub

    'RemoteDesktopResponseHandler
    'RemoteDesktopRequestHandler

    'Uploads the next chunk of a file
    'TODO: Need error handling
    Public Sub FileUploadResponseHandler(response As FileUploadResponse)
        Dim request As New FileUploadRequest(response)

        If response.hasError = False Then
            If request.currentPosition < request.totalBytes Then
                request.bytesToWrite = FileHelper.SampleBytesFromFile(request.sourceFilePath, request.currentPosition, request.bufferSize)
                request.currentPosition += request.bufferSize
                SendMessage(request)
            End If
        Else

        End If
    End Sub

    'Verifies the request to receive file
    'Writes data to file
    Public Sub FileUploadRequestHandler(request As FileUploadRequest)
        Dim response As New FileUploadResponse(request)
        If request.currentPosition = 0 Then
            Dim args As New FileUploadRequestEventArguments(
                Sub()
                    response.destinationFilePath = request.destinationFilePath
                    SendMessage(response)
                End Sub,
                Sub()
                    response.hasError = True
                    response.exception = New Exception("The file upload request was refused by the user!")
                    SendMessage(response)
                End Sub)
            args.request = request
            RaiseEvent FileUploadRequest(Me, args)
        Else
            FileHelper.AppendAllBytes(request.destinationFilePath, request.bytesToWrite)
            SendMessage(response)
            Dim eventArgs As New FileUploadProgressEventArguments()
            eventArgs.currentPosition = request.currentPosition
            eventArgs.fileName = request.fileName
            eventArgs.TotalBytes = request.totalBytes
            eventArgs.destinationPath = request.destinationFilePath
            RaiseEvent FileUploadProgress(Me, eventArgs)
        End If
    End Sub

    'EVENT: TextMessageReceived
    Public Sub TextMessageRequestHandler(request As TextMessageRequest)
        RaiseEvent TextMessageReceived(Me, request.message)
    End Sub

    'EVENT: SessionRequest
    Private Sub SessionRequestHandler(request As SessionRequest)
        Dim response As New SessionResponse(request)

        Dim args As New SessionRequestEventArguments(
            Sub()
                response.isConfirmed = True
                response.username = request.username
                SendMessage(response)
            End Sub,
            Sub()
                response.isConfirmed = False
                response.username = request.username
                SendMessage(response)
            End Sub)
        args.request = request
        RaiseEvent SessionRequest(Me, args)
    End Sub
#End Region

#Region "Callback Methods"

    'Adds response callback delegates to callback list
    Private Sub AddCallback(callback As [Delegate], msg As MessageBase)
        If callback IsNot Nothing Then
            Dim callbackID As Guid = Guid.NewGuid()
            Dim responseCallback As New ResponseCallbackObject()
            responseCallback.ID = callbackID
            responseCallback.callback = callback

            msg.callbackID = callbackID
            callBacks.Add(responseCallback)
        End If
    End Sub

    'Find response callback and invokes it
    Public Sub InvokeMessageCallBack(msg As MessageBase, deleteMessage As Boolean)
        Dim callBackObject = callBacks.SingleOrDefault(Function(x) x.ID = msg.callbackID)
        If callBackObject IsNot Nothing Then
            If deleteMessage Then
                callBacks.Remove(callBackObject)
            End If
            callBackObject.callback.DynamicInvoke(Me, msg)
        End If
    End Sub

#End Region
End Class
