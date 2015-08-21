Imports ContaBancaria
Module Startup

    Sub Main()
        Dim conta As New ContaCorrente("João")
        Console.WriteLine(conta.Numero)
        conta.Deposito(8.5)

        Console.WriteLine(conta.Saldo)
        Console.ReadLine()
    End Sub

End Module
