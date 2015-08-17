Class MainWindow
    ''' <summary>
    ''' Do the GCD calculations
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FindGCDButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim thirdNumber As Integer
        Dim fourthNumber As Integer
        Dim fifthNumber As Integer

        If Not GetPostiveIntegerFromTextBox(integer1, firstNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer2, secondNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer3, thirdNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer4, fourthNumber) Then Return
        If Not GetPostiveIntegerFromTextBox(integer5, fifthNumber) Then Return

        Dim timeEuclid As Long
        Dim timeStein As Long

        ' Display results in ticks - milliseconds is not a big enough resolution
        If sender Is FindGCDButton Then ' Euclid for two integers and graph
            ' Do the calculations
            Me.ResultEuclidLabel.Content =
                String.Format("Euclid: {0}, Time (ticks): {1}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, timeEuclid), timeEuclid)
            Me.ResultSteinLabel.Content = String.Format("Stein: {0}, Time (ticks): {1}", GCDAlgorithms.FindGCDStein(firstNumber, secondNumber, timeStein), timeStein)

            ' Get the preferred colors and orientation
            Dim selectedEuclidColor As String =
                CType(Me.EuclidColorListBox.SelectedItem, ListBoxItem).Content.ToString()
            Dim selectedSteinColor As String =
                CType(Me.SteinColorListBox.SelectedItem, ListBoxItem).Content.ToString()

            Dim orient As Orientation

            If Me.ChartOrientationListBox.SelectedIndex = 0 Then
                orient = Orientation.Vertical
            Else
                orient = Orientation.Horizontal
            End If

            ' Call DrawGraph
            DrawGraph(timeEuclid, timeStein,
                orient:=orient,
                colorStein:=selectedSteinColor,
                colorEuclid:=selectedEuclidColor)
        ElseIf sender Is FindGCD3Button Then ' Euclid for three integers
            Me.ResultEuclidLabel.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber, timeEuclid), timeEuclid)
            Me.ResultSteinLabel.Content = "N/A"
        ElseIf sender Is FindGCD4Button Then ' Euclid for four integers
            Me.ResultEuclidLabel.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber, timeEuclid), timeEuclid)
            Me.ResultSteinLabel.Content = "N/A"
        ElseIf sender Is FindGCD5Button Then ' Euclid for five integers
            Me.ResultEuclidLabel.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber, timeEuclid), timeEuclid)
            Me.ResultSteinLabel.Content = "N/A"
        End If
    End Sub

    ''' <summary>
    ''' Read a postive integer from a TextBox
    ''' Displays a message box with the data if the text can't be parsed.
    ''' </summary>
    ''' <param name="inputTextBox">TextBox to read</param>
    ''' <param name="i">Postive integer (out parameter)</param>
    ''' <returns>True if success, false otherwise</returns>
    Private Function GetPostiveIntegerFromTextBox(ByVal inputTextBox As TextBox, ByRef i As Integer) As Boolean
        i = -1

        If Integer.TryParse(inputTextBox.Text, i) Then
            If i >= 0 Then Return True
        End If

        MessageBox.Show("Not a positive integer value: " & inputTextBox.Text)

        Return False
    End Function

    ' Add optional parameters for orientation and colors
    ''' <summary>
    ''' Display the results in a simple graph
    ''' </summary>
    ''' <param name="euclidTime">Time taken by Euclid algorithm</param>
    ''' <param name="steinTime">Time taken by Stein algorithm</param>
    Private Sub DrawGraph(ByVal euclidTime As Long, ByVal steinTime As Long,
        Optional ByVal orient As Orientation = Orientation.Horizontal,
        Optional ByVal colorEuclid As String = "Red",
        Optional ByVal colorStein As String = "Blue")

        ' Clear the canvas before we start
        ChartCanvasStackPanel.Children.Clear()

        Dim euclidProportion As Double
        Dim steinProportion As Double

        ' Use optional color parameters
        ' Get brushes in requested colors
        Dim bc = New BrushConverter()
        Dim bEuclid As Brush = CType(bc.ConvertFromString(colorEuclid), Brush)
        Dim bStein As Brush = CType(bc.ConvertFromString(colorStein), Brush)

        ' Create two colored rectangles
        Dim rEuclid As New Rectangle()
        rEuclid.Stroke = bEuclid
        rEuclid.Fill = bEuclid
        rEuclid.VerticalAlignment = VerticalAlignment.Bottom
        rEuclid.HorizontalAlignment = HorizontalAlignment.Left

        Dim rStein As New Rectangle()
        rStein.Stroke = bStein
        rStein.Fill = bStein
        rStein.VerticalAlignment = VerticalAlignment.Bottom
        rStein.HorizontalAlignment = HorizontalAlignment.Left

        ' Calculate relative sizes (largest = 1)
        If euclidTime > steinTime Then
            euclidProportion = 1
            steinProportion = CType(steinTime, Double) / CType(euclidTime, Double)
        ElseIf (euclidTime < steinTime) Then
            steinProportion = 1
            euclidProportion = CType(euclidTime, Double) / CType(steinTime, Double)
        Else
            euclidProportion = steinProportion = 1
        End If

        ' Calculate rectangle sizes and orientation
        ChartCanvasStackPanel.Orientation = orient

        If orient = Orientation.Horizontal Then
            rEuclid.Height = ChartCanvasStackPanel.ActualHeight * euclidProportion
            rStein.Height = ChartCanvasStackPanel.ActualHeight * steinProportion
            rEuclid.Width = ChartCanvasStackPanel.ActualWidth / 2
            rStein.Width = ChartCanvasStackPanel.ActualWidth / 2
        Else
            rEuclid.Width = ChartCanvasStackPanel.ActualWidth * euclidProportion
            rStein.Width = ChartCanvasStackPanel.ActualWidth * steinProportion
            rEuclid.Height = ChartCanvasStackPanel.ActualHeight / 2
            rStein.Height = ChartCanvasStackPanel.ActualHeight / 2
        End If

        ' Add the rectangles to the chart
        ChartCanvasStackPanel.Children.Add(rEuclid)
        ChartCanvasStackPanel.Children.Add(rStein)
    End Sub
End Class
