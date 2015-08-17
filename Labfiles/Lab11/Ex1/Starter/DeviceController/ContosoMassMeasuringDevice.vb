Imports DeviceControl
Imports System.Threading

Namespace Contoso.MeasuringDevices
    Class MassMeasuringDevice
        Implements IControllableDevice

        Private rand As Random

        ''' <summary>
        ''' Creates a new instance of the MassMeasuringDevice class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            rand = New Random()
        End Sub

        ''' <summary>
        ''' Starts the MassMeasuringDevice
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StartDevice() Implements IControllableDevice.StartDevice
            ' Start the device.
        End Sub

        ''' <summary>
        ''' Stops the MassMeasuringDevice
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopDevice() Implements IControllableDevice.StopDevice
            ' Stop the device.
        End Sub

        ''' <summary>
        ''' Gets the latest measurement from the MassMeasuringDevice.
        ''' </summary>
        ''' <returns>The latest measurment taken by the device.</returns>
        ''' <remarks></remarks>
        Public Function GetLatestMeasure() As Integer Implements IControllableDevice.GetLatestMeasure
            Thread.Sleep(rand.Next(5000))
            Return rand.Next(1390)
        End Function
    End Class
End Namespace