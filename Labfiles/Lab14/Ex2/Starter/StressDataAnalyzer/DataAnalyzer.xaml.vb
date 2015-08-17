Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Diagnostics
Imports System.Reflection
Imports StressTestResult
Imports BinaryTree
Imports Expressions = System.Linq.Expressions

''' <summary>
''' Enumeration that specifies the ways in which the user can sort data
''' </summary>
''' <remarks></remarks>
Enum OrderByKey
    ByDate
    ByTemperature
    ByAppliedStress
    ByDeflection
    None
End Enum

Class DataAnalyzer
    ' Declare a String variable to hold the name of the file 
    ' that contains the stress test data.
    Private Const stressDataFilename As String =
        "D:\Labfiles\Lab14\StressData.dat"

    ' Declare a Tree variable to hold the loaded data.
    Private stressData As Tree(Of TestResult) = Nothing

    ''' <summary>
    ''' Event-handling method for the Loaded event of the WPF window.
    ''' <para>
    ''' This method calls readTestData to read in the test data and populate the binary tree with the results.
    ''' </para>
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

        ' When the BackgroundWorker has completed reading the test data
        ' set the status bar to "Ready" and enable the Display button
        AddHandler workerThread.RunWorkerCompleted,
            Sub(o, args)
                Me.DisplayResultsButton.IsEnabled = True
                Me.StatusMessageItem.Content = "Ready"
            End Sub

        ' Start the BackgroundWorker and set the status bar to "Reading test data ..."
        workerThread.RunWorkerAsync()
        Me.StatusMessageItem.Content = "Reading test data ..."
    End Sub

    ''' <summary>
    ''' Method that reads the test data from the file specified by the stressDataFileName string
    ''' and creates the stressData binary tree using this data.
    ''' </summary>
    ''' <remarks></remarks>
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

#Region "Event-handling methods for enabling/disabling query criteria and row limiting"
    Private Sub SpecifyDateRange_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.StartDatePicker.IsEnabled = True
        Me.EndDatePicker.IsEnabled = True
    End Sub

    Private Sub SpecifyDateRange_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.StartDatePicker.IsEnabled = False
        Me.EndDatePicker.IsEnabled = False
    End Sub

    Private Sub SpecifyTemperatureRange_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromTemperatureSlider.IsEnabled = True
        Me.ToTemperatureSlider.IsEnabled = True
        Me.DisplayFromTemperatureTextBox.IsEnabled = True
        Me.DisplayToTemperatureTextBox.IsEnabled = True
    End Sub

    Private Sub SpecifyTemperatureRange_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromTemperatureSlider.IsEnabled = False
        Me.ToTemperatureSlider.IsEnabled = False
        Me.DisplayFromTemperatureTextBox.IsEnabled = False
        Me.DisplayToTemperatureTextBox.IsEnabled = False
    End Sub

    Private Sub SpecifyAppliedStressRange_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromAppliedStressSlider.IsEnabled = True
        Me.ToAppliedStressSlider.IsEnabled = True
        Me.DisplayFromAppliedStressTextBox.IsEnabled = True
        Me.DisplayToAppliedStressTextBox.IsEnabled = True
    End Sub

    Private Sub SpecifyAppliedStressRange_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromAppliedStressSlider.IsEnabled = False
        Me.ToAppliedStressSlider.IsEnabled = False
        Me.DisplayFromAppliedStressTextBox.IsEnabled = False
        Me.DisplayToAppliedStressTextBox.IsEnabled = False
    End Sub

    Private Sub SpecifyDeflectionRange_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromDeflectionSlider.IsEnabled = True
        Me.ToDeflectionSlider.IsEnabled = True
        Me.DisplayFromDeflectionTextBox.IsEnabled = True
        Me.DisplayToDeflectionTextBox.IsEnabled = True
    End Sub

    Private Sub SpecifyDeflectionRange_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.FromDeflectionSlider.IsEnabled = False
        Me.ToDeflectionSlider.IsEnabled = False
        Me.DisplayFromDeflectionTextBox.IsEnabled = False
        Me.DisplayToDeflectionTextBox.IsEnabled = False
    End Sub

    Private Sub Limit_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.NumRowsSlider.IsEnabled = True
        Me.DisplayNumRowsTextBox.IsEnabled = True
    End Sub

    Private Sub Limit_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.NumRowsSlider.IsEnabled = False
        Me.DisplayNumRowsTextBox.IsEnabled = False
    End Sub
