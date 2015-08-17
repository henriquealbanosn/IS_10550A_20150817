Imports DeviceControl

Namespace Fabrikam.Devices.MeasuringDevices
    Class LengthMeasuringDevice
        Implements IControllableDevice

        Private rand As Random

        ''' <summary>
        ''' Creates a new instance of the LengthMeasuringDevice class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            rand = New Random()
        End Sub

        ''' <summary>
        ''' Starts the LengthMeasuringDevice 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StartDevice() Implements IControllableDevice.StartDevice
            ' Start the device.           
        End Sub

        ''' <summary>
        ''' Stops the LengthMeasuringDevice
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopDevice() Implements IControllableDevice.StopDevice
            ' Stop the device.
        End Sub

        ''' <summary>
        ''' Gets the latest measurement from the LengthMeasuringDevice.
        ''' </summary>
        ''' <returns>The latest measurment taken by the device.</returns>
        ''' <remarks></remarks>
        Public Function GetLatestMeasure() As Integer Implements IControllableDevice.GetLatestMeasure
            Return rand.Next(1000)
        End Function
    End Class
End Namespace