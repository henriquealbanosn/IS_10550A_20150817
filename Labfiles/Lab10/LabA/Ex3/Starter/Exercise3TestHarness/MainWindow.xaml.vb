Imports MeasuringDevice
Class MainWindow
    Private Const labFolder As String = "D:\Labfiles\Lab10\LabA\"
    Private device As MeasureMassDevice

    Private Sub StartCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        device = New MeasureMassDevice(Units.Metric, labFolder & "LogFile.txt")
        device.StartCollecting()
        ' TODO: Add code to set the UnitsTextBox to the current units.
        UnitsTextBox.Text = ""
        System.Threading.Thread.Sleep(10000)
        ' TODO: Add code to set the MostRecentMeasureTextBox to the value from the device.
        MostRecentMeasureTextBox.Text = ""
        ' TODO: Update to use the LoggingFileName property.
        LoggingFileNameTextBox.Text = device.GetLoggingFile().Replace(labFolder, "")
        MetricValueTextBox.Text = device.MetricValue().ToString()
        ImperialValueTextBox.Text = device.ImperialValue().ToString()
        RawDataValuesListBox.ItemsSource = Nothing
        ' TODO: Update to use the DataCaptured property.
        RawDataValuesListBox.ItemsSource = device.GetRawData()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            ' TODO: Add code to update the log file name property of the device.
        Else
            MessageBox.Show("You must start collecting first.")
        End If
    End Sub

    Private Sub DisposeButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.StopCollecting()
            device.Dispose()
            device = Nothing
        End If
    End Sub
End Class