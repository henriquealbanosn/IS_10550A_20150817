Imports System.Text
Imports System.IO

''' <summary>
''' Perform IO operations on text files
''' </summary>
''' <remarks></remarks>
Public Class TextFileOperations
    ''' <summary>
    ''' Read contents of a text file
    ''' </summary>
    ''' <param name="fileName">Full file name including path</param>
    ''' <returns>File contents</returns>
    ''' <remarks></remarks>
    Public Shared Function ReadTextFileContents(ByVal filename As String) As String
        Return File.ReadAllText(filename)
    End Function

    ' TODO: - Implement a new method in the TextFileOperations class
    ' Add a method to read the contents of a file, replacing special XML characters
    ' with their entities ( & becomes &amp; etc)

    ''' <summary>
    ''' Write to a text file
    ''' </summary>
    ''' <param name="fileName">Full file name including path</param>
    ''' <param name="text">Text to write to file</param>
    ''' <remarks></remarks>
    Public Shared Sub WriteTextFileContents(ByVal fileName As String, ByVal text As String)
        File.WriteAllText(fileName, text)
    End Sub
End Class
