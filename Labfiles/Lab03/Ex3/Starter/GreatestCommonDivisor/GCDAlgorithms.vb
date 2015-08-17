Public Class GCDAlgorithms
    ' TODO: Exercise 3, Task 3
    ' Modify all methods to return timing code

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

    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer) As Integer
        Dim d As Integer = FindGCDEuclid(a, b)
        Dim e As Integer = FindGCDEuclid(d, c)

        Return e
    End Function

    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer) As Integer
        Dim e As Integer = FindGCDEuclid(a, b, c)
        Dim f As Integer = FindGCDEuclid(e, d)

        Return f
    End Function

    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer, ByVal e As Integer) As Integer
        Dim f As Integer = FindGCDEuclid(a, b, c, d)
        Dim g As Integer = FindGCDEuclid(f, e)

        Return g
    End Function

    ' TODO: Exercise 3, Task 2
    ' Implement Stein's Algorithm

End Class