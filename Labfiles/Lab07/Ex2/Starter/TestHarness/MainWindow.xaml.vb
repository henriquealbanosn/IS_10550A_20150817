Imports System.Text
Imports StressTest

Class MainWindow
    ''' <summary>
    ''' Execute some stress tests on girders and show the results
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>       
    ''' <remarks></remarks>
    Private Sub RunStressTestsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        TestListBox.Items.Clear()
        ResultListBox.Items.Clear()

        Dim stressTestCases() As StressTestCase = CreateTestCases()
        Dim stc As StressTestCase
        Dim tcr As TestCaseResult

        For i As Integer = 0 To stressTestCases.Length - 1
            stc = stressTestCases(i)
            stc.PerformStressTest()

            TestListBox.Items.Add(stc.ToString())

            If stc.GetStressTestResult().HasValue Then
                tcr = CType(stc.GetStressTestResult().Value, TestCaseResult)
                ResultListBox.Items.Add(tcr.Result.ToString() & " " & tcr.ReasonForFailure)
            End If
        Next

        ' TODO: - Update the UI to display statistics. 
        ' Display the statistics, and illustrate by value passing behavior.
    End Sub

    ''' <summary>
    ''' Create some sample stress tests
    ''' </summary>
    ''' <returns>Array of Stress Test Cases</returns>
    ''' <remarks></remarks>
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