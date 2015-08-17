Imports System.IO

Module Startup

    Sub Main()
        Console.WriteLine("Digite seu texto <Linha Vazia> para salvar)")

        Dim Writer As StreamWriter = File.CreateText("texto.txt")

        Dim Linha As String = Console.ReadLine()

        While Linha <> ""
            Writer.WriteLine(Linha)
            Linha = Console.ReadLine()
        End While

        Writer.Close()
        Console.WriteLine("Arquivo salvo...")
        Console.ReadKey()

    End Sub

End Module
