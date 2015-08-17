Class MainWindow
    ''' <summary>
    ''' Do the GCD calculations
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FindGCDButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim thirdNumber As Integer
        Dim fourthNumber As Integer
        Dim fifthNumber As Integer

        If Not GetPostiveIntegerFromTextBox(integer1, firstNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer2, secondNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer3, thirdNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer4, fourthNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer5, fifthNumber) Then Return

        If sender Is FindGCDButton Then ' Euclid for two integers
            Me.ResultEuclidLabel.Content =
                String.Format("Euclid: {0}",
                GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber))
            ' Call the overloaded methods for 3, 4 and 5 integers
        ElseIf sender Is FindGCD3Button Then ' Euclid for three integers
            Me.ResultEuclidLabel.Content =
                String.Format("Euclid: {0}",
                GCDAlgorithms.FindGCDEuclid(
                firstNumber,
                secondNumber,
                thirdNumber))
            Me.ResultSteinLabel.Content = "N/A"
        ElseIf sender Is FindGCD4Button Then ' Euclid for four integers
            Me.ResultEuclidLabel.Content =
                String.Format("Euclid: {0}",
                GCDAlgorithms.FindGCDEuclid(
                firstNumber, secondNumber, thirdNumber, fourthNumber))
            Me.ResultSteinLabel.Content = "N/A"
        ElseIf sender Is FindGCD5Button Then ' Euclid for five integers
            Me.ResultEuclidLabel.Content =
                String.Format("Euclid: {0}",
                GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber,
                thirdNumber, fourthNumber, fifthNumber))

            Me.ResultSteinLabel.Content = "N/A"
        End If
    End Sub

    ''' <summary>
    ''' Read a postive integer from a TextBox
    ''' Displays a message box with the data if the text can't be parsed.
    ''' </summary>
    ''' <param name="inputTextBox">TextBox to read</param>
    ''' <param name="i">Postive integer (out parameter)</param>
    ''' <returns>True if success, false otherwise</returns>
    Private Function GetPostiveIntegerFromTextBox(ByVal inputTextBox As TextBox, ByRef i As Integer) As Boolean
        i = -1

        If Integer.TryParse(inputTextBox.Text, i) Then
            If i >= 0 Then Return True
        End If

        MessageBox.Show("Not a positive integer value: " & inputTextBox.Text)

        Return False
    End Function
End Class
