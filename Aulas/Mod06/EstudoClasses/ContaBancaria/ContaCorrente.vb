Public Class ContaCorrente
    Private _numero As Integer
    Public ReadOnly Property Numero() As Integer
        Get
            Return _numero
        End Get
    End Property
    Private _saldo As Decimal
    Public ReadOnly Property Saldo() As Decimal
        Get
            Return _saldo
        End Get
    End Property

    Private _gerente As String
    Public Property Gerente() As String
        Get
            Return _gerente
        End Get
        Set(ByVal value As String)
            _gerente = value
        End Set
    End Property

    Public Sub New()
        _numero = 199
    End Sub

    Public Sub New(ByVal gerente As String)
        Me.Gerente = gerente
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
