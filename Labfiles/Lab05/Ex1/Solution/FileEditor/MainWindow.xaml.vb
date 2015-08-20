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
            editor.Text =
                TextFileOperations.ReadTextFileContents(fileName)
        End If
    End Sub

    ' Add a GetFileName method
    Private Function GetFileName() As String
        Dim fName As String = String.Empty

        Dim openFileDlg As New OpenFileDialog()

        openFileDlg.InitialDirectory =
            "D:\Treinamentos\IS_10550A_20150817\Labfiles\Lab05\Ex1\Starter"

        openFileDlg.DefaultExt = ".txt"
        openFileDlg.Filter = "Text Documents (.txt)|*.txt"

        Dim result As Boolean = openFileDlg.ShowDialog()

        If result Then fName = openFileDlg.FileName

        Return fName
    End Function

    ' Save the data back to the file
    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Write the contents of the editor TextBox back to the file
        If fileName <> String.Empty Then
            TextFileOperations.WriteTextFileContents(fileName,
                editor.Text)
        End If
    End Sub
End Class
