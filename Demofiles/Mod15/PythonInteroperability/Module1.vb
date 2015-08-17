Imports IronPython.Hosting

Module Module1
    Sub Main()
        Console.WriteLine("Testing Python")

        ' Creating IronPython objects
        Dim pythonRT As Object = Python.CreateRuntime().UseFile("..\..\..\CustomerDB.py")
        Dim pythonCustomer As Object = pythonRT.GetNewCustomer(100, "Fred", "888")
        Dim pythonCustomerDB As Object = pythonRT.GetCustomerDB()

        pythonCustomerDB.storeCustomer(pythonCustomer)
        pythonCustomer = pythonRT.GetNewCustomer(101, "Sid", "999")
        pythonCustomerDB.storeCustomer(pythonCustomer)

        Console.WriteLine("{0}", pythonCustomerDB)
    End Sub
End Module