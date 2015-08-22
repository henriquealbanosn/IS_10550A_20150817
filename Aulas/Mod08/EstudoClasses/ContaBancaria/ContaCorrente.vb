Public Class ContaCorrente
    Inherits Conta

    Private _cestaServicos As String
    Public Property CestaServicos() As String
        Get
            Return _cestaServicos
        End Get
        Set(ByVal value As String)
            _cestaServicos = value
        End Set
    End Property

    Public Sub New()
        Me.CestaServicos = "Cesta Basica"
    End Sub

End Class
