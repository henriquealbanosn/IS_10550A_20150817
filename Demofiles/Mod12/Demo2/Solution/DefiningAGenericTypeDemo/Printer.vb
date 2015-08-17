Public Class Printer(Of DocumentType As IPrintable)
    Dim printQueue As New Queue(Of DocumentType)()

    Public Sub AddDocumentToQueue(ByVal document As DocumentType)
        printQueue.Enqueue(document)
    End Sub

    Public Sub PrintDocuments()
        While printQueue.Count > 0
            Dim document As DocumentType = printQueue.Dequeue()
            Console.WriteLine("PRINTING: {0}", document.Title.ToUpper())
            Console.WriteLine()
            Console.WriteLine(document.Print())
            Console.WriteLine()
            Console.WriteLine("PRINTED")
            Console.WriteLine()
        End While
    End Sub
End Class
