Module Module1

    Sub Main()
        ' Buffer to hold each line as it's read in
        Dim line As String

        line = Console.ReadLine()
        ' Loop until no more input (Ctrl-Z in a console or end-of-file)
        While Not line Is Nothing
            ' Format the data
            line = line.Replace(",", " y:")
            line = "x:" & line

            ' Write the results out to the console window
            Console.WriteLine(line)

            line = Console.ReadLine()
        End While
    End Sub

End Module
