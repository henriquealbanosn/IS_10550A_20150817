Public Delegate Sub DocumentAddingToQueueDelegate(Of DocumentType)(ByVal document As DocumentType, ByRef returnValue As Boolean)

Public Class Printer(Of DocumentType As IPrintable)
    Dim printQueue As New Queue(Of DocumentType)()

    Public Sub AddDocumentToQueue(ByVal document As DocumentType)
        Dim print As Boolean = OnDocumentAddingToQueue(document)

        If print Then
            printQueue.Enqueue(document)
        End If
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

            OnDocumentPrinted(Me, New DocumentPrintedEventArgs(Of DocumentType)(document))
        End While
    End Sub

    Public Event DocumentAddingToQueue As DocumentAddingToQueueDelegate(Of DocumentType)

    Protected Function OnDocumentAddingToQueue(ByVal document As DocumentType) As Boolean
        ' Check hidden event handler field, if any handlers have been attached to DocumentAddingToQueue event
        If Not DocumentAddingToQueueEvent Is Nothing Then
            Dim returnValue As Boolean

            RaiseEvent DocumentAddingToQueue(document, returnValue)

            Return returnValue
        Else
            Return True
        End If
    End Function

    Public Event DocumentPrinted As Action(Of Printer(Of DocumentType), DocumentPrintedEventArgs(Of DocumentType))

    Protected Sub OnDocumentPrinted(ByVal prt As Printer(Of DocumentType), ByVal e As DocumentPrintedEventArgs(Of DocumentType))
        RaiseEvent DocumentPrinted(prt, e)
    End Sub
End Class

Public Class DocumentPrintedEventArgs(Of DocumentType)
    Inherits EventArgs

    Public Property Document As DocumentType

    Public Sub New(ByVal document As DocumentType)
        Me.Document = document
    End Sub
End Class