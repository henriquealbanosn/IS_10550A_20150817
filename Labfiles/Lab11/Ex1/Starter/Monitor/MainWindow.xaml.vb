Imports MeasuringDevice

Class MainWindow
    Private device As MeasureMassDevice

    Private Sub StartCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If device Is Nothing Then
            device = New MeasureMassDevice(Units.Metric, "LogFile.txt")
        End If

        ' TODO: - Hook up the event handler to the event.

        LoggingFileNameTextBox.Text = device.GetLoggingFile()
        UnitsTextBox.Text = device.UnitsToUse.ToString()

        device.StartCollecting()
    End Sub

    ' TODO: - Add the device_NewMeasurementTaken event handler method to update the UI with the new measurement.

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.LoggingFileName = LoggingFileNameTextBox.Text
        Else
            MessageBox.Show("You must create an instance of the MeasureMassDevice class first.")
        End If
    End Sub

    Private Sub StopCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.StopCollecting()

            ' TODO: - Disconnect the event handler.
        End If
    End Sub

    Private Sub DisposeButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.Dispose()
            device = Nothing
        End If
    End Sub
End Class
