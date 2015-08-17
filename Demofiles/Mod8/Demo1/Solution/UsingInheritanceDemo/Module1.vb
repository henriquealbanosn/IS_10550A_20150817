Class Television
    Protected Overridable Sub SetCurrentChannel()
        Console.WriteLine("Channel set.")
    End Sub

    Protected Sub TurnOn()
        Console.WriteLine("Television on.")
    End Sub
End Class

Class WidescreenTV
    Inherits Television

    Protected Overrides Sub SetCurrentChannel()
        Console.WriteLine("Widescreen channel set.")
    End Sub

    Public Sub New()
        MyBase.New()

        TurnOn()
        SetCurrentChannel()
        MyBase.SetCurrentChannel()
    End Sub
End Class

Module Module1

    Sub Main()
        ' TODO: Uncomment the following line of code.
        Dim tv As New WidescreenTV()
        Console.ReadLine()
    End Sub
End Module