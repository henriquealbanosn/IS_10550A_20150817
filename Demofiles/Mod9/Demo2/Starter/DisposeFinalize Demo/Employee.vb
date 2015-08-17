Public Class Employee
    Private name As String

    Public Sub New(ByVal name As String)
        Me.name = name
    End Sub

    Public Sub PaySalary()
        Console.WriteLine("Employee {0} paid.", Me.name)
    End Sub
End Class
