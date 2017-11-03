Public Class frmSession
    Public username As String = ""

    'Adds chat message to the text box
    Delegate Sub AddChatMessageDelegate(user As String, msg As String)
    Public Sub AddChatMessage(user As String, msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddChatMessageDelegate(AddressOf AddChatMessage), New Object() {user, msg})
            Return
        End If
        rtxtChat.SelectionColor = Color.DarkBlue
        rtxtChat.AppendText(user + ": ")
        rtxtChat.SelectionColor = Color.Black
        rtxtChat.AppendText(msg + vbNewLine)
    End Sub

    'Sends a message if there is text in the message input field
    Private Sub SendMessage()
        If Not String.IsNullOrEmpty(txtMessageInput.Text) Then
            frmClient.client.SendTextMessage(txtMessageInput.Text)
            AddChatMessage("Me", txtMessageInput.Text)
            txtMessageInput.Text = ""
        End If
    End Sub

    'Handle for send button click event
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        SendMessage()
    End Sub

    'Sends the message upon pressing Enter
    Private Sub txtMessageInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessageInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendMessage()
            e.Handled = True
        End If
    End Sub

    'If session window is closed by user it will send a seesion end message to remote client 
    Private Sub frmSession_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If e.CloseReason = CloseReason.UserClosing Then
            frmClient.client.EndCurrentSession(Sub(c, r)    'Empty lambda function as end session response is not in use yet
                                               End Sub)
        End If
    End Sub
End Class