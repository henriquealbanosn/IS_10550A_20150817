Imports System.Threading
Imports System.Text

Public Class Gauss
    Private Shared results As Hashtable

    ''' <summary>
    ''' Number of equations (and variables) to solve for
    ''' </summary>
    Public Const numberOfEquations As Integer = 4

    ''' <summary>
    ''' Solve simultaneous equations using Gaussian method
    ''' </summary>
    ''' <param name="coefficients">Coefficients from all equations</param>
    ''' <param name="rhs">Constants from all equations</param>
    ''' <returns>Array of solution results</returns>
    ''' <remarks></remarks>
    Public Shared Function SolveGaussian(ByVal coefficients(,) As Double, ByVal rhs() As Double) As Double()
        If results Is Nothing Then
            results = New Hashtable()
        End If

        Dim hashString As New StringBuilder()

        For Each coefficient As Double In coefficients
            hashString.Append(coefficient)
        Next

        For Each value As Double In rhs
            hashString.Append(value)
        Next

        Dim hashValue As String = hashString.ToString()

        If results.Contains(hashValue) Then
            Return CType(results(hashValue), Double())
        Else
            ' Make a deep copy of the parameters
            Dim coefficientsCopy(,) As Double = DeepCopy2D(coefficients)
            Dim rhsCopy() As Double = DeepCopy1D(rhs)

            Dim x, sum As Double

            ' Convert to upper triangular form
            For k As Integer = 0 To numberOfEquations - 1
                Try
                    For i As Integer = k + 1 To numberOfEquations - 1
                        x = coefficientsCopy(i, k) / coefficientsCopy(k, k)

                        For j As Integer = k + 1 To numberOfEquations - 1
                            coefficientsCopy(i, j) = coefficientsCopy(i, j) - coefficientsCopy(k, j) * x
                        Next

                        rhsCopy(i) = rhsCopy(i) - rhsCopy(k) * x
                    Next
                Catch e As DivideByZeroException
                    Console.WriteLine(e.Message)
                End Try
            Next

            ' Back substitution
            rhsCopy(numberOfEquations - 1) = rhsCopy(numberOfEquations - 1) / coefficientsCopy(numberOfEquations - 1, numberOfEquations - 1)

            For i As Integer = numberOfEquations - 2 To 0 Step -1
                sum = rhsCopy(i)

                For j As Integer = i + 1 To numberOfEquations - 1
                    sum = sum - coefficientsCopy(i, j) * rhsCopy(j)
                Next
                rhsCopy(i) = sum / coefficientsCopy(i, i)
            Next

            ' Pause to exaggerate the benefit of implementing caching.
            ' In larger applications the gain could be significantly greater.
            System.Threading.Thread.Sleep(5000)
            results.Add(hashValue, rhsCopy)

            Return rhsCopy
        End If
    End Function

    ''' <summary>
    ''' Deep copy a one dimensional array
    ''' </summary>
    ''' <param name="arr">Array to copy</param>
    ''' <returns>New Array</returns>
    ''' <remarks></remarks>
    Private Shared Function DeepCopy1D(ByVal arr As Double()) As Double()
        ' Get dimensions
        Dim columns As Integer = arr.GetLength(0)

        ' Initialize a new array
        Dim newArray() As Double
        ReDim newArray(columns)

        ' Copy the values
        For i As Integer = 0 To columns - 1
            newArray(i) = arr(i)
        Next

        Return newArray
    End Function

    ''' <summary>
    ''' Deep copy a two dimensional array
    ''' </summary>
    ''' <param name="arr">Array to copy</param>
    ''' <returns>New Array</returns>
    ''' <remarks></remarks>
    Private Shared Function DeepCopy2D(ByVal arr(,) As Double) As Double(,)
        ' Get dimensions
        Dim columns As Integer = arr.GetLength(0)
        Dim rows As Integer = arr.GetLength(1)

        ' Initialize a new array
        Dim newArray(,) As Double
        ReDim newArray(columns, rows)

        ' Copy the values
        For i As Integer = 0 To columns - 1
            For j As Integer = 0 To rows - 1
                newArray(i, j) = arr(i, j)
            Next
        Next

        Return newArray
    End Function
End Class