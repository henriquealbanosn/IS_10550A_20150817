Module Module1
    Sub Main()
        Dim min As Integer = 48
        Dim max As Integer = 50
        Dim numberOfRequirednumbers As Integer = 100

        Dim randomNumbers() As Integer
        ReDim randomNumbers(numberOfRequirednumbers)

        Dim numberGenerator As New Random()

        For count As Integer = 0 To numberOfRequirednumbers - 1
            randomNumbers(count) = numberGenerator.Next(min, max)
        Next

        ' More logic that use the randomNumbers variable.
        Array.Sort(randomNumbers)
    End Sub
End Module