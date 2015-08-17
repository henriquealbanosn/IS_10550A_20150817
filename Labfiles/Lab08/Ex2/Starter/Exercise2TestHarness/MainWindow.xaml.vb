﻿Imports MeasuringDevice

Class MainWindow
    Private device As IMeasuringDevice

    Private Sub CreateInstanceButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If MetricChoiceRadioButton.IsChecked Then
            ' TODO: Add code to instantiate the device field.
        Else
            ' TODO: Add code to instantiate the device field.
        End If
    End Sub

    Private Sub MetricValueButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            MetricValueTextBox.Text = device.MetricValue().ToString()
        End If
    End Sub

    Private Sub ImperialValueButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            ImperialValueTextBox.Text = device.ImperialValue().ToString()
        End If
    End Sub

    Private Sub RawDataButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then
            RawDataValuesListBox.ItemsSource = Nothing
            RawDataValuesListBox.ItemsSource = device.GetRawData()
        End If
    End Sub

    Private Sub StartCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then device.StartCollecting()
    End Sub

    Private Sub StopCollectingButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not device Is Nothing Then device.StopCollecting()
    End Sub
End Class
