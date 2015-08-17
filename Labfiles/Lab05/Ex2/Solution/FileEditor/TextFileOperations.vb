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

    ' Add a method to read the contents of a file, replacing special XML characters
    ' with their entities ( & becomes &amp; etc)
    Public Shared Function ReadAndFilterTextFileContents(ByVal fileName As String) As String
        Dim fileContents As New StringBuilder()
        Dim charCode As Integer

        Dim fileReader As New StreamReader(fileName)

        charCode = fileReader.Read()
        While charCode <> -1
            Select Case charCode
                Case 34 ' "
                    fileContents.Append("&quot;")
                Case 38 ' &
                    fileContents.Append("&amp;")
                Case 39 ' '
                    fileContents.Append("&apos;")
                Case 60 ' <
                    fileContents.Append("&lt;")
                Case 62 ' >
                    fileContents.Append("&gt;")
                Case Else
                    fileContents.Append(CType(ChrW(charCode), Char))
            End Select

            charCode = fileReader.Read()
        End While

        Return fileContents.ToString()
    End Function

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
