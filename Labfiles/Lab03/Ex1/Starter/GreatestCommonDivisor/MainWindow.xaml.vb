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

        ' Display results 
        If sender Is FindGCDButton Then ' Euclid for two integers
            ' TODO: Exercise 1, Task 3
            ' Invoke the FindGCD method and display the result
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
