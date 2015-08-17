Imports System.Text

Public Class StressData
    ''' <summary>
    ''' The temperature at which the stress test results were generated. 
    ''' <para>
    ''' This value is specified in Kelvin (K).
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Temperature As Short

    ''' <summary>
    ''' A list of applied stress and deflection pairs recorded by the test.
    ''' <para>
    ''' The applied stress values are used as the dictionary keys, specified in kilo-Newtons (kN).
    ''' The deflection data are used as the dictionary values, specified in millimeters (mm).
    ''' Given an applied stress value, the deflection for that stress can be retrieved.
    ''' </para>
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Data As Dictionary(Of Short, Short?)

    ''' <summary>
    ''' Public method that renders the data in a StressData object as a string.
    ''' </summary>
    ''' <returns>
    ''' A string representation of the data in the StressData object
    ''' </returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim stringData As New StringBuilder()
        stringData.Append(String.Format("Temperature: {0}K" & vbNewLine, Me.Temperature))

        For Each itm In Me.Data
            stringData.Append(String.Format("Stress: {0}kN" & vbTab & vbTab & "Deflection: {1}mm" & vbNewLine, itm.Key, itm.Value))
        Next

        Return stringData.ToString()
    End Function
End Class
