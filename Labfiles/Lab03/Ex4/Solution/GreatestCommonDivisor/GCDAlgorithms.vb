Public Class GCDAlgorithms
    ' Modify all methods to return timing code

    ''' <summary>
    ''' Find the lowest common divisor of two numbers using Euclid's Algorithm
    ''' see: http://en.wikipedia.org/wiki/Euclidean_algorithm
    ''' </summary>
    ''' <param name="a">First number</param>
    ''' <param name="b">Second number</param>
    ''' <param name="time">Output time taken (in ticks)</param>
    ''' <returns>Lowest common divisor</returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByRef time As Long) As Integer
        ' Initialize timing
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

        ' Stop the timer and record execution time
        sw.Stop()
        time = sw.ElapsedTicks

        Return a
    End Function

    ''' <summary>
    ''' Find the lowest common divisor of three numbers using Euclid's Algorithm
    ''' </summary>
    ''' <param name="a">First number</param>
    ''' <param name="b">Second number</param>
    ''' <param name="c">Third number</param>
    ''' <param name="time">Output time taken (in ticks)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByRef time As Long) As Integer
        ' Find the LCD of the first two numbers, then find the LCD of the result and the third
        Dim t1 As Long
        Dim d As Integer = FindGCDEuclid(a, b, t1)
        Dim t2 As Long
        Dim e As Integer = FindGCDEuclid(d, c, t2)
        time = t1 + t2

        Return e
    End Function

    ''' <summary>
    ''' Find the lowest common divisor of four numbers using Euclid's Algorithm
    ''' </summary>
    ''' <param name="a">First number</param>
    ''' <param name="b">Second number</param>
    ''' <param name="c">Third number</param>
    ''' <param name="d">Fourth number</param>
    ''' <param name="time">Output time taken (in ticks)</param>
    ''' <returns>Lowest common divisor</returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer, ByRef time As Long) As Integer
        ' Find the LCD of the first three numbers, then find the LCD of the result and the fourth
        Dim t1 As Long
        Dim e As Integer = FindGCDEuclid(a, b, c, t1)
        Dim t2 As Long
        Dim f As Integer = FindGCDEuclid(e, d, t2)
        time = t1 + t2

        Return f
    End Function

    ''' <summary>
    ''' Find the lowest common divisor of five numbers using Euclid's Algorithm
    ''' </summary>
    ''' <param name="a">First number</param>
    ''' <param name="b">Second number</param>
    ''' <param name="c">Third number</param>
    ''' <param name="d">Fourth number</param>
    ''' <param name="e">Fifth number</param>
    ''' <param name="time">Output time taken (in ticks)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDEuclid(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer, ByVal e As Integer, ByRef time As Long) As Integer
        ' Find the LCD of the first four numbers, then find the LCD of the result and the fifth
        Dim t1 As Long
        Dim f As Integer = FindGCDEuclid(a, b, c, d, t1)
        Dim t2 As Long
        Dim g As Integer = FindGCDEuclid(f, e, t2)
        time = t1 + t2

        Return g
    End Function

    ''' <summary>
    ''' Find the lowest common divisor of two numbers using Stein's Algorithm
    ''' see: http://en.wikipedia.org/wiki/Binary_GCD_algorithm
    ''' </summary>
    ''' <param name="u"></param>
    ''' <param name="v"></param>
    ''' <param name="time">Output time taken (in ticks)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindGCDStein(ByVal u As Integer, ByVal v As Integer, ByRef time As Long) As Integer
        ' Initialize timing
        time = 0
        Dim sw = New Stopwatch()
        sw.Start()

        Dim k As Integer = 0

        ' Step 1.
        ' gcd(0, v) = v, because everything divides zero, and v is the largest number that divides v. 
        ' Similarly, gcd(u, 0) = u. gcd(0, 0) is not typically defined, but it is convenient to set gcd(0, 0) = 0.
        If u = 0 OrElse v = 0 Then
            sw.Stop()
            time = sw.ElapsedTicks
            Return u Or v
        End If

        ' Step 2.
        ' If u and v are both even, then gcd(u, v) = 2•gcd(u/2, v/2), because 2 is a common divisor. 
        Do While ((u Or v) And 1) = 0
            u >>= 1
            v >>= 1
            k += 1
        Loop

        ' Step 3.
        ' If u is even and v is odd, then gcd(u, v) = gcd(u/2, v), because 2 is not a common divisor. 
        ' Similarly, if u is odd and v is even, then gcd(u, v) = gcd(u, v/2). 
        While (u And 1) = 0
            u >>= 1
        End While

        ' Step 4.
        ' If u and v are both odd, and u ≥ v, then gcd(u, v) = gcd((u − v)/2, v). 
        ' If both are odd and u < v, then gcd(u, v) = gcd((v − u)/2, u). 
        ' These are combinations of one step of the simple Euclidean algorithm, 
        ' which uses subtraction at each step, and an application of step 3 above. 
        ' The division by 2 results in an integer because the difference of two odd numbers is even.
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
            ' Repeat steps 3–4 until u = v, or (one more step) until u = 0.
            ' In either case, the result is (2^k) * v, where k is the number of common factors of 2 found in step 2. 
        Loop While v <> 0

        u <<= k

        ' Stop timer
        sw.Stop()
        time = sw.ElapsedTicks

        Return u
    End Function
End Class