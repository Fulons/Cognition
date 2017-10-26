Public Class ctrlXMLDBConnection
    Public Function GetConnectionString() As String
        Return txtFilePath.Text
    End Function

    Private Sub btnFileDialog_Click(sender As Object, e As EventArgs) Handles btnFileDialog.Click
        OpenFileDialog.InitialDirectory = txtFilePath.Text
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFilePath.Text = OpenFileDialog.FileName
        End If
    End Sub

End Class
