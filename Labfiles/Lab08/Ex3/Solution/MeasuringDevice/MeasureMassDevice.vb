Imports DeviceControl

Public Class MeasureMassDevice
    Inherits MeasureDataDevice
    Implements IMeasuringDevice

    Public Sub New(ByVal deviceUnits As Units)
        unitsToUse = deviceUnits
        measurementType = DeviceType.MASS
    End Sub

    Public Overrides Function ImperialValue() As Decimal
        Dim imperialMostRecentMeasure As Decimal

        If unitsToUse = Units.Imperial Then
            imperialMostRecentMeasure =
                Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Metric measurements are in kilograms.
            ' Multiply metric measurement by 2.2046 to convert from
            ' kilograms to pounds.
            ' Convert from an integer value to a decimal.

            Dim decimalMetricValue As Decimal =
                Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 2.2046D
            imperialMostRecentMeasure =
                decimalMetricValue * conversionFactor
        End If

        Return imperialMostRecentMeasure
    End Function

    Public Overrides Function MetricValue() As Decimal
        Dim metricMostRecentMeasure As Decimal

        If unitsToUse = Units.Metric Then
            metricMostRecentMeasure =
                Convert.ToDecimal(mostRecentMeasure)
        Else
            ' Imperial measurements are in pounds.
            ' Multiply imperial measurement by 0.4536 to convert from
            ' pounds to kilograms.
            ' Convert from an integer value to a decimal.
            Dim decimalImperialValue As Decimal =
                Convert.ToDecimal(mostRecentMeasure)
            Dim conversionFactor As Decimal = 0.4536D
            metricMostRecentMeasure =
                decimalImperialValue * conversionFactor
        End If

        Return metricMostRecentMeasure
    End Function
End Class
