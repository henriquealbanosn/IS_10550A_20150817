Imports ControlRegister

Module Module1

    Sub Main()
        Dim register As New ControlRegisterIndexing.ControlRegister()
        register.RegisterData = 8

        Console.WriteLine("RegisterData: {0}", register.RegisterData)
        Console.WriteLine("Bit 0: {0}", register(0).ToString())
        Console.WriteLine("Bit 1: {0}", register(1).ToString())
        Console.WriteLine("Bit 2: {0}", register(2).ToString())
        Console.WriteLine("Bit 3: {0}", register(3).ToString())
        Console.WriteLine("Bit 4: {0}", register(4).ToString())
        Console.WriteLine("Bit 5: {0}", register(5).ToString())
        Console.WriteLine("Bit 6: {0}", register(6).ToString())
        Console.WriteLine("Bit 7: {0}", register(7).ToString())
        Console.WriteLine()

        Console.WriteLine("Set Bit 1 to 1")
        register(1) = 1
        Console.WriteLine()

        Console.WriteLine("RegisterData: {0}", register.RegisterData)
        Console.WriteLine("Bit 0: {0}", register(0).ToString())
        Console.WriteLine("Bit 1: {0}", register(1).ToString())
        Console.WriteLine("Bit 2: {0}", register(2).ToString())
        Console.WriteLine("Bit 3: {0}", register(3).ToString())
        Console.WriteLine("Bit 4: {0}", register(4).ToString())
        Console.WriteLine("Bit 5: {0}", register(5).ToString())
        Console.WriteLine("Bit 6: {0}", register(6).ToString())
        Console.WriteLine("Bit 7: {0}", register(7).ToString())
        Console.WriteLine()

        Console.WriteLine("Set Bit 0 to 1")
        register(0) = 1
        Console.WriteLine()

        Console.WriteLine("RegisterData: {0}", register.RegisterData)
        Console.WriteLine("Bit 0: {0}", register(0).ToString())
        Console.WriteLine("Bit 1: {0}", register(1).ToString())
        Console.WriteLine("Bit 2: {0}", register(2).ToString())
        Console.WriteLine("Bit 3: {0}", register(3).ToString())
        Console.WriteLine("Bit 4: {0}", register(4).ToString())
        Console.WriteLine("Bit 5: {0}", register(5).ToString())
        Console.WriteLine("Bit 6: {0}", register(6).ToString())
        Console.WriteLine("Bit 7: {0}", register(7).ToString())
        Console.WriteLine()

        Console.ReadLine()
    End Sub
End Module