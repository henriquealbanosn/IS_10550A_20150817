Public Interface IMeasuringDevice
    ''' <summary>
    ''' Converts the raw data collected by the measuring device
    ''' into a metric value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted
    ''' to metric units.</returns>
    ''' <remarks></remarks>
    Function MetricValue() As Decimal

    ''' <summary>
    ''' Converts the raw data collected by the measuring device into an
    ''' imperial value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted to 
    ''' imperial units.</returns>
    ''' <remarks></remarks>
    Function ImperialValue() As Decimal

    ''' <summary>
    ''' Starts the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartCollecting()

    ''' <summary>
    ''' Stops the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Sub StopCollecting()

    ''' <summary>
    ''' Enables access to the raw data from the device in whatever units
    ''' are native to the device.
    ''' </summary>
    ''' <returns>The raw data from the device in native format.</returns>
    ''' <remarks></remarks>
    Function GetRawData() As Integer()
End Interface
