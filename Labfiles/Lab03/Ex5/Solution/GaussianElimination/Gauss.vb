Public Class Gauss
    ''' <summary>
    ''' Number of equations (and variables) to solve for
    ''' </summary>
    ''' <remarks></remarks>
    Public Const numberOfEquations As Integer = 4

    ''' <summary>
    ''' Solve simultaneous equations using Gaussian method
    ''' </summary>
    ''' <param name="coefficients">Coefficients from all equations</param>
    ''' <param name="rhs">Constants from all equations</param>
    ''' <returns>Array of solution results</returns>
    ''' <remarks></remarks>
    Public Shared Function SolveGaussian(ByVal coefficients(,) As Double, ByVal rhs() As Double) As Double()
        ' Make deep copies of the coefficients and rhs arrays
        Dim a(,) As Double = DeepCopy2D(coefficients)
        Dim b() As Double = DeepCopy1D(rhs)

        ' Convert the equations to triangular form
        Dim x, sum As Double

        For k As Integer = 0 To numberOfEquations
            Try
                For i As Integer = k + 1 To numberOfEquations - 1
                    x = a(i, k) / a(k, k)

                    For j As Integer = k + 1 To numberOfEquations - 1
                        a(i, j) = a(i, j) - a(k, j) * x
                    Next

                    b(i) = b(i) - b(k) * x
                Next
            Catch e As DivideByZeroException
                Console.WriteLine(e.Message)
            End Try
        Next

        ' Perform the back substitution and return the result
        b(numberOfEquations - 1) = b(numberOfEquations - 1) / a(numberOfEquations - 1, numberOfEquations - 1)

        For i As Integer = numberOfEquations - 2 To 0 Step -1
            sum = b(i)

            For j As Integer = i + 1 To numberOfEquations - 1
                sum = sum - a(i, j) * b(j)
            Next

            b(i) = sum / a(i, i)
        Next

        Return b
    End Function

    ''' <summary>
    ''' Add static methods to do a deep copy of 1 and two dimensional arrays of doubles
    ''' </summary>
    ''' <param name="arr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function DeepCopy1D(ByVal arr() As Double) As Double()
        ' Get dimensions
        Dim columns As Integer = arr.GetLength(0)

        ' Initialize a new array
        Dim newArray() As Double
        ReDim newArray(columns)

        ' Copy the values
        For I As Integer = 0 To columns - 1
            newArray(I) = arr(I)
        Next

        Return newArray
    End Function

    Private Shared Function DeepCopy2D(ByVal arr(,) As Double) As Double(,)
        ' Get dimensions
        Dim columns As Integer = arr.GetLength(0)
        Dim rows As Integer = arr.GetLength(1)

        ' Initialize a new array
        Dim newArray(,) As Double
        ReDim newArray(columns, rows)

        ' Copy the values
        For I As Integer = 0 To columns - 1
            For j As Integer = 0 To rows - 1
                newArray(I, j) = arr(I, j)
            Next
        Next

        Return newArray
    End Function

End Class