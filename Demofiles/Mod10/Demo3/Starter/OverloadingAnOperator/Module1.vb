Module Module1
    Sub Main()
        Dim database As New EmployeeDatabase()

        'Dim mike As New Employee("Mike")
        'database = database + mike

        'database = database + new Employee("James") With
        '{
        '    .Salary = 500000,
        '    .Department = "HR"
        '}

        'Dim lisa As New Employee("Lisa")
        'database += lisa

        'database += new Employee("John") With
        '{
        '    .Salary = 125000,
        '    .Department = "HR"
        '}

        'database += new Employee("Louise") With
        '{
        '    .Salary = 1500000,
        '    .Department = "Management"
        '}

        'database += new Employee("Jane") With
        '{
        '    .Salary = 25000,
        '    .Department = "Support"
        '}

        'database += new Employee("Jennifer") With
        '{
        '    .Salary = 50000,
        '    .Department = "Support"
        '}

        Dim louise As Employee = database("Louise")

        Console.WriteLine(louise.ToString())

        Console.WriteLine(database("John").ToString())

        Console.ReadLine()
    End Sub
End Module