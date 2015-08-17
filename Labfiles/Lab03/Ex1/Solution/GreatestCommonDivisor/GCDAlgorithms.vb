Public Class GCDAlgorithms
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer) As Integer
        If a = 0 Then Return b

        While b <> 0
            If a > b Then
                a = a - b
            Else
                b = b - a
            End If
        End While

        Return a
    End Function
End Class