Module Module1
    Sub Main()
        Dim database As New EmployeeDatabase()

        Dim mike As New Employee("Mike")
        database = database + mike

        database = database + New Employee("James") With
        {
            .Salary = 500000,
            .Department = "HR"
        }

        Dim lisa As New Employee("Lisa")
        database += lisa

        database += New Employee("John") With
        {
            .Salary = 125000,
            .Department = "HR"
        }

        database += New Employee("Louise") With
        {
            .Salary = 1500000,
            .Department = "Management"
        }

        database += New Employee("Jane") With
        {
            .Salary = 25000,
            .Department = "Support"
        }

        database += New Employee("Jennifer") With
        {
            .Salary = 50000,
            .Department = "Support"
        }

        Dim louise As Employee = database("Louise")

        Console.WriteLine(louise.ToString())

        Console.WriteLine(database("John").ToString())

        Console.ReadLine()
    End Sub
End Module