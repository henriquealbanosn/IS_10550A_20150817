Imports MeasuringDevice
Class MainWindow
    Private Const labFolder As String = "D:\Labfiles\Lab10\LabA\"
    Private device As MeasureMassDevice

    Private Sub StartCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        device = New MeasureMassDevice(Units.Metric, labFolder & "LogFile.txt")
        device.StartCollecting()
        UnitsTextBox.Text = device.UnitsToUse.ToString()
        System.Threading.Thread.Sleep(10000)
        MostRecentMeasureTextBox.Text = device.MostRecentMeasure.ToString()
        LoggingFileNameTextBox.Text = device.LoggingFileName.Replace(labFolder, "")
        MetricValueTextBox.Text = device.MetricValue().ToString()
        ImperialValueTextBox.Text = device.ImperialValue().ToString()
        RawDataValuesListBox.ItemsSource = Nothing
        RawDataValuesListBox.ItemsSource = device.DataCaptured
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.LoggingFileName = labFolder & LoggingFileNameTextBox.Text
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