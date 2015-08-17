Class MainWindow
    ''' <summary>
    ''' Initiate the reactor shutdown using a Switch object
    ''' Record details of shutdown status in a TextBlock - recording all exceptions thrown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShutDownButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' TODO: - Add exception handling
        Me.textBlock1.Text = "Initiating test sequence: " & DateTime.Now.ToLongTimeString()
        Dim sd As New SwitchDevices.Switch()

        ' Step 1 - disconnect from the Power Generator
        If sd.DisconnectPowerGenerator() = SwitchDevices.SuccessFailureResult.Fail Then
            Me.textBlock1.Text &= vbNewLine & "Step 1: Failed to disconnect power generation system"
        Else
            Me.textBlock1.Text &= vbNewLine & "Step 1: Successfully disconnected power generation system"
        End If


        ' Step 2 - Verify the status of the Primary Coolant System
        Select Case sd.VerifyPrimaryCoolantSystem()
            Case SwitchDevices.CoolantSystemStatus.OK
                Me.textBlock1.Text &= vbNewLine & "Step 2: Primary coolant system OK"
            Case SwitchDevices.CoolantSystemStatus.Check
                Me.textBlock1.Text &= vbNewLine & "Step 2: Primary coolant system requires manual check"
            Case SwitchDevices.CoolantSystemStatus.Fail
                Me.textBlock1.Text &= vbNewLine & "Step 2: Problem reported with primary coolant system"
        End Select


        ' Step 3 - Verify the status of the Backup Coolant System
        Select sd.VerifyBackupCoolantSystem()
            Case SwitchDevices.CoolantSystemStatus.OK
                Me.textBlock1.Text &= vbNewLine & "Step 3: Backup coolant system OK"
            Case SwitchDevices.CoolantSystemStatus.Check
                Me.textBlock1.Text &= vbNewLine & "Step 3: Backup coolant system requires manual check"
            Case SwitchDevices.CoolantSystemStatus.Fail
                Me.textBlock1.Text &= vbNewLine & "Step 3: Backup reported with primary coolant system"
        End Select


        ' Step 4 - Record the core temperature prior to shutting down the reactor
        Me.textBlock1.Text &= vbNewLine & "Step 4: Core temperature before shutdown: " & sd.GetCoreTemperature()


        ' Step 5 - Insert the control rods into the reactor
        If sd.InsertRodCluster() = SwitchDevices.SuccessFailureResult.Success Then
            Me.textBlock1.Text &= vbNewLine & "Step 5: Control rods successfully inserted"
        Else
            Me.textBlock1.Text &= vbNewLine & "Step 5: Control rod insertion failed"
        End If

        ' Step 6 - Record the core temperature after shutting down the reactor
        Me.textBlock1.Text &= vbNewLine & "Step 6: Core temperature after shutdown: " & sd.GetCoreTemperature()


        ' Step 7 - Record the core radiation levels after shutting down the reactor
        Me.textBlock1.Text &= vbNewLine & "Step 7: Core radiation level after shutdown: " & sd.GetRadiationLevel()


        ' Step 8 - Broadcast "Shutdown Complete" message
        sd.SignalShutdownComplete()
        Me.textBlock1.Text &= vbNewLine & "Step 8: Broadcasting shutdown complete message"


        Me.textBlock1.Text &= vbNewLine & "Test sequence complete: " & DateTime.Now.ToLongTimeString()
    End Sub
End Class
