Public Interface IEventEnabledMeasuringDevice
    Inherits IMeasuringDevice

    Event NewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs)
End Interface
