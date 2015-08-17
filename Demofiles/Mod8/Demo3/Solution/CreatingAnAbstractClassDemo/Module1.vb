MustInherit Class Television
    Public Sub TurnOn()
        Console.WriteLine("Television on.")
    End Sub

    Public Sub TurnOff()
        Console.WriteLine("Television off.")
    End Sub

    Public MustOverride Sub IncreaseVolume()
    Public MustOverride Sub DecreaseVolume()
End Class

Class WidescreenTV
    Inherits Television

    Public Overrides Sub DecreaseVolume()
        Console.WriteLine("Volume decreased (WidescreenTV).")
    End Sub

    Public Overrides Sub IncreaseVolume()
        Console.WriteLine("Volume increased (WidescreenTV).")
    End Sub
End Class

Class TV
    Inherits Television

    Public Overrides Sub DecreaseVolume()
        Console.WriteLine("Volume decreased (TV).")
    End Sub

    Public Overrides Sub IncreaseVolume()
        Console.WriteLine("Volume increased (TV).")
    End Sub
End Class

Module Module1

    Sub Main()
        Dim tv As New WidescreenTV()
        tv.TurnOn()
        tv.IncreaseVolume()
        tv.DecreaseVolume()
        tv.TurnOff()
        Dim tv2 As New TV()
        tv2.TurnOn()
        tv2.IncreaseVolume()
        tv2.DecreaseVolume()
        tv2.TurnOff()
        Console.ReadLine()
    End Sub
End Module