Imports System.IO

Public Class TextFileOperations
    Public Shared Function ReadTextFileContents(ByVal filename As String) As String
        Return File.ReadAllText(filename)
    End Function

    Public Shared Sub WriteTextFileContents(ByVal fileName As String, ByVal text As String)
        File.WriteAllText(fileName, text)
    End Sub
End Class
