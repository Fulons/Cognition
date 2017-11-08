Public Class frmTest
    'Initialises the test
    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tstTest.Setup()
    End Sub

    'Test user control done event
    Private Sub testDone(result As [Shared].TestResult) Handles tstTest.Done
        frmClient.SendTestResult(result)
    End Sub

    Private Sub frmTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tstTest.Setup()
    End Sub
End Class