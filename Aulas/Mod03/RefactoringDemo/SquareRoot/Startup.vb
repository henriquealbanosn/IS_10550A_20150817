Module Startup

    Sub Main()
        Console.WriteLine("Calcular raiz quadrada de: ")
        Dim Valor As Integer = Console.ReadLine()

        Dim Raiz1 As Decimal = Math.Sqrt(Valor)
        Dim Raiz2 As Decimal = CalcularRaiz(Valor)

        Console.WriteLine("Calculo .NET  : {0}", Raiz1)
        Console.WriteLine("Calculo Newton: {0}", Raiz2)
        Console.ReadLine()
    End Sub

    Function CalcularRaiz(ByVal valor As Integer) As Decimal

        Dim Precisao As Decimal = Math.Pow(10, -28)
        Dim Raiz, Diferenca As Decimal
        Dim RaizAnterior As Decimal = valor

        Do
            If (RaizAnterior <> valor) Then
                Raiz = ((valor / RaizAnterior) + RaizAnterior) / 2
            Else
                Raiz = valor / 2
            End If
            Diferenca = RaizAnterior - Raiz
            RaizAnterior = Raiz
        Loop While Diferenca <> 0 Or Diferenca > Precisao

        Return Raiz
    End Function
End Module
