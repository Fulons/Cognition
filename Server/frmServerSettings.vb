Public Class frmServerSettings

    Private Sub txtPort_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPort.KeyDown
        If Asc(e.KeyCode) > 47 AndAlso Asc(e.KeyCode) < 58 Then
            Dim ipTxtBox As TextBox = CType(sender, TextBox)
        End If
        e.Handled = True
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub frmServerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbDBType.SelectedIndex = 0
        txtPort.Text = "8888"
        ccSQLDBConnection.txtDatabase.Text = "UserData"
        ccSQLDBConnection.txtUsername.Text = "tmp"
        ccSQLDBConnection.txtPassword.Text = "tmp"

        ccAccessDBConnection.txtFilePath.Text = ccAccessDBConnection.OpenFileDialog.FileName

        ccSQLDBConnection.Show()
        ccAccessDBConnection.Hide()
        ccXMLDBConnection.Hide()
    End Sub

    Private Sub cbDBType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDBType.SelectedIndexChanged
        Select Case cbDBType.Text
            Case "MS SQL"
                ccSQLDBConnection.Show()
                ccAccessDBConnection.Hide()
                ccXMLDBConnection.Hide()
            Case "MS Access"
                ccSQLDBConnection.Hide()
                ccAccessDBConnection.Show()
                ccXMLDBConnection.Hide()
            Case "XML"
                ccSQLDBConnection.Hide()
                ccAccessDBConnection.Hide()
                ccXMLDBConnection.Show()

        End Select
    End Sub
End Class