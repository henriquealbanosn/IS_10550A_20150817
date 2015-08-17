Public Interface IEventEnabledMeasuringDevice
    Inherits IMeasuringDevice

    Event NewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs)

    ' TODO: - Define the new event in the interface.
    ' Event that fires every heartbeat.

    ' TODO: - Define the HeartBeatInterval property in the interface.
    ' Read only heartbeat interval - set in constructor.
End Interface
