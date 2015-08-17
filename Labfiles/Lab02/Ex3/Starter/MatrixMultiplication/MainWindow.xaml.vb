Class MainWindow
    ' TODO: Task 2 Declare variables
    ' Declare three arrays of doubles to hold the 3 matrices:
    ' The two input matrices and the result matrix

    ''' <summary>
    ''' Event handler for all three combo boxes:
    ''' Creates matrices of requested size filled with zeroes
    ''' Displays matrices on the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MatrixDimensions_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
        Dim m1rows As Integer = 1
        Dim m1columns_m2rows As Integer = 1
        Dim m2columns As Integer = 1

        ' Set the matrix dimensions - note that matrix2 must have the same number of rows as matrix1 has columns
        If Not Matrix1WidthComboBox Is Nothing Then m1columns_m2rows = Matrix1WidthComboBox.SelectedIndex
        If Not MatrixHeightComboBox Is Nothing Then m1rows = MatrixHeightComboBox.SelectedIndex
        If Not Matrix2WidthComboBox Is Nothing Then m2columns = Matrix2WidthComboBox.SelectedIndex

        ' Matrices will be initialized with all zeros
        ReDim matrix1(m1columns_m2rows, m1rows)
        ReDim matrix2(m2columns, m1columns_m2rows)
        ReDim result(m2columns, m1rows)

        ' Display the matrices on the form
        initializeGrid(Matrix1Grid, matrix1)
        initializeGrid(Matrix2Grid, matrix2)
        initializeGrid(ResultMatrixGrid, result)
    End Sub

    ''' <summary>
    ''' Create a grid on the form displaying the matrix values in editable textboxes
    ''' </summary>
    ''' <param name="grid">A WPF grid control</param>
    ''' <param name="matrix">The matrix to display</param>
    Private Sub initializeGrid(ByVal grid As Grid, ByVal matrix(,) As Double)
        If Not grid Is Nothing Then
            ' Reset the grid before doing anything
            grid.Children.Clear()
            grid.ColumnDefinitions.Clear()
            grid.RowDefinitions.Clear()

            ' Get the dimensions
            Dim columns As Integer = matrix.GetLength(0)
            Dim rows As Integer = matrix.GetLength(1)

            ' Add the correct number of coumns to the grid
            For x As Integer = 0 To columns - 1
                ' GridUnitType.Star - The value is expressed as a weighted proportion of available space
                grid.ColumnDefinitions.Add(New ColumnDefinition() With {.Width = New GridLength(1, GridUnitType.Star)})
            Next

            For y As Integer = 0 To rows - 1
                ' GridUnitType.Star - The value is expressed as a weighted proportion of available space
                grid.RowDefinitions.Add(New RowDefinition() With {.Height = New GridLength(1, GridUnitType.Star)})
            Next

            ' Fill each cell of the grid with an editable TextBox containing the value from the matrix - centered in the cell
            For x As Integer = 0 To columns - 1
                For y As Integer = 0 To rows - 1
                    Dim cell As Double = CType(matrix(x, y), Double)
                    Dim t As New TextBox()
                    t.Text = cell.ToString()
                    t.VerticalAlignment = System.Windows.VerticalAlignment.Center
                    t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                    t.SetValue(grid.RowProperty, y)
                    t.SetValue(grid.ColumnProperty, x)
                    grid.Children.Add(t)
                Next
            Next
        End If
    End Sub

    Private Sub CalculateButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' TODO: Task 2 Copy data from input Grids
        ' Retrieve the contents of the first two grids into the first two matrices

        ' TODO: Task 2 Get the matrix dimensions
        ' Discover the dimensions of the input matrices
        ' (Remember that the number of columns in the first matrix will 
        ' always be the same as the number of rows in the second matrix)

        ' TODO: Task 3 Calculate the result
        ' Calculate the contents of each cell in the result matrix

        ' TODO: Task 4 Display the result
        ' Display the results of your calculation in the third Grid
    End Sub

    ''' <summary>
    ''' Retrieve data from the grid and put it in the array representing the matrix
    ''' </summary>
    ''' <param name="grid1">WPF Grid control holding matrix data</param>
    ''' <param name="matrix">Matrix array to store the values</param>
    Private Sub getValuesFromGrid(ByVal grid1 As Grid, ByVal matrix(,) As Double)
        ' Set up counters
        Dim columns As Integer = grid1.ColumnDefinitions.Count
        Dim rows As Integer = grid1.RowDefinitions.Count

        ' We should check that the grid has the same dimensions as the array
        ' (See Module 4)

        ' Iterate over cells in Grid, copying to matrix array
        For c As Integer = 0 To grid1.Children.Count - 1
            Dim t As TextBox = CType(grid1.Children(c), TextBox)
            Dim row As Integer = Grid.GetRow(t)
            Dim column As Integer = Grid.GetColumn(t)
            matrix(column, row) = Double.Parse(t.Text)
        Next
    End Sub
End Class
