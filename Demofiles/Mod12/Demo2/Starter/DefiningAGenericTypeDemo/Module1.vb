Module Module1
    Sub Main()
        Dim project1 As New Report("IT Upgrade Report")
        Dim project2 As New Report("Customer Project Report")
        Dim project3 As New Report("Office Relocation Report")

        Dim guide1 As New ReferenceGuide("Desktop Support Guide")
        Dim guide2 As New ReferenceGuide("Laptop Support Guide")
        Dim guide3 As New ReferenceGuide("Server Support Guide")

        'Dim reportPrinter As New Printer(Of Report)()
        'reportPrinter.AddDocumentToQueue(project1)
        'reportPrinter.AddDocumentToQueue(project2)
        'reportPrinter.AddDocumentToQueue(project3)

        'reportPrinter.PrintDocuments()

        Console.ReadLine()

        'Dim referenceGuidePrinter As New Printer(Of ReferenceGuide)()
        'referenceGuidePrinter.AddDocumentToQueue(guide1)
        'referenceGuidePrinter.AddDocumentToQueue(guide2)
        'referenceGuidePrinter.AddDocumentToQueue(guide3)

        'referenceGuidePrinter.PrintDocuments()

        Console.ReadLine()
    End Sub
End Module