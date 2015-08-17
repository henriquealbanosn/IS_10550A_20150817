Module Module1
    Sub Main()
        Dim julie As New Employee("Julie")
        julie.Salary = 125000
        julie.Department = "HR"

        Dim james As New Employee("James") With
            {
                .Salary = 120000,
                .Department = "Technical"
            }

        Console.WriteLine(james.ToString())
        Console.WriteLine(julie.ToString())

        Console.ReadLine()

        james.Salary = -125000
        Console.WriteLine(james.ToString())

        Console.ReadLine()
    End Sub
End Module