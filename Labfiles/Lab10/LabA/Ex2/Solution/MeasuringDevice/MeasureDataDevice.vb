Imports System.IO
Imports DeviceControl

Public MustInherit Class MeasureDataDevice
    Implements IDisposable, IMeasuringDeviceWithProperties

    Protected dataDeviceUnitsToUse As Units
    Protected dataDeviceDataCaptured() As Integer
    Protected dataDeviceMostRecentMeasure As Integer
    Protected dataDeviceController As DeviceController
    Protected dataDeviceMeasurementType As DeviceType
    Protected dataDeviceLoggingFileName As String
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
        dataDeviceController = DeviceController.StartDevice(dataDeviceMeasurementType)

        ' New code to check the logging file is not already open.
        ' If it is already open then write a log message.
        ' If not, open the logging file.
        If loggingFileWriter Is Nothing Then
            ' Check if the logging file exists - if not create it.
            If Not File.Exists(dataDeviceLoggingFileName) Then
                loggingFileWriter = File.CreateText(dataDeviceLoggingFileName)
                loggingFileWriter.WriteLine("Log file status checked - Created")
                loggingFileWriter.WriteLine("Collecting Started")
            Else
                loggingFileWriter = New StreamWriter(dataDeviceLoggingFileName)
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
        If Not dataDeviceController Is Nothing Then
            dataDeviceController.StopDevice()
            dataDeviceController = Nothing
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
        Return dataDeviceDataCaptured
    End Function

    Private Sub GetMeasurements()
        ReDim dataDeviceDataCaptured(9)

        System.Threading.ThreadPool.QueueUserWorkItem(
            Sub()
                Dim x As Integer = 0
                Dim timer As New Random()

                While Not dataDeviceController Is Nothing
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000))
                    dataDeviceDataCaptured(x) = If(Not dataDeviceController Is Nothing, dataDeviceController.TakeMeasurement(), dataDeviceDataCaptured(x))
                    dataDeviceMostRecentMeasure = dataDeviceDataCaptured(x)

                    If Not loggingFileWriter Is Nothing Then
                        loggingFileWriter.WriteLine("Measurement Taken: {0}", dataDeviceMostRecentMeasure.ToString())
                    End If

                    x += 1

                    If x = 10 Then
                        x = 0
                    End If
                End While
            End Sub)
    End Sub

    Public Function GetLoggingFile() As String Implements ILoggingMeasuringDevice.GetLoggingFile
        Return dataDeviceLoggingFileName
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


    Public ReadOnly Property DataCaptured As Integer() Implements IMeasuringDeviceWithProperties.DataCaptured
        Get
            Return dataDeviceDataCaptured
        End Get
    End Property

    Public Property LoggingFileName As String Implements IMeasuringDeviceWithProperties.LoggingFileName
        Get
            Return dataDeviceLoggingFileName
        End Get
        Set(ByVal value As String)
            If loggingFileWriter Is Nothing Then
                ' If the file has not been opened simply update the file name.
                dataDeviceLoggingFileName = value
            Else
                ' If the file has been opened close the current file first,
                ' then update the file name and open the new file.
                loggingFileWriter.WriteLine("Log File Changed")
                loggingFileWriter.WriteLine("New Log File: {0}", value)
                loggingFileWriter.Close()
                ' Now update the logging file and open the new file.
                dataDeviceLoggingFileName = value

                ' Check if the logging file exists - if not create it.
                If Not File.Exists(LoggingFileName) Then
                    loggingFileWriter = File.CreateText(LoggingFileName)
                    loggingFileWriter.WriteLine("Log file status checked - Created")
                    loggingFileWriter.WriteLine("Collecting Started")
                Else
                    loggingFileWriter = New StreamWriter(LoggingFileName)
                    loggingFileWriter.WriteLine("Log file status checked - Opened")
                    loggingFileWriter.WriteLine("Collecting Started")
                End If

                loggingFileWriter.WriteLine("Log File Changed Successfully")
            End If
        End Set
    End Property

    Public ReadOnly Property MostRecentMeasure As Integer Implements IMeasuringDeviceWithProperties.MostRecentMeasure
        Get
            Return dataDeviceMostRecentMeasure
        End Get
    End Property

    Public ReadOnly Property UnitsToUse As Units Implements IMeasuringDeviceWithProperties.UnitsToUse
        Get
            Return dataDeviceUnitsToUse
        End Get
    End Property
End Class