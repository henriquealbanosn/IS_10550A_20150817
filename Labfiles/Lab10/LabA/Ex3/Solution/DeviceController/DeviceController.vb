Imports ContosoDevices = Contoso.MeasuringDevices
Imports FabrikamDevices = Fabrikam.Devices.MeasuringDevices

Namespace DeviceControl
    Public Class DeviceController
        Implements IDisposable

        Private device As IControllableDevice

        ''' <summary>
        ''' A factory method to create a start a new instance of a device.
        ''' </summary>
        ''' <param name="MeasurementType">Specifies which type of device to start. Must be MASS or LENGTH.</param>
        ''' <returns>An instance of the DeviceController class with the controlled device in the started state.</returns>
        ''' <remarks></remarks>
        Public Shared Function StartDevice(ByVal MeasurementType As DeviceType) As DeviceController
            Dim controller As New DeviceController()

            Select Case MeasurementType
                Case DeviceType.LENGTH
                    controller.device = New FabrikamDevices.LengthMeasuringDevice()
                Case DeviceType.MASS
                    controller.device = New ContosoDevices.MassMeasuringDevice()
            End Select

            If Not controller.device Is Nothing Then
                controller.device.StartDevice()
            End If

            Return controller
        End Function

        ''' <summary>
        ''' Stops the controlled device.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopDevice()
            device.StopDevice()
        End Sub

        ''' <summary>
        ''' Forces the controlled device to record a measurement.
        ''' </summary>
        ''' <returns>The measurement taken by the device.</returns>
        ''' <remarks></remarks>
        Public Function TakeMeasurement() As Integer
            Return device.GetLatestMeasure()
        End Function

        ''' <summary>
        ''' Disposes the device.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Class

    Public Enum DeviceType
        MASS
        LENGTH
    End Enum
End Namespace