Imports ContaBancaria
Imports System.Runtime.CompilerServices

Module Startup

    Sub Main()
        Dim corrente As New ContaCorrente()
        Dim poupanca As New ContaPoupanca()

        poupanca.Deposito(100)
        corrente.Deposito(100)

        Console.WriteLine(corrente.Saldo)
        Console.WriteLine(poupanca.Saldo)
    End Sub

End Module

Module Extensions
    <Extension()>
    Public Function ToDatabaseString(ByVal data As DateTime) As String
        Return data.ToString("yyyy-MM-dd")
    End Function
End Module

