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

        Dim stressTestCases() As StressTestCase = CreateTestCases()
        Dim currentTestCase As StressTestCase
        Dim currentTestResult As TestCaseResult

        For i As Integer = 0 To stressTestCases.Length - 1
            currentTestCase = stressTestCases(i)
            currentTestCase.PerformStressTest()
            TestListBox.Items.Add(currentTestCase)
            currentTestResult = currentTestCase.GetStressTestResult()
            ResultListBox.Items.Add(currentTestResult.Result & " " &
                currentTestResult.ReasonForFailure)
        Next

    End Sub

    Private Function CreateTestCases() As StressTestCase()
        Dim stressTestCases(9) As StressTestCase

        stressTestCases(0) = New StressTestCase()
        stressTestCases(1) = New StressTestCase(Material.Composite, CrossSection.CShaped, 3500, 100, 20)
        stressTestCases(2) = New StressTestCase()
        stressTestCases(3) = New StressTestCase(Material.Aluminum, CrossSection.Box, 3500, 100, 20)
        stressTestCases(4) = New StressTestCase()
        stressTestCases(5) = New StressTestCase(Material.Titanium, CrossSection.CShaped, 3600, 150, 20)
        stressTestCases(6) = New StressTestCase(Material.Titanium, CrossSection.ZShaped, 4000, 80, 20)
        stressTestCases(7) = New StressTestCase(Material.Titanium, CrossSection.Box, 5000, 90, 20)
        stressTestCases(8) = New StressTestCase()
        stressTestCases(9) = New StressTestCase(Material.StainlessSteel, CrossSection.Box, 3500, 100, 20)

        Return stressTestCases
    End Function
End Class