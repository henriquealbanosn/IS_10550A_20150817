Imports System.Text
Imports StressTest
Imports StressTest.StressTestTypes

Class MainWindow
    ' TODO: - Declare a TestCaseResult array

    ''' <summary>
    ''' Create some sample Test Case Results and display
    ''' in a ListBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>       
    ''' <remarks></remarks>
    Private Sub RunTestsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ReasonsListBox.Items.Clear()

        ' Fill the array with 10 TestCaseResult objects.

        Dim passCount As Integer = 0
        Dim failCount As Integer = 0

        ' TODO: - Display the TestCaseResult data.

        SuccessLabel.Content = "Successes: " & passCount
        FailureLabel.Content = "Failures: " & failCount
    End Sub
End Class
