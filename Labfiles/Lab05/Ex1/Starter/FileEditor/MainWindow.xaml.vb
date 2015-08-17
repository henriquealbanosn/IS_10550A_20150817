Class MainWindow
    ''' <summary>
    ''' Name of file in use
    ''' </summary>
    ''' <remarks></remarks>
    Private fileName As String = String.Empty

    ''' <summary>
    ''' Open the file after the user has been prompted for the file name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' TODO: - Update the OpenButton_Click method
        ' Call GetFileName to get the name of the file to load            

        ' Populate the editor TextBox with the file contents
    End Sub

    ' TODO: - Implement a method to get the file name
    ' Add a GetFileName method

    ' Save the data back to the file
    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' TODO: - Update the SaveButton_Click method
        ' Write the contents of the editor TextBox back to the file
    End Sub
End Class