#End Region

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

            ' Determine how (and whether) the user wants to sort data
            Dim obKey As OrderByKey = OrderByKey.None

            If Me.OrderByDateRadioButton.IsChecked.Value Then
                obKey = OrderByKey.ByDate
            End If

            If Me.OrderByTemperatureRadioButton.IsChecked.Value Then
                obKey = OrderByKey.ByTemperature
            End If

            If Me.OrderByAppliedStressRadioButton.IsChecked.Value Then
                obKey = OrderByKey.ByAppliedStress
            End If

            If Me.OrderByDeflectionRadioButton.IsChecked.Value Then
                obKey = OrderByKey.ByDeflection
            End If

            ' Generate an enumerable result set using these criteria
            Dim query As IEnumerable(Of TestResult) = CreateQuery(Me.SpecifyDateRangeCheckBox.IsChecked.Value, dateStart, dateEnd,
                                                            Me.SpecifyTemperatureRangeCheckBox.IsChecked.Value, temperatureStart, temperatureEnd,
                                                            Me.SpecifyAppliedStressRangeCheckBox.IsChecked.Value, appliedStressStart, appliedStressEnd,
                                                            Me.SpecifyDeflectionRangeCheckBox.IsChecked.Value, deflectionStart, deflectionEnd,
                                                            obKey, Me.LimitCheckBox.IsChecked.Value, CType(Me.NumRowsSlider.Value, Integer))

            ' Determine how long the query actually takes to run -
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
    ''' binary tree, based on the criteria and sort key specified by the user. All data fetched will fall within
    ''' the range specified by these criteria.
    ''' </summary>
    ''' <param name="dateRangeSpecified">
    ''' A boolean that indicates whether the specified criteria for the test date data.
    ''' </param>
    ''' <param name="dateStart">
    ''' The start date criterion.
    ''' </param>
    ''' <param name="dateEnd">
    ''' The end date criterion.
    ''' </param>
    ''' <param name="temperatureRangeSpecified">
    ''' A boolean that indicates whether the specified criteria for the temperature data.
    ''' </param>
    ''' <param name="temperatureStart">
    ''' The lower temperature criterion,
    ''' </param>
    ''' <param name="temperatureEnd">
    ''' The upper temperature criterion.
    ''' </param>
    ''' <param name="appliedStressRangeSpecified">
    ''' A boolean that indicates whether the specified criteria for the applied stress data.
    ''' </param>
    ''' <param name="appliedStressStart">
    ''' The lower applied stress criterion.
    ''' </param>
    ''' <param name="appliedStressEnd">
    ''' The upper applied stress criterion.
    ''' </param>
    ''' <param name="deflectionRangeSpecified">
    ''' A boolean that indicates whether the specified criteria for the deflection data.
    ''' </param>
    ''' <param name="deflectionStart">
    ''' The lower deflection criterion.
    ''' </param>
    ''' <param name="deflectionEnd">
    ''' The upper deflection criterion.
    ''' </param>
    ''' <param name="obKey">
    ''' </param>
    ''' The sort key. Data will be retrieved in ascending order of this key.
    ''' <returns>
    ''' An IEnumerable&lt;TestResult&gt; object that can be used to iterate through the results.
    ''' </returns> 
    ''' <remarks></remarks>
    Private Function CreateQuery(ByVal dateRangeSpecified As Boolean, ByVal dateStart As DateTime, ByVal dateEnd As DateTime,
                    ByVal temperatureRangeSpecified As Boolean, ByVal temperatureStart As Short, ByVal temperatureEnd As Short,
                    ByVal appliedStressRangeSpecified As Boolean, ByVal appliedStressStart As Short, ByVal appliedStressEnd As Short,
                    ByVal deflectionRangeSpecified As Boolean, ByVal deflectionStart As Short, ByVal deflectionEnd As Short,
                    ByVal obKey As OrderByKey, ByVal limitRows As Boolean, ByVal numRows As Integer)

        ' TODO: - Examine the CreateQuery method

        ' Build the lambda expression that encapsulates the query criteria specified by the user
        ' This can be null if the user specified no criteria
        Dim getCriteria As Expressions.Expression(Of Func(Of TestResult, Boolean)) =
            BuildLambdaExpressionForQueryCriteria(dateRangeSpecified, dateStart, dateEnd,
                temperatureRangeSpecified, temperatureStart, temperatureEnd,
                appliedStressRangeSpecified, appliedStressStart, appliedStressEnd,
                deflectionRangeSpecified, deflectionStart, deflectionEnd)

        ' Build the lambda expression that defines the sort key specified by the user
        ' This can be null if the user elected to use the default sort key implemented by the TestResult type
        Dim getOrderBy As Expressions.Expression(Of Func(Of TestResult, ValueType)) = BuildLambdaExpressionForOrderBy(obKey)

        ' Construct an enumerable query object
        ' Only filter and sort data if necessary
        Dim query As IEnumerable(Of TestResult) = stressData

        If Not getCriteria Is Nothing Then
            query = query.Where(getCriteria.Compile())
        End If

        If Not getOrderBy Is Nothing Then
            query = query.OrderBy(getOrderBy.Compile())
        End If

        ' If the user specified to limit the number of rows returned
        ' then only retrieve the first numRows rows
        If limitRows Then
            query = query.Take(numRows)
        End If

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

        ' Return the string that is constructed by using the StringBuilder object
        Return builder.ToString()
    End Function

    ''' <summary>
    ''' Method that dynamically generates a lambda expression that matches the query criteria specified by the user.
    ''' </summary>
    ''' <param name="dateRangeSpecified">
    ''' A boolean. It is true if the user specified a date range for filtering data.
    ''' </param>
    ''' <param name="startDate">
    ''' The lower value of the date range, if specified.
    ''' </param>
    ''' <param name="endDate">
    ''' The upper value of the date range, if specified.
    ''' </param>
    ''' <param name="temperatureRangeSpecified">
    ''' A boolean. It is true if the user specified a temperature range for filtering data.</param>
    ''' <param name="fromTemperature">
    ''' The lower value of the temperature range, if specified.
    ''' </param>
    ''' <param name="toTemperature">
    ''' The upper value of the temperature range, if specified.
    ''' </param>
    ''' <param name="appliedStressRangeSpecified">
    ''' A boolean. It is true if the user specified an applied stress range for filtering data.</param>
    ''' <param name="fromStressRange">
    ''' The lower value of the applied stress range, if specified.
    ''' </param>
    ''' <param name="toStressRange">
    ''' The upper value of the applied stress range, if specified.
    ''' </param>
    ''' <param name="deflectionRangeSpecified">
    ''' A boolean. It is true if the user specified a deflection range for filtering data.
    ''' </param>
    ''' <param name="fromDeflection">
    ''' The lower value of the deflection range, if specified.
    ''' </param>
    ''' <param name="toDeflection">
    ''' The upper value of the deflection range, if specified.
    ''' </param>
    ''' <returns>
    ''' An Expression that defines a lambda expression that filters data using the criteria specified by the user,
    ''' or null if the user did not specify any query criteria.
    ''' </returns>
    Private Function BuildLambdaExpressionForQueryCriteria(ByVal dateRangeSpecified As Boolean, ByVal startDate As DateTime, ByVal endDate As DateTime,
                                              ByVal temperatureRangeSpecified As Boolean, ByVal fromTemperature As Short, ByVal toTemperature As Short,
                                              ByVal appliedStressRangeSpecified As Boolean, ByVal fromStressRange As Short, ByVal toStressRange As Short,
                                              ByVal deflectionRangeSpecified As Boolean, ByVal fromDeflection As Short, ByVal toDeflection As Short) As Expressions.Expression(Of Func(Of TestResult, Boolean))
        ' Define an Expression object to populate
        Dim lambda As Expressions.Expression(Of Func(Of TestResult, Boolean)) = Nothing

        ' Verify that the user actually specified some criteria
        If dateRangeSpecified OrElse temperatureRangeSpecified OrElse appliedStressRangeSpecified OrElse deflectionRangeSpecified Then
            ' TODO: - Complete the BuildLambdaExpressionForQueryCriteria method.
            ' Create the expression that defines the parameter for the 
            ' lambda expression.
            ' The type is TestResult, and the lambda expression refers to
            ' it with the name "item".

            ' Create expressions for each of the possible conditions.

            ' Build Boolean expressions for each of the possible criteria 
            ' that the user specifies.
            ' These method calls may return null if the user did not 
            ' specify criteria for a property.

            ' Combine the Boolean expressions together into a single body.

            ' Build the lambda expression using the parameter and the 
            ' body expressions.
        End If

        ' Return the lambda expression. If the user did not specify any criteria this value will be null.
        Return lambda
    End Function

#Region "Support methods used to build the dynamic lambda expression for specifying query criteria"

    ''' <summary>
    ''' Method that builds the boolean expression that evaluates criteria specified for the date range.
    ''' </summary>
    ''' <param name="dateRangeSpecified">
    ''' Boolean value that indicates whether the user specified a date range.
    ''' </param>
    ''' <param name="startDate">
    ''' The start date specified by the user.
    ''' </param>
    ''' <param name="endDate">
    ''' The end date specified by the user.
    ''' </param>
    ''' <param name="testResultType">
    ''' The type of the TestResult structure holding the TestDate property
    ''' </param>
    ''' <param name="itemBeingQueried">
    ''' The parameter passed in to the lambda expression containing the item in the TestResult collection being examined.
    ''' </param>
    ''' <returns>
    ''' A boolean Expression object, or null if the user did not specify a date range.
    ''' </returns>
    Private Function BuildDateExpressionBody(ByVal dateRangeSpecified As Boolean, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal testResultType As Type, ByVal itemBeingQueried As Expressions.ParameterExpression) As Expressions.BinaryExpression
        ' Define an Expression object to populate.
        Dim dateCondition As Expressions.BinaryExpression = Nothing

        ' If the user has specified a date range, generate the expression:
        '
        '     item.TestDate >= startDate && item.TestDate <= endDate
        '
        If dateRangeSpecified Then
            ' TODO: - Complete the BuildDateExpressionBody method.
            ' Generate the expression:
            '
            '    item.TestDate >= startDate
            '

            ' Generate the expression:
            '
            '    item.Testdate <= endDate
            '

            ' Combine the expressions with the && operator.

        End If

        ' Return the expression.
        Return dateCondition
    End Function

    ''' <summary>
    ''' Method that builds the boolean expression that evaluates criteria specified for the numeric properties 
    ''' (temperature, applied stress, and deflection).
    ''' </summary>
    ''' <param name="dateRangeSpecified">
    ''' Boolean value that indicates whether the user specified a range for the property.
    ''' </param>
    ''' <param name="lowerRange">
    ''' The lower limit specified by the user.
    ''' </param>
    ''' <param name="upperRange">
    ''' The upper limit specified by the user.
    ''' </param>
    ''' <param name="testResultType">
    ''' The type of the TestResult structure holding the property being examined
    ''' </param>
    ''' <param name="propertyName">
    ''' The name of the property in the TestResult structure the criteria query.
    ''' </param>
    ''' <param name="itemBeingQueried">
    ''' The parameter passed in to the lambda expression containing the item in the TestResult collection being examined.
    ''' </param>
    ''' <returns>
    ''' A boolean Expression object, or null if the user did not specify a date range.
    ''' </returns>
    Private Function BuildNumericExpressionBody(ByVal rangeSpecified As Boolean, ByVal lowerRange As Short, ByVal upperRange As Short, ByVal testResultType As Type, ByVal propertyName As String, ByVal itemBeingQueried As Expressions.ParameterExpression) As Expressions.BinaryExpression
        ' Define an Expression object to populate.
        Dim booleanCondition As Expressions.BinaryExpression = Nothing

        ' If the user has specified a range, generate the expression:
        '
        '     item.<Property> >= lowerRange && item.<Property> <= upperRange
        '
        If rangeSpecified Then
            ' TODO: - Complete the BuildNumericExpressionBody method.
            ' Generate the expression:
            '
            '    item.<Property> >= lowerRange
            '

            ' Generate the expression:
            '
            '    item.<Property> <= upperRange
            '

            ' Combine the expressions with the && operator.

        End If

        ' Return the expression.
        Return booleanCondition
    End Function

    ''' <summary>
    ''' Combine the boolean expressions defined by the parameters into a single boolean expression.
    ''' If all the expressions are null, return an expression that evaluates to True.
    ''' </summary>
    ''' <param name="dateCondition">
    ''' The date boolean expression (item.TestDate &ge; date1 && item.TestDate &le; date2)
    ''' This may be null.
    ''' </param>
    ''' <param name="temperatureCondition"></param>
    ''' The temperature boolean expression (item.Temperature &ge; temp1 && item.Temperature &le; temp2)
    ''' This may be null.
    ''' <param name="appliedStressCondition">
    ''' The applied stress boolean expression (item.AppliedStress &ge; stress1 && item.AppliedStress &le; stress2)
    ''' This may be null.
    ''' </param>
    ''' <param name="deflectionCondition">
    ''' The deflection boolean expression (item.Deflection &ge; def1 && item.Deflection &le; def2)
    ''' This may be null.
    ''' </param>
    ''' <returns></returns>
    Private Function BuildLambdaExpressionBody(ByVal dateCondition As Expressions.BinaryExpression, ByVal temperatureCondition As Expressions.BinaryExpression, ByVal appliedStressCondition As Expressions.BinaryExpression, ByVal deflectionCondition As Expressions.BinaryExpression) As Expressions.Expression
        ' TODO: - Complete the BuildLambdaExpressionBody method.
        ' Combine the expressions together into the body of the lambda expression.
        ' Start with the dateCondition expression.
        Dim body As Expressions.Expression = Nothing

        ' Add the temperatureCondition expression.

        ' Repeat the same logic for the remaining condition expressions.


        ' If the user specified no conditions, set the body to the constant expression True.
        ' NOTE: This case should not happen if this method is called correctly.
        '       It has been added to provide additional safety.
        If body Is Nothing Then
            body = Expressions.Expression.Constant(True)
        End If

        Return body
    End Function
#End Region

    ''' <summary>
    ''' Method that generates a lambda expression that defines the order for presenting data.
    ''' </summary>
    ''' <param name="obKey">
    ''' A member of the OrderByKey enumeration. 
    ''' It specifies the key to order the data, or None if the user wants to use the default order
    ''' of the TestResult type
    ''' </param>
    ''' <returns>
    ''' An Expression that defines a lambda expression that orders data by the column specified by the user,
    ''' or null if the user has not specified a field to order by.
    ''' </returns>
    Private Function BuildLambdaExpressionForOrderBy(ByVal obKey As OrderByKey) As Expressions.Expression(Of Func(Of TestResult, ValueType))
        ' Define an Expression object to populate
        Dim lambda As Expressions.Expression(Of Func(Of TestResult, ValueType)) = Nothing

        ' Verify that the user has actually specified a sort key
        If obKey <> OrderByKey.None Then
            ' Create the expression that defines the parameter for the
            ' lambda expression.
            ' The type is TestResult, and the lambda expression refers to 
            ' it with the name "item".
            ' TODO: - Create the type reference and ParameterExpression in the BuildLambdaExpressionForOrderBy method 

            ' Create the expression that will define the sort key that
            ' the lambda expression returns.
            ' This expression will reference one of the properties in the
            ' TestResult structure depending on the key that the user
            ' specifies.
            ' TODO: - Create a MemberExpression and MemberInfo object

            ' TODO: - Evaluate the obKey parameter to determine the property to sort by
            ' If the user selected the date column, set the property object
            ' to TestDate.
            ' If the user selected the temperature column,set the property 
            ' object to Temperature.
            ' If the user selected the applied stress column,set the property
            ' object to AppliedStress.
            ' If the user selected the deflection column,set the property 
            ' object to Deflection.

            ' Construct an Expression that specifies the value in the field 
            ' that the property object references in the TestResult object.
            ' TODO: - Construct the expression that specifies the OrderBy field

            ' Cast the sortKey object to a ValueType object (ValueType is the 
            ' ancestor of all value types, including DateTime and short)
            ' TODO: - Create a UnaryExpression object to convert the sortKey object to a ValueType

            ' Build the lambda expression by using the parameter and the 
            ' expression that contains the sort key
            ' TODO: - Create the OrderBy lambda expression 
        End If

        ' Return the lambda expression
        Return lambda
    End Function
End Class
