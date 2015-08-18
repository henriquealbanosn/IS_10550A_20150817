''' <summary>
''' Módulo responsável por iniciar a aplicação
''' </summary>
''' <remarks></remarks>
Module Startup

    ''' <summary>
    ''' Método inicial da aplicação
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()

        For index = 1 To 10
            Dim Resultado As Integer = Adicionar(index, 4)
        Next

    End Sub

    ''' <summary>
    ''' Adiciona dois números inteiros
    ''' </summary>
    ''' <param name="Valor1">Primeiro valor</param>
    ''' <param name="Valor2">Segundo valor</param>
    ''' <returns>A soma dos dois valores</returns>
    Function Adicionar(ByVal Valor1 As Integer, ByVal Valor2 As Integer) As Integer
        Return Valor1 + Valor2
    End Function

End Module