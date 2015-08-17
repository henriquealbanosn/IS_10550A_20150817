''' <summary>
''' WPF application to read and format data
''' </summary>
''' <remarks></remarks>
Class MainWindow
    ''' <summary>
    ''' Read a line of data entered by the user.
    ''' Format the data and display the results in the 
    ''' FormattedTextTextBlock control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TestButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TestButton.Click
        ' Copy the contents of the TextBox into a string
        Dim line As String = TestTextBox.Text

        ' Format the data in the string
        line = line.Replace(",", " y:")
        line = "x:" + line

        ' Store the results in the TextBlock
        FormattedTextTextBlock.Text = line
    End Sub

    ''' <summary>
    ''' After the Window has loaded, read data from the standard input. 
    ''' Format each line and display the results in the
    ''' FormattedTextTextBlock control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Buffer to hold a line read from the file on standard input
        Dim line As String

        line = Console.ReadLine()
        ' Loop until the end of the file
        While Not line Is Nothing
            ' Format the data in the buffer
            line = line.Replace(",", " y:")
            line = "x:" & line & vbNewLine
            ' Put the results into the TextBlock
            FormattedTextTextBlock.Text &= line

            line = Console.ReadLine()
        End While
    End Sub
End Class
