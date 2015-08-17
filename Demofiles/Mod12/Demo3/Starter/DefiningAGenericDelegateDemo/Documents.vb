Imports System.Text

Public Class Report
    Implements IPrintable

    Private reportTitle As String

    Public Sub New(ByVal title As String)
        Me.reportTitle = Title
    End Sub

    Public ReadOnly Property Title As String Implements IPrintable.Title
        Get
            Return reportTitle
        End Get
    End Property

    Public Function Print() As String Implements IPrintable.Print
        ' Add a pause to ensure that the time changes between documents (important for random number generation).
        System.Threading.Thread.Sleep(2000)

        Dim rand As New Random()
        Dim builder As New StringBuilder()
        builder.AppendFormat("REPORT: {0}", Me.Title)
        builder.AppendLine()

        If rand.Next(10) > 5 Then
            builder.AppendFormat("Status: OK")
        Else
            builder.AppendFormat("Status: OK")
        End If

        builder.AppendLine()

        If rand.Next(10) > 5 Then
            builder.AppendFormat("Project: On Schedule")
        Else
            builder.AppendFormat("Project: Behind Schedule")
        End If

        builder.AppendLine()

        If rand.Next(10) > 5 Then
            builder.AppendFormat("Budget: On Target")
        Else
            If rand.Next(10) > 5 Then
                builder.AppendFormat("Budget: Below Target")
            Else
                builder.AppendFormat("Budget: Above Target")
            End If
        End If

        builder.AppendLine()
        builder.Append("END REPORT")

        Return builder.ToString()
    End Function
End Class

Class ReferenceGuide
    Implements IPrintable

    Private refGuideTitle As String

    Public Sub New(ByVal title As String)
        Me.refGuideTitle = title
    End Sub

    Public ReadOnly Property Title As String Implements IPrintable.Title
        Get
            Return refGuideTitle
        End Get
    End Property

    Public Function Print() As String Implements IPrintable.Print
        ' Add a pause to ensure that the time changes between documents (important for random number generation).
        System.Threading.Thread.Sleep(2000)

        Dim rand As New Random()
        Dim builder As New StringBuilder()
        builder.AppendFormat("Reference Guide: {0}", Me.Title)
        builder.AppendLine()

        If rand.Next(10) > 5 Then
            builder.AppendFormat("Checklist:")
        Else
            builder.AppendFormat("Items for verification:")
        End If

        builder.AppendLine()

        If rand.Next(10) > 5 Then
            builder.AppendFormat("Power light on")
        Else
            builder.AppendFormat("Monitor power on")
        End If

        builder.AppendLine()
        If rand.Next(10) > 5 Then
            builder.AppendFormat("Fans spinning")
        Else
            If rand.Next(10) > 5 Then
                builder.AppendFormat("All connections correct")
            Else
                builder.AppendFormat("Drives spinning")
            End If
        End If

        builder.AppendLine()
        builder.Append("End of Reference Guide")

        Return builder.ToString()
    End Function
End Class