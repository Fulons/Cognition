Public Class ctrlAccessDBConnection

    Public Function GetConnectionString() As String
        Dim ret As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        If String.IsNullOrEmpty(txtPassword.Text) Then
            ret = ret + txtFilePath.Text + "; Persist Security Info=False;"
        Else
            ret = ret + txtFilePath.Text + ";Jet OleDb: Database Password=" + txtPassword.Text + ";"
        End If
        Return ret
    End Function

    Private Sub btnFileDialog_Click(sender As Object, e As EventArgs) Handles btnFileDialog.Click
        OpenFileDialog.InitialDirectory = txtFilePath.Text
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFilePath.Text = OpenFileDialog.FileName
        End If
    End Sub
End Class
