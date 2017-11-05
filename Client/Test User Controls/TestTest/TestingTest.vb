Public Class TestingTest

    Private labels(11) As Label
    Private buttons(11) As Button
    Private numbersLeft As New List(Of Integer)
    Private currentNumbersLeftIndex As Integer = 0
    Private numClockMakingErrors As Integer = 0

    Private address1Correct As Boolean = False
    Private address2Correct As Boolean = False
    Private address3Correct As Boolean = False

    Private dayCorrect As Boolean = False
    Private monthCorrect As Boolean = False
    Private yearCorrect As Boolean = False

    Private currentTest As Integer = 1

    Private clockTaskErrors As Integer = 0
    Private addressTaskScore As Integer = 0

    Public Event Done(results As [Shared].TestResult)

    'Initilises the tests, should be called upon opening the parent form
    Public Sub Setup()
        'Initialise containers and visibility of controls for clock task
        labels(0) = lblDigit1
        labels(1) = lblDigit2
        labels(2) = lblDigit3
        labels(3) = lblDigit4
        labels(4) = lblDigit5
        labels(5) = lblDigit6
        labels(6) = lblDigit7
        labels(7) = lblDigit8
        labels(8) = lblDigit9
        labels(9) = lblDigitA
        labels(10) = lblDigitB
        labels(11) = lblDigitC

        For Each lbl In labels
            lbl.Hide()
        Next

        buttons(0) = btnDigit1
        buttons(1) = btnDigit2
        buttons(2) = btnDigit3
        buttons(3) = btnDigit4
        buttons(4) = btnDigit5
        buttons(5) = btnDigit6
        buttons(6) = btnDigit7
        buttons(7) = btnDigit8
        buttons(8) = btnDigit9
        buttons(9) = btnDigitA
        buttons(10) = btnDigitB
        buttons(11) = btnDigitC

        For i As Integer = 1 To 12
            numbersLeft.Add(i)
        Next

        'Init randomisation for clock task
        Randomize()
        currentNumbersLeftIndex = Math.Floor(Rnd() * (numbersLeft.Count() - 1))
        lblCurrentNumber.Text = numbersLeft(currentNumbersLeftIndex).ToString()

        'Hide buttons from panel1 that is used only in task 4
        btnHint1.Hide()
        btnHint2.Hide()
        btnHint3.Hide()

        btnFinish.Hide()
        btnFinish.Enabled = False

        'Hide every panel except first task panel
        pnlPage2.Hide()
        pnlPage3.Hide()
    End Sub

#Region "Clock task (3)"
    'The whole of task 3 is handled by this event handler
    'By utilising the containers created on setup
    Private Sub btnDigit1_Click(sender As Object, e As EventArgs) Handles btnDigit1.Click, btnDigit2.Click, btnDigit3.Click,
                                                                          btnDigit4.Click, btnDigit5.Click, btnDigit6.Click,
                                                                          btnDigit7.Click, btnDigit8.Click, btnDigit9.Click,
                                                                          btnDigitA.Click, btnDigitB.Click, btnDigitC.Click
        Dim btn As Button = CType(sender, Button)                   'Button that was pressed
        Dim btnIndex As Integer = Array.IndexOf(buttons, btn)       'Index of the buttons array of the button that was pressed
        Dim clickedIndex As Integer = (lblCurrentNumber.Text) - 1   'Index of the label array of the correct label
        If btnIndex = (numbersLeft(currentNumbersLeftIndex) - 1) Then   'Checks if button has the same index as the label in their respective arrays
            labels(clickedIndex).Show()
            btn.Hide()
            numbersLeft.RemoveAt(currentNumbersLeftIndex)
            If numbersLeft.Count() > 0 Then     'Pick a new number
                currentNumbersLeftIndex = Math.Floor(Rnd() * (numbersLeft.Count() - 1))
                lblCurrentNumber.Text = numbersLeft(currentNumbersLeftIndex).ToString()
            Else                                'Complete
                lblCurrentNumber.Hide()
                MessageBox.Show("Complete!")
                pnlPage3.Hide()
                startTask4()
            End If
        Else                                    'Incorrect guess
            MessageBox.Show("Please try again", "Inncorrect")
            numClockMakingErrors += 1
        End If
    End Sub
