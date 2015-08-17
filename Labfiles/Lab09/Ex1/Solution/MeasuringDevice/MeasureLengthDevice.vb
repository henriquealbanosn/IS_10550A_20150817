Imports DeviceControl

Public Class MeasureLengthDevice
    Inherits MeasureDataDevice
    Implements IMeasuringDevice

    ''' <summary>
    ''' Construct a new instance of the MeasureLengthDevice class.
    ''' </summary>
    ''' <param name="deviceUnits">Specifies the units used by the device.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal deviceUnits As Units)
        unitsToUse = deviceUnits
        measurementType = DeviceType.LENGTH
    End Sub

    Public Overrides Function ImperialValue() As Decimal
        Dim imperialMostRecentMeasure As Decimal

        If unitsToUse = Units.Imperial Then
            imperialMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Metric measurements are in millimeters.
            ' Multiply metric measurement by 0.03937 to convert from
            ' millimeters to inches.
            ' Convert from an integer value to a decimal.
            Dim decimalMetricValue As Decimal = Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 0.03937D
            imperialMostRecentMeasure = decimalMetricValue * conversionFactor
        End If

        Return imperialMostRecentMeasure
    End Function

    Public Overrides Function MetricValue() As Decimal
        Dim metricMostRecentMeasure As Decimal

        If unitsToUse = Units.Metric Then
            metricMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Imperial measurements are in inches.
            ' Multiply imperial measurement by 25.4 to convert from
            ' inches to millimeters. 
            ' Convert from an integer value to a decimal.
            Dim decimalImperialValue As Decimal = Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 25.4D
            metricMostRecentMeasure = decimalImperialValue * conversionFactor
        End If

        Return metricMostRecentMeasure
    End Function
End Class
