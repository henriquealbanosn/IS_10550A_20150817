Imports System.Text
Imports StressTest

Class MainWindow
    ''' <summary>
    ''' Display the enumeration values in ListBoxes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        Dim materialsList() As Material = CType(System.Enum.GetValues(GetType(Material)), Material())

        For i As Integer = 0 To materialsList.Length - 1
            MaterialsListBox.Items.Add(materialsList(i))
        Next

        Dim crossSectionList() As CrossSection = CType(System.Enum.GetValues(GetType(CrossSection)), CrossSection())
        For i As Integer = 0 To crossSectionList.Length - 1
            CrossSectionsListBox.Items.Add(crossSectionList(i))
        Next

        Dim testResultsList() As TestResult = CType(System.Enum.GetValues(GetType(TestResult)), TestResult())
        For i As Integer = 0 To testResultsList.Length - 1
            TestResultsListBox.Items.Add(testResultsList(i))
        Next

        MaterialsListBox.SelectedIndex = 0
        CrossSectionsListBox.SelectedIndex = 0
        TestResultsListBox.SelectedIndex = 0
    End Sub

    Private Sub ListBox_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
        If MaterialsListBox.SelectedIndex = -1 OrElse CrossSectionsListBox.SelectedIndex = -1 OrElse TestResultsListBox.SelectedIndex = -1 Then Return

        ' TODO: - Retrieve user selections from the UI.
    End Sub
End Class
