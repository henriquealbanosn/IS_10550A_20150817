Imports System.Runtime.CompilerServices
Imports System.Text

Public Module Extensions
    <Extension()>
    Public Function ToBinaryString(ByVal i As Long) As String
        Dim remainder As Long = 0
        Dim binary As New StringBuilder("")

        While i > 0
            remainder = i Mod 2
            i = i \ 2
            binary.Insert(0, remainder)
        End While

        Return binary.ToString()
    End Function
End Module
