Imports DeviceControl

Public Class MeasureLengthDevice
    Implements IMeasuringDevice

    Private unitsToUse As Units
    Private dataCaptured() As Integer
    Private mostRecentMeasure As Integer
    Private controller As DeviceController
    Private Const measurementType As DeviceType = DeviceType.LENGTH

    ''' <summary>
    ''' Construct a new instance of the MeasureLengthDevice class.
    ''' </summary>
    ''' <param name="deviceUnits">Specifies the units used by the device.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal deviceUnits As Units)
        unitsToUse = deviceUnits
    End Sub

    Public Function GetRawData() As Integer() Implements IMeasuringDevice.GetRawData
        Return dataCaptured
    End Function

    Public Function ImperialValue() As Decimal Implements IMeasuringDevice.ImperialValue
        Dim imperialMostRecentMeasure As Decimal

        If unitsToUse = Units.Imperial Then
            imperialMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Metric measurements are in millimeters.
            ' Multiply metric measurement by 0.03937 to convert from
            ' millimeters to inches.
            ' Convert from an integer value to a decimal.
            Dim decimalMetricValue As Decimal = Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 0.03937
            imperialMostRecentMeasure = decimalMetricValue * conversionFactor
        End If

        Return imperialMostRecentMeasure
    End Function

    Public Function MetricValue() As Decimal Implements IMeasuringDevice.MetricValue
        Dim metricMostRecentMeasure As Decimal

        If unitsToUse = Units.Metric Then
            metricMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Imperial measurements are in inches.
            ' Multiply imperial measurement by 25.4 to convert from
            ' inches to millimeters. 
            ' Convert from an integer value to a decimal.
            Dim decimalImperialValue As Decimal = Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 25.4
            metricMostRecentMeasure = decimalImperialValue * conversionFactor
        End If

        Return metricMostRecentMeasure
    End Function

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
