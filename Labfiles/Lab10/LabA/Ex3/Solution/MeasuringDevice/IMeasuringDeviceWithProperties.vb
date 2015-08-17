Interface IMeasuringDeviceWithProperties
    Inherits ILoggingMeasuringDevice

    ReadOnly Property UnitsToUse As Units
    ReadOnly Property DataCaptured As Integer()
    ReadOnly Property MostRecentMeasure As Integer
    Property LoggingFileName As String
End Interface
