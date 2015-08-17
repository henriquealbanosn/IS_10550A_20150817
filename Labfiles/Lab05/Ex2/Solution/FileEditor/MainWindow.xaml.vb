Imports Microsoft.Win32

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
        ' Call GetFileName to get the name of the file to load            
        fileName = GetFileName()

        ' Populate the editor TextBox with the file contents
        If fileName <> String.Empty Then
            ' Call the new read file contents method
            editor.Text =
                TextFileOperations.ReadAndFilterTextFileContents(fileName)
        End If
    End Sub

    ''' <summary>
    ''' Use the common dialog to get a valid file name.
    ''' Filtering for .txt.
    ''' Starting in predefined location.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetFileName() As String
        ' Initialize the filename
        Dim fName As String = String.Empty

        ' Configure open file dialog box
        Dim openFileDlg As New OpenFileDialog()

        openFileDlg.InitialDirectory = "D:\Labfiles\Lab05\Ex2\Starter"
        openFileDlg.DefaultExt = ".txt" ' Default file extension
        openFileDlg.Filter = "Text Documents (.txt)|*.txt" ' Filter files by extension

        ' Show open file dialog box
        Dim result As Boolean = openFileDlg.ShowDialog()

        ' Process open file dialog box results
        If result Then fName = openFileDlg.FileName

        Return fName
    End Function

    ' Save the data back to the file
    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Write the contents of the editor TextBox back to the file
        If fileName <> String.Empty Then
            TextFileOperations.WriteTextFileContents(fileName, editor.Text)
        End If
    End Sub
End Class
