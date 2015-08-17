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
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByRef time As Long) As Long
        time = 0
        Dim sw As New Stopwatch()
        sw.Start()

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

        sw.Stop()
        time = sw.ElapsedTicks

        Return a
    End Function

    'Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer) As Integer
    '    Dim d As Integer = FindGCDEuclid(a, b)
    '    Dim e As Integer = FindGCDEuclid(d, c)

    '    Return e
    'End Function

    'Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer) As Integer
    '    Dim e As Integer = FindGCDEuclid(a, b, c)
    '    Dim f As Integer = FindGCDEuclid(e, d)

    '    Return f
    'End Function

    'Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer, ByVal e As Integer) As Integer
    '    Dim f As Integer = FindGCDEuclid(a, b, c, d)
    '    Dim g As Integer = FindGCDEuclid(f, e)

    '    Return g
    'End Function

    ' Implement Stein's Algorithm
    Public Shared Function FindGCDStein(ByVal u As Integer, ByVal v As Integer, ByRef time As Long) As Integer
        time = 0
        Dim sw = New Stopwatch()
        sw.Start()
        Dim k As Integer = 0

        ' Step 1.
        ' gcd(0, v) = v, because everything divides zero, 
        ' and v is the largest number that divides v. 
        ' Similarly, gcd(u, 0) = u. gcd(0, 0) is not typically 
        ' defined, but it is convenient to set gcd(0, 0) = 0.
        If u = 0 OrElse v = 0 Then
            sw.Stop()
            time = sw.ElapsedTicks
            Return u Or v
        End If

        ' Step 2.
        ' If u and v are both even, then gcd(u, v) = 2•gcd(u/2, v/2), 
        ' because 2 is a common divisor. 
        Do While ((u Or v) And 1) = 0
            u >>= 1
            v >>= 1
            k += 1
        Loop

        ' Step 3.
        ' If u is even and v is odd, then gcd(u, v) = gcd(u/2, v), 
        ' because 2 is not a common divisor. 
        ' Similarly, if u is odd and v is even, 
        ' then gcd(u, v) = gcd(u, v/2). 
        While (u And 1) = 0
            u >>= 1
        End While

        ' Step 4.
        ' If u and v are both odd, and u ≥ v, 
        ' then gcd(u, v) = gcd((u − v)/2, v). 
        ' If both are odd and u < v, then gcd(u, v) = gcd((v − u)/2, u). 
        ' These are combinations of one step of the simple 
        ' Euclidean algorithm, 
        ' which uses subtraction at each step, and an application 
        ' of step 3 above. 
        ' The division by 2 results in an integer because the 
        ' difference of two odd numbers is even.
        Do
            While (v And 1) = 0  ' Loop x
                v >>= 1
            End While

            ' Now u and v are both odd, so diff(u, v) is even.
            '   Let u = min(u, v), v = diff(u, v)/2. 
            If (u < v) Then
                v -= u
            Else
                Dim diff As Integer = u - v
                u = v
                v = diff
            End If
            v >>= 1
            ' Step 5.
            ' Repeat steps 3–4 until u = v, or (one more step) 
            ' until u = 0.
            ' In either case, the result is (2^k) * v, where k is 
            ' the number of common factors of 2 found in step 2. 
        Loop While v <> 0

        u <<= k

        sw.Stop()
        time = sw.ElapsedTicks

        Return u
    End Function
End Class