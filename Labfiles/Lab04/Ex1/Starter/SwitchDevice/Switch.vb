''' <summary>
''' Status of coolant system enumeration
''' Check indicates a manual check needs to be performed by the operator
''' </summary>
''' <remarks></remarks>
Public Enum CoolantSystemStatus
    OK
    Check
    Fail
End Enum

''' <summary>
''' Success or failure result enumeration
''' </summary>
''' <remarks></remarks>
Public Enum SuccessFailureResult
    Success
    Fail
End Enum

''' <summary>
''' Switch class - manages interaction with physical switch hardware
''' </summary>
''' <remarks></remarks>
Public Class Switch
    ''' <summary>
    ''' Utilty object for simulation
    ''' </summary>
    Private rand As New Random()

    ''' <summary>
    ''' Disconnect from the external power generation systems
    ''' </summary>
    ''' <returns>Success or Failure</returns>
    ''' <exception cref="PowerGeneratorCommsException">Thrown when the physical switch cannot establish a connection to the power generation system</exception>
    ''' <remarks></remarks>
    Public Function DisconnectPowerGenerator() As SuccessFailureResult
        Dim r As SuccessFailureResult = SuccessFailureResult.Fail
        If rand.Next(1, 10) > 2 Then r = SuccessFailureResult.Success
        If rand.Next(1, 20) > 18 Then Throw New PowerGeneratorCommsException("Network failure accessing Power Generator monitoring system")

        Return r
    End Function

    ''' <summary>
    ''' Runs a diagnostic check against the primary coolant system
    ''' </summary>
    ''' <returns>Coolant System Status (OK, Fail, Check)</returns>
    ''' <exception cref="CoolantTemperatureReadException">Thrown when the switch cannot read the temperature from the coolant system</exception>
    ''' <exception cref="CoolantPressureReadException">Thrown when the switch cannot read the pressure from the coolant system</exception>
    ''' <remarks></remarks>
    Public Function VerifyPrimaryCoolantSystem() As CoolantSystemStatus
        Dim c As CoolantSystemStatus = CoolantSystemStatus.Fail
        Dim r As Integer = rand.Next(1, 10)

        If r > 5 Then
            c = CoolantSystemStatus.OK
        ElseIf r > 2 Then
            c = CoolantSystemStatus.Check
        End If

        If rand.Next(1, 20) > 18 Then Throw New CoolantTemperatureReadException("Failed to read primary coolant system temperature")
        If rand.Next(1, 20) > 18 Then Throw New CoolantPressureReadException("Failed to read primary coolant system pressure")

        Return c
    End Function

    ''' <summary>
    ''' Runs a diagnostic check against the backup coolant system
    ''' </summary>
    ''' <returns>Coolant System Status (OK, Fail, Check)</returns>
    ''' <exception cref="CoolantTemperatureReadException">Thrown when the switch cannot read the temperature from the coolant system</exception>
    ''' <exception cref="CoolantPressureReadException">Thrown when the switch cannot read the pressure from the coolant system</exception>
    ''' <remarks></remarks>
    Public Function VerifyBackupCoolantSystem() As CoolantSystemStatus
        Dim c As CoolantSystemStatus = CoolantSystemStatus.Fail

        Dim r As Integer = rand.Next(1, 10)

        If r > 5 Then
            c = CoolantSystemStatus.OK
        ElseIf r > 2 Then
            c = CoolantSystemStatus.Check
        End If

        If rand.Next(1, 20) > 19 Then Throw New CoolantTemperatureReadException("Failed to read backup coolant system temperature")
        If rand.Next(1, 20) > 19 Then Throw New CoolantPressureReadException("Failed to read backup coolant system pressure")

        Return c
    End Function

    ''' <summary>
    ''' Reads the temperature from the reactor core
    ''' </summary>
    ''' <returns>Temperature</returns>
    ''' <exception cref="CoreTemperatureReadException">Thrown when the switch cannot access the temperature data</exception>
    ''' <remarks></remarks>
    Public Function GetCoreTemperature() As Double
        If rand.Next(1, 20) > 18 Then Throw New CoreTemperatureReadException("Failed to read core reactor system temperature")

        Return rand.NextDouble() * 1000
    End Function

    ''' <summary>
    ''' Instructs the reactor to insert the control rods to shut the reactor down
    ''' </summary>
    ''' <returns>Success or failure</returns>
    ''' <exception cref="RodClusterReleaseException">Thrown if the switch device cannot read the rod position</exception>
    ''' <remarks></remarks>
    Public Function InsertRodCluster() As SuccessFailureResult
        Dim r As SuccessFailureResult = SuccessFailureResult.Fail
        If rand.Next(1, 100) > 5 Then r = SuccessFailureResult.Success
        If rand.Next(1, 10) > 8 Then Throw New RodClusterReleaseException("Sensor failure, cannot verify rod release")

        Return r
    End Function

    ''' <summary>
    ''' Reads the radiation level from the reactor core
    ''' </summary>
    ''' <returns>Temperature</returns>
    ''' <exception cref="CoreRadiationLevelReadException">Thrown when the switch cannot access the radiation level data</exception>
    ''' <remarks></remarks>
    Public Function GetRadiationLevel() As Double
        If rand.Next(1, 20) > 18 Then Throw New CoreRadiationLevelReadException("Failed to read core reactor system radiation levels")

        Return rand.NextDouble() * 500
    End Function

    ''' <summary>
    ''' Sends a broadcast message to PA system notofying shutdown complete
    ''' </summary>
    ''' <exception cref="SignallingException">Thrown if the switch cannot connect to the PA system over the network</exception>
    ''' <remarks></remarks>
    Public Sub SignalShutdownComplete()
        If rand.Next(1, 20) > 18 Then Throw New SignallingException("Network failure connecting to broadcast systems")
    End Sub
End Class

Public Class PowerGeneratorCommsException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class CoolantSystemException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class CoolantTemperatureReadException
    Inherits CoolantSystemException

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class CoolantPressureReadException
    Inherits CoolantSystemException

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class CoreTemperatureReadException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class CoreRadiationLevelReadException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class RodClusterReleaseException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class SignallingException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class