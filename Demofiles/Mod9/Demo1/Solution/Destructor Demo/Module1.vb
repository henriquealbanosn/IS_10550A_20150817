Module Module1
    Sub Main()
        Dim john As New Employee("John")
        john.PaySalary()
        john.PayRise()
        john.PaySalary()
        john = Nothing
        Dim steve As New Employee("Steve")
        steve.PaySalary()
        steve.PayRise()
        steve.PaySalary()
        steve = Nothing
        GC.AddMemoryPressure(Int32.MaxValue)
        GC.WaitForPendingFinalizers()
        Dim sarah As New Employee("Sarah")
        sarah.PaySalary()
        sarah.PayRise()
        sarah.PaySalary()
        sarah = Nothing
        Console.ReadLine()
        GC.RemoveMemoryPressure(Int32.MaxValue)
    End Sub
End Module