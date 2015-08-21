Public Class ContaPoupanca
    Inherits Conta

    Public Overrides Sub Deposito(valor As Decimal)
        MyBase.Deposito(valor)
        MyBase.Deposito(valor * 0.001)
    End Sub

End Class
