Imports System.IO
Imports DeviceControl

' TODO: Implement the IMeasuringDeviceWithProperties interface.
Public MustInherit Class MeasureDataDevice
    Implements ILoggingMeasuringDevice, IDisposable

    Protected unitsToUse As Units
    Protected dataCaptured() As Integer
    Protected mostRecentMeasure As Integer
    Protected controller As DeviceController
    Protected measurementType As DeviceType
    Protected loggingFileName As String
    Private loggingFileWriter As TextWriter

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

        ' New code to check the logging file is not already open.
        ' If it is already open then write a log message.
        ' If not, open the logging file.
        If loggingFileWriter Is Nothing Then
            ' Check if the logging file exists - if not create it.
            If Not File.Exists(loggingFileName) Then
                loggingFileWriter = File.CreateText(loggingFileName)
                loggingFileWriter.WriteLine("Log file status checked - Created")
                loggingFileWriter.WriteLine("Collecting Started")
            Else
                loggingFileWriter = New StreamWriter(loggingFileName)
                loggingFileWriter.WriteLine("Log file status checked - Opened")
                loggingFileWriter.WriteLine("Collecting Started")
            End If
        Else
            loggingFileWriter.WriteLine("Log file status checked - Already open")
            loggingFileWriter.WriteLine("Collecting Started")
        End If

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

        ' New code to write to the log.
        If Not loggingFileWriter Is Nothing Then
            loggingFileWriter.WriteLine("Collecting Stopped.")
        End If
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

                While Not controller Is Nothing
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000))
                    dataCaptured(x) = If(Not controller Is Nothing, controller.TakeMeasurement(), dataCaptured(x))
                    mostRecentMeasure = dataCaptured(x)

                    If Not loggingFileWriter Is Nothing Then
                        loggingFileWriter.WriteLine("Measurement Taken: {0}", mostRecentMeasure.ToString())
                    End If

                    x += 1

                    If x = 10 Then
                        x = 0
                    End If
                End While
            End Sub)
    End Sub

    Public Function GetLoggingFile() As String Implements ILoggingMeasuringDevice.GetLoggingFile
        Return loggingFileName
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                ' Check that the log file is closed; if it is not closed, log
                ' a message and close it.
                If Not loggingFileWriter Is Nothing Then
                    loggingFileWriter.WriteLine("Object Disposed")
                    loggingFileWriter.Flush()
                    loggingFileWriter.Close()
                    loggingFileWriter = Nothing
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    ' TODO: Add properties specified by the IMeasuringDeviceWithProperties interface.

End Class