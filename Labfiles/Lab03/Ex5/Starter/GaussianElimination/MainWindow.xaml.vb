Class MainWindow
    ''' <summary>
    ''' Solve the simulatneous equations
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SolveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Array to hold the coefficients of the equations
        Dim coefficients(,) As Double
        ReDim coefficients(Gauss.numberOfEquations, Gauss.numberOfEquations)


        ' Array to hold the constants (Right Hand Side)
        Dim rhs() As Double
        ReDim rhs(Gauss.numberOfEquations)

        ' Array to hold the solution values
        Dim answers() As Double
        ReDim answers(Gauss.numberOfEquations)

        ' Get the user entered data
        CollectAndValidateInput(coefficients, rhs)

        ' TODO Exercise 5, Task 5
        ' Invoke the solveGaussian method

        ' Display the results
        DisplayResults(answers)
    End Sub

    ''' <summary>
    ''' Read the user entered data
    ''' </summary>
    ''' <param name="coefficients">Coefficients for all equations</param>
    ''' <param name="rhs">Constants for all equations</param>
    ''' <remarks></remarks>
    Private Sub CollectAndValidateInput(ByVal coefficients(,) As Double, ByVal rhs() As Double)
        If Not GetDoubleFromTextBox(w1TextBox, coefficients(0, 0)) Then Return
        If Not GetDoubleFromTextBox(x1TextBox, coefficients(0, 1)) Then Return
        If Not GetDoubleFromTextBox(y1TextBox, coefficients(0, 2)) Then Return
        If Not GetDoubleFromTextBox(z1TextBox, coefficients(0, 3)) Then Return
        If Not GetDoubleFromTextBox(w2TextBox, coefficients(1, 0)) Then Return
        If Not GetDoubleFromTextBox(x2TextBox, coefficients(1, 1)) Then Return
        If Not GetDoubleFromTextBox(y2TextBox, coefficients(1, 2)) Then Return
        If Not GetDoubleFromTextBox(z2TextBox, coefficients(1, 3)) Then Return
        If Not GetDoubleFromTextBox(w3TextBox, coefficients(2, 0)) Then Return
        If Not GetDoubleFromTextBox(x3TextBox, coefficients(2, 1)) Then Return
        If Not GetDoubleFromTextBox(y3TextBox, coefficients(2, 2)) Then Return
        If Not GetDoubleFromTextBox(z3TextBox, coefficients(2, 3)) Then Return
        If Not GetDoubleFromTextBox(w4TextBox, coefficients(3, 0)) Then Return
        If Not GetDoubleFromTextBox(x4TextBox, coefficients(3, 1)) Then Return
        If Not GetDoubleFromTextBox(y4TextBox, coefficients(3, 2)) Then Return
        If Not GetDoubleFromTextBox(z4TextBox, coefficients(3, 3)) Then Return

        If Not GetDoubleFromTextBox(r1TextBox, rhs(0)) Then Return
        If Not GetDoubleFromTextBox(r2TextBox, rhs(1)) Then Return
        If Not GetDoubleFromTextBox(r3TextBox, rhs(2)) Then Return
        If Not GetDoubleFromTextBox(r4TextBox, rhs(3)) Then Return

        ' Display formatted versions of the equations
        Me.Equation1Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(0, 0), coefficients(0, 1), coefficients(0, 2), coefficients(0, 3), rhs(0))
        Me.Equation2Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(1, 0), coefficients(1, 1), coefficients(1, 2), coefficients(1, 3), rhs(1))
        Me.Equation3Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(2, 0), coefficients(2, 1), coefficients(2, 2), coefficients(2, 3), rhs(2))
        Me.Equation4Label.Content = String.Format("{0}w + {1}x + {2}y + {3}z = {4}", coefficients(3, 0), coefficients(3, 1), coefficients(3, 2), coefficients(3, 3), rhs(3))
    End Sub

    ''' <summary>
    ''' Try to parse the contents of a TextBox as a double.
    ''' Displays a message box with the data if the text can't be parsed.
    ''' </summary>
    ''' <param name="inputTextBox">TextBox to parse</param>
    ''' <param name="d">Double value (as output parameter)</param>
    ''' <returns>True if it succeeds, false otherwise</returns>
    ''' <remarks></remarks>
    Private Function GetDoubleFromTextBox(ByVal inputTextBox As TextBox, ByRef d As Double) As Boolean
        If Not Double.TryParse(inputTextBox.Text, d) Then
            MessageBox.Show("Data couldn't be parsed as a double: " & inputTextBox.Text)

            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Display formatted results
    ''' </summary>
    ''' <param name="answers">Array containing solution</param>
    ''' <remarks></remarks>
    Private Sub DisplayResults(ByVal answers() As Double)
        Me.ResultsLabel.Content = String.Format("w = {0}, x = {1}, y = {2}, z = {3}", answers(0), answers(1), answers(2), answers(3))
    End Sub
End Class