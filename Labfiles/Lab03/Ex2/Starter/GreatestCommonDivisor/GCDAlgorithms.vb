Public Class GCDAlgorithms
    ''' <summary>
    ''' Find the lowest common divisor of two numbers using Euclid's Algorithm
    ''' see: http://en.wikipedia.org/wiki/Euclidean_algorithm
    ''' </summary>
    ''' <param name="a">First number</param>
    ''' <param name="b">Second number</param>
    ''' <returns>Lowest common divisor</returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer) As Integer
        ' If the first number is zero, return the second
        If a = 0 Then Return b

        ' Calculate the LCD
        While b <> 0
            If a > b Then
                a = a - b
            Else
                b = b - a
            End If
        End While

        Return a
    End Function

    ' TODO: Exercise 2, Task 2
    ' Add overloaded methods for 3,4, and 5 integers
End Class