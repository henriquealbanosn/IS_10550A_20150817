Class MainWindow
    ''' <summary>
    ''' Initiate the reactor shutdown using a Switch object
    ''' Record details of shutdown status in a TextBlock - recording all exceptions thrown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShutDownButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.textBlock1.Text = "Initiating test sequence: " & DateTime.Now.ToLongTimeString()
        Dim sd As New SwitchDevices.Switch()

        ' Step 1 - disconnect from the Power Generator
        Try
            If sd.DisconnectPowerGenerator() = SwitchDevices.SuccessFailureResult.Fail Then
                Me.textBlock1.Text &=
                    vbNewLine & "Step 1: Failed to disconnect power generation system"
            Else
                Me.textBlock1.Text &=
                    vbNewLine & "Step 1: Successfully disconnected power generation system"
            End If
        Catch ex As SwitchDevices.PowerGeneratorCommsException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 1: " & ex.Message
        End Try

        ' Step 2 - Verify the status of the Primary Coolant System
        Try
            Select Case sd.VerifyPrimaryCoolantSystem()
                Case SwitchDevices.CoolantSystemStatus.OK
                    Me.textBlock1.Text &= vbNewLine & "Step 2: Primary coolant system OK"
                Case SwitchDevices.CoolantSystemStatus.Check
                    Me.textBlock1.Text &= vbNewLine & "Step 2: Primary coolant system requires manual check"
                Case SwitchDevices.CoolantSystemStatus.Fail
                    Me.textBlock1.Text &= vbNewLine & "Step 2: Problem reported with primary coolant system"
            End Select
        Catch ex As SwitchDevices.CoolantPressureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 2: " & ex.Message
        Catch ex As SwitchDevices.CoolantTemperatureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 2: " & ex.Message
        End Try



        ' Step 3 - Verify the status of the Backup Coolant System
        Try
            Select Case sd.VerifyBackupCoolantSystem()
                Case SwitchDevices.CoolantSystemStatus.OK
                    Me.textBlock1.Text &= vbNewLine & "Step 3: Backup coolant system OK"
                Case SwitchDevices.CoolantSystemStatus.Check
                    Me.textBlock1.Text &= vbNewLine & "Step 3: Backup coolant system requires manual check"
                Case SwitchDevices.CoolantSystemStatus.Fail
                    Me.textBlock1.Text &= vbNewLine & "Step 3: Backup reported with primary coolant system"
            End Select
        Catch ex As SwitchDevices.CoolantPressureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 3: " & ex.Message
        Catch ex As SwitchDevices.CoolantTemperatureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 3: " & ex.Message
        End Try


        ' Step 4 - Record the core temperature prior to shutting down the reactor
        Try
            Me.textBlock1.Text &= vbNewLine & "Step 4: Core temperature before shutdown: " & sd.GetCoreTemperature()
        Catch ex As SwitchDevices.CoreTemperatureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 4: " & ex.Message
        End Try


        ' Step 5 - Insert the control rods into the reactor
        Try
            If sd.InsertRodCluster() = SwitchDevices.SuccessFailureResult.Success Then
                Me.textBlock1.Text &= vbNewLine & "Step 5: Control rods successfully inserted"
            Else
                Me.textBlock1.Text &= vbNewLine & "Step 5: Control rod insertion failed"
            End If
        Catch ex As SwitchDevices.RodClusterReleaseException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 5: " & ex.Message
        End Try

        ' Step 6 - Record the core temperature after shutting down the reactor
        Try
            Me.textBlock1.Text &= vbNewLine & "Step 6: Core temperature after shutdown: " & sd.GetCoreTemperature()
        Catch ex As SwitchDevices.CoreTemperatureReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 6: " & ex.Message
        End Try


        ' Step 7 - Record the core radiation levels after shutting down the reactor
        Try
            Me.textBlock1.Text &= vbNewLine & "Step 7: Core radiation level after shutdown: " & sd.GetRadiationLevel()
        Catch ex As SwitchDevices.CoreRadiationLevelReadException
            Me.textBlock1.Text &=
                vbNewLine & "*** Exception in step 7: " & ex.Message
        End Try


        ' Step 8 - Broadcast "Shutdown Complete" message
        Try
            sd.SignalShutdownComplete()
            Me.textBlock1.Text &= vbNewLine & "Step 8: Broadcasting shutdown complete message"
        Catch ex As SwitchDevices.SignallingException
            Me.textBlock1.Text &=
            vbNewLine & "*** Exception in step 8: " & ex.Message
        End Try

        Me.textBlock1.Text &= vbNewLine & "Test sequence complete: " & DateTime.Now.ToLongTimeString()
    End Sub
End Class
