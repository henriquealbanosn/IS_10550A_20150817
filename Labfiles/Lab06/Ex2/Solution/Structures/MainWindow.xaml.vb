Imports System.Text
Imports StressTest.StressTestTypes
Imports StressTest

Class MainWindow
    Private results() As TestCaseResult

    ''' <summary>
    ''' Create some sample Test Case Results and display
    ''' in a ListBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>       
    ''' <remarks></remarks>
    Private Sub RunTestsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ReasonsListBox.Items.Clear()
        ReDim results(10)

        ' Fill the array with 10 TestCaseResult objects.
        For i As Integer = 0 To results.Length - 1
            results(i) = TestManager.GenerateResult()
        Next

        Dim passCount As Integer = 0
        Dim failCount As Integer = 0

        For i As Integer = 0 To results.Length - 1
            If results(i).Result = TestResult.Pass Then
                passCount += 1
            Else
                failCount += 1
                ReasonsListBox.Items.Add(results(i).ReasonForFailure)
            End If
        Next

        SuccessLabel.Content = "Successes: " & passCount
        FailureLabel.Content = "Failures: " & failCount
    End Sub
End Class
