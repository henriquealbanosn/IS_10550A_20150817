Imports System.Text
Imports System.Runtime.Serialization

Namespace MatrixOperators
    Public Class Matrix
        Private data(,) As Integer

        Public Sub New(ByVal size As Integer)
            ReDim data(size - 1, size - 1)
        End Sub

        Default Public Property Index(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As Integer
            Get
                If rowIndex > data.GetUpperBound(0) OrElse columnIndex > data.GetUpperBound(0) Then
                    Throw New IndexOutOfRangeException()
                Else
                    Return data(rowIndex, columnIndex)
                End If
            End Get
            Set(ByVal value As Integer)
                If rowIndex > data.GetUpperBound(0) OrElse columnIndex > data.GetUpperBound(0) Then
                    Throw New IndexOutOfRangeException()
                Else
                    data(rowIndex, columnIndex) = value
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim builder As New StringBuilder()

            ' Iterate over every row in the matrix.
            For x As Integer = 0 To data.GetLength(0) - 1
                ' Iterate over every column in the matrix.
                For y As Integer = 0 To data.GetLength(1) - 1
                    builder.AppendFormat("{0}" & vbTab, data(x, y))
                Next

                builder.Append(Environment.NewLine)
            Next

            Return builder.ToString()
        End Function

        Public Shared Operator +(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix)
            If matrix1.data.GetLength(0) = matrix2.data.GetLength(0) Then
                Dim newMatrix As New Matrix(matrix1.data.GetLength(0))

                ' Iterate over every row in the matrix.
                For x As Integer = 0 To matrix1.data.GetLength(0) - 1
                    ' Iterate over every column in the matrix.
                    For y As Integer = 0 To matrix1.data.GetLength(1) - 1
                        newMatrix.data(x, y) = matrix1.data(x, y) + matrix2.data(x, y)
                    Next
                Next

                Return newMatrix
            Else
                Throw New MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size")
            End If
        End Operator

        Public Shared Operator -(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix)
            If matrix1.data.GetLength(0) = matrix2.data.GetLength(0) Then
                Dim newMatrix As New Matrix(matrix1.data.GetLength(0))

                ' Iterate over every row in the matrix.
                For x As Integer = 0 To matrix1.data.GetLength(0) - 1
                    ' Iterate over every column in the matrix.
                    For y As Integer = 0 To matrix1.data.GetLength(1) - 1
                        newMatrix.data(x, y) = matrix1.data(x, y) - matrix2.data(x, y)
                    Next
                Next

                Return newMatrix
            Else
                Throw New MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size")
            End If
        End Operator

        Public Shared Operator *(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix)
            If matrix1.data.GetLength(0) = matrix2.data.GetLength(0) Then
                Dim newMatrix As New Matrix(matrix1.data.GetLength(0))

                ' Iterate over every row in the matrix.
                For x As Integer = 0 To matrix1.data.GetLength(0) - 1
                    ' Iterate over every column in the matrix.
                    For y As Integer = 0 To matrix1.data.GetLength(1) - 1
                        Dim temp As Integer = 0

                        For z As Integer = 0 To matrix1.data.GetLength(0) - 1
                            temp += matrix1.data(x, z) * matrix2.data(z, y)
                        Next

                        newMatrix.data(x, y) = temp
                    Next
                Next

                Return newMatrix
            Else
                Throw New MatrixNotCompatibleException(matrix1, matrix2, "Matrices not the same size")
            End If
        End Operator
    End Class

    Public Class MatrixNotCompatibleException
        Inherits Exception

        Dim first As Matrix = Nothing
        Dim second As Matrix = Nothing

        Public ReadOnly Property FirstMatrix As Matrix
            Get
                Return first
            End Get
        End Property

        Public ReadOnly Property SecondMatrix As Matrix
            Get
                Return second
            End Get
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal matrix1 As Matrix, ByVal matrix2 As Matrix, ByVal message As String)
            MyBase.New(message)

            first = matrix1
            second = matrix2
        End Sub
    End Class
End Namespace