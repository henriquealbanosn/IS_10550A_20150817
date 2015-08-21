﻿Public Class ContaCorrente
    Private _numero As Integer
    Public Property Numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value
        End Set
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