#End Region

#Region "Address task (1&4)"
    'Initilises panel1 for task 4
    Private Sub startTask4()
        lblAddress1.Hide()
        lblAddress2.Hide()
        lblAddress3.Hide()
        btnFinish.Show()
        lblTask1Description1.Text = "Please enter the address from the first task"
        lblTask1Description2.Text = "and press finish when done."
        txtAdress1.Text = ""
        txtAdress2.Text = ""
        txtAdress3.Text = ""
        txtAdress1.ReadOnly = False
        txtAdress2.ReadOnly = False
        txtAdress3.ReadOnly = False
        pnlPage1.Show()
        tmrAddress.Start()
    End Sub

    '1 minute timer before hints are available
    Private Sub tmrAddress_Tick(sender As Object, e As EventArgs) Handles tmrAddress.Tick
        btnHint1.Show()
        btnHint2.Show()
        btnHint3.Show()
        tmrAddress.Stop()
    End Sub

    'Helper fucntion to check if address task is complete and to trigger next part of the test
    Private Sub CheckAdressCompleted()
        If address1Correct And address2Correct And address3Correct Then
            pnlPage1.Hide()
            pnlPage2.Show()
            If currentTest = 1 Then
                currentTest = 2
            ElseIf currentTest = 4 Then
                btnFinish.Enabled = True
            End If
        End If
    End Sub

    'Name address field handler
    'Check if the field is correct
    Private Sub txtAdress1_TextChanged(sender As Object, e As EventArgs) Handles txtAdress1.TextChanged
        Dim input As String = txtAdress1.Text.Replace(" ", "")
        Dim addr As String = lblAddress1.Text.Replace(" ", "")
        If input.ToLower = addr.ToLower Then
            address1Correct = True
            txtAdress1.ReadOnly = True
            CheckAdressCompleted()
        Else
            address1Correct = False
        End If
    End Sub

    'Street address field handler
    'Check if the field is correct
    Private Sub txtAdress2_TextChanged(sender As Object, e As EventArgs) Handles txtAdress2.TextChanged
        Dim input As String = txtAdress2.Text.Replace(" ", "")
        Dim addr As String = lblAddress2.Text.Replace(" ", "")
        If input.ToLower = addr.ToLower Then
            address2Correct = True
            txtAdress2.ReadOnly = True
            CheckAdressCompleted()
        Else
            address2Correct = False
        End If
    End Sub

    'Town address field handler
    'Check if the field is correct
    Private Sub txtAdress3_TextChanged(sender As Object, e As EventArgs) Handles txtAdress3.TextChanged
        Dim input As String = txtAdress3.Text.Replace(" ", "")
        Dim addr As String = lblAddress3.Text.Replace(" ", "")
        If input.ToLower = addr.ToLower Then
            address3Correct = True
            txtAdress3.ReadOnly = True
            CheckAdressCompleted()
        Else
            address3Correct = False
        End If
    End Sub

    'Address hint containers and variables
    Dim address1Hints() As String = {"Brown", "John"}
    Dim address1HintsUsed As Integer = 0
    Dim address2Hints() As String = {"42", "West", "Street"}
    Dim address2HintsUsed As Integer = 0
    Dim address3Hints() As String = {"Ken", "Kensing", "Kensingtonw"}
    Dim address3HintsUsed As Integer = 0

    'Display incremental revealing hints every time hint button is clicked
    Private Sub btnHint1_Click(sender As Object, e As EventArgs) Handles btnHint1.Click
        address1HintsUsed += 1
        Dim hintString As String = ""
        If address1HintsUsed >= address1Hints.Count() Then
            For Each str As String In address1Hints
                hintString += str + " "
            Next
        Else
            For i As Integer = 0 To (address1HintsUsed - 1)
                hintString += address1Hints(i) + " "
            Next
        End If
        MessageBox.Show(hintString, "Hint " + address1HintsUsed.ToString)
    End Sub

    'Display incremental revealing hints every time hint button is clicked
    Private Sub btnHint2_Click(sender As Object, e As EventArgs) Handles btnHint2.Click
        address2HintsUsed += 1
        Dim hintString As String = ""
        If address2HintsUsed >= address2Hints.Count() Then
            For Each str As String In address2Hints
                hintString += str + " "
            Next
        Else
            For i As Integer = 0 To (address2HintsUsed - 1)
                hintString += address2Hints(i) + " "
            Next
        End If
        MessageBox.Show(hintString, "Hint " + address2HintsUsed.ToString)
    End Sub

    'Display incremental revealing hints every time hint button is clicked
    Private Sub btnHint3_Click(sender As Object, e As EventArgs) Handles btnHint3.Click
        address3HintsUsed += 1
        Dim hintString As String = ""
        If address3HintsUsed >= address3Hints.Count() Then
            hintString = address3Hints.Last
        Else
            hintString = address3Hints(address1HintsUsed - 1)
        End If
        MessageBox.Show(hintString, "Hint " + address3HintsUsed.ToString)
    End Sub

    'Only visible on task 4
    'Clicked when user is finished with task 4
    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click
        Dim results As New [Shared].TestResult
        results.AddTask(1, 0)
        results.AddTask(2, 0)
        results.AddTask(3, numClockMakingErrors)

        results.AddTask(4, address1HintsUsed)
        results.AddTask(5, address2HintsUsed)
        results.AddTask(6, address3HintsUsed)

        RaiseEvent Done(results)    'Raise event to be caught by parent form
    End Sub
