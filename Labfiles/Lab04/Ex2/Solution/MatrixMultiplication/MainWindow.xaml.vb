Class MainWindow
    ''' <summary>
    ''' First matrix
    ''' </summary>
    Private matrix1(,) As Double

    ''' <summary>
    ''' Second matrix
    ''' </summary>
    Private matrix2(,) As Double

    ''' <summary>
    ''' Result of multiplying matrix1 and matrix2
    ''' </summary>
    Private result(,) As Double

    ''' <summary>
    ''' Event handler for all three combo boxes:
    ''' Creates matrices of requested size filled with zeroes
    ''' Displays matrices on the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MatrixDimensions_Changed(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Dim m1rows As Integer = 1
        Dim m1columns_m2rows As Integer = 1
        Dim m2columns As Integer = 1

        ' Set the matrix dimensions - note that matrix2 must have the same number of rows as matrix1 has columns
        If Not matrix1width Is Nothing Then m1columns_m2rows = matrix1width.SelectedIndex + 1
        If Not matrix1height Is Nothing Then m1rows = matrix1height.SelectedIndex + 1
        If Not matrix2width Is Nothing Then m2columns = matrix2width.SelectedIndex + 1

        ' matrices will be initialized with all zeros
        ReDim matrix1(m1columns_m2rows, m1rows)
        ReDim matrix2(m2columns, m1columns_m2rows)
        ReDim result(m2columns, m1rows)

        ' Display the matrices on the form
        InitializeGrid(grid1, matrix1)
        InitializeGrid(grid2, matrix2)
        InitializeGrid(grid3, result)
    End Sub

    ''' <summary>
    ''' Create a grid on the form displaying the matrix values in editable textboxes
    ''' </summary>
    ''' <param name="grd">A WPF grid control</param>
    ''' <param name="matrix">The matrix to display</param>
    Private Sub InitializeGrid(ByVal grd As Grid, ByVal matrix(,) As Double)
        If Not grd Is Nothing Then
            ' Reset the grid before doing anything
            grd.Children.Clear()
            grd.ColumnDefinitions.Clear()
            grd.RowDefinitions.Clear()

            ' Get the dimensions
            Dim columns As Integer = matrix.GetLength(0)
            Dim rows As Integer = matrix.GetLength(1)

            ' Add the correct number of coumns to the grid
            For x As Integer = 0 To columns - 1
                ' GridUnitType.Star - The value is expressed as a weighted proportion of available space
                grd.ColumnDefinitions.Add(New ColumnDefinition() With {.Width = New GridLength(1, GridUnitType.Star)})
            Next

            For y As Integer = 0 To rows - 1
                ' GridUnitType.Star - The value is expressed as a weighted proportion of available space
                grd.RowDefinitions.Add(New RowDefinition() With {.Height = New GridLength(1, GridUnitType.Star)})
            Next

            ' Fill each cell of the grid with an editable TextBox containing the value from the matrix - centered in the cell
            For x As Integer = 0 To columns - 1
                For y As Integer = 0 To rows - 1
                    Dim cell As Double = CType(matrix(x, y), Double)
                    Dim t As New TextBox()
                    t.Text = cell.ToString()
                    t.VerticalAlignment = System.Windows.VerticalAlignment.Center
                    t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                    t.SetValue(Grid.RowProperty, y)
                    t.SetValue(Grid.ColumnProperty, x)

                    grd.Children.Add(t)
                Next
            Next
        End If
    End Sub

    ''' <summary>
    ''' Do the matrix multiplication
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonCalculate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the current values from the grid and save them in the arrays
        GetValuesFromGrid(grid1, matrix1)
        GetValuesFromGrid(grid2, matrix2)

        ' Do the multiplication - checking for exceptions
        Try
            result = Matrix.MatrixMultiply(matrix1, matrix2)
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message)
        End Try

        ' Show the results
        InitializeGrid(grid3, result)
    End Sub

    ''' <summary>
    ''' Retrieve data from the grid and put it in the array representing the matrix
    ''' </summary>
    ''' <param name="grd">WPF Grid control holding matrix data</param>
    ''' <param name="matrix">Matrix array to store the values</param>
    Private Sub GetValuesFromGrid(ByVal grd As Grid, ByVal matrix(,) As Double)
        ' Set up counters
        Dim columns As Integer = grd.ColumnDefinitions.Count
        Dim rows As Integer = grd.RowDefinitions.Count

        ' Check grid has same dimensions as array
        If columns <> matrix.GetLength(0) Then Throw New ArgumentException("Grid and matrix have different number of columns")
        If rows <> matrix.GetLength(1) Then Throw New ArgumentException("Grid and matrix have different number of rows")

        ' Iterate over cells in Grid, copying to matrix array
        For c As Integer = 0 To grd.Children.Count - 1
            Dim t As TextBox = CType(grd.Children(c), TextBox)
            Dim row As Integer = Grid.GetRow(t)
            Dim column As Integer = Grid.GetColumn(t)
            matrix(column, row) = Double.Parse(t.Text)
        Next
    End Sub
End Class
