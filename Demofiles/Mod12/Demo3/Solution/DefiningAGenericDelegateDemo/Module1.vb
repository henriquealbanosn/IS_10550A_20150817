Module Module1
    Sub Main()
        Dim guide1 As New ReferenceGuide("Desktop Support Guide")
        Dim guide2 As New ReferenceGuide("Laptop Support Guide")
        Dim guide3 As New ReferenceGuide("Server Support Guide")

        Dim project1 As New Report("IT Upgrade Report")
        Dim project2 As New Report("Customer Project Report")
        Dim project3 As New Report("Office Relocation Report")

        Dim referenceGuidePrinter As New Printer(Of ReferenceGuide)()

        AddHandler referenceGuidePrinter.DocumentAddingToQueue, New DocumentAddingToQueueDelegate(Of ReferenceGuide)(AddressOf referenceGuidePrinter_DocumentAddingToQueue)

        referenceGuidePrinter.AddDocumentToQueue(guide1)
        referenceGuidePrinter.AddDocumentToQueue(guide2)
        referenceGuidePrinter.AddDocumentToQueue(guide3)

        referenceGuidePrinter.PrintDocuments()

        Console.ReadLine()

        Dim reportPrinter As New Printer(Of Report)()
        reportPrinter.AddDocumentToQueue(project1)
        reportPrinter.AddDocumentToQueue(project2)
        reportPrinter.AddDocumentToQueue(project3)

        Dim documentPrinter As Action(Of Printer(Of Report), DocumentPrintedEventArgs(Of Report)) = AddressOf reportPrinter_DocumentPrinted
        AddHandler reportPrinter.DocumentPrinted, documentPrinter

        reportPrinter.PrintDocuments()

        Console.ReadLine()
    End Sub

    Sub referenceGuidePrinter_DocumentAddingToQueue(ByVal document As ReferenceGuide, ByRef returnValue As Boolean)
        Dim result As System.Windows.Forms.DialogResult = System.Windows.Forms.MessageBox.Show(String.Format(
            "Reference Guide Title: {0} " & vbCrLf & "Proceeed?", document.Title), "Reference Guide Printing",
            System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information)

        returnValue = (result = System.Windows.Forms.DialogResult.OK)
    End Sub

    ''' <summary>
    ''' Displays message box indicating the report has been printed
    ''' </summary>
    ''' <param name="arg1"></param>
    ''' <param name="arg2"></param>
    ''' <remarks></remarks>
    Sub reportPrinter_DocumentPrinted(ByVal arg1 As Printer(Of Report), ByVal arg2 As DocumentPrintedEventArgs(Of Report))
        System.Windows.Forms.MessageBox.Show(arg2.Document.Title, "Report Printed",
            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
    End Sub
End Module