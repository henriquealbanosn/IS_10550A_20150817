Imports System.IO

Public Class Employee
    Public Sub New(ByVal EmployeeName As String)
        name = EmployeeName
        Console.WriteLine("Employee {0} created.", name)
        ' Read the current salary from a file. This could be a database.
        salary = Double.Parse(File.ReadAllText("SalaryDetails.txt"))
    End Sub

    Private name As String
    Private salary As Double

    Public Sub PaySalary()
        Console.WriteLine("Employee ({0}) paid: {1}", name, salary.ToString())
    End Sub

    Public Sub PayRise()
        salary = salary * 1.1
    End Sub
End Class
