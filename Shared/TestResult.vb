<Serializable()>
Public Class TestResult
    Public testDate As DateTime
    Public tasks As New List(Of Task)

    Public Sub New()
        testDate = DateTime.Now
    End Sub

    Public Sub AddTask(taskNum As Integer, score As Integer)
        tasks.Add(New Task(taskNum, score))
    End Sub

    <Serializable()>
    Public Class Task
        Public taskNum As Integer
        Public score As Integer
        Public Sub New(taskNum As Integer, score As Integer)
            Me.taskNum = taskNum
            Me.score = score
        End Sub
    End Class
End Class
