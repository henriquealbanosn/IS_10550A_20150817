Namespace DeviceControl
    Interface IControllableDevice
        ''' <summary>
        ''' A method to start the device being controlled.
        ''' </summary>
        ''' <remarks></remarks>
        Sub StartDevice()

        ''' <summary>
        ''' A method to stop the device being controlled.
        ''' </summary>
        ''' <remarks></remarks>
        Sub StopDevice()

        ''' <summary>
        '''  A method to force the device to take a measurement.
        ''' </summary>
        ''' <returns>The measurement taken by the device.</returns>
        ''' <remarks></remarks>
        Function GetLatestMeasure() As Integer
    End Interface
End Namespace
