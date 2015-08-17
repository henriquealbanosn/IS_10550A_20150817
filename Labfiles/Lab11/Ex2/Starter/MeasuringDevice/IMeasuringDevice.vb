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

    ''' <summary>
    ''' Returns the file name of the logging file for the device.
    ''' </summary>
    ''' <returns>The file name of the logging file.</returns>
    ''' <remarks></remarks>
    Function GetLoggingFile() As String

    ''' <summary>
    ''' Gets the Units used natively by the device.
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property UnitsToUse As Units

    ''' <summary>
    ''' Gets an array of the measurements taken by the device.
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property DataCaptured As Integer()

    ''' <summary>
    ''' Gets the most recent measurement taken by the device.
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property MostRecentMeasure As Integer

    ''' <summary>
    ''' Gets or sets the name of the logging file used. 
    ''' If the logging file changes this closes the current file and creates the new file.
    ''' </summary>
    ''' <remarks></remarks>
    Property LoggingFileName As String
End Interface
