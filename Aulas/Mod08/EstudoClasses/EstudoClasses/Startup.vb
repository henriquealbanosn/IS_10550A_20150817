Imports ContaBancaria
Imports System.Runtime.CompilerServices

Module Startup

    Sub Main()
        Dim corrente As New ContaCorrente()
        Dim poupanca As New ContaPoupanca()

        Depositar(poupanca, 100)
        Depositar(corrente, 100)

        ExibirConta(corrente)
        ExibirConta(poupanca)
    End Sub

    Sub Depositar(conta As Conta, valor As Decimal)
        Console.WriteLine("Deposito na conta de valor {0:C}", valor)
        conta.Deposito(valor)
    End Sub

    Sub ExibirConta(conta As Conta)
        Console.WriteLine("Tipo  : {0}", conta.ToString())
        Console.WriteLine("Numero: {0}", conta.Numero)
        Console.WriteLine("Saldo : {0}", conta.Saldo)
        If TypeOf conta Is ContaCorrente Then
            Dim contaCorrente As ContaCorrente
            contaCorrente = CType(conta, ContaCorrente)
            Console.WriteLine("Cesta : {0}", contaCorrente.CestaServicos)
        End If
    End Sub

End Module

Module Extensions
    <Extension()>
    Public Function ToDatabaseString(ByVal data As DateTime) As String
        Return data.ToString("yyyy-MM-dd")
    End Function
End Module

