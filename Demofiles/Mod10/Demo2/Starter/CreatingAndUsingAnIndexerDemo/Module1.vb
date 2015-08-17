Module Module1
    Sub Main()
        Dim database As New EmployeeDatabase()
        database.AddToDatabase(New Employee("John") With
        {
            .Salary = 125000,
            .Department = "HR"
        })
        database.AddToDatabase(New Employee("James") With
        {
            .Salary = 500000,
            .Department = "HR"
        })
        database.AddToDatabase(New Employee("Louise") With
        {
            .Salary = 1500000,
            .Department = "Management"
        })
        database.AddToDatabase(New Employee("Jane") With
        {
            .Salary = 25000,
            .Department = "Support"
        })
        database.AddToDatabase(New Employee("Jennifer") With
        {
            .Salary = 50000,
            .Department = "Support"
        })

        'Dim louise As Employee = database("Louise")

        'Console.WriteLine(louise.ToString())

        'Console.WriteLine(database("John").ToString())

        Console.ReadLine()
    End Sub
End Module