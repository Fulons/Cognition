Public Class frmClientLogin

    'Shuts down the form if user cli
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    'Try connect the user to the server
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If frmClient.client.Connect(ccIP.GetIPString, ccIP.GetPort) = True Then
            Me.Hide()
            frmClient.tmrConnectionTimeout.Start()      'Starts the login timeout timer
            frmClient.userName = txtUsername.Text
            frmClient.client.Login(txtUsername.Text, txtPassword.Text,
                                   Sub(SenderClient, response)                  'Lambda function to be called upon response from server
                                       If response.isValid Then                 'If login is accepted
                                           frmClient.client.status = [Shared].StatusEnum.Connected
                                           frmClient.mnuLogin.Enabled = False
                                           frmClient.mnuLogout.Enabled = True
                                           frmClient.tmrConnectionTimeout.Stop()
                                           frmClient.mnuTest1.Enabled = True
                                           MessageBox.Show("Login success!")
                                       Else                                     'If login is not accepted
                                           frmClient.userName = ""
                                           frmClient.mnuLogin.Enabled = True
                                           frmClient.mnuLogout.Enabled = False
                                           frmClient.tmrConnectionTimeout.Stop()
                                           MessageBox.Show("Login failed! Please assure that username and password is typed in correctly")
                                       End If
                                   End Sub)
        End If
    End Sub
End Class