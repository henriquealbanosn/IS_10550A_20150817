Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports DeviceControl
Imports MeasuringDevice.HeartBeatEventArgs

Public MustInherit Class MeasureDataDevice
    Implements IEventEnabledMeasuringDevice, IDisposable

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

    ' BackgroundWorker member to generate measurements.
    Private dataCollector As BackgroundWorker

    ''' <summary>
    ''' Starts the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartCollecting() Implements IMeasuringDevice.StartCollecting
        If disposedValue Then Return

        If dataDeviceController Is Nothing Then
            dataDeviceController = DeviceController.StartDevice(dataDeviceMeasurementType)
        End If

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

        StartHeartBeat()

        GetMeasurements()
    End Sub

    ' Add a GetMeasurements method to configure and start the 
    ' BackgroundWorker.
    Private Sub GetMeasurements()
        dataCollector = New BackgroundWorker()
        dataCollector.WorkerSupportsCancellation = True
        dataCollector.WorkerReportsProgress = True

        AddHandler dataCollector.DoWork, AddressOf dataCollector_DoWork
        AddHandler dataCollector.ProgressChanged, AddressOf dataCollector_ProgressChanged

        dataCollector.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' Stops the measuring device.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopCollecting() Implements IMeasuringDevice.StopCollecting
        If disposedValue Then Return

        If Not dataDeviceController Is Nothing Then
            dataDeviceController.StopDevice()
            dataDeviceController = Nothing
        End If

        ' New code to write to the log.
        If loggingFileWriter IsNot Nothing Then
            loggingFileWriter.WriteLine("Collecting Stopped.")
        End If

        ' Stop the data collection BackgroundWorker.
        If Not dataCollector Is Nothing Then
            dataCollector.CancelAsync()
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

    ''' <summary>
    ''' Returns the file name of the logging file for the device.
    ''' </summary>
    ''' <returns>The file name of the logging file.</returns>
    ''' <remarks></remarks>
    Public Function GetLoggingFile() As String Implements IMeasuringDevice.GetLoggingFile
        Return dataDeviceLoggingFileName
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Public Sub Dispose() Implements IDisposable.Dispose
        Me.disposedValue = True

        ' Check that the log file is closed; if it is not closed, log a message and close it.
        If loggingFileWriter IsNot Nothing Then
            loggingFileWriter.WriteLine("Object Disposed")
            loggingFileWriter.Flush()
            loggingFileWriter.Close()
        End If

        ' Dispose of the dataCollector BackgroundWorker object.
        If Not dataCollector Is Nothing Then
            dataCollector.Dispose()
        End If

        If Not heartBeatTimer Is Nothing Then
            heartBeatTimer.Dispose()
        End If
    End Sub
#End Region

    ' New properties to provide controlled access to data.

    ''' <summary>
    ''' Gets an array of the measurements taken by the device.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataCaptured As Integer() Implements IMeasuringDevice.DataCaptured
        Get
            Return dataDeviceDataCaptured
        End Get
    End Property

    ''' <summary>
    ''' Gets the Units used natively by the device.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UnitsToUse As Units Implements IMeasuringDevice.UnitsToUse
        Get
            Return dataDeviceUnitsToUse
        End Get
    End Property

    ''' <summary>
    ''' Gets the most recent measurement taken by the device.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MostRecentMeasure As Integer Implements IMeasuringDevice.MostRecentMeasure
        Get
            Return dataDeviceMostRecentMeasure
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the name of the logging file used. 
    ''' If the logging file changes this closes the current file and creates the new file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoggingFileName As String Implements IMeasuringDevice.LoggingFileName
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

    ' Class implementation of the NewMeasurementTaken event.
    Public Event NewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs) Implements IEventEnabledMeasuringDevice.NewMeasurementTaken

    ' Method to raise the NewMeasurementTaken event.
    Protected Overridable Sub OnNewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent NewMeasurementTaken(Me, Nothing)
    End Sub

    ' Heartbeat interval in milliseconds.
    Protected heartBeatIntervalTime As Integer
    Public ReadOnly Property HeartBeatInterval As Integer Implements IEventEnabledMeasuringDevice.HeartBeatInterval
        Get
            Return heartBeatIntervalTime
        End Get
    End Property

    ' Event that fires every heartbeat.
    Public Event HeartBeat As HeartBeatEventHandler Implements IEventEnabledMeasuringDevice.HeartBeat

    ' Overrideable method to fire the HeartBeat event.
    Protected Overridable Sub OnHeartBeat()
        RaiseEvent HeartBeat(Me, New HeartBeatEventArgs())
    End Sub

    ' Background worker object to host the heartbeat thread.
    Private heartBeatTimer As BackgroundWorker

    ' Start the BackgroundWorker that fires the heartbeat.
    Private Sub StartHeartBeat()
        heartBeatTimer = New BackgroundWorker()
        heartBeatTimer.WorkerSupportsCancellation = True
        heartBeatTimer.WorkerReportsProgress = True

        AddHandler heartBeatTimer.DoWork,
            Sub(o, args)
                While True
                    Thread.Sleep(HeartBeatInterval)

                    If disposedValue Then
                        Exit While
                    End If

                    heartBeatTimer.ReportProgress(0)
                End While
            End Sub

        AddHandler heartBeatTimer.ProgressChanged,
            Sub(o, args)
                OnHeartBeat()
            End Sub

        heartBeatTimer.RunWorkerAsync()
    End Sub

    Private Sub dataCollector_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        ReDim dataDeviceDataCaptured(9)

        Dim i As Integer = 0

        While Not dataCollector.CancellationPending
            dataDeviceDataCaptured(i) = dataDeviceController.TakeMeasurement()
            dataDeviceMostRecentMeasure = dataDeviceDataCaptured(i)

            If disposedValue Then
                Exit While
            End If

            If loggingFileWriter IsNot Nothing Then
                loggingFileWriter.WriteLine("Measurement - {0}", dataDeviceMostRecentMeasure.ToString())
            End If

            dataCollector.ReportProgress(0)

            i += 1

            If i > 9 Then
                i = 0
            End If
        End While
    End Sub

    Private Sub dataCollector_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        OnNewMeasurementTaken(Me, Nothing)
    End Sub
End Class