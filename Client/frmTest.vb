Public Class frmTest

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tstTest.Setup()
    End Sub

    'Test user control done event
    Private Sub testDone(result As [Shared].TestResult) Handles tstTest.Done
        frmClient.SendTestResult(result)
    End Sub
End Class