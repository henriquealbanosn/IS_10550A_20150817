Public Class ContaCorrente
    Private _numero As Integer
    Public ReadOnly Property Numero() As Integer
        Get
            Return _numero
        End Get
    End Property
    Private _saldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return _saldo
        End Get
        Set(ByVal value As Decimal)
            _saldo = value
        End Set
    End Property

    Public Sub New()
        _numero = 199
    End Sub

    Sub Deposito(ByVal valor As Decimal)
        _saldo += valor
    End Sub

    Sub Saque(ByVal valor As Decimal)
        If (_saldo < valor) Then
            Throw New InvalidOperationException("Saldo insuficiente")
        End If
        _saldo -= valor
    End Sub
End Class
