Interface ITelevision
    Sub TurnOn()
    Sub TurnOff()
    Sub IncreaseVolume()
    Sub DecreaseVolume()
End Interface

Class Television
    Implements ITelevision

    Public Sub DecreaseVolume() Implements ITelevision.DecreaseVolume

    End Sub

    Public Sub IncreaseVolume() Implements ITelevision.IncreaseVolume

    End Sub

    Public Sub TurnOff() Implements ITelevision.TurnOff

    End Sub

    Public Sub TurnOn() Implements ITelevision.TurnOn

    End Sub
End Class

Module Module1

    Sub Main()

    End Sub

End Module
