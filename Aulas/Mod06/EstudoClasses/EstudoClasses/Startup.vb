Imports ContaBancaria
Imports System.Runtime.CompilerServices

Module Startup

    Sub Main()
        Dim conta1 As New ContaCorrente("João")
        Dim conta2 As New ContaCorrente("João")
        Dim conta3 As New ContaCorrente("João")
        Dim conta4 As New ContaCorrente("João")

        Dim data As DateTime = DateTime.Now
        Console.WriteLine(data.ToDatabaseString())

        Console.WriteLine(conta1.Numero)
        conta1.Deposito(8.5)

        Console.WriteLine(conta1.Saldo)
        Console.ReadLine()
    End Sub

End Module

Module Extensions
    <Extension()>
    Public Function ToDatabaseString(ByVal data As DateTime) As String
        Return data.ToString("yyyy-MM-dd")
    End Function
End Module

