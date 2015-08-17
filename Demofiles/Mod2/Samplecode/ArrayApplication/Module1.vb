Module Module1
    Sub Main()
        ' -------------------------------------------------------- 
        ' Creating and Initializing Arrays.
        ' -------------------------------------------------------- 

        ' Single-dimensional array.
        Dim singleDimension1() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim singleDimension2(8) As Integer
        singleDimension2 = New Integer(8) {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim singleDimension3() = {1, 2, 3, 4, 5, 6, 7, 8, 9}

        ' Mulidimensional array.
        Dim multiDimensional1(5, 5) As Single
        multiDimensional1 = New Single(,) {{1, 2, 3, 4, 5},
                             {6, 7, 8, 9, 10}}
        Dim multiDimensional2(,) As Single = {{1, 2, 3, 4, 5},
                             {6, 7, 8, 9, 10}}
        Dim multiDimensional3 = {{1, 2, 3, 4, 5},
                             {6, 7, 8, 9, 10}}

        ' Jagged array.
        Dim jaggedArray(9)() As Integer
        jaggedArray(0) = New Integer(4) {1, 2, 3, 4, 5} ' Can specify different sizes
        jaggedArray(1) = New Integer(6) {}

        jaggedArray(9) = New Integer(20) {}

        ' -------------------------------------------------------- 
        ' Common Properties and Methods Exposed by Arrays.
        ' -------------------------------------------------------- 

        Dim numbers() As Integer = {1, 2, 3, 4, 5}
        Dim oldNumbers() As Integer = {2, 4, 3, 9, 1}

        ' Binary seach example.
        Dim searchTerm As Object = 3
        Dim result As Integer = Array.BinarySearch(oldNumbers, searchTerm)

        ' Clone example.
        Dim numbersClone As Object = numbers.Clone()

        ' CopyTo example.
        Dim newNumbers() As Integer
        ReDim newNumbers(oldNumbers.Length)
        oldNumbers.CopyTo(newNumbers, 0)

        ' GetEnumerator example
        Dim results As IEnumerator = oldNumbers.GetEnumerator()

        ' Or

        For Each number As Integer In oldNumbers
        Next

        ' GetLength example.
        Dim count As Integer = oldNumbers.GetLength(0)

        ' GetValue example.
        Dim value As Object = oldNumbers.GetValue(2)
        ' returns the value 3

        ' Length example.
        Dim numberCount As Integer = oldNumbers.Length
        ' Returns the value 5

        ' Rank example.
        Dim rank As Integer = oldNumbers.Rank
        ' Returns the value 1

        ' SetValue example.
        oldNumbers.SetValue(5000, 4)
        ' Changes the value 5 to 5000

        ' Sort example.
        Array.Sort(oldNumbers)
        ' Sorted values: 1 2 3 4 5
    End Sub
End Module