Public Interface ILoggingMeasuringDevice
    Inherits IMeasuringDevice

    ''' <summary>
    ''' Returns the file name of the logging file for the device.
    ''' </summary>
    ''' <returns>The file name for the logging file.</returns>
    ''' <remarks></remarks>
    Function GetLoggingFile() As String
End Interface
