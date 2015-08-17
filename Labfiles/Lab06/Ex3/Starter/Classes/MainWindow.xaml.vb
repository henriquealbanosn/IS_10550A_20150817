Imports System.Text
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
        TestListBox.Items.Clear()
        ResultListBox.Items.Clear()

        ' TODO: - Iterate through the StressTestCase samples displaying the results.
    End Sub

    ' TODO: - Create an array of sample StressTestCase objects.
End Class