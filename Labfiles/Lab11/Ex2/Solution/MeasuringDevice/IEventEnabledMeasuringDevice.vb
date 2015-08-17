Imports MeasuringDevice.HeartBeatEventArgs

Public Interface IEventEnabledMeasuringDevice
    Inherits IMeasuringDevice

    Event NewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs)

    ' Event that fires every heartbeat.
    Event HeartBeat As HeartBeatEventHandler

    ' Read only heartbeat interval - set in constructor.
    ReadOnly Property HeartBeatInterval As Integer
End Interface
