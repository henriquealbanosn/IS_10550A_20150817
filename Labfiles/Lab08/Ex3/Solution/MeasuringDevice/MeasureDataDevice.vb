Imports DeviceControl

Public MustInherit Class MeasureDataDevice
    Implements IMeasuringDevice

    Protected unitsToUse As Units
    Protected dataCaptured() As Integer
    Protected mostRecentMeasure As Integer
    Protected controller As DeviceController
    Protected measurementType As DeviceType

    Public MustOverride Function MetricValue() As Decimal Implements IMeasuringDevice.MetricValue
    Public MustOverride Function ImperialValue() As Decimal Implements IMeasuringDevice.ImperialValue

    Public Sub StartCollecting() Implements IMeasuringDevice.StartCollecting
        controller = DeviceController.StartDevice(measurementType)
        GetMeasurements()
    End Sub

    Public Sub StopCollecting() Implements IMeasuringDevice.StopCollecting
        If Not controller Is Nothing Then
            controller.StopDevice()
            controller = Nothing
        End If
    End Sub

    Public Function GetRawData() As Integer() Implements IMeasuringDevice.GetRawData
        Return dataCaptured
    End Function

    Private Sub GetMeasurements()
        ReDim dataCaptured(9)

        System.Threading.ThreadPool.QueueUserWorkItem(
            Sub()
                Dim x As Integer = 0
                Dim timer As New Random()

                While Not controller Is Nothing
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000))
                    dataCaptured(x) = If(Not controller Is Nothing,
                        controller.TakeMeasurement(), dataCaptured(x))
                    mostRecentMeasure = dataCaptured(x)
                    x += 1

                    If x = 10 Then
                        x = 0
                    End If
                End While
            End Sub)
    End Sub
End Class
