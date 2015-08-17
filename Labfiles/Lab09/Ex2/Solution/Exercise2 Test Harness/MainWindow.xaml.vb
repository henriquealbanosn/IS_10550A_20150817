Imports MeasuringDevice

Class MainWindow
    Private device As IMeasuringDevice

    Private Sub GetMeasurementsButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Using device As New MeasureMassDevice(Units.Metric, "D:\Labfiles\Lab09\LogFile.txt")
            device.StartCollecting()
            System.Threading.Thread.Sleep(20000)
            LoggingFileNameTextBox.Text = device.GetLoggingFile()
            MetricValueTextBox.Text = device.MetricValue().ToString()
            ImperialValueTextBox.Text = device.ImperialValue().ToString()
            RawDataValuesListBox.ItemsSource = device.GetRawData()
            device.StopCollecting()
        End Using
    End Sub
End Class
