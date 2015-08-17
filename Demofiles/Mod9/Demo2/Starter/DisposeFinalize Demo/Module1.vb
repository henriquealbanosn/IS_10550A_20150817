Module Module1

    Sub Main()
        Using Louise As New Employee("Louise")
            Louise.PaySalary()
        End Using

        Console.ReadLine()

        Dim Jane = New Employee("Jane")
        Jane.PaySalary()
        Jane.Dispose()
        Jane.PaySalary()
    End Sub

End Module
