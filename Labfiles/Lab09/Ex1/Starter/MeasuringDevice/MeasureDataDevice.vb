Imports System.IO
Imports DeviceControl

' TODO: Modify this class to implement the IDisposable interface.
' TODO: Modify this class to implement the ILoggingMeasuringDevice interface instead of the IMeasuringDevice interface.
Public MustInherit Class MeasureDataDevice
    Implements IMeasuringDevice

    Protected unitsToUse As Units
    Protected dataCaptured() As Integer
    Protected mostRecentMeasure As Integer
    Protected controller As DeviceController
    Protected measurementType As DeviceType

    ' TODO: Add fields necessary to support logging.

    ''' <summary>
    ''' Converts the raw data collected by the measuring device into a metric value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted to metric units.</returns>
    ''' <remarks></remarks>
    Public MustOverride Function MetricValue() As Decimal Implements IMeasuringDevice.MetricValue

    ''' <summary>
    ''' Converts the raw data collected by the measuring device into an imperial value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted to imperial units.</returns>
    ''' <remarks></remarks>
    Public MustOverride Function ImperialValue() As Decimal Implements IMeasuringDevice.ImperialValue

    ''' <summary>
    ''' Starts the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartCollecting() Implements IMeasuringDevice.StartCollecting
        controller = DeviceController.StartDevice(measurementType)

        ' TODO: Add code to open a logging file and write an initial entry.
        GetMeasurements()
    End Sub

    ''' <summary>
    ''' Stops the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopCollecting() Implements IMeasuringDevice.StopCollecting
        If Not controller Is Nothing Then
            controller.StopDevice()
            controller = Nothing
        End If

        ' TODO: Add code to write a message to the log file.
    End Sub

    ''' <summary>
    ''' Enables access to the raw data from the device in whatever units are native to the device.
    ''' </summary>
    ''' <returns>The raw data from the device in native format.</returns>
    ''' <remarks></remarks>
    Public Function GetRawData() As Integer() Implements IMeasuringDevice.GetRawData
        Return dataCaptured
    End Function

    Private Sub GetMeasurements()
        ReDim dataCaptured(9)

        System.Threading.ThreadPool.QueueUserWorkItem(
            Sub()
                Dim x As Integer = 0
                Dim timer As New Random()

                While True
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000))
                    dataCaptured(x) = controller.TakeMeasurement()
                    mostRecentMeasure = dataCaptured(x)

                    ' TODO: Add code to log each time a measurement is taken.

                    x += 1

                    If x = 10 Then
                        x = 0
                    End If
                End While
            End Sub)
    End Sub

    ' TODO: Add methods to implement the ILoggingMeasuringDevice interface.
End Class