Imports ContaBancaria
Module Startup

    Sub Main()
        Dim conta As New ContaCorrente
        Console.WriteLine(conta.Numero)
        conta.Deposito(8.5)

    End Sub

End Module
