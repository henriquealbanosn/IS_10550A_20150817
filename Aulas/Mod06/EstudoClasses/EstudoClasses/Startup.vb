Imports ContaBancaria
Module Startup

    Sub Main()
        Dim conta1 As New ContaCorrente("João")
        Dim conta2 As New ContaCorrente("João")
        Dim conta3 As New ContaCorrente("João")
        Dim conta4 As New ContaCorrente("João")



        Console.WriteLine(conta1.Numero)
        conta1.Deposito(8.5)

        Console.WriteLine(conta1.Saldo)
        Console.ReadLine()
    End Sub

End Module
