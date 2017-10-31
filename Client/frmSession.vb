Public Class frmSession
    Public username As String = ""

    Delegate Sub AddChatMessageDelegate(user As String, msg As String)
    Public Sub AddChatMessage(user As String, msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New AddChatMessageDelegate(AddressOf AddChatMessage), New Object() {user, msg})
            Return
        End If
        rtxtChat.SelectionColor = Color.DarkBlue
        rtxtChat.AppendText(user + ": ")
        rtxtChat.SelectionColor = Color.Black
        rtxtChat.AppendText(msg)
    End Sub

    Private Sub SendMessage()
        If Not String.IsNullOrEmpty(txtMessageInput.Text) Then
            frmClient.client.SendTextMessage(txtMessageInput.Text)
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        SendMessage()
    End Sub

    Private Sub txtMessageInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessageInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendMessage()
            e.Handled = True
        End If
    End Sub
End Class