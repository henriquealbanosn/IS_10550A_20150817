Imports MeasuringDevice

Class MainWindow
    Private device As MeasureMassDevice

    Private Sub StartCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If device Is Nothing Then
            device = New MeasureMassDevice(Units.Metric, "LogFile.txt")
        End If

        AddHandler device.NewMeasurementTaken, AddressOf device_NewMeasurementTaken

        AddHandler device.HeartBeat,
            Sub(o, args)
                HeartBeatTimeStampLabel.Content =
                    String.Format("HeartBeat Timestamp: {0}", args.TimeStamp)
            End Sub

        LoggingFileNameTextBox.Text = device.GetLoggingFile()
        UnitsTextBox.Text = device.UnitsToUse.ToString()

        device.StartCollecting()
    End Sub

    Private Sub device_NewMeasurementTaken(ByVal sender As Object, ByVal e As EventArgs)
        If Not device Is Nothing Then
            MostRecentMeasureTextBox.Text =
                device.MostRecentMeasure.ToString()
            MetricValueTextBox.Text = device.MetricValue().ToString()
            ImperialValueTextBox.Text = device.ImperialValue().ToString()
            RawDataValuesListBox.ItemsSource = Nothing
            RawDataValuesListBox.ItemsSource = device.GetRawData()
        End If
    End Sub

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

            RemoveHandler device.NewMeasurementTaken, AddressOf device_NewMeasurementTaken
        End If
    End Sub

    Private Sub DisposeButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            device.Dispose()
            device = Nothing
        End If
    End Sub
End Class
