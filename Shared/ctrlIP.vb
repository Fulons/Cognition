Public Class ctrlIP

    Public Function GetIPString() As String
        Dim ret As String = ""
        ret = ret + txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text + ":" + txtPort.Text
        Return ret
    End Function

    Private Sub txt_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtIP1.KeyDown, txtIP2.KeyDown, txtIP3.KeyDown, txtIP4.KeyDown, txtPort.KeyDown
        If Asc(e.KeyCode) > 47 AndAlso Asc(e.KeyCode) < 58 Then
            Dim ipTxtBox As Windows.Forms.TextBox = CType(sender, Windows.Forms.TextBox)
        End If
        e.Handled = True
    End Sub
End Class
