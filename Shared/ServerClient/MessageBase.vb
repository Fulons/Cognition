Imports System.Runtime.Serialization.Formatters.Binary

Public Class FileHelper
    Public Shared Function SampleBytesFromFile(filepath As String, currentPosition As Integer, bufferSize As Integer) As Byte()
        Dim length As Integer = bufferSize
        Dim fs As New System.IO.FileStream(filepath, System.IO.FileMode.Open)
        fs.Position = currentPosition

        If currentPosition + length > fs.Length Then
            length = length - currentPosition
        End If

        Dim b(length) As Byte
        fs.Read(b, 0, length)
        fs.Dispose()
        Return b
    End Function

    Public Shared Sub AppendAllBytes(filepath As String, bytes() As Byte)
        Dim fs As New System.IO.FileStream(filepath, System.IO.FileMode.Append, System.IO.FileAccess.Write)
        fs.Write(bytes, 0, bytes.Length)
        fs.Dispose()
    End Sub
End Class

Public Class AllowAllAssemblyVersionsDeserializationBinder : Inherits System.Runtime.Serialization.SerializationBinder
    Public Overrides Function BindToType(assemblyName As String, typeName As String) As Type
        Dim typeToDeserialize = Nothing
        Dim currentAssembly = System.Reflection.Assembly.GetExecutingAssembly().FullName

        assemblyName = currentAssembly
        typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName))
        Return typeToDeserialize
    End Function
End Class

'Used to store callbacks for responses
Public Class ResponseCallbackObject
    Public callback As [Delegate]
    Public ID As Guid
End Class

Public Enum StatusEnum
    Disconnected
    Connected
    Validated
    InSession
End Enum

Public Class FileUploadProgressEventArguments
    Public Property destinationPath As String
    Public Property fileName As String
    Public Property currentPosition As Integer
    Public Property TotalBytes As Long
End Class

<Serializable()>
Public Class MessageBase
    Public Property callbackID As Guid
    Public Property hasError As Boolean
    Public Property exception As Exception

    Public Sub New()
        exception = New Exception
    End Sub
End Class

#Region "Request message classes"
<Serializable()>
Public Class RequestMessageBase : Inherits MessageBase

End Class

<Serializable()>
Public Class GenericRequest : Inherits RequestMessageBase
    Public Property innerMessage As IO.MemoryStream

    Public Sub New()
        innerMessage = New IO.MemoryStream
    End Sub

    Public Sub New(request As RequestMessageBase)
        Me.New()
        Dim f As New BinaryFormatter
        f.Serialize(innerMessage, request)
        innerMessage.Position = 0
    End Sub

    Public Function ExtractInnerMessage() As GenericRequest
        Dim f As New BinaryFormatter
        f.Binder = New AllowAllAssemblyVersionsDeserializationBinder()
        Return f.Deserialize(innerMessage)
    End Function
End Class

<Serializable()>
Public Class ValidationRequest : Inherits RequestMessageBase
    Public Property username As String
    Public Property password As String
End Class

<Serializable()>
Public Class EndSessionRequest : Inherits RequestMessageBase
End Class

<Serializable()>
Public Class FileUploadRequest : Inherits RequestMessageBase
    Public Property fileName As String
    Public Property totalBytes As Long
    Public Property currentPosition As Integer
    Public Property sourceFilePath As String
    Public Property destinationFilePath As String
    Public Property bytesToWrite As Byte()
    Public Property bufferSize As Integer

    Public Sub New()
        bufferSize = 1024
    End Sub

    Public Sub New(response As FileUploadResponse)
        Me.New()
        callbackID = response.callbackID
        fileName = response.fileName
        totalBytes = response.totalBytes
        currentPosition = response.currentPosition
        sourceFilePath = response.sourceFilePath
        destinationFilePath = response.destinationFilePath
    End Sub
End Class

<Serializable()>
Public Class TextMessageRequest : Inherits RequestMessageBase
    Public message As String
End Class

<Serializable()>
Public Class SessionRequest : Inherits RequestMessageBase
    Public username As String
End Class

<Serializable()>
Public Class DisconnectRequest : Inherits RequestMessageBase

End Class

<Serializable()>
Public Class PublicMessageRequest : Inherits RequestMessageBase
    Public message As String
    Public username As String
End Class

<Serializable()>
Public Class UserListUpdatedRequest : Inherits RequestMessageBase
    Public list() As String
End Class
#End Region

#Region "Response message classes"
<Serializable()>
Public Class ResponseMessageBase : Inherits MessageBase
    Public Property DeleteCallBackAfterInvoke As Boolean
    Public Sub New(request As RequestMessageBase)
        DeleteCallBackAfterInvoke = True
        callbackID = request.callbackID
    End Sub
End Class

<Serializable()>
Public Class ValidationResponse : Inherits ResponseMessageBase
    Public isValid As Boolean
    Public Sub New(request As ValidationRequest)
        MyBase.New(request)
    End Sub
End Class

<Serializable()>
Public Class FileUploadResponse : Inherits ResponseMessageBase
    Public Sub New(request As FileUploadRequest)
        MyBase.New(request)
        fileName = request.fileName
        totalBytes = request.totalBytes
        currentPosition = request.currentPosition
        sourceFilePath = request.sourceFilePath
        destinationFilePath = request.destinationFilePath
        DeleteCallBackAfterInvoke = False
    End Sub

    Public Property fileName As String
    Public Property totalBytes As Long
    Public Property currentPosition As Integer
    Public Property sourceFilePath As String
    Public Property destinationFilePath As String
End Class

<Serializable()>
Public Class SessionResponse : Inherits ResponseMessageBase
    Public isConfirmed As Boolean
    Public username As String
    Public Sub New(request As SessionRequest)
        MyBase.New(request)
    End Sub
End Class

<Serializable()>
Public Class EndSessionResponse : Inherits ResponseMessageBase
    Public Sub New(request As EndSessionRequest)
        MyBase.New(request)
    End Sub
End Class
#End Region



