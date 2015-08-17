Class MainWindow 
    Private beat As HeartBeat

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' Initialize hearbeat
        beat = New HeartBeat()
        ' Add event handler for Beat event
        AddHandler beat.Beat, AddressOf beat_Beat
        ' Start heartbeat
        beat.Start()
    End Sub

    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not beat Is Nothing Then
            ' Stop heartbeat
            beat.Stop()
        End If
    End Sub

    Private Sub beat_Beat(ByVal sender As System.Object, ByVal e As HeartbeatEventArgs)
        MessageBox.Show(String.Format("Hearbeat received: {0}", e.Count))
    End Sub

    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If Not beat Is Nothing Then
            ' Stop heartbeat
            beat.Stop()
        End If

        MyBase.OnClosing(e)
    End Sub
End Class
