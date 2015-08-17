Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Diagnostics
Imports StressTestResult
Imports BinaryTree

Class DataAnalyzer
    ' Declare a String variable to hold the name of the file 
    ' that contains the stress test data.
    Private Const stressDataFilename As String =
        "D:\Labfiles\Lab14\StressData.dat"

    ' Declare a Tree variable to hold the loaded data.
    Private stressData As Tree(Of TestResult) = Nothing

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        ' Read the test data and populate the binary tree
        ' Use a BackgroundWorker object to avoid tying up the UI
        Dim workerThread As New BackgroundWorker()
        workerThread.WorkerReportsProgress = False
        workerThread.WorkerSupportsCancellation = False

        AddHandler workerThread.DoWork,
            Sub(o, args)
                Me.ReadTestData()
            End Sub

        AddHandler workerThread.RunWorkerCompleted,
            Sub(o, args)
                Me.DisplayResultsButton.IsEnabled = True
                Me.StatusMessageItem.Content = "Ready"
            End Sub

        workerThread.RunWorkerAsync()
        Me.StatusMessageItem.Content = "Reading test data ..."
    End Sub

    ' Add a method that reads the test data from the file specified by the stressDataFileName string
    ' and creates the stressData binary tree using this data.
    Private Sub ReadTestData()
        Try
            ' Open a stream over the file that holds the test data.
            Using readStream As FileStream = File.Open(stressDataFilename, FileMode.Open)
                ' The data is serialized as TestResult instances.
                ' Use a BinaryFormatter object to read the stream and
                ' deserialize the data.
                Dim formatter As New BinaryFormatter()
                Dim initialNode As TestResult =
                    CType(formatter.Deserialize(readStream), TestResult)

                ' Create the binary tree and use the first item retrieved
                ' as the root node. (Note: The tree will likely be 
                ' unbalanced, because it is probable that most nodes will
                ' have a value that is greater than or equal to the value in
                ' this root node - this is because of the way in which the
                ' test results are generated and the fact that the TestResult 
                ' class uses the deflection as the discriminator when it
                ' compares instances.)
                stressData = New Tree(Of TestResult)(initialNode)

                ' Read the TestResult instances from the rest of the file
                ' and add them into the binary tree.
                While readStream.Position < readStream.Length
                    Dim data As TestResult =
                        CType(formatter.Deserialize(readStream), TestResult)
                    stressData.Insert(data)
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Event-handling method for the Click event of the displayResults button.
    ''' <para>
    ''' This method retrieves the query criteria entered by the user on the form and then calls
    ''' the CreateQuery method to generate an enumerable result set.
    ''' </para>
    ''' The results are formatted by using the FormatResults method, 
    ''' and are then displayed in the results TextBox control on the form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayResultsButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            ' Capture the criteria for the start and end dates. Use DateTime.MinValue and DateTime.MaxValue as default values
            Dim dateStart As DateTime = If(String.IsNullOrWhiteSpace(Me.StartDatePicker.Text), DateTime.MinValue, DateTime.Parse(Me.StartDatePicker.Text))
            Dim dateEnd As DateTime = If(String.IsNullOrWhiteSpace(Me.EndDatePicker.Text), DateTime.MaxValue, DateTime.Parse(Me.EndDatePicker.Text))

            ' The date and times in the test data include a time of day, 
            ' whereas the dates selected by the user will have the time of day set to midnight.
            ' Consequently, you need to add 1 day to the end date specified by the user
            ' to avoid losing test results generated on that date.
            If dateEnd < DateTime.MaxValue Then
                dateEnd = dateEnd.AddDays(1)
            End If

            ' Capture the temperature range criteria
            Dim temperatureStart As Short = CType(Me.FromTemperatureSlider.Value, Short)
            Dim temperatureEnd As Short = CType(Me.ToTemperatureSlider.Value, Short)

            ' Capture the applied stress criteria
            Dim appliedStressStart As Short = CType(Me.FromAppliedStressSlider.Value, Short)
            Dim appliedStressEnd As Short = CType(Me.ToAppliedStressSlider.Value, Short)

            ' Capture the deflection criteria
            Dim deflectionStart As Short = CType(Me.FromDeflectionSlider.Value, Short)
            Dim deflectionEnd As Short = CType(Me.ToDeflectionSlider.Value, Short)

            ' Generate an enumerable result set using these criteria
            Dim query As IEnumerable(Of TestResult) = CreateQuery(dateStart, dateEnd, temperatureStart, temperatureEnd, appliedStressStart, appliedStressEnd, deflectionStart, deflectionEnd)

            ' Determine how long the quety actually takes to run -
            ' Calling the Count() method retrieves all rows
            Dim timer As Stopwatch = Stopwatch.StartNew()
            Dim rowCount As Integer = query.Count()
            Dim timeTaken As Long = timer.ElapsedMilliseconds
            QueryTimeLabel.Content = String.Format("Time (ms): {0}", timeTaken)

            ' Format the results into a string
            ' This might take some time, so use a BackgroundWorker to avoid tying up the user interface
            Dim workerThread As New BackgroundWorker()
            workerThread.WorkerReportsProgress = False
            workerThread.WorkerSupportsCancellation = False

            ' Return the formatted string as the result of the background 
            ' operation.
            AddHandler workerThread.DoWork,
                Sub(o, args)
                    args.Result = FormatResults(query)
                End Sub

            ' When the BackgroundWorker object has completed reading 
            ' the test data, display the results, set the status bar 
            ' to "Ready", and enable the displayResults button.
            AddHandler workerThread.RunWorkerCompleted,
                Sub(o, args)
                    Me.ResultsTextBox.Text = CType(args.Result, String)
                    Me.DisplayResultsButton.IsEnabled = True
                    Me.StatusMessageItem.Content = "Ready"
                End Sub

            ' Start the BackgroundWorker, disable the Display button,
            ' and set the status bar to "Fetching results ..."
            workerThread.RunWorkerAsync()
            Me.DisplayResultsButton.IsEnabled = False
            Me.StatusMessageItem.Content = "Fetching results ..."
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method that generates an enumerable collection of TestResult items from the stressData
    ''' binary tree, based on the criteria specified by the user. All data fetched will fall within
    ''' the range specified by these criteria.
    ''' </summary>
    ''' <param name="dateStart">
    ''' The start date criterion.
    ''' </param>
    ''' <param name="dateEnd">
    ''' The end date criterion.
    ''' </param>
    ''' <param name="temperatureStart">
    ''' The lower temperature criterion,
    ''' </param>
    ''' <param name="temperatureEnd">
    ''' The upper temperature criterion.
    ''' </param>
    ''' <param name="appliedStressStart">
    ''' The lower applied stress criterion.
    ''' </param>
    ''' <param name="appliedStressEnd">
    ''' The upper applied stress criterion.
    ''' </param>
    ''' <param name="deflectionStart">
    ''' The lower deflection criterion.
    ''' </param>
    ''' <param name="deflectionEnd">
    ''' The upper deflection criterion.
    ''' </param>
    ''' <returns>
    ''' An IEnumerable&lt;TestResult&gt; object that can be used to iterate through the results.
    ''' </returns>
    ''' <remarks></remarks>
    Private Function CreateQuery(ByVal dateStart As DateTime, ByVal dateEnd As DateTime, ByVal temperatureStart As Short, ByVal temperatureEnd As Short, ByVal appliedStressStart As Short,
                                 ByVal appliedStressEnd As Short, ByVal deflectionStart As Short, ByVal deflectionEnd As Short) As IEnumerable(Of TestResult)
        Dim query As IEnumerable(Of TestResult) =
            From result In stressData
            Where result.TestDate >= dateStart AndAlso
                  result.TestDate <= dateEnd AndAlso
                  result.Temperature >= temperatureStart AndAlso
                  result.Temperature <= temperatureEnd AndAlso
                  result.AppliedStress >= appliedStressStart AndAlso
                  result.AppliedStress <= appliedStressEnd AndAlso
                  result.Deflection >= deflectionStart AndAlso
                  result.Deflection <= deflectionEnd
            Order By result.TestDate
            Select result

        Return query
    End Function

    ''' <summary>
    ''' Fetch the data defined by the LINQ query specified as the parameter 
    ''' and format the results as a string.
    ''' </summary>
    ''' <param name="query">
    ''' The IEnumerable&lt;TestResult&gt;
    ''' </param>
    ''' <returns>
    ''' A formatted string that contains the data fetched by the query.
    ''' </returns>
    ''' <remarks></remarks>
    Private Function FormatResults(ByVal query As IEnumerable(Of TestResult)) As String
        ' Use a StringBuilder object to construct the formatted string.
        Dim builder As New StringBuilder()

        ' Add a heading and indicate the number of matching results retrieved.
        builder.Append(String.Format("Stress Test Results. Number of matching items: {0}" & vbNewLine & vbNewLine, query.Count()))

        ' Add column headings.
        builder.Append("Test Date" & vbTab & vbTab & "Temperature" & vbTab & "Applied Stress" & vbTab & "Deflection" & vbNewLine)

        ' Iterate through the results and format each item found.
        For Each itm In query
            builder.Append(String.Format("{0:d}" & vbTab & vbTab & "{1}" & vbTab & vbTab & "{2}" & vbTab & vbTab & "{3}" & vbNewLine,
            itm.TestDate,
            itm.Temperature,
            itm.AppliedStress,
            itm.Deflection))
        Next

        ' Return the string that is constructed by using the 
        ' StringBuilder object
        Return builder.ToString()
    End Function
End Class
