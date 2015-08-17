Imports DeviceControl

Public Class MeasureMassDevice
    Inherits MeasureDataDevice

    ''' <summary>
    ''' Construct a new instance of the MeasureMassDevice class.
    ''' </summary>
    ''' <param name="deviceUnits">Specifies the units used natively by the device.</param>
    ''' <param name="logFileName">Specifies the required file name used
    ''' for logging in the class.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal deviceUnits As Units, ByVal logFileName As String)
        dataDeviceUnitsToUse = deviceUnits
        dataDeviceMeasurementType = DeviceType.MASS
        dataDeviceLoggingFileName = logFileName
    End Sub

    ''' <summary>
    ''' Converts the raw data collected by the measuring device into an imperial value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted to imperial units.</returns>
    ''' <remarks></remarks>
    Public Overrides Function ImperialValue() As Decimal
        Dim imperialMostRecentMeasure As Decimal

        If dataDeviceUnitsToUse = Units.Imperial Then
            imperialMostRecentMeasure = Convert.ToDecimal(dataDeviceMostRecentMeasure)
        Else
            ' Metric measurements are in kilograms.
            ' Multiply metric measurement by 2.2046 to convert from
            ' kilograms to pounds.
            ' Convert from an integer value to a decimal.
            Dim decimalMetricValue As Decimal = Convert.ToDecimal(dataDeviceMostRecentMeasure)
            Dim conversionFactor As Decimal = 2.2046D
            imperialMostRecentMeasure = decimalMetricValue * conversionFactor
        End If

        Return imperialMostRecentMeasure
    End Function

    ''' <summary>
    ''' Converts the raw data collected by the measuring device into a metric value.
    ''' </summary>
    ''' <returns>The latest measurement from the device converted to metric units.</returns>
    ''' <remarks></remarks>
    Public Overrides Function MetricValue() As Decimal
        Dim metricMostRecentMeasure As Decimal

        If dataDeviceUnitsToUse = Units.Metric Then
            metricMostRecentMeasure = Convert.ToDecimal(dataDeviceMostRecentMeasure)
        Else
            ' Imperial measurements are in pounds.
            ' Multiply imperial measurement by 0.4536 to convert from pounds to kilograms.
            ' Convert from an integer value to a decimal.
            Dim decimalImperialValue As Decimal = Convert.ToDecimal(dataDeviceMostRecentMeasure)
            Dim conversionFactor As Decimal = 0.4536D
            metricMostRecentMeasure = decimalImperialValue * conversionFactor
        End If

        Return metricMostRecentMeasure
    End Function
End Class
