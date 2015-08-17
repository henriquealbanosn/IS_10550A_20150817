''' <summary>
''' Static class to perform a variety of matrix manipulations
''' </summary>
''' <remarks></remarks>
Public Class Matrix
    '''' <summary>
    '''' Multiply two matrices together
    '''' The number of columns in the first matrix must be the same as the number of rows in the second matrix
    '''' </summary>
    '''' <param name="matrix1">First matrix</param>
    '''' <param name="matrix2">Second matrix</param>
    '''' <returns>Product of matrix multiplication</returns>
    '''' <exception cref="ArgumentOutOfRangeException">Thrown if the matrices have incompatible dimensions or contain negative entries</exception>
    Public Shared Function MatrixMultiply(ByVal matrix1(,) As Double, ByVal matrix2(,) As Double) As Double(,)
        ' TODO: Evaluate input matrices for compatibility
        ' Check the matrices are compatible            

        ' Get the dimensions
        Dim m1columns_m2rows As Integer = matrix1.GetLength(0)
        Dim m1rows As Integer = matrix1.GetLength(1)
        Dim m2columns As Integer = matrix2.GetLength(0)

        ' Create a suitable array to hold the result of the multiplication
        Dim result(m2columns, m1rows) As Double

        ' Calculate the value for each cell in the result matrix
        For row As Integer = 0 To m1rows - 1
            For column As Integer = 0 To m2columns - 1
                ' Initialize the value for the result cell
                Dim accumulator As Double = 0

                ' Iterate over the row in the source matrix multiplying by the value in the column in the second matrix, add to the accumulator
                For cell As Integer = 0 To m1columns_m2rows - 1
                    ' TODO: Evaluate matrix data points for invalid data
                    ' Throw exceptions if either matrix contains a negative entry
                    accumulator += matrix1(cell, row) * matrix2(column, cell)
                Next

                result(column, row) = accumulator
            Next
        Next

        Return result
    End Function
End Class