#End Region

#Region "Date task (2)"
    'Helper fucntion to check if date task is complete and to trigger next part of the test
    Private Sub CheckDateComplete()
        If dayCorrect And monthCorrect And yearCorrect Then
            txtDateDay.ReadOnly = True
            txtDateMonth.ReadOnly = True
            txtDateYear.ReadOnly = True
            pnlPage2.Hide()
            pnlPage3.Show()
            currentTest = 3
        Else

        End If
    End Sub

    'Every time a date txt field is changed it is checked if it is correct and if it is next task is started
    Private Sub txtDateDay_TextChanged(sender As Object, e As EventArgs) Handles txtDateDay.TextChanged
        Dim inputDay As Integer
        Try
            inputDay = Convert.ToInt32(txtDateDay.Text)
        Catch ex As Exception
            Return
        End Try
        If inputDay = DateTime.Today.Day Then
            dayCorrect = True
            CheckDateComplete()
        Else
            dayCorrect = False
        End If
    End Sub

    'Every time a date txt field is changed it is checked if it is correct and if it is next task is started
    Private Sub txtDateMonth_TextChanged(sender As Object, e As EventArgs) Handles txtDateMonth.TextChanged
        Dim inputMonth As Integer
        Try
            inputMonth = Convert.ToInt32(txtDateMonth.Text)
        Catch ex As Exception
            Return
        End Try
        If inputMonth = DateTime.Today.Month Then
            monthCorrect = True
            CheckDateComplete()
        Else
            monthCorrect = False
        End If
    End Sub

    'Every time a date txt field is changed it is checked if it is correct and if it is next task is started
    Private Sub txtDateYear_TextChanged(sender As Object, e As EventArgs) Handles txtDateYear.TextChanged
        Dim inputYear As Integer
        Try
            inputYear = Convert.ToInt32(txtDateYear.Text)
        Catch ex As Exception
            Return
        End Try
        If inputYear = DateTime.Today.Year Then
            yearCorrect = True
            CheckDateComplete()
        Else
            yearCorrect = False
        End If
    End Sub

    'Ensures only numbers can be typed into the date fields
    Private Sub txtDateDay_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDateDay.KeyDown, txtDateMonth.KeyDown, txtDateYear.KeyDown
        If Asc(e.KeyCode) > 47 AndAlso Asc(e.KeyCode) < 58 Then
            Dim txtBox As Windows.Forms.TextBox = CType(sender, Windows.Forms.TextBox)
        End If
        e.Handled = True
    End Sub

    'Removes the default "DD-MM-YYYY" as the usere click into the text field
    Private Sub txtDateDay_Click(sender As Object, e As EventArgs) Handles txtDateDay.Click, txtDateMonth.Click, txtDateYear.Click
        Dim txtBox As TextBox = CType(sender, TextBox)
        If txtBox.Text = "DD" Or txtBox.Text = "MM" Or txtBox.Text = "YYYY" Then
            txtBox.Text = ""
        End If
    End Sub
#End Region


End Class
